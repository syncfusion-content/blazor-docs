---
layout: post
title: Collapse Records on Initial Render in Blazor TreeGrid | Syncfusion
description: Learn how to collapse records up to a specific level on initial render in the Syncfusion Blazor TreeGrid component using CollapseAtLevelAsync method.
platform: Blazor
control: TreeGrid
documentation: ug
---

# Collapse Records on Initial Render in Blazor TreeGrid Component

The Syncfusion Blazor TreeGrid allows you to collapse tree records up to a specific level when the component is first rendered. This is achieved using the [CollapseAtLevelAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_CollapseAtLevelAsync_System_Int32_) method, which accepts the level number as a parameter.

To implement this:
- Bind the [DataBound](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridEvents-1.html#Syncfusion_Blazor_TreeGrid_TreeGridEvents_1_DataBound) event of the TreeGrid using the [TreeGridEvents](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridEvents-1.html) component.
- In the [DataBound](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridEvents-1.html#Syncfusion_Blazor_TreeGrid_TreeGridEvents_1_DataBound) event handler, invoke the [CollapseAtLevelAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_CollapseAtLevelAsync_System_Int32_) method by passing the desired level (e.g., **1** to collapse the first level of records).

> **Note:** The `CollapseAtLevelAsync` method collapses all rows up to and including the specified level. Passing **1** will collapse all first-level parent rows on initial render.

{% tabs %}

{% highlight razor %}

<SfTreeGrid @ref="TreeGrid" DataSource="@TreeData" Height="312" IdMapping="TaskID" ParentIdMapping="ParentID" TreeColumnIndex="1" AllowFiltering="true" AllowSorting Toolbar="@(new List<string>() { "Add", "Delete", "Update", "Cancel", "Search" })">
    . . . .
    <TreeGridEvents TValue="TaskData" DataBound="DataBoundHandler"></TreeGridEvents>
    . . . .
</SfTreeGrid>

@code {
    SfTreeGrid<TaskData> TreeGrid;
    ...

    public void DataBoundHandler(object args)
    {
        TreeGrid.CollapseAtLevelAsync(1);
        // 1 represents the level
    }
}

{% endhighlight %}

{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rjhHNKKMAofdjnkI?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}
