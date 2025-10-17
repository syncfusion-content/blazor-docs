---
layout: post
title: Disable the Blazor DateTimePicker Component | Syncfusion
description: Learn how to disable the Syncfusion Blazor DateTimePicker component using the Enabled property to prevent focus, typing, and opening the popup.
platform: Blazor
control: DateTimePicker
documentation: ug
---

# Disable the Blazor DateTimePicker Component

To disable the DateTimePicker, set its [Enabled](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.DateTimePickerModel-1.html#Syncfusion_Blazor_Calendars_DateTimePickerModel_1_Enabled) property to `false`. When disabled, the input cannot receive focus, typing is blocked, and the popup cannot be opened. The default value of `Enabled` is `true`, and this property can be data-bound to toggle the disabled state at runtime.

The following code demonstrates the disabled component.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfDateTimePicker TValue="DateTime?" Enabled=false Value='@DateTimeValue'></SfDateTimePicker>

@code {
    public DateTime? DateTimeValue { get; set; } = DateTime.Now;
}
```

![Blazor DateTimePicker shown in a disabled state](../images/blazor-datetimepicker-disable-state.png)