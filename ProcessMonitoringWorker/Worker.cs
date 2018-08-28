namespace ProcessMonitoringWorker
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using Kamaji.Worker;
    using Powershell.Json;


    public sealed class Worker : WorkerBase
    {    
        protected override async Task<object> Run_Internal(IObserver observer, string asset, IScanRepository repository, object args)
        {
            List<ProcessInfo> list = new List<ProcessInfo>();

            string fileName = null;
            // string user, password; bunu uzak pc de test et.

            var dic = args as IDictionary<string, object>;
            if (null != dic)
            {
                if (dic.TryGetValue("fileName", out object temp1) && (null != temp1 && temp1 is string))
                {
                    fileName = temp1?.ToString();
                }
            }

            if (String.IsNullOrEmpty(fileName))
            {
                fileName = @"C:\Windows\System32\WindowsPowerShell\v1.0\powershell.exe";
            }

            var startInfo = new ProcessStartInfo
            {
                FileName = fileName,
                Arguments = "get-process | ConvertTo-Json",
                RedirectStandardOutput = true,
                UseShellExecute = false
            };
            using (Process process = Process.Start(startInfo))
            {
                string table = (await process.StandardOutput.ReadToEndAsync())?.Trim();

                try
                {
                    process.Kill();
                }
                catch { }

                if (!String.IsNullOrEmpty(table))
                {
                    var welcome = Welcome.FromJson(table);

                    if (null != welcome)
                    {
                        list.Capacity = welcome.Length;
                        foreach (var item in welcome)
                        {
                            ProcessInfo pi = new ProcessInfo();
                            pi.CpuUsage = item.Cpu ?? 0.0;
                            pi.Description = item.Description;
                            pi.Id = item.Id.ToString();
                            pi.MemoryUsage = item.PrivateMemorySize64;
                            pi.Name = item.Name;

                            list.Add(pi);
                        }
                    }
                }
            }

            observer.Notify("ProcessMonitoringWorker", "Ok.", null);

            return list;
        }

        public override Task SetupEnvironment() => Task.Delay(0);

        public override void Dispose() { }


        private sealed class ProcessInfo
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public long MemoryUsage { get; set; }
            public double CpuUsage { get; set; }

            public override string ToString() => $"{Id} {Name} {Description} {MemoryUsage} {CpuUsage}";
        }
    }
}
