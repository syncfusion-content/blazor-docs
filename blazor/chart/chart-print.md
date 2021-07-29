---
layout: post
title: Print and Export in Blazor Charts Component | Syncfusion
description: Checkout and learn here all about Print and Export in Syncfusion Blazor Charts component and much more.
platform: Blazor
control: Chart
documentation: ug
---

# Print and Export in Blazor Charts Component

## Print

The [`Print`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfChart.html#Syncfusion_Blazor_Charts_SfChart_Print) method can be used to print a rendered chart directly from the browser.

```cshtml

@using Syncfusion.Blazor.Charts
@using Syncfusion.Blazor.Buttons

<SfChart @ref="ChartObj" Title="Inflation - Consumer Price">
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category">
    </ChartPrimaryXAxis>

    <ChartSeriesCollection>
        <ChartSeries DataSource="@ConsumerDetails" XName="X" YName="YValue" Type="ChartSeriesType.Column">
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

<SfButton Id="button" Content="Print" @onclick="Print"  IsPrimary="true" CssClass="e-flat"></SfButton>

@code{

    SfChart ChartObj;

    private void Print(MouseEventArgs args)
    {
        ChartObj.Print();
    }

    public class ChartData
    {
        public string X { get; set; }
        public double YValue { get; set; }
    }

    public List<ChartData> ConsumerDetails = new List<ChartData>
	{
        new ChartData { X= "USA", YValue= 46 },
        new ChartData { X= "GBR", YValue= 27 },
        new ChartData { X= "CHN", YValue= 26 },
        new ChartData { X= "UK", YValue= 36 },
        new ChartData { X= "AUS", YValue= 15 },
        new ChartData { X= "IND", YValue= 55 },
        new ChartData { X= "DEN", YValue= 40 },
        new ChartData { X= "MEX", YValue= 30 }
    };
}

```

![Printing the chart](images/getting-started/print.png)

## Export

Using the [`Export`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfChart.html#Syncfusion_Blazor_Charts_SfChart_Export_Syncfusion_Blazor_Charts_ExportType_System_String_System_Nullable_Syncfusion_PdfExport_PdfPageOrientation__System_Boolean_) method, the rendered chart can be exported to [`JPEG`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ExportType.html#Syncfusion_Blazor_Charts_ExportType_JPEG), [`PNG`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ExportType.html#Syncfusion_Blazor_Charts_ExportType_PNG), [`SVG`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ExportType.html#Syncfusion_Blazor_Charts_ExportType_SVG), or [`PDF`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ExportType.html#Syncfusion_Blazor_Charts_ExportType_PDF) format. The [`Export Type`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ExportType.html) specifies the image format and [`FileName`](Syncfusion_Blazor_Charts_SfChart_Export_Syncfusion_Blazor_Charts_ExportType_System_String_System_Nullable_Syncfusion_PdfExport_PdfPageOrientation__System_Boolean_) specifies the name of the exported file. Both of these parameters are required input parameters for this method.

The optional parameters for this method are,
* [`Orientation`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfChart.html#Syncfusion_Blazor_Charts_SfChart_Export_Syncfusion_Blazor_Charts_ExportType_System_String_System_Nullable_Syncfusion_PdfExport_PdfPageOrientation__System_Boolean_) - Specifies the portrait or landscape orientation in the PDF document.
* [`AllowDownload`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfChart.html#Syncfusion_Blazor_Charts_SfChart_Export_Syncfusion_Blazor_Charts_ExportType_System_String_System_Nullable_Syncfusion_PdfExport_PdfPageOrientation__System_Boolean_) - Specifies whether to download or not. If not, base64 string will be returned.

```cshtml

@using Syncfusion.Blazor.Charts
@using Syncfusion.Blazor.Buttons

<SfChart @ref="ChartObj" Title="Inflation - Consumer Price">
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category">
    </ChartPrimaryXAxis>

    <ChartSeriesCollection>
        <ChartSeries DataSource="@ConsumerDetails" XName="X" YName="YValue" Type="ChartSeriesType.Column">
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

<SfButton Id="button" Content="Export" @onclick="Export"  IsPrimary="true" CssClass="e-flat"></SfButton>

@code{

    SfChart ChartObj;

    private void Export(MouseEventArgs args)
    {
        ChartObj.Export(ExportType.PNG, "pngImage");
    }

    public class ChartData
    {
        public string X { get; set; }
        public double YValue { get; set; }
    }

    public List<ChartData> ConsumerDetails = new List<ChartData>
    {
        new ChartData { X= "USA", YValue= 46 },
        new ChartData { X= "GBR", YValue= 27 },
        new ChartData { X= "CHN", YValue= 26 },
        new ChartData { X= "UK", YValue= 36 },
        new ChartData { X= "AUS", YValue= 15 },
        new ChartData { X= "IND", YValue= 55 },
        new ChartData { X= "DEN", YValue= 40 },
        new ChartData { X= "MEX", YValue= 30 }
    };
}

```

> Refer to our [`Blazor Charts`](https://www.syncfusion.com/blazor-components/blazor-charts) feature tour page for its groundbreaking feature representations and also explore our [`Blazor Chart Example`](https://blazor.syncfusion.com/demos/chart/line?theme=bootstrap4) to know various chart types and how to represent time-dependent data, showing trends at equal intervals.

## See Also

* [Data Label](./data-labels)
* [Tooltip](./tool-tip)
* [Legend](./legend)