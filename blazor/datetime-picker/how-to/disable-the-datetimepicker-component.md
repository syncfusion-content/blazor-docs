---
layout: post
title: How to disable the DateTime Picker in Blazor DateTime Picker | Syncfusion®
description: Disable the Blazor DateTime Picker using the Enabled property to prevent focus, typing, and opening the popup.
platform: Blazor
control: DateTimePicker
documentation: ug
---

# How to disable the DateTime Picker in Blazor DateTime Picker

To disable the DateTimePicker, set its [Enabled](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfDateTimePicker-1.html#Syncfusion_Blazor_Calendars_SfDateTimePicker_1_Enabled) property to `false`. When disabled, the input cannot receive focus, typing is blocked, and the popup cannot be opened. The default value is `true`. Bind `Enabled` to a property to toggle the disabled state at runtime; programmatic `Value` changes are still applied while disabled, but the input remains non-interactive.

The following example disables the component.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfDateTimePicker TValue="DateTime?" Enabled="false" Value='@DateTimeValue'></SfDateTimePicker>

@code {
    public DateTime? DateTimeValue { get; set; } = DateTime.Now;
}
```

![Blazor DateTimePicker shown in a disabled state](../images/blazor-datetimepicker-disable-state.webp)

## See also

* [Events in Blazor DateTimePicker](../events)