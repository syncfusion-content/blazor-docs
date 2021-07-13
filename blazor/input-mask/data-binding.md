---
layout: post
title: Data Binding in Blazor Input Mask Component | Syncfusion 
description: Learn about Data Binding in Blazor Input Mask component of Syncfusion, and more details.
platform: Blazor
control: Input Mask
documentation: ug
---

# Data Binding

Data binding can be achieved by using the `bind-Value` attribute and it supports string type. If component value has been changed, it will affect the all places where you bind the variable for the **bind-Value** attribute.

```csharp
@using Syncfusion.Blazor.Inputs

<p>MaskedTextBox value is: @MaskValue</p>

<SfMaskedTextBox @bind-Value="@MaskValue"></SfMaskedTextBox>

@code {
    public string MaskValue { get; set; } = "12345";
}
```

## Dynamic Value Binding

You can bind the value to the MaskedTextBox component dynamically for `bind-Value`  attribute as mentioned in the following code.

```csharp
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
