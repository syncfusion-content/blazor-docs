---
layout: post
title: Context Menu in Blazor Scheduler Component | Syncfusion
description: Learn here all about how to integrate the context menu manually to a Syncfusion Blazor Scheduler component and use it with required options.
platform: Blazor
control: Scheduler
documentation: ug
---

# Context Menu in Blazor Scheduler Component

The context menu can be displayed on work cells, resource cells and appointments of Scheduler by making use of the `ContextMenu` control manually from the application end. In the following code example, context menu control is being added from sample end and set its target as `Scheduler` and the target element is got by using `GetElementInfoAsync` public method in Blazor.

On Scheduler cells, the menu items can be displayed such as `New Event`, `New Recurring Event` and `Today` option. For appointments, its related options can be displayed such as `Edit Event` and `Delete Event`. For resource cells, the related resource cell information can be displayed. The default event window can be opened for appointment creation and editing using the `OpenEditorAsync` method of Scheduler.

The deletion of appointments can be done by using the `DeleteEventAsync` public method. Also, the `SelectedDate` property can be used to navigate between different dates.

> You can also display custom menu options on Scheduler cells and appointments. Context menu will open on tap-hold in responsive mode.

```cshtml
@using Syncfusion.Blazor.Schedule
@using Syncfusion.Blazor.Navigations
<SfSchedule TValue="ResourceData" @ref="ScheduleRef" Height="650px" @bind-SelectedDate="@SelectedDate">
    <ScheduleGroup Resources="@groupData"></ScheduleGroup>
    <ScheduleResources>
        <ScheduleResource TItem="ResourceData" TValue="int" DataSource="@ProjectData" Field="ProjectId" Title="Choose Project" Name="Projects" TextField="Text" IdField="Id" ColorField="Color"></ScheduleResource>
        <ScheduleResource TItem="ResourceData" TValue="int[]" DataSource="@TaskData" Field="TaskId" Title="Category" Name="Categories" TextField="Text" IdField="Id" GroupIDField="GroupId" ColorField="Color" AllowMultiple="true"></ScheduleResource>
    </ScheduleResources>
    <ScheduleEventSettings DataSource="@DataSource"></ScheduleEventSettings>
    <ScheduleViews>
        <ScheduleView Option="View.Day"></ScheduleView>
        <ScheduleView Option="View.Week"></ScheduleView>
        <ScheduleView Option="View.WorkWeek"></ScheduleView>
        <ScheduleView Option="View.Month"></ScheduleView>
        <ScheduleView Option="View.Agenda"></ScheduleView>
        <ScheduleView Option="View.TimelineDay"></ScheduleView>
        <ScheduleView Option="View.TimelineWeek"></ScheduleView>
        <ScheduleView Option="View.TimelineWorkWeek"></ScheduleView>
        <ScheduleView Option="View.TimelineMonth"></ScheduleView>
        </ScheduleViews>
    </SfSchedule>
    <SfContextMenu TValue="MenuItem" Target=".e-schedule">
        <MenuItems>
            <MenuItem Text="New Event" IconCss="e-icons e-plus" Id="Add" Hidden="@isCell"></MenuItem>
            <MenuItem Text="New Recurring Event" IconCss="e-icons e-repeat" Hidden="@isCell" Id="AddRecurrence"></MenuItem>
            <MenuItem Text="Today" IconCss="e-icons e-timeline-today" Id="Today" Hidden="@isCell"></MenuItem>
            <MenuItem Text="Edit Event" IconCss="e-icons e-edit" Id="Save" Hidden="@isEvent"></MenuItem>
            <MenuItem Text="Edit Event" IconCss="e-icons e-edit" Id="EditRecurrenceEvent" Hidden="@isRecurrence">
                <MenuItems>
                    <MenuItem Text="Edit Occurrence" Id="EditOccurrence" Hidden="@isRecurrence"></MenuItem>
                    <MenuItem Text="Edit Series" Id="EditSeries" Hidden="@isRecurrence"></MenuItem>
                </MenuItems>
            </MenuItem>
            <MenuItem Text="Delete Event" IconCss="e-icons e-trash" Id="Delete" Hidden="@isEvent"></MenuItem>
            <MenuItem Text="Delete Event" IconCss="e-icons e-trash" Id="DeleteRecurrenceEvent" Hidden="@isRecurrence">
                <MenuItems>
                    <MenuItem Text="Delete Occurrence" Id="DeleteOccurrence" Hidden="@isRecurrence"></MenuItem>
                    <MenuItem Text="Delete Series" Id="DeleteSeries" Hidden="@isRecurrence"></MenuItem>
                </MenuItems>
            </MenuItem>
        </MenuItems>
        <MenuEvents TValue="MenuItem" OnOpen="OnOpen" ItemSelected="OnItemSelected"></MenuEvents>
    </SfContextMenu>

@code{
    private DateTime SelectedDate = new DateTime(2020, 1, 8);
    private bool isCell;
    private bool isEvent;
    private bool isRecurrence;
    SfSchedule<ResourceData> ScheduleRef;
    private ResourceData EventData { get; set; }
    private CellClickEventArgs CellData { get; set; }
    private ElementInfo<ResourceData> ElementData { get; set; }
    private string[] groupData = new string[] { "Projects", "Categories" };
    private List<ResourceData> ProjectData { get; set; } = new List<ResourceData> {
        new ResourceData {Text = "PROJECT 1", Id= 1, Color= "#cb6bb2"},
        new ResourceData {Text = "PROJECT 2", Id= 2, Color= "#56ca85"},
        new ResourceData {Text = "PROJECT 3", Id= 3, Color= "#df5286"}
    };
    private List<ResourceData> TaskData { get; set; } = new List<ResourceData> {
        new ResourceData { Text = "Nancy", Id= 1, GroupId = 1, Color = "#df5286" },
        new ResourceData { Text = "Steven", Id= 2, GroupId = 1, Color = "#7fa900" },
        new ResourceData { Text = "Robert", Id= 3, GroupId = 2, Color = "#ea7a57" },
        new ResourceData { Text = "Smith", Id= 4, GroupId = 2, Color = "#5978ee" },
        new ResourceData { Text = "Michael", Id= 5, GroupId = 3, Color = "#df5286" },
        new ResourceData { Text = "Root", Id= 6, GroupId = 3, Color = "#00bdae" }
    };
    public class ResourceData
    {
        public string Text { get; set; }
        public int Id { get; set; }
        public int GroupId { get; set; }
        public string Color { get; set; }
        public string Subject { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsAllDay { get; set; }
        public string RecurrenceRule { get; set; }
        public Nullable<int> RecurrenceID { get; set; }
        public int ProjectId { get; set; }
        public int TaskId { get; set; }
    }
    public List<ResourceData> DataSource = new List<ResourceData>
    {
        new ResourceData { Id = 1, Subject = "Workflow Analysis", StartTime = new DateTime(2020, 1, 8, 10, 30, 0) , EndTime = new DateTime(2020, 1, 8, 12, 30, 0) , IsAllDay = false,  ProjectId = 1, TaskId = 2},
        new ResourceData { Id = 2, Subject = "Requirement planning", StartTime = new DateTime(2020, 1, 8, 9, 30, 0) , EndTime = new DateTime(2020, 1, 8, 12, 30, 0) , IsAllDay = false,  ProjectId = 1, TaskId = 1},
    };
        
    public async Task OnOpen(BeforeOpenCloseMenuEventArgs<MenuItem> args)
    {
        if (args.ParentItem == null)
        {
            ElementData = await ScheduleRef.GetElementInfoAsync((int)args.Left, (int)args.Top);
            if (ElementData.ElementType == ElementType.Event)
            {
                EventData = ElementData.EventData;
                if (EventData.Id == 0)
                {
                    args.Cancel = true;
                }
                if (EventData.RecurrenceRule != null)
                {
                    isCell = isEvent = true;
                    isRecurrence = false;
                }
                else
                {
                    isCell = isRecurrence = true;
                    isEvent = false;
                }
            }
            else
            {
                isCell = false;
                isEvent = isRecurrence = true;
            }

            if (ElementData.ElementType == ElementType.WorkCells)
            {
                var groupIndex = this.ScheduleRef.GetGroupIndex((ElementData.ResourceData.Last() as ResourceData).Id, "Categories");
                CellClickEventArgs cellData = new CellClickEventArgs
                {
                    StartTime = ElementData.StartTime,
                    EndTime = ElementData.EndTime,
                    IsAllDay = ElementData.IsAllDay,
                    GroupIndex = groupIndex,
                };
                CellData = cellData;
                isCell = false;
                isEvent = isRecurrence = true;
            }

            if (ElementData.ElementType == ElementType.ResourceHeader)
            {
                Console.WriteLine(ElementData.ResourceData);
            }
        }
    }
    public async Task OnItemSelected(MenuEventArgs<MenuItem> args)
    {
        var SelectedMenuItem = args.Item.Id;
        var ActiveCellsData = await ScheduleRef.GetSelectedCellsAsync();
        if (ActiveCellsData == null)
        {
            ActiveCellsData = CellData;
        }
        switch (SelectedMenuItem)
        {
            case "Today":
                SelectedDate = DateTime.Now;
                break;
            case "Add":
                await ScheduleRef.OpenEditorAsync(ActiveCellsData, CurrentAction.Add);
                break;
            case "AddRecurrence":
                await ScheduleRef.OpenEditorAsync(ActiveCellsData, CurrentAction.Add, RepeatType.Daily);
                break;
            case "Save":
                await ScheduleRef.OpenEditorAsync(EventData, CurrentAction.Save);
                break;
            case "EditOccurrence":
                await ScheduleRef.OpenEditorAsync(EventData, CurrentAction.EditOccurrence);
                break;
            case "EditSeries":
                List<ResourceData> Events = await ScheduleRef.GetEventsAsync();
                EventData = (ResourceData)Events.Where(data => data.Id == EventData.RecurrenceID).FirstOrDefault();
                await ScheduleRef.OpenEditorAsync(EventData, CurrentAction.EditSeries);
                break;
            case "Delete":
                await ScheduleRef.DeleteEventAsync(EventData);
                break;
            case "DeleteOccurrence":
                await ScheduleRef.DeleteEventAsync(EventData, CurrentAction.DeleteOccurrence);
                break;
            case "DeleteSeries":
                await ScheduleRef.DeleteEventAsync(EventData, CurrentAction.DeleteSeries);
                break;
        }
    }
}

```