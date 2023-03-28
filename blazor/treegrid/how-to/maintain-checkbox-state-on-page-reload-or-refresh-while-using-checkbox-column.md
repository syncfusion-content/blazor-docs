---
layout: post
title: Maintain checkbox state on page reload or refresh while using checkbox column in Blazor TreeGrid | Syncfusion
description: Learn here all about maintaining checkbox state on page reload or refresh while using checkbox column in Blazor TreeGrid and more.
platform: Blazor
control: Tree Grid
documentation: ug
---

# Maintain checkbox state on page reload or refresh while using checkbox column in Blazor TreeGrid

In order to maintain the checked records on page refresh, we have collected the checked records using [GetCheckedRecordsAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_GetCheckedRecordsAsync) method and upon refresh or reload we have filtered the values from the datasource and recheck them dynamically using [SelectCheckboxes](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_SelectCheckboxesAsync_System_Double___) method

{% tabs %}

{% highlight razor %}

@using TreeGridComponent.Data;
@using  Syncfusion.Blazor.Grids;
@using  Syncfusion.Blazor.TreeGrid;

<SfTreeGrid @ref="TreeGrid" DataSource="@TreeGridData" IdMapping="TaskId" ParentIdMapping="ParentId" TreeColumnIndex="1">
    <TreeGridSelectionSettings Type=SelectionType.Multiple></TreeGridSelectionSettings>
     <TreeGridEvents TValue="TreeData" DataBound="DatBoundHandler" RowSelected="RowSelectedHandler"></TreeGridEvents>
    <TreeGridPageSettings PageSize="8"></TreeGridPageSettings>
    <TreeGridColumns>
        <TreeGridColumn Field="TaskId" HeaderText="Task ID" Width="70" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="TaskName" HeaderText="Task Name" Width="85"></TreeGridColumn>
        <TreeGridColumn Field="Priority" HeaderText="Priority" Width="60"></TreeGridColumn>
        <TreeGridColumn Field="Duration" HeaderText="Duration" Width="60" TextAlign="TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="Progress" HeaderText="Progress" Width="60" TextAlign="TextAlign.Right"></TreeGridColumn>
    </TreeGridColumns>
</SfTreeGrid>

@code{
    SfTreeGrid<TreeData> TreeGrid;
    public List<TreeData> TreeGridData { get; set; }
    public static List<TreeData> CheckedModels { get; set; }

    protected override void OnInitialized()
    {
        this.TreeGridData = TreeData.GetSelfDataSource().ToList();
    }

    public void RowSelectedHandler()
    {
        CheckedModels = TreeGrid.GetCheckedRecordsAsync().Result;
    }


    public List<double> SelectedNodeIndex = new List<double>();

    public void DatBoundHandler()
    {
        if (CheckedModels != null && CheckedModels.Count > 0)
        {
            //To get records
            var dataSource = TreeGrid.DataSource;
            var index = 0;
            foreach (var data in dataSource)
            {
                var row = CheckedModels.Where(g => g.TaskId == data.TaskId);
                if (row.Count() > 0)
                {
                    SelectedNodeIndex.Add(index);
                }
                index++;
            }
            TreeGrid.AutoCheckHierarchy = false;
            TreeGrid.SelectCheckboxesAsync(SelectedNodeIndex.ToArray());

        }
        TreeGrid.AutoCheckHierarchy = true;
    }
}

{% endhighlight %}

{% highlight c# %}

namespace TreeGridComponent.Data {

public class TreeData
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public int? Duration { get; set; }
        public int? Progress { get; set; }
        public string Priority { get; set; }
        public int? ParentId { get; set; }

        public static List<TreeData> GetSelfDataSource()
        {
            List<TreeData> TreeDataCollection = new List<TreeData>();
            TreeDataCollection.Add(new TreeData() { TaskId = 1, TaskName = "Parent Task 1", Duration = 10, Progress = 70, Priority = "Critical", ParentId = null });
            TreeDataCollection.Add(new TreeData() { TaskId = 2, TaskName = "Child task 1", Progress = 80, Priority = "Low", Duration = 50, ParentId = 1 });
            TreeDataCollection.Add(new TreeData() { TaskId = 3, TaskName = "Child Task 2", Duration = 5, Progress = 65, Priority = "Critical", ParentId = 2 });
            TreeDataCollection.Add(new TreeData() { TaskId = 4, TaskName = "Child task 3", Duration = 6, Priority = "High", Progress = 77, ParentId = 3 });
            TreeDataCollection.Add(new TreeData() { TaskId = 5, TaskName = "Parent Task 2", Duration = 10, Progress = 70, Priority = "Critical", ParentId = null });
            TreeDataCollection.Add(new TreeData() { TaskId = 6, TaskName = "Child task 1", Duration = 4, Progress = 80, Priority = "Critical", ParentId = 5 });
            TreeDataCollection.Add(new TreeData() { TaskId = 7, TaskName = "Child Task 2", Duration = 5, Progress = 65, Priority = "Low", ParentId = 5 });
            TreeDataCollection.Add(new TreeData() { TaskId = 8, TaskName = "Child task 3", Duration = 6, Progress = 77, Priority = "High", ParentId = 5 });
            TreeDataCollection.Add(new TreeData() { TaskId = 9, TaskName = "Child task 4", Duration = 6, Progress = 77, Priority = "Low", ParentId = 5 });
            return TreeDataCollection;
        }
    }
}

{% endhighlight %}

{% endtabs %}

![Selection in Blazor TreeGrid](../images/blazor-treegrid-row-selection.PNG)
