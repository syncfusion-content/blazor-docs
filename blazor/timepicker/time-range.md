---
layout: post
title: Time Range in Blazor TimePicker Component | Syncfusion
description: Checkout and learn here all about Time Range in Syncfusion Blazor TimePicker component and much more.
platform: Blazor
control: TimePicker
documentation: ug
---

# Time Range in Blazor TimePicker Component

TimePicker provides an option to select a time value within a specified range by using the [Min](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfTimePicker-1.html#Syncfusion_Blazor_Calendars_SfTimePicker_1_Min) and [Max](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfTimePicker-1.html#Syncfusion_Blazor_Calendars_SfTimePicker_1_Max) properties. The Min value should always be lesser than the Max value. The `Value` property depends on the Min/Max with respect to [StrictMode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfTimePicker-1.html#Syncfusion_Blazor_Calendars_SfTimePicker_1_StrictMode) property. 

The following code allows to select a time value within a range of `9:00 AM` to `11:30 AM`. For more information about StrictMode, refer to the [Strict Mode](./strict-mode) section from the documentation.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfTimePicker TValue="DateTime?" Value='@TimeValue' Min='@MinVal' Max='@MaxVal'></SfTimePicker>

@code{
    public DateTime MinVal { get; set; } = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 15, 09, 00, 00);
    public DateTime MaxVal { get; set; } = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 15, 11, 30, 00);
    public DateTime? TimeValue { get; set; } = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 15, 11, 00, 00);
}

```

![Blazor TimePicker Value within Range](./images/blazor-timepicker-within-range.png)

When the `Min` and `Max` properties are configured and the selected time value is out-of-range or invalid, then the model value will be set to `out of range` time value or `null` respectively with highlighted `error` class to indicate that the time is out of range or invalid.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfTimePicker TValue="DateTime?" Value='@TimeValue' Min='@MinVal' Max='@MaxVal'></SfTimePicker>

@code{
    public DateTime MinVal { get; set; } = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 15, 09, 00, 00);
    public DateTime MaxVal { get; set; } = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 15, 11, 30, 00);
    public DateTime? TimeValue { get; set; } = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 15, 11, 40, 00);
}
```

![Blazor TimePicker Value without Time Range](./images/blazor-timepicker-value-without-range.png)

N> If the value of `Min` or `Max` property is changed through code behind, you have to update the `Value` property to set within the range.