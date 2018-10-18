namespace ArachniWorker
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Arachni.RestApi.Client;
    using Arachni.RestApi.Client.Models;
    using Kamaji.Worker;

    public sealed class Worker : WorkerBase
    {
        protected override async Task<object> Run_Internal(IObserver observer, string asset, IScanRepository repository, object args)
        {
            ReportResponse ret = null;
            if (!String.IsNullOrEmpty(asset) && args is IDictionary<string, object> dic)
            {
                string arachniRestApiAddress = dic[nameof(arachniRestApiAddress)]?.ToString();
                if (!String.IsNullOrEmpty(arachniRestApiAddress))
                {
                    ArachniApi api = new ArachniApi(arachniRestApiAddress);
                    string id = await api.NewScan(PostRequest.Create(asset));
                    if (!String.IsNullOrEmpty(id))
                    {
                        while (true)
                        {
                            await Task.Delay(1000);

                            SummaryResponse summary = await api.GetSummary(id);
                            if (null != summary && null != summary.Status)
                            {
                                observer?.Notify("Arachni_" + asset, $"Status: {summary.Status}, request: {summary.Statistics?.Http?["request_count"]}, runtime: {summary.Statistics?.Runtime}", null);

                                if (summary.Status == "done")
                                {
                                    ret = await api.GetReport(id);
                                    observer?.Notify("Arachni_" + asset, $"{asset} scan has been completed", null);
                                    break;
                                }
                            }
                            else
                                break;
                        }
                    }
                }
            }

            return ret;
        }

        public override Task SetupEnvironment() => Task.Delay(0);
        public override void Dispose() { }
    }
}
