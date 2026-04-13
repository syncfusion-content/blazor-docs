````markdown
---
layout: post
title: Custom Toolbar Items in Blazor TreeGrid Component | Syncfusion
description: Learn how to create and use custom toolbar items in the Syncfusion Blazor TreeGrid, including templates, icons with text, dropdowns, and export actions.
platform: Blazor
control: TreeGrid
documentation: ug
---

# Custom toolbar in Blazor TreeGrid

The custom toolbar in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor TreeGrid enables a distinctive toolbar layout, style, and behavior tailored to application requirements.

Use the `Template` property on `SfToolbar` inside a `ToolbarTemplate` to render custom controls and handle actions in event handlers.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.TreeGrid
@using Syncfusion.Blazor.Navigations
@using TreeGridComponent.Data

<SfTreeGrid DataSource="@TreeData" Height="250" @ref="TreeGrid" IdMapping="TaskId" ParentIdMapping="ParentId" TreeColumnIndex="1">
    <TreeGridTemplates>
        <ToolbarTemplate>
            <SfToolbar>
                <ToolbarEvents Clicked="ToolbarClickHandler"></ToolbarEvents>
                <ToolbarItems>
                    <ToolbarItem Type="@ItemType.Button" PrefixIcon="e-chevron-up icon" Id="collapseall" Text="Collapse All"></ToolbarItem>
                    <ToolbarItem Type="@ItemType.Button" PrefixIcon="e-chevron-down icon" Id="expandall" Text="Expand All"></ToolbarItem>
                </ToolbarItems>
            </SfToolbar>
        </ToolbarTemplate>
    </TreeGridTemplates>
    <TreeGridColumns>
        <TreeGridColumn Field="TaskId" HeaderText="Task ID" Width="120"></TreeGridColumn>
        <TreeGridColumn Field="TaskName" HeaderText="Task Name" Width="150"></TreeGridColumn>
        <TreeGridColumn Field="Duration" HeaderText="Duration" Width="130"></TreeGridColumn>
    </TreeGridColumns>
</SfTreeGrid>

@code {
    private SfTreeGrid<BusinessObject> TreeGrid;
    public List<BusinessObject> TreeData { get; set; }

    protected override void OnInitialized()
    {
        TreeData = BusinessObject.GetSelfDataSource();
    }

    public async Task ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
        if (args.Item.Text == "Collapse All")
        {
            await TreeGrid.CollapseAllAsync();
        }
        if (args.Item.Text == "Expand All")
        {
            await TreeGrid.ExpandAllAsync();
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/hXLnjTZEWdcWHjkO?appbar=true&editor=true&result=true&errorlist=true&theme=fluent2" %}

## Render image with text in custom Toolbar

Use a toolbar template to render images and buttons together. Provide alt text for accessibility.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.TreeGrid
@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.Buttons
@using TreeGridComponent.Data

<SfTreeGrid DataSource="@TreeData" Height="250" @ref="TreeGrid" IdMapping="TaskId" ParentIdMapping="ParentId" TreeColumnIndex="1">
    <TreeGridEditSettings AllowAdding="true" AllowDeleting="true"></TreeGridEditSettings>
    <SfToolbar>
        <ToolbarItems>
            <ToolbarItem Type="ItemType.Input">
                <Template>
                    <div class="image-toolbar">
                        <img src="/images/icon-add.png" alt="Add record" />
                        <SfButton OnClick="AddRecord">Add</SfButton>
                        <img src="/images/icon-delete.png" alt="Delete record" />
                        <SfButton OnClick="DeleteRecord">Delete</SfButton>
                    </div>
                </Template>
            </ToolbarItem>
        </ToolbarItems>
    </SfToolbar>
    <TreeGridColumns>
        <TreeGridColumn Field="TaskId" HeaderText="Task ID" IsPrimaryKey="true" Width="120"></TreeGridColumn>
        <TreeGridColumn Field="TaskName" HeaderText="Task Name" Width="150"></TreeGridColumn>
        <TreeGridColumn Field="Duration" HeaderText="Duration" Width="130"></TreeGridColumn>
        <TreeGridColumn Field="Progress" HeaderText="Progress" Width="120"></TreeGridColumn>
    </TreeGridColumns>
</SfTreeGrid>

@code {
    private SfTreeGrid<BusinessObject> TreeGrid;
    public List<BusinessObject> TreeData { get; set; }

    protected override void OnInitialized()
    {
        TreeData = BusinessObject.GetSelfDataSource();
    }

    public async Task AddRecord()
    {
        await TreeGrid.AddRecordAsync();
    }

    public async Task DeleteRecord()
    {
        await TreeGrid.DeleteRecordAsync();
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
{% previewsample "https://blazorplayground.syncfusion.com/embed/rtVHXpDkCmnRZRLG?appbar=true&editor=true&result=true&errorlist=true&theme=fluent2" %}

## Render SfDropDownList in Custom Toolbar

Rendering an `SfDropDownList` in the custom toolbar extends toolbar functionality and enables tree grid actions based on user selection.

Use the `Template` property inside a `ToolbarItem` to embed the `SfDropDownList`. Bind its `ValueChange` event to a handler method. In the handler, check the selected item value and call the corresponding tree grid method: `StartEditAsync`, `DeleteRecordAsync`, or `EndEditAsync`.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.TreeGrid
@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.DropDowns
@using TreeGridComponent.Data

<SfTreeGrid DataSource="@TreeData" AllowPaging="true" Height="200" @ref="TreeGrid" IdMapping="TaskId" ParentIdMapping="ParentId" TreeColumnIndex="1">
    <TreeGridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true"></TreeGridEditSettings>
    <SfToolbar>
        <ToolbarItems>
            <ToolbarItem Type="ItemType.Input">
                <Template>
                    <label>Change the value: </label>
                    <SfDropDownList @ref="Dropdown" TValue="string" TItem="SelectItem" DataSource=@LocalData Width="200">
                        <DropDownListFieldSettings Text="Text" Value="Text"></DropDownListFieldSettings>
                        <DropDownListEvents TValue="string" TItem="SelectItem" ValueChange="OnChange"></DropDownListEvents>
                    </SfDropDownList>
                </Template>
            </ToolbarItem>
        </ToolbarItems>
    </SfToolbar>
    <TreeGridColumns>
        <TreeGridColumn Field="TaskId" HeaderText="Task ID" IsPrimaryKey="true" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="120"></TreeGridColumn>
        <TreeGridColumn Field="TaskName" HeaderText="Task Name" Width="150"></TreeGridColumn>
        <TreeGridColumn Field="Duration" HeaderText="Duration" Width="130"></TreeGridColumn>
        <TreeGridColumn Field="Progress" HeaderText="Progress" Width="120"></TreeGridColumn>
    </TreeGridColumns>
</SfTreeGrid>

@code {
    private SfDropDownList<string, SelectItem> Dropdown;
    private SfTreeGrid<BusinessObject> TreeGrid;
    public List<BusinessObject> TreeData { get; set; }

    public class SelectItem
    {
        public string Text { get; set; }
    }

    List<SelectItem> LocalData = new List<SelectItem>
    {
        new SelectItem() { Text = "Edit" },
        new SelectItem() { Text = "Delete" },
        new SelectItem() { Text = "Update" },
    };

    protected override void OnInitialized()
    {
        TreeData = BusinessObject.GetSelfDataSource();
    }

    public async Task OnChange(Syncfusion.Blazor.DropDowns.ChangeEventArgs<string, SelectItem> args)
    {
        if (args.ItemData.Text == "Edit")
        {
            await this.TreeGrid.StartEditAsync();
        }
        if (args.ItemData.Text == "Delete")
        {
            await this.TreeGrid.DeleteRecordAsync();
        }
        if (args.Value == "Update")
        {
            await this.TreeGrid.EndEditAsync();
        }
        this.Dropdown.Placeholder = args.ItemData.Text;
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/rNhnNJjYMmmaBMkq?appbar=true&editor=true&result=true&errorlist=true&theme=fluent2" %}

## Render SfAutoComplete in Custom Toolbar

Rendering an `SfAutoComplete` in the custom toolbar enables dynamic search based on user input. Bind the `ValueChange` event to a handler that calls the tree grid's `SearchAsync` method to filter records.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.TreeGrid
@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.DropDowns
@using TreeGridComponent.Data

<SfTreeGrid DataSource="@TreeData" AllowPaging="true" @ref="TreeGrid" IdMapping="TaskId" ParentIdMapping="ParentId" TreeColumnIndex="1">
    <TreeGridPageSettings PageSize="8"></TreeGridPageSettings>
    <SfToolbar>
        <ToolbarItems>
            <ToolbarItem Type="ItemType.Input">
                <Template>
                    <SfAutoComplete Placeholder="Search Task Name" TItem="TaskSuggestion" TValue="string" DataSource="@Suggestions">
                        <AutoCompleteEvents ValueChange="OnSearch" TValue="string" TItem="TaskSuggestion"></AutoCompleteEvents>
                        <AutoCompleteFieldSettings Value="Name"></AutoCompleteFieldSettings>
                    </SfAutoComplete>
                </Template>
            </ToolbarItem>
        </ToolbarItems>
    </SfToolbar>
    <TreeGridColumns>
        <TreeGridColumn Field="TaskId" HeaderText="Task ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="120"></TreeGridColumn>
        <TreeGridColumn Field="TaskName" HeaderText="Task Name" Width="150"></TreeGridColumn>
        <TreeGridColumn Field="Duration" HeaderText="Duration" Width="130"></TreeGridColumn>
        <TreeGridColumn Field="Progress" HeaderText="Progress" Width="120"></TreeGridColumn>
    </TreeGridColumns>
</SfTreeGrid>

@code {
    public class TaskSuggestion
    {
        public string Name { get; set; }
        public int Id { get; set; }
    }

    List<TaskSuggestion> Suggestions = new List<TaskSuggestion>
    {
        new TaskSuggestion() { Name = "Parent Task 1", Id = 1 },
        new TaskSuggestion() { Name = "Child task 1", Id = 2 },
        new TaskSuggestion() { Name = "Child Task 2", Id = 3 },
        new TaskSuggestion() { Name = "Parent Task 2", Id = 4 },
        new TaskSuggestion() { Name = "Child task 3", Id = 5 }
    };

    private SfTreeGrid<BusinessObject> TreeGrid;
    public List<BusinessObject> TreeData { get; set; }

    protected override void OnInitialized()
    {
        TreeData = BusinessObject.GetSelfDataSource();
    }

    public async Task OnSearch(Syncfusion.Blazor.DropDowns.ChangeEventArgs<string, TaskSuggestion> args)
    {
        await this.TreeGrid.SearchAsync(args.Value);
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/LtLRXJNYswFuQKPS?appbar=true&editor=true&result=true&errorlist=true&theme=fluent2" %}


## Render a component or element using the Toolbar Template

Use the `Template` directive inside a `ToolbarItem` to embed any component � buttons, icons, inputs, or other UI elements � and bind event handlers to trigger tree grid actions.

The example below renders export and print buttons in the toolbar. Clicking **Excel Export** calls `ExportToExcelAsync`, **PDF Export** calls `ExportToPdfAsync`, and **Print** calls `PrintAsync`.

N> The styles and layout of image and text in the custom toolbar can be further customized to meet specific design requirements. For better accessibility, always include `alt` text on images.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.TreeGrid
@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.Buttons
@using TreeGridComponent.Data

<SfTreeGrid DataSource="@TreeData" AllowPaging="true" AllowExcelExport="true" AllowPdfExport="true" Height="200" @ref="TreeGrid" IdMapping="TaskId" ParentIdMapping="ParentId" TreeColumnIndex="1">
    <SfToolbar>
        <ToolbarItems>
            <ToolbarItem Type="ItemType.Input">
                <Template>
                    <div>
                        <SfButton OnClick="ExcelExport">Excel Export</SfButton>
                        <SfButton OnClick="PdfExport">PDF Export</SfButton>
                        <SfButton OnClick="Print">Print</SfButton>
                    </div>
                </Template>
            </ToolbarItem>
        </ToolbarItems>
    </SfToolbar>
    <TreeGridColumns>
        <TreeGridColumn Field="TaskId" HeaderText="Task ID" IsPrimaryKey="true" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="120"></TreeGridColumn>
        <TreeGridColumn Field="TaskName" HeaderText="Task Name" Width="150"></TreeGridColumn>
        <TreeGridColumn Field="Duration" HeaderText="Duration" Width="130"></TreeGridColumn>
        <TreeGridColumn Field="Progress" HeaderText="Progress" Width="120"></TreeGridColumn>
    </TreeGridColumns>
</SfTreeGrid>

@code {
    private SfTreeGrid<BusinessObject> TreeGrid;
    public List<BusinessObject> TreeData { get; set; }

    protected override void OnInitialized()
    {
        TreeData = BusinessObject.GetSelfDataSource();
    }

    public async Task ExcelExport()
    {
        await this.TreeGrid.ExportToExcelAsync();
    }

    public async Task PdfExport()
    {
        await this.TreeGrid.ExportToPdfAsync();
    }

    public async Task Print()
    {
        await this.TreeGrid.PrintAsync();
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/rNrdNTjuWljNshAx?appbar=true&editor=true&result=true&errorlist=true&theme=fluent2" %}
