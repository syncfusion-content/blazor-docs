---
layout: post
title: Other Maps in Blazor Maps Component | Syncfusion
description: Checkout and learn here all about Other Maps in Syncfusion Blazor Maps component and much more details.
platform: Blazor
control: Maps
documentation: ug
---

# Other Maps in Blazor Maps Component

Apart from OpenStreetMap and Bing Maps, you can also render Maps from other online map service providers by specifying the URL provided by those providers in the [UrlTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsLayer-1.html#Syncfusion_Blazor_Maps_MapsLayer_1_UrlTemplate) property. The URL template concept has been implemented in such a way that any online map service providers using the following template can benefit from previewing their Map in the Syncfusion Blazor Maps component.

Sample Template: https://< domain_name >/maps/basic/{z}/{x}/{y}.png

* "${z}" - It represents zoom factor (level).
* "${x}" - It indicates tile image x-position (tileX).
* "${y}" - It indicates tile image y-position (tileY).

In this case, the key generated for those online map service providers can also be appended to the URL. This allows you to create personalized Maps with your own content and imagery. In this example, Google Maps is rendered.

> Refer to [Google Maps Licensing](https://developers.google.com/maps/terms#10-license-restrictions).

```cshtml
@using Syncfusion.Blazor.Maps

<SfMaps>
    <MapsLayers>
        <MapsLayer UrlTemplate="http://mt1.google.com/vt/lyrs=m@129&hl=en&x=tileX&y=tileY&z=level" TValue="string">
        </MapsLayer>
    </MapsLayers>
</SfMaps>
```

![Syncfusion Maps with Google Maps provider](../images/MapProviders/Google-map.png)

**Enable zooming and panning**

Tile Maps layer can be zoomed and panned. Zooming helps to get a closer look at a particular area on a Maps for in-depth analysis. Panning helps to move a Maps around to focus the targeted area.

```cshtml
@using Syncfusion.Blazor.Maps

<SfMaps>
    @* To zoom and pan *@
    <MapsZoomSettings Enable="true">
        <MapsZoomToolbarSettings>
            <MapsZoomToolbarButton ToolbarItems="new List<ToolbarItem>() { ToolbarItem.Zoom, ToolbarItem.ZoomIn, ToolbarItem.ZoomOut,
            ToolbarItem.Pan, ToolbarItem.Reset }"></MapsZoomToolbarButton>
        </MapsZoomToolbarSettings>
    </MapsZoomSettings>
    <MapsLayers>
        <MapsLayer UrlTemplate="http://mt1.google.com/vt/lyrs=m@129&hl=en&x=tileX&y=tileY&z=level" TValue="string">
        </MapsLayer>
    </MapsLayers>
</SfMaps>
```

![Google Maps with zooming](../images/MapProviders/google-map-zoom.png)

**Adding markers and navigation line**

Markers can be added to the layers of tile Maps by setting the corresponding location's coordinates of latitude and longitude using [MapsMarker](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsMarker-1.html) class. Navigation lines can be added on top of the tile Maps layer for highlighting a path among various places by setting the corresponding location's coordinates of latitude and longitude in the [MapsNavigationLine](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsNavigationLine.html).

```csharp
@using Syncfusion.Blazor.Maps

<SfMaps>
    <MapsZoomSettings ZoomFactor="4"></MapsZoomSettings>
    <MapsCenterPosition Latitude="29.394708" Longitude="-94.954653"></MapsCenterPosition>
    <MapsLayers>
        <MapsLayer UrlTemplate="http://mt1.google.com/vt/lyrs=m@129&hl=en&x=tileX&y=tileY&z=level" TValue="string">
            @* Add markers *@
            <MapsMarkerSettings>
                <MapsMarker Visible="true" Height="25" Width="15" DataSource="Cities" TValue="City">
                </MapsMarker>
            </MapsMarkerSettings>
            @* Add navigation line *@
            <MapsNavigationLines>
                <MapsNavigationLine Visible="true" Color="blue" Angle="0.1" Latitude="new double[]{34.060620, 40.724546}"
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

![Google Maps with markers and navigation line](../images/MapProviders/google-map-marker-and-line.png)

**Adding sublayer**

Any GeoJSON shape can be rendered as a sublayer on top of the tile Maps layer for highlighting a particular continent or country in tile maps by adding another layer and specifying the [Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsLayer-1.html#Syncfusion_Blazor_Maps_MapsLayer_1_Type) property of [MapsLayer](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsLayer-1.html) to **SubLayer**.

```cshtml
@using Syncfusion.Blazor.Maps

<SfMaps>
    <MapsLayers>
        <MapsLayer UrlTemplate="http://mt1.google.com/vt/lyrs=m@129&hl=en&x=tileX&y=tileY&z=level" TValue="string">
        </MapsLayer>
        @* To add geometry shape as sublayer *@
        <MapsLayer ShapeData='new {dataOptions = "https://cdn.syncfusion.com/maps/map-data/africa.json"}'
                   Type="Syncfusion.Blazor.Maps.Type.SubLayer" TValue="string">
            <MapsShapeSettings Fill="blue"></MapsShapeSettings>
        </MapsLayer>
    </MapsLayers>
</SfMaps>
```

![Google Maps with sublayer](../images/MapProviders/google-map-sublayer.png)

## Other supportive online map service providers

The Maps component can also render the following online map service providers, which are listed below.

* MapBox
* TomTom
* ESRI

```cshtml
@using Syncfusion.Blazor.Maps

<SfMaps>
    <MapsLayers>
        @* Renders Mapbox map *@
        <MapsLayer UrlTemplate="https://api.mapbox.com/styles/v1/mapbox/streets-v11/tiles/level/tileX/tileY?access_token=" TValue="string">
        </MapsLayer>
        @* Renders TomTom map *@
        <!--<MapsLayer UrlTemplate="http://api.tomtom.com/map/1/tile/basic/main/level/tileX/tileY.png?key=zzVjM8webeABaPadifIf9hFpmdC9XzmG" TValue="string">
        </MapsLayer>-->
        @* Renders ESRI map *@
        <!--<MapsLayer UrlTemplate="https://ibasemaps-api.arcgis.com/arcgis/rest/services/World_Imagery/MapServer/tile/level/tileY/tileX?apiKey=AAPK04316d918e224b339f72d107b5aef880I2MT0hI3L2xIX4DMcuEELiOcb4DRmxeGp_-hqlsFhziOvqBwel-uIA-87Dp9h3eI" TValue="string">
        </MapsLayer>-->
    </MapsLayers>
</SfMaps>
```

![MapBox Map](../images/MapProviders/mapbox.png)

![TomTom Map](../images/MapProviders/tomtom.png)