---
layout: post
title: Access public methods in Blazor TreeGrid Component | Syncfusion®
description: Learn how to access and invoke Syncfusion Blazor TreeGrid public methods for programmatic data, editing, selection, and export operations.
platform: Blazor
control: Tree Grid
documentation: ug
---

# Access public methods in Blazor TreeGrid Component

In many applications, TreeGrid actions need to be triggered from outside the TreeGrid user interface. For example, you may want to:

- Print TreeGrid data from a custom button.
- Refresh the TreeGrid after updating data from an API.
- Expand or collapse records from a toolbar action.
- Select a row programmatically after a search operation.
- Open an edit dialog based on custom business logic.

To support these scenarios, the Blazor TreeGrid provides public methods that can be accessed through a component reference.

## When to use public methods

Use TreeGrid public methods when an operation needs to be performed programmatically instead of through the built-in TreeGrid user interface.

### Common scenarios

TreeGrid public methods are commonly used when you need to:

- Trigger TreeGrid actions from custom buttons, toolbars, or menus.
- Refresh the TreeGrid after updating data from an API or database.
- Select, edit, or expand records based on actions performed in another component.
- Synchronize TreeGrid behavior with dialogs, forms, dashboards, or custom workflows.
- Perform TreeGrid operations programmatically instead of relying on built-in user interactions.

## Access the TreeGrid instance

Before invoking a TreeGrid public method, you must obtain a reference to the TreeGrid component instance. The component instance provides access to TreeGrid properties and methods and can be accessed using the `@ref` directive.

```razor
<SfTreeGrid @ref="TreeGrid"></SfTreeGrid>
```

```csharp
private SfTreeGrid<TreeData> TreeGrid;
```

The component reference becomes available after the TreeGrid has been rendered.

> IMPORTANT
>
> The component reference is available only after the TreeGrid has been rendered. If you need to access the TreeGrid instance during component initialization, use lifecycle methods such as `OnAfterRenderAsync`.

## Example: Print TreeGrid data using a custom button

The following example demonstrates how to invoke the `PrintAsync` method from an external button.

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
{% endtabs %}

## Frequently used public methods

The following methods are commonly used when interacting with the TreeGrid programmatically.

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
| `FilterByColumnAsync()` | Apply filtering dynamically based on user interaction. |
| `AutoFitColumnsAsync()` | Automatically resize columns based on their content. |
| `ExportToExcelAsync()` | Export TreeGrid data to an Excel document. |
| `ExportToCsvAsync()` | Export TreeGrid data to a CSV document. |
| `ExportToPdfAsync()` | Export TreeGrid data to a PDF document. |
| `GoToPageAsync()` | Navigate to a specific page programmatically. |
| `GetSelectedRecordsAsync()` | Retrieve currently selected records. |
| `GetCurrentViewRecords()` | Retrieve records displayed in the current view. |
| `GetPersistDataAsync()` | Save the current TreeGrid state for later restoration. |

For a complete list of available methods and overloads, refer to the API reference documentation.

## Best practices

- Use public methods when TreeGrid operations must be triggered programmatically.
- Store the component reference in a field using the `@ref` directive.
- Verify that the component reference is not `null` before invoking a method.
- Trigger methods from user actions such as button clicks, toolbar items, or menu commands.
- Access the TreeGrid instance only after component rendering is completed.
- Await asynchronous TreeGrid methods to ensure operations complete successfully.
- Refer to the API documentation for advanced methods and additional overloads.

## See also

For detailed information about the available TreeGrid APIs, refer to the following API reference documentation:
- [SfTreeGrid Methods](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#methods)
- [SfTreeGrid Properties](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#properties)
- [TreeGrid API Reference](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html)
