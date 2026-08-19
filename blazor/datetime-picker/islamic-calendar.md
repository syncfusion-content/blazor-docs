---
layout: post
title: Islamic Calendar in Blazor DateTime Picker | Syncfusion®
description: Switch the Blazor DateTime Picker to the Islamic (Hijri) calendar to select, display, and bind date-time values in the Hijri system.
platform: Blazor
control: DateTimePicker
documentation: ug
---

# Islamic Calendar in Blazor DateTime Picker

In addition to the Gregorian calendar, the DateTimePicker component supports the Islamic (Hijri) calendar. The Islamic calendar is a lunar calendar, consisting of 12 months in a year of 354 or 355 days. Users can select a date from the Islamic calendar or manually enter a date. Additionally, helper methods such as `ConvertToHijri` and `ConvertToGregorian` can be used to convert dates between calendar systems.

The DateTimePicker retains its core features in Islamic mode, such as minimum and maximum date constraints, week numbers, first day of the week, right-to-left (RTL) support, [Start](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfDateTimePicker-1.html#Syncfusion_Blazor_Calendars_SfDateTimePicker_1_Start) and [Depth](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfDateTimePicker-1.html#Syncfusion_Blazor_Calendars_SfDateTimePicker_1_Depth) views, localization, and the ability to highlight and customize specific dates. By default, the calendar mode is Gregorian.

Enable Islamic mode by setting the [CalendarMode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfDateTimePicker-1.html#Syncfusion_Blazor_Calendars_SfDateTimePicker_1_CalendarMode) property to `CalendarType.Islamic`. The `CalendarType` enum is defined in the `Syncfusion.Blazor.Calendars` namespace and accepts `Gregorian` (default) or `Islamic`.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfDateTimePicker TValue="DateTime?" CalendarMode="CalendarType.Islamic"></SfDateTimePicker>
```

The following example demonstrates a full setup that combines the Islamic calendar with the Arabic locale.

{% highlight Razor %}

{% include_relative code-snippet/Islamic-Calendar.razor %}

{% endhighlight %}

## See also

* [Globalization in Blazor DateTimePicker](./globalization)
* [Islamic Calendar in Blazor Calendar](../calendar/islamic-calendar)