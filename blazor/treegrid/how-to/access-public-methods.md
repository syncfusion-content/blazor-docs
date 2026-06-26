---
layout: post
title: Access public methods in Blazor TreeGrid Component | Syncfusion
description: Learn here all about accessing public methods in Tree Grid in Syncfusion Blazor TreeGrid component and more.
platform: Blazor
control: Tree Grid
documentation: ug
---

# Access public methods in Tree Grid in Blazor TreeGrid Component

The public methods of the Blazor TreeGrid component provide programmatic control over actions such as printing, expanding or collapsing rows, refreshing the grid, and manipulating selection. These methods are available through the component reference that is assigned in the Razor markup.

A component reference is created by using the `@ref` directive in the `SfTreeGrid` tag. After the component is rendered, you can call the public methods from event handlers or lifecycle methods such as `OnAfterRenderAsync`.

The following example shows how to invoke the [PrintAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_PrintAsync) method from an external button click. This approach is useful when you need to expose TreeGrid features through custom toolbar buttons or page actions.

## Example: Invoke `PrintAsync` using TreeGrid reference

{% tabs %}

{% highlight razor %}

@using TreeGridComponent.Data;
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Grids;
@using Syncfusion.Blazor.TreeGrid;

<SfButton OnClick="Print" CssClass="e-primary" IsPrimary="true" Content="Print data"></SfButton>

<SfTreeGrid @ref="TreeGrid" DataSource="@TreeGridData" IdMapping="TaskId" ParentIdMapping="ParentId"
            TreeColumnIndex="1" AllowPaging="true" Height="200">
    <TreeGridColumns>
        <TreeGridColumn Field="TaskId" HeaderText="Task ID" Width="80" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="TaskName" HeaderText="Task Name" Width="160"></TreeGridColumn>
        <TreeGridColumn Field="Duration" HeaderText="Duration" Width="100" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="Progress" HeaderText="Progress" Width="100" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="Priority" HeaderText="Priority" Width="80"></TreeGridColumn>
    </TreeGridColumns>
</SfTreeGrid>

@code{
    SfTreeGrid<TreeData> TreeGrid;

    public List<TreeData> TreeGridData { get; set; }

    public void Print()
    {
        if (TreeGrid != null)
        {
            this.TreeGrid.PrintAsync();
        }
    }

    protected override void OnInitialized()
    {
        this.TreeGridData = TreeData.GetSelfDataSource().ToList();
    }
}

{% endhighlight %}

## Sample data model

{% highlight c# %}

namespace TreeGridComponent.Data
{
    public class TreeData
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public int? Duration { get; set; }
        public int? Progress { get; set; }
        public string Priority { get; set; }
        public int? ParentId { get; set; }

        public static List<TreeData> GetSelfDataSource()
        {
            List<TreeData> TreeDataCollection = new List<TreeData>();
            TreeDataCollection.Add(new TreeData() { TaskId = 1, TaskName = "Parent Task 1", Duration = 10, Progress = 70, Priority = "Critical", ParentId = null });
            TreeDataCollection.Add(new TreeData() { TaskId = 2, TaskName = "Child task 1", Progress = 80, Priority = "Low", Duration = 50, ParentId = 1 });
            TreeDataCollection.Add(new TreeData() { TaskId = 3, TaskName = "Child Task 2", Duration = 5, Progress = 65, Priority = "Critical", ParentId = 2 });
            TreeDataCollection.Add(new TreeData() { TaskId = 4, TaskName = "Child task 3", Duration = 6, Priority = "High", Progress = 77, ParentId = 3 });
            TreeDataCollection.Add(new TreeData() { TaskId = 5, TaskName = "Parent Task 2", Duration = 10, Progress = 70, Priority = "Critical", ParentId = null });
            TreeDataCollection.Add(new TreeData() { TaskId = 6, TaskName = "Child task 1", Duration = 4, Progress = 80, Priority = "Critical", ParentId = 5 });
            TreeDataCollection.Add(new TreeData() { TaskId = 7, TaskName = "Child Task 2", Duration = 5, Progress = 65, Priority = "Low", ParentId = 5 });
            TreeDataCollection.Add(new TreeData() { TaskId = 8, TaskName = "Child task 3", Duration = 6, Progress = 77, Priority = "High", ParentId = 5 });
            TreeDataCollection.Add(new TreeData() { TaskId = 9, TaskName = "Child task 4", Duration = 6, Progress = 77, Priority = "Low", ParentId = 5 });
            return TreeDataCollection;
        }
    }
}

{% endhighlight %}

## Common TreeGrid public methods

These public methods are frequently used to perform actions directly on the TreeGrid component instance:

- `PrintAsync()` - Prints the current TreeGrid content.
- `RefreshAsync()` - Refreshes the grid content and updates the UI.
- `ExpandAllAsync()` - Expands all rows in the TreeGrid.
- `CollapseAllAsync()` - Collapses all rows in the TreeGrid.
- `SelectRowAsync(int rowIndex)` - Selects a row by index.
- `ClearSelectionAsync()` - Clears the current row selection.
- `OpenDialogAsync()` / `CloseDialogAsync()` - Opens and closes dialogs when editing is enabled.

## Best practices

- Always assign the `@ref` reference to a field so you can access the TreeGrid instance from your component code.
- Call public methods in response to user actions, such as button clicks, or after rendering is complete.
- Verify the TreeGrid reference is not `null` before calling a method from the component instance.
- For asynchronous operations, use the method return value when necessary and handle any awaited tasks.

## Additional notes

The TreeGrid public method API is part of the Syncfusion Blazor TreeGrid component and is documented in the API reference. Use the API reference link to explore additional methods, properties, and overloads for the TreeGrid component.

N> Similarly all the public methods of the Tree Grid can be invoked. The available public methods can be found in this [link](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html).
