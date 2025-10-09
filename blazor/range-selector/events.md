---
layout: post
title: Events in Blazor Range Selector Component | Syncfusion
description: Check out and learn about all available events and event handling in the Syncfusion Blazor Range Selector component.
platform: Blazor
control: Range Selector
documentation: ug
---

# Events in Blazor Range Selector Component

This section describes the events triggered by the Range Selector component. Events are provided through the **RangeNavigatorEvents** component.

Supported events:

* [Loaded](events#loaded)
* [OnPrintCompleted](events#onprintcompleted)
* [Changed](events#changed)
* [Resized](events#resized)
* [LabelRender](events#labelrender)
* [TooltipRender](events#tooltiprender)
* [SelectorRender](events#selectorrender)

## Loaded

The [Loaded](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.RangeNavigatorEvents.html#Syncfusion_Blazor_Charts_RangeNavigatorEvents_Loaded) event triggers after the Range Selector is rendered.

```cshtml

@using Syncfusion.Blazor.Charts

<SfRangeNavigator Value="@Value" ValueType="RangeValueType.DateTime" IntervalType="RangeIntervalType.Years">
    <RangeNavigatorEvents Loaded="RangeNavigatorLoaded"></RangeNavigatorEvents>
    <RangeNavigatorSeriesCollection>
        <RangeNavigatorSeries DataSource="@StockInfo" XName="Date" Type="RangeNavigatorType.Line" YName="Close">
        </RangeNavigatorSeries>
    </RangeNavigatorSeriesCollection>
</SfRangeNavigator>

@code {
    public class StockDetails
    {
        public DateTime Date { get; set; }
        public double Close { get; set; }
    }

    public List<StockDetails> StockInfo = new List<StockDetails> {
        new StockDetails { Date = new DateTime(2005, 01, 01), Close = 21 },
        new StockDetails { Date = new DateTime(2006, 01, 01), Close = 24 },
        new StockDetails { Date = new DateTime(2007, 01, 01), Close = 36 },
        new StockDetails { Date = new DateTime(2008, 01, 01), Close = 38 },
        new StockDetails { Date = new DateTime(2009, 01, 01), Close = 54 },
        new StockDetails { Date = new DateTime(2010, 01, 01), Close = 57 },
        new StockDetails { Date = new DateTime(2011, 01, 01), Close = 70 }
    };

    public DateTime[] Value = new DateTime[] {
        new DateTime(2006, 01, 01), new DateTime(2008, 01, 01)
    };

    public void RangeNavigatorLoaded(RangeLoadedEventArgs args)
    {
        // Here you can customize your code.
    }
}

```

## OnPrintCompleted

The [OnPrintCompleted](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.RangeNavigatorEvents.html#Syncfusion_Blazor_Charts_RangeNavigatorEvents_OnPrintCompleted) event triggers after the Range Selector is printed.

```cshtml

@using Syncfusion.Blazor.Charts
@using Syncfusion.Blazor.Buttons

<SfRangeNavigator @ref="RangeObj" Value="@Value" ValueType="RangeValueType.DateTime" IntervalType="RangeIntervalType.Years">
    <RangeNavigatorEvents OnPrintCompleted="PrintCompleted"></RangeNavigatorEvents>
    <RangeNavigatorSeriesCollection>
        <RangeNavigatorSeries DataSource="@StockInfo" XName="Date" Type="RangeNavigatorType.Line" YName="Close">
        </RangeNavigatorSeries>
    </RangeNavigatorSeriesCollection>
</SfRangeNavigator>

<SfButton Id="button" Content="Print" @onclick="@Click" IsPrimary="true" CssClass="e-flat">
</SfButton>

@code {
    public SfRangeNavigator RangeObj;

    public class StockDetails
    {
        public DateTime Date { get; set; }
        public double Close { get; set; }
    }

    public List<StockDetails> StockInfo = new List<StockDetails> {
        new StockDetails { Date = new DateTime(2005, 01, 01), Close = 21 },
        new StockDetails { Date = new DateTime(2006, 01, 01), Close = 24 },
        new StockDetails { Date = new DateTime(2007, 01, 01), Close = 36 },
        new StockDetails { Date = new DateTime(2008, 01, 01), Close = 38 },
        new StockDetails { Date = new DateTime(2009, 01, 01), Close = 54 },
        new StockDetails { Date = new DateTime(2010, 01, 01), Close = 57 },
        new StockDetails { Date = new DateTime(2011, 01, 01), Close = 70 }
    };

    public DateTime[] Value = new DateTime[] {
        new DateTime(2006, 01, 01), new DateTime(2008, 01, 01)
    };

    public async Task Click(MouseEventArgs args)
    {
        await RangeObj.PrintAsync();
    }

    public void PrintCompleted(EventArgs args)
    {
        // Here you can customize your code.
    }
}

```

## Changed

The [Changed](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.RangeNavigatorEvents.html#Syncfusion_Blazor_Charts_RangeNavigatorEvents_Changed) event triggers when the slider position changes. Arguments include:

* [Start](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChangedEventArgs.html#Syncfusion_Blazor_Charts_ChangedEventArgs_Start) - Specifies the start value.
* [End](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChangedEventArgs.html#Syncfusion_Blazor_Charts_ChangedEventArgs_End) - Specifies the end value.
* [ZoomFactor](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChangedEventArgs.html#Syncfusion_Blazor_Charts_ChangedEventArgs_ZoomFactor) - Specifies the zoom factor.
* [ZoomPosition](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChangedEventArgs.html#Syncfusion_Blazor_Charts_ChangedEventArgs_ZoomPosition) - Specifies the zoom position.
* [SelectedData](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChangedEventArgs.html#Syncfusion_Blazor_Charts_ChangedEventArgs_SelectedData) - The selected data collection can be accessed in this argument.

```cshtml

@using Syncfusion.Blazor.Charts

<SfRangeNavigator Value="@Value" ValueType="RangeValueType.DateTime" IntervalType="RangeIntervalType.Years">
    <RangeNavigatorEvents Changed="SliderChanged"></RangeNavigatorEvents>
    <RangeNavigatorSeriesCollection>
        <RangeNavigatorSeries DataSource="@StockInfo" XName="Date" Type="RangeNavigatorType.Line" YName="Close">
        </RangeNavigatorSeries>
    </RangeNavigatorSeriesCollection>
</SfRangeNavigator>

@code {
    public class StockDetails
    {
        public DateTime Date { get; set; }
        public double Close { get; set; }
    }

    public List<StockDetails> StockInfo = new List<StockDetails> {
        new StockDetails { Date = new DateTime(2005, 01, 01), Close = 21 },
        new StockDetails { Date = new DateTime(2006, 01, 01), Close = 24 },
        new StockDetails { Date = new DateTime(2007, 01, 01), Close = 36 },
        new StockDetails { Date = new DateTime(2008, 01, 01), Close = 38 },
        new StockDetails { Date = new DateTime(2009, 01, 01), Close = 54 },
        new StockDetails { Date = new DateTime(2010, 01, 01), Close = 57 },
        new StockDetails { Date = new DateTime(2011, 01, 01), Close = 70 }
    };

    public DateTime[] Value = new DateTime[] {
        new DateTime(2006, 01, 01), new DateTime(2008, 01, 01)
    };

    public void SliderChanged(ChangedEventArgs args)
    {
        // Here you can customize your code.
    }
}

```

## Resized

The [Resized](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.RangeNavigatorEvents.html#Syncfusion_Blazor_Charts_RangeNavigatorEvents_Resized) event triggers when the browser window is resized. Arguments include:

* [CurrentSize](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.RangeResizeEventArgs.html#Syncfusion_Blazor_Charts_RangeResizeEventArgs_CurrentSize) - Specifies the current size for the Range Selector.
* [PreviousSize](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.RangeResizeEventArgs.html#Syncfusion_Blazor_Charts_RangeResizeEventArgs_PreviousSize) - Specifies the previous size for the Range Selector.

```cshtml

@using Syncfusion.Blazor.Charts

<SfRangeNavigator Value="@Value" ValueType="RangeValueType.DateTime" IntervalType="RangeIntervalType.Years">
    <RangeNavigatorEvents Resized="RangeNavigatorResized"></RangeNavigatorEvents>
    <RangeNavigatorSeriesCollection>
        <RangeNavigatorSeries DataSource="@StockInfo" XName="Date" Type="RangeNavigatorType.Line" YName="Close">
        </RangeNavigatorSeries>
    </RangeNavigatorSeriesCollection>
</SfRangeNavigator>

@code {
    public class StockDetails
    {
        public DateTime Date { get; set; }
        public double Close { get; set; }
    }

    public List<StockDetails> StockInfo = new List<StockDetails> {
        new StockDetails { Date = new DateTime(2005, 01, 01), Close = 21 },
        new StockDetails { Date = new DateTime(2006, 01, 01), Close = 24 },
        new StockDetails { Date = new DateTime(2007, 01, 01), Close = 36 },
        new StockDetails { Date = new DateTime(2008, 01, 01), Close = 38 },
        new StockDetails { Date = new DateTime(2009, 01, 01), Close = 54 },
        new StockDetails { Date = new DateTime(2010, 01, 01), Close = 57 },
        new StockDetails { Date = new DateTime(2011, 01, 01), Close = 70 }
    };

    public DateTime[] Value = new DateTime[] {
        new DateTime(2006, 01, 01), new DateTime(2008, 01, 01)
    };

    public void RangeNavigatorResized(RangeResizeEventArgs args)
    {
        // Here you can customize your code.
    }
}

```

## LabelRender

The [LabelRender](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.RangeNavigatorEvents.html#Syncfusion_Blazor_Charts_RangeNavigatorEvents_LabelRender) event triggers before rendering each axis label. Arguments include:

* [Text](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.RangeLabelRenderEventArgs.html#Syncfusion_Blazor_Charts_RangeLabelRenderEventArgs_Text) - Specifies the current axis label text.
* [Value](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.RangeLabelRenderEventArgs.html#Syncfusion_Blazor_Charts_RangeLabelRenderEventArgs_Value) - Specifies the current axis label value.
* [Region](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.RangeLabelRenderEventArgs.html#Syncfusion_Blazor_Charts_RangeLabelRenderEventArgs_Region) - Specifies the current axis label position.
* [LabelStyle](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.RangeLabelRenderEventArgs.html#Syncfusion_Blazor_Charts_RangeLabelRenderEventArgs_LabelStyle) - Specifies the current axis label style.

```cshtml

@using Syncfusion.Blazor.Charts

<SfRangeNavigator Value="@Value" ValueType="RangeValueType.DateTime" IntervalType="RangeIntervalType.Years">
    <RangeNavigatorEvents LabelRender="LabelCustomization"></RangeNavigatorEvents>
    <RangeNavigatorSeriesCollection>
        <RangeNavigatorSeries DataSource="@StockInfo" XName="Date" Type="RangeNavigatorType.Line" YName="Close">
        </RangeNavigatorSeries>
    </RangeNavigatorSeriesCollection>
</SfRangeNavigator>

@code {
    public class StockDetails
    {
        public DateTime Date { get; set; }
        public double Close { get; set; }
    }

    public List<StockDetails> StockInfo = new List<StockDetails> {
        new StockDetails { Date = new DateTime(2005, 01, 01), Close = 21 },
        new StockDetails { Date = new DateTime(2006, 01, 01), Close = 24 },
        new StockDetails { Date = new DateTime(2007, 01, 01), Close = 36 },
        new StockDetails { Date = new DateTime(2008, 01, 01), Close = 38 },
        new StockDetails { Date = new DateTime(2009, 01, 01), Close = 54 },
        new StockDetails { Date = new DateTime(2010, 01, 01), Close = 57 },
        new StockDetails { Date = new DateTime(2011, 01, 01), Close = 70 }
    };

    public DateTime[] Value = new DateTime[] {
        new DateTime(2006, 01, 01), new DateTime(2008, 01, 01)
    };

    public void LabelCustomization(RangeLabelRenderEventArgs args)
    {
        // Here you can customize your code.
    }
}

```

## TooltipRender

The [TooltipRender](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.RangeNavigatorEvents.html#Syncfusion_Blazor_Charts_RangeNavigatorEvents_TooltipRender) event triggers before the tooltip is rendered. Arguments include:

* [Text](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.RangeTooltipRenderEventArgs.html#Syncfusion_Blazor_Charts_RangeTooltipRenderEventArgs_Text) - Specifies the current tooltip text.
* [TextStyle](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.RangeTooltipRenderEventArgs.html#Syncfusion_Blazor_Charts_RangeTooltipRenderEventArgs_TextStyle) - Specifies the current tooltip text style.

```cshtml

@using Syncfusion.Blazor.Charts

<SfRangeNavigator Value="@Value" ValueType="RangeValueType.DateTime" IntervalType="RangeIntervalType.Years">
    <RangeNavigatorEvents TooltipRender="TooltipCustomization"></RangeNavigatorEvents>
    <RangeNavigatorSeriesCollection>
        <RangeNavigatorSeries DataSource="@StockInfo" XName="Date" Type="RangeNavigatorType.Line" YName="Close">
        </RangeNavigatorSeries>
    </RangeNavigatorSeriesCollection>
</SfRangeNavigator>

@code {
    public class StockDetails
    {
        public DateTime Date { get; set; }
        public double Close { get; set; }
    }

    public List<StockDetails> StockInfo = new List<StockDetails> {
        new StockDetails { Date = new DateTime(2005, 01, 01), Close = 21 },
        new StockDetails { Date = new DateTime(2006, 01, 01), Close = 24 },
        new StockDetails { Date = new DateTime(2007, 01, 01), Close = 36 },
        new StockDetails { Date = new DateTime(2008, 01, 01), Close = 38 },
        new StockDetails { Date = new DateTime(2009, 01, 01), Close = 54 },
        new StockDetails { Date = new DateTime(2010, 01, 01), Close = 57 },
        new StockDetails { Date = new DateTime(2011, 01, 01), Close = 70 }
    };

    public DateTime[] Value = new DateTime[] {
        new DateTime(2006, 01, 01), new DateTime(2008, 01, 01)
    };

    public void TooltipCustomization(RangeTooltipRenderEventArgs args)
    {
        // Here you can customize your code.
    }
}

```

## SelectorRender

The [SelectorRender](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.RangeNavigatorEvents.html#Syncfusion_Blazor_Charts_RangeNavigatorEvents_SelectorRender) event triggers before the period selector is rendered. Arguments include:

* [Content](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.RangeSelectorRenderEventArgs.html#Syncfusion_Blazor_Charts_RangeSelectorRenderEventArgs_Content) - Specifies the content for the calendar in the period selector.
* [EnableCustomFormat](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.RangeSelectorRenderEventArgs.html#Syncfusion_Blazor_Charts_RangeSelectorRenderEventArgs_EnableCustomFormat) - Enables to show the content for the calendar in the period selector. By default it is true.
* [Selector](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.RangeSelectorRenderEventArgs.html#Syncfusion_Blazor_Charts_RangeSelectorRenderEventArgs_Selector) - Specifies the period selector collection.

```cshtml

@using Syncfusion.Blazor.Charts

<SfRangeNavigator Value="@Value" ValueType="RangeValueType.DateTime" IntervalType="RangeIntervalType.Years">
    <RangeNavigatorPeriodSelectorSettings>
        <RangeNavigatorPeriods>
            <RangeNavigatorPeriod Interval="1" IntervalType="RangeIntervalType.Months" Text="1M"></RangeNavigatorPeriod>
            <RangeNavigatorPeriod Interval="2" IntervalType="RangeIntervalType.Months" Text="2M"></RangeNavigatorPeriod>
            <RangeNavigatorPeriod Interval="6" IntervalType="RangeIntervalType.Months" Text="6M"></RangeNavigatorPeriod>
            <RangeNavigatorPeriod Text="YTD"></RangeNavigatorPeriod>
            <RangeNavigatorPeriod Interval="1" IntervalType="RangeIntervalType.Years" Text="1Y"></RangeNavigatorPeriod>
            <RangeNavigatorPeriod Interval="2" IntervalType="RangeIntervalType.Years" Text="2Y"></RangeNavigatorPeriod>
            <RangeNavigatorPeriod Text="All"></RangeNavigatorPeriod>
        </RangeNavigatorPeriods>
    </RangeNavigatorPeriodSelectorSettings>
    <RangeNavigatorEvents SelectorRender="SelectorCustomization"></RangeNavigatorEvents>
    <RangeNavigatorSeriesCollection>
        <RangeNavigatorSeries DataSource="@StockInfo" XName="Date" Type="RangeNavigatorType.Line" YName="Close">
        </RangeNavigatorSeries>
    </RangeNavigatorSeriesCollection>
</SfRangeNavigator>

@code {
    public class StockDetails
    {
        public DateTime Date { get; set; }
        public double Close { get; set; }
    }

    public List<StockDetails> StockInfo = new List<StockDetails> {
        new StockDetails { Date = new DateTime(2005, 01, 01), Close = 21 },
        new StockDetails { Date = new DateTime(2006, 01, 01), Close = 24 },
        new StockDetails { Date = new DateTime(2007, 01, 01), Close = 36 },
        new StockDetails { Date = new DateTime(2008, 01, 01), Close = 38 },
        new StockDetails { Date = new DateTime(2009, 01, 01), Close = 54 },
        new StockDetails { Date = new DateTime(2010, 01, 01), Close = 57 },
        new StockDetails { Date = new DateTime(2011, 01, 01), Close = 70 }
    };

    public DateTime[] Value = new DateTime[] {
        new DateTime(2006, 01, 01), new DateTime(2008, 01, 01)
    };

    public void SelectorCustomization(RangeSelectorRenderEventArgs args)
    {
        // Here you can customize your code.
    }
}

```
