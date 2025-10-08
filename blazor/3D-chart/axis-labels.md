---
layout: post
title: Axis Labels in Blazor 3D Chart Component | Syncfusion
description: Check out and learn how to configure and customize Axis Labels in Syncfusion Blazor 3D Chart component.
platform: Blazor
control: 3D Chart
documentation: ug
---

# Axis Labels in Blazor 3D Chart Component

Axis labels are displayed adjacent to the y-axis and beneath the x-axis, providing descriptive information for each axis.

## Smart axis labels

When axis labels overlap, the `LabelIntersectAction` property can be used to manage their placement.

**Case 1:** Setting `LabelIntersectAction` to **Hide** hides overlapping labels.

```cshtml

@using Syncfusion.Blazor.Chart3D

<SfChart3D Title="Olympic Medals" WallColor="transparent" EnableRotation="true" RotationAngle="7" TiltAngle="10" Depth="100">
    <Chart3DPrimaryXAxis ValueType="Syncfusion.Blazor.Chart3D.ValueType.Category" LabelIntersectAction="Syncfusion.Blazor.Chart3D.LabelIntersectAction.Hide" />

    <Chart3DSeriesCollection>
        <Chart3DSeries DataSource="@MedalDetails" XName="X" YName="Y" Type="Chart3DSeriesType.Column" />
    </Chart3DSeriesCollection>
</SfChart3D>

@code {
    public class Chart3DData
    {
        public string X { get; set; }
        public double Y { get; set; }
    }
	
    public List<Chart3DData> MedalDetails = new List<Chart3DData>
    {
		new Chart3DData { X = "South Korea", Y = 39 },
		new Chart3DData { X = "India", Y = 61 },
		new Chart3DData { X = "Pakistan", Y = 20 },
		new Chart3DData { X = "Germany", Y = 65 },
		new Chart3DData { X = "Australia", Y = 15 },
		new Chart3DData { X = "Italy", Y = 29 },
		new Chart3DData { X = "United Kingdom", Y = 44 },
		new Chart3DData { X = "Saudi Arabia", Y = 9 },
		new Chart3DData { X = "Russia", Y = 40 },
		new Chart3DData { X = "Mexico", Y = 31 },
		new Chart3DData { X = "Brazil", Y = 75 },
		new Chart3DData { X = "China", Y = 51 }
    };
}


```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BtBTDnMVpitELVMq?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Hiding Smart Axis Label in Blazor Column 3D Chart](images/axis-labels/blazor-column-chart-hide-smart-axis-label.png)

**Case 2:** Setting `LabelIntersectAction` to **Rotate45** rotates overlapping labels by 45 degrees.

```cshtml

@using Syncfusion.Blazor.Chart3D

<SfChart3D Title="Olympic Medals" WallColor="transparent" EnableRotation="true" RotationAngle="7" TiltAngle="10" Depth="100">
    <Chart3DPrimaryXAxis ValueType="Syncfusion.Blazor.Chart3D.ValueType.Category" LabelIntersectAction="Syncfusion.Blazor.Chart3D.LabelIntersectAction.Rotate45" />

    <Chart3DSeriesCollection>
        <Chart3DSeries DataSource="@MedalDetails" XName="X" YName="Y" Type="Chart3DSeriesType.Column" />
    </Chart3DSeriesCollection>
</SfChart3D>

@code {
    public class Chart3DData
    {
        public string X { get; set; }
        public double Y { get; set; }
    }
	
    public List<Chart3DData> MedalDetails = new List<Chart3DData>
    {
		new Chart3DData { X = "South Korea", Y = 39 },
		new Chart3DData { X = "India", Y = 61 },
		new Chart3DData { X = "Pakistan", Y = 20 },
		new Chart3DData { X = "Germany", Y = 65 },
		new Chart3DData { X = "Australia", Y = 15 },
		new Chart3DData { X = "Italy", Y = 29 },
		new Chart3DData { X = "United Kingdom", Y = 44 },
		new Chart3DData { X = "Saudi Arabia", Y = 9 },
		new Chart3DData { X = "Russia", Y = 40 },
		new Chart3DData { X = "Mexico", Y = 31 },
		new Chart3DData { X = "Brazil", Y = 75 },
		new Chart3DData { X = "China", Y = 51 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/hXLptnWBJMsfXNjH?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor Column 3D Chart with Smart Axis Label in Rotate45](images/axis-labels/blazor-column-chart-axis-label-in-rotate45.png)

**Case 3:** Setting `LabelIntersectAction` to **Rotate90** rotates overlapping labels by 90 degrees.

```cshtml

@using Syncfusion.Blazor.Chart3D

<SfChart3D Title="Olympic Medals" WallColor="transparent" EnableRotation="true" RotationAngle="7" TiltAngle="10" Depth="100">
    <Chart3DPrimaryXAxis ValueType="Syncfusion.Blazor.Chart3D.ValueType.Category" LabelIntersectAction="Syncfusion.Blazor.Chart3D.LabelIntersectAction.Rotate90" />

    <Chart3DSeriesCollection>
        <Chart3DSeries DataSource="@MedalDetails" XName="X" YName="Y" Type="Chart3DSeriesType.Column" />
    </Chart3DSeriesCollection>
</SfChart3D>

@code {
    public class Chart3DData
    {
        public string X { get; set; }
        public double Y { get; set; }
    }
	
    public List<Chart3DData> MedalDetails = new List<Chart3DData>
    {
		new Chart3DData { X = "South Korea", Y = 39 },
		new Chart3DData { X = "India", Y = 61 },
		new Chart3DData { X = "Pakistan", Y = 20 },
		new Chart3DData { X = "Germany", Y = 65 },
		new Chart3DData { X = "Australia", Y = 15 },
		new Chart3DData { X = "Italy", Y = 29 },
		new Chart3DData { X = "United Kingdom", Y = 44 },
		new Chart3DData { X = "Saudi Arabia", Y = 9 },
		new Chart3DData { X = "Russia", Y = 40 },
		new Chart3DData { X = "Mexico", Y = 31 },
		new Chart3DData { X = "Brazil", Y = 75 },
		new Chart3DData { X = "China", Y = 51 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/VtBJjnsLJMrjzDrD?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor Column 3D Chart with Smart Axis Label in Rotate90](images/axis-labels/blazor-column-chart-axis-label-in-rotate90.png)

## Edge label placement

Labels with long text at the edges of an axis may appear partially in the 3D chart. The `EdgeLabelPlacement` property moves the label inside the chart area or hides it for improved appearance.

```cshtml

@using Syncfusion.Blazor.Chart3D

<SfChart3D Title="Olympic Medals" WallColor="transparent" EnableRotation="true" RotationAngle="7" TiltAngle="10" Depth="100">
    <Chart3DPrimaryXAxis EdgeLabelPlacement="Syncfusion.Blazor.Chart3D.EdgeLabelPlacement.Shift" ValueType="Syncfusion.Blazor.Chart3D.ValueType.Category">
    </Chart3DPrimaryXAxis>

    <Chart3DSeriesCollection>
        <Chart3DSeries DataSource="@MedalDetails" XName="Country" YName="Gold" Type="Chart3DSeriesType.Column">
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
		new Chart3DData { Country = "United States", Gold = 50 },
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
{% previewsample "https://blazorplayground.syncfusion.com/embed/rXVpDnsLTsLcphWe?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Displaying Blazor Chart Axis Label in Edge Position](images/axis-labels/blazor-chart-axis-label-in-edge.png)

## Maximum labels

Labels are rendered based on the count specified in the `MaximumLabels` property per 100 pixels. If both the range (minimum, maximum, interval) and `MaximumLabels` are set, the range takes priority. If the range is not set, the `MaximumLabels` property is used.

```cshtml

@using Syncfusion.Blazor.Chart3D

<SfChart3D Title="Product X" WallColor="transparent" EnableRotation="true" RotationAngle="7" TiltAngle="10" Depth="100">
    <Chart3DPrimaryXAxis EdgeLabelPlacement="EdgeLabelPlacement.Shift" MaximumLabels="1" ValueType="Syncfusion.Blazor.Chart3D.ValueType.Category">
    </Chart3DPrimaryXAxis>
    <Chart3DPrimaryYAxis Title="Profit ($)"></Chart3DPrimaryYAxis>
    <Chart3DSeriesCollection>
        <Chart3DSeries DataSource="@ChartPoints" XName="Period" YName="Price" Name="Product X" Type="Chart3DSeriesType.Column">
        </Chart3DSeries>
    </Chart3DSeriesCollection>
</SfChart3D>

@code {
    private Random randomNum = new Random();
    private double PriceY = 80;
    public List<ChartData> ChartPoints { get; set; } = new List<ChartData>();
    
    public class ChartData
    {
        public double Period { get; set; }
        public double Price { get; set; }
    }

    protected override void OnInitialized()
    {
        GetChartPoints(50);
    }

    private void GetChartPoints(int value)
    {
        if (ChartPoints.Count > 0)
        {
            ChartPoints.Clear();
        }
        for (int i = 1; i < value; i++)
        {
            if (randomNum.NextDouble() > 0.5)
            {
                PriceY += randomNum.NextDouble();
            }
            else
            {
                PriceY -= randomNum.NextDouble();
            }
            ChartPoints.Add(new ChartData
                {
                    Period = i,
                    Price = Math.Round(PriceY)
                }
            );
        }
    }
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/htBJNxCrTWKrGBCU?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}
