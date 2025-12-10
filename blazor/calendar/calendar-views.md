---
layout: post
title: Calendar Views in Blazor Calendar Component | Syncfusion
description: Checkout and learn here all about Calendar Views in Syncfusion Blazor Calendar component and much more.
platform: Blazor
control: Calendar
documentation: ug
---

# Calendar Views in Blazor Calendar Component

A [Blazor Calendar](https://www.syncfusion.com/blazor-components/blazor-calendar) has the following predefined views that provide a flexible way to navigate back and forth when selecting dates.

| **View** | **Description** |
| --- | --- |
| Month (default) | Displays the days in a month. |
| Year | Displays the months in a year. |
| Decade | Displays the years in a decade. |

## Set the initial view

Use the [Start](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.CalendarBase-1.html#Syncfusion_Blazor_Calendars_CalendarBase_1_Start) property to set the initial (top) view when the Calendar renders. The Start view also acts as the upper limit for drill-up navigation.

The following example demonstrates how to set the `Year` as the start view of the Calendar.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfCalendar TValue="DateTime?" Value='@DateValue' Start="CalendarView.Year"></SfCalendar>

@code {
    public DateTime DateValue {get;set;} = DateTime.Now;
}
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/LXLUsVVVhopruWLg?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Changing Blazor Calendar View](./images/blazor-full-calendar-view.png)" %}

## View restriction

By defining the Start and Depth property with different views, drill-down and drill-up navigation can be limited. Calendar views will drill down to the view set in the [Depth](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.CalendarBase-1.html#Syncfusion_Blazor_Calendars_CalendarBase_1_Depth) property and drill up to the view set in the [Start](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfCalendar-1.html) property. Start represents a broader view and Depth represents a more detailed view within the hierarchy (Month < Year < Decade).

The following example displays the Calendar in `Decade` view and allows selecting a date by drilling down to the `Month` view.

N> The Depth view must be “smaller” (more detailed) than the Start view. If the `Depth` and `Start` views are the same, the Calendar view remains unchanged and navigation between views is disabled.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfCalendar TValue="DateTime?" Value='@DateValue' Start="CalendarView.Decade" Depth="CalendarView.Year"></SfCalendar>

@code 
{
    public DateTime DateValue {get;set;} = DateTime.Now;
}
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/BZVgsLhhhofIigEl?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Restriction in Blazor Calendar](./images/blazor-calendar-restriction.png)" %}
