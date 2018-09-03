namespace ProcessMonitoringWorker
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using Windows.Powershell.Json;

    internal class WindowsProcessMonitoring : IProcessMonitoring
    {
        public async Task<IEnumerable<ProcessInfo>> Run(string asset, object args)
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



            return list;
        }
    }
}
