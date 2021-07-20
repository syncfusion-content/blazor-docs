---
layout: post
title: How to Do Nut in Blazor Accumulation Chart Component | Syncfusion
description: Checkout and learn about Do Nut in Blazor Accumulation Chart component of Syncfusion, and more details.
platform: Blazor
control: Accumulation Chart
documentation: ug
---

# Text placing center of the doughnut

The annotations are used to mark the specific area of interest in the chart area with texts, shapes or images.

By using the content option of annotation property, you can specify the Id of the element that needs to be displayed in the chart area.

To display the text placing center of the doughnut, `ContentTemplate` should be provided within the `AccumulationChartAnnotation` directive and create the div element inside `ContentTemplate`. we can access the div element attribute to text placing the center of the doughnut.

```
        <AccumulationChartAnnotation X="40%" Y="48%" CoordinateUnits="Units.Pixel" Region="Regions.Chart">
                <ContentTemplate>
                   <div class="donut-text">Chart Annotation</div>
                </ContentTemplate>
            </AccumulationChartAnnotation>
        </AccumulationChartAnnotations>
```

```csharp

@using Syncfusion.Blazor.Charts

<div class="col-6">
    <SfAccumulationChart>
        <AccumulationChartAnnotations>
            <AccumulationChartAnnotation X="40%" Y="48%" CoordinateUnits="Units.Pixel" Region="Regions.Chart">
                <ContentTemplate>
                    <div class="donut-text">Chart Annotation</div>
                </ContentTemplate>
            </AccumulationChartAnnotation>
        </AccumulationChartAnnotations>
        <AccumulationChartSeriesCollection>
            <AccumulationChartSeries InnerRadius="60%" Name="@nameof(MyDataModel.XValue)" DataSource="@chartData" YName="@nameof(MyDataModel.YValue)" XName="@nameof(MyDataModel.XValue)"></AccumulationChartSeries>
        </AccumulationChartSeriesCollection>
    </SfAccumulationChart>
</div>
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