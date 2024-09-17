---
layout: post
title:  Date Format in Blazor DatePicker Component | Syncfusion
description: Checkout and learn here all about Date Format in Syncfusion Blazor DatePicker component and much more.
platform: Blazor
control: DatePicker
documentation: ug
---

#  Date Format in Blazor DatePicker Component

## Display Format

The display format can be used to specify how the date value is displayed or entered in a `DatePicker` control

The string format of the date value specifies how the date value should be represented as a string. Different countries and regions have different conventions for representing the date value in a string format. In addition to representing the date value in different string formats, it is also possible to specify the order in which the day, month, and year values appear in the string. For example, the day/month/year format could be written as `28-12-2022` or `28.12.2022`

By default, the DatePicker's format is based on the culture. You can also set the own [Custom Format](https://learn.microsoft.com/en-us/dotnet/standard/base-types/custom-date-and-time-format-strings) or [Standard Format](https://learn.microsoft.com/en-us/dotnet/standard/base-types/standard-date-and-time-format-strings) by using the [Format](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfDatePicker-1.html#Syncfusion_Blazor_Calendars_SfDatePicker_1_Format) property.

> Once the display format property has been defined, it will be applied consistently to all cultures, regardless of their conventions for representing the date value. In other words, the display format property serves as a standardized way of representing the date value, ensuring that it is displayed and entered consistently regardless of the culture or region in which the application is used.

{% highlight Razor %}

{% include_relative code-snippet/DatePicker.razor %}

{% endhighlight %}


![Date Format in Blazor DatePicker](./images/DatePicker.png)

## Input Formats

The input format can be used to specify how the date value is entered in a `DatePicker` control.

The string format of the date value specifies how the date should be represented as a string when entered by the user. When the user types the date in the input format, it will be automatically converted to the display format after pressing enter, tab key, or when the input loses focus. This enhances the user experience by allowing intuitive data entry through various custom input formats. You can also set your own [Custom Format](https://learn.microsoft.com/en-us/dotnet/standard/base-types/custom-date-and-time-format-strings) or [Standard Format](https://learn.microsoft.com/en-us/dotnet/standard/base-types/standard-date-and-time-format-strings) by using [InputFormats](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfDatePicker-1.html#Syncfusion_Blazor_Calendars_SfDatePicker_1_InputFormats) property.

{% highlight Razor %}

{% include_relative code-snippet/InputFormat.razor %}

{% endhighlight %}