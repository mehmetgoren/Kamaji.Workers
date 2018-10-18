namespace Arachni.RestApi.Client.Models
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;


    public sealed class ReportResponse
    {
        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("seed")]
        public string Seed { get; set; }

        [JsonProperty("options")]
        public OptionsInfo Options { get; set; }

        [JsonProperty("sitemap")]
        public Dictionary<string, int> Sitemap { get; set; }

        [JsonProperty("start_datetime")]
        public string StartDatetime { get; set; }

        [JsonProperty("finish_datetime")]
        public string FinishDatetime { get; set; }

        [JsonProperty("delta_time")]
        public DateTimeOffset DeltaTime { get; set; }

        [JsonProperty("issues")]
        public Issue[] Issues { get; set; }

        [JsonProperty("plugins")]
        public object Plugins { get; set; }




        public sealed class Issue
        {
            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("references")]
            public Dictionary<string, string> References { get; set; }

            [JsonProperty("severity")]
            public string Severity { get; set; }

            [JsonProperty("remedy_guidance", NullValueHandling = NullValueHandling.Ignore)]
            public string RemedyGuidance { get; set; }

            [JsonProperty("check")]
            public Check Check { get; set; }

            [JsonProperty("vector")]
            public Vector Vector { get; set; }

            [JsonProperty("proof", NullValueHandling = NullValueHandling.Ignore)]
            public string Proof { get; set; }

            //[JsonProperty("referring_page")]
           // public Page ReferringPage { get; set; }

            //[JsonProperty("page")]
            //public Page Page { get; set; }

            [JsonProperty("remarks")]
            public object Remarks { get; set; }

            [JsonProperty("trusted")]
            public bool Trusted { get; set; }

            [JsonProperty("tags")]
            public string[] Tags { get; set; }

            [JsonProperty("cwe", NullValueHandling = NullValueHandling.Ignore)]
            public int? Cwe { get; set; }

            [JsonProperty("cwe_url", NullValueHandling = NullValueHandling.Ignore)]
            public string CweUrl { get; set; }

            [JsonProperty("digest")]
            public long Digest { get; set; }

            [JsonProperty("response")]
            public Response Response { get; set; }

            [JsonProperty("request")]
            public Request Request { get; set; }

            [JsonProperty("platform_name")]
            public object PlatformName { get; set; }

            [JsonProperty("platform_type")]
            public object PlatformType { get; set; }
        }

        public sealed class Check
        {
            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("elements")]
            public string[] Elements { get; set; }

            [JsonProperty("author")]
            public string Author { get; set; }

            [JsonProperty("version")]
            public string Version { get; set; }

            [JsonProperty("shortname")]
            public string Shortname { get; set; }

            [JsonProperty("max_issues", NullValueHandling = NullValueHandling.Ignore)]
            public int? MaxIssues { get; set; }
        }

        //public sealed class Page
        //{
        //    [JsonProperty("body")]
        //    public string Body { get; set; }

        //    [JsonProperty("dom")]
        //    public Dom Dom { get; set; }
        //}

        //public sealed class Dom
        //{
        //    [JsonProperty("url")]
        //    public string Url { get; set; }

        //    [JsonProperty("transitions")]
        //    public object[] Transitions { get; set; }

        //    [JsonProperty("cookies")]
        //    public object[] Cookies { get; set; }

        //    [JsonProperty("digest")]
        //    public object Digest { get; set; }

        //    [JsonProperty("data_flow_sinks")]
        //    public object[] DataFlowSinks { get; set; }

        //    [JsonProperty("execution_flow_sinks")]
        //    public object[] ExecutionFlowSinks { get; set; }
        //}

        public sealed class Request
        {
            [JsonProperty("url")]
            public string Url { get; set; }

            [JsonProperty("parameters")]
            public object Parameters { get; set; }

            //[JsonProperty("headers")]
           // public Headers Headers { get; set; }

            //[JsonProperty("headers_string")]
            //public string HeadersString { get; set; }

            //[JsonProperty("effective_body")]
            //public string EffectiveBody { get; set; }

            //[JsonProperty("body")]
            //public DefaultInputs Body { get; set; }

            [JsonProperty("method")]
            public string Method { get; set; }
        }

        public sealed class DefaultInputs
        {
            [JsonProperty("username")]
            public string Username { get; set; }

            [JsonProperty("password")]
            public string Password { get; set; }

            [JsonProperty("loginFormSubmit")]
            public string LoginFormSubmit { get; set; }
        }

        //public sealed class Headers
        //{
        //    [JsonProperty("Accept")]
        //    public string Accept { get; set; }

        //    [JsonProperty("User-Agent")]
        //    public string UserAgent { get; set; }

        //    [JsonProperty("Accept-Language")]
        //    public string AcceptLanguage { get; set; }

        //    [JsonProperty("X-Arachni-Scan-Seed")]
        //    public string XArachniScanSeed { get; set; }
        //}

        public sealed class Response
        {
            [JsonProperty("headers")]
            public Dictionary<string, object> Headers { get; set; }

            [JsonProperty("url")]
            public string Url { get; set; }

            [JsonProperty("code")]
            public int Code { get; set; }

            [JsonProperty("ip_address")]
            public string IpAddress { get; set; }

            //[JsonProperty("headers_string")]
            //public string HeadersString { get; set; }

            //[JsonProperty("body")]
            //public string Body { get; set; }

            [JsonProperty("time")]
            public double Time { get; set; }

            [JsonProperty("app_time")]
            public double AppTime { get; set; }

            [JsonProperty("total_time")]
            public double TotalTime { get; set; }

            [JsonProperty("return_code")]
            public string ReturnCode { get; set; }

            [JsonProperty("return_message")]
            public string ReturnMessage { get; set; }

            [JsonProperty("status_line", NullValueHandling = NullValueHandling.Ignore)]
            public string StatusLine { get; set; }
        }

        public sealed class Vector
        {
            [JsonProperty("class")]
            public string Class { get; set; }

            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonProperty("url")]
            public string Url { get; set; }

            [JsonProperty("affected_input_name")]
            public object AffectedInputName { get; set; }

            [JsonProperty("source", NullValueHandling = NullValueHandling.Ignore)]
            public string Source { get; set; }

            [JsonProperty("inputs", NullValueHandling = NullValueHandling.Ignore)]
            public DefaultInputs Inputs { get; set; }

            [JsonProperty("raw_inputs", NullValueHandling = NullValueHandling.Ignore)]
            public object[] RawInputs { get; set; }

            [JsonProperty("default_inputs", NullValueHandling = NullValueHandling.Ignore)]
            public DefaultInputs DefaultInputs { get; set; }

            [JsonProperty("action", NullValueHandling = NullValueHandling.Ignore)]
            public string Action { get; set; }

            [JsonProperty("method", NullValueHandling = NullValueHandling.Ignore)]
            public string Method { get; set; }

            [JsonProperty("affected_input_value", NullValueHandling = NullValueHandling.Ignore)]
            public string AffectedInputValue { get; set; }

            [JsonProperty("seed")]
            public object Seed { get; set; }
        }

        public sealed class OptionsInfo
        {
            [JsonProperty("scope")]
            public Scope Scope { get; set; }

            [JsonProperty("audit")]
            public Audit Audit { get; set; }

            [JsonProperty("http")]
            public Http Http { get; set; }

            [JsonProperty("browser_cluster")]
            public BrowserCluster BrowserCluster { get; set; }

            [JsonProperty("input")]
            public Input Input { get; set; }

            [JsonProperty("datastore")]
            public Datastore Datastore { get; set; }

            [JsonProperty("session")]
            public object Session { get; set; }

            [JsonProperty("checks")]
            public string[] Checks { get; set; }

            [JsonProperty("platforms")]
            public object[] Platforms { get; set; }

            [JsonProperty("plugins")]
            public object Plugins { get; set; }

            [JsonProperty("no_fingerprinting")]
            public bool NoFingerprinting { get; set; }

            [JsonProperty("authorized_by")]
            public object AuthorizedBy { get; set; }

            [JsonProperty("url")]
            public string Url { get; set; }
        }

        public sealed class Audit
        {
            [JsonProperty("parameter_values")]
            public bool ParameterValues { get; set; }

            [JsonProperty("exclude_vector_patterns")]
            public object[] ExcludeVectorPatterns { get; set; }

            [JsonProperty("include_vector_patterns")]
            public object[] IncludeVectorPatterns { get; set; }

            [JsonProperty("link_templates")]
            public object[] LinkTemplates { get; set; }

            [JsonProperty("links")]
            public bool Links { get; set; }

            [JsonProperty("forms")]
            public bool Forms { get; set; }

            [JsonProperty("cookies")]
            public bool Cookies { get; set; }
        }

        public sealed class BrowserCluster
        {
            [JsonProperty("local_storage")]
            public object LocalStorage { get; set; }

            [JsonProperty("wait_for_elements")]
            public object WaitForElements { get; set; }

            [JsonProperty("pool_size")]
            public int PoolSize { get; set; }

            [JsonProperty("job_timeout")]
            public int JobTimeout { get; set; }

            [JsonProperty("worker_time_to_live")]
            public int WorkerTimeToLive { get; set; }

            [JsonProperty("ignore_images")]
            public bool IgnoreImages { get; set; }

            [JsonProperty("screen_width")]
            public int ScreenWidth { get; set; }

            [JsonProperty("screen_height")]
            public int ScreenHeight { get; set; }
        }

        public sealed class Datastore
        {
            [JsonProperty("report_path")]
            public object ReportPath { get; set; }

            [JsonProperty("token")]
            public string Token { get; set; }
        }

        public sealed class Http
        {
            [JsonProperty("user_agent")]
            public string UserAgent { get; set; }

            [JsonProperty("request_timeout")]
            public int RequestTimeout { get; set; }

            [JsonProperty("request_redirect_limit")]
            public int RequestRedirectLimit { get; set; }

            [JsonProperty("request_concurrency")]
            public int RequestConcurrency { get; set; }

            [JsonProperty("request_queue_size")]
            public int RequestQueueSize { get; set; }

            [JsonProperty("request_headers")]
            public object RequestHeaders { get; set; }

            [JsonProperty("response_max_size")]
            public int ResponseMaxSize { get; set; }

            [JsonProperty("cookies")]
            public object Cookies { get; set; }

            [JsonProperty("authentication_type")]
            public string AuthenticationType { get; set; }
        }

        public sealed class Input
        {
            [JsonProperty("values")]
            public object Values { get; set; }

            [JsonProperty("default_values")]
            public Dictionary<string, string> DefaultValues { get; set; }

            [JsonProperty("without_defaults")]
            public bool WithoutDefaults { get; set; }

            [JsonProperty("force")]
            public bool Force { get; set; }
        }

        public sealed class Scope
        {
            [JsonProperty("redundant_path_patterns")]
            public object RedundantPathPatterns { get; set; }

            [JsonProperty("dom_depth_limit")]
            public int DomDepthLimit { get; set; }

            [JsonProperty("exclude_file_extensions")]
            public object[] ExcludeFileExtensions { get; set; }

            [JsonProperty("exclude_path_patterns")]
            public object[] ExcludePathPatterns { get; set; }

            [JsonProperty("exclude_content_patterns")]
            public object[] ExcludeContentPatterns { get; set; }

            [JsonProperty("include_path_patterns")]
            public object[] IncludePathPatterns { get; set; }

            [JsonProperty("restrict_paths")]
            public object[] RestrictPaths { get; set; }

            [JsonProperty("extend_paths")]
            public object[] ExtendPaths { get; set; }

            [JsonProperty("url_rewrites")]
            public object UrlRewrites { get; set; }

            [JsonProperty("page_limit")]
            public int PageLimit { get; set; }
        }
    }
}
