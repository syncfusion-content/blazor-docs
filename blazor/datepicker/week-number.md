---
layout: post
title: Week Numbers in Blazor DatePicker Component | Syncfusion
description: Learn how to display and configure week numbers in the Syncfusion Blazor DatePicker, including the WeekNumber property and WeekRule options for defining the first week of the year.
platform: Blazor
control: DatePicker
documentation: ug
---

# Week Number in Blazor DatePicker Component

Enable week numbers in the DatePicker to display the week index in the calendar’s left column. Turn this on using the [WeekNumber](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.CalendarBase-1.html#Syncfusion_Blazor_Calendars_CalendarBase_1_WeekNumber) property.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfDatePicker TValue="DateTime?" Width="250px" WeekNumber="true"></SfDatePicker>

```

![Blazor DatePicker showing week numbers in the left column](./images/blazor_datepicker_weeknumber.png)

## Week Rule

Configure how the first week of the year is determined using the [WeekRule](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.CalendarBase-1.html#Syncfusion_Blazor_Calendars_CalendarBase_1_WeekRule) property. This setting controls how week numbers roll over at the start of the year. The following values are supported (aligned with .NET’s CalendarWeekRule):

Types  |Description  
-----|-----
FirstDay | The first week starts on the first day of the year; subsequent weeks are numbered 1, 2, 3, and so on.
FirstFullWeek | The first full week of the year is week 1; days before the first full week belong to the last week (52 or 53) of the previous year.
FirstFourDayWeek | The first week with at least four days in the new year is week 1; otherwise, the week is counted as the last week (52 or 53) of the previous year.

N> The culture (Locale) and first day of the week influence week numbering. By default, the DatePicker uses the current culture’s settings unless overridden.

![Blazor DatePicker with WeekRule set to FirstDay](./images/blazor-datepicker-first-day.png)

![Blazor DatePicker with WeekRule set to FirstFullWeek](./images/blazor-datepicker-first-full-week.png)

![Blazor DatePicker with WeekRule set to FirstFourDayWeek](./images/blazor-datepicker-first-four-Day-Week.png)