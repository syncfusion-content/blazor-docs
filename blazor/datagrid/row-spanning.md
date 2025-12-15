---
layout: post
title: Row Spanning in Blazor DataGrid Component | Syncfusion
description: Learn how to use the row spanning in Syncfusion Blazor DataGrid.
platform: Blazor
control: DataGrid
documentation: ug
---

# Row Spanning in Blazor DataGrid

Row spanning in the Syncfusion Blazor DataGrid merges adjacent cells with identical values horizontally across columns within the same row. This feature reduces visual repetition and presents grouped data in a compact, readable format. It is particularly effective in scenarios where multiple columns share the same value, such as repeated product details or status indicators.

The functionality is enabled by setting the `AutoSpan` property of the `SfGrid` component to `AutoSpanMode.Row`. When activated, the grid evaluates each row and merges neighboring cells containing identical values, resulting in a single, wider cell. The merging process is automatic and declarative, requiring no manual logic or data transformation.

Row spanning is part of the broader `AutoSpanMode` enumeration, which provides multiple options for customizing cell merging behavior in the Syncfusion Blazor DataGrid. The available modes include `None`, `Row`, `Column`, and `HorizontalAndVertical`. 

## AutoSpanMode Enumeration

| Enum Value | Description |
|---------|-----|
| AutoSpanMode.None | Disables automatic cell spanning. Every cell remains isolated. (Default Mode) | 
| AutoSpanMode.Row | Enables horizontal merging across columns within the same row. | 
| AutoSpanMode.Column | Enables vertical merging of adjacent cells with identical values in the same column. | 
| AutoSpanMode.HorizontalAndVertical | Enables both horizontal and vertical merging. Executes row merging first, followed by column merging. | 


## Enabling Row Spanning

Horizontal cell merging in the Syncfusion Blazor DataGrid is enabled by setting the `AutoSpan` property of the `SfGrid` component to `AutoSpanMode.Row`. In this mode, adjacent cells across columns within the same row are automatically merged when they contain identical values. This reduces redundancy and provides a cleaner, more compact presentation of repeated data.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.DropDowns
@using Syncfusion.Blazor.Buttons

 <SfGrid DataSource="@EmployeeTimeSheet" AllowSorting="true" AllowFiltering="true" GridLines="GridLine.Both"
        AutoSpan="AutoSpanMode.Row" AllowSelection="false" EnableHover="false">
    <GridFilterSettings Type="Syncfusion.Blazor.Grids.FilterType.Menu"></GridFilterSettings>
    <GridColumns>
        <GridColumn Field=@nameof(EmployeeDetails.EmployeeID) HeaderText="Employee ID" Width="150" TextAlign="TextAlign.Right" IsPrimaryKey="true" IsFrozen="true"></GridColumn>
        <GridColumn Field=@nameof(EmployeeDetails.EmployeeName) HeaderText="Employee Name" Width="180" IsFrozen="@enableFrozen"></GridColumn>
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
    private bool enableFrozen { get; set; } = true;
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


## Disable spanning for specific column

Spanning in the Syncfusion Blazor DataGrid can be disabled at the column level by setting the `AutoSpan` property of the `GridColumn` component to `AutoSpanMode.None`. This configuration provides fine-grained control, allowing automatic spanning to be applied globally while excluding specific columns where merging is not desired.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.DropDowns
@using Syncfusion.Blazor.Buttons

 <SfGrid DataSource="@EmployeeTimeSheet" AllowSorting="true" AllowFiltering="true" GridLines="GridLine.Both"
        AutoSpan="AutoSpanMode.Row" AllowSelection="false" EnableHover="false">
    <GridFilterSettings Type="Syncfusion.Blazor.Grids.FilterType.Menu"></GridFilterSettings>
    <GridColumns>
        <GridColumn Field=@nameof(EmployeeDetails.EmployeeID) HeaderText="Employee ID" Width="150" TextAlign="TextAlign.Right" IsPrimaryKey="true" IsFrozen="true"></GridColumn>
        <GridColumn Field=@nameof(EmployeeDetails.EmployeeName) HeaderText="Employee Name" Width="180" IsFrozen="@enableFrozen"></GridColumn>
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
        <!-- Disable spanning for this column -->
        <GridColumn Field=@nameof(EmployeeDetails.Time_3_30) HeaderText="3:30 PM" Width="150" TextAlign="TextAlign.Center" AutoSpan="AutoSpanMode.None"></GridColumn>
         <!-- Enable only HorizontalAndVertical spanning for the below columns -->
        <GridColumn Field=@nameof(EmployeeDetails.Time_4_00) HeaderText="4:00 PM" Width="150" TextAlign="TextAlign.Center" AutoSpan="AutoSpanMode.HorizontalAndVertical"></GridColumn>
        <GridColumn Field=@nameof(EmployeeDetails.Time_4_30) HeaderText="4:30 PM" Width="150" TextAlign="TextAlign.Center" AutoSpan="AutoSpanMode.HorizontalAndVertical"></GridColumn>
        <GridColumn Field=@nameof(EmployeeDetails.Time_5_00) HeaderText="5:00 PM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    private bool enableFrozen { get; set; } = true;
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

The effective spanning behavior in the Syncfusion Blazor DataGrid is determined by the intersection of grid-level and column-level `AutoSpan` modes. A column can only restrict the spanning directions permitted at the grid level and cannot enable a span direction that has been disabled globally. This ensures consistent behavior across the grid while allowing fine-grained control for individual columns.


### Complete Combination Matrix

| Grid AutoSpan | Column AutoSpan | Effective Behavior |
|---|---|---|
| None | None | No spanning. Both grid and column explicitly disable spanning. |
| None | Row | No spanning. Grid-level None overrides column-level Row. |
| None | Column | No spanning. Grid-level None overrides column-level Column. |
| None | HorizontalAndVertical | No spanning. Grid-level None overrides all spanning modes. |
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

## Applying Row Spanning via programmatically

In addition to automatic cell merging, the Syncfusion Blazor DataGrid provides API support for manually merging cells when custom layout behavior is required. This functionality is available through the `MergeCellsAsync` method, which enables the definition of rectangular regions of cells to be merged programmatically.

Use `MergeCellsAsync` method to manually merge cells by defining rectangular regions. This method supports both single and batch merging, allowing precise control over layout customization when automatic spanning is insufficient.

| Parameter | Type | Description |
|-----------|------|-------------|
| info | `MergeCellInfo` | Defines a single rectangular cell region to be merged. |
| infos | `IEnumerable<MergeCellInfo>` | Specifies multiple cell regions to be merged in a batch operation. Each region is defined by a `MergeCellInfo` instance. |

To define a merged region, use the following properties of the MergeCellInfo class,

| Property     | Type | Description                                                                 |
|--------------|------|-----------------------------------------------------------------------------|
| RowIndex     | int  | The zero-based index of the anchor row (top-left cell of the merged region). |
| ColumnIndex  | int  | The zero-based index of the anchor column (top-left cell of the merged region). |
| RowSpan      | int (optional) | The number of rows to span, starting from the anchor cell. By default set to 1. |
| ColumnSpan   | int (optional) | The number of columns to span, starting from the anchor cell. By default set to 1. |

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<button @onclick="MergeCellsAsync">Merge Cell</button>
<button @onclick="MergeMultipleCellsAsync">Merge Multiple Cells</button>

<SfGrid TValue="Order" @ref="Grid" DataSource="@Orders" AllowPaging="true" GridLines="GridLine.Both">
    <GridColumns>
        <GridColumn Field="@nameof(Order.OrderID)" HeaderText="Order ID" Width="120" />
        <GridColumn Field="@nameof(Order.CustomerID)" HeaderText="Customer ID" Width="150" />
        <GridColumn Field="@nameof(Order.Freight)" HeaderText="Freight" Format="C2" Width="120" />
    </GridColumns>
</SfGrid>

@code 
{
    private SfGrid<Order> Grid;
    public List<Order> Orders { get; set; }

    public async Task MergeCellsAsync()
    {
        await Grid.MergeCellsAsync(new MergeCellInfo
        {
            RowIndex = 1,
            ColumnIndex = 1,
            RowSpan = 2,
        });
    }

    public async Task MergeMultipleCellsAsync()
    {
        await Grid.MergeCellsAsync(new[]
        {
            new MergeCellInfo { RowIndex = 0, ColumnIndex = 0, RowSpan = 2 },
            new MergeCellInfo { RowIndex = 5, ColumnIndex = 2, RowSpan = 3 },
            new MergeCellInfo { RowIndex = 7, ColumnIndex = 1, RowSpan = 2 }
        });
    }

    protected override void OnInitialized()
    {
        Orders = Order.GetAllRecords();
    }
}
{% endhighlight %}
{% highlight c# tabtitle="Order.cs" %}

public class Order
{
    public static List<Order> OrdersList = new List<Order>();

    public Order() { }

    public Order(int? OrderID, string CustomerID, DateTime? OrderDate, double? Freight)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerID;
        this.OrderDate = OrderDate;
        this.Freight = Freight;
    }

    public static List<Order> GetAllRecords()
    {
        if (OrdersList.Count == 0)
        {
            OrdersList = new List<Order>()
            {
                new Order { OrderID = 1, CustomerID = "ALFKI", Freight = 23.45 },
                new Order { OrderID = 2, CustomerID = "ANATR", Freight = 15.60 },
                new Order { OrderID = 3, CustomerID = "ANTON", Freight = 42.10 },
                new Order { OrderID = 4, CustomerID = "AROUT", Freight = 18.75 },
                new Order { OrderID = 5, CustomerID = "BERGS", Freight = 33.20 },
                new Order { OrderID = 6, CustomerID = "BLAUS", Freight = 27.50 },
                new Order { OrderID = 7, CustomerID = "BLONP", Freight = 12.90 },
                new Order { OrderID = 8, CustomerID = "BOLID", Freight = 25.00 },
                new Order { OrderID = 9, CustomerID = "BONAP", Freight = 19.40 },
                new Order { OrderID = 10, CustomerID = "BOTTM", Freight = 30.10 },
                new Order { OrderID = 11, CustomerID = "BSBEV", Freight = 22.80 },
                new Order { OrderID = 12, CustomerID = "CACTU", Freight = 14.60 },
                new Order { OrderID = 13, CustomerID = "CENTC", Freight = 28.90 },
                new Order { OrderID = 14, CustomerID = "CHOPS", Freight = 35.25 },
                new Order { OrderID = 15, CustomerID = "COMMI", Freight = 40.00 },
                new Order { OrderID = 16, CustomerID = "CONSH", Freight = 21.70 },
                new Order { OrderID = 17, CustomerID = "DRACD", Freight = 17.30 },
                new Order { OrderID = 18, CustomerID = "DUMON", Freight = 29.50 },
                new Order { OrderID = 19, CustomerID = "EASTC", Freight = 24.80 },
                new Order { OrderID = 20, CustomerID = "ERNSH", Freight = 31.60 },
                new Order { OrderID = 21, CustomerID = "FAMIA", Freight = 26.40 },
                new Order { OrderID = 22, CustomerID = "FISSA", Freight = 13.75 },
                new Order { OrderID = 23, CustomerID = "FOLKO", Freight = 36.90 },
                new Order { OrderID = 24, CustomerID = "FRANK", Freight = 20.50 },
                new Order { OrderID = 25, CustomerID = "FRANR", Freight = 27.80 },
                new Order { OrderID = 26, CustomerID = "FRANS", Freight = 32.40 },
                new Order { OrderID = 27, CustomerID = "FURIB", Freight = 15.90 },
                new Order { OrderID = 28, CustomerID = "GALED", Freight = 23.70 },
                new Order { OrderID = 29, CustomerID = "GODOS", Freight = 38.20 },
                new Order { OrderID = 30, CustomerID = "GOURL", Freight = 19.95 }
            };
        }
        return OrdersList;
    }

    public int? OrderID { get; set; }
    public string CustomerID { get; set; }
    public DateTime? OrderDate { get; set; }
    public double? Freight { get; set; }
}

{% endhighlight %}
{% endtabs %}

## Clearing Spanning via programmatically

The Syncfusion Blazor DataGrid provides API support to manually remove merged regions when restoration of individual cells is required. This functionality is achieved using the `UnmergeCellsAsync` methods, which allow specific merged areas to be unmerged programmatically. For scenarios where all merged regions in the current view need to be reset, the `UnmergeAllAsync` method can be used to restore every cell to its original state.

| Method | Parameter | Type | Description |
|--------|-----------|------|-------------|
| `UnmergeCellsAsync` | info | `UnmergeCellInfo` | Removes a single merged area identified by its anchor cell (top‑left of the merged region). |
| `UnmergeCellsAsync` | infos | `IEnumerable<UnmergeCellInfo>` | Removes multiple merged areas in one combined operation, improving performance by reducing re‑renders. |
| `UnmergeAllAsync` | – | – | Removes all merged regions in the current view, restoring every cell to its original state. |

To identify a merged region, use the following properties of the UnmergeCellInfo class:

| Property     | Type | Description                                                                 |
|--------------|------|-----------------------------------------------------------------------------|
| RowIndex     | int  | The zero-based index of the anchor row (top-left cell of the merged region). |
| ColumnIndex  | int  | The zero-based index of the anchor column (top-left cell of the merged region). |

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons

<SfButton OnClick="MergeCellsAsync">Merge Cell</SfButton>
<SfButton OnClick="UnMergeCell">UnMerge Cell</SfButton>

<SfButton OnClick="MergeMultipleCellsAsync">Merge Multiple Cells</SfButton>
<SfButton OnClick="UnMergeCells">UnMerge Multiple Cells</SfButton>

<SfButton OnClick="UnMergeAllCells">UnMerge All Cells</SfButton>

<SfGrid TValue="Order" @ref="Grid" DataSource="@Orders" AllowPaging="true" GridLines="GridLine.Both">
    <GridColumns>
        <GridColumn Field="@nameof(Order.OrderID)" HeaderText="Order ID" Width="120" />
        <GridColumn Field="@nameof(Order.CustomerID)" HeaderText="Customer ID" Width="150" />
        <GridColumn Field="@nameof(Order.Freight)" HeaderText="Freight" Format="C2" Width="120" />
    </GridColumns>
</SfGrid>

@code
{
    private SfGrid<Order> Grid;
    public List<Order> Orders { get; set; }

    public async Task MergeCellsAsync()
    {
        await Grid.MergeCellsAsync(new MergeCellInfo
        {
            RowIndex = 1,
            ColumnIndex = 1,
            RowSpan = 2,
        });
    }

    public async Task UnMergeCell()
    {
        await Grid.UnmergeCellsAsync(new UnmergeCellInfo
        {
            RowIndex = 1,
            ColumnIndex = 1,
        });
    }

    public async Task MergeMultipleCellsAsync()
    {
        await Grid.MergeCellsAsync(new[]
        {
            new MergeCellInfo { RowIndex = 0, ColumnIndex = 0, RowSpan = 2 },
            new MergeCellInfo { RowIndex = 5, ColumnIndex = 2, RowSpan = 3 },
            new MergeCellInfo { RowIndex = 7, ColumnIndex = 1, RowSpan = 2 }
        });
    }

    public async Task UnMergeCells()
    {
        await Grid.UnmergeCellsAsync(new[]
        {
            new UnmergeCellInfo { RowIndex = 0, ColumnIndex = 0 },
            new UnmergeCellInfo { RowIndex = 5, ColumnIndex = 2 },
            new UnmergeCellInfo { RowIndex = 7, ColumnIndex = 1 }
        });
    }

    public async Task UnMergeAllCells()
    {
        await Grid.UnmergeAllAsync();
    }

    protected override void OnInitialized()
    {
        Orders = Order.GetAllRecords();
    }
}
{% endhighlight %}
{% highlight c# tabtitle="Order.cs" %}

public class Order
{
    public static List<Order> OrdersList = new List<Order>();

    public Order() { }

    public Order(int? OrderID, string CustomerID, DateTime? OrderDate, double? Freight)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerID;
        this.OrderDate = OrderDate;
        this.Freight = Freight;
    }

    public static List<Order> GetAllRecords()
    {
        if (OrdersList.Count == 0)
        {
            OrdersList = new List<Order>()
            {
                new Order { OrderID = 1, CustomerID = "ALFKI", Freight = 23.45 },
                new Order { OrderID = 2, CustomerID = "ANATR", Freight = 15.60 },
                new Order { OrderID = 3, CustomerID = "ANTON", Freight = 42.10 },
                new Order { OrderID = 4, CustomerID = "AROUT", Freight = 18.75 },
                new Order { OrderID = 5, CustomerID = "BERGS", Freight = 33.20 },
                new Order { OrderID = 6, CustomerID = "BLAUS", Freight = 27.50 },
                new Order { OrderID = 7, CustomerID = "BLONP", Freight = 12.90 },
                new Order { OrderID = 8, CustomerID = "BOLID", Freight = 25.00 },
                new Order { OrderID = 9, CustomerID = "BONAP", Freight = 19.40 },
                new Order { OrderID = 10, CustomerID = "BOTTM", Freight = 30.10 },
                new Order { OrderID = 11, CustomerID = "BSBEV", Freight = 22.80 },
                new Order { OrderID = 12, CustomerID = "CACTU", Freight = 14.60 },
                new Order { OrderID = 13, CustomerID = "CENTC", Freight = 28.90 },
                new Order { OrderID = 14, CustomerID = "CHOPS", Freight = 35.25 },
                new Order { OrderID = 15, CustomerID = "COMMI", Freight = 40.00 },
                new Order { OrderID = 16, CustomerID = "CONSH", Freight = 21.70 },
                new Order { OrderID = 17, CustomerID = "DRACD", Freight = 17.30 },
                new Order { OrderID = 18, CustomerID = "DUMON", Freight = 29.50 },
                new Order { OrderID = 19, CustomerID = "EASTC", Freight = 24.80 },
                new Order { OrderID = 20, CustomerID = "ERNSH", Freight = 31.60 },
                new Order { OrderID = 21, CustomerID = "FAMIA", Freight = 26.40 },
                new Order { OrderID = 22, CustomerID = "FISSA", Freight = 13.75 },
                new Order { OrderID = 23, CustomerID = "FOLKO", Freight = 36.90 },
                new Order { OrderID = 24, CustomerID = "FRANK", Freight = 20.50 },
                new Order { OrderID = 25, CustomerID = "FRANR", Freight = 27.80 },
                new Order { OrderID = 26, CustomerID = "FRANS", Freight = 32.40 },
                new Order { OrderID = 27, CustomerID = "FURIB", Freight = 15.90 },
                new Order { OrderID = 28, CustomerID = "GALED", Freight = 23.70 },
                new Order { OrderID = 29, CustomerID = "GODOS", Freight = 38.20 },
                new Order { OrderID = 30, CustomerID = "GOURL", Freight = 19.95 }
            };
        }
        return OrdersList;
    }

    public int? OrderID { get; set; }
    public string CustomerID { get; set; }
    public DateTime? OrderDate { get; set; }
    public double? Freight { get; set; }
}

{% endhighlight %}
{% endtabs %}

## Limitations

The Row spanning is not compatible with the following features:

1. Autofill.
2. Inline Editing. 
3. Grouping – Row and column spanning are supported only within the same caption row during grouping scenarios. This means cells can be merged horizontally or vertically only inside a single group header (caption row). Merging across different caption rows is not supported, since each caption row represents a distinct group context. Allowing spans between these rows would break the logical grouping structure and the visual hierarchy of the grid.
4. Frozen Grid – When the `Freeze` property is set to `FreezeDirection.Fixed`, the concerned column will not be included for row spanning.
