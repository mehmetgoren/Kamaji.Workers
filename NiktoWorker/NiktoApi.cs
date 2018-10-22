namespace NiktoWorker
{
    using System;
    using System.Threading.Tasks;

    public sealed class NiktoApi
    {
        public string Address { get; }

        public NiktoApi(string address)
        {
            this.Address = address ?? throw new ArgumentNullException(nameof(address));
        }

        public async Task<CreateScanResponse> CreateScan(CreateScanRequest request)
        {
            if (null != request && !String.IsNullOrEmpty(request.Asset))
            {
                RestClient client = new RestClient(this.Address);
                CreateScanResponse response = await client.PostAsync<CreateScanResponse>("createScan", request);
                return response;
            }

            return null;
        }

        public async Task<GetResultResponse> GetResult(string id0)
        {
            if (!String.IsNullOrEmpty(id0))
            {
                RestClient client = new RestClient(this.Address);
                GetResultResponseUgly response = await client.GetAsync<GetResultResponseUgly>("getResult?id0=" + id0);
                return response?.Beatify();
            }

            return null;
        }

        public async Task<bool> StopScan(StopScanRequest request)
        {
            if (null != request && !String.IsNullOrEmpty(request.Id0) && !String.IsNullOrEmpty(request.Id1))
            {
                RestClient client = new RestClient(this.Address);
                return await client.PostAsync<bool>("stopScan", request);
            }

            return false;
        }
    }
}
