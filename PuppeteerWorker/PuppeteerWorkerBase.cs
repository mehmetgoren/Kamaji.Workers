namespace PuppeteerWorker
{
    using Kamaji.Worker;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    
    //Generic yapılmasının sebebi het rip için ayrı static field lerin olması
    public abstract class PuppeteerWorkerBase<TDerived> : IWorker
        where TDerived : PuppeteerWorkerBase<TDerived>
    {
        protected static int Port { get; private set; }

        private static string ScriptFileName => "script";

        private (string, string) GetPaths()
        {
            string location = Path.GetDirectoryName(this.GetType().Assembly.Location);// Assembly.GetExecutingAssembly().Location);
            string scriptLocation = location + "\\";
            string jsPath = $"{scriptLocation}{ScriptFileName}.js";

            return (scriptLocation, jsPath);
        }

        private static bool _isInitialized;

        private static Process _nodeJsProcess;
        private void RunNodePuppeteer()
        {
            _isInitialized = false;
            _nodeJsProcess?.Kill();

            (string scriptLocation, string jsPath) = this.GetPaths();

            string[] jsLines = File.ReadAllLines(jsPath);
            StringBuilder js = new StringBuilder();
            foreach (string jsLine in jsLines)
            {
                if (!jsLine.StartsWith("app.listen("))
                {
                    js.Append(jsLine).AppendLine();
                }
            }

            Port = Utility.GenerateAnAvailablePort();
            js.Append($"app.listen({Port}, () => console.log('Example app listening on port {Port}!'));");

            File.WriteAllText(jsPath, js.ToString());

            string batFileName = scriptLocation + "\\start.bat";

            File.Delete(batFileName);
            StringBuilder batScript = new StringBuilder($"cd {scriptLocation}").AppendLine()
                .Append($"node {ScriptFileName}.js").AppendLine().Append("pause");
            File.WriteAllText(batFileName, batScript.ToString());

            var terminal = CreateTerminal();
            _nodeJsProcess = terminal.StartTerminalAndExecute(scriptLocation, Port);
            _isInitialized = true;
            _nodeJsProcess.WaitForExit();
        }

        public void Dispose()
        {
            if (_nodeJsProcess != null)
            {
                (string scriptLocation, string jsPath) = GetPaths();

                string js = File.ReadAllText(jsPath);
                string appJs = $"app.listen({Port}, () => console.log('Example app listening on port {Port}!'));";
                js = js.Replace(appJs, "");

                File.WriteAllText(jsPath, js);

                CreateTerminal().KillPrecessTree(_nodeJsProcess);
                //_nodeJsProcess.Kill();
            }
        }


        private static IPuppeteerTerminal CreateTerminal()
        {
            return RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? new WindowsPuppeteerTerminal() : throw new NotSupportedException();
        }


        private async Task<WorkerResult> ExecuteSafely<T>(Func<Task<T>> func)
        {
            try
            {
                return new WorkerResult(await func());
            }
            catch (Exception ex)
            {
                return new WorkerResult(null, false, ex.Message);
            }
        }


        public async Task SetupEnvironment()
        {
            LazyInitializer lazy = new LazyInitializer(() => Task.Run((Action)this.RunNodePuppeteer));
            lazy.Execute();
            while (!_isInitialized)
            {
                await Task.Delay(100);
            }
        }


        public Task<WorkerResult> Run(IObserver observer, string asset, IScanRepository repository, object args)
        {
            return this.ExecuteSafely(() =>
            {
                var http = new RestClient($"http://{Utility.GetIpv4Address()}:{Port}");
                return this.Run_Internal(ProxyObserver.Create(observer), http, asset, repository, args);
            });
        }

        //template method pattern
        public abstract Task<object> Run_Internal(ProxyObserver observer, RestClient http, string asset, IScanRepository repository, object args);




        private interface IPuppeteerTerminal
        {
            Process StartTerminalAndExecute(string scriptLocation, int port);
            void KillPrecessTree(Process process);
        }

        private sealed class WindowsPuppeteerTerminal : IPuppeteerTerminal
        {
            public Process StartTerminalAndExecute(string scriptLocation, int port)
            {
                var processInfo = new ProcessStartInfo($@"{scriptLocation}start.bat");
                processInfo.CreateNoWindow = true;
                processInfo.UseShellExecute = false;
                processInfo.RedirectStandardError = true;
                processInfo.RedirectStandardOutput = true;


                var ret = Process.Start(processInfo);
                Console.WriteLine("port available at " + port);
                return ret;
            }

            public void KillPrecessTree(Process process)
            {
                var pi = TaskManagerInfo.GetTaskManegerInfos().FirstOrDefault(p => p.PortNumber == Port.ToString());
                Process nodeProcess = Process.GetProcessById(pi.PID);
                nodeProcess?.Kill();


                process.Kill();//şu an için böyle ama linux ve windows' da bu yapı geliştirilsin çünkü kill etmiyor
            }



            private sealed class TaskManagerInfo
            {
                internal static List<TaskManagerInfo> GetTaskManegerInfos()
                {
                    var Ports = new List<TaskManagerInfo>();

                    try
                    {
                        using (Process p = new Process())
                        {

                            ProcessStartInfo ps = new ProcessStartInfo();
                            ps.Arguments = "-a -n -o";
                            ps.FileName = "netstat.exe";
                            ps.UseShellExecute = false;
                            ps.WindowStyle = ProcessWindowStyle.Hidden;
                            ps.RedirectStandardInput = true;
                            ps.RedirectStandardOutput = true;
                            ps.RedirectStandardError = true;

                            p.StartInfo = ps;
                            p.Start();

                            StreamReader stdOutput = p.StandardOutput;
                            StreamReader stdError = p.StandardError;

                            string content = stdOutput.ReadToEnd() + stdError.ReadToEnd();
                            string exitStatus = p.ExitCode.ToString();

                            if (exitStatus != "0")
                            {
                                // Command Errored. Handle Here If Need Be
                            }

                            //Get The Rows
                            string[] rows = Regex.Split(content, "\r\n");
                            foreach (string row in rows)
                            {
                                //Split it baby
                                string[] tokens = Regex.Split(row, "\\s+");
                                if (tokens.Length > 4 && (tokens[1].Equals("UDP") || tokens[1].Equals("TCP")))
                                {
                                    string localAddress = Regex.Replace(tokens[2], @"\[(.*?)\]", "1.1.1.1");
                                    Ports.Add(new TaskManagerInfo
                                    {
                                        PID = tokens[1] == "UDP" ? Convert.ToInt16(tokens[4]) : Convert.ToInt16(tokens[5]),
                                        Protocol = localAddress.Contains("1.1.1.1") ? String.Format("{0}v6", tokens[1]) : String.Format("{0}v4", tokens[1]),
                                        PortNumber = localAddress.Split(':')[1],
                                        ProcessName = tokens[1] == "UDP" ? LookupProcess(Convert.ToInt16(tokens[4])) : LookupProcess(Convert.ToInt16(tokens[5]))
                                    });
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    return Ports;
                }
                private static string LookupProcess(int pid)
                {
                    string procName;
                    try { procName = Process.GetProcessById(pid).ProcessName; }
                    catch (Exception) { procName = "-"; }
                    return procName;
                }



                public short PID { get; set; }

                public string Name => $"PID: '{this.PID}', Process Name: '{this.ProcessName}' ({this.Protocol} port {this.PortNumber})";
                public string PortNumber { get; set; }
                public string ProcessName { get; set; }
                public string Protocol { get; set; }

                public override string ToString() => this.Name;
            }

        }
    }

    //spider da bu observe edilecek.
    public sealed class ProxyObserver : IObserver
    {
        public static ProxyObserver Create(IObserver concrete) => new ProxyObserver(concrete);

        private IObserver Concrete { get; }

        public ProxyObserver(IObserver concrete)
        {
            this.Concrete = concrete;
        }

        public void Notify(string id, string message, object args) => this.Concrete?.Notify(id, message, args);
    }
}
