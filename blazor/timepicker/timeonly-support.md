---
layout: post
title:  TimeOnly Support in Blazor DatePicker Component | Syncfusion
description: Checkout and learn here all about TimeOnly Support in Syncfusion Blazor TimePicker component and much more.
platform: Blazor
control: TimePicker
documentation: ug
---

# TimeOnly Support in Blazor TimePicker Component

The [TimeOnly](https://learn.microsoft.com/en-us/dotnet/api/system.timeonly?view=net-7.0) type is a new type in .NET 6 that is intended to represent only a time without a date. You can use the `TimeOnly` type with the Blazor TimePicker component by defining the type param as `TimeOnly`.

The Blazor TimePicker component only supports the `TimeOnly` type in .NET 7 and above, even though it was introduced in .NET 6 itself due to...

{% highlight Razor %}

{% include_relative code-snippet/TimeOnly.razor %}

{% endhighlight %}


![Blazor TimePicker with TimeOnly](./images/TimePickerTimeOnly.gif)