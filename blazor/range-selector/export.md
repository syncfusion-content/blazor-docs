---
layout: post
title: Blazor Range Selector Print and Export Guide | Syncfusion®
description: Learn how to print and export Syncfusion Blazor Range Selector using PrintAsync, or export to image, SVG, and PDF formats.
platform: Blazor
control: Range Selector
documentation: ug
---

# Blazor Range Selector Print and Export

The Blazor Range Selector can be printed directly from the browser and exported to image, SVG, PDF, and data (XLSX/CSV) formats through the public `PrintAsync` and `ExportAsync` methods of the component.

## Print

The rendered Range Selector can be printed directly from the browser by calling the public [PrintAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfRangeNavigator.html) method. It optionally accepts an `ElementReference`; when omitted, the current Range Selector is printed.

The [OnPrintCompleted](./events#onprintcompleted) event is triggered after the print operation completes.

```cshtml

@using Syncfusion.Blazor.Charts
@using Syncfusion.Blazor.Buttons

<SfRangeNavigator @ref="RangeObj" Value="@Value" ValueType="RangeValueType.DateTime">
    <RangeNavigatorSeriesCollection>
        <RangeNavigatorSeries DataSource="@StockInfo" XName="Date" Type="RangeNavigatorType.StepLine" YName="Close">
        </RangeNavigatorSeries>
    </RangeNavigatorSeriesCollection>
</SfRangeNavigator>

<SfButton Id="button" Content="Print" @onclick="@Click" IsPrimary="true" CssClass="e-flat">
</SfButton>

@code {
    public SfRangeNavigator RangeObj;

    public class StockDetails
    {
        public DateTime Date { get; set; }
        public double Close { get; set; }
    }

    public DateTime[] Value = new DateTime[] { new DateTime(2006, 01, 01), new DateTime(2008, 01, 01) };

    public List<StockDetails> StockInfo = new List<StockDetails> {
        new StockDetails { Date = new DateTime(2005, 01, 01), Close = 21 },
        new StockDetails { Date = new DateTime(2006, 01, 01), Close = 24  },
        new StockDetails { Date = new DateTime(2007, 01, 01), Close = 36  },
        new StockDetails { Date = new DateTime(2008, 01, 01), Close = 38  },
        new StockDetails { Date = new DateTime(2009, 01, 01), Close = 54 },
        new StockDetails { Date = new DateTime(2010, 01, 01), Close = 57  },
        new StockDetails { Date = new DateTime(2011, 01, 01), Close = 70  }
    };

    public async Task Click(MouseEventArgs args)
    {
        await RangeObj.PrintAsync();
    }
}

```

## Export

The rendered Range Selector can be exported to [JPEG](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ExportType.html#Syncfusion_Blazor_Charts_ExportType_JPEG), [PNG](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ExportType.html#Syncfusion_Blazor_Charts_ExportType_PNG), [SVG](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ExportType.html#Syncfusion_Blazor_Charts_ExportType_SVG), [PDF](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ExportType.html#Syncfusion_Blazor_Charts_ExportType_PDF), [XLSX](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ExportType.html#Syncfusion_Blazor_Charts_ExportType_XLSX), or [CSV](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ExportType.html#Syncfusion_Blazor_Charts_ExportType_CSV) format by using the `ExportAsync` method of the Range Selector. This method accepts the following parameters:

* `Type` - Specifies the export format as an [ExportType](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ExportType.html) value. Required.
* `FileName` - Specifies the name of the exported file. Required.
* `Orientation` - Specifies the `PdfPageOrientation` (`Portrait` or `Landscape`). Applicable only for PDF export. Optional.
* `AllowDownload` - When `true` (default), the browser download prompt is shown; when `false`, the exported content is returned as a `DataUrl` string. Optional.

```cshtml

@using Syncfusion.Blazor.Charts
@using Syncfusion.Blazor.Buttons

<SfRangeNavigator @ref="RangeObj" Value="@Value" ValueType="RangeValueType.DateTime">
    <RangeNavigatorSeriesCollection>
        <RangeNavigatorSeries DataSource="@StockInfo" XName="Date" Type="RangeNavigatorType.StepLine" YName="Close">
        </RangeNavigatorSeries>
    </RangeNavigatorSeriesCollection>
</SfRangeNavigator>

<SfButton Id="button" Content="Export" @onclick="@Click" IsPrimary="true" CssClass="e-flat">
</SfButton>

@code {
    public SfRangeNavigator RangeObj;

    public class StockDetails
    {
        public DateTime Date { get; set; }
        public double Close { get; set; }
    }

    public DateTime[] Value = new DateTime[] { new DateTime(2006, 01, 01), new DateTime(2008, 01, 01) };

    public List<StockDetails> StockInfo = new List<StockDetails> {
        new StockDetails { Date = new DateTime(2005, 01, 01), Close = 21 },
        new StockDetails { Date = new DateTime(2006, 01, 01), Close = 24  },
        new StockDetails { Date = new DateTime(2007, 01, 01), Close = 36  },
        new StockDetails { Date = new DateTime(2008, 01, 01), Close = 38  },
        new StockDetails { Date = new DateTime(2009, 01, 01), Close = 54 },
        new StockDetails { Date = new DateTime(2010, 01, 01), Close = 57  },
        new StockDetails { Date = new DateTime(2011, 01, 01), Close = 70  }
    };

    public async Task Click(MouseEventArgs args)
    {
        await RangeObj.ExportAsync(ExportType.PDF, "RangeSelector", Syncfusion.PdfExport.PdfPageOrientation.Landscape);
    }
}

```

## See also

* [Events](./events)
* [Period Selector](./period-selector)
