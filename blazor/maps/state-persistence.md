---
layout: post
title: State Persistence in Blazor Maps Component | Syncfusion
description: Check out and learn how to enable and use state persistence in the Syncfusion Blazor Maps component.
platform: Blazor
control: Maps
documentation: ug
---

# State Persistence in Blazor Maps Component

## State Persistence

State persistence retains selected Maps model values in browser storage for state maintenance. This behavior is controlled by the `EnablePersistence` property, which is set to **false** by default. When set to **true**, selected Maps component model values are retained after refreshing the page.

```cshtml

@using Syncfusion.Blazor.Maps

<SfMaps EnablePersistence ="true">
    <MapsLayers>
        <MapsLayer ShapeData='new {dataOptions= "https://cdn.syncfusion.com/maps/map-data/world-map.json"}' TValue="string">
        </MapsLayer>
    </MapsLayers>
    <MapsZoomSettings Enable='true'></MapsZoomSettings>
</SfMaps>

```