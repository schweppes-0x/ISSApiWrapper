using Newtonsoft.Json;

namespace ISSWrapper
{
    public class Coordinate
    {
        [JsonProperty("latitude")]
        public double Latitude { get; set; }
        
        [JsonProperty("longitude")]
        public double Longitude { get; set; }
        
        [JsonProperty("timezone_id")]
        public string TimeZone { get; set; }
        
        [JsonProperty("offset")]
        public int Offset { get; set; }
        
        [JsonProperty("country_code")]
        public string CountryCode { get; set; }
        
        [JsonProperty("map_url")]
        public string MapUrl { get; set; }

    }
}