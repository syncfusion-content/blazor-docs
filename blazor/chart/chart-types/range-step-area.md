---
layout: post
title: Range Step Area in Blazor Charts Component | Syncfusion
description: Check out and learn how to configure and customize Range Step Area Chart in Syncfusion Blazor Charts component.
platform: Blazor
control: Chart
documentation: ug
---

# Range Step Area in Blazor Charts Component

## Range Step Area

[Range Step Area Chart](https://www.syncfusion.com/blazor-components/blazor-charts/chart-types/range-step-area-chart) displays continuous data as steps between paired high and low values across categories or time. It is useful for visualizing ranges such as temperature bands, uncertainty intervals, or minimum–maximum variations.
 
1. **Set the series type**: Define the series [`Type`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Type) as [`RangeStepArea`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeriesType.html#Syncfusion_Blazor_Charts_ChartSeriesType_RangeStepArea). The chart connects data with horizontal and vertical segments, creating a step-like appearance for the band between high and low values.
 
2. **Provide high and low values**: The [`RangeStepArea`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeriesType.html#Syncfusion_Blazor_Charts_ChartSeriesType_RangeStepArea) series requires two y-values for each point. Map both the [`High`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_High) and [`Low`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Low) fields.

```cshtml
 
@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category">
        <ChartAxisMajorGridLines Width="0" />
    </ChartPrimaryXAxis>
    <ChartPrimaryYAxis>
        <ChartAxisLineStyle Width="0"></ChartAxisLineStyle>
        <ChartAxisMajorTickLines Width="0" />
    </ChartPrimaryYAxis>
    <ChartSeriesCollection>
        <ChartSeries DataSource="@ChartPoints" XName="X" High="High" Low="Low" Type="ChartSeriesType.RangeStepArea">
            <ChartMarker Visible="false"></ChartMarker>
        </ChartSeries>
    </ChartSeriesCollection>
    <ChartLegendSettings Visible="false" />
</SfChart>

@code {
    public List<ChartData> ChartPoints = new List<ChartData>
    {
        new ChartData { X= "Sun", Low= 4.7, High= 9.8 },
         new ChartData { X= "Mon", Low= 4.7, High= 11.4 },
         new ChartData { X= "Tue", Low= 6.4, High= 14.4 },
         new ChartData { X= "Wed", Low= 9.6, High= 17.2 },
         new ChartData { X= "Thu", Low= 7.5, High= 15.1 },
         new ChartData { X= "Fri", Low= 3.0, High= 10.5 },
         new ChartData { X= "Sat", Low= 1.2, High= 7.9 }
    };

    public class ChartData
    {
        public string X { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
    }
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/hthoNErzsfYwdVev?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor Range Step Area Chart](../images/chart-types-images/blazor-range-step-area.png)

## Binding data with series

Bind data using the series [`DataSource`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_DataSource) property. The source can be an [`SfDataManager`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) or a list of business objects. For correct rendering, map [`XName`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_XName), [`High`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_High), and [`Low`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Low). See [Working with data](../working-with-data) for more options.

```cshtml
 
@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category">
        <ChartAxisMajorGridLines Width="0" />
    </ChartPrimaryXAxis>
    <ChartPrimaryYAxis>
        <ChartAxisLineStyle Width="0"></ChartAxisLineStyle>
        <ChartAxisMajorTickLines Width="0" />
    </ChartPrimaryYAxis>
    <ChartSeriesCollection>
        <ChartSeries DataSource="@ChartPoints" XName="X" High="High" Low="Low" Type="ChartSeriesType.RangeStepArea">
            <ChartMarker Visible="false"></ChartMarker>
        </ChartSeries>
    </ChartSeriesCollection>
    <ChartLegendSettings Visible="false" />
</SfChart>

@code {
    public List<ChartData> ChartPoints = new List<ChartData>
    {
        new ChartData { X= "Sun", Low= 4.7, High= 9.8 },
         new ChartData { X= "Mon", Low= 4.7, High= 11.4 },
         new ChartData { X= "Tue", Low= 6.4, High= 14.4 },
         new ChartData { X= "Wed", Low= 9.6, High= 17.2 },
         new ChartData { X= "Thu", Low= 7.5, High= 15.1 },
         new ChartData { X= "Fri", Low= 3.0, High= 10.5 },
         new ChartData { X= "Sat", Low= 1.2, High= 7.9 }
    };

    public class ChartData
    {
        public string X { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
    }
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BDrIZOrTsIWtzfZZ?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> Refer to our [Blazor Range Step Area Chart](https://www.syncfusion.com/blazor-components/blazor-charts/chart-types/range-step-area-chart) feature tour page to know about its other groundbreaking feature representations. Explore our [Blazor Range Step Area Chart Example](https://blazor.syncfusion.com/demos/chart/range-step-area?theme=bootstrap5) to know how to show variations in the data values for a given time.

## Series customization

The following properties can be used to customize the [Range Step Area](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeriesType.html#Syncfusion_Blazor_Charts_ChartSeriesType_RangeStepArea) series.

**Fill**

The [Fill](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Fill) property sets the series color.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category">
        <ChartAxisMajorGridLines Width="0" />
    </ChartPrimaryXAxis>
    <ChartPrimaryYAxis>
        <ChartAxisLineStyle Width="0"></ChartAxisLineStyle>
        <ChartAxisMajorTickLines Width="0" />
    </ChartPrimaryYAxis>
    <ChartSeriesCollection>
        <ChartSeries DataSource="@ChartPoints" XName="X" High="High" Low="Low" Fill="blue" Type="ChartSeriesType.RangeStepArea">
            <ChartMarker Visible="false"></ChartMarker>
        </ChartSeries>
    </ChartSeriesCollection>
    <ChartLegendSettings Visible="false" />
</SfChart>

@code {
    public List<ChartData> ChartPoints = new List<ChartData>
    {
        new ChartData { X= "Sun", Low= 4.7, High= 9.8 },
         new ChartData { X= "Mon", Low= 4.7, High= 11.4 },
         new ChartData { X= "Tue", Low= 6.4, High= 14.4 },
         new ChartData { X= "Wed", Low= 9.6, High= 17.2 },
         new ChartData { X= "Thu", Low= 7.5, High= 15.1 },
         new ChartData { X= "Fri", Low= 3.0, High= 10.5 },
         new ChartData { X= "Sat", Low= 1.2, High= 7.9 }
    };

    public class ChartData
    {
        public string X { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
    }
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/VNVyDarJCHlsGMnq?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

The [Fill](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Fill) property can also reference a gradient for a smooth color transition.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category">
        <ChartAxisMajorGridLines Width="0" />
    </ChartPrimaryXAxis>
    <ChartPrimaryYAxis>
        <ChartAxisLineStyle Width="0"></ChartAxisLineStyle>
        <ChartAxisMajorTickLines Width="0" />
    </ChartPrimaryYAxis>
    <ChartSeriesCollection>
        <ChartSeries DataSource="@ChartPoints" XName="X" High="High" Low="Low" Fill="url(#grad1)" Type="ChartSeriesType.RangeStepArea">
            <ChartMarker Visible="false"></ChartMarker>
        </ChartSeries>
    </ChartSeriesCollection>
    <ChartLegendSettings Visible="false" />
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
    public List<ChartData> ChartPoints = new List<ChartData>
    {
        new ChartData { X= "Sun", Low= 4.7, High= 9.8 },
         new ChartData { X= "Mon", Low= 4.7, High= 11.4 },
         new ChartData { X= "Tue", Low= 6.4, High= 14.4 },
         new ChartData { X= "Wed", Low= 9.6, High= 17.2 },
         new ChartData { X= "Thu", Low= 7.5, High= 15.1 },
         new ChartData { X= "Fri", Low= 3.0, High= 10.5 },
         new ChartData { X= "Sat", Low= 1.2, High= 7.9 }
    };

    public class ChartData
    {
        public string X { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
    }
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/htBoZarTMxYSJZki?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

**Opacity**

The [Opacity](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Opacity) property sets the transparency of the series fill.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category">
        <ChartAxisMajorGridLines Width="0" />
    </ChartPrimaryXAxis>
    <ChartPrimaryYAxis>
        <ChartAxisLineStyle Width="0"></ChartAxisLineStyle>
        <ChartAxisMajorTickLines Width="0" />
    </ChartPrimaryYAxis>
    <ChartSeriesCollection>
        <ChartSeries DataSource="@ChartPoints" XName="X" High="High" Low="Low" Fill="blue" Opacity="0.5" Type="ChartSeriesType.RangeStepArea">
            <ChartMarker Visible="false"></ChartMarker>
        </ChartSeries>
    </ChartSeriesCollection>
    <ChartLegendSettings Visible="false" />
</SfChart>

@code {
    public List<ChartData> ChartPoints = new List<ChartData>
    {
        new ChartData { X= "Sun", Low= 4.7, High= 9.8 },
         new ChartData { X= "Mon", Low= 4.7, High= 11.4 },
         new ChartData { X= "Tue", Low= 6.4, High= 14.4 },
         new ChartData { X= "Wed", Low= 9.6, High= 17.2 },
         new ChartData { X= "Thu", Low= 7.5, High= 15.1 },
         new ChartData { X= "Fri", Low= 3.0, High= 10.5 },
         new ChartData { X= "Sat", Low= 1.2, High= 7.9 }
    };

    public class ChartData
    {
        public string X { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
    }
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/htroNOLJCGNGobZt?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

**DashArray**

The [DashArray](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_DashArray) property controls the dash pattern of the series border.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category">
        <ChartAxisMajorGridLines Width="0" />
    </ChartPrimaryXAxis>
    <ChartPrimaryYAxis>
        <ChartAxisLineStyle Width="0"></ChartAxisLineStyle>
        <ChartAxisMajorTickLines Width="0" />
    </ChartPrimaryYAxis>
    <ChartSeriesCollection>
        <ChartSeries DataSource="@ChartPoints" XName="X" High="High" Low="Low" Fill="blue" Opacity="0.5" DashArray="5,5" Type="ChartSeriesType.RangeStepArea">
           <ChartSeriesBorder Width="2" Color="red"></ChartSeriesBorder>
        </ChartSeries>
    </ChartSeriesCollection>
    <ChartLegendSettings Visible="false" />
</SfChart>

@code {
    public List<ChartData> ChartPoints = new List<ChartData>
    {
        new ChartData { X= "Sun", Low= 4.7, High= 9.8 },
         new ChartData { X= "Mon", Low= 4.7, High= 11.4 },
         new ChartData { X= "Tue", Low= 6.4, High= 14.4 },
         new ChartData { X= "Wed", Low= 9.6, High= 17.2 },
         new ChartData { X= "Thu", Low= 7.5, High= 15.1 },
         new ChartData { X= "Fri", Low= 3.0, High= 10.5 },
         new ChartData { X= "Sat", Low= 1.2, High= 7.9 }
    };

    public class ChartData
    {
        public string X { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
    }
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/VjVSZOLJCwWFeIUU?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

**StepPosition**

Use the [`StepPosition`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_StepPosition) property to adjust where steps render relative to data points (for example, `Left`, `Center`, or `Right`). Choose the option that best matches the sampling or bucket alignment of the data.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category">
        <ChartAxisMajorGridLines Width="0" />
    </ChartPrimaryXAxis>
    <ChartPrimaryYAxis>
        <ChartAxisLineStyle Width="0"></ChartAxisLineStyle>
        <ChartAxisMajorTickLines Width="0" />
    </ChartPrimaryYAxis>
    <ChartSeriesCollection>
        <ChartSeries DataSource="@ChartPoints" StepPosition="StepPosition.Center" XName="X" High="High" Low="Low" Type="ChartSeriesType.RangeStepArea">
            <ChartMarker Visible="true" Width="10" Height="10"></ChartMarker>
        </ChartSeries>
    </ChartSeriesCollection>
    <ChartLegendSettings Visible="false" />
</SfChart>

@code {
    public List<ChartData> ChartPoints = new List<ChartData>
    {
        new ChartData { X= "Sun", Low= 4.7, High= 9.8 },
         new ChartData { X= "Mon", Low= 4.7, High= 11.4 },
         new ChartData { X= "Tue", Low= 6.4, High= 14.4 },
         new ChartData { X= "Wed", Low= 9.6, High= 17.2 },
         new ChartData { X= "Thu", Low= 7.5, High= 15.1 },
         new ChartData { X= "Fri", Low= 3.0, High= 10.5 },
         new ChartData { X= "Sat", Low= 1.2, High= 7.9 }
    };

    public class ChartData
    {
        public string X { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
    }
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/LZreXOLJMmJzByZs?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

**Series Border**

The [ChartSeriesBorder](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeriesBorder.html) controls the border [Color](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCommonBorder.html#Syncfusion_Blazor_Charts_ChartCommonBorder_Color) and [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCommonBorder.html#Syncfusion_Blazor_Charts_ChartCommonBorder_Width).

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category">
        <ChartAxisMajorGridLines Width="0" />
    </ChartPrimaryXAxis>
    <ChartPrimaryYAxis>
        <ChartAxisLineStyle Width="0"></ChartAxisLineStyle>
        <ChartAxisMajorTickLines Width="0" />
    </ChartPrimaryYAxis>
    <ChartSeriesCollection>
        <ChartSeries DataSource="@ChartPoints" XName="X" High="High" Low="Low" Fill="blue" Type="ChartSeriesType.RangeStepArea">
           <ChartSeriesBorder Width="2" Color="red"></ChartSeriesBorder>
        </ChartSeries>
    </ChartSeriesCollection>
    <ChartLegendSettings Visible="false" />
</SfChart>

@code {
    public List<ChartData> ChartPoints = new List<ChartData>
    {
        new ChartData { X= "Sun", Low= 4.7, High= 9.8 },
         new ChartData { X= "Mon", Low= 4.7, High= 11.4 },
         new ChartData { X= "Tue", Low= 6.4, High= 14.4 },
         new ChartData { X= "Wed", Low= 9.6, High= 17.2 },
         new ChartData { X= "Thu", Low= 7.5, High= 15.1 },
         new ChartData { X= "Fri", Low= 3.0, High= 10.5 },
         new ChartData { X= "Sat", Low= 1.2, High= 7.9 }
    };

    public class ChartData
    {
        public string X { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
    }
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/VjryXEBpimdHVZrl?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> Refer to the [Blazor Charts](https://www.syncfusion.com/blazor-components/blazor-charts) feature tour and explore the [Blazor Chart examples](https://blazor.syncfusion.com/demos/chart/line?theme=bootstrap5) for additional chart types and scenarios.

## Events

### Series render

The [`OnSeriesRender`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_OnSeriesRender) event lets you customize properties such as [Data](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SeriesRenderEventArgs.html#Syncfusion_Blazor_Charts_SeriesRenderEventArgs_Data), [Fill](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SeriesRenderEventArgs.html#Syncfusion_Blazor_Charts_SeriesRenderEventArgs_Fill), and [Series](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SeriesRenderEventArgs.html#Syncfusion_Blazor_Charts_SeriesRenderEventArgs_Series) before rendering.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartEvents OnSeriesRender="SeriesRender"></ChartEvents>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category">
        <ChartAxisMajorGridLines Width="0" />
    </ChartPrimaryXAxis>
    <ChartPrimaryYAxis>
        <ChartAxisLineStyle Width="0"></ChartAxisLineStyle>
        <ChartAxisMajorTickLines Width="0" />
    </ChartPrimaryYAxis>
    <ChartSeriesCollection>
        <ChartSeries DataSource="@ChartPoints" XName="X" High="High" Low="Low" Type="ChartSeriesType.RangeStepArea">
        </ChartSeries>
    </ChartSeriesCollection>
    <ChartLegendSettings Visible="false" />
</SfChart>

@code {
    public List<ChartData> ChartPoints = new List<ChartData>
    {
        new ChartData { X= "Sun", Low= 4.7, High= 9.8 },
         new ChartData { X= "Mon", Low= 4.7, High= 11.4 },
         new ChartData { X= "Tue", Low= 6.4, High= 14.4 },
         new ChartData { X= "Wed", Low= 9.6, High= 17.2 },
         new ChartData { X= "Thu", Low= 7.5, High= 15.1 },
         new ChartData { X= "Fri", Low= 3.0, High= 10.5 },
         new ChartData { X= "Sat", Low= 1.2, High= 7.9 }
    };

    public void SeriesRender(SeriesRenderEventArgs args)
    {
        args.Fill = "#FF4081";
    }

    public class ChartData
    {
        public string X { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
    }
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/LXBItEBziPVSsXNz?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Point render

The [`OnPointRender`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_OnPointRender) event allows customization of each data point before it is rendered.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartEvents OnPointRender="PointRender"></ChartEvents>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category">
        <ChartAxisMajorGridLines Width="0" />
    </ChartPrimaryXAxis>
    <ChartPrimaryYAxis>
        <ChartAxisLineStyle Width="0"></ChartAxisLineStyle>
        <ChartAxisMajorTickLines Width="0" />
    </ChartPrimaryYAxis>
    <ChartSeriesCollection>
        <ChartSeries DataSource="@ChartPoints" XName="X" High="High" Low="Low" Type="Syncfusion.Blazor.Charts.ChartSeriesType.RangeStepArea">
            <ChartMarker Visible="true" Height="10" Width="10"></ChartMarker>
        </ChartSeries>
    </ChartSeriesCollection>
    <ChartLegendSettings Visible="false" />
</SfChart>

@code {
    public List<ChartData> ChartPoints = new List<ChartData>
    {
        new ChartData { X= "Sun", Low= 4.7, High= 9.8 },
         new ChartData { X= "Mon", Low= 4.7, High= 11.4 },
         new ChartData { X= "Tue", Low= 6.4, High= 14.4 },
         new ChartData { X= "Wed", Low= 9.6, High= 17.2 },
         new ChartData { X= "Thu", Low= 7.5, High= 15.1 },
         new ChartData { X= "Fri", Low= 3.0, High= 10.5 },
         new ChartData { X= "Sat", Low= 1.2, High= 7.9 }
    };

    public void PointRender(PointRenderEventArgs args)
    {
        args.Fill = (args.Point.Index % 2 != 0) ? "#ff6347" : "#009cb8";
    }

    public class ChartData
    {
        public string X { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
    }
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/LDrIZEhfMbUINPGz?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## See also

* [Data label](../data-labels)
* [Tooltip](../tool-tip)
