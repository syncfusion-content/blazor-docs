---
layout: post
title: Data Binding in Blazor DateRangePicker Component | Syncfusion
description: Checkout and learn here all about Data Binding in Syncfusion Blazor DateRangePicker component and more.
platform: Blazor
control: DateRangePicker
documentation: ug
---

# Data Binding in Blazor DateRangePicker Component

This section explains how to bind values to the DateRangePicker component in the following ways.

- One-Way Data Binding
- Two-Way Data Binding
- Dynamic Value Binding

## One-way binding

Bind values to the DateRangePicker using the `StartDate` and `EndDate` properties as shown below. In one-way binding, pass the property or variable name prefixed with `@` (for example, `@StartValue`). Changes to the source update the UI, but user edits do not update the source automatically.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfDateRangePicker TValue="DateTime?" StartDate="@StartValue" EndDate="@EndValue"></SfDateRangePicker>

<button @onclick="@UpdateValue">Update Value</button>

@code {
    public DateTime? StartValue { get; set; } = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 28);
    public DateTime? EndValue { get; set; } = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, 28);

    public void UpdateValue()
    {
        StartValue = new DateTime(DateTime.Now.Year + 1, DateTime.Now.Month, 28);
        EndValue = new DateTime(DateTime.Now.Year + 1, DateTime.Now.Month + 1, 28);
    }
}
```

Preview of the code snippet: Selecting Update Value changes the underlying StartDate and EndDate fields, and the DateRangePicker reflects the new range. Editing the input does not change the StartValue or EndValue fields.

## Two-way data binding

Two-way binding is achieved with the `@bind-StartDate` and `@bind-EndDate` attributes. These attributes bind the component’s values to the specified fields and keep the UI and source in sync. Use types that match the component’s `TValue` (for example, `DateTime` or `DateTime?`). The `@bind-...` syntax is shorthand for using the corresponding parameter, change callback, and expression.

```cshtml
@using Syncfusion.Blazor.Calendars

<p>DateRangePicker StartDate and EndDate: <strong>@StartValue</strong> and <strong>@EndValue</strong></p>

<SfDateRangePicker TValue="DateTime?"
                   @bind-StartDate="@StartValue"
                   @bind-EndDate="@EndValue">
</SfDateRangePicker>

@code {
    public DateTime? StartValue { get; set; } = DateTime.Now;
    public DateTime? EndValue { get; set; } = DateTime.Now;
}
```

Preview of the code snippet: Changing the selected range updates StartValue and EndValue immediately, and updating the bound fields in code updates the displayed range.

## Dynamic value binding

Values can be updated programmatically in response to component events (such as `ValueChange`) or from external logic. Event callbacks trigger re-rendering automatically. The following example updates the range in the DateRangePicker’s `ValueChange` event.

```cshtml
@using Syncfusion.Blazor.Calendars

<p>DateRangePicker StartDate and EndDate: <strong>@StartValue</strong> and <strong>@EndValue</strong></p>

<SfDateRangePicker TValue="DateTime?" StartDate="@StartValue" EndDate="@EndValue">
    <DateRangePickerEvents TValue="DateTime?" ValueChange="@OnChange"></DateRangePickerEvents>
</SfDateRangePicker>

@code {
    public DateTime? StartValue { get; set; } = DateTime.Now;
    public DateTime? EndValue { get; set; } = DateTime.Now;

    private void OnChange(RangePickerEventArgs<DateTime?> args)
    {
        StartValue = args.StartDate;
        EndValue = args.EndDate;
        // StateHasChanged() is not required here because event callbacks re-render automatically.
    }
}
```

Preview of the code snippet: Selecting a new range raises ValueChange, and the paragraph displays the updated StartDate and EndDate values.

## Additional resources

- Blazor Date Range Picker feature tour: https://www.syncfusion.com/blazor-components/blazor-daterangepicker
- Blazor Date Range Picker example: https://blazor.syncfusion.com/demos/daterangepicker/default-functionalities?theme=bootstrap5