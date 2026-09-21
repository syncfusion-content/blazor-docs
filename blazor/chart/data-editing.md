---
layout: post
title: Blazor Charts Data Editing Examples | Syncfusion®
description: Learn how to enable drag-and-drop data editing in Syncfusion Blazor Charts. Set ChartDataEditSettings Enable to true with MinY, MaxY, and Fill.
platform: Blazor
control: Charts
documentation: ug
---

# Blazor Charts Data Editing

Data editing allows the y-value of a rendered data point to be adjusted by dragging it at run time. To enable data editing, set [ChartDataEditSettings.Enable](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartDataEditSettings.html#Syncfusion_Blazor_Charts_ChartDataEditSettings_Enable) to **true**. Use the [Fill](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartDataEditSettings.html#Syncfusion_Blazor_Charts_ChartDataEditSettings_Fill) property to specify the edited point color, and the [MinY](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartDataEditSettings.html#Syncfusion_Blazor_Charts_ChartDataEditSettings_MinY) and [MaxY](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartDataEditSettings.html#Syncfusion_Blazor_Charts_ChartDataEditSettings_MaxY) properties to restrict the y-value to a minimum and maximum range.

N> Data editing is supported in both Blazor Server and Blazor WebAssembly hosting models. Available in Syncfusion Blazor Charts NuGet package version 18.2.0.39 and later.

The following example enables data editing with default settings.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart Title="Inflation - Consumer Price">
    <ChartArea><ChartAreaBorder Width="0"></ChartAreaBorder></ChartArea>

    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.DateTime" LabelFormat="y"
                       IntervalType="IntervalType.Years" EdgeLabelPlacement="EdgeLabelPlacement.Shift">
        <ChartAxisMajorGridLines Width="0"></ChartAxisMajorGridLines>
    </ChartPrimaryXAxis>

    <ChartPrimaryYAxis LabelFormat="{value}%" RangePadding="ChartRangePadding.None" Minimum="0" Maximum="100"
                       Interval="20">
        <ChartAxisLineStyle Width="0"></ChartAxisLineStyle>
        <ChartAxisMajorTickLines Width="0"></ChartAxisMajorTickLines>
    </ChartPrimaryYAxis>

    <ChartTooltipSettings Enable="true"></ChartTooltipSettings>

    <ChartSeriesCollection>
        <ChartSeries DataSource="@ConsumerDetails" XName="XValue" Width="2"
                     Opacity="1" YName="YValue" Type="ChartSeriesType.Column">
            <ChartMarker Visible="true" Width="10" Height="10" />
            <ChartDataEditSettings Enable="true"></ChartDataEditSettings>
        </ChartSeries>
        <ChartSeries DataSource="@ConsumerDetails" XName="XValue" Width="2"
                     Opacity="1" YName="YValue1" Type="ChartSeriesType.Line">
            <ChartMarker Visible="true" Width="10" Height="10" />
            <ChartDataEditSettings Enable="true"></ChartDataEditSettings>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    public class ChartData
    {
        public DateTime XValue { get; set; }
        public double YValue { get; set; }
        public double YValue1 { get; set; }
    }

    public List<ChartData> ConsumerDetails = new List<ChartData>
    {
        new ChartData { XValue = new DateTime(2005, 01, 01), YValue = 21, YValue1 = 28 },
        new ChartData { XValue = new DateTime(2006, 01, 01), YValue = 24, YValue1 = 44 },
        new ChartData { XValue = new DateTime(2007, 01, 01), YValue = 36, YValue1 = 48 },
        new ChartData { XValue = new DateTime(2008, 01, 01), YValue = 38, YValue1 = 50 },
        new ChartData { XValue = new DateTime(2009, 01, 01), YValue = 54, YValue1 = 66 },
        new ChartData { XValue = new DateTime(2010, 01, 01), YValue = 57, YValue1 = 78 },
        new ChartData { XValue = new DateTime(2011, 01, 01), YValue = 70, YValue1 = 84 },
    };
}

```

{% previewsample "https://blazorplayground.syncfusion.com/embed/LNLHtFsqqGKnEIgK?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Data Editing in Blazor Chart](images/data-editing/blazor-chart-data-editing.webp)" %}

## Customizing the edited point

The next example customizes the edited-point color with `Fill` and constrains drag movement to a 0–100 y-value range with `MinY` and `MaxY`.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart Title="Inflation - Consumer Price (Bounded Edit)">
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.DateTime" LabelFormat="y"
                       IntervalType="IntervalType.Years" EdgeLabelPlacement="EdgeLabelPlacement.Shift">
        <ChartAxisMajorGridLines Width="0"></ChartAxisMajorGridLines>
    </ChartPrimaryXAxis>

    <ChartPrimaryYAxis LabelFormat="{value}%" RangePadding="ChartRangePadding.None" Minimum="0" Maximum="100"
                       Interval="20">
        <ChartAxisLineStyle Width="0"></ChartAxisLineStyle>
        <ChartAxisMajorTickLines Width="0"></ChartAxisMajorTickLines>
    </ChartPrimaryYAxis>

    <ChartTooltipSettings Enable="true"></ChartTooltipSettings>

    <ChartSeriesCollection>
        <ChartSeries DataSource="@ConsumerDetails" XName="XValue" Width="2"
                     Opacity="1" YName="YValue" Type="ChartSeriesType.Column">
            <ChartMarker Visible="true" Width="10" Height="10" />
            <ChartDataEditSettings Enable="true" Fill="#e5e5e5" MinY="0" MaxY="100"></ChartDataEditSettings>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    public class ChartData
    {
        public DateTime XValue { get; set; }
        public double YValue { get; set; }
    }

    public List<ChartData> ConsumerDetails = new List<ChartData>
    {
        new ChartData { XValue = new DateTime(2005, 01, 01), YValue = 21 },
        new ChartData { XValue = new DateTime(2006, 01, 01), YValue = 24 },
        new ChartData { XValue = new DateTime(2007, 01, 01), YValue = 36 },
        new ChartData { XValue = new DateTime(2008, 01, 01), YValue = 38 },
        new ChartData { XValue = new DateTime(2009, 01, 01), YValue = 54 },
        new ChartData { XValue = new DateTime(2010, 01, 01), YValue = 57 },
        new ChartData { XValue = new DateTime(2011, 01, 01), YValue = 70 },
    };
}

```

{% previewsample "https://blazorplayground.syncfusion.com/embed/VNLHtFWgAwrlnhyx?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Customizing the edited point](images/data-editing/blazor-chart-customizing-edited-data.webp)" %}


## See Also

* [Events](./events)
* [Selection](./selection)
* [Working with Data](./working-with-data)
* [Data Markers](./data-markers)
