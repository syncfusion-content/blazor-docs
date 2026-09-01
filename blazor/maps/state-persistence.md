---
layout: post
title: Blazor Maps State Persistence | Syncfusion®
description: Learn how to retain Blazor Maps model values across page refreshes by setting EnablePersistence to store state in browser storage.
platform: Blazor
control: Maps
documentation: ug
---

# Blazor Maps State Persistence

State persistence retains selected Maps model values in the browser's local storage so they survive a page refresh. This behavior is controlled by the [EnablePersistence](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.SfMaps.html#Syncfusion_Blazor_Maps_SfMaps_EnablePersistence) property of [SfMaps](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.SfMaps.html), which is **false** by default. Set it to **true** to retain state.

The persisted state includes interaction-related values such as the current zoom factor, center position, and selected shapes. It does not persist data-source content or design-time settings.

N> Assign a unique [ID](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.SfMaps.html#Syncfusion_Blazor_Maps_SfMaps_ID) to the component. The `ID` is used as the local-storage key, so persistence requires a stable value that is unique across the application.

```cshtml

@using Syncfusion.Blazor.Maps

<SfMaps ID="persist-map" EnablePersistence="true">
    <MapsLayers>
        <MapsLayer ShapeData='new {dataOptions= "https://cdn.syncfusion.com/maps/map-data/world-map.json"}' TValue="string">
        </MapsLayer>
    </MapsLayers>
    <MapsZoomSettings Enable="true"></MapsZoomSettings>
</SfMaps>

```

To clear the persisted state, remove the entry keyed by the component `ID` from the browser's local storage.