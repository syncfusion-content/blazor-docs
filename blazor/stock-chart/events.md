---
layout: post
title: Events in Blazor Stock Chart Component | Syncfusion
description: Learn here all about Events in Syncfusion Blazor Stock Chart component and more.
platform: Blazor
control: Stock Chart 
documentation: ug
---

# Events in Blazor Stock Chart Component

In this section, we have provided the list of events of Stock Chart component which will be
triggered for appropriate stock chart actions.

The events should be provided to the Stock Chart using **StockChartEvents** component.

The following are the number of events supported for Stock Chart component.

* [Loaded](events/#loaded)
* [OnPointClick](events/#onpointclick)
* [PointMoved](events/#pointmoved)
* [RangeChange](events/#rangechange)
* [OnStockChartMouseClick](events/#onstockchartmouseclick)
* [OnStockChartMouseDown](events/#onstockchartmousedown)
* [OnStockChartMouseLeave](events/#onstockchartmouseleave)
* [OnStockChartMouseMove](events/#onstockchartmousemove)
* [OnStockChartMouseUp](events/#onstockchartmouseup)

## Loaded

[`Loaded`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartEvents.html#Syncfusion_Blazor_Charts_StockChartEvents_Loaded) event triggers after stock chart is rendered.

```cshtml
@using Syncfusion.Blazor.Charts

<SfStockChart>
    <StockChartEvents Loaded="StockChartLoaded"></StockChartEvents>
    <StockChartSeriesCollection>
        <StockChartSeries DataSource="@StockDetails" Type="ChartSeriesType.Column" XName="Date" YName="Y">
        </StockChartSeries>
    </StockChartSeriesCollection>
</SfStockChart>

@code {

    public void StockChartLoaded(IStockChartEventArgs args)
    {
        // Here you can customize your code
    }

    public class ChartData
    {
        public DateTime Date;
        public Double Y;
    }

    public List<ChartData> StockDetails = new List<ChartData>
{
         new ChartData { Date = new DateTime(2012, 04, 02), Y= 100},
         new ChartData { Date = new DateTime(2012, 04, 09), Y= 10 },
         new ChartData { Date = new DateTime(2012, 04, 16), Y= 500},
         new ChartData { Date = new DateTime(2012, 04, 23), Y= 80 },
         new ChartData { Date = new DateTime(2012, 04, 30), Y= 200},
         new ChartData { Date = new DateTime(2012, 05, 07), Y= 600},
         new ChartData { Date = new DateTime(2012, 05, 14), Y= 50 },
         new ChartData { Date = new DateTime(2012, 05, 21), Y= 700},
         new ChartData { Date = new DateTime(2012, 05, 28), Y= 90 }
   };
}
```

## OnPointClick

[`OnPointClick`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartEvents.html#Syncfusion_Blazor_Charts_StockChartEvents_OnPointClick) event triggers when data point is clicked.

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

    public void PointClick(IPointEventArgs args)
    {
        // Here you can customize your code
    }

    public class ChartData
    {
        public DateTime Date;
        public Double Y;
    }

    public List<ChartData> StockDetails = new List<ChartData>
{
         new ChartData { Date = new DateTime(2012, 04, 02), Y= 100},
         new ChartData { Date = new DateTime(2012, 04, 09), Y= 10 },
         new ChartData { Date = new DateTime(2012, 04, 16), Y= 500},
         new ChartData { Date = new DateTime(2012, 04, 23), Y= 80 },
         new ChartData { Date = new DateTime(2012, 04, 30), Y= 200},
         new ChartData { Date = new DateTime(2012, 05, 07), Y= 600},
         new ChartData { Date = new DateTime(2012, 05, 14), Y= 50 },
         new ChartData { Date = new DateTime(2012, 05, 21), Y= 700},
         new ChartData { Date = new DateTime(2012, 05, 28), Y= 90 }
   };
}
```

## PointMoved

[`PointMoved`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartEvents.html#Syncfusion_Blazor_Charts_StockChartEvents_PointMoved) event triggers when moving mouse over the data point.

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

    public void OnPointMoved(IPointEventArgs args)
    {
        // Here you can customize your code
    }

    public class ChartData
    {
        public DateTime Date;
        public Double Y;
    }

    public List<ChartData> StockDetails = new List<ChartData>
{
         new ChartData { Date = new DateTime(2012, 04, 02), Y= 100},
         new ChartData { Date = new DateTime(2012, 04, 09), Y= 10 },
         new ChartData { Date = new DateTime(2012, 04, 16), Y= 500},
         new ChartData { Date = new DateTime(2012, 04, 23), Y= 80 },
         new ChartData { Date = new DateTime(2012, 04, 30), Y= 200},
         new ChartData { Date = new DateTime(2012, 05, 07), Y= 600},
         new ChartData { Date = new DateTime(2012, 05, 14), Y= 50 },
         new ChartData { Date = new DateTime(2012, 05, 21), Y= 700},
         new ChartData { Date = new DateTime(2012, 05, 28), Y= 90 }
   };
}
```

## RangeChange

[`RangeChange`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartEvents.html#Syncfusion_Blazor_Charts_StockChartEvents_RangeChange) event triggers when range is changed.

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

    public void RangeChanged(IRangeChangeEventArgs args)
    {
        // Here you can customize your code
    }

    public class ChartData
    {
        public DateTime Date;
        public Double Y;
    }

    public List<ChartData> StockDetails = new List<ChartData>
{
         new ChartData { Date = new DateTime(2012, 04, 02), Y= 100},
         new ChartData { Date = new DateTime(2012, 04, 09), Y= 10 },
         new ChartData { Date = new DateTime(2012, 04, 16), Y= 500},
         new ChartData { Date = new DateTime(2012, 04, 23), Y= 80 },
         new ChartData { Date = new DateTime(2012, 04, 30), Y= 200},
         new ChartData { Date = new DateTime(2012, 05, 07), Y= 600},
         new ChartData { Date = new DateTime(2012, 05, 14), Y= 50 },
         new ChartData { Date = new DateTime(2012, 05, 21), Y= 700},
         new ChartData { Date = new DateTime(2012, 05, 28), Y= 90 }
   };
}
```

## OnStockChartMouseClick

[`OnStockChartMouseClick`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartEvents.html#Syncfusion_Blazor_Charts_StockChartEvents_OnStockChartMouseClick) event triggers when clicking the stock chart.

```cshtml
@using Syncfusion.Blazor.Charts

<SfStockChart>
    <StockChartEvents OnStockChartMouseClick="StockChartMouseClickHandler"></StockChartEvents>
    <StockChartSeriesCollection>
        <StockChartSeries DataSource="@StockDetails" Type="ChartSeriesType.Column" XName="Date" YName="Y">
        </StockChartSeries>
    </StockChartSeriesCollection>
</SfStockChart>

@code {

    public void StockChartMouseClickHandler(IMouseEventArgs args)
    {
        // Here you can customize your code
    }

    public class ChartData
    {
        public DateTime Date;
        public Double Y;
    }

    public List<ChartData> StockDetails = new List<ChartData>
{
         new ChartData { Date = new DateTime(2012, 04, 02), Y= 100},
         new ChartData { Date = new DateTime(2012, 04, 09), Y= 10 },
         new ChartData { Date = new DateTime(2012, 04, 16), Y= 500},
         new ChartData { Date = new DateTime(2012, 04, 23), Y= 80 },
         new ChartData { Date = new DateTime(2012, 04, 30), Y= 200},
         new ChartData { Date = new DateTime(2012, 05, 07), Y= 600},
         new ChartData { Date = new DateTime(2012, 05, 14), Y= 50 },
         new ChartData { Date = new DateTime(2012, 05, 21), Y= 700},
         new ChartData { Date = new DateTime(2012, 05, 28), Y= 90 }
   };
}
```

## OnStockChartMouseDown

[`OnStockChartMouseDown`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartEvents.html#Syncfusion_Blazor_Charts_StockChartEvents_OnStockChartMouseDown) event triggers when mouse down over the stock chart.

```cshtml
@using Syncfusion.Blazor.Charts

<SfStockChart>
    <StockChartEvents OnStockChartMouseDown="StockChartMouseDownHandler"></StockChartEvents>
    <StockChartSeriesCollection>
        <StockChartSeries DataSource="@StockDetails" Type="ChartSeriesType.Column" XName="Date" YName="Y">
        </StockChartSeries>
    </StockChartSeriesCollection>
</SfStockChart>

@code {

    public void StockChartMouseDownHandler(IMouseEventArgs args)
    {
        // Here you can customize your code
    }

    public class ChartData
    {
        public DateTime Date;
        public Double Y;
    }

    public List<ChartData> StockDetails = new List<ChartData>
{
         new ChartData { Date = new DateTime(2012, 04, 02), Y= 100},
         new ChartData { Date = new DateTime(2012, 04, 09), Y= 10 },
         new ChartData { Date = new DateTime(2012, 04, 16), Y= 500},
         new ChartData { Date = new DateTime(2012, 04, 23), Y= 80 },
         new ChartData { Date = new DateTime(2012, 04, 30), Y= 200},
         new ChartData { Date = new DateTime(2012, 05, 07), Y= 600},
         new ChartData { Date = new DateTime(2012, 05, 14), Y= 50 },
         new ChartData { Date = new DateTime(2012, 05, 21), Y= 700},
         new ChartData { Date = new DateTime(2012, 05, 28), Y= 90 }
   };
}
```

## OnStockChartMouseLeave

[`OnStockChartMouseLeave`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartEvents.html#Syncfusion_Blazor_Charts_StockChartEvents_OnStockChartMouseLeave) event triggers when cursor leaves the stock chart.

```cshtml
@using Syncfusion.Blazor.Charts

<SfStockChart>
    <StockChartEvents OnStockChartMouseLeave="StockChartMouseLeaveHandler"></StockChartEvents>
    <StockChartSeriesCollection>
        <StockChartSeries DataSource="@StockDetails" Type="ChartSeriesType.Column" XName="Date" YName="Y">
        </StockChartSeries>
    </StockChartSeriesCollection>
</SfStockChart>

@code {

    public void StockChartMouseLeaveHandler(IMouseEventArgs args)
    {
        // Here you can customize your code
    }

    public class ChartData
    {
        public DateTime Date;
        public Double Y;
    }

    public List<ChartData> StockDetails = new List<ChartData>
{
         new ChartData { Date = new DateTime(2012, 04, 02), Y= 100},
         new ChartData { Date = new DateTime(2012, 04, 09), Y= 10 },
         new ChartData { Date = new DateTime(2012, 04, 16), Y= 500},
         new ChartData { Date = new DateTime(2012, 04, 23), Y= 80 },
         new ChartData { Date = new DateTime(2012, 04, 30), Y= 200},
         new ChartData { Date = new DateTime(2012, 05, 07), Y= 600},
         new ChartData { Date = new DateTime(2012, 05, 14), Y= 50 },
         new ChartData { Date = new DateTime(2012, 05, 21), Y= 700},
         new ChartData { Date = new DateTime(2012, 05, 28), Y= 90 }
   };
}
```

## OnStockChartMouseMove

[`OnStockChartMouseMove`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartEvents.html#Syncfusion_Blazor_Charts_StockChartEvents_OnStockChartMouseMove) event triggers when hovering the stock chart.

```cshtml
@using Syncfusion.Blazor.Charts

<SfStockChart>
    <StockChartEvents OnStockChartMouseMove="StockChartMouseMoveHandler"></StockChartEvents>
    <StockChartSeriesCollection>
        <StockChartSeries DataSource="@StockDetails" Type="ChartSeriesType.Column" XName="Date" YName="Y">
        </StockChartSeries>
    </StockChartSeriesCollection>
</SfStockChart>

@code {

    public void StockChartMouseMoveHandler(IMouseEventArgs args)
    {
        // Here you can customize your code
    }

    public class ChartData
    {
        public DateTime Date;
        public Double Y;
    }

    public List<ChartData> StockDetails = new List<ChartData>
{
         new ChartData { Date = new DateTime(2012, 04, 02), Y= 100},
         new ChartData { Date = new DateTime(2012, 04, 09), Y= 10 },
         new ChartData { Date = new DateTime(2012, 04, 16), Y= 500},
         new ChartData { Date = new DateTime(2012, 04, 23), Y= 80 },
         new ChartData { Date = new DateTime(2012, 04, 30), Y= 200},
         new ChartData { Date = new DateTime(2012, 05, 07), Y= 600},
         new ChartData { Date = new DateTime(2012, 05, 14), Y= 50 },
         new ChartData { Date = new DateTime(2012, 05, 21), Y= 700},
         new ChartData { Date = new DateTime(2012, 05, 28), Y= 90 }
   };
}
```

## OnStockChartMouseUp

[`OnStockChartMouseUp`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartEvents.html#Syncfusion_Blazor_Charts_StockChartEvents_OnStockChartMouseUp) event triggers when mouse is up.

```cshtml
@using Syncfusion.Blazor.Charts

<SfStockChart>
    <StockChartEvents OnStockChartMouseUp="StockChartMouseUpHandler"></StockChartEvents>
    <StockChartSeriesCollection>
        <StockChartSeries DataSource="@StockDetails" Type="ChartSeriesType.Column" XName="Date" YName="Y">
        </StockChartSeries>
    </StockChartSeriesCollection>
</SfStockChart>

@code {

    public void StockChartMouseUpHandler(IMouseEventArgs args)
    {
        // Here you can customize your code
    }

    public class ChartData
    {
        public DateTime Date;
        public Double Y;
    }

    public List<ChartData> StockDetails = new List<ChartData>
{
         new ChartData { Date = new DateTime(2012, 04, 02), Y= 100},
         new ChartData { Date = new DateTime(2012, 04, 09), Y= 10 },
         new ChartData { Date = new DateTime(2012, 04, 16), Y= 500},
         new ChartData { Date = new DateTime(2012, 04, 23), Y= 80 },
         new ChartData { Date = new DateTime(2012, 04, 30), Y= 200},
         new ChartData { Date = new DateTime(2012, 05, 07), Y= 600},
         new ChartData { Date = new DateTime(2012, 05, 14), Y= 50 },
         new ChartData { Date = new DateTime(2012, 05, 21), Y= 700},
         new ChartData { Date = new DateTime(2012, 05, 28), Y= 90 }
   };
}
```