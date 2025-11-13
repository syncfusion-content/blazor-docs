---
layout: post
title: Print and export in Blazor Maps Component | Syncfusion
description: Check out and learn how to configure print and export feature in the Syncfusion Blazor Maps component.
platform: Blazor
control: Maps
documentation: ug
---

# Print and export in Blazor Maps Component

## Print

The rendered Maps component can be printed directly from the browser by calling the [PrintAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.SfMaps.html#Syncfusion_Blazor_Maps_SfMaps_PrintAsync) method. Enable printing by setting the [AllowPrint](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.SfMaps.html#Syncfusion_Blazor_Maps_SfMaps_AllowPrint) property to **true**.

```cshtml

@using Syncfusion.Blazor.Maps

<button @onclick="PrintMap">Print</button>
<SfMaps @ref="maps" AllowPrint="true">
    <MapsLayers>
        <MapsLayer ShapeData='new {dataOptions= "https://cdn.syncfusion.com/maps/map-data/world-map.json"}' TValue="string">
            <MapsLayerTooltipSettings Visible="true" ValuePath="name">
            </MapsLayerTooltipSettings>
        </MapsLayer>
    </MapsLayers>
</SfMaps>

@code {
    SfMaps maps;

    public async Task PrintMap()
    {
        // using Maps component reference call 'Print' method
        await this.maps.PrintAsync();
    }
}

```

![Printing in Blazor Maps](./images/Print/blazor-maps-printing.png)

## Export

### Image Export

Enable image export by setting the [AllowImageExport](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.SfMaps.html#Syncfusion_Blazor_Maps_SfMaps_AllowImageExport) property to **true**. Export the rendered Maps as an image using the [ExportAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.SfMaps.html#Syncfusion_Blazor_Maps_SfMaps_ExportAsync_Syncfusion_Blazor_Maps_ExportType_System_String_System_Nullable_Syncfusion_PdfExport_PdfPageOrientation__System_Boolean_) method. The method accepts the image type and file name. Supported formats:

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

    public async Task ExportMap()
    {
        await this.Maps.ExportAsync(ExportType.PNG, "Maps");
    }
}

```

![Exporting in Blazor Maps](./images/Print/blazor-maps-exporting.png)

### PDF Export

Enable PDF export by setting the [AllowPdfExport](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.SfMaps.html#Syncfusion_Blazor_Maps_SfMaps_AllowPdfExport) property to **true**. Export the rendered Maps to PDF using the [ExportAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.SfMaps.html#Syncfusion_Blazor_Maps_SfMaps_ExportAsync_Syncfusion_Blazor_Maps_ExportType_System_String_System_Nullable_Syncfusion_PdfExport_PdfPageOrientation__System_Boolean_) method. This method requires the file type, file name, and the PDF orientation. The orientation value can be set as **0** (portrait) or **1** (landscape).

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

    public async Task ExportMap()
    {
        await this.Maps.ExportAsync(ExportType.PDF, "Maps", 0);
    }
}

```

![Blazor Maps with PDF Export](./images/Print/blazor-maps-exporting.png)

### Exporting Maps as base64 string of the file

An image or PDF can be exported as a base64 string for JPEG, PNG, and PDF formats. Export the rendered Maps to a base64 string using the [ExportAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.SfMaps.html#Syncfusion_Blazor_Maps_SfMaps_ExportAsync_Syncfusion_Blazor_Maps_ExportType_System_String_System_Nullable_Syncfusion_PdfExport_PdfPageOrientation__System_Boolean_) method. Provide the image type, file name, orientation (set **null** for image export and **0** or **1** for PDF), and set **allowDownload** to **false** to return a base64 string.

```cshtml

@using Syncfusion.Blazor.Maps

<button @onclick="export">Export</button>
<SfMaps @ref="Maps" AllowPdfExport="true">
    <MapsLayers>
        <MapsLayer ShapeData='new {dataOptions= "https://cdn.syncfusion.com/maps/map-data/world-map.json"}' TValue="string">
        </MapsLayer>
    </MapsLayers>
</SfMaps>

@code {
    SfMaps Maps;
    string exportString;

    public async Task export()
    {
        exportString = await this.Maps.ExportAsync(ExportType.PDF, "Maps", 0, false);
        Console.WriteLine(exportString);
    }
}

```

N>Add the below service in Program.cs file if the size of the Maps is too large.
builder.Services.AddServerSideBlazor().AddHubOptions(o => { o.MaximumReceiveMessageSize = 102400000; });

### Export the tile Maps

Maps using tile providers such as OSM, Bing, and other providers can be exported using the [ExportAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.SfMaps.html#Syncfusion_Blazor_Maps_SfMaps_ExportAsync_Syncfusion_Blazor_Maps_ExportType_System_String_System_Nullable_Syncfusion_PdfExport_PdfPageOrientation__System_Boolean_) method. Supported export formats:

* JPEG
* PNG
* PDF

```cshtml

@using Syncfusion.Blazor.Maps

<button @onclick="ExportMap">Export</button>
<SfMaps @ref="Maps" AllowPdfExport="true" AllowImageExport="true">
    <MapsLayers>
        <MapsLayer UrlTemplate="https://tile.openstreetmap.org/level/tileX/tileY.png" TValue="string">
        </MapsLayer>
    </MapsLayers>
</SfMaps>

@code {
    SfMaps Maps;

    public async Task ExportMap()
    {
        await this.Maps.ExportAsync(ExportType.PNG, "OSM Map");
    }
}

```

![Blazor Maps with OSM Export](./images/Print/blazor-maps-osm-export.png)
