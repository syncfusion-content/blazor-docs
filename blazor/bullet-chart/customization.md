---
layout: post
title: Customization in Blazor Bullet Chart Component | Syncfusion
description: Checkout and learn here all about Customization in Syncfusion Blazor Bullet Chart component and more.
platform: Blazor
control: Bullet Chart 
documentation: ug
---

# Customization in Blazor Bullet Chart Component

## Orientation

The [Blazor Bullet Chart](https://www.syncfusion.com/blazor-components/blazor-bullet-chart) can be rendered in different orientations such as [Horizontal](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.OrientationType.html#Syncfusion_Blazor_Charts_OrientationType_Horizontal) or [Vertical](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.OrientationType.html#Syncfusion_Blazor_Charts_OrientationType_Vertical) via the [Orientation](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfBulletChart-1.html#Syncfusion_Blazor_Charts_SfBulletChart_1_Orientation) property. By default, the Bullet Chart is rendered in the [Horizontal](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.OrientationType.html#Syncfusion_Blazor_Charts_OrientationType_Horizontal) orientation.

```cshtml
@using Syncfusion.Blazor.Charts

<SfBulletChart DataSource="@BulletChartData" Orientation="OrientationType.Vertical" Width="20%" Title="Sales Rate in dollars" Subtitle="(in dollars $)" ValueField="FieldValue" TargetField="TargetValue" Minimum="0" Maximum="100" Interval="20">
    <BulletChartRangeCollection>
        <BulletChartRange End=35></BulletChartRange>
        <BulletChartRange End=50></BulletChartRange>
        <BulletChartRange End=100></BulletChartRange>
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
        new ChartData { FieldValue = 55, TargetValue = 75 }
    };
}
```

![Blazor Bullet Chart with Orientation](images/blazor-bullet-chart-orientation.png)

## Right-to-left (RTL)

The Bullet Chart supports the right-to-left rendering that can be enabled by setting the [EnableRtl](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfBulletChart-1.html#Syncfusion_Blazor_Charts_SfBulletChart_1_EnableRtl) property to **true**.

```cshtml
<SfBulletChart DataSource="@BulletChartData" EnableRtl="true" ValueField="FieldValue" TargetField="TargetValue" Minimum="0" Maximum="100" Interval="20">
    <BulletChartRangeCollection>
        <BulletChartRange End=35></BulletChartRange>
        <BulletChartRange End=50></BulletChartRange>
        <BulletChartRange End=100></BulletChartRange>
    </BulletChartRangeCollection>
</SfBulletChart>
```

N> Refer to the [code block](#orientation) to know about the property value of **BulletChartData**.

![Right to Left Flow Direction in Blazor Bullet Chart](images/blazor-bullet-chart-right-to-left-direction.png)

## Animation

The actual and the target bar supports the linear animation via the [BulletChartAnimation](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BulletChartAnimation.html) setting. The speed and the delay are controlled using the [Duration](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BulletChartAnimation.html#Syncfusion_Blazor_Charts_BulletChartAnimation_Duration) and [Delay](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BulletChartAnimation.html#Syncfusion_Blazor_Charts_BulletChartAnimation_Delay) properties respectively.

```cshtml
@using Syncfusion.Blazor.Charts

<SfBulletChart DataSource="@BulletChartData" ValueField="FieldValue" TargetField="TargetValue" Minimum="0" Maximum="100" Interval="20">
    <BulletChartAnimation Delay="0" Duration="2000"></BulletChartAnimation>
    <BulletChartRangeCollection>
        <BulletChartRange End=35></BulletChartRange>
        <BulletChartRange End=50></BulletChartRange>
        <BulletChartRange End=100></BulletChartRange>
    </BulletChartRangeCollection>
</SfBulletChart>
```

N> Refer to the [code block](#orientation) to know about the property value of **BulletChartData**.

## Theme

The Bullet Chart supports different type of themes via the [Theme](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfBulletChart-1.html#Syncfusion_Blazor_Charts_SfBulletChart_1_Theme) property.

```cshtml
@using Syncfusion.Blazor.Charts
@using Syncfusion.Blazor

<SfBulletChart DataSource="@BulletChartData" Theme="Theme.Fluent2Dark" ValueField="FieldValue" TargetField="TargetValue" Minimum="0" Maximum="100" Interval="20">
    <BulletChartRangeCollection>
        <BulletChartRange End=35></BulletChartRange>
        <BulletChartRange End=50></BulletChartRange>
        <BulletChartRange End=100></BulletChartRange>
    </BulletChartRangeCollection>
</SfBulletChart>
```

N> Refer to the [code block](#orientation) to know about the property value of **BulletChartData**.

![Applying Theme to Blazor Bullet Chart](images/blazor-bullet-chart-theme.png)

## Border

The Bullet Chart border color can be enabled by setting the [Color](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BulletChartCommonBorder.html#Syncfusion_Blazor_Charts_BulletChartCommonBorder_Color) property in the [BulletChartBorder](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfBulletChart-1.html#Syncfusion_Blazor_Charts_SfBulletChart_1_Theme), and the width of the border can be customized using the [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BulletChartCommonBorder.html#Syncfusion_Blazor_Charts_BulletChartCommonBorder_Width) property.

```cshtml
@using Syncfusion.Blazor.Charts

<SfBulletChart DataSource="@BulletChartData" Height="150px" Title="Sales Rate in dollars" Subtitle="(in dollars $)" ValueField="FieldValue" TargetField="TargetValue" Minimum="0" Maximum="100" Interval="20">
    <BulletChartBorder Color="red" Width="2"></BulletChartBorder>
    <BulletChartRangeCollection>
        <BulletChartRange End=35> </BulletChartRange>
        <BulletChartRange End=50></BulletChartRange>
        <BulletChartRange End=100></BulletChartRange>
    </BulletChartRangeCollection>
</SfBulletChart>
```

N> Refer to the [code block](#orientation) to know about the property value of **BulletChartData**.

![Blazor Bullet Chart with Border](images/blazor-bullet-chart-with-border.png)