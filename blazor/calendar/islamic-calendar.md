---
layout: post
title: Islamic Calendar in Blazor Calendar Component | Syncfusion
description: Checkout and learn here all about Islamic Calendar in Syncfusion Blazor Calendar component and much more.
platform: Blazor
control: Calendar
documentation: ug
---

# Islamic Calendar in Blazor Calendar Component

In addition to the Gregorian calendar, the Calendar component supports displaying the Islamic calendar (Hijri calendar). **Islamic calendar** or **Hijri calendar** is a `lunar calendar` consisting of 12 months in a year of 354 or 355 days. To know more about Islamic calendar, refer to this [wikipedia](https://en.wikipedia.org/wiki/Islamic_calendar). Also, it consists of all Gregorian calendar functionalities like min and max date, week number, start day of the week, multiselection, right to left, start and depth view, localization, highlight, and customize the specific dates.

By default, the calendar mode is in **Gregorian**. You can enable the Islamic mode by setting the **CalendarMode** as **Islamic**. The following code demonstrates how to display the Islamic Calendar (Hijri Calendar).

```cshtml
@using Syncfusion.Blazor.Calendars

<SfCalendar TValue="DateTime?" Value='@DateValue' CalendarMode="CalendarType.Islamic"></SfCalendar>

@code 
{
    public DateTime DateValue {get;set;} = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 14);
}
```

The output will be as follows.

![Blazor Calendar with Islamic Type](./images/blazor-calendar-with-islamic.png)