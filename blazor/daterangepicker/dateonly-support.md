---
layout: post
title:  DateOnly Support in Blazor DateRangePicker Component | Syncfusion
description: Checkout and learn here all about DateOnly Support in Syncfusion Blazor DateRangePicker component and much more.
platform: Blazor
control: DateRangePicker
documentation: ug
---

# DateOnly Support in Blazor DateRangePicker Component

The [DateOnly](https://devblogs.microsoft.com/dotnet/date-time-and-time-zone-enhancements-in-net-6/) type is a new feature of the System.DateTime structure in .NET 6 that allows you to store a date value without the time component. This can be useful in cases where you only need to store or work with a date value, without the need to store or consider the time component.

In the Synfusion Blazor DateRangePicker component, you can use the `DateOnly` type in version `20.4.38` or later, when using the .`NET 7.0` framework. This can help you to display or select a date value in the DateRangePicker, without having to worry about the time component.

The following example demonstrates the DateRangePicker component with DateOnly type.

{% highlight Razor %}

{% include_relative code-snippet/DateOnly.razor %}

{% endhighlight %}


![Blazor DateRangePicker with DateOnly](./images/DateRangePickerDateOnly.gif)