---
layout: post
title: State Persistence in Blazor Maps Component | Syncfusion 
description: Learn about State Persistence in Blazor Maps component of Syncfusion, and more details.
platform: Blazor
control: Maps
documentation: ug
---

# State Persistence

## State Persistence

State persistence allows the Maps to retain the current modal value in the browser cookies for state maintenance. This action is handled through the `enablePersistence` property which is set to false by default. When it is set to true, some of the Maps component model values will be retained even after refreshing the page.

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
