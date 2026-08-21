---
layout: post
title: Blazor Bullet Chart Dimensions and Sizing | Syncfusion®
description: Learn how to set the size of Syncfusion Blazor Bullet Chart using container width, height, and inline CSS or Size for container.
platform: Blazor
control: Bullet Chart
documentation: ug
---



# Blazor Bullet Chart Dimensions

## Size Based on Container

The size of the [Blazor Bullet Chart](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfBulletChart-1.html) is determined by the size of its parent container. The container dimensions can be set inline or through a CSS class as follows.

```cshtml
@using Syncfusion.Blazor.Charts

<div class="bullet-chart-container">
    <SfBulletChart DataSource="@BulletChartData" ValueField="FieldValue" TargetField="Target" Minimum="0" Maximum="300" Interval="50" Title="Revenue">
        <BulletChartTooltip TValue="ChartData" Enable="true"></BulletChartTooltip>
        <BulletChartRangeCollection>
            <BulletChartRange End="150"></BulletChartRange>
            <BulletChartRange End="250"></BulletChartRange>
            <BulletChartRange End="300"></BulletChartRange>
        </BulletChartRangeCollection>
    </SfBulletChart>
</div>

@code{
    public class ChartData
    {
        public double FieldValue { get; set; }
        public double Target { get; set; }
    }
    public List<ChartData> BulletChartData = new List<ChartData>
    {
        new ChartData { FieldValue = 270, Target = 250 }
    };
}

<style>
    .bullet-chart-container {
        width: 650px;
        height: 100px;
    }
</style>
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BZBxjbhiAsTXKsTL?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" %}

## Size Using Width and Height

The [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfBulletChart-1.html#Syncfusion_Blazor_Charts_SfBulletChart_1_Width) and [Height](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfBulletChart-1.html#Syncfusion_Blazor_Charts_SfBulletChart_1_Height) properties adjust the size of the Bullet Chart. These string properties accept pixel and percentage values. When a percentage is specified, the corresponding dimension is determined by the parent container. The parent must have a defined dimension for percentage sizing to work as expected.

N> If the size is not specified, the Bullet Chart uses the default dimensions defined by the current Syncfusion Blazor package. Refer to the [Height API reference](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfBulletChart-1.html#Syncfusion_Blazor_Charts_SfBulletChart_1_Height) for the current default value.

```cshtml
@using Syncfusion.Blazor.Charts

<div style="width:1000px; height:150px;">
    <SfBulletChart DataSource="@BulletChartData" Height="70%" Width="50%" ValueField="FieldValue" TargetField="Target" Minimum="0" Maximum="300" Interval="50" Title="Revenue">
        <BulletChartTooltip TValue="ChartData" Enable="true"></BulletChartTooltip>
        <BulletChartRangeCollection>
            <BulletChartRange End="150"></BulletChartRange>
            <BulletChartRange End="250"></BulletChartRange>
            <BulletChartRange End="300"></BulletChartRange>
        </BulletChartRangeCollection>
    </SfBulletChart>
</div>

@code{
    public class ChartData
    {
        public double FieldValue { get; set; }
        public double Target { get; set; }
    }
    public List<ChartData> BulletChartData = new List<ChartData>
    {
        new ChartData { FieldValue = 270, Target = 250 }
    };
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/hZBxXFrMKsHtNqws?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" %}

## Margin

The [BulletChartMargin](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BulletChartMargin.html) customizes the bottom, left, right, and top margins of the Bullet Chart.

```cshtml
@using Syncfusion.Blazor.Charts

<div style="width: 650px; height: 100px;">
    <SfBulletChart DataSource="@BulletChartData" ValueField="FieldValue" TargetField="Target" Minimum="0" Maximum="300" Interval="50" Title="Revenue">
        <BulletChartMargin Bottom="20" Left="20" Right="20" Top="20"></BulletChartMargin>
        <BulletChartBorder Color="#000000" Width="2"></BulletChartBorder>
        <BulletChartTooltip TValue="ChartData" Enable="true"></BulletChartTooltip>
        <BulletChartRangeCollection>
            <BulletChartRange End="150"></BulletChartRange>
            <BulletChartRange End="250"></BulletChartRange>
            <BulletChartRange End="300"></BulletChartRange>
        </BulletChartRangeCollection>
    </SfBulletChart>
</div>

@code{
    public class ChartData
    {
        public double FieldValue { get; set; }
        public double Target { get; set; }
    }
    public List<ChartData> BulletChartData = new List<ChartData>
    {
        new ChartData { FieldValue = 270, Target = 250 }
    };
}
```

N> The border is included to make the margin spacing visible around the chart.

{% previewsample "https://blazorplayground.syncfusion.com/embed/hXrnZPBWgMnnJRGK?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Blazor Bullet Chart with Margin](images/blazor-bullet-chart-margin.webp)" %}