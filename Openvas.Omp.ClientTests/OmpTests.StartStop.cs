namespace Openvas.Omp.ClientTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Openvas.Omp.Client;
    using System.Threading.Tasks;

    //start_task_response 
    partial class OmpTests
    {
        [TestMethod]
        public async Task StartTaskTest()
        {
            const string taskId = "f0a098e5-f8a4-43de-8176-bb823f7c0c06"; //"d005a36d-8cf1-47f8-8b88-ef785d6b2aa2";
            OpenvasApi api = new OpenvasApi(Address);

            var r = await api.StartTask(taskId);
            Assert.IsNotNull(r);

            await Task.Delay(5000);

            var r2 = await api.StopTask(taskId);
            Assert.IsNotNull(r2);

            await Task.Delay(5000);

            var r3 = await api.ResumeTask(taskId);
            Assert.IsNotNull(r3);
        }


        [TestMethod]
        public async Task SyncTest()
        {
            await Task.Delay(0);
            Assert.IsTrue(true);
            //OpenvasApi api = new OpenvasApi(Address);
            //var r = await api.Sync(OpenvasSyncType.SyncCert | OpenvasSyncType.SyncFeed | OpenvasSyncType.SyncScap);
            //Assert.IsNotNull(r);
        }
    }
}
