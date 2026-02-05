---
layout: post
title: Print in Blazor TreeGrid Component | Syncfusion
description: Learn to print the Syncfusion Blazor TreeGrid using the toolbar Print command or PrintAsync method, configure browser page setup, and handle large columns.
platform: Blazor
control: TreeGrid
documentation: ug
---

# Print in Syncfusion Blazor TreeGrid Component

Invoke the [PrintAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_PrintAsync) method on the TreeGrid instance to generate a print view. Enable the **Print** option in the toolbar by adding the "Print" item.

{% tabs %}


{% highlight razor %}
@using TreeGridComponent.Data;
@using Syncfusion.Blazor.TreeGrid
@using Syncfusion.Blazor.Grids

<SfTreeGrid @ref="TreeGrid" DataSource="@TreeData" IdMapping="TaskId" ParentIdMapping="ParentId" Toolbar="@(new List<string>() { "Print" })" TreeColumnIndex="1" AllowPaging="true">
    <TreeGridPageSettings PageSize="2"></TreeGridPageSettings>
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
            BusinessObjectCollection.Add(new WrapData() { TaskId = 4871, TaskName = "Planning", StartDate = new DateTime(2025, 3, 2), EndDate = new DateTime(2025, 7, 11), Progress = "Open", Duration = 132, Priority = "Normal", Resources = 6, Approved = false, ParentId = null }); 
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

![Printing in Blazor TreeGrid](images/blazor-treegrid-printing.png)

## Page Setup

Some print settings such as layout, paper size, and margins must be configured using the browser's page setup dialog. Refer to the following resources for browser-specific instructions:

* [Chrome](https://support.google.com/chrome/answer/1069693?hl=en&visit_id=1-636335333734668335-3165046395&rd=1)
* [Firefox](https://support.mozilla.org/en-US/kb/how-print-web-pages-firefox)
* [Safari](https://www.mintprintables.com/print-tips/adjust-margins-osx/)
* [Internet Explorer](http://www.helpteaching.com/help/print/index.htm)

## Printing using an external button

To trigger printing from an external button, invoke the [PrintAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_PrintAsync) method on the TreeGrid instance.

{% tabs %}

{% highlight razor %}

@using Syncfusion.Blazor.TreeGrid
@using Syncfusion.Blazor.Grids
<input type="button" @onclick="onClick" value="Print Tree" />
<SfTreeGrid @ref="TreeGrid" DataSource="@TreeData" IdMapping="TaskId" ParentIdMapping="ParentId" Toolbar="@(new List<string>() { "Print" })" TreeColumnIndex="1" AllowPaging="true">
    <TreeGridPageSettings PageSize="2"></TreeGridPageSettings>
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
    SfTreeGrid<WrapData> TreeGrid;
    private List<WrapData> TreeData { get; set; } = new List<WrapData>();
    protected override void OnInitialized()
    {
        TreeData = WrapData.GetWrapData().ToList();
    }
    private async Task onClick()
    {
        await TreeGrid.PrintAsync();
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
            BusinessObjectCollection.Add(new WrapData() { TaskId = 4871, TaskName = "Planning", StartDate = new DateTime(2025, 3, 2), EndDate = new DateTime(2025, 7, 11), Progress = "Open", Duration = 132, Priority = "Normal", Resources = 6, Approved = false, ParentId = null }); 
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

![Displaying Print Button in Blazor TreeGrid](images/blazor-treegrid-print-button.png)

## Print the visible page

By default, the TreeGrid prints all the pages. To print the current page alone, set the [PrintMode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor~Syncfusion.Blazor.TreeGrid.SfTreeGrid~PrintMode.html) to **CurrentPage**.

{% tabs %}

{% highlight razor %}

@using Syncfusion.Blazor.TreeGrid
@using Syncfusion.Blazor.Grids
<SfTreeGrid @ref="TreeGrid" DataSource="@TreeData" IdMapping="TaskId" ParentIdMapping="ParentId" PrintMode="Syncfusion.Blazor.Grids.PrintMode.CurrentPage" Toolbar="@(new List<string>() { "Print" })" TreeColumnIndex="1" AllowPaging="true">
    <TreeGridPageSettings PageSize="2"></TreeGridPageSettings>
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
            BusinessObjectCollection.Add(new WrapData() { TaskId = 4871, TaskName = "Planning", StartDate = new DateTime(2025, 3, 2), EndDate = new DateTime(2025, 7, 11), Progress = "Open", Duration = 132, Priority = "Normal", Resources = 6, Approved = false, ParentId = null });
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


![Printing with Page in Blazor TreeGrid](images/blazor-treegrid-print-with-page.png)

## Print large number of columns

By default, the browser uses A4 as page size option to print pages and to adapt the size of the page the browser print preview will auto-hide the overflowed contents. Hence TreeGrid with large number of columns will cut off to adapt the print page.

To show large number of columns when printing, adjust the scale option from the print option panel based on the content size.

![Displaying Print Preview Option in Blazor TreeGrid](./images/blazor-treegrid-print-preview.png)

<!-- Show or Hide columns while Printing

To show a hidden column or hide a visible column while printing the TreeGrid using [`ToolbarClick`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor~Syncfusion.Blazor.TreeGrid.SfTreeGrid~ToolbarClick.html) events.

In [`ToolbarClick`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor~Syncfusion.Blazor.TreeGrid.SfTreeGrid~ToolbarClick.html) event, based on **args.Item.Text** as **print**. To show or hide columns by setting [`Visible`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor~Syncfusion.Blazor.TreeGrid.TreeGridColumn~Visible.htmll) of [`TreeGridColumn`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor~Syncfusion.Blazor.TreeGrid.TreeGridColumn.html) property to **true** or **false** respectively.

In [`PrintComplete`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor~Syncfusion.Blazor.TreeGrid.SfTreeGrid~PrintComplete.html) event, We have reversed the state back to the previous state.

In the below example, we have **Duration** as a hidden column in the TreeGrid. While printing, we have changed **Duration** to visible column and **StartDate** as hidden column.
-->

## Limitations of printing large data

When tree grid contains large number of data, printing all the data at once is not a best option for the browser performance. Rendering all DOM elements on a single page can cause performance issues. It leads to browser slow down or browser hang.

Printing large datasets directly from the browser may lead to performance issues such as slow rendering or browser hang. For better performance, consider exporting the TreeGrid to **Excel**, **CSV**, or **PDF**, and print using a desktop application.
