---
layout: post
title:  Date Mask Support in Blazor DatePicker Component | Syncfusion
description: Checkout and learn here all about Date Mask Support in Syncfusion Blazor DatePicker component and much more.
platform: Blazor
control: DatePicker
documentation: ug
---

# Mask Support in Blazor DatePicker Component

DatePicker has `EnableMask` property that provides the option to enable the built-in date masking support. This means that the DatePicker will automatically apply a mask to the date input, so that users can only enter dates in a specific format. 

 > For example, if the mask is set to "MM/dd/yyyy", then users will only be able to enter dates in the format of "month/day/year", with two digits for the month, day, and year. This can be useful for ensuring that users enter dates in a consistent and accurate format, and can help to reduce errors and misunderstandings when working with dates in your application.

The following example demonstrates default and custom format of DatePicker component with mask.

{% highlight Razor %}

{% include_relative code-snippet/DatePickerMask.razor %}

{% endhighlight %}

![Blazor DatePicker with EnableMask](./images/DatePickerMask.gif)

## DatePicker MaskPlaceholder

The DatePicker control has a property called "DatePickerMaskPlaceholder" that allows you to customize the placeholder value for the date mask. By default, this property is set to the full name of the date elements (e.g. "Day", "Month", "Year"), but you can change it to any value you like. 

> For example, you might want to use abbreviated names like "D", "M", and "Y", or you might want to use symbols like "/" and "-" to separate the different parts of the date.

The following example demonstrates the custom mask placeholder for DatePicker component.

{% highlight Razor %}

{% include_relative code-snippet/DatePickerMaskPlaceholder.razor %}

{% endhighlight %}

![Blazor DatePicker Mask Support with MaskPlaceholder](./images/DatePickerMaskPlaceholder.gif)
