---
layout: post
title: Configure Animation Settings in Blazor ContextMenu Component | Syncfusion
description: Checkout and learn here all about Change animation settings in Syncfusion Blazor ContextMenu component and more.
platform: Blazor
control: Context Menu
documentation: ug
---

# Configure Animation Settings in Blazor ContextMenu Component

To configure the animation of the Context Menu, [MenuAnimationSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.MenuAnimationSettings.html) child component is used to define animation properties such as effect and duration.

The supported animation effects for the Context Menu are:

| Effect | Functionality |
| ------------ | ----------------------- |
| None | Specifies the sub menu transform with no animation effect. |
| SlideDown | Specifies the sub menu transform with slide down effect. |
| ZoomIn | Specifies the sub menu transform with zoom in effect. |
| FadeIn | Specifies the sub menu transform with fade in effect. |

The following sample illustrates how to open the Context Menu with a `FadeIn` effect and a `Duration` of `800ms`.

```cshtml
@using Syncfusion.Blazor.Navigations

<div id="target">Right click/Touch hold to open the Context Menu</div>
<SfContextMenu Target="#target" TValue="MenuItem">
    <MenuItems>
        <MenuItem Text="Cut"></MenuItem>
        <MenuItem Text="Copy"></MenuItem>
        <MenuItem Text="Paste"></MenuItem>
    </MenuItems>
    <MenuAnimationSettings Effect="MenuEffect.FadeIn" Duration="800"></MenuAnimationSettings>
</SfContextMenu>
<style>
    #target {
        border: 1px dashed;
        height: 250px;
        padding: 10px;
        position: relative;
        text-align: center;
        color: gray;
        line-height: 17;
        font-size: 14px;
    }
</style>

```

{% previewsample "https://blazorplayground.syncfusion.com/embed/BjLAirrwgacxYkyN?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor ContextMenu with Animation](./../images/blazor-contextmenu-component.png)