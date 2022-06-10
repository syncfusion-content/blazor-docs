---
layout: post
title: Disabled the Blazor DatePicker Component | Syncfusion
description: Check out and learn here all about disabling the Syncfusion Blazor DatePicker Component and much more.
platform: Blazor
control: DatePicker
documentation: ug
---

# Disabled the Blazor DatePicker Component

To disable the DatePicker, use its [Enabled](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfDatePicker-1.html#Syncfusion_Blazor_Calendars_SfDatePicker_1_Enabled) property.

The following code demonstrates the DatePicker in disabled state.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfDatePicker TValue="DateTime?" Enabled=false Value="@DateValue"></SfDatePicker>

@code {
    public DateTime? DateValue {get;set;} = DateTime.Now;
}
```



![Disable State in Blazor DatePicker](../images/blazor-datepicker-disable-state.png)