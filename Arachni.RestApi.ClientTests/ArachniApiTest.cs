namespace Arachni.RestApi.ClientTests
{
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;
    using Client;
    using Client.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;


    [TestClass]
    public class ArachniApiTest
    {
        private const string Address = "http://192.168.0.31:3001";

        private static string id = "77319420bbea96831236b72c373b8181";

        [TestMethod]
        public async Task NewScanTest()
        {
            ArachniApi api = new ArachniApi(Address);
            string result = await api.NewScan(PostRequest.Create("http://testhtml5.vulnweb.com"));
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task GetScanListTest()
        {
            ArachniApi api = new ArachniApi(Address);
            IEnumerable<ScansResponse> result = await api.GetScanList();
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task GetProgressTest()
        {
            ArachniApi api = new ArachniApi(Address);
            ProgressResponse result = await api.GetProgress(id);
            Assert.IsNotNull(result);
            string j = JsonConvert.SerializeObject(result);
            await File.WriteAllTextAsync("d:\\result_progress.json", j);
        }

        [TestMethod]
        public async Task GetSummaryTest()
        {
            ArachniApi api = new ArachniApi(Address);
            SummaryResponse result = await api.GetSummary(id);
            Assert.IsNotNull(result);
            string j = JsonConvert.SerializeObject(result);
            await File.WriteAllTextAsync("d:\\result_summary.json", j);
        }

        [TestMethod]
        public async Task GetReportTest()
        {
            ArachniApi api = new ArachniApi(Address);
            ReportResponse result = await api.GetReport(id);
            Assert.IsNotNull(result);
            string j = JsonConvert.SerializeObject(result);
            await File.WriteAllTextAsync("d:\\result_report.json", j);
        }

        [TestMethod]
        public async Task PauseScanTest()
        {
            ArachniApi api = new ArachniApi(Address);
            bool result = await api.PauseScan(id);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task ResumeScanTest()
        {
            ArachniApi api = new ArachniApi(Address);
            bool result = await api.ResumeScan(id);
            Assert.IsNotNull(result);
        }


        [TestMethod]
        public async Task DeleteScanTest()
        {
            ArachniApi api = new ArachniApi(Address);
            bool result = await api.DeleteScan("3e7ab3d000ca4ccaafa9cf1f90025e25");
            Assert.IsNotNull(result);
        }
    }
}
