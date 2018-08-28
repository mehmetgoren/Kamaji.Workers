namespace WebPageLinksWorker
{
    using Kamaji.Worker;
    using PuppeteerWorker;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public sealed class Worker : PuppeteerWorkerBase<Worker>
    {
        public override async Task<object> Run_Internal(ProxyObserver observer, RestClient http, string asset, IScanRepository repository, object args)
        {
            return await http.GetAsync<HashSet<string>>($"getAllLinks?site={asset}");
        }
    }
}
