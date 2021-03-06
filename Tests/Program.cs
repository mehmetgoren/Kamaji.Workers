﻿namespace Tests
{
    using System;
    using Newtonsoft.Json;
    using System.IO;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Threading;
    using System.Linq;
    using System.Diagnostics;

    static class Program
    {
        static async Task Main(string[] args) 
        {
            await AutoHostDiscoveryTest();
        }


        static async Task AutoHostDiscoveryTest()
        {
            FakeScanRepository rep = new FakeScanRepository();
            string json = "";
            using (Kamaji.Worker.IWorker worker = new AutoHostDiscoveryWorker.Worker())
            {
                var result = await worker.Run(ConsoleObserver.Instance,null, rep, null);
                json = result.Result?.ToString();
            }

            Console.WriteLine();
            Console.WriteLine("Done.");
        }

        static async Task NmapTest()
        {
            string json = "";
            using (Kamaji.Worker.IWorker worker = new NmapWorker.Worker())
            {
                var result = await worker.Run(ConsoleObserver.Instance, "-PS 127.0.0.1", null, null);
                json = result.Result?.ToString();
            }

            Console.WriteLine(json);
        }


        static async Task TsharkTest()
        {
            using (Kamaji.Worker.IWorker worker = new TsharkWorker.Worker())
            {
                dynamic dyn = new ExpandoObject();
                dyn.fileTemplate = "f:\\tshark";
                dyn.tsharkPath = @"C:\Program Files\Wireshark\tshark";
                dyn.duration = "13";

                while (true)
                {
                    var result = (List<TsharkWorker.TsharkModel>) (await worker.Run(ConsoleObserver.Instance, "2", null, dyn)).Result;

                    if (result.Count > 0)
                        await File.WriteAllTextAsync($"f:\\{DateTime.Now.Ticks}.json", JsonConvert.SerializeObject(result));
                    await Task.Delay(5000);
                }
            }
        }

        static async Task NiktoTest()
        {
            string json = "";
            using (Kamaji.Worker.IWorker worker = new NiktoWorker.Worker())
            {
                dynamic dyn = new ExpandoObject();
                dyn.niktoRestApiAddress = "http://192.168.0.31:3002";
                var result = await worker.Run(ConsoleObserver.Instance, "https://www.donanimhaber.com/", null, dyn);
                json = JsonConvert.SerializeObject(result.Result);
            }

            Console.WriteLine(json);
        }

        static async Task OwaspTest()
        {
            string json = "";
            using (Kamaji.Worker.IWorker worker = new OwaspWorker.Worker())
            {
                dynamic dyn = new ExpandoObject();
                dyn.owaspIp = "192.168.0.31";
                dyn.owaspPort = "8080";
                var result = await worker.Run(ConsoleObserver.Instance, "http://testhtml5.vulnweb.com", null, dyn);
                json = JsonConvert.SerializeObject(result.Result);
            }

            Console.WriteLine(json);
        }
        

        static async Task ArachniTest()
        {
            string json = "";
            using (Kamaji.Worker.IWorker worker = new ArachniWorker.Worker())
            {
                dynamic dyn = new ExpandoObject();
                dyn.arachniRestApiAddress = "http://192.168.0.31:3001";
                var result = await worker.Run(ConsoleObserver.Instance, "https://www.donanimhaber.com/", null, dyn);
                json = JsonConvert.SerializeObject(result.Result);
            }

            Console.WriteLine(json);
        }

        static async Task OpenvasTest()
        {
            string json = "";
            using (Kamaji.Worker.IWorker worker = new OpenvasWorker.Worker())
            {
                var result = await worker.Run(ConsoleObserver.Instance, "f0a098e5-f8a4-43de-8176-bb823f7c0c06", null, "http://192.168.0.31:3000");
                json = JsonConvert.SerializeObject(result.Result);
            }

            Console.WriteLine(json);
        }

        static async Task DollarsTest()
        {
            using (Kamaji.Worker.IWorker worker = new WebPageLinksWorker.Worker())
            {
                await worker.SetupEnvironment();

                var html = await worker.Run(ConsoleObserver.Instance, "http://www.cursedhardware.com/", null, null);

                Console.WriteLine(JsonConvert.SerializeObject(html.Result));

                Console.ReadKey();
            }

            CancellationTokenSource t = new CancellationTokenSource();


            _ = Task.Run(async () =>
            {
                using (Kamaji.Worker.IWorker worker = new Dollars.Worker())
                {
                    await worker.SetupEnvironment();
                    while (true)
                    {
                        var result = await worker.Run(ConsoleObserver.Instance, null, null, null);

                        IEnumerable<object> list = result.Result as IEnumerable<object>;
                        if (null != list)
                            (new List<object>(list)).ForEach(i => Console.WriteLine(JsonConvert.SerializeObject(i)));
                        else
                            Console.WriteLine(result.Result);

                        await Task.Delay(5000);

                        if (t.IsCancellationRequested)
                            break;
                    }
                }
            });

            Console.ReadKey();
            t.Cancel();
            Console.WriteLine("Kapandı");
            Console.ReadKey();
        }


        static async Task ProcessMonitoringTest()
        {
            using (Kamaji.Worker.IWorker worker = new ProcessMonitoringWorker.Worker())
            {
                var result = await worker.Run(ConsoleObserver.Instance, null, null, null);

                IEnumerable<object> list = result.Result as IEnumerable<object>;
                if (null != list)
                    (new List<object>(list)).ForEach(Console.WriteLine);
                else
                    Console.WriteLine(result.Result);

                Console.ReadKey();
            }
        }


        static async Task SpiderTest()
        {
            FakeScanRepository rep = new FakeScanRepository();


            using (Kamaji.Worker.IWorker worker = new WebPageSpider.Worker())
            {
                await worker.SetupEnvironment();

                async Task<Kamaji.Worker.WorkerResult> Result(string asset)
                {
                    var results = await worker.Run(ConsoleObserver.Instance, asset, rep, null);
                    await rep.AddChildScan(asset, results.Result as IEnumerable<string>);
                    return results;
                }


                await Result("http://toastytech.com/evil/");//"https://demos.telerik.com/aspnet-mvc/tripxpert/
                var links = await rep.GetResults(true, true);
                do
                {
                    foreach (var link in links)
                    {
                        await Result(link);
                        Console.WriteLine(rep.Dic.Count + " " + link);
                        await Task.Delay(150);
                    }
                    links = await rep.GetResults(true, true);
                    await Task.Delay(250);
                } while (links.Any());
            }
            Console.WriteLine();
            Console.WriteLine("its done");
            Console.WriteLine();
            foreach (var kvp in rep.Dic)
            {
                Console.WriteLine(kvp.Key);
            }
            Console.WriteLine();
            Console.ReadKey();
        }

        static async Task SimpleOnes()
        {
            using (Kamaji.Worker.IWorker worker = new WebPageLinksWorker.Worker())
            {
                await worker.SetupEnvironment();

                var html = await worker.Run(ConsoleObserver.Instance, "http://www.cursedhardware.com/", null, null);

                Console.WriteLine(html.Result);

                Console.ReadKey();
            }

            Console.Clear();
            using (Kamaji.Worker.IWorker worker = new WebPageScreenshotWorker.Worker())
            {
                await worker.SetupEnvironment();

                var html = await worker.Run(ConsoleObserver.Instance, "https://odatv.com/", null, null);

                Console.WriteLine(html.Result);

                File.WriteAllBytes("g:\\website_screenshot.png", html.Result as byte[]);

                Console.ReadKey();
            }

            Console.Clear();
            using (WebPageHtmlSourceWorker.Worker worker = new WebPageHtmlSourceWorker.Worker())
            {
                await worker.SetupEnvironment();

                // await Task.Delay(300);
                Stopwatch bench = Stopwatch.StartNew();
                var html = await worker.Run(ConsoleObserver.Instance, "https://www.donanimhaber.com/", null, null);
                bench.Stop();

                Console.WriteLine(html.Result);

                Console.WriteLine("\n\n\n\n\n");
                Console.WriteLine(bench.ElapsedMilliseconds);

                Console.ReadKey();
            }
        }

        // A connection attempt failed because the connected party did not properly respond after a period of time, or established connection failed because connected host has failed to respond
    }

    class ConsoleObserver : Kamaji.Worker.IObserver
    {
        public static ConsoleObserver Instance = new ConsoleObserver();

        public void Notify(string id, string message, object args)
        {
            var temp = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine($"{(!String.IsNullOrEmpty(id) ? id + " says : " : "")}'{message}', {(null != args ? JsonConvert.SerializeObject(args) : "")}");
            Console.ForegroundColor = temp;
        }
    }
}