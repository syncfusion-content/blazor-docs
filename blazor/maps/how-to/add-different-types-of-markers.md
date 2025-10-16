---
layout: post
title: Add different types of markers in Blazor Maps Component | Syncfusion
description: Check out and learn how to  add and customize different marker types in the Syncfusion Blazor Maps component.
platform: Blazor
control: Maps
documentation: ug
---

# Add different types of markers in Blazor Maps Component

Markers can be added in the Maps component using the [MapsMarkerSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsMarkerSettings.html). The following steps describe how to add different types of markers.

<b>Step 1</b>

Initialize the Maps component with marker settings. A marker is added with the specified latitude and longitude of California using the [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsMarker-1.html#Syncfusion_Blazor_Maps_MapsMarker_1_DataSource) property. The shape of the marker can be customized using the [Shape](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsMarker-1.html#Syncfusion_Blazor_Maps_MapsMarker_1_Shape) property, and the border color and width can be changed using the [MapsMarkerBorder](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsMarkerBorder.html).

```cshtml

@using Syncfusion.Blazor.Maps

<SfMaps>
    <MapsLayers>
        <MapsLayer ShapeData='new {dataOptions= "https://cdn.syncfusion.com/maps/map-data/world-map.json"}' TValue="string">
            <MapsMarkerSettings>
                <MapsMarker Visible="true"
                            Shape="MarkerType.Circle"
                            Fill="white"
                            Width="15"
                            DataSource="Cities" TValue="City">
                    <MapsMarkerBorder Width="2" Color="#333"></MapsMarkerBorder>
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

    private List<City> Cities = new List<City> {
        new City{ Latitude = 40.7424509, Longitude = -74.0081468, Name = "New York" }
    };
}
```

![Blazor Maps Marker with Circle Shape](../images/blazor-maps-marker-with-circle.PNG)

<b>Step 2</b>

Customize the above option for multiple markers as shown in the following example.

```cshtml

@using Syncfusion.Blazor.Maps

<SfMaps>
    <MapsLayers>
        <MapsLayer ShapeData='new {dataOptions= "https://cdn.syncfusion.com/maps/map-data/world-map.json"}' TValue="string">
            <MapsMarkerSettings>
                <MapsMarker Visible="true" Shape="MarkerType.Circle"
                            Fill="white"
                            Width="20"
                            DataSource="HighestPopulation" TValue="City">
                    <MapsMarkerBorder Width="2" Color="#333"></MapsMarkerBorder>
                </MapsMarker>
                <MapsMarker Visible="true" Shape="MarkerType.Rectangle"
                            Fill="yellow"
                            Width="20"
                            Height="5"
                            DataSource="LowestPopulation" TValue="City">
                    <MapsMarkerBorder Width="2" Color="#333"></MapsMarkerBorder>
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

    public List<City> LowestPopulation = new List<City> {
        new City { Latitude = 33.5302186, Longitude = -117.7418381, Name = "Laguna Niguel" }
    };
}

```

![Blazor Maps with Multiple Marker](../images/blazor-maps-multiple-marker.PNG)

## Tooltip for marker

A tooltip displays additional information about a marker on mouse over or touch end. It can be enabled separately for a layer or marker using the [MapsMarkerTooltipSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsMarkerTooltipSettings.html). The [ValuePath](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsMarkerTooltipSettings.html#Syncfusion_Blazor_Maps_MapsMarkerTooltipSettings_ValuePath) property specifies the field in the data source and displays that value as tooltip text.

```cshtml

@using Syncfusion.Blazor.Maps

<SfMaps>
    <MapsLayers>
        <MapsLayer ShapeData='new {dataOptions ="https://cdn.syncfusion.com/maps/map-data/usa.json"}' TValue="string">
            <MapsMarkerSettings>
                <MapsMarker Visible="true" Shape="MarkerType.Circle"
                            Fill="white"
                            Width="20"
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

![Blazor Maps with Marker Tooltip](../images/blazor-maps-marker-tooltip.png)
