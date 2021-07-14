---
layout: post
title: How to Select Treegrid Rows Based On Condition in Blazor Tree Grid Component | Syncfusion
description: Checkout and learn about Select Treegrid Rows Based On Condition in Blazor Tree Grid component of Syncfusion, and more details.
platform: Blazor
control: Tree Grid
documentation: ug
---

# Select Tree Grid rows based on certain condition

You can select specific rows in the Tree Grid based on some conditions by using the [`SelectRows`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_SelectRows_System_Double___) method in the [`DataBound`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridEvents-1.html#Syncfusion_Blazor_TreeGrid_TreeGridEvents_1_DataBound) event of the Tree Grid component.

This is demonstrated in the below sample code where the index value of Tree Grid rows with **Duration** column value greater than 6 are stored in the [`RowDataBound`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridEvents-1.html#Syncfusion_Blazor_TreeGrid_TreeGridEvents_1_RowDataBound) event and then selected in the [`DataBound`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridEvents-1.html#Syncfusion_Blazor_TreeGrid_TreeGridEvents_1_DataBound) event,

```csharp

@using TreeGridComponent.Data;
@using  Syncfusion.Blazor.Grids;
@using  Syncfusion.Blazor.TreeGrid;

<SfTreeGrid @ref="TreeGrid" DataSource="@TreeGridData" IdMapping="TaskId" ParentIdMapping="ParentId" TreeColumnIndex="1">
    <TreeGridSelectionSettings Type=SelectionType.Multiple></TreeGridSelectionSettings>
    <TreeGridEvents RowDataBound="OnRowDataBound" DataBound="OnDataBound" TValue="TreeData"></TreeGridEvents>
    <TreeGridPageSettings PageSize="8"></TreeGridPageSettings>
    <TreeGridColumns>
        <TreeGridColumn Field="TaskId" HeaderText="Task ID" Width="70" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="TaskName" HeaderText="Task Name" Width="85"></TreeGridColumn>
        <TreeGridColumn Field="Priority" HeaderText="Priority" Width="60"></TreeGridColumn>
        <TreeGridColumn Field="Duration" HeaderText="Duration" Width="60" TextAlign="TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="Progress" HeaderText="Progress" Width="60" TextAlign="TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="Resources" HeaderText="Resources" Width="70" TextAlign="TextAlign.Right"></TreeGridColumn>
    </TreeGridColumns>
</SfTreeGrid>

@code{
    SfTreeGrid<TreeData> TreeGrid;

    public List<TreeData> TreeGridData { get; set; }

    public List<int> SelectedNodeIndex = new List<int>();

    protected override void OnInitialized()
    {
        this.TreeGridData = TreeData.GetSelfDataSource().ToList();
    }

    public void OnDataBound(object args)
    {
        // The filtered index values are selected
        this.TreeGrid.SelectRows(SelectedNodeIndex);
    }

    public void OnRowDataBound(RowDataBoundEventArgs<TreeData> args)
    {
        // Freight values greater than 10 are filtered by comparing the primary column values
        if (args.Data.Duration > 6)
        {
            var dataSource = this.TreeGrid.DataSource;
            var index = 0;
            foreach (var data in dataSource)
            {
                if (data.TaskId == args.Data.TaskId)
                {
                    SelectedNodeIndex.Add(index);
                    break;
                }
                index++;
            }
        }
    }
}

```

Output be like the below.

![`Final output`](../images/select-row.PNG)