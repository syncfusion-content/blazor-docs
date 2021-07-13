---
layout: post
title: Header Rows in Blazor Scheduler Component | Syncfusion 
description: Learn about Header Rows in Blazor Scheduler component of Syncfusion, and more details.
platform: Blazor
control: Scheduler
documentation: ug
---

# Timeline header rows

The Timeline views can have additional header rows other than its default date and time header rows. It is possible to show individual header rows for displaying year, month and week separately using the `ScheduleHeaderRow` which is applicable only on the timeline views. The possible rows which can be added using `ScheduleHeaderRow` are as follows.

* `Year`
* `Month`
* `Week`
* `Date`
* `Hour`

> The `Hour` row is not applicable for Timeline month view.

The following example shows the Scheduler displaying all the available header rows on timeline views.

```csharp
@using Syncfusion.Blazor.Schedule

<SfSchedule TValue="AppointmentData" Height="650px">
    <ScheduleHeaderRows>
        <ScheduleHeaderRow Option="HeaderRowType.Year"></ScheduleHeaderRow>
        <ScheduleHeaderRow Option="HeaderRowType.Month"></ScheduleHeaderRow>
        <ScheduleHeaderRow Option="HeaderRowType.Week"></ScheduleHeaderRow>
        <ScheduleHeaderRow Option="HeaderRowType.Date"></ScheduleHeaderRow>
        <ScheduleHeaderRow Option="HeaderRowType.Hour"></ScheduleHeaderRow>
    </ScheduleHeaderRows>
    <ScheduleViews>
        <ScheduleView Option="View.TimelineWeek" MaxEventsPerRow="10"></ScheduleView>
    </ScheduleViews>
</SfSchedule>

@code{
    public class AppointmentData
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Location { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Description { get; set; }
        public bool IsAllDay { get; set; }
        public string RecurrenceRule { get; set; }
        public string RecurrenceException { get; set; }
        public Nullable<int> RecurrenceID { get; set; }
    }
}
```

## Display year and month rows in timeline views

To display the timeline Scheduler simply with year and month names alone, define the option `Year` and `Month` within the `ScheduleHeaderRow` property.

```csharp
@using Syncfusion.Blazor.Schedule

<SfSchedule TValue="AppointmentData" Height="650px">
    <ScheduleHeaderRows>
        <ScheduleHeaderRow Option="HeaderRowType.Year"></ScheduleHeaderRow>
        <ScheduleHeaderRow Option="HeaderRowType.Month"></ScheduleHeaderRow>
    </ScheduleHeaderRows>
    <ScheduleViews>
        <ScheduleView Option="View.TimelineMonth" MaxEventsPerRow="10" Interval="24"></ScheduleView>
    </ScheduleViews>
</SfSchedule>
@code{
    public class AppointmentData
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Location { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Description { get; set; }
        public bool IsAllDay { get; set; }
        public string RecurrenceRule { get; set; }
        public string RecurrenceException { get; set; }
        public Nullable<int> RecurrenceID { get; set; }
    }
}
```

## Display week numbers in timeline views

The week number can be displayed in a separate header row of the timeline Scheduler by setting `Week` option within `ScheduleHeaderRow` property.

```csharp
@using Syncfusion.Blazor.Schedule

<SfSchedule TValue="AppointmentData" Height="650px">
    <ScheduleHeaderRows>
        <ScheduleHeaderRow Option="HeaderRowType.Week"></ScheduleHeaderRow>
        <ScheduleHeaderRow Option="HeaderRowType.Date"></ScheduleHeaderRow>
        <ScheduleHeaderRow Option="HeaderRowType.Hour"></ScheduleHeaderRow>
    </ScheduleHeaderRows>
    <ScheduleViews>
        <ScheduleView Option="View.TimelineWeek" MaxEventsPerRow="10"></ScheduleView>
        <ScheduleView Option="View.TimelineMonth" MaxEventsPerRow="10"></ScheduleView>
    </ScheduleViews>
</SfSchedule>
@code{
    public class AppointmentData
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Location { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Description { get; set; }
        public bool IsAllDay { get; set; }
        public string RecurrenceRule { get; set; }
        public string RecurrenceException { get; set; }
        public Nullable<int> RecurrenceID { get; set; }
    }
}
```

## Timeline view displaying dates of a complete year

It is possible to display a complete year in a timeline view by setting `Interval` value as 12 and defining **TimelineMonth** view option within the `ScheduleView` tag helper.

```csharp
@using Syncfusion.Blazor.Schedule

<SfSchedule TValue="AppointmentData" Height="650px">
    <ScheduleHeaderRows>
        <ScheduleHeaderRow Option="HeaderRowType.Month"></ScheduleHeaderRow>
        <ScheduleHeaderRow Option="HeaderRowType.Date"></ScheduleHeaderRow>
    </ScheduleHeaderRows>
    <ScheduleViews>
        <ScheduleView Option="View.TimelineMonth" MaxEventsPerRow="10" Interval="12"></ScheduleView>
    </ScheduleViews>
</SfSchedule>
@code{
    public class AppointmentData
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Location { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Description { get; set; }
        public bool IsAllDay { get; set; }
        public string RecurrenceRule { get; set; }
        public string RecurrenceException { get; set; }
        public Nullable<int> RecurrenceID { get; set; }
    }
}
```

## Customizing the header rows using template

You can customize the text of the header rows and display any images or formatted text on each individual header rows using the built-in `Template` option available within the `ScheduleHeaderRow`.

```csharp
@using Syncfusion.Blazor.Schedule
@using System.Globalization
<p>Timeline header rows</p>
<SfSchedule TValue="AppointmentData" Height="650px">
    <ScheduleHeaderRows>
        <ScheduleHeaderRow Option="HeaderRowType.Year">
            <Template>
                <div class="date-text">Year: @(getYearText((context as TemplateContext).Date))</div>
            </Template>
        </ScheduleHeaderRow>
        <ScheduleHeaderRow Option="HeaderRowType.Month">
            <Template>
                <div class="date-text">Month: @(getMonthText((context as TemplateContext).Date))</div>
            </Template>
        </ScheduleHeaderRow>
        <ScheduleHeaderRow Option="HeaderRowType.Week">
            <Template>
                <div class="date-text">Week: @(getWeekText((context as TemplateContext).Date))</div>
            </Template>
        </ScheduleHeaderRow>
        <ScheduleHeaderRow Option="HeaderRowType.Date">
            <Template>
                <div class="date-text">@(getDateHeaderText((context as TemplateContext).Date))</div>
            </Template>
        </ScheduleHeaderRow>
    </ScheduleHeaderRows>
    <ScheduleViews>
        <ScheduleView Option="View.TimelineWeek" MaxEventsPerRow="10"></ScheduleView>
    </ScheduleViews>
</SfSchedule>
@code{
    public class AppointmentData
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Location { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Description { get; set; }
        public bool IsAllDay { get; set; }
        public string RecurrenceRule { get; set; }
        public string RecurrenceException { get; set; }
        public Nullable<int> RecurrenceID { get; set; }
    }
    public static string getYearText(DateTime date)
    {
        return date.ToString("yyyy", CultureInfo.InvariantCulture);
    }
    public static string getMonthText(DateTime date)
    {
        return date.ToString("MMMM", CultureInfo.InvariantCulture);
    }
    public static string getWeekText(DateTime date)
    {
        return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(date, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday).ToString();
    }
    public static string getDateHeaderText(DateTime date)
    {
        return date.ToString("dd ddd", CultureInfo.InvariantCulture);
    }
}
```