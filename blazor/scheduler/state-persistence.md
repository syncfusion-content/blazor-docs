---
layout: post
title: State Persistence in Blazor Scheduler Component | Syncfusion
description: This section shows the way to maintain and retain the Syncfusion Blazor scheduler component states even after refreshing the page.
platform: Blazor
control: Scheduler
documentation: ug
---

# State Persistence in Blazor Scheduler Component

State persistence enables the Scheduler to retain the [CurrentView](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Schedule.SfSchedule-1.html#Syncfusion_Blazor_Schedule_SfSchedule_1_CurrentView), [SelectedDate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Schedule.SfSchedule-1.html#Syncfusion_Blazor_Schedule_SfSchedule_1_SelectedDate), and scroll position values in the [localStorage](https://www.w3schools.com/html/html5_webstorage.asp) for state maintenance, even if the browser is refreshed or navigation occurs to another page within the browser. This behavior is controlled by the [EnablePersistence](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Schedule.SfSchedule-1.html#Syncfusion_Blazor_Schedule_SfSchedule_1_EnablePersistence) property, which is set to `false` by default. When set to `true`, `CurrentView`, `SelectedDate`, and scroll position values of the Scheduler component are retained even after refreshing the page.

N> Scheduler ID is essential to set state persistence.

The following example demonstrates how to enable state persistence in the Scheduler.

```cshtml

@using Syncfusion.Blazor.Schedule

<SfSchedule TValue="AppointmentData" Height="650px" ID="Schedule" EnablePersistence="true" @bind-SelectedDate="@SelectedDate" @bind-CurrentView="@CurrentView">
    <ScheduleEventSettings DataSource="@DataSource"></ScheduleEventSettings>
    <ScheduleViews>
        <ScheduleView Option="View.Day"></ScheduleView>
        <ScheduleView Option="View.Week"></ScheduleView>
        <ScheduleView Option="View.WorkWeek"></ScheduleView>
        <ScheduleView Option="View.Month"></ScheduleView>
        <ScheduleView Option="View.Agenda"></ScheduleView>
    </ScheduleViews>
</SfSchedule>

@code {
    public DateTime SelectedDate = new DateTime(2020, 1, 9);
    public View CurrentView = View.Week;
    List<AppointmentData> DataSource = new List<AppointmentData>
{
        new AppointmentData { Id = 1, Subject = "Meeting", StartTime = new DateTime(2020, 1, 6, 9, 30, 0) , EndTime = new DateTime(2020, 1, 6, 11, 0, 0),
        RecurrenceRule = "FREQ=DAILY;INTERVAL=1;COUNT=5", RecurrenceException = "20200107T043000Z,20200109T043000Z" }
    };
    public class AppointmentData
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Nullable<bool> IsAllDay { get; set; }
        public string CategoryColor { get; set; }
        public bool IsReadonly { get; set; }
        public string RecurrenceRule { get; set; }
        public Nullable<int> RecurrenceID { get; set; }
        public string RecurrenceException { get; set; }
        public string StartTimezone { get; set; }
        public string EndTimezone { get; set; }
    }
}
```
