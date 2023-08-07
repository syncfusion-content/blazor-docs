---
layout: post
title:  DateTime Format in Blazor DateTimePicker Component | Syncfusion
description: Checkout and learn here all about DateTime Format in Syncfusion Blazor DateTimePicker component and much more.
platform: Blazor
control: DateTimePicker
documentation: ug
---
#  DateTime Format in Blazor DateTimePicker Component

The date and time format can be used to specify how the date and time value is displayed or entered in a `DateTimePicker` control

By default, the DateTimePicker's format is based on the culture. You can also set the own [Custom Format](https://learn.microsoft.com/en-us/dotnet/standard/base-types/custom-date-and-time-format-strings) or [Standard Format](https://learn.microsoft.com/en-us/dotnet/standard/base-types/standard-date-and-time-format-strings) by using the [Format](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfDatePicker-1.html#Syncfusion_Blazor_Calendars_SfDatePicker_1_Format) property.

> Once the date format property has been defined, it will be applied consistently to all cultures, regardless of their conventions for representing the date value. In other words, the date format property serves as a standardized way of representing the date value, ensuring that it is displayed and entered consistently regardless of the culture or region in which the application is used.

{% highlight Razor %}

{% include_relative code-snippet/DateTimePicker.razor %}

{% endhighlight %}


![Date Time Format in Blazor DateTimePicker](./images/DateTimePicker.png)