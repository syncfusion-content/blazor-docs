---
layout: post
title: Data Binding in Blazor DateTimePicker Component | Syncfusion
description: Learn how to bind values to the Syncfusion Blazor DateTimePicker using one-way binding, two-way binding with @bind-Value, and dynamic updates.
platform: Blazor
control: DateTimePicker
documentation: ug
---

# Data Binding in Blazor DateTimePicker Component

This section explains how to bind values to the DateTimePicker component in the following ways.

* One-Way Data Binding
* Two-Way Data Binding
* Dynamic Value Binding

## One-way binding

Bind a value to the DateTimePicker component using the `Value` property as shown in the following example. In one-way binding, pass the property or variable name prefixed with `@` (for example, `@DateValue`). Changes to the source update the UI, but user edits do not update the source automatically.

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

Two-way binding is achieved with the `@bind-Value` attribute. This binds the component’s value to the specified field and keeps the UI and source in sync. Use a type that matches the component’s `TValue` (for example, `DateTime` or `DateTime?`). The `@bind-Value` syntax is shorthand for using the `Value`, `ValueChanged`, and `ValueExpression` parameters.

```cshtml
@using Syncfusion.Blazor.Calendars

<p>DateTimePicker value is: @DateValue</p>

<SfDateTimePicker TValue="DateTime?" @bind-Value="@DateValue"></SfDateTimePicker>

@code {
public DateTime? DateValue { get; set; } = DateTime.Now;
}
```

## Dynamic value binding

The value can be updated programmatically in response to component events (such as the DateTimePicker’s `ValueChange`) or from external logic. When updating state within component event callbacks, the UI re-renders automatically in most cases; `StateHasChanged()` is typically required only when changes originate outside the normal event pipeline (for example, from timers, external services, or non-UI threads). The following example updates the value in the DateTimePicker’s `ValueChange` event.

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