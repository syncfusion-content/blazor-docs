---
layout: post
title: How to Change Center Position on Zooming in Blazor Maps | Syncfusion®
description: Learn how to change the Blazor Maps center on zoom by setting MapsCenterPosition coordinates and the ZoomFactor in MapsZoomSettings.
platform: Blazor
control: Maps
documentation: ug
---

# How to Change Center Position on Zooming in Blazor Maps

The Blazor Maps component supports changing the map's center position by specifying coordinates in the [MapsCenterPosition](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsCenterPosition.html). The [ZoomFactor](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsZoomSettings.html#Syncfusion_Blazor_Maps_MapsZoomSettings_ZoomFactor) property in the [MapsZoomSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsZoomSettings.html) focuses on the specified center position.

```cshtml

@using Syncfusion.Blazor.Maps

<SfMaps>
    @* To change center position *@
    <MapsCenterPosition Latitude="25.54244147012483" Longitude="-89.62646484375"></MapsCenterPosition>
    <MapsZoomSettings Enable="false" ZoomFactor="13"></MapsZoomSettings>
    <MapsLayers>
        <MapsLayer ShapeData='new {dataOptions= "https://cdn.syncfusion.com/maps/map-data/world-map.json"}' TValue="string"></MapsLayer>
    </MapsLayers>
</SfMaps>

```

![Blazor Maps with Zooming Factor](../images/blazor-maps-zooming.webp)
