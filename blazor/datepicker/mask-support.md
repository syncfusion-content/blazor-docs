---
layout: post
title:  Mask Support in Blazor DatePicker Component | Syncfusion
description: Checkout and learn here all about Mask Support in Syncfusion Blazor DatePicker component and much more.
platform: Blazor
control: DatePicker
documentation: ug
---

# Mask Support in Blazor DatePicker Component

The masking feature allows users to enter a date in the correct format, as specified by the [Format](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfDatePicker-1.html#Syncfusion_Blazor_Calendars_SfDatePicker_1_Format) property. This helps to ensure that the date is entered correctly and can also make it easier for users to understand how to enter the date. The [EnableMask]() property in the DatePicker component allows you to enable or disable the masking functionality. When enabled, the input field will be displayed as masked with a specific date format pattern for entering the date.

By default, the `EnableMask` property is set to `false`.

The following example demonstrates default format of DatePicker component with mask.

{% highlight Razor %}

{% include_relative code-snippet/DatePickerMask.razor %}

{% endhighlight %}



![Blazor DatePicker with EnableMask](./images/DatePickerMask.gif)

## MaskPlaceholder

The [DatePickerMaskPlaceholder]() directive sets the placeholder text for each segment of the date format in a `DatePicker` component. It can be used to provide additional context or instructions to the user about the format that is expected for the input. To use the directive, include it in the component's configuration along with the [EnableMask]() property.

The `DatePickerMaskPlaceholder` tag directive has the following properties:

* [Day]() : Specifies the placeholder text for the day (`dd`) segment of the date value.

* [Month]() : Specifies the placeholder text for the month (`MM`) segment of the date value.

* [Year]() : Specifies the placeholder text for the year (`yy`) segment of the date value.

By default, the format placeholder text for each segment of the date format in the `DatePicker` component is taken from the current culture based resources file. This means that if you do not specify your own custom placeholder text using the `DatePickerMaskPlaceholder` directive and its properties, the component will use the default placeholder text from the resources file.

{% highlight Razor %}

{% include_relative code-snippet/DatePickerMaskPlaceholder.razor %}

{% endhighlight %}

![Blazor DatePicker Mask Support with MaskPlaceholder](./images/DatePickerMaskPlaceholder.gif)

> If you do not specify custom placeholder text for any segment of the date format, the component will use the default placeholder text from the current culture based resources file for not specified segments.