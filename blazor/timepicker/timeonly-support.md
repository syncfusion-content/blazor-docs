---
layout: post
title:  TimeOnly Support in Blazor DatePicker Component | Syncfusion
description: Checkout and learn here all about TimeOnly Support in Syncfusion Blazor TimePicker component and much more.
platform: Blazor
control: TimePicker
documentation: ug
---

# TimeOnly Support in Blazor TimePicker Component

The [TimeOnly](https://learn.microsoft.com/en-us/dotnet/api/system.timeonly?view=net-7.0) type is a new type in .NET 6 that allows you to represent a time without a date component. To use it with the Blazor TimePicker component, set the type parameter to `TimeOnly`.

> Blazor TimePicker Component supports `TimeOnly` type in .NET 7 and above version only, even though it introduced in .NET 6 itself due to serialization problem.

{% highlight Razor %}

{% include_relative code-snippet/TimeOnly.razor %}

{% endhighlight %}


![Blazor TimePicker with TimeOnly](./images/TimePickerTimeOnly.gif)