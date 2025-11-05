---
layout: post
title: Grid Lines and Tick Lines in Blazor Range Selector | Syncfusion
description: Learn here all about grid lines and tick lines in Syncfusion Blazor Range Selector component, it's elements and more.
platform: Blazor
control: Range Selector
documentation: ug
---

# Grid Lines and Tick Lines in Blazor Range Selector Component

## Gridline Customization

The gridlines indicate axis divisions by drawing the chart plot. Gridlines include helpful cues to the user, particularly for large or complicated charts. The [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCommonMajorGridLines.html#Syncfusion_Blazor_Charts_ChartCommonMajorGridLines_Width), [Color](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCommonMajorGridLines.html#Syncfusion_Blazor_Charts_ChartCommonMajorGridLines_Color), and [DashArray](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCommonMajorGridLines.html#Syncfusion_Blazor_Charts_ChartCommonMajorGridLines_DashArray) of the major gridlines can be customized by using the [RangeNavigatorMajorGridLines](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.RangeNavigatorMajorGridLines.html) setting.

```cshtml

@using Syncfusion.Blazor.Charts

<SfRangeNavigator Value="@Value" ValueType="RangeValueType.Double">
    <RangeNavigatorMajorGridLines Color="Blue" Width="4" DashArray="5,5"></RangeNavigatorMajorGridLines>
    <RangeNavigatorSeriesCollection>
        <RangeNavigatorSeries DataSource="@StockInfo" XName="Date" Type="RangeNavigatorType.StepLine" YName="Close">
        </RangeNavigatorSeries>
    </RangeNavigatorSeriesCollection>
</SfRangeNavigator>

@code {

    public class StockDetails
    {
        public double Date { get; set; }
        public double Close { get; set; }
    }

    public int[] Value = new int[] { 25, 40 };

    public List<StockDetails> StockInfo = new List<StockDetails> {
        new StockDetails { Date= 10, Close= 35 },
        new StockDetails { Date= 20, Close= 28 },
        new StockDetails { Date= 30, Close= 34 },
        new StockDetails { Date= 40, Close= 32 },
        new StockDetails { Date= 50, Close= 40 }
    };
}

```

![Blazor RangeNavigator with grid line](images/grid-tick/blazor-rangenavigator-grid-line.png)

## Tickline Customization

Ticklines are the small lines which is drawn on the axis line representing the axis labels. Ticklines will be drawn outside the axis by default. The [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCommonMajorTickLines.html#Syncfusion_Blazor_Charts_ChartCommonMajorTickLines_Width), [Color](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCommonMajorTickLines.html#Syncfusion_Blazor_Charts_ChartCommonMajorTickLines_Color), and [Height](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCommonMajorTickLines.html#Syncfusion_Blazor_Charts_ChartCommonMajorTickLines_Height) of the major ticklines can be customized by using the [RangeNavigatorMajorTickLines](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.RangeNavigatorMajorTickLines.html) setting.

```cshtml

@using Syncfusion.Blazor.Charts

<SfRangeNavigator Value="@Value" ValueType="RangeValueType.Double">
    <RangeNavigatorMajorTickLines Color="Red" Width="3"></RangeNavigatorMajorTickLines>
    <RangeNavigatorSeriesCollection>
        <RangeNavigatorSeries DataSource="@StockInfo" XName="Date" Type="RangeNavigatorType.StepLine" YName="Close">
        </RangeNavigatorSeries>
    </RangeNavigatorSeriesCollection>
</SfRangeNavigator>

@code {

    public class StockDetails
    {
        public double Date { get; set; }
        public double Close { get; set; }
    }

    public int[] Value = new int[] { 25, 40 };

    public List<StockDetails> StockInfo = new List<StockDetails> {
        new StockDetails { Date= 10, Close= 35 },
        new StockDetails { Date= 20, Close= 28 },
        new StockDetails { Date= 30, Close= 34 },
        new StockDetails { Date= 40, Close= 32 },
        new StockDetails { Date= 50, Close= 40 }
    };
}

```

![Blazor RangeNavigator with tick line](images/grid-tick/blazor-rangenavigator-tick-line.png)