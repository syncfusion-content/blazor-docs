---
layout: post
title: Print and export in Blazor Maps Component | Syncfusion
description: Checkout and learn here all about Print and export in Syncfusion Blazor Maps component and much more.
platform: Blazor
control: Maps
documentation: ug
---

# Print and export in Blazor Maps Component

## Print

To use the print functionality, we should set the [AllowPrint](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.SfMaps.html#Syncfusion_Blazor_Maps_SfMaps_AllowPrint) property to **true**. The rendered map can be printed directly from the browser by calling the method [print](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.SfMaps.html#Syncfusion_Blazor_Maps_SfMaps_Print_System_Object_). You can get the Maps component object using `@ref="maps"`.

```cshtml
@using Syncfusion.Blazor.Maps

<button @onclick="PrintMap">Print</button>
@*  To create reference  *@
<SfMaps @ref="maps" AllowPrint="true">
    <MapsLayers>
        <MapsLayer ShapeData='new {dataOptions= "https://cdn.syncfusion.com/maps/map-data/world-map.json"}' TValue="string">
            <MapsLayerTooltipSettings Visible="true"
                                  ValuePath="name">
            </MapsLayerTooltipSettings>
        </MapsLayer>
    </MapsLayers>
</SfMaps>

@code {
    SfMaps maps;
    void PrintMap()
    {
        // using Maps component reference call 'Print' method
        this.maps.Print();
    }
}
```

![Maps with print option](./images/Print/print.png)

## Export

### Image Export

To use the image export functionality, we should set the [AllowImageExport](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.SfMaps.html#Syncfusion_Blazor_Maps_SfMaps_AllowImageExport) property to **true**. The rendered map can be exported as an image using the [export](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.SfMaps.html#Syncfusion_Blazor_Maps_SfMaps_Export_Syncfusion_Blazor_Maps_ExportType_System_String_System_Object_System_Nullable_System_Boolean__) method. The method requires two parameters: image type and file name. The map can be exported as an image in the following formats.

* JPEG
* PNG
* SVG

```cshtml
@using Syncfusion.Blazor.Maps

<button @onclick="ExportMap">Export</button>
<SfMaps @ref="Maps" AllowImageExport="true">
    <MapsLayers>
        <MapsLayer ShapeData='new {dataOptions= "https://cdn.syncfusion.com/maps/map-data/world-map.json"}' TValue="string">
        </MapsLayer>
    </MapsLayers>
</SfMaps>

@code {
    SfMaps Maps;
    void ExportMap()
    {
        this.Maps.Export(ExportType.PNG, "Maps");
    }
}
```

![Maps with export option](./images/Print/export.png)

### PDF Export

To use the PDF export functionality, we should set the [AllowPdfExport](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.SfMaps.html#Syncfusion_Blazor_Maps_SfMaps_AllowPdfExport) property to **true**. The rendered map can be exported as PDF using the [export](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.SfMaps.html#Syncfusion_Blazor_Maps_SfMaps_Export_Syncfusion_Blazor_Maps_ExportType_System_String_System_Object_System_Nullable_System_Boolean__) method. The [export](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.SfMaps.html#Syncfusion_Blazor_Maps_SfMaps_Export_Syncfusion_Blazor_Maps_ExportType_System_String_System_Object_System_Nullable_System_Boolean__) method requires three parameters: file type, file name and orientation of the PDF document. The orientation setting is optional and "0" indicates portrait and "1" indicates landscape.

```cshtml
@using Syncfusion.Blazor.Maps

<button @onclick="ExportMap">Export</button>
<SfMaps @ref="Maps" AllowPdfExport="true">
    <MapsLayers>
        <MapsLayer ShapeData='new {dataOptions= "https://cdn.syncfusion.com/maps/map-data/world-map.json"}' TValue="string">
        </MapsLayer>
    </MapsLayers>
</SfMaps>

@code {
    SfMaps Maps;
    void ExportMap()
    {
        this.Maps.Export(ExportType.PDF, "Maps", 0);
    }
}
```

![Maps with export option](./images/Print/export.png)

### Export the tile maps

The rendered map with providers such as OSM, Bing and Google static maps can be exported using the [Export](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.SfMaps.html#Syncfusion_Blazor_Maps_SfMaps_Export_Syncfusion_Blazor_Maps_ExportType_System_String_System_Object_System_Nullable_System_Boolean__) method. It supports the following export formats.

* JPEG
* PNG
* PDF

```cshtml
@using Syncfusion.Blazor.Maps

<button @onclick="ExportMap">Export</button>
<SfMaps @ref="Maps" AllowPdfExport="true" AllowImageExport="true">
    <MapsLayers>
        <MapsLayer LayerType="ShapeLayerType.OSM" TValue="string">
        </MapsLayer>
    </MapsLayers>
</SfMaps>

@code {
    SfMaps Maps;
    void ExportMap()
    {
        this.Maps.Export(ExportType.PNG, "OSM Map");
    }
}
```

![Maps with export option](./images/Print/osm-export.png)