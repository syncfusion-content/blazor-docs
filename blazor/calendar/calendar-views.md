---
layout: post
title: Calendar Views in Blazor Calendar Component | Syncfusion
description: Learn here all about Calendar Views in Syncfusion Blazor Calendar component and more.
platform: Blazor
control: Calendar
documentation: ug
---

# Calendar Views in Blazor Calendar Component

A Calendar has the following predefined views
that provide a flexible way to navigate back and forth when selecting dates.

| **View** | **Description** |
| --- | --- |
| Month (default) | Displays the days in a month. |
| Year | Displays the months in a year. |
| Decade | Displays the years in a decade. |

## Set the initial view

When view is defined to the [Start](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.CalendarBase-1.html#Syncfusion_Blazor_Calendars_CalendarBase_1_Start)
property of the Calendar, it allows you to set the initial view on rendering.

The following example demonstrates how to set the `Year` as the start view of the Calendar.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfCalendar TValue="DateTime?" Value='@DateValue' Start="CalendarView.Year"></SfCalendar>

@code {
    public DateTime DateValue {get;set;} = DateTime.Now;
}
```

The output will be as follows.

![calendar](./images/year_view.png)

## View Restriction

By defining the Start and Depth property with the different view, drill-
down and drill-up views navigation can be limited to the users. Calendar views will be drill-down up to the view which is set in [Depth](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.CalendarBase-1.html#Syncfusion_Blazor_Calendars_CalendarBase_1_Depth) property and drill-up up to the view which is set in [Start](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfCalendar-1.html) property.

The following example displays the Calendar in `Decade` view, and allows you to select a date in `Month` view.

> Depth view should always be smaller than the Start view. If the `Depth` and `Start` views are the same, then the Calendar view remains unchanged.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfCalendar TValue="DateTime?" Value='@DateValue' Start="CalendarView.Decade" Depth="CalendarView.Year"></SfCalendar>

@code {
    public DateTime DateValue {get;set;} = DateTime.Now;
}
```

The output will be as follows.

![calendar](./images/view_restriction.png)