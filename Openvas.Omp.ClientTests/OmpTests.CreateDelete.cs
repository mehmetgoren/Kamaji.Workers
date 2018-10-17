namespace Openvas.Omp.ClientTests
{
    using Openvas.Omp.Client.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Openvas.Omp.Client;
    using System.Threading.Tasks;

    partial class OmpTests
    {
        [TestMethod]
        public async Task CreateCredentialTest()
        {
            OpenvasApi api = new OpenvasApi(Address);
            var resultCreate = await api.CreateCredential(new CreateCredentialRequest { Name = "user0", Login = "user", Password = "1234", Comment = "this is my first time." });
            Assert.IsNotNull(resultCreate);

            var resultDelete = await api.DeleteCredential(new DeleteCredentialRequest { CredentialId = resultCreate?.Id });
            Assert.IsNotNull(resultDelete);
        }

        [TestMethod]
        public async Task CreateTargetTest()
        {
            OpenvasApi api = new OpenvasApi(Address);
            var resultCreate = await api.CreateTarget(new CreateTargetRequest
            {
                Name = "AnkaraWnd via OMP",
                Comment = "this is my first time.",
                Hosts = "192.168.0.21",
                SshLscCredential = "38c7abb1-aea4-4fde-8f46-3a582758e87c",
                SmbLscCredential = "38c7abb1-aea4-4fde-8f46-3a582758e87c",
                EsxiLscCredential = "38c7abb1-aea4-4fde-8f46-3a582758e87c"
            });
            //string j11 = JsonConvert.SerializeObject(r11);
            Assert.IsNotNull(resultCreate);

            var r2 = await api.DeleteTarget(new DeleteTargetRequest { TargetId = resultCreate?.Id });
            Assert.IsNotNull(r2);
        }

        [TestMethod]
        public async Task CreateTaskTest()
        {
            OpenvasApi api = new OpenvasApi(Address);
            var resultCreate = await api.CreateTask(new CreateTaskRequest
            {
                Name = "Task For Testing",
                Comment = "Testing is our job.",
                Config = "8715c877-47a0-438d-98a3-27c7a6ab2196",//discovery
                Target = "bdeb8032-c1d2-489a-b8d2-3c229ed04b5c",//ankara
                Scanner = "08b69003-5fc2-4037-a479-93b440211c73"//oepnvas default
            });
            Assert.IsNotNull(resultCreate);

            var r2 = await api.DeleteTask(new DeleteTaskRequest { TaskId = resultCreate?.Id });
            Assert.IsNotNull(r2);
        }
    }
}
