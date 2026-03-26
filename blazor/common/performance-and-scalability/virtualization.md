---
layout: post
title: Virtualization in Blazor — Syncfusion
description: Learn how Syncfusion Blazor components use row and column virtualization, Overscan, virtual placeholders, frozen columns, and infinite scrolling.
platform: Blazor
control: Common
documentation: ug
---

# Virtualization in Syncfusion® Blazor Components

## Overview

Virtualization improves the overall performance of Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components by rendering only the elements that are visible in the viewport. Instead of creating all items at once, the framework reuses DOM elements while the user scrolls.

This approach helps reduce the initial loading time and lowers memory usage. It also keeps the DOM smaller, which leads to smoother scrolling and more responsive interactions.

With virtualization enabled, large datasets feel easier and faster to work with, even when they contain thousands of records.

## Prerequisites and setup

Make sure your development environment meets the [system requirements](https://blazor.syncfusion.com/documentation/system-requirements) for Syncfusion® Blazor components.

### Create a Blazor web app with Interactive Server

Run the following commands in the **command-line interface (CLI)**.

{% tabs %}
{% highlight c# tabtitle=".NET CLI" %}

dotnet new blazor -o BlazorApp -int Server
cd BlazorApp

{% endhighlight %}
{% endtabs %}

### Install the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor NuGet packages

Run the following commands to install the required Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor NuGet packages:
* [Syncfusion.Blazor.Grid](https://www.nuget.org/packages/Syncfusion.Blazor.Grid) 
* [Syncfusion.Blazor.Lists](https://www.nuget.org/packages/Syncfusion.Blazor.Lists/)
* [Syncfusion.Blazor.FileManager](https://www.nuget.org/packages/Syncfusion.Blazor.FileManager) 
* [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/)
   
{% tabs %}
{% highlight c# tabtitle=".NET CLI" %}

dotnet add package Syncfusion.Blazor.Grid -v {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Lists -v {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.FileManager -v {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Themes -v {{ site.releaseversion }}
dotnet restore

{% endhighlight %}
{% endtabs %}

### Add required namespaces

Add the required Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor namespaces in the **~/_Imports.razor** file.

{% tabs %}
{% highlight razor tabtitle="~/_Imports.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Lists
@using Syncfusion.Blazor.FileManager

{% endhighlight %}
{% endtabs %}
    
### Register Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor service

Add the required Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor service in the **~/Program.cs** file.

{% tabs %}
{% highlight c# tabtitle="Program.cs" hl_lines="2 4" %}
...
using Syncfusion.Blazor;
...
builder.Services.AddSyncfusionBlazor();
....
{% endhighlight %}
{% endtabs %}

### Add stylesheet and script resources

Before adding the stylesheet, ensure that no other Syncfusion<sup style="font-size:70%">&reg;</sup> theme CSS (e.g., bootstrap5.css, material.css) is already referenced to avoid conflicts.

Add the following stylesheet and script references in the **~/App.razor** file. 

{% tabs %}
{% highlight html hl_lines="4 10" %}

<head>
    ....
    <!-- Syncfusion theme stylesheet -->
    <link href="_content/Syncfusion.Blazor.Themes/fluent2.css" rel="stylesheet" />
</head>

<body>
    ....
    <!-- Syncfusion Blazor Core script -->
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
</body>

{% endhighlight %}
{% endtabs %}

### Configure render mode

For Server render mode, if your app's interactivity location is set to `Per page/component`, add the following directive at the top of each **~Pages/*.razor** file that requires interactive Server components.

**Per‑page directive (Server)**

{% tabs %}
{% highlight razor %}

@* Define the desired render mode here *@
@rendermode InteractiveServer

{% endhighlight %}
{% endtabs %}

## Components supporting virtualization

The following major Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components provide built‑in virtualization support to efficiently handle large datasets.

* **[DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid)** – Supports Row virtualization, column virtualization, buffered rendering (Overscan), virtual loading placeholders (mask row), frozen columns with virtualization, and infinite scrolling.
* **[ListView](https://www.syncfusion.com/blazor-components/blazor-listview)** – Supports UI virtualization with window or container scrolling modes.
* **[File Manager](https://www.syncfusion.com/blazor-components/blazor-file-manager)** – Supports UI virtualization in both Details and Large Icons views.
* **[TreeView](https://www.syncfusion.com/blazor-components/blazor-treeview)** – Provides UI virtualization to render only visible nodes, significantly boosting performance in large hierarchical structures.  
* **[Gantt Chart](https://www.syncfusion.com/blazor-components/blazor-gantt-chart)** – Includes row virtualization, timeline virtualization, and column virtualization to efficiently render large project schedules and complex timelines. 
* **[TreeGrid](https://www.syncfusion.com/blazor-components/blazor-tree-grid)** – Offers row virtualization, column virtualization, and cell placeholders (VirtualMaskRow) for smoother loading with large hierarchical data.

## Advantages of virtualization

| Benefit              | Explanation                                       |
|----------------------|---------------------------------------------------|
| Faster initial load  | Renders only the items visible in the viewport    |
| Reduced DOM size     | Keeps the DOM size small and reduces memory usage |
| Smoother scrolling   | Reuses DOM elements to avoid frequent reflows     |
| Scalable             | Performs well with tens of thousands of records   |

## Types of virtualization

| Type                              | Components                      | Description                                                                                                     |
|-----------------------------------|---------------------------------|-----------------------------------------------------------------------------------------------------------------|
| UI Virtualization                 | ListView, File Manager, TreeView| Renders only the visible items                                                                                  |
| Row Virtualization                | DataGrid, Gantt Chart, TreeGrid | Renders rows in the viewport and loads more during vertical scrolling                                           |
| Column Virtualization             | DataGrid, Gantt Chart, TreeGrid | Renders columns in view and loads more during horizontal scrolling                                              |
| Timeline Virtualization           | Gantt Chart                     | Optimizes timeline segments (time units) to efficiently render large project timelines                          |
| Cell Placeholder (VirtualMaskRow) | DataGrid, TreeGrid              | Shows placeholder cells while fetching or rendering virtualized content, improving perceived loading smoothness |
| Infinite Scrolling                | DataGrid                        | Loads additional data blocks when the end of the content is reached                                             |

## DataGrid virtualization

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid supports several virtualization features that help it handle large datasets efficiently. These include row virtualization, column virtualization, Overscan buffering, loading placeholders, frozen columns with virtualization, and infinite scrolling. Together, these features make the grid faster, smoother, and more responsive when working with large amounts of data.

### Row virtualization

Row virtualization improves performance by rendering only the rows that are visible in the viewport. Instead of creating all rows at once, the DataGrid loads and reuses rows while you scroll vertically. This reduces the initial loading time, lowers memory usage, and keeps scrolling smooth.

#### Configure row virtualization

* Set [EnableVirtualization](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_EnableVirtualization) to **true** on the grid.
* Assign a fixed pixel [Height](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_Height) (for example, Height="300").
* Use [PageSize](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridPageSettings.html#Syncfusion_Blazor_Grids_GridPageSettings_PageSize) to control how many rows load in each block.
* Make sure all rows have the same height. Avoid text wrapping or templates that create different row sizes.

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

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

{% previewsample "https://blazorplayground.syncfusion.com/embed/BXreXrDghESsUlpk?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Column virtualization

Column virtualization improves performance when the DataGrid has many columns. Only the columns that are currently visible in the viewport are rendered. As you scroll horizontally, additional columns load automatically. This results in faster rendering, lower memory usage, and smoother horizontal scrolling.

#### Configure column virtualization

* Set [EnableColumnVirtualization](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_EnableColumnVirtualization) to **true** on the grid.
* Assign a fixed pixel [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Width) to every column.
* Avoid percentage‑based widths.
* If no width is defined, the grid uses the default width of `200px`.

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid DataSource="GridData" Height="300px" EnableColumnVirtualization="true">
    <GridColumns>
        <GridColumn Field=@nameof(VirtualData.SNo) HeaderText="S.No" Width="140"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD1) HeaderText="Player Name" Width="140"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD2) HeaderText="Year" Width="120" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD3) HeaderText="Stint" Width="120" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD4) HeaderText="TMID" Width="120" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD5) HeaderText="LGID" Width="120" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD6) HeaderText="GP" Width="120" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD7) HeaderText="GS" Width="120" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD8) HeaderText="Minutes" Width="120" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD9) HeaderText="Points" Width="120" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD10) HeaderText="oRebounds" Width="130" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD11) HeaderText="dRebounds" Width="130" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD12) HeaderText="Rebounds" Width="120" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD13) HeaderText="Assists" Width="120" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD14) HeaderText="Steals" Width="120" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD15) HeaderText="Blocks" Width="120" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD16) HeaderText="Turnovers" Width="130" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD17) HeaderText="PF" Width="130" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD18) HeaderText="fgAttempted" Width="150" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD19) HeaderText="fgMade" Width="120" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD20) HeaderText="ftAttempted" Width="150" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD21) HeaderText="ftMade" Width="120" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD22) HeaderText="ThreeAttempted" Width="150" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD23) HeaderText="ThreeMade" Width="130" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD24) HeaderText="PostGP" Width="120" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD25) HeaderText="PostGS" Width="120" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD26) HeaderText="PostMinutes" Width="120" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD27) HeaderText="PostPoints" Width="130" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD28) HeaderText="PostoRebounds" Width="130" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD29) HeaderText="PostdRebounds" Width="130" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD30) HeaderText="PostRebounds" Width="130" TextAlign="TextAlign.Right"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<VirtualData> GridData { get; set; }
    protected override void OnInitialized()
    {
        GridData = VirtualData.GenerateData();
    }   
}

{% endhighlight %}

{% highlight cs tabtitle="VirtualData.cs" %}

public class VirtualData
{
    public VirtualData(int sNo, string field1, int field2, int field3, int field4, int field5, int field6, int field7, int field8, int field9, int field10, int field11, int field12, int field13, int field14, int field15, int field16, int field17, int field18, int field19, int field20, int field21, int field22, int field23, int field24, int field25, int field26, int field27, int field28, int field29, int field30)
    {
        SNo = sNo;
        FIELD1 = field1;
        FIELD2 = field2;
        FIELD3 = field3;
        FIELD4 = field4;
        FIELD5 = field5;
        FIELD6 = field6;
        FIELD7 = field7;
        FIELD8 = field8;
        FIELD9 = field9;
        FIELD10 = field10;
        FIELD11 = field11;
        FIELD12 = field12;
        FIELD13 = field13;
        FIELD14 = field14;
        FIELD15 = field15;
        FIELD16 = field16;
        FIELD17 = field17;
        FIELD18 = field18;
        FIELD19 = field19;
        FIELD20 = field20;
        FIELD21 = field21;
        FIELD22 = field22;
        FIELD23 = field23;
        FIELD24 = field24;
        FIELD25 = field25;
        FIELD26 = field26;
        FIELD27 = field27;
        FIELD28 = field28;
        FIELD29 = field29;
        FIELD30 = field30;
    }    
    public static List<VirtualData> GenerateData()
    {
        var virtualData = new List<VirtualData>();
        var random = new Random();
        var names = new[] {
            "hardire", "abramjo01", "aubucch01", "Hook", "Rumpelstiltskin", "Belle", "Emma", "Regina", "Aurora", "Elsa", 
            "Anna", "Snow White", "Prince Charming", "Cora", "Zelena", "August", "Mulan", "Graham", "Discord", "Will", 
            "Robin Hood", "Jiminy Cricket", "Henry", "Neal", "Red", "Aaran", "Aaren", "Aarez", "Aarman", "Aaron", "Aaron-James", 
            "Aarron", "Aaryan", "Aaryn", "Aayan", "Aazaan", "Abaan", "Abbas", "Abdallah", "Abdalroof", "Abdihakim", "Abdirahman", 
            "Abdisalam", "Abdul", "Abdul-Aziz", "Abdulbasir", "Abdulkadir", "Abdulkarem", "Abdulkhader", "Abdullah", 
            "Abdul-Majeed", "Abdulmalik", "Abdul-Rehman", "Abdur", "Abdurraheem", "Abdur-Rahman", "Abdur-Rehmaan", "Abel", 
            "Abhinav", "Abhisumant", "Abid", "Abir", "Abraham", "Abu", "Abubakar", "Ace", "Adain", "Adam", "Adam-James", 
            "Addison", "Addisson", "Adegbola", "Adegbolahan", "Aden", "Adenn", "Adie", "Adil", "Aditya", "Adnan", "Adrian", 
            "Adrien", "Aedan", "Aedin", "Aedyn", "Aeron", "Afonso", "Ahmad", "Ahmed", "Ahmed-Aziz", "Ahoua", "Ahtasham", 
            "Aiadan", "Aidan", "Aiden", "Aiden-Jack", "Aiden-Vee"
        };
        for (var i = 0; i < 1000; i++)
        {
            virtualData.Add(new VirtualData(
                i + 1,
                names[random.Next(names.Length)],
                1967 + (i % 10),
                random.Next(200),
                random.Next(100),
                random.Next(2000),
                random.Next(1000),
                random.Next(100),
                random.Next(10),
                random.Next(10),
                random.Next(100),
                random.Next(100),
                random.Next(1000),
                random.Next(10),
                random.Next(10),
                random.Next(1000),
                random.Next(200),
                random.Next(300),
                random.Next(400),
                random.Next(500),
                random.Next(700),
                random.Next(800),
                random.Next(1000),
                random.Next(2000),
                random.Next(150),
                random.Next(1000),
                random.Next(100),
                random.Next(400),
                random.Next(600),
                random.Next(500),
                random.Next(300)
            ));
        }
        return virtualData;
    }
    public int SNo { get; set; }
    public string FIELD1 { get; set; }
    public int FIELD2 { get; set; }
    public int FIELD3 { get; set; }
    public int FIELD4 { get; set; }
    public int FIELD5 { get; set; }
    public int FIELD6 { get; set; }
    public int FIELD7 { get; set; }
    public int FIELD8 { get; set; }
    public int FIELD9 { get; set; }
    public int FIELD10 { get; set; }
    public int FIELD11 { get; set; }
    public int FIELD12 { get; set; }
    public int FIELD13 { get; set; }
    public int FIELD14 { get; set; }
    public int FIELD15 { get; set; }
    public int FIELD16 { get; set; }
    public int FIELD17 { get; set; }
    public int FIELD18 { get; set; }
    public int FIELD19 { get; set; }
    public int FIELD20 { get; set; }
    public int FIELD21 { get; set; }
    public int FIELD22 { get; set; }
    public int FIELD23 { get; set; }
    public int FIELD24 { get; set; }
    public int FIELD25 { get; set; }
    public int FIELD26 { get; set; }
    public int FIELD27 { get; set; }
    public int FIELD28 { get; set; }
    public int FIELD29 { get; set; }
    public int FIELD30 { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rjLoZWBlzonBSEEX?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Overscan (buffered rendering)

Overscan makes scrolling smoother by rendering a few extra rows above and below the visible area of the grid. These extra rows act as a buffer so the grid does not need to frequently update the DOM while you scroll. This reduces flickering and helps the grid feel more responsive.

#### Configure Overscan

* Set the [OverscanCount](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_OverscanCount) to control how many extra rows should be rendered above and below the visible area.
* Use a higher value for smoother scrolling during fast scroll actions.
* Use a lower value if you want to minimize memory usage.

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@OrderData" Height="315" OverscanCount="5" EnableVirtualization="true" EnableColumnVirtualization="true">
    <GridColumns>
        <GridColumn Field=@nameof(OrderDetails.OrderID) HeaderText="Order ID" IsPrimaryKey="true" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.EmployeeID) HeaderText="Employee ID" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.OrderDate) HeaderText="Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipCountry) HeaderText="Ship Country" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipCity) HeaderText="Ship City" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipAddress) HeaderText="Ship Address" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShippedDate) HeaderText="Shipped Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.Verified) HeaderText="Verified" Type="ColumnType.Boolean" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<OrderDetails> OrderData { get; set; }
    protected override void OnInitialized()
    {
        OrderData = OrderDetails.GetAllRecords();
    }   
}

{% endhighlight %}

{% highlight cs tabtitle="OrderDetails.cs" %}

public class OrderDetails
{
    public static List<OrderDetails> order = new List<OrderDetails>();
    public OrderDetails(int OrderID, string CustomerID, int EmployeeID, DateTime OrderDate, double Freight, string ShipCountry, string ShipCity, string ShipAddress, DateTime ShippedDate, bool Verified)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerID;
        this.EmployeeID = EmployeeID;
        this.OrderDate = OrderDate;
        this.Freight = Freight;
        this.ShipCountry = ShipCountry;
        this.ShipCity = ShipCity;
        this.ShipAddress = ShipAddress;
        this.ShippedDate = ShippedDate;
        this.Verified = Verified;
    }
    public static List<OrderDetails> GetAllRecords()
    {
        if (order.Count == 0)
        {
            int Code = 10247;
            for (int i = 1; i < 500; i++)
            {
                order.Add(new OrderDetails(Code + 1, "VINET", i + 0, new DateTime(1991, 05, 15), 32.38, "Denmark", "Berlin", "Kirchgasse 6", new DateTime(1996, 7, 16), false));
                order.Add(new OrderDetails(Code + 2, "HANAR", i + 2, new DateTime(1990, 04, 04), 58.17, "Brazil", "Madrid", "Avda. Azteca 123", new DateTime(1996, 9, 11), true));
                order.Add(new OrderDetails(Code + 3, "TOMSP", i + 1, new DateTime(1957, 11, 30), 41.34, "Germany", "Cholchester", "Carrera 52 con Ave. Bolívar #65-98 Llano Largo", new DateTime(1996, 10, 7), true));
                order.Add(new OrderDetails(Code + 4, "VICTE", i + 3, new DateTime(1930, 10, 22), 55.09, "Austria", "Marseille", "Magazinweg 7", new DateTime(1996, 12, 30), false));
                order.Add(new OrderDetails(Code + 5, "SUPRD", i + 4, new DateTime(1953, 02, 18), 22.98, "Switzerland", "Tsawassen", "1029 - 12th Ave. S.", new DateTime(1997, 12, 3), true));
                Code += 5;
            }
        }
        return order;
    }
    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public int EmployeeID { get; set; }
    public DateTime OrderDate { get; set; }
    public double Freight { get; set; }
    public string ShipCountry { get; set; }
    public string ShipCity { get; set; }
    public string ShipAddress { get; set; }
    public DateTime ShippedDate { get; set; }
    public bool Verified { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rtBeDLNqVYqUifpB?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

N> The `OverscanCount` property supports both local and remote data.

### VirtualMaskRow (loading placeholders)

VirtualMaskRow shows placeholder cells while the grid loads new data during virtualization. This helps users understand that data is still being fetched, especially with large datasets or when scrolling triggers data loads.

When `VirtualMaskRow` is enabled, the grid reuses existing DOM elements and displays placeholders until real data becomes available.

#### Configure VirtualMaskRow

* Set [EnableVirtualMaskRow](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_EnableVirtualMaskRow) to **true**.
* Enable Row virtualization ([EnableVirtualization](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_EnableVirtualization)) or column virtualization ([EnableColumnVirtualization](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_EnableColumnVirtualization)).
* For the best results, set both [PageSize](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridPageSettings.html#Syncfusion_Blazor_Grids_GridPageSettings_PageSize) and [RowHeight](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_RowHeight).

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

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

### Frozen columns with virtualization

Frozen columns remain fixed on the left or right side of the grid while the rest of the columns scroll horizontally. When used with virtualization, the grid renders only visible rows and columns, but the frozen columns stay in place. This improves performance without affecting usability.

#### Configure frozen columns with virtualization

* Set [IsFrozen](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_IsFrozen) on the columns you want to freeze.
* Set [GridColumn.Freeze](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Freeze) to Left or Right.
* Enable both row and column virtualization using [EnableVirtualization](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_EnableVirtualization) and [EnableColumnVirtualization](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_EnableColumnVirtualization).
* Assign a fixed width to all columns.
* Use a fixed grid height for smoother virtualization.

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid DataSource="GridData" Height="300px" EnableHover="false" RowHeight="38" EnableVirtualization="true" EnableColumnVirtualization="true" EnableVirtualMaskRow="true">
    <GridPageSettings PageSize="40"></GridPageSettings>
    <GridColumns>
        <GridColumn Field=@nameof(VirtualData.FIELD1) HeaderText="Player Name" IsFrozen="true" Freeze="FreezeDirection.Left" Width="140"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD2) HeaderText="Year" Width="120" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD3) HeaderText="Stint" Width="120" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD4) HeaderText="TMID" Width="120" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD5) HeaderText="LGID" Width="120" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD6) HeaderText="GP" Width="120" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD7) HeaderText="GS" Width="120" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD8) HeaderText="Minutes" Width="120" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD9) HeaderText="Points" IsFrozen="true" Freeze="FreezeDirection.Right" Width="120" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD10) HeaderText="oRebounds" Width="130" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD11) HeaderText="dRebounds" Width="130" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD12) HeaderText="Rebounds" Width="120" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD13) HeaderText="Assists" Width="120" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD14) HeaderText="Steals" Width="120" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD15) HeaderText="Blocks" Width="120" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD16) HeaderText="Turnovers" Width="130" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD17) HeaderText="PF" Width="130" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD18) HeaderText="fgAttempted" Width="150" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD19) HeaderText="fgMade" Width="120" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD20) HeaderText="ftAttempted" Width="150" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD21) HeaderText="ftMade" Width="120" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD22) HeaderText="ThreeAttempted" Width="150" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD23) HeaderText="ThreeMade" Width="130" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD24) HeaderText="PostGP" Width="120" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD25) HeaderText="PostGS" Width="120" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD26) HeaderText="PostMinutes" Width="120" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD27) HeaderText="PostPoints" Width="130" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD28) HeaderText="PostoRebounds" Width="130" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD29) HeaderText="PostdRebounds" Width="130" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(VirtualData.FIELD30) HeaderText="PostRebounds" Width="130" TextAlign="TextAlign.Right"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<VirtualData> GridData { get; set; }
    protected override void OnInitialized()
    {
        GridData = VirtualData.GenerateData();
    }   
}

{% endhighlight %}

{% highlight cs tabtitle="VirtualData.cs" %}

public class VirtualData
{
    public VirtualData(int sNo, string field1, int field2, int field3, int field4, int field5, int field6, int field7, int field8, int field9, int field10, int field11, int field12, int field13, int field14, int field15, int field16, int field17, int field18, int field19, int field20, int field21, int field22, int field23, int field24, int field25, int field26, int field27, int field28, int field29, int field30)
    {
        SNo = sNo;
        FIELD1 = field1;
        FIELD2 = field2;
        FIELD3 = field3;
        FIELD4 = field4;
        FIELD5 = field5;
        FIELD6 = field6;
        FIELD7 = field7;
        FIELD8 = field8;
        FIELD9 = field9;
        FIELD10 = field10;
        FIELD11 = field11;
        FIELD12 = field12;
        FIELD13 = field13;
        FIELD14 = field14;
        FIELD15 = field15;
        FIELD16 = field16;
        FIELD17 = field17;
        FIELD18 = field18;
        FIELD19 = field19;
        FIELD20 = field20;
        FIELD21 = field21;
        FIELD22 = field22;
        FIELD23 = field23;
        FIELD24 = field24;
        FIELD25 = field25;
        FIELD26 = field26;
        FIELD27 = field27;
        FIELD28 = field28;
        FIELD29 = field29;
        FIELD30 = field30;
    }    
    public static List<VirtualData> GenerateData()
    {
        var virtualData = new List<VirtualData>();
        var random = new Random();
        var names = new[] {
            "hardire", "abramjo01", "aubucch01", "Hook", "Rumpelstiltskin", "Belle", "Emma", "Regina", "Aurora", "Elsa", 
            "Anna", "Snow White", "Prince Charming", "Cora", "Zelena", "August", "Mulan", "Graham", "Discord", "Will", 
            "Robin Hood", "Jiminy Cricket", "Henry", "Neal", "Red", "Aaran", "Aaren", "Aarez", "Aarman", "Aaron", "Aaron-James", 
            "Aarron", "Aaryan", "Aaryn", "Aayan", "Aazaan", "Abaan", "Abbas", "Abdallah", "Abdalroof", "Abdihakim", "Abdirahman", 
            "Abdisalam", "Abdul", "Abdul-Aziz", "Abdulbasir", "Abdulkadir", "Abdulkarem", "Abdulkhader", "Abdullah", 
            "Abdul-Majeed", "Abdulmalik", "Abdul-Rehman", "Abdur", "Abdurraheem", "Abdur-Rahman", "Abdur-Rehmaan", "Abel", 
            "Abhinav", "Abhisumant", "Abid", "Abir", "Abraham", "Abu", "Abubakar", "Ace", "Adain", "Adam", "Adam-James", 
            "Addison", "Addisson", "Adegbola", "Adegbolahan", "Aden", "Adenn", "Adie", "Adil", "Aditya", "Adnan", "Adrian", 
            "Adrien", "Aedan", "Aedin", "Aedyn", "Aeron", "Afonso", "Ahmad", "Ahmed", "Ahmed-Aziz", "Ahoua", "Ahtasham", 
            "Aiadan", "Aidan", "Aiden", "Aiden-Jack", "Aiden-Vee"
        };
        for (var i = 0; i < 1000; i++)
        {
            virtualData.Add(new VirtualData(
                i + 1,
                names[random.Next(names.Length)],
                1967 + (i % 10),
                random.Next(200),
                random.Next(100),
                random.Next(2000),
                random.Next(1000),
                random.Next(100),
                random.Next(10),
                random.Next(10),
                random.Next(100),
                random.Next(100),
                random.Next(1000),
                random.Next(10),
                random.Next(10),
                random.Next(1000),
                random.Next(200),
                random.Next(300),
                random.Next(400),
                random.Next(500),
                random.Next(700),
                random.Next(800),
                random.Next(1000),
                random.Next(2000),
                random.Next(150),
                random.Next(1000),
                random.Next(100),
                random.Next(400),
                random.Next(600),
                random.Next(500),
                random.Next(300)
            ));
        }
        return virtualData;
    }
    public int SNo { get; set; }
    public string FIELD1 { get; set; }
    public int FIELD2 { get; set; }
    public int FIELD3 { get; set; }
    public int FIELD4 { get; set; }
    public int FIELD5 { get; set; }
    public int FIELD6 { get; set; }
    public int FIELD7 { get; set; }
    public int FIELD8 { get; set; }
    public int FIELD9 { get; set; }
    public int FIELD10 { get; set; }
    public int FIELD11 { get; set; }
    public int FIELD12 { get; set; }
    public int FIELD13 { get; set; }
    public int FIELD14 { get; set; }
    public int FIELD15 { get; set; }
    public int FIELD16 { get; set; }
    public int FIELD17 { get; set; }
    public int FIELD18 { get; set; }
    public int FIELD19 { get; set; }
    public int FIELD20 { get; set; }
    public int FIELD21 { get; set; }
    public int FIELD22 { get; set; }
    public int FIELD23 { get; set; }
    public int FIELD24 { get; set; }
    public int FIELD25 { get; set; }
    public int FIELD26 { get; set; }
    public int FIELD27 { get; set; }
    public int FIELD28 { get; set; }
    public int FIELD29 { get; set; }
    public int FIELD30 { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rNhIDshOhHwVXCEM?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Infinite scrolling

Infinite scrolling loads additional data automatically as you scroll down. Instead of loading everything at once, the grid loads data in blocks. This keeps performance fast even when working with very large datasets.

#### Configure infinite scrolling

* Set [EnableInfiniteScrolling](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_EnableInfiniteScrolling) to **true** on the grid.
* Assign a fixed pixel [Height](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_Height) to the grid.
* Set [PageSize](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridPageSettings.html#Syncfusion_Blazor_Grids_GridPageSettings_PageSize) to control how many rows load in each block.


{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

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

## ListView virtualization

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor ListView supports UI virtualization, which helps improve performance when working with large datasets. Instead of rendering all items at once, only the items visible within the viewport are created. This keeps the component responsive and reduces memory usage even when the list contains thousands of records.

#### Configure ListView virtualization

Virtualization can be enabled by setting the [`EnableVirtualization`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Lists.SfListView-1.html#Syncfusion_Blazor_Lists_SfListView_1_EnableVirtualization) property to **true**.

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

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

{% endhighlight %}
{% endtabs %}

### Scroll modes

ListView supports two scrolling modes when virtualization is enabled.

**1. Window Scroll (Default)**
This mode is used automatically when no height is specified for the component. Scrolling is controlled by the browser window.

**2. Container Scroll**
This mode is used when you set a fixed pixel height for the ListView. In this case, the component scrolls inside its own container rather than the entire page.

## File Manager virtualization

The Syncfusion<sup style="font-size:70%">&reg;</sup> File Manager supports UI virtualization to efficiently load large numbers of files and folders without affecting performance. It renders only the items visible in the viewport, enabling smooth navigation even when directories contain thousands of entries. Virtualization works in both Details and Large Icons views.

The component determines which items to display based on the **height** and **width** of the viewport. As the user scrolls, the File Manager loads additional files and folders according to the available visible area.

#### Configure File Manager virtualization

To enable virtualization, set the [EnableVirtualization](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.SfFileManager-1.html#Syncfusion_Blazor_FileManager_SfFileManager_1_EnableVirtualization) property to **true**. The example below demonstrates virtualization applied in the Details view.

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}
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

### Row virtualization limitations

* Features like batch editing, detail templates, row templates, and autofill are not supported.
* Copy/paste and drag operations work only on rows currently visible in the viewport.
* Individual cell selection is not supported.
* All rows must have a fixed, identical height.
* Group expand/collapse states are not preserved unless [GridGroupSettings.PersistGroupState](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridGroupSettings.html#Syncfusion_Blazor_Grids_GridGroupSettings_PersistGroupState) is enabled.
* Text wrapping is not allowed because row height must remain consistent.
* Some browsers limit maximum scrollable height, which may affect extremely large datasets.

### Column virtualization limitations

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

### Infinite scrolling limitations

* Requires a fixed grid height for proper block calculation.
* Batch editing, and Row virtualization cannot be used with infinite scrolling.
* With infinite scrolling, copy-paste and drag-and-drop apply only to items within the current viewport.
* Programmatic selection using `SelectRowsAsync` and `SelectRowAsync` is not supported in infinite scrolling.

### ListView virtualization limitations

* Requires a pixel-based `height`. Percentage heights are not supported unless the ListView is placed inside a fixed-height parent container.
* If you prefer to use a percentage value, you can render the component within a div container with a specific pixel value set for height (It will be rendered based on the parent container height).

### File Manager virtualization limitations

* Programmatic selection using `SelectAllAsync` is not supported when virtualization is enabled.
* Pressing `CTRL + A` selects only the files and folders currently visible in the viewport, not all items in the directory.
* Selected items are not preserved while scrolling or when switching between views, to maintain optimal performance.

## See also

For detailed explanations, and additional configuration options, refer to the following documentation pages.

* [DataGrid – Virtual Scrolling & Virtualization](https://blazor.syncfusion.com/documentation/datagrid/virtual-scrolling)
* [DataGrid – Infinite Scrolling](https://blazor.syncfusion.com/documentation/datagrid/infinite-scrolling)
* [ListView – Virtualization](https://blazor.syncfusion.com/documentation/listview/virtualization)
* [File Manager – Virtualization](https://blazor.syncfusion.com/documentation/file-manager/virtualization)