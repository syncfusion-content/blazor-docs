---
layout: post
title: How to Display Custom Tool Tip In Treegrid Cell in Blazor Tree Grid Component | Syncfusion
description: Checkout and learn about Display Custom Tool Tip In Treegrid Cell in Blazor Tree Grid component of Syncfusion, and more details.
platform: Blazor
control: Tree Grid
documentation: ug
---

# Display Custom Tooltip in Tree Grid cell

You can display custom tooltip in Tree Grid column using [`Column Template`](https://blazor.syncfusion.com/documentation/treegrid/columns/#column-template) feature by rendering the [`SfTooltip`](https://blazor.syncfusion.com/documentation/tooltip/getting-started/) components inside the template.

This is demonstrated in the below sample code we have render the tooltip for **TaskName** column using [`Column Template`](https://blazor.syncfusion.com/documentation/treegrid/columns/#column-template).

```csharp

@using TreeGridComponent.Data;
@using  Syncfusion.Blazor.Grids;
@using  Syncfusion.Blazor.TreeGrid;
@using Syncfusion.Blazor.Popups;

<SfTreeGrid @ref="TreeGrid" DataSource="@TreeGridData" IdMapping="TaskId" ParentIdMapping="ParentId" TreeColumnIndex="1"
            AllowPaging="true" >
    <TreeGridColumns>
        <TreeGridColumn Field="TaskId" HeaderText="Task ID" IsPrimaryKey="true" Width="80" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="TaskName" HeaderText="Task Name" Width="160">
            <Template>
                @{
                    var taskData = (context as TreeData);
                    <SfTooltip Target="#txt">
                        <TooltipTemplates>
                            <Content>
                                @taskData.TaskName
                            </Content>
                        </TooltipTemplates>
                        <span id="txt">@taskData.TaskName</span>
                    </SfTooltip>
                }
            </Template>
        </TreeGridColumn>
        <TreeGridColumn Field="Priority" HeaderText="Priority" Width="80" >
        </TreeGridColumn>
        <TreeGridColumn Field="Duration" HeaderText="Duration" Width="100" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right">
        </TreeGridColumn>
        <TreeGridColumn Field="Progress" HeaderText="Progress" Width="100" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
    </TreeGridColumns>
</SfTreeGrid>
@code{
    SfTreeGrid<TreeData> TreeGrid;

    public List<TreeData> TreeGridData { get; set; }


    protected override void OnInitialized()
    {
        this.TreeGridData = TreeData.GetSelfDataSource().ToList();
    }
}

```

Output be like the below.
![`Final output`](../images/custom-tooltip.PNG)