namespace OpenvasOmpClientTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using OpenvasOmpClient;
    using OpenvasOmpClient.Models;
    using System.Threading.Tasks;

    [TestClass]
    public sealed partial class OmpTests
    {
        private const string Address = "http://192.168.0.31:3000";
        [TestMethod]
        public async Task GetVersionTest()
        {
            OpenvasApi api = new OpenvasApi(Address);
            OmpVersion version = await api.GetOmpVersion();
            Assert.IsNotNull(version);
        }


        [TestMethod]
        public async Task GetCredentialsTest()
        {
            OpenvasApi api = new OpenvasApi(Address);
            GetCredentialResponse credential = await api.GetCredential();
            Assert.IsNotNull(credential?.Credentials);
        }

        [TestMethod]
        public async Task GetConfigsTest()
        {
            OpenvasApi api = new OpenvasApi(Address);
            GetConfigResponse config = await api.GetConfig();
            //string j = JsonConvert.SerializeObject(config);
        }

        [TestMethod]
        public async Task GetNvtFamiliesTest()
        {
            OpenvasApi api = new OpenvasApi(Address);
            GetNvtFamiliesResponse familes = await api.GetNvtFamilies();
            Assert.IsNotNull(familes.Families);
        }


        [TestMethod]
        public async Task GetReportsTest()
        {
            OpenvasApi api = new OpenvasApi(Address);
            GetReportsResponse reports = await api.GetReports(new GetReportsRequest {ReportId = "4e1adb68-a2f7-409a-8393-926e9c8c7821" });
            Assert.IsNotNull(reports.Results);
            //string j = JsonConvert.SerializeObject(reports);
        }

        [TestMethod]
        public async Task GetResultsTest()
        {
            OpenvasApi api = new OpenvasApi(Address);
            GetResultsResponse results = await api.GetResults(new GetResultsRequest {TaskId = "f0a098e5-f8a4-43de-8176-bb823f7c0c06"});
            Assert.IsNotNull(results.Results);
            //string j = JsonConvert.SerializeObject(results);
        }

        [TestMethod]
        public async Task GetTargetsTest()
        {
            OpenvasApi api = new OpenvasApi(Address);
            GetTargetsResponse targets = await api.GetTargets(new GetTargetsRequest());
            Assert.IsNotNull(targets.Targets);

            string j = JsonConvert.SerializeObject(targets);
        }

        [TestMethod]
        public async Task GetTasksTest()
        {
            OpenvasApi api = new OpenvasApi(Address);
            GetTasksResponse tasks = await api.GetTasks(new GetTasksRequest());// { TaskId = "9f1c770b-22b6-4df9-9c2b-01b489ff466f" });
            Assert.IsNotNull(tasks.Tasks);

            string j = JsonConvert.SerializeObject(tasks);
        }


        [TestMethod]
        public async Task GetScannersTest()
        {
            OpenvasApi api = new OpenvasApi(Address);
            GetScannersResponse scanners = await api.GetScanners(new GetScannersRequest());
            Assert.IsNotNull(scanners.Scanners);
            string j = JsonConvert.SerializeObject(scanners);
        }
    }
}
