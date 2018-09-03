namespace ProcessMonitoringWorker
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using System.Threading.Tasks;
    using Kamaji.Worker;


    public sealed class Worker : WorkerBase
    {
        private static IProcessMonitoring CreateTerminal()
        {
            return RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? new WindowsProcessMonitoring() : throw new NotSupportedException();
        }

        protected override async Task<object> Run_Internal(IObserver observer, string asset, IScanRepository repository, object args)
        {
            IProcessMonitoring monitoring = CreateTerminal();
            IEnumerable<ProcessInfo> results = await monitoring.Run(asset, args);

            observer.Notify("ProcessMonitoringWorker", "Ok.", null);

            return results;
        }

        public override Task SetupEnvironment() => Task.Delay(0);

        public override void Dispose() { }

    }
}
