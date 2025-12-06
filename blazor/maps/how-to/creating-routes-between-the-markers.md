---
layout: post
title: How to create routes between markers in Maps Component | Syncfusion
description: Learn how to create routes between markers in the Syncfusion Blazor Maps component using API and navigation lines.
platform: Blazor
control: Maps
documentation: ug
---

# Creating Routes Between Markers in the Blazor Maps component

The Syncfusion<sup style="font-size:70%">&reg;</sup> Maps component supports plotting routes between two locations (source and destination) using the navigation line feature. Markers can be placed at these locations to indicate the source and destination, providing a clear view of the path on the map.

The data for navigation routes must be retrieved from an external source, such as the Google Maps Directions API. The following steps outline how to create a route using coordinates obtained from the Google Maps Directions API.

1. Initialize the Google Maps Directions API.
2. Create input fields for the source and destination.
3. Fetch the coordinates from the Google Maps Directions API.
4. Plot markers on the map at the specified locations.
5. Generate and visualize the route between the source and destination.

Similarly, coordinates can be retrieved from other services and integrated into the Maps component.

## Initialize the Google Maps Directions API

To access the Google Maps Directions API, include the following script file in the HTML page and add the generated API key to the script URL.

```

<script src="https://maps.googleapis.com/maps/api/js?key=Your_Key&callback=initMap&v=weekly" defer></script>
<script src="~/external-source.js"></script>

```

## Create Input Fields for Source and Destination

To obtain the source and destination, create two text box input fields. Additionally, include a button to generate routes on the map based on the entered values. The process for generating routes on button click is explained in the next section.

## Fetch coordinates from Google API

To obtain the geographic coordinates (latitude and longitude) from the Google Directions API, send a request to the API with the specified address to retrieve the corresponding coordinates. These coordinates can then be used to add markers and navigation lines to create a route on the map.

```

private string markerSource = string.Empty;
private string markerDestination = string.Empty;
public List<double> LatitudePoints = new List<double>();
public List<double> LongitudePoints = new List<double>();
private ObservableCollection<MapMarker> Cities = new ObservableCollection<MapMarker>();

public class MapMarker
{
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public string Name { get; set; }
}

public void ClearPoints()
{
    Cities.Clear();
    LatitudePoints.Clear();
    LongitudePoints.Clear();
}

public async Task AddRoutes()
{
    ClearPoints();
    if (markerSource != string.Empty && markerDestination != string.Empty)
    {
        var response = await JSRuntime.InvokeAsync<JsonElement>("initMap", markerSource, markerDestination);
        Cities.Add(new MapMarker
            {
                Latitude = response.GetProperty("startLocation").GetProperty("latitude").GetDouble(),
                Longitude = response.GetProperty("startLocation").GetProperty("longitude").GetDouble()
            });
        Cities.Add(new MapMarker
            {
                Latitude = response.GetProperty("endLocation").GetProperty("latitude").GetDouble(),
                Longitude = response.GetProperty("endLocation").GetProperty("longitude").GetDouble()
            });
        foreach (var point in response.GetProperty("path").EnumerateArray())
        {
            LatitudePoints.Add(point.GetProperty("latitude").GetDouble());
            LongitudePoints.Add(point.GetProperty("longitude").GetDouble());
        }
    }
}
    
```

### Customize the travel mode in the Google Map Directions API

Coordinates can be retrieved based on different travel modes, such as DRIVING, WALKING, BICYCLING, or TRANSIT, using the Google Maps Directions API. DRIVING is the default travel mode for these services. For additional information on available travel modes, refer to this [link](https://developers.google.com/maps/documentation/javascript/directions#TravelModes).

## Plot markers on the Map

To plot markers on the map, use the retrieved geographic coordinates to place markers at the source and destination locations. This makes the key points along the route easy to identify.

```

        //..
        //..
        @if (Cities != null)
        {
            <MapsMarkerSettings>
                <MapsMarker Visible="true" Height="20" Width="20" DataSource="Cities" TValue="MapMarker" Shape="MarkerType.Image" ImageUrl="https://blazor.syncfusion.com/demos/_content/blazor_server_common_net8/images/maps/ballon.png">
                </MapsMarker>
            </MapsMarkerSettings>
        }
        //..
        //..
@code {
        //..
        //..
        Cities.Add(new MapMarker
        {
            Latitude = response.GetProperty("startLocation").GetProperty("latitude").GetDouble(),
            Longitude = response.GetProperty("startLocation").GetProperty("longitude").GetDouble()
        });
        Cities.Add(new MapMarker
        {
            Latitude = response.GetProperty("endLocation").GetProperty("latitude").GetDouble(),
            Longitude = response.GetProperty("endLocation").GetProperty("longitude").GetDouble()
        });
    }

```

## Generate and visualize the route

To generate and visualize the route, use the geographic coordinates obtained from the Google Directions API to draw a navigation line between the source and destination markers on the map. This provides a clear representation of the path to follow.

```

    //..
    //..
    <MapsNavigationLines>
    @if (LatitudePoints.Count > 1 && LongitudePoints.Count > 1)
    {
        <MapsNavigationLine Visible="true" Angle="0" Color="black" Width="2" Latitude="@LatitudePoints.ToArray()" Longitude="@LongitudePoints.ToArray()"></MapsNavigationLine>
    }
    </MapsNavigationLines>
    //..
    //..
@code {
    foreach (var point in response.GetProperty("path").EnumerateArray())
    {
        LatitudePoints.Add(point.GetProperty("latitude").GetDouble());
        LongitudePoints.Add(point.GetProperty("longitude").GetDouble());
    }
}

```

A demonstration of integrating the Google Maps Directions API with the Syncfusion<sup style="font-size:70%">&reg;</sup> Maps component to render navigation routes is available at the following link.

[Sample in the GitHub](https://github.com/SyncfusionExamples/how-to-create-a-route-between-the-markers-in-the-Blazor-maps)
