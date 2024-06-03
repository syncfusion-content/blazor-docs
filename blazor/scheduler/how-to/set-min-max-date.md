---
layout: post
title: Setting Minimum and Maximum Date in Blazor Scheduler | Syncfusion
description: Learn here all about setting minimum and maximum date to the Syncfusion Blazor Scheduler component in order to display specific date range in our Scheduler.
platform: Blazor
control: Scheduler
documentation: ug
---

# Setting Minimum and Maximum Date in Blazor Scheduler Component

In Scheduler, by default all the date ranges are available. A particular date range alone can be rendered in the Scheduler by setting the date range within `MinDate` and `MaxDate` properties. In the following code example, the Scheduler has been rendered from 2020 to 2023 alone.

```cshtml
@using Syncfusion.Blazor.Schedule

<SfSchedule TValue="AppointmentData" Height="550px" MinDate="new DateTime(2020, 1, 1)" MaxDate="new DateTime(2023, 12, 31)" @bind-SelectedDate="@CurrentDate">
    <ScheduleEventSettings DataSource="@DataSource"></ScheduleEventSettings>
    <ScheduleViews>
        <ScheduleView Option="View.Day"></ScheduleView>
        <ScheduleView Option="View.Week"></ScheduleView>
        <ScheduleView Option="View.WorkWeek"></ScheduleView>
        <ScheduleView Option="View.Month"></ScheduleView>
        <ScheduleView Option="View.Agenda"></ScheduleView>
    </ScheduleViews>
</SfSchedule>

@code{
    DateTime CurrentDate = new DateTime(2020, 3, 11);
    List<AppointmentData> DataSource = new List<AppointmentData>
    {
        new AppointmentData { Id = 1, Subject = "Paris", StartTime = new DateTime(2020, 3, 10, 10, 0, 0 ) , EndTime = new DateTime(2020, 3, 10, 12, 0, 0) },
        new AppointmentData { Id = 2, Subject = "Germany", StartTime = new DateTime(2020, 3, 12, 10, 0, 0) , EndTime = new DateTime(2020, 3, 12, 12, 0, 0) }
    };
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

![Setting Minimum and Maximum Date in Blazor Scheduler](../images/blazor-scheduler-min-max-date.png)
