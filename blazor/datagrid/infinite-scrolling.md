---
layout: post
title: Infinite Scrolling in Blazor DataGrid | Syncfusion
description: Learn how to implement Infinite Scrolling in Syncfusion Blazor DataGrid and explore more advanced features and customization options.
platform: Blazor
control: DataGrid
documentation: ug
---

# Infinite scroll in Blazor DataGrid

The infinite scrolling feature in the DataGrid is a powerful tool for seamlessly handling extensive datasets by dynamically loading data as the vertical scrollbar reaches the end of the viewport. In infinite scrolling mode, a new block of data is loaded on-demand each time the scrollbar approaches the end, optimizing rendering performance by fetching only the required data blocks and reducing initial load time and memory usage. In this context, a block refers to the number of rows defined by the [PageSize](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridPageSettings.html#Syncfusion_Blazor_Grids_GridPageSettings_PageSize) property, if not explicitly specified, the DataGrid automatically calculates it based on the viewport and row height.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@TaskData" Height="300" EnableInfiniteScrolling="true">
    <GridPageSettings PageSize="50"></GridPageSettings>
    <GridColumns>
        <GridColumn Field=@nameof(TaskDetails.TaskID) HeaderText="TaskID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(TaskDetails.Engineer) HeaderText="Engineer" Width="150"></GridColumn>
        <GridColumn Field=@nameof(TaskDetails.Designation) HeaderText="Designation" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(TaskDetails.Estimation) HeaderText="Estimation" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(TaskDetails.Status) HeaderText="Status" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    public List<TaskDetails> TaskData { get; set; }
    protected override void OnInitialized()
    {
        TaskData = TaskDetails.GenerateData(5000);
    }  
}

{% endhighlight %}

{% highlight cs tabtitle="TaskDetails.cs" %}

public class TaskDetails
{
    public static List<TaskDetails> GenerateData(int count)
    {
        var names = new List<string> { "TOM", "Hawk", "Jon", "Chandler", "Monica", "Rachel", "Phoebe", "Gunther", "Ross", "Geller", "Joey", "Bing", "Tribbiani", "Janice", "Bong", "Perk", "Green", "Ken", "Adams" };
        var hours = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        var designations = new List<string> { "Manager", "Engineer 1", "Engineer 2", "Developer", "Tester" };
        var statusValues = new List<string> { "Completed", "Open", "In Progress", "Review", "Testing" };
        var random = new Random();
        var result = new List<TaskDetails>();
        // Generate random data.
        for (int i = 0; i < count; i++)
        {
            result.Add(new TaskDetails
            {
                TaskID = i + 1,
                Engineer = names[random.Next(names.Count)],
                Designation = designations[random.Next(designations.Count)],
                Estimation = hours[random.Next(hours.Count)],
                Status = statusValues[random.Next(statusValues.Count)]
            });
        }
        return result;
    }
    public int TaskID { get; set; }
    public string Engineer { get; set; }
    public string Designation { get; set; }
    public int Estimation { get; set; }
    public string Status { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LjreXMrOAPkHeOht?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Number of blocks rendered during initial loading

By default, three blocks are initially rendered when the DataGrid is loaded. Each block corresponds to a page size of the DataGrid, resulting in the rendering of a certain number of row elements determined by multiplying the initial block size with the page size.

Initial loading pages count configuration is managed through the [InitialBlocks](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridInfiniteScrollSettings.html#Syncfusion_Blazor_Grids_GridInfiniteScrollSettings_InitialBlocks) on [GridInfiniteScrollSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridInfiniteScrollSettings.html). The default value is "3". Subsequently, additional data is buffered and loaded based on either the page size or the number of rows rendered within the provided height.

The example below demonstrates how to configure InitialBlocks using a [DropDownList](https://blazor.syncfusion.com/documentation/dropdown-list/getting-started-with-web-app).

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.DropDowns

<div style="margin-bottom:5px">
    <label style="padding: 30px 2px 0 0">Select InitialBlocks count:</label>
    <SfDropDownList TValue="int" TItem="Rows" Placeholder="Select count" Width="220px" DataSource="DropDownData">
        <DropDownListFieldSettings Text="Text" Value="Value"></DropDownListFieldSettings>
        <DropDownListEvents ValueChange="ValueChanged" TValue="int" TItem="Rows"></DropDownListEvents>
    </SfDropDownList>
</div>
<SfGrid @ref="Grid" DataSource="@TaskData" Height="300" EnableInfiniteScrolling="true">
    <GridPageSettings PageSize="50"></GridPageSettings>
    <GridInfiniteScrollSettings InitialBlocks="@InitialBlockValue"></GridInfiniteScrollSettings>
    <GridColumns>
        <GridColumn Field=@nameof(TaskDetails.TaskID) HeaderText="TaskID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(TaskDetails.Engineer) HeaderText="Engineer" Width="150"></GridColumn>
        <GridColumn Field=@nameof(TaskDetails.Designation) HeaderText="Designation" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(TaskDetails.Estimation) HeaderText="Estimation" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(TaskDetails.Status) HeaderText="Status" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public SfGrid<TaskDetails> Grid { get; set; }
    public List<TaskDetails> TaskData { get; set; }
    protected override void OnInitialized()
    {
        TaskData = TaskDetails.GenerateData(1000);
    }
    public int InitialBlockValue { get; set; }
    public class Rows
    {
        public int Text { get; set; }
        public int Value { get; set; }
    }
    private List<Rows> DropDownData = new List<Rows>
    {
        new Rows() { Text = 1, Value = 1 },
        new Rows() { Text = 2, Value = 2 },
        new Rows() { Text = 3, Value = 3 },
        new Rows() { Text = 4, Value = 4 },
        new Rows() { Text = 5, Value = 5 },
        new Rows() { Text = 6, Value = 6 },
        new Rows() { Text = 7, Value = 7 },
    };
    public async Task ValueChanged(ChangeEventArgs<int, Rows> Args)
    {
        InitialBlockValue = Args.Value;
        await Grid.Refresh();
    }
}

{% endhighlight %}

{% highlight cs tabtitle="TaskDetails.cs" %}

public class TaskDetails
{
    public static List<TaskDetails> GenerateData(int count)
    {
        var names = new List<string> { "TOM", "Hawk", "Jon", "Chandler", "Monica", "Rachel", "Phoebe", "Gunther", "Ross", "Geller", "Joey", "Bing", "Tribbiani", "Janice", "Bong", "Perk", "Green", "Ken", "Adams" };
        var hours = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        var designations = new List<string> { "Manager", "Engineer 1", "Engineer 2", "Developer", "Tester" };
        var statusValues = new List<string> { "Completed", "Open", "In Progress", "Review", "Testing" };
        var random = new Random();
        var result = new List<TaskDetails>();
        // Generate random data.
        for (int i = 0; i < count; i++)
        {
            result.Add(new TaskDetails
            {
                TaskID = i + 1,
                Engineer = names[random.Next(names.Count)],
                Designation = designations[random.Next(designations.Count)],
                Estimation = hours[random.Next(hours.Count)],
                Status = statusValues[random.Next(statusValues.Count)]
            });
        }
        return result;
    }
    public int TaskID { get; set; }
    public string Engineer { get; set; }
    public string Designation { get; set; }
    public int Estimation { get; set; }
    public string Status { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rDheZMAZCHNIhdIg?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Efficient data caching and DOM management in DataGrid cache mode

Cache mode in infinite scrolling improves performance by reusing previously loaded data blocks, minimizing frequent data requests. Enabling cache mode requires setting the [EnableCache](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridInfiniteScrollSettings.html#Syncfusion_Blazor_Grids_GridInfiniteScrollSettings_EnableCache) property to `true`.

The [GridInfiniteScrollSettings.MaximumBlocks](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridInfiniteScrollSettings.html#Syncfusion_Blazor_Grids_GridInfiniteScrollSettings_MaximumBlocks) property defines the maximum number of cached blocks. When this limit is exceeded, the DataGrid removes the oldest block to manage DOM elements efficiently. The default value is "3".

The example below shows how to toggle cache mode using a [SfSwitch](https://blazor.syncfusion.com/documentation/toggle-switch-button/getting-started-webapp).

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons

<div style="display:flex; margin-bottom:5px">
    <label> Enable or Disable Cache mode:</label>
    <SfSwitch ValueChange="Change" TChecked="bool"></SfSwitch>
</div>
<SfGrid @ref="Grid" DataSource="@TaskData" Height="300" EnableVirtualization="true">
    <GridPageSettings PageSize="50"></GridPageSettings>
    <GridInfiniteScrollSettings EnableCache="@IsEnabled"></GridInfiniteScrollSettings>
    <GridColumns>
        <GridColumn Field=@nameof(TaskDetails.TaskID) HeaderText="TaskID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(TaskDetails.Engineer) HeaderText="Engineer" Width="150"></GridColumn>
        <GridColumn Field=@nameof(TaskDetails.Designation) HeaderText="Designation" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(TaskDetails.Estimation) HeaderText="Estimation" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(TaskDetails.Status) HeaderText="Status" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    public SfGrid<TaskDetails> Grid { get; set; }
    public List<TaskDetails> TaskData { get; set; }
    protected override void OnInitialized()
    {
        TaskData = TaskDetails.GenerateData(1000);
    }
    public bool IsEnabled { get; set; }
    private void Change(Syncfusion.Blazor.Buttons.ChangeEventArgs<bool> args)
    {
        IsEnabled = args.Checked;
        Grid.Refresh();
    }
}

{% endhighlight %}

{% highlight cs tabtitle="TaskDetails.cs" %}

public class TaskDetails
{
    public static List<TaskDetails> GenerateData(int count)
    {
        var names = new List<string> { "TOM", "Hawk", "Jon", "Chandler", "Monica", "Rachel", "Phoebe", "Gunther", "Ross", "Geller", "Joey", "Bing", "Tribbiani", "Janice", "Bong", "Perk", "Green", "Ken", "Adams" };
        var hours = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        var designations = new List<string> { "Manager", "Engineer 1", "Engineer 2", "Developer", "Tester" };
        var statusValues = new List<string> { "Completed", "Open", "In Progress", "Review", "Testing" };
        var random = new Random();
        var result = new List<TaskDetails>();
        // Generate random data.
        for (int i = 0; i < count; i++)
        {
            result.Add(new TaskDetails
            {
                TaskID = i + 1,
                Engineer = names[random.Next(names.Count)],
                Designation = designations[random.Next(designations.Count)],
                Estimation = hours[random.Next(hours.Count)],
                Status = statusValues[random.Next(statusValues.Count)]
            });
        }
        return result;
    }
    public int TaskID { get; set; }
    public string Engineer { get; set; }
    public string Designation { get; set; }
    public int Estimation { get; set; }
    public string Status { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hZreNsUXVSieZxOY?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Limitations

* Due to the element height limitation in browsers, the maximum number of records loaded by the DataGrid is limited due to the browser capability.
* Set a static height for the component or its parent container when using infinite scrolling. The 100% height will work only if the component height is set to 100%, and its parent container has a static height.
* The combined height of the initially loaded rows must exceed the viewport height for content to scroll.
* When infinite scrolling is activated, compatibility for copy-paste and drag-and-drop operations is limited to the data items visible in the current viewport of the DataGrid.
* Cell selection will not be persisted in cache mode.
* Group records cannot be collapsed in cache mode.
* Lazy load grouping with infinite scrolling does not support cache mode, and the infinite scrolling mode is exclusively applicable to parent-level caption rows in the scenario.
* In normal grouping, infinite scrolling is not supported for child items during expand/collapse; all child items load when caption rows are toggled.
* Aggregates and total group items reflect the current view items; this is expected with on-demand data loading.
* Programmatic selection using [SelectRowsAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_SelectRowsAsync_System_Int32___) and [SelectRowAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_SelectRowAsync_System_Int32_System_Nullable_System_Boolean__System_Boolean_) is not supported in infinite scrolling.
* Infinite scrolling is not compatible with:
    1. Batch editing
    2. Normal editing
    3. Row template
    4. Row virtual scrolling
    5. Detail template
    6. Hierarchy features
    7. Autofill
* Limitations of row drag and drop with infinite scrolling:
    1. In cache mode, the DataGrid refreshes automatically if the content's "tr" element count exceeds the cache limit of the DataGrid's content after the drop action.
    2. When performing row drag and drop with lazy load grouping, the DataGrid will refresh automatically.
    3. In remote data, changes are applied only in the UI. They will be lost once the DataGrid is refreshed. To restore them, update the changes in the database. By using the [RowDropped](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_RowDropped) event, send the request to the server and apply the changes in the database. After this, refresh the DataGrid to show the updated data.

## See also

* [Infinite scrolling with Lazy load grouping in DataGrid](https://blazor.syncfusion.com/documentation/datagrid/lazy-load-grouping#lazy-load-grouping-with-infinite-scrolling)