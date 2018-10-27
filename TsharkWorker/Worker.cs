namespace TsharkWorker
{
    using Kamaji.Worker;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    public sealed class Worker : WorkerBase
    {
        public override void Dispose() { }

        public override Task SetupEnvironment() => Task.Delay(0);

        public static async Task<string> GetNetworkDevices(string tsharkPath)
        {
            string ret = null;
            var startInfo = new ProcessStartInfo
            {
                FileName = tsharkPath,
                Arguments = "-D",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
            };

            using (Process process = Process.Start(startInfo))
            {

                ret = await process.StandardOutput.ReadToEndAsync();
                process.WaitForExit();
            }

            return ret;
        }


        private static bool isListining;
        private static readonly object synRoot = new object();
        private static void EnsureIsListining(string fileTemplate, string deviceId, string tsharkPath, int duration)
        {
            if (!isListining)
            {
                lock (synRoot)
                {
                    if (!isListining)
                    {
                        _ = StartListingNetworkDevice(fileTemplate, deviceId, tsharkPath, duration);
                        Thread.Sleep(250);
                        isListining = true;
                    }
                }
            }
        }

        private static async Task StartListingNetworkDevice(string fileTemplate, string deviceId, string tsharkPath, int duration)
        {
            string args = $"-i {deviceId} -w {fileTemplate}.pcap -b duration:{duration} -T fields -e frame.number -e frame.time -e eth.src -e eth.dst -e ip.src -e ip.dst -e ip.proto -e frame.len -E header=y -E separator=, -E quote=d -E occurrence=f";
            var startInfo = new ProcessStartInfo
            {
                FileName = tsharkPath,
                Arguments = args,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
            };

            using (Process process = Process.Start(startInfo))
            {
                string result = await process.StandardOutput.ReadToEndAsync();
                process.WaitForExit();
            }
            isListining = false;
        }

        private static async Task<IEnumerable<string>> ReadFiles(string fileTemplate, string tsharkPath)
        {
            List<string> ret = new List<string>();

            string directoryName = Path.GetDirectoryName(fileTemplate);
            string fileName = Path.GetFileName(fileTemplate);
            string[] filePaths = Directory.GetFiles(directoryName, $"{fileName}*.pcap");
            if (filePaths.Length > 1)
            {
                List<string> temp = new List<string>(filePaths);
                temp.Sort();
                temp.RemoveAt(temp.Count - 1);//so n dosya hala işleniyor.

                foreach (string filePath in filePaths)
                {
                    string args = $"-r {filePath} -T fields -e frame.number -e frame.time -e eth.src -e eth.dst -e ip.src -e ip.dst -e ip.proto -e frame.len -E header=y -E separator=; -E quote=d -E occurrence=f"; //$" -r {filePath} -T fields -e frame.number -e frame.time -e eth.src -e eth.dst -e ip.src -e ip.dst -e ip.proto -E header=y -E separator=, -E quote=d -E occurrence=f > {csvFileName}";
                    var startInfo = new ProcessStartInfo
                    {
                        FileName = tsharkPath,
                        Arguments = args,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        UseShellExecute = false,
                    };
                    //await Task.Delay(3000);
                    string result;
                    Process process = null;
                    try
                    {
                        process = Process.Start(startInfo);
                        result = await process.StandardOutput.ReadToEndAsync();
                        process.WaitForExit();
                        ret.Add(result);

                        File.Delete(filePath);
                    }
                    catch { }
                    finally
                    {
                        process?.Dispose();
                    }
                }
            }

            return ret;
        }

        protected override async Task<object> Run_Internal(IObserver observer, string asset, IScanRepository repository, object args)
        {
            List<TsharkModel> ret = new List<TsharkModel>();
            if (!String.IsNullOrEmpty(asset) && args is IDictionary<string, object> dic)
            {
                string deviceId = asset;
                string fileTemplate = dic[nameof(fileTemplate)]?.ToString();
                string tsharkPath = dic[nameof(tsharkPath)]?.ToString();//Belki linux' te vermiyoruzdur.
                string duration = dic[nameof(duration)]?.ToString();

                if (String.IsNullOrEmpty(fileTemplate))
                    fileTemplate = "tshark";
                if (String.IsNullOrEmpty(tsharkPath) || !int.TryParse(tsharkPath, out int d))
                    duration = "60";

                EnsureIsListining(fileTemplate, deviceId, tsharkPath, int.Parse(duration));

                //
                var files = await ReadFiles(fileTemplate, tsharkPath);
                foreach (string csv in files)
                {
                    IList<TsharkModel> modelList = TsharkModel.Deserialize(csv);
                    ret.AddRange(modelList);
                    observer?.Notify(deviceId, "Network Monitored", modelList);
                }
                //
            }

            return ret;
        }
    }
}
