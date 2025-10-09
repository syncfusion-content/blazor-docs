---
layout: post
title: Layers in Blazor Maps Component | Syncfusion
description: Check out and learn how to configure layers in the Syncfusion Blazor Maps component and much more details.
platform: Blazor
control: Maps
documentation: ug
---

# Layers in Blazor Maps Component

The Maps component is rendered through [MapsLayers](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsLayers.html), and any number of layers can be added to Maps.

## Multilayer

The multilayer feature supports loading multiple shape files and map providers in a single container, enabling Maps to display more information. The shape layer or map providers are the main layers. Multiple layers can be added as a **SubLayer** over the main layers using the [Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.Type.html) property in [MapsLayer](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsLayer-1.html).

## Sublayer

Sublayer is a type of shape file layer. It supports loading multiple shape files in a single map view. For example, a sublayer can be added over the main layer to display geographic features such as rivers, valleys, and cities in a country map. Similar to the main layer, elements such as markers, bubbles, color mapping, and legends can be added to the sublayer.

In this example, the United States map shape is used as shape data from the **usa.ts** file, and **texas.ts** and **california.ts** files are used as sublayers in the United States map.

```csharp

@using Syncfusion.Blazor.Maps

<SfMaps>
    <MapsLayers>
        <MapsLayer ShapeData='new {dataOptions ="https://cdn.syncfusion.com/maps/map-data/usa.json"}' TValue="string">
            <MapsShapeSettings Fill="#E5E5E5">
                <MapsShapeBorder Color="black" Width="0.1"></MapsShapeBorder>
            </MapsShapeSettings>
        </MapsLayer>
        <MapsLayer ShapeData='new {dataOptions = "https://cdn.syncfusion.com/maps/map-data/texas.json"}'
	        Type="Syncfusion.Blazor.Maps.Type.SubLayer" TValue="string">
            <MapsShapeSettings Fill="rgba(141, 206, 255, 0.6)">
                <MapsShapeBorder Color="#1a9cff" Width="0.25"></MapsShapeBorder>
            </MapsShapeSettings>
        </MapsLayer>
        <MapsLayer ShapeData='new {dataOptions= "https://cdn.syncfusion.com/maps/map-data/california.json"}'
	        Type="Syncfusion.Blazor.Maps.Type.SubLayer" TValue="string">
            <MapsShapeSettings Fill="rgba(141, 206, 255, 0.6)">
                <MapsShapeBorder Color="#1a9cff" Width="0.25"></MapsShapeBorder>
            </MapsShapeSettings>
        </MapsLayer>
    </MapsLayers>
</SfMaps>

```

![Blazor Maps with Sublayer](./images/Layers/blazor-maps-sublayer.png)

## Displaying different layer in the view

Multiple shape files and map providers can be loaded simultaneously. The [BaseLayerIndex](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.SfMaps.html#Syncfusion_Blazor_Maps_SfMaps_BaseLayerIndex) property determines which layer is displayed. This property also supports the drill-down feature; when the [BaseLayerIndex](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.SfMaps.html#Syncfusion_Blazor_Maps_SfMaps_BaseLayerIndex) value changes, the corresponding shape is loaded. In this example, two layers are configured for the world map and the United States map. Based on the [BaseLayerIndex](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.SfMaps.html#Syncfusion_Blazor_Maps_SfMaps_BaseLayerIndex) value, the corresponding shape is rendered. If [BaseLayerIndex](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.SfMaps.html#Syncfusion_Blazor_Maps_SfMaps_BaseLayerIndex) is set to **0**, the world map is loaded.

```csharp

@using Syncfusion.Blazor.Maps

@*  To switch the layer, set `BaseLayerIndex`  *@
<SfMaps BaseLayerIndex="1">
    <MapsLayers>
        <MapsLayer ShapeData='new { dataOptions = "https://cdn.syncfusion.com/maps/map-data/world-map.json" }' TValue="string"/>
        <MapsLayer ShapeData='new { dataOptions = "https://cdn.syncfusion.com/maps/map-data/usa.json" }'TValue="string"/>
    </MapsLayers>
</SfMaps>

```

![Blazor Maps with Multiple Layer](./images/Layers/blazor-maps-multiple-layer.png)

## Rendering custom shapes

Custom shapes (also known as custom maps) can be rendered in Maps to represent bus seat booking, cricket stadiums, basic home plans/sketches, and similar layouts. To achieve this, create a JSON file in GeoJSON format with proper geometries manually or with an online map vendor. Set the created GeoJSON file to the [ShapeData](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsLayer-1.html#Syncfusion_Blazor_Maps_MapsLayer_1_ShapeData) property in the Maps layer, and set [GeometryType](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsLayer-1.html#Syncfusion_Blazor_Maps_MapsLayer_1_GeometryType) to **GeometryType.Normal**.

Refer to the sample GeoJSON file for bus seat selection: [Seat selection GeoJSON](https://cdn.syncfusion.com/maps/map-data/seat.json).

For a live demonstration, see: [Bus seat selection demo](https://blazor.syncfusion.com/demos/maps/bus-seat-selection?theme=bootstrap5).

## See also

* [Display geometry shapes in Bing maps](how-to/display-geometry-shapes-in-bing-maps)
