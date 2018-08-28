namespace Powershell.Json
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;


    public partial class Welcome
    {
        [JsonProperty("BasePriority")]
        public long BasePriority { get; set; }

        [JsonProperty("ExitCode")]
        public object ExitCode { get; set; }

        [JsonProperty("HasExited")]
        public bool? HasExited { get; set; }

        [JsonProperty("ExitTime")]
        public object ExitTime { get; set; }

        [JsonProperty("Handle")]
        public long? Handle { get; set; }

        [JsonProperty("SafeHandle")]
        public SafeHandle SafeHandle { get; set; }

        [JsonProperty("HandleCount")]
        public long HandleCount { get; set; }

        [JsonProperty("Id")]
        public long Id { get; set; }

        [JsonProperty("MachineName")]
        public MachineName MachineName { get; set; }

        [JsonProperty("MainWindowHandle")]
        public long MainWindowHandle { get; set; }

        [JsonProperty("MainWindowTitle")]
        public string MainWindowTitle { get; set; }

        [JsonProperty("MainModule")]
        public MainModule MainModule { get; set; }

        [JsonProperty("MaxWorkingSet")]
        public long? MaxWorkingSet { get; set; }

        [JsonProperty("MinWorkingSet")]
        public long? MinWorkingSet { get; set; }

        [JsonProperty("Modules")]
        public string[] Modules { get; set; }

        [JsonProperty("NonpagedSystemMemorySize")]
        public long NonpagedSystemMemorySize { get; set; }

        [JsonProperty("NonpagedSystemMemorySize64")]
        public long NonpagedSystemMemorySize64 { get; set; }

        [JsonProperty("PagedMemorySize")]
        public long PagedMemorySize { get; set; }

        [JsonProperty("PagedMemorySize64")]
        public long PagedMemorySize64 { get; set; }

        [JsonProperty("PagedSystemMemorySize")]
        public long PagedSystemMemorySize { get; set; }

        [JsonProperty("PagedSystemMemorySize64")]
        public long PagedSystemMemorySize64 { get; set; }

        [JsonProperty("PeakPagedMemorySize")]
        public long PeakPagedMemorySize { get; set; }

        [JsonProperty("PeakPagedMemorySize64")]
        public long PeakPagedMemorySize64 { get; set; }

        [JsonProperty("PeakWorkingSet")]
        public long PeakWorkingSet { get; set; }

        [JsonProperty("PeakWorkingSet64")]
        public long PeakWorkingSet64 { get; set; }

        [JsonProperty("PeakVirtualMemorySize")]
        public long PeakVirtualMemorySize { get; set; }

        [JsonProperty("PeakVirtualMemorySize64")]
        public long PeakVirtualMemorySize64 { get; set; }

        [JsonProperty("PriorityBoostEnabled")]
        public bool? PriorityBoostEnabled { get; set; }

        [JsonProperty("PriorityClass")]
        public long? PriorityClass { get; set; }

        [JsonProperty("PrivateMemorySize")]
        public long PrivateMemorySize { get; set; }

        [JsonProperty("PrivateMemorySize64")]
        public long PrivateMemorySize64 { get; set; }

        [JsonProperty("PrivilegedProcessorTime")]
        public Dictionary<string, double> PrivilegedProcessorTime { get; set; }

        [JsonProperty("ProcessName")]
        public string ProcessName { get; set; }

        [JsonProperty("ProcessorAffinity")]
        public long? ProcessorAffinity { get; set; }

        [JsonProperty("Responding")]
        public bool Responding { get; set; }

        [JsonProperty("SessionId")]
        public long SessionId { get; set; }

        [JsonProperty("StartInfo")]
        public StartInfo StartInfo { get; set; }

        [JsonProperty("StartTime")]
        public string StartTime { get; set; }

        [JsonProperty("SynchronizingObject")]
        public object SynchronizingObject { get; set; }

        [JsonProperty("Threads")]
        public Thread[] Threads { get; set; }

        [JsonProperty("TotalProcessorTime")]
        public Dictionary<string, double> TotalProcessorTime { get; set; }

        [JsonProperty("UserProcessorTime")]
        public Dictionary<string, double> UserProcessorTime { get; set; }

        [JsonProperty("VirtualMemorySize")]
        public long VirtualMemorySize { get; set; }

        [JsonProperty("VirtualMemorySize64")]
        public long VirtualMemorySize64 { get; set; }

        [JsonProperty("EnableRaisingEvents")]
        public bool EnableRaisingEvents { get; set; }

        [JsonProperty("StandardInput")]
        public object StandardInput { get; set; }

        [JsonProperty("StandardOutput")]
        public object StandardOutput { get; set; }

        [JsonProperty("StandardError")]
        public object StandardError { get; set; }

        [JsonProperty("WorkingSet")]
        public long WorkingSet { get; set; }

        [JsonProperty("WorkingSet64")]
        public long WorkingSet64 { get; set; }

        [JsonProperty("Site")]
        public object Site { get; set; }

        [JsonProperty("Container")]
        public object Container { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("SI")]
        public long Si { get; set; }

        [JsonProperty("Handles")]
        public long Handles { get; set; }

        [JsonProperty("VM")]
        public long Vm { get; set; }

        [JsonProperty("WS")]
        public long Ws { get; set; }

        [JsonProperty("PM")]
        public long Pm { get; set; }

        [JsonProperty("NPM")]
        public long Npm { get; set; }

        [JsonProperty("Path")]
        public string Path { get; set; }

        [JsonProperty("Company")]
        public string Company { get; set; }

        [JsonProperty("CPU")]
        public double? Cpu { get; set; }

        [JsonProperty("FileVersion")]
        public string FileVersion { get; set; }

        [JsonProperty("ProductVersion")]
        public string ProductVersion { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("Product")]
        public string Product { get; set; }

        [JsonProperty("__NounName")]
        public NounName NounName { get; set; }
    }

    public partial class MainModule
    {
        [JsonProperty("ModuleName")]
        public string ModuleName { get; set; }

        [JsonProperty("FileName")]
        public string FileName { get; set; }

        [JsonProperty("BaseAddress")]
        public long BaseAddress { get; set; }

        [JsonProperty("ModuleMemorySize")]
        public long ModuleMemorySize { get; set; }

        [JsonProperty("EntryPointAddress")]
        public long EntryPointAddress { get; set; }

        [JsonProperty("FileVersionInfo")]
        public string FileVersionInfo { get; set; }

        [JsonProperty("Site")]
        public object Site { get; set; }

        [JsonProperty("Container")]
        public object Container { get; set; }
    }

    public partial class SafeHandle
    {
        [JsonProperty("IsInvalid")]
        public bool IsInvalid { get; set; }

        [JsonProperty("IsClosed")]
        public bool IsClosed { get; set; }
    }

    public partial class StartInfo
    {
        [JsonProperty("Verb")]
        public string Verb { get; set; }

        [JsonProperty("Arguments")]
        public string Arguments { get; set; }

        [JsonProperty("CreateNoWindow")]
        public bool CreateNoWindow { get; set; }

        [JsonProperty("EnvironmentVariables")]
        public string EnvironmentVariables { get; set; }

        [JsonProperty("Environment")]
        public string Environment { get; set; }

        [JsonProperty("RedirectStandardInput")]
        public bool RedirectStandardInput { get; set; }

        [JsonProperty("RedirectStandardOutput")]
        public bool RedirectStandardOutput { get; set; }

        [JsonProperty("RedirectStandardError")]
        public bool RedirectStandardError { get; set; }

        [JsonProperty("StandardErrorEncoding")]
        public object StandardErrorEncoding { get; set; }

        [JsonProperty("StandardOutputEncoding")]
        public object StandardOutputEncoding { get; set; }

        [JsonProperty("UseShellExecute")]
        public bool UseShellExecute { get; set; }

        [JsonProperty("Verbs")]
        public string Verbs { get; set; }

        [JsonProperty("UserName")]
        public string UserName { get; set; }

        [JsonProperty("Password")]
        public object Password { get; set; }

        [JsonProperty("PasswordInClearText")]
        public object PasswordInClearText { get; set; }

        [JsonProperty("Domain")]
        public string Domain { get; set; }

        [JsonProperty("LoadUserProfile")]
        public bool LoadUserProfile { get; set; }

        [JsonProperty("FileName")]
        public string FileName { get; set; }

        [JsonProperty("WorkingDirectory")]
        public string WorkingDirectory { get; set; }

        [JsonProperty("ErrorDialog")]
        public bool ErrorDialog { get; set; }

        [JsonProperty("ErrorDialogParentHandle")]
        public long ErrorDialogParentHandle { get; set; }

        [JsonProperty("WindowStyle")]
        public long WindowStyle { get; set; }
    }

    public enum MachineName { Empty };

    public enum NounName { Process };

    public enum Thread { SystemDiagnosticsProcessThread };

    public partial class Welcome
    {
        public static Welcome[] FromJson(string json) => JsonConvert.DeserializeObject<Welcome[]>(json, Powershell.Json.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Welcome[] self) => JsonConvert.SerializeObject(self, Powershell.Json.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                MachineNameConverter.Singleton,
                ThreadConverter.Singleton,
                NounNameConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class MachineNameConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(MachineName) || t == typeof(MachineName?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == ".")
            {
                return MachineName.Empty;
            }
            throw new Exception("Cannot unmarshal type MachineName");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (MachineName)untypedValue;
            if (value == MachineName.Empty)
            {
                serializer.Serialize(writer, ".");
                return;
            }
            throw new Exception("Cannot marshal type MachineName");
        }

        public static readonly MachineNameConverter Singleton = new MachineNameConverter();
    }

    internal class ThreadConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Thread) || t == typeof(Thread?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "System.Diagnostics.ProcessThread")
            {
                return Thread.SystemDiagnosticsProcessThread;
            }
            throw new Exception("Cannot unmarshal type Thread");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Thread)untypedValue;
            if (value == Thread.SystemDiagnosticsProcessThread)
            {
                serializer.Serialize(writer, "System.Diagnostics.ProcessThread");
                return;
            }
            throw new Exception("Cannot marshal type Thread");
        }

        public static readonly ThreadConverter Singleton = new ThreadConverter();
    }

    internal class NounNameConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(NounName) || t == typeof(NounName?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "Process")
            {
                return NounName.Process;
            }
            throw new Exception("Cannot unmarshal type NounName");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (NounName)untypedValue;
            if (value == NounName.Process)
            {
                serializer.Serialize(writer, "Process");
                return;
            }
            throw new Exception("Cannot marshal type NounName");
        }

        public static readonly NounNameConverter Singleton = new NounNameConverter();
    }
}