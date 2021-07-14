---
layout: post
title: How to Treegrid Customization in Blazor Tree Grid Component | Syncfusion
description: Checkout and learn about Treegrid Customization in Blazor Tree Grid component of Syncfusion, and more details.
platform: Blazor
control: Tree Grid
documentation: ug
---

# Tree Grid customization

It is possible to customize the default styles of the Tree Grid component. This can be achieved by adding class dynamically to the columns using the `AddClass` method of the [`QueryCellInfo`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridEvents-1.html#Syncfusion_Blazor_TreeGrid_TreeGridEvents_1_QueryCellInfo) event. Then the required styles are added to this class.

This is demonstrated in the below sample code,

```csharp

@using TreeGridComponent.Data;
@using  Syncfusion.Blazor.Grids;
@using  Syncfusion.Blazor.TreeGrid;

<SfTreeGrid @ref="TreeGrid" DataSource="@TreeGridData" IdMapping="TaskId" ParentIdMapping="ParentId" TreeColumnIndex="1"
            AllowPaging="true">
    <TreeGridEvents QueryCellInfo="QueryCellInfoHandler" TValue="TreeData"></TreeGridEvents>
    <TreeGridPageSettings PageSize="8"></TreeGridPageSettings>
    <TreeGridColumns>
        <TreeGridColumn Field="TaskId" HeaderText="Task ID" IsPrimaryKey="true" Width="80" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="TaskName" HeaderText="Task Name" Width="160">
        </TreeGridColumn>
        <TreeGridColumn Field="Priority" HeaderText="Priority" Width="80">
        </TreeGridColumn>
        <TreeGridColumn Field="Duration" HeaderText="Duration" Width="100" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right">
        </TreeGridColumn>
        <TreeGridColumn Field="Progress" HeaderText="Progress" Width="100" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
    </TreeGridColumns>
</SfTreeGrid>

<style>
    .e-treegrid .e-gridcontent .e-rowcell.above-10 {
        color: green;
    }

    .e-treegrid .e-gridcontent .e-rowcell.above-5 {
        color: blue;
    }

    .e-treegrid .e-gridcontent .e-rowcell.below-5 {
        color: red;
    }
</style>
@code{
    SfTreeGrid<TreeData> TreeGrid;

    public List<TreeData> TreeGridData { get; set; }


    protected override void OnInitialized()
    {
        this.TreeGridData = TreeData.GetSelfDataSource().ToList();
    }
    public void QueryCellInfoHandler(QueryCellInfoEventArgs<TreeData> args)
    {
        if (args.Data.Duration > 10)
        {
            args.Cell.AddClass(new string[] { "above-10" });
        }
        else if (args.Data.Duration > 5 && args.Data.Duration <= 10)
        {
            args.Cell.AddClass(new string[] { "above-5" });
        }
        else
        {
            args.Cell.AddClass(new string[] { "below-5" });
        }
    }
}

```

The following image represents customized Tree Grid columns,
![`Tree Grid Customization`](../images/treegrid-customization.png)