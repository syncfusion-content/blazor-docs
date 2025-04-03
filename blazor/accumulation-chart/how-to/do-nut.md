---
layout: post
title: Text placing center of Blazor Doughnut Chart Component | Syncfusion
description: Learn here all about Text placing center of the doughnut in Syncfusion Blazor Accumulation Chart component and more.
platform: Blazor
control: Accumulation Chart
documentation: ug
---

# Text placing center of the Blazor Doughnut Chart Component

The annotation is used to place text, shapes or images in the center of the doughnut chart.

The [AccumulationChartAnnotation](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartAnnotation.html) property allows to add annotations to the chart. Specify the content that needs to be displayed in the accumulation chart area by using the [ContentTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartAnnotation.html#Syncfusion_Blazor_Charts_AccumulationChartAnnotation_ContentTemplate) property of the annotation.

**Step 1:**

Render a doughnut chart with the required series using the [ChartSeriesCollection](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeriesCollection.html).

```cshtml
<AccumulationChartSeriesCollection>
        <AccumulationChartSeries InnerRadius="60%" Name="@nameof(MyDataModel.XValue)" DataSource="@chartData" 
                                YName="@nameof(MyDataModel.YValue)" XName="@nameof(MyDataModel.XValue)">
        </AccumulationChartSeries>
</AccumulationChartSeriesCollection>
```

**Step 2:**

Create a div element inside the [ContentTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartAnnotation.html#Syncfusion_Blazor_Charts_AccumulationChartAnnotation_ContentTemplate) to display the text placing the centre of the doughnut.

```cshtml
<AccumulationChartAnnotation>
        <ContentTemplate>
            <div class="donut-text">Chart Annotation</div>
        </ContentTemplate>
    </AccumulationChartAnnotation>
</AccumulationChartAnnotations>
```

**Step 3:**

Since the text need to be placed in the center of the doughnut chart the [Region](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartAnnotation.html#Syncfusion_Blazor_Charts_AccumulationChartAnnotation_Region) property need to be set to **Regions.Chart**. Specify the [CoordinateUnits](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartAnnotation.html#Syncfusion_Blazor_Charts_AccumulationChartAnnotation_CoordinateUnits) in [Pixel](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.Units.html#Syncfusion_Blazor_Charts_Units_Pixel) and set the X and Y coordinate values in percentage as shown in the following.

```cshtml
<AccumulationChartAnnotations>
        <AccumulationChartAnnotation X="50%" Y="50%" CoordinateUnits="Units.Pixel" Region="Regions.Chart">
        <ContentTemplate>
                <div class="donut-text">Chart Annotation</div>
        </ContentTemplate>
        </AccumulationChartAnnotation>
</AccumulationChartAnnotations>
```
The complete code snippet for the preceding steps is as follows.

```cshtml 

@using Syncfusion.Blazor.Charts

<SfAccumulationChart>
    <AccumulationChartLegendSettings Visible="false"></AccumulationChartLegendSettings>

    <AccumulationChartAnnotations>
        <AccumulationChartAnnotation X="50%" Y="50%" CoordinateUnits="Units.Pixel" Region="Regions.Chart">
            <ContentTemplate>
                <div class="donut-text">Chart Annotation</div>
            </ContentTemplate>
        </AccumulationChartAnnotation>
    </AccumulationChartAnnotations>

    <AccumulationChartSeriesCollection>
        <AccumulationChartSeries InnerRadius="60%" Name="@nameof(MyDataModel.XValue)" DataSource="@chartData" YName="@nameof(MyDataModel.YValue)" XName="@nameof(MyDataModel.XValue)"></AccumulationChartSeries>
    </AccumulationChartSeriesCollection>
</SfAccumulationChart>

<style>
    .donut-text {
        align-content: center;
    }
</style>

@code {
    public class MyDataModel
    {
        public int XValue { get; set; }
        public int YValue { get; set; }
    }
    private Random rnd = new Random();
    public List<MyDataModel> chartData = new List<MyDataModel>();

    protected override async Task OnInitializedAsync()
    {
        for (int i = 0; i < 4; i++)
        {
            chartData.Add(new MyDataModel() { XValue = i, YValue = rnd.Next(10, 100) });
        }
    }
}

```

{% previewsample "https://blazorplayground.syncfusion.com/embed/hjhAMLCziQTKvjhv?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

N> Refer to the [Blazor Charts](https://www.syncfusion.com/blazor-components/blazor-charts) feature tour page for its groundbreaking feature representations and also explore the [Blazor Accumulation Chart Example](https://blazor.syncfusion.com/demos/chart/pie?theme=bootstrap5) to know about the various features of accumulation charts and how it is used to represent numeric proportional data.
