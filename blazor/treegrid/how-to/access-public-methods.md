---
layout: post
title: Access public methods in Blazor TreeGrid | Syncfusion
description: Checkout and learn here all the details about accessing public methods in Blazor TreeGrid component and much more details.
platform: Blazor
control: Tree Grid
documentation: ug
---

# Access Public Methods in Blazor TreeGrid Component

In many applications, TreeGrid actions need to be triggered from outside the TreeGrid interface. Common scenarios include:

- Print TreeGrid data from a custom button.
- Refresh the TreeGrid after updating data from an API.
- Expand or collapse records from a toolbar action.
- Select a row programmatically after a search operation.
- Open an edit dialog based on custom business logic.

To support these scenarios, the Blazor TreeGrid provides public methods that can be accessed programmatically through a component reference obtained using the `@ref` directive.
## When to use Public Methods

- Invoke TreeGrid actions such as print, refresh, or select from external UI controls.
- Refresh the TreeGrid after updating data from an API or database.
- Select, edit, or expand records based on actions performed in another component.
- Synchronize TreeGrid behavior with dialogs, forms, dashboards, or custom workflows.

**Access the TreeGrid instance**

Before invoking a TreeGrid public method, obtain a reference to the TreeGrid component instance using the `@ref` directive. The component reference provides access to the TreeGrid's public properties and methods. The reference is assigned after the component is rendered and then can  be used to invoke public methods programmatically.

```razor
<SfTreeGrid @ref="TreeGrid"></SfTreeGrid>
```

```csharp
private SfTreeGrid<TreeData> TreeGrid;
```

The component reference becomes available after the TreeGrid has been rendered.

N> To access the TreeGrid instance during component initialization, use lifecycle methods such as `OnAfterRenderAsync`.

**Example: Print TreeGrid data using a custom button**

{% tabs %}

{% highlight razor %}

@using TreeGridComponent.Data;
@using Syncfusion.Blazor.Buttons;
@using Syncfusion.Blazor.Grids;
@using Syncfusion.Blazor.TreeGrid;

<SfButton OnClick="Print"
          CssClass="e-primary"
          IsPrimary="true"
          Content="Print data">
</SfButton>

<SfTreeGrid @ref="TreeGrid"
            DataSource="@TreeGridData"
            IdMapping="TaskId"
            ParentIdMapping="ParentId"
            TreeColumnIndex="1"
            AllowPaging="true"
            Height="200">

    <TreeGridColumns>
        <TreeGridColumn Field="TaskId"
                        HeaderText="Task ID"
                        Width="80"
                        TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right">
        </TreeGridColumn>

        <TreeGridColumn Field="TaskName"
                        HeaderText="Task Name"
                        Width="160">
        </TreeGridColumn>

        <TreeGridColumn Field="Duration"
                        HeaderText="Duration"
                        Width="100"
                        TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right">
        </TreeGridColumn>

        <TreeGridColumn Field="Progress"
                        HeaderText="Progress"
                        Width="100"
                        TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right">
        </TreeGridColumn>

        <TreeGridColumn Field="Priority"
                        HeaderText="Priority"
                        Width="80">
        </TreeGridColumn>
    </TreeGridColumns>

</SfTreeGrid>

@code {

    private SfTreeGrid<TreeData> TreeGrid;

    public List<TreeData> TreeGridData { get; set; }

    public async Task Print()
    {
        if (TreeGrid != null)
        {
            await TreeGrid.PrintAsync();
        }
    }

    protected override void OnInitialized()
    {
        TreeGridData = TreeData.GetSelfDataSource().ToList();
    }
}

{% endhighlight %}

{% highlight c# %}

namespace TreeGridComponent.Data {

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
{% endtabs %}

## Frequently used Public Methods


| Method | When to use |
|----------|----------|
| `PrintAsync()` | Generate a printable view from a custom button or toolbar. |
| `RefreshAsync()` | Refresh the TreeGrid after updating data dynamically. |
| `ExpandAllAsync()` | Expand all parent records to display the complete hierarchy. |
| `CollapseAllAsync()` | Collapse all expanded records to simplify the displayed hierarchy. |
| `SelectRowAsync(int rowIndex)` | Highlight a row after search, navigation, or custom business logic. |
| `ClearSelectionAsync()` | Remove row selections after completing an action. |
| `AddRecordAsync()` | Open a new row or dialog to add a record programmatically. |
| `EditCellAsync()` | Start editing a specific cell programmatically. |
| `DeleteRecordAsync()` | Remove a selected record from a custom action. |
| `FilterByColumnAsync()` | Apply filtering dynamically based on interaction. |
| `AutoFitColumnsAsync()` | Automatically resize columns based on their content. |
| `ExportToExcelAsync()` | Export TreeGrid data to an Excel document. |
| `ExportToCsvAsync()` | Export TreeGrid data to a CSV document. |
| `ExportToPdfAsync()` | Export TreeGrid data to a PDF document. |
| `GoToPageAsync()` | Navigate to a specific page programmatically. |
| `GetSelectedRecordsAsync()` | Retrieve currently selected records. |
| `GetCurrentViewRecords()` | Retrieve records displayed in the current view. |
| `GetPersistDataAsync()` | Save the current TreeGrid state for later restoration. |


## See Also

- For more detailed information about the available TreeGrid public methods and properties, refer to the [TreeGrid API Reference](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html) documentation.
