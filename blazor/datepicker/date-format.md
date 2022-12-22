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

## Mask Support in Blazor DatePicker Component

The [EnableMask]() property in the Syncfusion Blazor Datepicker component allows you to enable or disable the masking functionality of the input field. When enabled, the component will display the input field as a masked textbox, with a specific pattern to enter the date value.

By default, the "EnableMask" property is set to `false`.

You can also customize the mask pattern used by the component by using the [Format](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfDatePicker-1.html#Syncfusion_Blazor_Calendars_SfDatePicker_1_Format) property.

The following example demonstrates default format of DatePicker component with mask.

{% highlight Razor %}

{% include_relative code-snippet/DatePickerMask.razor %}

{% endhighlight %}



![Blazor DatePicker with EnableMask](./images/DatePickerMask.gif)

## MaskPlaceholder

The [DatePickerMaskPlaceholder]() class in the Syncfusion Blazor Datepicker component is used to customize the placeholder characters displayed in the input field when the masking functionality is enabled.

To use the "DatePickerMaskPlaceholder" class, you can define an instance of the class and set its properties, and then pass it to the DatePickerMaskPlaceholder property of the SfDatePicker component as shown in the following example:

{% highlight Razor %}

{% include_relative code-snippet/DatePickerMaskPlaceholder.razor %}

{% endhighlight %}



![Blazor DatePicker Mask Support with MaskPlaceholder](./images/DatePickerMaskPlaceholder.gif)


The "DatePickerMaskPlaceholder" class has the following properties:

`Day` : Gets or sets the placeholder character for the day portion of the date value.

`Month` : Gets or sets the placeholder character for the month portion of the date value.

`Year` : Gets or sets the placeholder character for the year portion of the date value.

By default, the placeholder characters for the day, month, and year portions of the date value are set to "Day", "Month", and "Year" respectively.

You can also customize the mask pattern used by the component by using the [Format](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfDatePicker-1.html#Syncfusion_Blazor_Calendars_SfDatePicker_1_Format) property.