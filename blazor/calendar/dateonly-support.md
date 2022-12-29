---
layout: post
title:  DateOnly Support in Blazor Calendar Component | Syncfusion
description: Checkout and learn here all about DateOnly Support in Syncfusion Blazor Calendar component and much more.
platform: Blazor
control: Calendar
documentation: ug
---

# DateOnly Support in Blazor Calendar Component

The [DateOnly](https://learn.microsoft.com/en-us/dotnet/api/system.dateonly?view=net-7.0) type is a new struct in .NET 6 that allows you to represent a date without a time component. To use it with the Blazor Calendar component, set the type parameter to `DateOnly`.

> Despite being introduced in .NET 6, the Blazor Calendar component only supports the `DateOnly` type in versions of .NET 7 and higher.

{% highlight Razor %}

{% include_relative code-snippet/DateOnly.razor %}

{% endhighlight %}


![Blazor Calendar with DateOnly](./images/CalendarDateOnly.gif)