---
layout: post
title:  TimeOnly Support in Blazor DatePicker Component | Syncfusion
description: Checkout and learn here all about TimeOnly Support in Syncfusion Blazor TimePicker component and much more.
platform: Blazor
control: TimePicker
documentation: ug
---

# TimeOnly Support in Blazor TimePicker Component

The [TimeOnly](https://learn.microsoft.com/en-us/dotnet/api/system.timeonly?view=net-7.0) type is a new struct in .NET 6 that allows you to represent a time without a date component. To use it with the Blazor TimePicker component, set the type parameter to `TimeOnly`.

> Despite being introduced in .NET 6, the Blazor TimePicker component only supports the `TimeOnly` type in versions of .NET 7 and higher.

{% highlight Razor %}

{% include_relative code-snippet/TimeOnly.razor %}

{% endhighlight %}


![Blazor TimePicker with TimeOnly](./images/TimePickerTimeOnly.gif)