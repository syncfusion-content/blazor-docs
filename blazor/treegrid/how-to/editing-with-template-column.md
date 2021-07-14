---
layout: post
title: How to Editing With Template Column in Blazor Tree Grid Component | Syncfusion
description: Checkout and learn about Editing With Template Column in Blazor Tree Grid component of Syncfusion, and more details.
platform: Blazor
control: Tree Grid
documentation: ug
---

# Editing with template column

You can edit a template column value by defining the [`Field`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridColumn.html#Syncfusion_Blazor_TreeGrid_TreeGridColumn_Field) property for that particular [`TreeGridColumn`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridColumn.html) component

In the below demo, the **TaskName** column is rendered with the template.

```csharp

@using TreeGridComponent.Data;
@using  Syncfusion.Blazor.Grids;
@using  Syncfusion.Blazor.TreeGrid;

<SfTreeGrid DataSource="@TreeGridData" IdMapping="TaskId" ParentIdMapping="ParentId" AllowPaging="true"
                TreeColumnIndex="1" Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Cancel", "Update" })">
        <TreeGridEditSettings AllowEditing="true" AllowAdding="true" AllowDeleting="true" Mode="Syncfusion.Blazor.TreeGrid.EditMode.Row" />
        <TreeGridColumns>
            <TreeGridColumn Field="TaskId" HeaderText="Task ID" IsPrimaryKey="true" Width="70" TextAlign="TextAlign.Right"></TreeGridColumn>
            <TreeGridColumn Field="TaskName" HeaderText="Task Name" Width="75">
                <Template>
                    @{
                        var data = context as TreeData;
                        <a href="#">@data.TaskName</a>
                    }
                </Template>
            </TreeGridColumn>
            <TreeGridColumn Field="Priority" HeaderText="Priority" Width="60"></TreeGridColumn>
            <TreeGridColumn Field="Duration" HeaderText="Duration" Width="70" Format="C2" TextAlign="TextAlign.Right"></TreeGridColumn>
            <TreeGridColumn Field="Resources" HeaderText="Resource" Width="70" Format="C2" TextAlign="TextAlign.Right"></TreeGridColumn>
            <TreeGridColumn Field="Progress" HeaderText="Progress" Width="70" Format="C2" TextAlign="TextAlign.Right"></TreeGridColumn>

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
![`Final output`](../images/template-edit.PNG)