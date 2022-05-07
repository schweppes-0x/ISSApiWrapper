using Newtonsoft.Json;

namespace ISSWrapper
{
    public class SatelliteBase
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("id")]
        public int Id { get; set; }
    }
}