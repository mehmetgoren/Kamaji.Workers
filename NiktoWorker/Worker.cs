namespace NiktoWorker
{
    using System.Threading.Tasks;
    using Kamaji.Worker;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Newtonsoft.Json;

    public sealed class Worker : WorkerBase
    {
        public override void Dispose() { }

        public override Task SetupEnvironment() => Task.Delay(0);

        protected override async Task<object> Run_Internal(IObserver observer, string asset, IScanRepository repository,
            object args)
        {
            GetResultResponse ret = null;
            if (!String.IsNullOrEmpty(asset) && args is IDictionary<string, object> dic)
            {
                string niktoRestApiAddress = dic[nameof(niktoRestApiAddress)]?.ToString();
                if (!String.IsNullOrEmpty(niktoRestApiAddress))
                {
                    NiktoApi api = new NiktoApi(niktoRestApiAddress);

                    var scan = await api.CreateScan(new CreateScanRequest { Asset = asset });

                    //testden sonra çıkar
                    await Task.Delay(10000);
                    var r = await api.StopScan(new StopScanRequest { Id0 = scan.Id0, Id1 = scan.Id1 });
                    //

                    while (true)
                    {
                       await Task.Delay(1000);

                        ret = api.GetResult(scan.Id0).Result;
                        if (null != ret)
                            break;
                    }
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
                observer?.Notify("", $"{name} progress: {progress}%", null);
                if (progress >= 100)
                    break;
            }
        }
    }
}
