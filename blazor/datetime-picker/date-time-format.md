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

## Mask Support in Blazor DateTimePicker Component

The [EnableMask]() property in the Syncfusion Blazor DateTimepicker component allows you to enable or disable the masking functionality of the input field. When enabled, the component will display the input field as a masked textbox, with a specific pattern to enter the date and time values.

By default, the "EnableMask" property is set to `false`.

You can also customize the mask pattern used by the component by using the [Format]() property. 

The following example demonstrates default and custom format of DateTimePicker component with mask.

{% highlight Razor %}

{% include_relative code-snippet/DateTimePickerMask.razor %}

{% endhighlight %}

![Blazor DateTimePicker with EnableMask](./images/DateTimePickerMask.gif)

## MaskPlaceholder

The [DateTimePickerMaskPlaceholder]() class in the Syncfusion Blazor DateTimepicker component is used to customize the placeholder characters displayed in the input field when the masking functionality is enabled.

To use the "DateTimePickerMaskPlaceholder" class, you can define an instance of the class and set its properties, and then pass it to the DateTimePickerMaskPlaceholder property of the SfDateTimePicker component as shown in the following example:

{% highlight Razor %}

{% include_relative code-snippet/DateTimePickerMaskPlaceholder.razor %}

{% endhighlight %}

![Blazor DateTimePicker Mask Support with MaskPlaceholder](./images/DateTimePickerMaskPlaceholder.gif)

The "DateTimePickerMaskPlaceholder" class has the following properties:

`Day` : Gets or sets the placeholder character for the day portion of the date value.

`Month` : Gets or sets the placeholder character for the month portion of the date value.

`Year` : Gets or sets the placeholder character for the year portion of the date value.

`Hour` : Gets or sets the placeholder character for the hour portion of the time value.

`Minute` : Gets or sets the placeholder character for the minute portion of the time value.

`Second` : Gets or sets the placeholder character for the second portion of the time value.

`WeekOfDay` : Gets or sets the placeholder character for the WeekOfDay portion of the date value.

By default, the placeholder characters for the day, month, and year portions of the date value are set to "Day", "Month", and "Year", respectively. The placeholder characters for the hour, minute, and second portions of the time value are set to "Hour", "Minute", and "Second", respectively.

You can also customize the mask pattern used by the component by using the [Format]() property.