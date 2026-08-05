---
layout: post
title: Data Binding in Blazor Input Mask Component | Syncfusion®
description: Checkout and learn here all about the Data Binding in Blazor Input Mask component and much more details.
platform: Blazor
control: Input Mask
documentation: ug
---

# Data Binding in Blazor Input Mask Component

Use the `@bind-Value` directive to enable two-way data binding with the MaskedTextBox. The Value parameter is of type string. When the user edits the input, the bound field is updated; when the bound field changes in code, the component reflects the new value.

**Prerequisites:** Ensure the Syncfusion Blazor theme is referenced and the `Syncfusion.Blazor` service is registered in `Program.cs` using `builder.Services.AddSyncfusionBlazor()`. See the [Getting Started](../input-mask/getting-started) guide for setup steps.

For reference, see the [SfMaskedTextBox](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfMaskedTextBox.html), [Value](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfMaskedTextBox.html#Syncfusion_Blazor_Inputs_SfMaskedTextBox_Value), and [Mask](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfMaskedTextBox.html#Syncfusion_Blazor_Inputs_SfMaskedTextBox_Mask) API references, and the Blazor [data binding](https://learn.microsoft.com/en-us/aspnet/core/blazor/components/data-binding) documentation.

```cshtml
@using Syncfusion.Blazor.Inputs

<p>MaskedTextBox value is: @MaskValue</p>

<SfMaskedTextBox @bind-Value="@MaskValue"></SfMaskedTextBox>

@code {
    public string MaskValue { get; set; } = "12345";
}
```

## Dynamic value binding

The value can also be updated programmatically at runtime. Updating the bound field triggers the component to display the new value, as shown in the following example. Click the **Update Value** button to change the bound value at runtime.

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