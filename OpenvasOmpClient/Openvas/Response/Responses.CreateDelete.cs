namespace OpenvasOmpClient
{
    using Newtonsoft.Json;
    using System;

    partial class Responses
    {

        public abstract class CreateCommandResponse
        {
            public class StatusInfo
            {
                [JsonProperty("id")]
                public string Id { get; set; }

                [JsonProperty("status_text")]
                public string StatusText { get; set; }

                [JsonProperty("status")]
                public string Status { get; set; }

                public override string ToString() => $"{this.StatusText} - {this.Status} - {this.Id}";
            }

            [JsonProperty("$")]
            public StatusInfo Result { get; set; }
        }

        public sealed class create_credential_response : CreateCommandResponse
        {

        }
        public sealed class delete_credential_response : Response
        {

        }

        public sealed class create_target_response : CreateCommandResponse
        {

        }
        public sealed class delete_target_response : Response
        {

        }


        public sealed class create_task_response : CreateCommandResponse
        {

        }
        public sealed class delete_task_response : Response
        {

        }
    }
}
