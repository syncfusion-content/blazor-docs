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


![Blazor DateTimePicker with EnableMask](./images/DateTimePicker.png)

## Mask Support in Blazor DateTimePicker Component

DateTimePicker has `EnableMask` property that provides the option to enable the built-in date and time masking support. This means that the DateTimePicker will automatically apply a mask to the date and time input, so that users can only enter dates and times in a specific format. 

 > For example, if the mask is set to "MM/dd/yyyy hh:mm", then users will only be able to enter dates and times in the format of "month/day/year hour:minute", with two digits for the month, day, year, hour and minute.

The following example demonstrates default and custom format of DateTimePicker component with mask.

{% highlight Razor %}

{% include_relative code-snippet/DateTimePickerMask.razor %}

{% endhighlight %}

![Blazor DateTimePicker with EnableMask](./images/DateTimePickerMask.gif)

## DateTimePicker MaskPlaceholder

The DateTimePicker control has a property called "DateTimePickerMaskPlaceholder" that allows you to customize the placeholder value for the date time mask. By default, this property is set to the full name of the date and time elements (e.g. "Day", "Month", "Year", "Hour", "Minute", "Second" and "DayOfWeek"), but you can change it to any value you like. 

> For example, you might want to use abbreviated names like "D", "M", "Y", "H", "m", "s" and "DDD" or you might want to use symbols like "/" and "-" to separate the different parts of the date and time.

The following example demonstrates the custom mask placeholder for DateTimePicker component.

{% highlight Razor %}

{% include_relative code-snippet/DateTimePickerMaskPlaceholder.razor %}

{% endhighlight %}

![Blazor DateTimePicker Mask Support with MaskPlaceholder](./images/DateTimePickerMaskPlaceholder.gif)
