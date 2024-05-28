---
layout: post
title: Bar Chart in Blazor 3D Chart Component | Syncfusion
description: Checkout and learn here all about the Bar Charts in Syncfusion Blazor 3D Chart component and much more.
platform: Blazor
control: 3D Chart 
documentation: ug
---

# Bar Chart in Blazor 3D Chart control

## Bar chart

To render a bar series, set series [Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Type) as [Bar](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeriesType.html#Syncfusion_Blazor_Charts_ChartSeriesType_Bar).

```cshtml

@using Syncfusion.Blazor.Chart3D

<SfChart3D Title="Olympic Medals" WallColor="transparent" EnableRotation="true" RotationAngle="7" TiltAngle="10" Depth="100">
    <Chart3DPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category">
    </Chart3DPrimaryXAxis>

    <Chart3DSeriesCollection>
        <Chart3DSeries DataSource="@MedalDetails" XName="Country" YName="Gold" Type="Chart3DSeriesType.Bar">
        </Chart3DSeries>
    </Chart3DSeriesCollection>
</SfChart3D>

@code{
    public class Chart3DData
    {
        public string Country { get; set; }
        public double Gold { get; set; }
    }

    public List<Chart3DData> MedalDetails = new List<Chart3DData>
	{
		new Chart3DData{ Country= "USA", Gold=50  },
		new Chart3DData{ Country="China", Gold=40 },
		new Chart3DData{ Country= "Japan", Gold=70 },
		new Chart3DData{ Country= "Australia", Gold=60},
		new Chart3DData{ Country= "France", Gold=50 },
		new Chart3DData{ Country= "Germany", Gold=40 },
		new Chart3DData{ Country= "Italy", Gold=40 },
		new Chart3DData{ Country= "Sweden", Gold=30 }
    };
}

```

![Blazor Bar 3D Chart](../images/chart-types-images/blazor-bar-chart.png)

## Bar space and width

The [ColumnSpacing](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_ColumnSpacing) and [ColumnWidth](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_ColumnWidth) properties are used to customize the space between bars.

```cshtml

@using Syncfusion.Blazor.Chart3D

<SfChart3D WallColor="transparent" EnableRotation="true" RotationAngle="7" TiltAngle="10" Depth="100">
    <Chart3DPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category">
       </Chart3DPrimaryXAxis>

    <Chart3DSeriesCollection>
        <Chart3DSeries DataSource="@MedalDetails" XName="Country" YName="Gold" Type="Chart3DSeriesType.Bar" />
        <Chart3DSeries DataSource="@MedalDetails" XName="Country" YName="Silver" ColumnSpacing="0.5" ColumnWidth="0.75" Type="Chart3DSeriesType.Bar" />
    </Chart3DSeriesCollection>
</SfChart3D>

@code{
    public class Chart3DData
    {
        public string Country { get; set; }
        public double Gold { get; set; }
        public double Silver { get; set; }
    }
	
    public List<Chart3DData> MedalDetails = new List<Chart3DData>
    {
		new Chart3DData{ Country = "USA", Gold = 50, Silver = 70 },
		new Chart3DData{ Country = "China", Gold = 40, Silver = 60 },
		new Chart3DData{ Country = "Japan", Gold = 70, Silver = 60 },
		new Chart3DData{ Country = "Australia", Gold = 60, Silver = 56 },
		new Chart3DData{ Country = "France", Gold = 50, Silver = 45 },
		new Chart3DData{ Country = "Germany", Gold = 40, Silver = 30 },
		new Chart3DData{ Country = "Italy", Gold = 40, Silver = 35 },
		new Chart3DData{ Country = "Sweden", Gold = 30, Silver = 25 }
    };
}


```

![Blazor Bar 3D Chart with Space and Width](../images/chart-types-images/blazor-bar-chart-space-and-width.png)

## Grouped bar

The data points can be grouped in the bar type charts by using the [GroupName](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_GroupName) property. Data points with same group name are grouped together.

```cshtml

@using Syncfusion.Blazor.Chart3D

<SfChart3D WallColor="transparent" EnableRotation="true" RotationAngle="7" TiltAngle="10" Depth="100">
        <Chart3DPrimaryXAxis ValueType="@Syncfusion.Blazor.Charts.ValueType.Category">
        </Chart3DPrimaryXAxis>
        <Chart3DSeriesCollection>
            <Chart3DSeries DataSource="@Chart3DPoints" XName="Year" YName="USA_Total" GroupName="USA" ColumnWidth="0.7" ColumnSpacing="0.1" Type="Chart3DSeriesType.Bar">
            </Chart3DSeries>
            <Chart3DSeries DataSource="@Chart3DPoints" XName="Year" YName="USA_Gold" GroupName="USA" ColumnWidth="0.5" ColumnSpacing="0.1" Type="Chart3DSeriesType.Bar">
             </Chart3DSeries>
            <Chart3DSeries DataSource="@Chart3DPoints" XName="Year" YName="UK_Total" GroupName="UK" ColumnWidth="0.7" ColumnSpacing="0.1" Type="Chart3DSeriesType.Bar">
            </Chart3DSeries>
            <Chart3DSeries DataSource="@Chart3DPoints" XName="Year" YName="UK_Gold" GroupName="UK" ColumnWidth="0.5" ColumnSpacing="0.1" Type="Chart3DSeriesType.Bar">
            </Chart3DSeries>
        </Chart3DSeriesCollection>
    </SfChart3D>

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
    public List<ColumnData> Chart3DPoints { get; set; } = new List<ColumnData>
    {
        new ColumnData { Year = "2012", USA_Total = 104, USA_Gold = 46, UK_Total = 65, UK_Gold = 29, China_Total = 91, China_Gold = 38},
        new ColumnData { Year = "2016", USA_Total = 121, USA_Gold = 46, UK_Total = 67, UK_Gold = 27, China_Total = 70, China_Gold = 26},
        new ColumnData { Year = "2020", USA_Total = 113, USA_Gold = 39, UK_Total = 65, UK_Gold = 22, China_Total = 88, China_Gold = 38},
    };
}

```

![Grouping in Blazor Grouped Bar 3D Chart](../images/chart-types-images/blazor-column-chart-grouped-bar.png)

## Cylindrical column chart

To render a cylindrical column chart, set the [`ColumnFacet`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeriesType.html#Syncfusion_Blazor_Charts_ChartSeriesType_Column) property to `Cylinder` in the chart series.

```cshtml

@using Syncfusion.Blazor.Chart3D

<SfChart3D WallColor="transparent" RotationAngle="7" TiltAngle="10" Depth="100" Title="Passenger Car Production in Selected Countries – 2021">
    <Chart3DPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" Interval="1"></Chart3DPrimaryXAxis>
    <Chart3DPrimaryYAxis Maximum="4" Interval="1"></Chart3DPrimaryYAxis>
    <Chart3DSeriesCollection>
        <Chart3DSeries DataSource="@Chart3DPoints" XName="X" YName="Y" ColumnWidth="0.9" Type="Chart3DSeriesType.Bar" ColumnFacet="Chart3DShapeType.Cylinder"></Chart3DSeries>
    </Chart3DSeriesCollection>
    <Chart3DTooltipSettings Enable="true" Header="${point.x}" Format="Car Production : <b>${point.y}M"></Chart3DTooltipSettings>
</SfChart3D>
@code {
    public List<ColumnChart3DData> Chart3DPoints { get; set; } = new List<ColumnChart3DData>
    {
         new ColumnChart3DData { X= "Czechia", Y= 1.11 },
         new ColumnChart3DData { X= "Spain", Y= 1.66 },
         new ColumnChart3DData { X= "USA", Y= 1.56 },
         new ColumnChart3DData { X= "Germany", Y= 3.1 },
         new ColumnChart3DData { X= "Russia", Y= 1.35 },
         new ColumnChart3DData { X= "Slovakia", Y= 1 },
         new ColumnChart3DData { X= "South Korea", Y= 3.16 },
         new ColumnChart3DData { X= "France", Y= 0.92 }
    };
    public class ColumnChart3DData
    {
        public string X { get; set; }
        public double Y { get; set; }
    }
}

```

![Blazor Cylindrical Bar 3D Chart](../images/chart-types-images/blazor-cylindricaal-bar-chart.png)

## Series customization

The following properties can be used to customize the `Bar` series.

* [Fill](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Fill) – Specifies the color of the series.
* [Opacity](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Opacity) – Specifies the opacity of the [Fill](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Fill) color.

```cshtml

@using Syncfusion.Blazor.Chart3D

<SfChart3D WallColor="transparent" EnableRotation="true" RotationAngle="7" TiltAngle="10" Depth="100">
    <Chart3DPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category">
       </Chart3DPrimaryXAxis>

    <Chart3DSeriesCollection>
        <Chart3DSeries DataSource="@MedalDetails" XName="Country" YName="Gold" Fill="red" Type="Chart3DSeriesType.Column" />
    </Chart3DSeriesCollection>
</SfChart3D>

@code{
    public class Chart3DData
    {
        public string Country { get; set; }
        public double Gold { get; set; }
        public double Silver { get; set; }
    }
	
    public List<Chart3DData> MedalDetails = new List<Chart3DData>
    {
		new Chart3DData{ Country = "USA", Gold = 50, Silver = 70 },
		new Chart3DData{ Country = "China", Gold = 40, Silver = 60 },
		new Chart3DData{ Country = "Japan", Gold = 70, Silver = 60 },
		new Chart3DData{ Country = "Australia", Gold = 60, Silver = 56 },
		new Chart3DData{ Country = "France", Gold = 50, Silver = 45 },
		new Chart3DData{ Country = "Germany", Gold = 40, Silver = 30 },
		new Chart3DData{ Country = "Italy", Gold = 40, Silver = 35 },
		new Chart3DData{ Country = "Sweden", Gold = 30, Silver = 25 }
    };
}

```

![Blazor Bar 3D Chart with Custom Series](../images/chart-types-images/blazor-bar-chart-custom-series.png)

N> Refer to our [Blazor 3D Chart](https://www.syncfusion.com/blazor-components/blazor-charts) feature tour page for its groundbreaking feature representations and also explore our [Blazor 3D Chart Example](https://blazor.syncfusion.com/demos/chart/line?theme=bootstrap4) to know various 3D chart types and how to represent time-dependent data, showing trends at equal intervals.

## See also

* [Data Label](../data-labels)
* [Tooltip](../tool-tip)
