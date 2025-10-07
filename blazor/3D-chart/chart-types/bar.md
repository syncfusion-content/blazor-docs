---
layout: post
title: Bar Chart in Blazor 3D Chart Component | Syncfusion
description: Check out and learn configure and customize the Bar Charts in Syncfusion Blazor 3D Chart component.
platform: Blazor
control: 3D Chart
documentation: ug
---

# Bar Chart in Blazor 3D Chart control

## Bar chart

To render a bar series, set the series `Type` property to `Bar`.

```cshtml

@using Syncfusion.Blazor.Chart3D

<SfChart3D Title="Olympic Medals" WallColor="transparent" EnableRotation="true" RotationAngle="7" TiltAngle="10" Depth="100">
    <Chart3DPrimaryXAxis ValueType="Syncfusion.Blazor.Chart3D.ValueType.Category" />

    <Chart3DSeriesCollection>
        <Chart3DSeries DataSource="@MedalDetails" XName="Country" YName="Gold" Type="Chart3DSeriesType.Bar">
        </Chart3DSeries>
    </Chart3DSeriesCollection>
</SfChart3D>

@code {
    public class Chart3DData
    {
        public string Country { get; set; }
        public double Gold { get; set; }
    }

    public List<Chart3DData> MedalDetails = new List<Chart3DData>
	{
        new Chart3DData { Country = "USA", Gold = 50 },
		new Chart3DData { Country = "China", Gold = 40 },
		new Chart3DData { Country = "Japan", Gold = 70 },
		new Chart3DData { Country = "Australia", Gold = 60 },
		new Chart3DData { Country = "France", Gold = 50 },
		new Chart3DData { Country = "Germany", Gold = 40 },
		new Chart3DData { Country = "Italy", Gold = 40 },
		new Chart3DData { Country = "Sweden", Gold = 30 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/hNhJXxsKslDavsMW?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor Bar 3D Chart](../images/chart-types-images/blazor-bar-chart.png)

## Bar space and width

The `ColumnSpacing` and `ColumnWidth` properties customize the space and width between bars.

```cshtml

@using Syncfusion.Blazor.Chart3D

<SfChart3D WallColor="transparent" EnableRotation="true" RotationAngle="7" TiltAngle="10" Depth="100">
    <Chart3DPrimaryXAxis ValueType="Syncfusion.Blazor.Chart3D.ValueType.Category" />

    <Chart3DSeriesCollection>
        <Chart3DSeries DataSource="@MedalDetails" XName="Country" YName="Gold" Type="Chart3DSeriesType.Bar" />
        <Chart3DSeries DataSource="@MedalDetails" XName="Country" YName="Silver" ColumnSpacing="0.5" ColumnWidth="0.75" Type="Chart3DSeriesType.Bar" />
    </Chart3DSeriesCollection>
</SfChart3D>

@code {
    public class Chart3DData
    {
        public string Country { get; set; }
        public double Gold { get; set; }
        public double Silver { get; set; }
    }
	
    public List<Chart3DData> MedalDetails = new List<Chart3DData>
    {
		new Chart3DData { Country = "USA", Gold = 50, Silver = 70 },
		new Chart3DData { Country = "China", Gold = 40, Silver = 60 },
		new Chart3DData { Country = "Japan", Gold = 70, Silver = 60 },
		new Chart3DData { Country = "Australia", Gold = 60, Silver = 56 },
		new Chart3DData { Country = "France", Gold = 50, Silver = 45 },
		new Chart3DData { Country = "Germany", Gold = 40, Silver = 30 },
		new Chart3DData { Country = "Italy", Gold = 40, Silver = 35 },
		new Chart3DData { Country = "Sweden", Gold = 30, Silver = 25 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BNhTXHMgilipfRPo?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor Bar 3D Chart with Space and Width](../images/chart-types-images/blazor-bar-chart-space-and-width.png)

## Grouped bar

Data points can be grouped in bar charts using the `GroupName` property. Data points with the same group name are grouped together.

```cshtml

@using Syncfusion.Blazor.Chart3D

<SfChart3D EnableSideBySidePlacement="false" RotationAngle="-12" Depth="250" TiltAngle="15">
    <Chart3DPrimaryXAxis ValueType="@Syncfusion.Blazor.Chart3D.ValueType.Category" />

    <Chart3DSeriesCollection>
        <Chart3DSeries DataSource="@Chart3DPoints" XName="Year" YName="USA_Total" GroupName="USA" Type="Chart3DSeriesType.Bar" ColumnWidth="0.2" Fill="#CB3587"></Chart3DSeries>
        <Chart3DSeries DataSource="@Chart3DPoints" XName="Year" YName="USA_Gold" GroupName="USA" Type="Chart3DSeriesType.Bar" ColumnWidth="0.2"></Chart3DSeries>
        <Chart3DSeries DataSource="@Chart3DPoints" XName="Year" YName="UK_Total" GroupName="UK" Type="Chart3DSeriesType.Bar" ColumnWidth="0.2"></Chart3DSeries>
        <Chart3DSeries DataSource="@Chart3DPoints" XName="Year" YName="UK_Gold" GroupName="UK" Type="Chart3DSeriesType.Bar" ColumnWidth="0.2" Fill="#E7910F"></Chart3DSeries>
    </Chart3DSeriesCollection>
</SfChart3D>

@code {
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
        new ColumnData { Year = "2020", USA_Total = 113, USA_Gold = 39, UK_Total = 65, UK_Gold = 22, China_Total = 88, China_Gold = 38}
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/htLfZRMUMlsmhOBI?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Grouping in Blazor Grouped Bar 3D Chart](../images/chart-types-images/blazor-column-chart-grouped-bar.png)

## Cylindrical column chart

To render a cylindrical bar chart, set the `ColumnFacet` property to `Cylinder` in the chart series.

```cshtml

@using Syncfusion.Blazor.Chart3D

<SfChart3D WallColor="transparent" RotationAngle="7" TiltAngle="10" Depth="100" Title="Passenger Car Production in Selected Countries – 2021">
    <Chart3DPrimaryXAxis ValueType="Syncfusion.Blazor.Chart3D.ValueType.Category" Interval="1" />
    <Chart3DPrimaryYAxis Maximum="4" Interval="1" />

    <Chart3DSeriesCollection>
        <Chart3DSeries DataSource="@Chart3DPoints" XName="X" YName="Y" ColumnWidth="0.9" Type="Chart3DSeriesType.Bar" ColumnFacet="Chart3DShapeType.Cylinder"></Chart3DSeries>
    </Chart3DSeriesCollection>
    <Chart3DTooltipSettings Enable="true" Header="${point.x}" Format="Car Production : <b>${point.y}M"></Chart3DTooltipSettings>
</SfChart3D>

@code {
    public class ColumnChart3DData
    {
        public string X { get; set; }
        public double Y { get; set; }
    }

    public List<ColumnChart3DData> Chart3DPoints { get; set; } = new List<ColumnChart3DData>
    {
        new ColumnChart3DData { X = "Czechia", Y = 1.11 },
        new ColumnChart3DData { X = "Spain", Y = 1.66 },
        new ColumnChart3DData { X = "USA", Y = 1.56 },
        new ColumnChart3DData { X = "Germany", Y = 3.1 },
        new ColumnChart3DData { X = "Russia", Y = 1.35 },
        new ColumnChart3DData { X = "Slovakia", Y = 1 },
        new ColumnChart3DData { X = "South Korea", Y = 3.16 },
        new ColumnChart3DData { X = "France", Y = 0.92 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BXhICXNGBzdWJrIr?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor Cylindrical Bar 3D Chart](../images/chart-types-images/blazor-cylindricaal-bar-chart.png)

## Series customization

The following properties are available to customize the `Bar` series:

* `Fill` – Specifies the color of the series.
* `Opacity` – Specifies the opacity of the fill color.

```cshtml

@using Syncfusion.Blazor.Chart3D

<SfChart3D WallColor="transparent" EnableRotation="true" RotationAngle="7" TiltAngle="10" Depth="100">
    <Chart3DPrimaryXAxis ValueType="Syncfusion.Blazor.Chart3D.ValueType.Category" />

    <Chart3DSeriesCollection>
        <Chart3DSeries DataSource="@MedalDetails" XName="Country" YName="Gold" Fill="#0364DE" Type="Chart3DSeriesType.Bar" />
    </Chart3DSeriesCollection>
</SfChart3D>

@code {
    public class Chart3DData
    {
        public string Country { get; set; }
        public double Gold { get; set; }
        public double Silver { get; set; }
    }
	
    public List<Chart3DData> MedalDetails = new List<Chart3DData>
    {
		new Chart3DData { Country = "USA", Gold = 50, Silver = 70 },
		new Chart3DData { Country = "China", Gold = 40, Silver = 60 },
		new Chart3DData { Country = "Japan", Gold = 70, Silver = 60 },
		new Chart3DData { Country = "Australia", Gold = 60, Silver = 56 },
		new Chart3DData { Country = "France", Gold = 50, Silver = 45 },
		new Chart3DData { Country = "Germany", Gold = 40, Silver = 30 },
		new Chart3DData { Country = "Italy", Gold = 40, Silver = 35 },
		new Chart3DData { Country = "Sweden", Gold = 30, Silver = 25 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/VZBTZdMKWvrLOzmq?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor Bar 3D Chart with Custom Series](../images/chart-types-images/blazor-bar-chart-custom-series.png)
