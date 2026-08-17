---
layout: post
title: Multi Selection in Blazor Calendar | Syncfusion®
description: Enable multi-date selection in the Blazor Calendar using the IsMultiSelection property to pick multiple dates in a single interaction.
platform: Blazor
control: Calendar
documentation: ug
---

# Multi Selection in Blazor Calendar

A [Blazor Calendar](https://www.syncfusion.com/blazor-components/blazor-calendar) provides an option to select **single** or **multiple dates** by using the [IsMultiSelection](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfCalendar-1.html#Syncfusion_Blazor_Calendars_SfCalendar_1_IsMultiSelection) property. By default, `IsMultiSelection` is `false` (single-selection mode).

The following code demonstrates enabling multi-selection and preselecting multiple dates using the IsMultiSelection and Values properties.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfCalendar TValue="DateTime?" IsMultiSelection=true Values="@MultipleValues"></SfCalendar>

@code {
public DateTime[] MultipleValues { get; set; } = new DateTime[] { new DateTime(DateTime.Now.Year, DateTime.Now.Month, 10),
        new DateTime(DateTime.Now.Year, DateTime.Now.Month, 15),
        new DateTime(DateTime.Now.Year, DateTime.Now.Month, 25) };
}
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/BtBdjRsVLblhrqeB?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Multi Selection in Blazor Calendar Component](./images/blazor-calendar-multi-selection.webp)" %}