---
layout: post
title: How to Customize Icon Column Menu in Blazor Tree Grid Component | Syncfusion
description: Checkout and learn about Customize Icon Column Menu in Blazor Tree Grid component of Syncfusion, and more details.
platform: Blazor
control: Tree Grid
documentation: ug
---

# Customize column menu icon

You can customize the column menu icon by overriding the default icon class `.e-icons.e-columnmenu` with the `content` property.

```css
.e-grid .e-columnheader .e-icons.e-columnmenu::before {
    content: "\e705";
}
```

This is demonstrated in the below sample code,

```csharp

@using TreeGridComponent.Data;
@using  Syncfusion.Blazor.Grids;
@using  Syncfusion.Blazor.TreeGrid;

<SfTreeGrid height="315" DataSource="@TreeData" IdMapping="TaskId" ParentIdMapping="ParentId" AllowPaging="true" TreeColumnIndex="1" ShowColumnMenu="true" AllowSorting="true">
    <TreeGridColumns>
        <TreeGridColumn Field="TaskId" HeaderText="Task ID" Width="100" TextAlign="TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="TaskName" HeaderText="Task Name" Width="145"></TreeGridColumn>
        <TreeGridColumn Field="StartDate" HeaderText="Start Date" Format="d" Type=ColumnType.Date Width="130" TextAlign="TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="EndDate" HeaderText="End Date" Format="d" Type=ColumnType.Date Width="130" TextAlign="TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="Duration" HeaderText="Duration" Width="120" TextAlign="TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="Priority" HeaderText="Priority" Width="110"></TreeGridColumn>
    </TreeGridColumns>
</SfTreeGrid>

@code{
    SfTreeGrid<WrapData> TreeGrid;

    public List<WrapData> TreeData { get; set; }
    protected override void OnInitialized()
    {
        this.TreeData = WrapData.GetWrapData().ToList();
    }
}

<style>
    .e-grid .e-columnheader .e-icons.e-columnmenu::before {
        content: "\e705";
    }
</style>

```

The following image represents Tree Grid with customized column menu icon
![Customize column menu icon](../images/customize-column-menu-icon.png)