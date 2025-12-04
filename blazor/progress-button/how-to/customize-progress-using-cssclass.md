---
layout: post
title: Customize progress using cssClass in Syncfusion Blazor ProgressButton
description: Learn here all about customizing the progress using cssClass in Syncfusion Blazor ProgressButton component and more.
platform: Blazor
control: Progress Button
documentation: ug
---

# Customize progress using cssClass in Blazor ProgressButton Component

Customize the progress indicator (filler) by using the [CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SplitButtons.SfProgressButton.html#Syncfusion_Blazor_SplitButtons_SfProgressButton_CssClass) property.

* Adding `e-vertical` to `CssClass` displays vertical progress.
* Adding `e-progress-top` to `CssClass` places the progress at the top of the button.

Reverse progress can also be shown by adding a custom class through the [CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SplitButtons.SfProgressButton.html#Syncfusion_Blazor_SplitButtons_SfProgressButton_CssClass) property.

```cshtml
@using Syncfusion.Blazor.SplitButtons

<SfProgressButton EnableProgress="true" CssClass="e-hide-spinner e-vertical" Duration="4000" Content="Vertical Progress"></SfProgressButton>
<SfProgressButton EnableProgress="true" CssClass="e-hide-spinner e-progress-top" Duration="4000" Content="Progress Top"></SfProgressButton>
<SfProgressButton EnableProgress="true" CssClass="e-hide-spinner e-reverse-progress" Duration="4000" Content="Reverse Progress"></SfProgressButton>

<style>
    .e-reverse-progress .e-progress {
        right: 0;
        left: auto;
    }
</style>

```

![Customizing Progress in Blazor ProgressButton](./../images/blazor-progressbutton-customization.png)