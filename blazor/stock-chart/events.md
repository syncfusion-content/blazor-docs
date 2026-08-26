---
layout: post
title: Blazor Stock Chart Events | Syncfusion®
description: Learn how to handle Blazor Stock Chart events, including Loaded, OnPointClick, PointMoved, RangeChange, and mouse-event hooks.
platform: Blazor
control: Stock Chart
documentation: ug
---

# Blazor Stock Chart Events

This section lists the events of the Stock Chart component that are triggered for corresponding actions. Configure events using the [StockChartEvents](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartEvents.html) component.

The Stock Chart supports the following events:

* [OnLoaded](#onloaded)
* [OnPointClick](#onpointclick)
* [PointMoved](#pointmoved)
* [RangeChange](#rangechange)
* [OnStockChartMouseClick](#onstockchartmouseclick)
* [OnStockChartMouseDown](#onstockchartmousedown)
* [OnStockChartMouseLeave](#onstockchartmouseleave)
* [OnStockChartMouseMove](#onstockchartmousemove)
* [OnStockChartMouseUp](#onstockchartmouseup)

## OnLoaded

The [Loaded](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartEvents.html#Syncfusion_Blazor_Charts_StockChartEvents_Loaded) event is triggered after the Stock Chart is rendered. The callback receives [StockChartEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartEventArgs.html).

```cshtml

@using Syncfusion.Blazor.Charts

<SfStockChart>
    <StockChartEvents OnLoaded="StockChartLoaded"></StockChartEvents>
    <StockChartSeriesCollection>
        <StockChartSeries DataSource="@StockDetails" Type="ChartSeriesType.Column" XName="Date" YName="Y">
        </StockChartSeries>
    </StockChartSeriesCollection>
</SfStockChart>

@code {
    public void StockChartLoaded(StockChartEventArgs args)
    {
        // Here you can customize your code
    }

    public class ChartData
    {
        public DateTime Date { get; set; }
        public Double Y { get; set; }
    }

    public List<ChartData> StockDetails = new List<ChartData>
    {
        new ChartData { Date = new DateTime(2012, 04, 02), Y = 100 },
        new ChartData { Date = new DateTime(2012, 04, 09), Y = 10 },
        new ChartData { Date = new DateTime(2012, 04, 16), Y = 500 },
        new ChartData { Date = new DateTime(2012, 04, 23), Y = 80 },
        new ChartData { Date = new DateTime(2012, 04, 30), Y = 200 },
        new ChartData { Date = new DateTime(2012, 05, 07), Y = 600 },
        new ChartData { Date = new DateTime(2012, 05, 14), Y = 50 },
        new ChartData { Date = new DateTime(2012, 05, 21), Y = 700 },
        new ChartData { Date = new DateTime(2012, 05, 28), Y = 90 }
   };
}

```

## OnPointClick

The [OnPointClick](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartEvents.html#Syncfusion_Blazor_Charts_StockChartEvents_OnPointClick) event is triggered when a data point is clicked. The callback receives [StockChartPointEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartPointEventArgs.html).

```cshtml

@using Syncfusion.Blazor.Charts

<SfStockChart>
    <StockChartEvents OnPointClick="PointClick"></StockChartEvents>
    <StockChartSeriesCollection>
        <StockChartSeries DataSource="@StockDetails" Type="ChartSeriesType.Column" XName="Date" YName="Y">
        </StockChartSeries>
    </StockChartSeriesCollection>
</SfStockChart>

@code {
    public void PointClick(StockChartPointEventArgs args)
    {
        // Here you can customize your code
    }

    public class ChartData
    {
        public DateTime Date { get; set; }
        public Double Y { get; set; }
    }

    public List<ChartData> StockDetails = new List<ChartData>
    {
        new ChartData { Date = new DateTime(2012, 04, 02), Y = 100 },
        new ChartData { Date = new DateTime(2012, 04, 09), Y = 10 },
        new ChartData { Date = new DateTime(2012, 04, 16), Y = 500 },
        new ChartData { Date = new DateTime(2012, 04, 23), Y = 80 },
        new ChartData { Date = new DateTime(2012, 04, 30), Y = 200 },
        new ChartData { Date = new DateTime(2012, 05, 07), Y = 600 },
        new ChartData { Date = new DateTime(2012, 05, 14), Y = 50 },
        new ChartData { Date = new DateTime(2012, 05, 21), Y = 700 },
        new ChartData { Date = new DateTime(2012, 05, 28), Y = 90 }
   };
}

```

## PointMoved

The [PointMoved](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartEvents.html#Syncfusion_Blazor_Charts_StockChartEvents_PointMoved) event is triggered when the mouse moves over a data point. The callback receives [StockChartPointEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartPointEventArgs.html).

```cshtml

@using Syncfusion.Blazor.Charts

<SfStockChart>
    <StockChartEvents PointMoved="OnPointMoved"></StockChartEvents>
    <StockChartSeriesCollection>
        <StockChartSeries DataSource="@StockDetails" Type="ChartSeriesType.Column" XName="Date" YName="Y">
        </StockChartSeries>
    </StockChartSeriesCollection>
</SfStockChart>

@code {
    public void OnPointMoved(StockChartPointEventArgs args)
    {
        // Handle point move
    }

    public class ChartData
    {
        public DateTime Date { get; set; }
        public Double Y { get; set; }
    }

    public List<ChartData> StockDetails = new List<ChartData>
    {
        new ChartData { Date = new DateTime(2012, 04, 02), Y = 100 },
        new ChartData { Date = new DateTime(2012, 04, 09), Y = 10 },
        new ChartData { Date = new DateTime(2012, 04, 16), Y = 500 },
        new ChartData { Date = new DateTime(2012, 04, 23), Y = 80 },
        new ChartData { Date = new DateTime(2012, 04, 30), Y = 200 },
        new ChartData { Date = new DateTime(2012, 05, 07), Y = 600 },
        new ChartData { Date = new DateTime(2012, 05, 14), Y = 50 },
        new ChartData { Date = new DateTime(2012, 05, 21), Y = 700 },
        new ChartData { Date = new DateTime(2012, 05, 28), Y = 90 }
   };
}

```

## RangeChange

The [RangeChange](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartEvents.html#Syncfusion_Blazor_Charts_StockChartEvents_RangeChange) event is triggered when the range changes. The callback receives [StockChartRangeChangeEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartRangeChangeEventArgs.html).

```cshtml

@using Syncfusion.Blazor.Charts

<SfStockChart>
    <StockChartEvents RangeChange="RangeChanged"></StockChartEvents>
    <StockChartSeriesCollection>
        <StockChartSeries DataSource="@StockDetails" Type="ChartSeriesType.Column" XName="Date" YName="Y">
        </StockChartSeries>
    </StockChartSeriesCollection>
</SfStockChart>

@code {
    public void RangeChanged(StockChartRangeChangeEventArgs args)
    {
        // Here you can customize your code
    }

    public class ChartData
    {
        public DateTime Date { get; set; }
        public Double Y { get; set; }
    }

    public List<ChartData> StockDetails = new List<ChartData>
    {
        new ChartData { Date = new DateTime(2012, 04, 02), Y = 100 },
        new ChartData { Date = new DateTime(2012, 04, 09), Y = 10 },
        new ChartData { Date = new DateTime(2012, 04, 16), Y = 500 },
        new ChartData { Date = new DateTime(2012, 04, 23), Y = 80 },
        new ChartData { Date = new DateTime(2012, 04, 30), Y = 200 },
        new ChartData { Date = new DateTime(2012, 05, 07), Y = 600 },
        new ChartData { Date = new DateTime(2012, 05, 14), Y = 50 },
        new ChartData { Date = new DateTime(2012, 05, 21), Y = 700 },
        new ChartData { Date = new DateTime(2012, 05, 28), Y = 90 }
   };
}

```

## OnStockChartMouseClick

The [OnStockChartMouseClick](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartEvents.html#Syncfusion_Blazor_Charts_StockChartEvents_OnStockChartMouseClick) event is triggered when a mouse click occurs on the chart surface. The callback receives [StockChartMouseEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartMouseEventArgs.html).

```cshtml
@using Syncfusion.Blazor.Charts

<SfStockChart>
    <StockChartEvents OnStockChartMouseClick="StockChartMouseClick"></StockChartEvents>
    <StockChartSeriesCollection>
        <StockChartSeries DataSource="@StockDetails" Type="ChartSeriesType.Column" XName="Date" YName="Y">
        </StockChartSeries>
    </StockChartSeriesCollection>
</SfStockChart>

@code {
    public void StockChartMouseClick(StockChartMouseEventArgs args)
    {
        // Handle chart click
    }

    public class ChartData
    {
        public DateTime Date { get; set; }
        public Double Y { get; set; }
    }

    public List<ChartData> StockDetails = new List<ChartData>
    {
        new ChartData { Date = new DateTime(2012, 04, 02), Y = 100 },
        new ChartData { Date = new DateTime(2012, 04, 09), Y = 10 },
        new ChartData { Date = new DateTime(2012, 04, 16), Y = 500 },
        new ChartData { Date = new DateTime(2012, 04, 23), Y = 80 },
        new ChartData { Date = new DateTime(2012, 04, 30), Y = 200 },
        new ChartData { Date = new DateTime(2012, 05, 07), Y = 600 },
        new ChartData { Date = new DateTime(2012, 05, 14), Y = 50 },
        new ChartData { Date = new DateTime(2012, 05, 21), Y = 700 },
        new ChartData { Date = new DateTime(2012, 05, 28), Y = 90 }
   };
}

```

## OnStockChartMouseDown

The [OnStockChartMouseDown](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartEvents.html#Syncfusion_Blazor_Charts_StockChartEvents_OnStockChartMouseDown) event is triggered when a mouse button is pressed on the chart. The callback receives [StockChartMouseEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartMouseEventArgs.html).

```cshtml
@using Syncfusion.Blazor.Charts

<SfStockChart>
    <StockChartEvents OnStockChartMouseDown="StockChartMouseDown"></StockChartEvents>
    <StockChartSeriesCollection>
        <StockChartSeries DataSource="@StockDetails" Type="ChartSeriesType.Column" XName="Date" YName="Y">
        </StockChartSeries>
    </StockChartSeriesCollection>
</SfStockChart>

@code {
    public void StockChartMouseDown(StockChartMouseEventArgs args)
    {
        // Handle mouse down
    }

    public class ChartData
    {
        public DateTime Date { get; set; }
        public Double Y { get; set; }
    }

    public List<ChartData> StockDetails = new List<ChartData>
    {
        new ChartData { Date = new DateTime(2012, 04, 02), Y = 100 },
        new ChartData { Date = new DateTime(2012, 04, 09), Y = 10 },
        new ChartData { Date = new DateTime(2012, 04, 16), Y = 500 },
        new ChartData { Date = new DateTime(2012, 04, 23), Y = 80 },
        new ChartData { Date = new DateTime(2012, 04, 30), Y = 200 },
        new ChartData { Date = new DateTime(2012, 05, 07), Y = 600 },
        new ChartData { Date = new DateTime(2012, 05, 14), Y = 50 },
        new ChartData { Date = new DateTime(2012, 05, 21), Y = 700 },
        new ChartData { Date = new DateTime(2012, 05, 28), Y = 90 }
   };
}

```

## OnStockChartMouseLeave

The [OnStockChartMouseLeave](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartEvents.html#Syncfusion_Blazor_Charts_StockChartEvents_OnStockChartMouseLeave) event is triggered when the mouse pointer leaves the chart area. The callback receives [StockChartMouseEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartMouseEventArgs.html).

```cshtml
@using Syncfusion.Blazor.Charts

<SfStockChart>
    <StockChartEvents OnStockChartMouseLeave="StockChartMouseLeave"></StockChartEvents>
    <StockChartSeriesCollection>
        <StockChartSeries DataSource="@StockDetails" Type="ChartSeriesType.Column" XName="Date" YName="Y">
        </StockChartSeries>
    </StockChartSeriesCollection>
</SfStockChart>

@code {
    public void StockChartMouseLeave(StockChartMouseEventArgs args)
    {
        // Handle mouse leave
    }

    public class ChartData
    {
        public DateTime Date { get; set; }
        public Double Y { get; set; }
    }

    public List<ChartData> StockDetails = new List<ChartData>
    {
        new ChartData { Date = new DateTime(2012, 04, 02), Y = 100 },
        new ChartData { Date = new DateTime(2012, 04, 09), Y = 10 },
        new ChartData { Date = new DateTime(2012, 04, 16), Y = 500 },
        new ChartData { Date = new DateTime(2012, 04, 23), Y = 80 },
        new ChartData { Date = new DateTime(2012, 04, 30), Y = 200 },
        new ChartData { Date = new DateTime(2012, 05, 07), Y = 600 },
        new ChartData { Date = new DateTime(2012, 05, 14), Y = 50 },
        new ChartData { Date = new DateTime(2012, 05, 21), Y = 700 },
        new ChartData { Date = new DateTime(2012, 05, 28), Y = 90 }
   };
}

```

## OnStockChartMouseMove

The [OnStockChartMouseMove](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartEvents.html#Syncfusion_Blazor_Charts_StockChartEvents_OnStockChartMouseMove) event is triggered when the mouse moves over the chart. The callback receives [StockChartMouseEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartMouseEventArgs.html).

```cshtml
@using Syncfusion.Blazor.Charts

<SfStockChart>
    <StockChartEvents OnStockChartMouseMove="StockChartMouseMove"></StockChartEvents>
    <StockChartSeriesCollection>
        <StockChartSeries DataSource="@StockDetails" Type="ChartSeriesType.Column" XName="Date" YName="Y">
        </StockChartSeries>
    </StockChartSeriesCollection>
</SfStockChart>

@code {
    public void StockChartMouseMove(StockChartMouseEventArgs args)
    {
        // Handle mouse move
    }

    public class ChartData
    {
        public DateTime Date { get; set; }
        public Double Y { get; set; }
    }

    public List<ChartData> StockDetails = new List<ChartData>
    {
        new ChartData { Date = new DateTime(2012, 04, 02), Y = 100 },
        new ChartData { Date = new DateTime(2012, 04, 09), Y = 10 },
        new ChartData { Date = new DateTime(2012, 04, 16), Y = 500 },
        new ChartData { Date = new DateTime(2012, 04, 23), Y = 80 },
        new ChartData { Date = new DateTime(2012, 04, 30), Y = 200 },
        new ChartData { Date = new DateTime(2012, 05, 07), Y = 600 },
        new ChartData { Date = new DateTime(2012, 05, 14), Y = 50 },
        new ChartData { Date = new DateTime(2012, 05, 21), Y = 700 },
        new ChartData { Date = new DateTime(2012, 05, 28), Y = 90 }
   };
}

```

## OnStockChartMouseUp

The [OnStockChartMouseUp](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartEvents.html#Syncfusion_Blazor_Charts_StockChartEvents_OnStockChartMouseUp) event is triggered when a pressed mouse button is released over the chart. The callback receives [StockChartMouseEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartMouseEventArgs.html).

```cshtml
@using Syncfusion.Blazor.Charts

<SfStockChart>
    <StockChartEvents OnStockChartMouseUp="StockChartMouseUp"></StockChartEvents>
    <StockChartSeriesCollection>
        <StockChartSeries DataSource="@StockDetails" Type="ChartSeriesType.Column" XName="Date" YName="Y">
        </StockChartSeries>
    </StockChartSeriesCollection>
</SfStockChart>

@code {
    public void StockChartMouseUp(StockChartMouseEventArgs args)
    {
        // Handle mouse up
    }

    public class ChartData
    {
        public DateTime Date { get; set; }
        public Double Y { get; set; }
    }

    public List<ChartData> StockDetails = new List<ChartData>
    {
        new ChartData { Date = new DateTime(2012, 04, 02), Y = 100 },
        new ChartData { Date = new DateTime(2012, 04, 09), Y = 10 },
        new ChartData { Date = new DateTime(2012, 04, 16), Y = 500 },
        new ChartData { Date = new DateTime(2012, 04, 23), Y = 80 },
        new ChartData { Date = new DateTime(2012, 04, 30), Y = 200 },
        new ChartData { Date = new DateTime(2012, 05, 07), Y = 600 },
        new ChartData { Date = new DateTime(2012, 05, 14), Y = 50 },
        new ChartData { Date = new DateTime(2012, 05, 21), Y = 700 },
        new ChartData { Date = new DateTime(2012, 05, 28), Y = 90 }
   };
}

```
