namespace AutoHostDiscoveryWorker
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using System.Xml;
    using Kamaji.Worker;
    using Newtonsoft.Json;

    //kendisi ip adreslerini bulduğu için asset e gerek yok ve IScanRepository' de gerek yok.
    internal class WindowsAutoHostDiscoveryWorker : INmapWorker
    {
        internal static readonly WindowsAutoHostDiscoveryWorker Instance = new WindowsAutoHostDiscoveryWorker();


        private async Task<HashSet<AutoDiscoveryModel>> Discover(IObserver observer, IEnumerable<string> ipList, string executablePath)
        {
            HashSet<AutoDiscoveryModel> list = new HashSet<AutoDiscoveryModel>();

            foreach (string ip in ipList)
            {
                if (ip != "localhost" && ip != "127.0.0.1")
                {
                    string xml;
                    var outputFile = Path.GetTempFileName();
                    using (var process = new Process())
                    {
                        using (var dis = new Disposable(() => File.Delete(outputFile)))
                        {
                            process.StartInfo.FileName = executablePath;
                            process.StartInfo.Arguments = $"-sP {ip}/24 -oX {outputFile}";
                            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                            process.StartInfo.CreateNoWindow = true;
                            process.StartInfo.RedirectStandardError = true;
                            process.StartInfo.RedirectStandardOutput = true;
                            process.Start();
                            process.WaitForExit();

                            using (var sourceReader = File.OpenText(outputFile))
                            {
                                xml = await sourceReader.ReadToEndAsync();
                            }
                        }
                    }
                    if (!String.IsNullOrEmpty(xml))
                    {
                        XmlDocument doc = new XmlDocument();
                        doc.LoadXml(xml);
                        var addressList = doc.GetElementsByTagName("address");

                        StringBuilder sb = new StringBuilder();
                        sb.Append("<addressList>");
                        foreach (XmlElement address in addressList)
                        {
                            sb.Append(address.OuterXml);
                        }
                        sb.Append("</addressList>");
                        XmlDocument customDoc = new XmlDocument();
                        customDoc.LoadXml(sb.ToString());


                        string json = JsonConvert.SerializeXmlNode(customDoc);
                        json = Regex.Replace(json, "(?<=\")(@)(?!.*\":\\s )", string.Empty, RegexOptions.IgnoreCase);


                        var models = JsonConvert.DeserializeObject<AddresListModel>(json);
                        if (null != models && null != models.AddressList && null != models.AddressList.Address)
                        {
                            int length = models.AddressList.Address.Length;
                            for (int j = 0; j < length; ++j)
                            {
                                var model = models.AddressList.Address[j];
                                if (model.Addrtype == "ipv4")
                                {
                                    AutoDiscoveryModel item = new AutoDiscoveryModel()
                                    {
                                        Address = model.Addr,
                                        //AddressType = model.Addrtype,
                                        Vendor = model.Vendor
                                    };
                                    if (j < length - 1)
                                    {
                                        var nextModel = models.AddressList.Address[j+1];
                                        if (nextModel.Addrtype == "mac")
                                        {
                                            item.Mac = nextModel.Addr;
                                            item.Vendor = nextModel.Vendor;
                                        }
                                    }
                                    observer.Notify(nameof(Worker) + "_" + nameof(Run), "Device Found:", item);
                                    list.Add(item);
                                }
                            }
                        }
                    }
                }
            }

            return list;
        }


        //private async Task Rec(IObserver observer, string executablePath, IEnumerable<string> ipList, HashSet<AutoDiscoveryModel> previousResults)
        //{
        //    HashSet<AutoDiscoveryModel> deviceList = await Discover(observer, ipList, executablePath);
        //    if (deviceList.Any())
        //    {
        //        deviceList = new HashSet<AutoDiscoveryModel>(deviceList.Where(l => !previousResults.Contains(l)));
        //        if (deviceList.Any())
        //        {
        //            //observer.Notify(nameof(Worker) + "_" + nameof(Run), "Auto host discovery is working now.", deviceList);

        //            deviceList.ToList().ForEach(i => previousResults.Add(i));
        //            await Rec(observer, executablePath, deviceList.Select(p => p.Address), previousResults);
        //        }
        //    }
        //}

        //public async Task<HashSet<AutoDiscoveryModel>> Run(IObserver observer, string asset, object args)
        //{
        //    string executablePath = Path.GetDirectoryName(this.GetType().Assembly.Location) + "\\nmap\\nmap";
        //    var ipList = Dns.GetHostEntry(String.Empty).AddressList.Where(p => p.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork);
        //    HashSet<AutoDiscoveryModel> deviceList = new HashSet<AutoDiscoveryModel>();
        //    await Rec(observer, executablePath, ipList.Select(i => i.ToString()), deviceList);
        //    return deviceList;
        //}

        public async Task<HashSet<AutoDiscoveryModel>> Run(IObserver observer, string asset, object args)
        {
            string executablePath = Path.GetDirectoryName(this.GetType().Assembly.Location) + "\\nmap\\nmap";
            var ipList = Dns.GetHostEntry(String.Empty).AddressList.Where(p => p.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork);
            HashSet<AutoDiscoveryModel> deviceList = await Discover(observer, ipList.Select(i => i.ToString()), executablePath);
            //var temp = JsonConvert.SerializeObject(list);

            return deviceList;
        }

    }
}
