---
layout: post
title: Customize the Appearance of Blazor Input Mask Component | Syncfusion
description: Learn here all about customizing the UI appearance of Syncfusion Blazor Input Mask component and more.
platform: Blazor
control: Input Mask
documentation: ug
---

# Customize the UI Appearance of the Blazor Input Mask Component

The appearance of the MaskedTextBox can be changed by adding custom [CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfMaskedTextBox.html#Syncfusion_Blazor_Inputs_SfMaskedTextBox_CssClass) to the component and enabling styles.

Refer to the following example to change the appearance of the MaskedTextBox.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfMaskedTextBox Mask="00000" Value="34523" CssClass="e-style" Placeholder="Enter user ID" FloatLabelType="@FloatLabelType.Always"> </SfMaskedTextBox>

<style>
    .e-mask.e-style .e-control.e-maskedtextbox {
        color: #00ffff;
        letter-spacing: 10px;
        font-size: xx-large;
        border: 1px;
        border-color: #ffffff;
    }

    .e-control-wrapper.e-mask.e-float-input.e-style .e-float-line::before {
        background: #ffffff;
    }

    .e-control-wrapper.e-mask.e-float-input.e-style .e-float-line::after {
        background: #ffffff;
    }

    .e-control-wrapper.e-mask.e-float-input.e-style .e-float-text.e-label-top {
        color: #00ffff;
        font-size: medium;
    }
</style>
```

![MaskedTextBox Sample](../images/customCss.png)
