---
layout: post
title:  Mask Support in Blazor DatePicker Component | Syncfusion
description: Checkout and learn here all about Mask Support in Syncfusion Blazor DatePicker component and much more.
platform: Blazor
control: DatePicker
documentation: ug
---

# Mask Support in Blazor DatePicker Component

The [EnableMask]() property in the Syncfusion Blazor Datepicker component allows you to enable or disable the masking functionality of the input field. When enabled, the component will display the input field as a masked textbox, with a specific pattern to enter the date value.

By default, the "EnableMask" property is set to `false`.

You can also customize the mask pattern used by the component by using the [Format](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfDatePicker-1.html#Syncfusion_Blazor_Calendars_SfDatePicker_1_Format) property.

The following example demonstrates default format of DatePicker component with mask.

{% highlight Razor %}

{% include_relative code-snippet/DatePickerMask.razor %}

{% endhighlight %}



![Blazor DatePicker with EnableMask](./images/DatePickerMask.gif)

## MaskPlaceholder

The [DatePickerMaskPlaceholder]() class in the Syncfusion Blazor Datepicker component is used to customize the maskplaceholders displayed in the input field when the masking functionality is enabled. 

By default, the "DatePickerMaskPlaceholder" class uses the values of the `Day`, `Month`, and `Year` properties from the current culture based resources file as the maskplaceholder characters in the input field when the "DatePickerMaskPlaceholder" class is not explicitly defined.

To use the "DatePickerMaskPlaceholder" class, you can define an instance of the class and set its properties, and then pass it to the DatePickerMaskPlaceholder property of the SfDatePicker component as shown in the following example:

{% highlight Razor %}

{% include_relative code-snippet/DatePickerMaskPlaceholder.razor %}

{% endhighlight %}



![Blazor DatePicker Mask Support with MaskPlaceholder](./images/DatePickerMaskPlaceholder.gif)


The "DatePickerMaskPlaceholder" class has the following properties:

`Day` : Specifies the placeholder character for the day (`dd`) segment of the date value.

`Month` : Specifies the placeholder character for the month (`MM`) segment of the date value.

`Year` : Specifies the placeholder character for the year (`yy`) segment of the date value.

When the DatePikerMaskPlaceholder class is defined, the contents for the "day", "month", and "year" segments are customized by the user. If any segment is missed by the user, it will be taken from the current culture-based resource contents by default.

You can also customize the mask pattern used by the component by using the [Format](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfDatePicker-1.html#Syncfusion_Blazor_Calendars_SfDatePicker_1_Format) property.