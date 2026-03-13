---
layout: post
title: Use Dictionary Values in Blazor TreeGrid Data Source | Syncfusion
description: Learn here all about using dictionary values in Tree Grid datasource in Syncfusion Blazor TreeGrid component and more.
platform: Blazor
control: Tree Grid
documentation: ug
---

# Using dictionary values as DataSource in Blazor TreeGrid Component

Dictionary values can be assigned in the Tree Grid data source by accessing them using **KeyValuePair** data type inside the [Template](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridColumn.html#Syncfusion_Blazor_TreeGrid_TreeGridColumn_Template) property of the [TreeGridColumn](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridColumns.html) component.

**Designation** is defined as Dictionary value and it is accessed inside the template property of the `TreeGridColumn` using **KeyValuePair** data type. The key value is compared with the **TaskId** column value to display the corresponding value.


{% tabs %}

{% highlight razor %}

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.TreeGrid

<SfTreeGrid DataSource="@TreeGridData" IdMapping="TaskId" ParentIdMapping="ParentId" AllowPaging="true" TreeColumnIndex="1">
    <TreeGridColumns>
        <TreeGridColumn Field="TaskId" HeaderText="Task ID" IsPrimaryKey="true" Width="100" TextAlign="TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="TaskName" HeaderText="Task Name" Width="145"></TreeGridColumn>
        <TreeGridColumn Field="Duration" HeaderText="Duration" Width="90" TextAlign="TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="Priority" HeaderText="Priority" Width="90"></TreeGridColumn>
        <TreeGridColumn Field="Designation" HeaderText="Designation" Width="90">
            <Template>
                @{
                    var details = (context as TreeData);
                    if(details.Designation.ContainsKey(details.TaskId))
                    {
                        <div>@details.Designation[details.TaskId]</div>
                    }
                }
            </Template>
        </TreeGridColumn>
    </TreeGridColumns>
</SfTreeGrid>

@code {
    public List<TreeData> TreeGridData { get; set; }

    protected override void OnInitialized()
    {
        this.TreeGridData = TreeData.GetTreeData().ToList();
    }
}

{% endhighlight %}

{% highlight c# %}

public class TreeData
{
    public int TaskId { get; set; }
    public string TaskName { get; set; }
    public int Duration { get; set; }
    public int? Progress { get; set; }
    public string Priority { get; set; }
    public int? ParentId { get; set; }
    public Dictionary<int, string> Designation { get; set; }

    public static List<TreeData> GetTreeData()
    {
        Dictionary<int, string> designationDetails = new Dictionary<int, string>()
        {
            { 1, "Manager" },
            { 2, "Lead" },
            { 3, "Developer" },
            { 4, "Tester" },
            { 5, "Manager" },
            { 6, "Lead" },
            { 7, "Developer" },
            { 8, "Tester" },
            { 9, "Developer" }
        };

        List<TreeData> treeDataCollection = new List<TreeData>();
        treeDataCollection.Add(new TreeData { TaskId = 1, TaskName = "Parent Task 1", Duration = 10, Progress = 70, Priority = "Critical", ParentId = null, Designation = designationDetails });
        treeDataCollection.Add(new TreeData { TaskId = 2, TaskName = "Child task 1", Duration = 50, Progress = 80, Priority = "Low", ParentId = 1, Designation = designationDetails });
        treeDataCollection.Add(new TreeData { TaskId = 3, TaskName = "Child Task 2", Duration = 5, Progress = 65, Priority = "Critical", ParentId = 2, Designation = designationDetails });
        treeDataCollection.Add(new TreeData { TaskId = 4, TaskName = "Child task 3", Duration = 6, Priority = "High", Progress = 77, ParentId = 3, Designation = designationDetails });
        treeDataCollection.Add(new TreeData { TaskId = 5, TaskName = "Parent Task 2", Duration = 10, Progress = 70, Priority = "Critical", ParentId = null, Designation = designationDetails });
        treeDataCollection.Add(new TreeData { TaskId = 6, TaskName = "Child task 1", Duration = 4, Progress = 80, Priority = "Critical", ParentId = 5, Designation = designationDetails });
        treeDataCollection.Add(new TreeData { TaskId = 7, TaskName = "Child Task 2", Duration = 5, Progress = 65, Priority = "Low", ParentId = 5, Designation = designationDetails });
        treeDataCollection.Add(new TreeData { TaskId = 8, TaskName = "Child task 3", Duration = 7, Progress = 77, Priority = "High", ParentId = 5, Designation = designationDetails });
        treeDataCollection.Add(new TreeData { TaskId = 9, TaskName = "Child task 4", Duration = 6, Progress = 77, Priority = "Low", ParentId = 5, Designation = designationDetails });

        return treeDataCollection;
    }
}

{% endhighlight %}

{% endtabs %}

![Dictionary Values in Blazor TreeGrid](../images/blazor-treegrid-dictionary-values.png)
