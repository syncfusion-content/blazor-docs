---
layout: post
title: How to Set Min Max Date in Blazor Scheduler Component | Syncfusion
description: Checkout and learn about Set Min Max Date in Blazor Scheduler component of Syncfusion, and more details.
platform: Blazor
control: Scheduler
documentation: ug
---

# Setting Minimum and Maximum Date

In Scheduler, by default all the date ranges are available. We can render particular date range alone in the Scheduler by setting the date range within `MinDate` and `MaxDate` properties. In the following code example, the Scheduler has been rendered from 2020 to 2023 alone.

```csharp
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

The Scheduler with min-max date will be rendered as shown in the following image.

![Min-Max Date](../images/min-max-date.png)