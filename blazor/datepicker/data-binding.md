---
layout: post
title: Data Binding in Blazor DatePicker Component | Syncfusion
description: Learn here all about Data Binding in Syncfusion Blazor DatePicker component and more.
platform: Blazor
control: DatePicker
documentation: ug
---

# Data Binding in Blazor DatePicker Component

This section briefly explains how to bind the value to the DatePicker component in the below different ways.

* One-Way Data Binding
* Two-Way Data Binding
* Dynamic Value Binding

## One-Way Binding

We can bind the value to the DatePicker component directly for `Value` property as mentioned in the following code example. In one-way binding, we need to pass property or variable name along with `@` (For Ex: "@DateValue").

```cshtml
@using Syncfusion.Blazor.Calendars

<SfDatePicker TValue="DateTime?" Value="@DateValue"></SfDatePicker>

<button @onclick="@UpdateValue">Update Value</button>

@code {
    public DateTime? DateValue {get;set;} = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 28);

    public void UpdateValue()
    {
        DateValue = DateTime.Now;
    }
}
```

## Two-Way Data Binding

Two-way binding can be achieved by using `bind-Value` attribute and its supports string, int, Enum, DateTime, bool types. If component value has been changed, it will affect the all places where we bind the variable for the **bind-value** attribute.

```cshtml
@using Syncfusion.Blazor.Calendars

<p>DatePicker value is: @DateValue</p>

<SfDatePicker TValue="DateTime?" @bind-Value="@DateValue"></SfDatePicker>

@code {
public DateTime? DateValue { get; set; } = DateTime.Now;
}
```

## Dynamic Value Binding

We can change the property value dynamically by manually calling the `StateHasChanged()` method inside public event of **Blazor DatePicker component** only. This method notifies the component that its state has changed and queues a re-render.

There is no need to call this method for native events since it’s called after any lifecycle method has been called and can also be invoked manually to trigger a re-render. Please refer the below mentioned code example.

```cshtml
@using Syncfusion.Blazor.Calendars

<p>DatePicker value is: @DateValue</p>

<SfDatePicker TValue="DateTime?" Value="@DateValue">
    <DatePickerEvents TValue="DateTime?" ValueChange="@onChange"></DatePickerEvents>
</SfDatePicker>

@code {

public DateTime? DateValue { get; set; } = DateTime.Now;

private void onChange(Syncfusion.Blazor.Calendars.ChangedEventArgs<DateTime?> args)
    {
        DateValue = args.Value;
        StateHasChanged();
    }
}
```