namespace OpenvasOmpClient
{
    using System.Threading.Tasks;
    using OpenvasOmpClient.Models;
    using System;

    partial class OpenvasApi
    {
        public async Task<GenericResponse> StartTask(string taskId)
        {
            if (String.IsNullOrEmpty(taskId))
                throw new ArgumentNullException(nameof(taskId));

            var result = await Omp.QueryAsync<Responses.start_task_response>(this.Address, new Requests.start_task { TaskId = taskId });

            return Generic(result);
        }

        public async Task<GenericResponse> StopTask(string taskId)
        {
            if (String.IsNullOrEmpty(taskId))
                throw new ArgumentNullException(nameof(taskId));

            var result = await Omp.QueryAsync<Responses.stop_task_response>(this.Address, new Requests.stop_task { TaskId = taskId });

            return Generic(result);
        }

        public async Task<GenericResponse> ResumeTask(string taskId)
        {
            if (String.IsNullOrEmpty(taskId))
                throw new ArgumentNullException(nameof(taskId));

            var result = await Omp.QueryAsync<Responses.resume_task_response>(this.Address, new Requests.resume_task { TaskId = taskId });

            return Generic(result);
        }

        public async Task<GenericResponse> Sync(OpenvasSyncType syncType)
        {
            Responses.Response ret = null;
            if (syncType.HasFlag(OpenvasSyncType.SyncCert))
                ret = await Omp.QueryAsync<Responses.sync_cert_response>(this.Address, new Requests.sync_cert());
            if (syncType.HasFlag(OpenvasSyncType.SyncFeed))
                ret = await Omp.QueryAsync<Responses.sync_feed_response>(this.Address, new Requests.sync_feed());
            if (syncType.HasFlag(OpenvasSyncType.SyncScap))
                ret = await Omp.QueryAsync<Responses.sync_scap_response>(this.Address, new Requests.sync_scap());

            return Generic(ret);
        }
    }

    [Flags]
    public enum OpenvasSyncType
    {
        SyncCert = 1,
        SyncFeed = 2,
        SyncScap = 4
    }
}
