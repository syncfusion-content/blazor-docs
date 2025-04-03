---
layout: post
title: Print and Export in Blazor Range Selector Component | Syncfusion
description: Checkout and learn here all about print and export in Syncfusion Blazor Range Selector component and more.
platform: Blazor
control: Range Selector
documentation: ug
---

# Print and Export in Blazor Range Selector Component

## Print

The rendered Range Selector can be printed directly from the browser by calling the public method `PrintAsync`.

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

The rendered Range Selector can be exported to **JPEG**, **PNG**, **SVG**, **PDF**, **XLSX**, or **CSV** format by using the `ExportAsync` method in the Range Selector. This method contains the following parameters:

* **Type** - To specify the export type. The component can be exported to **JPEG**, **PNG**, **SVG**, **PDF**, **XLSX**, or **CSV** format.
* **File name** - To specify the file name to export.
* **Orientation** - To specify the orientation type. This is applicable only for PDF export type. It is an optional parameter.

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
        await RangeObj.ExportAsync(ExportType.PDF, "pngImage", Syncfusion.PdfExport.PdfPageOrientation.Landscape);
    }
}

```
