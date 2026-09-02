---
layout: post
title: Islamic Calendar in Blazor DatePicker | Syncfusion®
description: Switch the Blazor DatePicker to the Islamic (Hijri) calendar to select, display, and bind dates in the Hijri calendar system.
platform: Blazor
control: DatePicker
documentation: ug
---

# Islamic Calendar in Blazor DatePicker

In addition to the Gregorian calendar, the Blazor DatePicker component supports displaying the Islamic (Hijri) calendar. The Hijri calendar is a lunar calendar consisting of 12 months in a year of 354 or 355 days. Users can either select a date from the Islamic calendar or enter a date manually.

The selected date is bound as a `DateTime?` (Gregorian). The Islamic calendar is a display and selection mode only; the underlying value is stored as a standard `DateTime`. All standard DatePicker features (such as `Min`, `Max`, `WeekNumber`, `FirstDayOfWeek`, `Start`, `Depth`, `EnableRtl`, and localization) continue to work when the Islamic mode is enabled.

By default, the calendar mode is Gregorian. You can enable the Islamic mode by setting the [CalendarMode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.CalendarBase-1.html#Syncfusion_Blazor_Calendars_CalendarBase_1_CalendarMode) property (inherited from `CalendarBase<TValue>`) to [`CalendarType.Islamic`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.CalendarType.html). The available values are `CalendarType.Gregorian` (default) and `CalendarType.Islamic`.

The following example demonstrates how to display the Islamic (Hijri) calendar.

{% highlight Razor %}

{% include_relative code-snippet/Islamic-Calendar.razor %}

{% endhighlight %}

## See also

* [CalendarMode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.CalendarBase-1.html#Syncfusion_Blazor_Calendars_CalendarBase_1_CalendarMode) property
* [CalendarType](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.CalendarType.html) enum
* [Calendar component](../calendar/getting-started)
* [Date Range](date-range) 
