---
layout: post
title: Events in Blazor Stock Chart Component | Syncfusion
description: Check out and learn here all about events in Syncfusion Blazor Stock Chart component and much more details.
platform: Blazor
control: Stock Chart 
documentation: ug
---

# Events in Blazor Stock Chart Component

This section lists the events of the Stock Chart component that are triggered for corresponding actions. Configure events using the **StockChartEvents** component.

The Stock Chart supports the following events:

* [OnLoaded](events#onloaded)
* [OnPointClick](events#onpointclick)
* [PointMoved](events#pointmoved)
* [RangeChange](events#rangechange)
* [OnStockChartMouseClick](events#onstockchartmouseclick)
* [OnStockChartMouseDown](events#onstockchartmousedown)
* [OnStockChartMouseLeave](events#onstockchartmouseleave)
* [OnStockChartMouseMove](events#onstockchartmousemove)
* [OnStockChartMouseUp](events#onstockchartmouseup)

## OnLoaded

[Loaded](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartEvents.html#Syncfusion_Blazor_Charts_StockChartEvents_Loaded) event triggers after the stock chart is rendered.

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

[OnPointClick](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartEvents.html#Syncfusion_Blazor_Charts_StockChartEvents_OnPointClick) event triggers when a data point is clicked.

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

[PointMoved](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartEvents.html#Syncfusion_Blazor_Charts_StockChartEvents_PointMoved) event triggers when the mouse moves over a data point.

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

[RangeChange](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartEvents.html#Syncfusion_Blazor_Charts_StockChartEvents_RangeChange) event triggers when the range is changed.

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

[OnStockChartMouseClick](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartEvents.html#Syncfusion_Blazor_Charts_StockChartEvents_OnStockChartMouseClick) event triggers when a mouse click occurs on the chart surface.

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

[OnStockChartMouseDown](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartEvents.html#Syncfusion_Blazor_Charts_StockChartEvents_OnStockChartMouseDown) event triggers when a mouse button is pressed on the chart.

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

[OnStockChartMouseLeave](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartEvents.html#Syncfusion_Blazor_Charts_StockChartEvents_OnStockChartMouseLeave) event triggers when the mouse pointer leaves the chart area.

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

[OnStockChartMouseMove](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartEvents.html#Syncfusion_Blazor_Charts_StockChartEvents_OnStockChartMouseMove) event triggers when the mouse moves over the chart.

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

[OnStockChartMouseUp](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartEvents.html#Syncfusion_Blazor_Charts_StockChartEvents_OnStockChartMouseUp) event triggers when a pressed mouse button is released over the chart.

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
