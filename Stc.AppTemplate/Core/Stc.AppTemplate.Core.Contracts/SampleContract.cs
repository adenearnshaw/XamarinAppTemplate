using Newtonsoft.Json;

namespace Stc.AppTemplate.Core.Contracts
{
    public class SampleContract
    {
        [JsonProperty]
        public string Name { get; set; }
    }
}
