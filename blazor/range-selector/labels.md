---
layout: post
title: Labels in Blazor Range Selector Component | Syncfusion
description: Check out and learn how to configure and customize labels in Syncfusion Blazor Range Selector component.
platform: Blazor
control: Range Selector
documentation: ug
---

# Labels in Blazor Range Selector Component

## Multi-level Labels

Enable multi-level labels by setting the [EnableGrouping](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfRangeNavigator.html#Syncfusion_Blazor_Charts_SfRangeNavigator_EnableGrouping) property to **true**. This feature is available only for the DateTime axis.

```cshtml

@using Syncfusion.Blazor.Charts

<SfRangeNavigator DataSource="@StockInfo" XName="X" YName="Y"      LabelPosition="AxisPosition.Outside"
                  EnableGrouping="true" IntervalType="RangeIntervalType.Quarter" Value="@Value" ValueType="RangeValueType.DateTime">
    <RangeNavigatorRangeTooltipSettings Enable="true"></RangeNavigatorRangeTooltipSettings>
</SfRangeNavigator>

@code {
    public class StockDetails
    {
        public DateTime X { get; set; }
        public double Y { get; set; }
    }

    public DateTime[] Value = new DateTime[] { new DateTime(2005, 11, 01), new DateTime(2006, 01, 01) };

    public List<StockDetails> StockInfo = new List<StockDetails> {
        new StockDetails { X = new DateTime(2005, 01, 01), Y = 21 },
        new StockDetails { X = new DateTime(2005, 03, 01), Y = 24 },
        new StockDetails { X = new DateTime(2005, 05, 01), Y = 36 },
        new StockDetails { X = new DateTime(2006, 07, 01), Y = 38 },
        new StockDetails { X = new DateTime(2006, 08, 01), Y = 54 },
        new StockDetails { X = new DateTime(2006, 09, 01), Y = 57 },
        new StockDetails { X = new DateTime(2006, 11, 01), Y = 70 }
    };
}

```

![Blazor RangeNavigator with Multilevel Labels](images/labels/blazor-rangenavigator-multilevel-labels.png)

## Grouping

Group multi-level labels using the [GroupBy](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfRangeNavigator.html#Syncfusion_Blazor_Charts_SfRangeNavigator_GroupBy) property. Supported interval types:

* Auto
* Years
* Quarter
* Months
* Weeks
* Days
* Hours
* Minutes
* Seconds

```cshtml

@using Syncfusion.Blazor.Charts

<SfRangeNavigator DataSource="@StockInfo" XName="X" YName="Y" LabelPosition="AxisPosition.Outside"
                  EnableGrouping="true" GroupBy="RangeIntervalType.Years" IntervalType="RangeIntervalType.Quarter"
                  Value="@Value" ValueType="RangeValueType.DateTime">
    <RangeNavigatorRangeTooltipSettings Enable="true"></RangeNavigatorRangeTooltipSettings>
</SfRangeNavigator>

@code {
    public class StockDetails
    {
        public DateTime X { get; set; }
        public double Y { get; set; }
    }

    public DateTime[] Value = new DateTime[] { new DateTime(2005, 11, 01), new DateTime(2006, 01, 01) };

    public List<StockDetails> StockInfo = new List<StockDetails> {
        new StockDetails { X = new DateTime(2005, 01, 01), Y = 21 },
        new StockDetails { X = new DateTime(2005, 03, 01), Y = 24 },
        new StockDetails { X = new DateTime(2005, 05, 01), Y = 36 },
        new StockDetails { X = new DateTime(2006, 07, 01), Y = 38 },
        new StockDetails { X = new DateTime(2006, 08, 01), Y = 54 },
        new StockDetails { X = new DateTime(2006, 09, 01), Y = 57 },
        new StockDetails { X = new DateTime(2006, 11, 01), Y = 70 }
    };
}

```

![Grouping in Blazor RangeNavigator](images/labels/blazor-rangenavigator-grouping.png)

## Smart Labels

Use the [LabelIntersectAction](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfRangeNavigator.html#Syncfusion_Blazor_Charts_SfRangeNavigator_LabelIntersectAction) property to avoid label overlap. For example, set it to **Hide** to hide overlapping labels.

```cshtml

@using Syncfusion.Blazor.Charts

<SfRangeNavigator Value="@Value" ValueType="RangeValueType.DateTime" LabelFormat="yyyy/M/d" LabelIntersectAction="RangeLabelIntersectAction.Hide">
    <RangeNavigatorRangeTooltipSettings Enable="true"></RangeNavigatorRangeTooltipSettings>
    <RangeNavigatorSeriesCollection>
        <RangeNavigatorSeries DataSource="@DataSource" XName="X" Type="RangeNavigatorType.StepLine"
                              YName="Y" Width="2"></RangeNavigatorSeries>
    </RangeNavigatorSeriesCollection>
</SfRangeNavigator>

@code {
    public class SampleData
    {
        public DateTime X { get; set; }
        public double Y { get; set; }
    }

    public DateTime[] Value = new DateTime[] { new DateTime(2006, 01, 01), new DateTime(2008, 01, 01) };

    public List<SampleData> DataSource = new List<SampleData> {
        new SampleData { X = new DateTime(2005, 01, 01), Y = 21 },
        new SampleData { X = new DateTime(2006, 01, 01), Y = 24 },
        new SampleData { X = new DateTime(2007, 01, 01), Y = 36 },
        new SampleData { X = new DateTime(2008, 01, 01), Y = 38 },
        new SampleData { X = new DateTime(2009, 01, 01), Y = 54 },
        new SampleData { X = new DateTime(2010, 01, 01), Y = 57 },
        new SampleData { X = new DateTime(2011, 01, 01), Y = 70 }
    };
}

```

![Blazor RangeNavigator with Smart Labels](images/labels/blazor-rangenavigator-smart-labels.png)

## Position

Labels are placed **outside** the Range Selector by default. Use the [LabelPosition](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfRangeNavigator.html#Syncfusion_Blazor_Charts_SfRangeNavigator_LabelPosition) property to place them inside if needed.

```cshtml

@using Syncfusion.Blazor.Charts

<SfRangeNavigator Value="@Value" ValueType="RangeValueType.DateTime" LabelPosition="AxisPosition.Inside">
    <RangeNavigatorSeriesCollection>
        <RangeNavigatorSeries DataSource="@StockInfo" XName="X" Type="RangeNavigatorType.StepLine" YName="Y">
        </RangeNavigatorSeries>
    </RangeNavigatorSeriesCollection>
</SfRangeNavigator>

@code {
    public class StockDetails
    {
        public DateTime X { get; set; }
        public double Y { get; set; }
    }
    
    public DateTime[] Value = new DateTime[] { new DateTime(2006, 01, 01), new DateTime(2008, 01, 01) };

    public List<StockDetails> StockInfo = new List<StockDetails> {
        new StockDetails { X = new DateTime(2005, 01, 01), Y = 21 },
        new StockDetails { X = new DateTime(2006, 01, 01), Y = 24 },
        new StockDetails { X = new DateTime(2007, 01, 01), Y = 36 },
        new StockDetails { X = new DateTime(2008, 01, 01), Y = 38 },
        new StockDetails { X = new DateTime(2009, 01, 01), Y = 54 },
        new StockDetails { X = new DateTime(2010, 01, 01), Y = 57 },
        new StockDetails { X = new DateTime(2011, 01, 01), Y = 70 }
    };
}

```

![Changing Label Position in Blazor RangeNavigator](images/labels/blazor-rangenavigator-change-label-position.png)

## Labels Customization

Customize label font size, color, family, and more using the [RangeNavigatorLabelStyle](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.RangeNavigatorLabelStyle.html) setting.

```cshtml

@using Syncfusion.Blazor.Charts

<SfRangeNavigator DataSource="@StockInfo" XName="X" YName="Y" Value="@Value" LabelFormat="MMM"
                  IntervalType="RangeIntervalType.Months" ValueType="RangeValueType.DateTime">
    <RangeNavigatorLabelStyle Color="red" Size="10"></RangeNavigatorLabelStyle>
</SfRangeNavigator>

@code {
    public class StockDetails
    {
        public DateTime X { get; set; }
        public double Y { get; set; }
    }

    public DateTime[] Value = new DateTime[] { new DateTime(2005, 11, 01), new DateTime(2006, 01, 01) };

    public List<StockDetails> StockInfo = new List<StockDetails> {
        new StockDetails { X = new DateTime(2005, 01, 01), Y = 21 },
        new StockDetails { X = new DateTime(2005, 03, 01), Y = 24 },
        new StockDetails { X = new DateTime(2005, 05, 01), Y = 36 },
        new StockDetails { X = new DateTime(2006, 07, 01), Y = 38 },
        new StockDetails { X = new DateTime(2006, 08, 01), Y = 54 },
        new StockDetails { X = new DateTime(2006, 09, 01), Y = 57 },
        new StockDetails { X = new DateTime(2006, 11, 01), Y = 70 }
    };
}

```

![Blazor RangeNavigator with Custom Label](images/labels/blazor-rangenavigator-custom-label.png)
