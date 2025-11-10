---
layout: post
title: Print and Export in Blazor TreeMap Component | Syncfusion
description: Checkout and learn here all about Print and Export in Syncfusion Blazor TreeMap component and much more.
platform: Blazor
control: TreeMap
documentation: ug
---

# Print and Export in Blazor TreeMap Component

## Print

The `PrintAsync` method can be used to print a rendered TreeMap directly from the browser and it can be enabled by setting the [AllowPrint](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeMap.SfTreeMap-1.html#Syncfusion_Blazor_TreeMap_SfTreeMap_1_AllowPrint) property to **true**.

```cshtml
@using Syncfusion.Blazor.TreeMap;

<button @onclick="PrintMap">Print Treemap</button>
<SfTreeMap @ref="Treemap" DataSource="@GrowthReport" WeightValuePath="GDP" TValue="Country" AllowPrint="true">
    <TreeMapLeafItemSettings LabelPath="Name" Fill="lightgray">
    </TreeMapLeafItemSettings>
</SfTreeMap>

@code {
    public SfTreeMap<Country> Treemap { get; set; }
    public async Task PrintMap()
    {
        await Treemap.PrintAsync();
    }
    public class Country
    {
        public string Name { get; set; }
        public double GDP { get; set; }
    }
    public List<Country> GrowthReport = new List<Country> {
        new Country  {Name="United States", GDP=17946 },
        new Country  {Name="China", GDP=10866 },
        new Country  {Name="Japan", GDP=4123 },
    };
}
```

![Printing in Blazor TreeMap](./images/Print/blazor-treemap-printing.png)

## Export

### Image Export

Export functionality can be enabled by setting the [AllowImageExport](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeMap.SfTreeMap-1.html#Syncfusion_Blazor_TreeMap_SfTreeMap_1_AllowImageExport) property to **true**. The rendered TreeMap can be exported as an image with help of `ExportAsync` method and the method requires two parameters: image type and file name. The orientation setting is optional.

The TreeMap can be exported as an image in the following formats.

* [JPEG](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeMap.ExportType.html#Syncfusion_Blazor_TreeMap_ExportType_JPEG)
* [PNG](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeMap.ExportType.html#Syncfusion_Blazor_TreeMap_ExportType_PNG)
* [SVG](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeMap.ExportType.html#Syncfusion_Blazor_TreeMap_ExportType_SVG)

The following code example shows how to export the TreeMap in [PNG](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeMap.ExportType.html#Syncfusion_Blazor_TreeMap_ExportType_PNG) format.

```cshtml
@using Syncfusion.Blazor.TreeMap;

<button @onclick="ExportMap">Export Treemap</button>
<SfTreeMap @ref="Treemap" DataSource="@GrowthReport" WeightValuePath="GDP" TValue="Country" AllowImageExport="true" AllowPdfExport="true">
    <TreeMapLeafItemSettings LabelPath="Name" Fill="lightgray">
    </TreeMapLeafItemSettings>
</SfTreeMap>

@code {
    public SfTreeMap<Country> Treemap { get; set; }
    public async Task ExportMap()
    {
        await Treemap.ExportAsync(ExportType.PNG, "Export", Syncfusion.PdfExport.PdfPageOrientation.Portrait, true);
    }
}
```

N> Refer to the [code block](#print) to know about the property value of the **GrowthReport**.

### PDF Export

[PDF](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeMap.ExportType.html#Syncfusion_Blazor_TreeMap_ExportType_PDF) export functionality can be enabled by setting the [AllowPdfExport](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeMap.SfTreeMap-1.html#Syncfusion_Blazor_TreeMap_SfTreeMap_1_AllowPdfExport) property to **true**. The rendered TreeMap can be exported as [PDF](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeMap.ExportType.html#Syncfusion_Blazor_TreeMap_ExportType_PDF) with the help of `ExportAsync` method and the export method requires two parameters: file type and file name. The orientation setting is optional.

```cshtml
@using Syncfusion.Blazor.TreeMap;

<button @onclick="ExportMap">Export Treemap</button>
<SfTreeMap @ref="Treemap" DataSource="@GrowthReport" WeightValuePath="GDP" TValue="Country" AllowImageExport="true" AllowPdfExport="true">
    <TreeMapLeafItemSettings LabelPath="Name" Fill="lightgray">
    </TreeMapLeafItemSettings>
</SfTreeMap>

@code {
    public SfTreeMap<Country> Treemap { get; set; }
    public async Task ExportMap()
    {
        await Treemap.ExportAsync(ExportType.PDF, "Export", Syncfusion.PdfExport.PdfPageOrientation.Portrait);
    }
}
```

N> Refer to the [code block](#print) to know about the property value of the **GrowthReport**.