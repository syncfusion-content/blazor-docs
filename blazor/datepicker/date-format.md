---
layout: post
title:  Date Format in Blazor DatePicker Component | Syncfusion
description: Learn how to control display and input date formats in the Syncfusion Blazor DatePicker using .NET standard and custom format strings with culture-aware parsing.
platform: Blazor
control: DatePicker
documentation: ug
---

#  Date Format in Blazor DatePicker Component

## Display Format

The display format specifies how a date value is rendered in the DatePicker input. Use it to control the visual representation of the selected value (for example, dd-MM-yyyy, MM/dd/yyyy, or MMM dd, yyyy).

By default, the DatePicker's display format is based on the current culture. A custom or standard .NET date and time format string can be applied using the [Custom Format](https://learn.microsoft.com/en-us/dotnet/standard/base-types/custom-date-and-time-format-strings) or [Standard Format](https://learn.microsoft.com/en-us/dotnet/standard/base-types/standard-date-and-time-format-strings) options via the [Format](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfDatePicker-1.html#Syncfusion_Blazor_Calendars_SfDatePicker_1_Format) property.

> When a display format is set, it consistently controls how the value is shown, regardless of culture-specific date order or separators. The underlying value type remains DateTime/DateTime?, and localized month/day names still follow the active culture where applicable.

{% highlight Razor %}

{% include_relative code-snippet/DatePicker.razor %}

{% endhighlight %}


![Date Format in Blazor DatePicker](./images/DatePicker.png)

## Input Formats

The input format defines how users can type dates that will be parsed into a valid value in the DatePicker.

Typed input is parsed according to the current culture and any formats specified. After the user confirms input (for example, by pressing Enter or Tab, or when the input loses focus), the value is reformatted and displayed using the configured display format. You can specify [.NET custom](https://learn.microsoft.com/en-us/dotnet/standard/base-types/custom-date-and-time-format-strings) or [standard](https://learn.microsoft.com/en-us/dotnet/standard/base-types/standard-date-and-time-format-strings) patterns in the [InputFormats](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfDatePicker-1.html#Syncfusion_Blazor_Calendars_SfDatePicker_1_InputFormats) property to accept multiple input patterns (for example, d-M-yy, d/M/yyyy, yyyy-MM-dd).

{% highlight Razor %}

{% include_relative code-snippet/InputFormat.razor %}

{% endhighlight %}