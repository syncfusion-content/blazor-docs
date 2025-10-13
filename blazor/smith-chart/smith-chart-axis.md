---
layout: post
title: Axis in Blazor Smith Chart Component | Syncfusion
description: Check out and learn how to configure and customize axis in Syncfusion Blazor Smith Chart component for better visualization.
platform: Blazor
control: Smith Chart
documentation: ug
---

# Axis in Blazor Smith Chart Component

The Smith Chart provides two types of axes:
* **Horizontal Axis** – Drawn as a straight line along the horizontal direction of the Smith Chart.
* **Radial Axis** – Drawn as a circular path.

## Labels Customization

Axis labels indicate the type of data bound to the Smith Chart, making it easier to interpret chart intervals. Labels for both horizontal and radial axes can be customized using the following properties:

* [Visible](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SmithChartHorizontalAxis.html#Syncfusion_Blazor_Charts_SmithChartHorizontalAxis_Visible) – Specifies the visibility of the axis.
* [LabelPosition](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SmithChartHorizontalAxis.html#Syncfusion_Blazor_Charts_SmithChartHorizontalAxis_LabelPosition) – Places labels inside or outside the axis line.
* [LabelIntersectAction](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SmithChartHorizontalAxis.html#Syncfusion_Blazor_Charts_SmithChartHorizontalAxis_LabelIntersectAction) – Hides labels when they intersect.
* [SmithChartRadialAxisLabelStyle](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SmithChartRadialAxisLabelStyle.html) and [SmithChartHorizontalAxisLabelStyle](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SmithChartHorizontalAxisLabelStyle.html) – Customize label font properties such as [FontFamily](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SmithChartCommonFont.html#Syncfusion_Blazor_Charts_SmithChartCommonFont_FontFamily), [FontWeight](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SmithChartCommonFont.html#Syncfusion_Blazor_Charts_SmithChartCommonFont_FontWeight), [FontStyle](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SmithChartCommonFont.html#Syncfusion_Blazor_Charts_SmithChartCommonFont_FontStyle), [Opacity](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SmithChartCommonFont.html#Syncfusion_Blazor_Charts_SmithChartCommonFont_Opacity), [Color](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SmithChartCommonFont.html#Syncfusion_Blazor_Charts_SmithChartCommonFont_Color), and [Size](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SmithChartCommonFont.html#Syncfusion_Blazor_Charts_SmithChartCommonFont_Size).

```cshtml

@using Syncfusion.Blazor.Charts

<SfSmithChart>
    <SmithChartHorizontalAxis>
        <SmithChartHorizontalAxisLabelStyle FontFamily="Times New Roman"
                                            FontWeight="bold"
                                            FontStyle="Italic"
                                            Opacity='0.75'
                                            Size="14px">
        </SmithChartHorizontalAxisLabelStyle>
    </SmithChartHorizontalAxis>
    <SmithChartRadialAxis LabelPosition='AxisLabelPosition.Inside'
                          LabelIntersectAction='SmithChartLabelIntersectAction.None'>
        <SmithChartRadialAxisLabelStyle FontFamily="Times New Roman"
                                        FontWeight="bold"
                                        FontStyle="Italic"
                                        Opacity='0.75'
                                        Size="14px">
        </SmithChartRadialAxisLabelStyle>
    </SmithChartRadialAxis>
    <SmithChartSeriesCollection>
        <SmithChartSeries DataSource='TransmissionData' Reactance="Reactance" Resistance="Resistance">
        </SmithChartSeries>
    </SmithChartSeriesCollection>
</SfSmithChart>

@code {
    public class SmithChartData
    {
        public double? Resistance { get; set; }
        public double? Reactance { get; set; }
    };

    public List<SmithChartData> TransmissionData = new List<SmithChartData> {
        new SmithChartData { Resistance = 10, Reactance = 25 },
        new SmithChartData { Resistance = 6, Reactance = 4.5 },
        new SmithChartData { Resistance = 3.5, Reactance = 1.6 },
        new SmithChartData { Resistance = 2, Reactance = 1.2 },
        new SmithChartData { Resistance = 1, Reactance = 0.8 },
        new SmithChartData { Resistance = 0, Reactance = 0.2 }
    };
}

```

![Blazor Smith Chart Axis with Custom Label](./images/Axis/blazor-smith-chart-axis-with-custom-label.png)

## Gridlines

Gridlines on the horizontal and radial axes improve data readability. Gridlines extend from the axes around the plot area. Both axes support major and minor gridlines. Major gridlines are drawn at label positions, while minor gridlines are drawn between major gridlines using the [Count](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SmithChartHorizontalMinorGridLines.html#Syncfusion_Blazor_Charts_SmithChartHorizontalMinorGridLines_Count) property.

The following properties can be customized for both major and minor gridlines:

* [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SmithChartHorizontalMinorGridLines.html#Syncfusion_Blazor_Charts_SmithChartHorizontalMinorGridLines_Width) – Sets the gridline width.
* [DashArray](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SmithChartMinorGridLines.html#Syncfusion_Blazor_Charts_SmithChartMinorGridLines_DashArray) – Renders gridlines as solid or dashed lines.
* [Visible](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SmithChartHorizontalMinorGridLines.html#Syncfusion_Blazor_Charts_SmithChartHorizontalMinorGridLines_Visible) – Enables or disables gridline visibility.
* [Opacity](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SmithChartHorizontalMajorGridLines.html#Syncfusion_Blazor_Charts_SmithChartHorizontalMajorGridLines_Opacity) – Sets the opacity of major gridlines.
* [Color](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SmithChartMajorGridLines.html#Syncfusion_Blazor_Charts_SmithChartMajorGridLines_Color) – Sets the color of major gridlines.
* [Count](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SmithChartHorizontalMinorGridLines.html#Syncfusion_Blazor_Charts_SmithChartHorizontalMinorGridLines_Count) – Sets the number of minor gridlines.

```cshtml

@using Syncfusion.Blazor.Charts

<SfSmithChart>
    <SmithChartHorizontalAxis>
        <SmithChartHorizontalMajorGridLines Visible='true' Opacity='0.8' Width='5'>
        </SmithChartHorizontalMajorGridLines>
        <SmithChartHorizontalMinorGridLines Visible='true' DashArray="5" Count="10">
        </SmithChartHorizontalMinorGridLines>
    </SmithChartHorizontalAxis>
    <SmithChartRadialAxis>
        <SmithChartRadialMajorGridLines Visible='true' Opacity='0.5' Width='5'>
        </SmithChartRadialMajorGridLines>
        <SmithChartRadialMinorGridLines Visible='true' DashArray="5" Count="10">
        </SmithChartRadialMinorGridLines>
    </SmithChartRadialAxis>
    <SmithChartSeriesCollection>
        <SmithChartSeries DataSource='TransmissionData' Reactance="Reactance" Resistance="Resistance">
        </SmithChartSeries>
    </SmithChartSeriesCollection>
</SfSmithChart>

@code {
    public class SmithChartData
    {
        public double? Resistance { get; set; }
        public double? Reactance { get; set; }
    };

    public List<SmithChartData> TransmissionData = new List<SmithChartData> {
        new SmithChartData { Resistance = 10, Reactance = 25 },
        new SmithChartData { Resistance = 6, Reactance = 4.5 },
        new SmithChartData { Resistance = 3.5, Reactance = 1.6 },
        new SmithChartData { Resistance = 2, Reactance = 1.2 },
        new SmithChartData { Resistance = 1, Reactance = 0.8 },
        new SmithChartData { Resistance = 0, Reactance = 0.2 }
    };
}

```

![Blazor Smith Chart with GridLines](./images/Axis/blazor-smith-chart-with-gridlines.png)

## Axis Line

The axis line is visible by default. Its visibility can be changed using the [Visible](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SmithChartHorizontalAxisLine.html#Syncfusion_Blazor_Charts_SmithChartHorizontalAxisLine_Visible) property. The following properties are available for customizing the axis line:

* [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SmithChartAxisLine.html#Syncfusion_Blazor_Charts_SmithChartAxisLine_Width) – Sets the axis line width.
* [DashArray](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SmithChartAxisLine.html#Syncfusion_Blazor_Charts_SmithChartAxisLine_DashArray) – Renders the axis line as a dashed line.
* [Visible](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SmithChartHorizontalAxisLine.html#Syncfusion_Blazor_Charts_SmithChartHorizontalAxisLine_Visible) – Enables or disables axis line visibility.
* [Color](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SmithChartAxisLine.html#Syncfusion_Blazor_Charts_SmithChartAxisLine_Color) – Sets the axis line color.

```cshtml

@using Syncfusion.Blazor.Charts

<SfSmithChart>
    <SmithChartHorizontalAxis>
        <SmithChartHorizontalAxisLine Width="2" Visible="true" DashArray="5" Color="blue">
        </SmithChartHorizontalAxisLine>
    </SmithChartHorizontalAxis>
    <SmithChartRadialAxis>
        <SmithChartRadialAxisLine Width="2" Visible="true" DashArray="5" Color="red">
        </SmithChartRadialAxisLine>
    </SmithChartRadialAxis>
    <SmithChartSeriesCollection>
        <SmithChartSeries DataSource='TransmissionData' Reactance="Reactance" Resistance="Resistance">
        </SmithChartSeries>
    </SmithChartSeriesCollection>
</SfSmithChart>

@code {
    public class SmithChartData
    {
        public double? Resistance { get; set; }
        public double? Reactance { get; set; }
    };

    public List<SmithChartData> TransmissionData = new List<SmithChartData> {
        new SmithChartData { Resistance = 10, Reactance = 25 },
        new SmithChartData { Resistance = 6, Reactance = 4.5 },
        new SmithChartData { Resistance = 3.5, Reactance = 1.6 },
        new SmithChartData { Resistance = 2, Reactance = 1.2 },
        new SmithChartData { Resistance = 1, Reactance = 0.8 },
        new SmithChartData { Resistance = 0, Reactance = 0.2 }
    };
}

```

![Blazor Smith Chart with Custom Axis Line](./images/Axis/blazor-smith-chart-custom-axis-line.png)
