---
layout: post
title: Disabled the Blazor DatePicker Component | Syncfusion
description: Learn how to disable the Syncfusion Blazor DatePicker component using the Enabled property to prevent user input and opening the popup.
platform: Blazor
control: DatePicker
documentation: ug
---

# Disabled the Blazor DatePicker Component

Disable user interaction with the DatePicker by setting the [Enabled](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfDatePicker-1.html#Syncfusion_Blazor_Calendars_SfDatePicker_1_Enabled) property to `false`. When disabled, the input cannot receive focus, typing is blocked, and the calendar popup cannot be opened. The default value of `Enabled` is `true`, and this property can be data-bound to enable or disable the component dynamically at runtime.

The following code demonstrates the DatePicker in a disabled state.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfDatePicker TValue="DateTime?" Enabled=false Value="@DateValue"></SfDatePicker>

@code {
    public DateTime? DateValue {get;set;} = DateTime.Now;
}
```

![Blazor DatePicker shown in a disabled state](../images/blazor-datepicker-disable-state.png)