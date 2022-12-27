---
layout: post
title: Time Format in Blazor TimePicker Component | Syncfusion
description: Checkout and learn here all about Time Format in Syncfusion Blazor TimePicker component and much more.
platform: Blazor
control: TimePicker
documentation: ug
---

# Time Format in Blazor TimePicker Component

Time format is a way of representing the time value in different string formats in text box.

By default, the TimePicker's format is based on the culture. You can also set the own [Custom Format](https://learn.microsoft.com/en-us/dotnet/standard/base-types/custom-date-and-time-format-strings) or [Standard Format](https://learn.microsoft.com/en-us/dotnet/standard/base-types/standard-date-and-time-format-strings) by using the [Format](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfDatePicker-1.html#Syncfusion_Blazor_Calendars_SfDatePicker_1_Format) property.

> Once the time format property has been defined, it will be common for all the cultures.

The following code demonstrates the TimePicker with the custom format (`HH:mm:ss`).

{% highlight Razor %}

{% include_relative code-snippet/TimePicker.razor %}

{% endhighlight %}


![Time Format in Blazor TimePicker](./images/TimePicker.png)