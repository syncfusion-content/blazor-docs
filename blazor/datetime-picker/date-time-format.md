---
layout: post
title: DateTime Format in Blazor DateTimePicker Component | Syncfusion
description: Checkout and learn here all about DateTime Format in Syncfusion Blazor DateTimePicker component and much more.
platform: Blazor
control: DateTimePicker
documentation: ug
---
# DateTime Format in Blazor DateTimePicker Component

## Display date and time format

The display format defines how the date and time value is shown (and parsed) in the DateTimePicker.

By default, the DateTimePicker’s format is based on the current culture. You can also apply a [custom](https://learn.microsoft.com/en-us/dotnet/standard/base-types/custom-date-and-time-format-strings) or [standard](https://learn.microsoft.com/en-us/dotnet/standard/base-types/standard-date-and-time-format-strings) .NET date and time format by using the [Format](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfDateTimePicker-1.html#Syncfusion_Blazor_Calendars_SfDateTimePicker_1_Format) property.

> When a format string is specified, it is used consistently regardless of culture settings. This provides a predictable, standardized representation for both display and entry.

{% highlight Razor %}

{% include_relative code-snippet/DateTimePicker.razor %}

{% endhighlight %}


![Date Time Format in Blazor DateTimePicker](./images/DateTimePicker.png)

## Input Formats

The input format controls how users can type date and time values in the DateTimePicker.

The string formats specified for input determine acceptable user-entered patterns. When the user types a date and time in one of the input formats, it is automatically parsed and then displayed using the configured display format after pressing Enter/Tab or when the input loses focus. This allows flexible, intuitive entry using multiple patterns. Configure acceptable formats with the [InputFormats](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfDateTimePicker-1.html#Syncfusion_Blazor_Calendars_SfDateTimePicker_1_InputFormats) property, using .NET [custom](https://learn.microsoft.com/en-us/dotnet/standard/base-types/custom-date-and-time-format-strings) or [standard](https://learn.microsoft.com/en-us/dotnet/standard/base-types/standard-date-and-time-format-strings) date/time format strings.

{% highlight Razor %}

{% include_relative code-snippet/InputFormat.razor %}

{% endhighlight %}