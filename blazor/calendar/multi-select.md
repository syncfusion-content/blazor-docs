---
layout: post
title: Multi Selection in Blazor Calendar Component | Syncfusion
description: Checkout and learn here all about Multi Selection in Syncfusion Blazor Calendar component and much more.
platform: Blazor
control: Calendar
documentation: ug
---

# Multi Selection in Blazor Calendar Component

A [Blazor Calendar](https://www.syncfusion.com/blazor-components/blazor-calendar) provides an option to select **single** or **multiple dates** by using the [IsMultiSelection](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfCalendar-1.html#Syncfusion_Blazor_Calendars_SfCalendar_1_Values) properties. By default, the IsMultiSelection property will be in disabled state.

The following code demonstrates the functionality of IsMultiSelection and Values properties in the Calendar component.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfCalendar TValue="DateTime?" IsMultiSelection=true Values="@MultipleValues"></SfCalendar>

@code {
public DateTime[] MultipleValues { get; set; } = new DateTime[] { new DateTime(DateTime.Now.Year, DateTime.Now.Month, 10),
        new DateTime(DateTime.Now.Year, DateTime.Now.Month, 15),
        new DateTime(DateTime.Now.Year, DateTime.Now.Month, 25) };
}
```



![Multi Selection in Blazor Calendar Component](./images/blazor-calendar-multi-selection.png)