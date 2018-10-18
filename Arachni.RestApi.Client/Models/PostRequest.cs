namespace Arachni.RestApi.Client.Models
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public sealed class PostRequest
    {
        public static PostRequest Create(string url) => new PostRequest {Url = url};

        [JsonProperty("url")]
        public string Url { get; set; }

        //[JsonProperty("http")]
       // public HttpInfo Http { get; set; } = HttpInfo.Default;

        [JsonProperty("audit")]
        public AuditInfo Audit { get; set; } = AuditInfo.Default;

        //[JsonProperty("input")]
        //public InputInfo Input { get; set; } = InputInfo.Default;

        //[JsonProperty("browser_cluster")]
        //public BrowserClusterInfo BrowserCluster { get; set; } = BrowserClusterInfo.Default;

        [JsonProperty("scope")]
        public ScopeInfo Scope { get; set; } = ScopeInfo.Default;

        //[JsonProperty("session")]
        //public object Session { get; set; } = new object();

        [JsonProperty("checks")]
        public string[] Checks { get; set; } = {"*"};

        //[JsonProperty("platforms")]
        //public object[] Platforms { get; set; } = new object[0];

        //[JsonProperty("plugins")]
        //public object Plugins { get; set; } = new object();

        //[JsonProperty("no_fingerprinting")]
        //public bool NoFingerprinting { get; set; }

        //[JsonProperty("authorized_by")]
        //public object AuthorizedBy { get; set; }


        public sealed class AuditInfo
        {
            public static readonly AuditInfo Default = new AuditInfo
            {
                //ParameterValues = true,
               // ExcludeVectorPatterns = new object[0],
              //  IncludeVectorPatterns = new object[0],
               // LinkTemplates = new object[0],
                Elements = new []{"link", "form", "cookie"}
            };

            //[JsonProperty("parameter_values")]
            //public bool ParameterValues { get; set; }

            //[JsonProperty("exclude_vector_patterns")]
            //public object[] ExcludeVectorPatterns { get; set; }

            //[JsonProperty("include_vector_patterns")]
            //public object[] IncludeVectorPatterns { get; set; }

            //[JsonProperty("link_templates")]
            //public object[] LinkTemplates { get; set; }

            [JsonProperty("elements")]
            public string[] Elements { get; set; }
        }

        //public sealed class BrowserClusterInfo
        //{
        //    public static readonly BrowserClusterInfo Default = new BrowserClusterInfo
        //    {
        //        WaitForElements = new object(),
        //        PoolSize = 6,
        //        JobTimeout = 25,
        //        WorkerTimeToLive = 100,
        //        IgnoreImages = false,
        //        ScreenWidth = 1600,
        //        ScreenHeight = 1200
        //    };

        //    [JsonProperty("wait_for_elements")]
        //    public object WaitForElements { get; set; }

        //    [JsonProperty("pool_size")]
        //    public int PoolSize { get; set; }

        //    [JsonProperty("job_timeout")]
        //    public int JobTimeout { get; set; }

        //    [JsonProperty("worker_time_to_live")]
        //    public int WorkerTimeToLive { get; set; }

        //    [JsonProperty("ignore_images")]
        //    public bool IgnoreImages { get; set; }

        //    [JsonProperty("screen_width")]
        //    public int ScreenWidth { get; set; }

        //    [JsonProperty("screen_height")]
        //    public int ScreenHeight { get; set; }
        //}


        //public sealed class HttpInfo
        //{
        //    public static readonly HttpInfo Default = new HttpInfo
        //    {
        //        UserAgent = "Arachni/v2.0dev",
        //        RequestTimeout = 10000,
        //        RequestRedirectLimit = 5,
        //        RequestConcurrency = 20,
        //        RequestQueueSize = 100,
        //        RequestHeaders = new object(),
        //        ResponseMaxSize = 500000,
        //        Cookies = new object()
        //    };

        //    [JsonProperty("user_agent")]
        //    public string UserAgent { get; set; }

        //    [JsonProperty("request_timeout")]
        //    public int RequestTimeout { get; set; }

        //    [JsonProperty("request_redirect_limit")]
        //    public int RequestRedirectLimit { get; set; }

        //    [JsonProperty("request_concurrency")]
        //    public int RequestConcurrency { get; set; }

        //    [JsonProperty("request_queue_size")]
        //    public int RequestQueueSize { get; set; }

        //    [JsonProperty("request_headers")]
        //    public object RequestHeaders { get; set; }

        //    [JsonProperty("response_max_size")]
        //    public int ResponseMaxSize { get; set; }

        //    [JsonProperty("cookies")]
        //    public object Cookies { get; set; }
        //}

        //public sealed class InputInfo
        //{
        //    public static readonly InputInfo Default = new InputInfo
        //    {
        //        Values = new object(),
        //        DefaultValues = new Dictionary<string, string>
        //        {
        //            { "(?i-mx:name)", "arachni_name"},
        //            { "(?i-mx:user)" , "arachni_user"},
        //            { "(?i-mx:usr)" , "arachni_user"},
        //            { "(?i-mx:pass)" , "5543!%arachni_secret"},
        //            {"(?i-mx:txt)" , "arachni_text"},
        //            {"(?i-mx:num)" , "132"},
        //            {"(?i-mx:amount)" , "100"},
        //            {"(?i-mx:mail)" , "arachni@email.gr"},
        //            {"(?i-mx:account)" , "12"},
        //            {"(?i-mx:id)" , "1"}
        //        },
        //        WithoutDefaults = false,
        //        Force = false
        //    };

        //    [JsonProperty("values")]
        //    public object Values { get; set; }

        //    [JsonProperty("default_values")]
        //    public Dictionary<string, string> DefaultValues { get; set; }

        //    [JsonProperty("without_defaults")]
        //    public bool WithoutDefaults { get; set; }

        //    [JsonProperty("force")]
        //    public bool Force { get; set; }
        //}

        public sealed class ScopeInfo
        {
            public static readonly ScopeInfo Default = new ScopeInfo
            {
                //RedundantPathPatterns = new object(),
                //DomDepthLimit = 5,
                //ExcludePathPatterns = new object[0],
                //ExcludeContentPatterns = new object[0],
                //IncludePathPatterns = new object[0],
                //RestrictPaths = new object[0],
                //ExtendPaths = new object[0],
                //UrlRewrites = new object(),
                PageLimit = 10
            };

            //[JsonProperty("redundant_path_patterns")]
            //public object RedundantPathPatterns { get; set; }

            //[JsonProperty("dom_depth_limit")]
            //public int DomDepthLimit { get; set; }

            //[JsonProperty("exclude_path_patterns")]
            //public object[] ExcludePathPatterns { get; set; }

            //[JsonProperty("exclude_content_patterns")]
            //public object[] ExcludeContentPatterns { get; set; }

            //[JsonProperty("include_path_patterns")]
            //public object[] IncludePathPatterns { get; set; }

            //[JsonProperty("restrict_paths")]
            //public object[] RestrictPaths { get; set; }

            //[JsonProperty("extend_paths")]
            //public object[] ExtendPaths { get; set; }

            //[JsonProperty("url_rewrites")]
            //public object UrlRewrites { get; set; }

            [JsonProperty("page_limit")]
            public int PageLimit { get; set; }
        }
    }
}
