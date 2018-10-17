namespace Openvas.Omp.Client
{
    using Openvas.Omp.Client.Models;
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;

    public sealed partial class OpenvasApi
    {
        public string Address { get; } 

        public OpenvasApi(string address)
        {
            this.Address = address ?? throw new ArgumentNullException(nameof(address));
        }

        public async Task<OmpVersion> GetOmpVersion()
        {
            var result = await Omp.QueryAsync<Responses.get_version_response>(this.Address, new Requests.get_version());
            return new OmpVersion {Version = result?.version?.FirstOrDefault().ToString()};
        }

        public async Task<GetCredentialResponse> GetCredential()
        {
            var result = await Omp.QueryAsync<Responses.get_credentials_response>(this.Address, new Requests.get_credentials());
            return result?.Beautify();
        }

        public async Task<GetConfigResponse> GetConfig()
        {
            var result = await Omp.QueryAsync<Responses.get_configs_response>(this.Address, new Requests.get_configs());
            return result?.Beautify();
        }

        public async Task<GetNvtFamiliesResponse> GetNvtFamilies()
        {
            var result = await Omp.QueryAsync<Responses.get_nvt_families_response>(this.Address, new Requests.get_nvt_families());
            return result?.Beautify();
        }

        private static void CopyPropertiesFrom<T>(T destObject, T sourceObject)
        {
            if (null == destObject)
                throw new ArgumentNullException(nameof(destObject));
            if (null == sourceObject)
                throw new ArgumentNullException(nameof(sourceObject));

            foreach (PropertyInfo pi in typeof(T).GetTypeInfo().GetProperties(BindingFlags.Instance | BindingFlags.Public))
            {
                if (null != pi.SetMethod)
                {
                    object sourcePropertyValue = pi.GetValue(sourceObject);
                    pi.SetValue(destObject, sourcePropertyValue, null);
                }
            }
        }
        public async Task<GetReportsResponse> GetReports(GetReportsRequest request)
        {
            var @params = new Requests.get_reports();
            if (null != request)
                CopyPropertiesFrom(@params, request);
            var result = await Omp.QueryAsync<Responses.get_reports_response>(this.Address, @params);
            return result?.Beautify();
        }

        public async Task<GetResultsResponse> GetResults(GetResultsRequest request)
        {
            var @params = new Requests.get_results();
            if (null != request)
                CopyPropertiesFrom(@params, request);

            var result = await Omp.QueryAsync<Responses.get_results_response>(this.Address, @params);
            return result?.Beautify();
        }

        public async Task<GetTargetsResponse> GetTargets(GetTargetsRequest request)
        {
            var @params = new Requests.get_targets();
            if (null != request)
                CopyPropertiesFrom(@params, request);

            var result = await Omp.QueryAsync<Responses.get_targets_response>(this.Address, @params);
            return result?.Beautify();
        }

        public async Task<GetTasksResponse> GetTasks(GetTasksRequest request)
        {
            var @params = new Requests.get_tasks();
            if (null != request)
                CopyPropertiesFrom(@params, request);

            var result = await Omp.QueryAsync<Responses.get_tasks_response>(this.Address, @params);
            return result?.Beautify();
        }

        public async Task<GetScannersResponse> GetScanners(GetScannersRequest request)
        {
            var @params = new Requests.get_scanners();
            if (null != request)
                CopyPropertiesFrom(@params, request);

            var result = await Omp.QueryAsync<Responses.get_scanners_response>(this.Address, @params);
            return result?.Beautify();
        }
    }
}
