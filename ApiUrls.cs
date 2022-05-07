using System.Collections.Generic;
using System.Linq;

namespace ISSWrapper
{
    public static class ApiUrls
    {
        public static string BaseUrl => "https://api.wheretheiss.at/v1";
        public static string AllSatelitesEndpoint => "/satellites";
        public static string CoordinatesEndpoint => "/coordinates";
        public static string PositionsEndpoint => "/positions"; 
        public static string _specificSatelitesEndpoint(int id) => $"{BaseUrl}{AllSatelitesEndpoint}/{id}";
        public static string _satellitePositionsEndpoint(int id, IEnumerable<int> timestamps, string measureUnit) => $"{_specificSatelitesEndpoint(id)}{PositionsEndpoint}?timestamps={string.Join(",", timestamps.Take(10))}&units={measureUnit}";
        public static string _satelliteCoordinateEndpoint(float latitude, float longitude) => $"{BaseUrl}{CoordinatesEndpoint}/{latitude},{longitude}";
        public static string _satelliteTleEndpoint(int id) => $"{_specificSatelitesEndpoint(id)}/tles";

    }
}