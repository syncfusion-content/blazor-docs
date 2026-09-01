---
layout: post
title: Blazor Grid Infinite Scrolling for Large Data Performance | Syncfusion
description: Learn how to implement infinite scrolling in Blazor Data Grid to efficiently load large datasets and enhance scrolling performance.
platform: Blazor
control: DataGrid
documentation: ug
---

# Infinite Scrolling for Large Data Performance in Blazor Data Grid

The infinite scrolling feature in the [Blazor Data Grid](https://www.syncfusion.com/blazor-components/blazor-datagrid) provides load-on-demand data retrieval for large datasets. The Data Grid loads the next block of data when the vertical scrollbar reaches the end of the scroller.

In this feature, a block is equivalent to the Grid’s [PageSize](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridPageSettings.html#Syncfusion_Blazor_Grids_GridPageSettings_PageSize). If `PageSize` is not set, the Data Grid calculates it from the viewport height and row height. To enable infinite scrolling, set [EnableInfiniteScrolling](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_EnableInfiniteScrolling) to **true** and define a content [Height](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_Height).

> - With this feature, the Data Grid does not issue a new data request when revisiting a previously loaded page.
> - When `EnableCache` is set to **false** (default), the Data Grid keeps the requested blocks in memory and reuses them when scrolled back into view, so revisiting a page does not trigger a new data request. When `EnableCache` is set to **true**, the Data Grid additionally reuses the rendered DOM row elements for those blocks (subject to the `MaximumBlocks` limit), which avoids recreating rows on revisit.
> - The `Height` property must be specified when `EnableInfiniteScrolling` is enabled (a fixed container height is required).
> - For large datasets served from a remote endpoint, bind the Data Grid through [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) with a suitable adaptor such as [ODataV4Adaptor](https://blazor.syncfusion.com/documentation/datagrid/connecting-to-adaptors/odatav4-adaptor), [WebApiAdaptor](https://blazor.syncfusion.com/documentation/datagrid/connecting-to-adaptors/web-api-adaptor), [UrlAdaptor](https://blazor.syncfusion.com/documentation/datagrid/connecting-to-adaptors/url-adaptor), or [CustomAdaptor](https://blazor.syncfusion.com/documentation/datagrid/connecting-to-adaptors/custom-adaptor). For more details and examples, refer to [Remote data binding](remote-data.md).

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

{% previewsample "https://blazorplayground.syncfusion.com/embed/VtLdZQDgIhNFteKy?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" %}

## Number of blocks rendered during initial loading

At initial load, the Data Grid renders a specified number of data blocks. The rendered row count is equal to the [InitialBlocks](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridInfiniteScrollSettings.html#Syncfusion_Blazor_Grids_GridInfiniteScrollSettings_InitialBlocks) value multiplied by the [PageSize](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridPageSettings.html#Syncfusion_Blazor_Grids_GridPageSettings_PageSize) value. The `InitialBlocks` value can also be reconfigured at runtime through the `GridInfiniteScrollSettings` to change how many blocks render on the next refresh.

Configure this setting through [InitialBlocks](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridInfiniteScrollSettings.html#Syncfusion_Blazor_Grids_GridInfiniteScrollSettings_InitialBlocks) on [GridInfiniteScrollSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridInfiniteScrollSettings.html). The default value is three blocks. After the initial load, additional data is buffered and loaded based on the page size or the number of rows that fit in the current height.

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

{% previewsample "https://blazorplayground.syncfusion.com/embed/VXrxNcNUeLCWkTqi?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" %}

## Efficient data caching and DOM management in Data Grid cache mode

In Blazor Data Grid cache mode, the Data Grid reuses the rendered DOM row elements of previously loaded blocks when those blocks are scrolled back into view, in addition to avoiding repeat data requests. The Data Grid manages the number of rendered DOM row elements using [GridInfiniteScrollSettings.MaximumBlocks](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridInfiniteScrollSettings.html#Syncfusion_Blazor_Grids_GridInfiniteScrollSettings_MaximumBlocks). When this limit is reached, the Data Grid removes an older block of row elements to render new ones.

Enable cache mode by setting [EnableCache](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridInfiniteScrollSettings.html#Syncfusion_Blazor_Grids_GridInfiniteScrollSettings_EnableCache) to **true** on [GridInfiniteScrollSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridInfiniteScrollSettings.html).

Configure the maximum cached blocks with `MaximumBlocks` (**default: 3**).

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons

<div style="display:flex; margin-bottom:5px">
    <label> Enable or Disable Cache mode:</label>
    <SfSwitch ValueChange="Change" TChecked="bool"></SfSwitch>
</div>
<SfGrid @ref="Grid" DataSource="@TaskData" Height="300" /EnableInfiniteScrolling="true">
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/BXBdNwDgIBWfxSsV?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" %}

## Limitations

* Due to browser element height limitations, the maximum number of records the Data Grid can load is constrained by browser capabilities.
* A static height must be set for the component or its parent container when using infinite scrolling. Using 100% height works only if both the Data Grid and its parent have explicit heights.
* The combined height of the initially loaded rows must exceed the viewport height for content to scroll. If the vertical scrollbar does not appear, increase the [PageSize](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridPageSettings.html#Syncfusion_Blazor_Grids_GridPageSettings_PageSize) or [InitialBlocks](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridInfiniteScrollSettings.html#Syncfusion_Blazor_Grids_GridInfiniteScrollSettings_InitialBlocks) value so that more rows are loaded on first render, or reduce the Grid's container [Height](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_Height) so the viewport is smaller relative to the rendered rows.
* With infinite scrolling, copy-paste and drag-and-drop apply only to items within the current viewport.
* Cell selection is not persisted in cache mode.
* Group records cannot be collapsed in cache mode.
* Lazy load grouping with infinite scrolling does not support cache mode; infinite scrolling applies only to parent-level caption rows in this scenario.
* In normal grouping, infinite scrolling is not supported for child items during expand/collapse; all child items load when caption rows are toggled.
* Aggregates and total group items reflect the current view items; this is expected with on-demand data loading.
* Programmatic selection using [SelectRowsAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_SelectRowsAsync_System_Int32___) and [SelectRowAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_SelectRowAsync_System_Int32_System_Nullable_System_Boolean__System_Boolean_) is not supported in infinite scrolling.
* Infinite scrolling is not compatible with:
    1. Batch editing
    2. Inline (normal) editing
    3. Row template
    4. Row virtual scrolling
    5. Detail template
    6. Hierarchy features
    7. Autofill
* Limitations of row drag and drop with infinite scrolling:
    1. In cache mode, the Data Grid refreshes automatically if the number of content `<tr>` elements exceeds the cache limit after the drop action.
    2. With lazy load grouping, the Data Grid refreshes automatically after row drag and drop.
    3. For remote data, changes from drag and drop are applied only in the UI and are lost after refresh unless persisted to the server. Use the [RowDropped](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_RowDropped) event to commit changes server-side, then refresh the Grid.

## See also

* [Virtual scrolling in Data Grid](virtual-scrolling.md)
* [Paging in Data Grid](paging.md)
* [Infinite scrolling with Lazy load grouping in Data Grid](https://blazor.syncfusion.com/documentation/datagrid/lazy-load-grouping#lazy-load-grouping-with-infinite-scrolling)