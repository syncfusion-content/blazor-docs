---
layout: post
title: Column Reorder in Blazor TreeGrid Component | Syncfusion
description: Learn how to reorder columns in the Syncfusion Blazor TreeGrid using methods and events for interactive and programmatic reordering.
platform: Blazor
control: TreeGrid
documentation: ug
---

# Column Reorder in Blazor TreeGrid

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor TreeGrid allows columns to be reordered by dragging and dropping a column header from one position to another within the TreeGrid.

To enable column reordering, set the [AllowReordering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_AllowReordering) property of the [TreeGrid](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html) component to **true**.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.TreeGrid
@using TreeGridComponent.Data

<SfTreeGrid IdMapping="TaskId" ParentIdMapping="ParentId" AllowReordering="true" DataSource="@TreeGridData" TreeColumnIndex="1">
    <TreeGridColumns>
        <TreeGridColumn Field="TaskId" HeaderText="Task ID" Width="90" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="TaskName" HeaderText="Task Name" Width="180"></TreeGridColumn>
        <TreeGridColumn Field="Duration" HeaderText="Duration" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="100"></TreeGridColumn>
        <TreeGridColumn Field="Progress" HeaderText="Progress" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="100"></TreeGridColumn>
    </TreeGridColumns>
</SfTreeGrid>

@code {
    public List<TreeData.BusinessObject> TreeGridData { get; set; }

    protected override void OnInitialized()
    {
        TreeGridData = TreeData.GetSelfDataSource().ToList();
    }
}
{% endhighlight %}
{% highlight c# tabtitle="TreeData.cs" %}
namespace TreeGridComponent.Data
{
    public class TreeData
    {
        public class BusinessObject
        {
            public int TaskId { get; set; }
            public string TaskName { get; set; }
            public int? Duration { get; set; }
            public int? Progress { get; set; }
            public int? ParentId { get; set; }
        }

        public static List<BusinessObject> GetSelfDataSource()
        {
            List<BusinessObject> BusinessObjectCollection = new List<BusinessObject>
            {
                new BusinessObject() { TaskId = 1, TaskName = "Parent Task 1", Duration = 10, Progress = 70, ParentId = null },
                new BusinessObject() { TaskId = 2, TaskName = "Child task 1", Duration = 4, Progress = 80, ParentId = 1 },
                new BusinessObject() { TaskId = 3, TaskName = "Child Task 2", Duration = 5, Progress = 65, ParentId = 2 },
                new BusinessObject() { TaskId = 4, TaskName = "Child task 3", Duration = 6, Progress = 77, ParentId = 3 },
                new BusinessObject() { TaskId = 5, TaskName = "Parent Task 2", Duration = 10, Progress = 70, ParentId = null },
                new BusinessObject() { TaskId = 6, TaskName = "Child task 1", Duration = 4, Progress = 80, ParentId = 5 },
                new BusinessObject() { TaskId = 7, TaskName = "Child Task 2", Duration = 5, Progress = 65, ParentId = 5 },
                new BusinessObject() { TaskId = 8, TaskName = "Child task 3", Duration = 6, Progress = 77, ParentId = 5 },
                new BusinessObject() { TaskId = 9, TaskName = "Child task 4", Duration = 6, Progress = 77, ParentId = 5 }
            };

            return BusinessObjectCollection;
        }
    }
}
{% endhighlight %}
{% endtabs %}

![Reordering Columns in Blazor TreeGrid](../images/blazor-treegrid-column-reorder.gif)

> * To disable reordering for a specific column, set the [AllowReordering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridColumn.html#Syncfusion_Blazor_TreeGrid_TreeGridColumn_AllowReordering) property of the [TreeGridColumn](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridColumn.html) to **false**.
> * When columns are reordered, the position of the corresponding column data also changes. Ensure that any logic dependent on column order is updated accordingly.

## Prevent reordering for particular column

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor TreeGrid allows all columns to be reordered by dragging and dropping their headers. However, certain columns are intended to remain fixed in position.

To disable reordering for a specific column, set the [AllowReordering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridColumn.html#Syncfusion_Blazor_TreeGrid_TreeGridColumn_AllowReordering) property of that [TreeGridColumn](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridColumn.html) to **false**.

In this configuration, reordering is disabled for the **TaskName** column.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.TreeGrid
@using TreeGridComponent.Data

<SfTreeGrid IdMapping="TaskId" ParentIdMapping="ParentId" AllowReordering="true" DataSource="@TreeGridData" TreeColumnIndex="1">
    <TreeGridColumns>
        <TreeGridColumn Field="TaskId" HeaderText="Task ID" Width="90" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="TaskName" HeaderText="Task Name" AllowReordering="false" Width="180"></TreeGridColumn>
        <TreeGridColumn Field="Duration" HeaderText="Duration" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="100"></TreeGridColumn>
        <TreeGridColumn Field="Progress" HeaderText="Progress" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="100"></TreeGridColumn>
    </TreeGridColumns>
</SfTreeGrid>

@code {
    public List<TreeData.BusinessObject> TreeGridData { get; set; }

    protected override void OnInitialized()
    {
        TreeGridData = TreeData.GetSelfDataSource().ToList();
    }
}
{% endhighlight %}
{% highlight c# tabtitle="TreeData.cs" %}
namespace TreeGridComponent.Data
{
    public class TreeData
    {
        public class BusinessObject
        {
            public int TaskId { get; set; }
            public string TaskName { get; set; }
            public int? Duration { get; set; }
            public int? Progress { get; set; }
            public int? ParentId { get; set; }
        }

        public static List<BusinessObject> GetSelfDataSource()
        {
            List<BusinessObject> BusinessObjectCollection = new List<BusinessObject>
            {
                new BusinessObject() { TaskId = 1, TaskName = "Parent Task 1", Duration = 10, Progress = 70, ParentId = null },
                new BusinessObject() { TaskId = 2, TaskName = "Child task 1", Duration = 4, Progress = 80, ParentId = 1 },
                new BusinessObject() { TaskId = 3, TaskName = "Child Task 2", Duration = 5, Progress = 65, ParentId = 2 },
                new BusinessObject() { TaskId = 4, TaskName = "Child task 3", Duration = 6, Progress = 77, ParentId = 3 },
                new BusinessObject() { TaskId = 5, TaskName = "Parent Task 2", Duration = 10, Progress = 70, ParentId = null },
                new BusinessObject() { TaskId = 6, TaskName = "Child task 1", Duration = 4, Progress = 80, ParentId = 5 },
                new BusinessObject() { TaskId = 7, TaskName = "Child Task 2", Duration = 5, Progress = 65, ParentId = 5 },
                new BusinessObject() { TaskId = 8, TaskName = "Child task 3", Duration = 6, Progress = 77, ParentId = 5 },
                new BusinessObject() { TaskId = 9, TaskName = "Child task 4", Duration = 6, Progress = 77, ParentId = 5 }
            };

            return BusinessObjectCollection;
        }
    }
}
{% endhighlight %}
{% endtabs %}

## Reorder columns via programmatically

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor TreeGrid allows columns to be reordered programmatically using the [ReorderColumnsAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_ReorderColumnsAsync_System_Collections_Generic_List_System_String__System_String_) method.

> To reorder columns externally, set the [AllowReordering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_AllowReordering) property of the TreeGrid component to **true**.

### Reorder column by field names

Columns can be reordered programmatically by specifying the field names of the columns to move and the target field name.

| Parameter | Type | Description |
|---|---|---|
| fromFieldNames | List&lt;string&gt; | Field names of the columns to be moved. |
| toFieldName | string | Field name of the column before which the group should be placed. |

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.TreeGrid
@using Syncfusion.Blazor.Buttons
@using TreeGridComponent.Data

<SfButton OnClick="ReorderSingleColumn" CssClass="e-outline" Content="REORDER SINGLE COLUMN"></SfButton>
<SfButton OnClick="ReorderMultipleColumn" CssClass="e-outline" Content="REORDER MULTIPLE COLUMN"></SfButton>

<SfTreeGrid @ref="TreeGrid" DataSource="@TreeGridData" IdMapping="TaskId" ParentIdMapping="ParentId" TreeColumnIndex="1" AllowReordering="true">
    <TreeGridColumns>
        <TreeGridColumn Field="TaskId" HeaderText="Task ID" Width="90" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="TaskName" HeaderText="Task Name" Width="180"></TreeGridColumn>
        <TreeGridColumn Field="Duration" HeaderText="Duration" Width="100" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="Progress" HeaderText="Progress" Width="100" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
    </TreeGridColumns>
</SfTreeGrid>

@code {
    private SfTreeGrid<TreeData.BusinessObject> TreeGrid;
    public List<TreeData.BusinessObject> TreeGridData { get; set; }

    protected override void OnInitialized()
    {
        TreeGridData = TreeData.GetSelfDataSource().ToList();
    }

    public async Task ReorderSingleColumn()
    {
        await TreeGrid.ReorderColumnsAsync(new List<string> { "TaskName" }, "TaskId");
    }

    public async Task ReorderMultipleColumn()
    {
        await TreeGrid.ReorderColumnsAsync(new List<string> { "TaskName", "Duration" }, "TaskId");
    }
}
{% endhighlight %}
{% highlight c# tabtitle="TreeData.cs" %}
namespace TreeGridComponent.Data
{
    public class TreeData
    {
        public class BusinessObject
        {
            public int TaskId { get; set; }
            public string TaskName { get; set; }
            public int? Duration { get; set; }
            public int? Progress { get; set; }
            public int? ParentId { get; set; }
        }

        public static List<BusinessObject> GetSelfDataSource()
        {
            List<BusinessObject> BusinessObjectCollection = new List<BusinessObject>
            {
                new BusinessObject() { TaskId = 1, TaskName = "Parent Task 1", Duration = 10, Progress = 70, ParentId = null },
                new BusinessObject() { TaskId = 2, TaskName = "Child task 1", Duration = 4, Progress = 80, ParentId = 1 },
                new BusinessObject() { TaskId = 3, TaskName = "Child Task 2", Duration = 5, Progress = 65, ParentId = 2 },
                new BusinessObject() { TaskId = 4, TaskName = "Child task 3", Duration = 6, Progress = 77, ParentId = 3 },
                new BusinessObject() { TaskId = 5, TaskName = "Parent Task 2", Duration = 10, Progress = 70, ParentId = null },
                new BusinessObject() { TaskId = 6, TaskName = "Child task 1", Duration = 4, Progress = 80, ParentId = 5 },
                new BusinessObject() { TaskId = 7, TaskName = "Child Task 2", Duration = 5, Progress = 65, ParentId = 5 },
                new BusinessObject() { TaskId = 8, TaskName = "Child task 3", Duration = 6, Progress = 77, ParentId = 5 },
                new BusinessObject() { TaskId = 9, TaskName = "Child task 4", Duration = 6, Progress = 77, ParentId = 5 }
            };

            return BusinessObjectCollection;
        }
    }
}
{% endhighlight %}
{% endtabs %}

## Reorder events

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor TreeGrid provides events to handle column reordering interactions.

1. [ColumnReordering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridEvents-1.html#Syncfusion_Blazor_TreeGrid_TreeGridEvents_1_ColumnReordering): Triggered while a column header is being dragged.
2. [ColumnReordered](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridEvents-1.html#Syncfusion_Blazor_TreeGrid_TreeGridEvents_1_ColumnReordered): Triggered when a column header is dropped on the target column.

### ColumnReordering

The `ColumnReordering` event is triggered while a column header is being dragged during a reordering operation.

**Event Arguments**

The event uses the [ColumnReorderingEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ColumnReorderingEventArgs.html) class, which includes the following properties:

| Event Argument | Type | Description |
|---|---|---|
| ReorderingColumns | List&lt;GridColumn&gt; | Represents the columns being dragged. |
| Cancel | bool | Set to **true** to cancel the reordering operation. |

### ColumnReordered

The `ColumnReordered` event is triggered after a column header is dropped on the target column during a reordering operation.

**Event Arguments**

The event uses the [ColumnReorderedEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ColumnReorderedEventArgs.html) class, which includes the following properties:

| Event Argument | Type | Description |
|---|---|---|
| ReorderingColumns | List&lt;GridColumn&gt; | Represents the columns that were reordered. |
| ToColumn | GridColumn | Destination column where the reordered columns are placed. |

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.TreeGrid
@using Syncfusion.Blazor.Grids
@using TreeGridComponent.Data

<div style="text-align: center; color: red">
    <span>@ReorderMessage</span>
</div>

<SfTreeGrid @ref="TreeGrid" DataSource="@TreeGridData" IdMapping="TaskId" ParentIdMapping="ParentId" TreeColumnIndex="1" AllowReordering="true">
    <TreeGridEvents TValue="TreeData.BusinessObject" ColumnReordered="ColumnReordered" ColumnReordering="ColumnReordering"></TreeGridEvents>
    <TreeGridColumns>
        <TreeGridColumn Field="TaskId" HeaderText="Task ID" Width="90" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="TaskName" HeaderText="Task Name" Width="180"></TreeGridColumn>
        <TreeGridColumn Field="Duration" HeaderText="Duration" Width="100" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="Progress" HeaderText="Progress" Width="100" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
    </TreeGridColumns>
</SfTreeGrid>

@code {
    public SfTreeGrid<TreeData.BusinessObject> TreeGrid { get; set; }
    public string ReorderMessage;
    public List<TreeData.BusinessObject> TreeGridData { get; set; }

    protected override void OnInitialized()
    {
        TreeGridData = TreeData.GetSelfDataSource().ToList();
    }

    public void ColumnReordering(ColumnReorderingEventArgs args)
    {
        if (args.ReorderingColumns[0].Field == "TaskId")
        {
            args.Cancel = true;
            ReorderMessage = "ColumnReordering event is triggered. Column Reordering cancelled for " + args.ReorderingColumns[0].HeaderText + " column ";
        }
    }

    public void ColumnReordered(ColumnReorderedEventArgs args)
    {
        ReorderMessage = "ColumnReordered event triggered. " + args.ReorderingColumns[0].HeaderText + " column is dragged to index " + args.ReorderingColumns[0].Index;
    }
}
{% endhighlight %}
{% highlight c# tabtitle="TreeData.cs" %}
namespace TreeGridComponent.Data
{
    public class TreeData
    {
        public class BusinessObject
        {
            public int TaskId { get; set; }
            public string TaskName { get; set; }
            public int? Duration { get; set; }
            public int? Progress { get; set; }
            public int? ParentId { get; set; }
        }

        public static List<BusinessObject> GetSelfDataSource()
        {
            List<BusinessObject> BusinessObjectCollection = new List<BusinessObject>
            {
                new BusinessObject() { TaskId = 1, TaskName = "Parent Task 1", Duration = 10, Progress = 70, ParentId = null },
                new BusinessObject() { TaskId = 2, TaskName = "Child task 1", Duration = 4, Progress = 80, ParentId = 1 },
                new BusinessObject() { TaskId = 3, TaskName = "Child Task 2", Duration = 5, Progress = 65, ParentId = 2 },
                new BusinessObject() { TaskId = 4, TaskName = "Child task 3", Duration = 6, Progress = 77, ParentId = 3 },
                new BusinessObject() { TaskId = 5, TaskName = "Parent Task 2", Duration = 10, Progress = 70, ParentId = null },
                new BusinessObject() { TaskId = 6, TaskName = "Child task 1", Duration = 4, Progress = 80, ParentId = 5 },
                new BusinessObject() { TaskId = 7, TaskName = "Child Task 2", Duration = 5, Progress = 65, ParentId = 5 },
                new BusinessObject() { TaskId = 8, TaskName = "Child task 3", Duration = 6, Progress = 77, ParentId = 5 },
                new BusinessObject() { TaskId = 9, TaskName = "Child task 4", Duration = 6, Progress = 77, ParentId = 5 }
            };

            return BusinessObjectCollection;
        }
    }
}
{% endhighlight %}
{% endtabs %}
