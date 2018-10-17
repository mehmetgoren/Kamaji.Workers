namespace Openvas.Omp.Client
{
    using System.Xml.Serialization;


    // sadly all types must be public to support xml serialize via XmlSerializer.
    public static partial class Requests
    {
        public sealed class get_version { }

        public sealed class get_credentials { }

        public sealed class get_configs { }

        public sealed class get_nvt_families { }


        public class get_reports
        {
            [XmlAttribute("max_results")]
            public int MaxResults { get; set; } = 100000;

            [XmlAttribute("first_result")]
            public int FirstResult { get; set; } = 100000;

            [XmlAttribute("overrides")]
            public int Overrides { get; set; } = 1;

            [XmlAttribute("overrides_details")]
            public int OverridesDetails { get; set; } = 1;

            //[XmlAttribute("filter")]
            // public string filter { get; set; } = "first=1 rows=-1 apply_overrides=1 notes=1 sort-reverse=severity";

            [XmlAttribute("report_id")]
            public string ReportId { get; set; }// = "4e1adb68-a2f7-409a-8393-926e9c8c7821";

            [XmlAttribute("report_filter")]
            public string ReportFilter { get; set; } = "first=1 rows=100000 apply_overrides=1 notes=1 sort-reverse=severity max=100000";//"min_qod=70 first=1 rows=1000 apply_overrides=1 notes=1 sort-reverse=severity max=100000"
        }


        public class get_results
        {
            [XmlAttribute("result_id")]
            public string ResultId { get; set; }

            [XmlAttribute("task_id")]
            public string TaskId { get; set; }

            [XmlAttribute("overrides")]
            public int Overrides { get; set; } = 1;

            [XmlAttribute("notes")]
            public int Notes { get; set; } = 1;

            [XmlAttribute("notes_details")]
            public int NotesDetails { get; set; } = 1;

            [XmlAttribute("details ")]
            public int Details { get; set; } = 1;

            [XmlAttribute("overrides_details")]
            public int OverridesDetails { get; set; } = 1;

            [XmlAttribute("apply_overrides")]
            public int ApplyOverrides { get; set; } = 1;



            [XmlAttribute("filter")]//???????
            public string Filter { get; set; } = "apply_overrides=1 min_qod=70 first=1 rows=1000 sort-reverse=severity";//"min_qod=70 first=1 rows=1000 apply_overrides=1 notes=1 sort-reverse=severity max=100000"
        }


        public class get_targets
        {
            [XmlAttribute("target_id")]
            public string TargetId { get; set; }

            [XmlAttribute("tasks")]
            public int Tasks { get; set; } = -1;
        }

        public class get_tasks
        {
            [XmlAttribute("task_id")]
            public string TaskId { get; set; }

            [XmlAttribute("details")]
            public string Details { get; set; }

            [XmlAttribute("apply_overrides")]
            public string ApplyOverrides { get; set; }

            [XmlAttribute("sort_order")]
            public string SortOrder { get; set; }

            [XmlAttribute("sort_field")]
            public string SortField { get; set; }

            [XmlAttribute("filter")]
            public string Filter { get; set; } = "apply_overrides=0 min_qod=70 first=1 rows=1000 sort=name";
        }


        public class get_scanners
        {
            [XmlAttribute("scanner_id")]
            public string ScannerId { get; set; }


            [XmlAttribute("filt_id")]
            public string FiltId { get; set; }

            //[XmlAttribute("trash")]
            //public int Trash { get; set; } = 1;

            [XmlAttribute("details")]
            public int Details { get; set; } = 1;

            [XmlAttribute("filter")]
            public string Filter { get; set; } = "apply_overrides=0 min_qod=70 first=1 rows=1000 sort=name";
        }
    }
}
