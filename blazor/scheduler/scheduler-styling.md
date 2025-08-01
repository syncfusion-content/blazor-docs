---
layout: post
title: Style And Appearance in Blazor Scheduler Component | Syncfusion
description: This section shows classes available to add customized CSS to Syncfusion Blazor scheduler component by overriding the default CSS.
platform: Blazor
control: Scheduler
documentation: ug
---

# Style And Appearance in Blazor Scheduler Component

To modify the Scheduler appearance, you need to override the default CSS of Scheduler. Also, there is an option to create our own custom theme using [Theme Studio](https://blazor.syncfusion.com/themestudio/?theme=material). Find the list of CSS classes in Scheduler.

| CSS class | Purpose |
|-------|---------|
| .e-schedule .e-vertical-view .e-work-cells | Work cells in vertical views of scheduler |
| .e-schedule .e-month-view .e-work-cells | Work cells in month view of scheduler |
| .e-schedule .e-month-view .e-other-month | Work cells of other month in month view of scheduler |
| .e-schedule .e-timeline-view .e-work-cells | Work cells in timeline views of scheduler |
| .e-schedule .e-timeline-month-view .e-work-cells | Work cells in timeline month view of scheduler |
| .e-schedule .e-timeline-year-view .e-work-cells | Work cells in timeline year view of scheduler |
| .e-schedule .e-timeline-year-view .e-work-cells.e-other-month | Work cells of other month in timeline year view of scheduler |
| .e-schedule .e-month-agenda-view .e-work-cells | Work cells in month agenda view of scheduler |
| .e-schedule .e-month-agenda-view .e-other-month | Work cells of other month in month agenda view of scheduler |
| .e-schedule .e-year-view .e-calendar-wrapper .e-month-calendar.e-calendar .e-other-month | Work cells of other month in year view of scheduler |
| .e-schedule .e-vertical-view .e-all-day-cells | All day cells in vertical views of scheduler |
| .e-schedule .e-vertical-view .e-work-hours | Work hour cells in vertical views of scheduler |
| .e-schedule .e-month-view .e-work-days | Work day cells in month view of scheduler |
| .e-schedule .e-month-agenda-view .e-work-days | Work day cells in month agenda view of scheduler |
| .e-schedule .e-timeline-view .e-work-hours | Work hour cells in timeline views of scheduler |
| .e-schedule .e-timeline-month-view .e-work-days | Work day cells in timeline month view of scheduler |
| .e-schedule .e-timeline-year-view .e-work-cells.e-work-days | Work day cells in timeline year view of scheduler |
| .e-schedule .e-vertical-view .e-day-wrapper .e-appointment | Appointment in vertical views of scheduler |
| .e-schedule .e-vertical-view .e-all-day-appointment-wrapper .e-appointment | All day Appointment in vertical views of scheduler |
| .e-schedule .e-month-view .e-appointment | Appointment in month view of scheduler |
| .e-schedule .e-timeline-view .e-appointment | Appointment in timeline views of scheduler |
| .e-schedule .e-timeline-month-view .e-appointment | Appointment in timeline month view of scheduler |
| .e-schedule .e-timeline-year-view .e-event-table .e-appointment | Appointment in timeline year view of scheduler |
| .e-schedule .e-year-view .e-calendar-wrapper .e-month-calendar.e-calendar .e-appointment | Appointment in year view of scheduler |
| .e-schedule .e-agenda-view .e-appointment | Appointment in agenda view of scheduler |
| .e-schedule .e-month-agenda-view .e-appointment-indicator | Appointment in month agenda view of scheduler |
| .e-schedule .e-block-appointment | Block appointment in scheduler |
| .e-schedule .e-read-only | Read only appointment in scheduler. |
| e-appointment-border | Appointment which are currently selected, use the appointment class hierarchical based on your views. |
| e-selected-cells | Work cells which are currently selected, use the work cell class hierarchical based on your views. |
| e-header-cells | Header cells of scheduler, use the work cells hierarchical based on your views. |
| .e-schedule .e-vertical-view .e-resource-cells| Resource cells in vertical views of scheduler. |
| .e-schedule .e-month-view .e-resource-cells| Resource cells in month view of scheduler. |
| .e-schedule .e-timeline-view .e-resource-cells | Resource cells in timeline views of scheduler. |
| .e-schedule .e-timeline-month-view .e-resource-cells| Resource cells in timeline month view of scheduler. |
| e-parent-node | Parent resource cells in timeline views of scheduler. |
| e-child-node | Child resource cells in timeline views of scheduler. |

# Work cells in vertical views of scheduler

This CSS selector targets the work cells in the vertical views (Day, Week, and WorkWeek) of the Syncfusion Scheduler component. These cells represent the individual time slots arranged vertically where appointments are displayed and can be scheduled.

```cshtml

@using Syncfusion.Blazor.Schedule
<div class="component-container">
    <SfSchedule TValue="AppointmentData" Height="650px" @bind-SelectedDate="@CurrentDate">
        <ScheduleViews>
            <ScheduleView Option="View.Day"></ScheduleView>
            <ScheduleView Option="View.Week"></ScheduleView>
            <ScheduleView Option="View.WorkWeek"></ScheduleView>
            <ScheduleView Option="View.Month"></ScheduleView>
            <ScheduleView Option="View.Agenda"></ScheduleView>
        </ScheduleViews>
    </SfSchedule>
</div>

@code{
    DateTime CurrentDate = new DateTime(2020, 2, 14);
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
<style>
    .e-schedule .e-vertical-view .e-work-cells
    {
        background-color: #ebf3ff;
        border: 1px solid #cceeff;
    }
</style>

```

{% previewsample "https://blazorplayground.syncfusion.com/embed/BDLSjzXQfGnvGHlh?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Work cells in vertical views](images/blazor-scheduler-verticalview-workcells.png)" %}

# Work cells in month view of scheduler

This CSS selector targets the work cells (day cells) that belong to the current month in the month view of the Syncfusion Scheduler. These cells represent the individual days of the displayed month where users can schedule and view appointments.

```cshtml

@using Syncfusion.Blazor.Schedule
<div class="component-container">
    <SfSchedule TValue="AppointmentData" Height="650px" @bind-SelectedDate="@CurrentDate">
        <ScheduleViews>
            <ScheduleView Option="View.Month"></ScheduleView>
        </ScheduleViews>
    </SfSchedule>
</div>

@code{
    DateTime CurrentDate = new DateTime(2020, 2, 14);
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
<style>
    .e-schedule .e-month-view .e-work-cells
    {
        background-color:rgb(150, 244, 166);
        border: 1px solid #cceeff;
    }
</style>

```

{% previewsample "https://blazorplayground.syncfusion.com/embed/LXBSXpMdpcPUpdLW?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Work cells in month view](images/blazor-scheduler-monthview-workcells.png)" %}

#  Work cells of other month in month view of scheduler

This CSS selector targets the work cells that represent days from adjacent months (previous or next month) that are visible in the current month view of the scheduler. These cells typically appear at the beginning and end of a month view to complete the week rows.

```cshtml

@using Syncfusion.Blazor.Schedule
<div class="component-container">
    <SfSchedule TValue="AppointmentData" Height="650px" @bind-SelectedDate="@CurrentDate">
        <ScheduleViews>
            <ScheduleView Option="View.Month"></ScheduleView>
        </ScheduleViews>
    </SfSchedule>
</div>

@code{
    DateTime CurrentDate = new DateTime(2020, 2, 14);
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
<style>
    .e-schedule .e-month-view .e-other-month 
    {
        background-color:rgb(218, 207, 240);
        opacity: 0.7;
        color: #999999;
    }
</style>

```

{% previewsample "https://blazorplayground.syncfusion.com/embed/LDVoDfinplIYBcIi?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Other month work cells in month view](images/blazor-scheduler-othermonth-workcells.png)" %}

#  Work cells in timeline views of scheduler

This CSS selector targets the work cells in the standard timeline views of the Syncfusion Scheduler. These cells represent time slots arranged horizontally across the scheduler.

```cshtml

@using Syncfusion.Blazor.Schedule
<div class="component-container">
    <SfSchedule TValue="AppointmentData" Height="650px" @bind-SelectedDate="@CurrentDate">
        <ScheduleViews>
            <ScheduleView Option="View.TimelineDay"></ScheduleView>
            <ScheduleView Option="View.TimelineWeek"></ScheduleView>
        </ScheduleViews>
    </SfSchedule>
</div>

@code{
    DateTime CurrentDate = new DateTime(2020, 2, 14);
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
<style>
    .e-schedule .e-timeline-view .e-work-cells 
    {
        background-color: rgb(119, 165, 234);
        border: 2px solid #dce7fa;
        min-width: 120px;
    }
</style>

```

{% previewsample "https://blazorplayground.syncfusion.com/embed/LtVetzsdeXJJNgsX?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Work cells in timeline views](images/blazor-scheduler-timelineview-workcells.png)" %}

#  Work cells in timeline month view of scheduler

This CSS selector targets the work cells in the timeline month view of the Syncfusion Scheduler component.

```cshtml

@using Syncfusion.Blazor.Schedule
<div class="component-container">
    <SfSchedule TValue="AppointmentData" Height="650px" @bind-SelectedDate="@CurrentDate">
        <ScheduleViews>
            <ScheduleView Option="View.TimelineMonth"></ScheduleView>
        </ScheduleViews>
    </SfSchedule>
</div>

@code{
    DateTime CurrentDate = new DateTime(2020, 2, 14);
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
<style>
    .e-schedule .e-timeline-month-view .e-work-cells
    {
        background-color:rgb(239, 186, 220);
        border: 1px solid rgb(31, 196, 36);
    }
</style>

```

{% previewsample "https://blazorplayground.syncfusion.com/embed/hZhSXIXUeKvJllyA?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Work cells in timeline month views](images/blazor-scheduler-timelinemonth-workcells.png)" %}

#  Work cells in timeline year view of scheduler

This CSS selector targets the work cells in the timeline year view of the Syncfusion Scheduler component. These cells represent time slots across the entire year, arranged in a timeline format that provides an overview of appointments throughout the entire year.

```cshtml

@using Syncfusion.Blazor.Schedule
<div class="component-container">
    <SfSchedule TValue="AppointmentData" Height="650px" @bind-SelectedDate="@CurrentDate">
        <ScheduleViews>
            <ScheduleView Option="View.TimelineYear"></ScheduleView>
        </ScheduleViews>
    </SfSchedule>
</div>

@code{
    DateTime CurrentDate = new DateTime(2020, 2, 14);
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
<style>
    .e-schedule .e-timeline-year-view .e-work-cells
    {
        background-color:rgb(255, 255, 255);
        border: 1px solid rgb(241, 199, 137);
    }
</style>

```

{% previewsample "https://blazorplayground.syncfusion.com/embed/rZBIZSXKozTrvbOf?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Work cells in timeline year views](images/blazor-scheduler-timelineyear-workcells.png)" %}

#  Work cells of other month in timeline year view of scheduler

This CSS selector targets the work cells representing days from adjacent months (previous or next month) that are visible in the timeline year view.

```cshtml

@using Syncfusion.Blazor.Schedule
<div class="component-container">
    <SfSchedule TValue="AppointmentData" Height="650px" @bind-SelectedDate="@CurrentDate">
        <ScheduleViews>
            <ScheduleView Option="View.TimelineYear"></ScheduleView>
        </ScheduleViews>
    </SfSchedule>
</div>

@code{
    DateTime CurrentDate = new DateTime(2020, 2, 14);
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
<style>
    .e-schedule .e-timeline-year-view .e-work-cells.e-other-month
    {
        background-color: rgba(247, 250, 102, 0.98);
        color: #777777;
    }
</style>

```

{% previewsample "https://blazorplayground.syncfusion.com/embed/VNLIteDUymCFDFFp?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Work cells in timeline other month views](images/blazor-scheduler-timeline-othermonth-workcells.png)" %}

# Work cells in month agenda view of scheduler

This CSS selector targets the work cells that represent the days in the month agenda view of the Syncfusion Scheduler. These cells are areas where appointments can be placed.

```cshtml
@using Syncfusion.Blazor.Schedule
<div class="component-container">
    <SfSchedule TValue="AppointmentData" Height="650px" @bind-SelectedDate="@CurrentDate">
        <ScheduleViews>
            <ScheduleView Option="View.MonthAgenda"></ScheduleView>
        </ScheduleViews>
    </SfSchedule>
</div>

@code{
    DateTime CurrentDate = new DateTime(2020, 2, 14);
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
<style>
    .e-schedule .e-month-agenda-view .e-work-cells
    {
        background-color: #f0f8ff;
        border: 1px solid #cceeff;
    }
</style>

```

{% previewsample "https://blazorplayground.syncfusion.com/embed/hjBItIMpzmNyLBhW?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Work cells in month agenda view](images/blazor-scheduler-monthagenda-workcells.png)" %}

# Work cells of other month in month agenda view of scheduler

This CSS selector targets the work cells representing days that belong to adjacent months within the month agenda view. These cells often show up to provide context for appointments that may extend beyond the current month.

```cshtml
@using Syncfusion.Blazor.Schedule
<div class="component-container">
    <SfSchedule TValue="AppointmentData" Height="650px" @bind-SelectedDate="@CurrentDate">
        <ScheduleViews>
            <ScheduleView Option="View.MonthAgenda"></ScheduleView>
        </ScheduleViews>
    </SfSchedule>
</div>

@code{
    DateTime CurrentDate = new DateTime(2020, 2, 14);
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
<style>
    .e-schedule .e-month-agenda-view .e-work-cells
    {
        background-color: #f0f8ff;
        border: 1px solid #cceeff;
    }
    .e-schedule .e-month-agenda-view .e-other-month 
    {
        background-color: rgba(218, 207, 240, 0.7);
        color: #999999;
    }
</style>

```

{% previewsample "https://blazorplayground.syncfusion.com/embed/htrINyszfvZfowQQ?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Other month work cells in month agenda view](images/blazor-scheduler-monthagenda-othermonth-workcells.png)" %}


# Work Cells of Other Month in Year View of Scheduler

This CSS selector targets the work cells representing days from adjacent months (previous or next month) that are visible in the year view of the Syncfusion Scheduler.

```cshtml
@using Syncfusion.Blazor.Schedule
<div class="component-container">
    <SfSchedule TValue="AppointmentData" Height="650px" @bind-SelectedDate="@CurrentDate">
        <ScheduleViews>
            <ScheduleView Option="View.Year"></ScheduleView>
        </ScheduleViews>
    </SfSchedule>
</div>

@code{
    DateTime CurrentDate = new DateTime(2020, 2, 14);
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
<style>
    .e-schedule .e-year-view .e-work-cells.e-other-month
    {
        background-color: rgba(230, 230, 250, 0.7);
        color: #999999;
    }
</style>

```

{% previewsample "https://blazorplayground.syncfusion.com/embed/BXBeNIMOzziiJCIN?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Other month work cells in Year view](images/blazor-scheduler-yearview-othermonth-workcells.png)" %}


# All Day Cells in Vertical Views of Scheduler

This CSS selector targets the all-day cells in the vertical views (Day, Week, and WorkWeek) of the Syncfusion Scheduler component. These cells represent the time slots designated for all-day events, providing users with a straightforward way to visualize and manage significant appointments.

```cshtml
@using Syncfusion.Blazor.Schedule
<div class="component-container">
    <SfSchedule TValue="AppointmentData" Height="650px" @bind-SelectedDate="@CurrentDate">
        <ScheduleViews>
            <ScheduleView Option="View.Day"></ScheduleView>
            <ScheduleView Option="View.Week"></ScheduleView>
            <ScheduleView Option="View.WorkWeek"></ScheduleView>
        </ScheduleViews>
    </SfSchedule>
</div>

@code{
    DateTime CurrentDate = new DateTime(2020, 2, 14);
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
<style>
    .e-schedule .e-vertical-view .e-date-header-wrap .e-all-day-cells
    {
        background-color: #f8c8c8;
        border: 1px solid #f8c8c8;
    }
</style>

```

{% previewsample "https://blazorplayground.syncfusion.com/embed/BNByDoMYpJcFHjMv?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[All-Day cells in vertical view](images/blazor-scheduler-Alldaycells-verticalview.png)" %}


# Work Hour Cells in Vertical Views of Scheduler

This CSS selector targets the work hour cells in vertical views (Day, Week, WorkWeek) of the Syncfusion Scheduler. These cells show the working hours where users can add appointments, making it easier to see available time slots.

```cshtml
@using Syncfusion.Blazor.Schedule
<div class="component-container">
    <SfSchedule TValue="AppointmentData" Height="650px" @bind-SelectedDate="@CurrentDate">
        <ScheduleViews>
            <ScheduleView Option="View.Day"></ScheduleView>
            <ScheduleView Option="View.Week"></ScheduleView>
            <ScheduleView Option="View.WorkWeek"></ScheduleView>
        </ScheduleViews>
    </SfSchedule>
</div>

@code{
    DateTime CurrentDate = new DateTime(2020, 2, 14);
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
<style>
    .e-schedule .e-vertical-view .e-work-hours
    {
        background-color: #d1eaf8;
        border: 1px solid #b2d3f7;
    }
</style>

```

{% previewsample "https://blazorplayground.syncfusion.com/embed/rtrSDeiOfoMsMoZt?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Work hour cells in vertical view](images/blazor-scheduler-work-hour-cells-verticalview.png)" %}


# Work Day Cells in Month View of Scheduler

This CSS selector targets the work day cells in the month view of the Syncfusion Scheduler. These cells show the days meant for scheduling work, helping users easily see which days are available for appointments.

```cshtml

@using Syncfusion.Blazor.Schedule
<div class="component-container">
    <SfSchedule TValue="AppointmentData" Height="650px" @bind-SelectedDate="@CurrentDate">
        <ScheduleViews>
            <ScheduleView Option="View.Month"></ScheduleView>
        </ScheduleViews>
    </SfSchedule>
</div>

@code{
    DateTime CurrentDate = new DateTime(2020, 2, 14);
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
<style>
    .e-schedule .e-month-view .e-work-days
    {
        background-color:rgb(168, 167, 205);
        border: 1px solidrgb(39, 143, 191);
    }
</style>

```

{% previewsample "https://blazorplayground.syncfusion.com/embed/rNVStIiapeGmfItK?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Work day cells in month view](images/blazor-scheduler-work-Day-cells-monthview.png)" %}


# Work Day Cells in Month Agenda View of Scheduler

This CSS selector targets the work day cells that represent the days in the month agenda view of the Syncfusion Scheduler. These cells show the specific days within the scheduled month where users can place appointments.

```cshtml

@using Syncfusion.Blazor.Schedule
<div class="component-container">
    <SfSchedule TValue="AppointmentData" Height="650px" @bind-SelectedDate="@CurrentDate">
        <ScheduleViews>
            <ScheduleView Option="View.MonthAgenda"></ScheduleView>
        </ScheduleViews>
    </SfSchedule>
</div>

@code{
    DateTime CurrentDate = new DateTime(2020, 2, 14);
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
<style>
    .e-schedule .e-month-agenda-view .e-work-days
    {
        background-color: #e2f7e2;
        border: 1px solid #c9e1c9;
    }
</style>

```

{% previewsample "https://blazorplayground.syncfusion.com/embed/rNVStIiapeGmfItK?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Work day cells in month agenda view](images/blazor-scheduler-work-day-cells-monthagenda-view.png)" %}


# Work Hour Cells in Timeline Views of Scheduler

This CSS selector targets the work hour cells in the timeline views (TimelineDay, TimelineWeek) of the Syncfusion Scheduler. These cells represent the slots of time designated for work hours, providing users with a visual indication of when appointments can be scheduled.

```cshtml

@using Syncfusion.Blazor.Schedule
<div class="component-container">
    <SfSchedule TValue="AppointmentData" Height="650px" @bind-SelectedDate="@CurrentDate">
        <ScheduleViews>
            <ScheduleView Option="View.TimelineDay"></ScheduleView>
            <ScheduleView Option="View.TimelineWeek"></ScheduleView>
        </ScheduleViews>
    </SfSchedule>
</div>

@code{
    DateTime CurrentDate = new DateTime(2020, 2, 14);
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
<style>
    .e-schedule .e-timeline-view .e-work-hours
    {
        background-color: #d1eaf8;
        border: 1px solid #b2d3f7;
    }
</style>

```

{% previewsample "https://blazorplayground.syncfusion.com/embed/VtBIXyCYpxaMcIgD?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Work hour cells in timeline view](images/blazor-scheduler-work-hour-cells-timeline-view.png)" %}


# Work Day Cells in Timeline Month View of Scheduler

This CSS selector targets the work day cells in the timeline month view of the Syncfusion Scheduler. These cells represent the specific days designated as working days for the month timeline, allowing users to visualize their tasks and appointments within those time frames.

```cshtml

@using Syncfusion.Blazor.Schedule
<div class="component-container">
    <SfSchedule TValue="AppointmentData" Height="650px" @bind-SelectedDate="@CurrentDate">
        <ScheduleViews>
            <ScheduleView Option="View.TimelineMonth"></ScheduleView>
        </ScheduleViews>
    </SfSchedule>
</div>

@code{
    DateTime CurrentDate = new DateTime(2020, 2, 14);
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
<style>
    .e-schedule .e-timeline-month-view .e-work-days
    {
        background-color:rgb(204, 165, 198);
        border: 1px solid #a1d95a;
    }
</style>

```

{% previewsample "https://blazorplayground.syncfusion.com/embed/rthIXICaJwbDIMPr?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Work day cells in timeline month view](images/blazor-scheduler-work-day-cells-timeline-monthview.png)" %}


# Work Day Cells in Timeline Year View of Scheduler

This CSS selector targets the work day cells in the timeline year view of the Syncfusion Scheduler. These cells highlight the working days throughout the entire year, giving users a comprehensive overview of their yearly schedule and enabling easier appointment management.

```cshtml

@using Syncfusion.Blazor.Schedule
<div class="component-container">
    <SfSchedule TValue="AppointmentData" Height="650px" @bind-SelectedDate="@CurrentDate">
        <ScheduleViews>
            <ScheduleView Option="View.TimelineYear"></ScheduleView>
        </ScheduleViews>
    </SfSchedule>
</div>

@code{
    DateTime CurrentDate = new DateTime(2020, 2, 14);
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
<style>
    .e-schedule .e-timeline-year-view .e-work-days
    {
        background-color:rgb(104, 177, 211);
        border: 1px solid #81d4fa;
    }
</style>

```

{% previewsample "https://blazorplayground.syncfusion.com/embed/VtLytSsaTviyMXFM?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Work day cells in timeline year view](images/blazor-scheduler-work-day-cells-timeline-yearview.png)" %}