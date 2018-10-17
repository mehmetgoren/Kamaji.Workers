namespace Openvas.Omp.Client.Models
{
    using System;


    public sealed class GetReportsRequest : Requests.get_reports { }

    public sealed class GetResultsRequest : Requests.get_results { }

    public sealed class GetTargetsRequest : Requests.get_targets { }

    public sealed class GetTasksRequest : Requests.get_tasks { }

    public sealed class GetScannersRequest : Requests.get_scanners { }

    public sealed class CreateCredentialRequest : Requests.create_credential { }

    public sealed class DeleteCredentialRequest : Requests.delete_credential { }

    public sealed class CreateTargetRequest : Requests.create_target { }
    
    public sealed class DeleteTargetRequest : Requests.delete_target { }

    public sealed class CreateTaskRequest : Requests.create_task { }

    public sealed class DeleteTaskRequest : Requests.delete_task { }
}
