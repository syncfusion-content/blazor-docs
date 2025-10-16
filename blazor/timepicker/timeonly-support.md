---
layout: post
title:  TimeOnly Support in Blazor DatePicker Component | Syncfusion
description: Checkout and learn here all about TimeOnly Support in Syncfusion Blazor TimePicker component and much more.
platform: Blazor
control: TimePicker
documentation: ug
---

# TimeOnly Support in Blazor TimePicker Component

The [TimeOnly](https://learn.microsoft.com/en-us/dotnet/api/system.timeonly?view=net-7.0) type was introduced in .NET 6 that allows you to represent a time without a date component. To use it with the Blazor TimePicker component, set the type parameter to `TimeOnly`.

> The Blazor TimePicker component supports the `TimeOnly` type in .NET 7 and later. Although TimeOnly was introduced in .NET 6, full support in Blazor requires .NET 7 due to serialization and model binding updates.

{% highlight razor %}

{% include_relative code-snippet/TimeOnly.razor %}

{% endhighlight %}

![Blazor TimePicker bound to a TimeOnly value](./images/TimePickerTimeOnly.gif)