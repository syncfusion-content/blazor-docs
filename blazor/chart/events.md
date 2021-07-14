---
layout: post
title: Events in Blazor Chart Component | Syncfusion 
description: Learn about Events in Blazor Chart component of Syncfusion, and more details.
platform: Blazor
control: Chart
documentation: ug
---

# Events

In this section, we have provided a list of chart component events that will be triggered for appropriate chart actions.

The events should be provided to the chart using [`ChartEvents`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html) component.

> From `v18.4.*`, we have added few additional events for the chart component

Event Name|
-----|
[OnZoomStart](events/#onzoomstart)|
[OnZoomEnd](events/#onzoomend)|
[OnLegendItemRender](events/#onlegenditemrender)|
[OnDataLabelRender](events/#ondatalabelrender)|
[OnPointRender](events/#onpointrender)|
[OnAxisLabelRender](events/#onaxislabelrender)|
[OnAxisLabelClick](events/#onaxislabelclick)|
[OnAxisActualRangeCalculated](events/#onaxisactualrangecalculated)|
[OnAxisMultiLevelLabelRender](events/#onaxismultilevellabelrender)|

> From `v18.4.*`, some event names are different from the previous releases. The following are the event name changes from `v18.3.*` to `v18.4.*`

Event Name(`v18.3.*`) |Event Name(`v18.4.*`)
-----|-----
Resized |[SizeChanged](events/#sizechanged)
ScrollChanged |[OnScrollChanged](events/#onscrollchanged)
OnScrollEnd |[OnScrollChanged](events/#onscrollchanged)
OnScrollStart |[OnScrollChanged](events/#onscrollchanged)
AfterExport |[OnExportComplete](events/#onexportcomplete)
OnPrint | [OnPrintComplete](events/#onprintcomplete)
DragStart |[OnDataEdit](events/#ondataedit)
DragEnd |[OnDataEditCompleted](events/#ondataeditcompleted)
LegendClick |[OnLegendClick](events/#onlegendclick)
MultiLevelLabelClick |[OnMultiLevelLabelClick](events/#onmultilevellabelclick)
OnSelectionComplete |[OnSelectionChanged](events/#onselectionchanged)
OnDragComplete |[OnSelectionChanged](events/#onselectionchanged)

> From `v18.4.*`, We have removed the following previous release events from chart component

Event Name|
-----|
OnAnimationComplete|
OnChartMouseClick|
OnChartMouseDown|
OnChartMouseLeave|
OnChartMouseMove|
OnChartMouseUp|
PointMoved|
BeforeExport|
Load|
OnPointDoubleClick|
PointMoved|

## OnZoomStart

After the zoom selection is made, the [`OnZoomStart`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_OnZoomStart) event is triggered.

{% highlight csharp %}

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartEvents OnZoomStart="OnZoomingEvent"></ChartEvents>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category"></ChartPrimaryXAxis>
    <ChartSeriesCollection>
        <ChartSeries DataSource="@Sales" XName="Month" YName="SalesValue" Type="ChartSeriesType.Column">
        </ChartSeries>
    </ChartSeriesCollection>
    <ChartZoomSettings EnableSelectionZooming="true"></ChartZoomSettings>
</SfChart>

@code{
    public class SalesInfo
    {
        public string Month { get; set; }
        public double SalesValue { get; set; }
    }
    public List<SalesInfo> Sales = new List<SalesInfo>
    {
        new SalesInfo { Month = "Jan", SalesValue = 35 },
        new SalesInfo { Month = "Feb", SalesValue = 28 },
        new SalesInfo { Month = "Mar", SalesValue = 34 },
        new SalesInfo { Month = "Apr", SalesValue = 32 },
        new SalesInfo { Month = "May", SalesValue = 40 },
        new SalesInfo { Month = "Jun", SalesValue = 32 },
        new SalesInfo { Month = "Jul", SalesValue = 35 }
    };

    public void OnZoomingEvent(ZoomingEventArgs args)
    {
        // Here you can customize your code
    }
}

{% endhighlight %}

## OnZoomEnd

[`OnZoomEnd`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_OnZoomEnd) event triggers, after the zoom selection is completed.

{% highlight csharp %}

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartEvents OnZoomEnd="OnZoomingEvent"></ChartEvents>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category"></ChartPrimaryXAxis>
    <ChartSeriesCollection>
        <ChartSeries DataSource="@Sales" XName="Month" YName="SalesValue" Type="ChartSeriesType.Column">
        </ChartSeries>
    </ChartSeriesCollection>
    <ChartZoomSettings EnableSelectionZooming="true"></ChartZoomSettings>
</SfChart>

@code{
    public class SalesInfo
    {
        public string Month { get; set; }
        public double SalesValue { get; set; }
    }
    public List<SalesInfo> Sales = new List<SalesInfo>
    {
        new SalesInfo { Month = "Jan", SalesValue = 35 },
        new SalesInfo { Month = "Feb", SalesValue = 28 },
        new SalesInfo { Month = "Mar", SalesValue = 34 },
        new SalesInfo { Month = "Apr", SalesValue = 32 },
        new SalesInfo { Month = "May", SalesValue = 40 },
        new SalesInfo { Month = "Jun", SalesValue = 32 },
        new SalesInfo { Month = "Jul", SalesValue = 35 }
    };

    public void OnZoomingEvent(ZoomingEventArgs args)
    {
        // Here you can customize your code
    }
}

{% endhighlight %}

## OnLegendItemRender

[`OnLegendItemRender`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_OnLegendItemRender) event triggers,before the legend is rendered.

{% highlight csharp %}

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartEvents OnLegendItemRender="LegendEvent"></ChartEvents>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category"></ChartPrimaryXAxis>
    <ChartSeriesCollection>
        <ChartSeries DataSource="@Sales" Name="Column" XName="Month" YName="SalesValue" Type="ChartSeriesType.Column">
        </ChartSeries>
        <ChartSeries DataSource="@Sales" Name="Line" XName="Month" YName="SalesValue" Type="ChartSeriesType.Line">
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code{
    public class SalesInfo
    {
        public string Month { get; set; }
        public double SalesValue { get; set; }
    }
    public List<SalesInfo> Sales = new List<SalesInfo>
    {
        new SalesInfo { Month = "Jan", SalesValue = 35 },
        new SalesInfo { Month = "Feb", SalesValue = 28 },
        new SalesInfo { Month = "Mar", SalesValue = 34 },
        new SalesInfo { Month = "Apr", SalesValue = 32 },
        new SalesInfo { Month = "May", SalesValue = 40 },
        new SalesInfo { Month = "Jun", SalesValue = 32 },
        new SalesInfo { Month = "Jul", SalesValue = 35 }
    };

    public void LegendEvent(LegendRenderEventArgs args)
    {
        // Here you can customize your code
    }
}

{% endhighlight %}

## OnDataLabelRender

[`OnDataLabelRender`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_OnDataLabelRender) event triggers, before the data label for series is rendered.

{% highlight csharp %}

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartEvents OnDataLabelRender="DataLabelEvent"></ChartEvents>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category"></ChartPrimaryXAxis>
    <ChartSeriesCollection>
        <ChartSeries DataSource="@Sales" XName="Month" YName="SalesValue" Type="ChartSeriesType.Column">
            <ChartMarker>
                <ChartDataLabel Visible="true"></ChartDataLabel>
            </ChartMarker>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code{
    public class SalesInfo
    {
        public string Month { get; set; }
        public double SalesValue { get; set; }
    }
    public List<SalesInfo> Sales = new List<SalesInfo>
    {
        new SalesInfo { Month = "Jan", SalesValue = 35 },
        new SalesInfo { Month = "Feb", SalesValue = 28 },
        new SalesInfo { Month = "Mar", SalesValue = 34 },
        new SalesInfo { Month = "Apr", SalesValue = 32 },
        new SalesInfo { Month = "May", SalesValue = 40 },
        new SalesInfo { Month = "Jun", SalesValue = 32 },
        new SalesInfo { Month = "Jul", SalesValue = 35 }
    };

    public void DataLabelEvent(TextRenderEventArgs args)
    {
        // Here you can customize your code
    }
}

{% endhighlight %}

## OnPointRender

[`OnPointRender`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_OnPointRender) event triggers, before each points for the series is rendered.

{% highlight csharp %}

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartEvents OnPointRender="PointRenderEvent"></ChartEvents>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category"></ChartPrimaryXAxis>
    <ChartSeriesCollection>
        <ChartSeries DataSource="@Sales" XName="Month" YName="SalesValue" Type="ChartSeriesType.Column">
            <ChartMarker Visible="true">
            </ChartMarker>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code{
    public class SalesInfo
    {
        public string Month { get; set; }
        public double SalesValue { get; set; }
    }
    public List<SalesInfo> Sales = new List<SalesInfo>
    {
        new SalesInfo { Month = "Jan", SalesValue = 35 },
        new SalesInfo { Month = "Feb", SalesValue = 28 },
        new SalesInfo { Month = "Mar", SalesValue = 34 },
        new SalesInfo { Month = "Apr", SalesValue = 32 },
        new SalesInfo { Month = "May", SalesValue = 40 },
        new SalesInfo { Month = "Jun", SalesValue = 32 },
        new SalesInfo { Month = "Jul", SalesValue = 35 }
    };

    public void PointRenderEvent(PointRenderEventArgs args)
    {
        // Here you can customize your code
    }
}

{% endhighlight %}

## OnAxisLabelRender

[`OnAxisLabelRender`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_OnAxisLabelRender) event triggers, before each axis label is rendered.

{% highlight csharp %}

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartEvents OnAxisLabelRender="AxisLabelEvent"></ChartEvents>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category"></ChartPrimaryXAxis>
    <ChartSeriesCollection>
        <ChartSeries DataSource="@Sales" XName="Month" YName="SalesValue" Type="ChartSeriesType.Column">
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code{
    public class SalesInfo
    {
        public string Month { get; set; }
        public double SalesValue { get; set; }
    }
    public List<SalesInfo> Sales = new List<SalesInfo>
    {
        new SalesInfo { Month = "Jan", SalesValue = 35 },
        new SalesInfo { Month = "Feb", SalesValue = 28 },
        new SalesInfo { Month = "Mar", SalesValue = 34 },
        new SalesInfo { Month = "Apr", SalesValue = 32 },
        new SalesInfo { Month = "May", SalesValue = 40 },
        new SalesInfo { Month = "Jun", SalesValue = 32 },
        new SalesInfo { Month = "Jul", SalesValue = 35 }
    };

    public void AxisLabelEvent(AxisLabelRenderEventArgs args)
    {
        // Here you can customize your code
    }
}

{% endhighlight %}

## OnAxisLabelClick

[`OnAxisLabelClick`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_OnAxisLabelClick) event triggers, when x axis label is clicked.

{% highlight csharp %}

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartEvents OnAxisLabelClick="AxisLabelClickEvent"></ChartEvents>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category"></ChartPrimaryXAxis>
    <ChartSeriesCollection>
        <ChartSeries DataSource="@Sales" XName="Month" YName="SalesValue" Type="ChartSeriesType.Column">
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code{
    public class SalesInfo
    {
        public string Month { get; set; }
        public double SalesValue { get; set; }
    }
    public List<SalesInfo> Sales = new List<SalesInfo>
    {
        new SalesInfo { Month = "Jan", SalesValue = 35 },
        new SalesInfo { Month = "Feb", SalesValue = 28 },
        new SalesInfo { Month = "Mar", SalesValue = 34 },
        new SalesInfo { Month = "Apr", SalesValue = 32 },
        new SalesInfo { Month = "May", SalesValue = 40 },
        new SalesInfo { Month = "Jun", SalesValue = 32 },
        new SalesInfo { Month = "Jul", SalesValue = 35 }
    };

    public void AxisLabelClickEvent(AxisLabelClickEventArgs args)
    {
        // Here you can customize your code
    }
}

{% endhighlight %}

## OnAxisActualRangeCalculated

[`OnAxisActualRangeCalculated`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_OnAxisActualRangeCalculated) event triggers, before each axis range is calculated.

{% highlight csharp %}

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartEvents OnAxisActualRangeCalculated="AxisActualRangeEvent"></ChartEvents>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category"></ChartPrimaryXAxis>
    <ChartSeriesCollection>
        <ChartSeries DataSource="@Sales" XName="Month" YName="SalesValue" Type="ChartSeriesType.Column">
            <ChartMarker Visible="true">
            </ChartMarker>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code{
    public class SalesInfo
    {
        public string Month { get; set; }
        public double SalesValue { get; set; }
    }
    public List<SalesInfo> Sales = new List<SalesInfo>
    {
        new SalesInfo { Month = "Jan", SalesValue = 35 },
        new SalesInfo { Month = "Feb", SalesValue = 28 },
        new SalesInfo { Month = "Mar", SalesValue = 34 },
        new SalesInfo { Month = "Apr", SalesValue = 32 },
        new SalesInfo { Month = "May", SalesValue = 40 },
        new SalesInfo { Month = "Jun", SalesValue = 32 },
        new SalesInfo { Month = "Jul", SalesValue = 35 }
    };

    public void AxisActualRangeEvent(AxisRangeCalculatedEventArgs args)
    {
        // Here you can customize your code
    }
}

{% endhighlight %}

## OnAxisMultiLevelLabelRender

[`OnAxisMultiLevelLabelRender`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_OnAxisMultiLevelLabelRender) event triggers, while rendering multilevellabels.

{% highlight csharp %}

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartEvents OnAxisMultiLevelLabelRender="AxisMultiLevelLabelEvent"></ChartEvents>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category">
        <ChartMultiLevelLabels>
            <ChartMultiLevelLabel>
               <ChartCategories>
                  <ChartCategory Start="0" End="3" Text="First_Half"></ChartCategory>
                  <ChartCategory Start="3" End="6" Text="Second_Half"></ChartCategory>
               </ChartCategories>
            </ChartMultiLevelLabel>
        </ChartMultiLevelLabels>
    </ChartPrimaryXAxis>
    <ChartSeriesCollection>
        <ChartSeries DataSource="@Sales" XName="Month" YName="SalesValue" Type="ChartSeriesType.Column">
            <ChartMarker Visible="true">
            </ChartMarker>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code{
    
    public class SalesInfo
    {
        public string Month { get; set; }
        public double SalesValue { get; set; }
    }
    public List<SalesInfo> Sales = new List<SalesInfo>
    {
        new SalesInfo { Month = "Jan", SalesValue = 35 },
        new SalesInfo { Month = "Feb", SalesValue = 28 },
        new SalesInfo { Month = "Mar", SalesValue = 34 },
        new SalesInfo { Month = "Apr", SalesValue = 32 },
        new SalesInfo { Month = "May", SalesValue = 40 },
        new SalesInfo { Month = "Jun", SalesValue = 32 },
        new SalesInfo { Month = "Jul", SalesValue = 35 }
    };

    public void AxisMultiLevelLabelEvent(AxisMultiLabelRenderEventArgs args)
    {
        // Here you can customize your code
    }
}

{% endhighlight %}

## SizeChanged

[`SizeChanged`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_SizeChanged) event triggers after resizing of chart.

{% highlight csharp %}

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartEvents SizeChanged="@SizeChangedEvent"></ChartEvents>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category"></ChartPrimaryXAxis>
    <ChartSeriesCollection>
        <ChartSeries DataSource="@Sales" XName="Month" YName="SalesValue" Type="ChartSeriesType.Column">
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code{
    public class SalesInfo
    {
        public string Month { get; set; }
        public double SalesValue { get; set; }
    }
    public List<SalesInfo> Sales = new List<SalesInfo>
{
        new SalesInfo { Month = "Jan", SalesValue = 35 },
        new SalesInfo { Month = "Feb", SalesValue = 28 },
        new SalesInfo { Month = "Mar", SalesValue = 34 },
        new SalesInfo { Month = "Apr", SalesValue = 32 },
        new SalesInfo { Month = "May", SalesValue = 40 },
        new SalesInfo { Month = "Jun", SalesValue = 32 },
        new SalesInfo { Month = "Jul", SalesValue = 35 }
    };

    public void SizeChangedEvent(ResizeEventArgs args)
    {
        // Here you can customize your code
    }
}

{% endhighlight %}

## OnScrollChanged

[`OnScrollChanged`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_OnScrollChanged) event triggers while scrolling the chart.

{% highlight csharp %}

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartEvents OnScrollChanged="ScrollChangeEvent"></ChartEvents>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" ZoomFactor="0.5" ZoomPosition="0.2">
        <ChartAxisScrollbarSettings Enable="true"></ChartAxisScrollbarSettings>
    </ChartPrimaryXAxis>
    <ChartSeriesCollection>
        <ChartSeries DataSource="@Sales" XName="Month" YName="SalesValue" Type="ChartSeriesType.Column">
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code{
    public class SalesInfo
    {
        public string Month { get; set; }
        public double SalesValue { get; set; }
    }
    public List<SalesInfo> Sales = new List<SalesInfo>
{
        new SalesInfo { Month = "Jan", SalesValue = 35 },
        new SalesInfo { Month = "Feb", SalesValue = 28 },
        new SalesInfo { Month = "Mar", SalesValue = 34 },
        new SalesInfo { Month = "Apr", SalesValue = 32 },
        new SalesInfo { Month = "May", SalesValue = 40 },
        new SalesInfo { Month = "Jun", SalesValue = 32 },
        new SalesInfo { Month = "Jul", SalesValue = 35 }
    };

    public void ScrollChangeEvent(ScrollEventArgs args)
    {
        // Here you can customize your code
    }
}

{% endhighlight %}

## OnExportComplete

[`OnExportComplete`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_OnExportComplete) event triggers after exporting the chart.

{% highlight csharp %}

@using Syncfusion.Blazor.Charts

<button class="btn-success" @onclick="Export">Export</button>
<SfChart @ref="chart">
    <ChartEvents OnExportComplete="ExportCompleteEvent"></ChartEvents>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category">
    </ChartPrimaryXAxis>
    <ChartSeriesCollection>
        <ChartSeries DataSource="@Sales" XName="Month" YName="SalesValue" Type="ChartSeriesType.Column">
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code{
    SfChart chart;
    public class SalesInfo
    {
        public string Month { get; set; }
        public double SalesValue { get; set; }
    }
    public List<SalesInfo> Sales = new List<SalesInfo>
{
        new SalesInfo { Month = "Jan", SalesValue = 35 },
        new SalesInfo { Month = "Feb", SalesValue = 28 },
        new SalesInfo { Month = "Mar", SalesValue = 34 },
        new SalesInfo { Month = "Apr", SalesValue = 32 },
        new SalesInfo { Month = "May", SalesValue = 40 },
        new SalesInfo { Month = "Jun", SalesValue = 32 },
        new SalesInfo { Month = "Jul", SalesValue = 35 }
    };

    public void Export()
    {
        chart.Export(ExportType.JPEG, "Charts");
    }
    public void ExportCompleteEvent(ExportEventArgs args)
    {
        // Here you can customize your code
    }
}

{% endhighlight %}

## OnPrintComplete

`OnPrintComplete` event triggers after printing the chart.

{% highlight csharp %}

@using Syncfusion.Blazor.Charts

<button class="btn-success" @onclick="Print">Print</button>
<SfChart @ref="chart">
    <ChartEvents OnPrintComplete="PrintCompleteEvent"></ChartEvents>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category">
    </ChartPrimaryXAxis>
    <ChartSeriesCollection>
        <ChartSeries DataSource="@Sales" XName="Month" YName="SalesValue" Type="ChartSeriesType.Column">
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code{
    SfChart chart;
    public class SalesInfo
    {
        public string Month { get; set; }
        public double SalesValue { get; set; }
    }
    public List<SalesInfo> Sales = new List<SalesInfo>
   {
        new SalesInfo { Month = "Jan", SalesValue = 35 },
        new SalesInfo { Month = "Feb", SalesValue = 28 },
        new SalesInfo { Month = "Mar", SalesValue = 34 },
        new SalesInfo { Month = "Apr", SalesValue = 32 },
        new SalesInfo { Month = "May", SalesValue = 40 },
        new SalesInfo { Month = "Jun", SalesValue = 32 },
        new SalesInfo { Month = "Jul", SalesValue = 35 }
    };

    public void Print()
    {
        chart.Print();
    }
    public void PrintCompleteEvent()
    {
        // Here you can customize your code
    }
}

{% endhighlight %}

## OnDataEdit

[`OnDataEdit`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_OnDataEdit) event triggers, while dragging the data point.

{% highlight csharp %}

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartEvents OnDataEdit="DataEditEvent"></ChartEvents>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category">
    </ChartPrimaryXAxis>
    <ChartSeriesCollection>
        <ChartSeries DataSource="@Sales" XName="Month" YName="SalesValue" Type="ChartSeriesType.Column">
            <ChartDataEditSettings Enable="true"></ChartDataEditSettings>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code{
    public class SalesInfo
    {
        public string Month { get; set; }
        public double SalesValue { get; set; }
    }
    public List<SalesInfo> Sales = new List<SalesInfo>
{
        new SalesInfo { Month = "Jan", SalesValue = 35 },
        new SalesInfo { Month = "Feb", SalesValue = 28 },
        new SalesInfo { Month = "Mar", SalesValue = 34 },
        new SalesInfo { Month = "Apr", SalesValue = 32 },
        new SalesInfo { Month = "May", SalesValue = 40 },
        new SalesInfo { Month = "Jun", SalesValue = 32 },
        new SalesInfo { Month = "Jul", SalesValue = 35 }
    };

    public void DataEditEvent(DataEditingEventArgs arg)
    {
        // Here you can customize your code
    }
}

{% endhighlight %}

## OnDataEditCompleted

[`OnDataEditCompleted`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_OnDataEditCompleted) event triggers  when the point drag completed.

{% highlight csharp %}

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartEvents OnDataEditCompleted="DataEditEvent"></ChartEvents>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category">
    </ChartPrimaryXAxis>
    <ChartSeriesCollection>
        <ChartSeries DataSource="@Sales" XName="Month" YName="SalesValue" Type="ChartSeriesType.Column">
            <ChartDataEditSettings Enable="true"></ChartDataEditSettings>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code{
    public class SalesInfo
    {
        public string Month { get; set; }
        public double SalesValue { get; set; }
    }
    public List<SalesInfo> Sales = new List<SalesInfo>
{
        new SalesInfo { Month = "Jan", SalesValue = 35 },
        new SalesInfo { Month = "Feb", SalesValue = 28 },
        new SalesInfo { Month = "Mar", SalesValue = 34 },
        new SalesInfo { Month = "Apr", SalesValue = 32 },
        new SalesInfo { Month = "May", SalesValue = 40 },
        new SalesInfo { Month = "Jun", SalesValue = 32 },
        new SalesInfo { Month = "Jul", SalesValue = 35 }
    };

    public void DataEditEvent(DataEditingEventArgs arg)
    {
        // Here you can customize your code
    }
}

{% endhighlight %}

## OnLegendClick

[`OnLegendClick`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_OnLegendClick) event triggers after legend click.

{% highlight csharp %}

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartEvents OnLegendClick="LegendClickEvent"></ChartEvents>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category"></ChartPrimaryXAxis>
    <ChartSeriesCollection>
        <ChartSeries DataSource="@Sales" Name="Column" XName="Month" YName="SalesValue" Type="ChartSeriesType.Column">
        </ChartSeries>
        <ChartSeries DataSource="@Sales" Name="Line" XName="Month" YName="SalesValue" Type="ChartSeriesType.Line">
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code{
    public class SalesInfo
    {
        public string Month { get; set; }
        public double SalesValue { get; set; }
    }
    public List<SalesInfo> Sales = new List<SalesInfo>
{
        new SalesInfo { Month = "Jan", SalesValue = 35 },
        new SalesInfo { Month = "Feb", SalesValue = 28 },
        new SalesInfo { Month = "Mar", SalesValue = 34 },
        new SalesInfo { Month = "Apr", SalesValue = 32 },
        new SalesInfo { Month = "May", SalesValue = 40 },
        new SalesInfo { Month = "Jun", SalesValue = 32 },
        new SalesInfo { Month = "Jul", SalesValue = 35 }
    };

    public void LegendClickEvent(LegendClickEventArgs args)
    {
        // Here you can customize your code
    }
}

{% endhighlight %}

## OnMultiLevelLabelClick

[`OnMultiLevelLabelClick`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_OnMultiLevelLabelClick) event triggers after click on multilevellabelclick.

{% highlight csharp %}

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartEvents OnMultiLevelLabelClick="MultiLabelClickEvent"></ChartEvents>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category">
        <ChartMultiLevelLabels>
            <ChartMultiLevelLabel>
                <ChartCategories>
                    <ChartCategory Start="0" End="3" Text="First_Half"></ChartCategory>
                    <ChartCategory Start="3" End="6" Text="Second_Half"></ChartCategory>
                </ChartCategories>
            </ChartMultiLevelLabel>
        </ChartMultiLevelLabels>
    </ChartPrimaryXAxis>
    <ChartSeriesCollection>
        <ChartSeries DataSource="@Sales" XName="Month" YName="SalesValue" Type="ChartSeriesType.Column">
            <ChartMarker Visible="true">
            </ChartMarker>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code{

    public class SalesInfo
    {
        public string Month { get; set; }
        public double SalesValue { get; set; }
    }
    public List<SalesInfo> Sales = new List<SalesInfo>
{
        new SalesInfo { Month = "Jan", SalesValue = 35 },
        new SalesInfo { Month = "Feb", SalesValue = 28 },
        new SalesInfo { Month = "Mar", SalesValue = 34 },
        new SalesInfo { Month = "Apr", SalesValue = 32 },
        new SalesInfo { Month = "May", SalesValue = 40 },
        new SalesInfo { Month = "Jun", SalesValue = 32 },
        new SalesInfo { Month = "Jul", SalesValue = 35 }
    };

    public void MultiLabelClickEvent(MultiLevelLabelClickEventArgs args)
    {
        // Here you can customize your code
    }
}

{% endhighlight %}

## OnSelectionChanged

[`OnSelectionChanged`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_OnSelectionChanged) event triggers after the selection is completed.

{% highlight csharp %}

@using Syncfusion.Blazor.Charts

<SfChart SelectionMode="SelectionMode.Point">
    <ChartEvents OnSelectionChanged="SelectionChangedEvent"></ChartEvents>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category">
    </ChartPrimaryXAxis>
    <ChartSeriesCollection>
        <ChartSeries DataSource="@Sales" XName="Month" YName="SalesValue" Type="ChartSeriesType.Column">
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code{

    public class SalesInfo
    {
        public string Month { get; set; }
        public double SalesValue { get; set; }
    }
    public List<SalesInfo> Sales = new List<SalesInfo>
{
        new SalesInfo { Month = "Jan", SalesValue = 35 },
        new SalesInfo { Month = "Feb", SalesValue = 28 },
        new SalesInfo { Month = "Mar", SalesValue = 34 },
        new SalesInfo { Month = "Apr", SalesValue = 32 },
        new SalesInfo { Month = "May", SalesValue = 40 },
        new SalesInfo { Month = "Jun", SalesValue = 32 },
        new SalesInfo { Month = "Jul", SalesValue = 35 }
    };

    public void SelectionChangedEvent(SelectionCompleteEventArgs args)
    {
        // Here you can customize your code
    }
}

{% endhighlight %}

## Loaded

`Loaded` event triggers after chart load.

{% highlight csharp %}

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartEvents Loaded="LoadedEvent"></ChartEvents>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category"></ChartPrimaryXAxis>
    <ChartSeriesCollection>
        <ChartSeries DataSource="@Sales" XName="Month" YName="SalesValue" Type="ChartSeriesType.Column">
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code{
    public class SalesInfo
    {
        public string Month { get; set; }
        public double SalesValue { get; set; }
    }
    public List<SalesInfo> Sales = new List<SalesInfo>
    {
        new SalesInfo { Month = "Jan", SalesValue = 35 },
        new SalesInfo { Month = "Feb", SalesValue = 28 },
        new SalesInfo { Month = "Mar", SalesValue = 34 },
        new SalesInfo { Month = "Apr", SalesValue = 32 },
        new SalesInfo { Month = "May", SalesValue = 40 },
        new SalesInfo { Month = "Jun", SalesValue = 32 },
        new SalesInfo { Month = "Jul", SalesValue = 35 }
    };

    public void LoadedEvent(LoadedEventArgs args)
    {
        // Here you can customize your code
    }
}

{% endhighlight %}

## OnPointClick

[`OnPointClick`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_OnPointClick) event triggers on point click.

{% highlight csharp %}

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartEvents OnPointClick="PointClickEvent"></ChartEvents>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category"></ChartPrimaryXAxis>
    <ChartSeriesCollection>
        <ChartSeries DataSource="@Sales" XName="Month" YName="SalesValue" Type="ChartSeriesType.Column">
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code{
    public class SalesInfo
    {
        public string Month { get; set; }
        public double SalesValue { get; set; }
    }
    public List<SalesInfo> Sales = new List<SalesInfo>
    {
        new SalesInfo { Month = "Jan", SalesValue = 35 },
        new SalesInfo { Month = "Feb", SalesValue = 28 },
        new SalesInfo { Month = "Mar", SalesValue = 34 },
        new SalesInfo { Month = "Apr", SalesValue = 32 },
        new SalesInfo { Month = "May", SalesValue = 40 },
        new SalesInfo { Month = "Jun", SalesValue = 32 },
        new SalesInfo { Month = "Jul", SalesValue = 35 }
    };

    public void PointClickEvent(PointEventArgs args)
    {
        // Here you can customize your code
    }
}

{% endhighlight %}

## TooltipRender

[`TooltipRender`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_TooltipRender) event triggers, before the tooltip for series is rendered.

{% highlight csharp %}

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartEvents TooltipRender="TooltipEvent"></ChartEvents>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category"></ChartPrimaryXAxis>
    <ChartSeriesCollection>
        <ChartSeries DataSource="@Sales" XName="Month" YName="SalesValue" Type="ChartSeriesType.Column">
        </ChartSeries>
    </ChartSeriesCollection>
    <ChartTooltipSettings Enable="true"></ChartTooltipSettings>
</SfChart>

@code{
    public class SalesInfo
    {
        public string Month { get; set; }
        public double SalesValue { get; set; }
    }
    public List<SalesInfo> Sales = new List<SalesInfo>
    {
        new SalesInfo { Month = "Jan", SalesValue = 35 },
        new SalesInfo { Month = "Feb", SalesValue = 28 },
        new SalesInfo { Month = "Mar", SalesValue = 34 },
        new SalesInfo { Month = "Apr", SalesValue = 32 },
        new SalesInfo { Month = "May", SalesValue = 40 },
        new SalesInfo { Month = "Jun", SalesValue = 32 },
        new SalesInfo { Month = "Jul", SalesValue = 35 }
    };

    public void TooltipEvent(TooltipRenderEventArgs args)
    {
        // Here you can customize your code
    }
}

{% endhighlight %}

## SharedTooltipRender

[`SharedTooltipRender`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_SharedTooltipRender) event triggers, before the sharedtooltip for series is rendered.

{% highlight csharp %}

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartEvents SharedTooltipRender="SharedTooltipEvent"></ChartEvents>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category"></ChartPrimaryXAxis>
    <ChartSeriesCollection>
        <ChartSeries DataSource="@Sales" XName="Month" YName="SalesValue" Type="ChartSeriesType.Column">
        </ChartSeries>
        <ChartSeries DataSource="@Sales" XName="Month" YName="SalesValue" Type="ChartSeriesType.Column">
        </ChartSeries>
    </ChartSeriesCollection>
    <ChartTooltipSettings Enable="true" Shared="true"></ChartTooltipSettings>
</SfChart>

@code{
    public class SalesInfo
    {
        public string Month { get; set; }
        public double SalesValue { get; set; }
    }
    public List<SalesInfo> Sales = new List<SalesInfo>
    {
        new SalesInfo { Month = "Jan", SalesValue = 35 },
        new SalesInfo { Month = "Feb", SalesValue = 28 },
        new SalesInfo { Month = "Mar", SalesValue = 34 },
        new SalesInfo { Month = "Apr", SalesValue = 32 },
        new SalesInfo { Month = "May", SalesValue = 40 },
        new SalesInfo { Month = "Jun", SalesValue = 32 },
        new SalesInfo { Month = "Jul", SalesValue = 35 }
    };

    public void SharedTooltipEvent(SharedTooltipRenderEventArgs args)
    {
        // Here you can customize your code
    }
}

{% endhighlight %}

## OnZooming

[`OnZooming`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_OnZooming) event triggers, after the zoom selection is completed.

{% highlight csharp %}

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartEvents OnZooming="OnZoomingEvent"></ChartEvents>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category"></ChartPrimaryXAxis>
    <ChartSeriesCollection>
        <ChartSeries DataSource="@Sales" XName="Month" YName="SalesValue" Type="ChartSeriesType.Column">
        </ChartSeries>
    </ChartSeriesCollection>
    <ChartZoomSettings EnableSelectionZooming="true"></ChartZoomSettings>
</SfChart>

@code{
    public class SalesInfo
    {
        public string Month { get; set; }
        public double SalesValue { get; set; }
    }
    public List<SalesInfo> Sales = new List<SalesInfo>
    {
        new SalesInfo { Month = "Jan", SalesValue = 35 },
        new SalesInfo { Month = "Feb", SalesValue = 28 },
        new SalesInfo { Month = "Mar", SalesValue = 34 },
        new SalesInfo { Month = "Apr", SalesValue = 32 },
        new SalesInfo { Month = "May", SalesValue = 40 },
        new SalesInfo { Month = "Jun", SalesValue = 32 },
        new SalesInfo { Month = "Jul", SalesValue = 35 }
    };

    public void OnZoomingEvent(ZoomingEventArgs args)
    {
        // Here you can customize your code
    }
}

{% endhighlight %}

> Note: You can refer to our [`Blazor Charts`](https://www.syncfusion.com/blazor-components/blazor-charts) feature tour page for its groundbreaking feature representations. You can also explore our [`Blazor Chart example`](https://blazor.syncfusion.com/demos/chart/line?theme=bootstrap4) to knows various chart types and how to represent time-dependent data, showing trends in data at equal intervals.