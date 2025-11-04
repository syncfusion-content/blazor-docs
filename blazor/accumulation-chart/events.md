---
layout: post
title: Events in Blazor Accumulation Chart Component | Syncfusion
description: Checkout and learn here all about Events in Syncfusion Blazor Accumulation Chart component and more.
platform: Blazor
control: Accumulation Chart
documentation: ug
---

# Events in Blazor Accumulation Chart Component

In this section, the list of events of Accumulation Chart component is provided which will be triggered for appropriate accumulation chart actions.

The events should be provided to the Accumulation Chart using [AccumulationChartEvents](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartEvents.html) component.

N> From `v18.4.*`, a few additional following events are added to the Accumulation Chart component.

Event Name|
-----|
[OnDataLabelRender](events#ondatalabelrender)|
[OnLegendItemRender](events#onlegenditemrender)|
[OnPointRender](events#onpointrender)|

N> From `v18.4.*`, some event names are different from the previous releases. The following are the event name changes from `v18.3.*` to `v18.4.*`

Event Name(`v18.3.*`) |Event Name(`v18.4.*`)
-----|-----
AfterExport |[OnExportComplete](events#onexportcomplete)
OnPrint |[OnPrintComplete](events#onprintcomplete)
Resized |[SizeChanged](events#sizechanged)

N> From `v18.4.*`, the following previous release events are removed from the Accumulation Chart component.

Event Name|
-----|
OnChartMouseClick|
OnChartMouseDown|
OnChartMouseLeave|
OnChartMouseMove|
OnChartMouseUp|
PointMoved|

## OnDataLabelRender

[OnDataLabelRender](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartEvents.html#Syncfusion_Blazor_Charts_AccumulationChartEvents_OnDataLabelRender) event triggers, before datalabel for series is rendered.

### Arguments

The following properties are available in the [AccumulationTextRenderEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationTextRenderEventArgs.html).

* [Color](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationTextRenderEventArgs.html#Syncfusion_Blazor_Charts_AccumulationTextRenderEventArgs_Color) – Specifies the color for the data label text.
* [Border](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationTextRenderEventArgs.html#Syncfusion_Blazor_Charts_AccumulationTextRenderEventArgs_Border) – Specifies the color and the width of the data label border.
* [Font](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationTextRenderEventArgs.html#Syncfusion_Blazor_Charts_AccumulationTextRenderEventArgs_Font) – Specifies the font information of the data label.
* [Text](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationTextRenderEventArgs.html#Syncfusion_Blazor_Charts_AccumulationTextRenderEventArgs_Text) – Specifies the text to be displayed in the data label.

```cshtml 
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
        // Here, you can customize your code.
    }
}
```

## OnLegendItemRender

[OnLegendItemRender](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartEvents.html#Syncfusion_Blazor_Charts_AccumulationChartEvents_OnLegendItemRender) event triggers, before legend getting rendered.

### Arguments

The following properties are available in the [AccumulationLegendRenderEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationLegendRenderEventArgs.html).

* [Fill](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationLegendRenderEventArgs.html#Syncfusion_Blazor_Charts_AccumulationLegendRenderEventArgs_Fill) – Specifies the fill color of the legend item's icon.
* [Shape](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationLegendRenderEventArgs.html#Syncfusion_Blazor_Charts_AccumulationLegendRenderEventArgs_Shape) – Specifies the shape of the legend item's icon.
* [Text](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationLegendRenderEventArgs.html#Syncfusion_Blazor_Charts_AccumulationLegendRenderEventArgs_Text) – Specifies the text to be displayed in the legend item.

```cshtml 
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
        // Here, you can customize your code.
    }
}
```

## OnPointRender

[OnPointRender](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartEvents.html#Syncfusion_Blazor_Charts_AccumulationChartEvents_OnPointRender) event triggers before each point for the accumulation chart is rendered.

### Arguments

The following properties are available in the [AccumulationPointRenderEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationPointRenderEventArgs.html).

* [Border](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationPointRenderEventArgs.html#Syncfusion_Blazor_Charts_AccumulationPointRenderEventArgs_Border) – Specifies the color and the width of the point border.
* [Fill](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationPointRenderEventArgs.html#Syncfusion_Blazor_Charts_AccumulationPointRenderEventArgs_Fill) – Specifies the fill color of the point.

```cshtml 
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
        // Here, you can customize your code.
    }
}
```

## OnExportComplete

[OnExportComplete](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartEvents.html#Syncfusion_Blazor_Charts_AccumulationChartEvents_OnExportComplete) event triggers after exporting the accumulation chart.

### Arguments

The following field is available in the [ExportEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ExportEventArgs.html).

* [DataUrl](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ExportEventArgs.html#Syncfusion_Blazor_Charts_ExportEventArgs_DataUrl) – Specifies the DataUrl of the exported file.

```cshtml 
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
        // Here, you can customize your code.
    }
}
```

## OnPrintComplete

`OnPrintComplete` event triggers after printing the accumulation chart.

```cshtml 
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
        // Here, you can customize your code.
    }
}
```

## SizeChanged

[SizeChanged](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartEvents.html#Syncfusion_Blazor_Charts_AccumulationChartEvents_SizeChanged) event is triggered when the accumulation chart is resized.

### Arguments

The following fields are available in the [AccumulationResizeEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationResizeEventArgs.html).

* [Chart](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationResizeEventArgs.html#Syncfusion_Blazor_Charts_AccumulationResizeEventArgs_Chart) – Specifies the current accumulation chart instance.
* [CurrentSize](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationResizeEventArgs.html#Syncfusion_Blazor_Charts_AccumulationResizeEventArgs_CurrentSize) – Specifies the current size of the accumulation chart.
* [PreviousSize](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationResizeEventArgs.html#Syncfusion_Blazor_Charts_AccumulationResizeEventArgs_PreviousSize) – Specifies the previous size of the accumulation chart.

```cshtml 
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
        // Here, you can customize your code.
    }
}
```

## Loaded

`Loaded` event triggers after accumulation chart is loaded.

```cshtml 
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
        // Here, you can customize your code.
    }
}
```

## OnPointClick

[OnPointClick](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartEvents.html#Syncfusion_Blazor_Charts_AccumulationChartEvents_OnPointClick) event triggers on point click.

### Arguments

The following fields are available in the [AccumulationPointEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationPointEventArgs.html).

* [PageX](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationPointEventArgs.html#Syncfusion_Blazor_Charts_AccumulationPointEventArgs_PageX) – Specifies the current window page x location.
* [PageY](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationPointEventArgs.html#Syncfusion_Blazor_Charts_AccumulationPointEventArgs_PageY) – Specifies the current window page y location.
* [Point](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationPointEventArgs.html#Syncfusion_Blazor_Charts_AccumulationPointEventArgs_Point) – Specifies the current point which is clicked.
* [PointIndex](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationPointEventArgs.html#Syncfusion_Blazor_Charts_AccumulationPointEventArgs_PointIndex) – Specifies the index of the current point.
* [SeriesIndex](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationPointEventArgs.html#Syncfusion_Blazor_Charts_AccumulationPointEventArgs_SeriesIndex) – Specifies the current series index.
* [X](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationPointEventArgs.html#Syncfusion_Blazor_Charts_AccumulationPointEventArgs_X) – Specifies the x coordinate of the current mouse click.
* [Y](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationPointEventArgs.html#Syncfusion_Blazor_Charts_AccumulationPointEventArgs_Y) – Specifies the y coordinate of the current mouse click.


```cshtml 
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
        // Here, you can customize your code.
    }
}
```

## TooltipRender

[TooltipRender](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartEvents.html#Syncfusion_Blazor_Charts_AccumulationChartEvents_TooltipRender) event triggers before the tooltip for series is rendered.

### Arguments

The following property is available in the [TooltipRenderEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.TooltipRenderEventArgs.html).

* [HeaderText](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.TooltipRenderEventArgs.html#Syncfusion_Blazor_Charts_TooltipRenderEventArgs_HeaderText) – Specifies the header text for the tooltip.
* [Text](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.TooltipRenderEventArgs.html#Syncfusion_Blazor_Charts_TooltipRenderEventArgs_Text) – Specifies the text for the tooltip.

```cshtml 
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
        // Here, you can customize your code.
    }
}
```