---
layout: post
title: Working Days and Hours in Blazor Scheduler | Syncfusion
description: Learn how to customize working days, set different work hours, hide weekends, show week numbers, and configure various time-related aspects in Syncfusion Blazor Scheduler.
platform: Blazor
control: Scheduler
documentation: ug
---

# Working Days and Hours in Blazor Scheduler Component

The Syncfusion Blazor Scheduler component provides several options to customize the display of working days and hours. This article explains how to customize various time-related aspects of the Scheduler component.

## Customizing Working Days

By default, the Scheduler displays all days of the week. You can customize which days should be treated as working days using the `WorkDays` property. This property accepts an array of integers from 0 to 6, representing Sunday to Saturday.

```cshtml
<SfSchedule TValue="AppointmentData" WorkDays="@WorkingDays">
</SfSchedule>

@code {
    public int[] WorkingDays { get; set; } = { 1, 2, 3, 4, 5 }; // Monday to Friday
}
```

## Dynamically Setting Working Days

You can change the working days dynamically after the Scheduler component is rendered using the methods provided by the Scheduler component.

### Using SetWorkDaysAsync Method

The `SetWorkDaysAsync` method allows you to dynamically change the working days after the Scheduler has been initialized.

```cshtml
<SfSchedule @ref="@ScheduleRef" TValue="AppointmentData" CurrentView="View.Week">
    <ScheduleEvents TValue="AppointmentData" Created="OnCreated"></ScheduleEvents>
</SfSchedule>

@code {
    SfSchedule<AppointmentData> ScheduleRef;
    
    private async Task OnCreated()
    {
        // Set Monday to Friday as working days
        await ScheduleRef.SetWorkDaysAsync(new int[] { 1, 2, 3, 4, 5 });
    }
    
    public class AppointmentData
    {
        // Appointment data properties
    }
}
```

### Using ResetWorkDaysAsync Method

If you need to reset the working days to their default state, you can use the `ResetWorkDaysAsync` method.

```cshtml
<button @onclick="ResetWorkDays">Reset Working Days</button>

@code {
    private async Task ResetWorkDays()
    {
        await ScheduleRef.ResetWorkDaysAsync();
    }
}
```

## Hiding Weekend Days

To hide weekend days in the Scheduler, you can set the `ShowWeekend` property to `false`.

```cshtml
<SfSchedule TValue="AppointmentData" ShowWeekend="false">
</SfSchedule>
```

## Show Week Numbers

The Scheduler component allows you to display week numbers alongside the Scheduler dates. You can enable this feature by setting the `ShowWeekNumber` property to `true`.

```cshtml
<SfSchedule TValue="AppointmentData" ShowWeekNumber="true">
</SfSchedule>
```

### Different Options in Showing Week Numbers

You can also customize the format of the week numbers using the `WeekRule` property, which accepts values from the `WeekRule` enum.

```cshtml
<SfSchedule TValue="AppointmentData" ShowWeekNumber="true" WeekRule="WeekRule.FirstDay">
</SfSchedule>
```

The available options for the `WeekRule` property are:
- `FirstDay`: The week number is calculated from the first day of the year.
- `FirstFourDayWeek`: The week number is calculated from the first week that has at least 4 days.
- `FirstFullWeek`: The week number is calculated from the first full week of the year.

## Set Working Hours

Working hours in the Scheduler define the time range that will be highlighted in the UI, making it easy to identify the business hours.

### Customizing Working Hours

You can set the default working hours using the `StartHour` and `EndHour` properties of the `ScheduleView` component.

```cshtml
<SfSchedule TValue="AppointmentData">
    <ScheduleViews>
        <ScheduleView Option="View.Day" StartHour="09:00" EndHour="18:00"></ScheduleView>
        <ScheduleView Option="View.Week" StartHour="09:00" EndHour="18:00"></ScheduleView>
    </ScheduleViews>
</SfSchedule>
```

## Different Work Hours for Each Day

In real-world scenarios, you might need to set different working hours for different days. The Blazor Scheduler provides the `SetWorkHoursAsync` method to set custom work hours for specific days. Before setting custom work hours, you can reset the default work hours using the `ResetWorkHoursAsync` method.

```cshtml
@using Syncfusion.Blazor.Schedule

<SfSchedule @ref="@ScheduleRef" TValue=AppointmentData CurrentView="View.Week" Timezone="@TimeZone" ShowWeekend="false" WorkDays="@WorkingDays">
    <ScheduleTimeScale Interval="@IntervalInMinutes" SlotCount="4"></ScheduleTimeScale>
    <ScheduleGroup Resources="@Resources"></ScheduleGroup>
    <ScheduleResources>
        <ScheduleResource TItem="DoctorData" TValue="int" DataSource="@DoctorsData" Field="DoctorID" Title="Doctor" Name="Doctors" TextField="Text" IdField="Id" ColorField="Color"></ScheduleResource>
    </ScheduleResources>
    <ScheduleViews>
        <ScheduleView Option="View.Week" StartHour="@StartTime" EndHour="@EndTime"></ScheduleView>
    </ScheduleViews>
    <ScheduleEventSettings DataSource="@TimeSlots"></ScheduleEventSettings>
    <ScheduleEvents TValue="AppointmentData" Created="OnCreated" ActionCompleted="OnActionCompleted" DataBound="OnDataBound"></ScheduleEvents>
</SfSchedule>

@code {
    SfSchedule<AppointmentData>? ScheduleRef;
    public string TimeZone { get; set; } = "UTC";
    public int[] WorkingDays { get; set; } = { 0, 1, 2, 4, 5 };
    public int IntervalInMinutes { get; set; } = 60;
    public string StartTime { get; set; } = "07:00";
    public string EndTime { get; set; } = "17:00";
    public bool IsLayoutChanged = false;
    public string[] Resources { get; set; } = { "Doctors" };
    public List<DoctorData> DoctorsData { get; set; } = new List<DoctorData> {
        new DoctorData{ Text = "Nancy", Id= 1, Color = "#df5286" },
        new DoctorData{ Text = "Steven", Id= 2, Color = "#7fa900" }
    };
    List<AppointmentData> TimeSlots = new List<AppointmentData>
    {
        new AppointmentData { Id = 1, Subject = "Daily Medical check up", StartTime = new DateTime(2022, 7, 17, 14, 30, 0) , EndTime = new DateTime(2022, 7, 17, 15, 30, 0), RecurrenceRule = "FREQ=WEEKLY;BYDAY=SU,MO,TU,TH,FR,SA;INTERVAL=1;", DoctorID = 1 },
        new AppointmentData { Id = 2, Subject = "Weekly Medical check up", StartTime = new DateTime(2022, 7, 17, 15, 30, 0) , EndTime = new DateTime(2022, 7, 17, 15, 45, 0), RecurrenceRule = "FREQ=WEEKLY;BYDAY=SU;INTERVAL=1;", DoctorID = 2 }
    };
    private async Task OnCreated() {
        await SetWorkHours(); // Setting work hours after the intial rendering
    }
    private void OnActionCompleted(ActionEventArgs<AppointmentData> args)
    {
        // Enabling the IsLayoutChanged for setting up the work hours
        if (args.ActionType == ActionType.ViewNavigate || args.ActionType == ActionType.DateNavigate)
        {
            IsLayoutChanged = true;
        }
    }
    private async Task OnDataBound(DataBoundEventArgs<AppointmentData> args)
    {
        if (IsLayoutChanged)
        {           
            await SetWorkHours();  // Setting work hours once view or date range changed.
        }
    }
    private async Task SetWorkHours()
    {
        // Getting current view dates
        List <DateTime> CurrentViewDates = ScheduleRef.GetCurrentViewDates();
        List<DateTime> Sunday = new List<DateTime> { CurrentViewDates[0] };
        List<DateTime> Monday = new List<DateTime> { CurrentViewDates[1] };
        List<DateTime> TuesDay = new List<DateTime> { CurrentViewDates[2] };
        List<DateTime> ThursDay = new List<DateTime> { CurrentViewDates[3] };
        List<DateTime> Friday = new List<DateTime> { CurrentViewDates[4] };

        // Removing work hours from the Scheduler
        await ScheduleRef.ResetWorkHoursAsync(CurrentViewDates);

        // Setting work hours to Doctor one
        await ScheduleRef.SetWorkHoursAsync(Sunday, "07:00", "12:00", 0);
        await ScheduleRef.SetWorkHoursAsync(Monday, "07:00", "12:00", 0);
        await ScheduleRef.SetWorkHoursAsync(TuesDay, "09:00", "14:00", 0);        
        await ScheduleRef.SetWorkHoursAsync(ThursDay, "09:00", "17:00", 0);
        await ScheduleRef.SetWorkHoursAsync(Friday, "09:00", "17:00", 0);

        // Setting work hours to Doctor two
        await ScheduleRef.SetWorkHoursAsync(Sunday, "08:00", "13:00", 1);
        await ScheduleRef.SetWorkHoursAsync(Monday, "08:00", "13:00", 1);
        await ScheduleRef.SetWorkHoursAsync(TuesDay, "10:00", "15:00", 1);        
        await ScheduleRef.SetWorkHoursAsync(ThursDay, "10:00", "16:00", 1);
        await ScheduleRef.SetWorkHoursAsync(Friday, "10:00", "16:00", 1);
    }
    public class AppointmentData
    {
        public int Id { get; set; }
        public string? Subject { get; set; }
        public string? Location { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string? Description { get; set; }
        public bool IsAllDay { get; set; }
        public bool IsBlock { get; set; }
        public string? RecurrenceRule { get; set; }
        public string? RecurrenceException { get; set; }
        public Nullable<int> RecurrenceID { get; set; }
        public int DoctorID { get; set; }
    }
    public class DoctorData
    {
        public int Id { get; set; }
        public string? Text { get; set; }
        public string? Color { get; set; }
    }
}
```

In this example:
1. The `ResetWorkHoursAsync` method first clears existing work hours
2. The `SetWorkHoursAsync` method is then used to set different working hours for each day for each doctor (resource)
3. The method is called in various lifecycle events to ensure work hours are properly set when navigating between dates and views

## Scheduler Displaying Custom Hours

You can customize the time range displayed in the Scheduler using the `StartHour` and `EndHour` properties. This is different from working hours - it defines what time range is visible in the Scheduler.

```cshtml
<SfSchedule TValue="AppointmentData">
    <ScheduleViews>
        <ScheduleView Option="View.Day" StartHour="05:00" EndHour="22:00"></ScheduleView>
        <ScheduleView Option="View.Week" StartHour="07:00" EndHour="20:00"></ScheduleView>
    </ScheduleViews>
</SfSchedule>
```

## Setting Start Day of the Week

By default, the Scheduler starts the week from Sunday. You can customize this using the `FirstDayOfWeek` property, which accepts values from 0 (Sunday) to 6 (Saturday).

```cshtml
<SfSchedule TValue="AppointmentData" FirstDayOfWeek="1">
</SfSchedule>
```

In the above example, the week starts from Monday (1) instead of the default Sunday (0).

## Scroll to Specific Time and Date

The Scheduler provides methods to programmatically scroll to specific times and dates.

### Scroll to Specific Time

Use the `ScrollToAsync` method to scroll the Scheduler to a specific time.

```cshtml
<button @onclick="ScrollToTime">Scroll to 10:30 AM</button>

@code {
    private async Task ScrollToTime()
    {
        await ScheduleRef.ScrollToAsync("10:30");
    }
}
```

### Scroll to Specific Date

You can also scroll to a specific date in the Timeline view or Month view.

```cshtml
<button @onclick="ScrollToDate">Scroll to July 15, 2023</button>

@code {
    private async Task ScrollToDate()
    {
        await ScheduleRef.ScrollToAsync(new DateTime(2023, 7, 15));
    }
}
```

With these customization options, you can tailor the Syncfusion Blazor Scheduler to meet your specific time-related requirements.