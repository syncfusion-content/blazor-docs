---
layout: post
title: Blazor TreeGrid State Management | Syncfusion
description: Learn how to persist, save, restore, and manage state in Blazor TreeGrid, including reset options and state persistence settings.
platform: Blazor
control: Tree Grid
documentation: ug
---

# State Management in Blazor TreeGrid

The TreeGrid component automatically retains state in browser local storage when the page is reloaded. Additionally, TreeGrid state can be manually saved and loaded using built-in methods. When state is restored, the TreeGrid renders with the saved state instead of relying solely on declaratively provided properties.

## Persistable Properties

The following properties can be saved and restored when state persistence is enabled:

| Property | Description |
|----------|-------------|
| **Columns** | Column order, visibility, width, and other column-specific settings |
| **TreeColumnIndex** | The index of the column that displays the expand/collapse icons for the tree hierarchy |
| **TreeGridFilterSettings** | Active filter conditions and filter mode settings |
| **TreeGridSortSettings** | Active sort columns, sort direction (ascending/descending), and multi-column sort order |
| **TreeGridPageSettings** | Current page number and page size for paginated TreeGrids |

## Enabling Persistence in TreeGrid

Enable state persistence by setting the [EnablePersistence](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_EnablePersistence) property to **true**. When enabled, TreeGrid automatically saves and restores the persistable properties after page reload.

N> State persistence is based on the TreeGrid component's **ID** property. Explicitly set the **ID** property for proper state persistence.
<br/> Use [ResetPersistDataAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_ResetPersistDataAsync) to restore the TreeGrid to its original state. This clears all persisted data from browser local storage.

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

## Handling TreeGrid State Manually

Manually manage TreeGrid state persistence using the following methods:

* [GetPersistDataAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_GetPersistDataAsync) — Retrieves the current TreeGrid state as a JSON string. Use this to save state to a database, file, or external storage for cross-device or cross-browser persistence.

* [SetPersistDataAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_SetPersistDataAsync_System_String_) — Restores a previously saved TreeGrid state from a JSON string. Use this to restore state that was saved using `GetPersistDataAsync`.

* [ResetPersistDataAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_ResetPersistDataAsync) — Clears all persisted data from browser local storage and restores the TreeGrid to its original state.

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
    private async Task ClearPersistence()  
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
}
```
