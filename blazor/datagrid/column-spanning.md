---
layout: post
title: Blazor Grid Column Spanning | Syncfusion
description: Learn how to use column spanning in Blazor Data Grid to merge adjacent cells, create custom layouts, and improve data presentation.
platform: Blazor
control: DataGrid
documentation: ug
---

# Column Spanning in Blazor Data Grid

Column spanning consolidates repeated values in the same column into a single, taller merged cell, reducing visual redundancy and improving readability in time-sheet and schedule grids. Enable automatic spanning by setting the [AutoSpan](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AutoSpan) property of the [SfGrid](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html) component to **AutoSpanMode.Column**, or merge specific regions programmatically with [MergeCellsAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_MergeCellsAsync_Syncfusion_Blazor_Grids_MergeCellInfo_).

The [AutoSpanMode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.AutoSpanMode.html) enumeration provides multiple options for customizing cell merging behavior. The available modes include **None**, **Row**, **Column**, and **HorizontalAndVertical**.

| AutoSpanMode Value | Controls | When to Use |
|---|---|---|
| `AutoSpanMode.None` | Disables merging on all columns (default) | Standalone cells required; no spanning |
| `AutoSpanMode.Row` | Merges cells horizontally across columns | Consolidate identical values in the same row |
| `AutoSpanMode.Column` | Merges cells vertically in the same column | Consolidate identical values in consecutive rows |
| `AutoSpanMode.HorizontalAndVertical` | Merges both directions (row first, then column) | Maximum consolidation across both axes | 

| Enum Value | Description |
|---------|-----|
| AutoSpanMode.None | Disables automatic cell spanning so every cell remains isolated (Default Mode). | 
| AutoSpanMode.Row | Enables horizontal merging across columns within the same row. | 
| AutoSpanMode.Column | Enables vertical merging of adjacent cells with identical values in the same column. | 
| AutoSpanMode.HorizontalAndVertical | Enables both horizontal and vertical merging. Executes row merging first, followed by column merging. | 


## Enable column spanning

Set the [AutoSpan](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AutoSpan) property of the [SfGrid](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html) component to **AutoSpanMode.Column** to automatically merge stacked cells that share identical values within the same column. The grid evaluates each column and consolidates consecutive identical values into taller merged cells without requiring additional code or preprocessing.

**When to Use** — Enable automatic column spanning when a grid displays time-sheets, schedules, or lookup tables where the same value repeats across consecutive rows. Setting `AutoSpan="AutoSpanMode.Column"` instantly improves readability by merging those cells.

**Where to Apply** — An employee time-sheet grid listing the same task ("Development", "Testing") across ten consecutive rows automatically merges those cells into one taller cell. See the sample below for the setup.


{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

 <SfGrid DataSource="@EmployeeTimeSheet"  GridLines="GridLine.Both"
         AutoSpan="AutoSpanMode.Column" AllowSelection="false" EnableHover="false">  
    <GridColumns>
        <GridColumn Field=@nameof(EmployeeDetails.EmployeeID) HeaderText="Employee ID" Width="150" TextAlign="TextAlign.Right" IsPrimaryKey="true" IsFrozen="true"></GridColumn>
        <GridColumn Field=@nameof(EmployeeDetails.EmployeeName) HeaderText="Employee Name" Width="180" IsFrozen="true"></GridColumn>
        <GridColumn Field=@nameof(EmployeeDetails.Time_9_00) HeaderText="9:00 AM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(EmployeeDetails.Time_9_30) HeaderText="9:30 AM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(EmployeeDetails.Time_10_00) HeaderText="10:00 AM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(EmployeeDetails.Time_10_30) HeaderText="10:30 AM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(EmployeeDetails.Time_11_00) HeaderText="11:00 AM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(EmployeeDetails.Time_11_30) HeaderText="11:30 AM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(EmployeeDetails.Time_12_00) HeaderText="12:00 PM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(EmployeeDetails.Time_12_30) HeaderText="12:30 PM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(EmployeeDetails.Time_1_00) HeaderText="1:00 PM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(EmployeeDetails.Time_1_30) HeaderText="1:30 PM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(EmployeeDetails.Time_2_00) HeaderText="2:00 PM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(EmployeeDetails.Time_2_30) HeaderText="2:30 PM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(EmployeeDetails.Time_3_00) HeaderText="3:00 PM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(EmployeeDetails.Time_3_30) HeaderText="3:30 PM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(EmployeeDetails.Time_4_00) HeaderText="4:00 PM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(EmployeeDetails.Time_4_30) HeaderText="4:30 PM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(EmployeeDetails.Time_5_00) HeaderText="5:00 PM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
    </GridColumns>
</SfGrid>
@code {
    public List<EmployeeDetails>? EmployeeTimeSheet { get; set; }

    protected override void OnInitialized()
    {
        EmployeeTimeSheet = EmployeeDetails.GetAllRecords();
    }
}

{% endhighlight %}
{% highlight c# tabtitle="EmployeeDetails.cs" %}

public class EmployeeDetails
{
    public EmployeeDetails()
    {
    }
    public EmployeeDetails(int employeeid, string employeename, string time_9_00, string time_9_30, string time_10_00, string time_10_30, string time_11_00, string time_11_30,
        string time_12_00, string time_12_30, string time_1_00, string time_1_30, string time_2_00, string time_2_30, string time_3_00, string time_3_30, string time_4_00, string time_4_30,
        string time_5_00)
    {
        this.EmployeeID = employeeid;
        this.EmployeeName = employeename;
        this.Time_9_00 = time_9_00;
        this.Time_9_00 = time_9_30;
        this.Time_10_00 = time_10_00;
        this.Time_10_30 = time_10_30;
        this.Time_11_00 = time_11_00;
        this.Time_11_30 = time_11_30;
        this.Time_12_00 = time_12_00;
        this.Time_12_30 = time_12_30;
        this.Time_1_00 = time_1_00;
        this.Time_1_30 = time_1_30;
        this.Time_2_00 = time_2_00;
        this.Time_2_30 = time_2_30;
        this.Time_3_00 = time_3_00;
        this.Time_3_30 = time_3_30;
        this.Time_4_00 = time_4_00;
        this.Time_4_30 = time_4_30;
        this.Time_5_00 = time_5_00;
    }
    public int EmployeeID { get; set; }
    public string? EmployeeName { get; set; }
    public string? Time_9_00 { get; set; }
    public string? Time_9_30 { get; set; }
    public string? Time_10_00 { get; set; }
    public string? Time_10_30 { get; set; }
    public string? Time_11_00 { get; set; }
    public string? Time_11_30 { get; set; }
    public string? Time_12_00 { get; set; }
    public string? Time_12_30 { get; set; }
    public string? Time_1_00 { get; set; }
    public string? Time_1_30 { get; set; }
    public string? Time_2_00 { get; set; }
    public string? Time_2_30 { get; set; }
    public string? Time_3_00 { get; set; }
    public string? Time_3_30 { get; set; }
    public string? Time_4_00 { get; set; }
    public string? Time_4_30 { get; set; }
    public string? Time_5_00 { get; set; }

    public static List<EmployeeDetails> GetAllRecords()
    {
        List<EmployeeDetails> data = new List<EmployeeDetails>();
        data.Add(new EmployeeDetails
        {
            EmployeeID = 10001,
            EmployeeName = "Nancy Davolio",
            Time_9_00 = "Analysis Tasks",
            Time_9_30 = "Analysis Tasks",
            Time_10_00 = "Team Meeting",
            Time_10_30 = "Testing",
            Time_11_00 = "Development",
            Time_11_30 = "Code Review",
            Time_12_00 = "Development",
            Time_12_30 = "Support",
            Time_1_00 = "Lunch Break",
            Time_1_30 = "Lunch Break",
            Time_2_00 = "Lunch Break",
            Time_2_30 = "Testing",
            Time_3_00 = "Testing",
            Time_3_30 = "Development",
            Time_4_00 = "Conference",
            Time_4_30 = "Team Meeting",
            Time_5_00 = "Team Meeting"
        });
        data.Add(new EmployeeDetails
        {
            EmployeeID = 10002,
            EmployeeName = "Steven Buchanan",
            Time_9_00 = "Analysis Tasks",
            Time_9_30 = "Support",
            Time_10_00 = "Support",
            Time_10_30 = "Support",
            Time_11_00 = "Testing",
            Time_11_30 = "Testing",
            Time_12_00 = "Testing",
            Time_12_30 = "Testing",
            Time_1_00 = "Lunch Break",
            Time_1_30 = "Lunch Break",
            Time_2_00 = "Lunch Break",
            Time_2_30 = "Code Review",
            Time_3_00 = "Development",
            Time_3_30 = "Documentation",
            Time_4_00 = "Documentation",
            Time_4_30 = "Team Meeting",
            Time_5_00 = "Team Meeting"
        });
        data.Add(new EmployeeDetails
        {
            EmployeeID = 10003,
            EmployeeName = "Andrew Fuller",
            Time_9_00 = "Documentation",
            Time_9_30 = "Documentation",
            Time_10_00 = "Documentation",
            Time_10_30 = "Analysis Tasks",
            Time_11_00 = "Analysis Tasks",
            Time_11_30 = "Support",
            Time_12_00 = "Support",
            Time_12_30 = "Support",
            Time_1_00 = "Lunch Break",
            Time_1_30 = "Lunch Break",
            Time_2_00 = "Lunch Break",
            Time_2_30 = "Development",
            Time_3_00 = "Development",
            Time_3_30 = "Team Meeting",
            Time_4_00 = "Team Meeting",
            Time_4_30 = "Development",
            Time_5_00 = "Development"
        });
        data.Add(new EmployeeDetails
        {
            EmployeeID = 10004,
            EmployeeName = "Janet Leverling",
            Time_9_00 = "Testing",
            Time_9_30 = "Documentation",
            Time_10_00 = "Documentation",
            Time_10_30 = "Support",
            Time_11_00 = "Testing",
            Time_11_30 = "Testing",
            Time_12_00 = "Testing",
            Time_12_30 = "Testing",
            Time_1_00 = "Lunch Break",
            Time_1_30 = "Lunch Break",
            Time_2_00 = "Lunch Break",
            Time_2_30 = "Development",
            Time_3_00 = "Code Review",
            Time_3_30 = "Documentation",
            Time_4_00 = "Conference",
            Time_4_30 = "Conference",
            Time_5_00 = "Team Meeting"
        });
        data.Add(new EmployeeDetails
        {
            EmployeeID = 10005,
            EmployeeName = "Margaret Parker",
            Time_9_00 = "Task Assign",
            Time_9_30 = "Task Assign",
            Time_10_00 = "Task Assign",
            Time_10_30 = "Task Assign",
            Time_11_00 = "Documentation",
            Time_11_30 = "Support",
            Time_12_00 = "Support",
            Time_12_30 = "Support",
            Time_1_00 = "Lunch Break",
            Time_1_30 = "Lunch Break",
            Time_2_00 = "Lunch Break",
            Time_2_30 = "Development",
            Time_3_00 = "Development",
            Time_3_30 = "Team Meeting",
            Time_4_00 = "Team Meeting",
            Time_4_30 = "Testing",
            Time_5_00 = "Testing"
        });
        data.Add(new EmployeeDetails
        {
            EmployeeID = 10006,
            EmployeeName = "Janet King",
            Time_9_00 = "Testing",
            Time_9_30 = "Testing",
            Time_10_00 = "Support",
            Time_10_30 = "Support",
            Time_11_00 = "Support",
            Time_11_30 = "Team Meeting",
            Time_12_00 = "Team Meeting",
            Time_12_30 = "Team Meeting",
            Time_1_00 = "Lunch Break",
            Time_1_30 = "Lunch Break",
            Time_2_00 = "Lunch Break",
            Time_2_30 = "Development",
            Time_3_00 = "Code Review",
            Time_3_30 = "Team Meeting",
            Time_4_00 = "Team Meeting",
            Time_4_30 = "Development",
            Time_5_00 = "Development"
        });
        data.Add(new EmployeeDetails
        {
            EmployeeID = 10007,
            EmployeeName = "Michael Suyama",
            Time_9_00 = "Analysis Tasks",
            Time_9_30 = "Analysis Tasks",
            Time_10_00 = "Testing",
            Time_10_30 = "Development",
            Time_11_00 = "Development",
            Time_11_30 = "Testing",
            Time_12_00 = "Testing",
            Time_12_30 = "Testing",
            Time_1_00 = "Lunch Break",
            Time_1_30 = "Lunch Break",
            Time_2_00 = "Lunch Break",
            Time_2_30 = "Support",
            Time_3_00 = "Build",
            Time_3_30 = "Build",
            Time_4_00 = "Documentation",
            Time_4_30 = "Documentation",
            Time_5_00 = "Documentation"
        });
        data.Add(new EmployeeDetails
        {
            EmployeeID = 10008,
            EmployeeName = "Robert King",
            Time_9_00 = "Task Assign",
            Time_9_30 = "Task Assign",
            Time_10_00 = "Task Assign",
            Time_10_30 = "Development",
            Time_11_00 = "Development",
            Time_11_30 = "Development",
            Time_12_00 = "Testing",
            Time_12_30 = "Support",
            Time_1_00 = "Lunch Break",
            Time_1_30 = "Lunch Break",
            Time_2_00 = "Lunch Break",
            Time_2_30 = "Documentation",
            Time_3_00 = "Documentation",
            Time_3_30 = "Documentation",
            Time_4_00 = "Team Meeting",
            Time_4_30 = "Team Meeting",
            Time_5_00 = "Build"
        });
        data.Add(new EmployeeDetails
        {
            EmployeeID = 10009,
            EmployeeName = "Andrew Callahan",
            Time_9_00 = "Documentation",
            Time_9_30 = "Team Meeting",
            Time_10_00 = "Team Meeting",
            Time_10_30 = "Support",
            Time_11_00 = "Testing",
            Time_11_30 = "Development",
            Time_12_00 = "Development",
            Time_12_30 = "Development",
            Time_1_00 = "Lunch Break",
            Time_1_30 = "Lunch Break",
            Time_2_00 = "Lunch Break",
            Time_2_30 = "Documentation",
            Time_3_00 = "Documentation",
            Time_3_30 = "Documentation",
            Time_4_00 = "Team Meeting",
            Time_4_30 = "Development",
            Time_5_00 = "Development"
        });
        data.Add(new EmployeeDetails
        {
            EmployeeID = 10010,
            EmployeeName = "Michael Dodsworth",
            Time_9_00 = "Task Assign",
            Time_9_30 = "Task Assign",
            Time_10_00 = "Task Assign",
            Time_10_30 = "Analysis Tasks",
            Time_11_00 = "Analysis Tasks",
            Time_11_30 = "Testing",
            Time_12_00 = "Build",
            Time_12_30 = "Task Assign",
            Time_1_00 = "Lunch Break",
            Time_1_30 = "Lunch Break",
            Time_2_00 = "Lunch Break",
            Time_2_30 = "Testing",
            Time_3_00 = "Testing",
            Time_3_30 = "Testing",
            Time_4_00 = "Build",
            Time_4_30 = "Build",
            Time_5_00 = "Testing"
        });
        return data;
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VtrxjctipobPdORK?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" %}

## Disable column spanning for specific column

Disable spanning on individual columns by setting the [AutoSpan](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AutoSpan) property of the [GridColumn](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html) component to **AutoSpanMode.None**. This lets the grid span most columns while keeping specific columns (such as counters or status indicators) unmerged.

**When to Use** — When automatic spanning suits most columns but one column must display every row separately, set `AutoSpan="AutoSpanMode.None"` on that column alone while the grid-level spanning remains active.

**Where to Apply** — A department roster enables column spanning globally to consolidate department names, but the Employee ID column must stay separate for data accuracy. Set `AutoSpan="AutoSpanMode.None"` on the ID column only.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@EmployeeTimeSheet"  GridLines="GridLine.Both"
        AutoSpan="AutoSpanMode.Column" AllowSelection="false" EnableHover="false">
       <GridColumns>
        <GridColumn Field=@nameof(EmployeeDetails.EmployeeID) HeaderText="Employee ID" Width="150" TextAlign="TextAlign.Right" IsPrimaryKey="true" IsFrozen="true"></GridColumn>
        <GridColumn Field=@nameof(EmployeeDetails.EmployeeName) HeaderText="Employee Name" Width="180" IsFrozen="true"></GridColumn>
        <GridColumn Field=@nameof(EmployeeDetails.Time_9_00) HeaderText="9:00 AM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(EmployeeDetails.Time_9_30) HeaderText="9:30 AM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(EmployeeDetails.Time_10_00) HeaderText="10:00 AM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(EmployeeDetails.Time_10_30) HeaderText="10:30 AM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(EmployeeDetails.Time_11_00) HeaderText="11:00 AM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(EmployeeDetails.Time_11_30) HeaderText="11:30 AM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(EmployeeDetails.Time_12_00) HeaderText="12:00 PM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(EmployeeDetails.Time_12_30) HeaderText="12:30 PM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(EmployeeDetails.Time_1_00) HeaderText="1:00 PM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(EmployeeDetails.Time_1_30) HeaderText="1:30 PM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(EmployeeDetails.Time_2_00) HeaderText="2:00 PM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(EmployeeDetails.Time_2_30) HeaderText="2:30 PM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(EmployeeDetails.Time_3_00) HeaderText="3:00 PM" Width="150" TextAlign="TextAlign.Center"></GridColumn>        
        <GridColumn Field=@nameof(EmployeeDetails.Time_3_30) HeaderText="3:30 PM" Width="150" TextAlign="TextAlign.Center" AutoSpan="AutoSpanMode.None"></GridColumn>         
        <GridColumn Field=@nameof(EmployeeDetails.Time_4_00) HeaderText="4:00 PM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(EmployeeDetails.Time_4_30) HeaderText="4:30 PM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(EmployeeDetails.Time_5_00) HeaderText="5:00 PM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    
    public List<EmployeeDetails>? EmployeeTimeSheet { get; set; }

    protected override void OnInitialized()
    {
        EmployeeTimeSheet = EmployeeDetails.GetAllRecords();
    }

}

{% endhighlight %}
{% highlight c# tabtitle="EmployeeDetails.cs" %}

public class EmployeeDetails
{
    public EmployeeDetails()
    {
    }
    public EmployeeDetails(int employeeid, string employeename, string time_9_00, string time_9_30, string time_10_00, string time_10_30, string time_11_00, string time_11_30,
        string time_12_00, string time_12_30, string time_1_00, string time_1_30, string time_2_00, string time_2_30, string time_3_00, string time_3_30, string time_4_00, string time_4_30,
        string time_5_00)
    {
        this.EmployeeID = employeeid;
        this.EmployeeName = employeename;
        this.Time_9_00 = time_9_00;
        this.Time_9_00 = time_9_30;
        this.Time_10_00 = time_10_00;
        this.Time_10_30 = time_10_30;
        this.Time_11_00 = time_11_00;
        this.Time_11_30 = time_11_30;
        this.Time_12_00 = time_12_00;
        this.Time_12_30 = time_12_30;
        this.Time_1_00 = time_1_00;
        this.Time_1_30 = time_1_30;
        this.Time_2_00 = time_2_00;
        this.Time_2_30 = time_2_30;
        this.Time_3_00 = time_3_00;
        this.Time_3_30 = time_3_30;
        this.Time_4_00 = time_4_00;
        this.Time_4_30 = time_4_30;
        this.Time_5_00 = time_5_00;
    }
    public int EmployeeID { get; set; }
    public string? EmployeeName { get; set; }
    public string? Time_9_00 { get; set; }
    public string? Time_9_30 { get; set; }
    public string? Time_10_00 { get; set; }
    public string? Time_10_30 { get; set; }
    public string? Time_11_00 { get; set; }
    public string? Time_11_30 { get; set; }
    public string? Time_12_00 { get; set; }
    public string? Time_12_30 { get; set; }
    public string? Time_1_00 { get; set; }
    public string? Time_1_30 { get; set; }
    public string? Time_2_00 { get; set; }
    public string? Time_2_30 { get; set; }
    public string? Time_3_00 { get; set; }
    public string? Time_3_30 { get; set; }
    public string? Time_4_00 { get; set; }
    public string? Time_4_30 { get; set; }
    public string? Time_5_00 { get; set; }
    public static List<EmployeeDetails> GetAllRecords()
    {
        List<EmployeeDetails> data = new List<EmployeeDetails>();
        data.Add(new EmployeeDetails
        {
            EmployeeID = 10001,
            EmployeeName = "Nancy Davolio",
            Time_9_00 = "Analysis Tasks",
            Time_9_30 = "Analysis Tasks",
            Time_10_00 = "Team Meeting",
            Time_10_30 = "Testing",
            Time_11_00 = "Development",
            Time_11_30 = "Code Review",
            Time_12_00 = "Development",
            Time_12_30 = "Support",
            Time_1_00 = "Lunch Break",
            Time_1_30 = "Lunch Break",
            Time_2_00 = "Lunch Break",
            Time_2_30 = "Testing",
            Time_3_00 = "Testing",
            Time_3_30 = "Development",
            Time_4_00 = "Conference",
            Time_4_30 = "Team Meeting",
            Time_5_00 = "Team Meeting"
        });
        data.Add(new EmployeeDetails
        {
            EmployeeID = 10002,
            EmployeeName = "Steven Buchanan",
            Time_9_00 = "Analysis Tasks",
            Time_9_30 = "Support",
            Time_10_00 = "Support",
            Time_10_30 = "Support",
            Time_11_00 = "Testing",
            Time_11_30 = "Testing",
            Time_12_00 = "Testing",
            Time_12_30 = "Testing",
            Time_1_00 = "Lunch Break",
            Time_1_30 = "Lunch Break",
            Time_2_00 = "Lunch Break",
            Time_2_30 = "Code Review",
            Time_3_00 = "Development",
            Time_3_30 = "Documentation",
            Time_4_00 = "Documentation",
            Time_4_30 = "Team Meeting",
            Time_5_00 = "Team Meeting"
        });
        data.Add(new EmployeeDetails
        {
            EmployeeID = 10003,
            EmployeeName = "Andrew Fuller",
            Time_9_00 = "Documentation",
            Time_9_30 = "Documentation",
            Time_10_00 = "Documentation",
            Time_10_30 = "Analysis Tasks",
            Time_11_00 = "Analysis Tasks",
            Time_11_30 = "Support",
            Time_12_00 = "Support",
            Time_12_30 = "Support",
            Time_1_00 = "Lunch Break",
            Time_1_30 = "Lunch Break",
            Time_2_00 = "Lunch Break",
            Time_2_30 = "Development",
            Time_3_00 = "Development",
            Time_3_30 = "Team Meeting",
            Time_4_00 = "Team Meeting",
            Time_4_30 = "Development",
            Time_5_00 = "Development"
        });
        data.Add(new EmployeeDetails
        {
            EmployeeID = 10004,
            EmployeeName = "Janet Leverling",
            Time_9_00 = "Testing",
            Time_9_30 = "Documentation",
            Time_10_00 = "Documentation",
            Time_10_30 = "Support",
            Time_11_00 = "Testing",
            Time_11_30 = "Testing",
            Time_12_00 = "Testing",
            Time_12_30 = "Testing",
            Time_1_00 = "Lunch Break",
            Time_1_30 = "Lunch Break",
            Time_2_00 = "Lunch Break",
            Time_2_30 = "Development",
            Time_3_00 = "Code Review",
            Time_3_30 = "Documentation",
            Time_4_00 = "Conference",
            Time_4_30 = "Conference",
            Time_5_00 = "Team Meeting"
        });
        data.Add(new EmployeeDetails
        {
            EmployeeID = 10005,
            EmployeeName = "Margaret Parker",
            Time_9_00 = "Task Assign",
            Time_9_30 = "Task Assign",
            Time_10_00 = "Task Assign",
            Time_10_30 = "Task Assign",
            Time_11_00 = "Documentation",
            Time_11_30 = "Support",
            Time_12_00 = "Support",
            Time_12_30 = "Support",
            Time_1_00 = "Lunch Break",
            Time_1_30 = "Lunch Break",
            Time_2_00 = "Lunch Break",
            Time_2_30 = "Development",
            Time_3_00 = "Development",
            Time_3_30 = "Team Meeting",
            Time_4_00 = "Team Meeting",
            Time_4_30 = "Testing",
            Time_5_00 = "Testing"
        });
        data.Add(new EmployeeDetails
        {
            EmployeeID = 10006,
            EmployeeName = "Janet King",
            Time_9_00 = "Testing",
            Time_9_30 = "Testing",
            Time_10_00 = "Support",
            Time_10_30 = "Support",
            Time_11_00 = "Support",
            Time_11_30 = "Team Meeting",
            Time_12_00 = "Team Meeting",
            Time_12_30 = "Team Meeting",
            Time_1_00 = "Lunch Break",
            Time_1_30 = "Lunch Break",
            Time_2_00 = "Lunch Break",
            Time_2_30 = "Development",
            Time_3_00 = "Code Review",
            Time_3_30 = "Team Meeting",
            Time_4_00 = "Team Meeting",
            Time_4_30 = "Development",
            Time_5_00 = "Development"
        });
        data.Add(new EmployeeDetails
        {
            EmployeeID = 10007,
            EmployeeName = "Michael Suyama",
            Time_9_00 = "Analysis Tasks",
            Time_9_30 = "Analysis Tasks",
            Time_10_00 = "Testing",
            Time_10_30 = "Development",
            Time_11_00 = "Development",
            Time_11_30 = "Testing",
            Time_12_00 = "Testing",
            Time_12_30 = "Testing",
            Time_1_00 = "Lunch Break",
            Time_1_30 = "Lunch Break",
            Time_2_00 = "Lunch Break",
            Time_2_30 = "Support",
            Time_3_00 = "Build",
            Time_3_30 = "Build",
            Time_4_00 = "Documentation",
            Time_4_30 = "Documentation",
            Time_5_00 = "Documentation"
        });
        data.Add(new EmployeeDetails
        {
            EmployeeID = 10008,
            EmployeeName = "Robert King",
            Time_9_00 = "Task Assign",
            Time_9_30 = "Task Assign",
            Time_10_00 = "Task Assign",
            Time_10_30 = "Development",
            Time_11_00 = "Development",
            Time_11_30 = "Development",
            Time_12_00 = "Testing",
            Time_12_30 = "Support",
            Time_1_00 = "Lunch Break",
            Time_1_30 = "Lunch Break",
            Time_2_00 = "Lunch Break",
            Time_2_30 = "Documentation",
            Time_3_00 = "Documentation",
            Time_3_30 = "Documentation",
            Time_4_00 = "Team Meeting",
            Time_4_30 = "Team Meeting",
            Time_5_00 = "Build"
        });
        data.Add(new EmployeeDetails
        {
            EmployeeID = 10009,
            EmployeeName = "Andrew Callahan",
            Time_9_00 = "Documentation",
            Time_9_30 = "Team Meeting",
            Time_10_00 = "Team Meeting",
            Time_10_30 = "Support",
            Time_11_00 = "Testing",
            Time_11_30 = "Development",
            Time_12_00 = "Development",
            Time_12_30 = "Development",
            Time_1_00 = "Lunch Break",
            Time_1_30 = "Lunch Break",
            Time_2_00 = "Lunch Break",
            Time_2_30 = "Documentation",
            Time_3_00 = "Documentation",
            Time_3_30 = "Documentation",
            Time_4_00 = "Team Meeting",
            Time_4_30 = "Development",
            Time_5_00 = "Development"
        });
        data.Add(new EmployeeDetails
        {
            EmployeeID = 10010,
            EmployeeName = "Michael Dodsworth",
            Time_9_00 = "Task Assign",
            Time_9_30 = "Task Assign",
            Time_10_00 = "Task Assign",
            Time_10_30 = "Analysis Tasks",
            Time_11_00 = "Analysis Tasks",
            Time_11_30 = "Testing",
            Time_12_00 = "Build",
            Time_12_30 = "Task Assign",
            Time_1_00 = "Lunch Break",
            Time_1_30 = "Lunch Break",
            Time_2_00 = "Lunch Break",
            Time_2_30 = "Testing",
            Time_3_00 = "Testing",
            Time_3_30 = "Testing",
            Time_4_00 = "Build",
            Time_4_30 = "Build",
            Time_5_00 = "Testing"
        });
        return data;
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rZrnZwtipIuFdrEW?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" %}

The effective spanning behavior in the Blazor DataGrid is determined by the intersection of grid-level and column-level [AutoSpan](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AutoSpan) modes. A column can only restrict the spanning directions permitted at the grid-level and cannot enable a span direction that has been disabled globally. This ensures consistent behavior across the grid while allowing fine-grained control for individual columns.

**Combination Matrix**

| Grid AutoSpan | Column AutoSpan | Effective Behavior |
|---|---|---|
| None | None | No spanning. Both grid and column explicitly disable spanning. |
| None | Row | No spanning. Grid-level **None** overrides column-level **Row**. |
| None | Column | No spanning. Grid-level **None** overrides column-level **Column**. |
| None | HorizontalAndVertical | No spanning. Grid-level **None** overrides all spanning modes. |
| Row | None | No spanning. Column explicitly disables spanning. |
| Row | Row | Row spanning only. Both grid and column enable row spanning. |
| Row | Column | No spanning. Grid only allows row spanning; column cannot enable column spanning. |
| Row | HorizontalAndVertical | Row spanning only. Grid only allows row spanning. |
| Column | None | No spanning. Column explicitly disables spanning. |
| Column | Row | No spanning. Grid only allows column spanning; column cannot enable row spanning. |
| Column | Column | Column spanning only. Both grid and column enable column spanning. |
| Column | HorizontalAndVertical | Column spanning only. Grid only allows column spanning. |
| HorizontalAndVertical | None | No spanning. Column explicitly disables both directions. |
| HorizontalAndVertical | Row | Row spanning only. Grid allows both; column narrows to Row. |
| HorizontalAndVertical | Column | Column spanning only. Grid allows both; column narrows to Column. |
| HorizontalAndVertical | HorizontalAndVertical | Row and Column spanning. Both grid and column enable both directions. |

---

## Apply column spanning via programmatically

Use the [MergeCellsAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_MergeCellsAsync_Syncfusion_Blazor_Grids_MergeCellInfo_) method to manually merge specific rectangular regions of cells. This method accepts single or batch merge definitions, enabling precise control over layout customization when automatic spanning is insufficient.

**When to Use** — When automatic spanning does not meet layout requirements, call `MergeCellsAsync` to merge specific cell regions based on runtime logic, user input, or custom business rules. Batch merging via an array of `MergeCellInfo` objects improves performance for multiple regions.

**Where to Apply** — A sales dashboard lets users click "Consolidate Q3" to programmatically merge all Q3 revenue cells across rows. Loop through the Q3 columns and call `MergeCellsAsync` with an array of `MergeCellInfo` objects defining each region to merge in one operation.

The [MergeCellsAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_MergeCellsAsync_Syncfusion_Blazor_Grids_MergeCellInfo_) method is overloaded, meaning multiple versions of the same method name exist, but each accepts different parameter types to handle different use cases. This approach provides flexibility while maintaining a consistent API design.

| Parameter | Type | Description |
|-----------|------|-------------|
| info | [MergeCellInfo](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.MergeCellInfo.html) | Defines a single rectangular cell region to be merged. |
| infos | [IEnumerable&lt;MergeCellInfo&gt;](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_MergeCellsAsync_System_Collections_Generic_IEnumerable_Syncfusion_Blazor_Grids_MergeCellInfo__) | Specifies multiple cell regions to be merged in a batch operation. Each region is defined by a [MergeCellInfo](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.MergeCellInfo.html) instance. |

To define a merged region, use the following properties of the [MergeCellInfo](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.MergeCellInfo.html) class,

| Property     | Type | Description                                                                 |
|--------------|------|-----------------------------------------------------------------------------|
| RowIndex     | int  | The zero-based index of the anchor row. |
| ColumnIndex  | int  | The zero-based index of the anchor column (**top-left cell of the merged region**). |
| RowSpan      | int (optional) | The number of rows to span, starting from the anchor cell. By default set to 1. |
| ColumnSpan   | int (optional) | The number of columns to span, starting from the anchor cell. By default set to 1. |

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons

<SfButton OnClick="MergeCellsAsync">Merge Cell</SfButton>
<SfButton OnClick="MergeMultipleCellsAsync">Merge Multiple Cells</SfButton>

<SfGrid @ref="Grid" DataSource="@EmployeeTimeSheet" AllowSorting="true" AllowFiltering="true" GridLines="GridLine.Both"
        AllowSelection="false" EnableHover="false">
    <GridFilterSettings Type="Syncfusion.Blazor.Grids.FilterType.Menu"></GridFilterSettings>
    <GridColumns>
        <GridColumn Field=@nameof(EmployeeDetails.EmployeeID) HeaderText="Employee ID" Width="150" TextAlign="TextAlign.Right" IsPrimaryKey="true" IsFrozen="true"></GridColumn>
        <GridColumn Field=@nameof(EmployeeDetails.EmployeeName) HeaderText="Employee Name" Width="180" IsFrozen="true"></GridColumn>
        <GridColumn Field=@nameof(EmployeeDetails.Time_9_00) HeaderText="9:00 AM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(EmployeeDetails.Time_9_30) HeaderText="9:30 AM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(EmployeeDetails.Time_10_00) HeaderText="10:00 AM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(EmployeeDetails.Time_10_30) HeaderText="10:30 AM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(EmployeeDetails.Time_11_00) HeaderText="11:00 AM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(EmployeeDetails.Time_11_30) HeaderText="11:30 AM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(EmployeeDetails.Time_12_00) HeaderText="12:00 PM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(EmployeeDetails.Time_12_30) HeaderText="12:30 PM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(EmployeeDetails.Time_1_00) HeaderText="1:00 PM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(EmployeeDetails.Time_1_30) HeaderText="1:30 PM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(EmployeeDetails.Time_2_00) HeaderText="2:00 PM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(EmployeeDetails.Time_2_30) HeaderText="2:30 PM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(EmployeeDetails.Time_3_00) HeaderText="3:00 PM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(EmployeeDetails.Time_3_30) HeaderText="3:30 PM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(EmployeeDetails.Time_4_00) HeaderText="4:00 PM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(EmployeeDetails.Time_4_30) HeaderText="4:30 PM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(EmployeeDetails.Time_5_00) HeaderText="5:00 PM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
    </GridColumns>
</SfGrid>

@code
{
    public List<EmployeeDetails>? EmployeeTimeSheet { get; set; }
    public SfGrid<EmployeeDetails>? Grid;

    protected override void OnInitialized()
    {
        EmployeeTimeSheet = EmployeeDetails.GetAllRecords();
    }

    public async Task MergeCellsAsync()
    {
        await Grid.MergeCellsAsync(new MergeCellInfo
        {
            RowIndex = 1,
            ColumnIndex = 2,
            ColumnSpan = 2,
        });
    }

    public async Task MergeMultipleCellsAsync()
    {
        await Grid.MergeCellsAsync(new[]
        {
            new MergeCellInfo { RowIndex = 0, ColumnIndex = 2, ColumnSpan = 2 },
            new MergeCellInfo { RowIndex = 5, ColumnIndex = 3, ColumnSpan = 3 },
            new MergeCellInfo { RowIndex = 7, ColumnIndex = 4, ColumnSpan = 2 }
        });
    }
}
{% endhighlight %}
{% highlight c# tabtitle="EmployeeDetails.cs" %}

public class EmployeeDetails
{
    public EmployeeDetails()
    {
    }
    public EmployeeDetails(int employeeid, string employeename, string time_9_00, string time_9_30, string time_10_00, string time_10_30, string time_11_00, string time_11_30,
        string time_12_00, string time_12_30, string time_1_00, string time_1_30, string time_2_00, string time_2_30, string time_3_00, string time_3_30, string time_4_00, string time_4_30,
        string time_5_00)
    {
        this.EmployeeID = employeeid;
        this.EmployeeName = employeename;
        this.Time_9_00 = time_9_00;
        this.Time_9_00 = time_9_30;
        this.Time_10_00 = time_10_00;
        this.Time_10_30 = time_10_30;
        this.Time_11_00 = time_11_00;
        this.Time_11_30 = time_11_30;
        this.Time_12_00 = time_12_00;
        this.Time_12_30 = time_12_30;
        this.Time_1_00 = time_1_00;
        this.Time_1_30 = time_1_30;
        this.Time_2_00 = time_2_00;
        this.Time_2_30 = time_2_30;
        this.Time_3_00 = time_3_00;
        this.Time_3_30 = time_3_30;
        this.Time_4_00 = time_4_00;
        this.Time_4_30 = time_4_30;
        this.Time_5_00 = time_5_00;
    }
    public int EmployeeID { get; set; }
    public string? EmployeeName { get; set; }
    public string? Time_9_00 { get; set; }
    public string? Time_9_30 { get; set; }
    public string? Time_10_00 { get; set; }
    public string? Time_10_30 { get; set; }
    public string? Time_11_00 { get; set; }
    public string? Time_11_30 { get; set; }
    public string? Time_12_00 { get; set; }
    public string? Time_12_30 { get; set; }
    public string? Time_1_00 { get; set; }
    public string? Time_1_30 { get; set; }
    public string? Time_2_00 { get; set; }
    public string? Time_2_30 { get; set; }
    public string? Time_3_00 { get; set; }
    public string? Time_3_30 { get; set; }
    public string? Time_4_00 { get; set; }
    public string? Time_4_30 { get; set; }
    public string? Time_5_00 { get; set; }

    public static List<EmployeeDetails> GetAllRecords()
    {
        List<EmployeeDetails> data = new List<EmployeeDetails>();
        data.Add(new EmployeeDetails
        {
            EmployeeID = 10001,
            EmployeeName = "Nancy Davolio",
            Time_9_00 = "Analysis Tasks",
            Time_9_30 = "Analysis Tasks",
            Time_10_00 = "Team Meeting",
            Time_10_30 = "Testing",
            Time_11_00 = "Development",
            Time_11_30 = "Code Review",
            Time_12_00 = "Development",
            Time_12_30 = "Support",
            Time_1_00 = "Lunch Break",
            Time_1_30 = "Lunch Break",
            Time_2_00 = "Lunch Break",
            Time_2_30 = "Testing",
            Time_3_00 = "Testing",
            Time_3_30 = "Development",
            Time_4_00 = "Conference",
            Time_4_30 = "Team Meeting",
            Time_5_00 = "Team Meeting"
        });
        data.Add(new EmployeeDetails
        {
            EmployeeID = 10002,
            EmployeeName = "Steven Buchanan",
            Time_9_00 = "Analysis Tasks",
            Time_9_30 = "Support",
            Time_10_00 = "Support",
            Time_10_30 = "Support",
            Time_11_00 = "Testing",
            Time_11_30 = "Testing",
            Time_12_00 = "Testing",
            Time_12_30 = "Testing",
            Time_1_00 = "Lunch Break",
            Time_1_30 = "Lunch Break",
            Time_2_00 = "Lunch Break",
            Time_2_30 = "Code Review",
            Time_3_00 = "Development",
            Time_3_30 = "Documentation",
            Time_4_00 = "Documentation",
            Time_4_30 = "Team Meeting",
            Time_5_00 = "Team Meeting"
        });
        data.Add(new EmployeeDetails
        {
            EmployeeID = 10003,
            EmployeeName = "Andrew Fuller",
            Time_9_00 = "Documentation",
            Time_9_30 = "Documentation",
            Time_10_00 = "Documentation",
            Time_10_30 = "Analysis Tasks",
            Time_11_00 = "Analysis Tasks",
            Time_11_30 = "Support",
            Time_12_00 = "Support",
            Time_12_30 = "Support",
            Time_1_00 = "Lunch Break",
            Time_1_30 = "Lunch Break",
            Time_2_00 = "Lunch Break",
            Time_2_30 = "Development",
            Time_3_00 = "Development",
            Time_3_30 = "Team Meeting",
            Time_4_00 = "Team Meeting",
            Time_4_30 = "Development",
            Time_5_00 = "Development"
        });
        data.Add(new EmployeeDetails
        {
            EmployeeID = 10004,
            EmployeeName = "Janet Leverling",
            Time_9_00 = "Testing",
            Time_9_30 = "Documentation",
            Time_10_00 = "Documentation",
            Time_10_30 = "Support",
            Time_11_00 = "Testing",
            Time_11_30 = "Testing",
            Time_12_00 = "Testing",
            Time_12_30 = "Testing",
            Time_1_00 = "Lunch Break",
            Time_1_30 = "Lunch Break",
            Time_2_00 = "Lunch Break",
            Time_2_30 = "Development",
            Time_3_00 = "Code Review",
            Time_3_30 = "Documentation",
            Time_4_00 = "Conference",
            Time_4_30 = "Conference",
            Time_5_00 = "Team Meeting"
        });
        data.Add(new EmployeeDetails
        {
            EmployeeID = 10005,
            EmployeeName = "Margaret Parker",
            Time_9_00 = "Task Assign",
            Time_9_30 = "Task Assign",
            Time_10_00 = "Task Assign",
            Time_10_30 = "Task Assign",
            Time_11_00 = "Documentation",
            Time_11_30 = "Support",
            Time_12_00 = "Support",
            Time_12_30 = "Support",
            Time_1_00 = "Lunch Break",
            Time_1_30 = "Lunch Break",
            Time_2_00 = "Lunch Break",
            Time_2_30 = "Development",
            Time_3_00 = "Development",
            Time_3_30 = "Team Meeting",
            Time_4_00 = "Team Meeting",
            Time_4_30 = "Testing",
            Time_5_00 = "Testing"
        });
        data.Add(new EmployeeDetails
        {
            EmployeeID = 10006,
            EmployeeName = "Janet King",
            Time_9_00 = "Testing",
            Time_9_30 = "Testing",
            Time_10_00 = "Support",
            Time_10_30 = "Support",
            Time_11_00 = "Support",
            Time_11_30 = "Team Meeting",
            Time_12_00 = "Team Meeting",
            Time_12_30 = "Team Meeting",
            Time_1_00 = "Lunch Break",
            Time_1_30 = "Lunch Break",
            Time_2_00 = "Lunch Break",
            Time_2_30 = "Development",
            Time_3_00 = "Code Review",
            Time_3_30 = "Team Meeting",
            Time_4_00 = "Team Meeting",
            Time_4_30 = "Development",
            Time_5_00 = "Development"
        });
        data.Add(new EmployeeDetails
        {
            EmployeeID = 10007,
            EmployeeName = "Michael Suyama",
            Time_9_00 = "Analysis Tasks",
            Time_9_30 = "Analysis Tasks",
            Time_10_00 = "Testing",
            Time_10_30 = "Development",
            Time_11_00 = "Development",
            Time_11_30 = "Testing",
            Time_12_00 = "Testing",
            Time_12_30 = "Testing",
            Time_1_00 = "Lunch Break",
            Time_1_30 = "Lunch Break",
            Time_2_00 = "Lunch Break",
            Time_2_30 = "Support",
            Time_3_00 = "Build",
            Time_3_30 = "Build",
            Time_4_00 = "Documentation",
            Time_4_30 = "Documentation",
            Time_5_00 = "Documentation"
        });
        data.Add(new EmployeeDetails
        {
            EmployeeID = 10008,
            EmployeeName = "Robert King",
            Time_9_00 = "Task Assign",
            Time_9_30 = "Task Assign",
            Time_10_00 = "Task Assign",
            Time_10_30 = "Development",
            Time_11_00 = "Development",
            Time_11_30 = "Development",
            Time_12_00 = "Testing",
            Time_12_30 = "Support",
            Time_1_00 = "Lunch Break",
            Time_1_30 = "Lunch Break",
            Time_2_00 = "Lunch Break",
            Time_2_30 = "Documentation",
            Time_3_00 = "Documentation",
            Time_3_30 = "Documentation",
            Time_4_00 = "Team Meeting",
            Time_4_30 = "Team Meeting",
            Time_5_00 = "Build"
        });
        data.Add(new EmployeeDetails
        {
            EmployeeID = 10009,
            EmployeeName = "Andrew Callahan",
            Time_9_00 = "Documentation",
            Time_9_30 = "Team Meeting",
            Time_10_00 = "Team Meeting",
            Time_10_30 = "Support",
            Time_11_00 = "Testing",
            Time_11_30 = "Development",
            Time_12_00 = "Development",
            Time_12_30 = "Development",
            Time_1_00 = "Lunch Break",
            Time_1_30 = "Lunch Break",
            Time_2_00 = "Lunch Break",
            Time_2_30 = "Documentation",
            Time_3_00 = "Documentation",
            Time_3_30 = "Documentation",
            Time_4_00 = "Team Meeting",
            Time_4_30 = "Development",
            Time_5_00 = "Development"
        });
        data.Add(new EmployeeDetails
        {
            EmployeeID = 10010,
            EmployeeName = "Michael Dodsworth",
            Time_9_00 = "Task Assign",
            Time_9_30 = "Task Assign",
            Time_10_00 = "Task Assign",
            Time_10_30 = "Analysis Tasks",
            Time_11_00 = "Analysis Tasks",
            Time_11_30 = "Testing",
            Time_12_00 = "Build",
            Time_12_30 = "Task Assign",
            Time_1_00 = "Lunch Break",
            Time_1_30 = "Lunch Break",
            Time_2_00 = "Lunch Break",
            Time_2_30 = "Testing",
            Time_3_00 = "Testing",
            Time_3_30 = "Testing",
            Time_4_00 = "Build",
            Time_4_30 = "Build",
            Time_5_00 = "Testing"
        });
        return data;
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rXVHZQtsfHNsdpBM?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" %}

## Clear spanning via programmatically

Restore individual cells after merging by calling [UnmergeCellsAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_UnmergeCellsAsync_Syncfusion_Blazor_Grids_UnmergeCellInfo_) to remove specific merged regions, or [UnmergeAllAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_UnmergeAllAsync) to reset all merged cells in the current view back to their original state.

**When to Use** — Call `UnmergeCellsAsync` when removing specific merged regions is sufficient, or `UnmergeAllAsync` when the entire grid must return to unmerged state. Batch unmerging via an array of `UnmergeCellInfo` objects improves performance over multiple individual calls.

**Where to Apply** — A report grid merges cells to show grouped quarters. When the user clicks "Restore Detail", call `UnmergeAllAsync` to unmerge all regions and display every row separately. See the sample below for all three unmerge patterns.

The [UnmergeCellsAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_UnmergeCellsAsync_Syncfusion_Blazor_Grids_UnmergeCellInfo_) method is overloaded to provide flexibility for different scenarios. Both overloads share the same method name but accept different parameter types, allowing removal of either a single merged region or multiple merged regions in one operation.

| Method | Parameter | Type | Description |
|--------|-----------|------|-------------|
| [UnmergeCellsAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_UnmergeCellsAsync_Syncfusion_Blazor_Grids_UnmergeCellInfo_) | info | [UnmergeCellInfo](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.UnmergeCellInfo.html) | Removes a single merged area identified by its anchor cell (top‑left of the merged region). |
| [UnmergeCellsAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_UnmergeCellsAsync_Syncfusion_Blazor_Grids_UnmergeCellInfo_) | infos | [IEnumerable&lt;UnmergeCellInfo&gt;](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_UnmergeCellsAsync_System_Collections_Generic_IEnumerable_Syncfusion_Blazor_Grids_UnmergeCellInfo__) | Removes multiple merged areas in one combined operation, improving performance by reducing re‑renders. |
| [UnmergeAllAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_UnmergeAllAsync) | – | – | Removes all merged regions in the current view, restoring every cell to its original state. |

To identify a merged region, use the following properties of the [UnmergeCellInfo](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.UnmergeCellInfo.html) class:

| Property     | Type | Description                                                                 |
|--------------|------|-----------------------------------------------------------------------------|
| RowIndex     | int  | The zero-based index of the anchor row. |
| ColumnIndex  | int  | The zero-based index of the anchor column (**top-left cell of the merged region**). |

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons

<SfButton OnClick="MergeCellsAsync">Merge Cell</SfButton>
<SfButton OnClick="UnMergeCell">UnMerge Cell</SfButton>

<SfButton OnClick="MergeMultipleCellsAsync">Merge Multiple Cells</SfButton>
<SfButton OnClick="UnMergeCells">UnMerge Multiple Cells</SfButton>

<SfButton OnClick="UnMergeAllCells">UnMerge All Cells</SfButton>

<SfGrid @ref="Grid" DataSource="@EmployeeTimeSheet"  GridLines="GridLine.Both" AllowSelection="false" EnableHover="false">    
    <GridColumns>
        <GridColumn Field=@nameof(EmployeeDetails.EmployeeID) HeaderText="Employee ID" Width="150" TextAlign="TextAlign.Right" IsPrimaryKey="true" IsFrozen="true"></GridColumn>
        <GridColumn Field=@nameof(EmployeeDetails.EmployeeName) HeaderText="Employee Name" Width="180" IsFrozen="true"></GridColumn>
        <GridColumn Field=@nameof(EmployeeDetails.Time_9_00) HeaderText="9:00 AM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(EmployeeDetails.Time_9_30) HeaderText="9:30 AM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(EmployeeDetails.Time_10_00) HeaderText="10:00 AM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(EmployeeDetails.Time_10_30) HeaderText="10:30 AM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(EmployeeDetails.Time_11_00) HeaderText="11:00 AM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(EmployeeDetails.Time_11_30) HeaderText="11:30 AM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(EmployeeDetails.Time_12_00) HeaderText="12:00 PM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(EmployeeDetails.Time_12_30) HeaderText="12:30 PM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(EmployeeDetails.Time_1_00) HeaderText="1:00 PM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(EmployeeDetails.Time_1_30) HeaderText="1:30 PM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(EmployeeDetails.Time_2_00) HeaderText="2:00 PM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(EmployeeDetails.Time_2_30) HeaderText="2:30 PM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(EmployeeDetails.Time_3_00) HeaderText="3:00 PM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(EmployeeDetails.Time_3_30) HeaderText="3:30 PM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(EmployeeDetails.Time_4_00) HeaderText="4:00 PM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(EmployeeDetails.Time_4_30) HeaderText="4:30 PM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(EmployeeDetails.Time_5_00) HeaderText="5:00 PM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
    </GridColumns>
</SfGrid>
@code
{
    public List<EmployeeDetails>? EmployeeTimeSheet { get; set; }
    public SfGrid<EmployeeDetails>? Grid;

    protected override void OnInitialized()
    {
        EmployeeTimeSheet = EmployeeDetails.GetAllRecords();
    }

    public async Task MergeCellsAsync()
    {
        await Grid.MergeCellsAsync(new MergeCellInfo
        {
            RowIndex = 1,
            ColumnIndex = 5,
            ColumnSpan = 2,
        });
    }

    public async Task UnMergeCell()
    {
        await Grid.UnmergeCellsAsync(new UnmergeCellInfo
        {
            RowIndex = 1,
            ColumnIndex = 5,
        });
    }

    public async Task MergeMultipleCellsAsync()
    {
        await Grid.MergeCellsAsync(new[]
        {
            new MergeCellInfo { RowIndex = 0, ColumnIndex = 2, ColumnSpan = 2 },
            new MergeCellInfo { RowIndex = 5, ColumnIndex = 3, ColumnSpan = 3 },
            new MergeCellInfo { RowIndex = 7, ColumnIndex = 4, ColumnSpan = 2 }
        });
    }

    public async Task UnMergeCells()
    {
        await Grid.UnmergeCellsAsync(new[]
        {
            new UnmergeCellInfo { RowIndex = 0, ColumnIndex = 2 },
            new UnmergeCellInfo { RowIndex = 5, ColumnIndex = 3 },
            new UnmergeCellInfo { RowIndex = 7, ColumnIndex = 4 }
        });
    }

    public async Task UnMergeAllCells()
    {
        await Grid.UnmergeAllAsync();
    }
}
{% endhighlight %}
{% highlight c# tabtitle="EmployeeDetails.cs" %}

public class EmployeeDetails
{
    public EmployeeDetails()
    {
    }
    public EmployeeDetails(int employeeid, string employeename, string time_9_00, string time_9_30, string time_10_00, string time_10_30, string time_11_00, string time_11_30,
        string time_12_00, string time_12_30, string time_1_00, string time_1_30, string time_2_00, string time_2_30, string time_3_00, string time_3_30, string time_4_00, string time_4_30,
        string time_5_00)
    {
        this.EmployeeID = employeeid;
        this.EmployeeName = employeename;
        this.Time_9_00 = time_9_00;
        this.Time_9_00 = time_9_30;
        this.Time_10_00 = time_10_00;
        this.Time_10_30 = time_10_30;
        this.Time_11_00 = time_11_00;
        this.Time_11_30 = time_11_30;
        this.Time_12_00 = time_12_00;
        this.Time_12_30 = time_12_30;
        this.Time_1_00 = time_1_00;
        this.Time_1_30 = time_1_30;
        this.Time_2_00 = time_2_00;
        this.Time_2_30 = time_2_30;
        this.Time_3_00 = time_3_00;
        this.Time_3_30 = time_3_30;
        this.Time_4_00 = time_4_00;
        this.Time_4_30 = time_4_30;
        this.Time_5_00 = time_5_00;
    }
    public int EmployeeID { get; set; }
    public string? EmployeeName { get; set; }
    public string? Time_9_00 { get; set; }
    public string? Time_9_30 { get; set; }
    public string? Time_10_00 { get; set; }
    public string? Time_10_30 { get; set; }
    public string? Time_11_00 { get; set; }
    public string? Time_11_30 { get; set; }
    public string? Time_12_00 { get; set; }
    public string? Time_12_30 { get; set; }
    public string? Time_1_00 { get; set; }
    public string? Time_1_30 { get; set; }
    public string? Time_2_00 { get; set; }
    public string? Time_2_30 { get; set; }
    public string? Time_3_00 { get; set; }
    public string? Time_3_30 { get; set; }
    public string? Time_4_00 { get; set; }
    public string? Time_4_30 { get; set; }
    public string? Time_5_00 { get; set; }

    public static List<EmployeeDetails> GetAllRecords()
    {
        List<EmployeeDetails> data = new List<EmployeeDetails>();
        data.Add(new EmployeeDetails
        {
            EmployeeID = 10001,
            EmployeeName = "Nancy Davolio",
            Time_9_00 = "Analysis Tasks",
            Time_9_30 = "Analysis Tasks",
            Time_10_00 = "Team Meeting",
            Time_10_30 = "Testing",
            Time_11_00 = "Development",
            Time_11_30 = "Code Review",
            Time_12_00 = "Development",
            Time_12_30 = "Support",
            Time_1_00 = "Lunch Break",
            Time_1_30 = "Lunch Break",
            Time_2_00 = "Lunch Break",
            Time_2_30 = "Testing",
            Time_3_00 = "Testing",
            Time_3_30 = "Development",
            Time_4_00 = "Conference",
            Time_4_30 = "Team Meeting",
            Time_5_00 = "Team Meeting"
        });
        data.Add(new EmployeeDetails
        {
            EmployeeID = 10002,
            EmployeeName = "Steven Buchanan",
            Time_9_00 = "Analysis Tasks",
            Time_9_30 = "Support",
            Time_10_00 = "Support",
            Time_10_30 = "Support",
            Time_11_00 = "Testing",
            Time_11_30 = "Testing",
            Time_12_00 = "Testing",
            Time_12_30 = "Testing",
            Time_1_00 = "Lunch Break",
            Time_1_30 = "Lunch Break",
            Time_2_00 = "Lunch Break",
            Time_2_30 = "Code Review",
            Time_3_00 = "Development",
            Time_3_30 = "Documentation",
            Time_4_00 = "Documentation",
            Time_4_30 = "Team Meeting",
            Time_5_00 = "Team Meeting"
        });
        data.Add(new EmployeeDetails
        {
            EmployeeID = 10003,
            EmployeeName = "Andrew Fuller",
            Time_9_00 = "Documentation",
            Time_9_30 = "Documentation",
            Time_10_00 = "Documentation",
            Time_10_30 = "Analysis Tasks",
            Time_11_00 = "Analysis Tasks",
            Time_11_30 = "Support",
            Time_12_00 = "Support",
            Time_12_30 = "Support",
            Time_1_00 = "Lunch Break",
            Time_1_30 = "Lunch Break",
            Time_2_00 = "Lunch Break",
            Time_2_30 = "Development",
            Time_3_00 = "Development",
            Time_3_30 = "Team Meeting",
            Time_4_00 = "Team Meeting",
            Time_4_30 = "Development",
            Time_5_00 = "Development"
        });
        data.Add(new EmployeeDetails
        {
            EmployeeID = 10004,
            EmployeeName = "Janet Leverling",
            Time_9_00 = "Testing",
            Time_9_30 = "Documentation",
            Time_10_00 = "Documentation",
            Time_10_30 = "Support",
            Time_11_00 = "Testing",
            Time_11_30 = "Testing",
            Time_12_00 = "Testing",
            Time_12_30 = "Testing",
            Time_1_00 = "Lunch Break",
            Time_1_30 = "Lunch Break",
            Time_2_00 = "Lunch Break",
            Time_2_30 = "Development",
            Time_3_00 = "Code Review",
            Time_3_30 = "Documentation",
            Time_4_00 = "Conference",
            Time_4_30 = "Conference",
            Time_5_00 = "Team Meeting"
        });
        data.Add(new EmployeeDetails
        {
            EmployeeID = 10005,
            EmployeeName = "Margaret Parker",
            Time_9_00 = "Task Assign",
            Time_9_30 = "Task Assign",
            Time_10_00 = "Task Assign",
            Time_10_30 = "Task Assign",
            Time_11_00 = "Documentation",
            Time_11_30 = "Support",
            Time_12_00 = "Support",
            Time_12_30 = "Support",
            Time_1_00 = "Lunch Break",
            Time_1_30 = "Lunch Break",
            Time_2_00 = "Lunch Break",
            Time_2_30 = "Development",
            Time_3_00 = "Development",
            Time_3_30 = "Team Meeting",
            Time_4_00 = "Team Meeting",
            Time_4_30 = "Testing",
            Time_5_00 = "Testing"
        });
        data.Add(new EmployeeDetails
        {
            EmployeeID = 10006,
            EmployeeName = "Janet King",
            Time_9_00 = "Testing",
            Time_9_30 = "Testing",
            Time_10_00 = "Support",
            Time_10_30 = "Support",
            Time_11_00 = "Support",
            Time_11_30 = "Team Meeting",
            Time_12_00 = "Team Meeting",
            Time_12_30 = "Team Meeting",
            Time_1_00 = "Lunch Break",
            Time_1_30 = "Lunch Break",
            Time_2_00 = "Lunch Break",
            Time_2_30 = "Development",
            Time_3_00 = "Code Review",
            Time_3_30 = "Team Meeting",
            Time_4_00 = "Team Meeting",
            Time_4_30 = "Development",
            Time_5_00 = "Development"
        });
        data.Add(new EmployeeDetails
        {
            EmployeeID = 10007,
            EmployeeName = "Michael Suyama",
            Time_9_00 = "Analysis Tasks",
            Time_9_30 = "Analysis Tasks",
            Time_10_00 = "Testing",
            Time_10_30 = "Development",
            Time_11_00 = "Development",
            Time_11_30 = "Testing",
            Time_12_00 = "Testing",
            Time_12_30 = "Testing",
            Time_1_00 = "Lunch Break",
            Time_1_30 = "Lunch Break",
            Time_2_00 = "Lunch Break",
            Time_2_30 = "Support",
            Time_3_00 = "Build",
            Time_3_30 = "Build",
            Time_4_00 = "Documentation",
            Time_4_30 = "Documentation",
            Time_5_00 = "Documentation"
        });
        data.Add(new EmployeeDetails
        {
            EmployeeID = 10008,
            EmployeeName = "Robert King",
            Time_9_00 = "Task Assign",
            Time_9_30 = "Task Assign",
            Time_10_00 = "Task Assign",
            Time_10_30 = "Development",
            Time_11_00 = "Development",
            Time_11_30 = "Development",
            Time_12_00 = "Testing",
            Time_12_30 = "Support",
            Time_1_00 = "Lunch Break",
            Time_1_30 = "Lunch Break",
            Time_2_00 = "Lunch Break",
            Time_2_30 = "Documentation",
            Time_3_00 = "Documentation",
            Time_3_30 = "Documentation",
            Time_4_00 = "Team Meeting",
            Time_4_30 = "Team Meeting",
            Time_5_00 = "Build"
        });
        data.Add(new EmployeeDetails
        {
            EmployeeID = 10009,
            EmployeeName = "Andrew Callahan",
            Time_9_00 = "Documentation",
            Time_9_30 = "Team Meeting",
            Time_10_00 = "Team Meeting",
            Time_10_30 = "Support",
            Time_11_00 = "Testing",
            Time_11_30 = "Development",
            Time_12_00 = "Development",
            Time_12_30 = "Development",
            Time_1_00 = "Lunch Break",
            Time_1_30 = "Lunch Break",
            Time_2_00 = "Lunch Break",
            Time_2_30 = "Documentation",
            Time_3_00 = "Documentation",
            Time_3_30 = "Documentation",
            Time_4_00 = "Team Meeting",
            Time_4_30 = "Development",
            Time_5_00 = "Development"
        });
        data.Add(new EmployeeDetails
        {
            EmployeeID = 10010,
            EmployeeName = "Michael Dodsworth",
            Time_9_00 = "Task Assign",
            Time_9_30 = "Task Assign",
            Time_10_00 = "Task Assign",
            Time_10_30 = "Analysis Tasks",
            Time_11_00 = "Analysis Tasks",
            Time_11_30 = "Testing",
            Time_12_00 = "Build",
            Time_12_30 = "Task Assign",
            Time_1_00 = "Lunch Break",
            Time_1_30 = "Lunch Break",
            Time_2_00 = "Lunch Break",
            Time_2_30 = "Testing",
            Time_3_00 = "Testing",
            Time_3_30 = "Testing",
            Time_4_00 = "Build",
            Time_4_30 = "Build",
            Time_5_00 = "Testing"
        });
        return data;
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hDVnXcZizdXJhdRE?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" %}

---

## Open Questions

> **Open question:** The code samples in this topic (constructor in EmployeeDetails.cs) contain the line `this.Time_9_00 = time_9_30;`, which assigns the wrong parameter to the property. Verify against the actual codebase before publishing, as this may be test-data scaffolding or a bug.

> **Open question:** The supported render modes (Server, WebAssembly, Auto, Static SSR) for column spanning and the merge/unmerge API methods are not confirmed. Verify whether all modes are supported or if there are render-mode differences. If all are supported, add this fact to the introduction. If differences exist, state them as plain prose without a render-mode table.

---

## Limitations

The Column spanning is not compatible with the following features:

1. AutoFill.
2. Detail-Template.
3. Grouping – Row and column spanning are supported only within the same caption row during grouping scenarios. This means cells can be merged horizontally or vertically only inside a single group header (**caption row**). Merging across different caption rows is not supported, since each caption row represents a distinct group context. Allowing spans between these rows would break the logical grouping structure and the visual hierarchy of the grid.

