---
layout: post
title: How to Show Dates Of Other Months in Blazor Calendar Component | Syncfusion
description: Checkout and learn about Show Dates Of Other Months in Blazor Calendar component of Syncfusion, and more details.
platform: Blazor
control: Calendar
documentation: ug
---

# Show Dates of Other Months

The following code demonstrates how to show dates of other months.

Using the styles below, you can bring the dates of other months to visibility from its hidden state.

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

![calendar](../images/other_month.png)
