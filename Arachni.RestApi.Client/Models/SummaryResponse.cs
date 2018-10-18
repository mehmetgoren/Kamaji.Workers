namespace Arachni.RestApi.Client.Models
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public sealed class SummaryResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("busy")]
        public bool Busy { get; set; }

        [JsonProperty("seed")]
        public string Seed { get; set; }

        [JsonProperty("statistics")]
        public StatisticsInfo Statistics { get; set; }

        [JsonProperty("messages")]
        public string[] Messages { get; set; }


        public sealed class StatisticsInfo
        {
            [JsonProperty("http")]
            public Dictionary<string, double> Http { get; set; }

            [JsonProperty("browser_cluster")]
            public BrowserCluster BrowserCluster { get; set; }

            [JsonProperty("runtime")]
            public double Runtime { get; set; }

            [JsonProperty("found_pages")]
            public int FoundPages { get; set; }

            [JsonProperty("audited_pages")]
            public int AuditedPages { get; set; }

            [JsonProperty("current_page")]
            public Uri CurrentPage { get; set; }
        }

        public sealed class BrowserCluster
        {
            [JsonProperty("seconds_per_job")]
            public double SecondsPerJob { get; set; }

            [JsonProperty("total_job_time")]
            public int TotalJobTime { get; set; }

            [JsonProperty("queued_job_count")]
            public int QueuedJobCount { get; set; }

            [JsonProperty("completed_job_count")]
            public int CompletedJobCount { get; set; }

            [JsonProperty("time_out_count")]
            public int TimeOutCount { get; set; }
        }
    }
}
