namespace WebPageSpider
{
    using Kamaji.Worker;
    using Newtonsoft.Json;
    using PuppeteerWorker;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public sealed class Worker : PuppeteerWorkerBase<Worker>
    {
        public override async Task<object> Run_Internal(ProxyObserver observer, RestClient http, string asset, IScanRepository repository, object args)
        {
            if (String.IsNullOrWhiteSpace(asset) || IsLinkFile(asset))
                return new List<string>();

           // asset = CleanURL(asset);

            HashSet<string> temp = await http.GetAsync<HashSet<string>>($"getAllLinks?site={asset}");
            if (null == temp)
                return new List<string>();

            HashSet<string> temp2 = new HashSet<string>();
            foreach (var link in temp)
            {
                if (!String.IsNullOrEmpty(link))
                {
                    if (_badChars.Contains(link[link.Length - 1]))
                    {
                        string fixedLink = link.Remove(link.Length - 1);
                        temp2.Add(fixedLink);
                    }
                    else
                    {
                        temp2.Add(link);
                    }
                }
            }

            IEnumerable<string> links = temp2;
            if (null != links && links.Any())
            {
                var yuri = new Uri(asset);
                string host = yuri.Scheme + "://" + yuri.Host;
                links = links.Where(link => link.StartsWith(host) && !IsLinkFile(link));//sadece host adıyla başlayanları al.
                if (links.Any())
                {
                    IEnumerable<string> previousResults = await repository.GetResults(true, true);
                    HashSet<string> doNotIncludeThose = new HashSet<string>();
                    foreach (string result in previousResults)
                    {
                        try
                        {
                            var list = JsonConvert.DeserializeObject<List<string>>(result);
                            list.ForEach(i => doNotIncludeThose.Add(i));
                        }
                        catch { }
                    }

                    links = links.Where(l => !doNotIncludeThose.Contains(l));

                    _ = repository.AddChildScan(asset, links);//clild' lari ekle asekron olarak.

                    observer.Notify(nameof(Worker) + "_" + nameof(Run), "The Spider is working now.", links);
                }
            }

            return links;
        }


        private static readonly HashSet<string> _imgeXtensions = new HashSet<string> { "bmp","jpg","gif","tiff","png", "zip","pdf","svg","mp3","eps","wav" };
        private static bool IsLinkFile(string url)
        {
            if (url.Length > 4)
            {
                string[] split = url.Split('.');
                if (split.Length > 1)
                {
                    string extension = split[split.Length - 1]; 
                    return _imgeXtensions.Contains(extension.ToLower());
                }

            }

            return false;
        }


        private static readonly HashSet<char> _badChars = new HashSet<char>
        {
            '!',
            '@',
            '#',
            '$',
            '%',
            '^',
            '&',
            '*',
            '(',
            ')',
            '+',
            '=',
            '{',
            '[',
            ']',
            '}',
            '|',
            '\\',
            ';',
            '\'',
            '<',
            '>',
            ',',
            '`',
            '~',
            '/',
            '?'
        };

    }
}
