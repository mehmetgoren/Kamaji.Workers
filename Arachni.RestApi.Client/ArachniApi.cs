namespace Arachni.RestApi.Client
{
    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Threading.Tasks;
    using Models;

    public sealed class ArachniApi
    {
        public string Address { get; }

        public ArachniApi(string address)
        {
            this.Address = address ?? throw new ArgumentNullException(nameof(address));
        }

        public async Task<IEnumerable<ScansResponse>> GetScanList()
        {
            List<ScansResponse> ret = new List<ScansResponse>();

            RestClient client = new RestClient(this.Address);
            string json = await client.GetAsync<string>("scans");
            if (!String.IsNullOrEmpty(json))
            {
                json = json.Replace("{", "").Replace("}", "").Replace(":", "").Replace("\"","").Trim();
                if (json.Length > 0)
                {
                    string[] splits = json.Split(',');
                    if (splits.Length > 0)
                    {
                        foreach (var id in splits)
                        {
                            ret.Add(new ScansResponse { Id = id});
                        }
                    }
                }
            }

            return ret;
        }

        public async Task<ProgressResponse> GetProgress(string id)
        {
            if (!String.IsNullOrEmpty(id))
            {
                RestClient client = new RestClient(this.Address);
                return await client.GetAsync<ProgressResponse>("progress?id=" + id);
            }

            return null;
        }

        public async Task<SummaryResponse> GetSummary(string id)
        {
            if (!String.IsNullOrEmpty(id))
            {
                RestClient client = new RestClient(this.Address);
                return await client.GetAsync<SummaryResponse>("summary?id=" + id);
            }

            return null;
        }

        public async Task<ReportResponse> GetReport(string id)
        {
            if (!String.IsNullOrEmpty(id))
            {
                RestClient client = new RestClient(this.Address);
                return await client.GetAsync<ReportResponse>("report?id=" + id);
            }

            return null;
        }

        public async Task<string> NewScan(PostRequest request)
        {
            if (null != request && !String.IsNullOrEmpty(request.Url))
            {
                RestClient client = new RestClient(this.Address);
                IDictionary<string, object> result = await client.PostAsync<ExpandoObject>("newscan", request);
                return result["id"]?.ToString();
            }

            return null;
        }

        public async Task<bool> PauseScan(string id)
        {
            if (!String.IsNullOrEmpty(id))
            {
                RestClient client = new RestClient(this.Address);
                string result = await client.GetAsync<string>("pause?id=" + id);
                return true;
            }

            return false;
        }

        public async Task<bool> ResumeScan(string id)
        {
            if (!String.IsNullOrEmpty(id))
            {
                RestClient client = new RestClient(this.Address);
                return await client.GetAsync<bool>("resume?id=" + id);
            }

            return false;
        }

        public async Task<bool> DeleteScan(string id)
        {
            if (!String.IsNullOrEmpty(id))
            {
                RestClient client = new RestClient(this.Address);
                return await client.GetAsync<bool>("delete?id=" + id);
            }

            return false;
        }
    }
}
