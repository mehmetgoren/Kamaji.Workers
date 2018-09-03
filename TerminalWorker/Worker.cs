namespace TerminalWorker
{
    using System;
    using System.Runtime.InteropServices;
    using System.Threading.Tasks;
    using Kamaji.Worker;


    public sealed class Worker : WorkerBase
    {
        private static ITerminal CreateTerminal()
        {
            return RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? new WindowsTerminal() : throw new NotSupportedException();
        }

        protected override async Task<object> Run_Internal(IObserver observer, string asset, IScanRepository repository, object args)
        {
            ITerminal terminal = CreateTerminal();
            string result = await terminal.Run(asset, args);

            observer.Notify("TerminalWorker", "Ok.", args);

            return result;
        }

        public override Task SetupEnvironment() => Task.Delay(0);

        public override void Dispose() { }
    }
}
