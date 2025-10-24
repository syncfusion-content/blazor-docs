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

Custom sorting in this TreeGrid example is useful for deriving insights beyond raw data, such as evaluating economic efficiency by sorting the **Area** column based on GDP per square kilometer (economic density) instead of just land size—allowing users to prioritize high-performing, densely productive regions like small states (e.g., California) over vast but less efficient ones (e.g., Russia) for better decision-making in geographic or economic analysis.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.TreeGrid
@using Syncfusion.Blazor.Grids
<SfTreeGrid @ref="_treegridRef" DataSource="@TreeGridData" IdMapping="@nameof(CountryData.ID)" ParentIdMapping="@nameof(CountryData.ParentID)" AllowSorting="true" Height="315" TreeColumnIndex="0">
    <TreeGridColumns>
        <TreeGridColumn Field=@nameof(CountryData.CountryName) TextAlign="Syncfusion.Blazor.Grids.TextAlign.Left" HeaderText="Country Name" Width="150"></TreeGridColumn>
        <TreeGridColumn Field=@nameof(CountryData.Population) HeaderText="Population" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Format="N0" Width="120"></TreeGridColumn>
        <TreeGridColumn Field=@nameof(CountryData.GDP) TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" HeaderText="GDP (in trillions USD)" Format="C2" Width="150"></TreeGridColumn>
        <TreeGridColumn Field=@nameof(CountryData.Area) TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" HeaderText="Area (sq km)" Format="N0" SortComparer="new CustomComparer()" Width="120"></TreeGridColumn>
        <TreeGridColumn Field=@nameof(CountryData.AverageTrade) TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" ClipMode=ClipMode.EllipsisWithTooltip HeaderText="Avg Trade (bn USD)" Format="C2" Width="130"></TreeGridColumn>
        <TreeGridColumn Field=@nameof(CountryData.PerCapitaGDP) TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" ClipMode=ClipMode.EllipsisWithTooltip HeaderText="Per Capita GDP (USD)" Format="C0" Width="130"></TreeGridColumn>
    </TreeGridColumns>
</SfTreeGrid>
<style>
    .e-treegrid .e-row {
        transition: background-color 0.3s ease;
    }
    .e-treegrid .e-row:hover {
        background-color: #e2e6ea !important;
    }
    .e-treegrid .e-row:nth-child(even) {
        background-color: #f8f9fa;
    }
    .e-treegrid .e-row:nth-child(odd) {
        background-color: #ffffff;
    }
    .e-treegrid .e-treegrid-expand, .e-treegrid .e-treegrid-collapse {
        color: #007bff;
    }
    .e-treegrid .e-altrow {
        background-color: #f0f4f8;
    }
    .e-treegrid .e-gridcontent {
        border: 1px solid #ced4da;
        border-radius: 0 0 4px 4px;
        box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
    }
</style>
@code {
    public List<CountryData> TreeGridData { get; set; }

    public static SfTreeGrid<CountryData>? _treegridRef;

    protected override void OnInitialized()
    {
        TreeGridData = CountryData.GetAllRecords();
    }

    public class CustomComparer : IComparer<object>
    {
        public int Compare(object XRowDataToCompare, object YRowDataToCompare)
        {
            var xDataItemProp = XRowDataToCompare.GetType().GetProperty("DataItem");
            var yDataItemProp = YRowDataToCompare.GetType().GetProperty("DataItem");

            var XRowData = xDataItemProp?.GetValue(XRowDataToCompare) as CountryData;
            var YRowData = yDataItemProp?.GetValue(YRowDataToCompare) as CountryData;

            // Compute economic density: GDP (trillions USD) * 1e12 / Area (sq km) to get USD per sq km
            double xEconDensity = XRowData != null && XRowData.Area > 0
                ? (XRowData.GDP * 1_000_000_000_000) / XRowData.Area
                : 0;
            double yEconDensity = YRowData != null && YRowData.Area > 0
                ? (YRowData.GDP * 1_000_000_000_000) / YRowData.Area
                : 0;

            if (xEconDensity > yEconDensity)
            {
                return -1;
            }
            else if (xEconDensity < yEconDensity)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
{% endhighlight %}
{% highlight c# tabtitle="CountryData.cs" %}
   public class CountryData
    {
        public static List<CountryData> Data = new List<CountryData>();

        public CountryData()
        {
        }

        public CountryData(int ID, string Name, long Population, double GDP, long Area, double AverageTrade, double PerCapitaGDP, int? ParentID = null)
        {
            this.ID = ID;
            this.CountryName = Name;
            this.Population = Population;
            this.GDP = GDP;
            this.Area = Area;
            this.AverageTrade = AverageTrade;
            this.PerCapitaGDP = PerCapitaGDP;
            this.ParentID = ParentID;
        }

        public static List<CountryData> GetAllRecords()
        {
            if (Data.Count() == 0)
            {
                // Countries
                Data.Add(new CountryData(1, "USA", 331000000, 22.67, 9833517, 6800, 68430));
                // States/Provinces for USA
                Data.Add(new CountryData(6, "California", 39500000, 3.10, 423970, 810, 78481, 1));
                Data.Add(new CountryData(7, "Texas", 29000000, 1.80, 695662, 470, 62069, 1));
                Data.Add(new CountryData(8, "New York", 20000000, 1.70, 141297, 410, 85000, 1));

                Data.Add(new CountryData(2, "China", 1441000000, 17.73, 9596961, 5100, 12310));
                // For China
                Data.Add(new CountryData(9, "Guangdong", 126000000, 1.90, 179800, 650, 15079, 2));
                Data.Add(new CountryData(10, "Jiangsu", 85000000, 1.60, 102600, 510, 18824, 2));
                Data.Add(new CountryData(11, "Shandong", 101000000, 1.20, 157100, 400, 11881, 2));

                Data.Add(new CountryData(3, "India", 1380000000, 3.17, 3287263, 900, 2297));
                // For India
                Data.Add(new CountryData(12, "Uttar Pradesh", 240000000, 0.30, 243290, 80, 1250, 3));
                Data.Add(new CountryData(13, "Maharashtra", 124000000, 0.40, 307713, 110, 3226, 3));
                Data.Add(new CountryData(14, "Bihar", 128000000, 0.10, 94163, 40, 781, 3));

                Data.Add(new CountryData(4, "Brazil", 213000000, 2.44, 8515767, 750, 11458));

                // For Brazil
                Data.Add(new CountryData(15, "São Paulo", 46000000, 0.70, 248209, 190, 15217, 4));
                Data.Add(new CountryData(16, "Rio de Janeiro", 17000000, 0.30, 43696, 90, 17647, 4));
                Data.Add(new CountryData(17, "Minas Gerais", 21000000, 0.25, 586528, 70, 11905, 4));

                Data.Add(new CountryData(5, "Russia", 146000000, 1.83, 17125191, 1100, 12540));

                // For Russia
                Data.Add(new CountryData(18, "Moscow Oblast", 13000000, 0.40, 44300, 130, 30769, 5));
                Data.Add(new CountryData(19, "Saint Petersburg", 5000000, 0.15, 13291, 60, 30000, 5));
                Data.Add(new CountryData(20, "Krasnodar Krai", 5600000, 0.10, 75485, 50, 17857, 5));
            }
            return Data;
        }
        public int ID { get; set; }
        public string CountryName { get; set; }
        public long Population { get; set; }
        public double GDP { get; set; }
        public long Area { get; set; }
        public double AverageTrade { get; set; } // in billions USD
        public double PerCapitaGDP { get; set; } // in USD
        public int? ParentID { get; set; }
    }
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rtLSMjLAzqrUHREe?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> * The SortComparer function takes two parameters: a and b. The a and b parameters are the values to be compared. The function returns -1, 0, or 1, depending on the comparison result.
> * The SortComparer property will work only for local data.
> * When using the column template to display data in a column, you will need to use the [Field](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridColumn.html#Syncfusion_Blazor_TreeGrid_TreeGridColumn_Field) property of [TreeGridColumn](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridColumn.html) to work with the [SortComparer](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_SortComparer) property.