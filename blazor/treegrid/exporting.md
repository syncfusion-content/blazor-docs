---
layout: post
title: Export TreeGrid Data to PDF in Blazor | Syncfusion
description: Learn how to configure PDF export, customize file names, apply themes, and change orientation in the Syncfusion Blazor TreeGrid component
platform: Blazor
control: TreeGrid
documentation: ug
---

# PDF Export in Blazor TreeGrid Component

The PDF export feature enables conversion of TreeGrid data into a downloadable PDF document. To perform the export, use the
 [ExportToPdfAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_ExportToPdfAsync) method for exporting. To enable PDF export in the TreeGrid, set the [AllowPdfExport](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor~Syncfusion.Blazor.Grids.EjsGrid~AllowPdfExport.html) as true.

For a visual walkthrough of PDF export in the Blazor TreeGrid component, refer to the following video:

{% youtube alt="PDF Export in Blazor TreeGrid - Syncfusion"
"youtube:https://www.youtube.com/watch?v=SHCWtM2buCc"%}

{% tabs %}

{% highlight razor %}

@using TreeGridComponent.Data;
@using Syncfusion.Blazor.TreeGrid
@using Syncfusion.Blazor.Grids

<SfTreeGrid @ref="TreeGrid" DataSource="@TreeData" IdMapping="TaskId" ParentIdMapping="ParentId" AllowPdfExport="true" Toolbar="@(new List<string>() { "PdfExport" })" TreeColumnIndex="1" AllowPaging="true">
    <TreeGridEvents OnToolbarClick="ToolbarClickHandler" TValue="WrapData"></TreeGridEvents>
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
    private async Task ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs Args)
    {
        if (Args.Item.Text == "PDF Export")
        {
            await this.TreeGrid.ExportToPdfAsync();
        }
    }
}

{% endhighlight %}

{% highlight c# %}

namespace TreeGridComponent.Data 
{
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

## PDF Export Customization Options

PDF export provides an option to customize mapping of TreeGrid to exported PDF document.

### Set File Name for Exported PDF

The file name can be assigned for the exported document by defining **fileName** property in [PdfExportProperties](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridPdfExportProperties.html).

{% tabs %}

{% highlight razor %}

@using TreeGridComponent.Data;
@using Syncfusion.Blazor.TreeGrid
@using Syncfusion.Blazor.Grids

<SfTreeGrid @ref="TreeGrid" DataSource="@TreeData" IdMapping="TaskId" ParentIdMapping="ParentId" AllowPdfExport="true" Toolbar="@(new List<string>() { "PdfExport" })" TreeColumnIndex="1" AllowPaging="true">
    <TreeGridEvents OnToolbarClick="ToolbarClickHandler" TValue="WrapData"></TreeGridEvents>
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
    private async Task ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs Args)
    {
        if (Args.Item.Text == "PDF Export")
        {
            Syncfusion.Blazor.Grids.PdfExportProperties ExportProperties = new Syncfusion.Blazor.Grids.PdfExportProperties();
            ExportProperties.FileName = "test.pdf";
            await this.TreeGrid.ExportToPdfAsync(ExportProperties);
        }
    }
}

{% endhighlight %}

{% highlight c# %}

namespace TreeGridComponent.Data 
{
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

### Change Page Orientation in Exported PDF

Page orientation can be changed Landscape (default is Portrait) for the exported document using the `PdfExportProperties`.

{% tabs %}

{% highlight razor %}

@using TreeGridComponent.Data;
@using Syncfusion.Blazor.TreeGrid
@using Syncfusion.Blazor.Grids

<SfTreeGrid @ref="TreeGrid" DataSource="@TreeData" IdMapping="TaskId" ParentIdMapping="ParentId" AllowPdfExport="true" Toolbar="@(new List<string>() { "PdfExport" })" TreeColumnIndex="1" AllowPaging="true">
    <TreeGridEvents OnToolbarClick="ToolbarClickHandler" TValue="WrapData"></TreeGridEvents>
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
    private async Task ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs Args)
    {
        if (Args.Item.Text == "PDF Export")
        {
            Syncfusion.Blazor.Grids.PdfExportProperties ExportProperties = new Syncfusion.Blazor.Grids.PdfExportProperties();
            ExportProperties.PageOrientation = Syncfusion.Blazor.Grids.PageOrientation.Landscape;
            await this.TreeGrid.ExportToPdfAsync(ExportProperties);
        }
    }
}

{% endhighlight %}

{% highlight c# %}

namespace TreeGridComponent.Data 
{
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

### Customize Page Size for Exported PDF

Page size can be customized for the exported document using the `PdfExportProperties`.

Supported page sizes are:

* Letter
* Note
* Legal
* A0
* A1
* A2
* A3
* A5
* A6
* A7
* A8
* A9
* B0
* B1
* B2
* B3
* B4
* B5
* Archa
* Archb
* Archc
* Archd
* Arche
* Flsa
* HalfLetter
* Letter11x17
* Ledger

{% tabs %}

{% highlight razor %}

@using TreeGridComponent.Data;
@using Syncfusion.Blazor.TreeGrid
@using Syncfusion.Blazor.Grids

<SfTreeGrid @ref="TreeGrid" DataSource="@TreeData" IdMapping="TaskId" ParentIdMapping="ParentId" AllowPdfExport="true" Toolbar="@(new List<string>() { "PdfExport" })" TreeColumnIndex="1" AllowPaging="true">
    <TreeGridEvents OnToolbarClick="ToolbarClickHandler" TValue="WrapData"></TreeGridEvents>
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
    private async Task ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs Args)
    {
        if(Args.Item.Text == "PDF Export")
        {
            Syncfusion.Blazor.Grids.PdfExportProperties ExportProperties = new Syncfusion.Blazor.Grids.PdfExportProperties();
            ExportProperties.PageSize = Syncfusion.Blazor.Grids.PdfPageSize.Letter;
            await this.TreeGrid.ExportToPdfAsync(ExportProperties);
        }
    }
}

{% endhighlight %}

{% highlight c# %}

namespace TreeGridComponent.Data 
{
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

### Export Only the Current Page

PDF export provides an option to export the current page into PDF. To export current page, define the **exportType** to **CurrentPage**.

{% tabs %}

{% highlight razor %}

@using TreeGridComponent.Data;
@using Syncfusion.Blazor.TreeGrid
@using Syncfusion.Blazor.Grids

<SfTreeGrid @ref="TreeGrid" DataSource="@TreeData" IdMapping="TaskId" ParentIdMapping="ParentId" AllowPdfExport="true" Toolbar="@(new List<string>() { "PdfExport" })" TreeColumnIndex="1" AllowPaging="true">
    <TreeGridEvents OnToolbarClick="ToolbarClickHandler" TValue="WrapData"></TreeGridEvents>
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
    private async Task ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs Args)
    {
        if (Args.Item.Text == "PDF Export")
        {
            Syncfusion.Blazor.Grids.PdfExportProperties ExportProperties = new Syncfusion.Blazor.Grids.PdfExportProperties();
            ExportProperties.ExportType = Syncfusion.Blazor.Grids.ExportType.CurrentPage;
            await this.TreeGrid.ExportToPdfAsync(ExportProperties);
        }
    }
}

{% endhighlight %}

{% highlight c# %}

namespace TreeGridComponent.Data 
{
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

### Include Hidden Columns in Exported PDF

PDF export provides an option to export hidden columns of the TreeGrid by defining the **includeHiddenColumn** as **true**.

{% tabs %}

{% highlight razor %}

@using TreeGridComponent.Data;
@using Syncfusion.Blazor.TreeGrid
@using Syncfusion.Blazor.Grids

<SfTreeGrid @ref="TreeGrid" DataSource="@TreeData" IdMapping="TaskId" ParentIdMapping="ParentId" AllowPdfExport="true" Toolbar="@(new List<string>() { "PdfExport" })" TreeColumnIndex="1" AllowPaging="true">
    <TreeGridEvents OnToolbarClick="ToolbarClickHandler" TValue="WrapData"></TreeGridEvents>
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
    private async Task ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs Args)
    {
        if(Args.Item.Text == "PDF Export")
        {
            Syncfusion.Blazor.Grids.PdfExportProperties ExportProperties = new Syncfusion.Blazor.Grids.PdfExportProperties();
            ExportProperties.IncludeHiddenColumn = true;
            await this.TreeGrid.ExportToPdfAsync(ExportProperties);
        }
    }
}

{% endhighlight %}

{% highlight c# %}

namespace TreeGridComponent.Data 
{
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

### Apply Theme to Exported PDF

PDF export provides an option to include theme for exported PDF document.

To apply theme in exported PDF, define the **theme** in `PdfExportProperties`.

{% tabs %}

{% highlight razor %}

@using TreeGridComponent.Data;
@using Syncfusion.Blazor.TreeGrid
@using Syncfusion.Blazor.Grids

<SfTreeGrid @ref="TreeGrid" DataSource="@TreeData" IdMapping="TaskId" ParentIdMapping="ParentId" AllowPdfExport="true" Toolbar="@(new List<string>() { "PdfExport" })" TreeColumnIndex="1" AllowPaging="true">
    <TreeGridEvents OnToolbarClick="ToolbarClickHandler" TValue="WrapData"></TreeGridEvents>
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
    private async Task ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs Args)
    {
        if(Args.Item.Text == "PDF Export")
        {
            Syncfusion.Blazor.Grids.PdfExportProperties ExportProperties = new Syncfusion.Blazor.Grids.PdfExportProperties();
            Syncfusion.Blazor.Grids.PdfTheme Theme = new Syncfusion.Blazor.Grids.PdfTheme();

            Syncfusion.Blazor.Grids.PdfBorder HeaderBorder = new Syncfusion.Blazor.Grids.PdfBorder();
            HeaderBorder.Color = "#64FA50";

            Syncfusion.Blazor.Grids.PdfThemeStyle HeaderThemeStyle = new Syncfusion.Blazor.Grids.PdfThemeStyle()
            {
                FontColor = "#64FA50",
                FontName = "Calibri",
                FontSize = 17,
                Bold = true,
                Border = HeaderBorder
            };
            Theme.Header = HeaderThemeStyle;

            Syncfusion.Blazor.Grids.PdfThemeStyle RecordThemeStyle = new Syncfusion.Blazor.Grids.PdfThemeStyle()
            {
                FontColor = "#64FA50",
                FontName = "Calibri",
                FontSize = 17

            };
            Theme.Record = RecordThemeStyle;

            Syncfusion.Blazor.Grids.PdfThemeStyle CaptionThemeStyle = new Syncfusion.Blazor.Grids.PdfThemeStyle()
            {
                FontColor = "#64FA50",
                FontName = "Calibri",
                FontSize = 17,
                Bold = true

            };
            Theme.Caption = CaptionThemeStyle;
            ExportProperties.Theme = Theme;
            await this.TreeGrid.ExportToPdfAsync(ExportProperties);
        }
    }
}

{% endhighlight %}

{% highlight c# %}

namespace TreeGridComponent.Data 
{
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

N> By default, material theme is applied to exported PDF document.