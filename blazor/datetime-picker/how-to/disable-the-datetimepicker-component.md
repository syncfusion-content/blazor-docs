---
layout: post
title: Disable the Blazor DateTimePicker Component | Syncfusion
description: Checkout and learn here all about disabling the Syncfusion Blazor DateTimePicker Component and much more.
platform: Blazor
control: Datetime Picker 
documentation: ug
---

# Disable the Blazor DateTimePicker Component

To disable the DateTimePicker, set its [Enabled](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.DateTimePickerModel-1.html#Syncfusion_Blazor_Calendars_DateTimePickerModel_1_Enabled) property to `false`.

The following code demonstrates the disabled component.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfDateTimePicker TValue="DateTime?" Enabled=false Value='@DateTimeValue'></SfDateTimePicker>

@code {
    public DateTime? DateTimeValue { get; set; } = DateTime.Now;
}
```


![Disable State in Blazor DateTimePicker](../images/blazor-datetimepicker-disable-state.png)