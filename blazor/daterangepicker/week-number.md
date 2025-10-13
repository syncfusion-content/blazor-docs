---
layout: post
title: Week Numbers in Blazor DateRangePicker Component | Syncfusion
description: Checkout and learn here all about Week Numbers in Syncfusion Blazor DateRangePicker component and more.
platform: Blazor
control: DateRangePicker
documentation: ug
---

# Week Number in Blazor DateRangePicker Component

Enable week numbers in the DateRangePicker to display the week index in the calendar’s left column by using the [WeekNumber](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.CalendarBase-1.html#Syncfusion_Blazor_Calendars_CalendarBase_1_WeekNumber) property.

```cshtml

@using Syncfusion.Blazor.Calendars

<SfDateRangePicker TValue="DateTime?" Width="250px" WeekNumber="true"></SfDateRangePicker>

```


![Blazor DateRangePicker with week numbers](./images/blazor_daterangepicker_weeknumber.png)

## Week Rule

Configure how the first week of the year is determined using the [WeekRule](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.CalendarBase-1.html#Syncfusion_Blazor_Calendars_CalendarBase_1_WeekRule) property. This setting controls how week numbers roll over at the start of the year. The following values correspond to .NET’s CalendarWeekRule:

Types  |Description  
-----|-----
FirstDay | The first week starts on the first day of the year; subsequent weeks are numbered 1, 2, 3, and so on.
FirstFullWeek | The first full week of the year is week 1; days before the first full week are counted as the last week (52 or 53) of the previous year.
FirstFourDayWeek | The first week with at least four days in the new year is week 1; otherwise, that week is counted as the last week (52 or 53) of the previous year.

N> The current culture (Locale) and the first day of the week influence week numbering. By default, the DateRangePicker uses the culture’s settings unless overridden.

![Blazor DateRangePicker displays Week Rule of FirstDay](./images/blazor-daterangepicker-first-day.png)

![Blazor DateRangePicker displays Week Rule of FirstFullWeek](./images/blazor-daterangepicker-first-full-week.png)

![Blazor DateRangePicker displays Week Rule of FirstFourDayWeek](./images/blazor-daterangepicker-first-four-Day-Week.png)