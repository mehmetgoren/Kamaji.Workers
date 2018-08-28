namespace WebPageHtmlSourceWorker
{
    using Kamaji.Worker;
    using PuppeteerWorker;
    using System.Threading.Tasks;


    public sealed class Worker : PuppeteerWorkerBase<Worker>
    {
        public override async Task<object> Run_Internal(ProxyObserver observer, RestClient http, string asset, IScanRepository repository, object args)
        {
            Result result = await http.GetAsync<Result>($"getHtmlSource?site={asset}");
            observer.Notify("WebPageHthm", "got Html Source", null);
            return result?.html;
        }

        private sealed class Result
        {
            public string html { get; set; }
        }
    }

}
