---
layout: post
title: Data Binding in Blazor Numeric Textbox | Syncfusion
description: Bind numeric values to Blazor Numeric TextBox using one-way, two-way, and dynamic data binding methods today.
platform: Blazor
control: Numeric TextBox
documentation: ug
---

# Data Binding in Blazor Numeric Textbox

This section explains how to bind values to the Blazor Numeric TextBox (SfNumericTextBox) in three common ways:
- One-way data binding
- Two-way data binding
- Dynamic value binding

## One-way binding

Bind the value to the Blazor Numeric TextBox component directly for `Value` property as mentioned in the following code example. In one-way binding, you have to pass property or variable name along with `@` (For Ex: "@Name").

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

Two-way binding can be achieved by using the `@bind-Value` attribute. The component supports numeric types such as `int`, `int?`, `long`, `float`, `double`, and `decimal`. If the component value changes, the change is reflected in all the places where the variable is bound to the `@bind-Value` attribute.

```cshtml
@using Syncfusion.Blazor.Inputs

<p>NumericTextBox value is: @NumericValue</p>

<SfNumericTextBox TValue="int?" @bind-Value="@NumericValue"></SfNumericTextBox>

@code {
    public int? NumericValue { get; set; } = 10;
}
```

## Dynamic value binding

When you handle a component event and update a property that drives the input, call `StateHasChanged()` inside the handler to queue a re-render. This is not required for native DOM events, which automatically trigger a re-render after the event.

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
        NumericValue = args.Value;
        StateHasChanged();
    }
}
```
