namespace Arachni.RestApi.Client.Models
{
    using System.Collections.Generic;
    using Newtonsoft.Json;


    public sealed class ProgressResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("busy")]
        public bool Busy { get; set; }

        [JsonProperty("seed")]
        public string Seed { get; set; }

        [JsonProperty("statistics")]
        public StatisticsInfo Statistics { get; set; }

        //[JsonProperty("errors")]
        //public object[] Errors { get; set; }

        [JsonProperty("messages")]
        public string[] Messages { get; set; }

        [JsonProperty("issues")]
        public Issue[] Issues { get; set; }

        [JsonProperty("sitemap")]
        public Dictionary<string, int> Sitemap { get; set; }



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

           // [JsonProperty("referring_page")]
           // public ReferringPage ReferringPage { get; set; }

            [JsonProperty("platform_name")]
            public object PlatformName { get; set; }

            [JsonProperty("platform_type")]
            public object PlatformType { get; set; }

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
            public object Author { get; set; }

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
        //    public PageDom Dom { get; set; }
        //}

        //public sealed class PageDom
        //{
        //    [JsonProperty("url")]
        //    public string Url { get; set; }

        //    [JsonProperty("transitions")]
        //    public PurpleTransition[] Transitions { get; set; }

        //    [JsonProperty("cookies")]
        //    public Cooky[] Cookies { get; set; }

        //    [JsonProperty("digest")]
        //    public object Digest { get; set; }

        //    //[JsonProperty("data_flow_sinks")]
        //   // public DataFlowSink[] DataFlowSinks { get; set; }

        //    //[JsonProperty("execution_flow_sinks")]
        //    //public ExecutionFlowSink[] ExecutionFlowSinks { get; set; }
        //}

        //public sealed class Cooky
        //{
        //    [JsonProperty("class")]
        //    public string Class { get; set; }

        //    [JsonProperty("type")]
        //    public string Type { get; set; }

        //    [JsonProperty("url")]
        //    public string Url { get; set; }

        //    [JsonProperty("action")]
        //    public string Action { get; set; }

        //    [JsonProperty("method")]
        //    public string Method { get; set; }

        //    [JsonProperty("source")]
        //    public object Source { get; set; }

        //    [JsonProperty("inputs")]
        //    public DefaultInputs Inputs { get; set; }

        //    [JsonProperty("raw_inputs")]
        //    public object[] RawInputs { get; set; }

        //    [JsonProperty("default_inputs")]
        //    public DefaultInputs DefaultInputs { get; set; }
        //}

        //public sealed class DefaultInputs
        //{
        //    [JsonProperty("username", NullValueHandling = NullValueHandling.Ignore)]
        //    public string Username { get; set; }
        //}

        //public sealed class DataFlowSink
        //{
        //    [JsonProperty("function")]
        //    public DataFlowSinkFunction Function { get; set; }

        //    [JsonProperty("object")]
        //    public string Object { get; set; }

        //    [JsonProperty("tainted_argument_index")]
        //    public int TaintedArgumentIndex { get; set; }

        //    [JsonProperty("tainted_value")]
        //    public string TaintedValue { get; set; }

        //    [JsonProperty("taint")]
        //    public string Taint { get; set; }

        //    [JsonProperty("trace")]
        //    public DataFlowSinkTrace[] Trace { get; set; }
        //}

        //public sealed class DataFlowSinkFunction
        //{
        //    [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        //    public string Name { get; set; }

        //    [JsonProperty("source", NullValueHandling = NullValueHandling.Ignore)]
        //    public string Source { get; set; }

        //    [JsonProperty("arguments", NullValueHandling = NullValueHandling.Ignore)]
        //    public string[] Arguments { get; set; }
        //}

        //public sealed class DataFlowSinkTrace
        //{
        //    [JsonProperty("function")]
        //    public DataFlowSinkFunction Function { get; set; }

        //    [JsonProperty("line")]
        //    public int? Line { get; set; }

        //    [JsonProperty("url")]
        //    public string Url { get; set; }
        //}

        //public sealed class ExecutionFlowSink
        //{
        //    [JsonProperty("data")]
        //    public object[] Data { get; set; }

        //    [JsonProperty("trace")]
        //    public ExecutionFlowSinkTrace[] Trace { get; set; }
        //}

        //public sealed class ExecutionFlowSinkTrace
        //{
        //    [JsonProperty("function")]
        //    public PurpleFunction Function { get; set; }

        //    [JsonProperty("line")]
        //    public int Line { get; set; }

        //    [JsonProperty("url")]
        //    public string Url { get; set; }
        //}

        //public sealed class PurpleFunction
        //{
        //    [JsonProperty("name")]
        //    public string Name { get; set; }
        //}

        //public sealed class PurpleTransition
        //{
        //    [JsonProperty("element")]
        //    public object Element { get; set; }

        //    [JsonProperty("event")]
        //    public string Event { get; set; }

        //    [JsonProperty("options")]
        //    public PurpleOptions Options { get; set; }

        //    [JsonProperty("time")]
        //    public double? Time { get; set; }
        //}

        public sealed class ElementClass
        {
            [JsonProperty("tag_name")]
            public string TagName { get; set; }

            [JsonProperty("attributes")]
            public Attributes Attributes { get; set; }
        }

        public sealed class Attributes
        {
            [JsonProperty("href")]
            public string Href { get; set; }

            [JsonProperty("data-arachni-id")]
            public int DataArachniId { get; set; }

            [JsonProperty("class", NullValueHandling = NullValueHandling.Ignore)]
            public string Class { get; set; }

            [JsonProperty("data-slide", NullValueHandling = NullValueHandling.Ignore)]
            public string DataSlide { get; set; }
        }

        //public sealed class PurpleOptions
        //{
        //    [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
        //    public string Url { get; set; }

        //    [JsonProperty("cookies", NullValueHandling = NullValueHandling.Ignore)]
        //    public DefaultInputs Cookies { get; set; }
        //}

        //public sealed class ReferringPage
        //{
        //    [JsonProperty("body")]
        //    public string Body { get; set; }

        //    [JsonProperty("dom")]
        //    public ReferringPageDom Dom { get; set; }
        //}

        //public sealed class ReferringPageDom
        //{
        //    [JsonProperty("url")]
        //    public string Url { get; set; }

        //    [JsonProperty("transitions")]
        //    public FluffyTransition[] Transitions { get; set; }

        //    [JsonProperty("cookies")]
        //    public object[] Cookies { get; set; }

        //    [JsonProperty("digest")]
        //    public object Digest { get; set; }

        //    [JsonProperty("data_flow_sinks")]
        //    public object[] DataFlowSinks { get; set; }

        //    [JsonProperty("execution_flow_sinks")]
        //    public object[] ExecutionFlowSinks { get; set; }
        //}

        //public sealed class FluffyTransition
        //{
        //    [JsonProperty("element")]
        //    public object Element { get; set; }

        //    [JsonProperty("event")]
        //    public string Event { get; set; }

        //    [JsonProperty("options")]
        //    public FluffyOptions Options { get; set; }

        //    [JsonProperty("time")]
        //    public double? Time { get; set; }
        //}

        //public sealed class FluffyOptions
        //{
        //    [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
        //    public string Url { get; set; }

        //    [JsonProperty("cookies", NullValueHandling = NullValueHandling.Ignore)]
        //    public object Cookies { get; set; }
        //}

        public sealed class Request
        {
            [JsonProperty("url")]
            public string Url { get; set; }

            [JsonProperty("parameters")]
            public Parameters Parameters { get; set; }

            //[JsonProperty("headers")]
            //public Headers Headers { get; set; }

            //[JsonProperty("headers_string")]
            //public string HeadersString { get; set; }

            //[JsonProperty("effective_body")]
            //public string EffectiveBody { get; set; }

            //[JsonProperty("body")]
            //public object Body { get; set; }

            [JsonProperty("method")]
            public string Method { get; set; }
        }

        public sealed class BodyClass
        {
            [JsonProperty("username")]
            public string Username { get; set; }

            [JsonProperty("password")]
            public string Password { get; set; }

            [JsonProperty("loginFormSubmit")]
            public int LoginFormSubmit { get; set; }
        }

        public sealed class Headers
        {
            [JsonProperty("Accept", NullValueHandling = NullValueHandling.Ignore)]
            public string Accept { get; set; }

            [JsonProperty("User-Agent", NullValueHandling = NullValueHandling.Ignore)]
            public string UserAgent { get; set; }

            [JsonProperty("Accept-Language", NullValueHandling = NullValueHandling.Ignore)]
            public string AcceptLanguage { get; set; }

            [JsonProperty("X-Arachni-Scan-Seed", NullValueHandling = NullValueHandling.Ignore)]
            public string XArachniScanSeed { get; set; }

            [JsonProperty("Cookie", NullValueHandling = NullValueHandling.Ignore)]
            public string Cookie { get; set; }

            [JsonProperty("Host", NullValueHandling = NullValueHandling.Ignore)]
            public string Host { get; set; }

            [JsonProperty("Cache-Control", NullValueHandling = NullValueHandling.Ignore)]
            public string CacheControl { get; set; }

            [JsonProperty("Pragma", NullValueHandling = NullValueHandling.Ignore)]
            public string Pragma { get; set; }
        }

        public sealed class Parameters
        {
            [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
            public string Id { get; set; }
        }

        public sealed class Response
        {
            [JsonProperty("headers")]
            public Dictionary<string, string> Headers { get; set; }

            [JsonProperty("url")]
            public string Url { get; set; }

            [JsonProperty("code")]
            public int Code { get; set; }

            [JsonProperty("ip_address", NullValueHandling = NullValueHandling.Ignore)]
            public string IpAddress { get; set; }

            //[JsonProperty("headers_string", NullValueHandling = NullValueHandling.Ignore)]
           // public string HeadersString { get; set; }

            //[JsonProperty("body")]
            //public string Body { get; set; }

            [JsonProperty("time")]
            public double Time { get; set; }

            [JsonProperty("app_time", NullValueHandling = NullValueHandling.Ignore)]
            public double? AppTime { get; set; }

            [JsonProperty("total_time", NullValueHandling = NullValueHandling.Ignore)]
            public double? TotalTime { get; set; }

            [JsonProperty("return_code", NullValueHandling = NullValueHandling.Ignore)]
            public string ReturnCode { get; set; }

            [JsonProperty("return_message", NullValueHandling = NullValueHandling.Ignore)]
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

            [JsonProperty("action", NullValueHandling = NullValueHandling.Ignore)]
            public string Action { get; set; }

            [JsonProperty("method", NullValueHandling = NullValueHandling.Ignore)]
            public string Method { get; set; }

            [JsonProperty("source", NullValueHandling = NullValueHandling.Ignore)]
            public string Source { get; set; }

            [JsonProperty("inputs", NullValueHandling = NullValueHandling.Ignore)]
            public Inputs Inputs { get; set; }

            [JsonProperty("raw_inputs", NullValueHandling = NullValueHandling.Ignore)]
            public object[] RawInputs { get; set; }

            [JsonProperty("default_inputs", NullValueHandling = NullValueHandling.Ignore)]
            public Inputs DefaultInputs { get; set; }

            [JsonProperty("affected_input_name")]
            public string AffectedInputName { get; set; }

            [JsonProperty("affected_input_value", NullValueHandling = NullValueHandling.Ignore)]
            public string AffectedInputValue { get; set; }

            [JsonProperty("seed")]
            public string Seed { get; set; }
        }

        public sealed class Inputs
        {
            [JsonProperty("username", NullValueHandling = NullValueHandling.Ignore)]
            public string Username { get; set; }

            [JsonProperty("message", NullValueHandling = NullValueHandling.Ignore)]
            public string Message { get; set; }

            [JsonProperty("firstName", NullValueHandling = NullValueHandling.Ignore)]
            public string FirstName { get; set; }

            [JsonProperty("lastName", NullValueHandling = NullValueHandling.Ignore)]
            public string LastName { get; set; }

            [JsonProperty("address", NullValueHandling = NullValueHandling.Ignore)]
            public string Address { get; set; }

            [JsonProperty("subject", NullValueHandling = NullValueHandling.Ignore)]
            public string Subject { get; set; }

            [JsonProperty("butonul", NullValueHandling = NullValueHandling.Ignore)]
            public string Butonul { get; set; }

            [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
            public string Url { get; set; }

            [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
            public string Id { get; set; }

            [JsonProperty("password", NullValueHandling = NullValueHandling.Ignore)]
            public string Password { get; set; }

            [JsonProperty("loginFormSubmit", NullValueHandling = NullValueHandling.Ignore)]
            public string LoginFormSubmit { get; set; }
        }

        public sealed class StatisticsInfo
        {
            [JsonProperty("http")]
            public Dictionary<string, double> Http { get; set; }

            [JsonProperty("browser_cluster")]
            public BrowserCluster BrowserCluster { get; set; }

            [JsonProperty("runtime")]
            public double Runtime { get; set; }

            [JsonProperty("found_pages")]
            public int FoundPages { get; set; }

            [JsonProperty("audited_pages")]
            public int AuditedPages { get; set; }

            [JsonProperty("current_page")]
            public string CurrentPage { get; set; }
        }

        public sealed class BrowserCluster
        {
            [JsonProperty("seconds_per_job")]
            public double SecondsPerJob { get; set; }

            [JsonProperty("total_job_time")]
            public int TotalJobTime { get; set; }

            [JsonProperty("queued_job_count")]
            public int QueuedJobCount { get; set; }

            [JsonProperty("completed_job_count")]
            public int CompletedJobCount { get; set; }

            [JsonProperty("time_out_count")]
            public int TimeOutCount { get; set; }
        }
    }
}
