---
layout: post
title: Methods in Blazor TreeMap Component | Syncfusion
description: Checkout and learn here all about Methods in Syncfusion Blazor TreeMap component and much more details.
platform: Blazor
control: TreeMap
documentation: ug
---

# Methods in Blazor TreeMap Component

Create an object for the TreeMap component using `@ref` property and call the desired TreeMap method.

## Print

To print the rendered TreeMap component by setting the [AllowPrint](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeMap.SfTreeMap-1.html#Syncfusion_Blazor_TreeMap_SfTreeMap_1_AllowPrint) property to **true** and using the `PrintAsync` method.

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
        new Country  {Name="United States", GDP=17946 },
        new Country  {Name="China", GDP=10866 },
        new Country  {Name="Japan", GDP=4123 },
    };
}
```

## Export

Using `ExportAsync` method the current TreeMap component will be exported to different file formats such as [PNG](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeMap.ExportType.html#Syncfusion_Blazor_TreeMap_ExportType_PNG), [PDF](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeMap.ExportType.html#Syncfusion_Blazor_TreeMap_ExportType_PDF), [JPEG](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeMap.ExportType.html#Syncfusion_Blazor_TreeMap_ExportType_JPEG) and [SVG](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeMap.ExportType.html#Syncfusion_Blazor_TreeMap_ExportType_SVG).

The [AllowImageExport](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeMap.SfTreeMap-1.html#Syncfusion_Blazor_TreeMap_SfTreeMap_1_AllowImageExport) and [AllowPdfExport](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeMap.SfTreeMap-1.html#Syncfusion_Blazor_TreeMap_SfTreeMap_1_AllowPdfExport) property represents to allow the file to be downloaded in an image and pdf type export.

|   Arguments      |   Description                                       |
|----------------------| ----------------------------------------------------|
|     type             |    Defines the export type such as **PNG**, **PDF**, **JPEG** and **SVG**.   |
|     fileName        |    Defines the file name.                             |
|     orientation      |    Defines the orientation such as **horizontal** and **vertical**.     |
| allowDownload | Defines the export file to be downloaded or not. |

N> Export method returns the **Base64** string, if **allowDownload** argument is set to **false**. To download the file, paste the returned **Base64** string in the browser URL bar and press the enter button.

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
        new Country  {Name="United States", GDP=17946 },
        new Country  {Name="China", GDP=10866 },
        new Country  {Name="Japan", GDP=4123 },
    };
}
```

## Refresh

The `RefreshAsync` method helps to refresh the TreeMap component.

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
        new Country  {Name="United States", GDP=17946 },
        new Country  {Name="China", GDP=10866 },
        new Country  {Name="Japan", GDP=4123 },
    };
}
```

## SelectItem

The `SelectItemAsync` method can be used to select or unselect the TreeMap item programmatically.

|   Arguments      |   Description                                       |
|----------------------| ----------------------------------------------------|
| levelOrder | Defines the level order name for the treemap item. |
| isSelected | Defines whether it has to select or unselect. |

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
        new Country  {Name="United States", GDP=17946 },
        new Country  {Name="China", GDP=10866 },
        new Country  {Name="Japan", GDP=4123 },
    };
}
```