---
layout: post
title: Data Binding in Blazor TextBox Component | Syncfusion
description: Learn here all about Data Binding in Syncfusion Blazor TextBox component and more.
platform: Blazor
control: TextBox
documentation: ug
---

# Data Binding in Blazor TextBox Component

This section briefly explains how to bind the value to the TextBox component in the following different ways.

* One-way data binding
* Two-way data binding
* Dynamic value binding

## One-way binding

You can bind the value to the TextBox component directly for `Value` property as mentioned in the following code example. In one-way binding, you have to pass property or variable name along with `@` (For Ex: "@Name").

```cshtml
@using Syncfusion.Blazor.Inputs

<SfTextBox Value="@Name"></SfTextBox>

<button @onclick="@UpdateValue">Update Value</button>

@code {

public string Name { get; set; } = "Hello, World!";

    public void UpdateValue()
    {
        Name = "Hello, Blazor!";
    }
}
```

## Two-way data binding

Two-way binding can be achieved by using `bind-Value` attribute and its supports string, int, Enum, DateTime, and bool types. If component value has been changed, it will affect the all places where you bind the variable for the **bind-value** attribute.

```cshtml
@using Syncfusion.Blazor.Inputs

<p>TextBox value is: @Name</p>

<SfTextBox @bind-Value="@Name"></SfTextBox>

@code {

public string Name { get; set; } = "Syncfusion";

}
```

## Dynamic value binding

You can change the property value dynamically by manually calling the `StateHasChanged()` method inside public event of **Blazor TextBox component** only. This method notifies the component that its state has changed and queues a re-render.

There is no need to call this method for native events since it’s called after any lifecycle method has been called and can also be invoked manually to trigger a re-render. Refer to the following code example.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfTextBox Placeholder="Enter a Numeric Values" Input="OnInput" CssClass="@CssClass"></SfTextBox>

@code {

    public string CssClass { get; set; }

    public void OnInput(InputEventArgs args)
    {
        if (!System.Text.RegularExpressions.Regex.IsMatch(args.Value, "^[0-9]*$")){
            CssClass = "e-error";
        }
        else {
            CssClass = "e-success";
        }
        this.StateHasChanged();
    }
}
```