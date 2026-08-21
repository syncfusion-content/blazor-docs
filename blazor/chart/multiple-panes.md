---
layout: post
title: Blazor Charts Multiple Panes Examples | Syncfusion®
description: Learn how to divide Blazor Charts into multiple panes. Use ChartRows and ChartColumns to give each pane its own height, axis, and series.
platform: Blazor
control: Charts
documentation: ug
---

# Blazor Charts Multiple Panes

The chart area can be divided into multiple panes using the [Rows](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartRow.html) and [Columns](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartColumn.html) collections. Use **rows** to stack series vertically (each pane gets its own height and Y axis), and use **columns** to place series side by side horizontally (each pane gets its own width and X axis). When you mix rows and columns, you create a grid of panes.

N> Multiple panes are supported in the [Syncfusion.Blazor.Charts](https://www.nuget.org/packages/Syncfusion.Blazor.Charts) NuGet package starting with Syncfusion Blazor `19.2.0.49`.

## Rows

Use the chart's [Rows](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartRow.html) collection to divide the chart area vertically into any number of rows.

* The [Height](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartRow.html#Syncfusion_Blazor_Charts_ChartRow_Height) property allocates space for each row. The value can be expressed as a percentage or in pixels.
* To bind a vertical axis to a specific row, set the axis's [RowIndex](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartAxis.html#Syncfusion_Blazor_Charts_ChartAxis_RowIndex) property to that row's index.
* The bottom line of each row can be customized using the [Border](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartRow.html#Syncfusion_Blazor_Charts_ChartRow_Border) property, as shown in the [Customizing row borders](#customizing-row-borders) section.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart Title="Weather condition JPN vs DEU">
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category"/>    

    <ChartPrimaryYAxis Title="Temperature (Fahrenheit)" LabelFormat="{value}°F" Minimum="0" Maximum="90" Interval="20"/>    

    <ChartRows>
        <ChartRow Height="50%"/>
        <ChartRow Height="50%"/>
    </ChartRows>

    <ChartAxes>
        <ChartAxis Minimum="24" Maximum="36" Interval="2" OpposedPosition="true" RowIndex="1" Name="YAxis" LabelFormat="{value}°C"/>        
    </ChartAxes>

    <ChartSeriesCollection>

        <ChartSeries DataSource="@WeatherReports" XName="X" YName="Y" Type="ChartSeriesType.Column"/>
        
        <ChartSeries DataSource="@WeatherReports" XName="X" YName="Y1" YAxisName="YAxis"/>
        
    </ChartSeriesCollection>
</SfChart>

@code {
    public class ChartData
    {
        public string X { get; set; }
        public double Y { get; set; }
        public double Y1 { get; set; }
    }

	public List<ChartData> WeatherReports = new List<ChartData>
	{
		new ChartData{ X= "Jan", Y= 15, Y1= 33 },
		new ChartData{ X= "Feb", Y= 20, Y1= 31 },
		new ChartData{ X= "Mar", Y= 35, Y1= 30 },
		new ChartData{ X= "Apr", Y= 40, Y1= 28 },
		new ChartData{ X= "May", Y= 80, Y1= 29 },
		new ChartData{ X= "Jun", Y= 70, Y1= 30 },
		new ChartData{ X= "Jul", Y= 65, Y1= 33 },
		new ChartData{ X= "Aug", Y= 55, Y1= 32 },
		new ChartData{ X= "Sep", Y= 50, Y1= 34 },
		new ChartData{ X= "Oct", Y= 30, Y1= 32 },
		new ChartData{ X= "Nov", Y= 35, Y1= 32 },
		new ChartData{ X= "Dec", Y= 35, Y1= 31 }
	};
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BjBxNHWLzJlLnsVV?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Rows with Multiple Panes in Blazor Chart](images/multiple-panes/blazor-chart-multiple-panes-with-rows.webp)" %}

### Spanning the primary Y axis across rows

The [Span](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartAxis.html#Syncfusion_Blazor_Charts_ChartAxis_Span) property on the primary axis can stretch the primary Y axis across every row in the chart, so a single axis references all vertically stacked panes.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart Title="Weather condition JPN vs DEU">
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category"/>    

    <ChartPrimaryYAxis Span="2" Title="Temperature (Fahrenheit)" LabelFormat="{value}°F" Minimum="0" Maximum="90" Interval="20"/>    

    <ChartRows>
        <ChartRow Height="50%"/>
        <ChartRow Height="50%"/>
    </ChartRows>

    <ChartAxes>
        <ChartAxis Minimum="24" Maximum="36" Interval="2" OpposedPosition="true" RowIndex="1" Name="YAxis" LabelFormat="{value}°C"/>        
    </ChartAxes>

    <ChartSeriesCollection>

        <ChartSeries DataSource="@WeatherReports" XName="X" YName="Y" Type="ChartSeriesType.Column"/>
        
        <ChartSeries DataSource="@WeatherReports" XName="X" YName="Y1" YAxisName="YAxis"/>
        
    </ChartSeriesCollection>
</SfChart>

@code {
    public class ChartData
    {
        public string X { get; set; }
        public double Y { get; set; }
        public double Y1 { get; set; }
    }

	public List<ChartData> WeatherReports = new List<ChartData>
	{
		new ChartData{ X= "Jan", Y= 15, Y1= 33 },
		new ChartData{ X= "Feb", Y= 20, Y1= 31 },
		new ChartData{ X= "Mar", Y= 35, Y1= 30 },
		new ChartData{ X= "Apr", Y= 40, Y1= 28 },
		new ChartData{ X= "May", Y= 80, Y1= 29 },
		new ChartData{ X= "Jun", Y= 70, Y1= 30 },
		new ChartData{ X= "Jul", Y= 65, Y1= 33 },
		new ChartData{ X= "Aug", Y= 55, Y1= 32 },
		new ChartData{ X= "Sep", Y= 50, Y1= 34 },
		new ChartData{ X= "Oct", Y= 30, Y1= 32 },
		new ChartData{ X= "Nov", Y= 35, Y1= 32 },
		new ChartData{ X= "Dec", Y= 35, Y1= 31 }
	};
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/LtLdXnWhJflSYgFU?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Row spanning with Multiple Panes in Blazor Chart](images/multiple-panes/blazor-chart-multiple-span-with-rows-span.webp)" %}

## Columns

Use the chart's [Columns](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartColumn.html) collection to divide the chart area horizontally into any number of columns.

* The [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartColumn.html#Syncfusion_Blazor_Charts_ChartColumn_Width) property allocates space for each column. The value can be expressed as a percentage or in pixels.
* To bind a horizontal axis to a specific column, set the axis's [ColumnIndex](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartAxis.html#Syncfusion_Blazor_Charts_ChartAxis_ColumnIndex) property to that column's index.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart Title="Weather condition JPN vs DEU">

    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category"/>    

    <ChartColumns>
        <ChartColumn Width="50%"/>
        <ChartColumn Width="50%"/>
    </ChartColumns>

    <ChartAxes>
        <ChartAxis Interval="2" OpposedPosition="true" ColumnIndex="1" Name="XAxis" ValueType="Syncfusion.Blazor.Charts.ValueType.Category"/>
       
    </ChartAxes>

    <ChartSeriesCollection>
        <ChartSeries DataSource="@WeatherReports" XName="X" YName="Y" Type="ChartSeriesType.Column"/>
        <ChartSeries DataSource="@WeatherReports" XName="X" YName="Y1" XAxisName="XAxis" />       
    </ChartSeriesCollection>
</SfChart>

@code {
    public class ChartData
    {
        public string X { get; set; }
        public double Y { get; set; }
        public double Y1 { get; set; }
    }

	public List<ChartData> WeatherReports = new List<ChartData>
	{
		new ChartData{ X= "Jan", Y= 15, Y1= 33 },
		new ChartData{ X= "Feb", Y= 20, Y1= 31 },
		new ChartData{ X= "Mar", Y= 35, Y1= 30 },
		new ChartData{ X= "Apr", Y= 40, Y1= 28 },
		new ChartData{ X= "May", Y= 80, Y1= 29 },
		new ChartData{ X= "Jun", Y= 70, Y1= 30 },
		new ChartData{ X= "Jul", Y= 65, Y1= 33 },
		new ChartData{ X= "Aug", Y= 55, Y1= 32 },
		new ChartData{ X= "Sep", Y= 50, Y1= 34 },
		new ChartData{ X= "Oct", Y= 30, Y1= 32 },
		new ChartData{ X= "Nov", Y= 35, Y1= 32 },
		new ChartData{ X= "Dec", Y= 35, Y1= 31 }
	};
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BjLRNFszTJmzqmeF?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Columns with Multiple Panes in Blazor Chart](images/multiple-panes/blazor-chart-multiple-panes-with-column.webp)" %}

### Spanning the primary X axis across columns

The [Span](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartAxis.html#Syncfusion_Blazor_Charts_ChartAxis_Span) property on the primary X axis can stretch the primary X axis across every column in the chart, so a single category axis references all horizontally arranged panes.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart Title="Weather condition JPN vs DEU">

    <ChartPrimaryXAxis Span="2" ValueType="Syncfusion.Blazor.Charts.ValueType.Category"/>    

    <ChartPrimaryYAxis Title="Temperature (Fahrenheit)" LabelFormat="{value}°F" Minimum="0" Maximum="90" Interval="20"/>
    
    <ChartColumns>
        <ChartColumn Width="50%"/>
        <ChartColumn Width="50%"/>
    </ChartColumns>

    <ChartAxes>
        <ChartAxis Interval="2" OpposedPosition="true" ColumnIndex="1" Name="XAxis" ValueType="Syncfusion.Blazor.Charts.ValueType.Category"/>
       
    </ChartAxes>

    <ChartSeriesCollection>
        <ChartSeries DataSource="@WeatherReports" XName="X" YName="Y" Type="ChartSeriesType.Column"/>
        <ChartSeries DataSource="@WeatherReports" XName="X" YName="Y1" XAxisName="XAxis" />       
    </ChartSeriesCollection>
</SfChart>

@code {
    public class ChartData
    {
        public string X { get; set; }
        public double Y { get; set; }
        public double Y1 { get; set; }
    }

    public List<ChartData> WeatherReports = new List<ChartData>
	{
		new ChartData{ X= "Jan", Y= 15, Y1= 33 },
		new ChartData{ X= "Feb", Y= 20, Y1= 31 },
		new ChartData{ X= "Mar", Y= 35, Y1= 30 },
		new ChartData{ X= "Apr", Y= 40, Y1= 28 },
		new ChartData{ X= "May", Y= 80, Y1= 29 },
		new ChartData{ X= "Jun", Y= 70, Y1= 30 },
		new ChartData{ X= "Jul", Y= 65, Y1= 33 },
		new ChartData{ X= "Aug", Y= 55, Y1= 32 },
		new ChartData{ X= "Sep", Y= 50, Y1= 34 },
		new ChartData{ X= "Oct", Y= 30, Y1= 32 },
		new ChartData{ X= "Nov", Y= 35, Y1= 32 },
		new ChartData{ X= "Dec", Y= 35, Y1= 31 }
	};
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BtBntdWBJfEgZHGh?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Column Spanning with Multiple Panes in Blazor Chart](images/multiple-panes/blazor-chart-multiple-panes-with-column-span.webp)" %}

## See also

* [Data label](./data-labels)
* [Tooltip](./tool-tip)
* [Marker](./data-markers)
