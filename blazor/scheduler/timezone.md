---
layout: post
title: Timezone in Blazor Scheduler Component | Syncfusion
description: This section includes the timezone topics explaining how to render the appointments in different timezones.
platform: Blazor
control: Scheduler
documentation: ug
---

# Timezone in Blazor Scheduler

The Scheduler makes use of the current system time zone by default. If it needs to follow some other user-specific time zone, then the [Timezone](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Schedule.SfSchedule-1.html#Syncfusion_Blazor_Schedule_SfSchedule_1_Timezone) property needs to be used. Apart from the default action of applying specific timezone to the Scheduler, it is also possible to set different time zone values for each appointments through the properties `StartTimezone` and `EndTimezone` which can be defined as separate fields within the event fields collection.

When no specific time zone is set to Scheduler, appointments will be displayed based on the server system’s timezone which is the default behavior. Here, the same appointment when viewed from different timezone will have different start and end times.

The appointments will be displayed based on the given `StartTime` and `EndTime` of appointment everywhere without considering the time zone.

> The given value for the Timezone property for both the Scheduler and the appointments should be in the [IANA](https://www.iana.org/time-zones) format. 

## Create appointments in different time zones

You can create appointments at different time zones using the `StartTimeZone` and `EndTimeZone` properties. An appointment’s start time and end time are calculated based on the given time zone information.

```csharp
@using Syncfusion.Blazor.Schedule

<SfSchedule TValue="AppointmentData" Width="100%" Height="550px" @bind-SelectedDate="@CurrentDate">
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
    DateTime CurrentDate = new DateTime(2020, 3, 10);
    List<AppointmentData> DataSource = new List<AppointmentData>
    {
        new AppointmentData {
            Id = 1,
            Subject = "Meeting",
            StartTime = new DateTime(2020, 3, 9, 9, 0, 0) ,
            EndTime = new DateTime(2020, 3, 9, 11, 0, 0),
            StartTimezone = "Europe/Moscow",
            EndTimezone = "Europe/Moscow"
        }
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
        public string StartTimezone { get; set; }
        public string EndTimezone { get; set; }
    }
}
```

> If the recurring appointment is converted to another time zone, then the whole sequence will be recalculated according to the new time zone information. <br /> If an all-day appointment is created, it’s start time and end time will be set to 12 A.M. and 12 A.M. by default, so time zone is not applicable for all-day appointments. <br /> Scheduler supports daylight saving time. <br /> The time zone support is applicable for custom appointments too, so map the corresponding property. <br /> Use `TimeZone` for custom appointments by mapping the `StartTimeZone` and `EndTimeZone` custom properties.

## Display Appointments based on client’s time zone

Display the appointments based on the client’s local time zone in scheduler. For example, consider a scenario that you are in North Carolina and you want to set up a meeting at 10 A.M. on North Carolina time. You have colleagues in London and Chennai, and they also need to participate. The time for this meeting will be 3 P.M. (15:00) in London and 8.30 P.M. in Chennai. When each view your Scheduler, you need to see the appointment displayed relative to your local time zones. It can be achieved by getting browser's timezone and set it's value to the scheduer time zone and appointment’s time zone to Eastern Standard Time (North Carolina) [as you are in North Carolina and it’s time zone is Eastern Standard Time].

```csharp
@using Syncfusion.Blazor.Schedule
@inject IJSRuntime JSRuntime

<SfSchedule TValue="AppointmentData" Width="100%" Height="550px" @bind-SelectedDate="@CurrentDate" Timezone="@TimezoneValue">
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
    public DateTime CurrentDate { get; set; } = new DateTime(2021, 1, 10);
    string TimezoneValue;
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            TimezoneValue = await JSRuntime.InvokeAsync<string>("eval", "(function(){try { return ''+ Intl.DateTimeFormat().resolvedOptions().timeZone; } catch(e) {} return 'UTC';}())");
            StateHasChanged();
        }
    }
    List<AppointmentData> DataSource = new List<AppointmentData>
    {
        new AppointmentData { Id = 1, Subject = "Meeting", StartTime = new DateTime(2021, 1, 11, 10, 0, 0) , EndTime = new DateTime(2021, 1 , 11, 11, 0, 0),StartTimezone = "America/New_York",
            EndTimezone = "America/New_York" }
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
        public string StartTimezone { get; set; }
        public string EndTimezone { get; set; }
    }
}
```

## Display appointments based on Scheduler time zone

Set the specific time zone to schedule using the `TimeZone` property of scheduler. On this scenario, the appointments will be displayed in UTC time when the `StartTimeZone` and `EndTimeZone` properties are set to null. The appointments will be displayed in UTC time based on the given scheduler time zone.

In the following code example, appointments will be displayed based on Europe Time (UTC+03:00).

```csharp
@using Syncfusion.Blazor.Schedule

<SfSchedule TValue="AppointmentData" Width="100%" Height="550px" @bind-SelectedDate="@CurrentDate" Timezone="@TimezoneValue">
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
    DateTime CurrentDate = new DateTime(2020, 3, 10);
    string TimezoneValue = "Europe/Moscow";
    List<AppointmentData> DataSource = new List<AppointmentData>
    {
        new AppointmentData { Id = 1, Subject = "Meeting", StartTime = new DateTime(2020, 3, 9, 9, 0, 0) , EndTime = new DateTime(2020, 3, 9, 11, 0, 0) }
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
        public string StartTimezone { get; set; }
        public string EndTimezone { get; set; }
    }
}
```

## Display appointments at same time everywhere regardless of client’s time zone

Display the appointments at the same time everywhere without considering the time zone while setting the `TimeZone` property of the scheduler, the `StartTimeZone` and `EndTimeZone` properties to null. The appointments will be displayed based on the given `StartTime` and `EndTime` of appointment everywhere without considering the time zone.

## Updating StartTime and EndTime after drag and drop appointment based on time zone.

After rescheduling an appointment using drag and drop, appointment’s start and end time value will be updated based on scheduler time zone and appointment’s time zone.

For an example, consider the local time zone is India Standard Time, if you drag an appointment from 9 AM and drop this on 1 PM and the scheduler’s `TimeZone` is not set and the appointment’s `StartTimeZone` and `EndTimeZone` has set as AUS Central Standard Time (Australia/Darwin) then appointment’s start time and end time value will be converted from Local time zone to appointment time zone and the appointment’s start time will be saved at 5 PM.

If you set scheduler’s `TimeZone` as AUS Central Standard Time (Australia/Darwin) and the appointment’s `StartTimeZone` and `EndTimeZone` as Central Standard Time (America/Mexico_City) then the appointment’s start time and end time value has converted from scheduler’s time zone to appointment time zone and the appointment’s start time will be saved at 8.30 PM.

If you set scheduler’s TimeZone as AUS Central Standard Time (Australia/Darwin) and appointment’s time zone was not set then the appointment’s start time and end time value converted from scheduler time zone to UTC time zone and the appointment’s start time will be saved at 9 AM.
