namespace Openvas.Omp.Client
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Newtonsoft.Json;
    using Openvas.Omp.Client.Models;

    partial class Responses
    {
        public sealed class get_tasks_response : Response, IBeautiful<GetTasksResponse>
        {
            [JsonProperty("apply_overrides")]
            public int[] ApplyOverrides { get; set; }

            [JsonProperty("task")]
            public PurpleTask[] Task { get; set; }

            [JsonProperty("filters")]
            public FilterElement[] Filters { get; set; }

            [JsonProperty("sort")]
            public SortInfo[] Sort { get; set; }

            [JsonProperty("tasks")]
            public FluffyTask[] Tasks { get; set; }

            [JsonProperty("task_count")]
            public TaskCountInfo[] TaskCount { get; set; }


            public sealed class FilterElement
            {
                [JsonProperty("$")]
                public Filter Empty { get; set; }

                [JsonProperty("term")]
                public string[] Term { get; set; }

                [JsonProperty("keywords")]
                public FilterKeyword[] Keywords { get; set; }
            }

            public sealed class Filter
            {
                [JsonProperty("id")]
                public string Id { get; set; }
            }

            public sealed class FilterKeyword
            {
                [JsonProperty("keyword")]
                public KeywordKeyword[] Keyword { get; set; }
            }

            public sealed class KeywordKeyword
            {
                [JsonProperty("column")]
                public string[] Column { get; set; }

                [JsonProperty("relation")]
                public string[] Relation { get; set; }

                [JsonProperty("value")]
                public string[] Value { get; set; }
            }

            public sealed class SortInfo
            {
                [JsonProperty("field")]
                public Field[] Field { get; set; }
            }

            public sealed class Field
            {
                [JsonProperty("_")]
                public string Empty { get; set; }

                [JsonProperty("order")]
                public string[] Order { get; set; }
            }

            public sealed class PurpleTask
            {
                [JsonProperty("$")]
                public Filter Empty { get; set; }

                [JsonProperty("owner")]
                public Owner[] Owner { get; set; }

                [JsonProperty("name")]
                public string[] Name { get; set; }

                [JsonProperty("comment")]
                public string[] Comment { get; set; }

                [JsonProperty("creation_time")]
                public DateTimeOffset[] CreationTime { get; set; }

                [JsonProperty("modification_time")]
                public DateTimeOffset[] ModificationTime { get; set; }

                [JsonProperty("writable")]
                public int[] Writable { get; set; }

                [JsonProperty("in_use")]
                public int[] InUse { get; set; }

                [JsonProperty("permissions")]
                public Permission[] Permissions { get; set; }

                [JsonProperty("user_tags")]
                public UserTag[] UserTags { get; set; }

                [JsonProperty("alterable")]
                public int[] Alterable { get; set; }

                [JsonProperty("config")]
                public Config[] Config { get; set; }

                [JsonProperty("target")]
                public Config[] Target { get; set; }

                [JsonProperty("hosts_ordering")]
                public string[] HostsOrdering { get; set; }

                [JsonProperty("scanner")]
                public Config[] Scanner { get; set; }

                [JsonProperty("status")]
                public string[] Status { get; set; }

                [JsonProperty("progress")]
                public object[] Progress { get; set; }

                [JsonProperty("report_count")]
                public ReportCount[] ReportCount { get; set; }

                [JsonProperty("trend")]
                public string[] Trend { get; set; }

                [JsonProperty("schedule")]
                public Config[] Schedule { get; set; }

                [JsonProperty("schedule_periods")]
                public int[] SchedulePeriods { get; set; }

                [JsonProperty("first_report")]
                public StReport[] FirstReport { get; set; }

                [JsonProperty("last_report")]
                public StReport[] LastReport { get; set; }

                [JsonProperty("observers")]
                public string[] Observers { get; set; }

                [JsonProperty("result_count")]
                public int[] ResultCount { get; set; }

                [JsonProperty("preferences")]
                public TaskPreference[] Preferences { get; set; }
            }

            public sealed class Config
            {
                [JsonProperty("$")]
                public Filter Empty { get; set; }

                [JsonProperty("name")]
                public string[] Name { get; set; }

                [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
                public int[] Type { get; set; }

                [JsonProperty("trash")]
                public int[] Trash { get; set; }

                [JsonProperty("next_time", NullValueHandling = NullValueHandling.Ignore)]
                public string[] NextTime { get; set; }
            }

            public sealed class StReport
            {
                [JsonProperty("report")]
                public Report[] Report { get; set; }
            }

            public sealed class Report
            {
                [JsonProperty("$")]
                public Filter Empty { get; set; }

                [JsonProperty("timestamp")]
                public DateTimeOffset[] Timestamp { get; set; }

                [JsonProperty("scan_start")]
                public DateTimeOffset[] ScanStart { get; set; }

                [JsonProperty("scan_end")]
                public DateTimeOffset[] ScanEnd { get; set; }

                [JsonProperty("result_count")]
                public ResultCount[] ResultCount { get; set; }

                [JsonProperty("severity")]
                public string[] Severity { get; set; }
            }

            public sealed class ResultCount
            {
                [JsonProperty("debug")]
                public int[] Debug { get; set; }

                [JsonProperty("hole")]
                public int[] Hole { get; set; }

                [JsonProperty("info")]
                public int[] Info { get; set; }

                [JsonProperty("log")]
                public int[] Log { get; set; }

                [JsonProperty("warning")]
                public int[] Warning { get; set; }

                [JsonProperty("false_positive")]
                public int[] FalsePositive { get; set; }
            }

            public sealed class Owner
            {
                [JsonProperty("name")]
                public string[] Name { get; set; }
            }

            public sealed class Permission
            {
                [JsonProperty("permission")]
                public Owner[] PermissionPermission { get; set; }
            }

            public sealed class TaskPreference
            {
                [JsonProperty("preference")]
                public PreferencePreference[] Preference { get; set; }
            }

            public sealed class PreferencePreference
            {
                [JsonProperty("name")]
                public string[] Name { get; set; }

                [JsonProperty("scanner_name")]
                public string[] ScannerName { get; set; }

                [JsonProperty("value")]
                public string[] Value { get; set; }
            }

            public sealed class ReportCount
            {
                [JsonProperty("_")]
                public int Empty { get; set; }

                [JsonProperty("finished")]
                public int[] Finished { get; set; }
            }

            public sealed class UserTag
            {
                [JsonProperty("count")]
                public int[] Count { get; set; }
            }

            public sealed class TaskCountInfo
            {
                [JsonProperty("_")]
                public int Empty { get; set; }

                [JsonProperty("filtered")]
                public int[] Filtered { get; set; }

                [JsonProperty("page")]
                public int[] Page { get; set; }
            }

            public sealed class FluffyTask
            {
                [JsonProperty("$")]
                public Purple Empty { get; set; }
            }

            public sealed class Purple
            {
                [JsonProperty("max")]
                public int Max { get; set; }

                [JsonProperty("start")]
                public int Start { get; set; }
            }



            public GetTasksResponse Beautify()
            {
                GetTasksResponse beauty = null;
                if (this.Status.Status == "200")
                {
                    beauty = new GetTasksResponse();
                    if (null != this.Task)
                    {
                        beauty.Tasks = new List<GetTasksResponse.Task>();
                        foreach (var task in this.Task)
                        {
                            var t = new GetTasksResponse.Task();

                            t.Id = task.Empty?.Id;
                            t.Name = task.Name?.FirstOrDefault();
                            t.Owner = task.Owner?.FirstOrDefault()?.Name?.FirstOrDefault();
                            t.Comment = task.Comment?.FirstOrDefault();
                            t.CreationTime = task.CreationTime?.FirstOrDefault();
                            t.ModificationTime = task.ModificationTime?.FirstOrDefault();
                            t.Writable = task.Writable.FirstOrDefault().As<bool>();
                            t.InUse = task.InUse.FirstOrDefault().As<bool>();

                            t.Permissions = task.Permissions?.FirstOrDefault()?.PermissionPermission?.FirstOrDefault()?.Name?.FirstOrDefault();
                            t.Alterable = task.Alterable?.FirstOrDefault() == 1;


                            if (task.Config?.Any() == true)
                            {
                                var first = task.Config.First();
                                t.Config = new Info();
                                t.Config.Id = first.Empty?.Id;
                                t.Config.Name = first.Name?.FirstOrDefault();
                                t.Config.Type = first.Type?.FirstOrDefault();
                                t.Config.Trash = first.Trash.FirstOrDefault();
                            }
                            if (task.Target?.Any() == true)
                            {
                                var first = task.Target.First();
                                t.Target = new Info();
                                t.Target.Id = first.Empty?.Id;
                                t.Target.Name = first.Name?.FirstOrDefault();
                                t.Target.Type = first.Type?.FirstOrDefault();
                                t.Target.Trash = first.Trash.FirstOrDefault();
                            }
                            t.HostsOrdering = task.HostsOrdering?.FirstOrDefault();
                            if (task.Scanner?.Any() == true)
                            {
                                var first = task.Scanner.First();
                                t.Scanner = new Info();
                                t.Scanner.Id = first.Empty?.Id;
                                t.Scanner.Name = first.Name?.FirstOrDefault();
                                t.Scanner.Type = first.Type?.FirstOrDefault();
                                t.Scanner.Trash = first.Trash.FirstOrDefault();
                            }
                            t.Status = task.Status?.FirstOrDefault();
                            t.Progress = task.Progress?.FirstOrDefault();
                            t.ReportCount = task.ReportCount?.FirstOrDefault()?.Empty;
                            t.ReportCountFinished = task.ReportCount?.FirstOrDefault()?.Finished.FirstOrDefault();
                            t.Trend = task.Trend?.FirstOrDefault();
                            t.Schedule = JsonConvert.SerializeObject(task.Schedule);
                            t.SchedulePeriods = task.SchedulePeriods?.FirstOrDefault();

                            if (task.FirstReport?.Any() == true)
                            {
                                var f = task.FirstReport.First();
                                if (f.Report?.Any() == true)
                                {
                                    var first = f.Report.First();
                                    t.FirstReport = new GetTasksResponse.Task.Report();
                                    t.FirstReport.Id = first.Empty?.Id;
                                    t.FirstReport.TimeStamp = first.Timestamp?.FirstOrDefault();
                                    t.FirstReport.ScanStart = first.ScanStart?.FirstOrDefault();
                                    t.FirstReport.ScanEnd = first.ScanEnd?.FirstOrDefault();
                                    if (first.ResultCount?.Any() == true)
                                    {
                                        var x = first.ResultCount.First();
                                        t.FirstReport.ResultCount = new GetTasksResponse.Task.Report.ResultCountInfo();
                                        t.FirstReport.ResultCount.Debug = x.Debug?.FirstOrDefault();
                                        t.FirstReport.ResultCount.Hole = x.Hole?.FirstOrDefault();
                                        t.FirstReport.ResultCount.Info = x.Info?.FirstOrDefault();
                                        t.FirstReport.ResultCount.Log = x.Log?.FirstOrDefault();
                                        t.FirstReport.ResultCount.Warning = x.Warning?.FirstOrDefault();
                                        t.FirstReport.ResultCount.FalsePositive = x.FalsePositive?.FirstOrDefault();
                                    }
                                    t.FirstReport.Severity = first.Severity?.FirstOrDefault().As<double>();
                                }
                            }

                            if (task.LastReport?.Any() == true)
                            {
                                var f = task.LastReport.First();
                                if (f.Report?.Any() == true)
                                {
                                    var first = f.Report.First();
                                    t.LastReport = new GetTasksResponse.Task.Report();
                                    t.LastReport.Id = first.Empty?.Id;
                                    t.LastReport.TimeStamp = first.Timestamp?.FirstOrDefault();
                                    t.LastReport.ScanStart = first.ScanStart?.FirstOrDefault();
                                    t.LastReport.ScanEnd = first.ScanEnd?.FirstOrDefault();
                                    if (first.ResultCount?.Any() == true)
                                    {
                                        var x = first.ResultCount.First();
                                        t.LastReport.ResultCount = new GetTasksResponse.Task.Report.ResultCountInfo();
                                        t.LastReport.ResultCount.Debug = x.Debug?.FirstOrDefault();
                                        t.LastReport.ResultCount.Hole = x.Hole?.FirstOrDefault();
                                        t.LastReport.ResultCount.Info = x.Info?.FirstOrDefault();
                                        t.LastReport.ResultCount.Log = x.Log?.FirstOrDefault();
                                        t.LastReport.ResultCount.Warning = x.Warning?.FirstOrDefault();
                                        t.LastReport.ResultCount.FalsePositive = x.FalsePositive?.FirstOrDefault();
                                    }
                                    t.LastReport.Severity = first.Severity?.FirstOrDefault().As<double>();
                                }
                            }

                            t.Observers = task.Observers?.FirstOrDefault();
                            t.ResultCount = task.ResultCount?.FirstOrDefault();

                            if (task.Preferences?.Any() == true)
                            {
                                var f = task.Preferences.First();
                                if (f.Preference != null)
                                {
                                    t.Preferences = new List<GetTasksResponse.Task.PreferencesInfo>();
                                    foreach (var pref in f.Preference)
                                    {
                                        var p = new GetTasksResponse.Task.PreferencesInfo();
                                        p.Name = pref.Name?.FirstOrDefault();
                                        p.ScannerName = pref.ScannerName?.FirstOrDefault();
                                        p.Value = pref.Value?.FirstOrDefault();
                                        t.Preferences.Add(p);
                                    }
                                }
                            }

                            beauty.Tasks.Add(t);
                        }
                    }

                    beauty.Filters = this.Filters?.FirstOrDefault()?.Term?.FirstOrDefault();
                    if (null != this.Sort && 0 < this.Sort.Length)
                    {
                        var s = this.Sort[0];
                        beauty.Sort = s.Field?.FirstOrDefault()?.Empty + ", " + s.Field?.FirstOrDefault()?.Order?.FirstOrDefault();
                    }
                    beauty.TaskCount = this.TaskCount?.FirstOrDefault()?.Empty;
                }

                return beauty;
            }
        }
    }
}
