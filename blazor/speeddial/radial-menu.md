---
layout: post
title: RadialMenu with Blazor SpeedDial Component | Syncfusion
description: Checkout and learn about RadialMenu with Blazor SpeedDial component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: SpeedDial
documentation: ug
---

# Radial Menu

## Direction

Types of Radial Menu directions
*Clockwise
*AntiClockwise
*Auto

Use [Direction]() property to display the Items in any one of the above direction.

```cshtml

@using Syncfusion.Blazor.Buttons

<div id="target" style="height:350px; position:relative; width:350px; border:1px solid;">
    <SfSpeedDial Target="#target" Position="FabPosition.MiddleCenter" Mode="SpeedDialMode.Radial" OpenIconCss="e-icons e-edit" CloseIconCss="e-icons e-close">
        <SpeedDialRadialSettings Direction="RadialDirection.AntiClockwise"/>
        <SpeedDialItems>
            <SpeedDialItem IconCss="e-icons e-cut"/>
            <SpeedDialItem IconCss="e-icons e-copy"/>
            <SpeedDialItem IconCss="e-icons e-paste"/>
            <SpeedDialItem IconCss="e-icons e-edit"/>
            <SpeedDialItem IconCss="e-icons e-save"/>
        </SpeedDialItems>
    </SfSpeedDial>
</div>

```

## Start and End Angle

Use SpeedDialRadialSettings to modify the Start and End Angles. It is available only when the [Mode]() property is `Radial`.

| Angles | Definition | Range  | Default value|
| --- | --- | --- | ---|
| Start Angle | The Start angle indicates the Start angle of speed dial item placement | 0 to 360 | -1 | 
| End Angle | The End angle indicates the End angle of speed dial items placement | 0 to 360 | -1 |

```cshtml

@using Syncfusion.Blazor.Buttons

<div id="target" style="height:350px; position:relative; width:350px; border:1px solid;">
    <SfSpeedDial Target="#target" Position="FabPosition.MiddleCenter" Mode="SpeedDialMode.Radial" OpenIconCss="e-icons e-edit" CloseIconCss="e-icons e-close">
        <SpeedDialRadialSettings Direction="RadialDirection.AntiClockwise" StartAngle="180" EndAngle="360"/>
        <SpeedDialItems>
            <SpeedDialItem IconCss="e-icons e-cut"/>
            <SpeedDialItem IconCss="e-icons e-copy"/>
            <SpeedDialItem IconCss="e-icons e-paste"/>
            <SpeedDialItem IconCss="e-icons e-edit"/>
            <SpeedDialItem IconCss="e-icons e-save"/>
        </SpeedDialItems>
    </SfSpeedDial>
</div>

```

## Offset

Use [Offset]() property to set the offset distance of speed dial items placement from the button of Speed Dial. It accepts the string values. The default value is 100px. It is available only when the [Mode]() property is `Radial`.

```cshtml

@using Syncfusion.Blazor.Buttons

<div id="target" style="height:350px; position:relative; width:350px; border:1px solid;">
    <SfSpeedDial Target="#target" Position="FabPosition.TopRight" Mode="SpeedDialMode.Radial" OpenIconCss="e-icons e-edit" CloseIconCss="e-icons e-close">
        <SpeedDialRadialSettings OffSet="110px"/>
        <SpeedDialItems>
            <SpeedDialItem IconCss="e-icons e-cut"/>
            <SpeedDialItem IconCss="e-icons e-copy"/>
            <SpeedDialItem IconCss="e-icons e-paste"/>
            <SpeedDialItem IconCss="e-icons e-edit"/>
            <SpeedDialItem IconCss="e-icons e-save"/>
        </SpeedDialItems>
    </SfSpeedDial>
</div>

```