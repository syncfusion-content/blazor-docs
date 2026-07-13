---
layout: post
title: Select Children based on Parent Selection in Blazor TreeGrid | Syncfusion
description: Learn how to automatically select child records when a parent row is selected in the Syncfusion Blazor TreeGrid component using RowSelecting event.
platform: Blazor
control: TreeGrid
documentation: ug
---

# Select Children based on Parent Selection in Blazor TreeGrid Component

When a user manually clicks a parent row in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor TreeGrid, all its child records can be automatically selected. This is achieved by handling the [RowSelecting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridEvents-1.html#Syncfusion_Blazor_TreeGrid_TreeGridEvents_1_RowSelecting) event and invoking the [SelectRowsAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_SelectRowsAsync_System_Int32___) method.

To implement this:
- Set the [Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridSelectionSettings.html#Syncfusion_Blazor_TreeGrid_TreeGridSelectionSettings_Type) property of [TreeGridSelectionSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridSelectionSettings.html) to **Multiple** and enable [PersistSelection](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridSelectionSettings.html#Syncfusion_Blazor_TreeGrid_TreeGridSelectionSettings_PersistSelection) to retain existing selections across interactions.
- Bind the [RowSelecting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridEvents-1.html#Syncfusion_Blazor_TreeGrid_TreeGridEvents_1_RowSelecting) event to detect when the user manually clicks to select a row.
- In the [RowSelecting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridEvents-1.html#Syncfusion_Blazor_TreeGrid_TreeGridEvents_1_RowSelecting) event handler, check if the manually selected row is a parent record using the `HasChild` property.
- Use a recursive helper method (`GetChildren`) to retrieve all nested child records for the selected parent.
- Invoke [SelectRowsAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_SelectRowsAsync_System_Int32___) to select all child records along with the parent row.

{% tabs %}

{% highlight razor %}

@using Syncfusion.Blazor.Grids;
@using Syncfusion.Blazor.TreeGrid;

<SfTreeGrid @ref="TreeGrid" DataSource="@TreeGridData" IdMapping="TaskId" ParentIdMapping="ParentId" TreeColumnIndex="1">
    <TreeGridSelectionSettings Type="Syncfusion.Blazor.Grids.SelectionType.Multiple" PersistSelection="true"></TreeGridSelectionSettings>
    <TreeGridEvents TValue="TreeData.BusinessObject" RowSelecting="RowSelectingHandler"></TreeGridEvents>
    <TreeGridColumns>
        <TreeGridColumn Field="TaskId" HeaderText="Task ID" Width="80" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="TaskName" HeaderText="Task Name" Width="160"></TreeGridColumn>
        <TreeGridColumn Field="Duration" HeaderText="Duration" Width="100" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="Progress" HeaderText="Progress" Width="100" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="Priority" HeaderText="Priority" Width="80"></TreeGridColumn>
    </TreeGridColumns>
</SfTreeGrid>

@code {
    SfTreeGrid<TreeData.BusinessObject> TreeGrid;
    public List<TreeData.BusinessObject> TreeGridData { get; set; }
    public List<int> selected_Inx = new List<int>();
    public bool multiselect = false;
    public string selectedParentId { get; set; }
    List<int> childRowIndexes = new List<int>();

    protected override void OnInitialized()
    {
        this.TreeGridData = TreeData.GetSelfDataSource().ToList();
    }

    // Recursively retrieves all child records for a given parent
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
                // Recursively get nested child records
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

        // Check if the selected row is a parent and has not already been selected via child selection
        if (args.Data.HasChild && childRowIndexes.IndexOf(index) == -1 && selected_Inx.IndexOf(index) == -1)
        {
            // Retrieve all child records for the selected parent
            var children = GetChildren(args.Data);

            // Collect the row indexes of all child records
            foreach (var child in children)
            {
                childRowIndexes.Add(currentViewData.IndexOf(child));
            }

            // If Ctrl key is pressed, merge with existing selection; otherwise select only children
            if (args.IsCtrlPressed)
            {
                var selecting_Inx = selected_Inx.Concat(childRowIndexes).ToArray();
                var inx = selecting_Inx.OrderBy(item => item).ToArray();
                await TreeGrid.SelectRowsAsync(inx);
                selected_Inx.Clear();
            }
            else
            {
                await TreeGrid.SelectRowsAsync(childRowIndexes.ToArray());
                multiselect = true;
            }

            childRowIndexes.Clear();
        }
    }
}

{% endhighlight %}

{% highlight c# %}

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
        BusinessObjectCollection.Add(new BusinessObject() { TaskId = new Guid("284b28db-04b4-401d-9e90-10f911fda5fe"), TaskName = "Parent Task 2", Duration = 5, Progress = 70, Priority = "Critical", ParentId = null, HasChild = true });
        BusinessObjectCollection.Add(new BusinessObject() { TaskId = new Guid("284b28db-04b4-401d-9e90-10f911fda6fe"), TaskName = "Child task 1", Duration = 4, Progress = 80, Priority = "Critical", ParentId = new Guid("284b28db-04b4-401d-9e90-10f911fda5fe"), HasChild = false });
        BusinessObjectCollection.Add(new BusinessObject() { TaskId = new Guid("284b28db-04b4-401d-9e90-10f911fda9fe"), TaskName = "Child task 4", Duration = 2, Progress = 77, Priority = "Low", ParentId = new Guid("284b28db-04b4-401d-9e90-10f911fda5fe"), HasChild = false });
        BusinessObjectCollection.Add(new BusinessObject() { TaskId = new Guid("284b28db-04b4-401d-9e90-10f91fda10fe"), TaskName = "Parent Task 3", Duration = 5, Progress = 70, Priority = "Critical", ParentId = null, HasChild = true });
        BusinessObjectCollection.Add(new BusinessObject() { TaskId = new Guid("284b28db-04b4-401d-9e90-10f91fda11fe"), TaskName = "Child task 1", Duration = 4, Progress = 80, Priority = "Critical", ParentId = new Guid("284b28db-04b4-401d-9e90-10f91fda10fe"), HasChild = false });
        BusinessObjectCollection.Add(new BusinessObject() { TaskId = new Guid("284b28db-04b4-401d-9e90-10f91fda15fe"), TaskName = "Child task 4", Duration = 2, Progress = 77, Priority = "Low", ParentId = new Guid("284b28db-04b4-401d-9e90-10f91fda10fe"), HasChild = true });
        BusinessObjectCollection.Add(new BusinessObject() { TaskId = new Guid("284b28db-04b4-401d-9e90-10f91fda16fe"), TaskName = "Parent Task 3", Duration = 5, Progress = 70, Priority = "Critical", ParentId = new Guid("284b28db-04b4-401d-9e90-10f91fda15fe"), HasChild = true });
        BusinessObjectCollection.Add(new BusinessObject() { TaskId = new Guid("284b28db-04b4-401d-9e90-10f91fda17fe"), TaskName = "Child task 7", Duration = 4, Progress = 80, Priority = "Critical", ParentId = new Guid("284b28db-04b4-401d-9e90-10f91fda16fe"), HasChild = false });
        BusinessObjectCollection.Add(new BusinessObject() { TaskId = new Guid("284b28db-04b4-401d-9e90-10f91fda18fe"), TaskName = "Child task 8", Duration = 2, Progress = 77, Priority = "Low", ParentId = new Guid("284b28db-04b4-401d-9e90-10f91fda16fe"), HasChild = false });
        return BusinessObjectCollection;
    }
}

{% endhighlight %}

{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hjBdDzjiKPmVUGhn?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}
