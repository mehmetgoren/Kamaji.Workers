namespace Openvas.Omp.Client
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Newtonsoft.Json;
    using Openvas.Omp.Client.Models;

    partial class Responses
    {
        public sealed class get_results_response : Response, IBeautiful<GetResultsResponse>
        {
            [JsonProperty("result")]
            public PurpleResult[] Result { get; set; }

            [JsonProperty("filters")]
            public FilterElement[] Filters { get; set; }

            [JsonProperty("sort")]
            public SortInfo[] Sort { get; set; }

            [JsonProperty("results")]
            public FluffyResult[] Results { get; set; }

            [JsonProperty("result_count")]
            public ResultCountInfo[] ResultCount { get; set; }


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

            public sealed class PurpleResult
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
                public UserTag[] UserTags { get; set; }

                [JsonProperty("host")]
                public Host[] Host { get; set; }

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

            public sealed class Host
            {
                [JsonProperty("_")]
                public string Empty { get; set; }

                [JsonProperty("asset")]
                public AssetElement[] Asset { get; set; }
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

            public sealed class Nvt
            {
                [JsonProperty("oid")]
                public string Oid { get; set; }
            }

            public sealed class Owner
            {
                [JsonProperty("name")]
                public string[] Name { get; set; }
            }

            public sealed class Qod
            {
                [JsonProperty("value")]
                public int[] Value { get; set; }

                [JsonProperty("type")]
                public string[] Type { get; set; }
            }

            public sealed class UserTag
            {
                [JsonProperty("count")]
                public int[] Count { get; set; }
            }

            public sealed class ResultCountInfo
            {
                [JsonProperty("_")]
                public int Empty { get; set; }

                [JsonProperty("filtered")]
                public int[] Filtered { get; set; }

                [JsonProperty("page")]
                public int[] Page { get; set; }
            }

            public sealed class FluffyResult
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


            public GetResultsResponse Beautify()
            {
                GetResultsResponse beauty = null;
                if (this.Status.Status == "200")
                {
                    beauty = new GetResultsResponse();
                    if (null != this.Result)
                    {
                        beauty.Results = new List<ResultInfo>();
                        foreach (var result in this.Result)
                        {
                            var r = new ResultInfo();
                            r.Id = result.Empty?.Id;
                            r.Name = result.Name?.FirstOrDefault();
                            r.Owner = result.Owner?.FirstOrDefault()?.Name?.FirstOrDefault();
                            r.Comment = result.Comment?.FirstOrDefault();
                            r.CreationTime = result.CreationTime?.FirstOrDefault();
                            r.ModificationTime = result.ModificationTime?.FirstOrDefault();

                            r.Host = result.Host?.FirstOrDefault()?.Empty;
                            r.AssetId = result.Host?.FirstOrDefault()?.Asset?.FirstOrDefault()?.Empty?.AssetId;
                            r.Port = result.Port?.FirstOrDefault();

                            if (null != result.Nvt && 0 != result.Nvt.Length)
                            {
                                var nvt = result.Nvt.First();
                                r.Nvt = new NvtInfo();
                                r.Nvt.Oid = nvt.Empty?.Oid;
                                r.Nvt.Type = nvt.Type?.FirstOrDefault();
                                r.Nvt.Name = nvt.Name?.FirstOrDefault();
                                r.Nvt.Family = nvt.Family?.FirstOrDefault();
                                r.Nvt.CvssBase = nvt.CvssBase?.FirstOrDefault();
                                r.Nvt.Cve = nvt.Cve?.FirstOrDefault();
                                r.Nvt.Bid = nvt.Bid?.FirstOrDefault();
                                r.Nvt.Xref = nvt.Xref?.FirstOrDefault();
                                r.Nvt.Tags = nvt.Tags?.FirstOrDefault();
                                r.Nvt.Cert = nvt.Cert?.FirstOrDefault()?.ToString();
                            }

                            r.ScanNvtVersion = result.ScanNvtVersion?.FirstOrDefault();
                            r.Threat = result.Threat?.FirstOrDefault();
                            r.Severity = result.Severity?.FirstOrDefault();
                            r.Qod = result.Qod?.FirstOrDefault()?.Value?.FirstOrDefault().ToString();
                            r.QodType = result.Qod?.FirstOrDefault()?.Type.FirstOrDefault();
                            r.Description = result.Description?.FirstOrDefault();
                            r.OrginalThreat = result.OriginalThreat?.FirstOrDefault();
                            r.OrginalSeverity = result.OriginalSeverity?.FirstOrDefault()?.As<double>();
                            r.Notes = result.Notes?.FirstOrDefault();
                            r.Overrides = result.Overrides?.FirstOrDefault();


                            beauty.Results.Add(r);
                        }
                    }
                    beauty.Filters = this.Filters?.FirstOrDefault()?.Term?.FirstOrDefault();
                    if (null != this.Sort && 0 < this.Sort.Length)
                    {
                        var s = this.Sort[0];
                        beauty.Sort = s.Field?.FirstOrDefault()?.Empty + ", " + s.Field?.FirstOrDefault()?.Order?.FirstOrDefault();
                    }
                    beauty.ResultCount = this.ResultCount?.FirstOrDefault()?.Empty;
                }

                return beauty;
            }
        }
    }
}
