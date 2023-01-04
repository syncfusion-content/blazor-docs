---
layout: post
title:  DateOnly Support in Blazor DateRangePicker Component | Syncfusion
description: Checkout and learn here all about DateOnly Support in Syncfusion Blazor DateRangePicker component and much more.
platform: Blazor
control: DateRangePicker
documentation: ug
---

# DateOnly Support in Blazor DateRangePicker Component

The [DateOnly](https://learn.microsoft.com/en-us/dotnet/api/system.dateonly?view=net-7.0) type is a new type in .NET 6 that allows you to represent a date without a time component. To use it with the Blazor DateRangePicker component, set the type parameter to `DateOnly`.

> Blazor DateRangePicker Component supports `DateOnly` type in .NET 7 and above version only, even though it introduced in .NET 6 itself due to serialization problem.

{% highlight Razor %}

{% include_relative code-snippet/DateOnly.razor %}

{% endhighlight %}


![Blazor DateRangePicker with DateOnly](./images/DateRangePickerDateOnly.gif)