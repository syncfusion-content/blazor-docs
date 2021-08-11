---
layout: post
title: Data Label in Blazor Accumulation Chart Component | Syncfusion
description: Checkout and learn here all about Data Label in Syncfusion Blazor Accumulation Chart component and more.
platform: Blazor
control: Accumulation Chart
documentation: ug
---

# Data Label in Blazor Accumulation Chart Component

The [Visible](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationDataLabelSettings.html#Syncfusion_Blazor_Charts_AccumulationDataLabelSettings_Visible) property in the [AccumulationDataLabelSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationDataLabelSettings.html) can be used to add a data label to a series point.

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

@code{
    public class Statistics
    {
        public string Browser { get; set;}
        public double Users { get; set; }
        public string Text { get; set; }
        public string Fill { get; set; }

    }

    public List<Statistics> StatisticsDetails = new List<Statistics>
	{
        new Statistics { Browser = "Chrome", Users = 37, Text= "37%", Fill="#498fff"},
        new Statistics { Browser = "UC Browser", Users = 17, Text= "17%", Fill="#ffa060"},
        new Statistics { Browser = "iPhone", Users = 19, Text= "19%", Fill="#ff68b6"},
        new Statistics { Browser = "Others", Users = 4 , Text= "4%", Fill="#81e2a1"},
    };
}

```

![Blazor Accumulation Chart with Data Label](images/data-label/blazor-accumulation-chart-with-data-label.png)

## Position

The [Position](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationDataLabelSettings.html#Syncfusion_Blazor_Charts_AccumulationDataLabelSettings_Position) property in the [AccumulationDataLabelSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationDataLabelSettings.html) allows the data label to be placed either [Inside](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationLabelPosition.html#Syncfusion_Blazor_Charts_AccumulationLabelPosition_Inside) or [Outside](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationLabelPosition.html#Syncfusion_Blazor_Charts_AccumulationLabelPosition_Outside) of the chart.

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

@code{
    public class Statistics
    {
        public string Browser { get; set; }
        public double Users { get; set; }
        public string Text { get; set; }
        public string Fill { get; set; }

    }

    public List<Statistics> StatisticsDetails = new List<Statistics>
	{
        new Statistics { Browser = "Chrome", Users = 37, Text= "37%", Fill="#498fff"},
        new Statistics { Browser = "UC Browser", Users = 17, Text= "17%", Fill="#ffa060"},
        new Statistics { Browser = "iPhone", Users = 19, Text= "19%", Fill="#ff68b6"},
        new Statistics { Browser = "Others", Users = 4 , Text= "4%", Fill="#81e2a1"},
    };
}

```

![Changing Data Label Position in Blazor Accumulation Chart](images/data-label/blazor-accumulation-chart-label-position.png)

## Smart Labels

Data labels will be arranged smartly without overlapping with each other. The [EnableSmartLabels](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfAccumulationChart.html#Syncfusion_Blazor_Charts_SfAccumulationChart_EnableSmartLabels) property can be used to enable or disable this feature.

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

@code{
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
        new Statistics { Country = "Germany", Users = 82114224 },
    };
}

```

![Blazor Accumulation Chart with Smart Labels](images/data-label/blazor-accumulation-chart-smart-labels.png)

## Connector Line

When the data label is placed [Outside](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationLabelPosition.html#Syncfusion_Blazor_Charts_AccumulationLabelPosition_Outside) the chart, the connector line will be visible. The [Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartConnector.html#Syncfusion_Blazor_Charts_AccumulationChartConnector_Type), [Color](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartConnector.html#Syncfusion_Blazor_Charts_AccumulationChartConnector_Color), [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartConnector.html#Syncfusion_Blazor_Charts_AccumulationChartConnector_Width), [Length](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartConnector.html#Syncfusion_Blazor_Charts_AccumulationChartConnector_Length) and [DashArray](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartConnector.html#Syncfusion_Blazor_Charts_AccumulationChartConnector_DashArray) properties can be used to customize the connector line.

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

@code{
    public class Statistics
    {
        public string Browser { get; set; }
        public double Users { get; set; }
        public string Text { get; set; }
        public string Fill { get; set; }

    }

    public List<Statistics> StatisticsDetails = new List<Statistics>
	{
        new Statistics { Browser = "Chrome", Users = 37, Text= "37%", Fill="#498fff"},
        new Statistics { Browser = "UC Browser", Users = 17, Text= "17%", Fill="#ffa060"},
        new Statistics { Browser = "iPhone", Users = 19, Text= "19%", Fill="#ff68b6"},
        new Statistics { Browser = "Others", Users = 4 , Text= "4%", Fill="#81e2a1"},
    };
}

```

![Blazor Accumulation Chart with Connector Line](images/data-label/blazor-accumulation-chart-connector-line.png)

## Text Mapping

The [Name](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationDataLabelSettings.html#Syncfusion_Blazor_Charts_AccumulationDataLabelSettings_Name) property can be used to map text from a data source to a data label.

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

@code{
    public class Statistics
    {
        public string Browser { get; set; }
        public double Users { get; set; }
        public string Text { get; set; }
        public string Fill { get; set; }
    }

    public List<Statistics> StatisticsDetails = new List<Statistics>
    {
        new Statistics { Browser = "Chrome", Users = 37, Text= "37%", Fill="#498fff"},
        new Statistics { Browser = "UC Browser", Users = 17, Text= "17%", Fill="#ffa060"},
        new Statistics { Browser = "iPhone", Users = 19, Text= "19%", Fill="#ff68b6"},
        new Statistics { Browser = "Others", Users = 4 , Text= "4%", Fill="#81e2a1"},
    };
}

```

![Text Mapping in Blazor Accumulation Chart](images/data-label/blazor-accumulation-chart-text-mapping.png)

> Refer to our [Blazor Charts](https://www.syncfusion.com/blazor-components/blazor-charts) feature tour page for its groundbreaking feature representations and also explore our [Blazor Accumulation Chart Example](https://blazor.syncfusion.com/demos/chart/pie?theme=bootstrap4) to know various features of accumulation charts and how it is used to represent numeric proportional data.

## See Also

* [Tooltip](./tool-tip/)
* [Legend](./legend/)