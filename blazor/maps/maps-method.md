---
layout: post
title: Maps Method in Blazor Maps Component | Syncfusion 
description: Learn about Maps Method in Blazor Maps component of Syncfusion, and more details.
platform: Blazor
control: Maps
documentation: ug
---

# Methods

## Using methods in Maps component

You can create an object for the maps component using `@ref` and call the `Print` method as demonstrated in the following example.

```csharp
@using Syncfusion.Blazor.Maps

<button @onclick="PrintMap">Print</button>
<SfMaps @ref="maps" @ref:suppressField>
    <MapsLayers>
        <MapsLayer ShapeData='new {dataOptions= "https://cdn.syncfusion.com/maps/map-data/world-map.json"}' TValue="string">
        </MapsLayer>
    </MapsLayers>
</SfMaps>

@code {
    SfMaps maps;
    void PrintMap()
    {
        maps.Print();
    }
}
```

## Available methods

### AddLayer

Adds a new layer to maps dynamically.

Return: void

|   Argument name      |   Description                                          |
|----------------------| -------------------------------------------------------|
|     layer            |    Defines the layer properties                         |

### AddMarker

Adds a new marker to maps dynamically.

Return: void

|   Argument name      |   Description                                          |
|----------------------| -------------------------------------------------------|
|     layerIndex      |    Define the layer index                              |
|     markerCollection |    Define the multiple marker settings properties in array    |

### Export

Exports the current map component to different file formats such as PNG, PDF, JPEG, and SVG.

Return: void

|   Argument name      |   Description                                       |
|----------------------| ----------------------------------------------------|
|     type             |    Defines the export types (PNG, PDF, JPEG, and SVG)  |
|     fileName        |    Defines the file name                             |
|     orientation      |    Defines the orientation (horizontal and vertical) as an optional parameter    |

### GetGeoLocation

Gets the geo location.

Return: GeoPosition - Returns geo position.

|   Argument name      |   Description                                       |
|----------------------| ----------------------------------------------------|
|     layerIndex      |    Defines the layer index                            |
|     pointerEvent    |    Specifies the pointer event                 |

### GetLocalizedLabel

Gets the localized label by locale keyword.

Return: string

|   Argument name      |   Description                                       |
|----------------------| ----------------------------------------------------|
|     key              |    Defines the locale keyword                        |

### GetTileGeoLocation

Gets the geo location in OSM/tile maps.

Return: GeoPosition - Returns geo position.

|   Argument name      |   Description                                       |
|----------------------| ----------------------------------------------------|
|     pointerEvent      |     Specifies the pointer event                  |

### PerformClick

Handles the click event for the maps.

Return: void

|   Argument name      |   Description                                       |
|----------------------| ----------------------------------------------------|
|     pointerEvent     |    Defines the pointer event                         |

### PerformDoubleClick

Handles the double-click event for the maps.

Return: void

|   Argument name      |   Description                                       |
|----------------------| ----------------------------------------------------|
|     pointerEvent     |    Defines the pointer event                         |

### PanByDirection

Pans the maps by specifying direction.

Return: void

|   Argument name      |   Description                                       |
|----------------------| ----------------------------------------------------|
|     direction        |    Defines the pan direction (Left, Right, Top, and Bottom)  |

### Print

Prints the rendered maps directly.

Return: void

### RemoveLayer

Removes the layer.

Return: void

|   Argument name      |   Description                                             |
|----------------------| ----------------------------------------------------------|
|     index            |    Specifies the name of the layer to remove              |

### ZoomByPosition

Zooms the maps by specifying the center position.

Return: void

|   Argument name      |   Description                                             |
|----------------------| ----------------------------------------------------------|
|    centerPosition   |    Specifying the latitude and longitude value             |
|    zoomFactor       |    Specifying the zoom level.                              |
