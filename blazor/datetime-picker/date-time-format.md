---
layout: post
title:  DateTime Format in Blazor DateTimePicker Component | Syncfusion
description: Checkout and learn here all about DateTime Format in Syncfusion Blazor DateTimePicker component and much more.
platform: Blazor
control: DateTimePicker
documentation: ug
---
#  DateTime Format in Blazor DateTimePicker Component

## Display Date and Time format

The display date and time format can be used to specify how the date and time value is displayed or entered in a `DateTimePicker` control

By default, the DateTimePicker's format is based on the culture. You can also set the own [Custom Format](https://learn.microsoft.com/en-us/dotnet/standard/base-types/custom-date-and-time-format-strings) or [Standard Format](https://learn.microsoft.com/en-us/dotnet/standard/base-types/standard-date-and-time-format-strings) by using the [Format](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfDatePicker-1.html#Syncfusion_Blazor_Calendars_SfDatePicker_1_Format) property.

> Once the date format property has been defined, it will be applied consistently to all cultures, regardless of their conventions for representing the date value. In other words, the date format property serves as a standardized way of representing the date value, ensuring that it is displayed and entered consistently regardless of the culture or region in which the application is used.

{% highlight Razor %}

{% include_relative code-snippet/DateTimePicker.razor %}

{% endhighlight %}


![Date Time Format in Blazor DateTimePicker](./images/DateTimePicker.png)

## Input Formats

The input format can be used to specify how the date and time value is entered in a `DateTimePicker` control.

The string format of the date and time value specifies how the date and time should be represented as a string when entered by the user. When the user types the date and time in the input format, it will be automatically converted to the display format after pressing enter, tab key, or when the input loses focus. This enhances the user experience by allowing intuitive data entry through various custom input formats. You can also set your own [Custom Format](https://learn.microsoft.com/en-us/dotnet/standard/base-types/custom-date-and-time-format-strings) or [Standard Format](https://learn.microsoft.com/en-us/dotnet/standard/base-types/standard-date-and-time-format-strings) by using the [InputFormats](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfDateTimePicker-1.html#Syncfusion_Blazor_Calendars_SfDateTimePicker_1_InputFormats) property.

{% highlight Razor %}

{% include_relative code-snippet/InputFormat.razor %}

{% endhighlight %}