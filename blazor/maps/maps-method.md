---
layout: post
title: Methods in Blazor Maps Component | Syncfusion
description: Checkout and learn here all about Methods in Syncfusion Blazor Maps component and much more details.
platform: Blazor
control: Maps
documentation: ug
---

# Methods in Blazor Maps Component

This section explains the methods used in the Maps component.

## ShapeSelectionAsync

The [ShapeSelectionAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.SfMaps.html#methods) method can be used to select a shape dynamically in the shape layer of the Maps. The following are the arguments for this method.

|   Argument name      |   Description                            |
|----------------------| -----------------------------------------|
|     layerIndex       |    Specifies the index number of layer in which the shape is to be selected. |
|     propertyName     |    Specifies the property path for map shape data to select the shape.           |
|     name             |    Specifies the shape data path for the data source of the layer.           |
|     enable           |    Specifies whether to select or unselect the shape. |

```cshtml
@using Syncfusion.Blazor.Maps

<button @onclick="ShapeSelectAsync">Select Shape</button>
<SfMaps @ref="maps">
    <MapsZoomSettings Enable="true" EnablePanning="true">
    </MapsZoomSettings>
    <MapsLayers>
        <MapsLayer ShapeData='new {dataOptions= "https://cdn.syncfusion.com/maps/map-data/world-map.json"}' TValue="string">
		    <MapsLayerSelectionSettings Enable="true">
        </MapsLayer>
    </MapsLayers>
</SfMaps>

@code {
    SfMaps maps;
    public async Task ShapeSelectAsync()
    {
        await maps.ShapeSelectionAsync(0, "Argentina", "Argentina");
    }
}
```

## Refresh

The [Refresh](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.SfMaps.html#Syncfusion_Blazor_Maps_SfMaps_Refresh) method can be used to change the state of the component and render it again. In the following example, the Maps is rendered again using the [Refresh](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.SfMaps.html#Syncfusion_Blazor_Maps_SfMaps_Refresh) method.

```cshtml
@using Syncfusion.Blazor.Maps

<button @onclick="Refresh">Refresh</button>
<SfMaps @ref="maps">
    <MapsZoomSettings Enable="true" EnablePanning="true">
    </MapsZoomSettings>
    <MapsLayers>
        <MapsLayer ShapeData='new {dataOptions= "https://cdn.syncfusion.com/maps/map-data/world-map.json"}' TValue="string">
        </MapsLayer>
    </MapsLayers>
</SfMaps>

@code {
    SfMaps maps;
    public void Refresh()
    {
        await maps.Refresh();
    }
}
```

## PanByDirectionAsync

[PanByDirectionAsync]((https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.SfMaps.html#methods)) method pans the Maps dynamically by specifying direction. The following are the arguments for this method.

|   Argument name      |   Description                            |
|----------------------| -----------------------------------------|
|     direction        |    Specifies to the direction of panning operation. |
|     mouseLocation    |    Specifies the position of the panning within the Maps.  |

```cshtml
@using Syncfusion.Blazor.Maps

<button @onclick="PanByDirectionAsync">Pan by Direction</button>
<SfMaps @ref="maps">
    <MapsZoomSettings Enable="true" EnablePanning="true">
    </MapsZoomSettings>
    <MapsLayers>
        <MapsLayer ShapeData='new {dataOptions= "https://cdn.syncfusion.com/maps/map-data/world-map.json"}' TValue="string">
        </MapsLayer>
    </MapsLayers>
</SfMaps>

@code {
    SfMaps maps;
    void PanByDirectionAsync()
    {
        Syncfusion.Blazor.Maps.Internal.Point position = new Syncfusion.Blazor.Maps.Internal.Point();
        position.X = 120;
        position.Y = 200;
        maps.PanByDirectionAsync(Syncfusion.Blazor.Maps.PanDirection.Bottom, position);
    }
}
```

## ZoomByPosition

[ZoomByPosition](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.SfMaps.html#Syncfusion_Blazor_Maps_SfMaps_ZoomByPosition_Syncfusion_Blazor_Maps_MapsCenterPosition_System_Double_) method zooms the Maps by specifying the center position for the map. The following are the arguments for this method.

|   Argument name      |   Description                            |
|----------------------| -----------------------------------------|
|     centerPosition   |    Specifies the position of the maps.   |
|     zoomFactor       |    Specifies the zoom level of maps.     |

```cshtml
@using Syncfusion.Blazor.Maps

<button @onclick="ZoomByPosition">Print</button>
<SfMaps @ref="maps">
    <MapsZoomSettings Enable="true">
    </MapsZoomSettings>
    <MapsLayers>
        <MapsLayer ShapeData='new {dataOptions= "https://cdn.syncfusion.com/maps/map-data/world-map.json"}' TValue="string">
        </MapsLayer>
    </MapsLayers>
</SfMaps>

@code {
    SfMaps maps;
    public void ZoomByPosition()
    {
        MapsCenterPosition centerPosition = new MapsCenterPosition();
        centerPosition.Latitude = 35.145083;
        centerPosition.Longitude = -117.960260;
        maps.ZoomByPosition(centerPosition, 2);
    }
}
```

## ZoomToCoordinates

[ZoomToCoordinates](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.SfMaps.html#Syncfusion_Blazor_Maps_SfMaps_ZoomToCoordinates_System_Double_System_Double_System_Double_System_Double_) zooms the map to the center point of the provied minimum and maximum coordinates.  The following are the arguments for this method.

|   Argument name      |   Description                            |
|----------------------| -----------------------------------------|
|     minLatitude      |    Specifies the minimum latitude of the coordinate for the zooming operation.   |
|     minLongitude     |    Specifies the minimum longitude of the coordinate for the zooming operation.     |
|     maxLatitude      |    Specifies the maximum latitude of the coordinate for the zooming operation.   |
|     maxLongitude     |    Specifies the maximum longitude of the coordinate for the zooming operation. |

```cshtml
@using Syncfusion.Blazor.Maps

<button @onclick="ZoomToCoordinates">Print</button>
<SfMaps @ref="maps">
    <MapsZoomSettings Enable="true">
    </MapsZoomSettings>
    <MapsLayers>
        <MapsLayer ShapeData='new {dataOptions= "https://cdn.syncfusion.com/maps/map-data/world-map.json"}' TValue="string">
        </MapsLayer>
    </MapsLayers>
</SfMaps>

@code {
    SfMaps maps;
    public void ZoomToCoordinates()
    {
        maps.ZoomToCoordinates(0, 0, 100, 100);
    }
}
```
