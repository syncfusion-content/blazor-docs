---
layout: post
title: Customize the UI appearance of Blazor Numeric TextBox | Syncfusion
description: Learn here all about customizing the UI appearance of Syncfusion Blazor Numeric TextBox component and more.
platform: Blazor
control: Numeric TextBox
documentation: ug
---

# Customize the UI appearance of Blazor Numeric TextBox Component

Change the appearance of the NumericTextBox by adding custom [CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfNumericTextBox-1.html#Syncfusion_Blazor_Inputs_SfNumericTextBox_1_CssClass) to the component and enabling styles.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfNumericTextBox TValue="int?" Value=10 CssClass="e-style" Placeholder="Enter value" FloatLabelType="@FloatLabelType.Always"></SfNumericTextBox>

<style>
    .e-numeric.e-style .e-control.e-numerictextbox {
        color: royalblue;
        font-size: xx-large;
        border: 0px;
    }

    .e-input-group.e-style.e-control-wrapper:not(.e-success):not(.e-warning):not(.e-error):not(.e-float-icon-left), .e-float-input.e-control-wrapper:hover:not(.e-success):not(.e-warning):not(.e-error):not(.e-disabled):not(.e-float-icon-left) {
        border-color: royalblue;
    }

    .e-control-wrapper.e-numeric.e-float-input.e-style .e-spin-down {
        color: royalblue;
    }

    .e-control-wrapper.e-numeric.e-float-input.e-style .e-float-line::before {
        background: royalblue;
    }

    .e-control-wrapper.e-numeric.e-float-input.e-style .e-float-line::after {
        background: royalblue;
    }

    .e-control-wrapper.e-numeric.e-float-input.e-style .e-spin-up {
        color: royalblue;
    }

    .e-control-wrapper.e-numeric.e-float-input.e-style.e-input-group .e-float-text.e-label-top {
        color: royalblue;
        font-size: medium;
    }
</style>
```

![Customizing UI Appearance of Blazor Numeric TextBox](../images/blazor-numerictextbox-ui-customization.png)