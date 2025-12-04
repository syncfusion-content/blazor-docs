---
layout: post
title: Data Binding in Blazor Numeric TextBox Component | Syncfusion
description: Checkout and learn here all about data binding in Syncfusion Blazor Numeric TextBox component and more.
platform: Blazor
control: Numeric TextBox
documentation: ug
---

# Data Binding in Blazor Numeric TextBox Component

This section explains how to bind values to the Numeric TextBox (SfNumericTextBox) in three common ways:
- One-way data binding
- Two-way data binding
- Dynamic value binding

## One-way binding

Bind the value to the NumericTextBox component directly for `Value` property as mentioned in the following code example. In one-way binding, you have to pass property or variable name along with `@` (For Ex: "@Name").

```cshtml
@using Syncfusion.Blazor.Inputs

<SfNumericTextBox TValue="int?" Value=@NumericValue></SfNumericTextBox>

<button @onclick="@UpdateValue">Update Value</button>

@code {

    public int? NumericValue { get; set; } = 5;

    public void UpdateValue()
    {
        NumericValue = 20;
    }
}
```

## Two-way data binding

Two-way binding can be achieved by using `bind-Value` attribute and it supports string, int, Enum, DateTime, and bool types. If component value has been changed, it will affect all the places where the variable is bound for the **bind-value** attribute.

```cshtml
@using Syncfusion.Blazor.Inputs

<p>NumericTextBox value is: @NumericValue</p>

<SfNumericTextBox TValue="int?" @bind-Value="@NumericValue"></SfNumericTextBox>

@code {
    public int? NumericValue { get; set; } = 10;
}
```

## Dynamic value binding

Change the property value dynamically by manually calling the `StateHasChanged()` method inside public event of **Blazor NumericTextBox component** only. This method notifies the component that its state has changed and queues a re-render.

There is no need to call this method for native events since it’s called after any lifecycle method has been called and can also be invoked manually to trigger a re-render.

```cshtml
@using Syncfusion.Blazor.Inputs

<p>NumericTextBox value is: @NumericValue</p>

<SfNumericTextBox TValue="int?" Value="@NumericValue">
    <NumericTextBoxEvents TValue="int?" ValueChange="OnChange" ></NumericTextBoxEvents>
</SfNumericTextBox>

@code {
    public int? NumericValue { get; set; } = 12;

    public void OnChange(Syncfusion.Blazor.Inputs.ChangeEventArgs<int?> args)
    {
        NumericValue = (int)args.Value;
        StateHasChanged();
    }
}
```