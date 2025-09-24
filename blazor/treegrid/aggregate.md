---
layout: post
title: Aggregate in Blazor TreeGrid Component | Syncfusion
description: Learn all about aggregate functionality in the Syncfusion Blazor TreeGrid component  and much more.
platform: Blazor
control: TreeGrid
documentation: ug
---

# Aggregate in Syncfusion Blazor TreeGrid Component

To learn about aggregate functionality in the Blazor TreeGrid component, refer to this video:

{% youtube
"youtube:https://www.youtube.com/watch?v=h-yS0PTLaXk"%}

Aggregate values are displayed in the TreeGrid footer and in parent row footers for child row aggregate values. This can be configured using the [TreeGridAggregateColumn](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridAggregateColumn.html) property. The [Field](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridAggregateColumn.html#Syncfusion_Blazor_TreeGrid_TreeGridAggregateColumn_Field) and [Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridAggregateColumn.html#Syncfusion_Blazor_TreeGrid_TreeGridAggregateColumn_Type) are the minimum required properties to define an aggregate column.

To display aggregate values in a specific cell, use the [FooterTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridAggregateColumn.html#Syncfusion_Blazor_TreeGrid_TreeGridAggregateColumn_FooterTemplate).

## Built-in Aggregate Types

Specify the aggregate type using the [Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridAggregateColumn.html#Syncfusion_Blazor_TreeGrid_TreeGridAggregateColumn_Type) property. Supported types include:

- Sum  
- Average  
- Min  
- Max  
- Count  
- TrueCount  
- FalseCount  

## Footer Aggregate

Footer aggregate values are calculated across all rows and displayed in the footer cells. Use the [FooterTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridAggregateColumn.html#Syncfusion_Blazor_TreeGrid_TreeGridAggregateColumn_FooterTemplate) to render these values.

{% tabs %}

{% highlight razor %}

@using TreeGridComponent.Data;
@using Syncfusion.Blazor.TreeGrid;

<SfTreeGrid DataSource="@TreeGridData" IdMapping="TaskId" ParentIdMapping="ParentId" AllowPaging="true" TreeColumnIndex="1">
    <TreeGridAggregates>
        <TreeGridAggregate ShowChildSummary="false">
            <TreeGridAggregateColumns>
                <TreeGridAggregateColumn Field="Duration" Type="Syncfusion.Blazor.Grids.AggregateType.Sum" Format="C2">
                    <FooterTemplate>
                        @{
                            var sumvalue = (context as Syncfusion.Blazor.Grids.AggregateTemplateContext);
                            <div>
                                <p>Sum: @sumvalue.Sum</p>
                            </div>
                        }
                    </FooterTemplate>
                </TreeGridAggregateColumn>
                <TreeGridAggregateColumn Field="Approved" Type="Syncfusion.Blazor.Grids.AggregateType.TrueCount" Format="C2">
                    <FooterTemplate>
                        @{
                            var truecount = (context as Syncfusion.Blazor.Grids.AggregateTemplateContext);
                            <div>
                                <p>Approved: @truecount.TrueCount</p>
                            </div>
                        }
                    </FooterTemplate>
                </TreeGridAggregateColumn>              
            </TreeGridAggregateColumns>
        </TreeGridAggregate>
    </TreeGridAggregates>
    <TreeGridColumns>
        <TreeGridColumn Field="TaskId" HeaderText="Task ID" Width="80" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="TaskName" HeaderText="Task Name" Width="100"></TreeGridColumn>
        <TreeGridColumn Field="Duration" HeaderText="Duration" Width="100" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="Progress" HeaderText="Progress" Width="100" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="Approved" HeaderText="Approved" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Center" DisplayAsCheckBox="true" Width="100">
        </TreeGridColumn>
    </TreeGridColumns>
</SfTreeGrid>

@code{
    public List<TreeData> TreeGridData { get; set; }

    public Syncfusion.Blazor.Grids.AggregateTemplateContext model = new Syncfusion.Blazor.Grids.AggregateTemplateContext();

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
            public int TaskId { get; set; }
            public string TaskName { get; set; }
            public DateTime? StartDate { get; set; }
            public int? Duration { get; set; }
            public int? Progress { get; set; }
            public bool Approved { get; set; }
            public int? ParentId { get; set; }
        
        public static List<TreeData> GetSelfDataSource()
        {
            List<TreeData> TreeDataCollection = new List<TreeData>();
            TreeDataCollection.Add(new TreeData() { TaskId = 1, TaskName = "Parent Task 1", Duration = 10, Progress = 70, Approved = true, ParentId = null });
            TreeDataCollection.Add(new TreeData() { TaskId = 2, TaskName = "Child task 1", Duration = 4, Progress = 80, Approved = false, Duration = 50, ParentId = 1 });
            TreeDataCollection.Add(new TreeData() { TaskId = 3, TaskName = "Child Task 2", Duration = 5, Progress = 65, Approved = true, ParentId = 2 });
            TreeDataCollection.Add(new TreeData() { TaskId = 4, TaskName = "Child task 3", Duration = 6, Approved = false, Progress = 77, ParentId = 3 });
            TreeDataCollection.Add(new TreeData() { TaskId = 5, TaskName = "Parent Task 2", Duration = 10, Progress = 70, Approved = true, ParentId = null });
            TreeDataCollection.Add(new TreeData() { TaskId = 6, TaskName = "Child task 1", Duration = 4, Progress = 80, Approved = false, ParentId = 5 });
            TreeDataCollection.Add(new TreeData() { TaskId = 7, TaskName = "Child Task 2", Duration = 5, Progress = 65, Approved = true, ParentId = 5 });
            TreeDataCollection.Add(new TreeData() { TaskId = 8, TaskName = "Child task 3", Duration = 6, Progress = 77, Approved = false, ParentId = 5 });
            TreeDataCollection.Add(new TreeData() { TaskId = 9, TaskName = "Child task 4", Duration = 6, Progress = 77, Approved = true, ParentId = 5 });
            return TreeDataCollection;
        }
    }
}

{% endhighlight %}

{% endtabs %}

![Footer Aggregate in Blazor TreeGrid](images/blazor-treegrid-footer-aggregate.png)

N> The aggregate values must be accessed inside the template using their corresponding `AggregateType`.

## How to Format Aggregate Value

Aggregate results can be formatted using the [Format](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridAggregateColumn.html#Syncfusion_Blazor_TreeGrid_TreeGridAggregateColumn_Format) property.

{% tabs %}

{% highlight razor %}

@using TreeGridComponent.Data;
@using Syncfusion.Blazor.TreeGrid;

<SfTreeGrid DataSource="@TreeGridData" IdMapping="TaskId" ParentIdMapping="ParentId" AllowPaging="true" TreeColumnIndex="1">
    <TreeGridAggregates>
        <TreeGridAggregate ShowChildSummary="false">
            <TreeGridAggregateColumns>
                <TreeGridAggregateColumn Field="Duration" Type="Syncfusion.Blazor.Grids.AggregateType.Sum" Format="C2">
                    <FooterTemplate>
                        @{
                            var sumvalue = (context as Syncfusion.Blazor.Grids.AggregateTemplateContext);
                            <div>
                                <p>Sum: @sumvalue.Sum</p>
                            </div>
                        }
                    </FooterTemplate>
                </TreeGridAggregateColumn>                            
            </TreeGridAggregateColumns>
        </TreeGridAggregate>
    </TreeGridAggregates>
    <TreeGridColumns>
        <TreeGridColumn Field="TaskId" HeaderText="Task ID" Width="80" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="TaskName" HeaderText="Task Name" Width="100"></TreeGridColumn>
        <TreeGridColumn Field="Duration" HeaderText="Duration" Width="100" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="Progress" HeaderText="Progress" Width="100" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="Approved" HeaderText="Approved" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Center" DisplayAsCheckBox="true" Width="100">
        </TreeGridColumn>
    </TreeGridColumns>
</SfTreeGrid>

@code{
    public List<TreeData> TreeGridData { get; set; }

    public Syncfusion.Blazor.Grids.AggregateTemplateContext model = new Syncfusion.Blazor.Grids.AggregateTemplateContext();

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
            public int TaskId { get; set; }
            public string TaskName { get; set; }
            public DateTime? StartDate { get; set; }
            public int? Duration { get; set; }
            public int? Progress { get; set; }
            public bool Approved { get; set; }
            public int? ParentId { get; set; }
        
        public static List<TreeData> GetSelfDataSource()
        {
            List<TreeData> TreeDataCollection = new List<TreeData>();
            TreeDataCollection.Add(new TreeData() { TaskId = 1, TaskName = "Parent Task 1", Duration = 10, Progress = 70, Approved = true, ParentId = null });
            TreeDataCollection.Add(new TreeData() { TaskId = 2, TaskName = "Child task 1",Duration = 4, Progress = 80, Approved = false, Duration = 50, ParentId = 1 });
            TreeDataCollection.Add(new TreeData() { TaskId = 3, TaskName = "Child Task 2", Duration = 5, Progress = 65, Approved = true, ParentId = 2 });
            TreeDataCollection.Add(new TreeData() { TaskId = 4, TaskName = "Child task 3", Duration = 6, Approved = false, Progress = 77, ParentId = 3 });
            TreeDataCollection.Add(new TreeData() { TaskId = 5, TaskName = "Parent Task 2", Duration = 10, Progress = 70, Approved = true, ParentId = null });
            TreeDataCollection.Add(new TreeData() { TaskId = 6, TaskName = "Child task 1", Duration = 4, Progress = 80, Approved = false, ParentId = 5 });
            TreeDataCollection.Add(new TreeData() { TaskId = 7, TaskName = "Child Task 2", Duration = 5, Progress = 65, Approved = true, ParentId = 5 });
            TreeDataCollection.Add(new TreeData() { TaskId = 8, TaskName = "Child task 3", Duration = 6, Progress = 77, Approved = false, ParentId = 5 });
            TreeDataCollection.Add(new TreeData() { TaskId = 9, TaskName = "Child task 4", Duration = 6, Progress = 77, Approved = true, ParentId = 5 });
            return TreeDataCollection;
        }
    }
}

{% endhighlight %}

{% endtabs %}

![Format Aggregate in Blazor TreeGrid](images/blazor-treegrid-aggregate-format.png)

<!-- Custom aggregate

To calculate the aggregate value with your own aggregate functions, use the custom aggregate option. To use custom aggregation, specify the [`Type`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridAggregateColumn.html#Syncfusion_Blazor_TreeGrid_TreeGridAggregateColumn_Type) as `Custom`, and provide the custom aggregate function in the [`CustomAggregate`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridAggregateColumn.html) property.

> To access the custom aggregate value inside the template, use the key as `Custom`.

-->

## Limitations

* By default, Footer Aggregates are calculated only for the current page records. To aggregate across all pages, configure the adaptor in **SfDataManager**.