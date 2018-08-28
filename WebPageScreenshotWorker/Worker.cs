namespace WebPageScreenshotWorker
{
    using Kamaji.Worker;
    using PuppeteerWorker;
    using System.Threading.Tasks;

    public sealed class Worker : PuppeteerWorkerBase<Worker>
    {
        private sealed class JsonObject
        {
            public ScreenShot screenshot { get; set; }

            internal sealed class ScreenShot
            {
                public string type { get; set; }

                public byte[] data { get; set; }
            }
        }

        public override async Task<object> Run_Internal(ProxyObserver observer, RestClient http, string asset, IScanRepository repository, object args)
        {
            var img = await http.GetAsync<JsonObject>($"screenshot?site={asset}");
            return null != img ? img.screenshot?.data : null;
        }
    }
}
