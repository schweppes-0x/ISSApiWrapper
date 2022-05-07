using System.Linq;
using Xunit;

public class ApiTests
{
    [Fact]
    public async void GetAllSatellites()
    {
        var allSatellites = await ISSWrapper.IssWrapper.GetAllSatellitesAsync();
        Assert.True(allSatellites != null);
        Assert.True(allSatellites.Any());
    }
    
    [Fact]
    public async void GetSpecificSatellite()
    {
        var satelliteData = await ISSWrapper.IssWrapper.GetSatelliteDataAsync();
            
        Assert.True(satelliteData != null);
        Assert.True(satelliteData.Latitude != null);
    }
    
    [Fact]
    public async void GetCoordinatesData()
    {
        float latitude= 37.795517f;
        float longitude = -122.393693f;
        
        var foundSatellite = await ISSWrapper.IssWrapper.GetCoordinateAsync(latitude,longitude);

        var extectedTimeZoneId = "America/Los_Angeles";
        var expectedOffset = -7;
        var exptectedCountryCode = "US";

        var actualTimeZoneId = foundSatellite.TimeZone;
        var actualOffset = foundSatellite.Offset;
        var actualCountryCode = foundSatellite.CountryCode;
        
        Assert.True(foundSatellite != null);
        
        Assert.Equal(extectedTimeZoneId, actualTimeZoneId);
        Assert.Equal(expectedOffset, actualOffset);
        Assert.Equal(exptectedCountryCode, actualCountryCode);
    }
    
    [Fact]
    public async void GetPositionsFromTimestamps()
    {
        var timestamps = new int[]
        {
            1436029892,
            1436029902
        };
        
        var satelliteData = await ISSWrapper.IssWrapper.GetPositionsAsync(timestamps);
        
        Assert.True(satelliteData != null);
        Assert.True(satelliteData.Length == 2);
        Assert.True(satelliteData[0].Name == "iss");
    }    
    
    [Fact]
    public async void GetSatelliteTLES()
    {
        var satelliteData = await ISSWrapper.IssWrapper.GetSatelliteTlesAsync();
        
        Assert.True(satelliteData != null);
        Assert.True(satelliteData.Header == "ISS (ZARYA)");
    }
}