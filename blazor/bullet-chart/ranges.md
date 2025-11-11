---
layout: post
title: Ranges in Blazor Bullet Chart Component | Syncfusion
description: Checkout and learn here all about the ranges in Syncfusion Blazor Bullet Chart component and much more.
platform: Blazor
control: Bullet Chart 
documentation: ug
---

# Ranges in Blazor Bullet Chart Component

Ranges represent the quality of a specific range such as **Good**, **Bad** and **Satisfactory** in the Bullet Chart scale. The ending point of a qualitative range is specified in the [End](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BulletChartRange.html#Syncfusion_Blazor_Charts_BulletChartRange_End) property. The minimum value of a quantitative scale is considered the starting point of the first range or the previous range end point.

```cshtml
@using Syncfusion.Blazor.Charts

<SfBulletChart DataSource="@BulletChartData" ValueField="FieldValue" TargetField="TargetValue" Minimum="0" Maximum="300" Interval="50" Title="Revenue">
    <BulletChartRangeCollection>
        <BulletChartRange End=150> </BulletChartRange>
        <BulletChartRange End=250></BulletChartRange>
        <BulletChartRange End=300></BulletChartRange>
    </BulletChartRangeCollection>
</SfBulletChart>

@code{
    public class ChartData
    {
        public double FieldValue { get; set; }
        public double TargetValue { get; set; }
    }
    public List<ChartData> BulletChartData = new List<ChartData>
    {
        new ChartData { FieldValue = 270, TargetValue = 250 }
    };
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BDLUiLLiTfIkQhfG?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Ranges in Blazor Bullet Chart](images/blazor-bullet-chart-range.png)" %}

## Color customization

Enhance the readability of ranges with color and opacity. It can be applied using the [Color](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BulletChartRange.html#Syncfusion_Blazor_Charts_BulletChartRange_Color) and [Opacity](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BulletChartRange.html#Syncfusion_Blazor_Charts_BulletChartRange_Opacity) properties respectively.

```cshtml
@using Syncfusion.Blazor.Charts

<SfBulletChart DataSource="@BulletChartData" CategoryField="CategoryValue" ValueField="FieldValue" TargetField="TargetValue" Minimum="0" Maximum="100" Interval="10" Title="Sales Rate" Height="400">
    <BulletChartRangeCollection>
        <BulletChartRange End=35 Color="darkred" Opacity="0.5"></BulletChartRange>
        <BulletChartRange End=50 Color="red" Opacity="1"></BulletChartRange>
        <BulletChartRange End=75 Color="blue" Opacity="0.7"></BulletChartRange>
        <BulletChartRange End=90 Color="lightgreen" Opacity="1"></BulletChartRange>
        <BulletChartRange End=100 Color="green" Opacity="1"></BulletChartRange>
    </BulletChartRangeCollection>
</SfBulletChart>

@code{
    public class ChartData
    {
        public double FieldValue { get; set; }
        public double TargetValue { get; set; }
        public string CategoryValue { get; set; }
    }
    public List<ChartData> BulletChartData = new List<ChartData>
    {
        new ChartData { FieldValue = 55, TargetValue = 75, CategoryValue = "Year 1" },
        new ChartData { FieldValue = 70, TargetValue = 70, CategoryValue = "Year 2" },
        new ChartData { FieldValue = 85, TargetValue = 75, CategoryValue = "Year 3" }
    };
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BZBUWBrWJJHrSIXJ?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Customizing Ranges with Color in Blazor Bullet Chart](images/blazor-bullet-chart-range-customization.png)" %}