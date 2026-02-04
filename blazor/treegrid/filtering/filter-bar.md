---
layout: post
title: Filter Bar in Blazor Tree Grid Component | Syncfusion
description: Checkout and learn here all about Filter Bar in Syncfusion Blazor Tree Grid component and much more details.
platform: Blazor
control: Tree Grid
documentation: ug
---

# Filter Bar in Blazor Tree Grid Component

By setting the [AllowFiltering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor~Syncfusion.Blazor.TreeGrid.SfTreeGrid~AllowFiltering.html) to true, the filter bar row will render next to the header, which allows to filter data. The records can be filtered with different expressions depending upon the column type.

 **Filter bar expressions:**

 Enter the following filter expressions (operators) manually in the filter bar.

Expression | Example | Description | Column Type
---|---|---|---
= | =value | equal | Number
!= | !=value | notequal | Number
> | >value | greaterthan | Number
< | <value | lessthan | Number
>= | >=value | greaterthanorequal | Number
<= | <=value | lessthanorequal | Number
* | *value | startswith | String
% | %value | endswith | String
N/A | N/A | **Equal** operator will always be used for date filter. | Date
N/A | N/A | **Equal** operator will always be used for Boolean filter. | Boolean

{% tabs %}

{% highlight razor %}

@using TreeGridComponent.Data;
@using Syncfusion.Blazor.TreeGrid;
@using Syncfusion.Blazor.Data;

<SfTreeGrid IdMapping="TaskId" DataSource="@TreeGridData" ParentIdMapping="ParentId" TreeColumnIndex="1" AllowFiltering="true">
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
            public DateTime? StartDate { get; set; }
            public int? Duration { get; set;}
            public int? Progress { get; set;}
            public string Priority { get; set;}
            public int? ParentId { get; set;}
       
        public static List<BusinessObject> GetSelfDataSource()
        {
            List<BusinessObject> BusinessObjectCollection = new List<BusinessObject>();
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 1,TaskName = "Parent Task 1", StartDate = new DateTime(2017, 08, 12), Duration = 10,Progress = 70,Priority = "Critical",ParentId = null });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 2,TaskName = "Child task 1", StartDate = new DateTime(2017, 03, 2), Duration = 4,Progress = 80,Priority = "Low",ParentId = 1 });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 3,TaskName = "Child Task 2", StartDate = new DateTime(2017, 03, 6), Duration = 5,Progress = 65,Priority = "Critical",ParentId = 2 });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 4,TaskName = "Child task 3", StartDate = new DateTime(2017, 03, 9), Duration = 6,Priority = "High",Progress = 77,ParentId = 3 });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 5,TaskName = "Parent Task 2", StartDate = new DateTime(2017, 09, 12), Duration = 10,Progress = 70,Priority = "Critical",ParentId = null});
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 6,TaskName = "Child task 1", StartDate = new DateTime(2017, 04, 5), Duration = 4,Progress = 80,Priority = "Critical",ParentId = 5});
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 7,TaskName = "Child Task 2", StartDate = new DateTime(2017, 04, 8), Duration = 5,Progress = 65,Priority = "Low",ParentId = 5});
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 8,TaskName = "Child task 3", StartDate = new DateTime(2017, 04, 12), Duration = 6,Progress = 77,Priority = "High",ParentId = 5});
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 9,TaskName = "Child task 4", StartDate = new DateTime(2017, 05, 12), Duration = 6,Progress = 77,Priority = "Low",ParentId = 5});
            return BusinessObjectCollection;
        }
    }
}

{% endhighlight %}

{% endtabs %}

The following screenshot shows filtering using FilterBar
![Filtering in Blazor Tree Grid](../images/blazor-treegrid-filtering.png)

## Filter bar template with custom component

The [FilterTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridColumn.html#Syncfusion_Blazor_TreeGrid_TreeGridColumn_FilterTemplate) property is used to add custom components to a particular column. To access the filtered values inside the `FilterTemplate`, use the implicit named parameter context, which can be cast as `PredicateModel<T>` to get filter values inside the template.

In the following sample, the dropdown is used as a custom component in the Duration column.

{% tabs %}

{% highlight razor %}

@using TreeGridComponent.Data
@using Syncfusion.Blazor.TreeGrid
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.DropDowns
@using Syncfusion.Blazor.Grids

<SfTreeGrid @ref="TreeGrid"
            DataSource="@TreeGridData"
            IdMapping="TaskId"
            ParentIdMapping="ParentId"
            TreeColumnIndex="1"
            AllowFiltering="true">

    <TreeGridColumns>
        <TreeGridColumn Field="TaskId" HeaderText="Task ID" Width="80" TextAlign="TextAlign.Right" />
        <TreeGridColumn Field="TaskName" HeaderText="Task Name" Width="100" />
        <TreeGridColumn Field="StartDate" HeaderText="Start Date" Width="100" TextAlign="TextAlign.Right" />

        <TreeGridColumn Field="Duration" HeaderText="Duration" Width="100" TextAlign="TextAlign.Right">
            <FilterTemplate>
                @{
                    var predicate = context as PredicateModel;
                    var currentValue = predicate?.Value?.ToString(); // safe
                }

                <SfDropDownList TValue="string"
                                TItem="string"
                                DataSource="@DropDownData"
                                Value="@currentValue"
                                Placeholder="Select"
                                AllowFiltering="false">

                    <DropDownListEvents TValue="string"
                                        TItem="string"
                                        ValueChange="@OnDurationChange">
                    </DropDownListEvents>

                </SfDropDownList>
            </FilterTemplate>
        </TreeGridColumn>

        <TreeGridColumn Field="Progress" HeaderText="Progress" Width="100" TextAlign="TextAlign.Right" />
        <TreeGridColumn Field="Priority" HeaderText="Priority" Width="60" />
    </TreeGridColumns>
</SfTreeGrid>

@code {
    private SfTreeGrid<BusinessObject>? TreeGrid;

    public List<string> DropDownData { get; set; } = new();
    public List<BusinessObject> TreeGridData { get; set; } = new();

    protected override void OnInitialized()
    {
        TreeGridData = BusinessObject.GetSelfDataSource().ToList();

        DropDownData.AddRange(new[] { "10", "50", "5", "6", "4", "All" });
    }

    private async Task OnDurationChange(ChangeEventArgs<string, string> args)
    {
        if (TreeGrid is null) return;

        if (args?.Value == "All" || string.IsNullOrWhiteSpace(args?.Value))
        {
            await TreeGrid.ClearFilteringAsync(new List<string> { "Duration" });
        }
        else
        {
            await TreeGrid.FilterByColumnAsync("Duration", "equal", args.Value);
        }
    }
}

{% endhighlight %}

{% highlight c# %}

namespace TreeGridComponent.Data {

            public class BusinessObject
            {
                public int TaskId { get; set;}
                public string TaskName { get; set;}
                public DateTime? StartDate { get; set; }
                public int? Duration { get; set;}
                public int? Progress { get; set;}
                public string Priority { get; set;}
                public int? ParentId { get; set;}
        
            public static List<BusinessObject> GetSelfDataSource()
            {
                List<BusinessObject> BusinessObjectCollection = new List<BusinessObject>();
                BusinessObjectCollection.Add(new BusinessObject() { TaskId = 1,TaskName = "Parent Task 1", StartDate = new DateTime(2017, 08, 12), Duration = 10,Progress = 70,Priority = "Critical",ParentId = null });
                BusinessObjectCollection.Add(new BusinessObject() { TaskId = 2,TaskName = "Child task 1", StartDate = new DateTime(2017, 03, 2), Duration = 4,Progress = 80,Priority = "Low",ParentId = 1 });
                BusinessObjectCollection.Add(new BusinessObject() { TaskId = 3,TaskName = "Child Task 2", StartDate = new DateTime(2017, 03, 6), Duration = 5,Progress = 65,Priority = "Critical",ParentId = 2 });
                BusinessObjectCollection.Add(new BusinessObject() { TaskId = 4,TaskName = "Child task 3", StartDate = new DateTime(2017, 03, 9), Duration = 6,Priority = "High",Progress = 77,ParentId = 3 });
                BusinessObjectCollection.Add(new BusinessObject() { TaskId = 5,TaskName = "Parent Task 2", StartDate = new DateTime(2017, 09, 12), Duration = 10,Progress = 70,Priority = "Critical",ParentId = null});
                BusinessObjectCollection.Add(new BusinessObject() { TaskId = 6,TaskName = "Child task 1", StartDate = new DateTime(2017, 04, 5), Duration = 4,Progress = 80,Priority = "Critical",ParentId = 5});
                BusinessObjectCollection.Add(new BusinessObject() { TaskId = 7,TaskName = "Child Task 2", StartDate = new DateTime(2017, 04, 8), Duration = 5,Progress = 65,Priority = "Low",ParentId = 5});
                BusinessObjectCollection.Add(new BusinessObject() { TaskId = 8,TaskName = "Child task 3", StartDate = new DateTime(2017, 04, 12), Duration = 6,Progress = 77,Priority = "High",ParentId = 5});
                BusinessObjectCollection.Add(new BusinessObject() { TaskId = 9,TaskName = "Child task 4", StartDate = new DateTime(2017, 05, 12), Duration = 6,Progress = 77,Priority = "Low",ParentId = 5});
                return BusinessObjectCollection;
            }
        }
}

{% endhighlight %}

{% endtabs %}

![Blazor TreeGrid with Filter Template](../images/blazor-treegrid-filter-template.png)

## Change default filter operator

The default filter operator can be changed by extending the [FilterSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridColumn.html#Syncfusion_Blazor_TreeGrid_TreeGridColumn_FilterSettings) property in the column.

In the following sample, we have changed the default operator for TaskName column as **contains** from **startswith**

{% tabs %}

{% highlight razor %}

@using TreeGridComponent.Data;
@using  Syncfusion.Blazor.TreeGrid;
@using  Syncfusion.Blazor.Grids;
@using  Syncfusion.Blazor.Data;

<SfTreeGrid @ref="TreeGrid" DataSource="@TreeGridData" IdMapping="TaskId" ParentIdMapping="ParentId" TreeColumnIndex="1" AllowFiltering="true">    
    <TreeGridColumns>
        <TreeGridColumn Field="TaskId" HeaderText="Task ID" Width="80" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="TaskName" HeaderText="Task Name" Width="100" FilterSettings="@(new FilterSettings{ Operator = Operator.Contains })"></TreeGridColumn>
        <TreeGridColumn Field="StartDate" HeaderText="Start Date" Width="100" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="Duration" HeaderText="Duration" Width="100" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="Progress" HeaderText="Progress" Width="100" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="Priority" HeaderText="Priority" Width="60"></TreeGridColumn>
    </TreeGridColumns>
</SfTreeGrid>

@code{
    SfTreeGrid<BusinessObject> TreeGrid;

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
            public DateTime? StartDate { get; set; }
            public int? Duration { get; set;}
            public int? Progress { get; set;}
            public string Priority { get; set;}
            public int? ParentId { get; set;}
       
        public static List<BusinessObject> GetSelfDataSource()
        {
            List<BusinessObject> BusinessObjectCollection = new List<BusinessObject>();
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 1,TaskName = "Parent Task 1", StartDate = new DateTime(2017, 08, 12), Duration = 10,Progress = 70,Priority = "Critical",ParentId = null });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 2,TaskName = "Child task 1", StartDate = new DateTime(2017, 03, 2), Duration = 4,Progress = 80,Priority = "Low",ParentId = 1 });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 3,TaskName = "Child Task 2", StartDate = new DateTime(2017, 03, 6), Duration = 5,Progress = 65,Priority = "Critical",ParentId = 2 });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 4,TaskName = "Child task 3", StartDate = new DateTime(2017, 03, 9), Duration = 6,Priority = "High",Progress = 77,ParentId = 3 });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 5,TaskName = "Parent Task 2", StartDate = new DateTime(2017, 09, 12), Duration = 10,Progress = 70,Priority = "Critical",ParentId = null});
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 6,TaskName = "Child task 1", StartDate = new DateTime(2017, 04, 5), Duration = 4,Progress = 80,Priority = "Critical",ParentId = 5});
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 7,TaskName = "Child Task 2", StartDate = new DateTime(2017, 04, 8), Duration = 5,Progress = 65,Priority = "Low",ParentId = 5});
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 8,TaskName = "Child task 3", StartDate = new DateTime(2017, 04, 12), Duration = 6,Progress = 77,Priority = "High",ParentId = 5});
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 9,TaskName = "Child task 4", StartDate = new DateTime(2017, 05, 12), Duration = 6,Progress = 77,Priority = "Low",ParentId = 5});
            return BusinessObjectCollection;
        }
    }
}

{% endhighlight %}

{% endtabs %}

The following screenshot represents Filter with change in default operator as contains
![Changing Filter Operator in Blazor Tree Grid](../images/blazor-treegrid-filter-operator.png)

## Filter bar modes

By default, the filter bar [Mode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridFilterSettings.html#Syncfusion_Blazor_TreeGrid_TreeGridFilterSettings_Mode) is of the `OnEnter` type, so it is necessary to press the Enter key after typing a value in the filter bar.

It is also possible to perform a filtering operation without pressing the Enter key by setting the filter bar `Mode` property to [Immediate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.FilterBarMode.html#Syncfusion_Blazor_Grids_FilterBarMode_Immediate).

The [ImmediateModeDelay](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridFilterSettings.html#Syncfusion_Blazor_TreeGrid_TreeGridFilterSettings_ImmediateModeDelay) property of [TreeGridFilterSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridFilterSettings.html) is used to define the time, tree grid has to wait for performing filter operation.

{% tabs %}

{% highlight razor %}

@using TreeGridComponent.Data;
@using Syncfusion.Blazor.TreeGrid;
@using Syncfusion.Blazor.Grids;
@using Syncfusion.Blazor.Data;

<SfTreeGrid IdMapping="TaskId" DataSource="@TreeGridData" ParentIdMapping="ParentId" TreeColumnIndex="1" AllowFiltering="true">
    <TreeGridFilterSettings Mode="FilterBarMode.Immediate" ImmediateModeDelay="300"></TreeGridFilterSettings>
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
            public DateTime? StartDate { get; set; }
            public int? Duration { get; set;}
            public int? Progress { get; set;}
            public string Priority { get; set;}
            public int? ParentId { get; set;}
       
        public static List<BusinessObject> GetSelfDataSource()
        {
            List<BusinessObject> BusinessObjectCollection = new List<BusinessObject>();
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 1,TaskName = "Parent Task 1", StartDate = new DateTime(2017, 08, 12), Duration = 10,Progress = 70,Priority = "Critical",ParentId = null });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 2,TaskName = "Child task 1", StartDate = new DateTime(2017, 03, 2), Duration = 4,Progress = 80,Priority = "Low",ParentId = 1 });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 3,TaskName = "Child Task 2", StartDate = new DateTime(2017, 03, 6), Duration = 5,Progress = 65,Priority = "Critical",ParentId = 2 });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 4,TaskName = "Child task 3", StartDate = new DateTime(2017, 03, 9), Duration = 6,Priority = "High",Progress = 77,ParentId = 3 });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 5,TaskName = "Parent Task 2", StartDate = new DateTime(2017, 09, 12), Duration = 10,Progress = 70,Priority = "Critical",ParentId = null});
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 6,TaskName = "Child task 1", StartDate = new DateTime(2017, 04, 5), Duration = 4,Progress = 80,Priority = "Critical",ParentId = 5});
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 7,TaskName = "Child Task 2", StartDate = new DateTime(2017, 04, 8), Duration = 5,Progress = 65,Priority = "Low",ParentId = 5});
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 8,TaskName = "Child task 3", StartDate = new DateTime(2017, 04, 12), Duration = 6,Progress = 77,Priority = "High",ParentId = 5});
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 9,TaskName = "Child task 4", StartDate = new DateTime(2017, 05, 12), Duration = 6,Progress = 77,Priority = "Low",ParentId = 5});
            return BusinessObjectCollection;
        }
    }
}

{% endhighlight %}

{% endtabs %}
