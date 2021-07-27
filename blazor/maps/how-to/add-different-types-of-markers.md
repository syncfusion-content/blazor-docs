---
layout: post
title: Add different types of markers in Blazor Maps Component | Syncfusion
description: Learn here all about Add different types of markers in Syncfusion Blazor Maps component and more.
platform: Blazor
control: Maps
documentation: ug
---

# Add different types of markers in Blazor Maps Component

You can add different types of markers in the Maps component using the [`MapsMarkerSettings`](https://help.syncfusion.com/cr/aspnetcore-blazor/Syncfusion.Blazor.Maps.MapsMarkerSettings.html) property.

The following steps describe how to add different types of markers.

<b>Step 1</b>

Initialize the Maps component with marker settings. Here, a marker is added with specified latitude and longitude of California using the [`DataSource`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfStockChart.html#Syncfusion_Blazor_Charts_SfStockChart_Crosshair) property. You can customize the shape of the marker using the [`Shape`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsMarker.html#Syncfusion_Blazor_Maps_MapsMarker_Shape) property and change the border color and width of the marker using the [`MapsMarkerBorder`](https://help.syncfusion.com/cr/aspnetcore-blazor/Syncfusion.Blazor.Maps.MapsMarkerBorder.html) tag as demonstrated in the following code example.

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
    };
    private List<City> Cities = new List<City> {
            new City{ Latitude = 40.7424509, Longitude = -74.0081468, Name = "New York" }
    };
}
```

![Markers with circle shape](../images/SingleMarker.PNG)

<b>Step 2</b>

Customize the above option for n number of markers as demonstrated in the following code example.

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
    };
    public List<City> HighestPopulation = new List<City> {
        new City { Latitude = 40.7424509, Longitude = -74.0081468, Name = "New York" }
    };
    public List<City> LowestPopulation = new List<City> {
        new City { Latitude=33.5302186, Longitude=-117.7418381, Name="Laguna Niguel" }
    };
}
```

![Maps with multiple marker](../images/MultipleMarker.PNG)

## Tooltip for marker

Tooltip is used to display more information about marker on mouse over or touch-end event. This can be enabled separately for layer or marker using the [`MapsMarkerTooltipSettings`](https://help.syncfusion.com/cr/aspnetcore-blazor/Syncfusion.Blazor.Maps.MapsMarkerTooltipSettings.html) tag. The [`ValuePath`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartIndicator.html#Syncfusion_Blazor_Charts_StockChartIndicator_Type) property in tooltip takes the field name that presents in dataSource and displays that value as tooltip text. The following code example demonstrates how to enable tooltip for marker to show city name.

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
    };
    public List<City> HighestPopulation = new List<City> {
        new City { Latitude = 40.7424509, Longitude = -74.0081468, Name = "New York" }
    };
}
```

![Maps with marker Tooltip](../images/MarkerTooltip.png)