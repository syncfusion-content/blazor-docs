---
layout: post
title: Working with Data in Blazor Bullet Chart Component | Syncfusion
description: Check out and learn how to bind data, configure value and target fields, and display multiple measures in Syncfusion Blazor Bullet Chart component.
platform: Blazor
control: Bullet Chart 
documentation: ug
---

# Working with Data in Blazor Bullet Chart Component

The [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfBulletChart-1.html#Syncfusion_Blazor_Charts_SfBulletChart_1_DataSource) property allows you to bind a collection of data to the Bullet Chart, enabling the visualization of actual and target measures. To display the actual and target bars, assign the appropriate properties from your data source to the [ValueField](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfBulletChart-1.html#Syncfusion_Blazor_Charts_SfBulletChart_1_ValueField) and [TargetField](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfBulletChart-1.html#Syncfusion_Blazor_Charts_SfBulletChart_1_TargetField) properties. The component also supports multiple comparative measures for each data point.

```cshtml

@using Syncfusion.Blazor.Charts

<SfBulletChart DataSource="@InputData" ValueField="FieldValue" TargetField="ComparativeMeasureValue" CategoryField="Category" Height="400" Minimum="0" Maximum="20" Interval="5" Title="Profit in %">
    <BulletChartMinorTickLines Width="0"></BulletChartMinorTickLines>
    <BulletChartRangeCollection>
        <BulletChartRange End=5> </BulletChartRange>
        <BulletChartRange End=15></BulletChartRange>
        <BulletChartRange End=20></BulletChartRange>
    </BulletChartRangeCollection>
</SfBulletChart>

@code {
    public class BulletChartData
    {
        public double FieldValue { get; set; }
        public double[] ComparativeMeasureValue { get; set; }
        public string Category { get; set; }
    }

    public List<BulletChartData> InputData = new List<BulletChartData>
    {
        new BulletChartData { FieldValue = 5, ComparativeMeasureValue = new double[] { 7.5 }, Category = "2001" },
        new BulletChartData { FieldValue = 7, ComparativeMeasureValue = new double[] { 5 }, Category = "2002" },
        new BulletChartData { FieldValue = 10, ComparativeMeasureValue = new double[] { 6 }, Category = "2003" },
        new BulletChartData { FieldValue = 5, ComparativeMeasureValue = new double[] { 8 }, Category = "2004" },
        new BulletChartData { FieldValue = 12, ComparativeMeasureValue = new double[] { 5, 6, 9 }, Category = "2005" },
        new BulletChartData { FieldValue = 8, ComparativeMeasureValue = new double[] { 6, 7 }, Category = "2006" }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/VtVKshVizpSfJRvO?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Data Binding in Blazor Bullet Chart](images/blazor-bullet-chart-data-binding.png)
