namespace PuppeteerWorker
{
    using Newtonsoft.Json;
    using System;
    using System.Net.Http;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    public class RestClient
    {
        public string Host { get; }

        public RestClient(string host)
        {
            this.Host = host ?? throw new ArgumentNullException(nameof(host));
        }


        public virtual async Task<T> GetAsync<T>(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                client.Timeout = TimeSpan.FromHours(3);

                Uri uri = new Uri(this.Host + "/" + url);
                using (HttpResponseMessage response = await client.GetAsync(uri, CancellationToken.None))
                {
                    string json = await response.Content.ReadAsStringAsync();
                    return String.IsNullOrEmpty(json) ? default(T) : JsonConvert.DeserializeObject<T>(json);
                }
            }
        }



        public virtual async Task<T> PostAsync<T>(string url, object data)
        {
            using (HttpClient client = new HttpClient())
            {
                client.Timeout = TimeSpan.FromHours(3);

                Uri uri = new Uri(this.Host + "/" + url);

                var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

                using (HttpResponseMessage response = await client.PostAsync(uri, content, CancellationToken.None))
                {
                    string json = await response.Content.ReadAsStringAsync();
                    return String.IsNullOrEmpty(json) ? default(T) : JsonConvert.DeserializeObject<T>(json);
                }
            }
        }

    }
}
