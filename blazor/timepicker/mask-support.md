---
layout: post
title: Mask Support in Blazor TimePicker Component | Syncfusion
description: Checkout and learn here all about Mask Support in Syncfusion Blazor TimePicker component and much more.
platform: Blazor
control: TimePicker
documentation: ug
---

# Mask Support in Blazor TimePicker Component

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

By default, the "TimePickerMaskPlaceholder" class uses the values of the `Hour`, `Minute`, and `Second` properties from the current culture based resources content as the maskplaceholder characters in the input field when the "TimePickerMaskPlaceholder" class is not explicitly defined.

To use the TimePikcerMaskPlaceholder class, you can define an instance of the class and set its properties, and then pass it to the TimePikcerMaskPlaceholder property of the SfTimePicker component as shown in the following example:

{% highlight Razor %}

{% include_relative code-snippet/TimePickerMaskPlaceholder.razor %}

{% endhighlight %}


![Blazor TimePicker Mask Support with MaskPlaceholder](./images/TimePickerMaskPlaceholder.gif)

The "TimePickerMaskPlaceholder" class has the following properties:

`Hour` : Specifies the placeholder character for the hour (`hh`) segment of the time value.

`Minute` : Specifies the placeholder character for the minute (`mm`) segment of the time value.

`Second` : Specifies the placeholder character for the second (`ss`) segment of the time value.

When the TimePikerMaskPlaceholder class is defined, the contents for the "hour", "minute", and "second" segments are customized by the user. If any segment is missed by the user, it will be taken from the current culture-based resource contents by default.

You can also customize the mask pattern used by the component by using the [Format]() property.