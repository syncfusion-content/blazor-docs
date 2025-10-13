---
layout: post
title: Markers in Blazor Maps Component | Syncfusion
description: Check out and learn how to configure and customize markers in the Syncfusion Blazor Maps component for effective data visualization.
platform: Blazor
control: Maps
documentation: ug
---

# Markers in Blazor Maps Component

Markers annotate locations on Maps with symbols. Enable markers by setting the [Visible](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsMarker-1.html#Syncfusion_Blazor_Maps_MapsMarker_1_Visible) property of [MapsMarker](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsMarker-1.html) to **true**.

## Adding marker

To add markers, assign a list of objects to the [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsMarker-1.html#Syncfusion_Blazor_Maps_MapsMarker_1_DataSource) property of [MapsMarker](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsMarker-1.html). Any number of markers can be added to map layers. By default, markers render at the specified latitude and longitude in the data source. Each data item should include:

* Latitude - Specifies the marker position in latitude coordinates.
* Longitude - Specifies the marker position in longitude coordinates.

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
    }

    public List<City> California = new List<City> {
        new City {Latitude = 35.145083,Longitude = -117.960260}
    };

    public List<City> NewYork = new List<City> {
        new City { Latitude = 40.724546, Longitude = -73.850344 }
    };

    public List<City> Iowa = new List<City> {
        new City {Latitude = 41.657782, Longitude = -91.533857}
    };
}

```

![Blazor Maps with Marker](./images/Marker/blazor-maps-marker.png)

## Adding marker template

Markers can be rendered using a template. Use the [MarkerTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsMarker-1.html#Syncfusion_Blazor_Maps_MapsMarker_1_MarkerTemplate) property of [MapsMarker](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsMarker-1.html) to supply an HTML element as the template.

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
    }

    public List<City> Europe = new List<City> {
        new City { Latitude = 49.95121990866204, Longitude = 18.468749999999998 }
    };

    public List<City> NorthAmerica = new List<City> {
        new City { Latitude = 59.88893689676585, Longitude = -109.3359375 }
    };

    public List<City> SouthAmerica = new List<City> {
        new City { Latitude = -6.64607562172573, Longitude = -55.54687499999999 }
    };
}

```

![Blazor Maps with Marker Template](./images/Marker/blazor-maps-marker-template.PNG)

## Customization

Use the following properties and class in [MapsMarker](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsMarker-1.html) to customize markers in the Maps component.

* [MapsMarkerBorder](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsMarkerBorder.html) - Customizes the border color and width for markers.
* [Fill](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsMarker-1.html#Syncfusion_Blazor_Maps_MapsMarker_1_Fill) - Applies a fill color to markers.
* [DashArray](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsMarker-1.html#Syncfusion_Blazor_Maps_MapsMarker_1_DashArray) - Defines the dash pattern for marker outlines.
* [Height](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsMarker-1.html#Syncfusion_Blazor_Maps_MapsMarker_1_Height) - Sets marker height.
* [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsMarker-1.html#Syncfusion_Blazor_Maps_MapsMarker_1_Width) - Sets marker width.
* [Opacity](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsMarker-1.html#Syncfusion_Blazor_Maps_MapsMarker_1_Opacity) - Controls marker transparency.
* [AnimationDelay](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsMarker-1.html#Syncfusion_Blazor_Maps_MapsMarker_1_AnimationDelay) - Sets the transition delay for markers.
* [AnimationDuration](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsMarker-1.html#Syncfusion_Blazor_Maps_MapsMarker_1_AnimationDuration) - Sets the animation duration for markers.

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
    }

    public List<City> MarkerData = new List<City> {
        new City { Latitude = 35.145083, Longitude = -117.960260 },
        new City { Latitude = 40.724546, Longitude = -73.850344 },
        new City { Latitude = 41.657782, Longitude = -91.533857 }
    };
}

```

![Blazor Maps with Custom Marker](./images/Marker/blazor-maps-custom-marker.PNG)

## Marker shapes

The Maps component supports the following marker shapes. Set the marker shape using the [Shape](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsMarker-1.html#Syncfusion_Blazor_Maps_MapsMarker_1_Shape) property of [MapsMarker](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsMarker-1.html).

* Balloon
* Circle
* Cross
* Diamond
* Image
* Rectangle
* Star
* Triangle
* VerticalLine
* HorizontalLine

### Rendering marker shape as image

To render a marker as an image, set the [Shape](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsMarker-1.html#Syncfusion_Blazor_Maps_MapsMarker_1_Shape) property of [MapsMarker](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsMarker-1.html) to **Image** and specify the image path in [ImageUrl](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsMarker-1.html#Syncfusion_Blazor_Maps_MapsMarker_1_ImageUrl) property. Alternatively, bind the field containing the image path using [ImageUrlValuePath](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsMarker-1.html#Syncfusion_Blazor_Maps_MapsMarker_1_ImageUrlValuePath) property.

```cshtml

@using Syncfusion.Blazor.Maps

<SfMaps>
    <MapsLayers>
        <MapsLayer ShapeData='new { dataOptions = "https://cdn.syncfusion.com/maps/map-data/world-map.json" }' TValue="string">
            <MapsMarkerSettings>
                <MapsMarker Visible="true" DataSource="MarkerData" Height="25" Width="15" TValue="City"
                            Shape="Syncfusion.Blazor.Maps.MarkerType.Image" ImageUrl="https://blazor.syncfusion.com/demos/_content/blazor_server_common_net8/images/maps/ballon.png">
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
    }

    public List<City> MarkerData = new List<City> {
        new City { Latitude  = 35.145083, Longitude = -117.960260 },
        new City { Latitude = 40.724546, Longitude = -73.850344 },
        new City { Latitude = 41.657782, Longitude = -91.533857 }
    };
}

```

![Blazor Maps Marker with Image](./images/Marker/blazor-maps-marker-image.PNG)

## Multiple marker groups

Multiple groups of markers can be added by including multiple [MapsMarker](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsMarker-1.html) tags within [MapsMarkerSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsMarkerSettings.html). Each group can be customized using its corresponding [MapsMarker](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsMarker-1.html).

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
    }

    private List<City> CitiesInUS = new List<City> {
        new City { Latitude = 37.0000, Longitude = -120.0000, Name = "California" },
        new City { Latitude = 40.7127, Longitude = -74.0059, Name = "New York" },
        new City { Latitude = 42, Longitude = -93, Name = "Iowa" }
    };

    private List<City> CitiesInIndia = new List<City> {
        new City { Latitude = 19.228825, Longitude = 72.854118, Name = "Mumbai" },
        new City { Latitude = 28.610001, Longitude = 77.230003, Name = "Delhi" },
        new City { Latitude = 13.067439, Longitude = 80.237617, Name = "Chennai" }
    };
}

```

![Blazor Maps with Multiple Marker Group](./images/Marker/blazor-maps-multiple-marker-group.png)

## Customize marker shapes from data source

### Bind different colors and shapes to the marker from data source

Using [ShapeValuePath](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsMarker-1.html#Syncfusion_Blazor_Maps_MapsMarker_1_ShapeValuePath) and [ColorValuePath](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsMarker-1.html#Syncfusion_Blazor_Maps_MapsMarker_1_ColorValuePath) properties, color and shape can be bound from the data source. Bind the data source to [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsMarker-1.html#Syncfusion_Blazor_Maps_MapsMarker_1_DataSource) and set field names containing shape and color values to `ShapeValuePath` and `ColorValuePath`.

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
    }

    public List<MapMarkerDataSource> MarkerDataSource = new List<MapMarkerDataSource> {
        new MapMarkerDataSource { latitude = 49.95121990866204, longitude = 18.468749999999998, name = "Europe", color = "red", shape = "Triangle" },
        new MapMarkerDataSource { latitude = 59.88893689676585, longitude = -109.3359375, name = "North America", color = "blue", shape = "Pentagon" },
        new MapMarkerDataSource { latitude = -6.64607562172573, longitude = -55.54687499999999, name = "South America", color = "green", shape = "InvertedTriangle" }
    };
}

```

![Blazor Maps with Custom Marker Shape](./images/Marker/blazor-maps-custom-marker-shape.PNG)

### Setting value path from the data source

Latitude and longitude determine the location of each marker. Use [LatitudeValuePath](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsMarker-1.html#Syncfusion_Blazor_Maps_MapsMarker_1_LatitudeValuePath) and [LongitudeValuePath](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsMarker-1.html#Syncfusion_Blazor_Maps_MapsMarker_1_LongitudeValuePath) properties to specify the corresponding fields in the marker data source.

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
    }

    public List<City> MarkerData = new List<City> {
        new City { Latitude = 35.145083, Longitude = -117.960260 },
        new City { Latitude = 40.724546, Longitude = -73.850344 },
        new City { Latitude = 41.657782, Longitude = -91.533857 }
    };
}

```

![Setting Value Path from DataSource in Blazor Maps Marker](./images/Marker/blazor-maps-marker.PNG)

### Setting different sizes for markers individually

Marker sizes within a group can vary using [WidthValuePath](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsMarker-1.html#Syncfusion_Blazor_Maps_MapsMarker_1_WidthValuePath) and [HeightValuePath](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsMarker-1.html#Syncfusion_Blazor_Maps_MapsMarker_1_HeightValuePath) properties, which read width and height from the data source. Bind the data source to [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsMarker-1.html#Syncfusion_Blazor_Maps_MapsMarker_1_DataSource), and provide the width and height field names.

```cshtml

@using Syncfusion.Blazor.Maps

<SfMaps>
    <MapsLayers>
        <MapsLayer ShapeData='new { dataOptions = "https://cdn.syncfusion.com/maps/map-data/world-map.json" }' TValue="string">
            <MapsMarkerSettings>
                <MapsMarker Visible="true" Shape="MarkerType.Circle" DataSource="MarkerData" WidthValuePath="Width" HeightValuePath="Height" TValue="City">
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
        public double Width {get; set; }
        public double Height {get; set; }
    }

    public List<City> MarkerData = new List<City> {
        new City { Latitude = 49.95121990866204, Longitude = 18.468749999999998, Width = 30, Height = 30  },
        new City { Latitude = 59.88893689676585, Longitude = -109.3359375, Width = 20, Height = 20 },
        new City { Latitude = -6.64607562172573, Longitude = -55.54687499999999, Width = 10, Height = 10 }
    };
}

```

![Setting different sizes for markers from DataSource in Blazor Maps Marker](./images/Marker/blazor-maps-marker-sizes.PNG)

## Repositioning the marker using drag and drop

Markers can be repositioned by dragging and dropping. Enable drag-and-drop by setting [EnableDrag](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsMarker-1.html#Syncfusion_Blazor_Maps_MapsMarker_1_EnableDrag) property to **true** in the `MapsMarker` settings.

```cshtml

@using Syncfusion.Blazor.Maps

<SfMaps>
    <MapsLayers>
        <MapsLayer ShapeData='new {dataOptions= "https://cdn.syncfusion.com/maps/map-data/world-map.json"}' TValue="string">
            <MapsMarkerSettings>
                <MapsMarker EnableDrag="true" Visible="true" DataSource="MarkerDataSource" Height="20" Width="20" TValue="City">
                    <MapsMarkerBorder Width="2" Color="#285255"></MapsMarkerBorder>
                    <MapsMarkerTooltipSettings Visible="true" ValuePath="Name"></MapsMarkerTooltipSettings>
                </MapsMarker>
            </MapsMarkerSettings>
            <MapsShapeSettings Fill="#C3E6ED"></MapsShapeSettings>
        </MapsLayer>
    </MapsLayers>
</SfMaps>

@code {
    public class City
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Name { get; set; }
    }

    public List<City> MarkerDataSource = new List<City> {
        new City { Latitude = 49.95121990866204, Longitude = 18.468749999999998, Name = "Marker 1" },
        new City { Latitude = 59.88893689676585, Longitude = -109.3359375, Name = "Marker 2" },
        new City { Latitude = -6.64607562172573, Longitude = -55.54687499999999, Name = "Marker 3" },
        new City { Latitude = 23.644385824912135, Longitude = 77.83189239539234, Name = "Marker 4" },
        new City { Latitude = 63.66569332894224, Longitude = 98.2225173953924, Name = "Marker 5" }
    };
}

```

![Marker with drag and drop functionality in Blazor Maps](./images/Marker/marker-drag-and-drop.gif)

The marker data can be updated during drag operations using the [OnMarkerDragStart](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsEvents.html#Syncfusion_Blazor_Maps_MapsEvents_OnMarkerDragStart) and [OnMarkerDragEnd](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsEvents.html#Syncfusion_Blazor_Maps_MapsEvents_OnMarkerDragEnd) events. Updating the relevant marker data automatically refreshes tooltip and legend text for that marker. The following properties are available in the event arguments:

|   Argument Name      |   Description                               |
|----------------------| --------------------------------------------|
|   DataIndex          |   Index of the dragged marker data in the marker data source.         |
|   Latitude           |   Latitude coordinate of the dragged marker.                          |
|   Longitude          |   Longitude coordinate of the dragged marker.                         |
|   MarkerIndex        |   Index of the marker setting.                                        |
|   LayerIndex         |   Index of the layer containing the marker.                           |
|   EventName          |   Name of the event.                                                  |
|   X                  |   Horizontal mouse position on the map during drag.                   |
|   Y                  |   Vertical mouse position on the map during drag.                     |

The example below demonstrates customizing marker data in response to drag events.

```cshtml

@using Syncfusion.Blazor.Maps

<SfMaps @ref="maps">
    <MapsEvents OnMarkerDragStart="MarkerDragStartEvent" OnMarkerDragEnd="MarkerDragEndEvent"></MapsEvents>
    <MapsLegendSettings Visible="true" Type="LegendType.Markers" Shape="LegendShape.Circle" ShapeWidth="10" ShapeHeight="10" Fill="#FF471A">
    </MapsLegendSettings>
    <MapsLayers>
        <MapsLayer ShapeData='new {dataOptions= "https://cdn.syncfusion.com/maps/map-data/world-map.json"}' TValue="string">
            <MapsMarkerSettings>
                <MapsMarker LegendText="Name" EnableDrag="true" Visible="true" DataSource="MarkerDataSource" AnimationDuration="0" Height="20" Width="20" TValue="City">
                    <MapsMarkerBorder Width="2" Color="#285255"></MapsMarkerBorder>
                    <MapsMarkerTooltipSettings Visible="true" ValuePath="Name"></MapsMarkerTooltipSettings>
                </MapsMarker>
            </MapsMarkerSettings>
            <MapsShapeSettings Fill="#C3E6ED"></MapsShapeSettings>
        </MapsLayer>
    </MapsLayers>
</SfMaps>

@code {
    public SfMaps maps;

    public class City
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Name { get; set; }
    }

    public List<City> MarkerDataSource = new List<City> {
        new City { Latitude = 49.95121990866204, Longitude = 18.468749999999998, Name = "Europe" },
        new City { Latitude = 59.88893689676585, Longitude = -109.3359375, Name = "North America" },
        new City { Latitude = -6.64607562172573, Longitude = -55.54687499999999, Name = "Sout America" },
        new City { Latitude = 23.644385824912135, Longitude = 77.83189239539234, Name = "India" },
        new City { Latitude = 63.66569332894224, Longitude = 98.2225173953924, Name = "China" }
    };

    public void MarkerDragStartEvent(MarkerDragStartEventArgs args)
    {
        // When the marker begins to move on the map, the event is triggered.
    }

    public void MarkerDragEndEvent(MarkerDragEndEventArgs args)
    {
        // When the marker on the map stops dragging, the event is triggered.
        MarkerDataSource[args.DataIndex].Name = "Australia";
        maps.Refresh();
    }
}

```

![Marker customization using marker drag events in Blazor Maps](./images/Marker/marker-drag-events.gif)

## Marker zooming

Maps can initially zoom based on marker distribution by setting [ShouldZoomInitially](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsZoomSettings.html#Syncfusion_Blazor_Maps_MapsZoomSettings_ShouldZoomInitially) property to **true** in [MapsZoomSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsZoomSettings.html).

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
    <MapsZoomSettings Enable='true' ShouldZoomInitially="true">
        <MapsZoomToolbarSettings HorizontalAlignment="Alignment.Near">
        </MapsZoomToolbarSettings>
    </MapsZoomSettings>
</SfMaps>

@code {
    public class MapMarkerDataSource
    {
        public double latitude { get; set; }
        public double longitude { get; set; }
        public string name { get; set; }
    }

    public List<MapMarkerDataSource> MarkerDataSource = new List<MapMarkerDataSource> {
        new MapMarkerDataSource { latitude = 49.95121990866204, longitude = 18.468749999999998, name = "Europe" },
        new MapMarkerDataSource { latitude = 59.88893689676585, longitude = -109.3359375, name = "North America" },
        new MapMarkerDataSource { latitude = -6.64607562172573, longitude = -55.54687499999999, name = "South America" }
    };
}

```

![Blazor Maps Marker with Zooming](./images/Marker/blazor-maps-marker-zooming.PNG)

## Disabling Zoom on Marker Click

Maps typically zoom on click or double-click, including when clicking a marker. To disable zooming for marker clicks, set [ZoomOnMarkerClick](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsZoomSettings.html#Syncfusion_Blazor_Maps_MapsZoomSettings_ZoomOnMarkerClick) to **false** in [MapsZoomSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsZoomSettings.html). By default, `ZoomOnMarkerClick` is **true**.

```cshtml

@using Syncfusion.Blazor.Maps

<SfMaps>
    <MapsLayers>
        <MapsLayer ShapeData='new {dataOptions= "https://cdn.syncfusion.com/maps/map-data/world-map.json"}' TValue="string">
            <MapsMarkerSettings>
                <MapsMarker Visible='true' Width="20" Height="20" AnimationDuration="0" DataSource='MarkerDataSource' TValue="MapMarkerDataSource">
                </MapsMarker>
            </MapsMarkerSettings>
        </MapsLayer>
    </MapsLayers>
    <MapsZoomSettings Enable='true' ZoomOnClick="true" ZoomOnMarkerClick="false">
        <MapsZoomToolbarSettings HorizontalAlignment="Alignment.Far">
        </MapsZoomToolbarSettings>
    </MapsZoomSettings>
</SfMaps>

@code {
    public class MapMarkerDataSource
    {
        public double latitude { get; set; }
        public double longitude { get; set; }
        public string name { get; set; }
    }

    public List<MapMarkerDataSource> MarkerDataSource = new List<MapMarkerDataSource> {
        new MapMarkerDataSource { latitude = 49.95121990866204, longitude = 18.468749999999998, name = "Europe" },
        new MapMarkerDataSource { latitude = 59.88893689676585, longitude = -109.3359375, name = "North America" },
        new MapMarkerDataSource { latitude = -6.64607562172573, longitude = -55.54687499999999, name = "South America" }
    };
}

```

![Disabling Zoom on Marker Click in Blazor Maps](./images/Marker/blazor-maps-disabling-zooming-on-marker-click.gif)

## Marker clustering

Maps support clustering of overlapping markers. A cluster displays the count of contained markers. Zooming into a cluster location reduces the count and reveals individual markers; zooming out increases overlap and re-forms clusters.

To enable clustering within a layer, set [AllowClustering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsMarkerClusterSettings.html#Syncfusion_Blazor_Maps_MapsMarkerClusterSettings_AllowClustering) property to **true** in [MapsMarkerClusterSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsMarkerClusterSettings.html) on the [MapsLayer](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsLayer-1.html). Customize clustering using the corresponding `MapsMarkerClusterSettings` properties.

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
    }

    private List<City> LargestCities = new List<City> {
        new City { Latitude = 40.6971494, Longitude = -74.2598747, Name = "New York", Area = 8683 },
        new City { Latitude = 40.0024137, Longitude = -75.2581194, Name = "Philadelphia", Area = 4661 },
        new City { Latitude = 42.3142647, Longitude = -71.11037, Name = "Boston", Area = 4497 },
        new City { Latitude = 42.3526257, Longitude = -83.239291, Name = "Detroit", Area = 3267 },
        new City { Latitude = 47.2510905, Longitude = -123.1255834, Name = "Washington", Area = 2996 },
        new City { Latitude = 25.7823907, Longitude = -80.2994995, Name = "Miami", Area = 2891 },
        new City { Latitude = 19.3892246, Longitude = -70.1305136, Name = "San Juan", Area = 2309 }
    };
}

```

![Blazr Maps Marker with Clustering](./images/Marker/blazor-maps-marker-clustering.png)

### Customization of marker cluster

The following properties and classes are available to customize marker clustering in the Maps component.

* [MapsLayerMarkerClusterBorder](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsLayerMarkerClusterBorder.html) - Customizes the border color and width of clusters.
* [MapsLayerMarkerClusterConnectorLineSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsLayerMarkerClusterConnectorLineSettings.html) - Customizes connector lines separating markers in an expanded cluster.
* [DashArray](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsMarkerClusterSettings.html#Syncfusion_Blazor_Maps_MapsMarkerClusterSettings_DashArray) - Sets the dash array for cluster outlines.
* [Fill](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsMarkerClusterSettings.html#Syncfusion_Blazor_Maps_MapsMarkerClusterSettings_Fill) - Applies the cluster fill color.
* [Height](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsMarkerClusterSettings.html#Syncfusion_Blazor_Maps_MapsMarkerClusterSettings_Height) - Sets cluster height.
* [ImageUrl](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsMarkerClusterSettings.html#Syncfusion_Blazor_Maps_MapsMarkerClusterSettings_ImageUrl) - Sets the image URL when the cluster shape is an image.
* [MapsLayerMarkerClusterLabelStyle](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsLayerMarkerClusterLabelStyle.html) - Customizes cluster text.
* [Offset](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsMarkerClusterSettings.html#Syncfusion_Blazor_Maps_MapsMarkerClusterSettings_Offset) - Adjusts the cluster offset.
* [Opacity](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsMarkerClusterSettings.html#Syncfusion_Blazor_Maps_MapsMarkerClusterSettings_Opacity) - Controls cluster opacity.
* [Shape](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsMarkerClusterSettings.html#Syncfusion_Blazor_Maps_MapsMarkerClusterSettings_Shape) - Sets the cluster shape.
* [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsMarkerClusterSettings.html#Syncfusion_Blazor_Maps_MapsMarkerClusterSettings_Width) - Sets cluster width.

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
    }

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

### Expanding the marker cluster

Clusters group identical and non-identical markers in nearby locations. Enable expansion by setting [AllowClusterExpand](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsMarkerClusterSettings.html#Syncfusion_Blazor_Maps_MapsMarkerClusterSettings_AllowClusterExpand) property to **true** in [MapsMarkerClusterSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsMarkerClusterSettings.html). Zooming in reduces cluster counts and reveals individual markers; zooming out increases counts and re-forms clusters.

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
    }

    public List<MapMarkerDataSource> MarkerDataSource = new List<MapMarkerDataSource> {
        new MapMarkerDataSource { latitude = 49.95121990866204, longitude = 18.468749999999998, name = "Europe" },
        new MapMarkerDataSource { latitude = 49.95121990866204, longitude = 18.468749999999998, name = "Europe" },
        new MapMarkerDataSource { latitude = 49.95121990866204, longitude = 18.468749999999998, name = "Europe" },
        new MapMarkerDataSource { latitude = 49.95121990866204, longitude = 18.468749999999998, name = "Europe" },
        new MapMarkerDataSource { latitude = 49.95121990866204, longitude = 18.468749999999998, name = "Europe" },
        new MapMarkerDataSource { latitude = 49.95121990866204, longitude = 18.468749999999998, name = "Europe" },
        new MapMarkerDataSource { latitude = 49.95121990866204, longitude = 18.468749999999998, name = "Europe" },
        new MapMarkerDataSource { latitude = 59.88893689676585, longitude = -109.3359375, name = "North America" },
        new MapMarkerDataSource { latitude = -6.64607562172573, longitude = -55.54687499999999, name = "South America" }
    };
}

```

![Expanding Marker Cluster in Blazor Maps](./images/Marker/blazor-maps-marker-expand-cluster.PNG)

### Clustering markers within each marker group

Clustering can be enabled per marker group by placing [MapsMarkerClusterSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsMarkerClusterSettings.html) inside each [MapsMarker](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsMarker-1.html) within a [MapsLayer](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsLayer-1.html). This enables individual customization of clusters for each group, reducing clutter and improving readability. When [AllowClustering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsMarkerClusterSettings.html#Syncfusion_Blazor_Maps_MapsMarkerClusterSettings_AllowClustering) property is **true**, markers in that group are clustered and can expand on zoom. Manual expansion can be enabled using [AllowClusterExpand](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsMarkerClusterSettings.html#Syncfusion_Blazor_Maps_MapsMarkerClusterSettings_AllowClusterExpand) property. Appearance and behavior can be customized using the same `MapsMarkerClusterSettings` options described above.

N> When `MapsMarkerClusterSettings` is enabled for a specific marker group, the `MapsMarkerClusterSettings` defined within the layer does not take effect.

```cshtml

@using Syncfusion.Blazor.Maps

<SfMaps>
    <MapsZoomSettings Enable="true">
        <MapsZoomToolbarSettings>
            <MapsZoomToolbarButton ToolbarItems="new List<ToolbarItem>() { ToolbarItem.Zoom,
                                ToolbarItem.ZoomIn, ToolbarItem.ZoomOut, ToolbarItem.Pan, ToolbarItem.Reset }"></MapsZoomToolbarButton>
        </MapsZoomToolbarSettings>
    </MapsZoomSettings>
    <MapsTitleSettings Text="Attractive places around the world">
        <MapsTitleTextStyle Size="16px"/>
    </MapsTitleSettings>
    <MapsLayers>
        <MapsLayer  ShapeData='new { dataOptions = "https://cdn.syncfusion.com/maps/map-data/world-map.json" }' TValue="string">
            <MapsMarkerSettings>
                <MapsMarker Visible="true" TValue="City" DataSource="@MarkerDataFrance" Shape="MarkerType.Circle" Fill="#b38600" Height="15" Width="15">
                    <MapsMarkerBorder Color="#e6f2ff" Width="2"></MapsMarkerBorder>
                    <MapsMarkerClusterSettings AllowClustering="true" AllowClusterExpand="true" Shape="MarkerType.Image" ImageUrl="https://blazor.syncfusion.com/demos/_content/Blazor_Server_Common_NET9/images/maps/cluster-france.svg" Height="40" Width="40">
                        <MapsLayerMarkerClusterLabelStyle Color="White" Size="10px"></MapsLayerMarkerClusterLabelStyle>
                    </MapsMarkerClusterSettings>
                    <MapsMarkerTooltipSettings Visible="true" ValuePath="Name" Format="<b>Name:<b> ${Name} <br/> <b>State:<b> ${State} <br/> <b>Country:<b> ${Country}">
                        <MapsMarkerTooltipTextStyle FontFamily="inherit"></MapsMarkerTooltipTextStyle>
                    </MapsMarkerTooltipSettings>
                </MapsMarker>
                <MapsMarker Visible="true" TValue="City" DataSource="@MarkerDataUSA" Shape="MarkerType.Circle" Fill="#bf4040" Height="15" Width="15">
                    <MapsMarkerBorder Color="#e6f2ff" Width="2"></MapsMarkerBorder>
                    <MapsMarkerClusterSettings AllowClustering="true" AllowClusterExpand="true" Shape="MarkerType.Image" ImageUrl="https://blazor.syncfusion.com/demos/_content/Blazor_Server_Common_NET9/images/maps/cluster-usa.svg" Height="40" Width="40">
                        <MapsLayerMarkerClusterLabelStyle Color="White" Size="10px"></MapsLayerMarkerClusterLabelStyle>
                    </MapsMarkerClusterSettings>
                    <MapsMarkerTooltipSettings Visible="true" ValuePath="Name" Format="<b>Name:<b> ${Name} <br/> <b>State:<b> ${State} <br/> <b>Country:<b> ${Country}">
                        <MapsMarkerTooltipTextStyle FontFamily="inherit"></MapsMarkerTooltipTextStyle>
                    </MapsMarkerTooltipSettings>
                </MapsMarker>
                <MapsMarker Visible="true" TValue="City" DataSource="@MarkerDataIndia" Shape="MarkerType.Circle" Fill="#00b3b3" Height="15" Width="15">
                    <MapsMarkerBorder Color="#e6f2ff" Width="2"></MapsMarkerBorder>
                    <MapsMarkerClusterSettings AllowClustering="true" AllowClusterExpand="true" Shape="MarkerType.Image" ImageUrl="https://blazor.syncfusion.com/demos/_content/Blazor_Server_Common_NET9/images/maps/cluster-india.svg" Height="40" Width="40">
                        <MapsLayerMarkerClusterLabelStyle Color="White" Size="10px"></MapsLayerMarkerClusterLabelStyle>
                    </MapsMarkerClusterSettings>
                    <MapsMarkerTooltipSettings Visible="true" ValuePath="Name" Format="<b>Name:<b> ${Name} <br/> <b>State:<b> ${State} <br/> <b>Country:<b> ${Country}">
                        <MapsMarkerTooltipTextStyle FontFamily="inherit"></MapsMarkerTooltipTextStyle>
                    </MapsMarkerTooltipSettings>
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
        public string State { get; set; }
        public string Country { get; set; }
    }

    private List<City> MarkerDataFrance = new List<City> {
        new City { Latitude = 48.8584, Longitude = 2.2945, Name = "Eiffel Tower", State = "Paris", Country = "France" },
        new City { Latitude = 48.8606, Longitude = 2.3376, Name = "Louvre Museum", State = "Paris", Country = "France" },
        new City { Latitude = 48.8529, Longitude = 2.3500, Name = "Notre-Dame Cathedral", State = "Paris", Country = "France" },
        new City { Latitude = 48.6360, Longitude = 1.5115, Name = "Mont Saint-Michel", State = "Normandy", Country = "France" }
    };

    private List<City> MarkerDataUSA = new List<City> {
        new City { Latitude = 35.019028, Longitude = -85.339439, Name = "Ruby Falls", State = "Tennessee", Country = "United States of America" },
        new City { Latitude = 35.654613, Longitude = -105.996979, Name = "Meow Wolf Santa Fe", State = "New Mexico", Country = "United States of America" },
        new City { Latitude = 36.107216, Longitude = -115.175804, Name = "City Center of Las Vegas", State = "Nevada", Country = "United States of America" },
        new City { Latitude = 36.879047, Longitude = -111.510498, Name = "Horseshoe Bend", State = "Arizona", Country = "United States of America" },
        new City { Latitude = 36.011955, Longitude = -113.810951, Name = "Grand Canyon West Skywalk", State = "Arizona", Country = "United States of America" }
    };

    private List<City> MarkerDataIndia = new List<City> {
        new City { Latitude = 26.985901, Longitude = 75.850700, Name = "Amber Fort, Amer", State = "Rajastan", Country = "India" },
        new City { Latitude = 22.957390, Longitude = 77.625275, Name = "Bhimbetka, Raisen District", State = "Madhya Pradesh", Country = "India" },
        new City { Latitude = 26.809330, Longitude = 75.540527, Name = "Bagru Fort, Bagru", State = "Rajasthan", Country = "India" },
        new City { Latitude = 25.489504, Longitude = 80.330116, Name = "Kalinjar Fort, Banda", State = "Uttar Pradesh", Country = "India" },
        new City { Latitude = 27.988890, Longitude = 76.388336, Name = "Neemrana", State = "Rajasthan", Country = "India" }
    };
}

```

![Clustering Marker Within Each Marker Group in Blazor Maps](./images/Marker/blazor-maps-marker-cluster-for-specific-markergroup.PNG)

## Tooltip for marker

A tooltip displays additional information about a marker on mouseover or touch end. Enable it by setting [Visible](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsTooltipSettings.html#Syncfusion_Blazor_Maps_MapsTooltipSettings_Visible) property to **true** in [MapsMarkerTooltipSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsMarkerTooltipSettings.html). Set [ValuePath](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsTooltipSettings.html#Syncfusion_Blazor_Maps_MapsTooltipSettings_ValuePath) property to the field name in the data source to display as tooltip text.

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
    }

    public List<City> HighestPopulation = new List<City> {
        new City { Latitude = 40.7424509, Longitude = -74.0081468, Name = "New York" }
    };
}

```

![Blazor Maps with Marker Tooltip](./images/blazor-maps-marker-tooltip.png)

## See also

* [Add different types of markers](how-to/add-different-types-of-markers)
