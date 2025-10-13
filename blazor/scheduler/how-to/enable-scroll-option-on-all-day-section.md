---
layout: post
title: Enable Scroller on All-Day Section in Blazor Scheduler | Syncfusion
description: Learn here all about how to enable scroll option on all-day section in Syncfusion Blazor Scheduler component when you have more number of appointments in a day.
platform: Blazor
control: Scheduler
documentation: ug
---

# Enable Scroll Option on All-Day Section in Blazor Scheduler Component

scheduled in the all-day row, viewing all of them simultaneously can become challenging. To address this, the Blazor Scheduler component provides a scroll option for the all-day row. By setting `EnableAllDayScroll` to `true` (its default value is `false`), an individual scroller is enabled for the all-day row, activating when its content exceeds its maximum height upon expansion.

N> This property is not applicable for Scheduler components where the `Height` property is set to `auto`.

```cshtml
@using Syncfusion.Blazor.Schedule

<SfSchedule TValue="AppointmentData" Height="550px" EnableAllDayScroll="true" @bind-SelectedDate="@CurrentDate">
    <ScheduleEventSettings DataSource="@generateObject()"></ScheduleEventSettings>
    <ScheduleViews>
        <ScheduleView Option="View.Day"></ScheduleView>
        <ScheduleView Option="View.Week"></ScheduleView>
        <ScheduleView Option="View.WorkWeek"></ScheduleView>
        <ScheduleView Option="View.Month"></ScheduleView>
        <ScheduleView Option="View.Agenda"></ScheduleView>
    </ScheduleViews>
</SfSchedule>
@code{
    SfSchedule<ScheduleData.RoomData> ScheduleObj;
    private View CurrentView = View.Week;
    public DateTime CurrentDate = new DateTime(2023, 6, 29);
    public List<AppointmentData> generateObject()
    {
        List<AppointmentData> appData = new List<AppointmentData>(25);
        for (int a = 0; a <= 25; a++)
        {
            appData.Add(new AppointmentData
            {
                Id = a + 1,
                Subject = "Testing",
                StartTime = new DateTime(2023, 6, 29, 0, 0, 0),
                EndTime = new DateTime(2023, 6, 30, 0, 0, 0),
                IsAllDay = true
            });
        }
        return appData;
    }

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

![Scrolling in Blazor Scheduler](../images/blazor-scheduler-scrolling.png)