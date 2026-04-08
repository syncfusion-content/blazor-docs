---
layout: post
title: Custom toolbar items in Blazor TreeGrid Component | Syncfusion
description: Learn here all about custom toolbar items with text name same as default toolbar items in Syncfusion Blazor TreeGrid component and more.
platform: Blazor
control: Tree Grid
documentation: ug
---

# Custom toolbar items in Blazor TreeGrid Component

The Custom toolbar items can be created with text name same as default toolbar items (e.g., 'Add', 'Delete'). But while creating them, they will be considered as default toolbar items which will cause issues while clicking on it. Resolve this behavior by defining **Id** property for custom toolbar items.

Custom toolbar items with text same as **Add** and **Delete** buttons will be enabled only when [TreeGridEditSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridEditSettings.html) defined in TreeGrid. So custom toolbar will be in disabled state considering it as default toolbar item. That behavior must be overcame by defining the Id property.

{% tabs %}

{% highlight razor %}

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.TreeGrid
@using Syncfusion.Blazor.Navigations

@{
    List<ItemModel> Toolbaritems = new List<ItemModel>();
    Toolbaritems.Add(new ItemModel() { Text = "Add", Id = "add", TooltipText = "Add Record", PrefixIcon = "add" });
    Toolbaritems.Add(new ItemModel() { Text = "Delete", Id = "delete", TooltipText = "Delete Record", PrefixIcon = "delete" });
}
<SfTreeGrid DataSource="@TreeGridData" IdMapping="TaskId" ParentIdMapping="ParentId" AllowPaging="true"
            TreeColumnIndex="1" Toolbar="Toolbaritems">
    <TreeGridEvents OnToolbarClick="ToolbarClickHandler" TValue="TreeData"></TreeGridEvents>
    <TreeGridColumns>
        <TreeGridColumn Field="TaskId" HeaderText="Task ID" IsPrimaryKey="true" Width="70" TextAlign="TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="TaskName" HeaderText="Task Name" Width="85"></TreeGridColumn>
        <TreeGridColumn Field="Duration" HeaderText="Duration" Width="70" TextAlign="TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="Progress" HeaderText="Progress" Width="70" TextAlign="TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="Priority" HeaderText="Priority" Width="70"></TreeGridColumn>
    </TreeGridColumns>
</SfTreeGrid>

@code {
    SfTreeGrid<TreeData> TreeGrid;

    public List<TreeData> TreeGridData { get; set; }
    protected override void OnInitialized()
    {
        this.TreeGridData = TreeData.GetSelfDataSource().ToList();
    }
    public void ToolbarClickHandler(ClickEventArgs args)
    {
        if (args.Item.Text == "Add")
        {
            //perform your actions here
        }
        if (args.Item.Text == "Delete")
        {
            //perform your actions here
        }
    }
}

{% endhighlight %}

{% highlight c# %}

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

{% endhighlight %}

{% endtabs %}

![Custom Toolbar Items in Blazor TreeGrid](../images/blazor-treegrid-custom-toolbar-item.PNG)
