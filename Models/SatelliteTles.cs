using Newtonsoft.Json;

namespace ISSWrapper
{
    public class SatelliteTles : SatelliteBase
    {
        [JsonProperty("requested_timestamp")]
        public int RequestedTimestamp { get; set; }
        [JsonProperty("tle_timestamp")]
        public int TleTimestamp { get; set; }
        [JsonProperty("header")]
        public string Header { get; set; }
        [JsonProperty("line1")]
        public string LineOne { get; set; }
        [JsonProperty("line2")]
        public string LineTwo { get; set; }
    }
}