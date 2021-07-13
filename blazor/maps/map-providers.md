# Map Providers

Maps component support map providers such as OpenStreetMap that can be added to any layers in maps.

## Open Street Map

`OpenStreetMap` is a map of the entire world. The OpenStreetMap allows you to view, edit and use geographical data in a collaborative way from any place on the Earth.

### Enable OSM

You can enable this feature by setting the `LayerType` property value as “OSM”.

```csharp
<SfMaps>
    <MapsLayers>
        <MapsLayer LayerType='@ShapeLayerType.OSM' UrlTemplate='http://a.tile.openstreetmap.org/level/tileX/tileY.png' TValue="string" />
    </MapsLayers>
</SfMaps>
```

![Open street map](./images/MapProviders/OSM.png)

#### URL Template

The `UrlTemplate` property determines the format of tile map. You can specify the template for the tile layer.

## Bing Map

Bing Map is a key feature in accessing the external geospatial imagery services for deep-zoom satellite view.

### Enable Bing Maps

You can enable this feature by defining the `LayerType` as “bing”. To get the type of bing map as aerial, aerialwithlabel and road.

```csharp
<SfMaps>
    <MapsLayers>
        <MapsLayer LayerType='ShapeLayerType.Bing' BingMapType="AerialWithLabel" TValue="string"
        Key="// …bingMapKey" />
    </MapsLayers>
</SfMaps>
```

#### Key

The bing Map key is provided as input to this key property. The Bing Map key can be obtained from [http://www.microsoft.com/maps/create-a-bing-maps-key.aspx](http://www.microsoft.com/maps/create-a-bing-maps-key.aspx).
