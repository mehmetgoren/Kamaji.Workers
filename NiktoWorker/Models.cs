namespace NiktoWorker
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Newtonsoft.Json;
    //using System;

    public sealed class CreateScanRequest
    {
        [JsonProperty("asset")]
        public string Asset { get; set; }
    }


    public class CreateScanResponse
    {
        [JsonProperty("id0")]
        public string Id0 { get; set; }

        [JsonProperty("id1")]
        public string Id1 { get; set; }
    }


    internal sealed class GetResultResponseUgly
    {
        [JsonProperty("niktoscan")]
        public NiktoscanInfo Niktoscan { get; set; }

        public sealed class NiktoscanInfo
        {
            [JsonProperty("$")]
            public NiktoscanClass Empty { get; set; }

            [JsonProperty("scandetails")]
            public ScandetailElement[] Scandetails { get; set; }
        }

        public sealed class NiktoscanClass
        {
            [JsonProperty("hoststest")]
            public int Hoststest { get; set; }

            [JsonProperty("options")]
            public string Options { get; set; }

            [JsonProperty("version")]
            public string Version { get; set; }

            [JsonProperty("scanstart")]
            public string Scanstart { get; set; }

            [JsonProperty("scanend")]
            public string Scanend { get; set; }

            [JsonProperty("scanelapsed")]
            public string Scanelapsed { get; set; }

            [JsonProperty("nxmlversion")]
            public string Nxmlversion { get; set; }
        }

        public sealed class ScandetailElement
        {
            [JsonProperty("$")]
            public Scandetail Empty { get; set; }

            [JsonProperty("ssl")]
            public SslElement[] Ssl { get; set; }

            [JsonProperty("item")]
            public ItemElement[] Item { get; set; }

            [JsonProperty("statistics")]
            public StatisticElement[] Statistics { get; set; }
        }

        public sealed class Scandetail
        {
            [JsonProperty("targetip")]
            public string Targetip { get; set; }

            [JsonProperty("targethostname")]
            public string Targethostname { get; set; }

            [JsonProperty("targetport")]
            public int Targetport { get; set; }

            [JsonProperty("targetbanner")]
            public string Targetbanner { get; set; }

            [JsonProperty("starttime")]
            public DateTimeOffset Starttime { get; set; }

            [JsonProperty("sitename")]
            public string Sitename { get; set; }

            [JsonProperty("siteip")]
            public string Siteip { get; set; }

            [JsonProperty("hostheader")]
            public string Hostheader { get; set; }

            [JsonProperty("errors")]
            public int Errors { get; set; }

            [JsonProperty("checks")]
            public int Checks { get; set; }
        }

        public sealed class ItemElement
        {
            [JsonProperty("$")]
            public Item Empty { get; set; }

            [JsonProperty("description")]
            public string[] Description { get; set; }

            [JsonProperty("uri")]
            public string[] Uri { get; set; }

            [JsonProperty("namelink")]
            public string[] Namelink { get; set; }

            [JsonProperty("iplink")]
            public string[] Iplink { get; set; }
        }

        public sealed class Item
        {
            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("osvdbid")]
            public string Osvdbid { get; set; }

            [JsonProperty("osvdblink")]
            public string Osvdblink { get; set; }

            [JsonProperty("method")]
            public string Method { get; set; }
        }

        public sealed class SslElement
        {
            [JsonProperty("$")]
            public Ssl Empty { get; set; }
        }

        public sealed class Ssl
        {
            [JsonProperty("ciphers")]
            public string Ciphers { get; set; }

            [JsonProperty("issuers")]
            public string Issuers { get; set; }

            [JsonProperty("info")]
            public string Info { get; set; }

            [JsonProperty("altnames")]
            public string Altnames { get; set; }
        }

        public sealed class StatisticElement
        {
            [JsonProperty("$")]
            public Statistic Empty { get; set; }
        }

        public sealed class Statistic
        {
            [JsonProperty("elapsed")]
            public int Elapsed { get; set; }

            [JsonProperty("itemsfound")]
            public string Itemsfound { get; set; }

            [JsonProperty("itemstested")]
            public int Itemstested { get; set; }

            [JsonProperty("endtime")]
            public DateTimeOffset Endtime { get; set; }
        }


        private static void CopyPropertiesFrom(object destObject, object sourceObject)
        {
            if (null == destObject)
                throw new ArgumentNullException(nameof(destObject));
            if (null == sourceObject)
                throw new ArgumentNullException(nameof(sourceObject));

            foreach (PropertyInfo sourcePi in sourceObject.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public))
            {
                PropertyInfo destPi = destObject.GetType().GetProperty(sourcePi.Name, BindingFlags.Instance | BindingFlags.Public);
                if (null != destPi && null != destPi.SetMethod)
                {
                    object sourcePropertyValue = sourcePi.GetValue(sourceObject);
                    destPi.SetValue(destObject, sourcePropertyValue, null);
                }
            }
        }
        public GetResultResponse Beatify()
        {
            GetResultResponse ret = new GetResultResponse();
            if (null != this.Niktoscan)
            {
                if (null != this.Niktoscan.Empty)
                {
                    ret.Info = new GetResultResponse.BasicInfo();
                    CopyPropertiesFrom(ret.Info, this.Niktoscan.Empty);
                }

                if (null != this.Niktoscan.Scandetails && 0 != this.Niktoscan.Scandetails.Length)
                {
                    var first = this.Niktoscan.Scandetails[0];
                    if (null != first.Empty)
                    {
                        CopyPropertiesFrom(ret.Info, first.Empty);
                    }

                    if (null != first.Ssl && 0 != first.Ssl.Length)
                    {
                        var f1 = first.Ssl[0]?.Empty;
                        if (null != f1)
                        {
                            ret.Ssl = new GetResultResponse.SslInfo();
                            CopyPropertiesFrom(ret.Ssl, f1);
                        }
                    }
                    if (null != first.Statistics && 0 != first.Statistics.Length)
                    {
                        var f1 = first.Statistics[0]?.Empty;
                        if (null != f1)
                        {
                            ret.Statistics = new GetResultResponse.StatisticsInfo();
                            CopyPropertiesFrom(ret.Statistics, f1);
                        }
                    }

                    if (null != first.Item && 0 != first.Item.Length)
                    {
                        ret.Items = new List<GetResultResponse.Item>();
                        foreach (var item in first.Item)
                        {
                            GetResultResponse.Item i = new GetResultResponse.Item();
                            if (null != item.Empty)
                            {
                                CopyPropertiesFrom(i, item.Empty);
                            }

                            i.Description = item.Description?.FirstOrDefault();
                            i.Uri = item.Uri?.FirstOrDefault();
                            i.Namelink = item.Namelink?.FirstOrDefault();
                            i.Iplink = item.Iplink?.FirstOrDefault();

                            ret.Items.Add(i);
                        }
                    }
                }
            }

            return ret;
        }
    }


    public sealed class GetResultResponse
    {
        public sealed class BasicInfo
        {
            [JsonProperty("hoststest")]
            public int Hoststest { get; set; }

            [JsonProperty("options")]
            public string Options { get; set; }

            [JsonProperty("version")]
            public string Version { get; set; }

            [JsonProperty("scanstart")]
            public string Scanstart { get; set; }

            [JsonProperty("scanend")]
            public string Scanend { get; set; }

            [JsonProperty("scanelapsed")]
            public string Scanelapsed { get; set; }

            [JsonProperty("nxmlversion")]
            public string Nxmlversion { get; set; }

            [JsonProperty("targetip")]
            public string Targetip { get; set; }

            [JsonProperty("targethostname")]
            public string Targethostname { get; set; }

            [JsonProperty("targetport")]
            public int Targetport { get; set; }

            [JsonProperty("targetbanner")]
            public string Targetbanner { get; set; }

            [JsonProperty("starttime")]
            public DateTimeOffset Starttime { get; set; }

            [JsonProperty("sitename")]
            public string Sitename { get; set; }

            [JsonProperty("siteip")]
            public string Siteip { get; set; }

            [JsonProperty("hostheader")]
            public string Hostheader { get; set; }

            [JsonProperty("errors")]
            public int Errors { get; set; }

            [JsonProperty("checks")]
            public int Checks { get; set; }
        }
        public BasicInfo Info { get; set; }



        //ssl
        public sealed class SslInfo
        {
            [JsonProperty("ciphers")]
            public string Ciphers { get; set; }

            [JsonProperty("issuers")]
            public string Issuers { get; set; }

            [JsonProperty("info")]
            public string Info { get; set; }

            [JsonProperty("altnames")]
            public string Altnames { get; set; }
        }
        public SslInfo Ssl { get; set; }
        //


        public sealed class Item
        {
            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("osvdbid")]
            public string Osvdbid { get; set; }

            [JsonProperty("osvdblink")]
            public string Osvdblink { get; set; }

            [JsonProperty("method")]
            public string Method { get; set; }


            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("uri")]
            public string Uri { get; set; }

            [JsonProperty("namelink")]
            public string Namelink { get; set; }

            [JsonProperty("iplink")]
            public string Iplink { get; set; }
        }
        public List<Item> Items { get; set; }

        public sealed class StatisticsInfo
        {
            [JsonProperty("elapsed")]
            public int Elapsed { get; set; }

            [JsonProperty("itemsfound")]
            public string Itemsfound { get; set; }

            [JsonProperty("itemstested")]
            public int Itemstested { get; set; }

            [JsonProperty("endtime")]
            public DateTimeOffset Endtime { get; set; }
        }
        public StatisticsInfo Statistics { get; set; }
    }


    public sealed class StopScanRequest : CreateScanResponse
    {

    }
}
