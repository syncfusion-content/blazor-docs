---
layout: post
title: Blazor Smith Chart Print and Export Examples | Syncfusion®
description: Learn how to print and export the Syncfusion Blazor Smith Chart using PrintAsync or exporting to image, SVG, and PDF formats.
platform: Blazor
control: Smith Chart
documentation: ug
---

# Blazor Smith Chart Print and Export

## Print

The rendered Smith Chart can be printed directly from the browser by calling the public method [`PrintAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfSmithChart.html#Syncfusion_Blazor_Charts_SfSmithChart_PrintAsync_Microsoft_AspNetCore_Components_ElementReference_). The optional element reference parameter can be omitted to print the Smith Chart.

```cshtml
@using Syncfusion.Blazor.Charts

<button id="print" @onclick="Print">Print</button>
<SfSmithChart @ref="smithChart">
    <SmithChartSeriesCollection>
        <SmithChartSeries Name="Transmission" DataSource='TransmissionData'
                          Reactance="Reactance" Resistance="Resistance">
            <SmithChartSeriesMarker Visible='true'>
                <SmithChartSeriesDatalabel Visible='true'></SmithChartSeriesDatalabel>
            </SmithChartSeriesMarker>
        </SmithChartSeries>
    </SmithChartSeriesCollection>
</SfSmithChart>

@code {
    private SfSmithChart smithChart;
    public class SmithChartData
    {
        public double? Resistance { get; set; }
        public double? Reactance { get; set; }
    };
    public List<SmithChartData> TransmissionData = new List<SmithChartData> {
        new SmithChartData { Resistance= 10, Reactance= 25 },
        new SmithChartData { Resistance= 6, Reactance= 4.5 },
        new SmithChartData { Resistance= 3.5, Reactance= 1.6 },
        new SmithChartData { Resistance= 2, Reactance= 1.2 },
        new SmithChartData { Resistance= 1, Reactance= 0.8 },
        new SmithChartData { Resistance= 0, Reactance= 0.2 }
    };
    private async Task Print()
    {
        await smithChart.PrintAsync();
    }
}
```

If printing or exporting does not work, verify that the Syncfusion Blazor service and required script resources are configured and that the Smith Chart has finished rendering before calling the method.

## Export

The rendered Smith Chart can be exported to **JPEG**, **PNG**, **SVG**, or **PDF** format by using the [`ExportAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfSmithChart.html#Syncfusion_Blazor_Charts_SfSmithChart_ExportAsync_Syncfusion_Blazor_Charts_ExportType_System_String_Syncfusion_PdfExport_PdfPageOrientation_) method of the Smith Chart component. Replace `ExportType.PDF` with `ExportType.JPEG`, `ExportType.PNG`, or `ExportType.SVG` to export to another format. The method accepts the following parameters:

* **type** - Specifies the export type.
* **fileName** - Specifies the file name.
* **orientation** - Specifies the page orientation. This applies only to PDF export and is optional; the default value is `null`.

```cshtml
@using Syncfusion.Blazor.Charts

<button id="export" @onclick="Export">Export</button>
<SfSmithChart @ref="smithChart">
    <SmithChartSeriesCollection>
        <SmithChartSeries Name="Transmission" DataSource='TransmissionData'
                          Reactance="Reactance" Resistance="Resistance">
            <SmithChartSeriesMarker Visible='true'>
                <SmithChartSeriesDatalabel Visible='true'></SmithChartSeriesDatalabel>
            </SmithChartSeriesMarker>
        </SmithChartSeries>
    </SmithChartSeriesCollection>
</SfSmithChart>

@code {
    private SfSmithChart smithChart;
    public class SmithChartData
    {
        public double? Resistance { get; set; }
        public double? Reactance { get; set; }
    };
    public List<SmithChartData> TransmissionData = new List<SmithChartData> {
        new SmithChartData { Resistance= 10, Reactance= 25 },
        new SmithChartData { Resistance= 6, Reactance= 4.5 },
        new SmithChartData { Resistance= 3.5, Reactance= 1.6 },
        new SmithChartData { Resistance= 2, Reactance= 1.2 },
        new SmithChartData { Resistance= 1, Reactance= 0.8 },
        new SmithChartData { Resistance= 0, Reactance= 0.2 }
    };
    private async Task Export()
    {
        await smithChart.ExportAsync(ExportType.PDF, "SmithChart", Syncfusion.PdfExport.PdfPageOrientation.Landscape);
    }
}
```