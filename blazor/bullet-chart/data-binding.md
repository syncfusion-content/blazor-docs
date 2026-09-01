---
layout: post
title: Blazor Bullet Chart Working with Data Example | Syncfusion®
description: Learn how to bind data to Syncfusion Blazor Bullet Chart using DataSource, ValueField, TargetField, and CategoryField with a code sample.
platform: Blazor
control: Bullet Chart
documentation: ug
---

# Blazor Bullet Chart Working with Data

The [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfBulletChart-1.html#Syncfusion_Blazor_Charts_SfBulletChart_1_DataSource) property accepts a collection of data objects used to display feature measures and compare them with target values. Map the corresponding data-source properties to the [ValueField](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfBulletChart-1.html#Syncfusion_Blazor_Charts_SfBulletChart_1_ValueField) and [TargetField](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfBulletChart-1.html#Syncfusion_Blazor_Charts_SfBulletChart_1_TargetField) properties. The [CategoryField](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfBulletChart-1.html#Syncfusion_Blazor_Charts_SfBulletChart_1_CategoryField) property maps the category labels from the data source.

In this example, `ComparativeMeasureValue` is an array, so each data item can display one or more comparative measures. Use a numeric value instead when each data item has only one target value.

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

@code{
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

If the chart does not render the expected bars or labels, verify that `ValueField`, `TargetField`, and `CategoryField` exactly match the corresponding data-source property names and that the mapped values are numeric.

{% previewsample "https://blazorplayground.syncfusion.com/embed/BXrxNnsVLCpMXlIO?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Data Binding in Blazor Bullet Chart](images/blazor-bullet-chart-data-binding.webp)" %}
