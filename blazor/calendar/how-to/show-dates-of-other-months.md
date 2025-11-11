---
layout: post
title: Show Dates of Other Months in Blazor Calendar Component | Syncfusion
description: Checkout and learn here all about Show Dates of Other Months in Syncfusion Blazor Calendar component and more.
platform: Blazor
control: Calendar
documentation: ug
---

# Show Dates of Other Months in Blazor Calendar Component

The following code demonstrates how to show dates of other months. Using the styles below, you can bring the dates of other months to visibility from its hidden state.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfCalendar TValue="DateTime?"></SfCalendar>

<style>
    .e-control.e-calendar {
        max-width: 260px;
    }
    .e-calendar .e-content tr.e-month-hide,
    .e-calendar .e-content td.e-other-month>span.e-day {
        display: block;
    }

    .e-calendar .e-content td.e-month-hide,
    .e-calendar .e-content td.e-other-month {
        pointer-events: auto;
        touch-action: auto;
    }
</style>
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/hNVAsVLLLeSYtRiu?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Displaying other Month Dates in Blazor Calendar](../images/blazor-calendar-other-month-dates.png)" %}