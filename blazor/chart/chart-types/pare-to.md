---
layout: post
title: Blazor Pareto Chart Examples and Documentation | Syncfusion®
description: Learn how to create Blazor Pareto Charts using Syncfusion. Combine column and line series to show individual values and their cumulative totals.
platform: Blazor
control: Charts
documentation: ug
---

# Pareto Chart in Blazor

## Pareto

The [Pareto Chart](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeriesType.html#Syncfusion_Blazor_Charts_ChartSeriesType_Pareto) is used to show the cumulative contribution of data across categories. It combines a [Column](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeriesType.html#Syncfusion_Blazor_Charts_ChartSeriesType_Column) series (sorted from highest to lowest value) with a [Line](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeriesType.html#Syncfusion_Blazor_Charts_ChartSeriesType_Line) series (overlaid to show each category's running total as a percentage of the overall sum). To render a Pareto series, set the series [`Type`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Type) to [`Pareto`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeriesType.html#Syncfusion_Blazor_Charts_ChartSeriesType_Pareto); the chart then displays the data as a Pareto combination of column and line series automatically.

N> **Troubleshooting:** If the cumulative line does not appear, verify that `Type` is set to `ChartSeriesType.Pareto` and that the data is sorted by the `YName` value descending. The chart container must have a non-zero height.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart Title="Defect vs Frequency">

    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" Interval="1" Title="Defects">
        <ChartAxisLineStyle Width="0"></ChartAxisLineStyle>
        <ChartAxisMajorTickLines Width="0"></ChartAxisMajorTickLines>
        <ChartAxisMajorGridLines Width="0"></ChartAxisMajorGridLines>
        <ChartAxisMinorTickLines Width="0"></ChartAxisMinorTickLines>
        <ChartAxisMinorGridLines Width="0"></ChartAxisMinorGridLines>
    </ChartPrimaryXAxis>

    <ChartPrimaryYAxis Title="Frequency" Minimum="0" Maximum="150" Interval="30">
        <ChartAxisLineStyle Width="0"></ChartAxisLineStyle>
        <ChartAxisMajorTickLines Width="0"></ChartAxisMajorTickLines>
        <ChartAxisMajorGridLines Width="1"></ChartAxisMajorGridLines>
        <ChartAxisMinorTickLines Width="0"></ChartAxisMinorTickLines>
        <ChartAxisMinorGridLines Width="1"></ChartAxisMinorGridLines>
    </ChartPrimaryYAxis>

    <ChartSeriesCollection>
        <ChartSeries DataSource="@Data" XName="X" YName="Y" Name="Defect" Width="2" Type="ChartSeriesType.Pareto">
            <ChartMarker Visible="true" Height="10" Width="10">
            </ChartMarker>
        </ChartSeries>
    </ChartSeriesCollection>

    <ChartLegendSettings Visible="false"></ChartLegendSettings>
</SfChart>

@code{
    public class ChartData
    {
        public string X { get; set; }
        public double Y { get; set; }
    }

    public List<ChartData> Data = new List<ChartData>
	{
        new ChartData { X= "Traffic", Y= 56 },
        new ChartData { X= "Child Care", Y= 44.8 },
        new ChartData { X= "Transport", Y= 27.2 },
        new ChartData { X= "Weather", Y= 19.6 },
        new ChartData { X= "Emergency", Y= 6.6 }
    };
}

``` 
{% previewsample "https://blazorplayground.syncfusion.com/embed/BjhntxiypUtzrGJW?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Blazor Pareto Chart](../images/othertypes/blazor-pareto-chart.webp)" %}

## Binding data with series

You can bind data to the chart using the [`DataSource`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_DataSource) property within the series configuration. The [`DataSource`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_DataSource) value can be set using either [`SfDataManager`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) property values or a list of business objects. More information on data binding is available in [Working with data](../working-with-data). To display the data correctly, map the fields from the data to the chart series' [`XName`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_XName) and [`YName`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_YName) properties.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart Title="Defect vs Frequency">

    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" Interval="1" Title="Defects">
        <ChartAxisLineStyle Width="0"></ChartAxisLineStyle>
        <ChartAxisMajorTickLines Width="0"></ChartAxisMajorTickLines>
        <ChartAxisMajorGridLines Width="0"></ChartAxisMajorGridLines>
        <ChartAxisMinorTickLines Width="0"></ChartAxisMinorTickLines>
        <ChartAxisMinorGridLines Width="0"></ChartAxisMinorGridLines>
    </ChartPrimaryXAxis>

    <ChartPrimaryYAxis Title="Frequency" Minimum="0" Maximum="150" Interval="30">
        <ChartAxisLineStyle Width="0"></ChartAxisLineStyle>
        <ChartAxisMajorTickLines Width="0"></ChartAxisMajorTickLines>
        <ChartAxisMajorGridLines Width="1"></ChartAxisMajorGridLines>
        <ChartAxisMinorTickLines Width="0"></ChartAxisMinorTickLines>
        <ChartAxisMinorGridLines Width="1"></ChartAxisMinorGridLines>
    </ChartPrimaryYAxis>

    <ChartSeriesCollection>
        <ChartSeries DataSource="@Data" XName="X" YName="Y" Name="Defect" Width="2" Type="ChartSeriesType.Pareto">
            <ChartMarker Visible="true" Height="10" Width="10">
            </ChartMarker>
        </ChartSeries>
    </ChartSeriesCollection>

    <ChartLegendSettings Visible="false"></ChartLegendSettings>
</SfChart>

@code{
    public class ChartData
    {
        public string X { get; set; }
        public double Y { get; set; }
    }

    public List<ChartData> Data = new List<ChartData>
	{
        new ChartData { X= "Traffic", Y= 56 },
        new ChartData { X= "Child Care", Y= 44.8 },
        new ChartData { X= "Transport", Y= 27.2 },
        new ChartData { X= "Weather", Y= 19.6 },
        new ChartData { X= "Emergency", Y= 6.6 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/VDrHDHseTUXwimTq?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" %}

## Events

### Series render

The [`OnSeriesRender`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_OnSeriesRender) event allows you to customize series properties, such as [Data](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SeriesRenderEventArgs.html#Syncfusion_Blazor_Charts_SeriesRenderEventArgs_Data), [Fill](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SeriesRenderEventArgs.html#Syncfusion_Blazor_Charts_SeriesRenderEventArgs_Fill), and [Series](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SeriesRenderEventArgs.html#Syncfusion_Blazor_Charts_SeriesRenderEventArgs_Series), before they are rendered on the chart.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart Title="Defect vs Frequency">
    <ChartEvents OnSeriesRender="SeriesRender"></ChartEvents>

    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" Interval="1" Title="Defects">
        <ChartAxisLineStyle Width="0"></ChartAxisLineStyle>
        <ChartAxisMajorTickLines Width="0"></ChartAxisMajorTickLines>
        <ChartAxisMajorGridLines Width="0"></ChartAxisMajorGridLines>
        <ChartAxisMinorTickLines Width="0"></ChartAxisMinorTickLines>
        <ChartAxisMinorGridLines Width="0"></ChartAxisMinorGridLines>
    </ChartPrimaryXAxis>

    <ChartPrimaryYAxis Title="Frequency" Minimum="0" Maximum="150" Interval="30">
        <ChartAxisLineStyle Width="0"></ChartAxisLineStyle>
        <ChartAxisMajorTickLines Width="0"></ChartAxisMajorTickLines>
        <ChartAxisMajorGridLines Width="1"></ChartAxisMajorGridLines>
        <ChartAxisMinorTickLines Width="0"></ChartAxisMinorTickLines>
        <ChartAxisMinorGridLines Width="1"></ChartAxisMinorGridLines>
    </ChartPrimaryYAxis>

    <ChartSeriesCollection>
        <ChartSeries DataSource="@Data" XName="X" YName="Y" Name="Defect" Type="ChartSeriesType.Pareto">
            <ChartMarker Visible="true" Width="10" Height="10"></ChartMarker>
        </ChartSeries>
    </ChartSeriesCollection>

    <ChartLegendSettings Visible="false"></ChartLegendSettings>
</SfChart>

@code {
    public class ChartData
    {
        public string X { get; set; }
        public double Y { get; set; }
    }

    public void SeriesRender(SeriesRenderEventArgs args)
    {
        args.Fill = "#FF4081";
    }

    public List<ChartData> Data = new List<ChartData>
    {
        new ChartData { X= "Traffic", Y= 56 },
        new ChartData { X= "Child Care", Y= 44.8 },
        new ChartData { X= "Transport", Y= 27.2 },
        new ChartData { X= "Weather", Y= 19.6 },
        new ChartData { X= "Emergency", Y= 6.6 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/hDVRjdsIJAZkVFyp?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" %}

### Point render

The [`OnPointRender`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_OnPointRender) event allows you to customize each data point before it is rendered on the chart.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart Title="Defect vs Frequency">
    <ChartEvents OnPointRender="PointRender"></ChartEvents>

    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" Interval="1" Title="Defects">
        <ChartAxisLineStyle Width="0"></ChartAxisLineStyle>
        <ChartAxisMajorTickLines Width="0"></ChartAxisMajorTickLines>
        <ChartAxisMajorGridLines Width="0"></ChartAxisMajorGridLines>
        <ChartAxisMinorTickLines Width="0"></ChartAxisMinorTickLines>
        <ChartAxisMinorGridLines Width="0"></ChartAxisMinorGridLines>
    </ChartPrimaryXAxis>

    <ChartPrimaryYAxis Title="Frequency" Minimum="0" Maximum="150" Interval="30">
        <ChartAxisLineStyle Width="0"></ChartAxisLineStyle>
        <ChartAxisMajorTickLines Width="0"></ChartAxisMajorTickLines>
        <ChartAxisMajorGridLines Width="1"></ChartAxisMajorGridLines>
        <ChartAxisMinorTickLines Width="0"></ChartAxisMinorTickLines>
        <ChartAxisMinorGridLines Width="1"></ChartAxisMinorGridLines>
    </ChartPrimaryYAxis>

    <ChartSeriesCollection>
        <ChartSeries DataSource="@Data" XName="X" YName="Y" Name="Defect" Type="ChartSeriesType.Pareto">
            <ChartMarker Visible="true" Width="10" Height="10"></ChartMarker>
        </ChartSeries>
    </ChartSeriesCollection>

    <ChartLegendSettings Visible="false"></ChartLegendSettings>
</SfChart>

@code {
    public class ChartData
    {
        public string X { get; set; }
        public double Y { get; set; }
    }

    public void PointRender(PointRenderEventArgs args)
    {
        if (args.Point.X?.ToString() == "Transport")
        {
            args.Fill = "#E91E63";
        }
        else
        {
            args.Fill = "#3F51B5";
        }
    }

    public List<ChartData> Data = new List<ChartData>
    {
        new ChartData { X= "Traffic", Y= 56 },
        new ChartData { X= "Child Care", Y= 44.8 },
        new ChartData { X= "Transport", Y= 27.2 },
        new ChartData { X= "Weather", Y= 19.6 },
        new ChartData { X= "Emergency", Y= 6.6 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/VXhdZHMozAsrnJzD?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" %}

N> Refer to the [Blazor Charts](https://www.syncfusion.com/blazor-components/blazor-charts) feature tour page for its groundbreaking feature representations and explore the [Blazor Pareto Chart Example](https://blazor.syncfusion.com/demos/chart/pareto?theme=fluent2) to learn how the chart combines a descending column series with a cumulative percentage line.

## See also

* [Column](./column)
* [Line](./line)
* [Data Label](../data-labels)
* [Tooltip](../tool-tip)
* [Data Marker](../data-markers)
* [Legend](../legend)