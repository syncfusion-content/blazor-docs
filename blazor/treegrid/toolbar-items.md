````markdown
---
layout: post
title: Toolbar Items in Blazor TreeGrid Component | Syncfusion
description: Learn how to use built-in and custom toolbar items in Syncfusion Blazor TreeGrid, including icons, alignment, tooltips, and handling toolbar actions.
platform: Blazor
control: TreeGrid
documentation: ug
---

# Toolbar items in Blazor TreeGrid

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor TreeGrid offers a flexible toolbar that enables the addition of custom toolbar items or modification of existing ones. The toolbar appears above the TreeGrid, providing convenient access to common actions and custom functionality.

## Built-in Toolbar Items

Built-in toolbar items perform standard TreeGrid actions and can be added by defining the [Toolbar](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_Toolbar) property as a collection of predefined item names. These items render with both icon and text.

| Built-in Toolbar Item | Action Description               |
|-----------------------|----------------------------------|
| ExpandAll             | Expands all rows                 |
| CollapseAll           | Collapses all rows              |
| Add                   | Adds a new record                |
| Edit                  | Edits the selected record        |
| Update                | Updates the edited record        |
| Delete                | Deletes the selected record      |
| Cancel                | Cancels the edit state           |
| Search                | Searches records by keyword      |
| Print                 | Prints the TreeGrid              |
| ExcelExport           | Exports TreeGrid to Excel        |
| PdfExport             | Exports TreeGrid to PDF          |
| WordExport            | Exports TreeGrid to Word         |

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.TreeGrid
@using TreeGridComponent.Data

<SfTreeGrid DataSource="@TreeData" AllowPaging="true" Height="200" @ref="TreeGrid" Toolbar="@ToolbarItems" IdMapping="TaskId" ParentIdMapping="ParentId" TreeColumnIndex="1">
    <TreeGridColumns>
        <TreeGridColumn Field="TaskId" HeaderText="Task ID" IsPrimaryKey="true" Width="120"></TreeGridColumn>
        <TreeGridColumn Field="TaskName" HeaderText="Task Name" Width="150"></TreeGridColumn>
        <TreeGridColumn Field="Duration" HeaderText="Duration" Width="130"></TreeGridColumn>
        <TreeGridColumn Field="Progress" HeaderText="Progress" Width="120"></TreeGridColumn>
        <TreeGridColumn Field="Priority" HeaderText="Priority" Width="100"></TreeGridColumn>
    </TreeGridColumns>
</SfTreeGrid>

@code {
    private SfTreeGrid<BusinessObject> TreeGrid;
    public string[] ToolbarItems = new string[] { "Search", "Print" };
    public List<BusinessObject> TreeData { get; set; }

    protected override void OnInitialized()
    {
        TreeData = BusinessObject.GetSelfDataSource();
    }
}
{% endhighlight %}
{% highlight c# tabtitle="BusinessObject.cs" %}
namespace TreeGridComponent.Data
{
    public class BusinessObject
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public int? Duration { get; set; }
        public int? Progress { get; set; }
        public string Priority { get; set; }
        public int? ParentId { get; set; }

        public static List<BusinessObject> GetSelfDataSource()
        {
            return new List<BusinessObject>
            {
                new BusinessObject { TaskId = 1, TaskName = "Parent Task 1", Duration = 10, Progress = 70, Priority = "Critical", ParentId = null },
                new BusinessObject { TaskId = 2, TaskName = "Child task 1", Progress = 80, Priority = "Low", ParentId = 1 },
                new BusinessObject { TaskId = 3, TaskName = "Child Task 2", Duration = 5, Progress = 65, Priority = "Critical", ParentId = 2 },
                new BusinessObject { TaskId = 4, TaskName = "Child task 3", Duration = 6, Priority = "High", Progress = 77, ParentId = 3 }
            };
        }
    }
}
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VNhHjfXYrjbwlvMD?appbar=true&editor=true&result=true&errorlist=true&theme=fluent2" %}

## Custom Toolbar Items

Define custom toolbar items by setting the `Toolbar` property to a collection of `ItemModel` objects and handle actions in the `OnToolbarClick` event.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.TreeGrid
@using Syncfusion.Blazor.Navigations
@using TreeGridComponent.Data

<SfTreeGrid DataSource="@TreeData" @ref="TreeGrid" Height="200" Toolbar=@Toolbaritems IdMapping="TaskId" ParentIdMapping="ParentId" TreeColumnIndex="1">
    <TreeGridEvents OnToolbarClick="ToolbarClickHandler" TValue="BusinessObject"></TreeGridEvents>
    <TreeGridColumns>
        <TreeGridColumn Field=@nameof(BusinessObject.TaskId) HeaderText="Task ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" IsPrimaryKey="true" Width="120"></TreeGridColumn>
        <TreeGridColumn Field=@nameof(BusinessObject.TaskName) HeaderText="Task Name" Width="150"></TreeGridColumn>
        <TreeGridColumn Field=@nameof(BusinessObject.Duration) HeaderText="Duration" Width="130"></TreeGridColumn>
        <TreeGridColumn Field=@nameof(BusinessObject.Progress) HeaderText="Progress" Width="120"></TreeGridColumn>
        <TreeGridColumn Field=@nameof(BusinessObject.Priority) HeaderText="Priority" Width="100"></TreeGridColumn>
    </TreeGridColumns>
</SfTreeGrid>

@code {
    private SfTreeGrid<BusinessObject> TreeGrid;
    private List<ItemModel> Toolbaritems = new List<ItemModel>();
    public List<BusinessObject> TreeData { get; set; }

    protected override void OnInitialized()
    {
        TreeData = BusinessObject.GetSelfDataSource();
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
}
{% endhighlight %}
{% highlight c# tabtitle="BusinessObject.cs" %}
namespace TreeGridComponent.Data
{
    public class BusinessObject
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public int? Duration { get; set; }
        public int? Progress { get; set; }
        public string Priority { get; set; }
        public int? ParentId { get; set; }

        public static List<BusinessObject> GetSelfDataSource()
        {
            return new List<BusinessObject>
            {
                new BusinessObject { TaskId = 1, TaskName = "Parent Task 1", Duration = 10, Progress = 70, Priority = "Critical", ParentId = null },
                new BusinessObject { TaskId = 2, TaskName = "Child task 1", Progress = 80, Priority = "Low", ParentId = 1 },
                new BusinessObject { TaskId = 3, TaskName = "Child Task 2", Duration = 5, Progress = 65, Priority = "Critical", ParentId = 2 },
                new BusinessObject { TaskId = 4, TaskName = "Child task 3", Duration = 6, Priority = "High", Progress = 77, ParentId = 3 }
            };
        }
    }
}
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BNrnXpNYhDOceKCc?appbar=true&editor=true&result=true&errorlist=true&theme=fluent2" %}

## Both built-in and custom items in Toolbar

You can mix built-in item names (strings) and custom `ItemModel` objects in the `Toolbar` collection.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.TreeGrid
@using Syncfusion.Blazor.Navigations
@using TreeGridComponent.Data

<div style="margin-left:280px"><p style="color:red;" id="message">@message</p></div>

<SfTreeGrid DataSource="@TreeData" @ref="TreeGrid" Height="200" Toolbar=@Toolbaritems IdMapping="TaskId" ParentIdMapping="ParentId" TreeColumnIndex="1">
    <TreeGridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true"></TreeGridEditSettings>
    <TreeGridEvents OnToolbarClick="ToolbarClickHandler" TValue="BusinessObject"></TreeGridEvents>
    <TreeGridColumns>
        <TreeGridColumn Field=@nameof(BusinessObject.TaskId) HeaderText="Task ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" IsPrimaryKey="true" Width="120"></TreeGridColumn>
        <TreeGridColumn Field=@nameof(BusinessObject.TaskName) HeaderText="Task Name" Width="150"></TreeGridColumn>
        <TreeGridColumn Field=@nameof(BusinessObject.Duration) HeaderText="Duration" Width="130"></TreeGridColumn>
        <TreeGridColumn Field=@nameof(BusinessObject.Progress) HeaderText="Progress" Width="120"></TreeGridColumn>
        <TreeGridColumn Field=@nameof(BusinessObject.Priority) HeaderText="Priority" Width="100"></TreeGridColumn>
    </TreeGridColumns>
</SfTreeGrid>

@code {
    private SfTreeGrid<BusinessObject> TreeGrid;
    public string message;
    private List<object> Toolbaritems = new List<object>() { "Add", "Delete", "Edit", "Update", "Cancel", new ItemModel() { Text = "Click", TooltipText = "Click", PrefixIcon = "e-click", Id = "Click" } };
    public List<BusinessObject> TreeData { get; set; }

    protected override void OnInitialized()
    {
        TreeData = BusinessObject.GetSelfDataSource();
    }

    public async Task ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
        if (args.Item.Text == "Click")
        {
            message = "Custom Toolbar Clicked";
        }
    }
}
{% endhighlight %}
{% highlight c# tabtitle="BusinessObject.cs" %}
namespace TreeGridComponent.Data
{
    public class BusinessObject
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public int? Duration { get; set; }
        public int? Progress { get; set; }
        public string Priority { get; set; }
        public int? ParentId { get; set; }

        public static List<BusinessObject> GetSelfDataSource()
        {
            return new List<BusinessObject>
            {
                new BusinessObject { TaskId = 1, TaskName = "Parent Task 1", Duration = 10, Progress = 70, Priority = "Critical", ParentId = null },
                new BusinessObject { TaskId = 2, TaskName = "Child task 1", Progress = 80, Priority = "Low", ParentId = 1 },
                new BusinessObject { TaskId = 3, TaskName = "Child Task 2", Duration = 5, Progress = 65, Priority = "Critical", ParentId = 2 },
                new BusinessObject { TaskId = 4, TaskName = "Child task 3", Duration = 6, Priority = "High", Progress = 77, ParentId = 3 }
            };
        }
    }
}
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BZVRZpXkBCKvdwxT?appbar=true&editor=true&result=true&errorlist=true&theme=fluent2" %}

## Customize the text name of custom Toolbar Items with same as default Toolbar Items

If a custom toolbar item uses the same `Text` as a built-in item, assign a unique `Id` so the TreeGrid doesn't treat it as the default item.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.TreeGrid
@using Syncfusion.Blazor.Navigations
@using TreeGridComponent.Data

<SfTreeGrid @ref="TreeGrid" DataSource="@TreeData" AllowPaging="true" Toolbar="@ToolbarItems" Height="250" IdMapping="TaskId" ParentIdMapping="ParentId" TreeColumnIndex="1">
    <TreeGridEditSettings AllowAdding="true" AllowDeleting="true" AllowEditing="true"></TreeGridEditSettings>
    <TreeGridEvents OnToolbarClick="ToolbarClickHandler" TValue="BusinessObject"></TreeGridEvents>
    <TreeGridColumns>
        <TreeGridColumn Field=@nameof(BusinessObject.TaskId) IsPrimaryKey="true" HeaderText="Task ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="120" />
        <TreeGridColumn Field=@nameof(BusinessObject.TaskName) HeaderText="Task Name" Width="150" />
        <TreeGridColumn Field=@nameof(BusinessObject.Duration) HeaderText="Duration" Width="130" />
        <TreeGridColumn Field=@nameof(BusinessObject.Progress) HeaderText="Progress" Width="120" />
        <TreeGridColumn Field=@nameof(BusinessObject.Priority) HeaderText="Priority" Width="100" />
    </TreeGridColumns>
</SfTreeGrid>

@code {
    private SfTreeGrid<BusinessObject> TreeGrid;
    public List<BusinessObject> TreeData { get; set; }

    private List<ItemModel> ToolbarItems = new List<ItemModel>() {
        new ItemModel() { Text = "Add", PrefixIcon = "e-add", Id = "TreeGrid_add" },
        new ItemModel() { Text = "Edit", PrefixIcon = "e-edit", Id = "TreeGrid_edit" },
        new ItemModel() { Text = "Delete", PrefixIcon = "e-delete", Id = "TreeGrid_delete" },
        new ItemModel() { Text = "Update", PrefixIcon = "e-update", Id = "TreeGrid_update" },
        new ItemModel() { Text = "Cancel", PrefixIcon = "e-cancel", Id = "TreeGrid_cancel" }
    };

    protected override void OnInitialized()
    {
        TreeData = BusinessObject.GetSelfDataSource();
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
}
{% endhighlight %}
{% highlight c# tabtitle="BusinessObject.cs" %}
namespace TreeGridComponent.Data
{
    public class BusinessObject
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public int? Duration { get; set; }
        public int? Progress { get; set; }
        public string Priority { get; set; }
        public int? ParentId { get; set; }

        public static List<BusinessObject> GetSelfDataSource()
        {
            return new List<BusinessObject>
            {
                new BusinessObject { TaskId = 1, TaskName = "Parent Task 1", Duration = 10, Progress = 70, Priority = "Critical", ParentId = null },
                new BusinessObject { TaskId = 2, TaskName = "Child task 1", Progress = 80, Priority = "Low", ParentId = 1 },
                new BusinessObject { TaskId = 3, TaskName = "Child Task 2", Duration = 5, Progress = 65, Priority = "Critical", ParentId = 2 },
                new BusinessObject { TaskId = 4, TaskName = "Child task 3", Duration = 6, Priority = "High", Progress = 77, ParentId = 3 }
            };
        }
    }
}
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BNrnXpNYhDOceKCc?appbar=true&editor=true&result=true&errorlist=true&theme=fluent2" %}

## Customizing the toolbar items tooltip text

Set `ItemModel.TooltipText` for custom items to improve accessibility and convey meaning when icons are shown without text.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.TreeGrid
@using Syncfusion.Blazor.Navigations
@using TreeGridComponent.Data

<SfTreeGrid ID="TreeGrid" @ref="TreeGrid" DataSource="@TreeData" AllowPaging="true" Toolbar=@ToolbarItems AllowExcelExport="true" AllowPdfExport="true" IdMapping="TaskId" ParentIdMapping="ParentId" TreeColumnIndex="1">
    <TreeGridEditSettings AllowAdding="true" AllowDeleting="true" AllowEditing="true"></TreeGridEditSettings>
    <TreeGridEvents OnToolbarClick="ToolbarClickHandler" TValue="BusinessObject"></TreeGridEvents>
    <TreeGridColumns>
        <TreeGridColumn Field=@nameof(BusinessObject.TaskId) IsPrimaryKey="true" HeaderText="Task ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="120"></TreeGridColumn>
        <TreeGridColumn Field=@nameof(BusinessObject.TaskName) HeaderText="Task Name" Width="150"></TreeGridColumn>
        <TreeGridColumn Field=@nameof(BusinessObject.Duration) HeaderText="Duration" Width="130"></TreeGridColumn>
        <TreeGridColumn Field=@nameof(BusinessObject.Progress) HeaderText="Progress" Width="120"></TreeGridColumn>
        <TreeGridColumn Field=@nameof(BusinessObject.Priority) HeaderText="Priority" Width="100"></TreeGridColumn>
    </TreeGridColumns>
</SfTreeGrid>

@code {
    private SfTreeGrid<BusinessObject> TreeGrid;
    public List<BusinessObject> TreeData { get; set; }
    private List<object> ToolbarItems = new List<object>() {
        new ItemModel() { Text = "Excel", TooltipText = "Export to Excel", PrefixIcon = "e-excelexport", Id = "TreeGrid_excelexport" },
        new ItemModel() { Text = "Pdf", TooltipText = "Export to PDF", PrefixIcon = "e-pdfexport", Id = "TreeGrid_pdfexport" },
        new ItemModel() { Text = "CSV", TooltipText = "Export to CSV", PrefixIcon = "e-csvexport", Id = "TreeGrid_csvexport" },
    };

    protected override void OnInitialized()
    {
        TreeData = BusinessObject.GetSelfDataSource();
    }

    public async Task ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
        if (args.Item.Id == "TreeGrid_pdfexport")
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
}
{% endhighlight %}
{% highlight c# tabtitle="BusinessObject.cs" %}
namespace TreeGridComponent.Data
{
    public class BusinessObject
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public int? Duration { get; set; }
        public int? Progress { get; set; }
        public string Priority { get; set; }
        public int? ParentId { get; set; }

        public static List<BusinessObject> GetSelfDataSource()
        {
            return new List<BusinessObject>
            {
                new BusinessObject { TaskId = 1, TaskName = "Parent Task 1", Duration = 10, Progress = 70, Priority = "Critical", ParentId = null },
                new BusinessObject { TaskId = 2, TaskName = "Child task 1", Progress = 80, Priority = "Low", ParentId = 1 },
                new BusinessObject { TaskId = 3, TaskName = "Child Task 2", Duration = 5, Progress = 65, Priority = "Critical", ParentId = 2 },
                new BusinessObject { TaskId = 4, TaskName = "Child task 3", Duration = 6, Priority = "High", Progress = 77, ParentId = 3 }
            };
        }
    }
}
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/htBxtTWKizdBkokh?appbar=true&editor=true&result=true&errorlist=true&theme=fluent2" %}

### Show only icons in built-in Toolbar Items

To show only icons, hide the text part of the buttons using CSS. For accessibility, provide an accessible name by using `TooltipText` or `aria-label`.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.TreeGrid
@using Syncfusion.Blazor.Navigations
@using TreeGridComponent.Data

<SfTreeGrid DataSource="@TreeData" IdMapping="TaskId" ParentIdMapping="ParentId" Toolbar=@ToolbarItems TreeColumnIndex="1">
    <TreeGridColumns>
        <TreeGridColumn Field=@nameof(BusinessObject.TaskId) HeaderText="Task ID" Width="80" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field=@nameof(BusinessObject.TaskName) HeaderText="Task Name" Width="160"></TreeGridColumn>
        <TreeGridColumn Field=@nameof(BusinessObject.Duration) HeaderText="Duration" Width="100" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field=@nameof(BusinessObject.Progress) HeaderText="Progress" Width="100" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field=@nameof(BusinessObject.Priority) HeaderText="Priority" Width="80"></TreeGridColumn>
    </TreeGridColumns>
</SfTreeGrid>

@code {
    public List<string> ToolbarItems = new List<string>() { "Search", "Print" };
    public List<BusinessObject> TreeData { get; set; }

    protected override void OnInitialized()
    {
        TreeData = BusinessObject.GetSelfDataSource();
    }
}

<style>
    .e-treegrid .e-toolbar .e-tbar-btn-text,
    .e-treegrid .e-toolbar .e-toolbar-items .e-toolbar-item .e-tbar-btn-text {
        display: none;
    }
</style>
{% endhighlight %}
{% highlight c# tabtitle="BusinessObject.cs" %}
namespace TreeGridComponent.Data
{
    public class BusinessObject
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public int? Duration { get; set; }
        public int? Progress { get; set; }
        public string Priority { get; set; }
        public int? ParentId { get; set; }

        public static List<BusinessObject> GetSelfDataSource()
        {
            return new List<BusinessObject>
            {
                new BusinessObject { TaskId = 1, TaskName = "Parent Task 1", Duration = 10, Progress = 70, Priority = "Critical", ParentId = null },
                new BusinessObject { TaskId = 2, TaskName = "Child task 1", Progress = 80, Priority = "Low", ParentId = 1 },
                new BusinessObject { TaskId = 3, TaskName = "Child Task 2", Duration = 5, Progress = 65, Priority = "Critical", ParentId = 2 },
                new BusinessObject { TaskId = 4, TaskName = "Child task 3", Duration = 6, Priority = "High", Progress = 77, ParentId = 3 }
            };
        }
    }
}
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BDLxXziUrNjwYslp?appbar=true&editor=true&result=true&errorlist=true&theme=fluent2" %}

## Customize the built-in toolbar items

Handle the `OnToolbarClick` event to intercept actions. Prefer checking `args.Item.Id` for reliability.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.TreeGrid
@using Syncfusion.Blazor.Navigations
@using TreeGridComponent.Data

<SfTreeGrid @ref="TreeGrid" DataSource="@TreeData" IdMapping="TaskId" ParentIdMapping="ParentId" TreeColumnIndex="1" Height="315" Toolbar="@Toolbaritems">
    <TreeGridEvents OnToolbarClick="ToolbarClickHandler" TValue="BusinessObject"></TreeGridEvents>
    <TreeGridColumns>
        <TreeGridColumn Field=@nameof(BusinessObject.TaskId) IsPrimaryKey="true" HeaderText="Task ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="120"></TreeGridColumn>
        <TreeGridColumn Field=@nameof(BusinessObject.TaskName) HeaderText="Task Name" Width="150"></TreeGridColumn>
        <TreeGridColumn Field=@nameof(BusinessObject.Duration) HeaderText="Duration" Width="130"></TreeGridColumn>
        <TreeGridColumn Field=@nameof(BusinessObject.Progress) HeaderText="Progress" Width="120"></TreeGridColumn>
        <TreeGridColumn Field=@nameof(BusinessObject.Priority) HeaderText="Priority" Width="100"></TreeGridColumn>
    </TreeGridColumns>
</SfTreeGrid>

@code {
    private SfTreeGrid<BusinessObject> TreeGrid;
    private List<object> Toolbaritems = new List<object>()
    {
        "Search",
        new ItemModel() { Text = "Expand all", TooltipText = "Expand all", PrefixIcon = "e-expand", Align = Syncfusion.Blazor.Navigations.ItemAlign.Left },
        new ItemModel() { Text = "Collapse all", TooltipText = "Collapse all", PrefixIcon = "e-collapse", Align = Syncfusion.Blazor.Navigations.ItemAlign.Right }
    };
    public List<BusinessObject> TreeData { get; set; }

    protected override void OnInitialized()
    {
        TreeData = BusinessObject.GetSelfDataSource();
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
}
{% endhighlight %}
{% highlight c# tabtitle="BusinessObject.cs" %}
namespace TreeGridComponent.Data
{
    public class BusinessObject
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public int? Duration { get; set; }
        public int? Progress { get; set; }
        public string Priority { get; set; }
        public int? ParentId { get; set; }

        public static List<BusinessObject> GetSelfDataSource()
        {
            return new List<BusinessObject>
            {
                new BusinessObject { TaskId = 1, TaskName = "Parent Task 1", Duration = 10, Progress = 70, Priority = "Critical", ParentId = null },
                new BusinessObject { TaskId = 2, TaskName = "Child task 1", Progress = 80, Priority = "Low", ParentId = 1 },
                new BusinessObject { TaskId = 3, TaskName = "Child Task 2", Duration = 5, Progress = 65, Priority = "Critical", ParentId = 2 },
                new BusinessObject { TaskId = 4, TaskName = "Child task 3", Duration = 6, Priority = "High", Progress = 77, ParentId = 3 }
            };
        }
    }
}
{% endhighlight %}
{% endtabs %}

````
{% previewsample "https://blazorplayground.syncfusion.com/embed/LjrdjzsUBLqHruIY?appbar=true&editor=true&result=true&errorlist=true&theme=fluent2" %}