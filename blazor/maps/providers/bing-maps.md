---
layout: post
title: Bing Maps in Blazor Maps Component | Syncfusion 
description: Learn about Bing Maps in Blazor Maps component of Syncfusion, and more details.
platform: Blazor
control: Maps
documentation: ug
---

# Bing Maps

Bing maps is a map of the entire World owned by Microsoft. As like OSM, it provides map tile images based on our requests and combines those images into a single one to display the map area.

## Add Bing Maps

One of the most important features in Blazor Maps component is the built-in online map provider support. By using this feature, you can render Bing maps in the maps component. This provides the ability to visualize satellite, aerial, and street maps without using any external shape files.

You can enable this feature by setting [`LayerType`](https://help.syncfusion.com/cr/aspnetcore-blazor/Syncfusion.Blazor.Maps.ShapeLayerType.html) to “ShapeLayerType.Bing”.

```csharp
@using Syncfusion.Blazor.Maps

<SfMaps>
    <MapsLayers>
        <MapsLayer LayerType="ShapeLayerType.Bing" TValue="string" Key=""></MapsLayer>
    </MapsLayers>
</SfMaps>
```

> Specify Bing map key in the `Key` property.

![Bing map](../images/MapProviders/Bing-map.png)

## Types of Bing maps

* **Aerial** - Displays satellite images to highlight roads and major landmarks for easy identification.
* **AerialWithLabel** - Displays aerial map with labels for the continent, country, ocean, etc.
* **Road** - Displays the default map view of roads, buildings, and geography.
* **CanvasDark** - Displays dark version of the road maps.
* **CanvasLight** - Displays light version of the road maps.
* **CanvasGray** - Displays grayscale version of the road maps.

To render the light version of the road maps, set the [`BingMapType`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsLayer.html#Syncfusion_Blazor_Maps_MapsLayer_BingMapType) to [`CanvasLight`](https://help.syncfusion.com/cr/aspnetcore-blazor/Syncfusion.Blazor.Maps.BingMapType.html) as demonstrated in the following code sample.

```csharp
@using Syncfusion.Blazor.Maps

<SfMaps>
    <MapsLayers>
        <MapsLayer LayerType="ShapeLayerType.Bing" BingMapType="BingMapType.CanvasLight" Key="" TValue="string">
        </MapsLayer>
    </MapsLayers>
    @* Additionally map has been zoomed based on the center position *@
    <MapsZoomSettings ZoomFactor="12"></MapsZoomSettings>
    <MapsCenterPosition Latitude="38.8951" Longitude="-77.0364"></MapsCenterPosition>
</SfMaps>
```

> Specify Bing maps key in the `Key` property.

![Bing map with light version of road maps](../images/MapProviders/Bing-map-with-canvas.png)

## Zooming and panning

You can zoom and pan the Bing maps layer. Zooming helps you get a closer look at a particular area on a map for in-depth analysis. Panning helps you to move a map around to focus the targeted area.

```csharp
@using Syncfusion.Blazor.Maps

<SfMaps>
    @* To zoom and pan using toolbar *@
    <MapsZoomSettings Enable="true"
                      Toolbars='new string[]{"Zoom", "ZoomIn", "ZoomOut", "Pan", "Reset" }'>
    </MapsZoomSettings>
    <MapsLayers>
        <MapsLayer LayerType="ShapeLayerType.Bing" Key="" TValue="string"></MapsLayer>
    </MapsLayers>
</SfMaps>
```

> Specify Bing map key in the `Key` property.

![Bing Maps with zooming](../images/MapProviders/osm-zooming.gif)

## Adding markers and navigation line

Markers can be added to the layers of Bing maps by setting the corresponding location's coordinates of latitude and longitude using `MapsMarker` property. You can add navigation lines on top of an Bing maps layer for highlighting a path among various places by setting the corresponding location's coordinates of latitude and longitude in the `MapsNavigationLine` property.

```csharp
@using Syncfusion.Blazor.Maps

<SfMaps>
    <MapsZoomSettings ZoomFactor="4"></MapsZoomSettings>
    <MapsCenterPosition Latitude="29.394708" Longitude="-94.954653"></MapsCenterPosition>
    <MapsLayers>
        <MapsLayer LayerType="ShapeLayerType.Bing"
                   BingMapType="BingMapType.CanvasLight"
                   Key="" TValue="string">
            @* Add markers *@
            <MapsMarkerSettings>
                <MapsMarker Visible="true"
                            Height="25"
                            Width="15"
                            DataSource="Cities" TValue="City">
                </MapsMarker>
            </MapsMarkerSettings>
            @* Add navigation line *@
            <MapsNavigationLines>
                <MapsNavigationLine Visible="true"
                                    Color="blue"
                                    Angle="0.1"
                                    Latitude="new double[]{34.060620, 40.724546}"
                                    Longitude="new double[]{-118.330491,-73.850344}">
                </MapsNavigationLine>
            </MapsNavigationLines>
        </MapsLayer>
    </MapsLayers>
</SfMaps>

@code{
    public class City
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Name { get; set; }
    }
    private List<City> Cities = new List<City> {
        new City { Latitude = 34.060620, Longitude = -118.330491,  Name="California" },
        new City{ Latitude = 40.724546, Longitude = -73.850344,  Name="New York"}
    };
}
```

> Specify Bing map key in the `Key` property.

![Bing Maps with markers and navigation line](../images/MapProviders/bing-marker-and-line.png)

## Sublayer

You can render any GeoJSON shape as a sublayer on top of an Bing maps layer for highlighting a particular continent or country in Bing maps by adding another layer and specifying the type to SubLayer.

> [Refer to section](../how-to/display-geometry-shapes-in-bing-maps) to learn how to add a sublayer in Bing maps

## Key

The Bing maps key is provided as input to this key property. The Bing Maps key can be obtained from [Bing Maps](http://www.microsoft.com/maps/create-a-bing-maps-key.aspx).
