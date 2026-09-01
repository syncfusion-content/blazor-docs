---
layout: post
title: Blazor Bullet Chart Actual Bar Examples | Syncfusion®
description: Learn how to render the actual bar (feature measure) in Syncfusion Blazor Bullet Chart by mapping ValueField to your data source.
platform: Blazor
control: Bullet Chart
documentation: ug
---

# Blazor Bullet Chart Actual Bar

The primary or current value being measured is known as the **Feature Measure**. In the Bullet Chart, it is displayed as the **Actual Bar** (also called the **Feature Bar**). To display the actual bar, map the [ValueField](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfBulletChart-1.html#Syncfusion_Blazor_Charts_SfBulletChart_1_ValueField) property to the appropriate field in the data source.

```cshtml
@using Syncfusion.Blazor.Charts

<SfBulletChart DataSource="@BulletChartData" ValueField="FieldValue" Minimum="0" Maximum="30" Interval="5">
    <BulletChartRangeCollection>
        <BulletChartRange End=20> </BulletChartRange>
        <BulletChartRange End=25></BulletChartRange>
        <BulletChartRange End=30></BulletChartRange>
    </BulletChartRangeCollection>
</SfBulletChart>

@code{
    public class ChartData
    {
        public double FieldValue { get; set; }
    }
    public List<ChartData> BulletChartData = new List<ChartData>
    {
        new ChartData { FieldValue = 23}
    };
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BjVRXHiLBCQqHDVF?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Actual Bar in Blazor Bullet Chart](images/blazor-bullet-chart-actual-bar.webp)" %}

## Types of actual bar

The shape of the actual bar can be customized using the [Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfBulletChart-1.html#Syncfusion_Blazor_Charts_SfBulletChart_1_Type) property of the Bullet Chart. The actual bar supports [Rect](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.FeatureType.html#Syncfusion_Blazor_Charts_FeatureType_Rect) and [Dot](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.FeatureType.html#Syncfusion_Blazor_Charts_FeatureType_Dot) shapes. Use `Rect` for a bar and `Dot` for a point-style feature measure. The default shape is [Rect](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.FeatureType.html#Syncfusion_Blazor_Charts_FeatureType_Rect).

```cshtml
@using Syncfusion.Blazor.Charts

<SfBulletChart DataSource="@BulletChartData" Type="FeatureType.Dot" ValueField="FieldValue" Minimum="0" Maximum="30" Interval="5">
    <BulletChartRangeCollection>
        <BulletChartRange End=20> </BulletChartRange>
        <BulletChartRange End=25></BulletChartRange>
        <BulletChartRange End=30></BulletChartRange>
    </BulletChartRangeCollection>
</SfBulletChart>

@code{
    public class ChartData
    {
        public double FieldValue { get; set; }
    }
    public List<ChartData> BulletChartData = new List<ChartData>
    {
        new ChartData { FieldValue = 23}
    };
}
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/LZrdDdsrLiQORPQW?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Blazor Bullet Chart with Dot Actual Bar](images/blazor-bullet-chart-dot-actual-bar.webp)" %}

## Actual bar customization

The following settings customize the actual bar.

* [ValueFill](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfBulletChart-1.html#Syncfusion_Blazor_Charts_SfBulletChart_1_ValueFill) - Specifies the fill color of the actual bar.
* [ValueHeight](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfBulletChart-1.html#Syncfusion_Blazor_Charts_SfBulletChart_1_ValueHeight) - Specifies the height of the actual bar.
* [BulletChartValueBorder](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BulletChartValueBorder.html) - Configures the border color and width of the actual bar.

```cshtml
@using Syncfusion.Blazor.Charts

<SfBulletChart DataSource="@BulletChartData" ValueFill="lightblue" ValueHeight="15" ValueField="FieldValue" Minimum="0" Maximum="30" Interval="5">
    <BulletChartValueBorder Color="red" Width="1"></BulletChartValueBorder>
    <BulletChartRangeCollection>
        <BulletChartRange End=20></BulletChartRange>
        <BulletChartRange End=25></BulletChartRange>
        <BulletChartRange End=30></BulletChartRange>
    </BulletChartRangeCollection>
</SfBulletChart>

@code{
    public class ChartData
    {
        public double FieldValue { get; set; }
    }
    public List<ChartData> BulletChartData = new List<ChartData>
    {
        new ChartData { FieldValue = 23}
    };
}
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/BDBRZxiBLWPdiIUb?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Customizing Actual Bar in Blazor Bullet Chart](images/blazor-bullet-chart-actual-bar-customization.webp)" %}