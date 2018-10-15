namespace OpenvasOmpClient
{
    using System.Threading.Tasks;
    using OpenvasOmpClient.Models;

    partial class OpenvasApi
    {
        private static CreateCommandResponse CreateCommand(Responses.CreateCommandResponse result)
        {
            CreateCommandResponse ret = new CreateCommandResponse();
            if (result?.Result != null)
            {
                CopyPropertiesFrom(ret, result.Result);
            }

            return ret;
        }
        private static GenericResponse Generic(Responses.Response result)
        {
            GenericResponse ret = new GenericResponse();
            if (result?.Status != null)
            {
                CopyPropertiesFrom(ret, result.Status);
            }

            return ret;
        }


        public async Task<CreateCommandResponse> CreateCredential(CreateCredentialRequest request)
        {
            var @params = new Requests.create_credential();
            if (null != request)
                CopyPropertiesFrom(@params, request);

            var result = await Omp.QueryAsync<Responses.create_credential_response>(this.Address, @params);

            return CreateCommand(result);
        }
        public async Task<GenericResponse> DeleteCredential(DeleteCredentialRequest request)
        {
            var @params = new Requests.delete_credential();
            if (null != request)
                CopyPropertiesFrom(@params, request);

            var result = await Omp.QueryAsync<Responses.delete_credential_response>(this.Address, @params);

            return Generic(result);
        }


        public async Task<CreateCommandResponse> CreateTarget(CreateTargetRequest request)
        {
            var @params = new Requests.create_target();
            if (null != request)
                CopyPropertiesFrom(@params, request);

            var result = await Omp.QueryAsync<Responses.create_target_response>(this.Address, @params);

            return CreateCommand(result);
        }
        public async Task<GenericResponse> DeleteTarget(DeleteTargetRequest request)
        {
            var @params = new Requests.delete_target();
            if (null != request)
                CopyPropertiesFrom(@params, request);

            var result = await Omp.QueryAsync<Responses.delete_target_response>(this.Address, @params);

            return Generic(result);
        }


        public async Task<CreateCommandResponse> CreateTask(CreateTaskRequest request)
        {
            var @params = new Requests.create_task();
            if (null != request)
                CopyPropertiesFrom(@params, request);

            var result = await Omp.QueryAsync<Responses.create_task_response>(this.Address, @params);

            return CreateCommand(result);
        }
        public async Task<GenericResponse> DeleteTask(DeleteTaskRequest request)
        {
            var @params = new Requests.delete_task();
            if (null != request)
                CopyPropertiesFrom(@params, request);

            var result = await Omp.QueryAsync<Responses.delete_task_response>(this.Address, @params);

            return Generic(result);
        }
    }
}
