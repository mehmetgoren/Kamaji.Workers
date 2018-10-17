namespace Openvas.Omp.Client.Models
{
    using System;
    using System.Collections.Generic;

    public abstract class ModelBase
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
    }
    public abstract class ModelBase2 : ModelBase
    {
        public string Owner { get; set; }
    }
    public abstract class ModelBase3 : ModelBase2
    {
        public DateTimeOffset? CreationTime { get; set; }
        public DateTimeOffset? ModificationTime { get; set; }
    }
    public abstract class ModelBase4 : ModelBase3
    {
        public bool? Writable { get; set; }
        public bool? InUse { get; set; }
    }
    public sealed class Info
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int? Type { get; set; }
        public int? Trash { get; set; }
        public int? Port { get; set; }
    }




    public sealed class OmpVersion
    {
        public string Version { get; set; }
    }

    public sealed class GetCredentialResponse
    {
        public sealed class Credential : ModelBase4
        {
            public string Permissions { get; set; }

            public bool AllowInsecure { get; set; }

            public string Login { get; set; }

            public string Type { get; set; }

            public string FullType { get; set; }
        }

        public List<Credential> Credentials { get; set; }

        public string Filters { get; set; }
    }

    public sealed class GetConfigResponse
    {
        public sealed class Config : ModelBase4
        {
            public string Permissions { get; set; }

            public int FamilyCount { get; set; }

            public int NvtCount { get; set; }

            public int Type { get; set; }
        }

        public List<Config> Configs { get; set; }

        public string Filters { get; set; }
    }

    public sealed class GetNvtFamiliesResponse
    {
        public sealed class Family
        {
            public string Name { get; set; }
            public int MaxNvtCount { get; set; }
        }

        public List<Family> Families { get; set; }
    }



    public sealed class NvtInfo
    {
        public string Oid { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string CvssBase { get; set; }
        public string Cve { get; set; }
        public string Bid { get; set; }
        public string Xref { get; set; }
        public string Tags { get; set; }
        public string Cert { get; set; }
    }
    public class ResultInfo : ModelBase3
    {
        public string Host { get; set; }
        public string AssetId { get; set; }
        public string Port { get; set; }

        public NvtInfo Nvt { get; set; }

        public string ScanNvtVersion { get; set; }
        public string Threat { get; set; }
        public string Severity { get; set; }
        public string Qod { get; set; }
        public string QodType { get; set; }
        public string Description { get; set; }
        public string OrginalThreat { get; set; }
        public double? OrginalSeverity { get; set; }
        public string Notes { get; set; }
        public string Overrides { get; set; }
    }
    public sealed class GetReportsResponse
    {
        public sealed class Result : ModelBase4
        {
            //public string TaskId { get; set; }
            //public string TaskName { get; set; }
            public sealed class TaskInfo : ModelBase
            {
                public string TargetId { get; set; }
                public int? Progress { get; set; }
            }
            public TaskInfo Task { get; set; }


            public string OmpVersion { get; set; }
            public string ScanRunStatus { get; set; }
            public int? VulnsCount { get; set; }
            public int? AppCount { get; set; }
            public int? SslCertsCount { get; set; }
            public DateTimeOffset? ScanStart { get; set; }


            public sealed class PortInfo
            {
                public string Port { get; set; }
                public string Host { get; set; }
                public double? Severity { get; set; }
                public string Threat { get; set; }
            }
            public List<PortInfo> Ports { get; set; }

            public List<ResultInfo> Results { get; set; }


            public sealed class ResultCountInfo
            {
                public int? Total { get; set; }
                public int? Debug { get; set; }
                public int? Hole { get; set; }
                public int? Info { get; set; }
                public int? Log { get; set; }
                public int? Warning { get; set; }
                public int? FalsePositive { get; set; }
            }
            public ResultCountInfo ResultCount { get; set; }


            public double? Severity { get; set; }


            public sealed class HostInfo
            {
                public string Ip { get; set; }
                public string AssetId { get; set; }
                public DateTimeOffset? Start { get; set; }
                public DateTimeOffset? End { get; set; }
                public int? PortCount { get; set; }
                public ResultCountInfo ResultCount { get; set; }

                public sealed class Detail
                {
                    public string Name { get; set; }
                    public string Value { get; set; }
                    public string SourceType { get; set; }
                    public string SourceName { get; set; }
                    public string SourceDescription { get; set; }
                    public string Extra { get; set; }
                }
                public List<Detail> Details { get; set; }
            }
            public HostInfo Host { get; set; }


            public DateTimeOffset? HostStart { get; set; }
            public string HostStartHost { get; set; }
            public DateTimeOffset? HostEnd { get; set; }
            public string HostEndHost { get; set; }
            public DateTimeOffset? ScanEnd { get; set; }
            public int? ErrorCount { get; set; }
            public string ReportFormat { get; set; }
        }

        public List<Result> Results { get; set; }

        public int? ReportCount { get; set; }

        public string Sort { get; set; }

        public string Filters { get; set; }
    }


    public sealed class GetResultsResponse
    {
        public List<ResultInfo> Results { get; set; }

        public string Filters { get; set; }
        public string Sort { get; set; }
        public int? ResultCount { get; set; }
    }


    public sealed class GetTargetsResponse
    {
        public sealed class Target : ModelBase4
        {
            public string Hosts { get; set; }
            public string ExcludeHosts { get; set; }
            public int? MaxHosts { get; set; }

            public Info PortList { get; set; }
            public Info SshCredential { get; set; }
            public Info SmbCredential { get; set; }
            public Info EsxiCredential { get; set; }
            public Info SnmpCredential { get; set; }

            public int? ReverseLookUpOnly { get; set; }
            public int? ReverseLookUpUnify { get; set; }
            public string AliveTests { get; set; }
        }

        public List<Target> Targets { get; set; }


        public string Filters { get; set; }
        public string Sort { get; set; }
        public int? TargetCount { get; set; }
    }

    public sealed class GetTasksResponse
    {
        public sealed class Task : ModelBase4
        {
            public string Permissions { get; set; }
            public bool? Alterable { get; set; }

            public Info Config { get; set; }
            public Info Target { get; set; }
            public string HostsOrdering { get; set; }
            public Info Scanner { get; set; }
            public string Status { get; set; }
            public object Progress { get; set; }
            public int? ReportCount { get; set; }
            public int? ReportCountFinished { get; set; }
            public string Trend { get; set; }
            public string Schedule { get; set; }
            public int? SchedulePeriods { get; set; }

            public sealed class Report
            {
                public string Id { get; set; }
                public DateTimeOffset? TimeStamp { get; set; }
                public DateTimeOffset? ScanStart { get; set; }
                public DateTimeOffset? ScanEnd { get; set; }

                public sealed class ResultCountInfo
                {
                    public int? Debug { get; set; }
                    public int? Hole { get; set; }
                    public int? Info { get; set; }
                    public int? Log { get; set; }
                    public int? Warning { get; set; }
                    public int? FalsePositive { get; set; }
                }
                public ResultCountInfo ResultCount { get; set; }

                public double? Severity { get; set; }
            }
            public Report FirstReport { get; set; }
            public Report LastReport { get; set; }
            public string Observers { get; set; }
            public int? ResultCount { get; set; }

            public sealed class PreferencesInfo
            {
                public string Name { get; set; }
                public string ScannerName { get; set; }
                public string Value { get; set; }
            }
            public List<PreferencesInfo> Preferences { get; set; }
        }

        public List<Task> Tasks { get; set; }

        public string Filters { get; set; }
        public string Sort { get; set; }
        public int? TaskCount { get; set; }
    }

    public sealed class GetScannersResponse
    {
        public sealed class Scanner : ModelBase4
        {
            public string Permissions { get; set; }
            public string Host { get; set; }
            public int? Port { get; set; }
            public int? Type { get; set; }
            public string CaPub { get; set; }
            public Info Credential { get; set; }
        }

        public List<Scanner> Scanners { get; set; }


        public string Filters { get; set; }
        public string Sort { get; set; }
        public int? TargetCount { get; set; }
    }

    public sealed class CreateCommandResponse : Responses.CreateCommandResponse.StatusInfo { }

    public sealed class GenericResponse : Responses.Response.StatusInfo { }
}
