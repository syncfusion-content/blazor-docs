---
layout: post
title: Blazor Maps Methods Support | Syncfusion®
description: Learn how to use Blazor Maps methods like ShapeSelectionAsync, PrintAsync, ExportAsync, and Refresh to control the map programmatically.
platform: Blazor
control: Maps
documentation: ug
---

# Blazor Maps Methods Support

This section describes the public methods of the Blazor Maps component. Call them through a component reference captured with `@ref`, after the component has rendered. The `PrintAsync` and `ExportAsync` methods are covered in the [Print and export](print-and-export) topic.

## ShapeSelectionAsync

The [ShapeSelectionAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.SfMaps.html#Syncfusion_Blazor_Maps_SfMaps_ShapeSelectionAsync_System_Int32_System_String_System_String_System_Boolean_) method can be used to select a shape dynamically in the shape layer of the Maps. The following are the arguments for this method.

|   Argument name      |   Description                            |
|----------------------| -----------------------------------------|
|     layerIndex       |    Specifies the zero based index of the layer in which the shape is selected. |
|     propertyName     |    Specifies the property path in the map shape data used to locate the shape.           |
|     name             |    Specifies the value to match for the given propertyName in the layer data source.           |
|     enable           |    Specifies whether to select (true) or unselect (false) the shape. |

```cshtml

@using Syncfusion.Blazor.Maps

<button @onclick="ShapeSelectAsync">Select Shape</button>
<SfMaps @ref="maps">
    <MapsZoomSettings Enable="true" EnablePanning="true">
    </MapsZoomSettings>
    <MapsLayers>
        <MapsLayer ShapeData='new {dataOptions= "https://cdn.syncfusion.com/maps/map-data/world-map.json"}' TValue="string">
            <MapsLayerSelectionSettings Enable="true" Fill="Green"></MapsLayerSelectionSettings>
        </MapsLayer>
    </MapsLayers>
</SfMaps>

@code {
    SfMaps maps;

    public async Task ShapeSelectAsync()
    {
         await maps.ShapeSelectionAsync(0, "name", "Argentina", true);
    }
}

```

## Refresh

The [Refresh](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.SfMaps.html#Syncfusion_Blazor_Maps_SfMaps_Refresh) method refreshes the component and renders it again.

```cshtml

@using Syncfusion.Blazor.Maps

<button @onclick="RefreshMap">Refresh</button>
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

    public void RefreshMap()
    {
       maps.Refresh();
    }
}

```

## PanByDirectionAsync

The [PanByDirectionAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.SfMaps.html#Syncfusion_Blazor_Maps_SfMaps_PanByDirectionAsync_Syncfusion_Blazor_Maps_PanDirection_Syncfusion_Blazor_Maps_Internal_Point_) method pans the Maps dynamically by specifying a [PanDirection](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.PanDirection.html). The following are the arguments for this method.

|   Argument name      |   Description                            |
|----------------------| -----------------------------------------|
|     direction        |    Specifies the panning direction. |
|     mouseLocation    |    Specifies the position from which the panning originates within the Maps.  |

```cshtml

@using Syncfusion.Blazor.Maps

<button @onclick="PanByDirection">Pan by Direction</button>
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

    async Task PanByDirection()
    {
        Syncfusion.Blazor.Maps.Internal.Point position = new Syncfusion.Blazor.Maps.Internal.Point();
        position.X = 120;
        position.Y = 200;
        await maps.PanByDirectionAsync(Syncfusion.Blazor.Maps.PanDirection.Bottom, position);
    }
}

```

## ZoomByPosition

The [ZoomByPosition](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.SfMaps.html#Syncfusion_Blazor_Maps_SfMaps_ZoomByPosition_Syncfusion_Blazor_Maps_MapsCenterPosition_System_Double_) method zooms the Maps by specifying the center position. This method triggers the [OnZoom](https://blazor.syncfusion.com/documentation/maps/maps-event#onzoom) event when the zooming operation begins and the [OnZoomComplete](https://blazor.syncfusion.com/documentation/maps/maps-event#onzoomcomplete) event when the zooming operation is completed. The following are the arguments for this method.

|   Argument name      |   Description                            |
|----------------------| -----------------------------------------|
|     centerPosition   |    Specifies the center position of the map.   |
|     zoomFactor       |    Specifies the zoom level of the map.        |

```cshtml

@using Syncfusion.Blazor.Maps

<button @onclick="ZoomMapByPosition">ZoomByPosition</button>
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

    public void ZoomMapByPosition()
    {
        MapsCenterPosition centerPosition = new MapsCenterPosition();
        centerPosition.Latitude = 35.145083;
        centerPosition.Longitude = -117.960260;
        maps.ZoomByPosition(centerPosition, 2);
    }
}

```

## ZoomToCoordinates

The [ZoomToCoordinates](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.SfMaps.html#Syncfusion_Blazor_Maps_SfMaps_ZoomToCoordinates_System_Double_System_Double_System_Double_System_Double_) method zooms the map to the center point of the provided minimum and maximum coordinates. This method triggers the [OnZoom](https://blazor.syncfusion.com/documentation/maps/maps-event#onzoom) event when the zooming operation begins and the [OnZoomComplete](https://blazor.syncfusion.com/documentation/maps/maps-event#onzoomcomplete) event when the zooming operation is completed. The following are the arguments for this method.

|   Argument name      |   Description                            |
|----------------------| -----------------------------------------|
|     minLatitude      |    Specifies the minimum latitude of the coordinate for the zooming operation.   |
|     minLongitude     |    Specifies the minimum longitude of the coordinate for the zooming operation.     |
|     maxLatitude      |    Specifies the maximum latitude of the coordinate for the zooming operation.   |
|     maxLongitude     |    Specifies the maximum longitude of the coordinate for the zooming operation. |

```cshtml

@using Syncfusion.Blazor.Maps

<button @onclick="ZoomMapToCoordinates">ZoomToCoordinates</button>
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

    public void ZoomMapToCoordinates()
    {
        maps.ZoomToCoordinates(6.7, 68.1, 35.5, 97.4);
    }
}

```

N> `ZoomByPosition` and `ZoomToCoordinates` are synchronous and take effect immediately. Latitude values must be within ±90 and longitude values within ±180.

## GetMinMaxLatitudeLongitude

The [GetMinMaxLatitudeLongitude](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.SfMaps.html#Syncfusion_Blazor_Maps_SfMaps_GetMinMaxLatitudeLongitude) method returns the minimum and maximum latitude and longitude values of the Maps visible area. This method returns a [MinMaxLatitudeLongitude](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MinMaxLatitudeLongitude.html) class instance that contains the minimum and maximum latitude and longitude coordinates.

```cshtml

@using Syncfusion.Blazor.Maps
@using System.Collections.ObjectModel

<button @onclick="GetBounds">GetMinMaxLatitudeLongitude</button>

@if(MapBoundCoordinates != null)
{
    <div>
        Maximum Latitude = @MapBoundCoordinates.MaxLatitude <br/>
        Minimum Latitude = @MapBoundCoordinates.MinLatitude  <br />
        Maximum Longitude = @MapBoundCoordinates.MaxLongitude <br />
        Minimum Longitude = @MapBoundCoordinates.MinLongitude
    </div>
}

<SfMaps ID="maps" @ref="MapsRef">
    <MapsZoomSettings Enable="true" ZoomFactor="@ZoomFactor"></MapsZoomSettings>
    <MapsCenterPosition Latitude="@CenterLat" Longitude="@CenterLong"></MapsCenterPosition>
    <MapsLayers>
        <MapsLayer ShapeData='new {dataOptions= "https://cdn.syncfusion.com/maps/map-data/world-map.json"}' TValue="string">
            <MapsMarkerSettings>
                <MapsMarker Visible="true" DataSource="MarkerDataSource" Height="25" Width="25" TValue="MarkerData" Shape="MarkerType.Circle" AnimationDuration="1500">
                </MapsMarker>
            </MapsMarkerSettings>
        </MapsLayer>
    </MapsLayers>
</SfMaps>


@code {
    SfMaps MapsRef;
    public double ZoomFactor = 7;
    public double CenterLat = 21.815447;
    public double CenterLong = 80.1932;
    public MinMaxLatitudeLongitude MapBoundCoordinates;

    public class MarkerData
    {
        public string Name{ get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }

    public void GetBounds()
    {
        MapBoundCoordinates = MapsRef?.GetMinMaxLatitudeLongitude();
    }

    public ObservableCollection<MarkerData> MarkerDataSource = new ObservableCollection<MarkerData> {
        new MarkerData {Latitude=22.572646,Longitude=88.363895},
        new MarkerData {Latitude=25.0700428,Longitude=67.2847875}
    };
}

```