---
layout: post
title: State Persistence in Blazor Map | Syncfusion®
description: Retain Syncfusion Blazor Map model values across page refreshes by setting the EnablePersistence property to store state in browser storage.
platform: Blazor
control: Maps
documentation: ug
---

# State Persistence in Blazor Map

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