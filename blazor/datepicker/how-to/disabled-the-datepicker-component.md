---
layout: post
title: How to Disabled The Datepicker Component in Blazor DatePicker Component | Syncfusion
description: Checkout and learn about Disabled The Datepicker Component in Blazor DatePicker component of Syncfusion, and more details.
platform: Blazor
control: DatePicker
documentation: ug
---

# Disabled State

To disable the DatePicker, use its
[Enabled](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfDatePicker-1.html#Syncfusion_Blazor_Calendars_SfDatePicker_1_Enabled)
property.

The following code demonstrates the DatePicker in
disabled state.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfDatePicker TValue="DateTime?" Enabled=false Value="@DateValue"></SfDatePicker>

@code {
    public DateTime? DateValue {get;set;} = DateTime.Now;
}
```

The output will be as follows.

![datepicker](../images/disabled.png)
