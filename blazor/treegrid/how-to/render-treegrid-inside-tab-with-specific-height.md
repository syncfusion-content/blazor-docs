---
layout: post
title: Blazor TreeGrid Component inside the Tab | Syncfusion
description: Learn how to render the Blazor TreeGrid component inside a Tab with a specific height and avoid layout issues.
platform: Blazor
control: TreeGrid
documentation: ug
---

# Render Blazor TreeGrid Component inside the Tab with Specific Height

By default, the TreeGrid occupies the full space of its parent element when the [Height](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_Height) and [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_Width) properties are set to `100%`. However, when the TreeGrid is rendered inside a Tab control, it may incorrectly calculate its dimensions based on the entire page, resulting in layout issues such as the absence of a horizontal scrollbar.

To resolve this, ensure that the parent container of the TreeGrid (inside the Tab) has a defined height. This allows the TreeGrid to correctly render with scrollbars and proper layout.

{% tabs %}

{% highlight razor %}

@using TreeGridComponent.Data;
@using Syncfusion.Blazor.Grids;
@using Syncfusion.Blazor.TreeGrid;
@using Syncfusion.Blazor.Navigations

<div style="height:300px">
        <SfTab ID="Ej2Tab" Width="100%">
            <TabItems>
                <TabItem>
                    <ChildContent>
                        <TabHeader Text="Tree Grid 1"></TabHeader>
                    </ChildContent>
                    <ContentTemplate>
                        <SfTreeGrid DataSource="@TreeGridData" IdMapping="TaskId" ParentIdMapping="ParentId" AllowPaging="true"
                                    TreeColumnIndex="1" Height="100%" Width="100%">
                            <TreeGridColumns>
                                <TreeGridColumn Field="TaskId" HeaderText="Task ID" IsPrimaryKey="true" Width="70" TextAlign="TextAlign.Right"></TreeGridColumn>
                                <TreeGridColumn Field="TaskName" HeaderText="Task Name" Width="85"></TreeGridColumn>
                                <TreeGridColumn Field="Priority" HeaderText="Priority" Width="60"></TreeGridColumn>
                                <TreeGridColumn Field="Duration" HeaderText="Duration" Width="70" Format="C2" TextAlign="TextAlign.Right"></TreeGridColumn>
                                <TreeGridColumn Field="Resources" HeaderText="Resource" Width="70" Format="C2" TextAlign="TextAlign.Right"></TreeGridColumn>
                                <TreeGridColumn Field="Progress" HeaderText="Progress" Width="70" Format="C2" TextAlign="TextAlign.Right"></TreeGridColumn>
                            </TreeGridColumns>
                        </SfTreeGrid>
                    </ContentTemplate>
                </TabItem>
                <TabItem>
                    <ChildContent>
                        <TabHeader Text="Tree Grid 2"></TabHeader>
                    </ChildContent>
                    <ContentTemplate>
                        <SfTreeGrid DataSource="@TreeDataSource" IdMapping="TaskId" ParentIdMapping="ParentId" AllowPaging="true"
                                    TreeColumnIndex="1" Height="100%" Width="100%">
                            <TreeGridColumns>
                                <TreeGridColumn Field="TaskId" HeaderText="Task ID" Visible="false" Width="100" TextAlign="TextAlign.Right"></TreeGridColumn>
                                <TreeGridColumn Field="Duration" HeaderText="Duration" Width="120" Format="C2" TextAlign="TextAlign.Right"></TreeGridColumn>
                                <TreeGridColumn Field="Progress" HeaderText="Progress" Width="120" Format="C2" TextAlign="TextAlign.Right"></TreeGridColumn>
                                <TreeGridColumn Field="Resources" HeaderText="Resources" Width="120" Format="C2" TextAlign="TextAlign.Right"></TreeGridColumn>
                            </TreeGridColumns>
                        </SfTreeGrid>
                    </ContentTemplate>
                </TabItem>
            </TabItems>
        </SfTab>
    </div>


    @code{
        SfTreeGrid<TreeData> TreeGrid;

        public List<TreeData> TreeGridData { get; set; }
        public List<WrapData> TreeDataSource { get; set; }
        protected override void OnInitialized()
        {
            this.TreeGridData = TreeData.GetSelfDataSource().ToList();
            this.TreeDataSource = WrapData.GetWrapData().ToList();
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
    public class WrapData
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? Duration { get; set; }
        public string Progress { get; set; }
        public string Priority { get; set; }
        public bool Approved { get; set; }
        public int Resources { get; set; }
        public int? ParentId { get; set; }
        public static List<WrapData> GetWrapData()
        {
            List<WrapData> BusinessObjectCollection = new List<WrapData>();
            BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 1,
                TaskName = "Planning",
                StartDate = new DateTime(2017, 03, 02),
                EndDate = new DateTime(2017, 07, 03),
                Progress = "Open",
                Duration = 5,
                Priority = "Normal",
                Resources = 6,
                Approved = false,
                ParentId = null
            });
            BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 2,
                TaskName = "Plan timeline",
                StartDate = new DateTime(2017, 03, 04),
                EndDate = new DateTime(2017, 07, 05),
                Progress = "Inprogress",
                Duration = 5,
                Resources = 4,
                Priority = "Normal",
                Approved = false,
                ParentId = 1
            });
            BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 3,
                TaskName = "Plan budget",
                StartDate = new DateTime(2017, 03, 06),
                EndDate = new DateTime(2017, 07, 07),
                Duration = 5,
                Progress = "Started",
                Approved = true,
                Resources = 6,
                Priority = "Low",
                ParentId = 1
            });
            BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 4,
                TaskName = "Allocate resources",
                StartDate = new DateTime(2017, 03, 08),
                EndDate = new DateTime(2017, 07, 09),
                Duration = 5,
                Progress = "Open",
                Priority = "Critical",
                ParentId = 1,
                Resources = 3,
                Approved = false
            });
            BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 5,
                TaskName = "Planning complete",
                StartDate = new DateTime(2017, 07, 10),
                EndDate = new DateTime(2017, 07, 11),
                Duration = 1,
                Progress = "Open",
                Priority = "Low",
                Resources = 5,
                ParentId = 1,
                Approved = true
            });
            BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 6,
                TaskName = "Design",
                StartDate = new DateTime(2017, 10, 12),
                EndDate = new DateTime(2017, 02, 13),
                Progress = "Inprogress",
                Duration = 3,
                Priority = "High",
                Resources = 4,
                Approved = false,
                ParentId = null
            });
            BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 7,
                TaskName = "Software Specification",
                StartDate = new DateTime(2017, 10, 14),
                EndDate = new DateTime(2017, 02, 15),
                Duration = 3,
                Progress = "Started",
                Resources = 3,
                Priority = "Normal",
                ParentId = 6,
                Approved = false
            });
            BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 8,
                TaskName = "Develop prototype",
                StartDate = new DateTime(2017, 10, 16),
                EndDate = new DateTime(2017, 02, 17),
                Duration = 3,
                Progress = "Inprogress",
                Resources = 2,
                Priority = "Critical",
                ParentId = 6,
                Approved = false
            });
            BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 9,
                TaskName = "Get approval from customer",
                StartDate = new DateTime(2017, 02, 18),
                EndDate = new DateTime(2017, 02, 19),
                Duration = 2,
                Progress = "Inprogress",
                Resources = 3,
                Priority = "Low",
                Approved = true,
                ParentId = 6
            });
            BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 10,
                TaskName = "Design complete",
                StartDate = new DateTime(2017, 02, 20),
                EndDate = new DateTime(2017, 02, 21),
                Duration = 1,
                Progress = "Inprogress",
                Resources = 6,
                Priority = "Normal",
                ParentId = 6,
                Approved = true
            });
            BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 12,
                TaskName = "Implementation Phase",
                StartDate = new DateTime(2017, 02, 22),
                EndDate = new DateTime(2017, 02, 23),
                Priority = "Normal",
                Approved = false,
                Duration = 11,
                Resources = 5,
                Progress = "Started",
                ParentId = null
            });
            BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 13,
                TaskName = "Phase 1",
                StartDate = new DateTime(2017, 02, 24),
                EndDate = new DateTime(2017, 02, 25),
                Priority = "High",
                Approved = false,
                Duration = 11,
                Progress = "Open",
                Resources = 4,
                ParentId = 12
            });
            BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 14,
                TaskName = "Implementation Module 1",
                StartDate = new DateTime(2017, 02, 26),
                EndDate = new DateTime(2017, 02, 27),
                Priority = "Normal",
                Duration = 11,
                Progress = "Started",
                Resources = 3,
                Approved = false,
                ParentId = 13
            });
            BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 15,
                TaskName = "Development Task 1",
                StartDate = new DateTime(2017, 06, 18),
                EndDate = new DateTime(2017, 06, 19),
                Duration = 3,
                Progress = "Inprogress",
                Priority = "High",
                Resources = 2,
                ParentId = 14,
                Approved = false
            });
            BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 16,
                TaskName = "Development Task 2",
                StartDate = new DateTime(2017, 02, 13),
                EndDate = new DateTime(2017, 03, 01),
                Duration = 3,
                Progress = "Closed",
                Priority = "Low",
                Resources = 5,
                ParentId = 14,
                Approved = true
            });
            BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 17,
                TaskName = "Testing",
                StartDate = new DateTime(2017, 03, 02),
                EndDate = new DateTime(2017, 03, 03),
                Duration = 2,
                Progress = "Closed",
                Priority = "Normal",
                ParentId = 14,
                Resources = 1,
                Approved = true
            });
            BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 18,
                TaskName = "Bug fix",
                StartDate = new DateTime(2017, 03, 04),
                EndDate = new DateTime(2017, 03, 05),
                Duration = 2,
                Progress = "Validated",
                Priority = "Critical",
                ParentId = 14,
                Resources = 6,
                Approved = false
            });
            BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 19,
                TaskName = "Customer review meeting",
                StartDate = new DateTime(2017, 03, 06),
                EndDate = new DateTime(2017, 03, 07),
                Duration = 2,
                Progress = "Open",
                Priority = "High",
                ParentId = 14,
                Resources = 6,
                Approved = false
            });
            BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 20,
                TaskName = "Phase 1 complete",
                StartDate = new DateTime(2017, 04, 27),
                EndDate = new DateTime(2017, 07, 27),
                Duration = 2,
                Progress = "Closed",
                Priority = "Low",
                ParentId = 14,
                Resources = 5,
                Approved = true
            });
            BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 21,
                TaskName = "Phase 2",
                StartDate = new DateTime(2017, 07, 17),
                EndDate = new DateTime(2017, 09, 28),
                Priority = "High",
                Approved = false,
                Progress = "Open",
                ParentId = 12,
                Resources = 3,
                Duration = 12,
            });
            BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 22,
                TaskName = "Implementation Module 2",
                StartDate = new DateTime(2017, 01, 17),
                EndDate = new DateTime(2017, 02, 28),
                Priority = "Critical",
                Approved = false,
                Progress = "Inprogress",
                ParentId = 21,
                Resources = 3,
                Duration = 12
            });
            BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 23,
                TaskName = "Development Task 1",
                StartDate = new DateTime(2017, 08, 17),
                EndDate = new DateTime(2017, 09, 20),
                Duration = 4,
                Progress = "Closed",
                Priority = "Normal",
                ParentId = 22,
                Resources = 2,
                Approved = true,
            });
            BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 24,
                TaskName = "Development Task 2",
                StartDate = new DateTime(2017, 04, 17),
                EndDate = new DateTime(2017, 03, 20),
                Duration = 4,
                Progress = "Closed",
                Priority = "Critical",
                ParentId = 22,
                Resources = 5,
                Approved = true,
            });
            BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 25,
                TaskName = "Testing",
                StartDate = new DateTime(2017, 01, 21),
                EndDate = new DateTime(2017, 01, 24),
                Duration = 2,
                Progress = "Open",
                Priority = "High",
                ParentId = 22,
                Resources = 3,
                Approved = false,
            });
            BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 26,
                TaskName = "Bug fix",
                StartDate = new DateTime(2017, 03, 25),
                EndDate = new DateTime(2017, 08, 26),
                Duration = 2,
                Progress = "Validated",
                Priority = "Low",
                Approved = false,
                Resources = 6,
                ParentId = 22
            });
            BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 27,
                TaskName = "Customer review meeting",
                StartDate = new DateTime(2017, 07, 27),
                EndDate = new DateTime(2017, 06, 28),
                Duration = 2,
                Progress = "Inprogress",
                Priority = "Critical",
                ParentId = 22,
                Resources = 4,
                Approved = true,
            });
            BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 28,
                TaskName = "Phase 2 complete",
                StartDate = new DateTime(2017, 07, 19),
                EndDate = new DateTime(2017, 05, 28),
                Duration = 2,
                Priority = "Normal",
                Progress = "Open",
                ParentId = 22,
                Resources = 3,
                Approved = false,
            });
            BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 29,
                TaskName = "Phase 3",
                StartDate = new DateTime(2017, 07, 17),
                EndDate = new DateTime(2017, 02, 12),
                Priority = "Normal",
                Approved = false,
                Duration = 11,
                Progress = "Inprogress",
                Resources = 4,
                ParentId = 12
            });
            BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 30,
                TaskName = "Implementation Module 3",
                StartDate = new DateTime(2017, 08, 17),
                EndDate = new DateTime(2017, 09, 27),
                Priority = "High",
                Approved = false,
                Duration = 11,
                Resources = 5,
                Progress = "Validated",
                ParentId = 29,
            });
            BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 31,
                TaskName = "Development Task 1",
                StartDate = new DateTime(2017, 11, 17),
                EndDate = new DateTime(2017, 12, 19),
                Duration = 3,
                Progress = "Closed",
                Priority = "Low",
                Approved = true,
                Resources = 3,
                ParentId = 30
            });
            BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 32,
                TaskName = "Development Task 2",
                StartDate = new DateTime(2017, 12, 17),
                EndDate = new DateTime(2017, 02, 19),
                Duration = 3,
                Progress = "Closed",
                Priority = "Normal",
                Approved = false,
                Resources = 2,
                ParentId = 30
            });
            BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 33,
                TaskName = "Testing",
                StartDate = new DateTime(2017, 01, 01),
                EndDate = new DateTime(2017, 07, 21),
                Duration = 2,
                Progress = "Closed",
                Priority = "Critical",
                ParentId = 30,
                Resources = 4,
                Approved = true,
            });
            BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 34,
                TaskName = "Bug fix",
                StartDate = new DateTime(2017, 01, 24),
                EndDate = new DateTime(2017, 01, 25),
                Duration = 2,
                Progress = "Open",
                Priority = "High",
                Approved = false,
                Resources = 3,
                ParentId = 30
            });
            BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 35,
                TaskName = "Customer review meeting",
                StartDate = new DateTime(2017, 12, 26),
                EndDate = new DateTime(2017, 12, 27),
                Duration = 2,
                Progress = "Inprogress",
                Priority = "Normal",
                ParentId = 30,
                Resources = 6,
                Approved = true,
            });
            BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 36,
                TaskName = "Phase 3 complete",
                StartDate = new DateTime(2017, 05, 27),
                EndDate = new DateTime(2017, 05, 27),
                Duration = 2,
                Priority = "Critical",
                Progress = "Open",
                Resources = 5,
                ParentId = 30,
                Approved = false,
            });
            return BusinessObjectCollection;
        }
    }
}

{% endhighlight %}

{% endtabs %}

![Blazor TreeGrid Tab with Specific Height](../images/blazor-treegrid-tab-with-specific-height.PNG)
