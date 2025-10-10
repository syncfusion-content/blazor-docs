---
layout: post
title: Tooltip in Blazor 3D Chart Component | Syncfusion
description: Check out and learn how to configure and customize Tooltip in the Syncfusion Blazor 3D Chart component.
platform: Blazor
control: 3D Chart
documentation: ug
---

# Tooltip in Blazor 3D Chart Component

<!-- markdownlint-disable MD036 -->

The 3D chart displays data point details through a tooltip when the pointer hovers over a specific point.

## Default tooltip

By default, the tooltip is not visible. Enable the tooltip by setting the `Enable` property in `Chart3DTooltipSettings` to **true**.

```cshtml

@using Syncfusion.Blazor.Chart3D

<SfChart3D WallColor="transparent" EnableRotation="true" RotationAngle="7" TiltAngle="10" Depth="100">
    <Chart3DPrimaryXAxis ValueType="Syncfusion.Blazor.Chart3D.ValueType.Category" LabelPlacement="Syncfusion.Blazor.Chart3D.LabelPlacement.BetweenTicks" />
    <Chart3DTooltipSettings Enable="true"></Chart3DTooltipSettings>
    <Chart3DSeriesCollection>
        <Chart3DSeries DataSource="@SalesReports" XName="Month" YName="Sales" Type="Chart3DSeriesType.Column" />
    </Chart3DSeriesCollection>
</SfChart3D>

@code{
    public class Chart3DData
    {
        public string Month { get; set; }
        public double Sales { get; set; }
    }

    public List<Chart3DData> SalesReports = new List<Chart3DData>
    {
        new Chart3DData { Month = "Jan", Sales = 35 },
        new Chart3DData { Month = "Feb", Sales = 28 },
        new Chart3DData { Month = "Mar", Sales = 34 },
        new Chart3DData { Month = "Apr", Sales = 32 },
        new Chart3DData { Month = "May", Sales = 40 },
        new Chart3DData { Month = "Jun", Sales = 32 },
        new Chart3DData { Month = "Jul", Sales = 35 },
        new Chart3DData { Month = "Aug", Sales = 55 },
        new Chart3DData { Month = "Sep", Sales = 38 },
        new Chart3DData { Month = "Oct", Sales = 30 },
        new Chart3DData { Month = "Nov", Sales = 25 },
        new Chart3DData { Month = "Dec", Sales = 32 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/LtBfXHiKipfupKhA?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor Column 3D Chart with Tooltip](images/tooltip/blazor-column-chart-tooltip.png)

## Fixed tooltip

By default, the tooltip tracks pointer movement. To render the tooltip at a fixed position, use the `Chart3DTooltipLocation` property.

```cshtml

@using Syncfusion.Blazor.Chart3D

<SfChart3D WallColor="transparent" EnableRotation="true" RotationAngle="7" TiltAngle="10" Depth="100">
    <Chart3DPrimaryXAxis ValueType="Syncfusion.Blazor.Chart3D.ValueType.Category" LabelPlacement="Syncfusion.Blazor.Chart3D.LabelPlacement.BetweenTicks" />
    <Chart3DTooltipSettings Enable="true">
        <Chart3DTooltipLocation X="120" Y="20" />
    </Chart3DTooltipSettings>
    <Chart3DSeriesCollection>
        <Chart3DSeries DataSource="@SalesReports" XName="Month" YName="Sales" Type="Chart3DSeriesType.Column" />
    </Chart3DSeriesCollection>
</SfChart3D>

@code {
    public class Chart3DData
    {
        public string Month { get; set; }
        public double Sales { get; set; }
    }
	
    public List<Chart3DData> SalesReports = new List<Chart3DData>
    {
        new Chart3DData { Month = "Jan", Sales = 35 },
        new Chart3DData { Month = "Feb", Sales = 28 },
        new Chart3DData { Month = "Mar", Sales = 34 },
        new Chart3DData { Month = "Apr", Sales = 32 },
        new Chart3DData { Month = "May", Sales = 40 },
        new Chart3DData { Month = "Jun", Sales = 32 },
        new Chart3DData { Month = "Jul", Sales = 35 },
        new Chart3DData { Month = "Aug", Sales = 55 },
        new Chart3DData { Month = "Sep", Sales = 38 },
        new Chart3DData { Month = "Oct", Sales = 30 },
        new Chart3DData { Month = "Nov", Sales = 25 },
        new Chart3DData { Month = "Dec", Sales = 32 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/hDBzNHiACfySnnZq?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor Column 3D Chart with Fixed Tooltip](images/tooltip/blazor-column-chart-fixed-tooltip.png)

## Format the tooltip

<!-- markdownlint-disable MD013 -->

By default, the tooltip displays the x and y values for each point. Additional information can be displayed using the `Format` property. For example, the format `${series.name} : ${point.y}` shows the series name and the point’s y-value.

```cshtml

@using Syncfusion.Blazor.Chart3D

<SfChart3D WallColor="transparent" EnableRotation="true" RotationAngle="7" TiltAngle="10" Depth="100">
    <Chart3DPrimaryXAxis ValueType="Syncfusion.Blazor.Chart3D.ValueType.Category" LabelPlacement="Syncfusion.Blazor.Chart3D.LabelPlacement.BetweenTicks" />
    <Chart3DTooltipSettings Enable="true" Header="Sales" Format="<b>${series.name} : ${point.y}</b>">
    </Chart3DTooltipSettings>
    <Chart3DSeriesCollection>
        <Chart3DSeries DataSource="@SalesReports" XName="Month" YName="Sales" Type="Chart3DSeriesType.Column" />
    </Chart3DSeriesCollection>
</SfChart3D>

@code {
    public class Chart3DData
    {
        public string Month { get; set; }
        public double Sales { get; set; }
    }
	
    public List<Chart3DData> SalesReports = new List<Chart3DData>
    {
        new Chart3DData { Month = "Jan", Sales = 35 },
        new Chart3DData { Month = "Feb", Sales = 28 },
        new Chart3DData { Month = "Mar", Sales = 34 },
        new Chart3DData { Month = "Apr", Sales = 32 },
        new Chart3DData { Month = "May", Sales = 40 },
        new Chart3DData { Month = "Jun", Sales = 32 },
        new Chart3DData { Month = "Jul", Sales = 35 },
        new Chart3DData { Month = "Aug", Sales = 55 },
        new Chart3DData { Month = "Sep", Sales = 38 },
        new Chart3DData { Month = "Oct", Sales = 30 },
        new Chart3DData { Month = "Nov", Sales = 25 },
        new Chart3DData { Month = "Dec", Sales = 32 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BXBpNnsgspnNkiNQ?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor Column 3D Chart with Tooltip Format](images/tooltip/blazor-column-chart-tooltip-format.png)

<!-- markdownlint-disable MD013 -->

## Tooltip template

Any HTML elements can be rendered in the tooltip using the `Chart3DTooltipTemplate` property of `Chart3DTooltipSettings`. The placeholders **data.X** and **data.Y** within the template represent the x and y values for the corresponding data point.

```cshtml

@using Syncfusion.Blazor.Chart3D

<SfChart3D WallColor="transparent" EnableRotation="true" RotationAngle="7" TiltAngle="10" Depth="100">
    <Chart3DPrimaryXAxis ValueType="Syncfusion.Blazor.Chart3D.ValueType.Category" LabelPlacement="Syncfusion.Blazor.Chart3D.LabelPlacement.BetweenTicks" />
    <Chart3DTooltipSettings Enable="true">
        <Chart3DTooltipTemplate>
            @{
                var data = context as Chart3DTooltipInfo;
                <div>                       
                    <table style="width:100%;  border: 1px solid black;">
                        <tr><th colspan="2" bgcolor="#00FFFF">Unemployment</th></tr>
                        <tr><td bgcolor="#00FFFF">@data.X:</td><td bgcolor="#00FFFF">@data.Y</td></tr>
                    </table>
                </div>
            }         
        </Chart3DTooltipTemplate>
    </Chart3DTooltipSettings>
    <Chart3DSeriesCollection>
        <Chart3DSeries DataSource="@SalesReports" XName="Month" YName="Sales" Type="Chart3DSeriesType.Column" />
    </Chart3DSeriesCollection>
</SfChart3D>

@code {
    public class Chart3DData
    {
        public string Month { get; set; }
        public double Sales { get; set; }
    }

    public List<Chart3DData> SalesReports = new List<Chart3DData>
    {
        new Chart3DData { Month = "Jan", Sales = 35 },
        new Chart3DData { Month = "Feb", Sales = 28 },
        new Chart3DData { Month = "Mar", Sales = 34 },
        new Chart3DData { Month = "Apr", Sales = 32 },
        new Chart3DData { Month = "May", Sales = 40 },
        new Chart3DData { Month = "Jun", Sales = 32 },
        new Chart3DData { Month = "Jul", Sales = 35 },
        new Chart3DData { Month = "Aug", Sales = 55 },
        new Chart3DData { Month = "Sep", Sales = 38 },
        new Chart3DData { Month = "Oct", Sales = 30 },
        new Chart3DData { Month = "Nov", Sales = 25 },
        new Chart3DData { Month = "Dec", Sales = 32 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/VjhpDnCUWTxpwqMH?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor Column 3D Chart with Tooltip Template](images/tooltip/blazor-column-chart-tooltip-template.png)

## Customize the appearance of tooltip

Use the `Fill` and `Border` properties to customize the tooltip background and border. Use `ChartTooltipTextStyle` to customize the tooltip text.

```cshtml

@using Syncfusion.Blazor.Chart3D

<SfChart3D WallColor="transparent" EnableRotation="true" RotationAngle="7" TiltAngle="10" Depth="100">
    <Chart3DPrimaryXAxis ValueType="Syncfusion.Blazor.Chart3D.ValueType.Category" LabelPlacement="Syncfusion.Blazor.Chart3D.LabelPlacement.BetweenTicks" />
    <Chart3DTooltipSettings Enable="true" Format="<b>${point.x} : ${point.y}</b>" Fill="#7bb4eb">
        <Chart3DTooltipBorder Color="red" Width="1"></Chart3DTooltipBorder>
    </Chart3DTooltipSettings>
    <Chart3DSeriesCollection>
        <Chart3DSeries DataSource="@SalesReports" XName="Month" YName="Sales" Type="Chart3DSeriesType.Column" />
    </Chart3DSeriesCollection>
</SfChart3D>

@code {
    public class Chart3DData
    {
        public string Month { get; set; }
        public double Sales { get; set; }
    }

    public List<Chart3DData> SalesReports = new List<Chart3DData>
    {
        new Chart3DData { Month = "Jan", Sales = 35 },
        new Chart3DData { Month = "Feb", Sales = 28 },
        new Chart3DData { Month = "Mar", Sales = 34 },
        new Chart3DData { Month = "Apr", Sales = 32 },
        new Chart3DData { Month = "May", Sales = 40 },
        new Chart3DData { Month = "Jun", Sales = 32 },
        new Chart3DData { Month = "Jul", Sales = 35 },
        new Chart3DData { Month = "Aug", Sales = 55 },
        new Chart3DData { Month = "Sep", Sales = 38 },
        new Chart3DData { Month = "Oct", Sales = 30 },
        new Chart3DData { Month = "Nov", Sales = 25 },
        new Chart3DData { Month = "Dec", Sales = 32 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/hZrTXxsgsfmibwll?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor Column 3D Chart with Custom Tooltip](images/tooltip/blazor-column-chart-custom-tooltip.png)
