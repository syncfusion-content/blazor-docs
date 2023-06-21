---
layout: post
title: Date Range in Blazor DatePicker Component | Syncfusion
description: Checkout and learn here all about Date Range in Syncfusion Blazor DatePicker component and much more.
platform: Blazor
control: DatePicker
documentation: ug
---

# Date Range in Blazor DatePicker Component

The DatePicker provides an option to select a date value within a specified range by using the [Min](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.CalendarBase-1.html#Syncfusion_Blazor_Calendars_CalendarBase_1_Min) and [Max](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.CalendarBase-1.html#Syncfusion_Blazor_Calendars_CalendarBase_1_Max) properties. Always the Min value has to be lesser than the Max value. The `Value` property depends on the Min/Max with respect to the [StrictMode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfDatePicker-1.html#Syncfusion_Blazor_Calendars_SfDatePicker_1_StrictMode) property. For more information about StrictMode, refer to the [Strict Mode](./strict-mode) section from the documentation.

The following code allows selecting a date within the range from 7th to 27th in a month.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfDatePicker TValue="DateTime?" Min='@MinDate' Max='@MaxDate' Value='@DateValue'></SfDatePicker>

@code {
    public DateTime MinDate {get;set;} = new DateTime(DateTime.Now.Year,DateTime.Now.Month,07);
    public DateTime MaxDate {get;set;} = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 27);
    public DateTime? DateValue {get;set;} = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 15);
}
```



![Date Selection in Blazor DatePicker](./images/blazor-datepicker-date-selection.png)

When the Min and Max properties are configured and the selected date value is out-of-range or invalid, then the model value will be set to `out of range` date value or `null` respectively with highlighted `error` class to indicate the date is out of range or invalid.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfDatePicker TValue="DateTime?" Min='@MinDate' Max='@MaxDate' Value='@DateValue'></SfDatePicker>

@code {
    public DateTime MinDate {get;set;} = new DateTime(DateTime.Now.Year,DateTime.Now.Month,07);
    public DateTime MaxDate {get;set;} = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 27);
    public DateTime? DateValue {get;set;} = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 28);
}
```



![Blazor DatePicker displays Selected Date](./images/blazor-datepicker-selected-date.png)

N> If the value of `Min` or `Max` properties changed through code behind, you have to update the `Value` property to set within the range.