---
layout: post
title: Auto Select Child Rows When Selecting Parent Row in Blazor TreeGrid | Syncfusion
description: Learn to automatically select child rows when selecting a parent row in the Syncfusion Blazor TreeGrid component and more.
platform: Blazor
control: TreeGrid
documentation: ug
---

# Automatically Select Child Rows When Selecting a Parent Row in Blazor TreeGrid

Handle the [RowSelecting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridEvents-1.html#Syncfusion_Blazor_TreeGrid_TreeGridEvents_1_RowSelecting) event to automatically select all child rows when a parent row is selected. Inside the event handler, use the `GetCurrentViewRecords` method to get the current view data and identify the selected row. Check whether the selected row is a parent using the `HasChild` boolean field, retrieve its child records recursively, and select them using the [SelectRowsAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_SelectRowsAsync_System_Int32___) method.

The following example demonstrates automatically selecting child rows when a parent row is selected in the Blazor TreeGrid component.

{% tabs %}

{% highlight razor %}

@using Syncfusion.Blazor.Grids;
@using Syncfusion.Blazor.TreeGrid;

<SfTreeGrid @ref="TreeGrid" DataSource="@TreeGridData" IdMapping="TaskId" ParentIdMapping="ParentId" TreeColumnIndex="1">
    <TreeGridSelectionSettings Type="SelectionType.Multiple" PersistSelection=true></TreeGridSelectionSettings>
    <TreeGridColumns>
        <TreeGridColumn Field="TaskId" HeaderText="Task ID" Width="80" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="TaskName" HeaderText="Task Name" Width="160"></TreeGridColumn>
        <TreeGridColumn Field="Duration" HeaderText="Duration" Width="100" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="Progress" HeaderText="Progress" Width="100" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="Priority" HeaderText="Priority" Width="80"></TreeGridColumn>
        <TreeGridEvents TValue="TreeData.BusinessObject" RowSelecting="RowSelectingHandler"></TreeGridEvents>
    </TreeGridColumns>
</SfTreeGrid>

@code {
    SfTreeGrid<TreeData.BusinessObject> TreeGrid;
    public List<TreeData.BusinessObject> TreeGridData { get; set; }
    public List<int> selected_Inx = new List<int>();
    public Boolean flag = false;
    public bool multiselect = false;
    public string selectedParentId { get; set; }
    List<int> childRowIndexes = new List<int>();

    protected override void OnInitialized()
    {
        this.TreeGridData = TreeData.GetSelfDataSource().ToList();
    }

    // To get the child records for the parent
    public List<TreeData.BusinessObject> GetChildren(TreeData.BusinessObject parentData)
    {
        List<TreeData.BusinessObject> children = new List<TreeData.BusinessObject>();
        selectedParentId = parentData.TaskId.ToString();
        var childRecords = TreeGridData.Where(rec => rec.ParentId != null && rec.ParentId.ToString() == parentData.TaskId.ToString()).ToList();
        for (var i = 0; i < childRecords?.Count; i++)
        {
            children.Add(childRecords[i]);
            var data = childRecords.ElementAt(i);
            if (data.HasChild)
            {
                // To get the root child records
                children = children.Concat(GetChildren(data)).ToList();
            }
        }
        return children;
    }

    public async void RowSelectingHandler(Syncfusion.Blazor.Grids.RowSelectingEventArgs<TreeData.BusinessObject> args)
    {
        var currentViewData = TreeGrid.GetCurrentViewRecords();
        var index = currentViewData.IndexOf(args.Data);
        selected_Inx = selected_Inx.Concat(await TreeGrid.GetSelectedRowIndexesAsync()).Distinct().ToList();
        // To check if args.Data is a parent and already selected
        if (args.Data.HasChild && childRowIndexes.IndexOf(index) == -1 && selected_Inx.IndexOf(index) == -1)
        {
            // To get the child records
            var children = GetChildren(args.Data);

            // To collect the child index
            foreach (var child in children)
            {
                childRowIndexes.Add(currentViewData.IndexOf(child));
            }

            // To select the child records
            if (args.IsCtrlPressed)
            {
                var selecting_Inx = selected_Inx.Concat(childRowIndexes).ToArray();
                var inx = selecting_Inx.OrderBy(item => item).ToArray();
                await TreeGrid.SelectRowsAsync(inx);
                selected_Inx.Clear(); // Clearing the selected indexes once the selection for the selected records were done.
            }
            else
            {
                await TreeGrid.SelectRowsAsync(childRowIndexes.ToArray());
                multiselect = true;
            }
            childRowIndexes.Clear(); // Clearing the childRowIndexes after the child records are selected
        }
    }

    public class TreeData
    {
        public class BusinessObject
        {
            public Guid TaskId { get; set; }
            public string TaskName { get; set; }
            public int? Duration { get; set; }
            public int? Progress { get; set; }
            public string Priority { get; set; }
            public Guid? ParentId { get; set; }
            public bool HasChild { get; set; }
        }

        public static List<BusinessObject> GetSelfDataSource()
        {
            List<BusinessObject> BusinessObjectCollection = new List<BusinessObject>();
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = new Guid("284b28db-04b4-401d-9e90-10f911fda1fe"), TaskName = "Parent Task 1", Duration = 1, Progress = 70, Priority = "Critical", ParentId = null, HasChild = true });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = new Guid("284b28db-04b4-401d-9e90-10f911fda2fe"), TaskName = "Child task 1", Duration = 2, Progress = 80, Priority = "Low", ParentId = new Guid("284b28db-04b4-401d-9e90-10f911fda1fe"), HasChild = false });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = new Guid("284b28db-04b4-401d-9e90-10f911fda3fe"), TaskName = "Child Task 2", Duration = 3, Progress = 65, Priority = "Critical", ParentId = new Guid("284b28db-04b4-401d-9e90-10f911fda1fe") });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = new Guid("284b28db-04b4-401d-9e90-10f911fda4fe"), TaskName = "Child task 3", Duration = 4, Priority = "High", Progress = 77, ParentId = new Guid("284b28db-04b4-401d-9e90-10f911fda1fe") });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = new Guid("284b28db-04b4-401d-9e90-10f911fda5fe"), TaskName = "Parent Task 2", Duration = 5, Progress = 70, Priority = "Critical", ParentId = null, HasChild = true });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = new Guid("284b28db-04b4-401d-9e90-10f911fda6fe"), TaskName = "Child task 1", Duration = 4, Progress = 80, Priority = "Critical", ParentId = new Guid("284b28db-04b4-401d-9e90-10f911fda5fe"), HasChild = false });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = new Guid("284b28db-04b4-401d-9e90-10f911fda7fe"), TaskName = "Child Task 2", Duration = 5, Progress = 65, Priority = "Low", ParentId = new Guid("284b28db-04b4-401d-9e90-10f911fda5fe") });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = new Guid("284b28db-04b4-401d-9e90-10f911fda8fe"), TaskName = "Child task 3", Duration = 3, Progress = 77, Priority = "High", ParentId = new Guid("284b28db-04b4-401d-9e90-10f911fda5fe") });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = new Guid("284b28db-04b4-401d-9e90-10f911fda9fe"), TaskName = "Child task 4", Duration = 2, Progress = 77, Priority = "Low", ParentId = new Guid("284b28db-04b4-401d-9e90-10f911fda5fe"), HasChild = false });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = new Guid("284b28db-04b4-401d-9e90-10f91fda10fe"), TaskName = "Parent Task 3", Duration = 5, Progress = 70, Priority = "Critical", ParentId = null, HasChild = true });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = new Guid("284b28db-04b4-401d-9e90-10f91fda11fe"), TaskName = "Child task 1", Duration = 4, Progress = 80, Priority = "Critical", ParentId = new Guid("284b28db-04b4-401d-9e90-10f91fda10fe"), HasChild = false });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = new Guid("284b28db-04b4-401d-9e90-10f91fda12fe"), TaskName = "Child Task 2", Duration = 5, Progress = 65, Priority = "Low", ParentId = new Guid("284b28db-04b4-401d-9e90-10f91fda10fe") });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = new Guid("284b28db-04b4-401d-9e90-10f91fda13fe"), TaskName = "Child task 3", Duration = 3, Progress = 77, Priority = "High", ParentId = new Guid("284b28db-04b4-401d-9e90-10f91fda10fe") });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = new Guid("284b28db-04b4-401d-9e90-10f91fda15fe"), TaskName = "Child task 4", Duration = 2, Progress = 77, Priority = "Low", ParentId = new Guid("284b28db-04b4-401d-9e90-10f91fda10fe"), HasChild = true });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = new Guid("284b28db-04b4-401d-9e90-10f91fda16fe"), TaskName = "Parent Task 3", Duration = 5, Progress = 70, Priority = "Critical", ParentId = new Guid("284b28db-04b4-401d-9e90-10f91fda15fe"), HasChild = true });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = new Guid("284b28db-04b4-401d-9e90-10f91fda17fe"), TaskName = "Child task 7", Duration = 4, Progress = 80, Priority = "Critical", ParentId = new Guid("284b28db-04b4-401d-9e90-10f91fda16fe"), HasChild = false });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = new Guid("284b28db-04b4-401d-9e90-10f91fda18fe"), TaskName = "Child task 8", Duration = 2, Progress = 77, Priority = "Low", ParentId = new Guid("284b28db-04b4-401d-9e90-10f91fda16fe"), HasChild = false });
            return BusinessObjectCollection;
        }
    }
}

{% endhighlight %}

{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rZBHDdCehThIpVGm?appbar=true&editor=true&result=true&errorlist=true&theme=bootstrap5" %}

> **Note:** Use a Boolean field such as `HasChild` in the data model along with the `GetCurrentViewRecords` method to determine parent-child relationships and identify the selected row accurately.
