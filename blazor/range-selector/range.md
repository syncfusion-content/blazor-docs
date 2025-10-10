---
layout: post
title: Range in Blazor Range Selector Component | Syncfusion
description: Check out and learn here all about ranges in Syncfusion Blazor Range Selector component and much more.
platform: Blazor
control: Range Selector
documentation: ug
---

# Range in Blazor Range Selector Component

The Range Selector's left and right thumbs indicate the selected range in a large data collection. A range can be selected in the following ways:

* Dragging the thumbs
* Tapping on the labels
* Setting the start and end through the [Value](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfRangeNavigator.html#Syncfusion_Blazor_Charts_SfRangeNavigator_Value) property

<!-- markdownlint-disable MD036 -->

## Value Binding

This section describes how to bind values to the Range Selector component:

* One-way binding
* Two-way binding

### One-way Binding

Use the [Value](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfRangeNavigator.html#Syncfusion_Blazor_Charts_SfRangeNavigator_Value) property directly as an object or from code-behind for the Range Selector.

```cshtml

@using Syncfusion.Blazor.Charts

<SfRangeNavigator Value="@Value" ValueType="RangeValueType.DateTime"
                  LabelFormat="MMM-yy" IntervalType="RangeIntervalType.Years" Interval="1">
    <RangeNavigatorRangeTooltipSettings Enable="true"></RangeNavigatorRangeTooltipSettings>
    <RangeNavigatorSeriesCollection>
        <RangeNavigatorSeries DataSource="@StockInfo" XName="Date" Type="RangeNavigatorType.Area" YName="Close">
        </RangeNavigatorSeries>
    </RangeNavigatorSeriesCollection>
</SfRangeNavigator>

@code {
    public class StockDetails
    {
        public DateTime Date { get; set; }
        public double Close { get; set; }
    }

    public DateTime[] Value = new DateTime[] { new DateTime(2009, 01, 01), new DateTime(2010, 01, 01) };

    public List<StockDetails> StockInfo = new List<StockDetails>
    {
        new StockDetails { Date = new DateTime(2005, 01, 01), Close = 21 },
        new StockDetails { Date = new DateTime(2006, 01, 01), Close = 24 },
        new StockDetails { Date = new DateTime(2007, 01, 01), Close = 36 },
        new StockDetails { Date = new DateTime(2008, 01, 01), Close = 38 },
        new StockDetails { Date = new DateTime(2009, 01, 01), Close = 54 },
        new StockDetails { Date = new DateTime(2010, 01, 01), Close = 57 },
        new StockDetails { Date = new DateTime(2011, 01, 01), Close = 70 }
    };
}

```

![Selecting Range in Blazor RangeNavigator](images/common/blazor-rangenavigator-range-selection.png)

### Two-way Binding

Use the **@bind-Value** attribute in the Range Selector to achieve two-way binding. The following example demonstrates two-way binding for the Range Selector.

```cshtml

@using Syncfusion.Blazor.Charts

<SfRangeNavigator @bind-Value="@Value" ValueType="RangeValueType.DateTime"
                  LabelFormat="MMM-yy" IntervalType="RangeIntervalType.Years" Interval="1">
    <RangeNavigatorRangeTooltipSettings Enable="true"></RangeNavigatorRangeTooltipSettings>
    <RangeNavigatorSeriesCollection>
        <RangeNavigatorSeries DataSource="@StockInfo" XName="Date" Type="RangeNavigatorType.Area" YName="Close">
        </RangeNavigatorSeries>
    </RangeNavigatorSeriesCollection>
</SfRangeNavigator>

@code {
    public class StockDetails
    {
        public DateTime Date { get; set; }
        public double Close { get; set; }
    }

    public object Value = new DateTime[] { new DateTime(2009, 01, 01), new DateTime(2010, 01, 01) };

    public List<StockDetails> StockInfo = new List<StockDetails>
    {
        new StockDetails { Date = new DateTime(2005, 01, 01), Close = 21 },
        new StockDetails { Date = new DateTime(2006, 01, 01), Close = 24 },
        new StockDetails { Date = new DateTime(2007, 01, 01), Close = 36 },
        new StockDetails { Date = new DateTime(2008, 01, 01), Close = 38 },
        new StockDetails { Date = new DateTime(2009, 01, 01), Close = 54 },
        new StockDetails { Date = new DateTime(2010, 01, 01), Close = 57 },
        new StockDetails { Date = new DateTime(2011, 01, 01), Close = 70 }
    };
}

```

![Selecting Range in Blazor RangeNavigator](images/common/blazor-rangenavigator-range-selection.png)
