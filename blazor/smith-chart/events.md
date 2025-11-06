---
layout: post
title: Events in Blazor Smith Chart Component | Syncfusion
description: Checkout and learn here all about events in Syncfusion Blazor Smith Chart component and much more details.
platform: Blazor
control: Smith Chart
documentation: ug
---

# Events in Blazor Smith Chart Component

This section describes about the Smith Chart component's events that will be triggered when appropriate actions are performed. The events should be provided to the Smith Chart through the **SmithChartEvents** component.

The Smith Chart component supports the following events.

* [Loaded](#loaded)
* [OnPrintComplete](#onprintcomplete)
* [OnExportComplete](#onexportcomplete)
* [AxisLabelRendering](#axislabelrendering)
* [LegendRendering](#legendrendering)
* [SeriesRender](#seriesrender)
* [TitleRendering](#titlerendering)
* [SubtitleRendering](#subtitlerendering)
* [TextRendering](#textrendering)
* [SizeChanged](#sizechanged)

## Loaded

The [Loaded](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SmithChartEvents.html#Syncfusion_Blazor_Charts_SmithChartEvents_Loaded) event triggers after the Smith Chart is rendered.

```cshtml
@using Syncfusion.Blazor.Charts

<SfSmithChart>
    <SmithChartEvents Loaded="SmithChartLoaded"></SmithChartEvents>
    <SmithChartSeriesCollection>
        <SmithChartSeries DataSource='FirstTransmissionData'
                          Reactance="Reactance" Resistance="Resistance">
        </SmithChartSeries>
    </SmithChartSeriesCollection>
</SfSmithChart>

@code {
    public class SmithChartData
    {
        public double? Resistance { get; set; }
        public double? Reactance { get; set; }
    };
    public List<SmithChartData> FirstTransmissionData = new List<SmithChartData> {
        new SmithChartData { Resistance= 10, Reactance= 25 },
        new SmithChartData { Resistance= 6, Reactance= 4.5 },
        new SmithChartData { Resistance= 3.5, Reactance= 1.6 },
        new SmithChartData { Resistance= 2, Reactance= 1.2 },
        new SmithChartData { Resistance= 1, Reactance= 0.8 },
        new SmithChartData { Resistance= 0, Reactance= 0.2 }
    };
    public void SmithChartLoaded(SmithChartLoadedEventArgs args)
    {
        // Here you can customize your code.
    }
}
```

## OnPrintComplete

The `OnPrintComplete` event triggers after the Smith Chart is printed.

```cshtml
@using Syncfusion.Blazor.Charts

<button id="print" @onclick="Print">Print</button>
<SfSmithChart @ref="SmithChart">
    <SmithChartEvents OnPrintComplete="PrintCompleted"></SmithChartEvents>
    <SmithChartSeriesCollection>
        <SmithChartSeries DataSource='FirstTransmissionData'
                          Reactance="Reactance" Resistance="Resistance">
        </SmithChartSeries>
    </SmithChartSeriesCollection>
</SfSmithChart>

@code {
    public SfSmithChart SmithChart;
    public class SmithChartData
    {
        public double? Resistance { get; set; }
        public double? Reactance { get; set; }
    };
    public List<SmithChartData> FirstTransmissionData = new List<SmithChartData> {
        new SmithChartData { Resistance= 10, Reactance= 25 },
        new SmithChartData { Resistance= 6, Reactance= 4.5 },
        new SmithChartData { Resistance= 3.5, Reactance= 1.6 },
        new SmithChartData { Resistance= 2, Reactance= 1.2 },
        new SmithChartData { Resistance= 1, Reactance= 0.8 },
        new SmithChartData { Resistance= 0, Reactance= 0.2 }
    };
    private async Task Print()
    {
        await SmithChart.PrintAsync();
    }
    public void PrintCompleted()
    {
        // Here you can customize your code.
    }
}
```

## OnExportComplete

The [OnExportComplete](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SmithChartEvents.html#Syncfusion_Blazor_Charts_SmithChartEvents_OnExportComplete) event triggers after the Smith Chart is exported.

```cshtml
@using Syncfusion.Blazor.Charts

<button id="export" @onclick="Export">Export</button>
<SfSmithChart @ref="SmithChart">
    <SmithChartEvents OnExportComplete="ExportCompleted"></SmithChartEvents>
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
    public SfSmithChart SmithChart;
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
        await SmithChart.ExportAsync(ExportType.PNG, "SmithChart");
    }
    public void ExportCompleted(SmithChartExportEventArgs args)
    {
        // Here you can customize your code.
    }
}
```

## AxisLabelRendering

Before rendering each axis label, the [AxisLabelRendering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SmithChartEvents.html#Syncfusion_Blazor_Charts_SmithChartEvents_AxisLabelRendering) event is triggered. The following arguments are present in this event:

* `Text` - Specifies the current axis label text.
* `X` - Specifies the current axis label X position.
* `Y` - Specifies the current axis label Y position.

```cshtml
@using Syncfusion.Blazor.Charts

<SfSmithChart>
    <SmithChartEvents AxisLabelRendering="AxisLabelCustomization"></SmithChartEvents>
    <SmithChartSeriesCollection>
        <SmithChartSeries DataSource='FirstTransmissionData'
                          Reactance="Reactance" Resistance="Resistance">
        </SmithChartSeries>
    </SmithChartSeriesCollection>
</SfSmithChart>

@code {
    public class SmithChartData
    {
        public double? Resistance { get; set; }
        public double? Reactance { get; set; }
    };
    public List<SmithChartData> FirstTransmissionData = new List<SmithChartData> {
        new SmithChartData { Resistance= 10, Reactance= 25 },
        new SmithChartData { Resistance= 6, Reactance= 4.5 },
        new SmithChartData { Resistance= 3.5, Reactance= 1.6 },
        new SmithChartData { Resistance= 2, Reactance= 1.2 },
        new SmithChartData { Resistance= 1, Reactance= 0.8 },
        new SmithChartData { Resistance= 0, Reactance= 0.2 }
    };
    public void AxisLabelCustomization(SmithChartAxisLabelRenderEventArgs args)
    {
        // Here you can customize your code
    }
}
```

## LegendRendering

Before rendering each legend, the [LegendRendering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SmithChartEvents.html#Syncfusion_Blazor_Charts_SmithChartEvents_LegendRendering) event is triggered. The following arguments are present in this event:

* `Text` - Specifies the current legend text.
* `Shape` - Customize the shape of the legend.
* `Fill` - Specifies the legend shape color.

```cshtml
@using Syncfusion.Blazor.Charts

<SfSmithChart>
    <SmithChartEvents LegendRendering="LegendCustomization"></SmithChartEvents>
    <SmithChartLegendSettings Visible="true"></SmithChartLegendSettings>
    <SmithChartSeriesCollection>
        <SmithChartSeries Name="Transmission" DataSource='FirstTransmissionData'
                          Reactance="Reactance" Resistance="Resistance">
        </SmithChartSeries>
    </SmithChartSeriesCollection>
</SfSmithChart>

@code {
    public class SmithChartData
    {
        public double? Resistance { get; set; }
        public double? Reactance { get; set; }
    };
    public List<SmithChartData> FirstTransmissionData = new List<SmithChartData> {
        new SmithChartData { Resistance= 10, Reactance= 25 },
        new SmithChartData { Resistance= 6, Reactance= 4.5 },
        new SmithChartData { Resistance= 3.5, Reactance= 1.6 },
        new SmithChartData { Resistance= 2, Reactance= 1.2 },
        new SmithChartData { Resistance= 1, Reactance= 0.8 },
        new SmithChartData { Resistance= 0, Reactance= 0.2 }
    };
    public void LegendCustomization(SmithChartLegendRenderEventArgs args)
    {
        // Here you can customize your code.
    }
}
```

## SeriesRender

Before rendering each series, the [SeriesRender](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SmithChartEvents.html#Syncfusion_Blazor_Charts_SmithChartEvents_SeriesRender) event is triggered. The following arguments are present in this event:

* `Text` - Specifies the current series text.
* `Index` - Specifies the current series index.
* `Fill` - Specifies the current series color.

```cshtml
@using Syncfusion.Blazor.Charts

<SfSmithChart>
    <SmithChartEvents SeriesRender="SeriesCustomization"></SmithChartEvents>
    <SmithChartSeriesCollection>
        <SmithChartSeries DataSource='FirstTransmissionData'
                          Reactance="Reactance" Resistance="Resistance">
        </SmithChartSeries>
    </SmithChartSeriesCollection>
</SfSmithChart>

@code {
    public class SmithChartData
    {
        public double? Resistance { get; set; }
        public double? Reactance { get; set; }
    };
    public List<SmithChartData> FirstTransmissionData = new List<SmithChartData> {
        new SmithChartData { Resistance= 10, Reactance= 25 },
        new SmithChartData { Resistance= 6, Reactance= 4.5 },
        new SmithChartData { Resistance= 3.5, Reactance= 1.6 },
        new SmithChartData { Resistance= 2, Reactance= 1.2 },
        new SmithChartData { Resistance= 1, Reactance= 0.8 },
        new SmithChartData { Resistance= 0, Reactance= 0.2 }
    };
    public void SeriesCustomization(SmithChartSeriesRenderEventArgs args)
    {
        // Here you can customize your code.
    }
}
```

## TitleRendering

The [TitleRendering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SmithChartEvents.html#Syncfusion_Blazor_Charts_SmithChartEvents_TitleRendering) event triggers before the title is rendered. The following arguments are present in this event:

* `Text` - Specifies the current title text.
* `X` - Specifies the current title X position.
* `Y` - Specifies the current title Y position.

```cshtml
@using Syncfusion.Blazor.Charts

<SfSmithChart>
    <SmithChartTitle Text="Smith Chart Title">
    </SmithChartTitle>
    <SmithChartEvents TitleRendering="TitleCustomization"></SmithChartEvents>
    <SmithChartSeriesCollection>
        <SmithChartSeries DataSource='FirstTransmissionData'
                          Reactance="Reactance" Resistance="Resistance">
        </SmithChartSeries>
    </SmithChartSeriesCollection>
</SfSmithChart>

@code {
    public class SmithChartData
    {
        public double? Resistance { get; set; }
        public double? Reactance { get; set; }
    };
    public List<SmithChartData> FirstTransmissionData = new List<SmithChartData> {
        new SmithChartData { Resistance= 10, Reactance= 25 },
        new SmithChartData { Resistance= 6, Reactance= 4.5 },
        new SmithChartData { Resistance= 3.5, Reactance= 1.6 },
        new SmithChartData { Resistance= 2, Reactance= 1.2 },
        new SmithChartData { Resistance= 1, Reactance= 0.8 },
        new SmithChartData { Resistance= 0, Reactance= 0.2 }
    };
    public void TitleCustomization(TitleRenderEventArgs args)
    {
        // Here you can customize your code.
    }
}
```

## SubtitleRendering

The [SubtitleRendering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SmithChartEvents.html#Syncfusion_Blazor_Charts_SmithChartEvents_SubtitleRendering) event triggers before the subtitle is rendered. The following arguments are present in this event:

* `Text` - Specifies the current subtitle text.
* `X` - Specifies the current subtitle X position.
* `Y` - Specifies the current subtitle Y position.

```cshtml
@using Syncfusion.Blazor.Charts

<SfSmithChart>
    <SmithChartTitle Text="Smith Chart Title">
        <SmithChartSubtitle Text="Smith Chart Subtitle"></SmithChartSubtitle>
    </SmithChartTitle>
    <SmithChartEvents SubtitleRendering="SubtitleCustomization"></SmithChartEvents>
    <SmithChartSeriesCollection>
        <SmithChartSeries DataSource='FirstTransmissionData'
                          Reactance="Reactance" Resistance="Resistance">
        </SmithChartSeries>
    </SmithChartSeriesCollection>
</SfSmithChart>

@code {
    public class SmithChartData
    {
        public double? Resistance { get; set; }
        public double? Reactance { get; set; }
    };
    public List<SmithChartData> FirstTransmissionData = new List<SmithChartData> {
        new SmithChartData { Resistance= 10, Reactance= 25 },
        new SmithChartData { Resistance= 6, Reactance= 4.5 },
        new SmithChartData { Resistance= 3.5, Reactance= 1.6 },
        new SmithChartData { Resistance= 2, Reactance= 1.2 },
        new SmithChartData { Resistance= 1, Reactance= 0.8 },
        new SmithChartData { Resistance= 0, Reactance= 0.2 }
    };
    public void SubtitleCustomization(SubTitleRenderEventArgs args)
    {
        // Here you can customize your code.
    }
}
```

## TextRendering

The [TextRendering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SmithChartEvents.html#Syncfusion_Blazor_Charts_SmithChartEvents_TextRendering) event triggers before the datalabel text is rendered. The following arguments are present in this event:

* `Text` - Specifies the current text of the label.
* `X` - Specifies the current datalabel X position.
* `Y` - Specifies the current datalabel Y position.
* `PointIndex` - Specifies the current point index of the datalabel.
* `SeriesIndex` - Specifies the current series index of the datalabel.
* `Border` - Specifies the current datalabel border.
* `Color` - Specifies the current datalabel color.

```cshtml
@using Syncfusion.Blazor.Charts

<SfSmithChart>
    <SmithChartEvents TextRendering="DataLabelCustomization"></SmithChartEvents>
    <SmithChartSeriesCollection>
        <SmithChartSeries DataSource='FirstTransmissionData'
                          Reactance="Reactance" Resistance="Resistance">
            <SmithChartSeriesMarker>
                <SmithChartSeriesDatalabel Visible="true"></SmithChartSeriesDatalabel>
            </SmithChartSeriesMarker>
        </SmithChartSeries>
    </SmithChartSeriesCollection>
</SfSmithChart>

@code {
    public class SmithChartData
    {
        public double? Resistance { get; set; }
        public double? Reactance { get; set; }
    };
    public List<SmithChartData> FirstTransmissionData = new List<SmithChartData> {
        new SmithChartData { Resistance= 10, Reactance= 25 },
        new SmithChartData { Resistance= 6, Reactance= 4.5 },
        new SmithChartData { Resistance= 3.5, Reactance= 1.6 },
        new SmithChartData { Resistance= 2, Reactance= 1.2 },
        new SmithChartData { Resistance= 1, Reactance= 0.8 },
        new SmithChartData { Resistance= 0, Reactance= 0.2 }
    };
    public void DataLabelCustomization(SmithChartTextRenderEventArgs args)
    {
        // Here you can customize your code.
    }
}
```

## SizeChanged

The [SizeChanged](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SmithChartEvents.html#Syncfusion_Blazor_Charts_SmithChartEvents_SizeChanged) event triggers when the browser window is resized. The following arguments are present in this event:

* `CurrentSize` - Specifies the current size of the Chart.
* `PreviousSize` - Specifies the previous size of the Chart.

```cshtml
@using Syncfusion.Blazor.Charts

<SfSmithChart>
    <SmithChartEvents SizeChanged="Resized"></SmithChartEvents>
    <SmithChartSeriesCollection>
        <SmithChartSeries DataSource='FirstTransmissionData'
                          Reactance="Reactance" Resistance="Resistance">
        </SmithChartSeries>
    </SmithChartSeriesCollection>
</SfSmithChart>

@code {
    public class SmithChartData
    {
        public double? Resistance { get; set; }
        public double? Reactance { get; set; }
    };
    public List<SmithChartData> FirstTransmissionData = new List<SmithChartData> {
        new SmithChartData { Resistance= 10, Reactance= 25 },
        new SmithChartData { Resistance= 6, Reactance= 4.5 },
        new SmithChartData { Resistance= 3.5, Reactance= 1.6 },
        new SmithChartData { Resistance= 2, Reactance= 1.2 },
        new SmithChartData { Resistance= 1, Reactance= 0.8 },
        new SmithChartData { Resistance= 0, Reactance= 0.2 }
    };
    public void Resized(SmithChartResizeEventArgs args)
    {
        // Here you can customize your code.
    }
}
```