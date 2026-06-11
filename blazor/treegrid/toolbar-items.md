---
layout: post
title: Toolbar Items in Blazor TreeGrid Component | Syncfusion
description: Learn how to use built-in and custom toolbar items in Syncfusion Blazor TreeGrid, including icons, alignment, tooltips, and handling toolbar actions.
platform: Blazor
control: TreeGrid
documentation: ug
---

# Toolbar items in Blazor TreeGrid

The [Blazor TreeGrid](https://www.syncfusion.com/blazor-components/blazor-tree-grid) offers a flexible toolbar that enables the addition of custom toolbar items or modification of existing ones. The toolbar appears above the TreeGrid, providing convenient access to common actions and custom functionality.

## Built-in Toolbar item

Built-in toolbar items in the Blazor TreeGrid use predefined actions to perform standard operations.

Add them by defining the [Toolbar](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_Toolbar) property as a collection of built-in item names (strings). Each item is rendered as a button with an icon and text. The following table lists the built-in toolbar items and their actions:

| Built-in Toolbar Items | Actions |
|------------------------|---------|
| Add | Adds a new row to the TreeGrid. |
| Edit | Puts the selected row into edit mode. |
| Update | Saves changes made during edit mode. |
| Delete | Deletes the selected record. |
| Cancel | Discards changes made during edit mode. |
| Search | Displays a search box to filter the records. |
| Print | Prints the TreeGrid content. |
| PdfExport | Exports TreeGrid data to a PDF file. |
| ExcelExport | Exports TreeGrid data to an Excel file. |
| CsvExport | Exports TreeGrid data to a CSV file. |
| ExpandAll | Expands all rows in the TreeGrid. |
| CollapseAll | Collapses all rows in the TreeGrid. |

N> Built-in item IDs are typically prefixed with the tree grid ID (for example, TreeGrid_add). Use these IDs in event handlers for robust detection.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.TreeGrid

<SfTreeGrid DataSource="@TreeGridData" @ref="TreeGrid" IdMapping="TaskId" ParentIdMapping="ParentId" TreeColumnIndex="1" Toolbar="@ToolbarItems">
    <TreeGridColumns>
        <TreeGridColumn Field="TaskId" HeaderText="Task ID" IsPrimaryKey="true" Width="80" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="TaskName" HeaderText="Task Name" Width="160"></TreeGridColumn>
        <TreeGridColumn Field="Duration" HeaderText="Duration" Width="100" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="Progress" HeaderText="Progress" Width="100" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="Priority" HeaderText="Priority" Width="80"></TreeGridColumn>
    </TreeGridColumns>
</SfTreeGrid>

@code {
    private SfTreeGrid<TreeData.BusinessObject> TreeGrid;
    public string[] ToolbarItems = new string[] { "Search", "Print" };
    public List<TreeData.BusinessObject> TreeGridData { get; set; }

    protected override void OnInitialized()
    {
        TreeGridData = TreeData.GetSelfDataSource();
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
        }

        public static List<BusinessObject> GetSelfDataSource()
        {
            List<BusinessObject> BusinessObjectCollection = new List<BusinessObject>();
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 1, TaskName = "Parent Task 1", Duration = 10, Progress = 70, Priority = "Critical", ParentId = null });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 2, TaskName = "Child Task 1", Duration = 4, Progress = 80, Priority = "Low", ParentId = 1 });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 3, TaskName = "Child Task 2", Duration = 5, Progress = 65, Priority = "Critical", ParentId = 2 });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 4, TaskName = "Child Task 3", Duration = 6, Progress = 77, Priority = "High", ParentId = 3 });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 5, TaskName = "Parent Task 2", Duration = 10, Progress = 70, Priority = "Critical", ParentId = null });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 6, TaskName = "Child Task 1", Duration = 4, Progress = 80, Priority = "Critical", ParentId = 5 });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 7, TaskName = "Child Task 2", Duration = 5, Progress = 65, Priority = "Low", ParentId = 5 });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 8, TaskName = "Child Task 3", Duration = 6, Progress = 77, Priority = "High", ParentId = 5 });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 9, TaskName = "Child Task 4", Duration = 6, Progress = 77, Priority = "Low", ParentId = 5 });
            return BusinessObjectCollection;
        }
    }
}
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rtVxXdWWJCSsyjdt?appbar=true&editor=true&result=true&errorlist=true&theme=fluent2" %}

### Show only icons in built-in Toolbar Items

Showing only icons in the built-in toolbar items allows a compact toolbar layout.

To show only icons, hide the text part of the buttons using CSS. For accessibility, provide an accessible name by using **TooltipText** or **aria-label** so screen readers can announce the action correctly.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.TreeGrid

<SfTreeGrid @ref="TreeGrid" DataSource="@TreeGridData" IdMapping="TaskId" ParentIdMapping="ParentId" TreeColumnIndex="1" Toolbar="@ToolbarItems">
    <TreeGridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true"></TreeGridEditSettings>
    <TreeGridColumns>
        <TreeGridColumn Field="TaskId" HeaderText="Task ID" IsPrimaryKey="true" Width="80" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="TaskName" HeaderText="Task Name" Width="160"></TreeGridColumn>
        <TreeGridColumn Field="Duration" HeaderText="Duration" Width="100" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="Progress" HeaderText="Progress" Width="100" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="Priority" HeaderText="Priority" Width="80"></TreeGridColumn>
    </TreeGridColumns>
</SfTreeGrid>

@code {
    private SfTreeGrid<TreeData.BusinessObject> TreeGrid;
    public string[] ToolbarItems = new string[] { "Add", "Edit", "Delete", "Update", "Cancel" };
    public List<TreeData.BusinessObject> TreeGridData { get; set; }

    protected override void OnInitialized()
    {
        TreeGridData = TreeData.GetSelfDataSource();
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
        }

        public static List<BusinessObject> GetSelfDataSource()
        {
            List<BusinessObject> BusinessObjectCollection = new List<BusinessObject>();
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 1, TaskName = "Parent Task 1", Duration = 10, Progress = 70, Priority = "Critical", ParentId = null });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 2, TaskName = "Child Task 1", Duration = 4, Progress = 80, Priority = "Low", ParentId = 1 });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 3, TaskName = "Child Task 2", Duration = 5, Progress = 65, Priority = "Critical", ParentId = 2 });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 4, TaskName = "Child Task 3", Duration = 6, Progress = 77, Priority = "High", ParentId = 3 });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 5, TaskName = "Parent Task 2", Duration = 10, Progress = 70, Priority = "Critical", ParentId = null });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 6, TaskName = "Child Task 1", Duration = 4, Progress = 80, Priority = "Critical", ParentId = 5 });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 7, TaskName = "Child Task 2", Duration = 5, Progress = 65, Priority = "Low", ParentId = 5 });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 8, TaskName = "Child Task 3", Duration = 6, Progress = 77, Priority = "High", ParentId = 5 });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 9, TaskName = "Child Task 4", Duration = 6, Progress = 77, Priority = "Low", ParentId = 5 });
            return BusinessObjectCollection;
        }
    }
}
<style>
    .e-treegrid .e-toolbar .e-tbar-btn-text,
    .e-treegrid .e-toolbar .e-toolbar-items .e-toolbar-item .e-tbar-btn-text {
        display: none;
    }
</style>
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LNBxtdMMJWoPBlHB?appbar=true&editor=true&result=true&errorlist=true&theme=fluent2" %}

### Customize the built-in toolbar items

The Blazor TreeGrid allows customizing built-in toolbar items, including disabling default actions and executing custom logic when a button is clicked.

Handle the [OnToolbarClick](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridEvents-1.html#Syncfusion_Blazor_TreeGrid_TreeGridEvents_1_OnToolbarClick) event to intercept actions. Prefer checking **args.Item.Id** for reliability (IDs are stable and not affected by localization), although Text is also available.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.TreeGrid

<p style="color:red;" id="message">@message</p>

<SfTreeGrid ID="TreeGrid" @ref="TreeGrid" DataSource="@TreeGridData" IdMapping="TaskId" ParentIdMapping="ParentId" TreeColumnIndex="1" Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Cancel", "Update" })">
    <TreeGridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true"></TreeGridEditSettings>
    <TreeGridEvents OnToolbarClick="ToolbarClickHandler" TValue="TreeData.BusinessObject"></TreeGridEvents>
    <TreeGridColumns>
        <TreeGridColumn Field="TaskId" HeaderText="Task ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="120" IsPrimaryKey="true" />
        <TreeGridColumn Field="TaskName" HeaderText="Task Name" Width="150" />
        <TreeGridColumn Field="Duration" HeaderText="Duration" Width="120" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" />
        <TreeGridColumn Field="Priority" HeaderText="Priority" Width="100" />
    </TreeGridColumns>
</SfTreeGrid>

@code {
    private SfTreeGrid<TreeData.BusinessObject> TreeGrid;
    public List<TreeData.BusinessObject> TreeGridData { get; set; }
    private string message;

    protected override void OnInitialized()
    {
        TreeGridData = TreeData.GetSelfDataSource();
    }

    public async Task ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
        if (args.Item.Text == "Add")
        {
            args.Cancel = true;
            var newRecord = new TreeData.BusinessObject() { TaskId = 10, TaskName = "New Task", Duration = 5, Progress = 50, Priority = "Normal", ParentId = null };
            await TreeGrid.AddRecordAsync(newRecord);
            message = "The default adding action is canceled, and a new record is added using the AddRecordAsync method.";
        }
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
        }

        public static List<BusinessObject> GetSelfDataSource()
        {
            List<BusinessObject> BusinessObjectCollection = new List<BusinessObject>();
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 1, TaskName = "Parent Task 1", Duration = 10, Progress = 70, Priority = "Critical", ParentId = null });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 2, TaskName = "Child Task 1", Duration = 4, Progress = 80, Priority = "Low", ParentId = 1 });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 3, TaskName = "Child Task 2", Duration = 5, Progress = 65, Priority = "Critical", ParentId = 2 });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 4, TaskName = "Child Task 3", Duration = 6, Progress = 77, Priority = "High", ParentId = 3 });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 5, TaskName = "Parent Task 2", Duration = 10, Progress = 70, Priority = "Critical", ParentId = null });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 6, TaskName = "Child Task 1", Duration = 4, Progress = 80, Priority = "Critical", ParentId = 5 });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 7, TaskName = "Child Task 2", Duration = 5, Progress = 65, Priority = "Low", ParentId = 5 });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 8, TaskName = "Child Task 3", Duration = 6, Progress = 77, Priority = "High", ParentId = 5 });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 9, TaskName = "Child Task 4", Duration = 6, Progress = 77, Priority = "Low", ParentId = 5 });
            return BusinessObjectCollection;
        }
    }
}
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rjhRjRiMzinSLnap?appbar=true&editor=true&result=true&errorlist=true&theme=fluent2" %}

## Custom Toolbar Items

Adding custom toolbar items to the Blazor TreeGrid enables personalized functionality.

Define custom items by setting the [Toolbar](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_Toolbar) property to a collection of [ItemModel](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.ItemModel.html) objects, and handle actions in the [OnToolbarClick](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridEvents-1.html#Syncfusion_Blazor_TreeGrid_TreeGridEvents_1_OnToolbarClick) event.

By default, custom toolbar items are positioned on the **left** side. Change the position using the [Align](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.ItemModel.html#Syncfusion_Blazor_Navigations_ItemModel_Align) property of ItemModel.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.TreeGrid
@using Syncfusion.Blazor.Navigations

<SfTreeGrid DataSource="@TreeGridData" @ref="TreeGrid" IdMapping="TaskId" ParentIdMapping="ParentId" TreeColumnIndex="1" Toolbar="@Toolbaritems">
    <TreeGridEvents OnToolbarClick="ToolbarClickHandler" TValue="TreeData.BusinessObject"></TreeGridEvents>
    <TreeGridColumns>
        <TreeGridColumn Field="TaskId" HeaderText="Task ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" IsPrimaryKey="true" Width="120"></TreeGridColumn>
        <TreeGridColumn Field="TaskName" HeaderText="Task Name" Width="150"></TreeGridColumn>
        <TreeGridColumn Field="Duration" HeaderText="Duration" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="130"></TreeGridColumn>
        <TreeGridColumn Field="Progress" HeaderText="Progress" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="120"></TreeGridColumn>
        <TreeGridColumn Field="Priority" HeaderText="Priority" Width="80"></TreeGridColumn>
    </TreeGridColumns>
</SfTreeGrid>

@code {
    private SfTreeGrid<TreeData.BusinessObject> TreeGrid;
    private List<ItemModel> Toolbaritems = new List<ItemModel>();
    public List<TreeData.BusinessObject> TreeGridData { get; set; }

    protected override void OnInitialized()
    {
        TreeGridData = TreeData.GetSelfDataSource();
        Toolbaritems.Add(new ItemModel() { Text = "Expand all", TooltipText = "Expand all", PrefixIcon = "e-expand" });
        Toolbaritems.Add(new ItemModel() { Text = "Collapse all", TooltipText = "Collapse all", PrefixIcon = "e-collapse-2", Align = Syncfusion.Blazor.Navigations.ItemAlign.Right });
    }

    public async Task ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
        if (args.Item.Text == "Expand all")
        {
            await this.TreeGrid.ExpandAllAsync();
        }
        if (args.Item.Text == "Collapse all")
        {
            await this.TreeGrid.CollapseAllAsync();
        }
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
        }

        public static List<BusinessObject> GetSelfDataSource()
        {
            List<BusinessObject> BusinessObjectCollection = new List<BusinessObject>();
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 1, TaskName = "Parent Task 1", Duration = 10, Progress = 70, Priority = "Critical", ParentId = null });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 2, TaskName = "Child Task 1", Duration = 4, Progress = 80, Priority = "Low", ParentId = 1 });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 3, TaskName = "Child Task 2", Duration = 5, Progress = 65, Priority = "Critical", ParentId = 2 });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 4, TaskName = "Child Task 3", Duration = 6, Progress = 77, Priority = "High", ParentId = 3 });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 5, TaskName = "Parent Task 2", Duration = 10, Progress = 70, Priority = "Critical", ParentId = null });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 6, TaskName = "Child Task 1", Duration = 4, Progress = 80, Priority = "Critical", ParentId = 5 });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 7, TaskName = "Child Task 2", Duration = 5, Progress = 65, Priority = "Low", ParentId = 5 });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 8, TaskName = "Child Task 3", Duration = 6, Progress = 77, Priority = "High", ParentId = 5 });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 9, TaskName = "Child Task 4", Duration = 6, Progress = 77, Priority = "Low", ParentId = 5 });
            return BusinessObjectCollection;
        }
    }
}
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LNLHZxMiTsQNjPoQ?appbar=true&editor=true&result=true&errorlist=true&theme=fluent2" %}

## Both built-in and custom items in Toolbar

Combining built-in and custom items provides flexibility to create a toolbar with standard actions and custom functionality.

Define the [Toolbar](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_Toolbar) property as an array that contains both built-in item names (strings) and custom items (objects with properties such as [Text](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.ToolbarItem.html#Syncfusion_Blazor_Navigations_ToolbarItem_Text), [PrefixIcon](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.ToolbarItem.html#Syncfusion_Blazor_Navigations_ToolbarItem_PrefixIcon), and [Id](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.ToolbarItem.html#Syncfusion_Blazor_Navigations_ToolbarItem_Id)).

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.TreeGrid
@using Syncfusion.Blazor.Navigations

<div style="margin-left:280px"><p style="color:red;" id="message">@message</p></div>

<SfTreeGrid DataSource="@TreeGridData" @ref="TreeGrid" IdMapping="TaskId" ParentIdMapping="ParentId" TreeColumnIndex="1" Toolbar="@Toolbaritems">
    <TreeGridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true"></TreeGridEditSettings>
    <TreeGridEvents OnToolbarClick="ToolbarClickHandler" TValue="TreeData.BusinessObject"></TreeGridEvents>
    <TreeGridColumns>
        <TreeGridColumn Field="TaskId" HeaderText="Task ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" IsPrimaryKey="true" Width="120"></TreeGridColumn>
        <TreeGridColumn Field="TaskName" HeaderText="Task Name" Width="150"></TreeGridColumn>
        <TreeGridColumn Field="Duration" HeaderText="Duration" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="130"></TreeGridColumn>
        <TreeGridColumn Field="Progress" HeaderText="Progress" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="120"></TreeGridColumn>
        <TreeGridColumn Field="Priority" HeaderText="Priority" Width="80"></TreeGridColumn>
    </TreeGridColumns>
</SfTreeGrid>

@code {
    private SfTreeGrid<TreeData.BusinessObject> TreeGrid;
    public string message;
    private List<object> Toolbaritems = new List<object>() { "Add", "Delete", "Edit", "Update", "Cancel", new ItemModel() { Text = "Click", TooltipText = "Click", PrefixIcon = "e-click", Id = "Click" } };
    public List<TreeData.BusinessObject> TreeGridData { get; set; }

    protected override void OnInitialized()
    {
        TreeGridData = TreeData.GetSelfDataSource();
    }

    public async Task ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
        if (args.Item.Text == "Click")
        {
            message = "Custom Toolbar Clicked";
            //You can customize your code here.
        }
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
        }

        public static List<BusinessObject> GetSelfDataSource()
        {
            List<BusinessObject> BusinessObjectCollection = new List<BusinessObject>();
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 1, TaskName = "Parent Task 1", Duration = 10, Progress = 70, Priority = "Critical", ParentId = null });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 2, TaskName = "Child Task 1", Duration = 4, Progress = 80, Priority = "Low", ParentId = 1 });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 3, TaskName = "Child Task 2", Duration = 5, Progress = 65, Priority = "Critical", ParentId = 2 });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 4, TaskName = "Child Task 3", Duration = 6, Progress = 77, Priority = "High", ParentId = 3 });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 5, TaskName = "Parent Task 2", Duration = 10, Progress = 70, Priority = "Critical", ParentId = null });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 6, TaskName = "Child Task 1", Duration = 4, Progress = 80, Priority = "Critical", ParentId = 5 });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 7, TaskName = "Child Task 2", Duration = 5, Progress = 65, Priority = "Low", ParentId = 5 });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 8, TaskName = "Child Task 3", Duration = 6, Progress = 77, Priority = "High", ParentId = 5 });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 9, TaskName = "Child Task 4", Duration = 6, Progress = 77, Priority = "Low", ParentId = 5 });
            return BusinessObjectCollection;
        }
    }
}
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VthHDnisTsmnDmtC?appbar=true&editor=true&result=true&errorlist=true&theme=fluent2" %}

## Custom Toolbar Items in a specific position

Customizing the position of a custom toolbar item modifies its default placement, allowing precise control over layout.

By default, custom toolbar items are aligned on the left. Modify the position by setting the [Align](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.ItemModel.html#Syncfusion_Blazor_Navigations_ItemModel_Align) property of the [ItemModel](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.ItemModel.html).

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.TreeGrid
@using Syncfusion.Blazor.Navigations

<SfTreeGrid @ref="TreeGrid" DataSource="@TreeGridData" IdMapping="TaskId" ParentIdMapping="ParentId" TreeColumnIndex="1" Toolbar="@Toolbaritems" Height="315">
    <TreeGridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true" Mode="Syncfusion.Blazor.TreeGrid.EditMode.Batch"></TreeGridEditSettings>
    <TreeGridEvents OnToolbarClick="ToolbarClickHandler" TValue="TreeData.BusinessObject"></TreeGridEvents>
    <TreeGridColumns>
        <TreeGridColumn Field="TaskId" HeaderText="Task ID" IsPrimaryKey="true" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" ValidationRules="@(new Syncfusion.Blazor.Grids.ValidationRules { Required = true })" Type="Syncfusion.Blazor.Grids.ColumnType.Integer" Width="120"></TreeGridColumn>
        <TreeGridColumn Field="TaskName" HeaderText="Task Name" ValidationRules="@(new Syncfusion.Blazor.Grids.ValidationRules { Required = true })" Width="120"></TreeGridColumn>
        <TreeGridColumn Field="Duration" HeaderText="Duration" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="130"></TreeGridColumn>
        <TreeGridColumn Field="Progress" HeaderText="Progress" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="120"></TreeGridColumn>
        <TreeGridColumn Field="Priority" HeaderText="Priority" Width="80"></TreeGridColumn>
    </TreeGridColumns>
</SfTreeGrid>

@code {
    private SfTreeGrid<TreeData.BusinessObject> TreeGrid;
    public List<TreeData.BusinessObject> TreeGridData { get; set; }
    private List<object> Toolbaritems = new List<object>() { "Search", new ItemModel() { Text = "Expand all", TooltipText = "Expand all", PrefixIcon = "e-expand", Align = Syncfusion.Blazor.Navigations.ItemAlign.Left }, new ItemModel() { Text = "Collapse all", TooltipText = "Collapse all", PrefixIcon = "e-collapse", Align = Syncfusion.Blazor.Navigations.ItemAlign.Right } };

    protected override void OnInitialized()
    {
        TreeGridData = TreeData.GetSelfDataSource();
    }

    public async Task ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
        if (args.Item.Text == "Expand all")
        {
            await this.TreeGrid.ExpandAllAsync();
        }
        if (args.Item.Text == "Collapse all")
        {
            await this.TreeGrid.CollapseAllAsync();
        }
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
        }

        public static List<BusinessObject> GetSelfDataSource()
        {
            List<BusinessObject> BusinessObjectCollection = new List<BusinessObject>();
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 1, TaskName = "Parent Task 1", Duration = 10, Progress = 70, Priority = "Critical", ParentId = null });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 2, TaskName = "Child Task 1", Duration = 4, Progress = 80, Priority = "Low", ParentId = 1 });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 3, TaskName = "Child Task 2", Duration = 5, Progress = 65, Priority = "Critical", ParentId = 2 });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 4, TaskName = "Child Task 3", Duration = 6, Progress = 77, Priority = "High", ParentId = 3 });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 5, TaskName = "Parent Task 2", Duration = 10, Progress = 70, Priority = "Critical", ParentId = null });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 6, TaskName = "Child Task 1", Duration = 4, Progress = 80, Priority = "Critical", ParentId = 5 });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 7, TaskName = "Child Task 2", Duration = 5, Progress = 65, Priority = "Low", ParentId = 5 });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 8, TaskName = "Child Task 3", Duration = 6, Progress = 77, Priority = "High", ParentId = 5 });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 9, TaskName = "Child Task 4", Duration = 6, Progress = 77, Priority = "Low", ParentId = 5 });
            return BusinessObjectCollection;
        }
    }
}
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hZrxZxiMJMlZBvHF?appbar=true&editor=true&result=true&errorlist=true&theme=fluent2" %}

## Customize the text name of custom Toolbar Items with same as default Toolbar Items

When creating custom toolbar items using the same text as default items (such as Add, Edit, or Delete), the TreeGrid may treat them as default items. This can lead to unexpected behaviorâ€”for example, the buttons may be disabled in certain states.

To avoid this behavior and ensure proper functionality:

- Assign a unique **Id** to each custom toolbar item to distinguish it from default items.
- Use the **Text**, **PrefixIcon**, and **TooltipText** properties of [ItemModel](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.ItemModel.html) to define appearance.
- Handle actions in `OnToolbarClick` using the Id (or Text, if necessary).

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.TreeGrid
@using Syncfusion.Blazor.Navigations

<SfTreeGrid @ref="TreeGrid" DataSource="@TreeGridData" IdMapping="TaskId" ParentIdMapping="ParentId" TreeColumnIndex="1" Toolbar="@ToolbarItems" Height="250">
    <TreeGridEditSettings AllowAdding="true" AllowDeleting="true" AllowEditing="true"></TreeGridEditSettings>
    <TreeGridEvents OnToolbarClick="ToolbarClickHandler" TValue="TreeData.BusinessObject"></TreeGridEvents>
    <TreeGridColumns>
        <TreeGridColumn Field="TaskId" IsPrimaryKey="true" HeaderText="Task ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="120" />
        <TreeGridColumn Field="TaskName" HeaderText="Task Name" Width="150" />
        <TreeGridColumn Field="Duration" HeaderText="Duration" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="130" />
        <TreeGridColumn Field="Progress" HeaderText="Progress" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="120" />
    </TreeGridColumns>
</SfTreeGrid>

@code {
    private SfTreeGrid<TreeData.BusinessObject> TreeGrid;
    public List<TreeData.BusinessObject> TreeGridData { get; set; }

    private List<ItemModel> ToolbarItems = new List<ItemModel>() {
        new ItemModel() { Text = "Add", PrefixIcon = "e-add", Id = "TreeGrid_add" },
        new ItemModel() { Text = "Edit", PrefixIcon = "e-edit", Id = "TreeGrid_edit" },
        new ItemModel() { Text = "Delete", PrefixIcon = "e-delete", Id = "TreeGrid_delete" },
        new ItemModel() { Text = "Update", PrefixIcon = "e-update", Id = "TreeGrid_update" },
        new ItemModel() { Text = "Cancel", PrefixIcon = "e-cancel", Id = "TreeGrid_cancel" }
    };

    protected override void OnInitialized()
    {
        TreeGridData = TreeData.GetSelfDataSource();
    }

    public async Task ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
        if (args.Item.Text == "Add")
        {
            await TreeGrid.AddRecordAsync();
        }
        if (args.Item.Text == "Edit")
        {
            await TreeGrid.StartEditAsync();
        }
        if (args.Item.Text == "Delete")
        {
            await TreeGrid.DeleteRecordAsync();
        }
        if (args.Item.Text == "Update")
        {
            await TreeGrid.EndEditAsync();
        }
        if (args.Item.Text == "Cancel")
        {
            await TreeGrid.CloseEditAsync();
        }
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
        }

        public static List<BusinessObject> GetSelfDataSource()
        {
            List<BusinessObject> BusinessObjectCollection = new List<BusinessObject>();
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 1, TaskName = "Parent Task 1", Duration = 10, Progress = 70, Priority = "Critical", ParentId = null });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 2, TaskName = "Child Task 1", Duration = 4, Progress = 80, Priority = "Low", ParentId = 1 });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 3, TaskName = "Child Task 2", Duration = 5, Progress = 65, Priority = "Critical", ParentId = 2 });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 4, TaskName = "Child Task 3", Duration = 6, Progress = 77, Priority = "High", ParentId = 3 });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 5, TaskName = "Parent Task 2", Duration = 10, Progress = 70, Priority = "Critical", ParentId = null });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 6, TaskName = "Child Task 1", Duration = 4, Progress = 80, Priority = "Critical", ParentId = 5 });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 7, TaskName = "Child Task 2", Duration = 5, Progress = 65, Priority = "Low", ParentId = 5 });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 8, TaskName = "Child Task 3", Duration = 6, Progress = 77, Priority = "High", ParentId = 5 });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 9, TaskName = "Child Task 4", Duration = 6, Progress = 77, Priority = "Low", ParentId = 5 });
            return BusinessObjectCollection;
        }
    }
}
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VZLxNRWiTWvopfdi?appbar=true&editor=true&result=true&errorlist=true&theme=fluent2" %}

## Customizing the toolbar items tooltip text

Customize a toolbar item's tooltip text by adding items externally and setting the [ItemModel.TooltipText](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.ItemModel.html) property. Tooltips also improve accessibility by conveying the action's purpose when icons are shown without text.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.TreeGrid
@using Syncfusion.Blazor.Navigations

<SfTreeGrid ID="TreeGrid" @ref="TreeGrid" DataSource="@TreeGridData" IdMapping="TaskId" ParentIdMapping="ParentId" TreeColumnIndex="1" Toolbar="@ToolbarItems" AllowExcelExport="true" AllowPdfExport="true">
    <TreeGridEditSettings AllowAdding="true" AllowDeleting="true" AllowEditing="true"></TreeGridEditSettings>
    <TreeGridEvents OnToolbarClick="ToolbarClickHandler" TValue="TreeData.BusinessObject"></TreeGridEvents>
    <TreeGridColumns>
        <TreeGridColumn Field="TaskId" IsPrimaryKey="true" HeaderText="Task ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="120"></TreeGridColumn>
        <TreeGridColumn Field="TaskName" HeaderText="Task Name" Width="150"></TreeGridColumn>
        <TreeGridColumn Field="Duration" HeaderText="Duration" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="130"></TreeGridColumn>
        <TreeGridColumn Field="Progress" HeaderText="Progress" Format="C2" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="120"></TreeGridColumn>
    </TreeGridColumns>
</SfTreeGrid>

@code {
    private SfTreeGrid<TreeData.BusinessObject> TreeGrid;
    public List<TreeData.BusinessObject> TreeGridData { get; set; }
    private List<object> ToolbarItems = new List<object>() {
        new ItemModel() { Text = "Excel", TooltipText = "Export to Excel", PrefixIcon = "e-excelexport", Id = "TreeGrid_excelexport" },
        new ItemModel() { Text = "Pdf", TooltipText = "Export to PDF", PrefixIcon = "e-pdfexport", Id = "TreeGrid_pdfexport" },
        new ItemModel() { Text = "Csv", TooltipText = "Export to CSV", PrefixIcon = "e-csvexport", Id = "TreeGrid_csvexport" },
    };

    public async Task ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
        if (args.Item.Id == "TreeGrid_pdfexport")  //Id is combination of TreeGrid's ID and item name.
        {
            await this.TreeGrid.ExportToPdfAsync();
        }
        else if (args.Item.Id == "TreeGrid_excelexport")
        {
            await TreeGrid.ExportToExcelAsync();
        }
        else if (args.Item.Id == "TreeGrid_csvexport")
        {
            await TreeGrid.ExportToCsvAsync();
        }
    }

    protected override void OnInitialized()
    {
        TreeGridData = TreeData.GetSelfDataSource();
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
        }

        public static List<BusinessObject> GetSelfDataSource()
        {
            List<BusinessObject> BusinessObjectCollection = new List<BusinessObject>();
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 1, TaskName = "Parent Task 1", Duration = 10, Progress = 70, Priority = "Critical", ParentId = null });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 2, TaskName = "Child Task 1", Duration = 4, Progress = 80, Priority = "Low", ParentId = 1 });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 3, TaskName = "Child Task 2", Duration = 5, Progress = 65, Priority = "Critical", ParentId = 2 });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 4, TaskName = "Child Task 3", Duration = 6, Progress = 77, Priority = "High", ParentId = 3 });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 5, TaskName = "Parent Task 2", Duration = 10, Progress = 70, Priority = "Critical", ParentId = null });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 6, TaskName = "Child Task 1", Duration = 4, Progress = 80, Priority = "Critical", ParentId = 5 });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 7, TaskName = "Child Task 2", Duration = 5, Progress = 65, Priority = "Low", ParentId = 5 });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 8, TaskName = "Child Task 3", Duration = 6, Progress = 77, Priority = "High", ParentId = 5 });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 9, TaskName = "Child Task 4", Duration = 6, Progress = 77, Priority = "Low", ParentId = 5 });
            return BusinessObjectCollection;
        }
    }
}
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hZVHDRCizWlEdUOo?appbar=true&editor=true&result=true&errorlist=true&theme=fluent2" %}