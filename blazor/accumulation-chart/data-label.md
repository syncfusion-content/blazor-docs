---
layout: post
title: Data Label in Blazor Accumulation Chart Component | Syncfusion
description: Check out and learn how to configure and customize Data Labels in Syncfusion Blazor Accumulation Chart component.
platform: Blazor
control: Accumulation Chart
documentation: ug
---

# Data Label in Blazor Accumulation Chart Component

The [Visible](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationDataLabelSettings.html#Syncfusion_Blazor_Charts_AccumulationDataLabelSettings_Visible) property in [AccumulationDataLabelSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationDataLabelSettings.html) adds a data label to a series point.

```cshtml

@using Syncfusion.Blazor.Charts

<SfAccumulationChart Title="Mobile Browser Statistics" EnableSmartLabels="true">
    <AccumulationChartLegendSettings Visible="false"></AccumulationChartLegendSettings>

    <AccumulationChartSeriesCollection>
        <AccumulationChartSeries DataSource="@StatisticsDetails" XName="Browser" YName="Users" Name="Browser">
            <AccumulationDataLabelSettings Visible="true" Name="Browser"></AccumulationDataLabelSettings>
        </AccumulationChartSeries>
    </AccumulationChartSeriesCollection>
</SfAccumulationChart>

@code {
    public class Statistics
    {
        public string Browser { get; set;}
        public double Users { get; set; }
        public string Text { get; set; }
        public string Fill { get; set; }
    }

    public List<Statistics> StatisticsDetails = new List<Statistics>
	{
        new Statistics { Browser = "Chrome", Users = 37, Text = "37%", Fill = "#498fff" },
        new Statistics { Browser = "UC Browser", Users = 17, Text = "17%", Fill = "#ffa060" },
        new Statistics { Browser = "iPhone", Users = 19, Text = "19%", Fill = "#ff68b6" },
        new Statistics { Browser = "Others", Users = 4 , Text = "4%", Fill = "#81e2a1" }
    };
}

```

![Blazor Accumulation Chart with Data Label](images/data-label/blazor-accumulation-chart-with-data-label.png)
{% previewsample "https://blazorplayground.syncfusion.com/embed/BtBUCrWAJzilTTrb?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Text Wrap

Wrap data label text using [TextWrap](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationDataLabelSettings.html#Syncfusion_Blazor_Charts_AccumulationDataLabelSettings_TextWrap) and [MaxWidth](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationDataLabelSettings.html#Syncfusion_Blazor_Charts_AccumulationDataLabelSettings_MaxWidth).

```cshtml

@using Syncfusion.Blazor.Charts

<SfAccumulationChart Title="Mobile Browser Statics">
        <AccumulationChartLegendSettings Visible="false"></AccumulationChartLegendSettings>

<AccumulationChartSeriesCollection>
    <AccumulationChartSeries DataSource="@PieChartPoints" XName="Browser" YName="Users" Name="Browser">
        <AccumulationDataLabelSettings EnableRotation="true" Visible="true" MaxWidth="100" TextWrap="TextWrap.Wrap" Name="DataLabelMappingName" Position="AccumulationLabelPosition.Inside">
            </AccumulationDataLabelSettings>
        </AccumulationChartSeries>
    </AccumulationChartSeriesCollection>
</SfAccumulationChart>

@code {
    public class PieData
    {
        public string Browser { get; set; }
        public double Users { get; set; }
        public string DataLabelMappingName { get; set; }
    }

    public List<PieData> PieChartPoints { get; set; } = new List<PieData>
    {
        new PieData { Browser = "Opera Mini", Users = 80, DataLabelMappingName = "Opera Mini (80M) 32%" },
        new PieData { Browser = "UC Browser", Users = 80, DataLabelMappingName = "UC Browser (80M) 32%" },
        new PieData { Browser = "Internet Explorer", Users = 90, DataLabelMappingName = "Chromium (90M) 36%" }
    };
}

```
![Text Wrap in Blazor Accumulation Chart](images/data-label/blazor-accumulation-chart-with-data-label-text-wrapping.png)
{% previewsample "https://blazorplayground.syncfusion.com/embed/hjVUCVCgTfRsrPGK?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Position

Set the data label position using the [Position](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationDataLabelSettings.html#Syncfusion_Blazor_Charts_AccumulationDataLabelSettings_Position) property.

```cshtml

@using Syncfusion.Blazor.Charts

<SfAccumulationChart Title="Mobile Browser Statistics">
    <AccumulationChartLegendSettings Visible="false"></AccumulationChartLegendSettings>

    <AccumulationChartSeriesCollection>
        <AccumulationChartSeries DataSource="@StatisticsDetails" XName="Browser" YName="Users" Name="Browser">
            <AccumulationDataLabelSettings Visible="true" Name="Browser" Position="AccumulationLabelPosition.Outside"></AccumulationDataLabelSettings>
        </AccumulationChartSeries>
    </AccumulationChartSeriesCollection>
</SfAccumulationChart>

@code {
    public class Statistics
    {
        public string Browser { get; set; }
        public double Users { get; set; }
        public string Text { get; set; }
        public string Fill { get; set; }
    }

    public List<Statistics> StatisticsDetails = new List<Statistics>
	{
        new Statistics { Browser = "Chrome", Users = 37, Text = "37%", Fill = "#498fff" },
        new Statistics { Browser = "UC Browser", Users = 17, Text = "17%", Fill = "#ffa060" },
        new Statistics { Browser = "iPhone", Users = 19, Text = "19%", Fill = "#ff68b6" },
        new Statistics { Browser = "Others", Users = 4 , Text = "4%", Fill = "#81e2a1" }
    };
}

```

![Changing Data Label Position in Blazor Accumulation Chart](images/data-label/blazor-accumulation-chart-label-position.png)
{% previewsample "https://blazorplayground.syncfusion.com/embed/VtLUMhsApTwpdpQa?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Smart Labels

Arrange data labels smartly without overlap using [EnableSmartLabels](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfAccumulationChart.html#Syncfusion_Blazor_Charts_SfAccumulationChart_EnableSmartLabels).

```cshtml

@using Syncfusion.Blazor.Charts

<SfAccumulationChart EnableSmartLabels="true">
    <AccumulationChartLegendSettings Visible="false"></AccumulationChartLegendSettings>

    <AccumulationChartSeriesCollection>
        <AccumulationChartSeries DataSource="@StatisticsDetails" XName="Country" YName="Users">
            <AccumulationDataLabelSettings Visible="true" Name="Country" Position="AccumulationLabelPosition.Outside">
                <AccumulationChartConnector Type="ConnectorType.Curve" Length="20px" />
            </AccumulationDataLabelSettings>
        </AccumulationChartSeries>
    </AccumulationChartSeriesCollection>
</SfAccumulationChart>

@code {
    public class Statistics
    {
        public string Country { get; set; }
        public double Users { get; set; }
    }
	
    public List<Statistics> StatisticsDetails = new List<Statistics>
    {
        new Statistics { Country = "China", Users = 1409517397 },
        new Statistics { Country = "India", Users = 1339180127 },
        new Statistics { Country = "United States", Users = 324459463 },
        new Statistics { Country = "Indonesia", Users = 263991379 },
        new Statistics { Country = "Brazil", Users = 209288278 },
        new Statistics { Country = "Pakistan", Users = 197015955 },
        new Statistics { Country = "Nigeria", Users = 190886311 },
        new Statistics { Country = "Bangladesh", Users = 164669751 },
        new Statistics { Country = "Russia", Users = 143989754 },
        new Statistics { Country = "Mexico", Users = 129163276 },
        new Statistics { Country = "Japan", Users = 127484450 },
        new Statistics { Country = "Ethiopia", Users = 104957438 },
        new Statistics { Country = "Philippines", Users = 104918090 },
        new Statistics { Country = "Egypt", Users = 97553151 },
        new Statistics { Country = "Vietnam", Users = 95540800 },
        new Statistics { Country = "Germany", Users = 82114224 }
    };
}

```

![Blazor Accumulation Chart with Smart Labels](images/data-label/blazor-accumulation-chart-smart-labels.png)
{% previewsample "https://blazorplayground.syncfusion.com/embed/VthqCrMgfzFDgIcO?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Connector line

Customize connector lines for outside labels using [Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartConnector.html#Syncfusion_Blazor_Charts_AccumulationChartConnector_Type), [Color](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartConnector.html#Syncfusion_Blazor_Charts_AccumulationChartConnector_Color), [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartConnector.html#Syncfusion_Blazor_Charts_AccumulationChartConnector_Width), [Length](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartConnector.html#Syncfusion_Blazor_Charts_AccumulationChartConnector_Length), and [DashArray](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartConnector.html#Syncfusion_Blazor_Charts_AccumulationChartConnector_DashArray).

```cshtml

@using Syncfusion.Blazor.Charts

<SfAccumulationChart Title="Mobile Browser Statistics" EnableSmartLabels="true">
    <AccumulationChartLegendSettings Visible="false"></AccumulationChartLegendSettings>

    <AccumulationChartSeriesCollection>
        <AccumulationChartSeries DataSource="@StatisticsDetails" XName="Browser" YName="Users" Name="Browser">
            <AccumulationDataLabelSettings Visible="true" Name="Text" Position="AccumulationLabelPosition.Outside">
                <AccumulationChartConnector Color="#f4429e" Length="50px" Width="2" Type="ConnectorType.Curve" DashArray="5,3"></AccumulationChartConnector>
            </AccumulationDataLabelSettings>
        </AccumulationChartSeries>
    </AccumulationChartSeriesCollection>
</SfAccumulationChart>

@code {
    public class Statistics
    {
        public string Browser { get; set; }
        public double Users { get; set; }
        public string Text { get; set; }
        public string Fill { get; set; }
    }

    public List<Statistics> StatisticsDetails = new List<Statistics>
	{
        new Statistics { Browser = "Chrome", Users = 37, Text = "37%", Fill = "#498fff" },
        new Statistics { Browser = "UC Browser", Users = 17, Text = "17%", Fill = "#ffa060" },
        new Statistics { Browser = "iPhone", Users = 19, Text = "19%", Fill = "#ff68b6" },
        new Statistics { Browser = "Others", Users = 4 , Text = "4%", Fill = "#81e2a1" }
    };
}

```

![Blazor Accumulation Chart with Connector Line](images/data-label/blazor-accumulation-chart-connector-line.png)
{% previewsample "https://blazorplayground.syncfusion.com/embed/rZLqWVsqzTYnAoVP?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Text mapping

Map text from the data source using the [Name](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationDataLabelSettings.html#Syncfusion_Blazor_Charts_AccumulationDataLabelSettings_Name) property.

```cshtml

@using Syncfusion.Blazor.Charts

<SfAccumulationChart Title="Mobile Browser Statistics" EnableSmartLabels="true">
    <AccumulationChartLegendSettings Visible="false"></AccumulationChartLegendSettings>

    <AccumulationChartSeriesCollection>
        <AccumulationChartSeries DataSource="@StatisticsDetails" XName="Browser" YName="Users" Name="Browser">
            <AccumulationDataLabelSettings Visible="true" Name="Text">
            </AccumulationDataLabelSettings>
        </AccumulationChartSeries>
    </AccumulationChartSeriesCollection>
</SfAccumulationChart>

@code {
    public class Statistics
    {
        public string Browser { get; set; }
        public double Users { get; set; }
        public string Text { get; set; }
        public string Fill { get; set; }
    }

    public List<Statistics> StatisticsDetails = new List<Statistics>
    {
        new Statistics { Browser = "Chrome", Users = 37, Text = "37%", Fill = "#498fff" },
        new Statistics { Browser = "UC Browser", Users = 17, Text = "17%", Fill = "#ffa060" },
        new Statistics { Browser = "iPhone", Users = 19, Text = "19%", Fill = "#ff68b6" },
        new Statistics { Browser = "Others", Users = 4 , Text = "4%", Fill = "#81e2a1" }
    };
}

```

![Text Mapping in Blazor Accumulation Chart](images/data-label/blazor-accumulation-chart-text-mapping.png)
{% previewsample "https://blazorplayground.syncfusion.com/embed/hjrUsrsApeCPdurG?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Format

Format data labels using the [Format](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationDataLabelSettings.html#Syncfusion_Blazor_Charts_AccumulationDataLabelSettings_Format) property. The global formatting options include 'N1', 'P1', and 'C1'.

```cshtml

@using Syncfusion.Blazor.Charts

<SfAccumulationChart Title="Product Sales" EnableAnimation="false">
    <AccumulationChartTooltipSettings Enable="true"></AccumulationChartTooltipSettings>

    <AccumulationChartLegendSettings Visible="false"></AccumulationChartLegendSettings>

    <AccumulationChartSeriesCollection>
        <AccumulationChartSeries DataSource="@ChartValues" XName="XValue" YName="YValue" Name="Browser" Radius="80%" StartAngle="0" EndAngle="360"InnerRadius="0%">
            <AccumulationDataLabelSettings Visible="true"  Format="C1" Position="AccumulationLabelPosition.Inside"></AccumulationDataLabelSettings>
        </AccumulationChartSeries>
    </AccumulationChartSeriesCollection>
</SfAccumulationChart>

@code {
    public class ChartData
    {
        public string XValue { get; set; }
        public double YValue { get; set; }
    }

    public List<ChartData> ChartValues = new List<ChartData>
    {
        new ChartData { XValue = "Apple", YValue = 26 },
        new ChartData { XValue = "Redmi", YValue = 19 },
        new ChartData { XValue = "Realme", YValue = 17 },
        new ChartData { XValue = "Oneplus", YValue = 12 },
        new ChartData { XValue = "Samsung", YValue = 15 }
    };
}

```

![Format in Blazor Accumulation Chart](images/data-label/blazor-accumulation-chart-with-data-label-format.png)
{% previewsample "https://blazorplayground.syncfusion.com/embed/VDhqMLsqzSLpcrER?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Template

Customize data labels using the [Template](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationDataLabelSettings.html#Syncfusion_Blazor_Charts_AccumulationDataLabelSettings_Template) property and HTML elements.

```cshtml

<AccumulationDataLabelSettings Visible="true" Name="Browser">
    <Template>
        @{
            var data = context as AccumulationChartDataPointInfo;
            <table>
                <tr><td align="center"> @data.X</td></tr>
            </table>
        }
    </Template>
</AccumulationDataLabelSettings>
  
```

```cshtml

@using Syncfusion.Blazor.Charts

<SfAccumulationChart Title="Mobile Browser Statistics">
    <AccumulationChartSeriesCollection>
        <AccumulationChartSeries DataSource="@StatisticsDetails" XName="Browser" YName="Users"
                                 Name="Browser" InnerRadius="40%">
            <AccumulationDataLabelSettings Position="AccumulationLabelPosition.Outside" Name="Browser" Visible="true">
                <Template>
                    @{
                        var data = context as AccumulationChartDataPointInfo;
                    }
                    <table>
                        <tr>
                            <td align="center" style="background-color: #C1272D; font-size: 14px; color: #E7C554; font-weight: bold; padding: 5px"> @data.X :</td>
                            <td align="center" style="background-color: #C1272D; font-size: 14px; color: whitesmoke; font-weight: bold; padding: 5px"> @data.Y</td>
                        </tr>
                    </table>
                </Template>
            </AccumulationDataLabelSettings>
        </AccumulationChartSeries>
    </AccumulationChartSeriesCollection>
    <AccumulationChartLegendSettings Visible="false"></AccumulationChartLegendSettings>
</SfAccumulationChart>

@code {
    public class Statistics
    {
        public string Browser { get; set; }
        public double Users { get; set; }
    }

    public List<Statistics> StatisticsDetails = new List<Statistics>
    {
        new Statistics { Browser = "Chrome", Users = 37 },
        new Statistics { Browser = "UC Browser", Users = 17 },
        new Statistics { Browser = "iPhone", Users = 19 },
        new Statistics { Browser = "Others", Users = 4  },
        new Statistics { Browser = "Opera", Users = 11 },
        new Statistics { Browser = "Android", Users = 12 }
    };
}

```

![Template in Blazor Accumulation Chart](images/data-label/blazor-accumulation-chart-with-data-label-template.png)
{% previewsample "https://blazorplayground.syncfusion.com/embed/BNLpZghnzXPGMCxq?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

N> Refer to the [Blazor Charts](https://www.syncfusion.com/blazor-components/blazor-charts) feature tour page for its groundbreaking feature representations and also explore the [Blazor Accumulation Chart Example](https://blazor.syncfusion.com/demos/chart/pie?theme=bootstrap5) to know various features of accumulation charts and how it is used to represent numeric proportional data.

## See also

* [Tooltip](./tool-tip)
* [Legend](./legend)
* [Dynamically Switch Themes](https://support.syncfusion.com/kb/article/21357/how-to-dynamically-switch-themes-in-a-blazor-accumulation-chart)