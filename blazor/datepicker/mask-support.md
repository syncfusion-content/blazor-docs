---
layout: post
title: Mask Support in Blazor DatePicker Component | Syncfusion
description: Learn how to use input mask support in the Syncfusion Blazor DatePicker, including EnableMask, Format-based patterns, and culture-aware placeholders.
platform: Blazor
control: DatePicker
documentation: ug
---

# Mask Support in Blazor DatePicker Component

The masking feature guides users to enter dates that match the display format defined by the [Format](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfDatePicker-1.html#Syncfusion_Blazor_Calendars_SfDatePicker_1_Format) property. Enable or disable this behavior using the [EnableMask](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfDatePicker-1.html#Syncfusion_Blazor_Calendars_SfDatePicker_1_EnableMask) property. When enabled, the input shows a mask pattern derived from the specified Format and the current culture, including localized separators and literals. Masking streamlines input but does not, by itself, validate out-of-range values or business rules.

{% highlight Razor %}

{% include_relative code-snippet/DatePickerMask.razor %}

{% endhighlight %}

![Blazor DatePicker with masked input using the configured Format](./images/DatePickerMask.gif)

## MaskPlaceholder

The [DatePickerMaskPlaceholder](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.DatePickerMaskPlaceholder.html) directive sets custom placeholder text for each segment of the date format in the `DatePicker` component. Use it together with [EnableMask](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfDatePicker-1.html#Syncfusion_Blazor_Calendars_SfDatePicker_1_EnableMask) to provide guidance for expected input. Placeholders apply to the segments used by the configured Format (for example, dd/MM/yyyy or MM/dd/yy).

The `DatePickerMaskPlaceholder` tag directive has the following properties:

- [Day](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.MaskPlaceholder.html#Syncfusion_Blazor_Calendars_MaskPlaceholder_Day): Placeholder text for the day segment (such as `d`/`dd`).
- [Month](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.MaskPlaceholder.html#Syncfusion_Blazor_Calendars_MaskPlaceholder_Month): Placeholder text for the month segment (such as `M`/`MM`).
- [Year](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.MaskPlaceholder.html#Syncfusion_Blazor_Calendars_MaskPlaceholder_Year): Placeholder text for the year segment (such as `yy`/`yyyy`).

By default, the component uses placeholder text from the current culture’s resource file for each date segment. To override these defaults, specify custom values using the `DatePickerMaskPlaceholder` directive.

{% highlight Razor %}

{% include_relative code-snippet/DatePickerMaskPlaceholder.razor %}

{% endhighlight %}

![Blazor DatePicker mask with custom segment placeholders](./images/DatePickerMaskPlaceholder.gif)

> If custom placeholder text is not specified for a segment, the component uses the default placeholder from the current culture’s resource file. The mask pattern and separators are culture-aware, and validation behavior (such as handling incomplete or out-of-range input) follows the component’s configuration, including properties like StrictMode.