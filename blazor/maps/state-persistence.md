---
layout: post
title: Blazor Maps State Persistence | Syncfusion®
description: Learn how to retain Blazor Maps model values across page refreshes by setting EnablePersistence to store state in browser storage.
platform: Blazor
control: Maps
documentation: ug
---

# Blazor Maps State Persistence

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