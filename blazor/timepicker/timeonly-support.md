---
layout: post
title:  TimeOnly Support in Blazor DatePicker Component | Syncfusion
description: Checkout and learn here all about TimeOnly Support in Syncfusion Blazor TimePicker component and much more.
platform: Blazor
control: TimePicker
documentation: ug
---

# TimeOnly Support in Blazor TimePicker Component

The [TimeOnly](https://devblogs.microsoft.com/dotnet/date-time-and-time-zone-enhancements-in-net-6/) type is a new feature of the System.DateTime structure in .NET 6 that allows you to store a time value without the date component. This can be useful in cases where you only need to store or work with a time value, without the need to store or consider the date component.

In the Synfusion Blazor TimePicker component, you can use the `TimeOnly` type in version `20.4.38` or later, when using the `.NET 7.0` framework. This can help you to display or select a time value in the TimePicker, without having to worry about the date component.

The following example demonstrates the TimePicker component with TimeOnly type.

{% highlight Razor %}

{% include_relative code-snippet/TimeOnly.razor %}

{% endhighlight %}


![Blazor TimePicker with TimeOnly](./images/TimePickerTimeOnly.gif)