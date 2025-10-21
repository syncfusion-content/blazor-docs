---
layout: post
title: Display Modes in Blazor SpeedDial Component | Syncfusion
description: Checkout and learn about linear and radial display modes in Blazor SpeedDial component and much more.
platform: Blazor
control: SpeedDial
documentation: ug
---

# Display Modes in Blazor Speed Dial Component

The action items in the Blazor Speed Dial can be displayed in Linear or Radial modes by setting the [Mode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfSpeedDial.html#Syncfusion_Blazor_Buttons_SfSpeedDial_Mode) property. By default, Speed Dial items are displayed in Linear mode.

## Linear display mode

In `Linear` display mode, Speed Dial action items are displayed in a list-like layout either horizontally or vertically, based on the direction.

### Direction

You can open the action items to the left, right, up, or down side of the Speed Dial button by setting [Direction](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfSpeedDial.html#Syncfusion_Blazor_Buttons_SfSpeedDial_Direction) property. The default value is `Auto` where the action items are displayed based on the [Position](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfSpeedDial.html#Syncfusion_Blazor_Buttons_SfSpeedDial_Position)
of the Speed Dial.

The `Linear` directions of Speed Dial are as follows:

* Left - Action items are displayed on the left side of the button.
* Right - Action items are displayed on the right side of the button.
* Up - Action items are displayed above the button.
* Down - Action items are displayed below the button.
* Auto - The direction is automatically calculated based on the Speed Dial `Position` (for example, if positioned at the bottom-right, items open upward).

```cshtml

@using Syncfusion.Blazor.Buttons

<SfSpeedDial Mode="SpeedDialMode.Linear" Direction="LinearDirection.Left" OpenIconCss="e-icons e-edit">
    <SpeedDialItems>
        <SpeedDialItem IconCss="e-icons e-cut"/>
        <SpeedDialItem IconCss="e-icons e-copy"/>
        <SpeedDialItem IconCss="e-icons e-paste"/>
    </SpeedDialItems>
</SfSpeedDial>

```

![Linear display mode with items opening to the left](./images/Blazor-SpeedDial-LinearMode.png)

## Radial display mode (Radial Menu)

In `Radial` mode, Speed Dial action items are displayed in a circular pattern similar to a radial menu. For more details about Radial mode, see the getting started guide [here](https://blazor.syncfusion.com/documentation/speeddial/getting-started).