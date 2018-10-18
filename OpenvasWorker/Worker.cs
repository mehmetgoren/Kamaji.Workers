namespace OpenvasWorker
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Kamaji.Worker;
    using Newtonsoft.Json.Linq;
    using Openvas.Omp.Client;
    using Openvas.Omp.Client.Models;

    public sealed class Worker : WorkerBase
    {
        public override void Dispose()
        {
        }

        public override Task SetupEnvironment() => Task.Delay(0);

        protected override async Task<object> Run_Internal(IObserver observer, string asset, IScanRepository repository, object args)
        {
            if (String.IsNullOrEmpty(asset) || args == null)
                return null;

            string address = args?.ToString();
            OpenvasApi api = new OpenvasApi(address);

            string taskId = asset; 
            var r = await api.StartTask(taskId);

            if (r?.Status == "202")
            {
                while (true)
                {
                    await Task.Delay(1000);
                    GetTasksResponse tasks = await api.GetTasks(new GetTasksRequest {TaskId = taskId});
                    var first = tasks.Tasks.FirstOrDefault();
                    if (null != first)
                    {
                        if (first.Status == "Running" || first.Status == "Requested")
                        {
                            if (first.Progress is JObject jo)
                            {
                                observer.Notify("Openvas_" + taskId, "Progress: " + jo["_"], null);
                            }
                            else if (first.Progress is string progress)
                            {
                                observer.Notify("Openvas_" + taskId, "Progress: " + progress, null);
                            }

                            continue;
                        }
                        else
                        {
                            observer.Notify("Openvas_" + taskId, "Done at : " + DateTime.Now, null);
                        }
                    }
                    else
                    {
                        observer.Notify("Openvas_" + taskId, "couldn't get the task info, operation cancelled", null);
                    }

                    break;
                }


            }

            GetResultsResponse results = await api.GetResults(new GetResultsRequest { TaskId = taskId });

            return results?.Results;
        }
    }
}
