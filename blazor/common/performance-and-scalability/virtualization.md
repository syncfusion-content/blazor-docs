---
layout: post
title: Virtualization in Blazor — Syncfusion
description: Learn how Syncfusion Blazor components use UI, row & column virtualization, Overscan, virtual placeholders, frozen columns, and infinite scrolling for large datasets.
platform: Blazor
control: Common
documentation: ug
---

# Virtualization in Syncfusion® Blazor Components

## Overview

Virtualization improves the overall performance of Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components by rendering only the elements that are visible in the viewport. Instead of creating all items at once, the framework reuses DOM elements while the user scrolls.

This approach helps reduce the initial loading time and lowers memory usage. It also keeps the DOM smaller, which leads to smoother scrolling and more responsive interactions.

With virtualization enabled, large datasets feel easier and faster to work with, even when they contain thousands of records.

## Prerequisites and Setup

Make sure your development environment meets the [system requirements](https://blazor.syncfusion.com/documentation/system-requirements) for Syncfusion® Blazor components.

All examples in this document are based on a Blazor Server application.

**1. Install the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor NuGet packages**

Run the following commands to install the required NuGet packages:
* [Syncfusion.Blazor.Grid](https://www.nuget.org/packages/Syncfusion.Blazor.Grid) 
* [Syncfusion.Blazor.Lists](https://www.nuget.org/packages/Syncfusion.Blazor.Lists/)
* [Syncfusion.Blazor.FileManager](https://www.nuget.org/packages/Syncfusion.Blazor.FileManager) 
* [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/)
   
{% tabs %}
{% highlight c# tabtitle="Package Manager" %}

dotnet add package Syncfusion.Blazor.Grid -v {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Lists -v {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.FileManager -v {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Themes -v {{ site.releaseversion }}
dotnet restore

{% endhighlight %}
{% endtabs %}
    
**2. Add the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Service in the ~/Program.cs file of your Blazor Server App.**

{% tabs %}
{% highlight c# tabtitle=".NET 8/.NET 9/.NET 10 (~/Program.cs) Server" hl_lines="3 10" %}
....
....
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
....
....
builder.Services.AddSyncfusionBlazor();

....
{% endhighlight %}
{% endtabs %}

**3. Add stylesheet and script resources in the App.razor file of your Blazor Server App.**

{% tabs %}
{% highlight html hl_lines="4 10" %}

<head>
    ....
    <!-- Syncfusion theme style sheet -->
    <link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />
</head>

<body>
    ....
    <!-- Syncfusion Blazor Core script -->
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
</body>

{% endhighlight %}
{% endtabs %}

**4. Add Syncfusion<sup style="font-size:70%">&reg;</sup> namespaces in the server project's ~/Components/_Imports.razor file.**

{% tabs %}
{% highlight razor tabtitle="~/_Imports.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Lists
@using Syncfusion.Blazor.FileManager

{% endhighlight %}
{% endtabs %}

## Components Supporting Virtualization

The following major Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components provide built‑in virtualization support to efficiently handle large datasets.

* **DataGrid** – Supports Row virtualization, column virtualization, buffered rendering (Overscan), virtual loading placeholders (mask row), frozen columns with virtualization, and infinite scrolling.
* **ListView** – Supports UI virtualization with window or container scrolling modes.
* **File Manager** – Supports UI virtualization in both Details and Large Icons views.
* **TreeView** – Provides UI virtualization to render only visible nodes, significantly boosting performance in large hierarchical structures.  
* **Gantt Chart** – Includes row virtualization, timeline virtualization, and column virtualization to efficiently render large project schedules and complex timelines. 
* **TreeGrid** – Offers row virtualization, column virtualization, and cell placeholders (VirtualMaskRow) for smoother loading with large hierarchical data.

## Advantages of Virtualization

| Benefit              | Explanation                                       |
|----------------------|---------------------------------------------------|
| Faster initial load  | Renders only the items visible in the viewport    |
| Reduced DOM size     | Keeps the DOM size small and reduces memory usage |
| Smoother scrolling   | Reuses DOM elements to avoid frequent reflows     |
| Scalable             | Performs well with tens of thousands of records   |

## Types of Virtualization

| Type                              | Components                      | Description                                                                                                     |
|-----------------------------------|---------------------------------|-----------------------------------------------------------------------------------------------------------------|
| UI Virtualization                 | ListView, File Manager, TreeView| Renders only the visible items                                                                                  |
| Row Virtualization                | DataGrid, Gantt Chart, TreeGrid | Renders rows in the viewport and loads more during vertical scrolling                                           |
| Column Virtualization             | DataGrid, Gantt Chart, TreeGrid | Renders columns in view and loads more during horizontal scrolling                                              |
| Timeline Virtualization           | Gantt Chart                     | Virtualizes timeline segments (time units) to efficiently render large project timelines                        |
| Cell Placeholder (VirtualMaskRow) | DataGrid, TreeGrid              | Shows placeholder cells while fetching or rendering virtualized content, improving perceived loading smoothness |
| Infinite Scrolling                | DataGrid                        | Loads additional data blocks when the end of the content is reached                                             |

## DataGrid Virtualization

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid supports several virtualization features that help it handle large datasets efficiently. These include row virtualization, column virtualization, Overscan buffering, loading placeholders, frozen columns with virtualization, and infinite scrolling. Together, these features make the grid faster, smoother, and more responsive when working with large amounts of data.

### Row Virtualization

Row virtualization improves performance by rendering only the rows that are visible in the viewport. Instead of creating all rows at once, the DataGrid loads and reuses rows while you scroll vertically. This reduces the initial loading time, lowers memory usage, and keeps scrolling smooth.

#### Configure Row Virtualization

To enable row virtualization:

* Set [EnableVirtualization](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_EnableVirtualization) to **true** on the grid.
* Assign a fixed pixel [Height](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_Height) (for example, Height="300").
* Use [PageSize](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridPageSettings.html#Syncfusion_Blazor_Grids_GridPageSettings_PageSize) to control how many rows load in each block.
* Make sure all rows have the same height. Avoid text wrapping or templates that create different row sizes.

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

### Column Virtualization

Column virtualization improves performance when the DataGrid has many columns. Only the columns that are currently visible in the viewport are rendered. As you scroll horizontally, additional columns load automatically. This results in faster rendering, lower memory usage, and smoother horizontal scrolling.

#### Configure Column Virtualization

To enable column virtualization:

* Set [EnableColumnVirtualization](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_EnableColumnVirtualization) to **true** on the grid.
* Assign a fixed pixel [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Width) to every column.
* Avoid percentage‑based widths.
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

### Overscan (Buffered Rendering)

Overscan makes scrolling smoother by rendering a few extra rows above and below the visible area of the grid. These extra rows act as a buffer so the grid does not need to frequently update the DOM while you scroll. This reduces flickering and helps the grid feel more responsive.

#### Configure Overscan

To configure Overscan:

* Set the [OverscanCount](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_OverscanCount) to control how many extra rows should be rendered above and below the visible area.
* Use a higher value for smoother scrolling during fast scroll actions.
* Use a lower value if you want to minimize memory usage.

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

#### Configure VirtualMaskRow

To show loading placeholders:

* Set [EnableVirtualMaskRow](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_EnableVirtualMaskRow) to **true**.
* Enable Row virtualization ([EnableVirtualization](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_EnableVirtualization)) or column virtualization ([EnableColumnVirtualization](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_EnableColumnVirtualization)).
* For the best results, set both [PageSize](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridPageSettings.html#Syncfusion_Blazor_Grids_GridPageSettings_PageSize) and [RowHeight](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_RowHeight).

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

Frozen columns remain fixed on the left or right side of the grid while the rest of the columns scroll horizontally. When used with virtualization, the grid renders only visible rows and columns, but the frozen columns stay in place. This improves performance without affecting usability.

#### Configure Frozen Columns with Virtualization

To use frozen columns:

* Set [IsFrozen](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_IsFrozen) on the columns you want to freeze.
* Set [GridColumn.Freeze](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Freeze) to Left or Right.
* Enable both row and column virtualization using [EnableVirtualization](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_EnableVirtualization) and [EnableColumnVirtualization](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_EnableColumnVirtualization).
* Assign a fixed width to all columns.
* Use a fixed grid height for smoother virtualization.

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

Infinite scrolling loads additional data automatically as you scroll down. Instead of loading everything at once, the grid loads data in blocks. This keeps performance fast even when working with very large datasets.

#### Configure Infinite Scrolling

To use infinite scrolling:

* Set [EnableInfiniteScrolling](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_EnableInfiniteScrolling) to **true** on the grid.
* Assign a fixed pixel [Height](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_Height) to the grid.
* Set [PageSize](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridPageSettings.html#Syncfusion_Blazor_Grids_GridPageSettings_PageSize) to control how many rows load in each block.


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

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor ListView supports UI virtualization, which helps improve performance when working with large datasets. Instead of rendering all items at once, only the items visible within the viewport are created. This keeps the component responsive and reduces memory usage even when the list contains thousands of records.

#### Configure ListView Virtualization

Virtualization can be enabled by setting the [`EnableVirtualization`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Lists.SfListView-1.html#Syncfusion_Blazor_Lists_SfListView_1_EnableVirtualization) property to **true**.

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

ListView supports two scrolling modes when virtualization is enabled:

**1. Window Scroll (Default)**
This mode is used automatically when no height is specified for the component. Scrolling is controlled by the browser window.

**2. Container Scroll**
This mode is used when you set a fixed pixel height for the ListView. In this case, the component scrolls inside its own container rather than the entire page.

## File Manager Virtualization

The Syncfusion<sup style="font-size:70%">&reg;</sup> File Manager supports UI virtualization to efficiently load large numbers of files and folders without affecting performance. It renders only the items visible in the viewport, enabling smooth navigation even when directories contain thousands of entries. Virtualization works in both Details and Large Icons views.

The component determines which items to display based on the **height** and **width** of the viewport. As the user scrolls, the File Manager loads additional files and folders according to the available visible area.

#### Configure File Manager Virtualization

To enable virtualization, set the [EnableVirtualization](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.SfFileManager-1.html#Syncfusion_Blazor_FileManager_SfFileManager_1_EnableVirtualization) property to **true**. The example below demonstrates virtualization applied in the Details view.

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

### Row Virtualization Limitations

* Features like batch editing, detail templates, row templates, and autofill are not supported.
* Copy/paste and drag operations work only on rows currently visible in the viewport.
* Individual cell selection is not supported.
* All rows must have a fixed, identical height.
* Group expand/collapse states are not preserved unless [GridGroupSettings.PersistGroupState](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridGroupSettings.html#Syncfusion_Blazor_Grids_GridGroupSettings_PersistGroupState) is enabled.
* Text wrapping is not allowed because row height must remain consistent.
* Some browsers limit maximum scrollable height, which may affect extremely large datasets.

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

### Infinite Scrolling Limitations

* Requires a fixed grid height for proper block calculation.
* Batch editing, and Row virtualization cannot be used with infinite scrolling.
* With infinite scrolling, copy-paste and drag-and-drop apply only to items within the current viewport.
* Programmatic selection using `SelectRowsAsync` and `SelectRowAsync` is not supported in infinite scrolling.

### ListView Virtualization Limitations

* Requires a pixel-based `height`. Percentage heights are not supported unless the ListView is placed inside a fixed-height parent container.
* If you prefer to use a percentage value, you can render the component within a div container with a specific pixel value set for height (It will be rendered based on the parent container height).

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
