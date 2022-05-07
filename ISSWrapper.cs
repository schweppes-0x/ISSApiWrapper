using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ISSWrapper
{
    /// <summary>
    /// API wrapper made for easy retrieval of satellite data. More information about this API can be found at https://wheretheiss.at/ and https://wheretheiss.at/w/developer 
    /// </summary>
    public static class IssWrapper
    {
        /// <summary>
        /// This function returns a list of satellites that this API has information about, inluding a common name and NORAD catalog id.
        /// Currently, there is only one, the International Space Station. But in the future, we plan to provide more.
        /// </summary>
        /// <returns>A list of <see cref="SatelliteBase"/> instances which are currently supported by the WHERE THE ISS AT</returns>
        public static async Task<SatelliteBase[]> GetAllSatellitesAsync() => await GetApiDataAsync<SatelliteBase[]>(ApiUrls.BaseUrl + ApiUrls.AllSatelitesEndpoint);
        
        /// <summary>
        /// Returns position, velocity, and other related information about a satellite for a given point in time.
        /// [id] is required and should be the NORAD catalog id. For the ISS, that id is 25544. To get information about all the supported NORAD ids refer to <see cref="GetAllSatellitesAsync"/>.
        /// </summary>
        /// <param name="satelliteId">NORAD Id (default is 25544)</param>
        /// <param name="measureUnit">The measure units, either "miles" or "kilometers" with the latter being the default.</param>
        /// <returns>Instance of the <see cref="SatelliteData"/> class.</returns>
        public static async Task<SatelliteData> GetSatelliteDataAsync(int satelliteId = 25544, string measureUnit = "kilometers") => await GetApiDataAsync<SatelliteData>($"{ApiUrls._specificSatelitesEndpoint(satelliteId)}&units={measureUnit}");

        /// <summary>
        /// Returns a list in which each entry contains position, velocity, and other related information about a satellite for a comma delimited list of timestamps (up to 10).
        /// [id] is required and should be the NORAD catalog id. For the ISS, that id is 25544.
        /// </summary>
        /// <param name="timestamps">Specify a comma delimited list of timestamps for orbital positions, limit 10 per request</param>
        /// <param name="id">NORAD Id (default is 25544)</param>
        /// <param name="measureUnit">The measure units, either "miles" or "kilometers" with the latter being the default.</param>
        /// <returns>List of instances of the <see cref="SatelliteData"/> class.</returns>
        public static async Task<SatelliteData[]> GetPositionsAsync(int[] timestamps, int id = 25544,  string measureUnit = "kilometers") => await GetApiDataAsync<SatelliteData[]>(ApiUrls._satellitePositionsEndpoint(id, timestamps, measureUnit));

        /// <summary>
        ///  Returns the TLE data for a given satellite
        /// </summary>
        /// <param name="id">NORAD Id (default is 25544)</param>
        /// <returns>Instance of the <see cref="SatelliteTles"/> class.</returns>
        public static async Task<SatelliteTles> GetSatelliteTlesAsync(int id = 25544) => await GetApiDataAsync<SatelliteTles>(ApiUrls._satelliteTleEndpoint(id));

        /// <summary>
        /// Returns position, current time offset, country code, and timezone id for a given set of coordinates in the format of longitude,latitude
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <returns>Instance of the <see cref="Coordinate"/> class.</returns>
        public static async Task<Coordinate> GetCoordinateAsync(float latitude, float longitude) => await GetApiDataAsync<Coordinate>(ApiUrls._satelliteCoordinateEndpoint(latitude, longitude));
        private static async Task<T> GetApiDataAsync<T>(string url)
        {
            try	
            {
                var response = await new HttpClient().GetAsync(url);
                response.EnsureSuccessStatusCode();
                
                return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
            }
            catch(HttpRequestException e)
            {
                throw;
            }
        }
    }
}