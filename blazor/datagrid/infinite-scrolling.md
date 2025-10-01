---
layout: post
title: Infinite Scrolling in Blazor DataGrid | Syncfusion
description: Learn how to implement Infinite Scrolling in Syncfusion Blazor DataGrid and explore more advanced features and customization options.
platform: Blazor
control: DataGrid
documentation: ug
---

# Infinite scroll in Blazor DataGrid

The infinite scrolling feature in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid provides load-on-demand data retrieval to handle large datasets without degrading performance. In default infinite scrolling, the Grid fetches the next block of data when the vertical scrollbar reaches the end of the scroller, creating a seamless browsing experience across extensive data.

In this feature, a block is equivalent to the Grid’s [PageSize](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridPageSettings.html#Syncfusion_Blazor_Grids_GridPageSettings_PageSize). If `PageSize` is not set, the Grid calculates it from the viewport height and row height. To enable infinite scrolling, set [EnableInfiniteScrolling](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_EnableInfiniteScrolling) to true and define a content [Height](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_Height).

> - With this feature, the Grid does not issue a new data request when revisiting a previously loaded page.
> - The `Height` property must be specified when `EnableInfiniteScrolling` is enabled (a fixed container height is required).

The following is an example that demonstrates how to enable infinite scroll in the Grid:

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

At initial load, the Grid renders a specified number of data blocks (pages), which equates to the `InitialBlocks` value multiplied by the page size.

Configure this using [InitialBlocks](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridInfiniteScrollSettings.html) on [GridInfiniteScrollSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridInfiniteScrollSettings.html). By default, three pages are rendered initially. Afterwards, additional data is buffered and loaded based on page size or the number of rows that fit within the given height.

The following example shows how to set the `initial blocks `based on a `DropDownList` selection:

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

## Efficient data caching and DOM management in Grid cache mode

In Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid cache mode, previously loaded blocks are reused when revisited, reducing repeat data requests. The Grid manages the number of rendered DOM row elements using [GridInfiniteScrollSettings.MaximumBlocks](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridInfiniteScrollSettings.html#Syncfusion_Blazor_Grids_GridInfiniteScrollSettings_MaximumBlocks). When this limit is reached, the Grid removes an older block of row elements to render new ones.

Enable cache mode by setting [EnableCache](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridInfiniteScrollSettings.html#Syncfusion_Blazor_Grids_GridInfiniteScrollSettings_EnableCache) to true on [GridInfiniteScrollSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridInfiniteScrollSettings.html).

Configure the maximum cached blocks with `MaximumBlocks` (default: 3).

The following example toggles cache mode using a Switch component and updates the Grid accordingly:

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

* Due to browser element height limitations, the maximum number of records the Grid can load is constrained by browser capabilities.
* A static height must be set for the component or its parent container when using infinite scrolling. Using 100% height works only if both the Grid and its parent have explicit heights.
* The combined height of the initially loaded rows must exceed the viewport height for content to scroll.
* With infinite scrolling, copy-paste and drag-and-drop apply only to items within the current viewport.
* Cell selection is not persisted in cache mode.
* Group records cannot be collapsed in cache mode.
* Lazy load grouping with infinite scrolling does not support cache mode; infinite scrolling applies only to parent-level caption rows in this scenario.
* In normal grouping, infinite scrolling is not supported for child items during expand/collapse; all child items load when caption rows are toggled.
* Aggregates and total group items reflect the current view items; this is expected with on-demand data loading.
* Programmatic selection using [SelectRowsAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_SelectRowsAsync_System_Int32___) and [SelectRowAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_SelectRowAsync_System_Int32_System_Nullable_System_Boolean__) is not supported in infinite scrolling.
* Infinite scrolling is not compatible with:
    1. Batch editing
    2. Normal editing
    3. Row template
    4. Row virtual scrolling
    5. Detail template
    6. Hierarchy features
    7. Autofill
* Limitations of row drag and drop with infinite scrolling:
    1. In cache mode, the Grid refreshes automatically if the number of content `<tr>` elements exceeds the cache limit after the drop action.
    2. With lazy load grouping, the Grid refreshes automatically after row drag and drop.
    3. For remote data, changes from drag and drop are applied only in the UI and are lost after refresh unless persisted to the server. Use the [RowDropped](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_RowDropped) event to commit changes server-side, then refresh the Grid.

## See also

* [Infinite scrolling with Lazy load grouping in Grid](https://blazor.syncfusion.com/documentation/datagrid/lazy-load-grouping#lazy-load-grouping-with-infinite-scrolling)