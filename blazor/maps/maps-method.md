---
layout: post
title: Methods in Blazor Maps Component | Syncfusion
description: Checkout and learn here all about methods in Syncfusion Blazor Maps component and much more details.
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

The [Refresh](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.SfMaps.html#Syncfusion_Blazor_Maps_SfMaps_Refresh) method can be used to change the state of the component and render it again.

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

The [PanByDirectionAsync]((https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.SfMaps.html#methods)) method pans the Maps dynamically by specifying direction. The following are the arguments for this method.

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

The [ZoomByPosition](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.SfMaps.html#Syncfusion_Blazor_Maps_SfMaps_ZoomByPosition_Syncfusion_Blazor_Maps_MapsCenterPosition_System_Double_) method zooms the Maps by specifying the center position for the map. This method triggers the [OnZoom](https://blazor.syncfusion.com/documentation/maps/maps-event#onzoom) event when the zooming operation begins and the [OnZoomComplete](https://blazor.syncfusion.com/documentation/maps/maps-event#onzoomcomplete) event when the zooming operation is completed. The following are the arguments for this method.

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

The [ZoomToCoordinates](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.SfMaps.html#Syncfusion_Blazor_Maps_SfMaps_ZoomToCoordinates_System_Double_System_Double_System_Double_System_Double_) zooms the map to the center point of the provided minimum and maximum coordinates. This method triggers the [OnZoom](https://blazor.syncfusion.com/documentation/maps/maps-event#onzoom) event when the zooming operation begins and the [OnZoomComplete](https://blazor.syncfusion.com/documentation/maps/maps-event#onzoomcomplete) event when the zooming operation is completed. The following are the arguments for this method.

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

## GetMinMaxLatitudeLongitude

The [GetMinMaxLatitudeLongitude](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.SfMaps.html#Syncfusion_Blazor_Maps_SfMaps_GetMinMaxLatitudeLongitude) method returns the minimum and maximum latitude and longitude values of the Maps visible area. This method returns a [MinMaxLatitudeLongitude](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MinMaxLatitudeLongitude.html) class object that contains the Maps minimum and maximum latitude and longitude coordinates.

```cshtml
@using Syncfusion.Blazor.Maps
@using System.Collections.ObjectModel;

<button @onclick="GetMinMaxLatitudeLongitude">GetMinMaxLatitudeLongitude</button>

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

    public void GetMinMaxLatitudeLongitude()
    {
        MapBoundCoordinates = MapsRef?.GetMinMaxLatitudeLongitude();
    }

    public ObservableCollection<MarkerData> MarkerDataSource = new ObservableCollection<MarkerData> {
        new MarkerData {Latitude=22.572646,Longitude=88.363895},
        new MarkerData {Latitude=25.0700428,Longitude=67.2847875}
    };
}
```