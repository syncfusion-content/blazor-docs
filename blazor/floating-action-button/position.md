---
layout: post
title: Positions in Blazor FloatingActionButton Component | Syncfusion
description: Checkout and learn here all about Positions in Syncfusion Blazor FloatingActionButton component and much more.
platform: Blazor
control: FloatingActionButton
documentation: ug
---

# Positions in Blazor Floating Action Button Component

This section explains the different positions of Floating Action Button.

## Positioning

The floating action button can be positioned using the [`Position`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfFab.html#Syncfusion_Blazor_Buttons_SfFab_Position) property. The fab is positioned based on the [`Target`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfFab.html#Syncfusion_Blazor_Buttons_SfFab_Target), if target is defined else positioned based on the browser viewport.

## Types of Positions

The types of Floating Action Button Positions are as follows:

* TopLeft
* TopCenter
* TopRight
* MiddleLeft
* MiddleCenter
* MiddleRight
* BottomLeft
* BottomCenter
* BottomRight

## Bottom Left position

In this example, Floating Action Button is demonstrated with BottomLeft position using Position property.

```cshtml

<div id="target" style="min-height:200px; position:relative; width:300px; border:1px solid;">
    <SfFab Target="#target" Position="FabPosition.BottomLeft" IconCss="e-icons e-link"></SfFab>
</div>

<style>
    .e-menu::before {
        content: '\e34e';
    }
</style>

```
## All avilable positions

In this example, Floating Action Button is demonstrated with All position using Position property.

```cshtml

<div id="target" style="min-height:200px; position:relative; width:300px; border:1px solid;">
    <SfFab Target="#target" Position="FabPosition.TopLeft" IconCss="e-icons e-link"></SfFab>
    <SfFab Target="#target" Position="FabPosition.TopCenter" IconCss="e-icons e-link"></SfFab>
    <SfFab Target="#target" Position="FabPosition.TopRight" IconCss="e-icons e-link"></SfFab>
    <SfFab Target="#target" Position="FabPosition.MiddleLeft" IconCss="e-icons e-link"></SfFab>
    <SfFab Target="#target" Position="FabPosition.MiddleCenter" IconCss="e-icons e-link"></SfFab>
    <SfFab Target="#target" Position="FabPosition.MiddleRight" IconCss="e-icons e-link"></SfFab>
    <SfFab Target="#target" Position="FabPosition.BottomLeft" IconCss="e-icons e-link"></SfFab>
    <SfFab Target="#target" Position="FabPosition.BottomCenter" IconCss="e-icons e-link"></SfFab>
    <SfFab Target="#target" Position="FabPosition.BottomRight" IconCss="e-icons e-link"></SfFab>
</div>

<style>
    .e-menu::before {
        content: '\e34e';
    }
</style>

```

![Blazor Floating Action Button Component]()