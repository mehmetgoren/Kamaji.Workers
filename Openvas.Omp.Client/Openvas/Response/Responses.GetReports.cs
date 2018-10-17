namespace Openvas.Omp.Client
{
    using Newtonsoft.Json;
    using Openvas.Omp.Client.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;


    partial class Responses
    {
        public sealed class get_reports_response : Response, IBeautiful<GetReportsResponse>
        {
            [JsonProperty("filters")]
            public FilterElement[] Filters { get; set; }

            [JsonProperty("sort")]
            public SortInfo[] Sort { get; set; }

            [JsonProperty("report_count")]
            public ReportCountInfo[] ReportCount { get; set; }

            [JsonProperty("report")]
            public WelcomeReport[] Report { get; set; }



            public sealed class WelcomeReport
            {
                [JsonProperty("$")]
                public Identity Id { get; set; }

                [JsonProperty("owner")]
                public Owner[] Owner { get; set; }

                [JsonProperty("name")]
                public DateTimeOffset[] Name { get; set; }

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

                [JsonProperty("task")]
                public ReportFormat[] Task { get; set; }

                [JsonProperty("report_format")]
                public ReportFormat[] ReportFormat { get; set; }

                [JsonProperty("report")]
                public ReportReport[] Report { get; set; }
            }

            public sealed class Identity
            {
                [JsonProperty("id")]
                public string Id { get; set; }

                [JsonProperty("format_id")]
                public string FormatId { get; set; }

                [JsonProperty("extension")]
                public string Extension { get; set; }

                [JsonProperty("type")]
                public string Type { get; set; }

                [JsonProperty("content_type")]
                public string ContentType { get; set; }
            }

            public sealed class Owner
            {
                [JsonProperty("name")]
                public string[] Name { get; set; }
            }

            public sealed class ReportReport
            {
                [JsonProperty("$")]
                public Filter Empty { get; set; }

                [JsonProperty("omp")]
                public Omp[] Omp { get; set; }

                [JsonProperty("sort")]
                public SortInfo[] Sort { get; set; }

                [JsonProperty("filters")]
                public FilterElement[] Filters { get; set; }

                [JsonProperty("severity_class")]
                public SeverityClass[] SeverityClass { get; set; }

                [JsonProperty("user_tags")]
                public App[] UserTags { get; set; }

                [JsonProperty("scan_run_status")]
                public string[] ScanRunStatus { get; set; }

                [JsonProperty("hosts")]
                public App[] Hosts { get; set; }

                [JsonProperty("closed_cves")]
                public App[] ClosedCves { get; set; }

                [JsonProperty("vulns")]
                public App[] Vulns { get; set; }

                [JsonProperty("os")]
                public App[] Os { get; set; }

                [JsonProperty("apps")]
                public App[] Apps { get; set; }

                [JsonProperty("ssl_certs")]
                public App[] SslCerts { get; set; }

                [JsonProperty("task")]
                public ReportTask[] Task { get; set; }

                [JsonProperty("scan")]
                public Scan[] Scan { get; set; }

                [JsonProperty("timestamp")]
                public DateTimeOffset[] Timestamp { get; set; }

                [JsonProperty("scan_start")]
                public DateTimeOffset[] ScanStart { get; set; }

                [JsonProperty("timezone")]
                public string[] Timezone { get; set; }

                [JsonProperty("timezone_abbrev")]
                public string[] TimezoneAbbrev { get; set; }

                [JsonProperty("ports")]
                public ReportPort[] Ports { get; set; }

                [JsonProperty("results")]
                public ReportResult[] Results { get; set; }

                [JsonProperty("result_count")]
                public ReportResultCount[] ResultCount { get; set; }

                [JsonProperty("severity")]
                public Severity[] Severity { get; set; }

                [JsonProperty("host")]
                public ReportHost[] Host { get; set; }

                [JsonProperty("host_start")]
                public Host[] HostStart { get; set; }

                [JsonProperty("host_end")]
                public Host[] HostEnd { get; set; }

                [JsonProperty("scan_end")]
                public DateTimeOffset[] ScanEnd { get; set; }

                [JsonProperty("errors")]
                public App[] Errors { get; set; }

                [JsonProperty("report_format")]
                public string[] ReportFormat { get; set; }
            }

            public sealed class App
            {
                [JsonProperty("count")]
                public int[] Count { get; set; }
            }

            public sealed class Filter
            {
                [JsonProperty("id")]
                public string Id { get; set; }
            }

            public sealed class FilterElement
            {
                [JsonProperty("$")]
                public Filter Empty { get; set; }

                [JsonProperty("term")]
                public string[] Term { get; set; }

                [JsonProperty("filter")]
                public string[] Filter { get; set; }

                [JsonProperty("keywords")]
                public FilterKeyword[] Keywords { get; set; }
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

            public sealed class ReportHost
            {
                [JsonProperty("ip")]
                public string[] Ip { get; set; }

                [JsonProperty("asset")]
                public AssetElement[] Asset { get; set; }

                [JsonProperty("start")]
                public DateTimeOffset[] Start { get; set; }

                [JsonProperty("end")]
                public DateTimeOffset?[] End { get; set; }

                [JsonProperty("port_count")]
                public PortCount[] PortCount { get; set; }

                [JsonProperty("result_count")]
                public HostResultCount[] ResultCount { get; set; }

                [JsonProperty("detail", NullValueHandling = NullValueHandling.Ignore)]
                public Detail[] Detail { get; set; }
            }

            public sealed class AssetElement
            {
                [JsonProperty("$")]
                public Asset Empty { get; set; }
            }

            public sealed class Asset
            {
                [JsonProperty("asset_id")]
                public string AssetId { get; set; }
            }

            public sealed class Detail
            {
                [JsonProperty("name")]
                public string[] Name { get; set; }

                [JsonProperty("value")]
                public string[] Value { get; set; }

                [JsonProperty("source")]
                public Source[] Source { get; set; }

                [JsonProperty("extra")]
                public string[] Extra { get; set; }
            }

            public sealed class Source
            {
                [JsonProperty("type")]
                public string[] Type { get; set; }

                [JsonProperty("name")]
                public string[] Name { get; set; }

                [JsonProperty("description")]
                public string[] Description { get; set; }
            }

            public sealed class PortCount
            {
                [JsonProperty("page")]
                public int[] Page { get; set; }
            }

            public sealed class HostResultCount
            {
                [JsonProperty("page")]
                public int[] Page { get; set; }

                [JsonProperty("hole")]
                public PortCount[] Hole { get; set; }

                [JsonProperty("warning")]
                public PortCount[] Warning { get; set; }

                [JsonProperty("info")]
                public PortCount[] Info { get; set; }

                [JsonProperty("log")]
                public PortCount[] Log { get; set; }

                [JsonProperty("false_positive")]
                public PortCount[] FalsePositive { get; set; }
            }

            public sealed class Host
            {
                [JsonProperty("_")]
                public DateTimeOffset Empty { get; set; }

                [JsonProperty("host")]
                public string[] HostHost { get; set; }
            }

            public sealed class Omp
            {
                [JsonProperty("version")]
                public string[] Version { get; set; }
            }

            public sealed class ReportPort
            {
                [JsonProperty("$")]
                public Port Empty { get; set; }

                [JsonProperty("count")]
                public int[] Count { get; set; }

                [JsonProperty("port")]
                public PortPort[] Port { get; set; }
            }

            public sealed class Port
            {
                [JsonProperty("max")]
                public int Max { get; set; }

                [JsonProperty("start")]
                public int Start { get; set; }
            }

            public sealed class PortPort
            {
                [JsonProperty("_")]
                public string Empty { get; set; }

                [JsonProperty("host")]
                public string[] Host { get; set; }

                [JsonProperty("severity")]
                public string[] Severity { get; set; }

                [JsonProperty("threat")]
                public string[] Threat { get; set; }
            }

            public sealed class ReportResultCount
            {
                [JsonProperty("_")]
                public int Empty { get; set; }

                [JsonProperty("full")]
                public int[] Full { get; set; }

                [JsonProperty("filtered")]
                public int[] Filtered { get; set; }

                [JsonProperty("debug")]
                public Severity[] Debug { get; set; }

                [JsonProperty("hole")]
                public Severity[] Hole { get; set; }

                [JsonProperty("info")]
                public Severity[] Info { get; set; }

                [JsonProperty("log")]
                public Severity[] Log { get; set; }

                [JsonProperty("warning")]
                public Severity[] Warning { get; set; }

                [JsonProperty("false_positive")]
                public Severity[] FalsePositive { get; set; }
            }

            public sealed class Severity
            {
                [JsonProperty("full")]
                public string[] Full { get; set; }

                [JsonProperty("filtered")]
                public string[] Filtered { get; set; }
            }

            public sealed class ReportResult
            {
                [JsonProperty("$")]
                public Port Empty { get; set; }

                [JsonProperty("result")]
                public ResultResult[] Result { get; set; }
            }

            public sealed class ResultResult
            {
                [JsonProperty("$")]
                public Filter Empty { get; set; }

                [JsonProperty("name")]
                public string[] Name { get; set; }

                [JsonProperty("owner")]
                public Owner[] Owner { get; set; }

                [JsonProperty("comment")]
                public string[] Comment { get; set; }

                [JsonProperty("creation_time")]
                public DateTimeOffset[] CreationTime { get; set; }

                [JsonProperty("modification_time")]
                public DateTimeOffset[] ModificationTime { get; set; }

                [JsonProperty("user_tags")]
                public App[] UserTags { get; set; }

                [JsonProperty("host")]
                public ResultHost[] Host { get; set; }

                [JsonProperty("port")]
                public string[] Port { get; set; }

                [JsonProperty("nvt")]
                public NvtElement[] Nvt { get; set; }

                [JsonProperty("scan_nvt_version")]
                public string[] ScanNvtVersion { get; set; }

                [JsonProperty("threat")]
                public string[] Threat { get; set; }

                [JsonProperty("severity")]
                public string[] Severity { get; set; }

                [JsonProperty("qod")]
                public Qod[] Qod { get; set; }

                [JsonProperty("description")]
                public string[] Description { get; set; }

                [JsonProperty("original_threat")]
                public string[] OriginalThreat { get; set; }

                [JsonProperty("original_severity")]
                public string[] OriginalSeverity { get; set; }

                [JsonProperty("notes")]
                public string[] Notes { get; set; }

                [JsonProperty("overrides")]
                public string[] Overrides { get; set; }
            }

            public sealed class ResultHost
            {
                [JsonProperty("_")]
                public string Empty { get; set; }

                [JsonProperty("asset")]
                public AssetElement[] Asset { get; set; }
            }

            public sealed class NvtElement
            {
                [JsonProperty("$")]
                public Nvt Empty { get; set; }

                [JsonProperty("type")]
                public string[] Type { get; set; }

                [JsonProperty("name")]
                public string[] Name { get; set; }

                [JsonProperty("family")]
                public string[] Family { get; set; }

                [JsonProperty("cvss_base")]
                public string[] CvssBase { get; set; }

                [JsonProperty("cve")]
                public string[] Cve { get; set; }

                [JsonProperty("bid")]
                public string[] Bid { get; set; }

                [JsonProperty("xref")]
                public string[] Xref { get; set; }

                [JsonProperty("tags")]
                public string[] Tags { get; set; }

                [JsonProperty("cert")]
                public object[] Cert { get; set; }
            }

            public sealed class CertClass
            {
                [JsonProperty("cert_ref")]
                public CertRefElement[] CertRef { get; set; }
            }

            public sealed class CertRefElement
            {
                [JsonProperty("$")]
                public CertRef Empty { get; set; }
            }

            public sealed class CertRef
            {
                [JsonProperty("id")]
                public string Id { get; set; }

                [JsonProperty("type")]
                public string Type { get; set; }
            }

            public sealed class Nvt
            {
                [JsonProperty("oid")]
                public string Oid { get; set; }
            }

            public sealed class Qod
            {
                [JsonProperty("value")]
                public int[] Value { get; set; }

                [JsonProperty("type")]
                public string[] Type { get; set; }
            }

            public sealed class Scan
            {
                [JsonProperty("task")]
                public ScanTask[] Task { get; set; }
            }

            public sealed class ScanTask
            {
                [JsonProperty("slave")]
                public Slave[] Slave { get; set; }

                [JsonProperty("preferences")]
                public TaskPreference[] Preferences { get; set; }
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

            public sealed class Slave
            {
                [JsonProperty("$")]
                public Filter Empty { get; set; }

                [JsonProperty("name")]
                public string[] Name { get; set; }

                [JsonProperty("host")]
                public string[] Host { get; set; }

                [JsonProperty("port")]
                public int[] Port { get; set; }
            }

            public sealed class SeverityClass
            {
                [JsonProperty("$")]
                public Filter Empty { get; set; }

                [JsonProperty("name")]
                public string[] Name { get; set; }

                [JsonProperty("full_name")]
                public string[] FullName { get; set; }

                [JsonProperty("severity_range")]
                public SeverityRange[] SeverityRange { get; set; }
            }

            public sealed class SeverityRange
            {
                [JsonProperty("name")]
                public string[] Name { get; set; }

                [JsonProperty("min")]
                public string[] Min { get; set; }

                [JsonProperty("max")]
                public string[] Max { get; set; }
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

            public sealed class ReportTask
            {
                [JsonProperty("$")]
                public Filter Empty { get; set; }

                [JsonProperty("name")]
                public string[] Name { get; set; }

                [JsonProperty("comment")]
                public string[] Comment { get; set; }

                [JsonProperty("target")]
                public Target[] Target { get; set; }

                [JsonProperty("progress")]
                public int[] Progress { get; set; }

                [JsonProperty("user_tags")]
                public App[] UserTags { get; set; }
            }

            public sealed class Target
            {
                [JsonProperty("$")]
                public Filter Empty { get; set; }

                [JsonProperty("trash")]
                public int[] Trash { get; set; }
            }

            public sealed class ReportFormat
            {
                [JsonProperty("$")]
                public Filter Empty { get; set; }

                [JsonProperty("name")]
                public string[] Name { get; set; }
            }

            public sealed class ReportCountInfo
            {
                [JsonProperty("_")]
                public int Empty { get; set; }
            }


            public GetReportsResponse Beautify()
            {
                GetReportsResponse ret = null;
                if (this.Status.Status == "200")
                {
                    ret = new GetReportsResponse();
                    if (null != this.Report)
                    {
                        ret.Results = new List<GetReportsResponse.Result>();
                        foreach (WelcomeReport report in this.Report)
                        {
                            var r = new GetReportsResponse.Result();

                            r.Id = report.Id?.Id;
                            if (TryGetValue(report.Owner, out var owner) && TryGetValue(owner.Name, out var ownerName))
                                r.Owner = ownerName;
                            if (TryGetValue(report.Name, out var name))
                                r.Name = name.ToString();

                            r.Comment = report.Comment?.FirstOrDefault();
                            r.CreationTime = report.CreationTime.FirstOrDefault();
                            r.Writable = report.Writable.FirstOrDefault().As<bool>();
                            r.InUse = report.InUse.FirstOrDefault().As<bool>();
                            //r.TaskId = report.GetValue(p => p.Task).As<ReportFormat>()?.Empty?.Id?.ConvertTo<string>();
                            //r.TaskName = report.GetValue(p => p.Task).As<ReportFormat>()?.GetValue(p=>p.Name).As<string>();

                            ReportReport inner = report.Report.FirstOrDefault();
                            if (null != inner)
                            {
                                r.OmpVersion = inner.Omp.FirstOrDefault()?.Version.FirstOrDefault();
                                r.ScanRunStatus = inner.ScanRunStatus.FirstOrDefault();
                                r.VulnsCount = inner.Vulns.FirstOrDefault()?.Count?.FirstOrDefault();
                                r.AppCount = inner.Apps.FirstOrDefault()?.Count.FirstOrDefault();
                                r.SslCertsCount = inner.SslCerts.FirstOrDefault()?.Count.FirstOrDefault();

                                ReportTask task = inner.Task.FirstOrDefault();
                                if (null != task)
                                {
                                    r.Task = new GetReportsResponse.Result.TaskInfo();
                                    r.Task.Id = task.Empty?.Id;// task.GetValue(p => p.Empty).As<Filter>()?.Id;
                                    r.Task.Name = task.Name?.FirstOrDefault();
                                    r.Task.Comment = task.Comment?.FirstOrDefault();
                                    r.Task.TargetId = task.Target?.FirstOrDefault()?.Empty?.Id;
                                    r.Task.Progress = task.Progress?.FirstOrDefault();
                                }

                                r.ScanStart = inner.ScanStart.FirstOrDefault();

                                var ports = inner.Ports;
                                if (ports != null && ports.Length > 0)
                                {
                                    var port = ports[0];
                                    if (null != port && null != port.Port)
                                    {
                                        r.Ports = new List<GetReportsResponse.Result.PortInfo>();
                                        foreach (PortPort prt in port.Port)
                                        {
                                            var entity = new GetReportsResponse.Result.PortInfo();

                                            entity.Port = prt.Empty;
                                            entity.Host = prt.Host?.FirstOrDefault();
                                            entity.Severity = prt.Severity?.FirstOrDefault()?.As<double>();
                                            entity.Threat = prt.Threat?.FirstOrDefault();

                                            r.Ports.Add(entity);
                                        }
                                    }
                                }

                                var resultsArr = inner.Results;
                                if (resultsArr != null && resultsArr.Length > 0)
                                {
                                    var results = resultsArr[0];
                                    if (null != results && null != results.Result)
                                    {
                                        r.Results = new List<ResultInfo>();
                                        foreach (ResultResult result in results.Result)
                                        {
                                            var entity = new ResultInfo();

                                            entity.Id = result.Empty?.Id;
                                            entity.Name = result.Name?.FirstOrDefault();
                                            entity.Owner = result.Owner?.FirstOrDefault()?.Name.FirstOrDefault();
                                            entity.Comment = result.Comment?.FirstOrDefault();
                                            entity.CreationTime = result.CreationTime?.FirstOrDefault();
                                            entity.ModificationTime = result.ModificationTime?.FirstOrDefault();
                                            entity.Host = result.Host?.FirstOrDefault()?.Empty;
                                            entity.AssetId = result.Host?.FirstOrDefault().Asset?.FirstOrDefault()?.Empty?.AssetId;
                                            entity.Port = result.Port?.FirstOrDefault();

                                            var nvt = result.Nvt.FirstOrDefault();
                                            if (null != nvt)
                                            {
                                                entity.Nvt = new NvtInfo();
                                                entity.Nvt.Oid = nvt.Empty?.Oid;
                                                entity.Nvt.Type = nvt.Type?.FirstOrDefault();
                                                entity.Nvt.Name = nvt.Name?.FirstOrDefault();
                                                entity.Nvt.Family = nvt.Family?.FirstOrDefault();
                                                entity.Nvt.CvssBase = nvt.CvssBase?.FirstOrDefault();
                                                entity.Nvt.Cve = nvt.Cve?.FirstOrDefault();
                                                entity.Nvt.Bid = nvt.Bid?.FirstOrDefault();
                                                entity.Nvt.Xref = nvt.Xref?.FirstOrDefault();
                                                entity.Nvt.Tags = nvt.Tags?.FirstOrDefault();
                                                entity.Nvt.Cert = nvt.Cert?.FirstOrDefault()?.ToString();
                                            }

                                            entity.ScanNvtVersion = result.ScanNvtVersion?.FirstOrDefault();
                                            entity.Threat = result.Threat?.FirstOrDefault();
                                            entity.Severity = result.Severity?.FirstOrDefault();
                                            entity.Qod = result.Qod?.FirstOrDefault()?.Value?.FirstOrDefault().ToString();
                                            entity.QodType = result.Qod?.FirstOrDefault()?.Type.FirstOrDefault();
                                            entity.Description = result.Description?.FirstOrDefault();
                                            entity.OrginalThreat = result.OriginalThreat?.FirstOrDefault();
                                            entity.OrginalSeverity = result.OriginalSeverity?.FirstOrDefault()?.As<double>();
                                            entity.Notes = result.Notes?.FirstOrDefault();
                                            entity.Overrides = result.Overrides?.FirstOrDefault();

                                            r.Results.Add(entity);
                                        }
                                    }

                                    ReportResultCount[] resultCountArr = inner.ResultCount;
                                    if (null != resultCountArr && 0 != resultCountArr.Length)
                                    {
                                        ReportResultCount resultCount = resultCountArr[0];
                                        if (null != resultCount)
                                        {
                                            r.ResultCount = new GetReportsResponse.Result.ResultCountInfo();
                                            r.ResultCount.Total = resultCount.Empty;
                                            r.ResultCount.Debug = resultCount.Debug?.FirstOrDefault()?.Full?.FirstOrDefault()?.As<int>();
                                            r.ResultCount.Hole = resultCount.Hole?.FirstOrDefault()?.Full?.FirstOrDefault()?.As<int>();
                                            r.ResultCount.Info = resultCount.Info?.FirstOrDefault()?.Full?.FirstOrDefault()?.As<int>();
                                            r.ResultCount.Log = resultCount.Log?.FirstOrDefault()?.Full?.FirstOrDefault()?.As<int>();
                                            r.ResultCount.Warning = resultCount.Warning?.FirstOrDefault()?.Full?.FirstOrDefault()?.As<int>();
                                            r.ResultCount.FalsePositive = resultCount.FalsePositive?.FirstOrDefault()?.Full?.FirstOrDefault()?.As<int>();
                                        }
                                    }

                                    r.Severity = inner.Severity?.FirstOrDefault()?.Full?.FirstOrDefault().As<double>();

                                    ReportHost host = inner.Host?.FirstOrDefault();
                                    if (null != host)
                                    {
                                        r.Host = new GetReportsResponse.Result.HostInfo();
                                        var model = r.Host;
                                        model.Ip = host.Ip?.FirstOrDefault();
                                        model.AssetId = host.Asset?.FirstOrDefault()?.Empty?.AssetId;
                                        model.Start = host.Start?.FirstOrDefault();
                                        model.End = host.End?.FirstOrDefault();
                                        model.PortCount = host.PortCount?.FirstOrDefault()?.Page?.FirstOrDefault();
                                        var rcArr = host.ResultCount;
                                        if (null != rcArr && 0 != rcArr.Length)
                                        {
                                            var rc = rcArr[0];
                                            model.ResultCount = new GetReportsResponse.Result.ResultCountInfo();
                                            model.ResultCount.Total = rc.Page?.FirstOrDefault();
                                            model.ResultCount.Hole = rc.Hole?.FirstOrDefault()?.Page?.FirstOrDefault();
                                            model.ResultCount.Warning = rc.Warning?.FirstOrDefault()?.Page?.FirstOrDefault();
                                            model.ResultCount.Info = rc.Info?.FirstOrDefault()?.Page?.FirstOrDefault();
                                            model.ResultCount.Log = rc.Log?.FirstOrDefault()?.Page?.FirstOrDefault();
                                            model.ResultCount.FalsePositive = rc.FalsePositive?.FirstOrDefault()?.Page?.FirstOrDefault();
                                        }
                                        var details = host.Detail;
                                        if (null != details && 0 != details.Length)
                                        {
                                            model.Details = new List<GetReportsResponse.Result.HostInfo.Detail>();
                                            foreach (var detail in details)
                                            {
                                                var d = new GetReportsResponse.Result.HostInfo.Detail();

                                                d.Name = detail.Name?.FirstOrDefault();
                                                d.Value = detail.Value?.FirstOrDefault();
                                                d.SourceType = detail.Source?.FirstOrDefault()?.Type?.FirstOrDefault();
                                                d.SourceName = detail.Source?.FirstOrDefault()?.Name?.FirstOrDefault();
                                                d.SourceDescription = detail.Source?.FirstOrDefault()?.Description.FirstOrDefault();
                                                d.Extra = detail.Extra?.FirstOrDefault();

                                                model.Details.Add(d);
                                            }
                                        }
                                    }

                                    var hostStart = inner.HostStart?.FirstOrDefault();
                                    if (null != hostStart)
                                    {
                                        r.HostStart = hostStart.Empty;
                                        r.HostStartHost = hostStart.HostHost?.FirstOrDefault();
                                    }
                                    var hostEnd = inner.HostEnd?.FirstOrDefault();
                                    if (null != hostEnd)
                                    {
                                        r.HostEnd = hostEnd.Empty;
                                        r.HostEndHost = hostEnd.HostHost?.FirstOrDefault();
                                    }
                                    r.ScanEnd = inner.ScanEnd?.FirstOrDefault();
                                    r.ErrorCount = inner.Errors?.FirstOrDefault()?.Count?.FirstOrDefault();
                                    r.ReportFormat = inner.ReportFormat?.FirstOrDefault();
                                }
                            }

                            ret.Results.Add(r);
                        }
                    }

                    ret.Filters = this.Filters?.FirstOrDefault()?.Term?.FirstOrDefault();
                    if (null != this.Sort && 0 < this.Sort.Length)
                    {
                        var s = this.Sort[0];
                        ret.Sort = s.Field?.FirstOrDefault()?.Empty + ", " + s.Field?.FirstOrDefault()?.Order?.FirstOrDefault();
                    }
                    ret.ReportCount = this.ReportCount?.FirstOrDefault()?.Empty.As<int>();
                }

                return ret;
            }

        }
    }
}
