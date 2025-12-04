---
layout: post
title: Islamic Calendar in Blazor Calendar Component | Syncfusion
description: Checkout and learn here all about Islamic Calendar in the Syncfusion Blazor Calendar component and much more.
platform: Blazor
control: Calendar
documentation: ug
---

# Islamic Calendar in Blazor Calendar Component

In addition to the Gregorian calendar, the Blazor Calendar component supports displaying the Islamic (Hijri) calendar. The Hijri calendar is a lunar calendar with 12 months and 354 or 355 days per year. To render the Islamic calendar, set the [CalendarMode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfCalendar-1.html#Syncfusion_Blazor_Calendars_SfCalendar_1_CalendarMode) property to CalendarType.Islamic. This switches the calendar system used for display and selection.


Also, it consists of all Gregorian calendar functionalities as like min and max date, week number, start day of the week, multi selection, enable RTL, start and depth view, localization, highlight and customize the specific dates.By default, calendar mode is in Gregorian.

The following example demonstrates how to display the Islamic calendar (Hijri calendar).

{% highlight Razor %}

{% include_relative code-snippet/Islamic-Calendar.razor %}

{% endhighlight %}