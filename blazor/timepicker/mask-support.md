---
layout: post
title: Mask Support in Blazor TimePicker Component | Syncfusion
description: Checkout and learn here all about Mask Support in Syncfusion Blazor TimePicker component and much more.
platform: Blazor
control: TimePicker
documentation: ug
---

# Mask Support in Blazor TimePicker Component

The masking feature enforces time entry in the correct format defined by the [Format](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfTimePicker-1.html#Syncfusion_Blazor_Calendars_SfTimePicker_1_Format) property. This helps ensure accurate input and provides clear guidance on how to enter time values. Enable or disable masking using the [EnableMask](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfTimePicker-1.html#Syncfusion_Blazor_Calendars_SfTimePicker_1_EnableMask) property. When enabled, the input field displays a mask pattern that matches the specified time format. Mask behavior also respects the current [Locale](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfTimePicker-1.html#Syncfusion_Blazor_Calendars_SfTimePicker_1_Locale) and culture-specific time patterns.

{% highlight Razor %}

{% include_relative code-snippet/TimePickerMask.razor %}

{% endhighlight %}

![Blazor TimePicker with input mask enabled](./images/TimePickerMask.gif)

## MaskPlaceholder

The [TimePickerMaskPlaceholder](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.TimePickerMaskPlaceholder.html) directive lets you specify custom placeholder text for each segment of the time format in a `TimePicker` component. This helps communicate the expected input format to users. Use this directive together with the [EnableMask](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfTimePicker-1.html#Syncfusion_Blazor_Calendars_SfTimePicker_1_EnableMask) property.

The `TimePickerMaskPlaceholder` class exposes the following properties:

* [Hour](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.MaskPlaceholder.html#Syncfusion_Blazor_Calendars_MaskPlaceholder_Hour): Specifies the placeholder text for the hour (`hh`) segment.
* [Minute](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.MaskPlaceholder.html#Syncfusion_Blazor_Calendars_MaskPlaceholder_Minute): Specifies the placeholder text for the minute (`mm`) segment.
* [Second](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.MaskPlaceholder.html#Syncfusion_Blazor_Calendars_MaskPlaceholder_Second): Specifies the placeholder text for the second (`ss`) segment.

By default, the `TimePicker` uses placeholder text from the current culture’s resource file for each segment of the time format. To override these defaults, define custom text using the `TimePickerMaskPlaceholder` directive and its properties. If a segment (for example, `Second`) is not part of the configured `Format`, its corresponding placeholder is ignored.

{% highlight Razor %}

{% include_relative code-snippet/TimePickerMaskPlaceholder.razor %}

{% endhighlight %}

![Blazor TimePicker with custom mask placeholders](./images/TimePickerMaskPlaceholder.gif)

> If custom placeholder text is not specified for a segment, the component uses the default placeholder text from the current culture-based resource file for that segment.