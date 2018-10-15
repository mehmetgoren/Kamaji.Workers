namespace OpenvasOmpClient
{
    using Newtonsoft.Json;
    using OpenvasOmpClient.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;


    public static partial class Responses
    {
        public interface IBeautiful<out TModel>
        {
            TModel Beautify();
        }

        private static bool TryGetValue<T>(IEnumerable<T> array, out T item)
        {
            item = default(T);
            bool ret = null != array && array.Any();
            if (ret)
                item = array.First();
            return ret;
        }
        public static T As<T>(this object value)
        {
            if (null != value)
            {
                try
                {
                    return (T)Convert.ChangeType(value, typeof(T));
                }
                catch { }
            }
            return default(T);
        }


        public abstract class Response
        {
            public class StatusInfo
            {
                [JsonProperty("status_text")]
                public string StatusText { get; set; }

                [JsonProperty("status")]
                public string Status { get; set; }

                public override string ToString() => $"{this.StatusText} - {this.Status}";
            }

            [JsonProperty("$")]
            public StatusInfo Status { get; set; }
        }


        public sealed class get_version_response : Response
        {
            public IList<double> version { get; set; }
        }


        public sealed class get_credentials_response : Response, IBeautiful<GetCredentialResponse>
        {
            [JsonProperty("filters")]
            public FilterElement[] Filters { get; set; }
            public sealed class FilterElement
            {
                [JsonProperty("term")]
                public string[] Term { get; set; }
            }

            [JsonProperty("credential")]
            public Credentials[] Credential { get; set; }

            public sealed class Credentials
            {
                [JsonProperty("$")]
                public Empty Empty { get; set; }

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
                public long[] Writable { get; set; }

                [JsonProperty("in_use")]
                public long[] InUse { get; set; }

                [JsonProperty("permissions")]
                public Permission[] Permissions { get; set; }

                [JsonProperty("user_tags")]
                public UserTag[] UserTags { get; set; }

                [JsonProperty("allow_insecure")]
                public long[] AllowInsecure { get; set; }

                [JsonProperty("login")]
                public string[] Login { get; set; }

                [JsonProperty("type")]
                public string[] Type { get; set; }

                [JsonProperty("full_type")]
                public string[] FullType { get; set; }
            }

            public sealed class Empty
            {
                [JsonProperty("id")]
                public string Id { get; set; }
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
                public long[] Count { get; set; }
            }

            public GetCredentialResponse Beautify()
            {
                GetCredentialResponse ret = null;
                if (this.Status.Status == "200")
                {
                    ret = new GetCredentialResponse();
                    if (null != this.Credential)
                    {
                        ret.Credentials = new List<GetCredentialResponse.Credential>();
                        foreach (Credentials credentials in this.Credential)
                        {
                            var c = new GetCredentialResponse.Credential();

                            if (null != credentials.Empty)
                                c.Id = credentials.Empty.Id;
                            if (TryGetValue(credentials.Owner, out Owner owner) && TryGetValue(owner.Name, out string ownerName))
                                c.Owner = ownerName;
                            if (TryGetValue(credentials.Name, out string name))
                                c.Name = name;
                            if (TryGetValue(credentials.Comment, out string comment))
                                c.Comment = comment;
                            if (TryGetValue(credentials.CreationTime, out DateTimeOffset creationTime))
                                c.CreationTime = creationTime;
                            if (TryGetValue(credentials.ModificationTime, out DateTimeOffset modificationTime))
                                c.ModificationTime = modificationTime;
                            if (TryGetValue(credentials.Writable, out long writable))
                                c.Writable = writable != 0L;
                            if (TryGetValue(credentials.InUse, out long inUse))
                                c.InUse = inUse != 0L;
                            if (TryGetValue(credentials.Permissions, out var per) && TryGetValue(per.PermissionPermission, out var per2) && TryGetValue(per2.Name, out string p))
                                c.Permissions = p;
                            if (TryGetValue(credentials.AllowInsecure, out long allowInsecure))
                                c.AllowInsecure = allowInsecure != 0L;
                            if (TryGetValue(credentials.Login, out string login))
                                c.Login = login;
                            if (TryGetValue(credentials.Type, out string type))
                                c.Type = type;
                            if (TryGetValue(credentials.FullType, out string fullType))
                                c.FullType = fullType;

                            ret.Credentials.Add(c);
                        }
                    }
                    ret.Filters = this.Filters?.FirstOrDefault()?.Term?.FirstOrDefault();
                }

                return ret;
            }


        }

        public sealed class get_configs_response : Response, IBeautiful<GetConfigResponse>
        {
            [JsonProperty("filters")]
            public FilterElement[] Filters { get; set; }
            public sealed class FilterElement
            {
                [JsonProperty("term")]
                public string[] Term { get; set; }
            }

            [JsonProperty("config")]
            public Configs[] Config { get; set; }

            public sealed class Configs
            {
                [JsonProperty("$")]
                public Empty Empty { get; set; }

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
                public long[] Writable { get; set; }

                [JsonProperty("in_use")]
                public long[] InUse { get; set; }

                [JsonProperty("permissions")]
                public string[] Permissions { get; set; }

                [JsonProperty("user_tags")]
                public UserTag[] UserTags { get; set; }

                [JsonProperty("family_count")]
                public Count[] FamilyCount { get; set; }

                [JsonProperty("nvt_count")]
                public Count[] NvtCount { get; set; }

                [JsonProperty("type")]
                public long[] Type { get; set; }
            }

            public sealed class Empty
            {
                [JsonProperty("id")]
                public string Id { get; set; }
            }

            public sealed class Count
            {
                [JsonProperty("_")]
                public long Empty { get; set; }

                [JsonProperty("growing")]
                public long[] Growing { get; set; }
            }

            public sealed class Owner
            {
                [JsonProperty("name")]
                public string[] Name { get; set; }
            }

            public sealed class UserTag
            {
                [JsonProperty("count")]
                public long[] Count { get; set; }
            }


            public GetConfigResponse Beautify()
            {
                GetConfigResponse ret = null;
                if (this.Status.Status == "200")
                {
                    ret = new GetConfigResponse();
                    if (null != this.Config)
                    {
                        ret.Configs = new List<GetConfigResponse.Config>();
                        foreach (Configs configs in this.Config)
                        {
                            var c = new GetConfigResponse.Config();

                            if (null != configs.Empty)
                                c.Id = configs.Empty.Id;
                            if (TryGetValue(configs.Owner, out Owner owner) && TryGetValue(owner.Name, out string ownerName))
                                c.Owner = ownerName;
                            if (TryGetValue(configs.Name, out string name))
                                c.Name = name;
                            if (TryGetValue(configs.Comment, out string comment))
                                c.Comment = comment;
                            if (TryGetValue(configs.CreationTime, out DateTimeOffset creationTime))
                                c.CreationTime = creationTime;
                            if (TryGetValue(configs.ModificationTime, out DateTimeOffset modificationTime))
                                c.ModificationTime = modificationTime;
                            if (TryGetValue(configs.Writable, out long writable))
                                c.Writable = writable != 0L;
                            if (TryGetValue(configs.InUse, out long inUse))
                                c.InUse = inUse != 0L;
                            if (TryGetValue(configs.Permissions, out var per))
                                c.Permissions = per;
                            if (TryGetValue(configs.FamilyCount, out Count familyCount))
                                c.FamilyCount = Convert.ToInt32(familyCount.Empty);
                            if (TryGetValue(configs.NvtCount, out Count nvtCount))
                                c.NvtCount = Convert.ToInt32(nvtCount.Empty);
                            if (TryGetValue(configs.Type, out long type))
                                c.Type = Convert.ToInt32(type);

                            ret.Configs.Add(c);
                        }
                    }
                    ret.Filters = this.Filters?.FirstOrDefault()?.Term?.FirstOrDefault();
                }

                return ret;
            }
        }

        public sealed class get_nvt_families_response : Response, IBeautiful<GetNvtFamiliesResponse>
        {
            [JsonProperty("families")]
            public WelcomeFamily[] Families { get; set; }

            public sealed class WelcomeFamily
            {
                [JsonProperty("family")]
                public FamilyFamily[] Family { get; set; }
            }

            public sealed class FamilyFamily
            {
                [JsonProperty("name")]
                public string[] Name { get; set; }

                [JsonProperty("max_nvt_count")]
                public long[] MaxNvtCount { get; set; }
            }


            public GetNvtFamiliesResponse Beautify()
            {
                GetNvtFamiliesResponse ret = new GetNvtFamiliesResponse();
                if (this.Status.Status == "200")
                {
                    if (null != this.Families && this.Families.Length > 0 && this.Families[0].Family != null)
                    {
                        ret.Families = new List<GetNvtFamiliesResponse.Family>();
                        foreach (FamilyFamily item in this.Families[0].Family)
                        {
                            var f = new GetNvtFamiliesResponse.Family();

                            if (TryGetValue(item.Name, out string name))
                                f.Name = name;
                            if (TryGetValue(item.MaxNvtCount, out long maxNvtCount))
                                f.MaxNvtCount = Convert.ToInt32(maxNvtCount);

                            ret.Families.Add(f);
                        }
                    }
                }

                return ret;
            }
        }
    }
}
