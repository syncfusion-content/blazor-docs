---
layout: post
title: Data Binding in Blazor Input Mask Component | Syncfusion
description: Checkout and learn here all about Data Binding in Syncfusion Blazor Input Mask component and much more.
platform: Blazor
control: Input Mask
documentation: ug
---

# Data Binding in Blazor Input Mask Component

Use the @bind-Value attribute to enable two-way data binding with the MaskedTextBox. The Value parameter is of type string. When the user edits the input, the bound field is updated; when the bound field changes in code, the component reflects the new value. For reference, see SfMaskedTextBox, Value, and Mask in the API, and the Blazor data binding guidance.

```cshtml
@using Syncfusion.Blazor.Inputs

<p>MaskedTextBox value is: @MaskValue</p>

<SfMaskedTextBox @bind-Value="@MaskValue"></SfMaskedTextBox>

@code {
    public string MaskValue { get; set; } = "12345";
}
```

## Dynamic value binding

The value can also be updated programmatically at runtime. Updating the bound field triggers the component to display the new value, as shown in the following example.

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