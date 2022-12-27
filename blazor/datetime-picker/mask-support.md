---
layout: post
title:  Mask Support in Blazor DateTimePicker Component | Syncfusion
description: Checkout and learn here all about Mask Support in Syncfusion Blazor DateTimePicker component and much more.
platform: Blazor
control: DateTimePicker
documentation: ug
---
# Mask Support in Blazor DateTimePicker Component

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

By default, the "DateTimePickerMaskPlaceholder" class uses the values of the `Day`, `Month`, `Year`, `Hour`, `Minute`, `Second`, and `DayOfWeek` properties from the current culture based resources content as the maskplaceholder characters in the input field when the "DateTimePickerMaskPlaceholder" class is not explicitly defined.

To use the "DateTimePickerMaskPlaceholder" class, you can define an instance of the class and set its properties, and then pass it to the DateTimePickerMaskPlaceholder property of the SfDateTimePicker component as shown in the following example:

{% highlight Razor %}

{% include_relative code-snippet/DateTimePickerMaskPlaceholder.razor %}

{% endhighlight %}

![Blazor DateTimePicker Mask Support with MaskPlaceholder](./images/DateTimePickerMaskPlaceholder.gif)

The "DateTimePickerMaskPlaceholder" class has the following properties:

`Day` : Specifies the placeholder character for the day (`dd`) segment of the date value.

`Month` : Specifies the placeholder character for the month (`MM`) segment of the date value.

`Year` : Specifies the placeholder character for the year (`yy`) segment of the date value.

`Hour` : Specifies the placeholder character for the hour (`hh`) segment of the time value.

`Minute` : Specifies the placeholder character for the minute (`mm`) segment of the time value.

`Second` : Specifies the placeholder character for the second (`ss`) segment of the time value.

`DayOfWeek` : Specifies the placeholder character for the dayofweek (`ddd`) segment of the date value.

When the DateTimePikerMaskPlaceholder class is defined, the contents for the "day", "month", "year", "hour", "minute", "second", and "dayofweek" segments are customized by the user. If any segment is missed by the user, it will be taken from the current culture-based resource contents by default.

You can also customize the mask pattern used by the component by using the [Format]() property.