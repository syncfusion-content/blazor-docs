---
layout: post
title: DateOnly Support in Blazor DateRangePicker | Syncfusion®
description: Use the .NET DateOnly type with the Blazor DateRangePicker by setting the TValue generic to DateOnly or DateOnly? for date-only range selection.
platform: Blazor
control: DateRangePicker
documentation: ug
---

# DateOnly Support in Blazor DateRangePicker

The [DateOnly](https://learn.microsoft.com/en-us/dotnet/api/system.dateonly) type was introduced in .NET 6 and allows you to represent a date without a time component. To use it with the Blazor DateRangePicker component, set the `TValue` parameter to `DateOnly`.

> The Blazor DateRangePicker component supports the `DateOnly` type in .NET 7 and above only, even though it was introduced in .NET 6, due to a serialization problem.

{% highlight Razor %}

{% include_relative code-snippet/DateOnly.razor %}

{% endhighlight %}


![Blazor DateRangePicker with DateOnly](./images/DateRangePickerDateOnly.gif)