---
layout: post
title: Data Binding in Blazor Input Mask Component | Syncfusion
description: Checkout and learn here all about Data Binding in Syncfusion Blazor Input Mask component and much more.
platform: Blazor
control: Input Mask
documentation: ug
---

# Data Binding in Blazor Input Mask Component

Data binding can be achieved by using the `bind-Value` attribute and it supports string type. If the component value is changed, it will affect all the places where you bind the variable for the **bind-Value** attribute.

```cshtml
@using Syncfusion.Blazor.Inputs

<p>MaskedTextBox value is: @MaskValue</p>

<SfMaskedTextBox @bind-Value="@MaskValue"></SfMaskedTextBox>

@code {
    public string MaskValue { get; set; } = "12345";
}
```

## Dynamic value binding

You can bind the value to the MaskedTextBox component dynamically for `bind-Value` attribute as mentioned in the following code.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfMaskedTextBox Mask="00000" @bind-Value="@MaskValue"></SfMaskedTextBox>

<button @onclick="@UpdateValue">Update Value</button>

@code {

    public string MaskValue { get; set; } = "12345";

    public void UpdateValue()
    {
        MaskValue = "67890";
    }
}
```