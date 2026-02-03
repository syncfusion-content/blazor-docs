---
layout: post
title: Scrolling in Blazor TreeGrid Component | Syncfusion
description: Checkout and learn here all about scrolling in Syncfusion Blazor TreeGrid component and much more details.
platform: Blazor
control: Tree Grid
documentation: ug
---

# Scrolling in Blazor TreeGrid Component

The scrollbar will be displayed in the TreeGrid when the content exceeds the element [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_Width) or [Height](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_Height). The vertical and horizontal scrollbars will be displayed based on the following criteria:

The vertical scrollbar appears when the total height of rows present in the tree grid exceeds its element height. The horizontal scrollbar appears when the sum of the columns' width exceeds the tree grid element width. The `Height` and `Width` are used to set the tree grid height and width, respectively.

N> The default value for `Height` and `Width` is **auto**.

## Set width and height

To specify the `Height` and `Width` of the scroller in the pixel, set the pixel value to a number.

{% tabs %}

{% highlight razor %}

@using TreeGridComponent.Data;
@using Syncfusion.Blazor.TreeGrid;
@using Syncfusion.Blazor.Grids

<SfTreeGrid DataSource="@TreeData" IdMapping="TaskId" ParentIdMapping="ParentId" TreeColumnIndex="1" Width="500" Height="300">
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

![Scrolling in Blazor TreeGrid](images/blazor-treegrid-scrolling.png)

## Responsive with parent container

Specify the [Height](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_Height) and [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_Width) as **100%** to make the tree grid element fill its parent container. Setting the [Height](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_Height) to **100%** requires the tree grid parent element to have explicit height.

{% tabs %}

{% highlight razor %}

@using TreeGridComponent.Data;
@using Syncfusion.Blazor.TreeGrid;
@using Syncfusion.Blazor.Grids

<div class="e-resizable">
    <SfTreeGrid DataSource="@TreeData" IdMapping="TaskId" ParentIdMapping="ParentId" TreeColumnIndex="1" Width="100%" Height="100%">
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
</div>

@code{
    private List<WrapData> TreeData { get; set; } = new List<WrapData>();
    protected override void OnInitialized()
    {
        TreeData = WrapData.GetWrapData().ToList();
    }
}
<style>
    .e-resizable {
        resize: both;
        overflow: auto;
        border: 1px solid red;
        padding: 10px;
        height: 300px;
        min-height: 250px;
        min-width: 250px;
    }
</style>
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

## Sticky header

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor TreeGrid provides a feature that allows column headers to remain fixed while scrolling, ensuring they stay visible at all times. This behavior can be enabled by setting the `EnableStickyHeader` property to **true**.

{% tabs %}
{% highlight razor %}

@using TreeGridComponent.Data;
@using Syncfusion.Blazor.TreeGrid;
@using Syncfusion.Blazor.Buttons

<div>
	<label>Enable or Disable Sticky Header</label>
	<SfSwitch ValueChange="Change" TChecked="bool" style="margin-top:5px"></SfSwitch>
</div>

<div style="height:350px; margin-top:5px">
	<SfTreeGrid @ref="TreeGrid"  DataSource="@TreeData" EnableStickyHeader="@isStickyHeaderEnabled" IdMapping="TaskID" TreeColumnIndex="1" ParentIdMapping="ParentID" >
		<TreeGridColumns>
			<TreeGridColumn Field="TaskID" HeaderText="Jersey No" TextAlign="TextAlign.Right" Width="150"></TreeGridColumn>
			<TreeGridColumn Field="FIELD1" HeaderText="Name" Width="150"></TreeGridColumn>
			<TreeGridColumn Field="FIELD2" HeaderText="Year" TextAlign="TextAlign.Right" Width="150"></TreeGridColumn>
			<TreeGridColumn Field="FIELD3" HeaderText="Stint" TextAlign="TextAlign.Right" Width="150"></TreeGridColumn>
			<TreeGridColumn Field="FIELD4" HeaderText="TMID" TextAlign="TextAlign.Right" Width="150"></TreeGridColumn>
			<TreeGridColumn Field="FIELD5" HeaderText="LGID" TextAlign="TextAlign.Right" Width="150"></TreeGridColumn>
			<TreeGridColumn Field="FIELD6" HeaderText="GP" TextAlign="TextAlign.Right" Width="150"></TreeGridColumn>
			<TreeGridColumn Field="Field7" HeaderText="GS" TextAlign="TextAlign.Right" Width="150"></TreeGridColumn>
			<TreeGridColumn Field="Field8" HeaderText="Minutes" TextAlign="TextAlign.Right" Width="150"></TreeGridColumn>
			<TreeGridColumn Field="Field9" HeaderText="Points" TextAlign="TextAlign.Right" Width="150"></TreeGridColumn>
		</TreeGridColumns>
	</SfTreeGrid>
</div>

@code {
	public SfTreeGrid<sampleData> TreeGrid;
	public List<sampleData> TreeData { get; set; }
	public bool isStickyHeaderEnabled;

	protected override void OnInitialized()
	{
		this.TreeData = sampleData.GetTreeSampleData().ToList();
	}

	private void Change(Syncfusion.Blazor.Buttons.ChangeEventArgs<bool> args)
	{
		isStickyHeaderEnabled = args.Checked;
		TreeGrid.RefreshAsync();
	}
}

{% endhighlight %}
{% highlight c# %}

namespace TreeGridComponent.Data 
{
    public class sampleData
    {
        public int TaskID { get; set; }
        public string FIELD1 { get; set; }
        public int FIELD2 { get; set; }
        public int FIELD3 { get; set; }
        public int FIELD4 { get; set; }
        public int FIELD5 { get; set; }
        public int FIELD6 { get; set; }
        public int Field7 { get; set; }
        public int Field8 { get; set; }
        public int Field9 { get; set; }
        public int? ParentID { get; set; }
        public static List<sampleData> GetTreeSampleData()
        {
            string[] Names = new string[] { "VINET", "TOMSP", "HANAR", "VICTE", "SUPRD", "HANAR", "CHOPS", "RICSU", "WELLI", "HILAA", "ERNSH", "CENTC",
            "OTTIK", "QUEDE", "RATTC", "ERNSH", "FOLKO", "BLONP", "WARTH", "FRANK", "GROSR", "WHITC", "WARTH", "SPLIR", "RATTC", "QUICK", "VINET",
            "MAGAA", "TORTU", "MORGK", "BERGS", "LEHMS", "BERGS", "ROMEY", "ROMEY", "LILAS", "LEHMS", "QUICK", "QUICK", "RICAR", "REGGC", "BSBEV",
            "COMMI", "QUEDE", "TRADH", "TORTU", "RATTC", "VINET", "LILAS", "BLONP", "HUNGO", "RICAR", "MAGAA", "WANDK", "SUPRD", "GODOS", "TORTU",
            "OLDWO", "ROMEY", "LONEP", "ANATR", "HUNGO", "THEBI", "DUMON", "WANDK", "QUICK", "RATTC", "ISLAT", "RATTC", "LONEP", "ISLAT", "TORTU",
            "WARTH", "ISLAT", "PERIC", "KOENE", "SAVEA", "KOENE", "BOLID", "FOLKO", "FURIB", "SPLIR", "LILAS", "BONAP", "MEREP", "WARTH", "VICTE",
            "HUNGO", "PRINI", "FRANK", "OLDWO", "MEREP", "BONAP", "SIMOB", "FRANK", "LEHMS", "WHITC", "QUICK", "RATTC", "FAMIA" };
            List<sampleData> DataCollection = new List<sampleData>();
            Random random = new Random();
            var RecordID = 0;
            for (var i = 1; i <= 100; i++)
            {
                var name = random.Next(0, 100);
                sampleData Parent = new sampleData()
                    {
                        TaskID = ++RecordID,
                        FIELD1 = Names[name],
                        FIELD2 = 1967 + random.Next(0, 10),
                        FIELD3 = 395 + random.Next(100, 600),
                        FIELD4 = 87 + random.Next(50, 250),
                        FIELD5 = 410 + random.Next(100, 600),
                        FIELD6 = 67 + random.Next(50, 250),
                        Field7 = (int)Math.Floor(random.NextDouble() * 100),
                        Field8 = (int)Math.Floor(random.NextDouble() * 10),
                        Field9 = (int)Math.Floor(random.NextDouble() * 10),
                        ParentID = null
                    };
                DataCollection.Add(Parent);
                for (var j = 1; j <= 4; j++)
                {
                    var childName = random.Next(0, 100);
                    DataCollection.Add(new sampleData()
                        {
                            TaskID = ++RecordID,
                            FIELD1 = Names[childName],
                            FIELD2 = 1967 + random.Next(0, 10),
                            FIELD3 = 395 + random.Next(100, 600),
                            FIELD4 = 87 + random.Next(50, 250),
                            FIELD5 = 410 + random.Next(100, 600),
                            FIELD6 = 67 + random.Next(50, 250),
                            Field7 = (int)Math.Floor(random.NextDouble() * 100),
                            Field8 = (int)Math.Floor(random.NextDouble() * 10),
                            Field9 = (int)Math.Floor(random.NextDouble() * 10),
                            ParentID = Parent.TaskID
                        });
                }
            }
            return DataCollection;
        }
    }
}

{% endhighlight %}
{% endtabs %}

![Sticky header](images/sticky-header.gif)

## Frozen rows and columns

Frozen rows and columns provides an option to make rows and columns always visible in the top and left side of the tree grid while scrolling.

In this demo, the [FrozenColumns](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_FrozenColumns) is set as **2** and the [FrozenRows](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_FrozenRows) is set as **3**. Hence, the left two columns and top three rows are frozen.

{% tabs %}

{% highlight razor %}

@using TreeGridComponent.Data;
@using Syncfusion.Blazor.TreeGrid;
@using Syncfusion.Blazor.Grids

<SfTreeGrid DataSource="@TreeData" IdMapping="TaskId" ParentIdMapping="ParentId" Width="600" TreeColumnIndex="1"  Height="400" FrozenColumns="2" FrozenRows="3">
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

![Frozen Rows and Columns in Blazor TreeGrid](images/blazor-treegrid-frozen-rows-and-columns.png)

### Freeze particular columns

To freeze a particular column in the tree grid, the [IsFrozen](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridColumn.html#Syncfusion_Blazor_TreeGrid_TreeGridColumn_IsFrozen) property can be used.

{% tabs %}

{% highlight razor %}

@using TreeGridComponent.Data;
@using Syncfusion.Blazor.TreeGrid;
@using Syncfusion.Blazor.Grids

<SfTreeGrid DataSource="@TreeData" IdMapping="TaskId" ParentIdMapping="ParentId" Width="600" TreeColumnIndex="1"Height="400">
    <TreeGridColumns>
        <TreeGridColumn Field="TaskId" HeaderText="Task ID" Width="120" IsPrimaryKey="true" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="TaskName" HeaderText="Task Name" Width="260" IsFrozen="true"></TreeGridColumn>
        <TreeGridColumn Field="Priority" HeaderText="Priority" Width="100"></TreeGridColumn>
        <TreeGridColumn Field="Progress" HeaderText="Progress" Width="110"></TreeGridColumn>
        <TreeGridColumn Field="Duration" HeaderText="Duration (In Days)" Width="140" IsFrozen="true" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
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

![Freezing Specific Column in Blazor TreeGrid](images/blazor-treegrid-freeze-specific-column.png)

### Limitations

The following features are not supported in frozen rows and columns:

* Row Template
* Detail Template
* Cell Editing

## Add or remove frozen columns by dragging the column separator

The [TreeGridColumns](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridColumns.html) can be added or removed from frozen content by dragging and dropping the column separator. To enable this feature, set the `AllowFreezeLineMoving` property to true.

{% tabs %}

{% highlight razor %}

@using TreeGridComponent.Data;
@using Syncfusion.Blazor.TreeGrid;
@using Syncfusion.Blazor.Grids

<SfTreeGrid DataSource="@TreeData" IdMapping="TaskId" ParentIdMapping="ParentId" TreeColumnIndex="1" AllowFreezeLineMoving="true">
    <TreeGridColumns>
        <TreeGridColumn Field="TaskId" HeaderText="Task ID" Width="120" IsPrimaryKey="true" IsFrozen="true" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
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


N> If frozen columns are not specified, the frozen column separator appears at the left and right ends. Frozen columns can be dynamically changed by dragging the column separator.

![Add or Remove Frozen Blazor TreeGrid Columns by Dragging the Column Separator](./images/blazor-treegrid-freeze-line-moving.gif)

## Scroll the content programmatically
This section demonstrates how to invoke a [ScrollIntoViewAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_ScrollIntoViewAsync_System_Int32_System_Int32_System_Int32_) method to scroll the tree grid content into view externally by passing column index or row index as parameter.

{% tabs %}

{% highlight razor %}

@using TreeGridComponent.Data;
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.TreeGrid
@using Syncfusion.Blazor.Buttons
<div style="display: flex; align-items: center;">
    <div style="margin-right: 10px;">
        ColumnIndex:
    </div>
    <div style="display: flex; align-items: center; margin-right: 10px;">
        <input style="margin-right: 10px;" @bind-value="@ColumnIndex" />
        <SfButton @onclick="Scroll" Content="Scroll Horizontally"></SfButton>
    </div>
</div>
<div style="display: flex; align-items: center; padding-top: 5px;">
    <div style="margin-right: 33px;">
        RowIndex:
    </div>
    <div style="display: flex; align-items: center; margin-right: 10px;">
        <input style="margin-right: 10px;" @bind-value="@RowIndex" />
        <SfButton @onclick="Scroll" Content="Scroll Vertically"></SfButton>
    </div>
</div>
<SfTreeGrid @ref="TreeGrid" DataSource="@TreeData" RowHeight="35" IdMapping="TaskID" TreeColumnIndex="1" ParentIdMapping="ParentID" Height="400" Width="600">
    <TreeGridColumns>
        <TreeGridColumn Field="TaskID" HeaderText="Jersey No" TextAlign="TextAlign.Right" Width="150"></TreeGridColumn>
        <TreeGridColumn Field="FIELD1" HeaderText="Name" Width="150"></TreeGridColumn>
        <TreeGridColumn Field="FIELD2" HeaderText="Year" TextAlign="TextAlign.Right" Width="150"></TreeGridColumn>
        <TreeGridColumn Field="FIELD3" HeaderText="Stint" TextAlign="TextAlign.Right" Width="150"></TreeGridColumn>
        <TreeGridColumn Field="FIELD4" HeaderText="TMID" TextAlign="TextAlign.Right" Width="150"></TreeGridColumn>
        <TreeGridColumn Field="FIELD5" HeaderText="LGID" TextAlign="TextAlign.Right" Width="150"></TreeGridColumn>
        <TreeGridColumn Field="FIELD6" HeaderText="GP" TextAlign="TextAlign.Right" Width="150"></TreeGridColumn>
        <TreeGridColumn Field="Field7" HeaderText="GS" TextAlign="TextAlign.Right" Width="150"></TreeGridColumn>
        <TreeGridColumn Field="Field8" HeaderText="Minutes" TextAlign="TextAlign.Right" Width="150"></TreeGridColumn>
        <TreeGridColumn Field="Field9" HeaderText="Points" TextAlign="TextAlign.Right" Width="150"></TreeGridColumn>
    </TreeGridColumns>
</SfTreeGrid>

@code{
    public List<SampleData> TreeData { get; set; }
    SfTreeGrid<SampleData> TreeGrid { get; set; }
    public int ColumnIndex { get; set; } = -1;
    public int RowIndex { get; set; } = -1;
    public int RowHeight { get; set; } = -1;
    protected override void OnInitialized()
    {
        this.TreeData = SampleData.GetTreeSampleData().ToList();
    }
    public async Task Scroll()
    {
        await TreeGrid.ScrollIntoViewAsync(ColumnIndex, RowIndex, RowHeight);
    }
}

{% endhighlight %}

{% highlight c# %}

namespace TreeGridComponent.Data {

    public class SampleData
    {
        public int TaskID { get; set; }
        public string FIELD1 { get; set; }
        public int FIELD2 { get; set; }
        public int FIELD3 { get; set; }
        public int FIELD4 { get; set; }
        public int FIELD5 { get; set; }
        public int FIELD6 { get; set; }
        public int Field7 { get; set; }
        public int Field8 { get; set; }
        public int Field9 { get; set; }
        public int? ParentID { get; set; }
        public static List<SampleData> GetTreeSampleData()
        {
            string[] Names = new string[] { "VINET", "TOMSP", "HANAR", "VICTE", "SUPRD", "HANAR", "CHOPS", "RICSU", "WELLI", "HILAA", "ERNSH", "CENTC",
            "OTTIK", "QUEDE", "RATTC", "ERNSH", "FOLKO", "BLONP", "WARTH", "FRANK", "GROSR", "WHITC", "WARTH", "SPLIR", "RATTC", "QUICK", "VINET",
            "MAGAA", "TORTU", "MORGK", "BERGS", "LEHMS", "BERGS", "ROMEY", "ROMEY", "LILAS", "LEHMS", "QUICK", "QUICK", "RICAR", "REGGC", "BSBEV",
            "COMMI", "QUEDE", "TRADH", "TORTU", "RATTC", "VINET", "LILAS", "BLONP", "HUNGO", "RICAR", "MAGAA", "WANDK", "SUPRD", "GODOS", "TORTU",
            "OLDWO", "ROMEY", "LONEP", "ANATR", "HUNGO", "THEBI", "DUMON", "WANDK", "QUICK", "RATTC", "ISLAT", "RATTC", "LONEP", "ISLAT", "TORTU",
            "WARTH", "ISLAT", "PERIC", "KOENE", "SAVEA", "KOENE", "BOLID", "FOLKO", "FURIB", "SPLIR", "LILAS", "BONAP", "MEREP", "WARTH", "VICTE",
            "HUNGO", "PRINI", "FRANK", "OLDWO", "MEREP", "BONAP", "SIMOB", "FRANK", "LEHMS", "WHITC", "QUICK", "RATTC", "FAMIA" };
            List<SampleData> DataCollection = new List<SampleData>();
            Random random = new Random();
            var RecordID = 0;
            for (var i = 1; i <= 100; i++)
            {
                var name = random.Next(0, 100);
                SampleData Parent = new SampleData()
                {
                    TaskID = ++RecordID,
                    FIELD1 = Names[name],
                    FIELD2 = 1967 + random.Next(0, 10),
                    FIELD3 = 395 + random.Next(100, 600),
                    FIELD4 = 87 + random.Next(50, 250),
                    FIELD5 = 410 + random.Next(100, 600),
                    FIELD6 = 67 + random.Next(50, 250),
                    Field7 = (int)Math.Floor(random.NextDouble() * 100),
                    Field8 = (int)Math.Floor(random.NextDouble() * 10),
                    Field9 = (int)Math.Floor(random.NextDouble() * 10),
                    ParentID = null
                };
                DataCollection.Add(Parent);
                for (var j = 1; j <= 4; j++)
                {
                    var childName = random.Next(0, 100);
                    DataCollection.Add(new SampleData()
                    {
                        TaskID = ++RecordID,
                        FIELD1 = Names[childName],
                        FIELD2 = 1967 + random.Next(0, 10),
                        FIELD3 = 395 + random.Next(100, 600),
                        FIELD4 = 87 + random.Next(50, 250),
                        FIELD5 = 410 + random.Next(100, 600),
                        FIELD6 = 67 + random.Next(50, 250),
                        Field7 = (int)Math.Floor(random.NextDouble() * 100),
                        Field8 = (int)Math.Floor(random.NextDouble() * 10),
                        Field9 = (int)Math.Floor(random.NextDouble() * 10),
                        ParentID = Parent.TaskID
                    });
                }
            }
            return DataCollection;
        }
    }
}

{% endhighlight %}

{% endtabs %}
![Blazor Tree Grid Scroll programmatically](./images/blazor-treegrid-scroll-programmatically.gif)