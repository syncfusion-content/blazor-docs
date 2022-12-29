---
layout: post
title:  DateOnly Support in Blazor DatePicker Component | Syncfusion
description: Checkout and learn here all about DateOnly Support in Syncfusion Blazor DatePicker component and much more.
platform: Blazor
control: DatePicker
documentation: ug
---

# DateOnly Support in Blazor DatePicker Component

The [DateOnly](https://learn.microsoft.com/en-us/dotnet/api/system.dateonly?view=net-7.0) type is a new struct in .NET 6 that allows you to represent a date without a time component. To use it with the Blazor DatePicker component, set the type parameter to `DateOnly`.

> Despite being introduced in .NET 6, the Blazor DatePicker component only supports the `DateOnly` type in versions of .NET 7 and higher.

{% highlight Razor %}

{% include_relative code-snippet/DateOnly.razor %}

{% endhighlight %}


![Blazor TimePicker with DateOnly](./images/DatePickerDateOnly.gif)