using Newtonsoft.Json;

namespace Structural.Adapter
{
    public class Character
    {
        [JsonProperty("name")]
        public string FullName { get; set; }
        public string Gender { get; set; }
        [JsonProperty("hair_color")]
        public string Hair { get; set; }
    }
}