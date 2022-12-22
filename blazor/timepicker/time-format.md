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


## Mask Support in Blazor TimePicker Component

The [EnableMask]() property in the Syncfusion Blazor Timepicker component allows you to enable or disable the masking functionality of the input field. When enabled, the component will display the input field as a masked textbox, with a specific pattern to enter the time value.

You can also customize the mask pattern used by the component by using the [Format]() property.

 For example, if the mask is set to "hh:mm", then users will only be able to enter times in the format of "hour:minute", with two digits for the hour and minute.

The following example demonstrates default format of TimePicker component with mask.

{% highlight Razor %}

{% include_relative code-snippet/TimePickerMask.razor %}

{% endhighlight %}


![Blazor TimePicker with EnableMask](./images/TimePickerMask.gif)

## MaskPlaceholder

The [TimePikcerMaskPlaceholder]() class in the Syncfusion Blazor Timepicker component is used to customize the placeholder characters displayed in the input field when the masking functionality is enabled.

To use the TimePikcerMaskPlaceholder class, you can define an instance of the class and set its properties, and then pass it to the TimePikcerMaskPlaceholder property of the SfTimePicker component as shown in the following example:

{% highlight Razor %}

{% include_relative code-snippet/TimePickerMaskPlaceholder.razor %}

{% endhighlight %}


![Blazor TimePicker Mask Support with MaskPlaceholder](./images/TimePickerMaskPlaceholder.gif)

The "TimePickerMaskPlaceholder" class has the following properties:

`Hour`: Gets or sets the placeholder character for the hour portion of the time value.

`Minute`: Gets or sets the placeholder character for the minute portion of the time value.

`Second`: Gets or sets the placeholder character for the second portion of the time value.

By default, the placeholder characters for the hour, minute, and second portions of the time value are set to "Hour", "Minute", and "Second" respectively.

You can also customize the mask pattern used by the component by using the [Format]() property.