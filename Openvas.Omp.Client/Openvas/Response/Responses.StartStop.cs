namespace Openvas.Omp.Client
{
    using Newtonsoft.Json;
    using System;

    partial class Responses
    {
        public sealed class start_task_response : Response
        {
            [JsonProperty("report_id")]
            public string[] ReportId { get; set; }

        }

        public sealed class stop_task_response : Response
        {

        }

        public sealed class resume_task_response : Response
        {
            [JsonProperty("report_id")]
            public string[] ReportId { get; set; }
        }







        public sealed class sync_cert_response : Response { }
        public sealed class sync_feed_response : Response { }
        public sealed class sync_scap_response : Response { }
    }
}
