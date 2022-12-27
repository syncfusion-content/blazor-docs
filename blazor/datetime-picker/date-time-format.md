---
layout: post
title:  DateTime Format in Blazor DateTimePicker Component | Syncfusion
description: Checkout and learn here all about DateTime Format in Syncfusion Blazor DateTimePicker component and much more.
platform: Blazor
control: DateTimePicker
documentation: ug
---
#  DateTime Format in Blazor DateTimePicker Component

Date time format is a way of representing the date time value in different string formats in text box.

By default, the DateTimePicker's format is based on the culture. You can also set the own [Custom Format](https://learn.microsoft.com/en-us/dotnet/standard/base-types/custom-date-and-time-format-strings) or [Standard Format](https://learn.microsoft.com/en-us/dotnet/standard/base-types/standard-date-and-time-format-strings) by using the [Format](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfDatePicker-1.html#Syncfusion_Blazor_Calendars_SfDatePicker_1_Format) property.

> Once the date time format property has been defined, it will be common for all the cultures.

The following code demonstrates the DatePicker with the custom format (`yyyy-MM-dd hh:mm:ss`).

{% highlight Razor %}

{% include_relative code-snippet/DateTimePicke.razor %}

{% endhighlight %}


![Date Time Format in Blazor DateTimePicker](./images/DateTimePicker.png)