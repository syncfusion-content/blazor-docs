---
layout: post
title: Filtering in Blazor Tree Grid Component | Syncfusion
description: Checkout and learn here all about filtering in Syncfusion Blazor Tree Grid component and much more details.
platform: Blazor
control: Tree Grid
documentation: ug
---

# Filtering in Blazor Tree Grid Component

Filtering allows to view specific or related records based on the filter criteria. To enable filtering in the Tree Grid, set the [AllowFiltering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_AllowFiltering) to true. Filtering options can be configured through the [FilterSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_FilterSettings).

To know about filtering data in Blazor tree grid component, you can check on this video.

{% youtube
"youtube:https://www.youtube.com/watch?v=7lhP9qa-UqY"%}

{% tabs %}

{% highlight razor %}

@using TreeGridComponent.Data;
@using  Syncfusion.Blazor.TreeGrid;
@using  Syncfusion.Blazor.Data;

<SfTreeGrid DataSource="@TreeGridData" IdMapping="TaskId" ParentIdMapping="ParentId" TreeColumnIndex="1" AllowFiltering="true">
    <TreeGridColumns>
        <TreeGridColumn Field="TaskId" HeaderText="Task ID" Width="80" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="TaskName" HeaderText="Task Name" Width="100"></TreeGridColumn>
        <TreeGridColumn Field="StartDate" HeaderText="Start Date" Width="100" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="Duration" HeaderText="Duration" Width="100" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="Progress" HeaderText="Progress" Width="100" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="Priority" HeaderText="Priority" Width="60"></TreeGridColumn>
    </TreeGridColumns>
</SfTreeGrid>

@code{
    public List<BusinessObject> TreeGridData { get; set; }

    protected override void OnInitialized()
    {
        this.TreeGridData = BusinessObject.GetSelfDataSource().ToList();
    }
}

{% endhighlight %}

{% highlight c# %}

namespace TreeGridComponent.Data {

        public class BusinessObject
        {
            public int TaskId { get; set;}
            public string TaskName { get; set;}
            public int? Duration { get; set;}
            public int? Progress { get; set;}
            public string Priority { get; set;}
            public int? ParentId { get; set;}
       
        public static List<BusinessObject> GetSelfDataSource()
        {
            List<BusinessObject> BusinessObjectCollection = new List<BusinessObject>();
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 1,TaskName = "Parent Task 1",Duration = 10,Progress = 70,Priority = "Critical",ParentId = null });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 2,TaskName = "Child task 1",Duration = 4,Progress = 80,Priority = "Low",ParentId = 1 });
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

![Filtering in Blazor Tree Grid](../images/blazor-treegrid-filtering.png)

N> * Apply and clear filtering by using the [FilterByColumnAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_FilterByColumnAsync_System_String_System_String_System_Object_System_String_System_Nullable_System_Boolean__System_Nullable_System_Boolean__System_String_System_String_) and [ClearFilteringAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_ClearFilteringAsync) methods.
<br/> * To disable filtering for a particular column, set the `AllowFiltering` property of [Column](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_Columns) to false.

## Filter hierarchy modes

Tree Grid provides support for a set of filtering modes with [HierarchyMode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_FilterSettings#Syncfusion_Blazor_TreeGrid_TreeGridFilterSettings_HierarchyMode) of [FilterSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_FilterSettings) property. The below are the types of filter mode available in the Tree Grid.

* **Parent** : This is the default filter hierarchy mode in the Tree Grid. The filtered records are displayed with its parent records, if the filtered records not have any parent record then the filtered records are only displayed.

* **Child** : The filtered records are displayed with its child record, if the filtered records does not have any child record then the filtered records are only displayed.

* **Both** : The filtered records are displayed with its both parent and child record, if the filtered records does not have any parent and child record then the filtered records are only displayed.

* **None** : The filtered records are only displayed.

## Initial filter

To apply the filter at initial rendering, set the filter **PredicateModel** in [Columns](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_FilterSettings#Syncfusion_Blazor_TreeGrid_TreeGridFilterSettings_Columns) property of the [FilterSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_FilterSettings).

{% tabs %}

{% highlight razor %}

@using TreeGridComponent.Data;
@using Syncfusion.Blazor.TreeGrid;
@using Syncfusion.Blazor.Data;
@using Syncfusion.Blazor.Grids;

<SfTreeGrid IdMapping="TaskId" DataSource="@TreeGridData" AllowFiltering="true" ParentIdMapping="ParentId" TreeColumnIndex="1">
    <TreeGridFilterSettings>
        <TreeGridFilterColumns>
            <TreeGridFilterColumn Field="TaskName" MatchCase="false" Operator="Syncfusion.Blazor.Operator.StartsWith" Predicate="and" Value="@Name"></TreeGridFilterColumn>
            <TreeGridFilterColumn Field="Duration" MatchCase="false" Operator="Syncfusion.Blazor.Operator.Equal" Predicate="and" Value="@Duration"></TreeGridFilterColumn>
        </TreeGridFilterColumns>
    </TreeGridFilterSettings>
    <TreeGridColumns>
        <TreeGridColumn Field="TaskId" HeaderText="Task ID" Width="80" TextAlign="@TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="TaskName" HeaderText="Task Name" Width="160"></TreeGridColumn>
        <TreeGridColumn Field="Duration" HeaderText="Duration" Width="100" TextAlign="@TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="Progress" HeaderText="Progress" Width="100" TextAlign="@TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="Priority" HeaderText="Priority" Width="80"></TreeGridColumn>
    </TreeGridColumns>
</SfTreeGrid>

@code{

    public string Name { get; set; } = "Child";

    public int Duration { get; set; } = 5;

    public List<BusinessObject> TreeGridData { get; set; }

    protected override void OnInitialized()
    {
        this.TreeGridData = BusinessObject.GetSelfDataSource().ToList();
    }
}

{% endhighlight %}

{% highlight c# %}

namespace TreeGridComponent.Data {

        public class BusinessObject
        {
            public int TaskId { get; set;}
            public string TaskName { get; set;}
            public int? Duration { get; set;}
            public int? Progress { get; set;}
            public string Priority { get; set;}
            public int? ParentId { get; set;}
       
        public static List<BusinessObject> GetSelfDataSource()
        {
            List<BusinessObject> BusinessObjectCollection = new List<BusinessObject>();
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 1,TaskName = "Parent Task 1",Duration = 10,Progress = 70,Priority = "Critical",ParentId = null });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 2,TaskName = "Child task 1",Duration = 4,Progress = 80,Priority = "Low",ParentId = 1 });
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

![Blazor Tree Grid with Initial Filter](../images/blazor-treegrid-initial-filter.png)

## Filter operators

The filter operator for a column can be defined in the **Operator** property of the [Columns](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_FilterSettings#Syncfusion_Blazor_TreeGrid_TreeGridFilterSettings_Columns) property of the [FilterSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_FilterSettings).

The available operators and its supported data types are:

Operator |Description |Supported Types
-----|-----|-----
startswith |Checks whether the value begins with the specified value. |String
doesnotstartswith |Checks whether the value does not begins with the specified value. |String
endswith |Checks whether the value ends with the specified value. |String
doesnotendswith |Checks whether the value does not ends with the specified value. |String
contains |Checks whether the value contains the specified value. |String
doesnotcontains |Checks whether the value does not contains the specified value. |String
empty |Checks whether the value is empty. |String
notempty |Checks whether the value is not empty. |String
like |It process single search patterns using the '%' symbol, retrieving values matching the specified patterns. |String
wildcard |It process one or more search patterns using the '*' symbol, retrieving values matching the specified patterns. |String
equal |Checks whether the value is equal to the specified value. |String &#124; Number &#124; Boolean &#124; Date
notequal |Checks for values not equal to the specified value. |String &#124; Number &#124; Boolean &#124; Date
greaterthan |Checks whether the value is greater than the specified value. |Number &#124; Date
greaterthanorequal|Checks whether a value is greater than or equal to the specified value. |Number &#124; Date
lessthan |Checks whether the value is lesser than the specified value. |Number &#124; Date
lessthanorequal |Checks whether the value is lesser than or equal to the specified value. |Number &#124; Date
null |Checks whether the value is null. |Number &#124; Date
notnull |Checks whether the value is not null. |Number &#124; Date

N> By default, the [Operator](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridFilterSettings.html#Syncfusion_Blazor_TreeGrid_TreeGridFilterSettings_Operators) value is **equal**.

## Wildcard and LIKE operator filter

**Wildcard** and **LIKE** filter operators filters the value based on the given string pattern, and they apply to string-type columns. But it will work slightly differently.

### Wildcard filtering

The **Wildcard** filter can process one or more search patterns using the "*" symbol, retrieving values matching the specified patterns.

* The **Wildcard** filter option is supported for the tree grid that has all search options.

**For example:**

Operator |Description
-----|-----
a*b |Everything that starts with "a" and ends with "b".
a* |Everything that starts with "a".
*b |Everything that ends with "b".
*a* |Everything that has an "a" in it.
*a*b* |Everything that has an "a" in it, followed by anything, followed by a "b", followed by anything.

The following image illustrates the behavior of the **Wildcard** operator in the filter

![WildcardFilter](../images/blazor-treegrid-wildcard-search.gif) 

> When using the **Wildcard** filter operator in a tree grid, records can be filtered using different filter [HierarchyMode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_FilterSettings#Syncfusion_Blazor_TreeGrid_TreeGridFilterSettings_HierarchyMode) of the [FilterSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_FilterSettings) property. The filtered records are displayed according to the filter hierarchy mode specified in the `FilterSettings` property. For further details on the filter hierarchy mode, refer to [this section](https://blazor.syncfusion.com/documentation/treegrid/filtering/filtering#filter-hierarchy-modes).

### LIKE filtering

The **LIKE** filter can process single search patterns using the "%" symbol, retrieving values matching the specified patterns. The following tree grid features support **LIKE** filtering on string-type columns:

* Filter Menu
* Custom Filter of Excel filter type.

**For example:**

Operator |Description
-----|-----
%ab% |Returns all the value that are contains "ab" character.
ab% |Returns all the value that are ends with "ab" character.
%ab |Returns all the value that are starts with "ab" character.

The following image illustrates the behavior of the **LIKE** operator in the filter.

![LIKEFilter](../images/blazor-treegrid-like_filter.gif)

> When using the **LIKE** filter operator in a tree grid, records can be filtered using different filter [HierarchyMode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_FilterSettings#Syncfusion_Blazor_TreeGrid_TreeGridFilterSettings_HierarchyMode) of the [FilterSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_FilterSettings) property. The filtered records are displayed according to the filter hierarchy mode specified in the `FilterSettings` property. For further details on the filter hierarchy mode, refer to [this section](https://blazor.syncfusion.com/documentation/treegrid/filtering/filtering#filter-hierarchy-modes).

## Filter enum column

Filter the enum type data in the tree grid column using the Filter Template feature of the tree grid.

In the following sample, the enumerated list data is bound to the Priority column and the `SfDropDownList` component is rendered in the [FilterTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_Columns#Syncfusion_Blazor_TreeGrid_TreeGridColumn_FilterTemplate) for the Priority column.  

In the [ValueChange](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.DropDownListEvents-2.html#Syncfusion_Blazor_DropDowns_DropDownListEvents_2_ValueChange) event of the `SfDropDownList`, dynamically filter the Type column using the [FilterByColumnAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_FilterByColumnAsync_System_String_System_String_System_Object_System_String_System_Nullable_System_Boolean__System_Nullable_System_Boolean__System_String_System_String_) method of the tree grid.

{% tabs %}

{% highlight razor %}

@using TreeGridComponent.Data;
@using Syncfusion.Blazor.TreeGrid
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.DropDowns
<div class="col-lg-12 control-section">
    <div class="content-wrapper">
        <div class="row">
            <SfTreeGrid @ref="TreeGrid" DataSource="@TreeData" AllowFiltering="true" IdMapping="TaskID" ParentIdMapping="ParentID" TreeColumnIndex="1">
                <TreeGridColumns>
                    <TreeGridColumn Field="TaskID" HeaderText="Task ID" Width="80" TextAlign="TextAlign.Right"></TreeGridColumn>
                    <TreeGridColumn Field="TaskName" HeaderText="Task Name" Width="145"></TreeGridColumn>
                    <TreeGridColumn Field="Duration" HeaderText="Duration" Width="100" TextAlign="TextAlign.Right"></TreeGridColumn>
                    <TreeGridColumn Field="Progress" HeaderText="Progress" Width="200"></TreeGridColumn>
                    <TreeGridColumn Field="Priority" HeaderText="Priority" Width="200">
                        <FilterTemplate>
                            <SfDropDownList Placeholder="Priority" ID="Priority" Value="@((string)(context as PredicateModel).Value)" DataSource="@FilterDropData" TValue="string" TItem="Data">
                                <DropDownListEvents TItem="Data" ValueChange="Change" TValue="string"></DropDownListEvents>
                                <DropDownListFieldSettings Value="Priority" Text="Priority"></DropDownListFieldSettings>
                            </SfDropDownList>
                        </FilterTemplate>
                    </TreeGridColumn>
                </TreeGridColumns>
            </SfTreeGrid>
        </div>
    </div>
</div>

@code{
    public SfTreeGrid<SelfReferenceData> TreeGrid;
    private List<SelfReferenceData> TreeData { get; set; }
    protected override void OnInitialized()
    {
        this.TreeData = SelfReferenceData.GetTree().Take(50).ToList();
    }
    public enum Prioritize : short
    {
        High = 1,
        Low = 2,
        Critical = 3
    }
    public class Data
    {
        public string Priority { get; set; }
    }
    List<Data> FilterDropData = new List<Data>
    {
        new Data() { Priority= "All" },
        new Data() { Priority= "High" },
        new Data() { Priority= "Low" },
        new Data() { Priority= "Critical" }
    };
    public async Task Change(ChangeEventArgs<string, Data> args)
    {
        if (args.Value == "All")
        {
           await this.TreeGrid.ClearFilteringAsync();
        }
        else
        {
            await this.TreeGrid.FilterByColumnAsync("Priority", "contains", args.Value);
        }
    }
}

{% endhighlight %}

{% highlight c# %}

namespace TreeGridComponent.Data {

        public class SelfReferenceData
        {
        public static List<SelfReferenceData> tree = new List<SelfReferenceData>();
        public int? TaskID { get; set; }
        public string TaskName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public String Progress { get; set; }
        public Prioritize Priority { get; set; }
        public double? Duration { get; set; }
        public int? ParentID { get; set; }
        public bool? IsParent { get; set; }
        public int? ParentItem { get; set;}
        public SelfReferenceData() { }
        public static List<SelfReferenceData> GetTree()
        {
                tree.Clear();
                int root = -1;
                int TaskNameID = 0;
                int ChildCount = -1;
                int SubTaskCount = -1;
                var values = Enum.GetValues(typeof(Prioritize));
                for (var t = 1; t <= 60; t++)
                {
                Random gen = new Random();
                Random ran = new Random();
                DateTime start = new DateTime(2021, 06, 07);
                int range = (DateTime.Today - start).Days;
                DateTime startingDate = start.AddDays(gen.Next(range));
                DateTime end = new DateTime(2023, 08, 25);
                int endrange = (end - DateTime.Today).Days;
                DateTime endingDate = end.AddDays(gen.Next(endrange));
                    string progr = (ran.Next() % 3) == 0 ? "Started" : (ran.Next() % 2) == 0 ? "Open" : "In Progress";
                    bool appr = (ran.Next() % 3) == 0 ? true : (ran.Next() % 2) == 0 ? false : true;
                    root++; TaskNameID++;
                    int rootItem = root + 1;
                    tree.Add(new SelfReferenceData() { TaskID = rootItem, TaskName = "Parent task " + TaskNameID.ToString(), StartDate = startingDate, EndDate = endingDate, IsParent = true, ParentID = null, Progress = progr, Priority = (Prioritize)(values.GetValue(gen.Next(values.Length))), Duration = ran.Next(1, 50) });
                    int parent = tree.Count;
                    for (var c = 0; c < 2; c++)
                    {
                    DateTime start1 = new DateTime(2021, 07, 09);
                    int range1 = (DateTime.Today - start1).Days;
                    DateTime startingDate1 = start1.AddDays(gen.Next(range1));
                    DateTime end1 = new DateTime(2022, 08, 23);
                    int endrange1 = (end1 - DateTime.Today).Days;
                    DateTime endingDate1 = end1.AddDays(gen.Next(endrange1));
                    root++; ChildCount++;
                        int parn = parent + c + 1;
                        progr = (ran.Next() % 3) == 0 ? "In Progress" : (ran.Next() % 2) == 0 ? "Open" : "Validated";
                        appr = (ran.Next() % 3) == 0 ? true : (ran.Next() % 2) == 0 ? false : true;
                        int iD = root + 1;
                        tree.Add(new SelfReferenceData() { TaskID = iD, TaskName = "Child task " + (ChildCount + 1).ToString(), StartDate = startingDate1, EndDate = endingDate1, IsParent = (((parent + c + 1) % 3) == 0), ParentID = rootItem, Progress = progr, Priority = (Prioritize)(values.GetValue(gen.Next(values.Length))), Duration = ran.Next(1, 50) });
                        if ((((parent + c + 1) % 3) == 0))
                        {
                        int immParent = tree.Count;
                            for (var s = 0; s < 3; s++)
                            {
                            DateTime start2 = new DateTime(2021, 05, 05);
                            int range2 = (DateTime.Today - start2).Days;
                            DateTime startingDate2 = start2.AddDays(gen.Next(range2));
                            DateTime end2 = new DateTime(2024, 06, 16);
                            int endrange2 = (end2 - DateTime.Today).Days;
                            DateTime endingDate2 = end2.AddDays(gen.Next(endrange2));
                            root++; SubTaskCount++;
                                tree.Add(new SelfReferenceData() { TaskID = root + 1, TaskName = "Sub task " + (SubTaskCount + 1).ToString(), StartDate = startingDate2, EndDate = endingDate2, IsParent = false, ParentID = iD, Progress = (immParent % 2 == 0) ? "In Progress" : "Closed", Priority = (Prioritize)(values.GetValue(gen.Next(values.Length))), Duration = ran.Next(1, 50) });
                            }
                        }
                    }
                }
            return tree;
        }
    }
}

{% endhighlight %}

{% endtabs %}
