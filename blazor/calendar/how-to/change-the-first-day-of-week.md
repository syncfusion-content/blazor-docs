---
layout: post
title: Change the First Day of Week in Blazor Calendar Component | Syncfusion
description: Checkout and learn here all about Change the First Day of Week in Syncfusion Blazor Calendar component and more.
platform: Blazor
control: Calendar
documentation: ug
---

# Change the First Day of Week in Blazor Calendar Component

The Calendar provides an option to change the first day of the week by using the [FirstDayOfWeek](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.CalendarBase-1.html#Syncfusion_Blazor_Calendars_CalendarBase_1_FirstDayOfWeek) property. Generally, the day of the week starts from 0 (Sunday) and ends with 6 (Saturday).

N> By default, the first day of the week is based on the current UI culture.

The following code shows the Calendar with `Tuesday` as the first day of the week.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfCalendar TValue="DateTime?" FirstDayOfWeek=2></SfCalendar>
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BNBgChhVBSnmAEDf?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Changing First Day of Week in Blazor Calendar](../images/blazor-calendar-first-day-of-week.png)