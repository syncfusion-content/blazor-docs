---
layout: post
title: Blazor Charts Tooltip Examples | Syncfusion®
description: Learn how to enable tooltips in Syncfusion Blazor Charts. Set ChartTooltipSettings Enable to true. Supports templates and custom formatting.
platform: Blazor
control: Charts
documentation: ug
---

# Blazor Charts Tooltip

<!-- markdownlint-disable MD036 -->

<<<<<<< HEAD
This section covers how to enable, format, template, customize, and highlight tooltips in the Blazor Charts component.

A detailed walkthrough demonstrating how to add and customize tooltips in the chart is presented in the video below.
=======
When the mouse is moved over a point on the chart, the tooltip will provide information about that point.

A detailed walkthrough demonstrating how to add and customize tooltip in the chart is presented in the video below.
>>>>>>> 655e5219cae0555ffa90c568af9ca098db13f034

{% youtube "youtube:https://www.youtube.com/watch?v=4g8JTwHuTz4" %}

## Enable tooltip

When space constraints prevent information from being displayed through data labels, tooltips provide an effective alternative. Tooltips can be enabled by setting the [Enable](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartTooltipSettings.html#Syncfusion_Blazor_Charts_ChartTooltipSettings_Enable) property in [ChartTooltipSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartTooltipSettings.html) to **true**.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart Title="Product Sales">
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />

<<<<<<< HEAD
    <ChartPrimaryYAxis LabelFormat="{value}M"></ChartPrimaryYAxis>
=======
    <ChartPrimaryYAxis LabelFormat="{value}M"  >

    </ChartPrimaryYAxis>
>>>>>>> 655e5219cae0555ffa90c568af9ca098db13f034

    <ChartTooltipSettings Enable="true"></ChartTooltipSettings>

    <ChartSeriesCollection>
<<<<<<< HEAD
        <ChartSeries DataSource="@SalesReports" Name="Sales" XName="X" YName="Y" Type="ChartSeriesType.Column">
=======
        <ChartSeries DataSource="@SalesReports" Name="Text" XName="X" YName="Y" Type="ChartSeriesType.Column">
>>>>>>> 655e5219cae0555ffa90c568af9ca098db13f034
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

<<<<<<< HEAD
@code {
    public class ColumnSalesData
    {
        public string X { get; set; }
        public double Y { get; set; }
    }

    public List<ColumnSalesData> SalesReports = new List<ColumnSalesData>
    {
       new ColumnSalesData { X = "Jan", Y = 3 },
       new ColumnSalesData { X = "Feb", Y = 3.5 },
       new ColumnSalesData { X = "Mar", Y = 7, },
       new ColumnSalesData { X = "Apr", Y = 13.5 }
=======
@code{
    public class Data
    {
        public string X { get; set; }
        public double Y { get; set; }
        public string Text { get; set; }
    }

    public List<Data> SalesReports = new List<Data>
	{
       new Data{ X= "Jan", Y= 3, Text= "January" },
       new Data{ X= "Feb", Y= 3.5, Text= "February" },
       new Data{ X= "Mar", Y= 7, Text= "March" },
       new Data{ X= "Apr", Y= 13.5, Text= "April" }
>>>>>>> 655e5219cae0555ffa90c568af9ca098db13f034
    };
}

```

![Blazor Column Chart with Tooltip](images/tooltip/blazor-column-chart-tooltip.webp)

## Tooltip format

<<<<<<< HEAD
By default, the tooltip displays the x and y values of a data point. In addition, further information can be displayed in the tooltip. For example, the format `${series.name} : ${point.y}` displays the series name and point y-value in the tooltip. The format can be specified using the [Format](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartTooltipSettings.html#Syncfusion_Blazor_Charts_ChartTooltipSettings_Format) property in [ChartTooltipSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartTooltipSettings.html). The [Header](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartTooltipSettings.html#Syncfusion_Blazor_Charts_ChartTooltipSettings_Header) property sets a custom header that appears above the formatted content.
=======
<!-- markdownlint-disable MD013 -->

By default, The tooltip displays x and y values of a data point. In addition, further information can be displayed in the tooltip. For example, the format **$series.name $point.x** displays series name and point x-value in the tooltip. The format can be specified using the [Format](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartTooltipSettings.html#Syncfusion_Blazor_Charts_ChartTooltipSettings_Format) property in [ChartTooltipSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartTooltipSettings.html).
>>>>>>> 655e5219cae0555ffa90c568af9ca098db13f034

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart Title="Product Sales">
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />

    <ChartPrimaryYAxis LabelFormat="{value}M"></ChartPrimaryYAxis>

    <ChartTooltipSettings Enable="true" Header="Sales" Format="<b>${series.name} : ${point.y}</b>"></ChartTooltipSettings>

    <ChartSeriesCollection>
<<<<<<< HEAD
        <ChartSeries DataSource="@SalesReports" Name="Sales" XName="X" YName="Y" Type="ChartSeriesType.Column">
=======
        <ChartSeries DataSource="@SalesReports" XName="X" YName="Y" Type="ChartSeriesType.Column">
>>>>>>> 655e5219cae0555ffa90c568af9ca098db13f034
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

<<<<<<< HEAD
@code {
    public class ColumnSalesFormatData
    {
        public string X { get; set; }
        public double Y { get; set; }
    }

    public List<ColumnSalesFormatData> SalesReports = new List<ColumnSalesFormatData>
    {
       new ColumnSalesFormatData { X = "Jan", Y = 3 },
       new ColumnSalesFormatData { X = "Feb", Y = 3.5 },
       new ColumnSalesFormatData { X = "Mar", Y = 7 },
       new ColumnSalesFormatData { X = "Apr", Y = 13.5 }
=======
@code{
    public class Data
    {
        public string X { get; set; }
        public double Y { get; set; }
        public string Text { get; set; }
    }

    public List<Data> SalesReports = new List<Data>
	{
       new Data{ X= "Jan", Y= 3, Text= "January" },
       new Data{ X= "Feb", Y= 3.5, Text= "February" },
       new Data{ X= "Mar", Y= 7, Text= "March" },
       new Data{ X= "Apr", Y= 13.5, Text= "April" }
>>>>>>> 655e5219cae0555ffa90c568af9ca098db13f034
    };
}

```

![Blazor Column Chart with Tooltip Format](images/tooltip/blazor-column-chart-tooltip-format.webp)

<<<<<<< HEAD
=======
<!-- markdownlint-disable MD013 -->

>>>>>>> 655e5219cae0555ffa90c568af9ca098db13f034
## Tooltip template

Any HTML elements can be displayed within the tooltip by using the [Template](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartTooltipSettings.html#Syncfusion_Blazor_Charts_ChartTooltipSettings_Template) property of the [ChartTooltipSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartTooltipSettings.html). You can use the **data.X** and **data.Y** as place holders in the HTML element to display x and y values of the corresponding data point.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart Title="Unemployment Rates 1975-2010">
    <ChartSeriesCollection>
        <ChartSeries DataSource="StepChartValues" Type="ChartSeriesType.StepLine" XName="Year" YName="YValue" Name="China">
            <ChartMarker Visible="true" Width="10" Height="10">
            </ChartMarker>
        </ChartSeries>
    </ChartSeriesCollection>
    <ChartTooltipSettings Enable="true">
        <Template>
            @{
<<<<<<< HEAD
                var data = context as ChartTooltipInfo;
                <div>
                    <table style="width:100%; border: 1px solid black;">
                        <tr><th colspan="2" bgcolor="#00FFFF">Unemployment</th></tr>
                        <tr><td bgcolor="#00FFFF">@data.X:</td><td bgcolor="#00FFFF">@data.Y</td></tr>
                    </table>
                </div>
            }
=======
                    var data = context as ChartTooltipInfo;
                    <div>                       
                        <table style="width:100%;  border: 1px solid black;">
                            <tr><th colspan="2" bgcolor="#00FFFF">Unemployment</th></tr>
                            <tr><td bgcolor="#00FFFF">@data.X:</td><td bgcolor="#00FFFF">@data.Y</td></tr>
                        </table>
                    </div>
                }         
>>>>>>> 655e5219cae0555ffa90c568af9ca098db13f034
        </Template>
    </ChartTooltipSettings>
</SfChart>

<<<<<<< HEAD
@code {
=======
@code{
>>>>>>> 655e5219cae0555ffa90c568af9ca098db13f034
    public List<StepChartData> StepChartValues = new List<StepChartData>
    {
        new StepChartData { Year = "1975", YValue = 16 },
        new StepChartData { Year = "1980", YValue = 12.5 },
        new StepChartData { Year = "1985", YValue = 19 },
        new StepChartData { Year = "1990", YValue = 14.4 },
        new StepChartData { Year = "1995", YValue = 11.5 },
        new StepChartData { Year = "2000", YValue = 14 },
        new StepChartData { Year = "2005", YValue = 10 },
        new StepChartData { Year = "2010", YValue = 16 }
    };

    public class StepChartData
    {
        public string Year { get; set; }
        public double YValue { get; set; }
    }
}

```

![Blazor StepLine Chart with Tooltip Template](images/tooltip/blazor-step-chart-tooltip-template.webp)

<<<<<<< HEAD
## Shared tooltip template

The [Template](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartTooltipSettings.html#Syncfusion_Blazor_Charts_ChartTooltipSettings_Template) property of the [ChartTooltipSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartTooltipSettings.html) accepts an HTML fragment that is rendered for each data point. When the [Shared](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartTooltipSettings.html#Syncfusion_Blazor_Charts_ChartTooltipSettings_Shared) property is enabled, the template context is a `List<ChartTooltipInfo>` containing one entry per visible series at the hovered x-value, letting you render a single tooltip that shows values for every series at once.
=======
## Shared Tooltip template

Any HTML elements can be displayed within the tooltip by using the [Template](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartTooltipSettings.html#Syncfusion_Blazor_Charts_ChartTooltipSettings_Template) property of the [ChartTooltipSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartTooltipSettings.html). You can use the **data.X** and **data.Y** as place holders in the HTML element to display x and y values of the corresponding data point. To show the tooltip for more than one series, enable the [Shared](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartTooltipSettings.html#Syncfusion_Blazor_Charts_ChartTooltipSettings_Shared) property in [ChartTooltipSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartTooltipSettings.html)
>>>>>>> 655e5219cae0555ffa90c568af9ca098db13f034

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartArea><ChartAreaBorder Width="0"></ChartAreaBorder></ChartArea>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.DateTime" LabelFormat="yyyy" IntervalType="IntervalType.Years" EdgeLabelPlacement="EdgeLabelPlacement.Shift">
        <ChartAxisMajorGridLines Width="0"></ChartAxisMajorGridLines>
    </ChartPrimaryXAxis>
    <ChartPrimaryYAxis LabelFormat="{value}%" RangePadding="ChartRangePadding.None" Minimum="0" Maximum="100" Interval="20">
        <ChartAxisLineStyle Width="0"></ChartAxisLineStyle>
        <ChartAxisMajorTickLines Width="0"></ChartAxisMajorTickLines>
    </ChartPrimaryYAxis>
    <ChartTooltipSettings Enable="true" Shared="true">
        <Template>
            @{
                var data = context as List<ChartTooltipInfo>;
                <div>
<<<<<<< HEAD
                    <table style="width:100%; border: 1px solid black;">
=======
                    <table style="width:100%;  border: 1px solid black;" class="table-borderless">
>>>>>>> 655e5219cae0555ffa90c568af9ca098db13f034
                        <tr>
                            <th colspan="2" bgcolor="#00FFFF">@data[0].X</th>
                        </tr>
                        <tr>
                            <td bgcolor="#00FFFF">Germany</td>
                            <td bgcolor="#00FFFF">@data[0].Y</td>
                        </tr>
                        <tr>
                            <td bgcolor="#00FFFF">England</td>
                            <td bgcolor="#00FFFF">@data[1].Y</td>
                        </tr>
                    </table>
                </div>
            }
        </Template>
    </ChartTooltipSettings>
    <ChartCrosshairSettings Enable="true" LineType="LineType.Vertical"></ChartCrosshairSettings>
    <ChartSeriesCollection>
        <ChartSeries DataSource="@ChartData" Name="Germany" XName="Period" Width="2"
                     Opacity="1" YName="ENG_InflationRate" Type="ChartSeriesType.Line">
            <ChartMarker Visible="true" Width="10" Height="10">
            </ChartMarker>
        </ChartSeries>
        <ChartSeries DataSource="@ChartData" Name="England" XName="Period" Width="2"
                     Opacity="1" YName="GER_InflationRate" Type="ChartSeriesType.Line">
            <ChartMarker Visible="true" Width="10" Height="10">
            </ChartMarker>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    public List<LineChartData> ChartData = new List<LineChartData>
    {
        new LineChartData { Period = new DateTime(2005, 01, 01), ENG_InflationRate = 21, GER_InflationRate = 28 },
        new LineChartData { Period = new DateTime(2006, 01, 01), ENG_InflationRate = 24, GER_InflationRate = 44 },
        new LineChartData { Period = new DateTime(2007, 01, 01), ENG_InflationRate = 36, GER_InflationRate = 48 },
        new LineChartData { Period = new DateTime(2008, 01, 01), ENG_InflationRate = 38, GER_InflationRate = 50 },
        new LineChartData { Period = new DateTime(2009, 01, 01), ENG_InflationRate = 54, GER_InflationRate = 66 },
        new LineChartData { Period = new DateTime(2010, 01, 01), ENG_InflationRate = 57, GER_InflationRate = 78 },
        new LineChartData { Period = new DateTime(2011, 01, 01), ENG_InflationRate = 70, GER_InflationRate = 84 }
    };
    public class LineChartData
    {
        public DateTime Period { get; set; }
        public double ENG_InflationRate { get; set; }
        public double GER_InflationRate { get; set; }
    }
}

```

<<<<<<< HEAD
![Blazor Line Chart with Shared Tooltip Template](images/tooltip/blazor-shared-tooltip-template.webp)

## Tooltip customization

The [Fill](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartTooltipSettings.html#Syncfusion_Blazor_Charts_ChartTooltipSettings_Fill) and [Border](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartTooltipSettings.html#Syncfusion_Blazor_Charts_ChartTooltipSettings_Border) properties customize the background color and border of the tooltip. The [ChartTooltipTextStyle](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartTooltipTextStyle.html) child element customizes the tooltip text (font color, size, and weight). The [HighlightColor](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfChart.html#Syncfusion_Blazor_Charts_SfChart_HighlightColor) property of `SfChart` customizes the point color while the tooltip is being hovered.
=======
![Blazor StepLine Chart with Tooltip Template](images/tooltip/blazor-shared-tooltip-template.webp)

## Tooltip customization

The [Fill](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartTooltipSettings.html#Syncfusion_Blazor_Charts_ChartTooltipSettings_Fill) and [Border](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartTooltipSettings.html#Syncfusion_Blazor_Charts_ChartTooltipSettings_Border) properties are used to customize the background color and the border of the tooltip respectively. The [ChartTooltipTextStyle](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartTooltipTextStyle.html) is used to customize the tooltip text. The [HighlightColor](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfChart.html#Syncfusion_Blazor_Charts_SfChart_HighlightColor) property is used to customize the point color while hovering for tooltip.
>>>>>>> 655e5219cae0555ffa90c568af9ca098db13f034

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart Title="Product Sales" HighlightColor="red">
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />

<<<<<<< HEAD
    <ChartPrimaryYAxis LabelFormat="{value}M"></ChartPrimaryYAxis>

    <ChartTooltipSettings Enable="true" Fill="gray">
        <ChartTooltipBorder Color="#FF0000" Width="2"></ChartTooltipBorder>
        <ChartTooltipTextStyle Color="white" Size="12px" FontWeight="Bold"></ChartTooltipTextStyle>
    </ChartTooltipSettings>

    <ChartSeriesCollection>
        <ChartSeries DataSource="@SalesReports" Name="Sales" XName="X" YName="Y" Type="ChartSeriesType.Column">
=======
    <ChartPrimaryYAxis LabelFormat="{value}M" >

    </ChartPrimaryYAxis>

    <ChartTooltipSettings Enable="true" Fill="gray">
        <ChartTooltipBorder Color="#FF0000"  Width="2"></ChartTooltipBorder>
    </ChartTooltipSettings>

    <ChartSeriesCollection>
        <ChartSeries DataSource="@SalesReports" XName="X" YName="Y" Type="ChartSeriesType.Column">
>>>>>>> 655e5219cae0555ffa90c568af9ca098db13f034
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

<<<<<<< HEAD
@code {
    public class ColumnSalesCustomData
=======
@code{
    public class Data
>>>>>>> 655e5219cae0555ffa90c568af9ca098db13f034
    {
        public string X { get; set; }
        public double Y { get; set; }
        public string Text { get; set; }
    }

<<<<<<< HEAD
    public List<ColumnSalesCustomData> SalesReports = new List<ColumnSalesCustomData>
    {
       new ColumnSalesCustomData { X = "Jan", Y = 3 },
       new ColumnSalesCustomData { X = "Feb", Y = 3.5 },
       new ColumnSalesCustomData { X = "Mar", Y = 7 },
       new ColumnSalesCustomData { X = "Apr", Y = 13.5 }
=======
    public List<Data> SalesReports = new List<Data>
	{
       new Data{ X= "Jan", Y= 3, Text= "January" },
       new Data{ X= "Feb", Y= 3.5, Text= "February" },
       new Data{ X= "Mar", Y= 7, Text= "March" },
       new Data{ X= "Apr", Y= 13.5, Text= "April" }
>>>>>>> 655e5219cae0555ffa90c568af9ca098db13f034
    };
}

```

![Blazor Column Chart with Custom Tooltip](images/tooltip/blazor-column-chart-custom-tooltip.webp)

<<<<<<< HEAD
## Enable highlight for series with tooltip

By enabling the [EnableHighlight](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartTooltipSettings.html#Syncfusion_Blazor_Charts_ChartTooltipSettings_EnableHighlight) property, all points in the hovered series are highlighted while points in other series are dimmed. This makes it easier to focus on the selected series when multiple series are plotted together.
=======
## Enabling highlight for series with tooltip

By enabling the [EnableHighlight](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartTooltipSettings.html#Syncfusion_Blazor_Charts_ChartTooltipSettings_EnableHighlight) property in [ChartTooltipSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartTooltipSettings.html), all points in the hovered series will be highlighted, while points in other series are dimmed. This feature enhances focus and clarity by drawing attention to the selected series.
>>>>>>> 655e5219cae0555ffa90c568af9ca098db13f034

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart Title="Unemployment Rates 1975-2010">
<<<<<<< HEAD
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category"></ChartPrimaryXAxis>
=======
>>>>>>> 655e5219cae0555ffa90c568af9ca098db13f034
    <ChartSeriesCollection>
        <ChartSeries DataSource="StepChartValues" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StepLine" XName="Year" YName="Y" Name="China">
            <ChartMarker Visible="true" Width="10" Height="10">
            </ChartMarker>
        </ChartSeries>
        <ChartSeries DataSource="StepChartValues" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StepLine" XName="Year" YName="Y1" Name="Australia">
            <ChartMarker Visible="true" Width="10" Height="10">
            </ChartMarker>
        </ChartSeries>
        <ChartSeries DataSource="StepChartValues" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StepLine" XName="Year" YName="Y2" Name="Japan">
            <ChartMarker Visible="true" Width="10" Height="10">
            </ChartMarker>
        </ChartSeries>
    </ChartSeriesCollection>
    <ChartTooltipSettings Enable="true" EnableHighlight="true">
    </ChartTooltipSettings>
</SfChart>

@code {
    public List<StepChartData> StepChartValues = new List<StepChartData>
    {
        new StepChartData { Year = "1975", Y = 16, Y1 = 10, Y2 = 4.5 },
        new StepChartData { Year = "1980", Y = 12.5, Y1 = 7.5, Y2 = 5},
        new StepChartData { Year = "1985", Y = 19, Y1 = 11, Y2 = 6.5 },
        new StepChartData { Year = "1990", Y = 14.4, Y1 = 7, Y2 = 4.4 },
        new StepChartData { Year = "1995", Y = 11.5, Y1 = 8, Y2 = 5 },
        new StepChartData { Year = "2000", Y = 14, Y1 = 6, Y2 = 1.5 },
        new StepChartData { Year = "2005", Y = 10, Y1 = 3.5, Y2 = 2.5 },
        new StepChartData { Year = "2010", Y = 16, Y1 = 7, Y2 = 3.7 }
    };

    public class StepChartData
    {
        public string Year { get; set; }
        public double Y { get; set; }
        public double Y1 { get; set; }
        public double Y2 { get; set; }
    }
}

```

<<<<<<< HEAD
{% previewsample "https://blazorplayground.syncfusion.com/embed/LjVnjbMOAjeZttkM?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Blazor Chart with tooltip series highlight](images/tooltip/blazor-tooltip-enable-highlight.webp)" %}

## Display tooltip for nearest data point

The [ShowNearestTooltip](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartTooltipSettings.html#Syncfusion_Blazor_Charts_ChartTooltipSettings_ShowNearestTooltip) property of [ChartTooltipSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartTooltipSettings.html) displays the tooltip for the data point nearest to the cursor. It automatically identifies the closest point within a defined interaction zone, which is useful when points are densely packed or overlap.

N> By default, the [ShowNearestTooltip](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_ShowNearestTooltip) property of [ChartSeries](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html) is set to **false** for all series. Enable it on a specific `ChartSeries` to opt that series in to the nearest-point behavior while leaving the others on the chart-wide default.
=======
{% previewsample "https://blazorplayground.syncfusion.com/embed/VZBRNniBJeIZMugw?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Blazor Chart tooltip with highlight series](images/tooltip/blazor-tooltip-enable-highlight.webp)" %}

## Displaying tooltip for nearest data point

The [ShowNearestTooltip](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartTooltipSettings.html#Syncfusion_Blazor_Charts_ChartTooltipSettings_ShowNearestTooltip) property in the [ChartTooltipSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartTooltipSettings.html) displays tooltip for the data point nearest to the cursor. It automatically identifies and highlights the closest point within a defined interaction zone, enhancing usability and accessibility, especially when dealing with densely packed or overlapping data points.

N> By default, `ShowNearestTooltip` property in [ChartSeries](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html) is set to **false** for all series. When this property is enabled for a specific `ChartSeries`, the tooltip is displayed for the nearest data point in that series.
>>>>>>> 655e5219cae0555ffa90c568af9ca098db13f034

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart Title="Unemployment Rates 1975-2010">
<<<<<<< HEAD
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category"></ChartPrimaryXAxis>
    <ChartSeriesCollection>
        <ChartSeries DataSource="StepChartValues" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StepLine" XName="Year" YName="Y" Name="China" ShowNearestTooltip="true">
            <ChartMarker Visible="true" Width="10" Height="10">
            </ChartMarker>
        </ChartSeries>
        <ChartSeries DataSource="StepChartValues" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StepLine" XName="Year" YName="Y1" Name="Australia">
=======
    <ChartSeriesCollection>
        <ChartSeries DataSource="StepChartValues" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StepLine" XName="Year" YName="Y" Name="China">
            <ChartMarker Visible="true" Width="10" Height="10">
            </ChartMarker>
        </ChartSeries>
        <ChartSeries DataSource="StepChartValues" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StepLine" XName="Year" YName="Y1" Name="Australia" ShowNearestTooltip="false">
>>>>>>> 655e5219cae0555ffa90c568af9ca098db13f034
            <ChartMarker Visible="true" Width="10" Height="10">
            </ChartMarker>
        </ChartSeries>
        <ChartSeries DataSource="StepChartValues" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StepLine" XName="Year" YName="Y2" Name="Japan">
            <ChartMarker Visible="true" Width="10" Height="10">
            </ChartMarker>
        </ChartSeries>
    </ChartSeriesCollection>
    <ChartTooltipSettings Enable="true" ShowNearestTooltip="true">
    </ChartTooltipSettings>
</SfChart>

@code {
    public List<StepChartData> StepChartValues = new List<StepChartData>
    {
        new StepChartData { Year = "1975", Y = 16, Y1 = 10, Y2 = 4.5 },
        new StepChartData { Year = "1980", Y = 12.5, Y1 = 7.5, Y2 = 5},
        new StepChartData { Year = "1985", Y = 19, Y1 = 11, Y2 = 6.5 },
        new StepChartData { Year = "1990", Y = 14.4, Y1 = 7, Y2 = 4.4 },
        new StepChartData { Year = "1995", Y = 11.5, Y1 = 8, Y2 = 5 },
        new StepChartData { Year = "2000", Y = 14, Y1 = 6, Y2 = 1.5 },
        new StepChartData { Year = "2005", Y = 10, Y1 = 3.5, Y2 = 2.5 },
        new StepChartData { Year = "2010", Y = 16, Y1 = 7, Y2 = 3.7 }
    };

    public class StepChartData
    {
        public string Year { get; set; }
        public double Y { get; set; }
        public double Y1 { get; set; }
        public double Y2 { get; set; }
    }
}

```

<<<<<<< HEAD
{% previewsample "https://blazorplayground.syncfusion.com/embed/LNBRjPCYUNGWUbhL?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Blazor Chart showing tooltip for nearest data point](images/tooltip/blazor-chart-nearest-tooltip.webp)" %}

N> For more chart-type options and live examples, see the [Blazor Charts demo](https://blazor.syncfusion.com/demos/chart/line?theme=fluent2). For getting started with the project setup, refer to the [Getting Started](./getting-started) guide.
=======
{% previewsample "https://blazorplayground.syncfusion.com/embed/rjBRNxMrTSSSftnE?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Blazor Chart shows nearest tooltip](images/tooltip/blazor-chart-nearest-tooltip.webp)" %}

N> Refer to the [Blazor Charts](https://www.syncfusion.com/blazor-components/blazor-charts) feature tour page for its groundbreaking feature representations and also explore the [Blazor Chart Example](https://blazor.syncfusion.com/demos/chart/line?theme=fluent2) to know various chart types and how to represent time-dependent data, showing trends at equal intervals.
>>>>>>> 655e5219cae0555ffa90c568af9ca098db13f034

## See also

* [Data label](./data-labels)
<<<<<<< HEAD
* [Marker](./data-markers)
* [Crosshair and trackball](./cross-hair-and-track-ball)
* [Selection](./selection)
* [Legend](./legend)
=======
* [Marker](./data-markers)
>>>>>>> 655e5219cae0555ffa90c568af9ca098db13f034
