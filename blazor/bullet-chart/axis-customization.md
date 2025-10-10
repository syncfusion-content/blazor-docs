---
layout: post
title: Axis Customization in Blazor Bullet Chart Component | Syncfusion
description: Check out and learn here all about Axis Customization in Syncfusion Blazor Bullet Chart component and more.
platform: Blazor
control: Bullet Chart 
documentation: ug
---

# Axis Customization in Blazor Bullet Chart Component

## Customizing Major and Minor Tick Lines

Use the following properties to customize [MajorTickLines](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BulletChartMajorTickLines.html) and [MinorTickLines](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BulletChartMinorTickLines.html):

* **Width** – Sets the tick line width.
* **Height** – Sets the tick line height.
* **Color** – Sets the tick line color.
* **EnableRangeColor** – Applies the corresponding range color to tick lines.

```cshtml

@using Syncfusion.Blazor.Charts

<SfBulletChart DataSource="@BulletChartData" ValueField="FieldValue" TargetField="Target" Minimum="0" Maximum="30" Interval="5">
    <BulletChartMinorTickLines Width="4" Height="10" EnableRangeColor="true"></BulletChartMinorTickLines>
    <BulletChartMajorTickLines Width="5" Height="15" Color="red"></BulletChartMajorTickLines>
    <BulletChartRangeCollection>
        <BulletChartRange End=20 Color="#DBE7F3"></BulletChartRange>
        <BulletChartRange End=25 Color="#BBCEE7"></BulletChartRange>
        <BulletChartRange End=30 Color="#96B2D7"></BulletChartRange>
    </BulletChartRangeCollection>
</SfBulletChart>

@code {
    public class ChartData
    {
        public double FieldValue { get; set; }
        public double Target { get; set; }
    }

    public List<ChartData> BulletChartData = new List<ChartData>
    {
        new ChartData { FieldValue = 25, Target = 20 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BthAshrMpzsZIqTR?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Customizing Major and Minor TickLines in Blazor Bullet Chart](images/blazor-bullet-chart-tick-line-customization.png)

## Tick Placement

Major and minor ticks can be placed [inside](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.TickPosition.html#Syncfusion_Blazor_Charts_TickPosition_Inside) or [outside](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.TickPosition.html#Syncfusion_Blazor_Charts_TickPosition_Outside) the ranges using the [TickPosition](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfBulletChart-1.html#Syncfusion_Blazor_Charts_SfBulletChart_1_TickPosition) property.

```cshtml

@using Syncfusion.Blazor.Charts

<SfBulletChart DataSource="@BulletChartData" TickPosition="TickPosition.Inside" ValueField="FieldValue" TargetField="Target" Minimum="0" Maximum="30" Interval="5">
    <BulletChartRangeCollection>
        <BulletChartRange End=20></BulletChartRange>
        <BulletChartRange End=25></BulletChartRange>
        <BulletChartRange End=30></BulletChartRange>
    </BulletChartRangeCollection>
</SfBulletChart>

@code {
    public class ChartData
    {
        public double FieldValue { get; set; }
        public double Target { get; set; }
    }

    public List<ChartData> BulletChartData = new List<ChartData>
    {
        new ChartData { FieldValue = 25, Target = 20 }
    };
}

```

{% previewsample "https://blazorplayground.syncfusion.com/embed/rDVgiLVCTTsfCtyC?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Changing Tick Position in Blazor Bullet Chart](images/blazor-bullet-chart-tick-position.png)

## Label Format

Axis labels support all globalize formats and can be changed using the [Format](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfBulletChart-1.html#Syncfusion_Blazor_Charts_SfBulletChart_1_Format) property. The following example displays axis labels in currency format.

```cshtml

@using Syncfusion.Blazor.Charts

<SfBulletChart DataSource="@BulletChartData" Format="C" ValueField="FieldValue" TargetField="Target" Minimum="0" Maximum="30" Interval="5">
    <BulletChartRangeCollection>
        <BulletChartRange End=20></BulletChartRange>
        <BulletChartRange End=25></BulletChartRange>
        <BulletChartRange End=30></BulletChartRange>
    </BulletChartRangeCollection>
</SfBulletChart>

@code {
    public class ChartData
    {
        public double FieldValue { get; set; }
        public double Target { get; set; }
    }

    public List<ChartData> BulletChartData = new List<ChartData>
    {
        new ChartData { FieldValue = 25, Target = 20 }
    };
}

```

{% previewsample "https://blazorplayground.syncfusion.com/embed/VZhgMBVMpfCnRdov?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Changing Label Format in Blazor Bullet Chart](images/blazor-bullet-chart-label-format.png)

The table below shows the results of applying common formats to numeric axis values.

<!-- markdownlint-disable MD033 -->
<table>
<tr>
<td><b>Label Value</b></td>
<td><b>Label Format property value</b></td>
<td><b>Result</b></td>
<td><b>Description</b></td>
</tr>
<tr>
<td>1000</td>
<td>n1</td>
<td>1000.0</td>
<td>Rounded to 1 decimal place.</td>
</tr>
<tr>
<td>1000</td>
<td>n2</td>
<td>1000.00</td>
<td>Rounded to 2 decimal places.</td>
</tr>
<tr>
<td>1000</td>
<td>n3</td>
<td>1000.000</td>
<td>Rounded to 3 decimal places.</td>
</tr>
<tr>
<td>0.01</td>
<td>p1</td>
<td>1.0%</td>
<td>Converted to percentage with 1 decimal place.</td>
</tr>
<tr>
<td>0.01</td>
<td>p2</td>
<td>1.00%</td>
<td>Converted to percentage with 2 decimal places.</td>
</tr>
<tr>
<td>0.01</td>
<td>p3</td>
<td>1.000%</td>
<td>Converted to percentage with 3 decimal places.</td>
</tr>
<tr>
<td>1000</td>
<td>c1</td>
<td>$1000.0</td>
<td>Currency symbol appended, rounded to 1 decimal place.</td>
</tr>
<tr>
<td>1000</td>
<td>c2</td>
<td>$1000.00</td>
<td>Currency symbol appended, rounded to 2 decimal places.</td>
</tr>
</table>

## Grouping Separator

To display thousands separators, set the [EnableGroupSeparator](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfBulletChart-1.html#Syncfusion_Blazor_Charts_SfBulletChart_1_EnableGroupSeparator) property to **true** and specify the numeric axis label format using the [Format](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfBulletChart-1.html#Syncfusion_Blazor_Charts_SfBulletChart_1_Format) property as **N0**.

```cshtml

@using Syncfusion.Blazor.Charts

<SfBulletChart DataSource="@BulletChartData" EnableGroupSeparator="true" Format="N0" ValueField="FieldValue" TargetField="Target" Minimum="0" Maximum="2500" Interval="250">
    <BulletChartRangeCollection>
        <BulletChartRange End=500></BulletChartRange>
        <BulletChartRange End=1500></BulletChartRange>
        <BulletChartRange End=2500></BulletChartRange>
    </BulletChartRangeCollection>
</SfBulletChart>

@code {
    public class ChartData
    {
        public double FieldValue { get; set; }
        public double Target { get; set; }
    }

    public List<ChartData> BulletChartData = new List<ChartData>
    {
        new ChartData { FieldValue = 1500, Target = 1300 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/VthqsBLMzfBQwPJD?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Grouping in Blazor Bullet Chart](images/blazor-bullet-chart-grouping.png)

## Custom Label Format

The [LabelFormat](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfBulletChart-1.html#Syncfusion_Blazor_Charts_SfBulletChart_1_LabelFormat) property allows you to specify a custom format for axis labels. Use placeholders such as **${value}K** to represent the axis value.

```cshtml

@using Syncfusion.Blazor.Charts

<SfBulletChart DataSource="@BulletChartData" LabelFormat="${value}K" ValueField="FieldValue" TargetField="Target" Minimum="0" Maximum="2500" Interval="250">
    <BulletChartRangeCollection>
        <BulletChartRange End=500></BulletChartRange>
        <BulletChartRange End=1500></BulletChartRange>
        <BulletChartRange End=2500></BulletChartRange>
    </BulletChartRangeCollection>
</SfBulletChart>

@code {
    public class ChartData
    {
        public double FieldValue { get; set; }
        public double Target { get; set; }
    }

    public List<ChartData> BulletChartData = new List<ChartData>
    {
        new ChartData { FieldValue = 1500, Target = 1300 }
    };
}

```

{% previewsample "https://blazorplayground.syncfusion.com/embed/VDrUshVCfpgssdbx?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor Bullet Chart with Custom Label Format](images/blazor-bullet-chart-custom-label-format.png)

## Label Placement

Labels can be placed [inside](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.LabelsPlacement.html#Syncfusion_Blazor_Charts_LabelsPlacement_Inside) or [outside](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.LabelsPlacement.html#Syncfusion_Blazor_Charts_LabelsPlacement_Outside) the ranges using the [LabelPosition](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfBulletChart-1.html#Syncfusion_Blazor_Charts_SfBulletChart_1_LabelPosition) property.

```cshtml

@using Syncfusion.Blazor.Charts

<SfBulletChart DataSource="@BulletChartData" LabelPosition="LabelsPlacement.Inside" ValueField="FieldValue" TargetField="Target" Minimum="0" Maximum="30" Interval="5">
    <BulletChartRangeCollection>
        <BulletChartRange End=20></BulletChartRange>
        <BulletChartRange End=25></BulletChartRange>
        <BulletChartRange End=30></BulletChartRange>
    </BulletChartRangeCollection>
</SfBulletChart>

@code {
    public class ChartData
    {
        public double FieldValue { get; set; }
        public double Target { get; set; }
    }

    public List<ChartData> BulletChartData = new List<ChartData>
    {
        new ChartData { FieldValue = 25, Target = 20 }
    };
}

```

{% previewsample "https://blazorplayground.syncfusion.com/embed/hNLesNZUCyCVjSWv?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Changing Label Position in Blazor Bullet Chart](images/blazor-bullet-chart-labels-position.png)

## Opposed Position

To place the axis opposite its default position, set the [OpposedPosition](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfBulletChart-1.html#Syncfusion_Blazor_Charts_SfBulletChart_1_OpposedPosition) property to **true**.

```cshtml

@using Syncfusion.Blazor.Charts

<SfBulletChart DataSource="@BulletChartData" OpposedPosition="true" ValueField="FieldValue" TargetField="Target" Minimum="0" Maximum="30" Interval="5">
    <BulletChartRangeCollection>
        <BulletChartRange End=20></BulletChartRange>
        <BulletChartRange End=25></BulletChartRange>
        <BulletChartRange End=30></BulletChartRange>
    </BulletChartRangeCollection>
</SfBulletChart>

@code {
    public class ChartData
    {
        public double FieldValue { get; set; }
        public double Target { get; set; }
    }

    public List<ChartData> BulletChartData = new List<ChartData>
    {
        new ChartData { FieldValue = 25, Target = 20 }
    };
}

```

{% previewsample "https://blazorplayground.syncfusion.com/embed/VtVyMNjKCSLQrRms?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor Bullet Chart with Opposed Position](images/blazor-bullet-chart-opposed-position.png)

## Category Label

The [Bullet Chart](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfBulletChart-1.html) supports X-axis labels by specifying a property from the data source using the [CategoryField](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfBulletChart-1.html#Syncfusion_Blazor_Charts_SfBulletChart_1_CategoryField) property. This helps users interpret input data more efficiently.

```cshtml

@using Syncfusion.Blazor.Charts

<SfBulletChart DataSource="@BulletChartData" CategoryField="Category" ValueField="FieldValue" TargetField="Target" Minimum="0" Maximum="30" Interval="5">
    <BulletChartRangeCollection>
        <BulletChartRange End=20></BulletChartRange>
        <BulletChartRange End=25></BulletChartRange>
        <BulletChartRange End=30></BulletChartRange>
    </BulletChartRangeCollection>
</SfBulletChart>

@code {
    public class ChartData
    {
        public double FieldValue { get; set; }
        public double Target { get; set; }
        public string Category { get; set; }
    }
    public List<ChartData> BulletChartData = new List<ChartData>
    {
        new ChartData { FieldValue = 23, Target = 25, Category="Product A" }
    };
}

```

{% previewsample "https://blazorplayground.syncfusion.com/embed/LjhgsrViJpTWnjZN?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor Bullet Chart with Category Label](images/blazor-bullet-chart-category-label.png)

## Customizing Axis and Category Labels

Customize label color, opacity, font size, font family, font weight, and font style using the [BulletChartCategoryLabelStyle](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BulletChartCategoryLabelStyle.html) property for category labels and the [BulletChartLabelStyle](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BulletChartLabelStyle.html) property for axis labels. The [EnableRangeColor](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BulletChartCommonFont.html#Syncfusion_Blazor_Charts_BulletChartCommonFont_EnableRangeColor) property applies the corresponding range color to axis labels.

```cshtml

@using Syncfusion.Blazor.Charts

<SfBulletChart DataSource="@BulletChartData" CategoryField="Category" ValueField="FieldValue" TargetField="Target" Minimum="0" Maximum="30" Interval="5">
    <BulletChartCategoryLabelStyle Color="red" Opacity="0.8" Size="15px" FontStyle="italic"></BulletChartCategoryLabelStyle>
    <BulletChartLabelStyle Color="red" Opacity="1" Size="15px" FontStyle="italic" EnableRangeColor="true"></BulletChartLabelStyle>
    <BulletChartRangeCollection>
        <BulletChartRange End=20 Color="#959595"></BulletChartRange>
        <BulletChartRange End=25 Color="#BDBDBD"></BulletChartRange>
        <BulletChartRange End=30 Color="#E3E2E2"></BulletChartRange>
    </BulletChartRangeCollection>
</SfBulletChart>

@code {
    public class ChartData
    {
        public double FieldValue { get; set; }
        public double Target { get; set; }
        public string Category { get; set; }
    }

    public List<ChartData> BulletChartData = new List<ChartData>
    {
        new ChartData { FieldValue = 23, Target = 25, Category="Product A" }
    };
}

```

{% previewsample "https://blazorplayground.syncfusion.com/embed/rXrgWrLCzTJTgHRy?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Customizing Axis and Category Labels in Blazor Bullet Chart](images/blazor-bullet-chart-label-customization.png)
