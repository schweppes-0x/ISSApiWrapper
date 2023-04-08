#.NET IIS API Wrapper 

A simple wrapper for the API at https://wheretheiss.at/w/developer. 

![image](https://user-images.githubusercontent.com/88944709/230719678-6bc1e9a7-43a5-430b-a713-6f3812e65c0d.png)


##Features

Get all satellites : 
```c#
SatelliteBase[] allSatellites = await ISSWrapper.IssWrapper.GetAllSatellitesAsync();
```


---
Get information about a specific satellite:
```c#
int noradID = 25544;

//since we're using the default value(25544), we don't need to pass it as an parameter.
SatelliteData satelliteData = await ISSWrapper.IssWrapper.GetSatelliteDataAsync();
```
---
Get information about specific coordinates:
```c#
float latitude= 37.795517f;
float longitude = -122.393693f;

CoordinateData foundData = await ISSWrapper.IssWrapper.GetCoordinateAsync(latitude,longitude);
```
---

Get a list in which each entry contains position, velocity, and other related information about a satellite for a comma delimited list of timestamps (up to 10):
```c#
var timestamps = new int[]
        {
            1436029892,
            1436029902
        };
        
SatelliteData[] satelliteData = await ISSWrapper.IssWrapper.GetPositionsAsync(timestamps);
        
```
---
Get satellite TLES data:
```c#
SatelliteTles satelliteTles = await ISSWrapper.IssWrapper.GetSatelliteTlesAsync();
```

