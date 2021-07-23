---
layout: post
title: Layers in Blazor Maps Component | Syncfusion 
description: Learn about Layers in Blazor Maps component of Syncfusion, and more details.
platform: Blazor
control: Maps
documentation: ug
---

# Layers

The Maps component is rendered through [`MapsLayers`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsLayers.html) class and any number of layers can be added to the Maps.

## Multilayer

The Multilayer support allows loading multiple shape files and map providers in a single container, enabling Maps to display more information. The shape layer or map providers are the main layers of the Maps. Multiple layers can be added as sublayer over the main layers using the [`Type`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.Type.html) property in the [`MapsLayer`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsLayer-1.html) class.

## Sublayer

Sublayer is a type of shape layer. It allows loading multiple shape files in a single map view. For example, a sublayer can be added over the main layer to view geographic features such as rivers, valleys and cities in a map of a country. Similar to the main layer, elements in the Maps such as markers, bubbles, color mapping and legends can be added to the sub-layer.

In this example, the United States map shape is used as shape data by utilizing the **usa.json** file, and the **texas.json** and **california.json** files are used as sub-layers in the United States map.

```csharp
@using Syncfusion.Blazor.Maps

<SfMaps>
    <MapsLayers>
        <MapsLayer ShapeData='new {dataOptions ="https://cdn.syncfusion.com/maps/map-data/usa.json"}' TValue="string">
            <MapsShapeSettings Fill="#E5E5E5">
                <MapsShapeBorder Color="black" Width="0.1"></MapsShapeBorder>
            </MapsShapeSettings>
        </MapsLayer>
        <MapsLayer ShapeData='new {dataOptions = "https://cdn.syncfusion.com/maps/map-data/texas.json"}' Type="Syncfusion.Blazor.Maps.Type.SubLayer" TValue="string">
            <MapsShapeSettings Fill="rgba(141, 206, 255, 0.6)">
                <MapsShapeBorder Color="#1a9cff" Width="0.25"></MapsShapeBorder>
            </MapsShapeSettings>
        </MapsLayer>
        <MapsLayer ShapeData='new {dataOptions= "https://cdn.syncfusion.com/maps/map-data/california.json"}' Type="Syncfusion.Blazor.Maps.Type.SubLayer" TValue="string">
            <MapsShapeSettings Fill="rgba(141, 206, 255, 0.6)">
                <MapsShapeBorder Color="#1a9cff" Width="0.25"></MapsShapeBorder>
            </MapsShapeSettings>
        </MapsLayer>
    </MapsLayers>
</SfMaps>
```

![Maps with sublayer](./images/Layers/layers.png)

## Displaying layer in the view

Multiple shape files and map providers can be loaded simultaneously in Maps. The [`BaseLayerIndex`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor~Syncfusion.Blazor.Maps.SfMaps~BaseLayerIndex.html) property is used to determine which layer should be displayed on the user interface. This property is used for the Maps drill-down feature, so when the [`BaseLayerIndex`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor~Syncfusion.Blazor.Maps.SfMaps~BaseLayerIndex.html) value is changed, the corresponding shape is loaded. For example, two layers can be loaded with the World map and the United States map. Based on the given [`BaseLayerIndex`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor~Syncfusion.Blazor.Maps.SfMaps~BaseLayerIndex.html) value, the corresponding shape will be loaded in the user interface. In the below code snippet, if the [`BaseLayerIndex`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor~Syncfusion.Blazor.Maps.SfMaps~BaseLayerIndex.html) value is set to 1, then the USA map will be loaded.

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

![Maps with multiple layer](./images/Layers/multi-layer.png)

> When only the [`ShapeData`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsLayer-1.html#Syncfusion_Blazor_Maps_MapsLayer_1_ShapeData) property is set in the [`MapsLayer`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsLayer-1.html) class, the Maps component will render. By default, the [`LayerType`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsLayer-1.html#Syncfusion_Blazor_Maps_MapsLayer_1_LayerType) is **Geometry** type. If a [`LayerType`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsLayer-1.html#Syncfusion_Blazor_Maps_MapsLayer_1_LayerType) other than **Geometry** is set and [`ShapeData`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsLayer-1.html#Syncfusion_Blazor_Maps_MapsLayer_1_ShapeData) is specified in the [`MapsLayer`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsLayer-1.html), the Maps will be rendered based on the provided [`LayerType`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsLayer-1.html#Syncfusion_Blazor_Maps_MapsLayer_1_LayerType). For example, when the [`LayerType`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsLayer-1.html#Syncfusion_Blazor_Maps_MapsLayer_1_LayerType) is set as **OSM** and [`ShapeData`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsLayer-1.html#Syncfusion_Blazor_Maps_MapsLayer_1_ShapeData) property is set, then the **OSM** map will be rendered in the component.

## See also

* [Display geometry shapes in Bing maps](how-to/display-geometry-shapes-in-bing-maps)
