---
layout: post
title: Waterfall in Blazor Charts Component | Syncfusion
description: Checkout and learn here all about Waterfall Chart in Syncfusion Blazor Charts component and much more.
platform: Blazor
control: Chart
documentation: ug
---

# Waterfall in Blazor Charts Component

## Waterfall

`Waterfall Chart` helps to understand the cumulative effect of the sequentially introduced positive and negative values. To render a waterfall series, set the series [Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Type) as **Waterfall**. [IntermediateSumIndexes](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_IntermediateSumIndexes) property of waterfall is used to represent the in-between sum values and [SumIndexes](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_SumIndexes) is used to represent the cumulative sum values.

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
{% previewsample "https://blazorplayground.syncfusion.com/embed/BNhzNbVjepXCmPUR?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor Waterfall Chart](../images/othertypes/blazor-waterfall-chart.png)

N> Explore our [Blazor Waterfall Chart Example](https://blazor.syncfusion.com/demos/chart/waterfall?theme=bootstrap5) to know how to render and configure the Waterfall type chart.

## Binding data with series

You can bind data to the chart using the [`DataSource`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_DataSource) property within the series configuration. The [`DataSource`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_DataSource) value can be set using either [`SfDataManager`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) property values or a list of business objects. More information on data binding can be found [here](../working-with-data). To display the data correctly, map the fields from the data to the chart series' [`XName`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_XName) and [`YName`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_YName) properties.

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
{% previewsample "https://blazorplayground.syncfusion.com/embed/BNhzNbVjepXCmPUR?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

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

{% previewsample "https://blazorplayground.syncfusion.com/embed/LjhTtuiqSypahHvu?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Empty points

Data points with `null`, `double.NaN` or `undefined` values are considered empty. Empty data points are ignored and not plotted on the chart.

**Mode**

Use the [`Mode`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEmptyPointSettings.html#Syncfusion_Blazor_Charts_ChartEmptyPointSettings_Mode) property to define how empty or missing data points are handled in the series. The default mode for empty points is [`Gap`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.EmptyPointMode.html#Syncfusion_Blazor_Charts_EmptyPointMode_Gap).

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
{% previewsample "https://blazorplayground.syncfusion.com/embed/hDhptlBXopnVPtmr?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

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
{% previewsample "https://blazorplayground.syncfusion.com/embed/LDLTXlVNSzGeHAIC?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

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
{% previewsample "https://blazorplayground.syncfusion.com/embed/rtrJNvBZIJlcWPCQ?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

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
{% previewsample "https://blazorplayground.syncfusion.com/embed/rjhpZvrtIHLqzmYX?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

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
{% previewsample "https://blazorplayground.syncfusion.com/embed/BDVJtbVtIdfizCZu?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

N> Refer to our [Blazor Charts](https://www.syncfusion.com/blazor-components/blazor-charts) feature tour page for its groundbreaking feature representations and also explore our [Blazor Chart Example](https://blazor.syncfusion.com/demos/chart/line?theme=bootstrap5) to know various chart types and how to represent time-dependent data, showing trends at equal intervals.

## See also

* [Data Label](../data-labels)
* [Tooltip](../tool-tip)