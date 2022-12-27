---
layout: post
title:  Mask Support in Blazor DateTimePicker Component | Syncfusion
description: Checkout and learn here all about Mask Support in Syncfusion Blazor DateTimePicker component and much more.
platform: Blazor
control: DateTimePicker
documentation: ug
---
# Mask Support in Blazor DateTimePicker Component

The masking feature allows users to enter a date and time in the correct format, as specified by the [Format](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfDatePicker-1.html#Syncfusion_Blazor_Calendars_SfDatePicker_1_Format) property. This helps to ensure that the date and time is entered correctly and can also make it easier for users to understand how to enter the date and time. The [EnableMask]() property in the DateTimePicker component allows you to enable or disable the masking functionality. When enabled, the input field will be displayed as masked with a specific datetime format pattern for entering the date and time.

By default, the "EnableMask" property is set to `false`.

You can also customize the mask pattern used by the component by using the [Format]() property. 

The following example demonstrates default and custom format of DateTimePicker component with mask.

{% highlight Razor %}

{% include_relative code-snippet/DateTimePickerMask.razor %}

{% endhighlight %}

![Blazor DateTimePicker with EnableMask](./images/DateTimePickerMask.gif)

## MaskPlaceholder

The [DateTimePickerMaskPlaceholder]() directive sets the placeholder text for each segment of the date and time format in a `DateTimePicker` component. It can be used to provide additional context or instructions to the user about the format that is expected for the input. To use the directive, include it in the component's configuration along with the [EnableMask]() property.

The `DateTimePickerMaskPlaceholder` tag directive has the following properties:

* [Day]() : Specifies the placeholder text for the day (`dd`) segment of the date value.

* [Month]() : Specifies the placeholder text for the month (`MM`) segment of the date value.

* [Year]() : Specifies the placeholder text for the year (`yy`) segment of the date value.

* [Hour]() : Specifies the placeholder text for the hour (`hh`) segment of the time value.

* [Minute]() : Specifies the placeholder text for the minute (`mm`) segment of the time value.

* [Second](): Specifies the placeholder text for the second (`ss`) segment of the time value.

* [DayOfWeek]() : Specifies the placeholder text for the day of the week (`dddd`) segment of the date value.

By default, the format placeholder text for each segment of the date and time format in the `DateTimePicker` component is taken from the current culture based resources file. This means that if you do not specify your own custom placeholder text using the `DateTimePickerMaskPlaceholder` directive and its properties, the component will use the default placeholder text from the resources file.

{% highlight Razor %}

{% include_relative code-snippet/DateTimePickerMaskPlaceholder.razor %}

{% endhighlight %}

![Blazor DateTimePicker Mask Support with MaskPlaceholder](./images/DateTimePickerMaskPlaceholder.gif)

> If you do not specify custom placeholder text for any segment of the date and time format, the component will use the default placeholder text from the current culture based resources file for not specified segments.