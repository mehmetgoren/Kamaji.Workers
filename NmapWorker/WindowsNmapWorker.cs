namespace NmapWorker
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Threading.Tasks;
    using Kamaji.Worker;

    internal class WindowsNmapWorker : INmapWorker
    {
        internal static readonly WindowsNmapWorker Instance = new WindowsNmapWorker();

        public async Task<string> Run(IObserver observer, string asset, object args)
        {
            string LocateExecutable()
            {
                string location = Path.GetDirectoryName(this.GetType().Assembly.Location);
               // string upLocation = Path.GetFullPath(Path.Combine(location, @"..\")); no need a prereq.

                return location + "//nmap//nmap.exe";
                //string path = Environment.GetEnvironmentVariable("path");
                //string[] folders = path.Split(';');

                //foreach (string folder in folders)
                //{
                //    string combined = System.IO.Path.Combine(folder, "nmap.exe");
                //    if (File.Exists(combined))
                //    {
                //        return combined;
                //    }
                //}

                //return string.Empty;
            }
            string xml = "";
            if (!String.IsNullOrEmpty(asset))
            {
                var outputFile = Path.GetTempFileName();
                if (!asset.Contains("-oX"))
                {
                    asset += $" -oX {outputFile}";
                }

                using (var process = new Process())
                {
                    using (var dis = new Disposable(() => File.Delete(outputFile)))
                    {
                        process.StartInfo.FileName = LocateExecutable();
                        process.StartInfo.Arguments = asset;// $"-PS 127.0.0.1 -oX {outputFile}";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.CreateNoWindow = true;
                        // process.StartInfo.UseShellExecute = false;
                        process.StartInfo.RedirectStandardError = true;
                        process.StartInfo.RedirectStandardOutput = true;
                        process.Start();
                        process.WaitForExit();


                        using (var sourceReader = File.OpenText(outputFile))
                        {
                            xml = await sourceReader.ReadToEndAsync();
                        }

                        // string xml = File.ReadAllText(outputFile);

                        Console.WriteLine(xml);
                    }
                }
            }

            return xml;
        }
    }
}
