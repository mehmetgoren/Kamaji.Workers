namespace OpenvasOmpClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Newtonsoft.Json;
    using OpenvasOmpClient.Models;


    partial class Responses
    {
        public sealed class get_scanners_response : Response, IBeautiful<GetScannersResponse>
        {
            [JsonProperty("scanner")]
            public PurpleScanner[] Scanner { get; set; }

            [JsonProperty("filters")]
            public FilterElement[] Filters { get; set; }

            [JsonProperty("sort")]
            public SortInfo[] Sort { get; set; }

            [JsonProperty("scanners")]
            public FluffyScanner[] Scanners { get; set; }

            [JsonProperty("scanner_count")]
            public ScannerCountInfo[] ScannerCount { get; set; }


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

            public sealed class PurpleScanner
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
                public string[] Permissions { get; set; }

                [JsonProperty("user_tags")]
                public UserTag[] UserTags { get; set; }

                [JsonProperty("host")]
                public string[] Host { get; set; }

                [JsonProperty("port")]
                public int[] Port { get; set; }

                [JsonProperty("type")]
                public int[] Type { get; set; }

                [JsonProperty("ca_pub")]
                public string[] CaPub { get; set; }

                [JsonProperty("credential")]
                public Credential[] Credential { get; set; }
            }

            public sealed class Credential
            {
                [JsonProperty("$")]
                public Filter Empty { get; set; }

                [JsonProperty("name")]
                public string[] Name { get; set; }

                [JsonProperty("trash")]
                public int[] Trash { get; set; }
            }

            public sealed class Owner
            {
                [JsonProperty("name")]
                public string[] Name { get; set; }
            }

            public sealed class UserTag
            {
                [JsonProperty("count")]
                public int[] Count { get; set; }
            }

            public sealed class ScannerCountInfo
            {
                [JsonProperty("_")]
                public int Empty { get; set; }

                [JsonProperty("filtered")]
                public int[] Filtered { get; set; }

                [JsonProperty("page")]
                public int[] Page { get; set; }
            }

            public sealed class FluffyScanner
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



            public GetScannersResponse Beautify()
            {
                GetScannersResponse beauty = null;
                if (this.Status.Status == "200")
                {
                    beauty = new GetScannersResponse();
                    if (null != this.Scanner)
                    {
                        beauty.Scanners = new List<GetScannersResponse.Scanner>();
                        foreach (var scanner in this.Scanner)
                        {
                            var s = new GetScannersResponse.Scanner();

                            s.Id = scanner.Empty?.Id;
                            s.Name = scanner.Name?.FirstOrDefault();
                            s.Owner = scanner.Owner?.FirstOrDefault()?.Name?.FirstOrDefault();
                            s.Comment = scanner.Comment?.FirstOrDefault();
                            s.CreationTime = scanner.CreationTime?.FirstOrDefault();
                            s.ModificationTime = scanner.ModificationTime?.FirstOrDefault();
                            s.Writable = scanner.Writable.FirstOrDefault().As<bool>();
                            s.InUse = scanner.InUse.FirstOrDefault().As<bool>();

                            s.Permissions = scanner.Permissions?.FirstOrDefault();
                            s.Host = scanner.Host?.FirstOrDefault();
                            s.Port = scanner.Port?.FirstOrDefault();
                            s.Type = scanner.Type?.FirstOrDefault();
                            s.CaPub = scanner.CaPub?.FirstOrDefault();

                            if (scanner.Credential?.Any() == true)
                            {
                                var first = scanner.Credential.First();
                                s.Credential = new Info();
                                s.Credential.Id = first.Empty?.Id;
                                s.Credential.Name = first.Name?.FirstOrDefault();
                                s.Credential.Trash = first.Trash.FirstOrDefault();
                            }

                            beauty.Scanners.Add(s);
                        }
                    }

                    beauty.Filters = this.Filters?.FirstOrDefault()?.Term?.FirstOrDefault();
                    if (null != this.Sort && 0 < this.Sort.Length)
                    {
                        var s = this.Sort[0];
                        beauty.Sort = s.Field?.FirstOrDefault()?.Empty + ", " + s.Field?.FirstOrDefault()?.Order?.FirstOrDefault();
                    }
                    beauty.TargetCount = this.ScannerCount?.FirstOrDefault()?.Empty;
                }

                return beauty;
            }
        }
    }
}
