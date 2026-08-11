---
layout: post
title: Data Binding in Blazor TimePicker | Syncfusion
description: Bind values to Blazor TimePicker with one-way, two-way, and dynamic value binding.
platform: Blazor
control: TimePicker
documentation: ug
---

# Data Binding in Blazor TimePicker

This section briefly explains how to bind the value to the TimePicker component in the following ways.

* One-Way Data Binding
* Two-Way Data Binding
* Dynamic Value Binding

## One-Way Binding

You can bind a value to the TimePicker component directly through the `Value` property, as shown in the following code example. In one-way binding, pass a property or variable name prefixed with `@` (for example, `@DateValue`).

```cshtml
@using Syncfusion.Blazor.Calendars

<SfTimePicker TValue="DateTime?" Value="@DateValue"></SfTimePicker>

<button @onclick="UpdateValue">Update Value</button>

@code {
    public DateTime DateValue { get; set; } = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 28, 12, 30, 00);

    public void UpdateValue()
    {
        DateValue = DateTime.Now;
    }
}
```

## Two-Way Data Binding

Two-way binding can be achieved by using the `bind-Value` attribute. It supports the `string`, `int`, `Enum`, `DateTime`, and `bool` types. When the value changes, all locations bound to the variable through the `bind-Value` attribute are updated.

```cshtml
@using Syncfusion.Blazor.Calendars

<p>TimePicker value is: @DateValue</p>

<SfTimePicker TValue="DateTime?" @bind-Value="@DateValue"></SfTimePicker>

@code {
    public DateTime? DateValue { get; set; } = DateTime.Now;
}
```

## Dynamic Value Binding

The property value can be changed dynamically by manually calling the `StateHasChanged()` method from within a public event of the Blazor TimePicker component. This method notifies the component that its state has changed and queues a re-render.

There is no need to call this method for Blazor lifecycle events, because it is invoked automatically after any lifecycle method has run. It can also be called manually whenever a re-render needs to be triggered.

```cshtml
@using Syncfusion.Blazor.Calendars

<p>TimePicker value is: @TimeValue</p>

<SfTimePicker TValue="DateTime?" Value="@TimeValue">
    <TimePickerEvents TValue="DateTime?" ValueChange="@OnChange"></TimePickerEvents>
</SfTimePicker>

@code {
    public DateTime? TimeValue { get; set; } = DateTime.Now;

    private void OnChange(Syncfusion.Blazor.Calendars.ChangeEventArgs<DateTime?> args)
    {
        TimeValue = args.Value;
        StateHasChanged();
    }
}
```

## See also

* [Events in Blazor TimePicker](events)
* [Time Format in Blazor TimePicker](time-format)
* [Strict Mode in Blazor TimePicker](strict-mode)
* [Time Range in Blazor TimePicker](time-range)