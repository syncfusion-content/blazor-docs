---
layout: post
title: Range Column in Blazor Charts Component | Syncfusion
description: Checkout and learn here all about Range Column Chart in Syncfusion Blazor Charts component and more.
platform: Blazor
control: Chart
documentation: ug
---

# Range Column in Blazor Charts Component

## Range Column

[Range Column Chart](https://www.syncfusion.com/blazor-components/blazor-charts/chart-types/range-column-chart) shows variation in the data values for a given time using vertical bars. To render a [range column](https://www.syncfusion.com/blazor-components/blazor-charts/chart-types/range-column-chart) series in your chart, you need to follow a few steps to configure it correctly. Here's a concise guide on how to do this:

1. **Set the series type**: Define the series [`Type`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Type) as [`RangeColumn`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeriesType.html#Syncfusion_Blazor_Charts_ChartSeriesType_RangeColumn) in your chart configuration. This indicates that the data should be represented as a range column chart, which is ideal for visualizing data that has both minimum and maximum values for each category. This is especially useful for visualizing data ranges, such as temperature fluctuations over time, stock prices, or any other data with upper and lower bounds.

2. **Provide high and low values**: The [`RangeColumn`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeriesType.html#Syncfusion_Blazor_Charts_ChartSeriesType_RangeColumn) series requires two y-values for each data point, you need to specify both the high and low values. The high value represents the maximum range, while the low value represents the minimum range for each data point. These values define the upper and lower boundaries of the column for each point on the chart.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category"></ChartPrimaryXAxis>

    <ChartSeriesCollection>
        <ChartSeries DataSource="@WeatherReport1" XName="X" High="High" Low="Low" Width="2" Type="ChartSeriesType.RangeColumn">
        </ChartSeries>
        <ChartSeries DataSource="@WeatherReport2" XName="X" High="High" Low="Low" Width="2" Type="ChartSeriesType.RangeColumn">
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code{
    public class ChartData
    {
        public string X { get; set; }
        public double Low { get; set; }
        public double High { get; set; }
    }

    public List<ChartData> WeatherReport1 = new List<ChartData>
	{
        new ChartData { X= "Sun", Low= 3.1, High= 10.8 },
        new ChartData { X= "Mon", Low= 5.7, High= 14.4 },
        new ChartData { X= "Tue", Low= 8.4, High= 16.9 },
        new ChartData { X= "Wed", Low= 10.6, High= 19.2 },
        new ChartData { X= "Thu", Low= 8.5, High= 16.1 },
        new ChartData { X= "Fri", Low= 6.0, High= 12.5 },
        new ChartData { X= "Sat", Low= 1.5, High= 6.9 }
    };

    public List<ChartData> WeatherReport2 = new List<ChartData>
	{
        new ChartData { X= "Sun", Low= 2.5, High= 9.8 },
        new ChartData { X= "Mon", Low= 4.7, High= 11.4 },
        new ChartData { X= "Tue", Low= 6.4, High= 14.4 },
        new ChartData { X= "Wed", Low= 9.6, High= 17.2 },
        new ChartData { X= "Thu", Low= 7.5, High= 15.1 },
        new ChartData { X= "Fri", Low= 3.0, High= 10.5 },
        new ChartData { X= "Sat", Low= 1.2, High= 7.9 }
    };
}

``` 
{% previewsample "https://blazorplayground.syncfusion.com/embed/BDLgCLrnzdoaeqgs?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor Range Column Chart](../images/chart-types-images/blazor-range-column-chart.png)" %}

N> Refer to our [Blazor Range Column Chart](https://www.syncfusion.com/blazor-components/blazor-charts/chart-types/range-column-chart) feature tour page to know about its other groundbreaking feature representations. Explore our [Blazor Range Column Chart Example](https://blazor.syncfusion.com/demos/chart/range-column?theme=bootstrap5) to know how to show variations in the data values for a given time.

## Binding data with series

You can bind data to the chart using the [`DataSource`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_DataSource) property within the series configuration. The [`DataSource`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_DataSource) value can be set using either [`SfDataManager`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) property values or a list of business objects. More information on data binding can be found [here](../working-with-data). To display the data correctly, map the fields from the data to the chart series' [`XName`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_XName), [`High`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_High) and [`Low`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Low) properties.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category"></ChartPrimaryXAxis>

    <ChartSeriesCollection>
        <ChartSeries DataSource="@WeatherReport1" XName="X" High="High" Low="Low" Width="2" Type="ChartSeriesType.RangeColumn">
        </ChartSeries>
        <ChartSeries DataSource="@WeatherReport2" XName="X" High="High" Low="Low" Width="2" Type="ChartSeriesType.RangeColumn">
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code{
    public class ChartData
    {
        public string X { get; set; }
        public double Low { get; set; }
        public double High { get; set; }
    }

    public List<ChartData> WeatherReport1 = new List<ChartData>
	{
        new ChartData { X= "Sun", Low= 3.1, High= 10.8 },
        new ChartData { X= "Mon", Low= 5.7, High= 14.4 },
        new ChartData { X= "Tue", Low= 8.4, High= 16.9 },
        new ChartData { X= "Wed", Low= 10.6, High= 19.2 },
        new ChartData { X= "Thu", Low= 8.5, High= 16.1 },
        new ChartData { X= "Fri", Low= 6.0, High= 12.5 },
        new ChartData { X= "Sat", Low= 1.5, High= 6.9 }
    };

    public List<ChartData> WeatherReport2 = new List<ChartData>
	{
        new ChartData { X= "Sun", Low= 2.5, High= 9.8 },
        new ChartData { X= "Mon", Low= 4.7, High= 11.4 },
        new ChartData { X= "Tue", Low= 6.4, High= 14.4 },
        new ChartData { X= "Wed", Low= 9.6, High= 17.2 },
        new ChartData { X= "Thu", Low= 7.5, High= 15.1 },
        new ChartData { X= "Fri", Low= 3.0, High= 10.5 },
        new ChartData { X= "Sat", Low= 1.2, High= 7.9 }
    };
}

``` 
{% previewsample "https://blazorplayground.syncfusion.com/embed/BDLgCLrnzdoaeqgs?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Series customization

The following properties can be used to customize the [Range Column](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeriesType.html#Syncfusion_Blazor_Charts_ChartSeriesType_RangeColumn) series.

**Fill**

The [Fill](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Fill) property determines the color applied to the series.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category"></ChartPrimaryXAxis>

    <ChartSeriesCollection>
        <ChartSeries DataSource="@WeatherReport1" XName="X" High="High" Low="Low" Width="2" Type="Syncfusion.Blazor.Charts.ChartSeriesType.RangeColumn" Fill="green"></ChartSeries>
        <ChartSeries DataSource="@WeatherReport2" XName="X" High="High" Low="Low" Width="2" Type="Syncfusion.Blazor.Charts.ChartSeriesType.RangeColumn" Fill="red"></ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    public class ChartData
    {

        public string X { get; set; }
        public double Low { get; set; }
        public double High { get; set; }
    }

    public List<ChartData> WeatherReport1 = new List<ChartData>
    {
        new  ChartData { X=  "Sun", Low=  3.1, High=  10.8 },
        new  ChartData { X=  "Mon", Low=  5.7, High=  14.4 },
        new  ChartData { X=  "Tue", Low=  8.4, High=  16.9 },
        new  ChartData { X=  "Wed", Low=  10.6, High=  19.2 },
        new  ChartData { X=  "Thu", Low=  8.5, High=  16.1 },
        new  ChartData { X=  "Fri", Low=  6.0, High=  12.5 },
        new  ChartData { X=  "Sat", Low=  1.5, High=  6.9 }
    };

    public List<ChartData> WeatherReport2 = new List<ChartData>
    {
        new  ChartData { X=  "Sun", Low=  2.5, High=  9.8 },
        new  ChartData { X=  "Mon", Low=  4.7, High=  11.4 },
        new  ChartData { X=  "Tue", Low=  6.4, High=  14.4 },
        new  ChartData { X=  "Wed", Low=  9.6, High=  17.2 },
        new  ChartData { X=  "Thu", Low=  7.5, High=  15.1 },
        new  ChartData { X=  "Fri", Low=  3.0, High=  10.5 },
        new  ChartData { X=  "Sat", Low=  1.2, High=  7.9 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/VXVTjPsuPHANPsBK?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

The [Fill](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Fill) property can be used to apply a gradient color to the range column series. By configuring this property with gradient values, you can create a visually appealing effect in which the color transitions smoothly from one shade to another.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category"></ChartPrimaryXAxis>

    <ChartSeriesCollection>
        <ChartSeries DataSource="@WeatherReport1" XName="X" High="High" Low="Low" Width="2" Type="ChartSeriesType.RangeColumn" Fill="url(#grad1)"></ChartSeries>
        <ChartSeries DataSource="@WeatherReport2" XName="X" High="High" Low="Low" Width="2" Type="ChartSeriesType.RangeColumn" Fill="url(#grad2)"></ChartSeries>
    </ChartSeriesCollection>
</SfChart>

<svg style="height: 0">
    <defs>
        <linearGradient id="grad1" x1="0%" y1="0%" x2="0%" y2="100%">
            <stop offset="20%" style="stop-color:orange;stop-opacity:1" />
            <stop offset="100%" style="stop-color:black;stop-opacity:1" />
        </linearGradient>
    </defs>
</svg>

<svg style="height: 0">
    <defs>
        <linearGradient id="grad2" x1="0%" y1="0%" x2="0%" y2="100%">
            <stop offset="20%" style="stop-color:green;stop-opacity:1" />
            <stop offset="100%" style="stop-color:lawngreen;stop-opacity:1" />
        </linearGradient>
    </defs>
</svg>

@code {
    public class ChartData
    {

        public string X { get; set; }
        public double Low { get; set; }
        public double High { get; set; }
    }

    public List<ChartData> WeatherReport1 = new List<ChartData>
    {
        new  ChartData { X=  "Sun", Low=  3.1, High=  10.8 },
        new  ChartData { X=  "Mon", Low=  5.7, High=  14.4 },
        new  ChartData { X=  "Tue", Low=  8.4, High=  16.9 },
        new  ChartData { X=  "Wed", Low=  10.6, High=  19.2 },
        new  ChartData { X=  "Thu", Low=  8.5, High=  16.1 },
        new  ChartData { X=  "Fri", Low=  6.0, High=  12.5 },
        new  ChartData { X=  "Sat", Low=  1.5, High=  6.9 }
    };

    public List<ChartData> WeatherReport2 = new List<ChartData>
    {
        new  ChartData { X=  "Sun", Low=  2.5, High=  9.8 },
        new  ChartData { X=  "Mon", Low=  4.7, High=  11.4 },
        new  ChartData { X=  "Tue", Low=  6.4, High=  14.4 },
        new  ChartData { X=  "Wed", Low=  9.6, High=  17.2 },
        new  ChartData { X=  "Thu", Low=  7.5, High=  15.1 },
        new  ChartData { X=  "Fri", Low=  3.0, High=  10.5 },
        new  ChartData { X=  "Sat", Low=  1.2, High=  7.9 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/hXLzXvrDDXLBCKlj?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}


**Opacity**

The [Opacity](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Opacity) property specifies the transparency level of the [Fill](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Fill). Adjusting this property allows you to control how opaque or transparent the fill color of the series appears.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category"></ChartPrimaryXAxis>

    <ChartSeriesCollection>
        <ChartSeries DataSource="@WeatherReport1" XName="X" High="High" Low="Low" Width="2" Type="Syncfusion.Blazor.Charts.ChartSeriesType.RangeColumn" Fill="green" Opacity="0.5"></ChartSeries>
        <ChartSeries DataSource="@WeatherReport2" XName="X" High="High" Low="Low" Width="2" Type="Syncfusion.Blazor.Charts.ChartSeriesType.RangeColumn" Fill="red" Opacity="0.5"></ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    public class ChartData
    {

        public string X { get; set; }
        public double Low { get; set; }
        public double High { get; set; }
    }

    public List<ChartData> WeatherReport1 = new List<ChartData>
    {
        new  ChartData { X=  "Sun", Low=  3.1, High=  10.8 },
        new  ChartData { X=  "Mon", Low=  5.7, High=  14.4 },
        new  ChartData { X=  "Tue", Low=  8.4, High=  16.9 },
        new  ChartData { X=  "Wed", Low=  10.6, High=  19.2 },
        new  ChartData { X=  "Thu", Low=  8.5, High=  16.1 },
        new  ChartData { X=  "Fri", Low=  6.0, High=  12.5 },
        new  ChartData { X=  "Sat", Low=  1.5, High=  6.9 }
    };

    public List<ChartData> WeatherReport2 = new List<ChartData>
    {
        new  ChartData { X=  "Sun", Low=  2.5, High=  9.8 },
        new  ChartData { X=  "Mon", Low=  4.7, High=  11.4 },
        new  ChartData { X=  "Tue", Low=  6.4, High=  14.4 },
        new  ChartData { X=  "Wed", Low=  9.6, High=  17.2 },
        new  ChartData { X=  "Thu", Low=  7.5, High=  15.1 },
        new  ChartData { X=  "Fri", Low=  3.0, High=  10.5 },
        new  ChartData { X=  "Sat", Low=  1.2, High=  7.9 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BDrfjlVjXDAdyObH?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

**DashArray**

The [DashArray](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_DashArray) property determines the pattern of dashes and gaps in the series border.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category"></ChartPrimaryXAxis>

    <ChartSeriesCollection>
        <ChartSeries DataSource="@WeatherReport1" XName="X" High="High" Low="Low" Width="2" Type="Syncfusion.Blazor.Charts.ChartSeriesType.RangeColumn" Fill="green" DashArray="5,5" Opacity="0.7">
            <ChartSeriesBorder Width="2" Color="green"></ChartSeriesBorder>
        </ChartSeries>
        <ChartSeries DataSource="@WeatherReport2" XName="X" High="High" Low="Low" Width="2" Type="Syncfusion.Blazor.Charts.ChartSeriesType.RangeColumn" Fill="red" DashArray="5,5" Opacity="0.7">
            <ChartSeriesBorder Width="2" Color="red"></ChartSeriesBorder>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    public class ChartData
    {

        public string X { get; set; }
        public double Low { get; set; }
        public double High { get; set; }
    }

    public List<ChartData> WeatherReport1 = new List<ChartData>
    {
        new  ChartData { X=  "Sun", Low=  3.1, High=  10.8 },
        new  ChartData { X=  "Mon", Low=  5.7, High=  14.4 },
        new  ChartData { X=  "Tue", Low=  8.4, High=  16.9 },
        new  ChartData { X=  "Wed", Low=  10.6, High=  19.2 },
        new  ChartData { X=  "Thu", Low=  8.5, High=  16.1 },
        new  ChartData { X=  "Fri", Low=  6.0, High=  12.5 },
        new  ChartData { X=  "Sat", Low=  1.5, High=  6.9 }
    };

    public List<ChartData> WeatherReport2 = new List<ChartData>
    {
        new  ChartData { X=  "Sun", Low=  2.5, High=  9.8 },
        new  ChartData { X=  "Mon", Low=  4.7, High=  11.4 },
        new  ChartData { X=  "Tue", Low=  6.4, High=  14.4 },
        new  ChartData { X=  "Wed", Low=  9.6, High=  17.2 },
        new  ChartData { X=  "Thu", Low=  7.5, High=  15.1 },
        new  ChartData { X=  "Fri", Low=  3.0, High=  10.5 },
        new  ChartData { X=  "Sat", Low=  1.2, High=  7.9 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/LjrztbhXXZogMLpu?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

**Series Border**

The [ChartSeriesBorder](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeriesBorder.html) property determines the [Color](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeriesBorder.html#Syncfusion_Blazor_Charts_ChartSeriesBorder_Color) and [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeriesBorder.html#Syncfusion_Blazor_Charts_ChartSeriesBorder_Width) of series border.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category"></ChartPrimaryXAxis>

    <ChartSeriesCollection>
        <ChartSeries DataSource="@WeatherReport1" XName="X" High="High" Low="Low" Width="2" Type="Syncfusion.Blazor.Charts.ChartSeriesType.RangeColumn" Fill="green" DashArray="5,5" Opacity="0.7">
            <ChartSeriesBorder Width="2" Color="green"></ChartSeriesBorder>
        </ChartSeries>
        <ChartSeries DataSource="@WeatherReport2" XName="X" High="High" Low="Low" Width="2" Type="Syncfusion.Blazor.Charts.ChartSeriesType.RangeColumn" Fill="red" DashArray="5,5" Opacity="0.7">
            <ChartSeriesBorder Width="2" Color="red"></ChartSeriesBorder>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    public class ChartData
    {

        public string X { get; set; }
        public double Low { get; set; }
        public double High { get; set; }
    }

    public List<ChartData> WeatherReport1 = new List<ChartData>
    {
        new  ChartData { X=  "Sun", Low=  3.1, High=  10.8 },
        new  ChartData { X=  "Mon", Low=  5.7, High=  14.4 },
        new  ChartData { X=  "Tue", Low=  8.4, High=  16.9 },
        new  ChartData { X=  "Wed", Low=  10.6, High=  19.2 },
        new  ChartData { X=  "Thu", Low=  8.5, High=  16.1 },
        new  ChartData { X=  "Fri", Low=  6.0, High=  12.5 },
        new  ChartData { X=  "Sat", Low=  1.5, High=  6.9 }
    };

    public List<ChartData> WeatherReport2 = new List<ChartData>
    {
        new  ChartData { X=  "Sun", Low=  2.5, High=  9.8 },
        new  ChartData { X=  "Mon", Low=  4.7, High=  11.4 },
        new  ChartData { X=  "Tue", Low=  6.4, High=  14.4 },
        new  ChartData { X=  "Wed", Low=  9.6, High=  17.2 },
        new  ChartData { X=  "Thu", Low=  7.5, High=  15.1 },
        new  ChartData { X=  "Fri", Low=  3.0, High=  10.5 },
        new  ChartData { X=  "Sat", Low=  1.2, High=  7.9 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/LjrztbhXXZogMLpu?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

**Column Spacing**

The [ColumnSpacing](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_ColumnSpacing) property determines the space between the series segments.

```cshtml

@using  Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category"></ChartPrimaryXAxis>
	
    <ChartSeriesCollection>
        <ChartSeries DataSource="@WeatherReport1" XName="X" High="High" Low="Low" Width="2" Type="ChartSeriesType.RangeColumn" Fill="green" ColumnSpacing="0.4" DashArray="5,5" Opacity="0.7">
            <ChartSeriesBorder Width="2" Color="green"></ChartSeriesBorder>
        </ChartSeries>
        <ChartSeries DataSource="@WeatherReport2" XName="X" High="High" Low="Low" Width="2" Type="ChartSeriesType.RangeColumn" Fill="red" ColumnSpacing="0.4" DashArray="5,5" Opacity="0.7">
            <ChartSeriesBorder Width="2" Color="red"></ChartSeriesBorder>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code{ 
    public class ChartData
    {

        public string X { get; set; }
        public double Low { get; set; }
        public double High { get; set; }
    }
    
    public List<ChartData> WeatherReport1 = new List<ChartData>
    {
        new  ChartData { X=  "Sun", Low=  3.1, High=  10.8 },
        new  ChartData { X=  "Mon", Low=  5.7, High=  14.4 },
        new  ChartData { X=  "Tue", Low=  8.4, High=  16.9 },
        new  ChartData { X=  "Wed", Low=  10.6, High=  19.2 },
        new  ChartData { X=  "Thu", Low=  8.5, High=  16.1 },
        new  ChartData { X=  "Fri", Low=  6.0, High=  12.5 },
        new  ChartData { X=  "Sat", Low=  1.5, High=  6.9 }
    };

    public List<ChartData> WeatherReport2 = new List<ChartData>
    {
        new  ChartData { X=  "Sun", Low=  2.5, High=  9.8 },
        new  ChartData { X=  "Mon", Low=  4.7, High=  11.4 },
        new  ChartData { X=  "Tue", Low=  6.4, High=  14.4 },
        new  ChartData { X=  "Wed", Low=  9.6, High=  17.2 },
        new  ChartData { X=  "Thu", Low=  7.5, High=  15.1 },
        new  ChartData { X=  "Fri", Low=  3.0, High=  10.5 },
        new  ChartData { X=  "Sat", Low=  1.2, High=  7.9 } 
    }; 
}

``` 
{% previewsample "https://blazorplayground.syncfusion.com/embed/BjLUWrrnTnRLsksm?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Corner radius

The [ChartCornerRadius](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCornerRadius.html) property is used to customize the corner radius for range column series. This allows you to create columns with rounded corners, giving your chart a more polished appearance. You can customize each corner of the columns using the [BottomLeft](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCornerRadius.html#Syncfusion_Blazor_Charts_ChartCornerRadius_BottomLeft), [BottomRight](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCornerRadius.html#Syncfusion_Blazor_Charts_ChartCornerRadius_BottomRight), [TopLeft](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCornerRadius.html#Syncfusion_Blazor_Charts_ChartCornerRadius_TopLeft), [TopRight](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCornerRadius.html#Syncfusion_Blazor_Charts_ChartCornerRadius_TopRight) properties.


```cshtml
@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category"></ChartPrimaryXAxis>

    <ChartSeriesCollection>
        <ChartSeries DataSource="@Sales1" XName="X" High="High" Low="Low" Type="Syncfusion.Blazor.Charts.ChartSeriesType.RangeColumn">
            <ChartCornerRadius TopLeft="4" TopRight="4" BottomLeft="4" BottomRight="4"></ChartCornerRadius>
        </ChartSeries>
        <ChartSeries DataSource="@Sales2" XName="X" High="High" Low="Low" Type="Syncfusion.Blazor.Charts.ChartSeriesType.RangeColumn">
            <ChartCornerRadius TopLeft="4" TopRight="4" BottomLeft="4" BottomRight="4"></ChartCornerRadius>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    public class SalesInfo
    {
        public string X { get; set; }
        public double Low { get; set; }
        public double High { get; set; }
    }

    public List<SalesInfo> Sales1 = new List<SalesInfo>
    {
        new SalesInfo { X= "Sun", Low= 3.1, High= 10.8 },
        new SalesInfo { X= "Mon", Low= 5.7, High= 14.4 },
        new SalesInfo { X= "Tue", Low= 8.4, High= 16.9 },
        new SalesInfo { X= "Wed", Low= 10.6, High= 19.2 },
        new SalesInfo { X= "Thu", Low= 8.5, High= 16.1 },
        new SalesInfo { X= "Fri", Low= 6.0, High= 12.5 },
        new SalesInfo { X= "Sat", Low= 1.5, High= 6.9 }
    };

    public List<SalesInfo> Sales2 = new List<SalesInfo>
    {
        new SalesInfo { X= "Sun", Low= 2.5, High= 9.8 },
        new SalesInfo { X= "Mon", Low= 4.7, High= 11.4 },
        new SalesInfo { X= "Tue", Low= 6.4, High= 14.4 },
        new SalesInfo { X= "Wed", Low= 9.6, High= 17.2 },
        new SalesInfo { X= "Thu", Low= 7.5, High= 15.1 },
        new SalesInfo { X= "Fri", Low= 3.0, High= 10.5 },
        new SalesInfo { X= "Sat", Low= 1.2, High= 7.9 }
    };
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BDBSDTtTAfxgaRes?appbar=true&editor=true&result=true&errorlist=true&theme=bootstrap5" backgroundimage "[Blazor Range Column Chart with corner radius](../images/chart-types-images/blazor-range-column-corner-radius.png)" %}

We can also customize the corner radius for individual points in the chart series using the [OnPointRender](https://blazor.syncfusion.com/documentation/chart/events#onpointrender) event by utilizing the [CornerRadius](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.PointRenderEventArgs.html#Syncfusion_Blazor_Charts_PointRenderEventArgs_CornerRadius) property in its event argument.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartEvents OnPointRender="PointRenderEvent"></ChartEvents>

    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category"></ChartPrimaryXAxis>

    <ChartSeriesCollection>
        <ChartSeries DataSource="@Sales1" XName="X" High="High" Low="Low" Type="Syncfusion.Blazor.Charts.ChartSeriesType.RangeColumn">
        </ChartSeries>
        <ChartSeries DataSource="@Sales2" XName="X" High="High" Low="Low" Type="Syncfusion.Blazor.Charts.ChartSeriesType.RangeColumn">
        </ChartSeries>
    </ChartSeriesCollection>    `
</SfChart>

@code {
    public class SalesInfo
    {
        public string X { get; set; }
        public double Low { get; set; }
        public double High { get; set; }
    }

    public List<SalesInfo> Sales1 = new List<SalesInfo>
    {
        new SalesInfo { X= "Sun", Low= 3.1, High= 10.8 },
        new SalesInfo { X= "Mon", Low= 5.7, High= 14.4 },
        new SalesInfo { X= "Tue", Low= 8.4, High= 16.9 },
        new SalesInfo { X= "Wed", Low= 10.6, High= 19.2 },
        new SalesInfo { X= "Thu", Low= 8.5, High= 16.1 },
        new SalesInfo { X= "Fri", Low= 6.0, High= 12.5 },
        new SalesInfo { X= "Sat", Low= 1.5, High= 6.9 }
    };

    public List<SalesInfo> Sales2 = new List<SalesInfo>
    {
        new SalesInfo { X= "Sun", Low= 2.5, High= 9.8 },
        new SalesInfo { X= "Mon", Low= 4.7, High= 11.4 },
        new SalesInfo { X= "Tue", Low= 6.4, High= 14.4 },
        new SalesInfo { X= "Wed", Low= 9.6, High= 17.2 },
        new SalesInfo { X= "Thu", Low= 7.5, High= 15.1 },
        new SalesInfo { X= "Fri", Low= 3.0, High= 10.5 },
        new SalesInfo { X= "Sat", Low= 1.2, High= -7.9 }
    };

    public void PointRenderEvent(PointRenderEventArgs args)
    {
        if ((args.Point.X as string) == "Sun" || (args.Point.X as string) == "Wed" || (args.Point.X as string) == "Sat")
        {
            args.CornerRadius.TopLeft = 5;
            args.CornerRadius.TopRight = 5;
            args.CornerRadius.BottomLeft = 5;
            args.CornerRadius.BottomRight = 5;
        }
    }
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BNLejTXzqothXDiL?appbar=true&editor=true&result=true&errorlist=true&theme=bootstrap5" backgroundimage "[Blazor Range Column Chart with corner radius using OnPointRender event](../images/chart-types-images/blazor-range-column-corner-radius-onPointRender.png)" %}

## Empty points

Data points with `null` or `undefined` values are considered empty. Empty data points are ignored and not plotted on the chart.

**Mode**

Use the [`Mode`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEmptyPointSettings.html#Syncfusion_Blazor_Charts_ChartEmptyPointSettings_Mode) property to define how empty or missing data points are handled in the series. The default mode for empty points is [`Gap`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.EmptyPointMode.html#Syncfusion_Blazor_Charts_EmptyPointMode_Gap).

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category"></ChartPrimaryXAxis>

    <ChartSeriesCollection>
        <ChartSeries DataSource="@WeatherReport1" XName="X" High="High" Low="Low" Width="2" Type="Syncfusion.Blazor.Charts.ChartSeriesType.RangeColumn">
            <ChartEmptyPointSettings Mode="EmptyPointMode.Gap"></ChartEmptyPointSettings>
            <ChartMarker Visible="true" Height="10" Width="10"></ChartMarker>
        </ChartSeries>
        <ChartSeries DataSource="@WeatherReport2" XName="X" High="High" Low="Low" Width="2" Type="Syncfusion.Blazor.Charts.ChartSeriesType.RangeColumn">
            <ChartEmptyPointSettings Mode="EmptyPointMode.Gap"></ChartEmptyPointSettings>
            <ChartMarker Visible="true" Height="10" Width="10"></ChartMarker>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    public class ChartData
    {

        public string X { get; set; }
        public double Low { get; set; }
        public double High { get; set; }
    }

    public List<ChartData> WeatherReport1 = new List<ChartData>
    {
        new  ChartData { X=  "Sun", Low=  3.1, High=  10.8 },
        new  ChartData { X=  "Mon", Low=  5.7, High=  14.4 },
        new  ChartData { X=  "Tue", Low=  8.4, High=  16.9 },
        new  ChartData { X=  "Wed", Low=  double.NaN, High=  double.NaN },
        new  ChartData { X=  "Thu", Low=  8.5, High=  16.1 },
        new  ChartData { X=  "Fri", Low=  6.0, High=  12.5 },
        new  ChartData { X=  "Sat", Low=  1.5, High=  6.9 }
    };

    public List<ChartData> WeatherReport2 = new List<ChartData>
    {
        new  ChartData { X=  "Sun", Low=  2.5, High=  9.8 },
        new  ChartData { X=  "Mon", Low=  4.7, High=  11.4 },
        new  ChartData { X=  "Tue", Low=  6.4, High=  14.4 },
        new  ChartData { X=  "Wed", Low=  double.NaN, High=  double.NaN },
        new  ChartData { X=  "Thu", Low=  7.5, High=  15.1 },
        new  ChartData { X=  "Fri", Low=  3.0, High=  10.5 },
        new  ChartData { X=  "Sat", Low=  1.2, High=  7.9 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/VXBJDPLjtjuPynMF?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

**Fill**

Use the [`Fill`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEmptyPointSettings.html#Syncfusion_Blazor_Charts_ChartEmptyPointSettings_Fill) property to customize the fill color of empty points in the series.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category"></ChartPrimaryXAxis>

    <ChartSeriesCollection>
        <ChartSeries DataSource="@WeatherReport1" XName="X" High="High" Low="Low" Width="2" Type="Syncfusion.Blazor.Charts.ChartSeriesType.RangeColumn">
            <ChartEmptyPointSettings Mode="EmptyPointMode.Average" Fill="#FFDE59"></ChartEmptyPointSettings>
            <ChartMarker Visible="true" Height="10" Width="10"></ChartMarker>
        </ChartSeries>
        <ChartSeries DataSource="@WeatherReport2" XName="X" High="High" Low="Low" Width="2" Type="Syncfusion.Blazor.Charts.ChartSeriesType.RangeColumn">
            <ChartEmptyPointSettings Mode="EmptyPointMode.Average" Fill="#FFDE59"></ChartEmptyPointSettings>
            <ChartMarker Visible="true" Height="10" Width="10"></ChartMarker>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    public class ChartData
    {

        public string X { get; set; }
        public double Low { get; set; }
        public double High { get; set; }
    }

    public List<ChartData> WeatherReport1 = new List<ChartData>
    {
        new  ChartData { X=  "Sun", Low=  3.1, High=  10.8 },
        new  ChartData { X=  "Mon", Low=  5.7, High=  14.4 },
        new  ChartData { X=  "Tue", Low=  8.4, High=  16.9 },
        new  ChartData { X=  "Wed", Low=  double.NaN, High=  double.NaN },
        new  ChartData { X=  "Thu", Low=  8.5, High=  16.1 },
        new  ChartData { X=  "Fri", Low=  6.0, High=  12.5 },
        new  ChartData { X=  "Sat", Low=  1.5, High=  6.9 }
    };

    public List<ChartData> WeatherReport2 = new List<ChartData>
    {
        new  ChartData { X=  "Sun", Low=  2.5, High=  9.8 },
        new  ChartData { X=  "Mon", Low=  4.7, High=  11.4 },
        new  ChartData { X=  "Tue", Low=  6.4, High=  14.4 },
        new  ChartData { X=  "Wed", Low=  double.NaN, High=  double.NaN },
        new  ChartData { X=  "Thu", Low=  7.5, High=  15.1 },
        new  ChartData { X=  "Fri", Low=  3.0, High=  10.5 },
        new  ChartData { X=  "Sat", Low=  1.2, High=  7.9 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/rNBztlBtDsChfQHL?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

**Border**

Use the [`Border`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEmptyPointSettings.html#Syncfusion_Blazor_Charts_ChartEmptyPointSettings_Border) property to customize the [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEmptyPointBorder.html#Syncfusion_Blazor_Charts_ChartEmptyPointBorder_Width) and [Color](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEmptyPointBorder.html#Syncfusion_Blazor_Charts_ChartEmptyPointBorder_Color) of the border for empty points.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category"></ChartPrimaryXAxis>

    <ChartSeriesCollection>
        <ChartSeries DataSource="@WeatherReport1" XName="X" High="High" Low="Low" Width="2" Type="Syncfusion.Blazor.Charts.ChartSeriesType.RangeColumn">
            <ChartEmptyPointSettings Mode="EmptyPointMode.Average" Fill="#FFDE59">
                <ChartEmptyPointBorder Color="red" Width="2"></ChartEmptyPointBorder>
            </ChartEmptyPointSettings>
            <ChartMarker Visible="true" Height="10" Width="10"></ChartMarker>
        </ChartSeries>
        <ChartSeries DataSource="@WeatherReport2" XName="X" High="High" Low="Low" Width="2" Type="Syncfusion.Blazor.Charts.ChartSeriesType.RangeColumn">
            <ChartEmptyPointSettings Mode="EmptyPointMode.Average" Fill="#FFDE59">
                <ChartEmptyPointBorder Color="red" Width="2"></ChartEmptyPointBorder>
            </ChartEmptyPointSettings>
            <ChartMarker Visible="true" Height="10" Width="10"></ChartMarker>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    public class ChartData
    {

        public string X { get; set; }
        public double Low { get; set; }
        public double High { get; set; }
    }

    public List<ChartData> WeatherReport1 = new List<ChartData>
    {
        new  ChartData { X=  "Sun", Low=  3.1, High=  10.8 },
        new  ChartData { X=  "Mon", Low=  5.7, High=  14.4 },
        new  ChartData { X=  "Tue", Low=  8.4, High=  16.9 },
        new  ChartData { X=  "Wed", Low=  double.NaN, High=  double.NaN },
        new  ChartData { X=  "Thu", Low=  8.5, High=  16.1 },
        new  ChartData { X=  "Fri", Low=  6.0, High=  12.5 },
        new  ChartData { X=  "Sat", Low=  1.5, High=  6.9 }
    };

    public List<ChartData> WeatherReport2 = new List<ChartData>
    {
        new  ChartData { X=  "Sun", Low=  2.5, High=  9.8 },
        new  ChartData { X=  "Mon", Low=  4.7, High=  11.4 },
        new  ChartData { X=  "Tue", Low=  6.4, High=  14.4 },
        new  ChartData { X=  "Wed", Low=  double.NaN, High=  double.NaN },
        new  ChartData { X=  "Thu", Low=  7.5, High=  15.1 },
        new  ChartData { X=  "Fri", Low=  3.0, High=  10.5 },
        new  ChartData { X=  "Sat", Low=  1.2, High=  7.9 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/htBzXFVjtshfELkG?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Events

### Series render

The [`OnSeriesRender`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_OnSeriesRender) event allows you to customize series properties, such as [Data](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SeriesRenderEventArgs.html#Syncfusion_Blazor_Charts_SeriesRenderEventArgs_Data), [Fill](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SeriesRenderEventArgs.html#Syncfusion_Blazor_Charts_SeriesRenderEventArgs_Fill), and [Series](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SeriesRenderEventArgs.html#Syncfusion_Blazor_Charts_SeriesRenderEventArgs_Series), before they are rendered on the chart.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category"></ChartPrimaryXAxis>
    <ChartEvents OnSeriesRender="SeriesRender"></ChartEvents>
    <ChartSeriesCollection>
        <ChartSeries DataSource="@WeatherReport1" XName="X" Name="Series1" High="High" Low="Low" Width="2" Type="Syncfusion.Blazor.Charts.ChartSeriesType.RangeColumn" />
        <ChartSeries DataSource="@WeatherReport2" XName="X" Name="Series2" High="High" Low="Low" Width="2" Type="Syncfusion.Blazor.Charts.ChartSeriesType.RangeColumn" />
    </ChartSeriesCollection>
</SfChart>

@code {
    public class ChartData
    {

        public string X { get; set; }
        public double Low { get; set; }
        public double High { get; set; }
    }

    public void SeriesRender(SeriesRenderEventArgs args)
    {
        if (args.Series.Name == "Series1")
        {
            args.Fill = "blue";
        }
        else if (args.Series.Name == "Series2")
        {
            args.Fill = "green";
        }
    }

    public List<ChartData> WeatherReport1 = new List<ChartData>
    {
        new ChartData { X= "Sun", Low= 3.1, High= 10.8 },
        new ChartData { X= "Mon", Low= 5.7, High= 14.4 },
        new ChartData { X= "Tue", Low= 8.4, High= 16.9 },
        new ChartData { X= "Wed", Low= 10.6, High= 19.2 },
        new ChartData { X= "Thu", Low= 8.5, High= 16.1 },
        new ChartData { X= "Fri", Low= 6.0, High= 12.5 },
        new ChartData { X= "Sat", Low= 1.5, High= 6.9 }
    };

    public List<ChartData> WeatherReport2 = new List<ChartData>
    {
        new ChartData { X= "Sun", Low= 2.5, High= 9.8 },
        new ChartData { X= "Mon", Low= 4.7, High= 11.4 },
        new ChartData { X= "Tue", Low= 6.4, High= 14.4 },
        new ChartData { X= "Wed", Low= 9.6, High= 17.2 },
        new ChartData { X= "Thu", Low= 7.5, High= 15.1 },
        new ChartData { X= "Fri", Low= 3.0, High= 10.5 },
        new ChartData { X= "Sat", Low= 1.2, High= 7.9 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BthfZvBDXMSZESmh?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Point render

The [`OnPointRender`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_OnPointRender) event allows you to customize each data point before it is rendered on the chart.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category"></ChartPrimaryXAxis>
    <ChartEvents OnPointRender="PointRender"></ChartEvents>
    <ChartSeriesCollection>
        <ChartSeries DataSource="@WeatherReport1" XName="X" Name="Series1" High="High" Low="Low" Width="2" Type="Syncfusion.Blazor.Charts.ChartSeriesType.RangeColumn" />
        <ChartSeries DataSource="@WeatherReport2" XName="X" Name="Series2" High="High" Low="Low" Width="2" Type="Syncfusion.Blazor.Charts.ChartSeriesType.RangeColumn" />
    </ChartSeriesCollection>
    <ChartLegendSettings Visible="false"></ChartLegendSettings>
</SfChart>

@code {
    public class ChartData
    {

        public string X { get; set; }
        public double Low { get; set; }
        public double High { get; set; }
    }

    public void PointRender(PointRenderEventArgs args)
    {
        args.Fill = (args.Point.Index % 2 != 0) ? "#ff6347" : "#009cb8";
    }

    public List<ChartData> WeatherReport1 = new List<ChartData>
    {
        new ChartData { X= "Sun", Low= 3.1, High= 10.8 },
        new ChartData { X= "Mon", Low= 5.7, High= 14.4 },
        new ChartData { X= "Tue", Low= 8.4, High= 16.9 },
        new ChartData { X= "Wed", Low= 10.6, High= 19.2 },
        new ChartData { X= "Thu", Low= 8.5, High= 16.1 },
        new ChartData { X= "Fri", Low= 6.0, High= 12.5 },
        new ChartData { X= "Sat", Low= 1.5, High= 6.9 }
    };

    public List<ChartData> WeatherReport2 = new List<ChartData>
    {
        new ChartData { X= "Sun", Low= 2.5, High= 9.8 },
        new ChartData { X= "Mon", Low= 4.7, High= 11.4 },
        new ChartData { X= "Tue", Low= 6.4, High= 14.4 },
        new ChartData { X= "Wed", Low= 9.6, High= 17.2 },
        new ChartData { X= "Thu", Low= 7.5, High= 15.1 },
        new ChartData { X= "Fri", Low= 3.0, High= 10.5 },
        new ChartData { X= "Sat", Low= 1.2, High= 7.9 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/rjVztaigzJrTUPvR?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

N> Refer to our [Blazor Charts](https://www.syncfusion.com/blazor-components/blazor-charts) feature tour page for its groundbreaking feature representations and also explore our [Blazor Chart Example](https://blazor.syncfusion.com/demos/chart/line?theme=bootstrap5) to know various chart types and how to represent time-dependent data, showing trends at equal intervals.

## See also

* [Data Label](../data-labels)
* [Tooltip](../tool-tip)