---
layout: post
title: Drag and drop in Blazor Scheduler Component | Syncfusion
description: Checkout and learn here all about recurring events in Syncfusion Blazor Scheduler component.
platform: Blazor
control: Scheduler
documentation: ug
---

# Drag and drop

Appointments can be rescheduled to any time by dragging and dropping them onto the desired location. To work with drag and drop functionality make sure that [AllowDragAndDrop](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Schedule.SfSchedule-1.html#Syncfusion_Blazor_Schedule_SfSchedule_1_AllowDragAndDrop) is set to **true** on Scheduler. In mobile mode, you can drag and drop the events by tap holding an event and dropping them on to the desired location.

N> By default, drag and drop action is applicable on all Scheduler views, except Agenda and Month-Agenda view.

To get start quickly about drag options available in our Scheduler, you can check on this video:

{% youtube
"youtube:https://www.youtube.com/watch?v=Vtl1Wyuwt-0"%}

## Drag and drop multiple appointments

Multiple appointments can be dragged and dropped by enabling the [AllowMultiDrag](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Schedule.SfSchedule-1.html#Syncfusion_Blazor_Schedule_SfSchedule_1_AllowMultiDrag) property. Multiple appointments can be selected by holding the CTRL key. Once the events are selected, leave the CTRL key and start dragging the event.

Multiple events can also be dragged from one resource to another resource. In this case, if all the selected events are in the different resources, then all the events should be moved to the single resource that is related to the target event.

N> Multiple events drag and drop is not supported on mobile devices.

```cshtml
@using Syncfusion.Blazor.Schedule

<SfSchedule TValue="AppointmentData" Height="550px" AllowMultiDrag="true" @bind-SelectedDate="@CurrentDate">
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
    DateTime CurrentDate = new DateTime(2020, 1, 31);
    List<AppointmentData> DataSource = new List<AppointmentData>
    {
        new AppointmentData{ Id = 1, Subject = "Meeting", StartTime = new DateTime(2020, 1, 31, 9, 30, 0) , EndTime = new DateTime(2020, 1, 31, 11, 0, 0)},
        new AppointmentData{ Id = 2, Subject = "Testing", StartTime = new DateTime(2020, 1, 31, 12, 0, 0) , EndTime = new DateTime(2020, 1, 31, 13, 0, 0)}
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

## Disable the drag action

By default, the events can be dragged and dropped within any of the applicable scheduler views, and to disable it, set **false** to the [AllowDragAndDrop](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Schedule.SfSchedule-1.html#Syncfusion_Blazor_Schedule_SfSchedule_1_AllowDragAndDrop) property.

```cshtml
@using Syncfusion.Blazor.Schedule

<SfSchedule TValue="AppointmentData" Height="550px" AllowDragAndDrop="false" @bind-SelectedDate="@CurrentDate">
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
    DateTime CurrentDate = new DateTime(2020, 1, 31);
    List<AppointmentData> DataSource = new List<AppointmentData>
    {
        new AppointmentData{ Id = 1, Subject = "Meeting", StartTime = new DateTime(2020, 1, 31, 9, 30, 0) , EndTime = new DateTime(2020, 1, 31, 11, 0, 0)}
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

## Preventing drag and drop on specific targets

It is possible to prevent the drag action on particular target, by passing the target to be excluded in the `ExcludeSelectors` option within [OnDragStart](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Schedule.ScheduleEvents-1.html#Syncfusion_Blazor_Schedule_ScheduleEvents_1_OnDragStart) event. 

```cshtml
@using Syncfusion.Blazor.Schedule

<SfSchedule TValue="AppointmentData" Height="550px" @bind-SelectedDate="@CurrentDate">
    <ScheduleEvents TValue="AppointmentData" OnDragStart="OnAppointmentDrag"></ScheduleEvents>
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
    DateTime CurrentDate = new DateTime(2020, 1, 31);
    public void OnAppointmentDrag(DragEventArgs<AppointmentData> args)
    {
        args.ExcludeSelectors = "e-header-cells,e-all-day-cells";
    }
    List<AppointmentData> DataSource = new List<AppointmentData>
    {
        new AppointmentData{ Id = 1, Subject = "Meeting", StartTime = new DateTime(2020, 1, 31, 9, 30, 0) , EndTime = new DateTime(2020, 1, 31, 11, 0, 0)}
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

## Disable scrolling on drag action

By default, while dragging an appointment to the edges, either top/bottom in the vertical Scheduler or left/right in the timeline Scheduler, scrolling action takes place automatically. To prevent this scrolling, set `false` to the `Scroll` value within the [OnDragStart](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Schedule.ScheduleEvents-1.html#Syncfusion_Blazor_Schedule_ScheduleEvents_1_OnDragStart) event arguments.

```cshtml
@using Syncfusion.Blazor.Schedule

<SfSchedule TValue="AppointmentData" Height="550px" SelectedDate="@CurrentDate">
    <ScheduleEvents TValue="AppointmentData" OnDragStart="OnAppointmentDrag"></ScheduleEvents>
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
    DateTime CurrentDate = new DateTime(2020, 1, 31);
    public void OnAppointmentDrag(DragEventArgs<AppointmentData> args)
    {
        args.Scroll.Enable = false;
    }
    List<AppointmentData> DataSource = new List<AppointmentData>
    {
        new AppointmentData{ Id = 1, Subject = "Meeting", StartTime = new DateTime(2020, 1, 31, 9, 30, 0) , EndTime = new DateTime(2020, 1, 31, 11, 0, 0)}
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

## Controlling scroll speed while dragging an event

The speed of the scrolling action while dragging an appointment to the Scheduler edges can be controlled within the [OnDragStart](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Schedule.ScheduleEvents-1.html#Syncfusion_Blazor_Schedule_ScheduleEvents_1_OnDragStart) event by setting the desired value to the `ScrollBy` and `TimeDelay` option, whereas its default value is 30 minutes and 100ms.

```cshtml
@using Syncfusion.Blazor.Schedule

<SfSchedule TValue="AppointmentData" Height="550px" @bind-SelectedDate="@CurrentDate">
    <ScheduleEvents TValue="AppointmentData" OnDragStart="OnAppointmentDrag"></ScheduleEvents>
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
    DateTime CurrentDate = new DateTime(2020, 1, 31);
    public void OnAppointmentDrag(DragEventArgs<AppointmentData> args)
    {
        args.Scroll.ScrollBy = 5;
        args.Scroll.TimeDelay = 200;
    }
    List<AppointmentData> DataSource = new List<AppointmentData>
    {
        new AppointmentData{ Id = 1, Subject = "Meeting", StartTime = new DateTime(2020, 1, 31, 9, 30, 0) , EndTime = new DateTime(2020, 1, 31, 11, 0, 0)}
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

## Auto navigation of date ranges on dragging an event

When an event is dragged either to the left or right extreme edges of the Scheduler and kept hold for few seconds without dropping, the auto navigation of date ranges will be enabled allowing the Scheduler to navigate from current date range to back and forth respectively. This action is set to `false` by default and to enable it, set `Navigation` to true within the [OnDragStart](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Schedule.ScheduleEvents-1.html#Syncfusion_Blazor_Schedule_ScheduleEvents_1_OnDragStart) event.

By default, the navigation delay is set to 2000ms. The navigation delay decides how long the user needs to drag and hold the appointments at the extremities. You can also set your own delay value for letting the users to navigate based on it, using the `TimeDelay` within the [OnDragStart](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Schedule.ScheduleEvents-1.html#Syncfusion_Blazor_Schedule_ScheduleEvents_1_OnDragStart) event.

```cshtml
@using Syncfusion.Blazor.Schedule

<SfSchedule TValue="AppointmentData" Height="550px" @bind-SelectedDate="@CurrentDate">
    <ScheduleEvents TValue="AppointmentData" OnDragStart="OnAppointmentDrag"></ScheduleEvents>
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
    DateTime CurrentDate = new DateTime(2020, 1, 31);
    public void OnAppointmentDrag(DragEventArgs<AppointmentData> args)
    {
        args.Navigation.Enable = true;
        args.Navigation.TimeDelay = 4000;
    }
    List<AppointmentData> DataSource = new List<AppointmentData>
    {
        new AppointmentData{ Id = 1, Subject = "Meeting", StartTime = new DateTime(2020, 1, 31, 9, 30, 0) , EndTime = new DateTime(2020, 1, 31, 11, 0, 0)}
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

## Setting drag time interval

By default, while dragging an appointment, it moves at an interval of 30 minutes. To change the dragging time interval, pass the appropriate values to the `Interval` option within the [OnDragStart](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Schedule.ScheduleEvents-1.html#Syncfusion_Blazor_Schedule_ScheduleEvents_1_OnDragStart) event.

```cshtml
@using Syncfusion.Blazor.Schedule

<SfSchedule TValue="AppointmentData" Height="550px" @bind-SelectedDate="@CurrentDate">
    <ScheduleEvents TValue="AppointmentData" OnDragStart="OnAppointmentDrag"></ScheduleEvents>
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
    DateTime CurrentDate = new DateTime(2020, 1, 31);
    public void OnAppointmentDrag(DragEventArgs<AppointmentData> args)
    {
        args.Interval = 10;
    }
    List<AppointmentData> DataSource = new List<AppointmentData>
    {
        new AppointmentData{ Id = 1, Subject = "Meeting", StartTime = new DateTime(2020, 1, 31, 9, 30, 0) , EndTime = new DateTime(2020, 1, 31, 11, 0, 0)}
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

## Drag and drop items from external source

It is possible to drag and drop the unplanned items from any of the external source into the scheduler, by manually saving those dropped item as a new appointment data through [AddEventAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Schedule.SfSchedule-1.html#Syncfusion_Blazor_Schedule_SfSchedule_1_AddEventAsync__0_) method of Scheduler.

To get start quickly about dropping items from external source to our Scheduler, you can check on this video:

{% youtube
"youtube:https://www.youtube.com/watch?v=QxBBZYef6cg"%}

In this example, the tree view control is used as an external source and the child nodes from the tree view component are dragged and dropped onto the Scheduler. Therefore, it is necessary to make use of the `OnNodeDragStop` event of the TreeView component, where an event object can be formed and save it using the [AddEventAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Schedule.SfSchedule-1.html#Syncfusion_Blazor_Schedule_SfSchedule_1_AddEventAsync__0_) method.

```cshtml
@using Syncfusion.Blazor.Schedule
@using Syncfusion.Blazor.Navigations

<div class="row">
    <div class="col-lg-8 e-droppable">
        <SfSchedule @ref="ScheduleRef" TValue="AppointmentData" Height="650px" @bind-SelectedDate="@CurrentDate">
            <ScheduleGroup Resources="@GroupData"></ScheduleGroup>
            <ScheduleResources>
                <ScheduleResource TItem="ResourceData" TValue="int" DataSource="@Consultants" Field="ConsultantID" Title="Consultant" Name="Consultants" TextField="Text" IdField="Id" ColorField="Color"></ScheduleResource>
            </ScheduleResources>
            <ScheduleEventSettings DataSource="@DataSource">
            </ScheduleEventSettings>
            <ScheduleViews>
                <ScheduleView Option="View.Day"></ScheduleView>
                <ScheduleView Option="View.Week"></ScheduleView>
                <ScheduleView Option="View.WorkWeek"></ScheduleView>
                <ScheduleView Option="View.Month"></ScheduleView>
                <ScheduleView Option="View.Agenda"></ScheduleView>
            </ScheduleViews>
        </SfSchedule>
    </div>
    <div class="col-lg-4">
        <h3>Waiting list</h3>
        <SfTreeView TValue="EmployeeData" AllowDragAndDrop="true">
            <TreeViewFieldsSettings DataSource="@WaitingListData" Id="Id" Text="Name"></TreeViewFieldsSettings>
            <TreeViewEvents TValue="EmployeeData" OnNodeDragStop="DragStop"></TreeViewEvents>
        </SfTreeView>
    </div>
</div>

@code{
    DateTime CurrentDate = new DateTime(2020, 1, 31);
    SfSchedule<AppointmentData> ScheduleRef;
    public string[] GroupData = new string[] { "Consultants" };
    public List<ResourceData> Consultants { get; set; } = new List<ResourceData> {
    new ResourceData { Text = "Margaret", Id = 1, Color = "#1aaa55" },
    new ResourceData { Text = "Robert", Id = 2, Color = "#357cd2" },
    new ResourceData { Text = "Laura", Id = 3, Color = "#7fa900" },
    new ResourceData { Text = "Robson", Id = 4, Color = "#9e5fff" },
    new ResourceData { Text = "Laura", Id = 5, Color = "#bbdc00" }
    };
    public List<EmployeeData> WaitingListData { get; set; } = new List<EmployeeData>() {
    new EmployeeData { Id = 1, Name = "Johnson" },
    new EmployeeData { Id = 2, Name = "Sourav" },
    new EmployeeData { Id = 3,  Name = "Sanjay" }
    };
    List<AppointmentData> DataSource = new List<AppointmentData>
{
    new AppointmentData{ Id = 1, Subject = "General-Check up", StartTime = new DateTime(2020, 1, 31, 9, 30, 0) , EndTime = new DateTime(2020, 1, 31, 11, 0, 0), ConsultantID=1 }
    };

    async void DragStop(DragAndDropEventArgs args)
    {
        args.Cancel = true;
        CellClickEventArgs cellData = await ScheduleRef.GetTargetCellAsync((int)args.Left, (int)args.Top);
        if (cellData != null)
        {
            var resourceDetails = ScheduleRef.GetResourceByIndex(cellData.GroupIndex);
            Random rnd = new Random();
            AppointmentData eventData = new AppointmentData
            {
                Id = rnd.Next(1000),
                Subject = args.DraggedNodeData.Text,
                StartTime = cellData.StartTime,
                EndTime = cellData.EndTime,
                IsAllDay = cellData.IsAllDay,
                ConsultantID = resourceDetails.GroupData.ConsultantID,
            };
            await ScheduleRef.OpenEditorAsync(eventData, CurrentAction.Add);
        }
    }

    public class AppointmentData
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string RecurrenceRule { get; set; }
        public Nullable<int> RecurrenceID { get; set; }
        public string RecurrenceException { get; set; }
        public bool? IsAllDay { get; set; }
        public Nullable<int> ConsultantID { get; set; }
    }
    public class EmployeeData
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class ResourceData
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Color { get; set; }
    }
}
```

## Drag and drop items to external source

You can drag and drop the events to external source by setting the target to the property [EventDragArea](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Schedule.SfSchedule-1.html#Syncfusion_Blazor_Schedule_SfSchedule_1_EventDragArea). In the following code example, we have two Scheduler and events from the first scheduler that can be dropped to the second scheduler. In the [Dragged](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Schedule.ScheduleEvents-1.html#Syncfusion_Blazor_Schedule_ScheduleEvents_1_Dragged) event of the first scheduler, the dragged event has been deleted from the first scheduler and added to the second scheduler.

```cshtml
@using Syncfusion.Blazor.Schedule

<div class="row">
    <div class="col-lg-6">
        <SfSchedule @ref="Schedule1Ref" Height="550px" TValue="AppointmentData" EventDragArea=".ScheduleClass" @bind-SelectedDate="@CurrentDate">
            <ScheduleEvents TValue="AppointmentData" Dragged="OnDragged"></ScheduleEvents>
            <ScheduleEventSettings DataSource="@ScheduleData"></ScheduleEventSettings>
            <ScheduleViews>
                <ScheduleView Option="View.Day"></ScheduleView>
                <ScheduleView Option="View.Week"></ScheduleView>
                <ScheduleView Option="View.WorkWeek"></ScheduleView>
                <ScheduleView Option="View.Month"></ScheduleView>
                <ScheduleView Option="View.Agenda"></ScheduleView>
            </ScheduleViews>
        </SfSchedule>
    </div>
    <div class="col-lg-6">
        <SfSchedule @ref="Schedule2Ref" Height="550px" TValue="AppointmentData" CssClass="ScheduleClass" SelectedDate="@(new DateTime(2020, 1, 6))">
            <ScheduleViews>
                <ScheduleView Option="View.Day"></ScheduleView>
                <ScheduleView Option="View.Week"></ScheduleView>
                <ScheduleView Option="View.WorkWeek"></ScheduleView>
                <ScheduleView Option="View.Month"></ScheduleView>
                <ScheduleView Option="View.Agenda"></ScheduleView>
            </ScheduleViews>
        </SfSchedule>
    </div>
</div>


@code {
    DateTime CurrentDate = new DateTime(2020, 1, 6);
    SfSchedule<AppointmentData> Schedule1Ref;
    SfSchedule<AppointmentData> Schedule2Ref;
    List<AppointmentData> ScheduleData = new List<AppointmentData>
    {
        new AppointmentData { Id = 1, Subject = "Meeting", StartTime = new DateTime(2020, 1, 6, 9, 30, 0) , EndTime = new DateTime(2020, 1, 6, 11, 0, 0)}
    };
    public async Task OnDragged(DragEventArgs<AppointmentData> args)
    {
        await Schedule1Ref.DeleteEventAsync(args.Data.Id);
        Random random = new Random();
        args.Data.Id = Convert.ToInt32(random.Next());
        await Schedule2Ref.AddEventAsync(args.Data);
    }
    public class AppointmentData
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Nullable<bool> IsAllDay { get; set; }
        public bool IsReadonly { get; set; }
        public string RecurrenceRule { get; set; }
        public Nullable<int> RecurrenceID { get; set; }
        public string RecurrenceException { get; set; }
        public string StartTimezone { get; set; }
        public string EndTimezone { get; set; }
    }
}
```

## Opening the editor window on drag stop

There are scenarios where you want to open the editor filled with data on newly dropped location and may need to proceed to save it, only when `Save` button is clicked on the editor. Clicking on the cancel button should revert these changes. This can be achieved using the [Dragged](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Schedule.ScheduleEvents-1.html#Syncfusion_Blazor_Schedule_ScheduleEvents_1_Dragged) event of Scheduler.

```cshtml
@using Syncfusion.Blazor.Schedule

<SfSchedule TValue="AppointmentData" @ref="ScheduleRef" Height="550px" @bind-SelectedDate="@CurrentDate">
    <ScheduleEvents TValue="AppointmentData" Dragged="OnAppointmentDragStop"></ScheduleEvents>
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
    DateTime CurrentDate = new DateTime(2020, 1, 31);
    SfSchedule<AppointmentData> ScheduleRef;
    public async Task OnAppointmentDragStop(DragEventArgs<AppointmentData> args)
    {
        args.Cancel = true;
        await this.ScheduleRef.OpenEditorAsync(args.Data, CurrentAction.Save);
    }
    List<AppointmentData> DataSource = new List<AppointmentData>
    {
        new AppointmentData{ Id = 1, Subject = "Meeting", StartTime = new DateTime(2020, 1, 31, 9, 30, 0) , EndTime = new DateTime(2020, 1, 31, 11, 0, 0)}
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
