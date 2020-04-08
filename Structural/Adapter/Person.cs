using Newtonsoft.Json;

namespace Structural.Adapter
{
    public class Person
    {
        public virtual string Name { get; set;  }
        public virtual string Gender { get; set; }
        [JsonProperty("hair_color")]
        public virtual string HairColor { get; set; }
    }
}