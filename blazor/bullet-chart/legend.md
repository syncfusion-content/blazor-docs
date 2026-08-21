---
layout: post
title: Blazor Bullet Chart Legend Configuration Examples | Syncfusion®
description: Learn how to enable and customize the legend in Syncfusion Blazor Bullet Chart, including position, alignment, and BulletChartLegendSettings.
platform: Blazor
control: Bullet Chart
documentation: ug
---

# Blazor Bullet Chart Legend

The legend provides valuable information for interpreting what the Bullet Chart displays. Legend items can be represented using various colors, positions, shapes, or other identifiers based on the data. Enable the legend by setting the [Visible](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BulletChartLegendSettings.html#Syncfusion_Blazor_Charts_BulletChartLegendSettings_Visible) property to **true** in the [BulletChartLegendSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BulletChartLegendSettings.html).

```cshtml
@using Syncfusion.Blazor.Charts

<SfBulletChart DataSource="@BulletChartData" Height="300px" Title="Sales Rate" ValueField="FieldValue" TargetField="TargetValue" Minimum="0" Maximum="100" Interval="20">
    <BulletChartLegendSettings Visible="true"></BulletChartLegendSettings>
    <BulletChartRangeCollection>
        <BulletChartRange End="35" Name="Poor"></BulletChartRange>
        <BulletChartRange End="50" Name="Average"></BulletChartRange>
        <BulletChartRange End="100" Name="Good"></BulletChartRange>
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
        new ChartData { FieldValue = 55, TargetValue = 75 },
        new ChartData { FieldValue = 45, TargetValue = 15 },
        new ChartData { FieldValue = 75, TargetValue = 35 }
    };
}
```

![Legend in Blazor Bullet Chart](images/blazor-bullet-chart-legend.webp)

## Legend items from color mapping

Legend items are rendered based on the ranges in the Bullet Chart. The legend item's name can be determined from the [Name](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BulletChartRange.html#Syncfusion_Blazor_Charts_BulletChartRange_Name) property, and the shape of the legend item can be customized using the [Shape](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BulletChartRange.html#Syncfusion_Blazor_Charts_BulletChartRange_Shape) property in the [BulletChartRange](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BulletChartRange.html). By default, the legend item is rendered using the [Rectangle](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.LegendShape.html) shape.

Legend items can be customized using the following properties.

* [Padding](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BulletChartLegendSettings.html#Syncfusion_Blazor_Charts_BulletChartLegendSettings_Padding) - Specifies the padding between the legend items.
* [ShapeHeight](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BulletChartLegendSettings.html#Syncfusion_Blazor_Charts_BulletChartLegendSettings_ShapeHeight) - Specifies the shape height of the legend items.
* [ShapeWidth](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BulletChartLegendSettings.html#Syncfusion_Blazor_Charts_BulletChartLegendSettings_ShapeWidth) - Specifies the shape width of the legend items.
* [ShapePadding](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BulletChartLegendSettings.html#Syncfusion_Blazor_Charts_BulletChartLegendSettings_ShapePadding) - Specifies the padding between the shape and the text of the legend item.
* [TabIndex](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BulletChartLegendSettings.html#Syncfusion_Blazor_Charts_BulletChartLegendSettings_TabIndex) - Specifies the tab index of the legend.
* [BulletChartLegendTextStyle](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BulletChartLegendTextStyle.html) - Specifies the text style of the legend item.

```cshtml
@using Syncfusion.Blazor.Charts

<SfBulletChart DataSource="@BulletChartData" Height="300px" Title="Sales Rate" ValueField="FieldValue" TargetField="TargetValue" Minimum="0" Maximum="100" Interval="20">
    <BulletChartLegendSettings Visible="true"></BulletChartLegendSettings>
    <BulletChartRangeCollection>
        <BulletChartRange End="35" Name="Apple"></BulletChartRange>
        <BulletChartRange End="50" Name="Mango" Color="lightgreen" Shape="LegendShape.Pentagon"></BulletChartRange>
        <BulletChartRange End="100" Name="Papaya"></BulletChartRange>
    </BulletChartRangeCollection>
</SfBulletChart>
```

N> The **BulletChartData** definition is included in the first example.

![Customizing Legend Items with Color Mapping in Blazor Bullet Chart](images/blazor-bullet-chart-legend-color-mapping.webp)

## Legend size

Customize the legend size by modifying the [Height](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BulletChartLegendSettings.html#Syncfusion_Blazor_Charts_BulletChartLegendSettings_Height) and the [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BulletChartLegendSettings.html#Syncfusion_Blazor_Charts_BulletChartLegendSettings_Width) properties in the [BulletChartLegendSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BulletChartLegendSettings.html). These properties accept percentage and pixel values.

```cshtml
@using Syncfusion.Blazor.Charts

<SfBulletChart DataSource="@BulletChartData" Height="300px" Title="Sales Rate" ValueField="FieldValue" TargetField="TargetValue" Minimum="0" Maximum="100" Interval="20">
    <BulletChartLegendSettings Visible="true" Width="50%" Height="40px"></BulletChartLegendSettings>
    <BulletChartRangeCollection>
        <BulletChartRange End="35" Name="Apple"></BulletChartRange>
        <BulletChartRange End="50" Name="Mango" Color="lightgreen" Shape="LegendShape.Pentagon"></BulletChartRange>
        <BulletChartRange End="100" Name="Papaya"></BulletChartRange>
    </BulletChartRangeCollection>
</SfBulletChart>
```

N> The **BulletChartData** definition is included in the first example.

![Customizing Legend Size in Blazor Bullet Chart](images/blazor-bullet-chart-legend-size.webp)

## Legend with paging support

Bullet Chart supports legend paging when the legend items cannot be placed within the provided [Height](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BulletChartLegendSettings.html#Syncfusion_Blazor_Charts_BulletChartLegendSettings_Height) and [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BulletChartLegendSettings.html#Syncfusion_Blazor_Charts_BulletChartLegendSettings_Width) of the legend.

```cshtml
@using Syncfusion.Blazor.Charts

<SfBulletChart DataSource="@BulletChartData" Height="300px" Title="Sales Rate" ValueField="FieldValue" TargetField="TargetValue" Minimum="0" Maximum="100" Interval="20">
    <BulletChartLegendSettings Visible="true" Width="15%" Height="15%">
        <BulletChartLegendBorder Color="red" Width="1"></BulletChartLegendBorder>
    </BulletChartLegendSettings>
    <BulletChartRangeCollection>
        <BulletChartRange End="35" Name="Apple"></BulletChartRange>
        <BulletChartRange End="50" Name="Mango" Color="lightgreen" Shape="LegendShape.Pentagon"></BulletChartRange>
        <BulletChartRange End="100" Name="Papaya"></BulletChartRange>
    </BulletChartRangeCollection>
</SfBulletChart>
```

N> The **BulletChartData** definition is included in the first example.

![Legend with Paging in Blazor Bullet Chart](images/blazor-bullet-chart-legend-paging.webp)

## Position and alignment

The legend can be placed in various positions and the following options are available to customize the legend position using the [Position](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BulletChartLegendSettings.html#Syncfusion_Blazor_Charts_BulletChartLegendSettings_Position) property:

* [Auto](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.LegendPosition.html#Syncfusion_Blazor_Charts_LegendPosition_Auto)
* [Bottom](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.LegendPosition.html#Syncfusion_Blazor_Charts_LegendPosition_Bottom)
* [Top](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.LegendPosition.html#Syncfusion_Blazor_Charts_LegendPosition_Top)
* [Left](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.LegendPosition.html#Syncfusion_Blazor_Charts_LegendPosition_Left)
* [Right](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.LegendPosition.html#Syncfusion_Blazor_Charts_LegendPosition_Right)
* [Custom](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.LegendPosition.html#Syncfusion_Blazor_Charts_LegendPosition_Custom)

The following code example demonstrates the top legend position.

```cshtml
@using Syncfusion.Blazor.Charts

<SfBulletChart DataSource="@BulletChartData" Height="300px" ValueField="FieldValue" TargetField="TargetValue" Minimum="0" Maximum="100" Interval="20">
    <BulletChartLegendSettings Height="40px" Visible="true" Position="LegendPosition.Top"></BulletChartLegendSettings>
    <BulletChartRangeCollection>
        <BulletChartRange End="35" Name="Apple"></BulletChartRange>
        <BulletChartRange End="50" Name="Mango" Color="lightgreen" Shape="LegendShape.Pentagon"></BulletChartRange>
        <BulletChartRange End="100" Name="Papaya"></BulletChartRange>
    </BulletChartRangeCollection>
</SfBulletChart>
```

N> The **BulletChartData** definition is included in the first example.

![Blazor Bullet Chart displays Legend on Top Position](images/blazor-bullet-chart-legend-on-top-position.webp)

The [Auto](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.LegendPosition.html#Syncfusion_Blazor_Charts_LegendPosition_Auto) position renders the legend at the [Bottom](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.LegendPosition.html#Syncfusion_Blazor_Charts_LegendPosition_Bottom) of the component with a responsive height. The [Custom](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.LegendPosition.html#Syncfusion_Blazor_Charts_LegendPosition_Custom) position uses the x and y coordinates specified by the [X](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BulletChartLegendLocation.html#Syncfusion_Blazor_Charts_BulletChartLegendLocation_X) and [Y](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BulletChartLegendLocation.html#Syncfusion_Blazor_Charts_BulletChartLegendLocation_Y) properties in the [BulletChartLegendLocation](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BulletChartLegendLocation.html).

The following code example demonstrates the [Custom](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.LegendPosition.html#Syncfusion_Blazor_Charts_LegendPosition_Custom) legend position.

```cshtml
@using Syncfusion.Blazor.Charts

<SfBulletChart DataSource="@BulletChartData" Height="300px" ValueField="FieldValue" TargetField="TargetValue" Minimum="0" Maximum="100" Interval="20">
    <BulletChartMargin Top="30"></BulletChartMargin>
    <BulletChartLegendSettings Height="40px" Visible="true" Position="LegendPosition.Custom">
        <BulletChartLegendLocation X="5" Y="0"></BulletChartLegendLocation>
    </BulletChartLegendSettings>
    <BulletChartRangeCollection>
        <BulletChartRange End="35" Name="Apple"></BulletChartRange>
        <BulletChartRange End="50" Name="Mango" Color="lightgreen" Shape="LegendShape.Pentagon"></BulletChartRange>
        <BulletChartRange End="100" Name="Papaya"></BulletChartRange>
    </BulletChartRangeCollection>
</SfBulletChart>
```

N> The **BulletChartData** definition is included in the first example.

![Blazor Bullet Chart displays Legend on Custom position](images/blazor-bullet-chart-legend-on-custom-position.webp)

The legend alignment is used to align the legend items to the specific location. The following options are available to customize using the [Alignment](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BulletChartLegendSettings.html#Syncfusion_Blazor_Charts_BulletChartLegendSettings_Alignment) property:

* [Near](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.Alignment.html#Syncfusion_Blazor_Charts_Alignment_Near)
* [Center](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.Alignment.html#Syncfusion_Blazor_Charts_Alignment_Center)
* [Far](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.Alignment.html#Syncfusion_Blazor_Charts_Alignment_Far)

The following code example demonstrates legend item alignment.

```cshtml
@using Syncfusion.Blazor.Charts

<SfBulletChart DataSource="@BulletChartData" Height="300px" ValueField="FieldValue" TargetField="TargetValue" Minimum="0" Maximum="100" Interval="20">
    <BulletChartLegendSettings Height="40px" Visible="true" Position="LegendPosition.Top" Alignment="Alignment.Near"></BulletChartLegendSettings>
    <BulletChartRangeCollection>
        <BulletChartRange End="35" Name="Apple"></BulletChartRange>
        <BulletChartRange End="50" Name="Mango" Color="lightgreen" Shape="LegendShape.Pentagon"></BulletChartRange>
        <BulletChartRange End="100" Name="Papaya"></BulletChartRange>
    </BulletChartRangeCollection>
</SfBulletChart>
```

N> The **BulletChartData** definition is included in the first example.

![Changing Legend Item Alignment in Blazor Bullet Chart](images/blazor-bullet-chart-legend-alignment.webp)

## Customization

The legend can be customized using the following properties:

* [Background](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BulletChartLegendSettings.html#Syncfusion_Blazor_Charts_BulletChartLegendSettings_Background) - Specifies the fill color of the legend.
* [Opacity](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BulletChartLegendSettings.html#Syncfusion_Blazor_Charts_BulletChartLegendSettings_Opacity) - Specifies the opacity of the legend background.
* [BulletChartLegendMargin](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BulletChartLegendMargin.html) - Specifies the bottom, left, right, and top margin of the legend.
* [BulletChartLegendBorder](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BulletChartLegendBorder.html) - Specifies the color and the width of the legend border.

```cshtml
@using Syncfusion.Blazor.Charts

<SfBulletChart DataSource="@BulletChartData" Height="300px" ValueField="FieldValue" TargetField="TargetValue" Minimum="0" Maximum="100" Interval="20">
    <BulletChartLegendSettings Height="40px" Visible="true" Position="LegendPosition.Top" Background="lightgray" Opacity="0.4" ShapeHeight="15" ShapeWidth="15">
        <BulletChartLegendMargin Top="5"></BulletChartLegendMargin>
        <BulletChartLegendTextStyle Size="15px" Color="red" Opacity="1" FontStyle="italic"></BulletChartLegendTextStyle>
        <BulletChartLegendBorder Color="#000000" Width="2"></BulletChartLegendBorder>
    </BulletChartLegendSettings>
    <BulletChartRangeCollection>
        <BulletChartRange End="35" Name="Apple"></BulletChartRange>
        <BulletChartRange End="50" Name="Mango" Shape="LegendShape.Pentagon"></BulletChartRange>
        <BulletChartRange End="100" Name="Papaya"></BulletChartRange>
    </BulletChartRangeCollection>
</SfBulletChart>
```

N> The **BulletChartData** definition is included in the first example.

![Customizing Legend Items in Blazor Bullet Chart](images/blazor-bullet-chart-legend-customization.webp)