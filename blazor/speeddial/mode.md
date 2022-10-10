---
layout: post
title: Mode with Blazor SpeedDial Component | Syncfusion
description: Checkout and learn about Mode with Blazor SpeedDial component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: SpeedDial
documentation: ug
---

# Mode

## Types of Mode
* Linear
* Radial

## Linear Mode

SpeedDial items are displayed in linear order like list. Use [Direction]() property to display the Items in linear order direction. In Linear Mode below directions are available

| List of Directions | 
|--|
| Right | 
| Left | 
| Up | 
| Down | 
| Auto |

In `Auto` direction Speed dial action items are displayed vertically above or below the button of Speed Dial based on the Speed Dial button position. In the following example, Speed Dial Items are demonstrated with `Direction` property.

```cshtml

@using Syncfusion.Blazor.Buttons

<div id="target" style="height:350px; position:relative; width:350px; border:1px solid;">
    <SfSpeedDial Target="#target" Position="FabPosition.MiddleCenter" Mode="SpeedDialMode.Linear" Direction="LinearDirection.Down" OpenIconCss="e-icons e-edit" CloseIconCss="e-icons e-close">
        <SpeedDialItems>
            <SpeedDialItem IconCss="e-icons e-cut"/>
            <SpeedDialItem IconCss="e-icons e-copy"/>
            <SpeedDialItem IconCss="e-icons e-paste"/>
        </SpeedDialItems>
    </SfSpeedDial>
</div>

```

## Radial Mode

SpeedDial items are displayed like radial menu in radial direction (circular direction). Use [Direction]() property to display the Items in Radial menu order direction. In Radial Mode below directions are available

| List of Directions | 
|--|
| Clockwise | 
| AntiClockwise |  
| Auto |

In `Auto` direction Speed dial action items are displayed clockwise or anti-clockwise based on the Speed Dial button position.
