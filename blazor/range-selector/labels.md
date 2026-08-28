---
layout: post
title: Blazor Range Selector Labels Examples and Overview | Syncfusion®
description: Learn how to configure labels in Syncfusion Blazor Range Selector, including multi-level labels, format, and LabelPosition options.
platform: Blazor
control: Range Selector
documentation: ug
---

# Blazor Range Selector Labels

The Range Selector axis labels can be grouped into multiple levels, positioned inside or outside, prevented from overlapping, and styled.

## Multi-level labels

The multi-level labels for the Range Selector can be enabled by setting the [EnableGrouping](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfRangeNavigator.html#Syncfusion_Blazor_Charts_SfRangeNavigator_EnableGrouping) property to **true**. This is applicable only to the DateTime axis. The label levels are derived from the [IntervalType](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfRangeNavigator.html#Syncfusion_Blazor_Charts_SfRangeNavigator_IntervalType) and [ValueType](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfRangeNavigator.html#Syncfusion_Blazor_Charts_SfRangeNavigator_ValueType) properties.

```cshtml

@using Syncfusion.Blazor.Charts

<SfRangeNavigator DataSource="@StockInfo" XName="X" YName="Y" LabelPosition="AxisPosition.Outside"
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

![Blazor RangeNavigator with Multilevel Labels](images/labels/blazor-rangenavigator-multilevel-labels.webp)

## Grouping

The multi-level labels can be grouped using the [GroupBy](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfRangeNavigator.html#Syncfusion_Blazor_Charts_SfRangeNavigator_GroupBy) property with the following [RangeIntervalType](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.RangeIntervalType.html) values:

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

![Grouping in Blazor RangeNavigator](images/labels/blazor-rangenavigator-grouping.webp)

## Smart labels

The [LabelIntersectAction](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfRangeNavigator.html#Syncfusion_Blazor_Charts_SfRangeNavigator_LabelIntersectAction) property is used to prevent labels from overlapping. It accepts the following [RangeLabelIntersectAction](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.RangeLabelIntersectAction.html) values:

* `None` - Shows all labels, even when they overlap. This is the default.
* `Hide` - Hides labels that intersect with a previous label.

The following code sample sets the `LabelIntersectAction` property to `Hide`.

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

![Blazor RangeNavigator with Smart Labels](images/labels/blazor-rangenavigator-smart-labels.webp)

## Position

By default, the labels are placed outside the Range Selector. They can also be placed inside the Range Selector by setting the [LabelPosition](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfRangeNavigator.html#Syncfusion_Blazor_Charts_SfRangeNavigator_LabelPosition) property to [AxisPosition.Inside](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AxisPosition.html).

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

![Changing Label Position in Blazor RangeNavigator](images/labels/blazor-rangenavigator-change-label-position.webp)

## Labels customization

Label properties can be customized using the [RangeNavigatorLabelStyle](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.RangeNavigatorLabelStyle.html) setting, which exposes the [Color](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCommonFont.html#Syncfusion_Blazor_Charts_ChartCommonFont_Color), [Size](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCommonFont.html#Syncfusion_Blazor_Charts_ChartCommonFont_Size), [FontFamily](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCommonFont.html#Syncfusion_Blazor_Charts_ChartCommonFont_FontFamily), [FontStyle](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCommonFont.html#Syncfusion_Blazor_Charts_ChartCommonFont_FontStyle), [FontWeight](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCommonFont.html#Syncfusion_Blazor_Charts_ChartCommonFont_FontWeight), and [Opacity](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCommonFont.html#Syncfusion_Blazor_Charts_ChartCommonFont_Opacity) properties.

```cshtml

@using Syncfusion.Blazor.Charts

<SfRangeNavigator DataSource="@StockInfo" XName="X" YName="Y" Value="@Value" LabelFormat="MMM"
                  IntervalType="RangeIntervalType.Months" ValueType="RangeValueType.DateTime">
    <RangeNavigatorLabelStyle Color="red" Size="10px"></RangeNavigatorLabelStyle>
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

![Blazor RangeNavigator with Custom Label](images/labels/blazor-rangenavigator-custom-label.webp)

## See Also

* [Type of Data](./data)
* [Grid and Tick Lines](./grid-tick)