---
layout: post
title: Markers in Blazor Maps Component | Syncfusion
description: Checkout and learn here all about markers in Syncfusion Blazor Maps component and much more details.
platform: Blazor
control: Maps
documentation: ug
---

# Markers in Blazor Maps Component

Markers are notes that are used to leave a message on the Maps. It indicates or marks a specific location with desired symbols on the Maps. It can be enabled by setting the [Visible](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsMarker-1.html#Syncfusion_Blazor_Maps_MapsMarker_1_Visible) property of the [MapsMarker](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsMarker-1.html) to **true**.

## Adding marker

To add the markers, the [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsMarker-1.html#Syncfusion_Blazor_Maps_MapsMarker_1_DataSource) property of the [MapsMarker](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsMarker-1.html) has a list of objects that contains the data for markers. Using this property, any number of markers can be added to the layers of the Maps. By default, it displays the markers based on the specified latitude and longitude in the given data source. Each data source object should contain the following list of properties.

* Latitude - Specifies the position of the marker in latitude co-ordinate.
* Longitude - Specifies the position of the marker in longitude co-ordinate.

```cshtml
@using Syncfusion.Blazor.Maps

<SfMaps>
    <MapsLayers>
        <MapsLayer ShapeData='new {dataOptions= "https://cdn.syncfusion.com/maps/map-data/usa.json"}' TValue="string">
            <MapsMarkerSettings>
                <MapsMarker Visible="true" DataSource="California" Height="25" Width="15" TValue="City"></MapsMarker>
                <MapsMarker Visible="true" DataSource="NewYork" Height="25" Width="15" TValue="City"></MapsMarker>
                <MapsMarker Visible="true" DataSource="Iowa" Height="25" Width="15" TValue="City"></MapsMarker>
            </MapsMarkerSettings>
            <MapsShapeSettings Fill="lightgray"></MapsShapeSettings>
        </MapsLayer>
    </MapsLayers>
</SfMaps>
@code {
    public class City
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    };
    public List<City> California = new List<City> {
        new City {Latitude=35.145083,Longitude=-117.960260}
    };
    public List<City> NewYork = new List<City> {
        new City { Latitude=40.724546, Longitude=-73.850344 }
    };
    public List<City> Iowa = new List<City> {
        new City {Latitude= 41.657782, Longitude=-91.533857}
    };
}
```

![Blazor Maps with Marker](./images/Marker/blazor-maps-marker.png)

## Adding marker template

The marker can be added as a template in the Maps component. The [MarkerTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsMarker-1.html#Syncfusion_Blazor_Maps_MapsMarker_1_MarkerTemplate) property of the [MapsMarker](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsMarker-1.html) is used to set HTML element as a template for the marker.

```cshtml
@using Syncfusion.Blazor.Maps

<SfMaps Height="600" Width="700">
    <MapsLayers>
        <MapsLayer ShapeData='new {dataOptions= "https://cdn.syncfusion.com/maps/map-data/world-map.json"}' TValue="string">
            <MapsMarkerSettings>
                <MapsMarker Visible="true" DataSource="Europe" TValue="City">
                    <MarkerTemplate>
                        @{
                            <div id="marker4" class="markerTemplate">Europe</div>
                        }
                    </MarkerTemplate>
                </MapsMarker>
                <MapsMarker Visible="true" DataSource="NorthAmerica" TValue="City">
                    <MarkerTemplate>
                        @{
                            <div id="marker5" class="markerTemplate" style="width:50px">North America</div>
                        }
                    </MarkerTemplate>
                </MapsMarker>
                <MapsMarker Visible="true" DataSource="SouthAmerica" TValue="City">
                    <MarkerTemplate>
                        @{
                            <div id="marker6" class="markerTemplate" style="width:50px">South America</div>
                        }
                    </MarkerTemplate>
                </MapsMarker>
            </MapsMarkerSettings>
            <MapsShapeSettings Fill="lightgray"></MapsShapeSettings>
        </MapsLayer>
    </MapsLayers>
</SfMaps>
@code {
    public class City
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    };
    public List<City> Europe = new List<City> {
        new City { Latitude=49.95121990866204, Longitude=18.468749999999998 }
    };
    public List<City> NorthAmerica = new List<City> {
        new City { Latitude= 59.88893689676585, Longitude= -109.3359375 }
    };
    public List<City> SouthAmerica = new List<City> {
        new City { Latitude= -6.64607562172573, Longitude=-55.54687499999999 }
    };
}
```

![Blazor Maps with Marker Template](./images/Marker/blazor-maps-marker-template.PNG)

## Customization

The following properties and class are available in [MapsMarker](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsMarker-1.html) to customize the markers of the Maps component.

* [MapsMarkerBorder](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsMarkerBorder.html) - To customize the color and width of the border for the markers in Maps.
* [Fill](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsMarker-1.html#Syncfusion_Blazor_Maps_MapsMarker_1_Fill) - To apply the color for markers in Maps.
* [DashArray](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsMarker-1.html#Syncfusion_Blazor_Maps_MapsMarker_1_DashArray) - To define the pattern of dashes and gaps that is applied to the outline of the markers in Maps.
* [Height](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsMarker-1.html#Syncfusion_Blazor_Maps_MapsMarker_1_Height) - To customize the height of the markers in Maps.
* [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsMarker-1.html#Syncfusion_Blazor_Maps_MapsMarker_1_Width) - To customize the width of the markers in Maps.
* [Opacity](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsMarker-1.html#Syncfusion_Blazor_Maps_MapsMarker_1_Opacity) - To customize the transparency of the markers in Maps.
* [AnimationDelay](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsMarker-1.html#Syncfusion_Blazor_Maps_MapsMarker_1_AnimationDelay) - To change the time delay in the transition for markers.
* [AnimationDuration](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsMarker-1.html#Syncfusion_Blazor_Maps_MapsMarker_1_AnimationDuration) - To change the time duration of animation for markers.

```cshtml
@using Syncfusion.Blazor.Maps

<SfMaps>
    <MapsLayers>
        <MapsLayer ShapeData='new { dataOptions = "https://cdn.syncfusion.com/maps/map-data/world-map.json" }' TValue="string">
            <MapsMarkerSettings>
                <MapsMarker Visible="true" DataSource="MarkerData" Height="25" Width="15" Fill="red" DashArray="1" Opacity="0.9"
                            Shape="Syncfusion.Blazor.Maps.MarkerType.Balloon" TValue="City">
                    <MapsMarkerBorder Color="green" Width="2"></MapsMarkerBorder>
                </MapsMarker>
            </MapsMarkerSettings>
            <MapsShapeSettings Fill="lightgray"></MapsShapeSettings>
        </MapsLayer>
    </MapsLayers>
</SfMaps>
@code {
    public class City
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    };
    public List<City> MarkerData = new List<City> {
        new City { Latitude=35.145083, Longitude=-117.960260 },
        new City { Latitude=40.724546, Longitude=-73.850344 },
        new City { Latitude= 41.657782, Longitude=-91.533857 }
    };
}
```

![Blazor Maps with Custom Marker](./images/Marker/blazor-maps-custom-marker.PNG)

## Marker shapes

The Maps component supports the following marker shapes. To set the shape of the marker, the [Shape](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsMarker-1.html#Syncfusion_Blazor_Maps_MapsMarker_1_Shape) property in [MapsMarker](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsMarker-1.html) is used.

* Balloon
* Circle
* Cross
* Diamond
* Image
* Rectangle
* Start
* Triangle
* VerticalLine
* HorizontalLine

### Rendering marker shape as image

To render a marker as an image in Maps, set the [Shape](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsMarker-1.html#Syncfusion_Blazor_Maps_MapsMarker_1_Shape) property of [MapsMarker](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsMarker-1.html) as **Image** and specify the path of the image to [ImageUrl](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsMarker-1.html#Syncfusion_Blazor_Maps_MapsMarker_1_ImageUrl) property. There is another way to render a marker as an image using the [ImageUrlValuePath](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsMarker-1.html#Syncfusion_Blazor_Maps_MapsMarker_1_ImageUrlValuePath) property of the [MapsMarker](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsMarker-1.html). Bind the field name that contains the path of the image in the data source to the [ImageUrlValuePath](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsMarker-1.html#Syncfusion_Blazor_Maps_MapsMarker_1_ImageUrlValuePath) property.

```cshtml
@using Syncfusion.Blazor.Maps

<SfMaps>
    <MapsLayers>
        <MapsLayer ShapeData='new { dataOptions = "https://cdn.syncfusion.com/maps/map-data/world-map.json" }' TValue="string">
            <MapsMarkerSettings>
                <MapsMarker Visible="true" DataSource="MarkerData" Height="25" Width="15" TValue="City"
                            Shape="Syncfusion.Blazor.Maps.MarkerType.Image" ImageUrl="src/maps/images/ballon.png">
                </MapsMarker>
            </MapsMarkerSettings>
            <MapsShapeSettings Fill="lightgray"></MapsShapeSettings>
        </MapsLayer>
    </MapsLayers>
</SfMaps>
@code {
    public class City
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    };
    public List<City> MarkerData = new List<City> {
        new City { Latitude=35.145083,Longitude=-117.960260 },
        new City { Latitude=40.724546, Longitude=-73.850344 },
        new City { Latitude= 41.657782, Longitude=-91.533857 }
    };
}
```

![Blazor Maps Marker with Image](./images/Marker/blazor-maps-marker-image.PNG)

## Multiple marker groups

Multiple groups of markers can be added in the Maps by adding multiple [MapsMarker](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsMarker-1.html) in the [MapsMarkerSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsMarkerSettings.html) and customization for the markers can be done with the [MapsMarker](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsMarker-1.html).

```cshtml
@using Syncfusion.Blazor.Maps

<SfMaps>
    <MapsLayers>
        <MapsLayer ShapeData='new {dataOptions= "https://cdn.syncfusion.com/maps/map-data/world-map.json"}' TValue="string">
            <MapsMarkerSettings>
                <MapsMarker Visible="true" DataSource="CitiesInUS" Shape="MarkerType.Diamond" Height="15" Fill="green" Width="15" TValue="City">
                    <MapsMarkerTooltipSettings ValuePath="Name" Visible="true"></MapsMarkerTooltipSettings>
                </MapsMarker>
                <MapsMarker Visible="true" DataSource="CitiesInIndia" Shape="MarkerType.Circle" Fill="blue" Height="10" Width="10" TValue="City">
                    <MapsMarkerTooltipSettings ValuePath="Name" Visible="true"></MapsMarkerTooltipSettings>
                </MapsMarker>
            </MapsMarkerSettings>
        </MapsLayer>
    </MapsLayers>
</SfMaps>

@code {
    public class City
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Name { get; set; }
    };
    private List<City> CitiesInUS = new List<City> {
        new City { Latitude = 37.0000, Longitude = -120.0000, Name = "California" },
        new City { Latitude= 40.7127, Longitude = -74.0059, Name = "New York" },
        new City { Latitude = 42, Longitude = -93, Name = "Iowa" }
    };
    private List<City> CitiesInIndia = new List<City> {
        new City { Latitude = 19.228825, Longitude = 72.854118, Name= "Mumbai" },
        new City { Latitude = 28.610001, Longitude = 77.230003, Name= "Delhi" },
        new City { Latitude = 13.067439, Longitude = 80.237617, Name= "Chennai" }
    };
}
```

![Blazor Maps with Multiple Marker Group](./images/Marker/blazor-maps-multiple-marker-group.png)

## Customize marker shapes from data source

### Bind different colors and shapes to the marker from data source

Using the [ShapeValuePath](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsMarker-1.html#Syncfusion_Blazor_Maps_MapsMarker_1_ShapeValuePath) and [ColorValuePath](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsMarker-1.html#Syncfusion_Blazor_Maps_MapsMarker_1_ColorValuePath) properties, the color and shape of the marker can be applied from the given data source. Bind the data source to the [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsMarker-1.html#Syncfusion_Blazor_Maps_MapsMarker_1_DataSource) property of the [MapsMarker](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsMarker-1.html) and set the field names that contains the shape and color values in the data source to the [ShapeValuePath](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsMarker-1.html#Syncfusion_Blazor_Maps_MapsMarker_1_ShapeValuePath) and [ColorValuePath](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsMarker-1.html#Syncfusion_Blazor_Maps_MapsMarker_1_ColorValuePath) properties.

```cshtml
@using Syncfusion.Blazor.Maps

<SfMaps>
    <MapsLayers>
        <MapsLayer ShapeData='new {dataOptions= "https://cdn.syncfusion.com/maps/map-data/world-map.json"}' TValue="string">
            <MapsMarkerSettings>
                <MapsMarker Visible='true' DataSource='MarkerDataSource' ShapeValuePath="shape" ColorValuePath="color" TValue="MapMarkerDataSource">
                </MapsMarker>
            </MapsMarkerSettings>
        </MapsLayer>
    </MapsLayers>
</SfMaps>
@code {
    public class MapMarkerDataSource
    {
        public double latitude { get; set; }
        public double longitude { get; set; }
        public string name { get; set; }
        public string color { get; set; }
        public string shape { get; set; }
    };
    public List<MapMarkerDataSource> MarkerDataSource = new List<MapMarkerDataSource> {
        new MapMarkerDataSource{ latitude= 49.95121990866204, longitude= 18.468749999999998, name= "Europe", color="red", shape="Triangle" },
        new MapMarkerDataSource{ latitude= 59.88893689676585, longitude= -109.3359375, name= "North America", color="blue", shape="Pentagon" },
        new MapMarkerDataSource{ latitude= -6.64607562172573, longitude= -55.54687499999999, name= "South America", color="green", shape="InvertedTriangle" }
    };
}
```

![Blazor Maps with Custom Marker Shape](./images/Marker/blazor-maps-custom-marker-shape.PNG)

### Setting value path from the data source

The latitude and longitude values are used to determine the location of each marker in the Maps. The [LatitudeValuePath](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsMarker-1.html#Syncfusion_Blazor_Maps_MapsMarker_1_LatitudeValuePath) and [LongitudeValuePath](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsMarker-1.html#Syncfusion_Blazor_Maps_MapsMarker_1_LongitudeValuePath) properties are used to specify the value path that presents in the data source of the marker. In the following example, the field name from the data source is set to the [LatitudeValuePath](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsMarker-1.html#Syncfusion_Blazor_Maps_MapsMarker_1_LatitudeValuePath) and [LongitudeValuePath](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsMarker-1.html#Syncfusion_Blazor_Maps_MapsMarker_1_LongitudeValuePath) properties.

```cshtml
@using Syncfusion.Blazor.Maps

<SfMaps>
    <MapsLayers>
        <MapsLayer ShapeData='new { dataOptions = "https://cdn.syncfusion.com/maps/map-data/world-map.json" }' TValue="string">
            <MapsMarkerSettings>
                <MapsMarker Visible="true" DataSource="MarkerData" LatitudeValuePath="Latitude" LongitudeValuePath="Longitude" TValue="City">
                </MapsMarker>
            </MapsMarkerSettings>
        <MapsShapeSettings Fill="lightgray"></MapsShapeSettings>
        </MapsLayer>
    </MapsLayers>
</SfMaps>
@code {
    public class City
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    };
    public List<City> MarkerData = new List<City> {
        new City { Latitude=35.145083, Longitude=-117.960260 },
        new City { Latitude=40.724546, Longitude=-73.850344 },
        new City { Latitude= 41.657782, Longitude=-91.533857 }
    };
}
```

![Setting Value Path from DataSource in Blazor Maps Marker](./images/Marker/blazor-maps-marker.PNG)

## Marker zooming

The Maps can be initially scaled to the center value based on the marker distance. This can be achieved by setting the [ShouldZoomInitially](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsZoomSettings.html#Syncfusion_Blazor_Maps_MapsZoomSettings_ShouldZoomInitially) property in [MapsZoomSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsZoomSettings.html) as **true**.

```cshtml
@using Syncfusion.Blazor.Maps

<SfMaps>
    <MapsLayers>
        <MapsLayer ShapeData='new {dataOptions= "https://cdn.syncfusion.com/maps/map-data/world-map.json"}' TValue="string">
            <MapsMarkerSettings>
                <MapsMarker Visible='true' DataSource='MarkerDataSource' TValue="MapMarkerDataSource">
                </MapsMarker>
            </MapsMarkerSettings>
        </MapsLayer>
    </MapsLayers>
    <MapsZoomSettings Enable='true' HorizontalAlignment="Syncfusion.Blazor.Maps.Alignment.Near" ShouldZoomInitially="true"></MapsZoomSettings>
</SfMaps>
@code {
    public class MapMarkerDataSource
    {
        public double latitude { get; set; }
        public double longitude { get; set; }
        public string name { get; set; }
    };
    public List<MapMarkerDataSource> MarkerDataSource = new List<MapMarkerDataSource> {
        new MapMarkerDataSource{ latitude= 49.95121990866204, longitude= 18.468749999999998, name= "Europe" },
        new MapMarkerDataSource{ latitude= 59.88893689676585, longitude= -109.3359375, name= "North America" },
        new MapMarkerDataSource{ latitude= -6.64607562172573, longitude= -55.54687499999999, name= "South America" }
    };
}
```

![Blazor Maps Marker with Zooming](./images/Marker/blazor-maps-marker-zooming.PNG)

## Marker clustering

Maps provide support to cluster the markers when they overlap each other. The number on a cluster indicates how many overlapped markers it contains. If zooming is performed on any of the cluster locations in Maps, the number on the cluster will decrease, and the individual markers will be seen on the map. When zooming out, the overlapping marker will increase. So that it can cluster again and increase the count over the cluster.

To enable clustering in markers, set the [AllowClustering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsMarkerClusterSettings.html#Syncfusion_Blazor_Maps_MapsMarkerClusterSettings_AllowClustering) property of [MapsMarkerClusterSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsMarkerClusterSettings.html) as **true** and customization of clustering can be done with [MapsMarkerClusterSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsMarkerClusterSettings.html).

```cshtml
@using Syncfusion.Blazor.Maps

<SfMaps>
    <MapsZoomSettings Enable="true"></MapsZoomSettings>
    <MapsLayers>
        <MapsLayer ShapeData='new {dataOptions= "https://cdn.syncfusion.com/maps/map-data/world-map.json"}' TValue="string">
            <MapsMarkerSettings>
                <MapsMarker Visible="true" DataSource="LargestCities" Height="25" Width="15" TValue="City">
                </MapsMarker>
            </MapsMarkerSettings>
            <MapsMarkerClusterSettings AllowClustering="true" Shape="MarkerType.Circle" Fill="#008CFF" Height="25" Width="25">
                <MapsLayerMarkerClusterLabelStyle Color="white"></MapsLayerMarkerClusterLabelStyle>
            </MapsMarkerClusterSettings>
            <MapsShapeSettings Fill="lightgray">
            </MapsShapeSettings>
        </MapsLayer>
    </MapsLayers>
</SfMaps>

@code {
    public class City
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Name { get; set; }
        public double Area { get; set; }
    };
    private List<City> LargestCities = new List<City> {
        new City { Latitude=40.6971494, Longitude= -74.2598747, Name="New York", Area=8683 },
        new City { Latitude=40.0024137, Longitude= -75.2581194, Name="Philadelphia", Area=4661 },
        new City { Latitude=42.3142647, Longitude= -71.11037, Name="Boston", Area=4497 },
        new City { Latitude=42.3526257, Longitude= -83.239291, Name="Detroit", Area=3267 },
        new City { Latitude=47.2510905, Longitude= -123.1255834, Name="Washington", Area=2996 },
        new City { Latitude=25.7823907, Longitude= -80.2994995, Name="Miami", Area=2891 },
        new City { Latitude=19.3892246, Longitude= -70.1305136, Name="San Juan", Area=2309 }
    };
}
```

![Blazr Maps Marker with Clustering](./images/Marker/blazor-maps-marker-clustering.png)

## Customization of marker cluster

The following properties and classes are available to customize the marker clustering in the Maps component.

* [MapsLayerMarkerClusterBorder](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsLayerMarkerClusterBorder.html) - To customize the color and width of the border of cluster in Maps.
* [MapsLayerMarkerClusterConnectorLineSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsLayerMarkerClusterConnectorLineSettings.html) - To customize the connector line in cluster separating the markers.
* [DashArray](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsMarkerClusterSettings.html#Syncfusion_Blazor_Maps_MapsMarkerClusterSettings_DashArray) - To customize the dash array for the marker cluster in Maps.
* [Fill](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsMarkerClusterSettings.html#Syncfusion_Blazor_Maps_MapsMarkerClusterSettings_Fill) - Applies the color of the cluster in Maps.
* [Height](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsMarkerClusterSettings.html#Syncfusion_Blazor_Maps_MapsMarkerClusterSettings_Height) - To customize the height of the marker cluster in Maps.
* [ImageUrl](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsMarkerClusterSettings.html#Syncfusion_Blazor_Maps_MapsMarkerClusterSettings_ImageUrl) - To customize the URL path for the marker cluster when the cluster shape is set as image in Maps.
* [MapsLayerMarkerClusterLabelStyle](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsLayerMarkerClusterLabelStyle.html) - To customize the text in marker cluster.
* [Offset](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsMarkerClusterSettings.html#Syncfusion_Blazor_Maps_MapsMarkerClusterSettings_Offset) - To customize the offset position for the marker cluster in Maps.
* [Opacity](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsMarkerClusterSettings.html#Syncfusion_Blazor_Maps_MapsMarkerClusterSettings_Opacity) - To customize the opacity of the marker cluster.
* [Shape](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsMarkerClusterSettings.html#Syncfusion_Blazor_Maps_MapsMarkerClusterSettings_Shape) - To customize the shape for the cluster of markers.
* [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsMarkerClusterSettings.html#Syncfusion_Blazor_Maps_MapsMarkerClusterSettings_Width) - To customize the width of the marker cluster in Maps.

```cshtml
@using Syncfusion.Blazor.Maps

<SfMaps>
    <MapsZoomSettings Enable="true"></MapsZoomSettings>
    <MapsLayers>
        <MapsLayer ShapeData='new {dataOptions= "https://cdn.syncfusion.com/maps/map-data/world-map.json"}' TValue="string">
            <MapsMarkerSettings>
                <MapsMarker Visible="true" DataSource="LargestCities" Height="25" Width="15" TValue="City">
                </MapsMarker>
            </MapsMarkerSettings>
            <MapsMarkerClusterSettings AllowClustering="true" AllowClusterExpand="true" Shape="MarkerType.Circle"
                                       Fill="#008CFF" Height="25" Width="25" Offset="10" Opacity="0.9">
                <MapsLayerMarkerClusterConnectorLineSettings Color="Orange" Opacity="0.8" Width="2"></MapsLayerMarkerClusterConnectorLineSettings>
                <MapsLayerMarkerClusterLabelStyle Color="green"></MapsLayerMarkerClusterLabelStyle>
            </MapsMarkerClusterSettings>
            <MapsShapeSettings Fill="lightgray">
            </MapsShapeSettings>
        </MapsLayer>
    </MapsLayers>
</SfMaps>

@code {
    public class City
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Name { get; set; }
        public double Area { get; set; }
    };
    private List<City> LargestCities = new List<City> {
        new City { Latitude=40.6971494, Longitude= -74.2598747, Name="New York", Area=8683 },
        new City { Latitude=40.0024137, Longitude= -75.2581194, Name="Philadelphia", Area=4661 },
        new City { Latitude=42.3142647, Longitude= -71.11037, Name="Boston", Area=4497 },
        new City { Latitude=42.3526257, Longitude= -83.239291, Name="Detroit", Area=3267 },
        new City { Latitude=47.2510905, Longitude= -123.1255834, Name="Washington", Area=2996 },
        new City { Latitude=25.7823907, Longitude= -80.2994995, Name="Miami", Area=2891 },
        new City { Latitude=19.3892246, Longitude= -70.1305136, Name="San Juan", Area=2309 }
    };
}
```

![Blazor Maps Marker with Custom Cluster](./images/Marker/blazor-maps-custom-cluster.png)

## Expanding the marker cluster

The cluster is formed by grouping an identical and non-identical marker from the surrounding area. By clicking on the cluster and setting the [AllowClusterExpand](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsMarkerClusterSettings.html#Syncfusion_Blazor_Maps_MapsMarkerClusterSettings_AllowClusterExpand) property in [MapsMarkerClusterSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsMarkerClusterSettings.html) as **true** to expand the identical markers. If zooming is performed in any of the locations of the cluster, the number on the cluster will decrease and the overlapping marker will be split into an individual marker on the map. When performing zoom out, it will increase the marker count and then cluster it again.

```cshtml
@using Syncfusion.Blazor.Maps

<SfMaps>
    <MapsLayers>
        <MapsLayer ShapeData='new {dataOptions= "https://cdn.syncfusion.com/maps/map-data/world-map.json"}' TValue="string">
            <MapsMarkerSettings>
                <MapsMarker Visible="true" DataSource='MarkerDataSource' TValue="MapMarkerDataSource"/>
            </MapsMarkerSettings>
            <MapsMarkerClusterSettings AllowClustering="true" AllowClusterExpand="true" Shape="MarkerType.Circle" Height="40" Width="40">
                <MapsLayerMarkerClusterLabelStyle Color="white"></MapsLayerMarkerClusterLabelStyle>
            </MapsMarkerClusterSettings>
        </MapsLayer>
    </MapsLayers>
    <MapsZoomSettings Enable='true' MouseWheelZoom="true"></MapsZoomSettings>
</SfMaps>
@code {
    public class MapMarkerDataSource
    {
        public double latitude { get; set; }
        public double longitude { get; set; }
        public string name { get; set; }
    };
    public List<MapMarkerDataSource> MarkerDataSource = new List<MapMarkerDataSource> {
        new MapMarkerDataSource{ latitude= 49.95121990866204, longitude= 18.468749999999998, name= "Europe" },
        new MapMarkerDataSource{ latitude= 49.95121990866204, longitude= 18.468749999999998, name= "Europe" },
        new MapMarkerDataSource{ latitude= 49.95121990866204, longitude= 18.468749999999998, name= "Europe" },
        new MapMarkerDataSource{ latitude= 49.95121990866204, longitude= 18.468749999999998, name= "Europe" },
        new MapMarkerDataSource{ latitude= 49.95121990866204, longitude= 18.468749999999998, name= "Europe" },
        new MapMarkerDataSource{ latitude= 49.95121990866204, longitude= 18.468749999999998, name= "Europe" },
        new MapMarkerDataSource{ latitude= 49.95121990866204, longitude= 18.468749999999998, name= "Europe" },
        new MapMarkerDataSource{ latitude= 59.88893689676585, longitude= -109.3359375, name= "North America" },
        new MapMarkerDataSource{ latitude= -6.64607562172573, longitude= -55.54687499999999, name= "South America" }
    };
}
```

![Expanding Marker Cluster in Blazor Maps](./images/Marker/blazor-maps-marker-expand-cluster.PNG)

## Tooltip for marker

Tooltip is used to display more information about a marker on mouse over or touch end event. This can be enabled separately for marker by setting the [Visible](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsTooltipSettings.html#Syncfusion_Blazor_Maps_MapsTooltipSettings_Visible) property of [MapsMarkerTooltipSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsMarkerTooltipSettings.html) to **true**. The [ValuePath](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsTooltipSettings.html#Syncfusion_Blazor_Maps_MapsTooltipSettings_ValuePath) property in the [MapsMarkerTooltipSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsMarkerTooltipSettings.html) takes the field name that presents in data source and displays that value as tooltip text.

```cshtml
@using Syncfusion.Blazor.Maps

<SfMaps>
    <MapsLayers>
        <MapsLayer ShapeData='new {dataOptions ="https://cdn.syncfusion.com/maps/map-data/usa.json"}' TValue="string">
            <MapsMarkerSettings>
                <MapsMarker Visible="true" Shape="MarkerType.Circle" Fill="white" Width="20"
                            DataSource="HighestPopulation" TValue="City">
                    <MapsMarkerBorder Width="2" Color="#333"></MapsMarkerBorder>
                    <MapsMarkerTooltipSettings Visible="true" ValuePath="Name"></MapsMarkerTooltipSettings>
                </MapsMarker>
            </MapsMarkerSettings>
        </MapsLayer>
    </MapsLayers>
</SfMaps>

@code {
    public class City
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Name { get; set; }
    };
    public List<City> HighestPopulation = new List<City> {
        new City { Latitude = 40.7424509, Longitude = -74.0081468, Name = "New York" }
    };
}
```

![Blazor Maps with Marker Tooltip](./images/blazor-maps-marker-tooltip.png)

## See also

* [Add different types of markers](how-to/add-different-types-of-markers)