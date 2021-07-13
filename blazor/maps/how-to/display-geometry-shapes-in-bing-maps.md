# Display geometry shapes in Bing Maps

Usually, the Bing Maps displays the maps in satellite view, in which you cannot make changes as you need. To overcome this, add maps shape as sub layer over the Bing Maps and customize it. The following steps explain how to add geometry shapes as sublayer in Bing Maps.

<b>Step 1</b>

To render Bing Maps in the Maps component, set `LayerType` as Bing and provide the Bing Maps key.

```csharp
@using Syncfusion.Blazor.Maps

<SfMaps>
    <MapsLayers>
        <MapsLayer LayerType="ShapeLayerType.Bing" TValue="string"
                   Key="">
        </MapsLayer>
    </MapsLayers>
</SfMaps>
```

> Specify the Bing Maps key in the `Key` property.

![Bing Maps](../images/bingmap.PNG)

<b>Step 2</b>

Add geometry shape in the Bing Maps using sublayer concept. To add geometry shape, import shape data, set type as subLayer, and assign your shape data to the ShapeData API.

```csharp
@using Syncfusion.Blazor.Maps

<SfMaps>
    <MapsLayers>
        <MapsLayer LayerType="ShapeLayerType.Bing" TValue="string"
                   Key="">
        </MapsLayer>
        @* To add geometry shape as sublayer *@
        <MapsLayer ShapeData='new {dataOptions = "https://cdn.syncfusion.com/maps/map-data/africa.json"}'
                   Type="Syncfusion.Blazor.Maps.Type.SubLayer" TValue="string">
            <MapsShapeSettings Fill="blue"></MapsShapeSettings>
        </MapsLayer>
    </MapsLayers>
</SfMaps>

```

> Specify the Bing Maps key in the `Key` property.

The above code renders Africa continent as sublayer in the Bing Maps.

![Bing Map with Sublayer](../images/BingMapSublayer.PNG)