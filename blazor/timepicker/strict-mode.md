---
layout: post
title: Strict Mode in Blazor TimePicker Component | Syncfusion
description: Checkout and learn here all about Strict Mode in Syncfusion Blazor TimePicker component and much more.
platform: Blazor
control: TimePicker
documentation: ug
---

# Strict Mode in Blazor TimePicker Component

The [StrictMode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfTimePicker-1.html#Syncfusion_Blazor_Calendars_SfTimePicker_1_StrictMode) is an act that allows to enter only valid time value within the specified Min/Max range in the textbox. If the value is invalid, the component value sets to the previous value. If the value is out of range, the component sets the time value to Min/Max value.

The following example demonstrates the TimePicker in `StrictMode` with a `Min`/`Max` range of `10:00 AM` to `4:00 PM`. It allows entering only valid times within the specified range.

* If an out-of-range value such as `8:00 PM` is entered, the value is set to the Max time `4:00 PM` because `8:00 PM` is greater than the Max value `4:00 PM`.
* If an invalid time such as `9:00 tt` is entered, the value reverts to the previous value.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfTimePicker TValue="DateTime?" Value='@TimeValue' StrictMode=true Min='@MinVal' Max='@MaxVal'></SfTimePicker>

@code {
    public DateTime MinVal { get; set; } = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 15, 08, 00, 00);
    public DateTime MaxVal { get; set; } = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 15, 16, 00, 00);
    public DateTime? TimeValue { get; set; } = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 15, 3, 00, 00);
}
```

![Blazor TimePicker in Strict Mode](./images/blazor-timepicker-strict-mode.png)

By default, the TimePicker operates with `StrictMode` set to `false`, which allows entering invalid or out-of-range times in the textbox.

If the time is out of range or invalid, then the model value will be set to the out-of-range time value or `null`, respectively, and the input is highlighted with an `error` class to indicate that the value is out of range or invalid.

The following example demonstrates `StrictMode` set to `false`. In this mode, entering valid, invalid, or out-of-range values in the textbox is allowed.

* When an out-of-range or invalid time value is entered, the model value is set to the out-of-range time value or `null`, respectively, and the input is highlighted with an `error` class to indicate the condition.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfTimePicker TValue="DateTime?" Value='@TimeValue' StrictMode=false Min='@MinVal' Max='@MaxVal'></SfTimePicker>

@code {
    public DateTime MinVal { get; set; } = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 15, 08, 00, 00);
    public DateTime MaxVal { get; set; } = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 15, 16, 00, 00);
    public DateTime? TimeValue { get; set; } = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 15, 3, 00, 00);
}
```

![Blazor TimePicker without Strict Mode](./images/blazor-timepicker-without-strict-mode.png)

N> If the value of the `Min` or `Max` property is changed in code-behind, update the `Value` property so that it remains within the new range.