---
layout: post
title: Data Labels in Blazor Charts Component | Syncfusion
description: Check out and learn how to configure and customize Data Labels in Syncfusion Blazor Charts component.
platform: Blazor
control: Chart
documentation: ug
---

# Data Labels in Blazor Charts Component

[Data labels](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartDataLabel.html) can be added to a [ChartSeries](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html) by enabling the [Visible](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartDataLabel.html#Syncfusion_Blazor_Charts_ChartDataLabel_Visible) option in the data label settings. Labels automatically organize themselves to avoid overlap.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />

    <ChartSeriesCollection>
        <ChartSeries DataSource="@WeatherReports" XName="X" YName="Y" Type="ChartSeriesType.Column">
            <ChartMarker>
                <ChartDataLabel Visible="true"/>
            </ChartMarker>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    public class Data
    {
        public string X { get; set; }
        public double Y { get; set; }
    }
	
    public List<Data> WeatherReports = new List<Data>
	{
        new Data { X = "Jan", Y = 3 },
        new Data { X = "Feb", Y = 3.5 },
        new Data { X = "Mar", Y = 7 },
        new Data { X = "Apr", Y = 13.5 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BNVIZYrIfXsIMOJL?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor Chart with Data Label](images/data-label/blazor-chart-data-label.png)

## Position

Set the label position using the [Position](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartDataLabel.html#Syncfusion_Blazor_Charts_ChartDataLabel_Position) property: [Top](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.LabelPosition.html#Syncfusion_Blazor_Charts_LabelPosition_Top), [Middle](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.LabelPosition.html#Syncfusion_Blazor_Charts_LabelPosition_Middle), [Bottom](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.LabelPosition.html#Syncfusion_Blazor_Charts_LabelPosition_Bottom), or [Outer](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.LabelPosition.html#Syncfusion_Blazor_Charts_LabelPosition_Outer). The `Outer` position applies only to column and bar series.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />

    <ChartSeriesCollection>
        <ChartSeries DataSource="@WeatherReports" XName="X" YName="Y" Type="ChartSeriesType.Column">
            <ChartMarker>
                <ChartDataLabel Visible="true" Position="Syncfusion.Blazor.Charts.LabelPosition.Middle" />
            </ChartMarker>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code{
    public class Data
    {
        public string X { get; set; }
        public double Y { get; set; }
    }
	
    public List<Data> WeatherReports = new List<Data>
    {
        new Data { X = "Jan", Y = 3 },
        new Data { X = "Feb", Y = 3.5 },
        new Data { X = "Mar", Y = 7 },
        new Data { X = "Apr", Y = 13.5 }
    };
}

```

![Changing Label Position in Blazor Chart](images/data-label/blazor-chart-label-position.png)

N> The position `Outer` is applicable only for column and bar series.

## Template

Format label content using the [Template](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartDataLabel.html#Syncfusion_Blazor_Charts_ChartDataLabel_Template) option. Use placeholders like **${point.x}** and **${point.y}** to display data point values.

## Text mapping

Map text from a datasource to a data label using the [Name](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartDataLabel.html#Syncfusion_Blazor_Charts_ChartDataLabel_Name) property.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />

    <ChartSeriesCollection>
        <ChartSeries DataSource="@WeatherReports" XName="X" YName="Y" Type="ChartSeriesType.Column">
            <ChartMarker>
                <ChartDataLabel Visible="true" Name="Text"></ChartDataLabel>
            </ChartMarker>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    public class Data
    {
        public string X { get; set; }
        public double Y { get; set; }
        public string Text { get; set; }
    }

    public List<Data> WeatherReports = new List<Data> 
	{
	   new Data { X = "Jan", Y = 3, Text = "January" },
	   new Data { X = "Feb", Y = 3.5, Text = "February" },
	   new Data { X = "Mar", Y = 7, Text = "March" },
	   new Data { X = "Apr", Y = 13.5, Text = "April" }
	};
}

```

![Blazor Chart Label with Text Mapping](images/data-label/blazor-chart-label-with-text-mapping.png)

## Format

Format data labels using the [Format](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartDataLabel.html#Syncfusion_Blazor_Charts_ChartDataLabel_Format) property. Supported formats include 'N1', 'P1', and 'C1'.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category />
    
    <ChartSeriesCollection>
        <ChartSeries DataSource="@WeatherReports" XName="X" YName="Y" Type="ChartSeriesType.Line" >
            <ChartMarker>
                <ChartDataLabel Visible="true" Format="N1" />
            </ChartMarker>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    public class Data
    {
        public string X { get; set; }
        public double Y { get; set; }
        public string Text { get; set; }
    }

    public List<Data> WeatherReports = new List<Data>
    {
        new Data { X = "Jan", Y = 3, Text = "January" },
        new Data { X = "Feb", Y = 3.5, Text = "February" },
        new Data { X = "Mar", Y = 7, Text = "March" },
        new Data { X = "Apr", Y = 13.5, Text = "April" }
    };
}

```

![Blazor Chart Label with Format](images/data-label/blazor-chart-label-with-format.png)

## Margin

Apply [Margin](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartDataLabel.html#Syncfusion_Blazor_Charts_ChartDataLabel_Margin) to create space around the data label.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />

    <ChartSeriesCollection>
        <ChartSeries DataSource="@WeatherReports" XName="X" YName="Y" Type="ChartSeriesType.Column">
            <ChartMarker>
                <ChartDataLabel Visible="true" Name="Text">
                    <ChartDataLabelBorder Width="2" Color="red"/>
                    <ChartDataLabelMargin Left="15" Right="15" Top="15" Bottom="15"/>
                </ChartDataLabel>
            </ChartMarker>
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

    public List<Data> WeatherReports = new List<Data> 
	{
	   new Data{ X= "Jan", Y= 3, Text= "January" },
	   new Data{ X= "Feb", Y= 3.5, Text= "February" },
	   new Data{ X= "Mar", Y= 7, Text= "March" },
	   new Data{ X= "Apr", Y= 13.5, Text= "April" }
	};
}

```

![Blazor Chart Label with Margin](images/data-label/blazor-chart-label-with-margin.png)

## Customization

Customize data label color using the [Fill](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartDataLabel.html#Syncfusion_Blazor_Charts_ChartDataLabel_Fill) property. Adjust border color and width with [ChartDataLabelBorder](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartDataLabelBorder.html). Apply rounded corners using [Rx](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartDataLabel.html#Syncfusion_Blazor_Charts_ChartDataLabel_Rx) and [Ry](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartDataLabel.html#Syncfusion_Blazor_Charts_ChartDataLabel_Ry).

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />   

    <ChartSeriesCollection>
        <ChartSeries DataSource="@WeatherReports" XName="X" YName="Y" >
            <ChartMarker>
                <ChartDataLabel Visible="true" Name="Text" Rx="10" Ry="10">
                    <ChartDataLabelBorder Width="2" Color="red"></ChartDataLabelBorder>
                </ChartDataLabel>
            </ChartMarker>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    public class Data
    {
        public string X { get; set; }
        public double Y { get; set; }
        public string Text { get; set; }
    }

    public List<Data> WeatherReports = new List<Data> 
	{
	   new Data { X = "Jan", Y = 3, Text = "January" },
	   new Data { X = "Feb", Y = 3.5, Text = "February" },
	   new Data { X = "Mar", Y = 7, Text = "March" },
	   new Data { X = "Apr", Y = 13.5, Text = "April" }
	};
}

```

![Blazor Chart with Custom Label](images/data-label/blazor-chart-custom-label.png)

N> Refer to our [Blazor Charts](https://www.syncfusion.com/blazor-components/blazor-charts) feature tour page for its groundbreaking feature representations and also explore our [Blazor Chart Example](https://blazor.syncfusion.com/demos/chart/line?theme=bootstrap5) to know various chart types and how to represent time-dependent data, showing trends at equal intervals.

## See also

* [Tooltip](./tool-tip)
* [Legend](./legend)
