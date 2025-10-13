---
layout: post
title: Legend in Blazor Bullet Chart Component | Syncfusion
description: Check out and learn how to configure and customize Legend in Syncfusion Blazor Bullet Chart component.
platform: Blazor
control: Bullet Chart 
documentation: ug
---

# Legend in Blazor Bullet Chart Component

Legends provide essential information for interpreting the Bullet Chart. Legends can be displayed in various colors, positions, shapes, or other identifiers based on the data. Enable the legend by setting the [Visible](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BulletChartLegendSettings.html#Syncfusion_Blazor_Charts_BulletChartLegendSettings_Visible) property to **true** in [BulletChartLegendSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BulletChartLegendSettings.html).

```cshtml

@using Syncfusion.Blazor.Charts

<SfBulletChart DataSource="@BulletChartData" Height="300px" Title="Sales Rate" ValueField="FieldValue" TargetField="TargetValue" Minimum="0" Maximum="100" Interval="20">
    <BulletChartLegendSettings Visible="true"></BulletChartLegendSettings>
    <BulletChartRangeCollection>
        <BulletChartRange End=35></BulletChartRange>
        <BulletChartRange End=50></BulletChartRange>
        <BulletChartRange End=100></BulletChartRange>
    </BulletChartRangeCollection>
</SfBulletChart>

@code {
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

![Legend in Blazor Bullet Chart](images/blazor-bullet-chart-legend.png)

## Legend Items

Legend items are rendered based on the mapping ranges in the Bullet Chart. The legend item's name is set using the [Name](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BulletChartRange.html#Syncfusion_Blazor_Charts_BulletChartRange_Name) property, and the shape can be customized with the [Shape](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BulletChartRange.html#Syncfusion_Blazor_Charts_BulletChartRange_Shape) property in [BulletChartRange](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BulletChartRange.html). By default, the legend item uses the [Rectangle](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.LegendShape.html) shape.

Customize legend items with these properties:

* [Padding](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BulletChartLegendSettings.html#Syncfusion_Blazor_Charts_BulletChartLegendSettings_Padding) – Sets the padding between legend items.
* [ShapeHeight](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BulletChartLegendSettings.html#Syncfusion_Blazor_Charts_BulletChartLegendSettings_ShapeHeight) – Sets the legend item shape height.
* [ShapeWidth](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BulletChartLegendSettings.html#Syncfusion_Blazor_Charts_BulletChartLegendSettings_ShapeWidth) – Sets the legend item shape width.
* [ShapePadding](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BulletChartLegendSettings.html#Syncfusion_Blazor_Charts_BulletChartLegendSettings_ShapePadding) – Sets the padding between the shape and the legend text.
* [BulletChartLegendTextStyle](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BulletChartLegendTextStyle.html) – Sets the legend item text style.

```cshtml

@using Syncfusion.Blazor.Charts

<SfBulletChart DataSource="@BulletChartData" Height="300px" Title="Sales Rate" ValueField="FieldValue" TargetField="TargetValue" Minimum="0" Maximum="100" Interval="20">
    <BulletChartLegendSettings Visible="true"></BulletChartLegendSettings>
    <BulletChartRangeCollection>
        <BulletChartRange End=35 Name="Apple"></BulletChartRange>
        <BulletChartRange End=50 Name="Mango" Color="lightgreen" Shape="LegendShape.Pentagon"></BulletChartRange>
        <BulletChartRange End=100 Name="Papaya"></BulletChartRange>
    </BulletChartRangeCollection>
</SfBulletChart>

```

N> Refer to the [code block](#legend-in-blazor-bullet-chart-component) to know the property value of the **BulletChartData**.

![Customizing Legend Items with Color Mapping in Blazor Bullet Chart](images/blazor-bullet-chart-legend-color-mapping.png)

## Legend Size

Adjust the legend size using the [Height](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BulletChartLegendSettings.html#Syncfusion_Blazor_Charts_BulletChartLegendSettings_Height) and [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BulletChartLegendSettings.html#Syncfusion_Blazor_Charts_BulletChartLegendSettings_Width) properties in [BulletChartLegendSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BulletChartLegendSettings.html). Both percentage and pixel values are supported.

```cshtml
@using Syncfusion.Blazor.Charts

<SfBulletChart DataSource="@BulletChartData" Height="300px" Title="Sales Rate" ValueField="FieldValue" TargetField="TargetValue" Minimum="0" Maximum="100" Interval="20">
    <BulletChartLegendSettings Visible="true" Width="15%"></BulletChartLegendSettings>
    <BulletChartRangeCollection>
        <BulletChartRange End=35 Name="Apple"></BulletChartRange>
        <BulletChartRange End=50 Name="Mango" Color="lightgreen" Shape="LegendShape.Pentagon"></BulletChartRange>
        <BulletChartRange End=100 Name="Papaya"></BulletChartRange>
    </BulletChartRangeCollection>
</SfBulletChart>
```

N> Refer to the [code block](#legend-in-blazor-bullet-chart-component) to know about the property value of the **BulletChartData**.

![Customizing Legend Size in Blazor Bullet Chart](images/blazor-bullet-chart-legend-size.png)

## Legend with Paging Support

If legend items cannot fit within the specified [Height](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BulletChartLegendSettings.html#Syncfusion_Blazor_Charts_BulletChartLegendSettings_Height) and [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BulletChartLegendSettings.html#Syncfusion_Blazor_Charts_BulletChartLegendSettings_Width), paging is enabled automatically.

```cshtml

@using Syncfusion.Blazor.Charts

<SfBulletChart DataSource="@BulletChartData" Height="300px" Title="Sales Rate" ValueField="FieldValue" TargetField="TargetValue" Minimum="0" Maximum="100" Interval="20">
    <BulletChartLegendSettings Visible="true" Width="15%" Height="15%">
        <BulletChartLegendBorder Color="red" Width="1"></BulletChartLegendBorder>
    </BulletChartLegendSettings>
    <BulletChartRangeCollection>
        <BulletChartRange End=35 Name="Apple"></BulletChartRange>
        <BulletChartRange End=50 Name="Mango" Color="lightgreen" Shape="LegendShape.Pentagon"></BulletChartRange>
        <BulletChartRange End=100 Name="Papaya"></BulletChartRange>
    </BulletChartRangeCollection>
</SfBulletChart>

```

N> Refer to the [code block](#legend-in-blazor-bullet-chart-component) to know about the property value of the **BulletChartData**.

![Legend with Paging in Blazor Bullet Chart](images/blazor-bullet-chart-legend-paging.png)

## Position and Alignment

Set the legend position using the [Position](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BulletChartLegendSettings.html#Syncfusion_Blazor_Charts_BulletChartLegendSettings_Position) property. Options include:

* [Auto](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.LegendPosition.html#Syncfusion_Blazor_Charts_LegendPosition_Auto)
* [Bottom](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.LegendPosition.html#Syncfusion_Blazor_Charts_LegendPosition_Bottom)
* [Top](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.LegendPosition.html#Syncfusion_Blazor_Charts_LegendPosition_Top)
* [Left](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.LegendPosition.html#Syncfusion_Blazor_Charts_LegendPosition_Left)
* [Right](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.LegendPosition.html#Syncfusion_Blazor_Charts_LegendPosition_Right)
* [Custom](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.LegendPosition.html#Syncfusion_Blazor_Charts_LegendPosition_Custom)

The following example demonstrates the top legend position.

```cshtml

@using Syncfusion.Blazor.Charts

<SfBulletChart DataSource="@BulletChartData" Height="300px" ValueField="FieldValue" TargetField="TargetValue" Minimum="0" Maximum="100" Interval="20">
    <BulletChartLegendSettings Height="40px" Visible="true" Position="LegendPosition.Top"></BulletChartLegendSettings>
    <BulletChartRangeCollection>
        <BulletChartRange End=35 Name="Apple"></BulletChartRange>
        <BulletChartRange End=50 Name="Mango" Color="lightgreen" Shape="LegendShape.Pentagon"></BulletChartRange>
        <BulletChartRange End=100 Name="Papaya"></BulletChartRange>
    </BulletChartRangeCollection>
</SfBulletChart>

```

N> Refer to the [code block](#legend-in-blazor-bullet-chart-component) to know about the property value of the **BulletChartData**.

![Blazor Bullet Chart displays Legend on Top Position](images/blazor-bullet-chart-legend-on-top-position.png)

The [Auto](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.LegendPosition.html#Syncfusion_Blazor_Charts_LegendPosition_Auto) position renders the legend at the bottom of the component with responsive height. The [Custom](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.LegendPosition.html#Syncfusion_Blazor_Charts_LegendPosition_Custom) position uses the [X](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BulletChartLegendLocation.html#Syncfusion_Blazor_Charts_BulletChartLegendLocation_X) and [Y](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BulletChartLegendLocation.html#Syncfusion_Blazor_Charts_BulletChartLegendLocation_Y) properties in [BulletChartLegendLocation](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BulletChartLegendLocation.html) to specify coordinates.

The following example demonstrates the custom legend position.

```cshtml

@using Syncfusion.Blazor.Charts

<SfBulletChart DataSource="@BulletChartData" Height="300px" ValueField="FieldValue" TargetField="TargetValue" Minimum="0" Maximum="100" Interval="20">
    <BulletChartMargin Top="30"></BulletChartMargin>
    <BulletChartLegendSettings Height="40px" Visible="true" Position="LegendPosition.Custom">
        <BulletChartLegendLocation X="5" Y="0"></BulletChartLegendLocation>
    </BulletChartLegendSettings>
    <BulletChartRangeCollection>
        <BulletChartRange End=35 Name="Apple"></BulletChartRange>
        <BulletChartRange End=50 Name="Mango" Color="lightgreen" Shape="LegendShape.Pentagon"></BulletChartRange>
        <BulletChartRange End=100 Name="Papaya"></BulletChartRange>
    </BulletChartRangeCollection>
</SfBulletChart>

```

N> Refer to the [code block](#legend-in-blazor-bullet-chart-component) to know about the property value of the **BulletChartData**.

![Blazor Bullet Chart displays Legend on Custom position](images/blazor-bullet-chart-legend-on-custom-position.png)

Align legend items using the [Alignment](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BulletChartLegendSettings.html#Syncfusion_Blazor_Charts_BulletChartLegendSettings_Alignment) property. Options include:

* [Near](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.Alignment.html#Syncfusion_Blazor_Charts_Alignment_Near)
* [Center](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.Alignment.html#Syncfusion_Blazor_Charts_Alignment_Center)
* [Far](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.Alignment.html#Syncfusion_Blazor_Charts_Alignment_Far)

The following example demonstrates legend item alignment.

```cshtml

@using Syncfusion.Blazor.Charts

<SfBulletChart DataSource="@BulletChartData" Height="300px" ValueField="FieldValue" TargetField="TargetValue" Minimum="0" Maximum="100" Interval="20">
    <BulletChartLegendSettings Height="40px" Visible="true" Position="LegendPosition.Top" Alignment="Alignment.Near"></BulletChartLegendSettings>
    <BulletChartRangeCollection>
        <BulletChartRange End=35 Name="Apple"></BulletChartRange>
        <BulletChartRange End=50 Name="Mango" Color="lightgreen" Shape="LegendShape.Pentagon"></BulletChartRange>
        <BulletChartRange End=100 Name="Papaya"></BulletChartRange>
    </BulletChartRangeCollection>
</SfBulletChart>

```

N> Refer to the [code block](#legend-in-blazor-bullet-chart-component) to know about the property value of the **BulletChartData**.

![Changing Legend Item Alignment in Blazor Bullet Chart](images/blazor-bullet-chart-legend-alignment.png)

## Customization

Further customize the legend using these properties:

* [Background](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BulletChartLegendSettings.html#Syncfusion_Blazor_Charts_BulletChartLegendSettings_Background) – Sets the legend background color.
* [Opacity](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BulletChartLegendSettings.html#Syncfusion_Blazor_Charts_BulletChartLegendSettings_Opacity) – Sets the legend background opacity.
* [BulletChartLegendMargin](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BulletChartLegendMargin.html) – Sets the legend margin.
* [BulletChartLegendBorder](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BulletChartLegendBorder.html) – Sets the legend border color and width.

```cshtml

@using Syncfusion.Blazor.Charts

<SfBulletChart DataSource="@BulletChartData" Height="300px" ValueField="FieldValue" TargetField="TargetValue" Minimum="0" Maximum="100" Interval="20">
    <BulletChartLegendSettings Height="40px" Visible="true" Position="LegendPosition.Top" Background="lightgray" Opacity="0.4" ShapeHeight="15" ShapeWidth="15">
        <BulletChartMargin Top="5"></BulletChartMargin>
        <BulletChartLegendTextStyle Size="15px" Color="red" Opacity="1" FontStyle="italic"></BulletChartLegendTextStyle>
        <BulletChartLegendBorder Color="#000000" Width="2"></BulletChartLegendBorder>
    </BulletChartLegendSettings>
    <BulletChartRangeCollection>
        <BulletChartRange End=35 Name="Apple"></BulletChartRange>
        <BulletChartRange End=50 Name="Mango" Shape="LegendShape.Pentagon"></BulletChartRange>
        <BulletChartRange End=100 Name="Papaya"></BulletChartRange>
    </BulletChartRangeCollection>
</SfBulletChart>

```

N> Refer to the [code block](#legend-in-blazor-bullet-chart-component) to know about the property value of the **BulletChartData**.

![Customizing Legend Items in Blazor Bullet Chart](images/blazor-bullet-chart-legend-customization.png)
