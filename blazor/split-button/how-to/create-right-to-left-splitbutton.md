---
layout: post
title: How to enable right-to-left Blazor Split Button | Syncfusion
description: Enable right-to-left rendering in Blazor Split Button by setting the EnableRtl property to true.
platform: Blazor
control: Split Button
documentation: ug
---

# How to enable right-to-left Blazor Split Button

The SplitButton component supports right-to-left (RTL) rendering. Enable RTL by setting the [EnableRtl property (SfSplitButton)](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SplitButtons.SfSplitButton.html#Syncfusion_Blazor_SplitButtons_SfSplitButton_EnableRtl) to `true`.

The following example demonstrates how to enable right-to-left support in the SplitButton component.

```cshtml
@using Syncfusion.Blazor.SplitButtons

<SfSplitButton Content="Paste" IconCss="e-icons e-paste" EnableRtl="true">
    <DropDownMenuItems>
        <DropDownMenuItem IconCss="e-icons e-cut" Text="Cut"></DropDownMenuItem>
        <DropDownMenuItem IconCss="e-icons e-copy" Text="Copy"></DropDownMenuItem>
        <DropDownMenuItem IconCss="e-icons e-paste" Text="Paste"></DropDownMenuItem>
    </DropDownMenuItems>
</SfSplitButton>

<style>
    .e-paste::before {
        content: '\e739';
    }

    .e-cut::before {
        content: '\e73f';
    }

    .e-copy::before {
        content: '\e77b';
    }
</style>
  
```

![Right to Left in Blazor SplitButton](./../images/blazor-splitbutton-right-to-left.webp)