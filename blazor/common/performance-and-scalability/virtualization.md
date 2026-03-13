---
layout: post
title: Virtualization in Blazor — Syncfusion
description: Learn how Syncfusion Blazor components use UI virtualization to render only visible content for smooth scrolling and fast load times with large data.
platform: Blazor
control: Common
documentation: ug
---

# Virtualization in Syncfusion® Blazor Components

## Overview

Virtualization improves performance by rendering only the UI elements that are visible in the viewport and reusing DOM elements during scrolling. This reduces initial render time, memory usage, and DOM size, resulting in smooth scrolling and responsive interactions even with very large datasets.

### Components Supporting Virtualization

* **DataGrid** – Supports Row virtualization, column virtualization, buffered rendering (overscan), virtual loading placeholders (mask row), frozen columns with virtualization, and infinite scrolling.
* **ListView** – Supports UI virtualization with window or container scrolling modes.
* **File Manager** – Supports UI virtualization in both **Details** and **Large Icons** views.

N> A few more components also support virtualization, but only key examples are listed here.

### Advantages of Virtualization

| Benefit              | Explanation                                       |
|----------------------|---------------------------------------------------|
| Faster initial load  | Renders only the items visible in the viewport    |
| Reduced DOM size     | Keeps the DOM size small and reduces memory usage |
| Smoother scrolling   | Reuses DOM elements to avoid frequent reflows     |
| Scalable             | Performs well with tens of thousands of records   |

### Types of Virtualization

| Type                  | Components            | Description                                                            |
|-----------------------|-----------------------|------------------------------------------------------------------------|
| UI Virtualization     | ListView, File Manager| Renders only visible items; others are removed or reused               |
| Row Virtualization    | DataGrid              | Renders rows in the viewport and loads more during vertical scrolling  |
| Column Virtualization | DataGrid              | Renders columns in view and loads more during horizontal scrolling     |
| Infinite Scrolling    | DataGrid              | Loads additional data blocks when the end of the content is reached    |

## DataGrid Virtualization

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid supports advanced virtualization features including row virtualization, column virtualization, overscan buffering, loading placeholders, frozen columns with virtualization, and infinite scrolling.

### Row Virtualization

Row virtualization improves grid performance when working with large datasets by rendering only the rows that are visible in the viewport. As you scroll vertically, the DataGrid loads and reuses rows instead of creating every row at once. This reduces initial load time, lowers memory usage, and keeps scrolling smooth.

### Configure Row Virtualization

To use row virtualization:

* Set `EnableVirtualization="true"` on the grid.
* Assign a fixed pixel Height (for example, Height="300").
* (Optional) Use `PageSize` to control the size of each data block.
* Ensure all rows have the same height by avoiding text wrapping or variable-height templates.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@TaskData" Height="300" EnableVirtualization="true">
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
        TaskData = TaskDetails.GenerateData(1000);
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

### Row Virtualization Limitations

* Features like batch editing, detail templates, row templates, and autofill are not supported.
* Copy/paste and drag operations work only on rows currently visible in the viewport.
* Individual cell selection is not supported.
* All rows must have a fixed, identical height.
* Group expand/collapse states are not preserved unless `PersistGroupState` is enabled.
* Text wrapping is not allowed because row height must remain consistent.
* Some browsers limit maximum scrollable height, which may affect extremely large datasets.

### Column Virtualization

Column virtualization improves performance when a DataGrid contains many columns. Instead of rendering all columns at once, the grid renders only the columns currently visible in the viewport. As you scroll horizontally, the next set of columns loads automatically. This results in faster rendering, lower memory usage, and smoother scrolling.

### Configure Column Virtualization

To use column virtualization:

* Set `EnableColumnVirtualization="true"` on the grid.
* Assign a fixed pixel width to each column using the `Width` property.
* Avoid percentage‑based widths, as they are not supported.
* If no width is defined, the grid uses the default width of `200px`.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@GridData" Height="300" EnableColumnVirtualization="true">
    <GridColumns>
        <GridColumn Field="@nameof(VirtualData.SNo)"  Width="140" />
        <GridColumn Field="@nameof(VirtualData.Name)" Width="150" />
        <GridColumn Field="@nameof(VirtualData.Year)" Width="120" />
    </GridColumns>
</SfGrid>


@code {
    public List<VirtualData> GridData { get; set; } = VirtualData.GenerateData();
}
{% endhighlight %}

{% highlight cs tabtitle="VirtualData.cs" %}
public class VirtualData
{
    public int SNo { get; set; }
    public string Name { get; set; }
    public int Year { get; set; }

    public static List<VirtualData> GenerateData()
    {
        var list = new List<VirtualData>();
        for (int i = 1; i <= 1000; i++)
            list.Add(new VirtualData { SNo = i, Name = "Player " + i, Year = 2000 + (i % 20) });
        return list;
    }
}
{% endhighlight %}
{% endtabs %}

### Column Virtualization Limitations

* Cell selection is not supported.
* The **Ctrl + Home** and **Ctrl + End** keyboard shortcuts do not work.
* Features that work only inside the visible area (viewport):
  * Column resizing
  * Column chooser
  * Auto-fit
  * Clipboard
  * Column menu
* Features that are NOT compatible with column virtualization:
  * Grouping
  * Batch editing
  * Column virtualization cannot be combined with infinite scrolling
  * Stacked headers
  * Row template / detail template
  * Hierarchy grid
  * Autofill

### Overscan (Buffered Rendering)

Overscan makes scrolling smoother by rendering a few extra rows above and below the visible area of the grid. These extra rows act as a buffer so the grid does not need to frequently update the DOM while you scroll. This reduces flickering and helps the grid feel more responsive.

### Configure Overscan

To use overscan:

* Set the `OverscanCount` property to control how many extra rows should be rendered above and below the visible area.
* Use a higher value for smoother scrolling, especially with fast scroll actions.
* Use a lower value if you want to minimize memory usage and keep the DOM size small.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@OrderData" Height="315" OverscanCount="5" EnableVirtualization="true" EnableColumnVirtualization="true">
    <GridPageSettings PageSize="50"></GridPageSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderDetails.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120" />
        <GridColumn Field=@nameof(OrderDetails.CustomerID) HeaderText="Customer" Width="150" />
        <GridColumn Field=@nameof(OrderDetails.OrderDate) HeaderText="Order Date" Type="ColumnType.Date" Format="d" TextAlign="TextAlign.Right" Width="130" />
        <GridColumn Field=@nameof(OrderDetails.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120" />
    </GridColumns>
</SfGrid>

@code {
    public List<OrderDetails> OrderData { get; set; }

    protected override void OnInitialized()
    {
        OrderData = OrderDetails.GetAllRecords(1000);
    }
}
{% endhighlight %}

{% highlight cs tabtitle="OrderDetails.cs" %}
public class OrderDetails
{
    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal Freight { get; set; }

    public static List<OrderDetails> GetAllRecords(int count)
    {
        var list = new List<OrderDetails>();
        var rnd = new Random(1);
        for (int i = 1; i <= count; i++)
        {
            list.Add(new OrderDetails
            {
                OrderID = i,
                CustomerID = "CUS-" + (1000 + i),
                OrderDate = DateTime.Today.AddDays(-i),
                Freight = Math.Round((decimal)rnd.NextDouble() * 500m, 2)
            });
        }
        return list;
    }
}
{% endhighlight %}
{% endtabs %}

N> The `OverscanCount` property supports both local and remote data.

### VirtualMaskRow (Loading Placeholders)

VirtualMaskRow shows placeholder cells while the grid loads new data during virtualization. This helps users understand that data is still being fetched, especially with large datasets or when scrolling triggers data loads.

When `VirtualMaskRow` is enabled, the grid reuses existing DOM elements and displays placeholders until real data becomes available.

### Configure VirtualMaskRow

To show loading placeholders:

* Set `EnableVirtualMaskRow="true"`.
* Row virtualization (EnableVirtualization) or column virtualization (EnableColumnVirtualization) must be enabled for this feature.
* For the best results, set both `PageSize` and `RowHeight` so the grid can calculate loading areas correctly.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@OrderData" Height="400" RowHeight="38" EnableVirtualMaskRow="true" EnableVirtualization="true" EnableColumnVirtualization="true">
    <GridPageSettings PageSize="32"></GridPageSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderDetails.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120" />
        <GridColumn Field=@nameof(OrderDetails.CustomerID) HeaderText="Customer" Width="150" />
        <GridColumn Field=@nameof(OrderDetails.OrderDate) HeaderText="Order Date" Type="ColumnType.Date" Format="d" TextAlign="TextAlign.Right" Width="130" />
        <GridColumn Field=@nameof(OrderDetails.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120" />
    </GridColumns>
</SfGrid>

@code {
    public List<OrderDetails> OrderData { get; set; }

    protected override void OnInitialized()
    {
        // Load a sufficiently large set to experience virtualization & placeholders.
        OrderData = OrderDetails.GetAllRecords(1000);
    }
}
{% endhighlight %}

{% highlight cs tabtitle="OrderDetails.cs" %}
public class OrderDetails
{
    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal Freight { get; set; }

    public static List<OrderDetails> GetAllRecords(int count)
    {
        var list = new List<OrderDetails>();
        var rnd = new Random(1);

        for (int i = 1; i <= count; i++)
        {
            list.Add(new OrderDetails
            {
                OrderID = i,
                CustomerID = "CUS-" + (1000 + i),
                OrderDate = DateTime.Today.AddDays(-i),
                Freight = Math.Round((decimal)rnd.NextDouble() * 500m, 2)
            });
        }

        return list;
    }
}

{% endhighlight %}
{% endtabs %}

### Frozen Columns with Virtualization

Frozen columns in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid allow certain columns to stay fixed while the rest of the columns scroll horizontally. When combined with virtualization, the grid renders only the rows and columns that are currently visible, while the frozen columns remain in place on the left or right side. This helps improve performance without affecting usability.

### Configure Frozen Columns with Virtualization

To use frozen columns with virtualization:

* Set `IsFrozen="true"` on the columns you want to freeze.
* Use `Freeze="Left"` or `Freeze="Right"` to choose the freeze direction.
* Enable row virtualization using `EnableVirtualization="true"`.
* Enable column virtualization using `EnableColumnVirtualization="true"`.
* Assign a fixed pixel width to every column (required for column virtualization).
* Use a fixed grid `height` to maintain smooth row virtualization.


{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Players" Height="320"
        EnableVirtualization="true"
        EnableColumnVirtualization="true">
    <GridColumns>
        <GridColumn Field=@nameof(PlayerDetails.PlayerName) HeaderText="Player" IsFrozen="true" Freeze="FreezeDirection.Left" Width="140" />
        <GridColumn Field=@nameof(PlayerDetails.Rank) HeaderText="Rank" TextAlign="TextAlign.Right" Width="120" />
        <GridColumn Field=@nameof(PlayerDetails.Country) HeaderText="Country" Width="150" />
        <GridColumn Field=@nameof(PlayerDetails.Age) HeaderText="Age" TextAlign="TextAlign.Right" Width="100" />
        <GridColumn Field=@nameof(PlayerDetails.Points) HeaderText="Points" TextAlign="TextAlign.Right" Width="120" />
    </GridColumns>
</SfGrid>

@code {
    public List<PlayerDetails> Players { get; set; }

    protected override void OnInitialized()
    {
        Players = PlayerDetails.GenerateData(2000);
    }
}
{% endhighlight %}

{% highlight cs tabtitle="PlayerDetails.cs" %}
public class PlayerDetails
{
    public string PlayerName { get; set; }
    public int Rank { get; set; }
    public string Country { get; set; }
    public int Age { get; set; }
    public int Points { get; set; }

    public static List<PlayerDetails> GenerateData(int count)
    {
        var list = new List<PlayerDetails>();
        var rnd = new Random(2);
        string[] countries = { "USA", "UK", "IND", "AUS", "CAN", "GER", "FRA" };
        for (int i = 1; i <= count; i++)
        {
            list.Add(new PlayerDetails
            {
                PlayerName = "Player " + i,
                Rank = i,
                Country = countries[i % countries.Length],
                Age = 18 + (i % 20),
                Points = 1000 + rnd.Next(0, 5000)
            });
        }
        return list;
    }
}
{% endhighlight %}
{% endtabs %}

### Infinite Scrolling

Infinite scrolling allows the DataGrid to load more data automatically as you scroll downward. Instead of loading all records at once, the grid loads data in blocks, which keeps performance fast and scrolling smooth even with very large datasets.

### Configure Infinite Scrolling

To use infinite scrolling:

* Set `EnableInfiniteScrolling="true"` on the grid.
* Assign a fixed pixel `height` to the grid (for example, Height="300").
* Use `PageSize` to control how many rows load in each block.

### Infinite Scrolling Limitations

* Requires a fixed grid height for proper block calculation.
* Grouping, batch editing, and Row virtualization cannot be used with infinite scrolling.
* Rows must have a consistent height for accurate block loading.
* Data loads only when scrolling reaches the bottom of the viewport.

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

## ListView Virtualization

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor ListView supports UI virtualization which renders only the items visible in the viewport. This improves performance when working with large datasets.

### Configure ListView Virtualization

Virtualization can be enabled using the `EnableVirtualization="true"` property.

```html

@using Syncfusion.Blazor.Lists

<SfListView DataSource="@ListData" EnableVirtualization="true">
    <ListViewFieldSettings TValue="DataModel" Id="Id" Text="Text"></ListViewFieldSettings>
</SfListView>

@code{
    List<DataModel> ListData = new List<DataModel>();

    protected override void OnInitialized()
    {
        base.OnInitialized();
        ListData.Add(new DataModel { Text = "Nancy", Id = "0" });
        ListData.Add(new DataModel { Text = "Andrew", Id = "1" });
        ListData.Add(new DataModel { Text = "Janet", Id = "2" });
        ListData.Add(new DataModel { Text = "Margaret", Id = "3" });
        ListData.Add(new DataModel { Text = "Steven", Id = "4" });
        ListData.Add(new DataModel { Text = "Laura", Id = "5" });
        ListData.Add(new DataModel { Text = "Robert", Id = "6" });
        ListData.Add(new DataModel { Text = "Michael", Id = "7" });
        ListData.Add(new DataModel { Text = "Albert", Id = "8" });
        ListData.Add(new DataModel { Text = "Nolan", Id = "9" });

        for (int i = 10; i < 1000; i++)
        {
            int index = new Random().Next(0, 10);
            ListData.Add(new DataModel
            {
                Text = ListData[index].GetType().GetProperty("Text").GetValue(ListData[index], null).ToString(),
                Id = i.ToString()
            });
        }
    }

    public class DataModel
    {
        public string Id { get; set; }
        public string Text { get; set; }
    }
}

```

### Scroll Modes

ListView offers two scrolling behaviors when virtualization is enabled:

1. Window Scroll (Default)
   * Used automatically when no Height is specified.
   * Scrolling is controlled by the browser window.
2. Container Scroll
   * Activated when a pixel‑based Height is defined.
   * The ListView scrolls inside its own container instead of the window.

### ListView Virtualization Limitations

Requires a pixel-based `height`. Percentage heights are not supported unless the ListView is placed inside a fixed-height parent container.

## File Manager Virtualization

The Syncfusion<sup style="font-size:70%">&reg;</sup> File Manager supports UI virtualization to efficiently load large numbers of files and folders without affecting performance. It renders only the items visible in the viewport, enabling smooth navigation even when directories contain thousands of entries. Virtualization works in both Details and Large Icons views.

The component determines which items to display based on the **height** and **width** of the viewport. As the user scrolls, the File Manager loads additional files and folders according to the available visible area.

### Configure File Manager Virtualization

To enable virtualization, set the `EnableVirtualization` property to `true`. The example below demonstrates virtualization applied in the Details view

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.FileManager

<SfFileManager TValue="FileManagerDirectoryContent"
               View="ViewType.Details"
               EnableVirtualization="true">
    <FileManagerAjaxSettings Url="https://ej2-aspcore-service.azurewebsites.net/api/Virtualization/FileOperations"
                             UploadUrl="https://ej2-aspcore-service.azurewebsites.net/api/Virtualization/Upload"
                             DownloadUrl="https://ej2-aspcore-service.azurewebsites.net/api/Virtualization/Download"
                             GetImageUrl="https://ej2-aspcore-service.azurewebsites.net/api/Virtualization/GetImage">
    </FileManagerAjaxSettings>
</SfFileManager>
{% endhighlight %}
{% endtabs %}

### File Manager Virtualization Limitations

* Programmatic selection using `SelectAllAsync` is not supported when virtualization is enabled.
* Pressing `CTRL + A` selects only the files and folders currently visible in the viewport, not all items in the directory.
* Selected items are not preserved while scrolling or when switching between views, to maintain optimal performance.

## See Also

For complete working examples, detailed explanations, and additional configuration options, refer to the following documentation pages.

* [DataGrid – Virtual Scrolling & Virtualization](https://blazor.syncfusion.com/documentation/datagrid/virtual-scrolling)
* [DataGrid – Infinite Scrolling](https://blazor.syncfusion.com/documentation/datagrid/infinite-scrolling)
* [ListView – Virtualization](https://blazor.syncfusion.com/documentation/listview/virtualization)
* [File Manager – Virtualization](https://blazor.syncfusion.com/documentation/file-manager/virtualization)
