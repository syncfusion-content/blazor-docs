---
layout: post
title: Custom Toolbar in Blazor TreeGrid Component | Syncfusion
description: Learn about creating and using custom toolbar in the Syncfusion Blazor TreeGrid, including templates, icons with text, dropdowns, and export actions.
platform: Blazor
control: TreeGrid
documentation: ug
---

# Custom toolbar in Blazor TreeGrid

The custom toolbar in the [Blazor TreeGrid](https://www.syncfusion.com/blazor-components/blazor-tree-grid) enables a distinctive toolbar layout, style, and behavior tailored to application requirements, delivering a personalized TreeGrid experience.

This is implemented by using the `Template` property, which provides extensive customization options for the toolbar. Define a custom template for the toolbar and handle toolbar item actions in the **OnClick** event.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.TreeGrid
@using Syncfusion.Blazor.Navigations

<SfTreeGrid DataSource="@TreeGridData" @ref="TreeGrid" IdMapping="TaskId" ParentIdMapping="ParentId" TreeColumnIndex="1">
    <TreeGridTemplates>
        <ToolbarTemplate>
            <SfToolbar>
                <ToolbarEvents Clicked="ToolbarClickHandler"></ToolbarEvents>
                <ToolbarItems>
                    <ToolbarItem Type="@ItemType.Button" PrefixIcon="e-chevron-up icon" Id="collapseall" Text="Collapse All"></ToolbarItem>
                    <ToolbarItem Type="@ItemType.Button" PrefixIcon="e-chevron-down icon" Id="ExpandAll" Text="Expand All"></ToolbarItem>
                </ToolbarItems>
            </SfToolbar>
        </ToolbarTemplate>
    </TreeGridTemplates>
    <TreeGridColumns>
        <TreeGridColumn Field="TaskId" HeaderText="Task ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="120"></TreeGridColumn>
        <TreeGridColumn Field="TaskName" HeaderText="Task Name" Width="150"></TreeGridColumn>
        <TreeGridColumn Field="Duration" HeaderText="Duration" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="130"></TreeGridColumn>
        <TreeGridColumn Field="Progress" HeaderText="Progress" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="120"></TreeGridColumn>
        <TreeGridColumn Field="Priority" HeaderText="Priority" Width="80"></TreeGridColumn>
    </TreeGridColumns>
</SfTreeGrid>

@code {
    private SfTreeGrid<TreeData.BusinessObject> TreeGrid;
    public List<TreeData.BusinessObject> TreeGridData { get; set; }

    protected override void OnInitialized()
    {
        TreeGridData = TreeData.GetSelfDataSource();
    }

    public async Task ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
        if (args.Item.Text == "Collapse All")
        {
            await this.TreeGrid.CollapseAllAsync();
        }
        if (args.Item.Text == "Expand All")
        {
            await this.TreeGrid.ExpandAllAsync();
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

<style>
    .e-collapse::before {
        content: '\e834';
    }
</style>
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LXBHZxWWpWElBCsL?appbar=true&editor=true&result=true&errorlist=true&theme=fluent2" %}

## Render image with text in custom Toolbar

Rendering an image with text in the custom toolbar of the Blazor TreeGrid helps provide context and improves visual clarity for actions.

To render an image with text in the custom toolbar, use the `Template` in [SfToolbar](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfToolbar.html).

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.TreeGrid
@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.Buttons

<SfTreeGrid DataSource="@TreeGridData" @ref="TreeGrid" IdMapping="TaskId" ParentIdMapping="ParentId" TreeColumnIndex="1">
    <TreeGridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true"></TreeGridEditSettings>
    <SfToolbar>
        <ToolbarItems>
            <ToolbarItem Type="ItemType.Input">
                <Template>
                    <div class="image">
                        <img class="image" src="@($"image/addimage.png")" />
                        <SfButton id="AddButton" OnClick="AddButton">Add</SfButton>
                        <img class="image" src="@($"image/deleteimage.png")" />
                        <SfButton id="DeleteButton" OnClick="DeleteButton">Delete</SfButton>
                    </div>
                </Template>
            </ToolbarItem>
        </ToolbarItems>
    </SfToolbar>
    <TreeGridColumns>
        <TreeGridColumn Field="TaskId" HeaderText="Task ID" IsPrimaryKey="true" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="120"></TreeGridColumn>
        <TreeGridColumn Field="TaskName" HeaderText="Task Name" Width="150"></TreeGridColumn>
        <TreeGridColumn Field="Duration" HeaderText="Duration" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="130"></TreeGridColumn>
        <TreeGridColumn Field="Progress" HeaderText="Progress" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="120"></TreeGridColumn>
        <TreeGridColumn Field="Priority" HeaderText="Priority" Width="80"></TreeGridColumn>
    </TreeGridColumns>
</SfTreeGrid>

@code {
    private SfTreeGrid<TreeData.BusinessObject> TreeGrid;
    public List<TreeData.BusinessObject> TreeGridData { get; set; }

    protected override void OnInitialized()
    {
        TreeGridData = TreeData.GetSelfDataSource();
    }

    public async Task AddButton()
    {
        await this.TreeGrid.AddRecordAsync();
    }

    public async Task DeleteButton()
    {
        await this.TreeGrid.DeleteRecordAsync();
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
    .image {
        height: 50px;
    }
</style>
{% endhighlight %}
{% endtabs %}

{% previewsample "{% previewsample "https://blazorplayground.syncfusion.com/embed/rtVxXdWWJCSsyjdt?appbar=true&editor=true&result=true&errorlist=true&theme=fluent2" %}

> The styles and layout of the image and text in the custom toolbar can be further customized to meet specific design requirements. For better accessibility, include alt text on images.

## Render SfDropDownList in Custom Toolbar

Rendering an [SfDropdownList](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html) in the custom toolbar of the Blazor TreeGrid extends toolbar functionality and enables actions based on user selection.

This is achieved by using the `Template`. The example below demonstrates rendering the `SfDropDownList` in the custom toolbar, where the toolbar template binds the [ValueChanged](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_ValueChanged) event to the **OnChange** method.

In the **OnChange** method, the selected item text determines the action. For example, if **Update** is chosen, the [EndEditAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_EndEditAsync) method exits edit mode. If **Edit** is selected, the selected record is passed to [StartEditingAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_StartEditingAsync) to start editing dynamically. Similarly, if **Delete** is chosen, the selected record is passed to [DeleteRecordAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_DeleteRecordAsync) to remove it from the TreeGrid.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.TreeGrid
@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.DropDowns

<SfTreeGrid DataSource="@TreeGridData" @ref="TreeGrid" IdMapping="TaskId" ParentIdMapping="ParentId" TreeColumnIndex="1">
    <TreeGridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true"></TreeGridEditSettings>
    <SfToolbar>
        <ToolbarItems>
            <ToolbarItem Type="ItemType.Input">
                <Template>
                    <label>Change the value: </label>
                    <SfDropDownList @ref="Dropdown" TValue="string" TItem="Select" DataSource="@LocalData" Width="200">
                        <DropDownListFieldSettings Text="text" Value="text"></DropDownListFieldSettings>
                        <DropDownListEvents TValue="string" TItem="Select" ValueChange="OnChange"></DropDownListEvents>
                    </SfDropDownList>
                </Template>
            </ToolbarItem>
        </ToolbarItems>
    </SfToolbar>
    <TreeGridColumns>
        <TreeGridColumn Field="TaskId" HeaderText="Task ID" IsPrimaryKey="true" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="120"></TreeGridColumn>
        <TreeGridColumn Field="TaskName" HeaderText="Task Name" Width="150"></TreeGridColumn>
        <TreeGridColumn Field="Duration" HeaderText="Duration" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="130"></TreeGridColumn>
        <TreeGridColumn Field="Progress" HeaderText="Progress" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="120"></TreeGridColumn>
        <TreeGridColumn Field="Priority" HeaderText="Priority" Width="80"></TreeGridColumn>
    </TreeGridColumns>
</SfTreeGrid>

@code {
    SfDropDownList<string, Select> Dropdown;
    private SfTreeGrid<TreeData.BusinessObject> TreeGrid;
    public List<TreeData.BusinessObject> TreeGridData { get; set; }

    public class Select
    {
        public string text { get; set; }
    }

    List<Select> LocalData = new List<Select>
    {
        new Select() { text = "Edit" },
        new Select() { text = "Delete" },
        new Select() { text = "Update" },
    };

    protected override void OnInitialized()
    {
        TreeGridData = TreeData.GetSelfDataSource();
    }

    public async Task OnChange(Syncfusion.Blazor.DropDowns.ChangeEventArgs<string, Select> args)
    {
        if (args.ItemData.text == "Edit")
        {
            await this.TreeGrid.StartEditAsync();
        }
        if (args.ItemData.text == "Delete")
        {
            await this.TreeGrid.DeleteRecordAsync();
        }
        if (args.Value == "Update")
        {
            await this.TreeGrid.EndEditAsync();
        }
        this.Dropdown.Placeholder = args.ItemData.text;
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/LZLdZHWiJBhaHCNE?appbar=true&editor=true&result=true&errorlist=true&theme=fluent2" %}

## Render SfAutoComplete in custom toolbar

Rendering the [SfAutoComplete](https://blazor.syncfusion.com/documentation/autocomplete/getting-started-with-web-app) in the custom toolbar of the Blazor TreeGrid enhances usability by enabling dynamic search based on user input.

This is implemented by using the `Template` property of the [Toolbar](https://blazor.syncfusion.com/documentation/toolbar/getting-started-webapp). The example below renders the `SfAutoComplete` within the custom toolbar. The [ValueChange](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.AutoCompleteEvents-2.html#Syncfusion_Blazor_DropDowns_AutoCompleteEvents_2_ValueChange) event of `SfAutoComplete` is bound to the **OnSearch** method, which searches the TreeGrid based on the selected input.

In the **OnSearch** method, the selected value from `SfAutoComplete` is used as the search keyword. The TreeGrid's [SearchAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_SearchAsync_System_String_) method filters records that match the keyword across all searchable columns.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.TreeGrid
@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.DropDowns

<SfTreeGrid DataSource="@TreeGridData" @ref="TreeGrid" IdMapping="TaskId" ParentIdMapping="ParentId" TreeColumnIndex="1" AllowPaging="true">
    <TreeGridPageSettings PageSize="8"></TreeGridPageSettings>
    <SfToolbar>
        <ToolbarItems>
            <ToolbarItem Type="ItemType.Input">
                <Template>
                    <SfAutoComplete Placeholder="Search Task Name" TItem="TaskDetails" TValue="string" DataSource="@Tasks">
                        <AutoCompleteEvents ValueChange="OnSearch" TValue="string" TItem="TaskDetails"></AutoCompleteEvents>
                        <AutoCompleteFieldSettings Value="Name"></AutoCompleteFieldSettings>
                    </SfAutoComplete>
                </Template>
            </ToolbarItem>
        </ToolbarItems>
    </SfToolbar>
    <TreeGridColumns>
        <TreeGridColumn Field="TaskId" HeaderText="Task ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="120"></TreeGridColumn>
        <TreeGridColumn Field="TaskName" HeaderText="Task Name" Width="150"></TreeGridColumn>
        <TreeGridColumn Field="Duration" HeaderText="Duration" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="130"></TreeGridColumn>
        <TreeGridColumn Field="Progress" HeaderText="Progress" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="120"></TreeGridColumn>
        <TreeGridColumn Field="Priority" HeaderText="Priority" Width="80"></TreeGridColumn>
    </TreeGridColumns>
</SfTreeGrid>

@code {
    public class TaskDetails
    {
        public string Name { get; set; }
        public int Id { get; set; }
    }

    List<TaskDetails> Tasks = new List<TaskDetails>
    {
        new TaskDetails() { Name = "Parent Task 1", Id = 1 },
        new TaskDetails() { Name = "Parent Task 2", Id = 5 },
        new TaskDetails() { Name = "Child Task 1", Id = 2 },
        new TaskDetails() { Name = "Child Task 2", Id = 3 },
        new TaskDetails() { Name = "Child Task 3", Id = 4 },
    };

    private SfTreeGrid<TreeData.BusinessObject> TreeGrid;
    public List<TreeData.BusinessObject> TreeGridData { get; set; }

    protected override void OnInitialized()
    {
        TreeGridData = TreeData.GetSelfDataSource();
    }

    public async Task OnSearch(Syncfusion.Blazor.DropDowns.ChangeEventArgs<string, TaskDetails> args)
    {
        await this.TreeGrid.SearchAsync(args.Value);
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/rDVxZdCWJVUpYkVj?appbar=true&editor=true&result=true&errorlist=true&theme=fluent2" %}

## Render a component or element using the Toolbar Template

Rendering a component or element by using the toolbar template in the Blazor TreeGrid extends the toolbar with custom components such as buttons, dropdowns, input fields, icons, or other UI elements. Event handlers can be bound within the template to enable actions for the added components.

To render custom components within the toolbar, use the `Template` directive. For example, include an [SfButton](https://help.syncfusion.com/cr/blazor/syncfusion.blazor.buttons.sfbutton.html) and perform specific TreeGrid actions based on button clicks. When the **ExcelExport** button is clicked, [ExportToExcelAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_ExportToExcelAsync_Syncfusion_Blazor_TreeGrid_ExcelExportProperties_System_Nullable_System_Boolean__System_Object_System_Nullable_System_Boolean__) exports the TreeGrid to Excel. When the **PdfExport** button is clicked, [ExportToPdfAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_ExportToPdfAsync_Syncfusion_Blazor_TreeGrid_PdfExportProperties_System_Nullable_System_Boolean__System_Object_System_Nullable_System_Boolean__) exports the TreeGrid to PDF. Likewise, when the **Print** button is clicked, [PrintAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_PrintAsync) is triggered to print the TreeGrid.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.TreeGrid
@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.Buttons

<SfTreeGrid DataSource="@TreeGridData" @ref="TreeGrid" IdMapping="TaskId" ParentIdMapping="ParentId" TreeColumnIndex="1" AllowPdfExport="true" AllowExcelExport="true">
    <SfToolbar>
        <ToolbarItems>
            <ToolbarItem Type="ItemType.Input">
                <Template>
                    <div>
                        <SfButton id="excelExportButton" OnClick="ExcelExport">Excel Export</SfButton>
                        <SfButton id="pdfExportButton" OnClick="PdfExport">Pdf Export</SfButton>
                        <SfButton id="printButton" OnClick="Print">Print</SfButton>
                    </div>
                </Template>
            </ToolbarItem>
        </ToolbarItems>
    </SfToolbar>
    <TreeGridColumns>
        <TreeGridColumn Field="TaskId" HeaderText="Task ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="120"></TreeGridColumn>
        <TreeGridColumn Field="TaskName" HeaderText="Task Name" Width="150"></TreeGridColumn>
        <TreeGridColumn Field="Duration" HeaderText="Duration" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="130"></TreeGridColumn>
        <TreeGridColumn Field="Progress" HeaderText="Progress" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="120"></TreeGridColumn>
        <TreeGridColumn Field="Priority" HeaderText="Priority" Width="80"></TreeGridColumn>
    </TreeGridColumns>
</SfTreeGrid>

@code {
    private SfTreeGrid<TreeData.BusinessObject> TreeGrid;
    public List<TreeData.BusinessObject> TreeGridData { get; set; }

    protected override void OnInitialized()
    {
        TreeGridData = TreeData.GetSelfDataSource();
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/VNLRNHCiJLgaXntt?appbar=true&editor=true&result=true&errorlist=true&theme=fluent2" %}
