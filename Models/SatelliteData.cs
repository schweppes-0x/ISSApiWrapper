using Newtonsoft.Json;

namespace ISSWrapper
{
    public class SatelliteData : SatelliteBase
    {
        [JsonProperty("latitude")]
        public float Latitude { get; set; }
        
        [JsonProperty("longitude")]
        public float Longitude { get; set; }
        
        [JsonProperty("altitude")]
        public float Altitude { get; set; }
        
        [JsonProperty("velocity")]
        public float Velocity { get; set; }

        [JsonProperty("visibility")]
        public string Visibility { get; set; }
        
        [JsonProperty("footprint")]
        public float Footprint { get; set; }
        
        [JsonProperty("timestamp")]
        public float Timestamp { get; set; }
        
        [JsonProperty("daynum")]
        public float Daynum { get; set; }
        
        [JsonProperty("solar_lat")]
        public float SolarLatitude { get; set; }
        
        [JsonProperty("solar_lon")]
        public float SolarLongitute { get; set; }
        
        [JsonProperty("units")]
        public string MeasureUnits { get; set; }
    }
}