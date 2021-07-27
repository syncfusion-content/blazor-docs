---
layout: post
title: Axis in Blazor Linear Gauge Component | Syncfusion
description: Learn here all about Axis feature in Syncfusion Blazor Linear Gauge component (SfLinearGauge) and more.
platform: Blazor
control: Linear Gauge
documentation: ug
---

# Axis in Blazor Linear Gauge Component (SfLinearGauge)

Axis is used to indicate the numeric values in the linear scale. The Linear Gauge component can have any number of axes. The sub-elements of an axis are line, ticks, labels, ranges, and pointers.

## Setting the start value and end value of the axis

The start value and end value for the Linear Gauge can be set using the [`Minimum`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugeAxis.html#Syncfusion_Blazor_LinearGauge_LinearGaugeAxis_Minimum) and [`Maximum`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugeAxis.html#Syncfusion_Blazor_LinearGauge_LinearGaugeAxis_Maximum) properties in the [`LinearGaugeAxis`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugeAxis.html) class respectively. By default, the start value of the axis is "**0**" and the end value of the axis is "**100**".

```csharp
@using Syncfusion.Blazor.LinearGauge

<SfLinearGauge>
    <LinearGaugeAxes>
        <LinearGaugeAxis Minimum="20" Maximum="200">
        </LinearGaugeAxis>
    </LinearGaugeAxes>
</SfLinearGauge>
```

![Linear Gauge with Minimum and Maximum values](images/min-max.png)

## Line Customization

The following properties in the [`LinearGaugeLine`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugeLine.html) class can be used to customize the axis line in the Linear Gauge.

* [`Height`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugeLine.html#Syncfusion_Blazor_LinearGauge_LinearGaugeLine_Height) - To set the length of the axis line.
* [`Width`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugeLine.html#Syncfusion_Blazor_LinearGauge_LinearGaugeLine_Width) - To set the thickness of the axis line.
* [`Color`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugeLine.html#Syncfusion_Blazor_LinearGauge_LinearGaugeLine_Color) - To set the color of the axis line.
* [`Offset`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugeLine.html#Syncfusion_Blazor_LinearGauge_LinearGaugeLine_Offset) - To render the axis line with the specified distance from the Linear Gauge.

```csharp
@using Syncfusion.Blazor.LinearGauge

<SfLinearGauge>
    <LinearGaugeAxes>
        <LinearGaugeAxis>
            <LinearGaugeLine Height="150"
                             Width="2"
                             Color="#4286f4"
                             Offset="2">
            </LinearGaugeLine>
        </LinearGaugeAxis>
    </LinearGaugeAxes>
</SfLinearGauge>
```

![Linear Gauge with Line Customization Sample](images/line.png)

## Ticks Customization

Ticks are used to specify the interval in the axis. Ticks are of two types, major ticks and minor ticks. The following properties in the [`LinearGaugeMajorTicks`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugeMajorTicks.html) and [`LinearGaugeMinorTicks`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugeMinorTicks.html) classes can be used to customize the major ticks and minor ticks respectively.

* [`Height`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugeTickSettings.html#Syncfusion_Blazor_LinearGauge_LinearGaugeTickSettings_Height) - To set the length of the major and minor ticks in pixel values.
* [`Color`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugeTickSettings.html#Syncfusion_Blazor_LinearGauge_LinearGaugeTickSettings_Color) - To set the color of the major and minor ticks of the Linear Gauge.
* [`Width`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugeTickSettings.html#Syncfusion_Blazor_LinearGauge_LinearGaugeTickSettings_Width) - To set the thickness of the major and minor ticks in pixel values.
* [`Interval`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugeTickSettings.html#Syncfusion_Blazor_LinearGauge_LinearGaugeTickSettings_Interval) - To set the interval for the major ticks and minor ticks in the Linear Gauge.

```csharp
@using Syncfusion.Blazor.LinearGauge

<SfLinearGauge>
    <LinearGaugeAxes>
        <LinearGaugeAxis Minimum=20 Maximum=140>
            <LinearGaugeMajorTicks Color="red" Interval="20" Height="20" Width="3">
            </LinearGaugeMajorTicks>
            <LinearGaugeMinorTicks Color="Orange" Interval="5" Height="10">
            </LinearGaugeMinorTicks>
            <LinearGaugePointers>
                <LinearGaugePointer></LinearGaugePointer>
            </LinearGaugePointers>
        </LinearGaugeAxis>
    </LinearGaugeAxes>
</SfLinearGauge>
```

![Linear Gauge with Ticks Customization Sample](images/ticks-custom.png)

<!-- markdownlint-disable MD036 -->
### Positioning the ticks

The minor and major ticks can be positioned by using the [`Offset`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugeTickSettings.html#Syncfusion_Blazor_LinearGauge_LinearGaugeTickSettings_Offset) and [`Position`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugeTickSettings.html#Syncfusion_Blazor_LinearGauge_LinearGaugeTickSettings_Position) properties. The [`Offset`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugeTickSettings.html#Syncfusion_Blazor_LinearGauge_LinearGaugeTickSettings_Offset) is used to render the ticks with the specified distance from the axis. By default, the offset value is "**0**". The possible values of the [`Position`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugeTickSettings.html#Syncfusion_Blazor_LinearGauge_LinearGaugeTickSettings_Position) property are "[**Inside**](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.Position.html#Syncfusion_Blazor_LinearGauge_Position_Inside)", "[**Outside**](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.Position.html#Syncfusion_Blazor_LinearGauge_Position_Outside)", "[**Cross**](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.Position.html#Syncfusion_Blazor_LinearGauge_Position_Cross)", and "[**Auto**](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.Position.html#Syncfusion_Blazor_LinearGauge_Position_Auto)". By default, the ticks will be placed inside the axis.

```csharp
@using Syncfusion.Blazor.LinearGauge

<SfLinearGauge>
    <LinearGaugeAxes>
        <LinearGaugeAxis Minimum="0" Maximum="160">
           <LinearGaugeMajorTicks Interval="10" Color="red" Height="10" Width="3" Position="Position.Outside">
           </LinearGaugeMajorTicks>
            <LinearGaugeMinorTicks Interval="5" Color="green" Height="5" Width="2" Position="Position.Cross">
            </LinearGaugeMinorTicks>
            <LinearGaugePointers>
                <LinearGaugePointer></LinearGaugePointer>
            </LinearGaugePointers>
        </LinearGaugeAxis>
    </LinearGaugeAxes>
</SfLinearGauge>
```

![Linear Gauge with Ticks position](images/tick-position.png)

## Labels Customization

The style of the labels can be customized using the following properties in [`LinearGaugeAxisLabelFont`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugeAxisLabelFont.html) class in the [`LinearGaugeAxisLabelStyle`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugeAxisLabelStyle.html).

* [`Color`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugeFontSettings.html#Syncfusion_Blazor_LinearGauge_LinearGaugeFontSettings_Color) - To set the color of the axis label.
* [`FontFamily`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugeFontSettings.html#Syncfusion_Blazor_LinearGauge_LinearGaugeFontSettings_FontFamily) - To set the font family of the axis label.
* [`FontStyle`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugeFontSettings.html#Syncfusion_Blazor_LinearGauge_LinearGaugeFontSettings_FontStyle) - To set the font style of the axis label.
* [`FontWeight`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugeFontSettings.html#Syncfusion_Blazor_LinearGauge_LinearGaugeFontSettings_FontWeight) - To set the font weight of the axis label.
* [`Opacity`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugeFontSettings.html#Syncfusion_Blazor_LinearGauge_LinearGaugeFontSettings_Opacity) - To set the opacity of the axis label.
* [`Size`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugeFontSettings.html#Syncfusion_Blazor_LinearGauge_LinearGaugeFontSettings_Size) - To set the size of the axis label.

```csharp
@using Syncfusion.Blazor.LinearGauge

<SfLinearGauge>
    <LinearGaugeAxes>
        <LinearGaugeAxis>
            <LinearGaugeAxisLabelStyle>
                <LinearGaugeAxisLabelFont Color="red"></LinearGaugeAxisLabelFont>
            </LinearGaugeAxisLabelStyle>
        </LinearGaugeAxis>
    </LinearGaugeAxes>
</SfLinearGauge>
```

![Linear Gauge with Label customization](images/label-styles.png)

<!-- markdownlint-disable MD036 -->

### Positioning the axis label

Labels can be positioned by using [`Offset`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugeAxisLabelStyle.html#Syncfusion_Blazor_LinearGauge_LinearGaugeAxisLabelStyle_Offset) and [`Position`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugeAxisLabelStyle.html#Syncfusion_Blazor_LinearGauge_LinearGaugeAxisLabelStyle_Position) properties in the [`LinearGaugeAxisLabelStyle`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugeAxisLabelStyle.html) class. The [`Offset`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugeAxisLabelStyle.html#Syncfusion_Blazor_LinearGauge_LinearGaugeAxisLabelStyle_Offset) defines the distance between the labels and ticks. By default, the offset value is "**0**". The possible values of the [`Position`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugeAxisLabelStyle.html#Syncfusion_Blazor_LinearGauge_LinearGaugeAxisLabelStyle_Position) property are "[**Inside**](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.Position.html#Syncfusion_Blazor_LinearGauge_Position_Inside)", "[**Outside**](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.Position.html#Syncfusion_Blazor_LinearGauge_Position_Outside)", "[**Cross**](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.Position.html#Syncfusion_Blazor_LinearGauge_Position_Cross)", and "[**Auto**](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.Position.html#Syncfusion_Blazor_LinearGauge_Position_Auto)". By default, the labels will be placed inside the axis.

```csharp
@using Syncfusion.Blazor.LinearGauge

<SfLinearGauge>
    <LinearGaugeAxes>
        <LinearGaugeAxis>
            <LinearGaugeAxisLabelStyle Offset="55" Position="Position.Cross">
            </LinearGaugeAxisLabelStyle>
            <LinearGaugePointers>
                <LinearGaugePointer></LinearGaugePointer>
            </LinearGaugePointers>
        </LinearGaugeAxis>
    </LinearGaugeAxes>
</SfLinearGauge>
```

![Linear Gauge with label Position](images/label-position.png)

<!-- markdownlint-disable MD036 -->

### Customizing the display of the last label

If the last label is not in the visible range, it will be hidden by default. The last label can be made visible by setting the [`ShowLastLabel`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugeAxis.html#Syncfusion_Blazor_LinearGauge_LinearGaugeAxis_ShowLastLabel) property as "**true**" in the [`LinearGaugeAxis`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugeAxis.html) class.

```csharp
@using Syncfusion.Blazor.LinearGauge

<SfLinearGauge>
    <LinearGaugeAxes>
        <LinearGaugeAxis Minimum="0" Maximum="170" ShowLastLabel="true">
        <LinearGaugePointers>
                <LinearGaugePointer></LinearGaugePointer>
            </LinearGaugePointers>
        </LinearGaugeAxis>
    </LinearGaugeAxes>
</SfLinearGauge>
```

![Linear Gauge with Last label](images/last-label.png)

<!-- markdownlint-disable MD036 -->

### Label Format

Axis labels in the Linear Gauge control can be formatted using the [`Format`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugeAxisLabelStyle.html#Syncfusion_Blazor_LinearGauge_LinearGaugeAxisLabelStyle_Format) property in the [`LinearGaugeAxisLabelStyle`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugeAxisLabelStyle.html) class. It is used to render the axis labels in a certain format or to add a user-defined unit in the label. It works with the help of placeholder like "**{value}°C**", where "**value**" represents the axis value. For example, 20°C.

```csharp
@using Syncfusion.Blazor.LinearGauge

<SfLinearGauge>
    <LinearGaugeAxes>
        <LinearGaugeAxis Minimum =20 Maximum =140>
            <LinearGaugeAxisLabelStyle Format= "{value}°C">
            </LinearGaugeAxisLabelStyle>
            <LinearGaugePointers>
                <LinearGaugePointer></LinearGaugePointer>
            </LinearGaugePointers>
        </LinearGaugeAxis>
    </LinearGaugeAxes>
</SfLinearGauge>
```

![Linear Gauge with Custom label format](images/custom-format.png)

### Displaying numeric format in labels

The numeric formats such as currency, percentage, and so on can be displayed in the labels of the Linear Gauge using the [`Format`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.SfLinearGauge.html#Syncfusion_Blazor_LinearGauge_SfLinearGauge_Format) property in the [`SfLinearGauge`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.SfLinearGauge.html) class. The following table describes the result of applying some commonly used label formats on numeric values.

<!-- markdownlint-disable MD033 -->
<table>
<tr>
<td><b>Label Value</b></td>
<td><b>Label Format property value</b></td>
<td><b>Result </b></td>
<td><b>Description </b></td>
</tr>
<tr>
<td>1000</td>
<td>n1</td>
<td>1000.0</td>
<td>The number is rounded to 1 decimal place.</td>
</tr>
<tr>
<td>1000</td>
<td>n2</td>
<td>1000.00</td>
<td>The number is rounded to 2 decimal place.</td>
</tr>
<tr>
<td>1000</td>
<td>n3</td>
<td>1000.000</td>
<td>The number is rounded to 3 decimal place.</td>
</tr>
<tr>
<td>0.01</td>
<td>p1</td>
<td>1.0%</td>
<td>The number is converted to percentage with 1 decimal place.</td>
</tr>
<tr>
<td>0.01</td>
<td>p2</td>
<td>1.00%</td>
<td>The number is converted to percentage with 2 decimal place.</td>
</tr>
<tr>
<td>0.01</td>
<td>p3</td>
<td>1.000%</td>
<td>The number is converted to percentage with 3 decimal place.</td>
</tr>
<tr>
<td>1000</td>
<td>c1</td>
<td>$1,000.0</td>
<td>The currency symbol is appended to number and number is rounded to 1 decimal place.</td>
</tr>
<tr>
<td>1000</td>
<td>c2</td>
<td>$1,000.00</td>
<td>The currency symbol is appended to number and number is rounded to 2 decimal place.</td>
</tr>
</table>

<!-- markdownlint-disable MD036 -->

```csharp
@using Syncfusion.Blazor.LinearGauge

<SfLinearGauge Format="c">
    <LinearGaugeAxes>
        <LinearGaugeAxis>
        </LinearGaugeAxis>
    </LinearGaugeAxes>
</SfLinearGauge>
```

![Linear Gauge with Label format](images/label-format1.png)

## Orientation

By default, the Linear Gauge is rendered vertically. To change its orientation, the [`Orientation`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.Orientation.html) property must be set "**Horizontal**".

```csharp
@using Syncfusion.Blazor.LinearGauge

<SfLinearGauge Orientation="Orientation.Horizontal">
    <LinearGaugeAxes>
        <LinearGaugeAxis Minimum="20" Maximum="140"></LinearGaugeAxis>
    </LinearGaugeAxes>
</SfLinearGauge>
```

![Linear Gauge with Orientation](images/gauge-orientation.png)

## Inverted Axis

The axis of the Linear Gauge component can be inversed by setting the [`IsInversed`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugeAxis.html#Syncfusion_Blazor_LinearGauge_LinearGaugeAxis_IsInversed) property to "**true**" in the [`LinearGaugeAxis`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugeAxis.html).

```csharp
@using Syncfusion.Blazor.LinearGauge

<SfLinearGauge>
    <LinearGaugeAxes>
        <LinearGaugeAxis IsInversed="true">
            <LinearGaugePointers>
                <LinearGaugePointer></LinearGaugePointer>
            </LinearGaugePointers>
        </LinearGaugeAxis>
    </LinearGaugeAxes>
</SfLinearGauge>
```

![Linear Gauge with Inverted axis](images/invert.png)

## Opposed Axis

To place an axis opposite from its original position, [`OpposedPosition`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugeAxis.html#Syncfusion_Blazor_LinearGauge_LinearGaugeAxis_OpposedPosition) property in the [`LinearGaugeAxis`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugeAxis.html) class must be set as "**true**".

```csharp
@using Syncfusion.Blazor.LinearGauge

<SfLinearGauge>
    <LinearGaugeAxes>
        <LinearGaugeAxis OpposedPosition="true">
            <LinearGaugePointers>
                <LinearGaugePointer></LinearGaugePointer>
            </LinearGaugePointers>
        </LinearGaugeAxis>
    </LinearGaugeAxes>
</SfLinearGauge>
```

![Linear Gauge with Opposed position](images/opposite-axes.png)

## Multiple Axes

Multiple axes can be added to the Linear Gauge by adding multiple [`LinearGaugeAxis`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugeAxis.html) classes in the [`LinearGaugeAxes`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugeAxes.html) class and customization can be done with the [`LinearGaugeAxis`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugeAxis.html) class. Each axis can be customized separately as shown in the following example.

```csharp
@using Syncfusion.Blazor.LinearGauge

<SfLinearGauge>
    <LinearGaugeAxes>
        <LinearGaugeAxis Minimum=20 Maximum=100>
            <LinearGaugeAxisLabelStyle Format="{value}°C">
            </LinearGaugeAxisLabelStyle>
            <LinearGaugePointers>
                <LinearGaugePointer PointerValue=20></LinearGaugePointer>
            </LinearGaugePointers>
        </LinearGaugeAxis>
        <LinearGaugeAxis Minimum=20 Maximum=100 OpposedPosition=true>
            <LinearGaugeMajorTicks Interval="20" Height="20">
            </LinearGaugeMajorTicks>
            <LinearGaugeMinorTicks Interval="5" Height="10">
            </LinearGaugeMinorTicks>
            <LinearGaugeAxisLabelStyle Format="{value}°C">
            </LinearGaugeAxisLabelStyle>
            <LinearGaugePointers>
                <LinearGaugePointer PointerValue=20></LinearGaugePointer>
            </LinearGaugePointers>
        </LinearGaugeAxis>
    </LinearGaugeAxes>
</SfLinearGauge>
```

![Linear Gauge with Multiple axes](images/multiple-axes.png)