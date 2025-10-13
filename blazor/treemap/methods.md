---
layout: post
title: Methods in Blazor TreeMap Component | Syncfusion
description: Check out and learn how to make use of the available methods in the Syncfusion Blazor TreeMap component.
platform: Blazor
control: TreeMap
documentation: ug
---

# Methods in Blazor TreeMap Component

Create a component reference with the `@ref` attribute and invoke TreeMap methods as needed.

## Print

Print the rendered TreeMap by enabling the [AllowPrint](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeMap.SfTreeMap-1.html#Syncfusion_Blazor_TreeMap_SfTreeMap_1_AllowPrint) property and calling the `PrintAsync` method.

```cshtml

@using Syncfusion.Blazor.TreeMap;

<button @onclick="PrintMap">Print Treemap</button>
<SfTreeMap @ref="Treemap" DataSource="@growthReport" WeightValuePath="GDP" TValue="Country" AllowPrint="true">
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

    public List<Country> growthReport = new List<Country> {
        new Country {Name = "United States", GDP = 17946 },
        new Country {Name = "China", GDP = 10866 },
        new Country {Name = "Japan", GDP = 4123 }
    };
}

```

## Export

Use the `ExportAsync` method to export the current TreeMap to [PNG](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeMap.ExportType.html#Syncfusion_Blazor_TreeMap_ExportType_PNG), [PDF](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeMap.ExportType.html#Syncfusion_Blazor_TreeMap_ExportType_PDF), [JPEG](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeMap.ExportType.html#Syncfusion_Blazor_TreeMap_ExportType_JPEG), or [SVG](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeMap.ExportType.html#Syncfusion_Blazor_TreeMap_ExportType_SVG).

The [AllowImageExport](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeMap.SfTreeMap-1.html#Syncfusion_Blazor_TreeMap_SfTreeMap_1_AllowImageExport) and [AllowPdfExport](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeMap.SfTreeMap-1.html#Syncfusion_Blazor_TreeMap_SfTreeMap_1_AllowPdfExport) properties enable image and PDF export respectively.

| Arguments   | Description                                                                 |
|-------------|-----------------------------------------------------------------------------|
| type        | Defines the export type such as **PNG**, **PDF**, **JPEG**, and **SVG**.    |
| fileName    | Defines the file name.                                                      |
| orientation | Defines the page orientation such as **Portrait** and **Landscape**.        |
| allowDownload | Defines whether the exported file is downloaded.                          |

N> The export method returns a **Base64** string when **allowDownload** is set to **false**. To download the file, paste the returned **Base64** string into the browser address bar and press Enter.

```cshtml

@using Syncfusion.Blazor.TreeMap;

<button @onclick="ExportMap">Export Treemap</button>
<SfTreeMap @ref="Treemap" DataSource="@growthReport" WeightValuePath="GDP" TValue="Country" AllowImageExport="true" AllowPdfExport="true">
    <TreeMapLeafItemSettings LabelPath="Name" Fill="lightgray">
    </TreeMapLeafItemSettings>
</SfTreeMap>

@code {
    public SfTreeMap<Country> Treemap { get; set; }

    public async Task ExportMap()
    {
        await Treemap.ExportAsync(ExportType.SVG, "Export", Syncfusion.PdfExport.PdfPageOrientation.Portrait, true);
    }

    public class Country
    {
        public string Name { get; set; }
        public double GDP { get; set; }
    }

    private List<Country> growthReport = new List<Country> {
        new Country {Name = "United States", GDP = 17946 },
        new Country {Name = "China", GDP = 10866 },
        new Country {Name = "Japan", GDP = 4123 }
    };
}

```

## Refresh

The `RefreshAsync` method refreshes the TreeMap component.

```cshtml
@using Syncfusion.Blazor.TreeMap;

<button @onclick="RefreshCall">Refresh</button>
<SfTreeMap @ref="Treemap" DataSource="@growthReport" WeightValuePath="GDP" TValue="Country" AllowImageExport="true" AllowPdfExport="true">
</SfTreeMap>

@code {
    public SfTreeMap<Country> Treemap { get; set; }

    public async Task RefreshCall()
    {
        await Treemap.RefreshAsync();
    }

    public class Country
    {
        public string Name { get; set; }
        public double GDP { get; set; }
    }

    private List<Country> growthReport = new List<Country> {
        new Country {Name = "United States", GDP = 17946 },
        new Country {Name = "China", GDP = 10866 },
        new Country {Name = "Japan", GDP = 4123 }
    };
}

```

## SelectItem

The `SelectItemAsync` method selects or clears a TreeMap item programmatically.

| Arguments  | Description                                               |
|------------|-----------------------------------------------------------|
| levelOrder | Defines the level order name for the TreeMap item.        |
| isSelected | Specifies whether to select or clear the item.            |

```cshtml

@using Syncfusion.Blazor.TreeMap;

<button @onclick="SelectCall">Select</button>
<SfTreeMap @ref="Treemap" DataSource="@growthReport" WeightValuePath="GDP" TValue="Country">
    <TreeMapLeafItemSettings LabelPath="Name" Fill="lightgray">
    </TreeMapLeafItemSettings>
    <TreeMapSelectionSettings Enable="true" Fill="#a4d1f2">
    </TreeMapSelectionSettings>
</SfTreeMap>

@code {
    public SfTreeMap<Country> Treemap { get; set; }

    public async Task SelectCall()
    {
        await Treemap.SelectItemAsync(new string[] { "United States" }, true);
    }

    public class Country
    {
        public string Name { get; set; }
        public double GDP { get; set; }
    }

    private List<Country> growthReport = new List<Country> {
        new Country {Name = "United States", GDP = 17946 },
        new Country {Name = "China", GDP = 10866 },
        new Country {Name = "Japan", GDP = 4123 }
    };
}

```