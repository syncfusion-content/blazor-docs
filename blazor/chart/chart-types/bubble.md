---
layout: post
title: Bubble Chart in Blazor Charts Component | Syncfusion
description: Check out and learn how to configure and customize the Bubble Chart in Syncfusion Blazor Charts component.
platform: Blazor
control: Chart
documentation: ug
---

# Bubble Chart in Blazor Charts Component

## Bubble Chart

The Bubble Chart is similar to the Scatter chart but visualizes a third parameter using the marker size. To render a bubble series, set the series [Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Type) to [Bubble](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeriesType.html#Syncfusion_Blazor_Charts_ChartSeriesType_Bubble). It displays data with three parameters: [XName](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_XName), [YName](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_YName), and [Size](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Size). The bubble size is determined by the third parameter.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartSeriesCollection>
        <ChartSeries DataSource="@SalesReports" XName="X" YName="Y" Type="ChartSeriesType.Bubble">
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    public class ChartData
    {
        public double X { get; set; }
        public double Y { get; set; }
        public string Text { get; set; }
    }

    public List<ChartData> SalesReports = new List<ChartData>
	{
        new ChartData { X = 92.2, Y = 7.8, Text = "China" },
        new ChartData { X = 74, Y = 6.5, Text = "India" },
        new ChartData { X = 90.4, Y = 6.0, Text = "Indonesia" },
        new ChartData { X = 99.4,  = 2.2, Text = "US" },
        new ChartData { X = 88.6, Y = 1.3, Text = "Brazil" },
        new ChartData { X = 99, Y = 0.7, Text = "Germany" },
        new ChartData { X = 72, Y = 2.0, Text = "Egypt" },
        new ChartData { X = 99.6, Y = 3.4, Text = "Russia" },
        new ChartData { X = 99, Y = 0.2, Text = "Japan" },
        new ChartData { X = 86.1, Y = 4.0, Text = "Mexico" },
        new ChartData { X = 92.6, Y = 6.6, Text = "Philippines" },
        new ChartData { X = 61.3,  = 1.45, Text = "Nigeria" },
        new ChartData { X = 82.2, Y = 3.97, Text = "Hong Kong" },
        new ChartData { X = 79.2, Y = 3.9, Text = "Netherland" },
        new ChartData { X = 72.5, Y = 4.5, Text = "Jordan" },
        new ChartData { X = 81, Y = 3.5, Text = "Australia" },
        new ChartData { X = 66.8, Y = 3.9, Text = "Mongolia" },
        new ChartData { X = 78.4, Y = 2.9, Text = "Taiwan" }
    };
}

``` 
{% previewsample "https://blazorplayground.syncfusion.com/embed/hNVfZlVZAFsaTHgz?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor Bubble Chart](../images/chart-types-images/blazor-bubble-chart.png)

Refer to the [Blazor Bubble Charts](https://www.syncfusion.com/blazor-components/blazor-charts/chart-types/bubble-chart) feature tour page for more feature details. Explore the [Blazor Bubble Chart Example](https://blazor.syncfusion.com/demos/chart/bubble?theme=bootstrap5) for interactive examples.

## Binding data with series

Bind data to the chart using the [`DataSource`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_DataSource) property in the series configuration. The [`DataSource`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_DataSource) value can be set using either [`SfDataManager`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) or a list of business objects. For more information, see [Working with Data](../working-with-data). Map the data fields to the chart series' [`XName`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_XName) and [`YName`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_YName) properties.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartSeriesCollection>
        <ChartSeries DataSource="@SalesReports" XName="X" YName="Y" Type="ChartSeriesType.Bubble">
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    public class ChartData
    {
        public double X { get; set; }
        public double Y { get; set; }
        public string Text { get; set; }
    }

    public List<ChartData> SalesReports = new List<ChartData>
	{
        new ChartData { X = 92.2, Y = 7.8, Text = "China" },
        new ChartData { X = 74, Y = 6.5, Text = "India" },
        new ChartData { X = 90.4, Y = 6.0, Text = "Indonesia" },
        new ChartData { X = 99.4,  = 2.2, Text = "US" },
        new ChartData { X = 88.6, Y = 1.3, Text = "Brazil" },
        new ChartData { X = 99, Y = 0.7, Text = "Germany" },
        new ChartData { X = 72, Y = 2.0, Text = "Egypt" },
        new ChartData { X = 99.6, Y = 3.4, Text = "Russia" },
        new ChartData { X = 99, Y = 0.2, Text = "Japan" },
        new ChartData { X = 86.1, Y = 4.0, Text = "Mexico" },
        new ChartData { X = 92.6, Y = 6.6, Text = "Philippines" },
        new ChartData { X = 61.3,  = 1.45, Text = "Nigeria" },
        new ChartData { X = 82.2, Y = 3.97, Text = "Hong Kong" },
        new ChartData { X = 79.2, Y = 3.9, Text = "Netherland" },
        new ChartData { X = 72.5, Y = 4.5, Text = "Jordan" },
        new ChartData { X = 81, Y = 3.5, Text = "Australia" },
        new ChartData { X = 66.8, Y = 3.9, Text = "Mongolia" },
        new ChartData { X = 78.4, Y = 2.9, Text = "Taiwan" }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/hNVfZlVZAFsaTHgz?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Series customization

Customize the [Bubble](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeriesType.html#Syncfusion_Blazor_Charts_ChartSeriesType_Bubble) series using the following properties:

**Fill**

The [Fill](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Fill) property sets the color for the series.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartSeriesCollection>
        <ChartSeries DataSource="@SalesReports" XName="X" YName="Y" Fill="blue" Type="Syncfusion.Blazor.Charts.ChartSeriesType.Bubble">
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    public class ChartData
    {
        public double X { get; set; }
        public double Y { get; set; }
        public string Text { get; set; }
    }

    public List<ChartData> SalesReports = new List<ChartData>
    {
        new ChartData { X = 92.2, Y = 7.8, Text = "China" },
        new ChartData { X = 74, Y = 6.5, Text = "India" },
        new ChartData { X = 90.4, Y = 6.0, Text = "Indonesia" },
        new ChartData { X = 99.4,  = 2.2, Text = "US" },
        new ChartData { X = 88.6, Y = 1.3, Text = "Brazil" },
        new ChartData { X = 99, Y = 0.7, Text = "Germany" },
        new ChartData { X = 72, Y = 2.0, Text = "Egypt" },
        new ChartData { X = 99.6, Y = 3.4, Text = "Russia" },
        new ChartData { X = 99, Y = 0.2, Text = "Japan" },
        new ChartData { X = 86.1, Y = 4.0, Text = "Mexico" },
        new ChartData { X = 92.6, Y = 6.6, Text = "Philippines" },
        new ChartData { X = 61.3,  = 1.45, Text = "Nigeria" },
        new ChartData { X = 82.2, Y = 3.97, Text = "Hong Kong" },
        new ChartData { X = 79.2, Y = 3.9, Text = "Netherland" },
        new ChartData { X = 72.5, Y = 4.5, Text = "Jordan" },
        new ChartData { X = 81, Y = 3.5, Text = "Australia" },
        new ChartData { X = 66.8, Y = 3.9, Text = "Mongolia" },
        new ChartData { X = 78.4, Y = 2.9, Text = "Taiwan" }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/hjBJjFLDKFITLPEy?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

Apply a gradient color to the bubble series by configuring the [Fill](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Fill) property with gradient values.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartSeriesCollection>
        <ChartSeries DataSource="@SalesReports" XName="X" YName="Y" Fill="url(#grad1)" Type="Syncfusion.Blazor.Charts.ChartSeriesType.Bubble">
        </ChartSeries>
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

@code {
    public class ChartData
    {
        public double X { get; set; }
        public double Y { get; set; }
        public string Text { get; set; }
    }

    public List<ChartData> SalesReports = new List<ChartData>
    {
        new ChartData { X = 92.2, Y = 7.8, Text = "China" },
        new ChartData { X = 74, Y = 6.5, Text = "India" },
        new ChartData { X = 90.4, Y = 6.0, Text = "Indonesia" },
        new ChartData { X = 99.4,  = 2.2, Text = "US" },
        new ChartData { X = 88.6, Y = 1.3, Text = "Brazil" },
        new ChartData { X = 99, Y = 0.7, Text = "Germany" },
        new ChartData { X = 72, Y = 2.0, Text = "Egypt" },
        new ChartData { X = 99.6, Y = 3.4, Text = "Russia" },
        new ChartData { X = 99, Y = 0.2, Text = "Japan" },
        new ChartData { X = 86.1, Y = 4.0, Text = "Mexico" },
        new ChartData { X = 92.6, Y = 6.6, Text = "Philippines" },
        new ChartData { X = 61.3,  = 1.45, Text = "Nigeria" },
        new ChartData { X = 82.2, Y = 3.97, Text = "Hong Kong" },
        new ChartData { X = 79.2, Y = 3.9, Text = "Netherland" },
        new ChartData { X = 72.5, Y = 4.5, Text = "Jordan" },
        new ChartData { X = 81, Y = 3.5, Text = "Australia" },
        new ChartData { X = 66.8, Y = 3.9, Text = "Mongolia" },
        new ChartData { X = 78.4, Y = 2.9, Text = "Taiwan" }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BtBfZlVjgFdRuSQm?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

**Opacity**

The [Opacity](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Opacity) property controls the transparency of the [Fill](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Fill) color, allowing adjustment of the series' appearance.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartSeriesCollection>
        <ChartSeries DataSource="@SalesReports" XName="X" YName="Y" Opacity="0.5" Fill="blue" Type="Syncfusion.Blazor.Charts.ChartSeriesType.Bubble">
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    public class ChartData
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Size { get; set; }
        public string Text { get; set; }
    }

    public List<ChartData> SalesReports = new List<ChartData>
    {
        new ChartData { X = 92.2, Y = 7.8, Text = "China" },
        new ChartData { X = 74, Y = 6.5, Text = "India" },
        new ChartData { X = 90.4, Y = 6.0, Text = "Indonesia" },
        new ChartData { X = 99.4,  = 2.2, Text = "US" },
        new ChartData { X = 88.6, Y = 1.3, Text = "Brazil" },
        new ChartData { X = 99, Y = 0.7, Text = "Germany" },
        new ChartData { X = 72, Y = 2.0, Text = "Egypt" },
        new ChartData { X = 99.6, Y = 3.4, Text = "Russia" },
        new ChartData { X = 99, Y = 0.2, Text = "Japan" },
        new ChartData { X = 86.1, Y = 4.0, Text = "Mexico" },
        new ChartData { X = 92.6, Y = 6.6, Text = "Philippines" },
        new ChartData { X = 61.3,  = 1.45, Text = "Nigeria" },
        new ChartData { X = 82.2, Y = 3.97, Text = "Hong Kong" },
        new ChartData { X = 79.2, Y = 3.9, Text = "Netherland" },
        new ChartData { X = 72.5, Y = 4.5, Text = "Jordan" },
        new ChartData { X = 81, Y = 3.5, Text = "Australia" },
        new ChartData { X = 66.8, Y = 3.9, Text = "Mongolia" },
        new ChartData { X = 78.4, Y = 2.9, Text = "Taiwan" }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/VDhpNbhjgvPifngh?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Bubble size mapping

Map the size value from the data source using the [Size](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Size) property.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartSeriesCollection>
        <ChartSeries DataSource="@SalesReports" XName="X" YName="Y" Size="Size" Type="Syncfusion.Blazor.Charts.ChartSeriesType.Bubble">
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    public class ChartData
    {
        public double X { get; set; }
        public double Y { get; set; }
        public string Text { get; set; }
        public double Size { get; set; }
    }

    public List<ChartData> SalesReports = new List<ChartData>
    {
        new ChartData { X = 92.2, Y = 7.8, Size = 1.347, Text = "China" },
        new ChartData { X = 74, Y = 6.5, Size = 1.241, Text = "India" },
        new ChartData { X = 90.4, Y = 6.0, Size = 0.238, Text = "Indonesia" },
        new ChartData { X = 99.4, Y = 2.2, Size = 0.312, Text = "US" },
        new ChartData { X = 88.6, Y = 1.3, Size = 0.197, Text = "Brazil" },
        new ChartData { X = 99, Y = 0.7, Size = 0.0818, Text = "Germany" },
        new ChartData { X = 72, Y = 2.0, Size = 0.0826, Text = "Egypt" },
        new ChartData { X = 99.6, Y = 3.4, Size = 0.143, Text = "Russia" },
        new ChartData { X = 99, Y = 0.2, Size = 0.128, Text = "Japan" },
        new ChartData { X = 86.1, Y = 4.0, Size = 0.115, Text = "Mexico" },
        new ChartData { X = 92.6, Y = 6.6, Size = 0.096, Text = "Philippines" },
        new ChartData { X = 61.3, Y = 1.45, Size = 0.162, Text = "Nigeria" },
        new ChartData { X = 82.2, Y = 3.97, Size = 0.7, Text = "Hong Kong" },
        new ChartData { X = 79.2, Y = 3.9, Size = 0.162, Text = "Netherland" },
        new ChartData { X = 72.5, Y = 4.5, Size = 0.7, Text = "Jordan" },
        new ChartData { X = 81, Y = 3.5, Size = 0.21, Text = "Australia" },
        new ChartData { X = 66.8, Y = 3.9, Size = 0.028, Text = "Mongolia" },
        new ChartData { X = 78.4, Y = 2.9, Size = 0.231, Text = "Taiwan" }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/rtLfZPVXqYFMgJrs?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Empty points

Data points with `null`, `double.NaN`, or `undefined` values are considered empty and are not plotted.

**Mode**

Use the [`Mode`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEmptyPointSettings.html#Syncfusion_Blazor_Charts_ChartEmptyPointSettings_Mode) property to specify how empty or missing data points are handled. The default mode is [`Gap`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.EmptyPointMode.html#Syncfusion_Blazor_Charts_EmptyPointMode_Gap).

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartSeriesCollection>
        <ChartSeries DataSource="@SalesReports" XName="X" YName="Y" Type="Syncfusion.Blazor.Charts.ChartSeriesType.Bubble">
            <ChartEmptyPointSettings Mode="EmptyPointMode.Gap"></ChartEmptyPointSettings>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    public class ChartData
    {
        public double X { get; set; }
        public double Y { get; set; }
        public string Text { get; set; }
    }

    public List<ChartData> SalesReports = new List<ChartData>
    {
        new ChartData { X = 92.2, Y = 7.8, Text = "China" },
        new ChartData { X = 74, Y = 6.5, Text = "India" },
        new ChartData { X = 90.4, Y = 6.0, Text = "Indonesia" },
        new ChartData { X = 99.4, Y = 2.2, Text = "US" },
        new ChartData { X = 88.6, Y = 1.3, Text = "Brazil" },
        new ChartData { X = 99, Y = 0.7, Text = "Germany" },
        new ChartData { X = 72, Y = 2.0, Text = "Egypt" },
        new ChartData { X = 99.6, Y = 3.4, Text = "Russia" },
        new ChartData { X = 99, Y = 0.2, Text = "Japan" },
        new ChartData { X = 86.1, Y = double.NaN, Text = "Mexico" },
        new ChartData { X = 92.6, Y = 6.6, Text = "Philippines" },
        new ChartData { X = 61.3, Y = 1.45, Text = "Nigeria" },
        new ChartData { X = 82.2, Y = 3.97, Text = "Hong Kong" },
        new ChartData { X = 79.2, Y = 3.9, Text = "Netherland" },
        new ChartData { X = 72.5, Y = 4.5, Text = "Jordan" },
        new ChartData { X = 81, Y = 3.5, Text = "Australia" },
        new ChartData { X = 66.8, Y = 3.9, Text = "Mongolia" },
        new ChartData { X = 78.4, Y = 2.9, Text = "Taiwan" }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/LDrTZbhZqkBHEzZc?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

**Fill**

Customize the fill color of empty points using the [`Fill`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEmptyPointSettings.html#Syncfusion_Blazor_Charts_ChartEmptyPointSettings_Fill) property.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartSeriesCollection>
        <ChartSeries DataSource="@SalesReports" XName="X" YName="Y" Type="Syncfusion.Blazor.Charts.ChartSeriesType.Bubble">
            <ChartEmptyPointSettings Mode="EmptyPointMode.Average" Fill="#FFDE59"></ChartEmptyPointSettings>
            <ChartMarker Height="10" Width="10"></ChartMarker>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    public class ChartData
    {
        public double X { get; set; }
        public double Y { get; set; }
        public string Text { get; set; }
    }

    public List<ChartData> SalesReports = new List<ChartData>
    {
        new ChartData { X = 92.2, Y = 7.8, Text = "China" },
        new ChartData { X = 74, Y = 6.5, Text = "India" },
        new ChartData { X = 90.4, Y = 6.0, Text = "Indonesia" },
        new ChartData { X = 99.4, Y = 2.2, Text = "US" },
        new ChartData { X = 88.6, Y = 1.3, Text = "Brazil" },
        new ChartData { X = 99, Y = 0.7, Text = "Germany" },
        new ChartData { X = 72, Y = 2.0, Text = "Egypt" },
        new ChartData { X = 99.6, Y = 3.4, Text = "Russia" },
        new ChartData { X = 99, Y = 0.2, Text = "Japan" },
        new ChartData { X = 86.1, Y = double.NaN, Text = "Mexico" },
        new ChartData { X = 92.6, Y = 6.6, Text = "Philippines" },
        new ChartData { X = 61.3, Y = 1.45, Text = "Nigeria" },
        new ChartData { X = 82.2, Y = 3.97, Text = "Hong Kong" },
        new ChartData { X = 79.2, Y = 3.9, Text = "Netherland" },
        new ChartData { X = 72.5, Y = 4.5, Text = "Jordan" },
        new ChartData { X = 81, Y = 3.5, Text = "Australia" },
        new ChartData { X = 66.8, Y = 3.9, Text = "Mongolia" },
        new ChartData { X = 78.4, Y = 2.9, Text = "Taiwan" }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/VZLJjlrjqEAmyrpm?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

**Border**

Customize the border width and color of empty points using the [`Border`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEmptyPointSettings.html#Syncfusion_Blazor_Charts_ChartEmptyPointSettings_Border) property, including [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEmptyPointBorder.html#Syncfusion_Blazor_Charts_ChartEmptyPointBorder_Width) and [Color](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEmptyPointBorder.html#Syncfusion_Blazor_Charts_ChartEmptyPointBorder_Color).

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartSeriesCollection>
        <ChartSeries DataSource="@SalesReports" XName="X" YName="Y" Type="Syncfusion.Blazor.Charts.ChartSeriesType.Bubble">
            <ChartEmptyPointSettings Mode="EmptyPointMode.Average" Fill="#FFDE59">
                <ChartEmptyPointBorder Color="red" Width="2"></ChartEmptyPointBorder>
            </ChartEmptyPointSettings>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    public class ChartData
    {
        public double X { get; set; }
        public double Y { get; set; }
        public string Text { get; set; }
    }

    public List<ChartData> SalesReports = new List<ChartData>
    {
        new ChartData { X = 92.2, Y = 7.8, Text = "China" },
        new ChartData { X = 74, Y = 6.5, Text = "India" },
        new ChartData { X = 90.4, Y = 6.0, Text = "Indonesia" },
        new ChartData { X = 99.4, Y = 2.2, Text = "US" },
        new ChartData { X = 88.6, Y = 1.3, Text = "Brazil" },
        new ChartData { X = 99, Y = 0.7, Text = "Germany" },
        new ChartData { X = 72, Y = 2.0, Text = "Egypt" },
        new ChartData { X = 99.6, Y = 3.4, Text = "Russia" },
        new ChartData { X = 99, Y = 0.2, Text = "Japan" },
        new ChartData { X = 86.1, Y = double.NaN, Text = "Mexico" },
        new ChartData { X = 92.6, Y = 6.6, Text = "Philippines" },
        new ChartData { X = 61.3, Y = 1.45, Text = "Nigeria" },
        new ChartData { X = 82.2, Y = 3.97, Text = "Hong Kong" },
        new ChartData { X = 79.2, Y = 3.9, Text = "Netherland" },
        new ChartData { X = 72.5, Y = 4.5, Text = "Jordan" },
        new ChartData { X = 81, Y = 3.5, Text = "Australia" },
        new ChartData { X = 66.8, Y = 3.9, Text = "Mongolia" },
        new ChartData { X = 78.4, Y = 2.9, Text = "Taiwan" }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/VZrfNFBNAEzlQWwl?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Events

### Series render

The [`OnSeriesRender`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_OnSeriesRender) event enables customization of series properties, such as [Data](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SeriesRenderEventArgs.html#Syncfusion_Blazor_Charts_SeriesRenderEventArgs_Data), [Fill](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SeriesRenderEventArgs.html#Syncfusion_Blazor_Charts_SeriesRenderEventArgs_Fill), and [Series](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SeriesRenderEventArgs.html#Syncfusion_Blazor_Charts_SeriesRenderEventArgs_Series), before rendering.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartSeriesCollection>
        <ChartEvents OnSeriesRender="SeriesRender" />
        <ChartSeries DataSource="@SalesReports" XName="X" YName="Y" Type="Syncfusion.Blazor.Charts.ChartSeriesType.Bubble">
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    public class ChartData
    {
        public double X { get; set; }
        public double Y { get; set; }
        public string Text { get; set; }
    }

    public void SeriesRender(SeriesRenderEventArgs args)
    {
        args.Fill = "#FF4081";
    }

    public List<ChartData> SalesReports = new List<ChartData>
    {
        new ChartData { X = 92.2, Y = 7.8, Text = "China" },
        new ChartData { X = 74, Y = 6.5, Text = "India" },
        new ChartData { X = 90.4, Y = 6.0, Text = "Indonesia" },
        new ChartData { X = 99.4,  = 2.2, Text = "US" },
        new ChartData { X = 88.6, Y = 1.3, Text = "Brazil" },
        new ChartData { X = 99, Y = 0.7, Text = "Germany" },
        new ChartData { X = 72, Y = 2.0, Text = "Egypt" },
        new ChartData { X = 99.6, Y = 3.4, Text = "Russia" },
        new ChartData { X = 99, Y = 0.2, Text = "Japan" },
        new ChartData { X = 86.1, Y = 4.0, Text = "Mexico" },
        new ChartData { X = 92.6, Y = 6.6, Text = "Philippines" },
        new ChartData { X = 61.3,  = 1.45, Text = "Nigeria" },
        new ChartData { X = 82.2, Y = 3.97, Text = "Hong Kong" },
        new ChartData { X = 79.2, Y = 3.9, Text = "Netherland" },
        new ChartData { X = 72.5, Y = 4.5, Text = "Jordan" },
        new ChartData { X = 81, Y = 3.5, Text = "Australia" },
        new ChartData { X = 66.8, Y = 3.9, Text = "Mongolia" },
        new ChartData { X = 78.4, Y = 2.9, Text = "Taiwan" }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/LZBJNbhjgEOdityZ?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Point render

The [`OnPointRender`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_OnPointRender) event allows customization of each data point before rendering.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartSeriesCollection>
        <ChartEvents OnPointRender="PointRender" />
        <ChartSeries DataSource="@SalesReports" XName="X" YName="Y" Type="Syncfusion.Blazor.Charts.ChartSeriesType.Bubble">
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    public class ChartData
    {
        public double X { get; set; }
        public double Y { get; set; }
        public string Text { get; set; }
    }

    public void PointRender(PointRenderEventArgs args)
    {
         args.Fill = args.Point.X.ToString() == "86.1" ? "#E91E63" : "#3F51B5";
    }

    public List<ChartData> SalesReports = new List<ChartData>
    {
        new ChartData { X = 92.2, Y = 7.8, Text = "China" },
        new ChartData { X = 74, Y = 6.5, Text = "India" },
        new ChartData { X = 90.4, Y = 6.0, Text = "Indonesia" },
        new ChartData { X = 99.4,  = 2.2, Text = "US" },
        new ChartData { X = 88.6, Y = 1.3, Text = "Brazil" },
        new ChartData { X = 99, Y = 0.7, Text = "Germany" },
        new ChartData { X = 72, Y = 2.0, Text = "Egypt" },
        new ChartData { X = 99.6, Y = 3.4, Text = "Russia" },
        new ChartData { X = 99, Y = 0.2, Text = "Japan" },
        new ChartData { X = 86.1, Y = 4.0, Text = "Mexico" },
        new ChartData { X = 92.6, Y = 6.6, Text = "Philippines" },
        new ChartData { X = 61.3,  = 1.45, Text = "Nigeria" },
        new ChartData { X = 82.2, Y = 3.97, Text = "Hong Kong" },
        new ChartData { X = 79.2, Y = 3.9, Text = "Netherland" },
        new ChartData { X = 72.5, Y = 4.5, Text = "Jordan" },
        new ChartData { X = 81, Y = 3.5, Text = "Australia" },
        new ChartData { X = 66.8, Y = 3.9, Text = "Mongolia" },
        new ChartData { X = 78.4, Y = 2.9, Text = "Taiwan" }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/rtBJtFhNpNKNdooM?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

N> Refer to our [Blazor Charts](https://www.syncfusion.com/blazor-components/blazor-charts) feature tour page for its groundbreaking feature representations and also explore our [Blazor Chart Example](https://blazor.syncfusion.com/demos/chart/line?theme=bootstrap5) to know various chart types and how to represent time-dependent data, showing trends at equal intervals.

## See also

* [Data label](../data-labels)
* [Tooltip](../tool-tip)
