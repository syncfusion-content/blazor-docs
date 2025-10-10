---
layout: post
title: Scheduler Dimensions in Blazor Scheduler Component | Syncfusion
description: This article demonstrates how to set the height and width of Syncfusion Blazor Scheduler component in pixels, percentage or auto values.
platform: Blazor
control: Scheduler
documentation: ug
---

# Scheduler Dimensions in Blazor Scheduler Component

The dimensions of the Syncfusion Blazor Scheduler component, encompassing both height and width of its entire layout, can be defined using three types of values:

* auto
* pixel
* percentage

## Auto Height and Width

When the height and width of the Scheduler are set to `auto`, the component attempts to match the width of its parent container. In this configuration, the parent container's width or height will be the cumulative size of its children. By default, the Scheduler component is assigned `auto` values for both its `Height` and `Width` properties.

```cshtml
@using Syncfusion.Blazor.Schedule

<SfSchedule TValue="AppointmentData" Height="auto" Width="auto">
    <ScheduleViews>
        <ScheduleView Option="View.Day"></ScheduleView>
        <ScheduleView Option="View.Week"></ScheduleView>
        <ScheduleView Option="View.WorkWeek"></ScheduleView>
        <ScheduleView Option="View.Month"></ScheduleView>
        <ScheduleView Option="View.Agenda"></ScheduleView>
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
{% previewsample "https://blazorplayground.syncfusion.com/embed/BNBesjtcsURMTcIB?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Height and Width in Pixel

The Scheduler's height and width render precisely according to the specified pixel values. Both string and number values are accepted for these properties.

```cshtml
@using Syncfusion.Blazor.Schedule

<SfSchedule TValue="AppointmentData" Height="650px" Width="550px">
    <ScheduleViews>
        <ScheduleView Option="View.Day"></ScheduleView>
        <ScheduleView Option="View.Week"></ScheduleView>
        <ScheduleView Option="View.WorkWeek"></ScheduleView>
        <ScheduleView Option="View.Month"></ScheduleView>
        <ScheduleView Option="View.Agenda"></ScheduleView>
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
{% previewsample "https://blazorplayground.syncfusion.com/embed/rZByiNjQWKmhecik?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Height and width in pixel in Blazor Scheduler](images/height-width-inpixel.png)

## Height and Width in Percentage

When the height and width of the Scheduler are provided as percentage values, the component will expand to occupy the specified percentage of its parent container's dimensions.

```cshtml
@using Syncfusion.Blazor.Schedule

<SfSchedule TValue="AppointmentData" Height="100%" Width="100%">
    <ScheduleViews>
        <ScheduleView Option="View.Day"></ScheduleView>
        <ScheduleView Option="View.Week"></ScheduleView>
        <ScheduleView Option="View.WorkWeek"></ScheduleView>
        <ScheduleView Option="View.Month"></ScheduleView>
        <ScheduleView Option="View.Agenda"></ScheduleView>
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
{% previewsample "https://blazorplayground.syncfusion.com/embed/BtLSstjwCqYbFnCD?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## How to set the full height of the viewport

Setting the Scheduler's height using the CSS unit of Viewport Height (vh) allows the component to occupy the full height within the viewport.

In the following example, the application header height (4.6rem) is reduced from the total viewport.

```cshtml
@using Syncfusion.Blazor.Schedule

<SfSchedule TValue="AppointmentData" Height="calc(100vh - 4.6rem)" Width="550px">
    <ScheduleViews>
        <ScheduleView Option="View.Day"></ScheduleView>
        <ScheduleView Option="View.Week"></ScheduleView>
        <ScheduleView Option="View.WorkWeek"></ScheduleView>
        <ScheduleView Option="View.Month"></ScheduleView>
        <ScheduleView Option="View.Agenda"></ScheduleView>
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
![Blazor Scheduler with View Port Height](images/blazor-scheduler-view-port-height.png)