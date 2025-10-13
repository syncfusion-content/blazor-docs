---
layout: post
title: Print and Export in Blazor Range Selector Component | Syncfusion
description: Check out and learn how to utilize the print and export functionality in Syncfusion Blazor Range Selector component.
platform: Blazor
control: Range Selector
documentation: ug
---

# Print and Export in Blazor Range Selector Component

## Print

Print the rendered Range Selector directly from the browser by calling the public method `PrintAsync`.

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

Export the rendered Range Selector to **JPEG**, **PNG**, **SVG**, **PDF**, **XLSX**, or **CSV** formats using the `ExportAsync` method. This method accepts the following parameters:

* **Type** – Specifies the export type (JPEG, PNG, SVG, PDF, XLSX, or CSV).
* **File name** – Specifies the file name for export.
* **Orientation** – Specifies the orientation type (applicable only for PDF export; optional).

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
        new StockDetails { Date = new DateTime(2006, 01, 01), Close = 24 },
        new StockDetails { Date = new DateTime(2007, 01, 01), Close = 36 },
        new StockDetails { Date = new DateTime(2008, 01, 01), Close = 38 },
        new StockDetails { Date = new DateTime(2009, 01, 01), Close = 54 },
        new StockDetails { Date = new DateTime(2010, 01, 01), Close = 57 },
        new StockDetails { Date = new DateTime(2011, 01, 01), Close = 70 }
    };

    public async Task Click(MouseEventArgs args)
    {
        await RangeObj.ExportAsync(ExportType.PDF, "pngImage", Syncfusion.PdfExport.PdfPageOrientation.Landscape);
    }
}

```
