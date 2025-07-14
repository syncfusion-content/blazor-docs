---
layout: post
title: Bar Charts in Blazor Charts Component | Syncfusion
description: Checkout and learn here all about the Bar Charts in Syncfusion Blazor Charts component and much more.
platform: Blazor
control: Chart
documentation: ug
---

# Bar Charts in Blazor Charts Component

## Bar

[Bar Chart](https://www.syncfusion.com/blazor-components/blazor-charts/chart-types/bar-chart) is the most commonly used chart type to compare different categories of data, such as  **Frequency**, **Count**, **Total**, or **Average** displayed in horizontal bars. It is ideal for showing variations in the value of an item over time. To render a [bar](https://www.syncfusion.com/blazor-components/blazor-charts/chart-types/bar-chart) series in your chart, define the series [`Type`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Type) as [`Bar`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeriesType.html#Syncfusion_Blazor_Charts_ChartSeriesType_Bar) in your chart configuration. This indicates that the data should be represented as a bar chart, which makes it easy to compare values across categories.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category"></ChartPrimaryXAxis>
    <ChartSeriesCollection>
        <ChartSeries DataSource="@SalesDetails" XName="X" YName="Y" Type="ChartSeriesType.Bar">
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code{
    public class ChartData
    {
        public string X { get; set;}
        public double Y {get; set;}
    }
	
    public List<ChartData> SalesDetails = new List<ChartData>
	{
        new ChartData { X= "Jan", Y= 35 },
        new ChartData { X= "Feb", Y= 28 },
        new ChartData { X= "Mar", Y= 34 },
        new ChartData { X= "Apr", Y= 32 },
        new ChartData { X= "May", Y= 40 },
        new ChartData { X= "Jun", Y= 32 },
        new ChartData { X= "Jul", Y= 35 },
        new ChartData { X= "Aug", Y= 55 },
        new ChartData { X= "Sep", Y= 38 },
        new ChartData { X= "Oct", Y= 30 },
        new ChartData { X= "Nov", Y= 25 },
        new ChartData { X= "Dec", Y= 32 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/hXLTNYsqpkzRkDLi?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor Bar Chart](../images/chart-types-images/blazor-bar-chart.png)

N> Refer to our [Blazor Bar Charts](https://www.syncfusion.com/blazor-components/blazor-charts/chart-types/bar-chart) feature tour page to know about its other groundbreaking feature representations. Explore our [Blazor Bar Chart Example](https://blazor.syncfusion.com/demos/chart/bar?theme=bootstrap5) to compare values across categories by using horizontal bars.

## Binding data with series

You can bind data to the chart using the [`DataSource`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_DataSource) property within the series configuration. The [`DataSource`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_DataSource) value can be set using either [`SfDataManager`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) property values or a list of business objects. More information on data binding can be found [here](../working-with-data). To display the data correctly, map the fields from the data to the chart series' [`XName`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_XName) and [`YName`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_YName) properties.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category"></ChartPrimaryXAxis>
    <ChartSeriesCollection>
        <ChartSeries DataSource="@SalesDetails" XName="X" YName="Y" Type="ChartSeriesType.Bar">
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code{
    public class ChartData
    {
        public string X { get; set;}
        public double Y {get; set;}
    }
	
    public List<ChartData> SalesDetails = new List<ChartData>
	{
        new ChartData { X= "Jan", Y= 35 },
        new ChartData { X= "Feb", Y= 28 },
        new ChartData { X= "Mar", Y= 34 },
        new ChartData { X= "Apr", Y= 32 },
        new ChartData { X= "May", Y= 40 },
        new ChartData { X= "Jun", Y= 32 },
        new ChartData { X= "Jul", Y= 35 },
        new ChartData { X= "Aug", Y= 55 },
        new ChartData { X= "Sep", Y= 38 },
        new ChartData { X= "Oct", Y= 30 },
        new ChartData { X= "Nov", Y= 25 },
        new ChartData { X= "Dec", Y= 32 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/hXLTNYsqpkzRkDLi?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Series customization

The following properties can be used to customize the [Bar](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeriesType.html#Syncfusion_Blazor_Charts_ChartSeriesType_Bar) series.

**Fill**

The [Fill](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Fill) property determines the color applied to the series.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category"></ChartPrimaryXAxis>
    <ChartSeriesCollection>
        <ChartSeries DataSource="@SalesDetails" Fill="blue" XName="X" YName="Y" Type="ChartSeriesType.Bar">
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code{
    public class ChartData
    {
        public string X { get; set;}
        public double Y {get; set;}
    }
	
    public List<ChartData> SalesDetails = new List<ChartData>
	{
        new ChartData { X= "Jan", Y= 35 },
        new ChartData { X= "Feb", Y= 28 },
        new ChartData { X= "Mar", Y= 34 },
        new ChartData { X= "Apr", Y= 32 },
        new ChartData { X= "May", Y= 40 },
        new ChartData { X= "Jun", Y= 32 },
        new ChartData { X= "Jul", Y= 35 },
        new ChartData { X= "Aug", Y= 55 },
        new ChartData { X= "Sep", Y= 38 },
        new ChartData { X= "Oct", Y= 30 },
        new ChartData { X= "Nov", Y= 25 },
        new ChartData { X= "Dec", Y= 32 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/hjrJNOMAzkGIHLBV?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

The [Fill](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Fill) property can be used to apply a gradient color to the bar series. By configuring this property with gradient values, you can create a visually appealing effect in which the color transitions smoothly from one shade to another.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category"></ChartPrimaryXAxis>
    <ChartSeriesCollection>
        <ChartSeries DataSource="@SalesDetails" Fill="url(#grad1)" XName="X" YName="Y" Type="ChartSeriesType.Bar">
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

@code{
    public class ChartData
    {
        public string X { get; set;}
        public double Y {get; set;}
    }
	
    public List<ChartData> SalesDetails = new List<ChartData>
	{
        new ChartData { X= "Jan", Y= 35 },
        new ChartData { X= "Feb", Y= 28 },
        new ChartData { X= "Mar", Y= 34 },
        new ChartData { X= "Apr", Y= 32 },
        new ChartData { X= "May", Y= 40 },
        new ChartData { X= "Jun", Y= 32 },
        new ChartData { X= "Jul", Y= 35 },
        new ChartData { X= "Aug", Y= 55 },
        new ChartData { X= "Sep", Y= 38 },
        new ChartData { X= "Oct", Y= 30 },
        new ChartData { X= "Nov", Y= 25 },
        new ChartData { X= "Dec", Y= 32 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/VZhJZYMUTOFVhLEz?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

**Opacity**

The [Opacity](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Opacity) property specifies the transparency level of the [Fill](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Fill). Adjusting this property allows you to control how opaque or transparent the fill color of the series appears.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category"></ChartPrimaryXAxis>
    <ChartSeriesCollection>
        <ChartSeries DataSource="@SalesDetails" Opacity="0.5" XName="X" YName="Y" Type="ChartSeriesType.Bar">
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code{
    public class ChartData
    {
        public string X { get; set;}
        public double Y {get; set;}
    }
	
    public List<ChartData> SalesDetails = new List<ChartData>
	{
        new ChartData { X= "Jan", Y= 35 },
        new ChartData { X= "Feb", Y= 28 },
        new ChartData { X= "Mar", Y= 34 },
        new ChartData { X= "Apr", Y= 32 },
        new ChartData { X= "May", Y= 40 },
        new ChartData { X= "Jun", Y= 32 },
        new ChartData { X= "Jul", Y= 35 },
        new ChartData { X= "Aug", Y= 55 },
        new ChartData { X= "Sep", Y= 38 },
        new ChartData { X= "Oct", Y= 30 },
        new ChartData { X= "Nov", Y= 25 },
        new ChartData { X= "Dec", Y= 32 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/rjBJZOCKpYPQQtuq?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

**DashArray**

The [DashArray](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_DashArray) property determines the pattern of dashes and gaps in the series.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category"></ChartPrimaryXAxis>
    <ChartSeriesCollection>
        <ChartSeries DataSource="@SalesDetails" DashArray="5,5" XName="X" YName="Y" Type="Syncfusion.Blazor.Charts.ChartSeriesType.Bar">
            <ChartSeriesBorder Width="2" Color="red"></ChartSeriesBorder>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    public class ChartData
    {
        public string X { get; set; }
        public double Y { get; set; }
    }

    public List<ChartData> SalesDetails = new List<ChartData>
    {
        new ChartData { X= "Jan", Y= 35 },
        new ChartData { X= "Feb", Y= 28 },
        new ChartData { X= "Mar", Y= 34 },
        new ChartData { X= "Apr", Y= 32 },
        new ChartData { X= "May", Y= 40 },
        new ChartData { X= "Jun", Y= 32 },
        new ChartData { X= "Jul", Y= 35 },
        new ChartData { X= "Aug", Y= 55 },
        new ChartData { X= "Sep", Y= 38 },
        new ChartData { X= "Oct", Y= 30 },
        new ChartData { X= "Nov", Y= 25 },
        new ChartData { X= "Dec", Y= 32 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/rtBTtuWUTuOhOKlj?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

**Series Border**

The [ChartSeriesBorder](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeriesBorder.html) property to customize the [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCommonBorder.html#Syncfusion_Blazor_Charts_ChartCommonBorder_Width) and [Color](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCommonBorder.html#Syncfusion_Blazor_Charts_ChartCommonBorder_Color) of the series border.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category"></ChartPrimaryXAxis>
    <ChartSeriesCollection>
        <ChartSeries DataSource="@SalesDetails" DashArray="5,5" XName="X" YName="Y" Type="Syncfusion.Blazor.Charts.ChartSeriesType.Bar">
            <ChartSeriesBorder Width="2" Color="red"></ChartSeriesBorder>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    public class ChartData
    {
        public string X { get; set; }
        public double Y { get; set; }
    }

    public List<ChartData> SalesDetails = new List<ChartData>
    {
        new ChartData { X= "Jan", Y= 35 },
        new ChartData { X= "Feb", Y= 28 },
        new ChartData { X= "Mar", Y= 34 },
        new ChartData { X= "Apr", Y= 32 },
        new ChartData { X= "May", Y= 40 },
        new ChartData { X= "Jun", Y= 32 },
        new ChartData { X= "Jul", Y= 35 },
        new ChartData { X= "Aug", Y= 55 },
        new ChartData { X= "Sep", Y= 38 },
        new ChartData { X= "Oct", Y= 30 },
        new ChartData { X= "Nov", Y= 25 },
        new ChartData { X= "Dec", Y= 32 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/rtBTtuWUTuOhOKlj?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Corner radius

The [ChartCornerRadius](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCornerRadius.html) property is used to customize the corner radius for bar series. This allows you to create bars with rounded corners, giving your chart a more polished appearance. You can customize each corner of the bars using the [BottomLeft](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCornerRadius.html#Syncfusion_Blazor_Charts_ChartCornerRadius_BottomLeft), [BottomRight](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCornerRadius.html#Syncfusion_Blazor_Charts_ChartCornerRadius_BottomRight), [TopLeft](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCornerRadius.html#Syncfusion_Blazor_Charts_ChartCornerRadius_TopLeft), [TopRight](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCornerRadius.html#Syncfusion_Blazor_Charts_ChartCornerRadius_TopRight) properties.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category"></ChartPrimaryXAxis>
    <ChartSeriesCollection>
        <ChartSeries DataSource="@SalesDetails" XName="X" YName="Y" Type="Syncfusion.Blazor.Charts.ChartSeriesType.Bar">
            <ChartCornerRadius TopRight="5" BottomRight="5"></ChartCornerRadius>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    public class ChartData
    {
        public string X { get; set; }
        public double Y { get; set; }
    }

    public List<ChartData> SalesDetails = new List<ChartData>
    {
        new ChartData { X= "Jan", Y= 35 },
        new ChartData { X= "Feb", Y= 28 },
        new ChartData { X= "Mar", Y= 34 },
        new ChartData { X= "Apr", Y= 32 },
        new ChartData { X= "May", Y= -38 },
        new ChartData { X= "Jun", Y= 32 },
        new ChartData { X= "Jul", Y= 35 },
        new ChartData { X= "Aug", Y= -30 },
        new ChartData { X= "Sep", Y= 38 },
        new ChartData { X= "Oct", Y= 30 },
        new ChartData { X= "Nov", Y= -25 },
        new ChartData { X= "Dec", Y= 32 }
    };
}

```

![Blazor Bar Chart with corner radius](../images/chart-types-images/blazor-bar-chart-corner-radius.png)
{% previewsample "https://blazorplayground.syncfusion.com/embed/rDBINTjfrHKsRaBF?appbar=true&editor=true&result=true&errorlist=true&theme=bootstrap5" %}

We can customize the corner radius for individual points in the chart series using the [OnPointRender](https://blazor.syncfusion.com/documentation/chart/events#onpointrender) event by utilizing the [CornerRadius](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.PointRenderEventArgs.html#Syncfusion_Blazor_Charts_PointRenderEventArgs_CornerRadius) property in its event argument.

```cshtml
 @using Syncfusion.Blazor.Charts

<SfChart>
    <ChartEvents OnPointRender="PointRenderEvent"></ChartEvents>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category"></ChartPrimaryXAxis>
    <ChartSeriesCollection>
        <ChartSeries DataSource="@SalesDetails" XName="X" YName="Y" Type="Syncfusion.Blazor.Charts.ChartSeriesType.Bar">
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    public class ChartData
    {
        public string X { get; set; }
        public double Y { get; set; }
    }

    public List<ChartData> SalesDetails = new List<ChartData>
    {
        new ChartData { X= "Jan", Y= 35 },
        new ChartData { X= "Feb", Y= 28 },
        new ChartData { X= "Mar", Y= 34 },
        new ChartData { X= "Apr", Y= 32 },
        new ChartData { X= "May", Y= -38 },
        new ChartData { X= "Jun", Y= 32 },
        new ChartData { X= "Jul", Y= 35 },
        new ChartData { X= "Aug", Y= -30 },
        new ChartData { X= "Sep", Y= 38 },
        new ChartData { X= "Oct", Y= 30 },
        new ChartData { X= "Nov", Y= -25 },
        new ChartData { X= "Dec", Y= 32 }
    };

    public void PointRenderEvent(PointRenderEventArgs args)
    {
        if ((args.Point.X as string) == "Jan" || (args.Point.X as string) == "Mar" || (args.Point.X as string == "May") || (args.Point.X as string == "Aug") || (args.Point.X as string) == "Nov")
        {
            args.CornerRadius.TopRight = 5;
            args.CornerRadius.BottomRight = 5;
        }
    }
}

```
![Blazor bar chart with corner radius using OnPointRender event](../images/chart-types-images/blazor-bar-chart-corner-radius-using_onPointRenderEvent.png)
{% previewsample "https://blazorplayground.syncfusion.com/embed/BZBejJXJVPrWIMKc?appbar=true&editor=true&result=true&errorlist=true&theme=bootstrap5" %}

## Bar space and width

The [ColumnSpacing](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_ColumnSpacing) and [ColumnWidth](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_ColumnWidth) properties are used to customize the space between bars. The default value of [ColumnSpacing](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_ColumnSpacing) is 0, and the default value of [ColumnWidth](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_ColumnWidth) is 0.7. Both properties range from 0 to 1.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />

    <ChartSeriesCollection>
        <ChartSeries DataSource="@SalesDetails" XName="X" YName="Y" Type="Syncfusion.Blazor.Charts.ChartSeriesType.Bar" ColumnSpacing="0.2" ColumnWidth="0.2">
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    public class ChartData
    {
        public string X { get; set; }
        public double Y { get; set; }
    }

    public List<ChartData> SalesDetails = new List<ChartData>
    {
        new ChartData { X= "Jan", Y= 35 },
        new ChartData { X= "Feb", Y= 28 },
        new ChartData { X= "Mar", Y= 34 },
        new ChartData { X= "Apr", Y= 32 },
        new ChartData { X= "May", Y= 40 },
        new ChartData { X= "Jun", Y= 32 },
        new ChartData { X= "Jul", Y= 35 },
        new ChartData { X= "Aug", Y= 55 },
        new ChartData { X= "Sep", Y= 38 },
        new ChartData { X= "Oct", Y= 30 },
        new ChartData { X= "Nov", Y= 25 },
        new ChartData { X= "Dec", Y= 32 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BNBfjaWUejsQPZoB?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Column width in pixels

The [ColumnWidthInPixel](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_ColumnWidthInPixel) property in [ChartSeries](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html) is used to set the width of the bar and rectangle-based series types in pixels. This property ensures that each bar maintains the specified width, providing a uniform appearance throughout the chart.

```cshtml
@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />

    <ChartSeriesCollection>
        <ChartSeries DataSource="@SalesDetails" XName="X" YName="Y" Type="Syncfusion.Blazor.Charts.ChartSeriesType.Bar" ColumnSpacing="0.2" ColumnWidthInPixel="30">
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    public class ChartData
    {
        public string X { get; set; }
        public double Y { get; set; }
    }

    public List<ChartData> SalesDetails = new List<ChartData>
    {
        new ChartData { X= "Jan", Y= 35 },
        new ChartData { X= "Feb", Y= 28 },
        new ChartData { X= "Mar", Y= 34 },
        new ChartData { X= "Apr", Y= 32 },
        new ChartData { X= "May", Y= 40 },
        new ChartData { X= "Jun", Y= 32 },
        new ChartData { X= "Jul", Y= 35 },
        new ChartData { X= "Aug", Y= 55 },
        new ChartData { X= "Sep", Y= 38 },
        new ChartData { X= "Oct", Y= 30 },
        new ChartData { X= "Nov", Y= 25 },
        new ChartData { X= "Dec", Y= 32 }
    };
}
```
![Blazor Bar Chart with column width set in pixel](../images/chart-types-images/blazor-bar-chart-width-in-pixels.png)
{% previewsample "https://blazorplayground.syncfusion.com/embed/rDreDxhnJqkknbxM?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Grouped bar

You can use the [GroupName](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_GroupName) property to group the data points in the bar type charts. Data points with same group name are grouped together.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
        <ChartPrimaryXAxis ValueType="@Syncfusion.Blazor.Charts.ValueType.Category">
        </ChartPrimaryXAxis>
        <ChartSeriesCollection>
            <ChartSeries DataSource="@ChartPoints" XName="Year" YName="USA_Total" GroupName="USA" ColumnWidth="0.7" ColumnSpacing="0.1" Type="ChartSeriesType.Bar">
            </ChartSeries>
            <ChartSeries DataSource="@ChartPoints" XName="Year" YName="USA_Gold" GroupName="USA" ColumnWidth="0.5" ColumnSpacing="0.1" Type="ChartSeriesType.Bar">
             </ChartSeries>
            <ChartSeries DataSource="@ChartPoints" XName="Year" YName="UK_Total" GroupName="UK" ColumnWidth="0.7" ColumnSpacing="0.1" Type="ChartSeriesType.Bar">
            </ChartSeries>
            <ChartSeries DataSource="@ChartPoints" XName="Year" YName="UK_Gold" GroupName="UK" ColumnWidth="0.5" ColumnSpacing="0.1" Type="ChartSeriesType.Bar">
            </ChartSeries>
        </ChartSeriesCollection>
    </SfChart>

@code{
    public class ColumnData
    {
        public string Year { get; set; }
        public double USA_Total { get; set; }
        public double USA_Gold { get; set; }
        public double UK_Total { get; set; }
        public double UK_Gold { get; set; }
        public double China_Total { get; set; }
        public double China_Gold { get; set; }
    }
    public List<ColumnData> ChartPoints { get; set; } = new List<ColumnData>
    {
        new ColumnData { Year = "2012", USA_Total = 104, USA_Gold = 46, UK_Total = 65, UK_Gold = 29, China_Total = 91, China_Gold = 38},
        new ColumnData { Year = "2016", USA_Total = 121, USA_Gold = 46, UK_Total = 67, UK_Gold = 27, China_Total = 70, China_Gold = 26},
        new ColumnData { Year = "2020", USA_Total = 113, USA_Gold = 39, UK_Total = 65, UK_Gold = 22, China_Total = 88, China_Gold = 38},
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/rDrpZFrZMwknOUgV?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Empty points

Data points with `null`, `double.NaN` or `undefined` values are considered empty. Empty data points are ignored and not plotted on the chart.

**Mode**

Use the [`Mode`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEmptyPointSettings.html#Syncfusion_Blazor_Charts_ChartEmptyPointSettings_Mode) property to define how empty or missing data points are handled in the series. The default mode for empty points is [`Gap`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.EmptyPointMode.html#Syncfusion_Blazor_Charts_EmptyPointMode_Gap).

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category"></ChartPrimaryXAxis>
    <ChartSeriesCollection>
        <ChartSeries DataSource="@SalesDetails" XName="X" YName="Y" Type="ChartSeriesType.Bar">
            <ChartEmptyPointSettings Mode="EmptyPointMode.Zero"></ChartEmptyPointSettings>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code{
    public class ChartData
    {
        public string X { get; set;}
        public double Y {get; set;}
    }
	
    public List<ChartData> SalesDetails = new List<ChartData>
	{
        new ChartData { X= "Jan", Y= 35 },
        new ChartData { X= "Feb", Y= 28 },
        new ChartData { X= "Mar", Y= 34 },
        new ChartData { X= "Apr", Y= double.NaN },
        new ChartData { X= "May", Y= 40 },
        new ChartData { X= "Jun", Y= 32 },
        new ChartData { X= "Jul", Y= 35 },
        new ChartData { X= "Aug", Y= double.NaN },
        new ChartData { X= "Sep", Y= 38 },
        new ChartData { X= "Oct", Y= 30 },
        new ChartData { X= "Nov", Y= 25 },
        new ChartData { X= "Dec", Y= 32 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/hNVpjaigoNLmAhdP?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

**Fill**

Use the [`Fill`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEmptyPointSettings.html#Syncfusion_Blazor_Charts_ChartEmptyPointSettings_Fill) property to customize the fill color of empty points in the series.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category"></ChartPrimaryXAxis>
    <ChartSeriesCollection>
        <ChartSeries DataSource="@SalesDetails" XName="X" YName="Y" Type="Syncfusion.Blazor.Charts.ChartSeriesType.Bar">
            <ChartEmptyPointSettings Fill="red" Mode="EmptyPointMode.Average" />
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code{
    public class ChartData
    {
        public string X { get; set;}
        public double Y {get; set;}
    }
	
    public List<ChartData> SalesDetails = new List<ChartData>
	{
        new ChartData { X= "Jan", Y= 35 },
        new ChartData { X= "Feb", Y= 28 },
        new ChartData { X= "Mar", Y= 34 },
        new ChartData { X= "Apr", Y= double.NaN },
        new ChartData { X= "May", Y= 40 },
        new ChartData { X= "Jun", Y= 32 },
        new ChartData { X= "Jul", Y= 35 },
        new ChartData { X= "Aug", Y= double.NaN },
        new ChartData { X= "Sep", Y= 38 },
        new ChartData { X= "Oct", Y= 30 },
        new ChartData { X= "Nov", Y= 25 },
        new ChartData { X= "Dec", Y= 32 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/hXBTNYCqIXKgENws?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

**Border**

Use the [`Border`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEmptyPointSettings.html#Syncfusion_Blazor_Charts_ChartEmptyPointSettings_Border) property to customize the [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEmptyPointBorder.html#Syncfusion_Blazor_Charts_ChartEmptyPointBorder_Width) and [Color](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEmptyPointBorder.html#Syncfusion_Blazor_Charts_ChartEmptyPointBorder_Color) of the border for empty points.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category"></ChartPrimaryXAxis>
    <ChartSeriesCollection>
        <ChartSeries DataSource="@SalesDetails" XName="X" YName="Y" Type="Syncfusion.Blazor.Charts.ChartSeriesType.Bar">
            <ChartEmptyPointSettings Fill="red" Mode="EmptyPointMode.Average">
                <ChartEmptyPointBorder Color="green" Width="2"></ChartEmptyPointBorder>
            </ChartEmptyPointSettings>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    public class ChartData
    {
        public string X { get; set; }
        public double Y { get; set; }
    }

    public List<ChartData> SalesDetails = new List<ChartData>
    {
        new ChartData { X= "Jan", Y= 35 },
        new ChartData { X= "Feb", Y= 28 },
        new ChartData { X= "Mar", Y= 34 },
        new ChartData { X= "Apr", Y= double.NaN },
        new ChartData { X= "May", Y= 40 },
        new ChartData { X= "Jun", Y= 32 },
        new ChartData { X= "Jul", Y= 35 },
        new ChartData { X= "Aug", Y= double.NaN },
        new ChartData { X= "Sep", Y= 38 },
        new ChartData { X= "Oct", Y= 30 },
        new ChartData { X= "Nov", Y= 25 },
        new ChartData { X= "Dec", Y= 32 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/VNhpDYWAyDKOnNtK?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Events

### Series render

The [`OnSeriesRender`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_OnSeriesRender) event allows you to customize series properties, such as [Data](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SeriesRenderEventArgs.html#Syncfusion_Blazor_Charts_SeriesRenderEventArgs_Data), [Fill](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SeriesRenderEventArgs.html#Syncfusion_Blazor_Charts_SeriesRenderEventArgs_Fill), and [Series](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SeriesRenderEventArgs.html#Syncfusion_Blazor_Charts_SeriesRenderEventArgs_Series), before they are rendered on the chart.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category"></ChartPrimaryXAxis>
    <ChartEvents OnSeriesRender="SeriesRender"></ChartEvents>
    <ChartSeriesCollection>
        <ChartSeries DataSource="@SalesDetails" XName="X" YName="Y" Type="ChartSeriesType.Bar">
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code{
    public class ChartData
    {
        public string X { get; set;}
        public double Y {get; set;}
    }

    public void SeriesRender(SeriesRenderEventArgs args)
    {
        args.Fill = "#FF4081";
    }
	
    public List<ChartData> SalesDetails = new List<ChartData>
	{
        new ChartData { X= "Jan", Y= 35 },
        new ChartData { X= "Feb", Y= 28 },
        new ChartData { X= "Mar", Y= 34 },
        new ChartData { X= "Apr", Y= 32 },
        new ChartData { X= "May", Y= 40 },
        new ChartData { X= "Jun", Y= 32 },
        new ChartData { X= "Jul", Y= 35 },
        new ChartData { X= "Aug", Y= 55 },
        new ChartData { X= "Sep", Y= 38 },
        new ChartData { X= "Oct", Y= 30 },
        new ChartData { X= "Nov", Y= 25 },
        new ChartData { X= "Dec", Y= 32 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/VZVTjYMKyDTFzNmG?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Point render

The [`OnPointRender`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_OnPointRender) event allows you to customize each data point before it is rendered on the chart.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category"></ChartPrimaryXAxis>
   <ChartEvents OnPointRender="PointRender"></ChartEvents>
    <ChartSeriesCollection>
        <ChartSeries DataSource="@SalesDetails" XName="X" YName="Y" Type="Syncfusion.Blazor.Charts.ChartSeriesType.Bar">
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code{
    public class ChartData
    {
        public string X { get; set;}
        public double Y {get; set;}
    }

    public void PointRender(PointRenderEventArgs args)
    {
        args.Fill = (args.Point.Index % 2 != 0) ? "#ff6347" : "#009cb8";
    }
	
    public List<ChartData> SalesDetails = new List<ChartData>
	{
        new ChartData { X= "Jan", Y= 35 },
        new ChartData { X= "Feb", Y= 28 },
        new ChartData { X= "Mar", Y= 34 },
        new ChartData { X= "Apr", Y= 32 },
        new ChartData { X= "May", Y= 40 },
        new ChartData { X= "Jun", Y= 32 },
        new ChartData { X= "Jul", Y= 35 },
        new ChartData { X= "Aug", Y= 55 },
        new ChartData { X= "Sep", Y= 38 },
        new ChartData { X= "Oct", Y= 30 },
        new ChartData { X= "Nov", Y= 25 },
        new ChartData { X= "Dec", Y= 32 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/rZVJNaCUIXSpUkTS?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}


N> Refer to our [Blazor Charts](https://www.syncfusion.com/blazor-components/blazor-charts) feature tour page for its groundbreaking feature representations and also explore our [Blazor Chart Example](https://blazor.syncfusion.com/demos/chart/line?theme=bootstrap5) to know various chart types and how to represent time-dependent data, showing trends at equal intervals.

## See also

* [Creating stacked waterfall chart using Blazor bar chart](https://support.syncfusion.com/kb/article/11589/creating-stacked-waterfall-chart-using-blazor-bar-chart)
* [Data Label](../data-labels)
* [Tooltip](../tool-tip)
