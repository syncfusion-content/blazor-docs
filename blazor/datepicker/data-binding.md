---
layout: post
title: Data Binding in Blazor DatePicker Component | Syncfusion
description: Learn how to bind values to the Syncfusion Blazor DatePicker using one-way binding, two-way binding with @bind-Value, and dynamic value updates.
platform: Blazor
control: DatePicker
documentation: ug
---

# Data Binding in Blazor DatePicker Component

This section explains how to bind values to the DatePicker component in the following ways.

* One-Way Data Binding
* Two-Way Data Binding
* Dynamic Value Binding

## One-way binding

Bind a value to the DatePicker component using the `Value` property as shown in the following example. In one-way binding, pass the property or variable name prefixed with `@` (for example, `@DateValue`). Changes to the source update the UI, but edits in the UI do not update the source automatically.

- API reference: [Value](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfDatePicker-1.html#Syncfusion_Blazor_Calendars_SfDatePicker_1_Value)

```cshtml
@using Syncfusion.Blazor.Calendars

<SfDatePicker TValue="DateTime?" Value="@DateValue"></SfDatePicker>

<button @onclick="@UpdateValue">Update Value</button>

@code {
    public DateTime? DateValue { get; set; } = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 28);

    public void UpdateValue()
    {
        DateValue = DateTime.Now;
    }
}
```

Preview:
- The DatePicker initially shows the 28th of the current month. Selecting the “Update Value” button sets the input to today’s date. Typing or selecting a date in the UI does not change the underlying DateValue field.

## Two-way data binding

Two-way binding is achieved with the `@bind-Value` attribute. This binds the component’s value to the specified field and updates both the UI and the source when changes occur. Use a type that matches the component’s `TValue` (for example, `DateTime` or `DateTime?`). Clearing the input sets the value to `null` when using a nullable type. The `@bind-Value` syntax is shorthand for using the `Value`, `ValueChanged`, and `ValueExpression` parameters.

- API references:
  - [Value](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfDatePicker-1.html#Syncfusion_Blazor_Calendars_SfDatePicker_1_Value)
  - [ValueChanged](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfDatePicker-1.html#Syncfusion_Blazor_Calendars_SfDatePicker_1_ValueChanged)
  - [ValueExpression](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfDatePicker-1.html#Syncfusion_Blazor_Calendars_SfDatePicker_1_ValueExpression)

```cshtml
@using Syncfusion.Blazor.Calendars

<p>DatePicker value is: @DateValue</p>

<SfDatePicker TValue="DateTime?" @bind-Value="@DateValue"></SfDatePicker>

@code {
    public DateTime? DateValue { get; set; } = DateTime.Now;
}
```

Preview:
- The paragraph renders the current value from the bound field. Selecting a new date in the DatePicker updates the paragraph text immediately. Clearing the input results in a blank (null) display when using a nullable type.

## Dynamic value binding

The value can be updated programmatically in response to component events (such as the DatePicker’s `ValueChange`) or from external logic. When updating state within component event callbacks, the UI re-renders automatically.

- API references:
  - [ValueChange event](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfDatePicker-1.html#Syncfusion_Blazor_Calendars_SfDatePicker_1_ValueChange)
  - [ChangedEventArgs<TValue>](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.ChangedEventArgs-1.html)

```cshtml
@using Syncfusion.Blazor.Calendars

<p>DatePicker value is: @DateValue</p>

<SfDatePicker TValue="DateTime?" Value="@DateValue">
    <DatePickerEvents TValue="DateTime?" ValueChange="@OnChange"></DatePickerEvents>
</SfDatePicker>

@code {
    public DateTime? DateValue { get; set; } = DateTime.Now;

    private void OnChange(Syncfusion.Blazor.Calendars.ChangedEventArgs<DateTime?> args)
    {
        DateValue = args.Value;
        // StateHasChanged() is not required here because event callbacks trigger re-rendering.
    }
}

