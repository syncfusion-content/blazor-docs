---
layout: post
title:  DateOnly Support in Blazor Calendar Component | Syncfusion
description: Checkout and learn here all about DateOnly Support in Syncfusion Blazor Calendar component and much more.
platform: Blazor
control: Calendar
documentation: ug
---

# DateOnly Support in Blazor Calendar Component

The [DateOnly](https://learn.microsoft.com/en-us/dotnet/api/system.dateonly?view=net-7.0) type is a new type in .NET 6 that is intended to represent only a date without time. You can use the `DateOnly` type with the Blazor Calendar component by defining the type param as `DateOnly`.

The Blazor Calendar component only supports the `DateOnly` type in .NET 7 and above, even though it was introduced in .NET 6 itself due to..

{% highlight Razor %}

{% include_relative code-snippet/DateOnly.razor %}

{% endhighlight %}


![Blazor Calendar with DateOnly](./images/CalendarDateOnly.gif)