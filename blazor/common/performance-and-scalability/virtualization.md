---
layout: post
title: Virtualization in Blazor — Syncfusion
description: Learn how Syncfusion Blazor components use UI virtualization to render only what's visible, enabling smooth scrolling and fast load times with very large datasets.
platform: Blazor
control: Common
documentation: ug
---

# Virtualization in Syncfusion® Blazor Components

## Overview

Virtualization is a technique used to make UI components faster and more efficient, especially when working with large amounts of data. Instead of rendering every single row, column, or item at once, the component creates only the elements currently visible on the screen. As the user scrolls, the component reuses (recycles) existing UI elements and loads the next set of data when it is needed.

This approach helps achieve:

* Faster initial load, because only a small part of the data is shown at first.
* Smoother scrolling, even with thousands of records.
* Lower memory usage, since the browser doesn't hold the entire UI in the DOM.
* Better performance at scale, allowing grids and lists to handle very large datasets without slowing down.

Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components offer reliable virtualization features that keep your app running smoothly, even when handling tens of thousands of items.

### Components Supporting Virtualization

*   **DataGrid** – Row virtualization, column virtualization, virtual scrolling, infinite scrolling
*   **ListView** – UI/DOM virtualization
*   **File Manager** – UI/DOM virtualization in Details and Large Icons views

### Advantages of Virtualization

| Benefit                   | Explanation                                    |
| ------------------------- | ---------------------------------------------- | 
| Faster initial load       | Only visible items are rendered                | 
| Reduced DOM weight        | Minimizes memory usage                         | 
| Smoother scrolling        | Reused elements provide stable navigation      | 
| Scalable                  | Performs well with 10,000+ records             | 

### Types of Virtualization 

| Type                      | Components                       | Description                                                                 |
| ------------------------- | -------------------------------- | --------------------------------------------------------------------------- |
| UI/DOM Virtualization     | ListView, File Manager           | Only visible items are rendered; others are removed or reused               |
| Row Virtualization        | DataGrid                         | Renders visible rows and loads more on scroll                               |  
| Column Virtualization     | DataGrid                         | Renders visible columns, loads more on horizontal scroll                    |
| Infinite Scrolling        | DataGrid                         | Loads additional blocks of data on reaching end of scroll                   |

## General Implementation Principles

### 1. Set a fixed viewport

Give the component a fixed **height** (and a fixed **width** if you are virtualizing columns). This enables accurate viewport and item calculations.

### 2. Use predictable row or item sizes

Virtualization works best when each row or item has a consistent height. This allows smooth scrolling and accurate positioning.

### 3. Use Overscan/Buffer When Available

The `OverscanCount` setting in the DataGrid loads a few extra rows outside the visible area, which reduces flicker and makes scrolling feel more natural.

### 4. Prepare Data for Progressive Loading

If your data comes from a server, the API should support loading small slices (using skip/take or paging) instead of returning the entire dataset at once. This keeps the app fast even with huge datasets.

## DataGrid Virtualization

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid supports advanced virtualization features including row virtualization, column virtualization, overscan buffering, loading placeholders, frozen columns with virtualization, and infinite scrolling.

### Row Virtualization

Row virtualization renders only the rows visible in the viewport and dynamically loads new rows during scroll. A **fixed pixel height** is required for correct calculations.

**Key Features**

*   Faster initial rendering
*   Reduced memory usage due to a smaller DOM
*   Cached records enable smooth backward scrolling

### Example

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

* Features like batch editing, detail templates, row templates, and autofill do not work with row virtualization.
* You can copy, paste, and drag items only in the rows that are currently visible on the screen.
* Selecting individual cells is not supported.
* Rows cannot have different heights, all rows must be the same height.
* Group expand/collapse states are not saved unless you enable the PersistGroupState option.
* Text wrapping is not allowed because row height must stay the same for all rows.
* Some browsers limit how tall a scrollable area can be, which may affect extremely large datasets.

### Column Virtualization

Column virtualization renders only the columns that are currently visible on the screen. When you scroll horizontally, the grid renders more columns as you move. This helps the DataGrid load faster and use less memory when working with wide tables that contain many columns.

**Requirements:**

* Each column must use a pixel-based width.
* Percentage column widths are not supported.
* If a width is not provided, the DataGrid assumes `200px`.

### Example

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

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


### Column Virtualization Limitations

* Cell selection is not supported
* Keyboard shortcuts Ctrl + Home and Ctrl + End keyboard shortcuts do not work with column virtualization
* Features that work only inside the visible area (viewport):
    * Column resizing
    * Column chooser
    * Auto-fit
    * Clipboard
    * Column menu

* Features that are NOT compatible with column virtualization:
    * Grouping
    * Batch editing
    * Column virtualization combined with infinite scrolling
    * Stacked headers
    * Row template / detail template
    * Hierarchy grid
    * Autofill

### Overscan (Buffered Rendering)

`OverscanCount` allows the DataGrid to render a small set of extra rows before and after the rows that are currently visible on the screen.

This extra buffer helps the grid scroll more smoothly, because it reduces how often new data needs to be loaded or the DOM needs to be updated. It also helps prevent flicker during scrolling.

Overscan applies during both the grid’s initial load and while using virtual scrolling.

```

<SfGrid DataSource="@OrderData"
        Height="315"
        EnableVirtualization="true"
        OverscanCount="5"
        EnableColumnVirtualization="true">
</SfGrid>

```

### VirtualMaskRow (Loading Placeholders)

When virtualization is enabled, the DataGrid can display placeholder cells while new data is loading. These placeholders help users understand that the content is still being fetched, which is useful when working with large datasets or when data loads as you scroll. 

To turn this feature on, set `EnableVirtualMaskRow="true"`. When enabled, the grid reuses existing DOM elements and shows placeholder cells until the new data is rendered.

This feature works only when row virtualization `(EnableVirtualization)` or column virtualization `(EnableColumnVirtualization)` is enabled. For the best results, also set `PageSize` and `RowHeight`.

```

<SfGrid DataSource="@OrderData"
        Height="315"
        EnableVirtualization="true"
        EnableVirtualMaskRow="true">
</SfGrid>

```

### Frozen Columns with Virtualization

Frozen columns stay fixed in place, while the rest of the columns scroll horizontally. When used together with virtualization, the DataGrid can efficiently render both frozen and movable columns, even when working with large datasets.

**How it works**

* Column Virtualization renders only the columns that are currently visible on the screen, while frozen columns remain fixed.
* Row Virtualization renders only the rows currently in view and can display placeholder cells while new data loads (if enabled). 
* When both types of virtualization are enabled, placeholder cells appear for both rows and columns until their data is loaded.

**How to enable frozen columns with virtualization**

1. Set columns as frozen:
Use `IsFrozen="true"` and `set Freeze="Left"` or `Freeze="Right"` for the columns you want to freeze.
2. Enable virtualization:
Turn on both `EnableVirtualization="true"` and `EnableColumnVirtualization="true"`.

```

<GridColumn Field="PlayerName"
            IsFrozen="true"
            Freeze="FreezeDirection.Left"
            Width="140" />

```

### Infinite Scrolling

Infinite scrolling allows the DataGrid to load data as you scroll, so you can work with very large datasets without slowing down the page. When the scrollbar reaches the bottom, the grid automatically loads the next set of rows, creating a smooth and continuous browsing experience.

**How it works**

* The grid loads data block by block.
* A block is the same size as the grid’s PageSize.
* If PageSize is not set, the grid calculates the block size based on the viewport height and row height.

**Requirements**

The grid must have a fixed `Height` when `EnableInfiniteScrolling` is enabled. This allows the DataGrid to calculate how many rows fit in the visible area (viewport) and determine when to load the next set of data.

**Key features**

* Requires a fixed Height for the grid container.
* `InitialBlocks` controls how many blocks load at the beginning.
* `EnableCache` reuses data that was already loaded.
* `MaximumBlocks` helps manage memory usage .

### Example

```
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

```

## ListView Virtualization

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor ListView supports UI virtualization to efficiently display large lists by rendering only the items currently visible in the viewport. The component reuses existing DOM elements as the user scrolls, helping maintain smooth performance even with thousands of items.

### Scroll Modes

ListView offers two scrolling behaviors when virtualization is enabled:

1. Window Scroll (Default)

* Used automatically when no Height is specified.
* Scrolling is controlled by the browser window.

2. Container Scroll

* Activated when a pixel‑based Height is defined.
* The ListView scrolls inside its own container instead of the window.

### Requirements

Virtualization requires:

* A `Height` value in pixels (e.g., Height="300").
* Percentage heights ("100%") are not supported unless the ListView is wrapped inside a parent container with a fixed pixel height.

```
<div style="height:320px">
    <SfListView DataSource="@Contacts"
                EnableVirtualization="true"
                Height="320">
        <ListViewFieldSettings TValue="Contact"
                               Id="Id"
                               Text="Name" />
    </SfListView>
</div>
```


## File Manager Virtualization

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor File Manager component supports UI Virtualization to efficiently load and display large numbers of files and folders. Instead of rendering all items at once, only the elements that fit inside the visible viewport are displayed. Additional items are loaded automatically as the user scrolls.

This improves performance significantly when working with directories that contain thousands of files.

### How Virtualization Works

The File Manager looks at the size of the visible area (the part you can currently see on the screen). It then shows only the files and folders that fit inside that space.
As you scroll:

* More items load automatically when you reach new areas.
* Existing on‑screen elements are reused, so the browser doesn’t have to create everything from scratch.
* Scrolling stays smooth, even if the folder contains thousands of items.

### Configuration

```
@using Syncfusion.Blazor.FileManager

<SfFileManager TValue="FileManagerDirectoryContent" View="ViewType.Details" EnableVirtualization="true">
        <FileManagerAjaxSettings Url="https://ej2-aspcore-service.azurewebsites.net/api/Virtualization/FileOperations"
                                 UploadUrl="https://ej2-aspcore-service.azurewebsites.net/api/Virtualization/Upload"
                                 DownloadUrl="https://ej2-aspcore-service.azurewebsites.net/api/Virtualization/Download"
                                 GetImageUrl="https://ej2-aspcore-service.azurewebsites.net/api/Virtualization/GetImage">
        </FileManagerAjaxSettings>        
    </SfFileManager>
```

### Limitations

* Programmatic selection using the `SelectAllAsync` method is not supported with virtual scrolling.
* The keyboard shortcut `CTRL+A` will only select the files and directories that are currently visible within the viewport, rather than selecting all files and directories in the entire directory tree.
* Selected file items are not maintained while scrolling and view switching, considering the performance of the component.






