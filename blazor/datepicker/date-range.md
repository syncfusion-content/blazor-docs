---
layout: post
title: Date Range in Blazor DatePicker | Syncfusion®
description: Restrict the Blazor DatePicker to a specific date range using the Min and Max properties, with inclusive bounds and date-only comparison.
platform: Blazor
control: DatePicker
documentation: ug
---

# Date Range in Blazor DatePicker

The Blazor DatePicker allows you to restrict the selectable date to a specified range by using the [Min](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.CalendarBase-1.html#Syncfusion_Blazor_Calendars_CalendarBase_1_Min) and [Max](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.CalendarBase-1.html#Syncfusion_Blazor_Calendars_CalendarBase_1_Max) properties.

When [StrictMode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfDatePicker-1.html#Syncfusion_Blazor_Calendars_SfDatePicker_1_StrictMode) is enabled, the [Value](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfDatePicker-1.html#Syncfusion_Blazor_Calendars_SfDatePicker_1_Value) is reset to `null` if it falls outside the configured Min/Max range. For more information, refer to the [Strict Mode](./strict-mode) section.

The following example allows selecting a date within the range from the 7th to the 27th of the current month.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfDatePicker TValue="DateTime?" Min='@MinDate' Max='@MaxDate' Value='@DateValue'></SfDatePicker>

@code {
    public DateTime MinDate {get;set;} = new DateTime(DateTime.Now.Year,DateTime.Now.Month,07);
    public DateTime MaxDate {get;set;} = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 27);
    public DateTime? DateValue {get;set;} = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 15);
}
```

![Date Selection in Blazor DatePicker](./images/blazor-datepicker-date-selection.webp)

The following example sets the initial `Value` to the 28th, which is outside the configured range (7th–27th). Because the date is out of range, the model value is reset to `null` and the `e-error` CSS class is applied to the input to highlight the invalid value.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfDatePicker TValue="DateTime?" Min='@MinDate' Max='@MaxDate' Value='@DateValue'></SfDatePicker>

@code {
    public DateTime MinDate {get;set;} = new DateTime(DateTime.Now.Year,DateTime.Now.Month,07);
    public DateTime MaxDate {get;set;} = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 27);
    public DateTime? DateValue {get;set;} = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 28);
}
```

![Blazor DatePicker displays Selected Date](./images/blazor-datepicker-selected-date.webp)

N> If the value of the `Min` or `Max` property is changed through code-behind, you have to update the `Value` property so that it stays within the range.

## See also

* [Strict Mode](./strict-mode)
* [DateRangePicker](../daterangepicker/getting-started)