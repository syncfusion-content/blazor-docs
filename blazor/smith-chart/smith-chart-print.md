---
title: " Print and Export in the Blazor Smith Chart component | Syncfusion "

component: "Smith Chart"

description: "Learn here about Print and Export in Syncfusion Blazor Smith Chart (SfSmithChart) component and more."
---

# Print and Export in Blazor Smith Chart

## Print

The rendered Smith Chart can be printed directly from the browser by calling the public method [`Print`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfSmithChart.html#Syncfusion_Blazor_Charts_SfSmithChart_Print).

```csharp
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
    private void Print()
    {
        smithChart.Print();
    }
}
```

## Export

The rendered Smith Chart can be exported to **JPEG**, **PNG**, **SVG**, or **PDF** format by using the [`Export`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfSmithChart.html#Syncfusion_Blazor_Charts_SfSmithChart_Export_Syncfusion_Blazor_Charts_ExportType_System_String_System_Nullable_Syncfusion_PdfExport_PdfPageOrientation__) method in the Smith Chart. This method contains the following parameters:

* **Type** - To specify the export type. The component can be exported to **JPEG**, **PNG**, **SVG**, or **PDF** format.
* **File name** - To specify the file name to export.
* **Orientation** - To specify the orientation type. This is applicable only for PDF export type. It is an optional parameter.

```csharp
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
    private void Export()
    {
        smithChart.Export(ExportType.PDF, "SmithChart", Syncfusion.PdfExport.PdfPageOrientation.Landscape);
    }
}
```