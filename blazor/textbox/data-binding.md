---
layout: post
title: Data Binding in Blazor TextBox Component | Syncfusion
description: Checkout and learn here all about data binding in Syncfusion Blazor TextBox component and much more.
platform: Blazor
control: TextBox
documentation: ug
---

# Data Binding in Blazor TextBox Component

This section briefly explains how to bind the value to the TextBox component in the following different ways.

* One-way data binding
* Two-way data binding
* Dynamic value binding
* Complex data binding

## One-way binding

The value can be bound to the TextBox component directly for `Value` property as mentioned in the following code example. In one-way binding, pass the property or variable name along with `@` (For Ex: "@Name").

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

Two-way binding can be achieved by using `bind-Value` attribute and its support string, int, Enum, DateTime, and bool types. If the component value has been changed, it will affect all places where you bind the variable for the **bind-value** attribute.

```cshtml
@using Syncfusion.Blazor.Inputs

<p>TextBox value is: @Name</p>

<SfTextBox @bind-Value="@Name"></SfTextBox>

@code {

public string Name { get; set; } = "Syncfusion";

}
```

## Dynamic value binding

The property value can be changed dynamically by manually calling the `StateHasChanged()` method inside public event of **Blazor TextBox component** only. This method notifies the component that its state has changed and queues a re-render.

There is no need to call this method for native events since it’s called after any life cycle method and can also be invoked manually to trigger a re-render.
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

The complex data values can be bound to the TextBox component.The following code demonstrates how to bind complex data values to the TextBox component.

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