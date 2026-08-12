---
layout: post
title: TimeOnly Support in Blazor TimePicker | Syncfusion
description: Bind the .NET TimeOnly type to Blazor TimePicker in .NET 7 and later applications and modern Blazor projects.
platform: Blazor
control: TimePicker
documentation: ug
---

# TimeOnly Support in Blazor TimePicker

The [TimeOnly](https://learn.microsoft.com/en-us/dotnet/api/system.timeonly?view=net-7.0) type is a new type in .NET 6 that allows you to represent a time without a date component. To use it with the Blazor TimePicker component, set the type parameter to `TimeOnly`.

> Blazor TimePicker Component supports `TimeOnly` type in .NET 7 and above version only, even though it was introduced in .NET 6 itself due to a serialization problem in .NET 6.

{% highlight Razor %}

{% include_relative code-snippet/TimeOnly.razor %}

{% endhighlight %}


![Blazor TimePicker with TimeOnly](./images/TimePickerTimeOnly.gif)

## See also

* [Data Binding in Blazor TimePicker](data-binding)
* [Time Format in Blazor TimePicker](time-format)
* [Time Range in Blazor TimePicker](time-range)