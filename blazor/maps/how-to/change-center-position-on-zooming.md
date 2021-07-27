---
layout: post
title: Change center position on zooming in Blazor Maps Component | Syncfusion
description: Learn here all about Change center position on zooming in Syncfusion Blazor Maps component and more.
platform: Blazor
control: Maps
documentation: ug
---

# Change center position on zooming in Blazor Maps Component

If you zoom the map using the [`ZoomFactor`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsZoomSettings.html#Syncfusion_Blazor_Maps_MapsZoomSettings_ZoomFactor) property, the center location of the map will be zoomed. In some cases, you may need to zoom in other than the center position, and you can do this by specifying the geo location in the [`CenterPosition`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.SfMaps.html#Syncfusion_Blazor_Maps_SfMaps_CenterPosition) property as shown in the following code example.

 The center position is used to configure the geo location, where the maps should be zoomed, and zoom factor is used to specify zoom level of the maps.

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

![Maps with zoom Factor](../images/ZoomFactor.PNG)G)