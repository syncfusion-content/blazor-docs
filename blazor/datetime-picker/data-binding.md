---
layout: post
title: Data Binding in Blazor Datetime Picker Component | Syncfusion
description: Checkout and learn here all about Data Binding in Syncfusion Blazor Datetime Picker component and more.
platform: Blazor
control: Datetime Picker 
documentation: ug
---

# Data Binding in Blazor Datetime Picker Component

This section briefly explains how to bind the value to the DateTimePicker component in the below different ways.

* One-Way Data Binding
* Two-Way Data Binding
* Dynamic Value Binding

## One-way binding

You can bind the value to the DateTimePicker component directly for `Value` property as mentioned in the following code example. In one-way binding, you need to pass property or variable name along with `@` (For Ex: "@DateValue").

```cshtml
@using Syncfusion.Blazor.Calendars

<SfDateTimePicker TValue="DateTime?" Value="@DateValue"></SfDateTimePicker>

<button @onclick="@UpdateValue">Update Value</button>

@code {
    public DateTime? DateValue { get; set; } = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 28);

    public void UpdateValue()
    {
        DateValue = DateTime.Now;
    }
}
```

## Two-way data binding

Two-way binding can be achieved by using `bind-Value` attribute and it supports string, int, Enum, DateTime, bool types. If component value has been changed, it will affect all places where the variable is bound for the **bind-value** attribute.

```cshtml
@using Syncfusion.Blazor.Calendars

<p>DateTimePicker value is: @DateValue</p>

<SfDateTimePicker TValue="DateTime?" @bind-Value="@DateValue"></SfDateTimePicker>

@code {
public DateTime? DateValue { get; set; } = DateTime.Now;
}
```

## Dynamic value binding

You can change the property value dynamically by manually calling the `StateHasChanged()` method inside public event of **Blazor DateTimePicker component** only. This method notifies the component that its state has changed and queues a re-render.

There is no need to call this method for native events since it’s called after any lifecycle method has been called and can also be invoked manually to trigger a re-render. Refer the below mentioned code example.

```cshtml
@using Syncfusion.Blazor.Calendars

<p>DateTimePicker value is: @DateValue</p>

<SfDateTimePicker TValue="DateTime?" Value="@DateValue">
    <DateTimePickerEvents TValue="DateTime?" ValueChange="@onChange">
    </DateTimePickerEvents>
</SfDateTimePicker>

@code {

public DateTime? DateValue { get; set; } = DateTime.Now;

private void onChange(Syncfusion.Blazor.Calendars.ChangedEventArgs<DateTime?> args)
    {
        DateValue = args.Value;
        StateHasChanged();
    }
}
```
