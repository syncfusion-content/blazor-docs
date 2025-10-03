---
layout: post
title: Add Multiple Events in Different Slots in Blazor Scheduler | Syncfusion
description: Learn here all about how to create multiple events in different time slots through CTRL key in Syncfusion Blazor Scheduler component and more.
platform: Blazor
control: Scheduler
documentation: ug
---

# Add Multiple Events in Different Slots in Blazor Scheduler Component

The Blazor Scheduler component supports selecting multiple distinct time slots (e.g., 10:00 - 10:30, 8:00 - 8:30) by holding the <kbd>CTRL</kbd> key and clicking on various cells. This functionality is handled using the `OnCellClick` event. The following example demonstrates how new events are created on these selected time slots when an **Add Appointments**button is clicked.

```cshtml
@using Syncfusion.Blazor
@using Syncfusion.Blazor.Schedule
@using Syncfusion.Blazor.Buttons

<SfButton OnClick="OnButtonClick">Add Appointments</SfButton>
<SfSchedule @ref="ScheduleObj" TValue="AppointmentData" Width="100%" Height="650px" SelectedDate="@(new DateTime(2020, 3, 10))">
    <ScheduleEventSettings DataSource="@DataSource"></ScheduleEventSettings>
    <ScheduleEvents TValue="AppointmentData" OnCellClick="OnCellClicked"></ScheduleEvents>
    <ScheduleViews>
        <ScheduleView Option="View.Day"></ScheduleView>
        <ScheduleView Option="View.Week"></ScheduleView>
        <ScheduleView Option="View.WorkWeek"></ScheduleView>
        <ScheduleView Option="View.Month"></ScheduleView>
        <ScheduleView Option="View.Agenda"></ScheduleView>
    </ScheduleViews>
</SfSchedule>

@code{
    SfSchedule<AppointmentData> ScheduleObj;
    public List<CellClickEventArgs> CellDetails = new List<CellClickEventArgs>();
    public async void OnCellClicked(CellClickEventArgs args)
    {
        if (args.MouseEventArgs.CtrlKey == true) //to check whether CTRL key is pressed
        {
            await this.ScheduleObj.CloseQuickInfoPopupAsync();
            CellClickEventArgs cell = await this.ScheduleObj.GetSelectedCellsAsync();
            CellDetails.Add(cell);
        }
    }

    public async Task OnButtonClick()
    {
        for (int i = 0; i < CellDetails.Count; i++)
        {
            Random rnd = new Random();
            int Id = rnd.Next(1000);
            List<AppointmentData> newData = new List<AppointmentData>();
            newData.Add(new AppointmentData
            {
                Id = Id,
                Subject = "Added events",
                StartTime = CellDetails[i].StartTime,
                EndTime = CellDetails[i].EndTime
            });
            await this.ScheduleObj.AddEventAsync(newData);  //to add appointments to the scheduler
        }
        CellDetails.Clear();
    }

    List<AppointmentData> DataSource = new List<AppointmentData>
    {
        new AppointmentData { Id = 1, Subject = "Eclipse", StartTime = new DateTime(2020, 3, 9, 9, 30, 0) , EndTime = new DateTime(2020, 3, 9, 11, 0, 0) },
        new  AppointmentData { Id = 2, Subject = "Crash", StartTime = new DateTime(2020, 3, 11, 11, 30, 0), EndTime = new DateTime(2020, 3, 11, 13, 0, 0)}
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
