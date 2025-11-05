---
layout: post
title: Events in Blazor Stock Chart Component | Syncfusion
description: Checkout and learn here all about events in Syncfusion Blazor Stock Chart component and much more details.
platform: Blazor
control: Stock Chart 
documentation: ug
---

# Events in Blazor Stock Chart Component

In this section, the list of events of Stock Chart component is provided which will be triggered for appropriate stock chart actions. The events should be provided to the Stock Chart using **StockChartEvents** component.

The following are the number of events supported for Stock Chart component.

* [OnLoaded](events#Onloaded)
* [OnPointClick](events#onpointclick)
* [PointMoved](events#pointmoved)
* [RangeChange](events#rangechange)
* [OnStockChartMouseClick](events#onstockchartmouseclick)
* [OnStockChartMouseDown](events#onstockchartmousedown)
* [OnStockChartMouseLeave](events#onstockchartmouseleave)
* [OnStockChartMouseMove](events#onstockchartmousemove)
* [OnStockChartMouseUp](events#onstockchartmouseup)

## OnLoaded

[Loaded](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartEvents.html#Syncfusion_Blazor_Charts_StockChartEvents_Loaded) event triggers after stock chart is rendered.

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
        public DateTime Date {get; set;}
        public Double Y {get; set;}
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

[OnPointClick](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartEvents.html#Syncfusion_Blazor_Charts_StockChartEvents_OnPointClick) event triggers when data point is clicked.

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
        public DateTime Date {get; set;}
        public Double Y {get; set;}
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

[RangeChange](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartEvents.html#Syncfusion_Blazor_Charts_StockChartEvents_RangeChange) event triggers when range is changed.

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
        public DateTime Date {get; set;}
        public Double Y {get; set;}
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