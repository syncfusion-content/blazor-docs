---
layout: post
title: Start and Depth View in Blazor DatePicker Component | Syncfusion
description: Checkout and learn here all about Start and Depth View in Syncfusion Blazor DatePicker component and more.
platform: Blazor
control: DatePicker
documentation: ug
---

# Start and Depth View in Blazor DatePicker Component

The DatePicker has the following predefined views that provides a flexible way to navigate back and forth to select the date:

| **View** | **Description** |
| --- | --- |
| Month (default) | Displays the days in a month. |
| Year | Displays the months in a year. |
| Decade | Displays the years in a decade. |

## Start view

You can use the [Start](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.CalendarBase-1.html#Syncfusion_Blazor_Calendars_CalendarBase_1_Start) property to define the initial rendering view.

The following example demonstrates how to create a DatePicker with `Decade` as initial rendering view.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfDatePicker TValue="DateTime?" Value='@DateValue' Placeholder='Select a date' Start='CalendarView.Decade'></SfDatePicker>

@code {
    public DateTime? DateValue {get;set;} = DateTime.Now;
}
```



![Blazor DatePicker displays Start View](./images/blazor-datepicker-view.png)

## Depth view

Define the [Depth](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.CalendarBase-1.html#Syncfusion_Blazor_Calendars_CalendarBase_1_Depth) property to control the view navigation.

> Always the Depth view has to be smaller than the Start view, otherwise the view restriction will be not restricted.

The following example demonstrates how to create a DatePicker that allows users to select a month.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfDatePicker TValue="DateTime?" Value='@DateValue' Placeholder='choose a date' Start='CalendarView.Decade' Depth='CalendarView.Year'></SfDatePicker>

@code {
    public DateTime? DateValue { get; set; } = DateTime.Now;
}
```

N> To learn more about Calendar views, refer to the Calendar's [Calendar Views](../calendar/calendar-views) section.