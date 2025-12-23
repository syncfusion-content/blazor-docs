---
layout: post
title: Custom Toolbar Items in Blazor TreeGrid Component | Syncfusion
description: Learn how to create and use custom toolbar items in the Syncfusion Blazor TreeGrid, including templates, icons with text, dropdowns, and export actions.
platform: Blazor
control: TreeGrid
documentation: ug
---

# Custom Toolbar In Blazor TreeGrid

The custom toolbar in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor TreeGrid enables a distinctive toolbar layout, style, and behavior tailored to application requirements, delivering a personalized TreeGrid experience.

The [ToolbarTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridTemplates.html#Syncfusion_Blazor_TreeGrid_TreeGridTemplates_ToolbarTemplate) feature provides option to render custom components

## Enable/Disable toolbar items based on row selection

`ToolbarTemplate` enables rendering of custom components like [SfToolbar](https://blazor.syncfusion.com/documentation/toolbar/getting-started-webapp), which allows dynamic enabling or disabling of its toolbar items using the [Disabled](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.ToolbarItem.html#Syncfusion_Blazor_Navigations_ToolbarItem_Disabled) property.

Setting the `Disabled` property of an `SfToolbar` item inside the [RowSelected](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridEvents-1.html#Syncfusion_Blazor_TreeGrid_TreeGridEvents_1_RowSelected) or [RowDeselected](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridEvents-1.html#Syncfusion_Blazor_TreeGrid_TreeGridEvents_1_RowDeselected) event controls custom toolbar items based on row selection.

In the following sample, the custom toolbar item **Add** becomes enabled when a row is selected and disabled when the row is deselected.


```cshtml
@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.TreeGrid;


<SfTreeGrid @ref="TreeGrid" DataSource="@TreeGridData" IdMapping="TaskId"  ParentIdMapping="ParentId" TreeColumnIndex="1">
    <TreeGridEvents RowSelected="RowSelected" RowDeselected="RowDeselected" TValue="TreeData.BusinessObject"></TreeGridEvents>
    <TreeGridEditSettings AllowAdding="true" NewRowPosition="Syncfusion.Blazor.TreeGrid.RowPosition.Child"></TreeGridEditSettings>
    <TreeGridTemplates>
        <ToolbarTemplate>
            <SfToolbar>
                <ToolbarEvents Clicked = "ToolbarClickHandler"></ToolbarEvents>
                <ToolbarItems>
                    <ToolbarItem Text="Add" Id="Add" TooltipText="Add" Disabled="@IsRowSelected"></ToolbarItem>
                    <ToolbarItem Text="Save" Id="Save" TooltipText="Save Data" Disabled="@EnableSave"></ToolbarItem>
                    </ToolbarItems>
            </SfToolbar>
        </ToolbarTemplate>
    </TreeGridTemplates>
    <TreeGridColumns>
        <TreeGridColumn Field="TaskId" HeaderText="Task ID" Width="80" IsPrimaryKey="true" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="TaskName" HeaderText="Task Name" Width="160"></TreeGridColumn>
        <TreeGridColumn Field="Duration" HeaderText="Duration" Width="100" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
    </TreeGridColumns>
</SfTreeGrid>

@code {
    public List<TreeData.BusinessObject> TreeGridData { get; set; }
    SfTreeGrid<TreeData.BusinessObject> TreeGrid;
    public bool IsRowSelected { get; set; } = true;
    public bool EnableSave { get; set; } = true;

    protected override void OnInitialized()
    {
        this.TreeGridData = TreeData.GetSelfDataSource().ToList();
    }

    public void ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
        if (args.Item.Text == "Add")
        {
            this.TreeGrid.AddRecordAsync();
            EnableSave = false;
        }
        if (args.Item.Text == "Save")
        {
            this.TreeGrid.EndEditAsync();
            EnableSave = true;
        }
    }

    public void RowSelected(Syncfusion.Blazor.Grids.RowSelectEventArgs<TreeData.BusinessObject> args)
    {
        IsRowSelected = false;
    }
    public void RowDeselected(Syncfusion.Blazor.Grids.RowDeselectEventArgs<TreeData.BusinessObject> args)
    {
        IsRowSelected = true;
    }

    public class TreeData
    {
        public class BusinessObject
        {
            public int TaskId { get; set; }
            public string TaskName { get; set; }
            public int? Duration { get; set; }
            public int? Progress { get; set; }
            public string Priority { get; set; }
            public int? ParentId { get; set; }
            public int? AgendaTopicTypeId { get; set; }
            
        }

        public static List<BusinessObject> GetSelfDataSource()
        {
            List<BusinessObject> BusinessObjectCollection = new List<BusinessObject>();
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 1, TaskName = "Parent Task 1", Duration = 10, Progress = 70, Priority = "Critical", ParentId = null });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 2, TaskName = "Child task 1", Progress = 80, Priority = "Low", ParentId = 1 });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 3, TaskName = "Child Task 2", Duration = 5, Progress = 65, Priority = "Critical", ParentId = 2 });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 4, TaskName = "Child task 3", Duration = 6, Priority = "High", Progress = 77, ParentId = 3 });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 5, TaskName = "Parent Task 2", Duration = 10, Progress = 70, Priority = "Critical", ParentId = null });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 6, TaskName = "Child task 1", Duration = 4, Progress = 80, Priority = "Critical", ParentId = 5 });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 7, TaskName = "Child Task 2", Duration = 5, Progress = 65, Priority = "Low", ParentId = 5 });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 8, TaskName = "Child task 3", Duration = 6, Progress = 77, Priority = "High", ParentId = 5 });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 9, TaskName = "Child task 4", Duration = 6, Progress = 77, Priority = "Low", ParentId = 5 });
            return BusinessObjectCollection;
        }
    }
}
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/VjreWhBUfzxLZRkQ?appbar=true&editor=true&result=true&errorlist=true&theme=bootstrap5" %}