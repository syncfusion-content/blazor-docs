---
layout: post
title: Sorting in Blazor TreeGrid Component | Syncfusion
description: Learn how to enable and configure sorting in the Syncfusion Blazor TreeGrid component, including multi-column sorting, initial sort, and sorting events.
platform: Blazor
control: TreeGrid
documentation: ug
---

# Sorting in Blazor TreeGrid Component

Sorting allows data to be organized in either **Ascending** or **Descending** order. A column can be sorted by clicking its header. For multi-column sorting, hold the `CTRL` key and click additional column headers. To clear sorting on a specific column, hold the `SHIFT` key and click the column header.

To enable sorting, set the [AllowSorting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_AllowSorting) property to `true`. Sorting behavior can be customized using the [TreeGridSortSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridSortSettings.html) component.

{% tabs %}

{% highlight razor %}

@using TreeGridComponent.Data;
@using Syncfusion.Blazor.TreeGrid;

<SfTreeGrid DataSource="@TreeGridData" AllowSorting="true" IdMapping="TaskId" ParentIdMapping="ParentId" TreeColumnIndex="1">
    <TreeGridSortSettings Columns="@Sort"></TreeGridSortSettings>
    <TreeGridColumns>
        <TreeGridColumn Field="TaskId" HeaderText="Task ID" Width="80" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="TaskName" HeaderText="Task Name" Width="160"></TreeGridColumn>
        <TreeGridColumn Field="Duration" HeaderText="Duration" Width="100" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="Progress" HeaderText="Progress" Width="100" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="Priority" HeaderText="Priority" Width="80"></TreeGridColumn>
    </TreeGridColumns>
</SfTreeGrid>

@code{
    public List<TreeData.BusinessObject> TreeGridData { get; set; }
    public List<TreeGridSortColumn> Sort { get; set; }
    protected override void OnInitialized()
    {
        this.Sort = new List<TreeGridSortColumn>();
        this.Sort.Add(new TreeGridSortColumn() { Field = "TaskName", Direction = Syncfusion.Blazor.Grids.SortDirection.Descending });

        this.TreeGridData = TreeData.GetSelfDataSource().ToList();
    }
}

{% endhighlight %}

{% highlight c# %}

namespace TreeGridComponent.Data {

public class TreeData
    {
        public class BusinessObject
        {
            public int TaskId { get; set;}
            public string TaskName { get; set;}
            public int? Duration { get; set;}
            public int? Progress { get; set;}
            public string Priority { get; set;}
            public int? ParentId { get; set;}
        }

        public static List<BusinessObject> GetSelfDataSource()
        {
            List<BusinessObject> BusinessObjectCollection = new List<BusinessObject>();
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 1,TaskName = "Parent Task 1",Duration = 10,Progress = 70,Priority = "Critical",ParentId = null });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 2,TaskName = "Child task 1",Progress = 80,Priority = "Low",ParentId = 1 });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 3,TaskName = "Child Task 2",Duration = 5,Progress = 65,Priority = "Critical",ParentId = 2 });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 4,TaskName = "Child task 3",Duration = 6,Priority = "High",Progress = 77,ParentId = 3 });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 5,TaskName = "Parent Task 2",Duration = 10,Progress = 70,Priority = "Critical",ParentId = null});
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 6,TaskName = "Child task 1",Duration = 4,Progress = 80,Priority = "Critical",ParentId = 5});
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 7,TaskName = "Child Task 2",Duration = 5,Progress = 65,Priority = "Low",ParentId = 5});
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 8,TaskName = "Child task 3",Duration = 6,Progress = 77,Priority = "High",ParentId = 5});
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 9,TaskName = "Child task 4",Duration = 6,Progress = 77,Priority = "Low",ParentId = 5});
            return BusinessObjectCollection;
        }
    }
}

{% endhighlight %}

{% endtabs %}

N> * TreeGrid columns are sorted in the **Ascending** order. Clicking an already sorted column toggles its sort direction.
<br/> * Apply and clear sorting by invoking [SortByColumnAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_SortByColumnAsync_System_String_Syncfusion_Blazor_Grids_SortDirection_System_Nullable_System_Boolean__) and [ClearSortingAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_ClearSortingAsync) methods.
<br/> * To disable sorting for a particular column, set the [AllowSorting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridColumn.html#Syncfusion_Blazor_TreeGrid_TreeGridColumn_AllowSorting) property of [Column](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridColumn.html#Syncfusion_Blazor_TreeGrid_TreeGridColumn_Columns) to **false**.

## Initial Sort

To apply sorting during initial rendering, define the **Field** and **Direction** in the [Columns](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridSortSettings.html#Syncfusion_Blazor_TreeGrid_TreeGridSortSettings_Columns) property of [SortSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_SortSettings).

{% tabs %}

{% highlight razor %}

@using TreeGridComponent.Data;
@using Syncfusion.Blazor.TreeGrid;

<SfTreeGrid DataSource="@TreeGridData" AllowSorting="true" IdMapping="TaskId" ParentIdMapping="ParentId" TreeColumnIndex="1">
    <TreeGridSortSettings>
        <TreeGridSortColumns>
            <TreeGridSortColumn Field="TaskName" Direction="Syncfusion.Blazor.Grids.SortDirection.Descending"></TreeGridSortColumn>
        </TreeGridSortColumns>
    </TreeGridSortSettings>
    <TreeGridColumns>
        <TreeGridColumn Field="TaskId" HeaderText="Task ID" Width="80" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="TaskName" HeaderText="Task Name" Width="160"></TreeGridColumn>
        <TreeGridColumn Field="Duration" HeaderText="Duration" Width="100" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="Progress" HeaderText="Progress" Width="100" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="Priority" HeaderText="Priority" Width="80"></TreeGridColumn>
    </TreeGridColumns>
</SfTreeGrid>

@code{
    public List<TreeData.BusinessObject> TreeGridData { get; set; }
    protected override void OnInitialized()
    {       
        this.TreeGridData = TreeData.GetSelfDataSource().ToList();
    }
}

{% endhighlight %}

{% highlight c# %}

namespace TreeGridComponent.Data {

public class TreeData
    {
        public class BusinessObject
        {
            public int TaskId { get; set;}
            public string TaskName { get; set;}
            public int? Duration { get; set;}
            public int? Progress { get; set;}
            public string Priority { get; set;}
            public int? ParentId { get; set;}
        }

        public static List<BusinessObject> GetSelfDataSource()
        {
            List<BusinessObject> BusinessObjectCollection = new List<BusinessObject>();
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 1,TaskName = "Parent Task 1",Duration = 10,Progress = 70,Priority = "Critical",ParentId = null });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 2,TaskName = "Child task 1",Progress = 80,Priority = "Low",ParentId = 1 });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 3,TaskName = "Child Task 2",Duration = 5,Progress = 65,Priority = "Critical",ParentId = 2 });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 4,TaskName = "Child task 3",Duration = 6,Priority = "High",Progress = 77,ParentId = 3 });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 5,TaskName = "Parent Task 2",Duration = 10,Progress = 70,Priority = "Critical",ParentId = null});
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 6,TaskName = "Child task 1",Duration = 4,Progress = 80,Priority = "Critical",ParentId = 5});
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 7,TaskName = "Child Task 2",Duration = 5,Progress = 65,Priority = "Low",ParentId = 5});
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 8,TaskName = "Child task 3",Duration = 6,Progress = 77,Priority = "High",ParentId = 5});
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 9,TaskName = "Child task 4",Duration = 6,Progress = 77,Priority = "Low",ParentId = 5});
            return BusinessObjectCollection;
        }
    }
}

{% endhighlight %}

{% endtabs %}

![Sorting in Blazor TreeGrid](images/blazor-treegrid-sorting.png)

## Sorting Events

During the sort action, the TreeGrid component triggers two events. The [ActionBegin](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridEvents-1.html#Syncfusion_Blazor_TreeGrid_TreeGridEvents_1_OnActionBegin) event triggers before the sort action starts, and the [ActionComplete](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridEvents-1.html#Syncfusion_Blazor_TreeGrid_TreeGridEvents_1_OnActionComplete) event triggers after the sort action is completed. Using these events the needed actions can be performed.

{% tabs %}

{% highlight razor %}

@using TreeGridComponent.Data;
@using Syncfusion.Blazor.TreeGrid;
@inject IJSRuntime  JsRuntime;

<SfTreeGrid DataSource="@TreeGridData" AllowSorting="true" IdMapping="TaskId" ParentIdMapping="ParentId" TreeColumnIndex="1">
    <TreeGridEvents Sorting="SortingHandler" Sorted="SortedHandler" TValue="TreeData"></TreeGridEvents>
    <TreeGridColumns>
        <TreeGridColumn Field="TaskId" HeaderText="Task ID" Width="80" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="TaskName" HeaderText="Task Name" Width="160"></TreeGridColumn>
        <TreeGridColumn Field="Duration" HeaderText="Duration" Width="100" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="Progress" HeaderText="Progress" Width="100" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="Priority" HeaderText="Priority" Width="80"></TreeGridColumn>
    </TreeGridColumns>
</SfTreeGrid>

@code {

    public List<TreeData> TreeGridData { get; set; }

    protected override void OnInitialized()
    {
        this.TreeGridData = TreeData.GetSelfDataSource().ToList();
    }

    private void SortingHandler(SortingEventArgs args)
    {
        JsRuntime.InvokeAsync<string>("window.alert", args.RequestType.ToString());
    }

    private void SortedHandler(SortedEventArgs args)
    {
        JsRuntime.InvokeAsync<string>("window.alert", args.RequestType.ToString());
    }
}

{% endhighlight %}

{% highlight c# %}

namespace TreeGridComponent.Data {

public class TreeData
    {
       
            public int TaskId { get; set;}
            public string TaskName { get; set;}
            public int? Duration { get; set;}
            public int? Progress { get; set;}
            public string Priority { get; set;}
            public int? ParentId { get; set;}
       
        public static List<TreeData> GetSelfDataSource()
        {
            List<TreeData> TreeDataCollection = new List<TreeData>();
            TreeDataCollection.Add(new TreeData() { TaskId = 1,TaskName = "Parent Task 1",Duration = 10,Progress = 70,Priority = "Critical",ParentId = null });
            TreeDataCollection.Add(new TreeData() { TaskId = 2,TaskName = "Child task 1",Progress = 80,Priority = "Low",ParentId = 1 });
            TreeDataCollection.Add(new TreeData() { TaskId = 3,TaskName = "Child Task 2",Duration = 5,Progress = 65,Priority = "Critical",ParentId = 2 });
            TreeDataCollection.Add(new TreeData() { TaskId = 4,TaskName = "Child task 3",Duration = 6,Priority = "High",Progress = 77,ParentId = 3 });
            TreeDataCollection.Add(new TreeData() { TaskId = 5,TaskName = "Parent Task 2",Duration = 10,Progress = 70,Priority = "Critical",ParentId = null});
            TreeDataCollection.Add(new TreeData() { TaskId = 6,TaskName = "Child task 1",Duration = 4,Progress = 80,Priority = "Critical",ParentId = 5});
            TreeDataCollection.Add(new TreeData() { TaskId = 7,TaskName = "Child Task 2",Duration = 5,Progress = 65,Priority = "Low",ParentId = 5});
            TreeDataCollection.Add(new TreeData() { TaskId = 8,TaskName = "Child task 3",Duration = 6,Progress = 77,Priority = "High",ParentId = 5});
            TreeDataCollection.Add(new TreeData() { TaskId = 9,TaskName = "Child task 4",Duration = 6,Progress = 77,Priority = "Low",ParentId = 5});
            return TreeDataCollection;
        }
    }
}

{% endhighlight %}

{% endtabs %}

N> The **args.requestType** is the current action name. For example, in sorting the **args.requestType** value is *sorting*. 

## Touch Interaction

When the TreeGrid header is tapped on the touchscreen devices, the selected column header is sorted. A popup ![Multi column sorting](images/sorting.jpg) is displayed for the multi-column sorting. To sort multiple columns, tap the popup![Multi sorting](images/msorting.jpg), and then tap the desired TreeGrid headers.

<!-- markdownlint-disable MD033 -->
<img src="images/blazor-treegrid-touch-sorting.jpg" alt="Sorting in Blazor TreeGrid" style="width:320px;height: 620px">
<!-- markdownlint-enable MD033 -->

## Custom sorting 

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor TreeGrid provides a way to customize the default sort action for a column by defining the [SortComparer](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_SortComparer) property of TreeGridColumn. The SortComparer data type uses the IComparer interface, so the custom sort comparer class should be implemented in the interface [IComparer](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.icomparer-1?view=net-7.0&viewFallbackFrom=net-5).

Custom sorting in this TreeGrid example enhances project management by allowing the **Priority** column to be sorted based on a predefined hierarchy (Critical, High, Normal, Low) instead of alphabetical order.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.TreeGrid
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Navigations
<div class="col-lg-12 control-section">
    <div class="content-wrapper">
        <div class="row">
            <SfTreeGrid DataSource="@TreeGridData" IdMapping="TaskId" ParentIdMapping="ParentId" TreeColumnIndex="1" AllowSorting=true Height="312">
                <TreeGridEvents TValue="WrapData" OnToolbarClick="ToolBarClick"></TreeGridEvents>
                <TreeGridColumns>
                    <TreeGridColumn Field="TaskId" HeaderText="Task ID" Width="83" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
                    <TreeGridColumn Field="TaskName" HeaderText="Task Name" Width="260"></TreeGridColumn>
                    <TreeGridColumn Field="StartDate" HeaderText="Start Date" Format="d" Type=Syncfusion.Blazor.Grids.ColumnType.Date Width="106" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
                    <TreeGridColumn Field="EndDate" HeaderText=" End Date" Format="d" Type=Syncfusion.Blazor.Grids.ColumnType.Date Width="106" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
                    <TreeGridColumn Field="Duration" HeaderText="Duration" Width="100" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
                    <TreeGridColumn Field="Progress" HeaderText="Progress" Width="110"></TreeGridColumn>
                    <TreeGridColumn Field="Priority" HeaderText="Priority" SortComparer="new CustomComparer()" Width="100"></TreeGridColumn>
                </TreeGridColumns>
            </SfTreeGrid>
        </div>
    </div>
</div>
<style>
    .e-treegrid {
        border: none;
        background: white;
        border-radius: 8px;
        overflow: hidden;
        font-family: 'Segoe UI', -apple-system, BlinkMacSystemFont, sans-serif;
    }

    .e-gridheader {
        background: #3b5998;
        color: white;
    }

    .e-headercell {
        padding: 12px !important;
        font-weight: 600;
    }

    .e-row {
        transition: background-color 0.2s;
    }

        .e-row:hover {
            background-color: #f0f4ff;
        }

    .e-treecell {
        padding: 10px;
        color: #333;
    }

    .e-treegrid .e-rowcell {
        border-bottom: 1px solid #e0e0e0;
    }

    .e-rowcell[aria-colindex="7"] {
        font-weight: 500;
    }
</style>

@code {
    private List<WrapData> TreeGridData { get; set; } = new List<WrapData>();
    private double RowHeightValue { get; set; } = 20;
    private List<ItemModel> ToolbarTools { get; set; } = new List<ItemModel>();

    protected override void OnInitialized()
    {
        this.TreeGridData = WrapData.GetWrapData().ToList();
    }

    public void ToolBarClick(Syncfusion.Blazor.Navigations.ClickEventArgs Args)
    {
        if (Args.Item.Id == "small")
        {
            RowHeightValue = 20;
        }
        if (Args.Item.Id == "medium")
        {
            RowHeightValue = 40;
        }
        if (Args.Item.Id == "big")
        {
            RowHeightValue = 60;
        }
    }

    public class CustomComparer : IComparer<object>
    {
        private static readonly Dictionary<string, int> PriorityOrder = new()
        {
            { "Low", 1 },
            { "Normal", 2 },
            { "High", 3 },
            { "Critical", 4 }
        };

        public int Compare(object XRowDataToCompare, object YRowDataToCompare)
        {
            var xx = XRowDataToCompare as WrapData;
            var yy = YRowDataToCompare as WrapData;
            string stringX = xx?.Priority.ToString() ?? string.Empty;
            string stringY = yy?.Priority.ToString() ?? string.Empty;

            int priorityX = PriorityOrder.GetValueOrDefault(stringX, 1);
            int priorityY = PriorityOrder.GetValueOrDefault(stringY, 1);

            if (priorityX == priorityY)
            {
                return 0;
            }
            else if (priorityX > priorityY)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }
    }
}
{% endhighlight %}
{% highlight c# tabtitle="WrapData.cs" %}
public class WrapData
{
    public int? TaskId { get; set; }
    public string? TaskName { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public int? Duration { get; set; }
    public String? Progress { get; set; }
    public string? Priority { get; set; }
    public bool Approved { get; set; }
    public int Resources { get; set; }
    public int? ParentId { get; set; }

    public static List<WrapData> GetWrapData()
    {
        List<WrapData> BusinessObjectCollection = new List<WrapData>();

        // Parent 1: Project Initiation
        BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 1,
                TaskName = "Project Initiation",
                StartDate = new DateTime(2026, 03, 02),
                EndDate = new DateTime(2026, 03, 08),
                Progress = "Open",
                Duration = 6,
                Priority = "Normal",
                Resources = 6,
                Approved = false,
                ParentId = null
            });
        BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 2,
                TaskName = "Stakeholder Analysis",
                StartDate = new DateTime(2026, 03, 03),
                EndDate = new DateTime(2026, 03, 06),
                Progress = "In Progress",
                Duration = 3,
                Resources = 4,
                Priority = "High",
                Approved = true,
                ParentId = 1
            });
        BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 3,
                TaskName = "Project Charter",
                StartDate = new DateTime(2026, 03, 04),
                EndDate = new DateTime(2026, 03, 13),
                Progress = "Started",
                Duration = 9,
                Resources = 3,
                Priority = "Normal",
                Approved = false,
                ParentId = 1
            });
        BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 4,
                TaskName = "Resource Planning",
                StartDate = new DateTime(2026, 03, 05),
                EndDate = new DateTime(2026, 03, 09),
                Progress = "Open",
                Duration = 4,
                Resources = 5,
                Priority = "Critical",
                Approved = false,
                ParentId = 1
            });
        BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 5,
                TaskName = "Risk Assessment",
                StartDate = new DateTime(2026, 03, 06),
                EndDate = new DateTime(2026, 03, 13),
                Progress = "In Progress",
                Duration = 7,
                Resources = 4,
                Priority = "Low",
                Approved = true,
                ParentId = 1
            });

        // Parent 2: Design Phase
        BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 6,
                TaskName = "Design Phase",
                StartDate = new DateTime(2026, 04, 01),
                EndDate = new DateTime(2026, 04, 10),
                Progress = "Open",
                Duration = 9,
                Priority = "High",
                Resources = 5,
                Approved = false,
                ParentId = null
            });
        BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 7,
                TaskName = "UI Design",
                StartDate = new DateTime(2026, 04, 02),
                EndDate = new DateTime(2026, 04, 07),
                Progress = "In Progress",
                Duration = 5,
                Resources = 3,
                Priority = "Normal",
                Approved = true,
                ParentId = 6
            });
        BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 8,
                TaskName = "Database Design",
                StartDate = new DateTime(2026, 04, 03),
                EndDate = new DateTime(2026, 04, 06),
                Progress = "Started",
                Duration = 3,
                Resources = 4,
                Priority = "Critical",
                Approved = false,
                ParentId = 6
            });
        BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 9,
                TaskName = "API Specification",
                StartDate = new DateTime(2026, 04, 04),
                EndDate = new DateTime(2026, 04, 12),
                Progress = "Open",
                Duration = 8,
                Resources = 3,
                Priority = "Low",
                Approved = true,
                ParentId = 6
            });
        BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 10,
                TaskName = "Prototype Development",
                StartDate = new DateTime(2026, 04, 05),
                EndDate = new DateTime(2026, 04, 11),
                Progress = "In Progress",
                Duration = 6,
                Resources = 5,
                Priority = "Normal",
                Approved = false,
                ParentId = 6
            });

        // Parent 3: Development Phase
        BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 11,
                TaskName = "Development Phase",
                StartDate = new DateTime(2026, 05, 01),
                EndDate = new DateTime(2026, 05, 08),
                Progress = "Open",
                Duration = 7,
                Priority = "Low",
                Resources = 6,
                Approved = false,
                ParentId = null
            });
        BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 12,
                TaskName = "Frontend Development",
                StartDate = new DateTime(2026, 05, 02),
                EndDate = new DateTime(2026, 05, 10),
                Progress = "In Progress",
                Duration = 8,
                Resources = 4,
                Priority = "High",
                Approved = true,
                ParentId = 11
            });
        BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 13,
                TaskName = "Backend Development",
                StartDate = new DateTime(2026, 05, 03),
                EndDate = new DateTime(2026, 05, 07),
                Progress = "Started",
                Duration = 4,
                Resources = 5,
                Priority = "Critical",
                Approved = false,
                ParentId = 11
            });
        BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 14,
                TaskName = "API Integration",
                StartDate = new DateTime(2026, 05, 04),
                EndDate = new DateTime(2026, 05, 09),
                Progress = "Open",
                Duration = 5,
                Resources = 3,
                Priority = "Normal",
                Approved = true,
                ParentId = 11
            });
        BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 15,
                TaskName = "Module Testing",
                StartDate = new DateTime(2026, 05, 05),
                EndDate = new DateTime(2026, 05, 15),
                Progress = "In Progress",
                Duration = 10,
                Resources = 4,
                Priority = "Low",
                Approved = false,
                ParentId = 11
            });

        // Parent 4: Testing Phase
        BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 16,
                TaskName = "Testing Phase",
                StartDate = new DateTime(2026, 06, 01),
                EndDate = new DateTime(2026, 06, 06),
                Progress = "Open",
                Duration = 5,
                Priority = "Critical",
                Resources = 5,
                Approved = false,
                ParentId = null
            });
        BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 17,
                TaskName = "Unit Testing",
                StartDate = new DateTime(2026, 06, 02),
                EndDate = new DateTime(2026, 06, 05),
                Progress = "In Progress",
                Duration = 3,
                Resources = 3,
                Priority = "High",
                Approved = true,
                ParentId = 16
            });
        BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 18,
                TaskName = "Integration Testing",
                StartDate = new DateTime(2026, 06, 03),
                EndDate = new DateTime(2026, 06, 11),
                Progress = "Started",
                Duration = 8,
                Resources = 4,
                Priority = "Normal",
                Approved = false,
                ParentId = 16
            });
        BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 19,
                TaskName = "Performance Testing",
                StartDate = new DateTime(2026, 06, 04),
                EndDate = new DateTime(2026, 06, 08),
                Progress = "Open",
                Duration = 4,
                Resources = 3,
                Priority = "Low",
                Approved = true,
                ParentId = 16
            });
        BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 20,
                TaskName = "Bug Fixing",
                StartDate = new DateTime(2026, 06, 05),
                EndDate = new DateTime(2026, 06, 12),
                Progress = "In Progress",
                Duration = 7,
                Resources = 5,
                Priority = "Critical",
                Approved = false,
                ParentId = 16
            });

        // Parent 5: Deployment Phase
        BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 21,
                TaskName = "Deployment Phase",
                StartDate = new DateTime(2026, 07, 01),
                EndDate = new DateTime(2026, 07, 09),
                Progress = "Open",
                Duration = 8,
                Priority = "Normal",
                Resources = 6,
                Approved = false,
                ParentId = null
            });
        BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 22,
                TaskName = "Environment Setup",
                StartDate = new DateTime(2026, 07, 02),
                EndDate = new DateTime(2026, 07, 07),
                Progress = "In Progress",
                Duration = 5,
                Resources = 4,
                Priority = "High",
                Approved = true,
                ParentId = 21
            });
        BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 23,
                TaskName = "Data Migration",
                StartDate = new DateTime(2026, 07, 03),
                EndDate = new DateTime(2026, 07, 10),
                Progress = "Started",
                Duration = 7,
                Resources = 5,
                Priority = "Normal",
                Approved = false,
                ParentId = 21
            });
        BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 24,
                TaskName = "User Training",
                StartDate = new DateTime(2026, 07, 04),
                EndDate = new DateTime(2026, 07, 07),
                Progress = "Open",
                Duration = 3,
                Resources = 3,
                Priority = "Low",
                Approved = true,
                ParentId = 21
            });
        BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 25,
                TaskName = "Final Deployment",
                StartDate = new DateTime(2026, 07, 05),
                EndDate = new DateTime(2026, 07, 14),
                Progress = "In Progress",
                Duration = 9,
                Resources = 4,
                Priority = "Critical",
                Approved = false,
                ParentId = 21
            });

        return BusinessObjectCollection;
    }
}
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rZhSsZrHyPAzZEUF?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> * The SortComparer function takes two parameters: a and b. The a and b parameters are the values to be compared. The function returns -1, 0, or 1, depending on the comparison result.
> * The SortComparer property will work only for local data.
> * When using the column template to display data in a column, you will need to use the [Field](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridColumn.html#Syncfusion_Blazor_TreeGrid_TreeGridColumn_Field) property of [TreeGridColumn](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridColumn.html) to work with the [SortComparer](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_SortComparer) property.