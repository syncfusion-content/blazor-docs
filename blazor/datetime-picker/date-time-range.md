---
layout: post
title: DateTime Range in Blazor Datetime Picker Component | Syncfusion
description: Checkout and learn here all about DateTime Range in Syncfusion Blazor Datetime Picker component and more.
platform: Blazor
control: Datetime Picker 
documentation: ug
---

# DateTime Range in Blazor Datetime Picker Component

## DateTime Restriction

DateTimePicker provides an option to select a date and time value within a specified range by using the [Min](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfDateTimePicker-1.html#Syncfusion_Blazor_Calendars_SfDateTimePicker_1_Min) and [Max](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfDateTimePicker-1.html#Syncfusion_Blazor_Calendars_SfDateTimePicker_1_Max) properties. The Min value must always be less than the Max value.

The `Value` property depends on the Min/Max with respect to [StrictMode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfDateTimePicker-1.html#Syncfusion_Blazor_Calendars_SfDateTimePicker_1_StrictMode) property. For more information about StrictMode, refer to the [Strict Mode](./strict-mode) section from the documentation.

The following code allows selecting a date within the range from 7th to 27th day in a month.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfDateTimePicker TValue="DateTime?" Min='@MinDateTime' Max='@MaxDateTime' Value='@DateTimeValue'></SfDateTimePicker>

@code {
    public DateTime MinDateTime {get;set;} = new DateTime(DateTime.Now.Year,DateTime.Now.Month, 7, 0, 0, 0);
    public DateTime MaxDateTime {get;set;} = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 27, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
    public DateTime? DateTimeValue {get;set;} = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 14, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
}
```


![DateTime Selection in Blazor DateTimePicker](./images/blazor-datetimepicker-selection.png)

When the Min and Max properties are configured and the selected datetime value is out-of-range or invalid, then the model value will be set to `out of range` datetime value or `null` respectively with highlighted `error` class to indicate the datetime is out of range or invalid.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfDateTimePicker TValue="DateTime?" Min='@MinDateTime' Max='@MaxDateTime' Value='@DateTimeValue'></SfDateTimePicker>

@code {
    public DateTime MinDateTime {get;set;} = new DateTime(DateTime.Now.Year,DateTime.Now.Month, 7, 0, 0, 0);
    public DateTime MaxDateTime {get;set;} = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 27, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
    public DateTime? DateTimeValue {get;set;} = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 28, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
}
```


![Blazor DateTimePicker displays Selected Date and Time](./images/blazor-datetimepicker-date-time-selection.png)

N> If the value of `Min` or `Max` properties changed through code behind, you have to update the `Value` property to set within the range.

## Time Restriction

DateTimePicker provides an option to select a time value within a specified range by using the [MinTime](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfDateTimePicker-1.html#Syncfusion_Blazor_Calendars_SfDateTimePicker_1_MinTime) and [MaxTime](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfDateTimePicker-1.html#Syncfusion_Blazor_Calendars_SfDateTimePicker_1_MaxTime) properties. The MinTime value must always be less than the MaxTime value.

The `Value` property depends on the MinTime/MaxTime with respect to [StrictMode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfDateTimePicker-1.html#Syncfusion_Blazor_Calendars_SfDateTimePicker_1_StrictMode) property. For more information about StrictMode, refer to the [Strict Mode](./strict-mode) section from the documentation.

The following code allows selecting a date within the range from 10:00 AM to 8:30 PM of each day.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfDateTimePicker TValue="DateTime?" MinTime='@MinTime' MaxTime='@MaxTime' Value='@DateTimeValue'></SfDateTimePicker>

@code {
    public DateTime DateTimeValue { get; set; } = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 9, 11, 0, 0);
    public DateTime MinTime { get; set; } = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 7, 10, 0, 0);
    public DateTime MaxTime { get; set; } = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 27, 20, 30, 0);
}
```

![Time Selection in Blazor DateTimePicker](./images/blazor-datetimepicker-time-selection.png)

When minTime and maxTime are set, the component will prioritize min if minTime is less than the current min time, and max if maxTime is greater than the current max time. Conversely, it will prioritize minTime if it is greater than the current min time, and maxTime if it is less than the current max time. These behaviors apply only when min and max Dates are selected or pre-bounded, with minTime and maxTime values set for all other dates apart from min and max dates.

The below example allows selecting a time within the range from 10:00 AM to 8:30 PM of each day.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfDateTimePicker TValue="DateTime?" MinTime='@MinTime' MaxTime='@MaxTime' Value='@DateTimeValue'></SfDateTimePicker>

@code {
    public DateTime DateTimeValue { get; set; } = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 9, 11, 0, 0);
    public DateTime MinTime { get; set; } = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 7, 10, 0, 0);
    public DateTime MaxTime { get; set; } = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 27, 20, 30, 0);
}
```

![Blazor DateTimePicker displays Time Selection](./images/blazor-datetimepicker-time-validation.png)