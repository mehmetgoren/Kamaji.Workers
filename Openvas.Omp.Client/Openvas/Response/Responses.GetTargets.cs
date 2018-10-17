namespace Openvas.Omp.Client
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Newtonsoft.Json;
    using Openvas.Omp.Client.Models;

    partial class Responses
    {
        public sealed class get_targets_response : Response, IBeautiful<GetTargetsResponse>
        {
            [JsonProperty("target")]
            public PurpleTarget[] Target { get; set; }

            [JsonProperty("filters")]
            public FilterElement[] Filters { get; set; }

            [JsonProperty("sort")]
            public SortInfo[] Sort { get; set; }

            [JsonProperty("targets")]
            public FluffyTarget[] Targets { get; set; }

            [JsonProperty("target_count")]
            public TargetCountInfo[] TargetCount { get; set; }


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

            public sealed class PurpleTarget
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

                [JsonProperty("hosts")]
                public string[] Hosts { get; set; }

                [JsonProperty("exclude_hosts")]
                public string[] ExcludeHosts { get; set; }

                [JsonProperty("max_hosts")]
                public int[] MaxHosts { get; set; }

                [JsonProperty("port_list")]
                public EsxiCredential[] PortList { get; set; }

                [JsonProperty("ssh_credential")]
                public EsxiCredential[] SshCredential { get; set; }

                [JsonProperty("smb_credential")]
                public EsxiCredential[] SmbCredential { get; set; }

                [JsonProperty("esxi_credential")]
                public EsxiCredential[] EsxiCredential { get; set; }

                [JsonProperty("snmp_credential")]
                public EsxiCredential[] SnmpCredential { get; set; }

                [JsonProperty("reverse_lookup_only")]
                public int[] ReverseLookupOnly { get; set; }

                [JsonProperty("reverse_lookup_unify")]
                public int[] ReverseLookupUnify { get; set; }

                [JsonProperty("alive_tests")]
                public string[] AliveTests { get; set; }
            }

            public sealed class EsxiCredential
            {
                [JsonProperty("$")]
                public Filter Empty { get; set; }

                [JsonProperty("name")]
                public string[] Name { get; set; }

                [JsonProperty("trash")]
                public int[] Trash { get; set; }

                [JsonProperty("port", NullValueHandling = NullValueHandling.Ignore)]
                public int[] Port { get; set; }
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

            public sealed class UserTag
            {
                [JsonProperty("count")]
                public int[] Count { get; set; }
            }

            public sealed class TargetCountInfo
            {
                [JsonProperty("_")]
                public int Empty { get; set; }

                [JsonProperty("filtered")]
                public int[] Filtered { get; set; }

                [JsonProperty("page")]
                public int[] Page { get; set; }
            }

            public sealed class FluffyTarget
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



            public GetTargetsResponse Beautify()
            {
                GetTargetsResponse beauty = null;
                if (this.Status.Status == "200")
                {
                    beauty = new GetTargetsResponse();
                    if (null != this.Target)
                    {
                        beauty.Targets = new List<GetTargetsResponse.Target>();
                        foreach (var target in this.Target)
                        {
                            var t = new GetTargetsResponse.Target();

                            t.Id = target.Empty?.Id;
                            t.Name = target.Name?.FirstOrDefault();
                            t.Owner = target.Owner?.FirstOrDefault()?.Name?.FirstOrDefault();
                            t.Comment = target.Comment?.FirstOrDefault();
                            t.CreationTime = target.CreationTime?.FirstOrDefault();
                            t.ModificationTime = target.ModificationTime?.FirstOrDefault();
                            t.Writable = target.Writable.FirstOrDefault().As<bool>();
                            t.InUse = target.InUse.FirstOrDefault().As<bool>();

                            t.Hosts = target.Hosts?.FirstOrDefault();
                            t.ExcludeHosts = target.ExcludeHosts?.FirstOrDefault();
                            t.MaxHosts = target.MaxHosts?.FirstOrDefault();

                            if (target.PortList?.Any() == true)
                            {
                                var first = target.PortList.First();
                                t.PortList = new Info();
                                t.PortList.Id = first.Empty?.Id;
                                t.PortList.Name = first.Name?.FirstOrDefault();
                                t.PortList.Trash = first.Trash.FirstOrDefault();
                            }
                            if (target.SshCredential?.Any() == true)
                            {
                                var first = target.SshCredential.First();
                                t.SshCredential = new Info();
                                t.SshCredential.Id = first.Empty?.Id;
                                t.SshCredential.Name = first.Name?.FirstOrDefault();
                                t.SshCredential.Port = first.Port?.FirstOrDefault();
                                t.SshCredential.Trash = first.Trash.FirstOrDefault();
                            }
                            if (target.SmbCredential?.Any() == true)
                            {
                                var first = target.SmbCredential.First();
                                t.SmbCredential = new Info();
                                t.SmbCredential.Id = first.Empty?.Id;
                                t.SmbCredential.Name = first.Name?.FirstOrDefault();
                                t.SmbCredential.Trash = first.Trash.FirstOrDefault();
                            }
                            if (target.EsxiCredential?.Any() == true)
                            {
                                var first = target.EsxiCredential.First();
                                t.EsxiCredential = new Info();
                                t.EsxiCredential.Id = first.Empty?.Id;
                                t.EsxiCredential.Name = first.Name?.FirstOrDefault();
                                t.EsxiCredential.Trash = first.Trash.FirstOrDefault();
                            }
                            if (target.SnmpCredential?.Any() == true)
                            {
                                var first = target.SnmpCredential.First();
                                t.SnmpCredential = new Info();
                                t.SnmpCredential.Id = first.Empty?.Id;
                                t.SnmpCredential.Name = first.Name?.FirstOrDefault();
                                t.SnmpCredential.Trash = first.Trash.FirstOrDefault();
                            }

                            t.ReverseLookUpOnly = target.ReverseLookupOnly?.FirstOrDefault();
                            t.ReverseLookUpUnify = target.ReverseLookupUnify?.FirstOrDefault();
                            t.AliveTests = target.AliveTests?.FirstOrDefault();

                            beauty.Targets.Add(t);
                        }
                    }

                    beauty.Filters = this.Filters?.FirstOrDefault()?.Term?.FirstOrDefault();
                    if (null != this.Sort && 0 < this.Sort.Length)
                    {
                        var s = this.Sort[0];
                        beauty.Sort = s.Field?.FirstOrDefault()?.Empty + ", " + s.Field?.FirstOrDefault()?.Order?.FirstOrDefault();
                    }
                    beauty.TargetCount = this.TargetCount?.FirstOrDefault()?.Empty;
                }

                return beauty;
            }
        }
    }
}
