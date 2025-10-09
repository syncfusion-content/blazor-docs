---
layout: post
title: State Management in Blazor TreeGrid Component | Syncfusion
description: Learn how to manage and persist state in the Syncfusion Blazor TreeGrid component and much more details.
platform: Blazor
control: TreeGrid
documentation: ug
---

# State Management in Blazor TreeGrid Component

The TreeGrid component supports state persistence using the browser's local storage. It also provides methods to manually save, load, and reset the grid's state. When a saved state is applied, the TreeGrid renders based on that state rather than its declarative property values.

The following properties can be persisted:

- Columns  
- TreeColumnIndex  
- TreeGridFilterSettings  
- TreeGridSortSettings  
- TreeGridPageSettings  

## Enabling Persistence in TreeGrid

State persistence allows the TreeGrid to retain its current state across browser reloads. This feature is controlled by the `EnablePersistence` property, which is disabled by default. When enabled, supported properties are stored in local storage and restored automatically.

N> The persisted state is tied to the **ID** property. It is recommended to explicitly set the **ID** property for the TreeGrid.
<br/>To reset the TreeGrid state to its original configuration, use the [ResetPersistDataAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_ResetPersistDataAsync) method. This clears the stored data and re-renders the TreeGrid using its initial property values.

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

## Handling TreeGrid state manually

The TreeGrid state can be managed manually using built-in persistence methods. These include: [GetPersistDataAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_GetPersistDataAsync), [SetPersistDataAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_SetPersistDataAsync), [ResetPersistDataAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_ResetPersistDataAsync) methods of TreeGrid to save, load, and reset the TreeGrid's persisted state respectively.
 1. `GetPersistDataAsync` - Returns TreeGrid properties as a string value, which is suitable for sending them over a network and storing them in databases.
 2. `SetPersistDataAsync` - Loads already saved the state of the TreeGrid.
 3. `ResetPersistDataAsync` - Clears persisted data in window local storage and renders TreeGrid with its original property values.

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
