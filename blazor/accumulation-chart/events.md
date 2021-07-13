---
layout: post
title: Events in Blazor Accumulation Chart Component | Syncfusion 
description: Learn about Events in Blazor Accumulation Chart component of Syncfusion, and more details.
platform: Blazor
control: Accumulation Chart
documentation: ug
---

# Events

In this section, we have provided the list of events of Accumulation Chart component which will be
triggered for appropriate accumulation chart actions.

The events should be provided to the Accumulation Chart using [`AccumulationChartEvents`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartEvents.html) component.

> From `v18.4.*`, we have added few additional following events for the Accumulation Chart component

Event Name|
-----|
[OnDataLabelRender](events/#ondatalabelrender)|
[OnLegendItemRender](events/#onlegenditemrender)|
[OnPointRender](events/#onpointrender)|

> From `v18.4.*`, some event names are different from the previous releases. The following are the event name changes from `v18.3.*` to `v18.4.*`

Event Name(`v18.3.*`) |Event Name(`v18.4.*`)
-----|-----
AfterExport |[OnExportComplete](events/#onexportcomplete)
OnPrint |[OnPrintComplete](events/#onprintcomplete)
Resized |[SizeChanged](events/#sizechanged)

> From `v18.4.*`, we remove the following previous release events from Accumulation Chart component

Event Name|
-----|
OnChartMouseClick|
OnChartMouseDown|
OnChartMouseLeave|
OnChartMouseMove|
OnChartMouseUp|
PointMoved|

## OnDataLabelRender

[`OnDataLabelRender`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartEvents.html#Syncfusion_Blazor_Charts_AccumulationChartEvents_OnDataLabelRender) event is triggers, before datalabel for series is render.

```csharp
@using Syncfusion.Blazor.Charts

<SfAccumulationChart Title="Mobile Browser Statistics">
    <AccumulationChartEvents OnDataLabelRender="DataLabelRenderEvent"></AccumulationChartEvents>
    <AccumulationChartSeriesCollection>
        <AccumulationChartSeries DataSource="@StatisticsDetails" XName="Browser" YName="Users">
            <AccumulationDataLabelSettings Visible="true"></AccumulationDataLabelSettings>
        </AccumulationChartSeries>
    </AccumulationChartSeriesCollection>
</SfAccumulationChart>

@code{
    public class Statistics
    {
        public string Browser { get; set; }
        public double Users { get; set; }
    }

    public List<Statistics> StatisticsDetails = new List<Statistics>
{
        new Statistics { Browser = "Chrome", Users = 37 },
        new Statistics { Browser = "UC Browser", Users = 17 },
        new Statistics { Browser = "iPhone", Users = 19 },
        new Statistics { Browser = "Others", Users = 4  },
        new Statistics { Browser = "Opera", Users = 11 },
        new Statistics { Browser = "Android", Users = 12 },
    };

    public void DataLabelRenderEvent(AccumulationTextRenderEventArgs args)
    {
        // Here you can customize your code
    }
}
```

## OnLegendItemRender

[`OnLegendItemRender`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartEvents.html#Syncfusion_Blazor_Charts_AccumulationChartEvents_OnLegendItemRender) event is triggers, before legend getting rendered.

```csharp
@using Syncfusion.Blazor.Charts

<SfAccumulationChart Title="Mobile Browser Statistics">
    <AccumulationChartEvents OnLegendItemRender="LegendRenderEvent"></AccumulationChartEvents>
    <AccumulationChartSeriesCollection>
        <AccumulationChartSeries DataSource="@StatisticsDetails" XName="Browser" YName="Users"
                                 Name="Browser">
        </AccumulationChartSeries>
    </AccumulationChartSeriesCollection>
    <AccumulationChartLegendSettings Visible="true"></AccumulationChartLegendSettings>
</SfAccumulationChart>

@code{
    public class Statistics
    {
        public string Browser { get; set; }
        public double Users { get; set; }
    }

    public List<Statistics> StatisticsDetails = new List<Statistics>
{
        new Statistics { Browser = "Chrome", Users = 37 },
        new Statistics { Browser = "UC Browser", Users = 17 },
        new Statistics { Browser = "iPhone", Users = 19 },
        new Statistics { Browser = "Others", Users = 4  },
        new Statistics { Browser = "Opera", Users = 11 },
        new Statistics { Browser = "Android", Users = 12 },
    };

    public void LegendRenderEvent(AccumulationLegendRenderEventArgs args)
    {
        // Here you can customize your code
    }
}
```

## OnPointRender

[`OnPointRender`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartEvents.html#Syncfusion_Blazor_Charts_AccumulationChartEvents_OnPointRender) event is triggers, before the point rendering.

```csharp
@using Syncfusion.Blazor.Charts

<SfAccumulationChart Title="Mobile Browser Statistics">
    <AccumulationChartEvents OnPointRender="PointRenderEvent"></AccumulationChartEvents>
    <AccumulationChartSeriesCollection>
        <AccumulationChartSeries DataSource="@StatisticsDetails" XName="Browser" YName="Users">
        </AccumulationChartSeries>
    </AccumulationChartSeriesCollection>
</SfAccumulationChart>

@code{
    public class Statistics
    {
        public string Browser { get; set; }
        public double Users { get; set; }
    }

    public List<Statistics> StatisticsDetails = new List<Statistics>
{
        new Statistics { Browser = "Chrome", Users = 37 },
        new Statistics { Browser = "UC Browser", Users = 17 },
        new Statistics { Browser = "iPhone", Users = 19 },
        new Statistics { Browser = "Others", Users = 4  },
        new Statistics { Browser = "Opera", Users = 11 },
        new Statistics { Browser = "Android", Users = 12 },
    };

    public void PointRenderEvent(AccumulationPointRenderEventArgs args)
    {
        // Here you can customize your code
    }
}
```

## OnExportComplete

[`OnExportComplete`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartEvents.html#Syncfusion_Blazor_Charts_AccumulationChartEvents_OnExportComplete) after the export completed.

```csharp
@using Syncfusion.Blazor.Charts

<button @onclick="Export" class="btn-success">Export</button>
<SfAccumulationChart Title="Mobile Browser Statistics" @ref="AccChart">
    <AccumulationChartEvents OnExportComplete="ExportCompleteEvent"></AccumulationChartEvents>
    <AccumulationChartSeriesCollection>
        <AccumulationChartSeries DataSource="@StatisticsDetails" XName="Browser" YName="Users">
        </AccumulationChartSeries>
    </AccumulationChartSeriesCollection>
</SfAccumulationChart>

@code{
    SfAccumulationChart AccChart;
    public class Statistics
    {
        public string Browser { get; set; }
        public double Users { get; set; }
    }

    public List<Statistics> StatisticsDetails = new List<Statistics>
    {
        new Statistics { Browser = "Chrome", Users = 37 },
        new Statistics { Browser = "UC Browser", Users = 17 },
        new Statistics { Browser = "iPhone", Users = 19 },
        new Statistics { Browser = "Others", Users = 4  },
        new Statistics { Browser = "Opera", Users = 11 },
        new Statistics { Browser = "Android", Users = 12 },
    };

    public void Export()
    {
        AccChart.Export(ExportType.JPEG,"Charts");
    }

    public void ExportCompleteEvent(ExportEventArgs args)
    {
        // Here you can customize your code
    }
}
```

## OnPrintComplete

`OnPrintComplete` event is triggers, after the print completed.

```csharp
@using Syncfusion.Blazor.Charts

<button @onclick="Print" class="btn-success">Print</button>
<SfAccumulationChart Title="Mobile Browser Statistics" @ref="AccChart">
    <AccumulationChartEvents OnPrintComplete="PrintCompleteEvent"></AccumulationChartEvents>
    <AccumulationChartSeriesCollection>
        <AccumulationChartSeries DataSource="@StatisticsDetails" XName="Browser" YName="Users">
        </AccumulationChartSeries>
    </AccumulationChartSeriesCollection>
</SfAccumulationChart>

@code{
    SfAccumulationChart AccChart;
    public class Statistics
    {
        public string Browser { get; set; }
        public double Users { get; set; }
    }

    public List<Statistics> StatisticsDetails = new List<Statistics>
    {
        new Statistics { Browser = "Chrome", Users = 37 },
        new Statistics { Browser = "UC Browser", Users = 17 },
        new Statistics { Browser = "iPhone", Users = 19 },
        new Statistics { Browser = "Others", Users = 4  },
        new Statistics { Browser = "Opera", Users = 11 },
        new Statistics { Browser = "Android", Users = 12 },
    };

    public void Print()
    {
        AccChart.Print();
    }

    public void PrintCompleteEvent()
    {
        // Here you can customize your code
    }
}
```

## SizeChanged

[`SizeChanged`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartEvents.html#Syncfusion_Blazor_Charts_AccumulationChartEvents_SizeChanged) event is triggers, after resizing of chart.

```csharp
@using Syncfusion.Blazor.Charts

<SfAccumulationChart Title="Mobile Browser Statistics">
    <AccumulationChartEvents SizeChanged="SizeChangedEvent"></AccumulationChartEvents>
    <AccumulationChartSeriesCollection>
        <AccumulationChartSeries DataSource="@StatisticsDetails" XName="Browser" YName="Users">
        </AccumulationChartSeries>
    </AccumulationChartSeriesCollection>
</SfAccumulationChart>

@code{
    public class Statistics
    {
        public string Browser { get; set; }
        public double Users { get; set; }
    }

    public List<Statistics> StatisticsDetails = new List<Statistics>
{
        new Statistics { Browser = "Chrome", Users = 37 },
        new Statistics { Browser = "UC Browser", Users = 17 },
        new Statistics { Browser = "iPhone", Users = 19 },
        new Statistics { Browser = "Others", Users = 4  },
        new Statistics { Browser = "Opera", Users = 11 },
        new Statistics { Browser = "Android", Users = 12 },
    };

    public void SizeChangedEvent(AccumulationResizeEventArgs args)
    {
        // Here you can customize your code
    }
}
```

## Loaded

`Loaded` event is triggers after accumulation chart loaded.

```csharp
@using Syncfusion.Blazor.Charts

<SfAccumulationChart Title="Mobile Browser Statistics">
    <AccumulationChartEvents Loaded="@LoadHandler"></AccumulationChartEvents>
    <AccumulationChartSeriesCollection>
        <AccumulationChartSeries DataSource="@StatisticsDetails" XName="Browser" YName="Users">
        </AccumulationChartSeries>
    </AccumulationChartSeriesCollection>
</SfAccumulationChart>

@code{
    public class Statistics
    {
        public string Browser { get; set; }
        public double Users { get; set; }
    }

    public List<Statistics> StatisticsDetails = new List<Statistics>
{
        new Statistics { Browser = "Chrome", Users = 37 },
        new Statistics { Browser = "UC Browser", Users = 17 },
        new Statistics { Browser = "iPhone", Users = 19 },
        new Statistics { Browser = "Others", Users = 4  },
        new Statistics { Browser = "Opera", Users = 11 },
        new Statistics { Browser = "Android", Users = 12 },
    };

    public void LoadHandler(AccumulationLoadedEventArgs args)
    {
        // Here you can customize your code
    }
}
```

## OnPointClick

[`OnPointClick`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartEvents.html#Syncfusion_Blazor_Charts_AccumulationChartEvents_OnPointClick) event is triggers, when the point click.

```csharp
@using Syncfusion.Blazor.Charts

<SfAccumulationChart Title="Mobile Browser Statistics">
    <AccumulationChartEvents OnPointClick="PointClick"></AccumulationChartEvents>
    <AccumulationChartSeriesCollection>
        <AccumulationChartSeries DataSource="@StatisticsDetails" XName="Browser" YName="Users">
        </AccumulationChartSeries>
    </AccumulationChartSeriesCollection>
</SfAccumulationChart>

@code{
    public class Statistics
    {
        public string Browser { get; set; }
        public double Users { get; set; }
    }

    public List<Statistics> StatisticsDetails = new List<Statistics>
   {
        new Statistics { Browser = "Chrome", Users = 37 },
        new Statistics { Browser = "UC Browser", Users = 17 },
        new Statistics { Browser = "iPhone", Users = 19 },
        new Statistics { Browser = "Others", Users = 4  },
        new Statistics { Browser = "Opera", Users = 11 },
        new Statistics { Browser = "Android", Users = 12 },
    };

    public void PointClick(AccumulationPointEventArgs args)
    {
        // Here you can customize your code
    }
}
```

## TooltipRender

[`TooltipRender`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartEvents.html#Syncfusion_Blazor_Charts_AccumulationChartEvents_TooltipRender) event is triggers, before the tooltip for series is rendered.

```csharp
@using Syncfusion.Blazor.Charts

<SfAccumulationChart Title="Mobile Browser Statistics">
    <AccumulationChartEvents TooltipRender="TooltipRenderEvent"></AccumulationChartEvents>
    <AccumulationChartSeriesCollection>
        <AccumulationChartSeries DataSource="@StatisticsDetails" XName="Browser" YName="Users">
        </AccumulationChartSeries>
    </AccumulationChartSeriesCollection>
    <AccumulationChartTooltipSettings Enable="true"></AccumulationChartTooltipSettings>
</SfAccumulationChart>

@code{
    public class Statistics
    {
        public string Browser { get; set; }
        public double Users { get; set; }
    }

    public List<Statistics> StatisticsDetails = new List<Statistics>
    {
        new Statistics { Browser = "Chrome", Users = 37 },
        new Statistics { Browser = "UC Browser", Users = 17 },
        new Statistics { Browser = "iPhone", Users = 19 },
        new Statistics { Browser = "Others", Users = 4  },
        new Statistics { Browser = "Opera", Users = 11 },
        new Statistics { Browser = "Android", Users = 12 },
    };

    public void TooltipRenderEvent(TooltipRenderEventArgs args)
    {
        // Here you can customize your code
    }
}
```