---
layout: post
title: Data Binding in Blazor DatePicker Component | Syncfusion
description: Checkout and learn here all about Data Binding in Syncfusion Blazor DatePicker component and much more.
platform: Blazor
control: DatePicker
documentation: ug
---

# Data Binding in Blazor DatePicker Component

This section briefly explains how to bind the value to the DatePicker component in the below different ways.

* One-Way Data Binding
* Two-Way Data Binding
* Dynamic Value Binding

## One-way binding

You can bind the value to the DatePicker component directly for `Value` property as mentioned in the following code example. In one-way binding, you need to pass property or variable name along with `@` (For Ex: "@DateValue").

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

## Two-way data binding

Two-way binding can be achieved by using `bind-Value` attribute, which supports string, int, Enum, DateTime, bool types. If the component value has been changed, it will affect all places where the variable is bound for the **bind-value** attribute.

```cshtml
@using Syncfusion.Blazor.Calendars

<p>DatePicker value is: @DateValue</p>

<SfDatePicker TValue="DateTime?" @bind-Value="@DateValue"></SfDatePicker>

@code {
public DateTime? DateValue { get; set; } = DateTime.Now;
}
```

## Dynamic value binding

You can change the property value dynamically by manually calling the `StateHasChanged()` method inside public event of **Blazor DatePicker component** only. This method notifies the component that its state has changed and queues a re-render.

There is no need to call this method for native events since it’s called after any lifecycle method has been called and can also be invoked manually to trigger a re-render. Refer the below mentioned code example.

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
