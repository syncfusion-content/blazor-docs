---
layout: post
title: Data Binding in Blazor TextBox Component | Syncfusion
description: Checkout and learn here all about data binding in Syncfusion Blazor TextBox component and much more.
platform: Blazor
control: TextBox
documentation: ug
---

# Data Binding in Blazor TextBox Component

This section describes how to bind values to the TextBox component using the following approaches:

- One-way data binding
- Two-way data binding
- Dynamic value binding
- Complex data binding

## One-way binding

Bind a value to the TextBox by assigning a property to the `Value` parameter. In one-way binding, pass the property or variable name with `@` (for example, `@Name`). UI updates occur when the bound property changes during a render (for example, inside an event handler).

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

Use the `@bind-Value` attribute for two-way binding. Supported types include `string`, `int`, `enum`, `DateTime`, and `bool`. When the component value changes, the bound variable is updated, and vice versa.

```cshtml
@using Syncfusion.Blazor.Inputs

<p>TextBox value is: @Name</p>

<SfTextBox @bind-Value="@Name"></SfTextBox>

@code {

public string Name { get; set; } = "Syncfusion";

}
```

## Dynamic value binding

The component can update styles or other parameters dynamically in response to events. Calling `StateHasChanged()` notifies the component to re-render; event callbacks typically trigger re-render automatically, so this call may be optional depending on the scenario.

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

## Complex data binding

Bind nested (complex) data by referencing the property path in the `Value` parameter.

```cshtml
@using Syncfusion.Blazor.Inputs; 

<SfTextBox Value="@country.data.countryname"></SfTextBox>

@code   {

    Country country = new Country();

    protected override void OnInitialized()
    {
        country.data = new Data();
    }

    public class Country
    {

        public string id { get; set; }
        public Data data;
    }

    public class Data
    {
        public string countryname { get; set; } = "India";
    }
}
```