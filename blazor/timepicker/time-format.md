---
layout: post
title: Time Format in Blazor TimePicker Component | Syncfusion
description: Checkout and learn here all about Time Format in Syncfusion Blazor TimePicker component and much more.
platform: Blazor
control: TimePicker
documentation: ug
---

# Time Format in Blazor TimePicker Component

## Display format

The display format can be used to specify how the time value is displayed or entered in a `TimePicker` control

By default, the TimePicker format is derived from the current culture. To override it, set the [Format](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfTimePicker-1.html#Syncfusion_Blazor_Calendars_SfTimePicker_1_Format) property with a custom or standard .NET date and time format string (for example, “hh:mm tt” for 12‑hour or “HH:mm” for 24‑hour formats). See the .NET guidance for [custom format strings](https://learn.microsoft.com/en-us/dotnet/standard/base-types/custom-date-and-time-format-strings) and [standard format strings](https://learn.microsoft.com/en-us/dotnet/standard/base-types/standard-date-and-time-format-strings).

> Once the date format property has been defined, it will be applied consistently to all cultures, regardless of their conventions for representing the date value. In other words, the date format property serves as a standardized way of representing the date value, ensuring that it is displayed and entered consistently regardless of the culture or region in which the application is used.

{% highlight Razor %}

{% include_relative code-snippet/TimePicker.razor %}

{% endhighlight %}


![Time Format in Blazor TimePicker](./images/TimePicker.png)

## Input formats

Use input formats to specify how users can type time values in the TimePicker.

The string format of the time value specifies how the time should be represented as a string when entered by the user. When the user types the time in the input format, it will be automatically converted to the display format after pressing enter, tab key, or when the input loses focus. This enhances the user experience by allowing intuitive data entry through various custom input formats. can also set own [Custom Format](https://learn.microsoft.com/en-us/dotnet/standard/base-types/custom-date-and-time-format-strings) or [Standard Format](https://learn.microsoft.com/en-us/dotnet/standard/base-types/standard-date-and-time-format-strings) by using the [InputFormats](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfTimePicker-1.html#Syncfusion_Blazor_Calendars_SfTimePicker_1_InputFormats) property.

{% highlight Razor %}

{% include_relative code-snippet/InputFormat.razor %}

{% endhighlight %}