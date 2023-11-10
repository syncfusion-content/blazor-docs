---
layout: post
title: WebAssembly Performance in Blazor Scheduler Component | Syncfusion
description: This topic helps you to improve the performance of Web Assembly Application when using Syncfusion Blazor Scheduler components with some tips.
platform: Blazor
control: Scheduler
documentation: ug
---

# WebAssembly Performance in Blazor Scheduler Component

This section provides performance guidelines for using Syncfusion Scheduler component efficiently in Blazor WebAssembly application. The best practice or guidelines for general framework Blazor WebAssembly performance can be found [here](https://learn.microsoft.com/en-us/aspnet/core/blazor/performance?view=aspnetcore-7.0).

N> You can refer to our Getting Started with [Blazor Server-Side Scheduler](https://blazor.syncfusion.com/documentation/getting-started/blazor-server-side-visual-studio) and [Blazor WebAssembly Scheduler](./how-to/blazor-web-assembly-scheduler) documentation pages for configuration specifications.

## Avoid unnecessary component renders

During Blazor Diffing Algorithm, every views of the Scheduler component and its child component will be checked for re-rendering. For instance, having **EventCallBack** on the application or Scheduler will check every child component, once event callback is completed.

You can have fine-grained control over Scheduler component rendering. **PreventRender** method helps to avoid unnecessary re-rendering of the Scheduler component. This method internally overrides the **ShouldRender** method of the Scheduler to prevent rendering.

In the following example:

* **PreventRender** method is called in the **IncrementCount** method which is a click callback.
* Now, Scheduler component will not be a part of the rendering which happens as result of the click event and **currentCount** alone will get updated.

```cshtml
@using Syncfusion.Blazor.Schedule

<p>Current count: @currentCount</p>

<button class="btn btn-primary" @onclick="IncrementCount">Click me</button>

<SfSchedule @ref="ScheduleRef" TValue=AppointmentData>
    <ScheduleViews>
        <ScheduleView Option="View.Day"></ScheduleView>
        <ScheduleView Option="View.Week"></ScheduleView>
        <ScheduleView Option="View.WorkWeek"></ScheduleView>
        <ScheduleView Option="View.Month"></ScheduleView>
        <ScheduleView Option="View.Agenda"></ScheduleView>
    </ScheduleViews>
</SfSchedule>
@code {
    SfSchedule<AppointmentData> ScheduleRef;
    private int currentCount = 0;
    private void IncrementCount()
    {
        ScheduleRef.PreventRender();
        currentCount++;
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

N> * **PreventRender** method accepts boolean argument that accepts true or false to disable or enable rendering respectively.
<br/> * **PreventRender** method can be used only after Scheduler component completed initial rendering. Calling this method during initial rendering will not have any effect.

## Avoid unnecessary component renders after Scheduler events

When a callback method is assigned to the Scheduler events, then the **StateHasChanged** will be called in parent component of the Scheduler automatically once the event is completed.

You can prevent this re-rendering of the Scheduler component by calling the **PreventRender** method.

In the following example:

* **OnCellClick** event is bound with a callback method, so once cell click event is completed the **StateHasChanged** will be invoked for the parent component.

```cshtml
@using Syncfusion.Blazor.Schedule

<p style="color:green; font-size:20px">@Status</p>
<SfSchedule @ref="ScheduleRef" TValue="AppointmentData" Width="100%" Height="550px" @bind-SelectedDate="@CurrentDate">
    <ScheduleEvents TValue="AppointmentData" OnCellClick="OnCellClick" ActionCompleted="OnActionCompleted"></ScheduleEvents>
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
    SfSchedule<AppointmentData> ScheduleRef;
    string Status = string.Empty;
    DateTime CurrentDate = new DateTime(2020, 3, 10);
    public void OnCellClick(CellClickEventArgs args)
    {
        ScheduleRef.PreventRender();
    }
    public void OnActionCompleted(ActionEventArgs<AppointmentData> args)
    {
        ScheduleRef.PreventRender();
        if (args.ActionType == ActionType.EventCreate || args.ActionType == ActionType.EventChange)
        {
            Status = "Success";   //Status become success on create and update of an event.
        }
    }
    List<AppointmentData> DataSource = new List<AppointmentData>
    {
    new AppointmentData { Id = 1, Subject = "Meeting", StartTime = new DateTime(2020, 3, 10, 9, 30, 0) , EndTime = new DateTime(2020, 3, 10, 12, 0, 0) }
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

N> * **PreventRender** method internally overrides the **ShouldRender** method of the Scheduler to prevent rendering.
<br/> * It is recommended to use **PreventRender** method for user interactive events such as OnCellClick, OnEventClick etc. for better performance.
<br/> * For events without any argument such as **DataBound**, you can use **PreventRender** method of the Scheduler to disable rendering.