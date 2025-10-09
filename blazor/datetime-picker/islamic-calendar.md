---
layout: post
title: Islamic Calendar in Blazor DateTimePicker Component | Syncfusion
description: Learn how to enable and use the Islamic (Hijri) calendar in the Syncfusion Blazor DateTimePicker component with CalendarMode set to CalendarType.Islamic.
platform: Blazor
control: Datetime Picker
documentation: ug
---

# Islamic Calendar in Blazor Datetime Picker  Component

In addition to the Gregorian calendar, the DateTimePicker component supports the Islamic (Hijri) calendar. The Islamic calendar is a lunar calendar consisting of 12 months in a year of 354 or 355 days. Users can select a date from the Islamic calendar or manually enter a date. Additionally, helper methods such as ConvertToHijri and ConvertToGregorian can be used to convert dates between calendar systems.

The DateTimePicker retains its core features in Islamic mode, such as minimum and maximum date constraints, week numbers, first day of the week, right-to-left (RTL) support, start and depth views, localization, and the ability to highlight and customize specific dates. By default, the calendar mode is Gregorian. Enable Islamic mode by setting the [CalendarMode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfDateTimePicker-1.html#Syncfusion_Blazor_Calendars_SfDateTimePicker_1_CalendarMode) property to CalendarType.Islamic. The selected value continues to be handled as a date/time value while the UI uses the Hijri calendar for display and navigation.

The following example demonstrates how to display the Islamic calendar (Hijri calendar).

{% highlight Razor %}

{% include_relative code-snippet/Islamic-Calendar.razor %}

{% endhighlight %}