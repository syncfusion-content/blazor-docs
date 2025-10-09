---
layout: post
title: Start and Depth View in Blazor DatePicker Component | Syncfusion
description: Learn how to configure Start and Depth views in the Syncfusion Blazor DatePicker to control initial view and navigation between Month, Year, and Decade.
platform: Blazor
control: DatePicker
documentation: ug
---

# Start and Depth View in Blazor DatePicker Component

The DatePicker provides predefined calendar views and properties to control the initial view and navigation depth when selecting a date.

| **View** | **Description** |
| --- | --- |
| Month (default) | Displays the days in a month. |
| Year | Displays the months in a year. |
| Decade | Displays the years in a decade. |

## Start view

Use the [Start](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.CalendarBase-1.html#Syncfusion_Blazor_Calendars_CalendarBase_1_Start) property to define the initial view shown when the popup opens. If not set, the initial view defaults to Month.

The following example demonstrates how to create a DatePicker with `Decade` as the initial view.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfDatePicker TValue="DateTime?" Value="@DateValue" Placeholder="Select a date" Start="CalendarView.Decade"></SfDatePicker>

@code {
    public DateTime? DateValue { get; set; } = DateTime.Now;
}
```

![Blazor DatePicker showing the configured start view](./images/blazor-datepicker-view.png)

## Depth view

Use the [Depth](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.CalendarBase-1.html#Syncfusion_Blazor_Calendars_CalendarBase_1_Depth) property to control how far navigation can drill down. Depth must be the same as, or a more detailed view than, Start (Month is more detailed than Year, and Year is more detailed than Decade). For DatePicker (which selects a day), set Depth to Month to enable date selection.

The following example demonstrates configuring the DatePicker to start at the Decade view and allow drilling down to the Month view (day grid) for date selection:

```cshtml
@using Syncfusion.Blazor.Calendars

<SfDatePicker TValue="DateTime?" Value="@DateValue" Placeholder="Select a date" Start="CalendarView.Decade" Depth="CalendarView.Month"></SfDatePicker>

@code {
    public DateTime? DateValue { get; set; } = DateTime.Now;
}
```

Preview of the Depth example:
- The popup initially shows a Decade view with a grid of years.
- Selecting a year drills down to the Year view (grid of months).
- Selecting a month drills down to the Month view (grid of days).
- A date is selected from the Month view, which is the configured Depth for DatePicker.

N> To learn more about Calendar views, refer to the Calendar’s [Calendar Views](../calendar/calendar-views) section.