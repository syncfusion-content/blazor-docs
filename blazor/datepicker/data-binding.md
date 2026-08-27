---
layout: post
title: Data Binding in Blazor DatePicker | Syncfusion®
description: Bind a date value to the Blazor DatePicker using one-way, two-way, or dynamic value binding with Value, DateTime, or DateOnly types.
platform: Blazor
control: DatePicker
documentation: ug
---

# Data Binding in Blazor DatePicker

This section briefly explains how to bind a value to the Blazor DatePicker component in the following ways.

* One-way binding
* Two-way binding
* Event-based binding

## One-way binding

In one-way binding, you assign a value to the Blazor DatePicker's [Value](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfDatePicker-1.html#Syncfusion_Blazor_Calendars_SfDatePicker_1_Value) property by passing a property or variable name prefixed with `@` (for example, `@DateValue`). The `TValue` parameter must match the type of the bound variable.

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

## Two-way binding

Two-way binding can be achieved by using the `bind-Value` attribute. The bound variable's type must match the Blazor DatePicker's `TValue` parameter — `DateTime` or `DateTime?`.

```cshtml
@using Syncfusion.Blazor.Calendars

<p>DatePicker value is: @DateValue</p>

<SfDatePicker TValue="DateTime?" @bind-Value="@DateValue"></SfDatePicker>

@code {
    public DateTime? DateValue { get; set; } = DateTime.Now;
}
```

## Dynamic value binding

You can react to value changes by handling the [ValueChange](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.DatePickerEvents-1.html) event of [DatePickerEvents](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.DatePickerEvents-1.html) and updating the bound variable inside the handler. Blazor automatically re-renders the component when the bound property changes, so calling `StateHasChanged()` is not required in this scenario.

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
