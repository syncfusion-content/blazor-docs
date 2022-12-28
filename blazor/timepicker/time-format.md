---
layout: post
title: Time Format in Blazor TimePicker Component | Syncfusion
description: Checkout and learn here all about Time Format in Syncfusion Blazor TimePicker component and much more.
platform: Blazor
control: TimePicker
documentation: ug
---

# Time Format in Blazor TimePicker Component

The time format can be used to specify how the time value is displayed or entered in a `TimePicker` control

By default, the TimePicker's format is based on the culture. You can also set the own [Custom Format](https://learn.microsoft.com/en-us/dotnet/standard/base-types/custom-date-and-time-format-strings) or [Standard Format](https://learn.microsoft.com/en-us/dotnet/standard/base-types/standard-date-and-time-format-strings) by using the [Format](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfDatePicker-1.html#Syncfusion_Blazor_Calendars_SfDatePicker_1_Format) property.

> Once the date format property has been defined, it will be applied consistently to all cultures, regardless of their conventions for representing the date value. In other words, the date format property serves as a standardized way of representing the date value, ensuring that it is displayed and entered consistently regardless of the culture or region in which the application is used.

{% highlight Razor %}

{% include_relative code-snippet/TimePicker.razor %}

{% endhighlight %}


![Time Format in Blazor TimePicker](./images/TimePicker.png)