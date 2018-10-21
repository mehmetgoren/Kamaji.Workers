namespace OwaspWorker
{
    using System;
    using Newtonsoft.Json;

    public sealed class ReportResponse
    {
        [JsonProperty("@version")]
        public string Version { get; set; }

        [JsonProperty("@generated")]
        public string Generated { get; set; }

        [JsonProperty("site")]
        public SiteInfo[] Site { get; set; }


        public sealed class SiteInfo
        {
            [JsonProperty("@name")]
            public Uri Name { get; set; }

            [JsonProperty("@host")]
            public string Host { get; set; }

            [JsonProperty("@port")]
            public int Port { get; set; }

            [JsonProperty("@ssl")]
            public bool Ssl { get; set; }

            [JsonProperty("alerts")]
            public Alert[] Alerts { get; set; }
        }

        public sealed class Alert
        {
            [JsonProperty("pluginid")]
            public int Pluginid { get; set; }

            [JsonProperty("alert")]
            public string AlertAlert { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("riskcode")]
            public int Riskcode { get; set; }

            [JsonProperty("confidence")]
            public int Confidence { get; set; }

            [JsonProperty("riskdesc")]
            public string Riskdesc { get; set; }

            [JsonProperty("desc")]
            public string Desc { get; set; }

            [JsonProperty("instances")]
            public Instance[] Instances { get; set; }

            [JsonProperty("count")]
            public int Count { get; set; }

            [JsonProperty("solution")]
            public string Solution { get; set; }

            [JsonProperty("reference")]
            public string Reference { get; set; }

            [JsonProperty("cweid")]
            public int Cweid { get; set; }

            [JsonProperty("wascid")]
            public int Wascid { get; set; }

            [JsonProperty("sourceid")]
            public int Sourceid { get; set; }

            [JsonProperty("otherinfo", NullValueHandling = NullValueHandling.Ignore)]
            public string Otherinfo { get; set; }
        }

        public sealed class Instance
        {
            [JsonProperty("uri")]
            public Uri Uri { get; set; }

            [JsonProperty("method")]
            public string Method { get; set; }

            [JsonProperty("param", NullValueHandling = NullValueHandling.Ignore)]
            public string Param { get; set; }

            [JsonProperty("evidence", NullValueHandling = NullValueHandling.Ignore)]
            public string Evidence { get; set; }
        }
    }
}
