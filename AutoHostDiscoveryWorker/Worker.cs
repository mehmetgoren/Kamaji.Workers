namespace AutoHostDiscoveryWorker
{
    using Kamaji.Worker;
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using System.Threading.Tasks;

    public class Worker : WorkerBase
    {
        public override void Dispose() { }

        public override Task SetupEnvironment() => Task.Delay(0);

        protected override async Task<object> Run_Internal(IObserver observer, string asset, IScanRepository repository, object args) => await CreateNmap().Run(observer, asset, args);

        private static INmapWorker CreateNmap() => RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? WindowsAutoHostDiscoveryWorker.Instance : throw new NotSupportedException();
    }

    internal interface INmapWorker
    {
        Task<HashSet<AutoDiscoveryModel>> Run(IObserver observer, string asset, object args);
    }


    internal sealed class Disposable : IDisposable
    {
        private Action OnDispose { get; }
        internal Disposable(Action onDispose)
        {
            this.OnDispose = onDispose;
        }
        public void Dispose()
        {
            try
            {
                this.OnDispose();
            }
            catch { }
        }
    }
}
