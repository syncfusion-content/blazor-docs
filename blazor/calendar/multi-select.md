---
layout: post
title: Multi Select in Blazor Calendar Component | Syncfusion 
description: Learn about Multi Select in Blazor Calendar component of Syncfusion, and more details.
platform: Blazor
control: Calendar
documentation: ug
---

# Multi Selection

A calendar provides an option to select **single** or **multiple dates** by using the [IsMultiSelection](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfCalendar-1.html#Syncfusion_Blazor_Calendars_SfCalendar_1_Values) properties. By default, the IsMultiSelection property will be in disabled state.

The following code demonstrates the functionality of IsMultiSelection and Values properties in the Calendar component.

```csharp
@using Syncfusion.Blazor.Calendars

<SfCalendar TValue="DateTime?" IsMultiSelection=true Values="@MultipleValues"></SfCalendar>

@code {
public DateTime[] MultipleValues { get; set; } = new DateTime[] { new DateTime(DateTime.Now.Year, DateTime.Now.Month, 10),
        new DateTime(DateTime.Now.Year, DateTime.Now.Month, 15),
        new DateTime(DateTime.Now.Year, DateTime.Now.Month, 25) };
}
```

The output will be as follows.

![calendar](./images/multi-selection.png)
