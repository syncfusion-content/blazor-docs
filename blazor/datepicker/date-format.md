---
layout: post
title: Date Format in Blazor DatePicker Component | Syncfusion®
description: Checkout and learn here all the features about Date Format in Blazor DatePicker component and much more.
platform: Blazor
control: DatePicker
documentation: ug
---

# Date Format in Blazor DatePicker Component

## Display Format

The display format specifies how the date value is rendered in the DatePicker input. By default, the DatePicker's format is based on the current culture (for example, `M/d/yyyy` for `en-US`). You can override the default by setting your own [.NET custom](https://learn.microsoft.com/en-us/dotnet/standard/base-types/custom-date-and-time-format-strings) or [.NET standard](https://learn.microsoft.com/en-us/dotnet/standard/base-types/standard-date-and-time-format-strings) date format string through the [Format](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfDatePicker-1.html#Syncfusion_Blazor_Calendars_SfDatePicker_1_Format) property. Once the `Format` is set, it is applied consistently to all cultures, regardless of their regional conventions.

{% highlight Razor %}

{% include_relative code-snippet/DatePicker.razor %}

{% endhighlight %}


![Date Format in Blazor DatePicker](./images/DatePicker.webp)

## Input Formats

The [InputFormats](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfDatePicker-1.html#Syncfusion_Blazor_Calendars_SfDatePicker_1_InputFormats) property accepts an array of format strings used to parse the value typed by the user. When the user finishes typing (by pressing the Enter key, the Tab key, or when the input loses focus), the entered value is parsed against the configured input formats and converted to the `Format` value. The default value of `InputFormats` is `null`, which means the culture's date pattern is used.

You can specify one or more [.NET custom](https://learn.microsoft.com/en-us/dotnet/standard/base-types/custom-date-and-time-format-strings) or [.NET standard](https://learn.microsoft.com/en-us/dotnet/standard/base-types/standard-date-and-time-format-strings) date format strings. When multiple formats are provided, each pattern is tried in order until one parses successfully. For invalid input, the [StrictMode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfDatePicker-1.html#Syncfusion_Blazor_Calendars_SfDatePicker_1_StrictMode) property controls whether the value is reset or highlighted with an error style.

{% highlight Razor %}

{% include_relative code-snippet/InputFormat.razor %}

{% endhighlight %}

## See also

* [Format](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfDatePicker-1.html#Syncfusion_Blazor_Calendars_SfDatePicker_1_Format) property
* [InputFormats](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfDatePicker-1.html#Syncfusion_Blazor_Calendars_SfDatePicker_1_InputFormats) property
* [StrictMode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfDatePicker-1.html#Syncfusion_Blazor_Calendars_SfDatePicker_1_StrictMode) property
* [Globalization in Blazor DatePicker](globalization)