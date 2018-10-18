namespace Arachni.RestApi.Client.Models
{
    public sealed class ScansResponse
    {
        public  string Id { get; set; }

        public override string ToString() => this.Id;
    }
}
