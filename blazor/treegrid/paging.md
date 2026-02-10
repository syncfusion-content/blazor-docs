---
layout: post
title: Paging in Blazor TreeGrid Component | Syncfusion
description: Learn how to configure Paging in the Syncfusion Blazor TreeGrid component, including page size modes, templates, and dropdown settings.
platform: Blazor
control: TreeGrid
documentation: ug
---

# Paging in Blazor TreeGrid Component

Paging provides an option to display TreeGrid data in page segments. To enable paging, set the [AllowPaging](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_AllowPaging) to **true**. When paging is enabled, the pager component renders at the bottom of the TreeGrid. Paging options can be configured through the [TreeGridPageSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridPageSettings.html).

{% tabs %}

{% highlight razor %}

@using Syncfusion.Blazor.TreeGrid
@using Syncfusion.Blazor.Grids

<SfTreeGrid DataSource="@TreeData" IdMapping="TaskId" ParentIdMapping="ParentId" TreeColumnIndex="1" AllowPaging="true">
    <TreeGridPageSettings PageCount="2" PageSize="2" PageSizeMode="PageSizeMode.Root">
    </TreeGridPageSettings>
    <TreeGridColumns>
        <TreeGridColumn Field="TaskId" HeaderText="Task ID" Width="120" IsPrimaryKey="true" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="TaskName" HeaderText="Task Name" Width="260"></TreeGridColumn>
        <TreeGridColumn Field="Priority" HeaderText="Priority" Width="100"></TreeGridColumn>
        <TreeGridColumn Field="Progress" HeaderText="Progress" Width="110"></TreeGridColumn>
        <TreeGridColumn Field="Duration" HeaderText="Duration (In Days)" Width="140" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="StartDate" HeaderText="Start Date" Format="d" Type=Syncfusion.Blazor.Grids.ColumnType.Date Width="140" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="EndDate" HeaderText="End Date" Format="d" Type=Syncfusion.Blazor.Grids.ColumnType.Date Width="140" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" ></TreeGridColumn>
    </TreeGridColumns>
</SfTreeGrid>

@code{
    private List<WrapData> TreeData { get; set; } = new List<WrapData>();
    protected override void OnInitialized()
    {
        TreeData = WrapData.GetWrapData().ToList();
    }
}

{% endhighlight %}

{% highlight c# %}

namespace TreeGridComponent.Data {

    public class WrapData
    {
        public int? TaskId { get; set; }
        public string? TaskName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? Duration { get; set; }
        public string? Progress { get; set; }
        public string? Priority { get; set; }
        public bool Approved { get; set; }
        public int Resources { get; set; }
        public int? ParentId { get; set; }
        public static List<WrapData> GetWrapData()
        {
            List<WrapData> BusinessObjectCollection = new List<WrapData>();
            BusinessObjectCollection.Add(new WrapData() { TaskId = 4871, TaskName = "Planning", StartDate = new DateTime(2025, 3, 2), EndDate = new DateTime(2025, 7, 11), Progress = "Open", Duration = 132, Priority = "Normal", Resources = 6, Approved = false, ParentId = null }); // Mar 2 ? Jul 11
            BusinessObjectCollection.Add(new WrapData() { TaskId = 4872, TaskName = "Plan timeline", StartDate = new DateTime(2025, 3, 4), EndDate = new DateTime(2025, 3, 8), Progress = "In Progress", Duration = 5, Resources = 4, Priority = "Normal", Approved = false, ParentId = 4871 });
            BusinessObjectCollection.Add(new WrapData() { TaskId = 4873, TaskName = "Plan budget", StartDate = new DateTime(2025, 3, 6), EndDate = new DateTime(2025, 3, 10), Duration = 5, Progress = "Started", Approved = true, Resources = 6, Priority = "Low", ParentId = 4871 });
            BusinessObjectCollection.Add(new WrapData() { TaskId = 4874, TaskName = "Allocate resources", StartDate = new DateTime(2025, 3, 8), EndDate = new DateTime(2025, 3, 12), Duration = 5, Progress = "Open", Priority = "Critical", Resources = 3, Approved = false, ParentId = 4871 });
            BusinessObjectCollection.Add(new WrapData() { TaskId = 4875, TaskName = "Planning complete", StartDate = new DateTime(2025, 7, 10), EndDate = new DateTime(2025, 7, 11), Duration = 2, Progress = "Open", Priority = "Low", Resources = 5, ParentId = 4871, Approved = true });

            BusinessObjectCollection.Add(new WrapData() { TaskId = 4876, TaskName = "Design", StartDate = new DateTime(2025, 7, 15), EndDate = new DateTime(2025, 9, 20), Progress = "In Progress", Duration = 68, Priority = "High", Resources = 4, Approved = false, ParentId = null });
            BusinessObjectCollection.Add(new WrapData() { TaskId = 4877, TaskName = "Software specification", StartDate = new DateTime(2025, 7, 16), EndDate = new DateTime(2025, 7, 25), Duration = 10, Progress = "Started", Resources = 3, Priority = "Normal", ParentId = 4876, Approved = false });
            BusinessObjectCollection.Add(new WrapData() { TaskId = 4878, TaskName = "Develop prototype", StartDate = new DateTime(2025, 7, 26), EndDate = new DateTime(2025, 8, 10), Duration = 16, Progress = "In Progress", Resources = 2, Priority = "Critical", ParentId = 4876, Approved = false });
            BusinessObjectCollection.Add(new WrapData() { TaskId = 4879, TaskName = "Get approval from customer", StartDate = new DateTime(2025, 8, 11), EndDate = new DateTime(2025, 8, 15), Duration = 5, Progress = "In Progress", Resources = 3, Priority = "Low", Approved = true, ParentId = 4876 });
            BusinessObjectCollection.Add(new WrapData() { TaskId = 4880, TaskName = "Design complete", StartDate = new DateTime(2025, 9, 18), EndDate = new DateTime(2025, 9, 20), Duration = 3, Progress = "In Progress", Resources = 6, Priority = "Normal", ParentId = 4876, Approved = true });

            BusinessObjectCollection.Add(new WrapData() { TaskId = 4881, TaskName = "Implementation phase", StartDate = new DateTime(2025, 9, 21), EndDate = new DateTime(2025, 12, 31), Priority = "Normal", Approved = false, Duration = 102, Resources = 5, Progress = "Started", ParentId = null });
            BusinessObjectCollection.Add(new WrapData() { TaskId = 4882, TaskName = "Phase 1", StartDate = new DateTime(2025, 9, 22), EndDate = new DateTime(2025, 10, 15), Priority = "High", Approved = false, Duration = 24, Progress = "Open", Resources = 4, ParentId = 4881 });
            BusinessObjectCollection.Add(new WrapData() { TaskId = 4883, TaskName = "Implementation module 1", StartDate = new DateTime(2025, 9, 23), EndDate = new DateTime(2025, 10, 14), Priority = "Normal", Duration = 22, Progress = "Started", Resources = 3, Approved = false, ParentId = 4882 });
            BusinessObjectCollection.Add(new WrapData() { TaskId = 4884, TaskName = "Development task 1", StartDate = new DateTime(2025, 9, 24), EndDate = new DateTime(2025, 9, 28), Duration = 5, Progress = "In Progress", Priority = "High", Resources = 2, ParentId = 4883, Approved = false });
            BusinessObjectCollection.Add(new WrapData() { TaskId = 4885, TaskName = "Development task 2", StartDate = new DateTime(2025, 9, 29), EndDate = new DateTime(2025, 10, 3), Duration = 5, Progress = "Closed", Priority = "Low", Resources = 5, ParentId = 4883, Approved = true });
            BusinessObjectCollection.Add(new WrapData() { TaskId = 4886, TaskName = "Testing", StartDate = new DateTime(2025, 10, 4), EndDate = new DateTime(2025, 10, 7), Duration = 4, Progress = "Closed", Priority = "Normal", ParentId = 4883, Resources = 1, Approved = true });
            BusinessObjectCollection.Add(new WrapData() { TaskId = 4887, TaskName = "Bug fix", StartDate = new DateTime(2025, 10, 8), EndDate = new DateTime(2025, 10, 10), Duration = 3, Progress = "Validated", Priority = "Critical", ParentId = 4883, Resources = 6, Approved = false });
            BusinessObjectCollection.Add(new WrapData() { TaskId = 4888, TaskName = "Customer review meeting", StartDate = new DateTime(2025, 10, 11), EndDate = new DateTime(2025, 10, 14), Duration = 4, Progress = "Open", Priority = "High", ParentId = 4883, Resources = 6, Approved = false });
            BusinessObjectCollection.Add(new WrapData() { TaskId = 4889, TaskName = "Phase 1 complete", StartDate = new DateTime(2025, 10, 14), EndDate = new DateTime(2025, 10, 15), Duration = 2, Progress = "Closed", Priority = "Low", ParentId = 4883, Resources = 5, Approved = true });
            BusinessObjectCollection.Add(new WrapData() { TaskId = 4890, TaskName = "Phase 2", StartDate = new DateTime(2025, 10, 16), EndDate = new DateTime(2025, 11, 15), Priority = "High", Approved = false, Progress = "Open", ParentId = 4881, Resources = 3, Duration = 31 });
            BusinessObjectCollection.Add(new WrapData() { TaskId = 4891, TaskName = "Implementation module 2", StartDate = new DateTime(2025, 10, 17), EndDate = new DateTime(2025, 11, 14), Priority = "Critical", Approved = false, Progress = "In Progress", ParentId = 4890, Resources = 3, Duration = 29 });
            BusinessObjectCollection.Add(new WrapData() { TaskId = 4892, TaskName = "Development task 1", StartDate = new DateTime(2025, 10, 18), EndDate = new DateTime(2025, 10, 25), Duration = 8, Progress = "Closed", Priority = "Normal", ParentId = 4891, Resources = 2, Approved = true });
            BusinessObjectCollection.Add(new WrapData() { TaskId = 4893, TaskName = "Development task 2", StartDate = new DateTime(2025, 10, 26), EndDate = new DateTime(2025, 11, 2), Duration = 8, Progress = "Closed", Priority = "Critical", ParentId = 4891, Resources = 5, Approved = true });
            BusinessObjectCollection.Add(new WrapData() { TaskId = 4894, TaskName = "Testing", StartDate = new DateTime(2025, 11, 3), EndDate = new DateTime(2025, 11, 6), Duration = 4, Progress = "Open", Priority = "High", ParentId = 4891, Resources = 3, Approved = false });
            BusinessObjectCollection.Add(new WrapData() { TaskId = 4895, TaskName = "Bug fix", StartDate = new DateTime(2025, 11, 7), EndDate = new DateTime(2025, 11, 10), Duration = 4, Progress = "Validated", Priority = "Low", Approved = false, Resources = 6, ParentId = 4891 });
            BusinessObjectCollection.Add(new WrapData() { TaskId = 4896, TaskName = "Customer review meeting", StartDate = new DateTime(2025, 11, 11), EndDate = new DateTime(2025, 11, 14), Duration = 4, Progress = "In Progress", Priority = "Critical", ParentId = 4891, Resources = 4, Approved = true });
            BusinessObjectCollection.Add(new WrapData() { TaskId = 4897, TaskName = "Phase 2 complete", StartDate = new DateTime(2025, 11, 14), EndDate = new DateTime(2025, 11, 15), Duration = 2, Priority = "Normal", Progress = "Open", ParentId = 4891, Resources = 3, Approved = false });
            BusinessObjectCollection.Add(new WrapData() { TaskId = 4898, TaskName = "Phase 3", StartDate = new DateTime(2025, 11, 16), EndDate = new DateTime(2025, 12, 20), Priority = "Normal", Approved = false, Duration = 35, Progress = "In Progress", Resources = 4, ParentId = 4881 });
            BusinessObjectCollection.Add(new WrapData() { TaskId = 4899, TaskName = "Implementation module 3", StartDate = new DateTime(2025, 11, 17), EndDate = new DateTime(2025, 12, 19), Priority = "High", Approved = false, Duration = 33, Resources = 5, Progress = "Validated", ParentId = 4898 });
            BusinessObjectCollection.Add(new WrapData() { TaskId = 4900, TaskName = "Development task 1", StartDate = new DateTime(2025, 11, 18), EndDate = new DateTime(2025, 11, 25), Duration = 8, Progress = "Closed", Priority = "Low", Approved = true, Resources = 3, ParentId = 4899 });
            BusinessObjectCollection.Add(new WrapData() { TaskId = 4901, TaskName = "Development task 2", StartDate = new DateTime(2025, 11, 26), EndDate = new DateTime(2025, 12, 3), Duration = 8, Progress = "Closed", Priority = "Normal", Approved = false, Resources = 2, ParentId = 4899 });
            BusinessObjectCollection.Add(new WrapData() { TaskId = 4902, TaskName = "Testing", StartDate = new DateTime(2025, 12, 4), EndDate = new DateTime(2025, 12, 10), Duration = 7, Progress = "Closed", Priority = "Critical", ParentId = 4899, Resources = 4, Approved = true });
            BusinessObjectCollection.Add(new WrapData() { TaskId = 4903, TaskName = "Bug fix", StartDate = new DateTime(2025, 12, 11), EndDate = new DateTime(2025, 12, 15), Duration = 5, Progress = "Open", Priority = "High", Approved = false, Resources = 3, ParentId = 4899 });
            BusinessObjectCollection.Add(new WrapData() { TaskId = 4904, TaskName = "Customer review meeting", StartDate = new DateTime(2025, 12, 16), EndDate = new DateTime(2025, 12, 19), Duration = 4, Progress = "In Progress", Priority = "Normal", ParentId = 4899, Resources = 6, Approved = true });
            BusinessObjectCollection.Add(new WrapData() { TaskId = 4905, TaskName = "Phase 3 complete", StartDate = new DateTime(2025, 12, 19), EndDate = new DateTime(2025, 12, 20), Duration = 2, Priority = "Critical", Progress = "Open", Resources = 5, ParentId = 4899, Approved = false });
            return BusinessObjectCollection;
        }
    }
}

{% endhighlight %}

{% endtabs %}


![Paging in Blazor TreeGrid](images/blazor-treegrid-paging.png)

N> Better performance can be achieved by using TreeGrid paging to fetch only a pre-defined number of records from the data source.

## Page size mode

The [`PageSizeMode`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridPageSettings.html#Syncfusion_Blazor_TreeGrid_TreeGridPageSettings_PageSizeMode) property of [`TreeGridPageSettings`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridPageSettings.html) defines two behaviors in TreeGrid paging to display a specific number of records on the current page.

* **All** : Page size is calculated using the entire hierarchy, including both root and child records. 
* **Root** : This is the default mode. The number of root nodes or the **0th-level** records to be displayed per page is based on [PageSize](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridPageSettings.html#Syncfusion_Blazor_TreeGrid_TreeGridPageSettings_PageSize) property. With `PageSizeMode` property as **Root**, only the root level or the 0th level records are considered in records count.

N> The **ALL** mode of **PageSizeMode** is not supported with remote data binding in the TreeGrid.

{% tabs %}

{% highlight razor %}

@using Syncfusion.Blazor.TreeGrid
@using Syncfusion.Blazor.Grids

<SfTreeGrid DataSource="@TreeData" IdMapping="TaskId" ParentIdMapping="ParentId" TreeColumnIndex="1" AllowPaging="true">
    <TreeGridPageSettings PageCount="2" PageSize="2" PageSizeMode="PageSizeMode.Root">
    </TreeGridPageSettings>
    <TreeGridColumns>
        <TreeGridColumn Field="TaskId" HeaderText="Task ID" Width="120" IsPrimaryKey="true" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="TaskName" HeaderText="Task Name" Width="260"></TreeGridColumn>
        <TreeGridColumn Field="Priority" HeaderText="Priority" Width="100"></TreeGridColumn>
        <TreeGridColumn Field="Progress" HeaderText="Progress" Width="110"></TreeGridColumn>
        <TreeGridColumn Field="Duration" HeaderText="Duration (In Days)" Width="140" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="StartDate" HeaderText="Start Date" Format="d" Type=Syncfusion.Blazor.Grids.ColumnType.Date Width="140" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="EndDate" HeaderText="End Date" Format="d" Type=Syncfusion.Blazor.Grids.ColumnType.Date Width="140" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" ></TreeGridColumn>
    </TreeGridColumns>
</SfTreeGrid>

@code{
    private List<WrapData> TreeData { get; set; } = new List<WrapData>();
    protected override void OnInitialized()
    {
        TreeData = WrapData.GetWrapData().ToList();
    }
}

{% endhighlight %}

{% highlight c# %}

namespace TreeGridComponent.Data {

    public class WrapData
    {
        public int? TaskId { get; set; }
        public string? TaskName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? Duration { get; set; }
        public string? Progress { get; set; }
        public string? Priority { get; set; }
        public bool Approved { get; set; }
        public int Resources { get; set; }
        public int? ParentId { get; set; }
        public static List<WrapData> GetWrapData()
        {
            List<WrapData> BusinessObjectCollection = new List<WrapData>();
            BusinessObjectCollection.Add(new WrapData() { TaskId = 4871, TaskName = "Planning", StartDate = new DateTime(2025, 3, 2), EndDate = new DateTime(2025, 7, 11), Progress = "Open", Duration = 132, Priority = "Normal", Resources = 6, Approved = false, ParentId = null }); // Mar 2 ? Jul 11
            BusinessObjectCollection.Add(new WrapData() { TaskId = 4872, TaskName = "Plan timeline", StartDate = new DateTime(2025, 3, 4), EndDate = new DateTime(2025, 3, 8), Progress = "In Progress", Duration = 5, Resources = 4, Priority = "Normal", Approved = false, ParentId = 4871 });
            BusinessObjectCollection.Add(new WrapData() { TaskId = 4873, TaskName = "Plan budget", StartDate = new DateTime(2025, 3, 6), EndDate = new DateTime(2025, 3, 10), Duration = 5, Progress = "Started", Approved = true, Resources = 6, Priority = "Low", ParentId = 4871 });
            BusinessObjectCollection.Add(new WrapData() { TaskId = 4874, TaskName = "Allocate resources", StartDate = new DateTime(2025, 3, 8), EndDate = new DateTime(2025, 3, 12), Duration = 5, Progress = "Open", Priority = "Critical", Resources = 3, Approved = false, ParentId = 4871 });
            BusinessObjectCollection.Add(new WrapData() { TaskId = 4875, TaskName = "Planning complete", StartDate = new DateTime(2025, 7, 10), EndDate = new DateTime(2025, 7, 11), Duration = 2, Progress = "Open", Priority = "Low", Resources = 5, ParentId = 4871, Approved = true });

            BusinessObjectCollection.Add(new WrapData() { TaskId = 4876, TaskName = "Design", StartDate = new DateTime(2025, 7, 15), EndDate = new DateTime(2025, 9, 20), Progress = "In Progress", Duration = 68, Priority = "High", Resources = 4, Approved = false, ParentId = null });
            BusinessObjectCollection.Add(new WrapData() { TaskId = 4877, TaskName = "Software specification", StartDate = new DateTime(2025, 7, 16), EndDate = new DateTime(2025, 7, 25), Duration = 10, Progress = "Started", Resources = 3, Priority = "Normal", ParentId = 4876, Approved = false });
            BusinessObjectCollection.Add(new WrapData() { TaskId = 4878, TaskName = "Develop prototype", StartDate = new DateTime(2025, 7, 26), EndDate = new DateTime(2025, 8, 10), Duration = 16, Progress = "In Progress", Resources = 2, Priority = "Critical", ParentId = 4876, Approved = false });
            BusinessObjectCollection.Add(new WrapData() { TaskId = 4879, TaskName = "Get approval from customer", StartDate = new DateTime(2025, 8, 11), EndDate = new DateTime(2025, 8, 15), Duration = 5, Progress = "In Progress", Resources = 3, Priority = "Low", Approved = true, ParentId = 4876 });
            BusinessObjectCollection.Add(new WrapData() { TaskId = 4880, TaskName = "Design complete", StartDate = new DateTime(2025, 9, 18), EndDate = new DateTime(2025, 9, 20), Duration = 3, Progress = "In Progress", Resources = 6, Priority = "Normal", ParentId = 4876, Approved = true });

            BusinessObjectCollection.Add(new WrapData() { TaskId = 4881, TaskName = "Implementation phase", StartDate = new DateTime(2025, 9, 21), EndDate = new DateTime(2025, 12, 31), Priority = "Normal", Approved = false, Duration = 102, Resources = 5, Progress = "Started", ParentId = null });
            BusinessObjectCollection.Add(new WrapData() { TaskId = 4882, TaskName = "Phase 1", StartDate = new DateTime(2025, 9, 22), EndDate = new DateTime(2025, 10, 15), Priority = "High", Approved = false, Duration = 24, Progress = "Open", Resources = 4, ParentId = 4881 });
            BusinessObjectCollection.Add(new WrapData() { TaskId = 4883, TaskName = "Implementation module 1", StartDate = new DateTime(2025, 9, 23), EndDate = new DateTime(2025, 10, 14), Priority = "Normal", Duration = 22, Progress = "Started", Resources = 3, Approved = false, ParentId = 4882 });
            BusinessObjectCollection.Add(new WrapData() { TaskId = 4884, TaskName = "Development task 1", StartDate = new DateTime(2025, 9, 24), EndDate = new DateTime(2025, 9, 28), Duration = 5, Progress = "In Progress", Priority = "High", Resources = 2, ParentId = 4883, Approved = false });
            BusinessObjectCollection.Add(new WrapData() { TaskId = 4885, TaskName = "Development task 2", StartDate = new DateTime(2025, 9, 29), EndDate = new DateTime(2025, 10, 3), Duration = 5, Progress = "Closed", Priority = "Low", Resources = 5, ParentId = 4883, Approved = true });
            BusinessObjectCollection.Add(new WrapData() { TaskId = 4886, TaskName = "Testing", StartDate = new DateTime(2025, 10, 4), EndDate = new DateTime(2025, 10, 7), Duration = 4, Progress = "Closed", Priority = "Normal", ParentId = 4883, Resources = 1, Approved = true });
            BusinessObjectCollection.Add(new WrapData() { TaskId = 4887, TaskName = "Bug fix", StartDate = new DateTime(2025, 10, 8), EndDate = new DateTime(2025, 10, 10), Duration = 3, Progress = "Validated", Priority = "Critical", ParentId = 4883, Resources = 6, Approved = false });
            BusinessObjectCollection.Add(new WrapData() { TaskId = 4888, TaskName = "Customer review meeting", StartDate = new DateTime(2025, 10, 11), EndDate = new DateTime(2025, 10, 14), Duration = 4, Progress = "Open", Priority = "High", ParentId = 4883, Resources = 6, Approved = false });
            BusinessObjectCollection.Add(new WrapData() { TaskId = 4889, TaskName = "Phase 1 complete", StartDate = new DateTime(2025, 10, 14), EndDate = new DateTime(2025, 10, 15), Duration = 2, Progress = "Closed", Priority = "Low", ParentId = 4883, Resources = 5, Approved = true });
            BusinessObjectCollection.Add(new WrapData() { TaskId = 4890, TaskName = "Phase 2", StartDate = new DateTime(2025, 10, 16), EndDate = new DateTime(2025, 11, 15), Priority = "High", Approved = false, Progress = "Open", ParentId = 4881, Resources = 3, Duration = 31 });
            BusinessObjectCollection.Add(new WrapData() { TaskId = 4891, TaskName = "Implementation module 2", StartDate = new DateTime(2025, 10, 17), EndDate = new DateTime(2025, 11, 14), Priority = "Critical", Approved = false, Progress = "In Progress", ParentId = 4890, Resources = 3, Duration = 29 });
            BusinessObjectCollection.Add(new WrapData() { TaskId = 4892, TaskName = "Development task 1", StartDate = new DateTime(2025, 10, 18), EndDate = new DateTime(2025, 10, 25), Duration = 8, Progress = "Closed", Priority = "Normal", ParentId = 4891, Resources = 2, Approved = true });
            BusinessObjectCollection.Add(new WrapData() { TaskId = 4893, TaskName = "Development task 2", StartDate = new DateTime(2025, 10, 26), EndDate = new DateTime(2025, 11, 2), Duration = 8, Progress = "Closed", Priority = "Critical", ParentId = 4891, Resources = 5, Approved = true });
            BusinessObjectCollection.Add(new WrapData() { TaskId = 4894, TaskName = "Testing", StartDate = new DateTime(2025, 11, 3), EndDate = new DateTime(2025, 11, 6), Duration = 4, Progress = "Open", Priority = "High", ParentId = 4891, Resources = 3, Approved = false });
            BusinessObjectCollection.Add(new WrapData() { TaskId = 4895, TaskName = "Bug fix", StartDate = new DateTime(2025, 11, 7), EndDate = new DateTime(2025, 11, 10), Duration = 4, Progress = "Validated", Priority = "Low", Approved = false, Resources = 6, ParentId = 4891 });
            BusinessObjectCollection.Add(new WrapData() { TaskId = 4896, TaskName = "Customer review meeting", StartDate = new DateTime(2025, 11, 11), EndDate = new DateTime(2025, 11, 14), Duration = 4, Progress = "In Progress", Priority = "Critical", ParentId = 4891, Resources = 4, Approved = true });
            BusinessObjectCollection.Add(new WrapData() { TaskId = 4897, TaskName = "Phase 2 complete", StartDate = new DateTime(2025, 11, 14), EndDate = new DateTime(2025, 11, 15), Duration = 2, Priority = "Normal", Progress = "Open", ParentId = 4891, Resources = 3, Approved = false });
            BusinessObjectCollection.Add(new WrapData() { TaskId = 4898, TaskName = "Phase 3", StartDate = new DateTime(2025, 11, 16), EndDate = new DateTime(2025, 12, 20), Priority = "Normal", Approved = false, Duration = 35, Progress = "In Progress", Resources = 4, ParentId = 4881 });
            BusinessObjectCollection.Add(new WrapData() { TaskId = 4899, TaskName = "Implementation module 3", StartDate = new DateTime(2025, 11, 17), EndDate = new DateTime(2025, 12, 19), Priority = "High", Approved = false, Duration = 33, Resources = 5, Progress = "Validated", ParentId = 4898 });
            BusinessObjectCollection.Add(new WrapData() { TaskId = 4900, TaskName = "Development task 1", StartDate = new DateTime(2025, 11, 18), EndDate = new DateTime(2025, 11, 25), Duration = 8, Progress = "Closed", Priority = "Low", Approved = true, Resources = 3, ParentId = 4899 });
            BusinessObjectCollection.Add(new WrapData() { TaskId = 4901, TaskName = "Development task 2", StartDate = new DateTime(2025, 11, 26), EndDate = new DateTime(2025, 12, 3), Duration = 8, Progress = "Closed", Priority = "Normal", Approved = false, Resources = 2, ParentId = 4899 });
            BusinessObjectCollection.Add(new WrapData() { TaskId = 4902, TaskName = "Testing", StartDate = new DateTime(2025, 12, 4), EndDate = new DateTime(2025, 12, 10), Duration = 7, Progress = "Closed", Priority = "Critical", ParentId = 4899, Resources = 4, Approved = true });
            BusinessObjectCollection.Add(new WrapData() { TaskId = 4903, TaskName = "Bug fix", StartDate = new DateTime(2025, 12, 11), EndDate = new DateTime(2025, 12, 15), Duration = 5, Progress = "Open", Priority = "High", Approved = false, Resources = 3, ParentId = 4899 });
            BusinessObjectCollection.Add(new WrapData() { TaskId = 4904, TaskName = "Customer review meeting", StartDate = new DateTime(2025, 12, 16), EndDate = new DateTime(2025, 12, 19), Duration = 4, Progress = "In Progress", Priority = "Normal", ParentId = 4899, Resources = 6, Approved = true });
            BusinessObjectCollection.Add(new WrapData() { TaskId = 4905, TaskName = "Phase 3 complete", StartDate = new DateTime(2025, 12, 19), EndDate = new DateTime(2025, 12, 20), Duration = 2, Priority = "Critical", Progress = "Open", Resources = 5, ParentId = 4899, Approved = false });
            return BusinessObjectCollection;
        }
    }
}
{% endhighlight %}

{% endtabs %}

![Changing Page Size Mode in Blazor TreeGrid](images/blazor-treegrid-page-size-mode.png)

## Pager template

The pager template in the Syncfusion® TreeGrid component enables customization of the appearance and behavior of the pager element, which facilitates navigation across different pages of TreeGrid data. This feature is especially useful when custom elements are required inside the pager instead of the default controls.

To use the pager template, specify the [Template](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridPageSettings.html#Syncfusion_Blazor_TreeGrid_TreeGridPageSettings_Template) property of the [TreeGridPageSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridPageSettings.html) component in your Syncfusion<sup style="font-size:70%">&reg;</sup> TreeGrid configuration. Within the pager `Template`, utilize the `PagerTemplateContext` context to retrieve vital paging values such as [CurrentPage](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridPageSettings.html#Syncfusion_Blazor_TreeGrid_TreeGridPageSettings_CurrentPage), [PageSize](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridPageSettings.html#Syncfusion_Blazor_TreeGrid_TreeGridPageSettings_PageSize), [PageCount](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridPageSettings.html#Syncfusion_Blazor_TreeGrid_TreeGridPageSettings_PageCount), **TotalPage**, and **TotalRecordCount**. These values provide the data necessary to display and manage the pager effectively.

When implementing a custom pager template, the layout of pager controls can be designed as desired. However, for actual paging functionality,  integrate the [GoToPageAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_GoToPageAsync_System_Int32_) method. This method handles navigation to a specific page based on the page number input.

The following example demonstrates how to render a **NumericTextBox** component in the pager using the `Template` property

{% tabs %}

{% highlight razor %}

@using Syncfusion.Blazor.TreeGrid
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Inputs
@using Syncfusion.Blazor.Navigations
@using System.ComponentModel.DataAnnotations
@using TreeGridComponent.Data;

<SfTreeGrid @ref="TreeGrid" DataSource="@TreeData" Height="312" IdMapping="TaskID" ParentIdMapping="ParentID" TreeColumnIndex="1" AllowPaging="true">
    <TreeGridPageSettings  PageSize="@pageSize">
        <Template>

            @{
                var Paging = (context as PagerTemplateContext);
            <div>
                <div>
                    <div>
                        <SfNumericTextBox TValue="int" Format="###" Step="1" Min="1" Max="5" Placeholder="Select Page Size" Width="200px">
                            <NumericTextBoxEvents TValue="int" ValueChange="@CalculatePageSize"></NumericTextBoxEvents>
                        </SfNumericTextBox>
                    </div>
                </div>
                <div style="margin-top:5px;margin-left:30px;border: none; display: inline-block">
                    <span> of @totalPages pages (@TreeData.Count items)</span>
                </div>
            </div>
            }
        </Template>
    </TreeGridPageSettings>
    <TreeGridColumns>
        <TreeGridColumn Field="TaskID" HeaderText="Task ID" Width="80" TextAlign="TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="TaskName" HeaderText="Task Name" Width="170"></TreeGridColumn>
        <TreeGridColumn Field="StartDate" HeaderText="Start Date" Format="d" Type=ColumnType.Date Width="145" TextAlign="TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="Duration" HeaderText="Duration" Width="100" TextAlign="TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="Progress" HeaderText="Progress" Width="110"></TreeGridColumn>
        <TreeGridColumn Field="Priority" HeaderText="Priority" Width="100"></TreeGridColumn>
    </TreeGridColumns>
</SfTreeGrid>

@code {
    private List<SelfReferenceData> TreeData { get; set; }
    SfTreeGrid<SelfReferenceData> TreeGrid;
    public int pageSize { get; set; } = 3;
    public int totalPages => (int)Math.Ceiling((double)TreeData.Count / (pageSize * 6));

    protected override void OnInitialized()
    {
        TreeData = SelfReferenceData.GetTree().Take(90).ToList();
    }

    
    private async Task CalculatePageSize(Syncfusion.Blazor.Inputs.ChangeEventArgs<int> args)
    {
        await TreeGrid.GoToPageAsync(args.Value);
    }
}


{% endhighlight %}

{% highlight c# %}

namespace TreeGridComponent.Data {

    public class SelfReferenceData
    {
        public static List<SelfReferenceData> tree = new List<SelfReferenceData>();
        [Key]
        public int? TaskID { get; set; }
        public string TaskName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public String Progress { get; set; }
        public String Priority { get; set; }
        public double? Duration { get; set; }
        public int? ParentID { get; set; }
        public bool? IsParent { get; set; }
        public bool? Approved { get; set; }
        public int? ParentItem { get; set; }
        public SelfReferenceData() { }
        public static List<SelfReferenceData> GetTree()
        {
            tree.Clear();
            int root = -1;
            int TaskNameID = 0;
            int ChildCount = -1;
            int SubTaskCount = -1;
            for (var t = 1; t <= 60; t++)
            {
                DateTime start = new DateTime(2022, 08, 25);
                DateTime end = new DateTime(2027, 08, 25);
                DateTime startingDate = start.AddDays(t + 2);
                DateTime endingDate = end.AddDays(t + 20);
                string math = "";
                string progr = "";
                bool appr = true;
                int duration = 0;
                duration = (t % 2 == 0) ? 52 : (t % 5 == 0) ? 14 : (t % 3 == 0) ? 25 : 34;
                math = (t % 3) == 0 ? "High" : (t % 2) == 0 ? "Low" : "Critical";
                progr = (t % 3) == 0 ? "Started" : (t % 2) == 0 ? "Open" : "In Progress";
                appr = (t % 3) == 0 ? true : (t % 2) == 0 ? false : true;
                root++; TaskNameID++;
                int rootItem = root + 1;
                tree.Add(new SelfReferenceData() { TaskID = rootItem, TaskName = "Parent task " + TaskNameID.ToString(), StartDate = startingDate, EndDate = endingDate, IsParent = true, ParentID = null, Progress = progr, Priority = math, Duration = duration, Approved = appr });
                int parent = tree.Count;
                for (var c = 0; c < 2; c++)
                {
                    DateTime start1 = new DateTime(2022, 08, 25);
                    DateTime startingDate1 = start1.AddDays(c + 4);
                    DateTime end1 = new DateTime(2025, 06, 16);
                    DateTime endingDate1 = end1.AddDays(c + 15);
                    root++; ChildCount++;
                    int parn = parent + c + 1;
                    string val = "";
                    duration = (c % 3 == 0) ? 1 : (c % 2 == 0) ? 12 : 98;
                    val = ((parent + c + 1) % 3 == 0) ? "Low" : "Critical";
                    progr = ((c + 1) % 3) == 0 ? "In Progress" : ((c + 1) % 2) == 0 ? "Open" : "Validated";
                    appr = ((c + 1) % 3) == 0 ? true : ((c + 3) % 2) == 0 ? false : true;
                    int iD = root + 1;
                    tree.Add(new SelfReferenceData() { TaskID = iD, TaskName = "Child task " + (ChildCount + 1).ToString(), StartDate = startingDate1, EndDate = endingDate1, IsParent = (((parent + c + 1) % 3) == 0), ParentID = rootItem, Progress = progr, Priority = val, Duration = duration, Approved = appr });
                    if ((((parent + c + 1) % 3) == 0))
                    {
                        int immParent = tree.Count;
                        for (var s = 0; s < 3; s++)
                        {
                            DateTime start2 = new DateTime(2022, 08, 25);
                            DateTime startingDate2 = start2.AddDays(s + 4);
                            DateTime end2 = new DateTime(2024, 06, 16);
                            DateTime endingDate2 = end2.AddDays(s + 13);
                            root++; SubTaskCount++;
                            duration = (s % 2 == 0) ? 67 : 14;
                            string Prior = (immParent % 2 == 0) ? "Validated" : "Normal";
                            tree.Add(new SelfReferenceData() { TaskID = root + 1, TaskName = "Sub task " + (SubTaskCount + 1).ToString(), StartDate = startingDate2, EndDate = endingDate2, IsParent = false, ParentID = iD, Progress = (immParent % 2 == 0) ? "In Progress" : "Closed", Priority = Prior, Duration = duration, Approved = appr });
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/VXVfCMMTzAVvikyC?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5 %}

## Pager with page size dropdown

The pager Dropdown enables changing the number of records in the TreeGrid dynamically. It can be enabled by defining the [PageSizes](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridPageSettings.html#Syncfusion_Blazor_TreeGrid_TreeGridPageSettings_PageSizes) property of [TreeGridPageSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridPageSettings.html). Set this property to **true** to use the default page size options, or assign a list of integer values to define custom page size options.

{% tabs %}

{% highlight razor %}

@using TreeGridComponent.Data;
@using Syncfusion.Blazor.TreeGrid;

<SfTreeGrid DataSource="@TreeGridData" IdMapping="TaskId" ParentIdMapping="ParentId" TreeColumnIndex="1" AllowPaging="true">
    <TreeGridPageSettings PageCount="2" PageSize="2" PageSizeMode="PageSizeMode.Root" PageSizes="new List<int>() { 2, 5, 10}"></TreeGridPageSettings>
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

![Displaying Page Dropdown in Blazor TreeGrid](images/blazor-treegrid-page-drop-down.png)
