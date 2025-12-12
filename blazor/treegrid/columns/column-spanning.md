---
layout: post
title: Column spanning in Blazor Tree Grid Component | Syncfusion
description: Check out here and learn more details about the Column spanning in the Syncfusion Blazor Tree Grid component.
platform: Blazor
control: Tree Grid
documentation: ug
---

# Column spanning in Blazor Tree Grid Component

The column spanning feature in the Syncfusion<sup style="font-size:70%">&reg;</sup> Tree Grid allows automatically merging cells with identical values in the same row across consecutive columns. This significantly enhances readability and delivers a clean, professional look by eliminating repetitive data.

To enable column spanning, set the [AutoSpan](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_AutoSpan) property to **AutoSpanMode.Column** in the Tree Grid configuration.

In the following example, cells in rows are automatically merged when they have identical values in consecutive columns. The `AutoSpan` mode in this example can be dynamically changed using the dropdown selector. It is initially set to **Column** mode, allowing you to easily switch between different spanning modes to understand how row and column spanning work in practice.

{% tabs %}

{% highlight razor %}

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.TreeGrid
@using Syncfusion.Blazor.DropDowns
@using Syncfusion.Blazor.Buttons

<div class="form-row alt">
    <div class="left">
        <label class="e-option">Select AutoSpan Mode:</label>
        <SfDropDownList TValue="string" TItem="string"
                        DataSource="@modes"
                        Value="@selectedMode"
                        Width="auto">
            <DropDownListEvents TItem="string" ValueChange="OnModeChanged" TValue="string"></DropDownListEvents>
        </SfDropDownList>
    </div>
</div>
 <br/>
<SfTreeGrid @ref="TreeGridInstance" DataSource="@TreeData" IdMapping="Id" EnableHover ParentIdMapping="ParentId"  AutoSpan="@currentMode" TreeColumnIndex="1" GridLines="GridLine.Both">
    <TreeGridColumns>
        <TreeGridColumn Field="Id"  HeaderText="ID" Width="80" TextAlign="TextAlign.Center" IsPrimaryKey></TreeGridColumn>
        <TreeGridColumn Field="Name" HeaderText="Developer" Width="150"></TreeGridColumn>
        <TreeGridColumn Field="Slot1" HeaderText="10:00 - 11:00 AM" Width="150" ></TreeGridColumn>
        <TreeGridColumn Field="Slot2" HeaderText="11:00 - 12:00 AM" Width="150"></TreeGridColumn>
        <TreeGridColumn Field="Slot3" HeaderText="12:00 - 13:00 PM" Width="150"></TreeGridColumn>
        <TreeGridColumn Field="Slot4" HeaderText="01:00 - 02:00 PM" Width="150"></TreeGridColumn>
        <TreeGridColumn Field="Slot5" HeaderText="02:00 - 03:00 PM" Width="150"></TreeGridColumn>
        <TreeGridColumn Field="Slot6" HeaderText="03:00 - 04:00 PM" Width="150"></TreeGridColumn>
        <TreeGridColumn Field="Slot7" HeaderText="04:00 - 05:00 PM" Width="150"></TreeGridColumn>
    </TreeGridColumns>
</SfTreeGrid>


@code {
    private AutoSpanMode currentMode = AutoSpanMode.Column;
    private string selectedMode = "Column";
    private List<string> modes = new() { "None", "Row", "Column", "Horizontal and Vertical" };
    public SfTreeGrid<DeveloperSchedule> TreeGridInstance;
    public List<DeveloperSchedule> TreeData { get; set; }

    protected override void OnInitialized()
    {
        TreeData = DeveloperSchedule.GetTree().ToList();
    }

    private void OnModeChanged(ChangeEventArgs<string, string> args)
    {
        selectedMode = args?.Value ?? "None";
        currentMode = selectedMode switch
        {
            "Row" => AutoSpanMode.Row,
            "Column" => AutoSpanMode.Column,
            "Horizontal and Vertical" => AutoSpanMode.HorizontalAndVertical,
            _ => AutoSpanMode.None
        };
    }
}

{% endhighlight %}

{% highlight c# %}
namespace TreeGridComponent.Data {

    public class DeveloperSchedule
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slot1 { get; set; }
        public string Slot2 { get; set; }
        public string Slot3 { get; set; }
        public string Slot4 { get; set; }
        public string Slot5 { get; set; }
        public string Slot6 { get; set; }
        public string Slot7 { get; set; }
        public int? ParentId { get; set; }
        public bool IsExpanded { get; set; }

        public static List<DeveloperSchedule> GetTree()
        {
            List<DeveloperSchedule> Developers = new List<DeveloperSchedule>
            {
                new DeveloperSchedule { Id = 1, Name = "Martin", Slot1 = "Feature Dev", Slot2 = "Bug Fixing", Slot3 = "Team Sync", Slot4 = "Lunch Break", Slot5 = "Testing", Slot6 = "Planning", Slot7 = "Code Review", IsExpanded = false },
                new DeveloperSchedule { Id = 2, ParentId = 1, Name = "Vance", Slot1 = "Bug Fixing", Slot2 = "Bug Fixing", Slot3 = "Team Sync", Slot4 = "Lunch Break", Slot5 = "Planning", Slot6 = "Code Review", Slot7 = "Feature Dev" },
                new DeveloperSchedule { Id = 3, ParentId = 2, Name = "Charlie", Slot1 = "Team Sync", Slot2 = "Team Sync", Slot3 = "Testing", Slot4 = "Lunch Break", Slot5 = "Feature Dev", Slot6 = "Code Review", Slot7 = "Bug Fixing" },
                new DeveloperSchedule { Id = 4, Name = "Taylor", Slot1 = "Team Sync", Slot2 = "Bug Fixing", Slot3 = "Planning", Slot4 = "Lunch Break", Slot5 = "Testing", Slot6 = "Bug Fixing", Slot7 = "Planning", IsExpanded = false },
                new DeveloperSchedule { Id = 5, ParentId = 4, Name = "Anderson", Slot1 = "Testing", Slot2 = "Planning", Slot3 = "Code Review", Slot4 = "Lunch Break", Slot5 = "Bug Fixing", Slot6 = "Testing", Slot7 = "Planning" },
                new DeveloperSchedule { Id = 6, ParentId = 5, Name = "Chris", Slot1 = "Planning", Slot2 = "Code Review", Slot3 = "Feature Dev", Slot4 = "Lunch Break", Slot5 = "Testing", Slot6 = "Team Sync", Slot7 = "Testing" },
                new DeveloperSchedule { Id = 7, Name = "Elizabeth", Slot1 = "Code Review", Slot2 = "Feature Dev", Slot3 = "Bug Fixing", Slot4 = "Lunch Break", Slot5 = "Testing", Slot6 = "Code Review", Slot7 = "Planning", IsExpanded = false },
                new DeveloperSchedule { Id = 8, ParentId = 7, Name = "Robert", Slot1 = "Feature Dev", Slot2 = "Bug Fixing", Slot3 = "Bug Fixing", Slot4 = "Lunch Break", Slot5 = "Testing", Slot6 = "Planning", Slot7 = "Code Review" },
                new DeveloperSchedule { Id = 9, ParentId = 8, Name = "Smith", Slot1 = "Bug Fixing", Slot2 = "Testing", Slot3 = "Team Sync", Slot4 = "Lunch Break", Slot5 = "Planning", Slot6 = "Planning", Slot7 = "Feature Dev" },
                new DeveloperSchedule { Id = 10, ParentId = 7, Name = "John", Slot1 = "Scrum", Slot2 = "Team Sync", Slot3 = "Testing", Slot4 = "Lunch Break", Slot5 = "Code Review", Slot6 = "Feature Dev", Slot7 = "Bug Fixing" }
            };
            return Developers;
        }
    }
}
{% endhighlight %}

{% endtabs %}

N> In the above example, notice how cells with identical consecutive values across columns in each row are automatically merged horizontally, creating a cleaner view. For instance, when consecutive time slots have the same activity value, they span across multiple columns.

## Limitations

Column spanning feature is not compatible with all the features which are available in Tree Grid and it has limited features support. Here we have listed out the features which are not compatible with column spanning feature.

* Virtualization
* Infinite Scrolling
* Row Drag and Drop
* Column Virtualization
* Detail Template
* Editing
* Export

## See Also

* [Row spanning in Syncfusion<sup style="font-size:70%">&reg;</sup> TreeGrid](https://ej2.syncfusion.com/blazor/documentation/treegrid/rows/row-spanning)
