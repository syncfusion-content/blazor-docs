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

TimePicker has `EnableMask` property that provides the option to enable the built-in time masking support. This means that the TimePicker will automatically apply a mask to the time input, so that users can only enter times in a specific format. 

 For example, if the mask is set to "hh:mm", then users will only be able to enter times in the format of "hour:minute", with two digits for the hour and minute.

The following example demonstrates default format of TimePicker component with mask.

{% highlight Razor %}

{% include_relative code-snippet/TimePickerMask.razor %}

{% endhighlight %}


![Blazor TimePicker with EnableMask](./images/TimePickerMask.gif)

## TimePicker MaskPlaceholder

The TimePicker control has a property called "TimePickerMaskPlaceholder" that allows you to customize the placeholder value for the time mask. By default, this property is set to the full name of the time elements (e.g. "Hour", "Minute", "Second"), but you can change it to any value you like. 

For example, you might want to use abbreviated names like "H", "m" and "s" or you might want to use symbols like ":" and "-" to separate the different parts of time.

The following example demonstrates the custom mask placeholder for TimePicker component.

{% highlight Razor %}

{% include_relative code-snippet/TimePickerMaskPlaceholder.razor %}

{% endhighlight %}


![Blazor TimePicker Mask Support with MaskPlaceholder](./images/TimePickerMaskPlaceholder.gif)
