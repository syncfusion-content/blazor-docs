---
layout: post
title: Position in Blazor Tooltip Component | Syncfusion
description: Checkout and learn here all about position in Syncfusion Blazor Tooltip component and much more details.
platform: Blazor
control: Tooltip
documentation: ug
---

# Position in Blazor Tooltip Component

Tooltips can be attached to 12 static locations around the target. On initializing the Tooltip, set the [**Position**](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Popups.SfTooltip.html#Syncfusion_Blazor_Popups_SfTooltip_Position) property with any one of the following values:

* `TopLeft`
* `TopCenter`
* `TopRight`
* `BottomLeft`
* `BottomCenter`
* `BottomRight`
* `LeftTop`
* `LeftCenter`
* `LeftBottom`
* `RightTop`
* `RightCenter`
* `RightBottom`

N> By default, Tooltip is placed at the **TopCenter** of the target element.

```cshtml
@using Syncfusion.Blazor.Popups
@using Syncfusion.Blazor.Buttons

<SfTooltip Target="#target" Content="@Content" Position="Position.RightCenter">
    <SfButton ID="target" Content="Show Tooltip"></SfButton>
</SfTooltip>

@code
{
    string Content = "Tooltip Content";
}
```

![Changing Blazor Tooltip Position](images/blazor-tooltip-position.gif)

## Mouse trailing

Tooltips can be positioned relative to the mouse pointer. This behavior can be enabled or disabled by using the [`MouseTrail`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Popups.SfTooltip.html#Syncfusion_Blazor_Popups_SfTooltip_MouseTrail) property. By default, it is set to `false`.

```cshtml
@using Syncfusion.Blazor.Popups
@using Syncfusion.Blazor.Buttons

<SfTooltip MouseTrail=true Content="@Content" Target="#target">
    <SfButton ID="target" Content="Show Tooltip"></SfButton>
</SfTooltip>

@code
{
    string Content="Tooltip Content";
}

<style>
    #target {
        background-color: #ececec;
        border: 1px solid #c8c8c8;
        box-sizing: border-box;
        margin: 80px auto;
        padding: 20px;
        width: 200px;
    }
</style>
```

![Blazor Tooltip with Mouse Trail](images/blazor-tooltip-mouse-trail.gif)

N> When mouse trailing option is enabled, the tip pointer position gets auto adjusted based on the target, and other position values like start, end, and middle are not applied (to prevent the pointer from moving out of target).

## Setting offset values

Offset values are set to specify the distance between the target and Tooltip element. [`OffsetX`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Popups.SfTooltip.html#Syncfusion_Blazor_Popups_SfTooltip_OffsetX) and [`OffsetY`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Popups.SfTooltip.html#Syncfusion_Blazor_Popups_SfTooltip_OffsetY) properties are used to specify the offset left and top values.

* `OffsetX` specifies the distance between the target and Tooltip element in X axis.
* `OffsetY` specifies the distance between the target and Tooltip element in Y axis.

```cshtml
@using Syncfusion.Blazor.Popups
@using Syncfusion.Blazor.Buttons

<SfTooltip Target="#target" ShowTipPointer="false" MouseTrail="true" Content="@Content" OffsetX="30" OffsetY="30">
    <SfButton ID="target" Content="Show Tooltip"></SfButton>
</SfTooltip>

@code
{
    string Content="Tooltip Content";
}

<style>
    #target {
        background-color: #ececec;
        border: 1px solid #c8c8c8;
        box-sizing: border-box;
        margin: 80px auto;
        padding: 20px;
        width: 200px;
    }
</style>

```

![Blazor Tooltip with Offset Value](images/blazor-tooltip-offset-value.gif)

N> By default, collision is handled automatically and therefore when collision is detected the Tooltip fits horizontally and flips vertically.

## Change collision target to viewport when setting Target

You can set the [WindowCollision](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Popups.SfTooltip.html#Syncfusion_Blazor_Popups_SfTooltip_WindowCollision) property to change collision target to `viewport` instead of parent of Tooltip element.

```cshtml
@using Syncfusion.Blazor.Popups
@using Syncfusion.Blazor.Buttons

<SfTooltip ID="Tooltip" Target="#btn" Content="@content" Position="Position.TopCenter" WindowCollision="true">
     <SfButton ID="btn" Content="Show Tooltip"></SfButton>
</SfTooltip>
@code
{
    string content = "Lets go green & Save Earth !!";
}

```

![Blazor Tooltip with Window Collision](images/blazor-tooltip-window-collision.png)

N>[View Sample in GitHub](https://github.com/SyncfusionExamples/Change-collision-target-to-viewport-in-Blazor-Tooltip).
