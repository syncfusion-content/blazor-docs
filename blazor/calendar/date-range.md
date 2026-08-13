---
layout: post
title: Date Range in Blazor Calendar Component | Syncfusion®
description: Checkout and learn here all features about Date Range in the Blazor Calendar component and much more.
platform: Blazor
control: Calendar
documentation: ug
---

# Date Range in Blazor Calendar Component

A [Blazor Calendar](https://www.syncfusion.com/blazor-components/blazor-calendar) provides an option to select a date value within a specified range by defining the [Min](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.CalendarBase-1.html#Syncfusion_Blazor_Calendars_CalendarBase_1_Min) and [Max](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.CalendarBase-1.html#Syncfusion_Blazor_Calendars_CalendarBase_1_Max) properties. The range is inclusive (Min and Max are selectable), and Min must be less than or equal to Max. The Calendar is date-based; time components of DateTime are ignored when evaluating the range.

N> * If the value of `Min` or `Max` properties is changed through code-behind, update the `Value` property to fall within the specified range.
* If the `Value` is out of the specified date range, dates outside the range are disabled in the calendar UI.

The following code allows you to select a date within the range of 7th to 27th day in a month.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfCalendar TValue="DateTime?" Min='@MinDate' Max='@MaxDate' Value='@DateValue'></SfCalendar>

@code{
    public DateTime MinDate {get;set;} = new DateTime(DateTime.Now.Year,DateTime.Now.Month,07);
    public DateTime MaxDate {get;set;} = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 27);
    public DateTime? DateValue {get;set;} = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 14);
}
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/LNVRtRshrFnXUsXL?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[DataRange in Blazor Calendar Component](./images/blazor-calendar-date-range.webp)" %}
