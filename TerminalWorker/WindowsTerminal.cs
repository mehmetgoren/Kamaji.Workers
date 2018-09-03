using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace TerminalWorker
{
    class WindowsTerminal : ITerminal
    {
        public async Task<string> Run(string asset, object args)
        {
            string result = null;
            if (!String.IsNullOrEmpty(asset))
            {
                var startInfo = new ProcessStartInfo
                {
                    FileName = @"C:\Windows\System32\WindowsPowerShell\v1.0\powershell.exe",
                    Arguments = asset,
                    RedirectStandardOutput = true,
                    UseShellExecute = false
                };
                using (Process process = Process.Start(startInfo))
                {
                    result = (await process.StandardOutput.ReadToEndAsync())?.Trim();
                }
            }

            return result;
        }
    }
}
