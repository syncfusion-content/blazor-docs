---
layout: post
title: Blazor Waterfall Chart Examples and Documentation | Syncfusion®
description: Learn how to create Blazor Waterfall Charts using Syncfusion. Show the cumulative effect of sequential positive and negative values.
platform: Blazor
control: Charts
documentation: ug
---

# Waterfall Chart in Blazor

## Waterfall

The Waterfall Chart displays how an initial value is affected by a series of positive and negative contributions, resulting in a cumulative total. It is commonly used to visualize incremental changes in financial and analytical data. To render a waterfall series, set the series [`Type`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Type) property to [`Waterfall`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeriesType.html#Syncfusion_Blazor_Charts_ChartSeriesType_Waterfall). Use the [`IntermediateSumIndexes`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_IntermediateSumIndexes) property to display intermediate subtotals and the SumIndexes property to display cumulative totals.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category">
    </ChartPrimaryXAxis>

    <ChartSeriesCollection>
        <ChartSeries DataSource="@SalesReports" XName="XValue" YName="YValue" Type="ChartSeriesType.Waterfall" IntermediateSumIndexes="@index" SumIndexes="@sumIndex">
            <ChartMarker Height="10" Width="10" Visible="true"></ChartMarker>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code{
    double[] index = new double[] { 4 };
    double[] sumIndex = new double[] { 8 };
	
    public class ChartData
    {
        public string XValue { get; set; }
        public double YValue { get; set; }
    }

    public List<ChartData> SalesReports = new List<ChartData>
	{
		new ChartData { XValue = "Income", YValue = 4711 },
		new ChartData { XValue = "Sales", YValue = -1015 },
		new ChartData { XValue = "Development", YValue = -688 },
		new ChartData { XValue = "Revenue", YValue = 1030 },
		new ChartData { XValue = "Balance" },
		new ChartData { XValue = "Expense", YValue = -361 },
		new ChartData { XValue = "Tax", YValue = -695 },
		new ChartData { XValue = "Net Profit" },
	};
}

``` 
{% previewsample "https://blazorplayground.syncfusion.com/embed/LZhRDHCLysdCeIuP?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Blazor Waterfall Chart](../images/othertypes/blazor-waterfall-chart.webp)" %}

N> Refer to the [Blazor Waterfall Chart Example](https://blazor.syncfusion.com/demos/chart/waterfall?theme=fluent2) to learn how to render and configure the Waterfall chart.

## Binding data with series

You can bind data to the chart using the [`DataSource`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_DataSource) property within the series configuration. The [`DataSource`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_DataSource) value can be set using either [`SfDataManager`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) property values or a list of business objects. More information on data binding can be found in [Working with data](../working-with-data). To display the data correctly, map the fields from the data to the chart series' [`XName`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_XName) and [`YName`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_YName) properties.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category">
    </ChartPrimaryXAxis>

    <ChartSeriesCollection>
        <ChartSeries DataSource="@SalesReports" XName="XValue" YName="YValue" Type="ChartSeriesType.Waterfall" IntermediateSumIndexes="@index" SumIndexes="@sumIndex">
            <ChartMarker Height="10" Width="10" Visible="true"></ChartMarker>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code{
    double[] index = new double[] { 4 };
    double[] sumIndex = new double[] { 8 };
	
    public class ChartData
    {
        public string XValue { get; set; }
        public double YValue { get; set; }
    }

    public List<ChartData> SalesReports = new List<ChartData>
	{
		new ChartData { XValue = "Income", YValue = 4711 },
		new ChartData { XValue = "Sales", YValue = -1015 },
		new ChartData { XValue = "Development", YValue = -688 },
		new ChartData { XValue = "Revenue", YValue = 1030 },
		new ChartData { XValue = "Balance" },
		new ChartData { XValue = "Expense", YValue = -361 },
		new ChartData { XValue = "Tax", YValue = -695 },
		new ChartData { XValue = "Net Profit" },
	};
}

``` 
{% previewsample "https://blazorplayground.syncfusion.com/embed/rDBdZxWLIsnSbonu?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" %}

## Series customization 

The negative changes of waterfall charts are represented by using [NegativeFillColor](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_NegativeFillColor) and the summary changes are represented by using [SummaryFillColor](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_SummaryFillColor) properties respectively. By default, the [NegativeFillColor](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_NegativeFillColor) is **#E94649** and the [SummaryFillColor](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_SummaryFillColor) is **#4E81BC**.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category">
    </ChartPrimaryXAxis>

    <ChartSeriesCollection>
        <ChartSeries DataSource="@SalesReports" SummaryFillColor="#e56590" NegativeFillColor="#f8b883" XName="XValue" YName="YValue" Type="Syncfusion.Blazor.Charts.ChartSeriesType.Waterfall" IntermediateSumIndexes="@index" SumIndexes="@sumIndex">
            <ChartMarker Height="10" Width="10" Visible="true"></ChartMarker>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    double[] index = new double[] { 4 };
    double[] sumIndex = new double[] { 8 };

    public class ChartData
    {
        public string XValue { get; set; }
        public double YValue { get; set; }
    }

    public List<ChartData> SalesReports = new List<ChartData>
    {
        new ChartData { XValue = "Income", YValue = 4711 },
        new ChartData { XValue = "Sales", YValue = -1015 },
        new ChartData { XValue = "Development", YValue = -688 },
        new ChartData { XValue = "Revenue", YValue = 1030 },
        new ChartData { XValue = "Balance" },
        new ChartData { XValue = "Expense", YValue = -361 },
        new ChartData { XValue = "Tax", YValue = -695 },
        new ChartData { XValue = "Net Profit" },
    };
}

``` 

{% previewsample "https://blazorplayground.syncfusion.com/embed/htrxjHMLSMwZKzGF?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" %}

### Corner radius

The [ChartCornerRadius](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCornerRadius.html) property is used to customize the corner radius for Waterfall series. This allows you to create columns with rounded corners, giving your chart a more polished appearance. You can customize each corner of the columns using the [BottomLeft](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCornerRadius.html#Syncfusion_Blazor_Charts_ChartCornerRadius_BottomLeft), [BottomRight](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCornerRadius.html#Syncfusion_Blazor_Charts_ChartCornerRadius_BottomRight), [TopLeft](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCornerRadius.html#Syncfusion_Blazor_Charts_ChartCornerRadius_TopLeft), [TopRight](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCornerRadius.html#Syncfusion_Blazor_Charts_ChartCornerRadius_TopRight) properties.

```cshtml
@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category">
    </ChartPrimaryXAxis>

    <ChartSeriesCollection>
        <ChartSeries DataSource="@SalesReports" SummaryFillColor="#e56590" NegativeFillColor="#f8b883" XName="XValue" YName="YValue" Type="Syncfusion.Blazor.Charts.ChartSeriesType.Waterfall" IntermediateSumIndexes="@index" SumIndexes="@sumIndex">
            <ChartCornerRadius TopLeft="5" TopRight="5" BottomLeft="5" BottomRight="5"></ChartCornerRadius>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    double[] index = new double[] { 4 };
    double[] sumIndex = new double[] { 8 };

    public class ChartData
    {
        public string XValue { get; set; }
        public double YValue { get; set; }
    }

    public List<ChartData> SalesReports = new List<ChartData>
    {
        new ChartData { XValue = "Income", YValue = 4711 },
        new ChartData { XValue = "Sales", YValue = -1015 },
        new ChartData { XValue = "Development", YValue = -688 },
        new ChartData { XValue = "Revenue", YValue = 1030 },
        new ChartData { XValue = "Balance" },
        new ChartData { XValue = "Expense", YValue = -361 },
        new ChartData { XValue = "Tax", YValue = -695 },
        new ChartData { XValue = "Net Profit", YValue = -587},
    };
}
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/LjhdtxsBoiwxaGyi?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Blazor Waterfall Chart with corner radius](../images/chart-types-images/blazor-waterfall-chart-corner-radius.webp)" %}

Customize the corner radius for individual points in the chart series using the [OnPointRender](https://blazor.syncfusion.com/documentation/chart/events#onpointrender) event by utilizing the [CornerRadius](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.PointRenderEventArgs.html#Syncfusion_Blazor_Charts_PointRenderEventArgs_CornerRadius) property in its event argument.

```cshtml
@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartEvents OnPointRender="PointRenderEvent"></ChartEvents>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category">
    </ChartPrimaryXAxis>

    <ChartSeriesCollection>
        <ChartSeries DataSource="@SalesReports" SummaryFillColor="#e56590" NegativeFillColor="#f8b883" XName="XValue" YName="YValue" Type="Syncfusion.Blazor.Charts.ChartSeriesType.Waterfall" IntermediateSumIndexes="@index" SumIndexes="@sumIndex">
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    double[] index = new double[] { 4 };
    double[] sumIndex = new double[] { 8 };

    public class ChartData
    {
        public string XValue { get; set; }
        public double YValue { get; set; }
    }

    public List<ChartData> SalesReports = new List<ChartData>
    {
        new ChartData { XValue = "Income", YValue = 4711 },
        new ChartData { XValue = "Sales", YValue = -1015 },
        new ChartData { XValue = "Development", YValue = -688 },
        new ChartData { XValue = "Revenue", YValue = 1030 },
        new ChartData { XValue = "Balance" },
        new ChartData { XValue = "Expense", YValue = -361 },
        new ChartData { XValue = "Tax", YValue = -695 },
        new ChartData { XValue = "Net Profit", YValue = -587},
    };

    public void PointRenderEvent(PointRenderEventArgs args)
    {
        if ((args.Point.X as string) == "Income" || (args.Point.X as string) == "Development" || (args.Point.X as string) == "Balance" || (args.Point.X as string) == "Tax")
        {
            args.CornerRadius.BottomLeft = 5;
            args.CornerRadius.BottomRight = 5;
            args.CornerRadius.TopLeft = 5;
            args.CornerRadius.TopRight = 5;
        }
    }
}
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/hjBdXRsLoCFTkiLm?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Blazor Waterfall Chart with corner radius using OnPointRender event](../images/chart-types-images/blazor-waterfall-chart-corner-radius-onPointRender.webp)" %}

## Empty points

Data points with `null`, `double.NaN` or `undefined` values are considered empty. Empty data points are ignored and not plotted on the chart.

**Mode**

Use the [`Mode`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEmptyPointSettings.html#Syncfusion_Blazor_Charts_ChartEmptyPointSettings_Mode) property to define how empty or missing data points are handled in the series. The available values are [`Gap`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.EmptyPointMode.html#Syncfusion_Blazor_Charts_EmptyPointMode_Gap) (default — leave space at the empty point), [`Zero`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.EmptyPointMode.html#Syncfusion_Blazor_Charts_EmptyPointMode_Zero) (plot at zero), [`Average`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.EmptyPointMode.html#Syncfusion_Blazor_Charts_EmptyPointMode_Average) (replace with the average of neighboring points), and [`Drop`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.EmptyPointMode.html#Syncfusion_Blazor_Charts_EmptyPointMode_Drop) (remove the connecting bar).

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category">
    </ChartPrimaryXAxis>

    <ChartSeriesCollection>
        <ChartSeries DataSource="@SalesReports" XName="XValue" YName="YValue" Type="Syncfusion.Blazor.Charts.ChartSeriesType.Waterfall" IntermediateSumIndexes="@index" SumIndexes="@sumIndex">
            <ChartEmptyPointSettings Mode="EmptyPointMode.Gap"></ChartEmptyPointSettings>
            <ChartMarker Height="10" Width="10" Visible="true"></ChartMarker>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    double[] index = new double[] { 4 };
    double[] sumIndex = new double[] { 8 };

    public class ChartData
    {
        public string XValue { get; set; }
        public double YValue { get; set; }
    }

    public List<ChartData> SalesReports = new List<ChartData>
    {
        new ChartData { XValue = "Income", YValue = 4711 },
        new ChartData { XValue = "Sales", YValue = -1015 },
        new ChartData { XValue = "Development", YValue = -688 },
        new ChartData { XValue = "Revenue", YValue = double.NaN },
        new ChartData { XValue = "Balance" },
        new ChartData { XValue = "Expense", YValue = -361 },
        new ChartData { XValue = "Tax", YValue = -695 },
        new ChartData { XValue = "Net Profit" },
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/LthnZHCreWkCTHcl?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" %}

**Fill**

Use the [`Fill`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEmptyPointSettings.html#Syncfusion_Blazor_Charts_ChartEmptyPointSettings_Fill) property to customize the fill color of empty points in the series.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category">
    </ChartPrimaryXAxis>

    <ChartSeriesCollection>
        <ChartSeries DataSource="@SalesReports" XName="XValue" YName="YValue" Type="Syncfusion.Blazor.Charts.ChartSeriesType.Waterfall" IntermediateSumIndexes="@index" SumIndexes="@sumIndex">
            <ChartEmptyPointSettings Fill="#FFDE59" Mode="EmptyPointMode.Average"></ChartEmptyPointSettings>
            <ChartMarker Height="10" Width="10" Visible="true"></ChartMarker>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    double[] index = new double[] { 4 };
    double[] sumIndex = new double[] { 8 };

    public class ChartData
    {
        public string XValue { get; set; }
        public double YValue { get; set; }
    }

    public List<ChartData> SalesReports = new List<ChartData>
    {
        new ChartData { XValue = "Income", YValue = 4711 },
        new ChartData { XValue = "Sales", YValue = -1015 },
        new ChartData { XValue = "Development", YValue = -688 },
        new ChartData { XValue = "Revenue", YValue = double.NaN },
        new ChartData { XValue = "Balance" },
        new ChartData { XValue = "Expense", YValue = -361 },
        new ChartData { XValue = "Tax", YValue = -695 },
        new ChartData { XValue = "Net Profit" },
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/hZVnNHCrIMaylXLp?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" %}

**Border**

Use the [`Border`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEmptyPointSettings.html#Syncfusion_Blazor_Charts_ChartEmptyPointSettings_Border) property to customize the [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEmptyPointBorder.html#Syncfusion_Blazor_Charts_ChartEmptyPointBorder_Width) and [Color](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEmptyPointBorder.html#Syncfusion_Blazor_Charts_ChartEmptyPointBorder_Color) of the border for empty points.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category">
    </ChartPrimaryXAxis>

    <ChartSeriesCollection>
        <ChartSeries DataSource="@SalesReports" XName="XValue" YName="YValue" Type="Syncfusion.Blazor.Charts.ChartSeriesType.Waterfall" IntermediateSumIndexes="@index" SumIndexes="@sumIndex">
            <ChartEmptyPointSettings Fill="#FFDE59" Mode="EmptyPointMode.Average">
                <ChartEmptyPointBorder Color="red" Width="2"></ChartEmptyPointBorder>
            </ChartEmptyPointSettings>
            <ChartMarker Height="10" Width="10" Visible="true"></ChartMarker>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    double[] index = new double[] { 4 };
    double[] sumIndex = new double[] { 8 };

    public class ChartData
    {
        public string XValue { get; set; }
        public double YValue { get; set; }
    }

    public List<ChartData> SalesReports = new List<ChartData>
    {
        new ChartData { XValue = "Income", YValue = 4711 },
        new ChartData { XValue = "Sales", YValue = -1015 },
        new ChartData { XValue = "Development", YValue = -688 },
        new ChartData { XValue = "Revenue", YValue = double.NaN },
        new ChartData { XValue = "Balance" },
        new ChartData { XValue = "Expense", YValue = -361 },
        new ChartData { XValue = "Tax", YValue = -695 },
        new ChartData { XValue = "Net Profit" },
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/LjLHXRMhSVNijbaN?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" %}

## Events

### Series render

The [`OnSeriesRender`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_OnSeriesRender) event allows you to customize series properties, such as [Data](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SeriesRenderEventArgs.html#Syncfusion_Blazor_Charts_SeriesRenderEventArgs_Data), [Fill](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SeriesRenderEventArgs.html#Syncfusion_Blazor_Charts_SeriesRenderEventArgs_Fill), and [Series](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SeriesRenderEventArgs.html#Syncfusion_Blazor_Charts_SeriesRenderEventArgs_Series), before they are rendered on the chart.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category">
    </ChartPrimaryXAxis>
    <ChartEvents OnSeriesRender="SeriesRender"></ChartEvents>
    <ChartSeriesCollection>
        <ChartSeries DataSource="@SalesReports" XName="XValue" YName="YValue" Type="Syncfusion.Blazor.Charts.ChartSeriesType.Waterfall" IntermediateSumIndexes="@index" SumIndexes="@sumIndex">
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    double[] index = new double[] { 4 };
    double[] sumIndex = new double[] { 8 };

    public class ChartData
    {
        public string XValue { get; set; }
        public double YValue { get; set; }
    }

    public void SeriesRender(SeriesRenderEventArgs args)
    {
        args.Series.SummaryFillColor = "green";
        args.Series.NegativeFillColor = "blue";
        args.Fill = "red";
    }

    public List<ChartData> SalesReports = new List<ChartData>
    {
        new ChartData { XValue = "Income", YValue = 4711 },
        new ChartData { XValue = "Sales", YValue = -1015 },
        new ChartData { XValue = "Development", YValue = -688 },
        new ChartData { XValue = "Revenue", YValue = 1030 },
        new ChartData { XValue = "Balance" },
        new ChartData { XValue = "Expense", YValue = -361 },
        new ChartData { XValue = "Tax", YValue = -695 },
        new ChartData { XValue = "Net Profit" },
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/VNrdDdsVyhZRSkVt?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" %}

### Point render

The [`OnPointRender`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_OnPointRender) event allows you to customize each data point before it is rendered on the chart.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category">
    </ChartPrimaryXAxis>
    <ChartEvents OnPointRender="PointRender"></ChartEvents>
    <ChartSeriesCollection>
        <ChartSeries DataSource="@SalesReports" XName="XValue" YName="YValue" Type="Syncfusion.Blazor.Charts.ChartSeriesType.Waterfall" IntermediateSumIndexes="@index" SumIndexes="@sumIndex">
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    double[] index = new double[] { 4 };
    double[] sumIndex = new double[] { 8 };

    public class ChartData
    {
        public string XValue { get; set; }
        public double YValue { get; set; }
    }

    public void PointRender(PointRenderEventArgs args)
    {
        args.Fill = args.Point.X.ToString() == "Revenue" ? "#E91E63" : "#3F51B5";
        args.Series.SummaryFillColor = args.Point.X.ToString() == "Revenue" ? "#E91E63" : "#3F51B5";
        args.Series.NegativeFillColor = args.Point.X.ToString() == "Revenue" ? "#E91E63" : "#3F51B5";
    }

    public List<ChartData> SalesReports = new List<ChartData>
    {
        new ChartData { XValue = "Income", YValue = 4711 },
        new ChartData { XValue = "Sales", YValue = -1015 },
        new ChartData { XValue = "Development", YValue = -688 },
        new ChartData { XValue = "Revenue", YValue = 1030 },
        new ChartData { XValue = "Balance" },
        new ChartData { XValue = "Expense", YValue = -361 },
        new ChartData { XValue = "Tax", YValue = -695 },
        new ChartData { XValue = "Net Profit" },
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/VjBnXnMLeBWgBnvV?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" %}

N> Refer to the [Blazor Charts](https://www.syncfusion.com/blazor-components/blazor-charts) feature tour page for its groundbreaking feature representations, and explore the [Blazor Waterfall Chart Example](https://blazor.syncfusion.com/demos/chart/waterfall?theme=fluent2) to learn how to render cumulative contribution charts.

## See also

* [Data Label](../data-labels)
* [Tooltip](../tool-tip)
* [Data Marker](../data-markers)
* [Legend](../legend)