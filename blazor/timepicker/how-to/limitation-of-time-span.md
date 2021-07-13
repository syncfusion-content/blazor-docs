---
layout: post
title: How to Limitation Of Time Span in Blazor TimePicker Component | Syncfusion
description: Checkout and learn about Limitation Of Time Span in Blazor TimePicker component of Syncfusion, and more details.
platform: Blazor
control: TimePicker
documentation: ug
---

# Limitations of TimeSpan DataType in Timepicker

Based on [C# standard behaviour](https://docs.microsoft.com/en-us/dotnet/standard/base-types/custom-timespan-format-strings), the custom TimeSpan format specifiers  do not include placeholder separator symbols, such as the symbols that separate days from hours, hours from minutes, or seconds from fractional seconds. Instead, these symbols must be included in the custom format string as string literals. For example, "hh\\:mm\\:ss" defines a colon (:) as a separator between hours, minutes, and seconds.

```csharp

@using Syncfusion.Blazor.Calendars

<SfTimePicker TValue="TimeSpan" @bind-Value="myTime" Format="@("hh\\:mm\\:ss")"></SfTimePicker>

@code {
    TimeSpan myTime = new TimeSpan(12, 59, 59);
}

```

The output will be as follows.

![TimePicker](../images/timespan_format.png)
