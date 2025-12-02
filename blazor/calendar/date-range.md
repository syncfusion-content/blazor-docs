---
layout: post
title: Date Range in Blazor Calendar Component | Syncfusion
description: Checkout and learn here all about Date Range in the Syncfusion Blazor Calendar component and much more.
platform: Blazor
control: Calendar
documentation: ug
---

# Date Range in Blazor Calendar Component

A [Blazor Calendar](https://www.syncfusion.com/blazor-components/blazor-calendar) provides an option to select a date value within a specified range by defining the [Min](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.CalendarBase-1.html#Syncfusion_Blazor_Calendars_CalendarBase_1_Min) and [Max](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.CalendarBase-1.html#Syncfusion_Blazor_Calendars_CalendarBase_1_Max) properties. The Min date should always be lesser than the Max date.

* If the value of `Min` or `Max` properties are changed through code behind, then update the `Value` property to be set within the  specified range.

* If the value is out of specified date range and less than the Min date, the `Value` property will be updated with the Min date. If the value is higher than the Max date, the `Value` property will be updated with the Max date.

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

{% previewsample "https://blazorplayground.syncfusion.com/embed/BNBgMhBLLyBEcqBn?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[DataRange in Blazor Calendar Component](./images/blazor-calendar-date-range.png)" %}