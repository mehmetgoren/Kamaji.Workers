namespace ProcessMonitoringWorker
{
    using Kamaji.Worker;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    internal interface IProcessMonitoring
    {
        Task<IEnumerable<ProcessInfo>> Run(string asset, object args);
    }


    internal sealed class ProcessInfo
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long MemoryUsage { get; set; }
        public double CpuUsage { get; set; }

        public override string ToString() => $"{Id} {Name} {Description} {MemoryUsage} {CpuUsage}";
    }
}
