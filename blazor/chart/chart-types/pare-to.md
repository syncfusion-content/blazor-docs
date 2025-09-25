---
layout: post
title: Pareto Chart in Blazor Charts Component | Syncfusion
description: Check out and learn how to configure and customize the Pareto Chart in Syncfusion Blazor Charts component.
platform: Blazor
control: Chart
documentation: ug
---

# Pareto Chart in Blazor Charts Component

## Pareto Chart

The Pareto Chart is used to display cumulative values across different categories. It combines [Column](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeriesType.html#Syncfusion_Blazor_Charts_ChartSeriesType_Column) and [Line](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeriesType.html#Syncfusion_Blazor_Charts_ChartSeriesType_Line) series, where initial values are shown as columns and cumulative values as a line. To render a Pareto series, set the series [`Type`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Type) to [`Pareto`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeriesType.html#Syncfusion_Blazor_Charts_ChartSeriesType_Pareto) in your chart configuration.

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

@code {
    public class ChartData
    {
        public string X { get; set; }
        public double Y { get; set; }
    }

    public List<ChartData> Data = new List<ChartData>
	{
        new ChartData { X = "Traffic", Y = 56 },
        new ChartData { X = "Child Care", Y = 44.8 },
        new ChartData { X = "Transport", Y = 27.2 },
        new ChartData { X = "Weather", Y = 19.6 },
        new ChartData { X = "Emergency", Y = 6.6 }
    };
}

``` 
{% previewsample "https://blazorplayground.syncfusion.com/embed/VDLoZYheKSPLDeLm?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor Pareto Chart](../images/othertypes/blazor-pareto-chart.png)

## Binding data with series

Bind data to the chart using the [`DataSource`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_DataSource) property in the series configuration. The [`DataSource`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_DataSource) value can be set using either [`SfDataManager`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) or a list of business objects. For more information, see [Working with Data](../working-with-data). Map the data fields to the chart series' [`XName`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_XName) and [`YName`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_YName) properties.

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

@code {
    public class ChartData
    {
        public string X { get; set; }
        public double Y { get; set; }
    }

    public List<ChartData> Data = new List<ChartData>
	{
        new ChartData { X = "Traffic", Y = 56 },
        new ChartData { X = "Child Care", Y = 44.8 },
        new ChartData { X = "Transport", Y = 27.2 },
        new ChartData { X = "Weather", Y = 19.6 },
        new ChartData { X = "Emergency", Y = 6.6 }
    };
}

``` 
{% previewsample "https://blazorplayground.syncfusion.com/embed/VDLoZYheKSPLDeLm?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Events

### Series render

The [`OnSeriesRender`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_OnSeriesRender) event enables customization of series properties, such as [Data](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SeriesRenderEventArgs.html#Syncfusion_Blazor_Charts_SeriesRenderEventArgs_Data), [Fill](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SeriesRenderEventArgs.html#Syncfusion_Blazor_Charts_SeriesRenderEventArgs_Fill), and [Series](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SeriesRenderEventArgs.html#Syncfusion_Blazor_Charts_SeriesRenderEventArgs_Series), before rendering.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart Title="Defect vs Frequency">
    <ChartEvents OnSeriesRender="SeriesRender" />

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
        new ChartData { X = "Traffic", Y = 56 },
        new ChartData { X = "Child Care", Y = 44.8 },
        new ChartData { X = "Transport", Y = 27.2 },
        new ChartData { X = "Weather", Y = 19.6 },
        new ChartData { X = "Emergency", Y = 6.6 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/LZrSNkLSKHBQeYTm?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Point render

The [`OnPointRender`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_OnPointRender) event allows customization of each data point before rendering.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart Title="Defect vs Frequency">
    <ChartEvents OnPointRender="PointRender" />

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
        args.Fill = args.Point.X.ToString() == "Transport" ? "#E91E63" : "#3F51B5";
    }

    public List<ChartData> Data = new List<ChartData>
    {
        new ChartData { X = "Traffic", Y = 56 },
        new ChartData { X = "Child Care", Y = 44.8 },
        new ChartData { X = "Transport", Y = 27.2 },
        new ChartData { X = "Weather", Y = 19.6 },
        new ChartData { X = "Emergency", Y = 6.6 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/LjhSNErSKHKxjFrz?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

N> Refer to our [Blazor Charts](https://www.syncfusion.com/blazor-components/blazor-charts) feature tour page for its groundbreaking feature representations and also explore our [Blazor Chart Example](https://blazor.syncfusion.com/demos/chart/line?theme=bootstrap5) to know various chart types and how to represent time-dependent data, showing trends at equal intervals.

## See also

* [Data label](../data-labels)
* [Tooltip](../tool-tip)
