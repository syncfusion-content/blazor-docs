---
layout: post
title: Stacked Area in Blazor Charts Component | Syncfusion
description: Checkout and learn here all about Stacked Area Chart in Syncfusion Blazor Charts component and more.
platform: Blazor
control: Chart
documentation: ug
---

# Stacked Area in Blazor Charts Component

## Stacked Area

[Blazor Stacked Area Chart](https://www.syncfusion.com/blazor-components/blazor-charts/chart-types/stacked-area-chart) is a chart with Y values stacked over one another in the series order. It shows the relation between individual values to the total sum of the points. To render a [stacked area](https://www.syncfusion.com/blazor-components/blazor-charts/chart-types/stacked-area-chart) series in your chart, define the series [`Type`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Type) as [`StackingArea`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeriesType.html#Syncfusion_Blazor_Charts_ChartSeriesType_StackingArea) in your chart configuration. This indicates that the data should be represented as a stacked area chart, which is ideal for showing the contribution of each part to a total over time or across other categorical data.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category"/>
	
    <ChartSeriesCollection>
        <ChartSeries DataSource="@ChartDatas" XName="X" YName="Y" Type="ChartSeriesType.StackingArea"/>    
        <ChartSeries DataSource="@ChartDatas" XName="X" YName="Y1" Type="ChartSeriesType.StackingArea"/>
        <ChartSeries DataSource="@ChartDatas" XName="X" YName="Y2" Type="ChartSeriesType.StackingArea"/> 
    </ChartSeriesCollection>
</SfChart>

@code{
    public class ChartData
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Y1 { get; set; }
        public double Y2 { get; set; }
    }
	
    public List<ChartData> ChartDatas = new List<ChartData>
	{
        new ChartData{ X=2000, Y= 0.61, Y1= 0.03, Y2= 0.48},
        new ChartData{ X=2001, Y= 0.81, Y1= 0.05, Y2= 0.53 },
        new ChartData{ X=2002, Y= 0.91, Y1= 0.06, Y2= 0.57 },
        new ChartData{ X=2003, Y= 1, Y1= 0.09, Y2= 0.61 },
        new ChartData{ X=2004, Y= 1.19, Y1= 0.14, Y2= 0.63 },
        new ChartData{ X=2005, Y= 1.47, Y1= 0.20, Y2= 0.64 },
        new ChartData{ X=2006, Y= 1.74, Y1= 0.29, Y2= 0.66 },
        new ChartData{ X=2007, Y= 1.98, Y1= 0.46, Y2= 0.76 },
        new ChartData{ X=2008, Y= 1.99, Y1= 0.64, Y2= 0.77 },
        new ChartData{ X=2009, Y= 1.70, Y1= 0.75, Y2= 0.55 }
    };
}

``` 
{% previewsample "https://blazorplayground.syncfusion.com/embed/LDhUsVLxzRMlYUSx?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor Stacked Area Chart](../images/chart-types-images/blazor-stacked-area-chart.png)

N> Refer to our [Blazor Stacked Area Chart](https://www.syncfusion.com/blazor-components/blazor-charts/chart-types/stacked-area-chart) feature tour page to know about its other groundbreaking feature representations. Explore our [Blazor Stacked Area Chart Example](https://blazor.syncfusion.com/demos/chart/stacked-area?theme=bootstrap5) to know how to render and configure the Stacked Area type chart.

## Binding data with series

You can bind data to the chart using the [`DataSource`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_DataSource) property within the series configuration. The [`DataSource`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_DataSource) value can be set using either [`SfDataManager`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) property values or a list of business objects. More information on data binding can be found [here](../working-with-data). To display the data correctly, map the fields from the data to the chart series' [`XName`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_XName) and [`YName`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_YName) properties.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category"/>
	
    <ChartSeriesCollection>
        <ChartSeries DataSource="@ChartDatas" XName="X" YName="Y" Type="ChartSeriesType.StackingArea"/>    
        <ChartSeries DataSource="@ChartDatas" XName="X" YName="Y1" Type="ChartSeriesType.StackingArea"/>
        <ChartSeries DataSource="@ChartDatas" XName="X" YName="Y2" Type="ChartSeriesType.StackingArea"/> 
    </ChartSeriesCollection>
</SfChart>

@code{
    public class ChartData
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Y1 { get; set; }
        public double Y2 { get; set; }
    }
	
    public List<ChartData> ChartDatas = new List<ChartData>
	{
        new ChartData{ X=2000, Y= 0.61, Y1= 0.03, Y2= 0.48},
        new ChartData{ X=2001, Y= 0.81, Y1= 0.05, Y2= 0.53 },
        new ChartData{ X=2002, Y= 0.91, Y1= 0.06, Y2= 0.57 },
        new ChartData{ X=2003, Y= 1, Y1= 0.09, Y2= 0.61 },
        new ChartData{ X=2004, Y= 1.19, Y1= 0.14, Y2= 0.63 },
        new ChartData{ X=2005, Y= 1.47, Y1= 0.20, Y2= 0.64 },
        new ChartData{ X=2006, Y= 1.74, Y1= 0.29, Y2= 0.66 },
        new ChartData{ X=2007, Y= 1.98, Y1= 0.46, Y2= 0.76 },
        new ChartData{ X=2008, Y= 1.99, Y1= 0.64, Y2= 0.77 },
        new ChartData{ X=2009, Y= 1.70, Y1= 0.75, Y2= 0.55 }
    };
}

``` 
{% previewsample "https://blazorplayground.syncfusion.com/embed/LDhUsVLxzRMlYUSx?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Series customization

The following properties can be used to customize the [Stacked Area](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeriesType.html#Syncfusion_Blazor_Charts_ChartSeriesType_StackingArea) series.

**Fill**

The [Fill](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Fill) property determines the color applied to the series.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />

    <ChartSeriesCollection>
        <ChartSeries DataSource="@ChartDatas" XName="X" YName="Y" Fill="red" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingArea" />
        <ChartSeries DataSource="@ChartDatas" XName="X" YName="Y1" Fill="blue" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingArea" />
        <ChartSeries DataSource="@ChartDatas" XName="X" YName="Y2" Fill="green" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingArea" />
    </ChartSeriesCollection>
</SfChart>

@code {
    public class ChartData
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Y1 { get; set; }
        public double Y2 { get; set; }
    }

    public List<ChartData> ChartDatas = new List<ChartData>
    {
        new ChartData{ X=2000, Y= 0.61, Y1= 0.03, Y2= 0.48},
        new ChartData{ X=2001, Y= 0.81, Y1= 0.05, Y2= 0.53 },
        new ChartData{ X=2002, Y= 0.91, Y1= 0.06, Y2= 0.57 },
        new ChartData{ X=2003, Y= 1, Y1= 0.09, Y2= 0.61 },
        new ChartData{ X=2004, Y= 1.19, Y1= 0.14, Y2= 0.63 },
        new ChartData{ X=2005, Y= 1.47, Y1= 0.20, Y2= 0.64 },
        new ChartData{ X=2006, Y= 1.74, Y1= 0.29, Y2= 0.66 },
        new ChartData{ X=2007, Y= 1.98, Y1= 0.46, Y2= 0.76 },
        new ChartData{ X=2008, Y= 1.99, Y1= 0.64, Y2= 0.77 },
        new ChartData{ X=2009, Y= 1.70, Y1= 0.75, Y2= 0.55 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/VDLTNPsufiIAQhTr?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

The [Fill](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Fill) property can be used to apply a gradient color to the stacked area series. By configuring this property with gradient values, you can create a visually appealing effect in which the color transitions smoothly from one shade to another.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />

    <ChartSeriesCollection>
        <ChartSeries DataSource="@ChartDatas" XName="X" YName="Y" Fill="url(#grad1)" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingArea" />
        <ChartSeries DataSource="@ChartDatas" XName="X" YName="Y1" Fill="url(#grad2)" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingArea" />
        <ChartSeries DataSource="@ChartDatas" XName="X" YName="Y2" Fill="url(#grad3)" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingArea" />
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
            <stop offset="20%" style="stop-color:blue;stop-opacity:1" />
            <stop offset="100%" style="stop-color:black;stop-opacity:1" />
        </linearGradient>
    </defs>
</svg>

<svg style="height: 0">
    <defs>
        <linearGradient id="grad3" x1="0%" y1="0%" x2="0%" y2="100%">
            <stop offset="20%" style="stop-color:green;stop-opacity:1" />
            <stop offset="100%" style="stop-color:black;stop-opacity:1" />
        </linearGradient>
    </defs>
</svg>

@code {
    public class ChartData
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Y1 { get; set; }
        public double Y2 { get; set; }
    }

    public List<ChartData> ChartDatas = new List<ChartData>
    {
        new ChartData{ X=2000, Y= 0.61, Y1= 0.03, Y2= 0.48},
        new ChartData{ X=2001, Y= 0.81, Y1= 0.05, Y2= 0.53 },
        new ChartData{ X=2002, Y= 0.91, Y1= 0.06, Y2= 0.57 },
        new ChartData{ X=2003, Y= 1, Y1= 0.09, Y2= 0.61 },
        new ChartData{ X=2004, Y= 1.19, Y1= 0.14, Y2= 0.63 },
        new ChartData{ X=2005, Y= 1.47, Y1= 0.20, Y2= 0.64 },
        new ChartData{ X=2006, Y= 1.74, Y1= 0.29, Y2= 0.66 },
        new ChartData{ X=2007, Y= 1.98, Y1= 0.46, Y2= 0.76 },
        new ChartData{ X=2008, Y= 1.99, Y1= 0.64, Y2= 0.77 },
        new ChartData{ X=2009, Y= 1.70, Y1= 0.75, Y2= 0.55 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/LNBpXbWYTilVqwGp?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}


**Opacity**

The [Opacity](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Opacity) property specifies the transparency level of the [Fill](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Fill). Adjusting this property allows you to control how opaque or transparent the fill color of the series appears.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />

    <ChartSeriesCollection>
        <ChartSeries DataSource="@ChartDatas" XName="X" YName="Y" Fill="red" Opacity="0.5" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingArea" />
        <ChartSeries DataSource="@ChartDatas" XName="X" YName="Y1" Fill="blue" Opacity="0.5" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingArea" />
        <ChartSeries DataSource="@ChartDatas" XName="X" YName="Y2" Fill="green" Opacity="0.5" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingArea" />
    </ChartSeriesCollection>
</SfChart>

@code {
    public class ChartData
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Y1 { get; set; }
        public double Y2 { get; set; }
    }

    public List<ChartData> ChartDatas = new List<ChartData>
    {
        new ChartData{ X=2000, Y= 0.61, Y1= 0.03, Y2= 0.48},
        new ChartData{ X=2001, Y= 0.81, Y1= 0.05, Y2= 0.53 },
        new ChartData{ X=2002, Y= 0.91, Y1= 0.06, Y2= 0.57 },
        new ChartData{ X=2003, Y= 1, Y1= 0.09, Y2= 0.61 },
        new ChartData{ X=2004, Y= 1.19, Y1= 0.14, Y2= 0.63 },
        new ChartData{ X=2005, Y= 1.47, Y1= 0.20, Y2= 0.64 },
        new ChartData{ X=2006, Y= 1.74, Y1= 0.29, Y2= 0.66 },
        new ChartData{ X=2007, Y= 1.98, Y1= 0.46, Y2= 0.76 },
        new ChartData{ X=2008, Y= 1.99, Y1= 0.64, Y2= 0.77 },
        new ChartData{ X=2009, Y= 1.70, Y1= 0.75, Y2= 0.55 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/hDLTXvsYzrjDnWhZ?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

**DashArray**

The [DashArray](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_DashArray) property determines the dashes of series border.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />
	
    <ChartSeriesCollection>
        <ChartSeries DataSource="@ChartDatas" XName="X" YName="Y" Fill="pink" Opacity="0.7" DashArray="5,5" Type="ChartSeriesType.StackingArea">
            <ChartSeriesBorder Width="2" Color="black"></ChartSeriesBorder>
        </ChartSeries>
        <ChartSeries DataSource="@ChartDatas" XName="X" YName="Y1" Fill="blue" Opacity="0.7" DashArray="5,5" Type="ChartSeriesType.StackingArea">
            <ChartSeriesBorder Width="2" Color="black"></ChartSeriesBorder>
        </ChartSeries>
        <ChartSeries DataSource="@ChartDatas" XName="X" YName="Y2" Fill="green" Opacity="0.7" DashArray="5,5" Type="ChartSeriesType.StackingArea">
            <ChartSeriesBorder Width="2" Color="black"></ChartSeriesBorder>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code{
    public class ChartData
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Y1 { get; set; }
        public double Y2 { get; set; }
    }
	
    public List<ChartData> ChartDatas = new List<ChartData>
	{
          new ChartData{ X=2000, Y= 0.61, Y1= 0.03, Y2= 0.48},
          new ChartData{ X=2001, Y= 0.81, Y1= 0.05, Y2= 0.53 },
          new ChartData{ X=2002, Y= 0.91, Y1= 0.06, Y2= 0.57 },
          new ChartData{ X=2003, Y= 1, Y1= 0.09, Y2= 0.61 },
          new ChartData{ X=2004, Y= 1.19, Y1= 0.14, Y2= 0.63 },
          new ChartData{ X=2005, Y= 1.47, Y1= 0.20, Y2= 0.64 },
          new ChartData{ X=2006, Y= 1.74, Y1= 0.29, Y2= 0.66 },
          new ChartData{ X=2007, Y= 1.98, Y1= 0.46, Y2= 0.76 },
          new ChartData{ X=2008, Y= 1.99, Y1= 0.64, Y2= 0.77 },
          new ChartData{ X=2009, Y= 1.70, Y1= 0.75, Y2= 0.55 }
    };
}

``` 
{% previewsample "https://blazorplayground.syncfusion.com/embed/VjhKsrhdpxrCydRe?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

**Series Border**

The [ChartSeriesBorder](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeriesBorder.html) property determines the [Color](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCommonBorder.html#Syncfusion_Blazor_Charts_ChartCommonBorder_Color) and [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCommonBorder.html#Syncfusion_Blazor_Charts_ChartCommonBorder_Width) of series border.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />
	
    <ChartSeriesCollection>
        <ChartSeries DataSource="@ChartDatas" XName="X" YName="Y" Fill="pink" Opacity="0.7" DashArray="5,5" Type="ChartSeriesType.StackingArea">
            <ChartSeriesBorder Width="2" Color="black"></ChartSeriesBorder>
        </ChartSeries>
        <ChartSeries DataSource="@ChartDatas" XName="X" YName="Y1" Fill="blue" Opacity="0.7" DashArray="5,5" Type="ChartSeriesType.StackingArea">
            <ChartSeriesBorder Width="2" Color="black"></ChartSeriesBorder>
        </ChartSeries>
        <ChartSeries DataSource="@ChartDatas" XName="X" YName="Y2" Fill="green" Opacity="0.7" DashArray="5,5" Type="ChartSeriesType.StackingArea">
            <ChartSeriesBorder Width="2" Color="black"></ChartSeriesBorder>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code{
    public class ChartData
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Y1 { get; set; }
        public double Y2 { get; set; }
    }
	
    public List<ChartData> ChartDatas = new List<ChartData>
	{
          new ChartData{ X=2000, Y= 0.61, Y1= 0.03, Y2= 0.48},
          new ChartData{ X=2001, Y= 0.81, Y1= 0.05, Y2= 0.53 },
          new ChartData{ X=2002, Y= 0.91, Y1= 0.06, Y2= 0.57 },
          new ChartData{ X=2003, Y= 1, Y1= 0.09, Y2= 0.61 },
          new ChartData{ X=2004, Y= 1.19, Y1= 0.14, Y2= 0.63 },
          new ChartData{ X=2005, Y= 1.47, Y1= 0.20, Y2= 0.64 },
          new ChartData{ X=2006, Y= 1.74, Y1= 0.29, Y2= 0.66 },
          new ChartData{ X=2007, Y= 1.98, Y1= 0.46, Y2= 0.76 },
          new ChartData{ X=2008, Y= 1.99, Y1= 0.64, Y2= 0.77 },
          new ChartData{ X=2009, Y= 1.70, Y1= 0.75, Y2= 0.55 }
    };
}

``` 
{% previewsample "https://blazorplayground.syncfusion.com/embed/VjhKsrhdpxrCydRe?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Empty points

Data points with `null`, `double.NaN` or `undefined` values are considered empty. Empty data points are ignored and not plotted on the chart.

**Mode**

Use the [`Mode`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEmptyPointSettings.html#Syncfusion_Blazor_Charts_ChartEmptyPointSettings_Mode) property to define how empty or missing data points are handled in the series. The default mode for empty points is [`Gap`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.EmptyPointMode.html#Syncfusion_Blazor_Charts_EmptyPointMode_Gap).

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart Title="Family Expense for Month">
    <ChartPrimaryXAxis LabelRotation="90" ValueType="Syncfusion.Blazor.Charts.ValueType.Category">
    </ChartPrimaryXAxis>

    <ChartSeriesCollection>
        <ChartSeries XName="X" DataSource="@ExpenseReports" YName="Y" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingArea">
            <ChartEmptyPointSettings Mode="EmptyPointMode.Average"></ChartEmptyPointSettings>
            <ChartMarker Visible="true"></ChartMarker>
        </ChartSeries>
        <ChartSeries XName="X" DataSource="@ExpenseReports" YName="Y1" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingArea">
            <ChartMarker Visible="true"></ChartMarker>
        </ChartSeries>
        <ChartSeries XName="X" DataSource="@ExpenseReports" YName="Y2" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingArea">
            <ChartEmptyPointSettings Mode="EmptyPointMode.Gap"></ChartEmptyPointSettings>
            <ChartMarker Visible="true"></ChartMarker>
        </ChartSeries>
        <ChartSeries XName="X" DataSource="@ExpenseReports" YName="Y3" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingArea">
            <ChartMarker Visible="true"></ChartMarker>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    public class ChartData
    {
        public string X { get; set; }
        public double Y { get; set; }
        public double Y1 { get; set; }
        public double Y2 { get; set; }
        public double Y3 { get; set; }
    }

    public List<ChartData> ExpenseReports = new List<ChartData>
    {
         new ChartData { X = "Food" , Y = 90, Y1 = 40 , Y2= 70, Y3= 120},
         new ChartData { X = "Transport", Y = 80, Y1 = 90, Y2= 110, Y3= 70 },
         new ChartData { X = "Medical",Y = 50, Y1 = 80, Y2= 120, Y3= 50 },
         new ChartData { X = "Clothes",Y = 70, Y1 = 30, Y2= 60, Y3= 180 },
         new ChartData { X = "Personal Care", Y = 30, Y1 = 80, Y2= 80, Y3= 30 },
         new ChartData { X = "Books", Y = double.NaN, Y1 = 40, Y2= double.NaN, Y3= 270},
         new ChartData { X = "Fitness",Y = 100, Y1 = 30, Y2= 70, Y3= 40 },
         new ChartData { X = "Electricity", Y = 55, Y1 = 95, Y2= 55, Y3= 75},
         new ChartData { X = "Tax", Y = 20, Y1 = 50, Y2= 40, Y3= 65 },
         new ChartData { X = "Pet Care", Y = 40, Y1 = 20, Y2= 80, Y3= 95 },
         new ChartData { X = "Education", Y = 45, Y1 = 15, Y2= 45, Y3= 195 },
         new ChartData { X = "Entertainment", Y = 75, Y1 = 45, Y2= 65, Y3= 115 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BXBpjEsgAolUQBDo?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

**Fill**

Use the [`Fill`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEmptyPointSettings.html#Syncfusion_Blazor_Charts_ChartEmptyPointSettings_Fill) property to customize the fill color of empty points in the series.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart Title="Family Expense for Month">
    <ChartPrimaryXAxis LabelRotation="90" ValueType="Syncfusion.Blazor.Charts.ValueType.Category">
    </ChartPrimaryXAxis>

    <ChartSeriesCollection>
        <ChartSeries XName="X" DataSource="@ExpenseReports" YName="Y" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingArea">
            <ChartEmptyPointSettings Mode="EmptyPointMode.Average" Fill="red"></ChartEmptyPointSettings>
            <ChartMarker Visible="true"></ChartMarker>
        </ChartSeries>
        <ChartSeries XName="X" DataSource="@ExpenseReports" YName="Y1" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingArea">
            <ChartMarker Visible="true"></ChartMarker>
        </ChartSeries>
        <ChartSeries XName="X" DataSource="@ExpenseReports" YName="Y2" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingArea">
            <ChartEmptyPointSettings Mode="EmptyPointMode.Gap"></ChartEmptyPointSettings>
            <ChartMarker Visible="true"></ChartMarker>
        </ChartSeries>
        <ChartSeries XName="X" DataSource="@ExpenseReports" YName="Y3" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingArea">
            <ChartMarker Visible="true"></ChartMarker>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    public class ChartData
    {
        public string X { get; set; }
        public double Y { get; set; }
        public double Y1 { get; set; }
        public double Y2 { get; set; }
        public double Y3 { get; set; }
    }

    public List<ChartData> ExpenseReports = new List<ChartData>
    {
         new ChartData { X = "Food" , Y = 90, Y1 = 40 , Y2= 70, Y3= 120},
         new ChartData { X = "Transport", Y = 80, Y1 = 90, Y2= 110, Y3= 70 },
         new ChartData { X = "Medical",Y = 50, Y1 = 80, Y2= 120, Y3= 50 },
         new ChartData { X = "Clothes",Y = 70, Y1 = 30, Y2= 60, Y3= 180 },
         new ChartData { X = "Personal Care", Y = 30, Y1 = 80, Y2= 80, Y3= 30 },
         new ChartData { X = "Books", Y = double.NaN, Y1 = 40, Y2= double.NaN, Y3= 270},
         new ChartData { X = "Fitness",Y = 100, Y1 = 30, Y2= 70, Y3= 40 },
         new ChartData { X = "Electricity", Y = 55, Y1 = 95, Y2= 55, Y3= 75},
         new ChartData { X = "Tax", Y = 20, Y1 = 50, Y2= 40, Y3= 65 },
         new ChartData { X = "Pet Care", Y = 40, Y1 = 20, Y2= 80, Y3= 95 },
         new ChartData { X = "Education", Y = 45, Y1 = 15, Y2= 45, Y3= 195 },
         new ChartData { X = "Entertainment", Y = 75, Y1 = 45, Y2= 65, Y3= 115 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/rNhJXksUqIaKdTsV?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

**Border**

Use the [`Border`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEmptyPointSettings.html#Syncfusion_Blazor_Charts_ChartEmptyPointSettings_Border) property to customize the [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEmptyPointBorder.html#Syncfusion_Blazor_Charts_ChartEmptyPointBorder_Width) and [Color](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEmptyPointBorder.html#Syncfusion_Blazor_Charts_ChartEmptyPointBorder_Color) of the border for empty points.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart Title="Family Expense for Month">
    <ChartPrimaryXAxis LabelRotation="90" ValueType="Syncfusion.Blazor.Charts.ValueType.Category">
    </ChartPrimaryXAxis>

    <ChartSeriesCollection>
        <ChartSeries XName="X" DataSource="@ExpenseReports" YName="Y" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingArea">
            <ChartEmptyPointSettings Mode="EmptyPointMode.Average" Fill="red">
                <ChartEmptyPointBorder Color="green" Width="2"></ChartEmptyPointBorder>
            </ChartEmptyPointSettings>
            <ChartMarker Visible="true"></ChartMarker>
        </ChartSeries>
        <ChartSeries XName="X" DataSource="@ExpenseReports" YName="Y1" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingArea">
            <ChartMarker Visible="true"></ChartMarker>
        </ChartSeries>
        <ChartSeries XName="X" DataSource="@ExpenseReports" YName="Y2" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingArea">
            <ChartEmptyPointSettings Mode="EmptyPointMode.Gap"></ChartEmptyPointSettings>
            <ChartMarker Visible="true"></ChartMarker>
        </ChartSeries>
        <ChartSeries XName="X" DataSource="@ExpenseReports" YName="Y3" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingArea">
            <ChartMarker Visible="true"></ChartMarker>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    public class ChartData
    {
        public string X { get; set; }
        public double Y { get; set; }
        public double Y1 { get; set; }
        public double Y2 { get; set; }
        public double Y3 { get; set; }
    }

    public List<ChartData> ExpenseReports = new List<ChartData>
    {
         new ChartData { X = "Food" , Y = 90, Y1 = 40 , Y2= 70, Y3= 120},
         new ChartData { X = "Transport", Y = 80, Y1 = 90, Y2= 110, Y3= 70 },
         new ChartData { X = "Medical",Y = 50, Y1 = 80, Y2= 120, Y3= 50 },
         new ChartData { X = "Clothes",Y = 70, Y1 = 30, Y2= 60, Y3= 180 },
         new ChartData { X = "Personal Care", Y = 30, Y1 = 80, Y2= 80, Y3= 30 },
         new ChartData { X = "Books", Y = double.NaN, Y1 = 40, Y2= double.NaN, Y3= 270},
         new ChartData { X = "Fitness",Y = 100, Y1 = 30, Y2= 70, Y3= 40 },
         new ChartData { X = "Electricity", Y = 55, Y1 = 95, Y2= 55, Y3= 75},
         new ChartData { X = "Tax", Y = 20, Y1 = 50, Y2= 40, Y3= 65 },
         new ChartData { X = "Pet Care", Y = 40, Y1 = 20, Y2= 80, Y3= 95 },
         new ChartData { X = "Education", Y = 45, Y1 = 15, Y2= 45, Y3= 195 },
         new ChartData { X = "Entertainment", Y = 75, Y1 = 45, Y2= 65, Y3= 115 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/VtBTNaCggdjLzXLg?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Stack Labels

The Stack Labels feature enables the display of cumulative total values for stacked chart segments directly through data labels. This feature provides an enhanced user experience when stacked chart series are used in Blazor Charts. 

The `Visible` property of the `ChartStackLabelSettings` is used to control the visibility of stack labels. Setting it to true will display the stack labels.

```cshtml
@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartStackLabelSettings Visible="true">
    </ChartStackLabelSettings>

    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />

    <ChartSeriesCollection>
        <ChartSeries DataSource="@ChartDatas" XName="X" YName="Y" Type="ChartSeriesType.StackingArea">
            <ChartSeriesAnimation Enable="false" />
            <ChartMarker>
                <ChartDataLabel Visible="true" />
            </ChartMarker>
        </ChartSeries>
        <ChartSeries DataSource="@ChartDatas" XName="X" YName="Y1" Type="ChartSeriesType.StackingArea">
            <ChartSeriesAnimation Enable="false" />
            <ChartMarker>
                <ChartDataLabel Visible="true" />
            </ChartMarker>
        </ChartSeries>
        <ChartSeries DataSource="@ChartDatas" XName="X" YName="Y2" Type="ChartSeriesType.StackingArea">
            <ChartSeriesAnimation Enable="false" />
            <ChartMarker>
                <ChartDataLabel Visible="true" />
            </ChartMarker>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    public class ChartData
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Y1 { get; set; }
        public double Y2 { get; set; }
    }

    public List<ChartData> ChartDatas = new List<ChartData>
    {
        new ChartData{ X=2000, Y= 0.61, Y1= 0.03, Y2= 0.48},
        new ChartData{ X=2001, Y= 0.81, Y1= 0.05, Y2= 0.53 },
        new ChartData{ X=2002, Y= 0.91, Y1= 0.06, Y2= 0.57 },
        new ChartData{ X=2003, Y= 1, Y1= 0.09, Y2= 0.61 },
        new ChartData{ X=2004, Y= 1.19, Y1= 0.14, Y2= 0.63 },
        new ChartData{ X=2005, Y= 1.47, Y1= 0.20, Y2= 0.64 },
        new ChartData{ X=2006, Y= 1.74, Y1= 0.29, Y2= 0.66 },
        new ChartData{ X=2007, Y= 1.98, Y1= 0.46, Y2= 0.76 },
        new ChartData{ X=2008, Y= 1.99, Y1= 0.64, Y2= 0.77 },
        new ChartData{ X=2009, Y= 1.70, Y1= 0.75, Y2= 0.55 }
    };
}
```
![Blazor Stacking Area Chart with Stack Labels](../images/chart-types-images/blazor-stacked-area-stack-labels.png)

### Stack labels Customization

Stack labels have various properties for customization to enhance the visual based on your requirements.

* `fill` - Specifies the background color of the stack labels. The default value is transparent.

* `format` - Specifies the format of the stack labels. It supports placeholder like {value}.

* `Rx` - Specifies the rounded corner radius along the X-axis (horizontal direction) for the stack label background. The default value is 5.

* `Ry` - Specifies the rounded corner radius along the Y-axis (vertical direction) for the stack label background. The default value is 5.

* `Angle` - Specifies the rotation angle for stack labels in degrees. Default is 0.

We can also customize the font using the `ChartStackLabelFont` of the stack labels with the properties:

* `TextAlignment` - Specifies the alignment of the text within the stack label.

* `FontFamily` - Specifies the font family for the stack label text.

* `Size` - Specifies the font size of the stack label text.

* `FontStyle` - Specifies the font style of the stack label text.

* `FontWeight` - Specifies the font weight of the stack label text.

* `Color` - Specifies the color of the stack label text.

We also customize the border of the stack labels using the `ChartStackLabelBorder` with the properties:

* `Width` - Specifies the width of the border around the stack label.

* `Color` - Specifies the color of the border around the stack label.

 To customize margin, we can use the `ChartStackLabelMargin` with the properties:

* `Bottom` - Specifies the bottom margin of the stack label.

* `Top` - Specifies the top margin of the stack label.

* `Right` - Specifies the right margin of the stack label.

* `Left` - Specifies the left margin of the stack label.

```cshtml
@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartStackLabelSettings Visible="true" Format="{value}" Fill="#ADD8E6" Rx="10" Ry="10" Angle="35">
        <ChartStackLabelFont TextAlignment="Alignment.Center" FontFamily="Roboto" Size="12px" FontStyle="bold" FontWeight="600" Color="blue" />
        <ChartStackLabelBorder Width="2" Color="#000000" />
        <ChartStackLabelMargin Bottom="10" Top="10" Right="10" Left="10" />
    </ChartStackLabelSettings>

    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />

    <ChartSeriesCollection>
        <ChartSeries DataSource="@ChartDatas" XName="X" YName="Y" Type="ChartSeriesType.StackingArea">
            <ChartSeriesAnimation Enable="false" />
            <ChartMarker>
                <ChartDataLabel Visible="true" />
            </ChartMarker>
        </ChartSeries>
        <ChartSeries DataSource="@ChartDatas" XName="X" YName="Y1" Type="ChartSeriesType.StackingArea">
            <ChartSeriesAnimation Enable="false" />
            <ChartMarker>
                <ChartDataLabel Visible="true" />
            </ChartMarker>
        </ChartSeries>
        <ChartSeries DataSource="@ChartDatas" XName="X" YName="Y2" Type="ChartSeriesType.StackingArea">
            <ChartSeriesAnimation Enable="false" />
            <ChartMarker>
                <ChartDataLabel Visible="true" />
            </ChartMarker>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    public class ChartData
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Y1 { get; set; }
        public double Y2 { get; set; }
    }

    public List<ChartData> ChartDatas = new List<ChartData>
    {
        new ChartData{ X=2000, Y= 0.61, Y1= 0.03, Y2= 0.48},
        new ChartData{ X=2001, Y= 0.81, Y1= 0.05, Y2= 0.53 },
        new ChartData{ X=2002, Y= 0.91, Y1= 0.06, Y2= 0.57 },
        new ChartData{ X=2003, Y= 1, Y1= 0.09, Y2= 0.61 },
        new ChartData{ X=2004, Y= 1.19, Y1= 0.14, Y2= 0.63 },
        new ChartData{ X=2005, Y= 1.47, Y1= 0.20, Y2= 0.64 },
        new ChartData{ X=2006, Y= 1.74, Y1= 0.29, Y2= 0.66 },
        new ChartData{ X=2007, Y= 1.98, Y1= 0.46, Y2= 0.76 },
        new ChartData{ X=2008, Y= 1.99, Y1= 0.64, Y2= 0.77 },
        new ChartData{ X=2009, Y= 1.70, Y1= 0.75, Y2= 0.55 }
    };
}
```
![Blazor Chart with Stack Label Customization](../images/chart-types-images/blazor-stacked-area-stack-labels-customization.png)

## Events

### Series render

The [`OnSeriesRender`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_OnSeriesRender) event allows you to customize series properties, such as [Data](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SeriesRenderEventArgs.html#Syncfusion_Blazor_Charts_SeriesRenderEventArgs_Data), [Fill](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SeriesRenderEventArgs.html#Syncfusion_Blazor_Charts_SeriesRenderEventArgs_Fill), and [Series](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SeriesRenderEventArgs.html#Syncfusion_Blazor_Charts_SeriesRenderEventArgs_Series), before they are rendered on the chart.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />
    <ChartEvents OnSeriesRender="SeriesRender"></ChartEvents>
    <ChartSeriesCollection>
        <ChartSeries DataSource="@ChartDatas" XName="X" Name="Series1" YName="Y" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingArea" />
        <ChartSeries DataSource="@ChartDatas" XName="X" Name="Series2" YName="Y1" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingArea" />
        <ChartSeries DataSource="@ChartDatas" XName="X" Name="Series3" YName="Y2" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingArea" />
    </ChartSeriesCollection>
    <ChartLegendSettings Visible="false"></ChartLegendSettings>
</SfChart>

@code {
    public class ChartData
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Y1 { get; set; }
        public double Y2 { get; set; }
    }

    public void SeriesRender(SeriesRenderEventArgs args)
    {
       if (args.Series.Name == "Series1")
       {
           args.Fill = "red";
       }
       else if (args.Series.Name == "Series2")
       {
           args.Fill = "green";
       }
       else if (args.Series.Name == "Series3")
       {
           args.Fill = "blue";
       }
    }

    public List<ChartData> ChartDatas = new List<ChartData>
    {
        new ChartData{ X=2000, Y= 0.61, Y1= 0.03, Y2= 0.48},
        new ChartData{ X=2001, Y= 0.81, Y1= 0.05, Y2= 0.53 },
        new ChartData{ X=2002, Y= 0.91, Y1= 0.06, Y2= 0.57 },
        new ChartData{ X=2003, Y= 1, Y1= 0.09, Y2= 0.61 },
        new ChartData{ X=2004, Y= 1.19, Y1= 0.14, Y2= 0.63 },
        new ChartData{ X=2005, Y= 1.47, Y1= 0.20, Y2= 0.64 },
        new ChartData{ X=2006, Y= 1.74, Y1= 0.29, Y2= 0.66 },
        new ChartData{ X=2007, Y= 1.98, Y1= 0.46, Y2= 0.76 },
        new ChartData{ X=2008, Y= 1.99, Y1= 0.64, Y2= 0.77 },
        new ChartData{ X=2009, Y= 1.70, Y1= 0.75, Y2= 0.55 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/LXVTjviYzAmlMaxt?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Point render

The [`OnPointRender`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_OnPointRender) event allows you to customize each data point before it is rendered on the chart.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart Title="Family Expense for Month">
    <ChartEvents OnPointRender="PointRender"></ChartEvents>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category"></ChartPrimaryXAxis>
     <ChartSeriesCollection>
        <ChartSeries XName="X" DataSource="@ExpenseReports"
                     YName="Y" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingArea">
            <ChartMarker Visible="true" Height="10" Width ="10">
            </ChartMarker>
        </ChartSeries>
        <ChartSeries XName="X" DataSource="@ExpenseReports"
                     YName="Y1" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingArea">
            <ChartMarker Visible="true" Height="10" Width ="10">
            </ChartMarker>
        </ChartSeries>
        <ChartSeries XName="X" DataSource="@ExpenseReports"
                     YName="Y2" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingArea">
            <ChartMarker Visible="true" Height="10" Width ="10">
            </ChartMarker>
        </ChartSeries>
        <ChartSeries XName="X" DataSource="@ExpenseReports"
                     YName="Y3" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingArea">
            <ChartMarker Visible="true" Height="10" Width ="10">
            </ChartMarker>
        </ChartSeries>
    </ChartSeriesCollection>

</SfChart>

@code {
    public class ChartData
    {
        public string X { get; set; }
        public double Y { get; set; }
        public double Y1 { get; set; }
        public double Y2 { get; set; }
        public double Y3 { get; set; }
    }

    public List<ChartData> ExpenseReports = new List<ChartData>
	{
        new ChartData { X = "Food" , Y = 90, Y1 = 40 , Y2= 70, Y3= 120},
        new ChartData { X = "Transport", Y = 80, Y1 = 90, Y2= 110, Y3= 70 },
        new ChartData { X = "Medical",Y = 50, Y1 = 80, Y2= 120, Y3= 50 },
        new ChartData { X = "Clothes",Y = 70, Y1 = 30, Y2= 60, Y3= 180 },
        new ChartData { X = "Personal Care", Y = 30, Y1 = 80, Y2= 80, Y3= 30 },
        new ChartData { X = "Books", Y = 10, Y1 = 40, Y2= 30, Y3= 270},
        new ChartData { X = "Fitness",Y = 100, Y1 = 30, Y2= 70, Y3= 40 },
        new ChartData { X = "Electricity", Y = 55, Y1 = 95, Y2= 55, Y3= 75},
        new ChartData { X = "Tax", Y = 20, Y1 = 50, Y2= 40, Y3= 65 },
        new ChartData { X = "Pet Care", Y = 40, Y1 = 20, Y2= 80, Y3= 95 },
        new ChartData { X = "Education", Y = 45, Y1 = 15, Y2= 45, Y3= 195 },
        new ChartData { X = "Entertainment", Y = 75, Y1 = 45, Y2= 65, Y3= 115 }
    };

    public void PointRender(PointRenderEventArgs args)
    {
        args.Fill = (args.Point.Index % 2 != 0) ? "#ff6347" : "#009cb8";
    }
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BXrfZuMAURdafsLu?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

N> Refer to our [Blazor Charts](https://www.syncfusion.com/blazor-components/blazor-charts) feature tour page for its groundbreaking feature representations and also explore our [Blazor Chart Example](https://blazor.syncfusion.com/demos/chart/line?theme=bootstrap5) to know various chart types and how to represent time-dependent data, showing trends at equal intervals.

## See also

* [Data Label](../data-labels)
* [Tooltip](../tool-tip)