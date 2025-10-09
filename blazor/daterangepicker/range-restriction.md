---
layout: post
title: Range Restriction in Blazor DateRangePicker Component | Syncfusion
description: Learn how to restrict selectable ranges in the Syncfusion Blazor DateRangePicker using Min, Max, MinDays, MaxDays, and StrictMode to control valid input and selection.
platform: Blazor
control: DateRangePicker
documentation: ug
---

# Range Restriction in Blazor DateRangePicker Component

Range selection in the DateRangePicker can be constrained to meet application requirements using built-in properties.

## Restrict the range within a range

Limit the earliest and latest selectable dates using the [Min](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.DateRangePickerModel-1.html#Syncfusion_Blazor_Calendars_DateRangePickerModel_1_Min) and [Max](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.DateRangePickerModel-1.html#Syncfusion_Blazor_Calendars_DateRangePickerModel_1_Max) properties.

- `Min`: Sets the earliest date allowed for `StartDate`.
- `Max`: Sets the latest date allowed for `EndDate`.

In the following sample, the selectable range is limited from the 15th of the current month to the 15th of the next month.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfDateRangePicker TValue="DateTime?" Min='@MinDate' Max='@MaxDate'></SfDateRangePicker>

@code {
    public DateTime MinDate {get;set;} = new DateTime(DateTime.Now.Year,DateTime.Now.Month,15);
    public DateTime MaxDate {get;set;} = new DateTime(DateTime.Now.Year, DateTime.Now.Month+1, 15);
}
```

![Range restriction applied in the Blazor DateRangePicker](./images/blazor-daterangepicker-range-restriction.png)

## Range span

Constrain the length of the selected range using the [MinDays](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfDateRangePicker-1.html#Syncfusion_Blazor_Calendars_SfDateRangePicker_1_MinDays) and [MaxDays](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfDateRangePicker-1.html#Syncfusion_Blazor_Calendars_SfDateRangePicker_1_MaxDays) properties.

- `MinDays`: Sets the minimum number of days between `StartDate` and `EndDate`.
- `MaxDays`: Sets the maximum number of days between `StartDate` and `EndDate`.

In the following example, the selected range must be greater than 5 days and less than 10 days; otherwise, the range is not set.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfDateRangePicker TValue="DateTime?" MinDays=5 MaxDays=10 Placeholder='Select a range'>
</SfDateRangePicker>
```

![Blazor DateRangePicker enforcing a span between start and end dates](./images/blazor-daterangepicker-range-span.png)

## Strict mode

The [StrictMode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfDateRangePicker-1.html#Syncfusion_Blazor_Calendars_SfDateRangePicker_1_StrictMode) property controls how typed input is validated against `Min` and `Max`.

When StrictMode is enabled (true):
- Only valid dates within the `Min` and `Max` range are accepted.
- If an invalid date range is entered, the component reverts to the previous valid value.
- If a date is out of range, the value is clamped to the nearest boundary (`Min` or `Max`).

```cshtml
@using Syncfusion.Blazor.Calendars

<SfDateRangePicker TValue="DateTime?" StartDate='@Start' EndDate='@End' StrictMode=true Min='@MinDate' Max='@MaxDate'></SfDateRangePicker>

@code {
    public DateTime MinDate {get;set;} = new DateTime(DateTime.Now.Year,DateTime.Now.Month,15);
    public DateTime MaxDate {get;set;} = new DateTime(DateTime.Now.Year, DateTime.Now.Month+1, 15);
    public DateTime? Start {get;set;} = new DateTime(DateTime.Now.Year,DateTime.Now.Month,20);
    public DateTime? End {get;set;} = new DateTime(DateTime.Now.Year, DateTime.Now.Month+1, 25);
}
```

If the values of `Min` or `Max` are changed through code-behind, update the `StartDate` and `EndDate` to keep them within the defined range.

If the start/end dates fall outside the allowed range, an error style is applied to the input. With `StrictMode` enabled, out-of-range dates are adjusted to the boundary:
- If both start and end are less than `Min`, they are set to `Min`.
- If both are greater than `Max`, they are set to `Max`.
- If only the start is less than `Min`, it is set to `Min`.
- If only the end is greater than `Max`, it is set to `Max`.

![Blazor DateRangePicker with StrictMode enabled](./images/blazor-daterangepicker-strict-mode.png)

When StrictMode is disabled (false) (default):
- The textbox allows invalid or out-of-range dates to be entered.
- If the entered date is invalid, the model value becomes `null`.
- If the date is out of range, the model can hold the out-of-range value, and an `error` style indicates the condition.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfDateRangePicker TValue="DateTime?" StartDate='@Start' EndDate='@End' StrictMode=false Min='@MinDate' Max='@MaxDate'></SfDateRangePicker>

@code {
    public DateTime MinDate {get;set;} = new DateTime(DateTime.Now.Year,DateTime.Now.Month,15);
    public DateTime MaxDate {get;set;} = new DateTime(DateTime.Now.Year, DateTime.Now.Month+1, 15);
    public DateTime? Start {get;set;} = new DateTime(DateTime.Now.Year,DateTime.Now.Month,20);
    public DateTime? End {get;set;} = new DateTime(DateTime.Now.Year, DateTime.Now.Month+1, 25);
}
```

![Blazor DateRangePicker with StrictMode disabled](./images/blazor-daterangepicker-without-strict-mode.png)

N> You can refer to our [Blazor Date Range Picker](https://www.syncfusion.com/blazor-components/blazor-daterangepicker) feature tour page for its groundbreaking feature representations. You can also explore our [Blazor Date Range Picker example](https://blazor.syncfusion.com/demos/daterangepicker/default-functionalities?theme=bootstrap5) to understand how to present and manipulate data.