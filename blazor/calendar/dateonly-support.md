---
layout: post
title:  DateOnly Support in Blazor Calendar Component | Syncfusion
description: Checkout and learn here all about DateOnly Support in Syncfusion Blazor Calendar component and much more.
platform: Blazor
control: Calendar
documentation: ug
---

# DateOnly Support in Blazor Calendar Component

The [DateOnly](https://devblogs.microsoft.com/dotnet/date-time-and-time-zone-enhancements-in-net-6/) type is a new feature of the System.DateTime structure in .NET 6 that allows you to store a date value without the time component. This can be useful in cases where you only need to store or work with a date value, without the need to store or consider the time component.

In the Synfusion Blazor Calendar component, you can use the `DateOnly` type in version `20.4.38` or later, when using the `.NET 7.0` framework. This can help you to display or select a date value in the calendar, without having to worry about the time component.

The following example demonstrates the Calendar component with DateOnly type.

{% highlight Razor %}

{% include_relative code-snippet/DateOnly.razor %}

{% endhighlight %}


![Blazor Calendar with DateOnly](./images/CalendarDateOnly.gif)