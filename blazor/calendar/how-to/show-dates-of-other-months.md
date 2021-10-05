---
layout: post
title: Show Dates of Other Months in Blazor Calendar Component | Syncfusion
description: Checkout and learn here all about Show Dates of Other Months in Syncfusion Blazor Calendar component and more.
platform: Blazor
control: Calendar
documentation: ug
---

# Show Dates of Other Months in Blazor Calendar Component

The following code demonstrates how to show dates of other months. Using the styles below, you can make the hidden dates of other months visible.

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

The output will be as follows.

![Displaying other Month Dates in Blazor Calendar](../images/blazor-calendar-other-month-dates.png)