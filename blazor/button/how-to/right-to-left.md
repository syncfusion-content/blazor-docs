---
layout: post
title: Right-To-Left in Blazor Button Component | Syncfusion
description: Checkout and learn here all about Right-To-Left in Syncfusion Blazor Button component and much more.
platform: Blazor
control: Button
documentation: ug
---

# Right-To-Left in Blazor Button Component

The Blazor Button component supports right-to-left (RTL) rendering. Enable RTL by setting the [EnableRtl](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfButton.html#Syncfusion_Blazor_Buttons_SfButton_EnableRtl) property to `true`.

The following example illustrates how to enable right-to-left support in the Button component.

```cshtml
@using Syncfusion.Blazor.Buttons

<SfButton IconCss="e-icons e-setting-icon" EnableRtl="true">Settings</SfButton>

<style>
    .e-setting-icon::before {
        content: '\e679';
    }
</style>
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/rjVgirrrCcOUEMiy?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}


![Right to Left in Blazor Button](./../images/blazor-button-in-right-to-left.png)