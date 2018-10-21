namespace OwaspWorker
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using Kamaji.Worker;
    using Newtonsoft.Json;
    using OWASPZAPDotNetAPI;

    public sealed class Worker : WorkerBase
    {
        public override void Dispose()
        {
        }

        public override Task SetupEnvironment() => Task.Delay(0);

        protected override async Task<object> Run_Internal(IObserver observer, string asset, IScanRepository repository,
            object args)
        {
            ReportResponse ret = null;
            if (!String.IsNullOrEmpty(asset) && args is IDictionary<string, object> dic)
            {
                string owaspIp = dic[nameof(owaspIp)]?.ToString();
                string owaspPort = dic[nameof(owaspPort)]?.ToString();
                if (!String.IsNullOrEmpty(owaspIp) && !String.IsNullOrEmpty(owaspPort))
                {
                    ClientApi api = new ClientApi(owaspIp, Convert.ToInt32(owaspPort), null);

                     var scanId = ((ApiResponseElement)api.spider.scan(asset, "5", "true", "", "false")).Value;
                    await Progress(observer, "Spider", () => Convert.ToInt32(((ApiResponseElement)api.spider.status(scanId)).Value));

                    var response = api.ascan.scan(asset, "", "", "", "", "", "");
                    await Progress(observer, "Active Scan", () => Convert.ToInt32(((ApiResponseElement)api.ascan.status(scanId)).Value));

                    byte[] report = api.core.jsonreport();

                    string json = Encoding.UTF8.GetString(report);

                    ret = JsonConvert.DeserializeObject<ReportResponse>(json);
                }
            }

            return ret;
        }

        static async Task Progress(IObserver observer, string name, Func<int> fn)
        {
            while (true)
            {
                await Task.Delay(1000);
                int progress = fn();
                observer?.Notify("", $"{name} progress: {progress}%",null);
                if (progress >= 100)
                    break;
            }
        }
    }
}
