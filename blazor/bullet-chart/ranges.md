---
layout: post
title: Blazor Bullet Chart Ranges Examples | Syncfusion®
description: Learn how to define qualitative ranges in Syncfusion Blazor Bullet Chart using BulletChartRangeCollection with Bad, Satisfactory, and Good values.
platform: Blazor
control: Bullet Chart
documentation: ug
---

# Blazor Bullet Chart Ranges

Ranges represent the quality of each interval, such as **Bad**, **Satisfactory**, and **Good**, on the Bullet Chart scale. The ending point of a qualitative range is specified in the [End](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BulletChartRange.html#Syncfusion_Blazor_Charts_BulletChartRange_End) property. The minimum value of the quantitative scale is the starting point of the first range, and the end point of the previous range is the starting point of each subsequent range. Set the range end points in ascending order and set the final range end point to the chart maximum to cover the entire scale.

```cshtml
@using Syncfusion.Blazor.Charts

<SfBulletChart DataSource="@BulletChartData" ValueField="FieldValue" TargetField="TargetValue" Minimum="0" Maximum="300" Interval="50" Title="Revenue">
    <BulletChartRangeCollection>
        <BulletChartRange End=150 Name="Bad"> </BulletChartRange>
        <BulletChartRange End=250 Name="Satisfactory"></BulletChartRange>
        <BulletChartRange End=300 Name="Good"></BulletChartRange>
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
{% previewsample "https://blazorplayground.syncfusion.com/embed/hXBRDbLMKraVVXSe?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Ranges in Blazor Bullet Chart](images/blazor-bullet-chart-range.webp)" %}

## Color customization

Enhance the readability of ranges with color and opacity. They can be applied using the [Color](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BulletChartRange.html#Syncfusion_Blazor_Charts_BulletChartRange_Color) and [Opacity](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BulletChartRange.html#Syncfusion_Blazor_Charts_BulletChartRange_Opacity) properties respectively.

Use the [Name](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BulletChartRange.html#Syncfusion_Blazor_Charts_BulletChartRange_Name) property to specify the range name displayed in the legend. The [Shape](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BulletChartRange.html#Syncfusion_Blazor_Charts_BulletChartRange_Shape) property customizes the legend symbol for the range.

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
{% previewsample "https://blazorplayground.syncfusion.com/embed/LjrnDHCLBCIkyJWS?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Customizing Ranges with Color in Blazor Bullet Chart](images/blazor-bullet-chart-range-customization.webp)" %}