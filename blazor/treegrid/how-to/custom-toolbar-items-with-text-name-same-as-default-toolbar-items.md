---
layout: post
title: Custom toolbar items in Blazor TreeGrid
description: Learn how to configure custom toolbar items with identical text to default buttons in Syncfusion Blazor TreeGrid and more.
platform: Blazor
control: TreeGrid
documentation: ug
---

# Custom toolbar items in Blazor TreeGrid Component

Custom toolbar items can be created using text labels identical to default toolbar items such as **Add**, **Edit**, or **Delete**. However, when these items are defined without an explicit `Id`, they are treated as default toolbar items, which may lead to unintended behavior—such as being disabled when certain settings are not configured.

To prevent this issue, it is recommended to define the **Id** property for each custom toolbar item. This ensures that the Tree Grid treats them as distinct from the default toolbar actions.

The following example demonstrates how to define custom toolbar items with the same text as default buttons, and how to handle their click events appropriately.

{% tabs %}

{% highlight razor %}

@using TreeGridComponent.Data;
@using Syncfusion.Blazor.Grids;
@using Syncfusion.Blazor.TreeGrid;
@{
    List<Syncfusion.Blazor.Navigations.ItemModel> Toolbaritems = new List<Syncfusion.Blazor.Navigations.ItemModel>();
    Toolbaritems.Add(new Syncfusion.Blazor.Navigations.ItemModel() { Text = "Add", Id = "add", TooltipText = "Add Record", PrefixIcon = "add" });
    Toolbaritems.Add(new Syncfusion.Blazor.Navigations.ItemModel() { Text = "Delete", Id = "delete", TooltipText = "Delete Record", PrefixIcon = "delete" });
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

@code{
    SfTreeGrid<TreeData> TreeGrid;

    public List<TreeData> TreeGridData { get; set; }
    protected override void OnInitialized()
    {
        this.TreeGridData = TreeData.GetSelfDataSource().ToList();
    }
    public void ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
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

namespace TreeGridComponent.Data {

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
}

{% endhighlight %}

{% endtabs %}

![Custom Toolbar Items in Blazor TreeGrid](../images/blazor-treegrid-custom-toolbar-item.PNG)
