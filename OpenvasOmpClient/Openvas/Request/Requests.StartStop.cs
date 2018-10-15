namespace OpenvasOmpClient
{
    using System.Xml.Serialization;

    partial class Requests
    {
        public sealed class start_task
        {
            [XmlAttribute("task_id")]
            public string TaskId { get; set; }
        }

        public sealed class stop_task
        {
            [XmlAttribute("task_id")]
            public string TaskId { get; set; }
        }

        public sealed class resume_task
        {
            [XmlAttribute("task_id")]
            public string TaskId { get; set; }
        }




        public sealed class sync_cert { }
        public sealed class sync_feed { }
        public sealed class sync_scap { }
    }
}
