---
layout: post
title: Dependency validation in Blazor Gantt Chart Component | Syncfusion
description: Checkout and learn here all about how to enable or disable predecessor validation on predecessor drawing.
platform: Blazor
control: Gantt Chart
documentation: ug
---

# Restricting dependency validation using OnActionBegin event 

When the connector lines are drawn between tasks, the task date gets validated based on predecessor values. We can restrict this validation on predecessor drawing using the `OnActionBegin` event which gets triggered with the `Action` argument as `DrawConnectorLine`. You can enable/disable the validation using `EnableAutoLinkValidation` event argument. By default `EnableAutoLinkValidation` is true.

```cshtml
@using Syncfusion.Blazor.Gantt

<SfGantt @ref="Gantt" DataSource="@TaskCollection" Height="450px" Width="1000px" ProjectStartDate="@ProjectStart" 
    ProjectEndDate="@ProjectEnd"  Toolbar="@(new List<string>() { "Add",  "Edit", "Update", "Cancel", "Delete"})">

	<GanttTaskFields Id="TaskId" Name="TaskName" StartDate="StartDate"
		Duration="Duration" Dependency="Predecessor" ParentID="ParentId">
	</GanttTaskFields>
	<GanttEditSettings AllowTaskbarEditing="true" AllowEditing="true" AllowAdding="true"
		AllowDeleting="true" ShowDeleteConfirmDialog="true">
	</GanttEditSettings>
    <GanttEvents OnActionBegin="ActionBegin" TValue="TaskData"></GanttEvents>
</SfGantt>

@code {
	public SfGantt<TaskData> Gantt;
	public DateTime ProjectStart = new DateTime(2019, 3, 24);
    public DateTime ProjectEnd = new DateTime(2019, 7, 6);
	public List<TaskData> TaskCollection { get; set; }
	protected override void OnInitialized()
	{
		this.TaskCollection = GetTaskCollection();
	}
	
    public void ActionBegin(GanttActionEventArgs<TaskData> args)
    {
        if(args.Action != null && args.Action.Equals("DrawConnectorLine", StringComparison.Ordinal)){
			args.EnableAutoLinkValidation = false;
		}
    }
	
	public class TaskData
	{
		public int TaskId { get; set; }
		public string TaskName { get; set; }
		public DateTime StartDate { get; set; }
		public string Duration { get; set; }
		public string Predecessor { get; set; }
		public int Progress { get; set; }
		public int? ParentId { get; set; }
	}

	public static List<TaskData> GetTaskCollection()
	{
		List<TaskData> Tasks = new List<TaskData>() {
            new TaskData() { TaskId = 1, TaskName = "Project initiation", StartDate = new DateTime(2019, 04, 02)},
            new TaskData() { TaskId = 2, TaskName = "Identify Site location", StartDate = new DateTime(2019, 04, 02), Progress = 30, ParentId = 1},
            new TaskData() { TaskId = 3, TaskName = "Perform soil test", StartDate = new DateTime(2019, 04, 02), Duration = "3", Progress = 40, Predecessor = "2fs", ParentId = 1 },
            new TaskData() { TaskId = 4, TaskName = "Soil test approval", StartDate = new DateTime(2019, 04, 02), Duration = "1", Progress = 30, ParentId = 1 },
            new TaskData() { TaskId = 5, TaskName = "Project estimation", StartDate = new DateTime(2019, 04, 02) },
            new TaskData() { TaskId = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2019, 04, 04), Duration = "3", Progress = 30, ParentId = 5 },
            new TaskData() { TaskId = 7, TaskName = "List materials", StartDate = new DateTime(2019, 04, 04), Duration = "3", Progress = 40, ParentId = 5 },
            new TaskData() { TaskId = 8, TaskName = "Estimation approval", StartDate = new DateTime(2019, 04, 04), Duration = "2", Progress = 30, ParentId = 5 }
        };
	    return Tasks;
	}
}
```

`Note:` `EnablePredecessorValidation` is used to enable/disable validation based on predecessor values both on load time and on edit actions like cell editing, dialog editing, and on predecessor drawing. Whereas, `EnableAutoLinkValidation` event argument is used to enable/disable validation only on predecessor drawing. 