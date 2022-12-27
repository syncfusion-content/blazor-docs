---
layout: post
title:  Date Format in Blazor DatePicker Component | Syncfusion
description: Checkout and learn here all about Date Format in Syncfusion Blazor DatePicker component and much more.
platform: Blazor
control: DatePicker
documentation: ug
---

#  Date Format in Blazor DatePicker Component

Date format is a way of representing the date value in different string formats in text box.

By default, the DatePicker's format is based on the culture. You can also set the own [Custom Format](https://learn.microsoft.com/en-us/dotnet/standard/base-types/custom-date-and-time-format-strings) or [Standard Format](https://learn.microsoft.com/en-us/dotnet/standard/base-types/standard-date-and-time-format-strings) by using the [Format](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfDatePicker-1.html#Syncfusion_Blazor_Calendars_SfDatePicker_1_Format) property.

> Once the date format property has been defined, it will be common for all the cultures.

The following code demonstrates the DatePicker with the custom format (`yyyy-MM-dd`).

{% highlight Razor %}

{% include_relative code-snippet/DatePicker.razor %}

{% endhighlight %}



![Date Format in Blazor DatePicker](./images/DatePicker.png)