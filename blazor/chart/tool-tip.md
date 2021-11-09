---
layout: post
title: Tooltip in Blazor Charts Component | Syncfusion
description: Checkout and learn here all about Tooltip and its customization in Syncfusion Blazor Charts component and much more.
platform: Blazor
control: Chart
documentation: ug
---

# Tooltip in Blazor Charts Component

<!-- markdownlint-disable MD036 -->

When the mouse is moved over a point on the chart, the tooltip will provide information about that point.

## Enable Tooltip

When space constraints prevent displaying information using data labels, the tooltip comes in useful. The [Enable](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartTooltipSettings.html#Syncfusion_Blazor_Charts_ChartTooltipSettings_Enable) property in [ChartTooltipSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartTooltipSettings.html) can be set to **true** to enable the tooltip.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart Title="Product Sales">
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />

    <ChartPrimaryYAxis LabelFormat="{value}M"  >
        
    </ChartPrimaryYAxis>

    <ChartTooltipSettings Enable="true"></ChartTooltipSettings>

    <ChartSeriesCollection>
        <ChartSeries DataSource="@SalesReports" Name="Text" XName="X" YName="Y" Type="ChartSeriesType.Column"> 
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

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
    };
}

```

![Blazor Column Chart with Tooltip](images/tooltip/blazor-column-chart-tooltip.png)

## Tooltip Format

<!-- markdownlint-disable MD013 -->

By default, the tooltip displays information in points for the x and y values. In addition, further information can be displayed in the tooltip. For example, the format **$series.name $point.x** displays series name and point x-value in the tooltip.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart Title="Product Sales">
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />

    <ChartPrimaryYAxis LabelFormat="{value}M"></ChartPrimaryYAxis>

    <ChartTooltipSettings Enable="true" Header="Sales" Format="<b>${series.name} : ${point.y}</b>"></ChartTooltipSettings>

    <ChartSeriesCollection>
        <ChartSeries DataSource="@SalesReports" XName="X" YName="Y" Type="ChartSeriesType.Column">
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

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
    };
}

```

![Blazor Column Chart with Tooltip Format](images/tooltip/blazor-column-chart-tooltip-format.png)

<!-- markdownlint-disable MD013 -->

## Tooltip Customization 

The [Fill](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartTooltipSettings.html#Syncfusion_Blazor_Charts_ChartTooltipSettings_Fill) and [Border](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartTooltipSettings.html#Syncfusion_Blazor_Charts_ChartTooltipSettings_Border) properties are used to customize the background color and the border of the tooltip respectively. The [ChartTooltipTextStyle](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartTooltipTextStyle.html) is used to customize the tooltip text.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart Title="Product Sales">
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />

    <ChartPrimaryYAxis LabelFormat="{value}M" >

    </ChartPrimaryYAxis>

    <ChartTooltipSettings Enable="true" Fill="gray">
        <ChartTooltipBorder Color="#FF0000"  Width="2"></ChartTooltipBorder>
    </ChartTooltipSettings>

    <ChartSeriesCollection>
        <ChartSeries DataSource="@SalesReports" XName="X" YName="Y" Type="ChartSeriesType.Column">
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

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
    };
}

```

![Blazor Column Chart with Custom Tooltip](images/tooltip/blazor-column-chart-custom-tooltip.png)

> Refer to our [Blazor Charts](https://www.syncfusion.com/blazor-components/blazor-charts) feature tour page for its groundbreaking feature representations and also explore our [Blazor Chart Example](https://blazor.syncfusion.com/demos/chart/line?theme=bootstrap4) to know various chart types and how to represent time-dependent data, showing trends at equal intervals.

## See Also

* [Data label](./data-labels)
* [Marker](./data-markers)