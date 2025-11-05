---
layout: post
title: State management in Blazor TreeGrid Component | Syncfusion
description: Learn here all about State management in Syncfusion Blazor TreeGrid component and much more details.
platform: Blazor
control: Tree Grid
documentation: ug
---

# State management in Blazor TreeGrid Component

Tree Grid Component retains its state using local storage on browser reload. Also, it allows users to save and load tree grid state manually. The tree grid will use a user-provided state to render instead of its properties provided declaratively.

Below properties can be saved and loaded into a tree grid.

Property|
-----|
Columns |
TreeColumnIndex |
TreeGridFilterSettings |
TreeGridSortSettings |
TreeGridPageSettings |

## Enabling persistence in tree grid

State persistence allows the tree grid to retain the current tree grid state in the browser's local storage for state maintenance. This action is handled through the `EnablePersistence` property, which is disabled by default. When it is enabled, some properties of the tree grid will be retained even after refreshing the page.

N> The state will be persisted based on **ID** property. So, it is recommended to explicitly set the **ID** property for tree grid.
<br/> You can use [ResetPersistDataAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_ResetPersistDataAsync) method to reset tree grid state to its original state. This will clear persisted data in window local storage and renders tree grid with its original property values.

```cshtml
@using Syncfusion.Blazor.TreeGrid;

<SfTreeGrid ID="TreeGrid" DataSource="@TreeData" Height="312" IdMapping="TaskId" ParentIdMapping="ParentId" TreeColumnIndex="1" EnablePersistence="true" AllowPaging="true" AllowFiltering="true" AllowSorting="true" AllowReordering="true" AllowResizing="true" ShowColumnMenu="true" Toolbar="@(new List<string>() { "Search" })">
    <TreeGridPageSettings PageSize="2"></TreeGridPageSettings>
    <TreeGridColumns>
        <TreeGridColumn Field="TaskId" HeaderText="Task ID" Width="80" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="TaskName" HeaderText="Task Name" Width="160"></TreeGridColumn>
        <TreeGridColumn Field="Duration" HeaderText="Duration" Width="100" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="Progress" HeaderText="Progress" Width="100" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
    </TreeGridColumns>
</SfTreeGrid>

@code{
   public class BusinessObject
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public int Duration { get; set; }
        public int Progress { get; set; }
        public string Priority { get; set; }
        public int? ParentId { get; set; }
    }

    public List<BusinessObject> TreeData = new List<BusinessObject>();

    protected override void OnInitialized()
    {
        TreeData.Add(new BusinessObject() { TaskId = 1, TaskName = "Parent Task 1", Duration = 10, Progress = 70, ParentId = null, Priority = "High" });
        TreeData.Add(new BusinessObject() { TaskId = 2, TaskName = "Child task 1", Duration = 4, Progress = 80, ParentId = 1, Priority = "Normal" });
        TreeData.Add(new BusinessObject() { TaskId = 3, TaskName = "Child Task 2", Duration = 5, Progress = 65, ParentId = 1, Priority = "Critical" });
        TreeData.Add(new BusinessObject() { TaskId = 4, TaskName = "Parent Task 2", Duration = 6, Progress = 77, ParentId = null, Priority = "Low" });
        TreeData.Add(new BusinessObject() { TaskId = 5, TaskName = "Child Task 5", Duration = 9, Progress = 25, ParentId = 4, Priority = "Normal" });
        TreeData.Add(new BusinessObject() { TaskId = 6, TaskName = "Child Task 6", Duration = 9, Progress = 7, ParentId = 5, Priority = "Normal" });
        TreeData.Add(new BusinessObject() { TaskId = 7, TaskName = "Parent Task 3", Duration = 4, Progress = 45, ParentId = null, Priority = "High" });
        TreeData.Add(new BusinessObject() { TaskId = 8, TaskName = "Child Task 7", Duration = 3, Progress = 38, ParentId = 7, Priority = "Critical" });
        TreeData.Add(new BusinessObject() { TaskId = 9, TaskName = "Child Task 8", Duration = 7, Progress = 70, ParentId = 7, Priority = "Low" });
    }
}
```

## Handling tree grid state manually

You can handle the tree grid's state manually by using built-in state persistence methods. You can use [GetPersistDataAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_GetPersistDataAsync), [SetPersistDataAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_SetPersistDataAsync), [ResetPersistDataAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_ResetPersistDataAsync) methods of tree grid to save, load, and reset the tree grid's persisted state respectively.
 1. `GetPersistDataAsync` - Returns tree grid properties as a string value, which is suitable for sending them over a network and storing them in databases.
 2. `SetPersistDataAsync` - Loads already saved the state of the tree grid.
 3. `ResetPersistDataAsync` - Clears persisted data in window local storage and renders tree grid with its original property values.

```cshtml
@using Syncfusion.Blazor.TreeGrid;
@using Syncfusion.Blazor.Buttons;

<button id="GetPersistence" @onclick="GetPersistence">Save Current State</button>
<button id="SetPersistence" @onclick="SetPersistence">Set State</button> 
<button id="ClearPersistence" @onclick="ClearPersistence">Reset State</button>

<SfTreeGrid ID="TreeGridOne" @ref="TreeGrid" DataSource="@TreeData" Height="312" IdMapping="TaskId" ParentIdMapping="ParentId" TreeColumnIndex="1" EnablePersistence="true" AllowPaging="true" AllowFiltering="true" AllowSorting="true" AllowReordering="true" AllowResizing="true" ShowColumnMenu="true" Toolbar="@(new List<string>() { "Search" })">
    <TreeGridPageSettings PageSize="2"></TreeGridPageSettings>
    <TreeGridColumns>
        <TreeGridColumn Field="TaskId" HeaderText="Task ID" Width="80" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="TaskName" HeaderText="Task Name" Width="160"></TreeGridColumn>
        <TreeGridColumn Field="Duration" HeaderText="Duration" Width="100" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="Progress" HeaderText="Progress" Width="100" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
    </TreeGridColumns>
</SfTreeGrid>

@code{
    public SfTreeGrid<BusinessObject> TreeGrid;
    public string SavedPersistence { get; set; } = "";
    private async Task GetPersistence()  
    {  
        SavedPersistence =  await TreeGrid.GetPersistDataAsync();
    } 
    private async Task SetPersistence()  
    {  
        await TreeGrid.SetPersistDataAsync(SavedPersistence);
    } 
    private async void ClearPersistence()  
    {  
        await TreeGrid.ResetPersistDataAsync();
    }  
   public class BusinessObject
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public int Duration { get; set; }
        public int Progress { get; set; }
        public string Priority { get; set; }
        public int? ParentId { get; set; }
    }

    public List<BusinessObject> TreeData = new List<BusinessObject>();

    protected override void OnInitialized()
    {
        TreeData.Add(new BusinessObject() { TaskId = 1, TaskName = "Parent Task 1", Duration = 10, Progress = 70, ParentId = null, Priority = "High" });
        TreeData.Add(new BusinessObject() { TaskId = 2, TaskName = "Child task 1", Duration = 4, Progress = 80, ParentId = 1, Priority = "Normal" });
        TreeData.Add(new BusinessObject() { TaskId = 3, TaskName = "Child Task 2", Duration = 5, Progress = 65, ParentId = 1, Priority = "Critical" });
        TreeData.Add(new BusinessObject() { TaskId = 4, TaskName = "Parent Task 2", Duration = 6, Progress = 77, ParentId = null, Priority = "Low" });
        TreeData.Add(new BusinessObject() { TaskId = 5, TaskName = "Child Task 5", Duration = 9, Progress = 25, ParentId = 4, Priority = "Normal" });
        TreeData.Add(new BusinessObject() { TaskId = 6, TaskName = "Child Task 6", Duration = 9, Progress = 7, ParentId = 5, Priority = "Normal" });
        TreeData.Add(new BusinessObject() { TaskId = 7, TaskName = "Parent Task 3", Duration = 4, Progress = 45, ParentId = null, Priority = "High" });
        TreeData.Add(new BusinessObject() { TaskId = 8, TaskName = "Child Task 7", Duration = 3, Progress = 38, ParentId = 7, Priority = "Critical" });
        TreeData.Add(new BusinessObject() { TaskId = 9, TaskName = "Child Task 8", Duration = 7, Progress = 70, ParentId = 7, Priority = "Low" });
    }
```
