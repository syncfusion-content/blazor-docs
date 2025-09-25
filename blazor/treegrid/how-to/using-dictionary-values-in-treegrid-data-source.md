---
layout: post
title: Using Dictionary as DataSource in Blazor TreeGrid | Syncfusion
description: Learn how to use dictionary values in the TreeGrid DataSource in Syncfusion Blazor TreeGrid component.
platform: Blazor
control: TreeGrid
documentation: ug
---

# Using Dictionary values as DataSource in Blazor TreeGrid Component

Dictionary values can be assigned to the Tree Grid's data source by accessing them using **KeyValuePair** data type inside the [Template](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridColumn.html#Syncfusion_Blazor_TreeGrid_TreeGridColumn_Template) property of the [TreeGridColumn](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridColumns.html) component.

The following sample demonstrates how **Designation** is defined as a dictionary and accessed inside the [TreeGridColumn](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridColumns.html) using **KeyValuePair** is compared with the **TaskId** column value, and the corresponding value is displayed.

```cshtml
@using TreeGridComponent.Data;
@using Syncfusion.Blazor.Grids;
@using Syncfusion.Blazor.TreeGrid;


<SfTreeGrid DataSource="@TreeGridData" IdMapping="TaskId" ParentIdMapping="ParentId" AllowPaging="true"
            TreeColumnIndex="1" >
    <TreeGridColumns>
        <TreeGridColumn Field="TaskId" HeaderText="Task ID" IsPrimaryKey="true" Width="100" TextAlign="TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="TaskName" HeaderText="Task Name" Width="145"></TreeGridColumn>
        <TreeGridColumn Field="Duration" HeaderText="Duation" Width="90"></TreeGridColumn>
        <TreeGridColumn Field="Priority" HeaderText="Priority" Width="90"></TreeGridColumn>
        <TreeGridColumn Field="Designation" HeaderText="Designation" Width="90">
            <Template>
                @{
                    var Details = context as TaskDetails;
                    var level = Details.Designation.Select(kvp => (kvp.Key == Details.TaskId) ? kvp.Value.ToString() : "");
                    <p>@string.Join("", level)</p>
                }
            </Template>
        </TreeGridColumn>
    </TreeGridColumns>
</SfTreeGrid>

@code{
    SfTreeGrid<TaskDetails> TreeGrid;

    public class TaskDetails
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public int Duration { get; set; }
        public int? Progress { get; set; }
        public string Priority { get; set; }
        public int? ParentId { get; set; }
        public Dictionary<int, string> Designation { get; set; }

    }
    List<TaskDetails> TreeGridData = new List<TaskDetails>
    {
        new TaskDetails { TaskId = 1, TaskName = "Parent Task 1", Duration = 10, Progress = 70, Priority = "Critical", ParentId = null, Designation = DesignationDetails},
        new TaskDetails { TaskId = 2, TaskName = "Child task 1",Duration = 50, Progress = 80, Priority = "Low",  ParentId = 1, Designation = DesignationDetails},
        new TaskDetails { TaskId = 3, TaskName = "Child Task 2", Duration = 5, Progress = 65, Priority = "Critical", ParentId = 2, Designation = DesignationDetails},
        new TaskDetails { TaskId = 4, TaskName = "Child task 3", Duration = 6, Priority = "High", Progress = 77, ParentId = 3, Designation = DesignationDetails},
        new TaskDetails { TaskId = 5, TaskName = "Parent Task 2", Duration = 10, Progress = 70, Priority = "Critical", ParentId = null, Designation = DesignationDetails},
        new TaskDetails { TaskId = 6, TaskName = "Child task 1", Duration = 4, Progress = 80, Priority = "Critical", ParentId = 5, Designation = DesignationDetails},
        new TaskDetails { TaskId = 7, TaskName = "Child Task 2", Duration = 5, Progress = 65, Priority = "Low", ParentId = 5, Designation = DesignationDetails},
        new TaskDetails { TaskId = 8, TaskName = "Child task 3", Duration = 7, Progress = 77, Priority = "High", ParentId = 5, Designation = DesignationDetails},
        new TaskDetails { TaskId = 9, TaskName = "Child task 4", Duration = 6, Progress = 77, Priority = "Low", ParentId = 5, Designation = DesignationDetails},
    };
    private static Dictionary<int, string> DesignationDetails = new Dictionary<int, string>()
    {
            { 1, "Level1" },
            { 2, "Level2" },
            { 3, "Level3" },
            { 4, "Level4" },
            { 5, "Level5" },
            { 6, "Level6" },
            { 7, "Level7" },
            { 8, "Level8" },
            { 9, "Level9" },
        };
}

```
![Dictionary Values in Blazor TreeGrid](../images/blazor-treegrid-dictionary-values.png)
