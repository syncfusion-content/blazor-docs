---
layout: post
title: Mask Support in Blazor DateTimePicker Component | Syncfusion
description: Learn how to use input mask support in the Syncfusion Blazor DateTimePicker, including EnableMask, Format-based patterns, and culture-aware placeholders for date and time.
platform: Blazor
control: DateTimePicker
documentation: ug
---
# Mask Support in Blazor DateTimePicker Component

The masking feature guides users to enter date and time values that match the display format defined by the [Format](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfDatePicker-1.html#Syncfusion_Blazor_Calendars_SfDatePicker_1_Format) property. Enable or disable masking using the [EnableMask](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfDatePicker-1.html#Syncfusion_Blazor_Calendars_SfDatePicker_1_EnableMask) property. When enabled, the input shows a mask pattern derived from the configured format and the current culture (including localized separators and literals). Masking improves guidance during entry but does not, by itself, validate out-of-range values or business rules.

{% highlight Razor %}

{% include_relative code-snippet/DateTimePickerMask.razor %}

{% endhighlight %}

![Blazor DateTimePicker with EnableMask](./images/DateTimePickerMask.gif)

## MaskPlaceholder

The [DateTimePickerMaskPlaceholder](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.DateTimePickerMaskPlaceholder.html) directive allows custom placeholder text for each segment of the date and time format in a `DateTimePicker`. Use it together with [EnableMask](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfDatePicker-1.html#Syncfusion_Blazor_Calendars_SfDatePicker_1_EnableMask) to provide clear guidance for expected input. Placeholders apply to the segments used by the configured format (for example, dd/MM/yyyy hh:mm:ss).

The `DateTimePickerMaskPlaceholder` tag directive has the following properties:

* [Day](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.MaskPlaceholder.html#Syncfusion_Blazor_Calendars_MaskPlaceholder_Day) : Placeholder text for the day segment (such as `d`/`dd`).
* [Month](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.MaskPlaceholder.html#Syncfusion_Blazor_Calendars_MaskPlaceholder_Month) : Placeholder text for the month segment (such as `M`/`MM`).
* [Year](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.MaskPlaceholder.html#Syncfusion_Blazor_Calendars_MaskPlaceholder_Year) : Placeholder text for the year segment (such as `yy`/`yyyy`).
* [Hour](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.MaskPlaceholder.html#Syncfusion_Blazor_Calendars_MaskPlaceholder_Hour) : Placeholder text for the hour segment (such as `h`/`hh`).
* [Minute](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.MaskPlaceholder.html#Syncfusion_Blazor_Calendars_MaskPlaceholder_Minute) : Placeholder text for the minute segment (`m`/`mm`).
* [Second](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.MaskPlaceholder.html#Syncfusion_Blazor_Calendars_MaskPlaceholder_Second): Placeholder text for the second segment (`s`/`ss`).
* [DayOfWeek](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.MaskPlaceholder.html#Syncfusion_Blazor_Calendars_MaskPlaceholder_DayOfWeek) : Placeholder text for the weekday segment (`ddd`/`dddd`).

By default, the component uses placeholder text from the current culture’s resource file for each date and time segment. To override these defaults, specify custom values using the `DateTimePickerMaskPlaceholder` directive.

{% highlight Razor %}

{% include_relative code-snippet/DateTimePickerMaskPlaceholder.razor %}

{% endhighlight %}

![Blazor DateTimePicker Mask Support with MaskPlaceholder](./images/DateTimePickerMaskPlaceholder.gif)

> If custom placeholder text is not specified for a segment, the component uses the default placeholder text from the current culture’s resource file for that segment. The mask pattern and separators are culture-aware, and validation behavior (such as handling incomplete or out-of-range input) follows the component’s configuration, including properties like StrictMode.