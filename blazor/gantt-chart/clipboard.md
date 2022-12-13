---
layout: post
title: Clipboard in Blazor Gantt Chart Component | Syncfusion
description: Checkout and learn here all about clipboard in Syncfusion Blazor Gantt Chart component and much more details.
platform: Blazor
control: Gantt Chart
documentation: ug
---

# Clipboard in Blazor Gantt Chart Component

The clipboard provides an option to copy selected rows or cells data into the clipboard.

The following list of keyboard shortcuts is supported in the Gantt Chart to copy selected rows or cells data into the clipboard.

Interaction keys |Description
-----|-----
<kbd>Ctrl + C</kbd> |Copy selected rows or cells data into clipboard.
<kbd>Ctrl + Shift + H</kbd> |Copy selected rows or cells data with header into clipboard.

```cshtml

@using Syncfusion.Blazor.Gantt

<SfGantt DataSource="@TaskCollection" Height="450px" Width="1000px">
    <GanttTaskFields Id="TaskId" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" Dependency="Predecessor" ParentID="ParentId">
    </GanttTaskFields>
</SfGantt>

@code{
    private List<TaskData> TaskCollection { get; set; }
    protected override void OnInitialized()
    {
        this.TaskCollection = GetTaskCollection();
    }

    public class TaskData
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Duration { get; set; }
        public int Progress { get; set; }
        public string Predecessor { get; set; }
        public int? ParentId { get; set; }
    }

    public static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>()
        {
            new TaskData() { TaskId = 1, TaskName = "Project initiation", StartDate = new DateTime(2019, 04, 05), EndDate = new DateTime(2019, 04, 21), },
            new TaskData() { TaskId = 2, TaskName = "Identify Site location", StartDate = new DateTime(2019, 04, 05), Duration = "0", Progress = 30, ParentId = 1 },
            new TaskData() { TaskId = 3, TaskName = "Perform soil test", StartDate = new DateTime(2019, 04, 05), Duration = "4", Progress = 40, Predecessor = "2", ParentId = 1 },
            new TaskData() { TaskId = 4, TaskName = "Soil test approval", StartDate = new DateTime(2019, 04, 05), Duration = "0", Progress = 30, Predecessor = "3", ParentId = 1 },
            new TaskData() { TaskId = 5, TaskName = "Project estimation", StartDate = new DateTime(2019, 04, 06), EndDate = new DateTime(2019, 04, 21) },
            new TaskData() { TaskId = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2019, 04, 06), Duration = "3", Progress = 30, Predecessor = "4" , ParentId = 5 },
            new TaskData() { TaskId = 7, TaskName = "List materials", StartDate = new DateTime(2019, 04, 06), Duration = "3", Progress = 40, Predecessor = "6" , ParentId = 5 },
            new TaskData() { TaskId = 8, TaskName = "Estimation approval", StartDate = new DateTime(2019, 04, 06), Duration = "0", Progress = 30, Predecessor = "7" , ParentId = 5 },
        };
        return Tasks;
    }
}
```

## Copy to clipboard by external buttons

To copy the data of the selected rows or cells into the clipboard with the help of external buttons, invoke the [CopyAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_CopyAsync) method.

```cshtml

@using Syncfusion.Blazor.Gantt
@using Syncfusion.Blazor.Navigations
<SfGantt DataSource="@TaskCollection" @ref="GanttObject" Height="450px" Width="1000px">
    <GanttTaskFields Id="TaskId" Name="TaskName" StartDate="StartDate" EndDate="EndDate"      Duration="Duration" Progress="Progress" Dependency="Predecessor" ParentID="ParentId">
    </GanttTaskFields>
    <SfToolbar ID="Gantt_Gantt_Toolbar">
        <ToolbarItems>
            <ToolbarItem Id="copyHeader" Text="Copy With Header" OnClick="ToolbarClick" PrefixIcon="e-copy"></ToolbarItem>
            <ToolbarItem Id="copy" Text="Copy" OnClick="ToolbarClick" PrefixIcon="e-copy"></ToolbarItem>
        </ToolbarItems>
    </SfToolbar>
</SfGantt>
@code{
    private List<TaskData> TaskCollection { get; set; }
    private SfGantt<TaskData> GanttObject;
    protected override void OnInitialized()
    {
        this.TaskCollection = GetTaskCollection();
    }

    public async void ToolbarClick(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
        var SelectedRecords = await this.GanttObject.GetSelectedRecordsAsync();
        if (SelectedRecords.Count() > 0)
        {
            var WithHeader = false;
            if (args.Item.Id == "copyHeader")
            {
                WithHeader = true;
            }
            await this.GanttObject.CopyAsync(WithHeader);
        }
    }
    public class TaskData
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Duration { get; set; }
        public int Progress { get; set; }
        public string Predecessor { get; set; }
        public int? ParentId { get; set; }
    }

    public static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>()
        {
            new TaskData() { TaskId = 1, TaskName = "Project initiation", StartDate = new DateTime(2019, 04, 05), EndDate = new DateTime(2019, 04, 21), },
            new TaskData() { TaskId = 2, TaskName = "Identify Site location", StartDate = new DateTime(2019, 04, 05), Duration = "0", Progress = 30, ParentId = 1 },
            new TaskData() { TaskId = 3, TaskName = "Perform soil test", StartDate = new DateTime(2019, 04, 05), Duration = "4", Progress = 40, Predecessor = "2", ParentId = 1 },
            new TaskData() { TaskId = 4, TaskName = "Soil test approval", StartDate = new DateTime(2019, 04, 05), Duration = "0", Progress = 30, Predecessor = "3", ParentId = 1 },
            new TaskData() { TaskId = 5, TaskName = "Project estimation", StartDate = new DateTime(2019, 04, 06), EndDate = new DateTime(2019, 04, 21) },
            new TaskData() { TaskId = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2019, 04, 06), Duration = "3", Progress = 30, Predecessor = "4" , ParentId = 5 },
            new TaskData() { TaskId = 7, TaskName = "List materials", StartDate = new DateTime(2019, 04, 06), Duration = "3", Progress = 40, Predecessor = "6" , ParentId = 5 },
            new TaskData() { TaskId = 8, TaskName = "Estimation approval", StartDate = new DateTime(2019, 04, 06), Duration = "0", Progress = 30, Predecessor = "7" , ParentId = 5 },
        };
        return Tasks;
    }
}
```

## Copy Hierarchy Modes

Gantt Chart provides support for a set of copy modes with [CopyHierarchyMode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.CopyHierarchyType.html) property. The below are the type of filter mode available in the Tree Grid.

* **Parent** : This is the default copy hierarchy mode in the Tree Grid. Clipboard value will have the selected records with its parent records, if the selected records does not have any parent record then the selected record will be in clipboard.

* **Child** : Clipboard value will have the selected records with its child record. If the selected records do not have any child record then the selected records will be in clipboard.

* **Both** : Clipboard value will have the selected records with its both parent and child record. If the selected records do not have any parent and child record then the selected records alone are copied to the clipboard.

* **None** : Only the selected records will be in the clipboard.

{% tabs %}

{% highlight razor %}

@using TreeGridComponent.Data;
@using Syncfusion.Blazor.TreeGrid;
@using Syncfusion.Blazor.DropDowns;

<SfDropDownList TValue="string" TItem="DropdownData" @bind-Value="@CopyMode" DataSource="@CopyModes">
    <DropDownListEvents TValue="string" ValueChange="OnTypeChange"></DropDownListEvents>
    <DropDownListFieldSettings Text="Mode" Value="Id"></DropDownListFieldSettings>
</SfDropDownList>
        
<SfTreeGrids @ref="TreeGrid" CopyHierarchyMode="@CopyType" DataSource="@TreeData" IdMapping="TaskID" ParentIdMapping="ParentID" TreeColumnIndex="1">
    <TreeGridColumns>
        <TreeGridColumn Field="TaskID" HeaderText="Task ID" Width="60" TextAlign="TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="TaskName" HeaderText="Task Name" Width="80"></TreeGridColumn>
        <TreeGridColumn Field="StartDate" HeaderText="Start Date" Format="d" Type=ColumnType.Date Width="90" TextAlign="TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="Duration" HeaderText="Duration" Width="80" TextAlign="TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="Progress" HeaderText="Progress" Width="80"></TreeGridColumn>
    </TreeGridColumns>
</SfTreeGrids>

@code {    

    SfTreeGrids<BusinessObject> TreeGrid;

    public string CopyMode { get; set; } = "Parent";

    public CopyHierarchyType CopyType { get; set; } = CopyHierarchyType.Parent;

    public List<BusinessObject> TreeData { get; set; }

    public List<DropdownData> CopyModes { get; set; } = new List<DropdownData>();

    public class DropdownData
    {
        public string Id { get; set; }

        public string Mode { get; set; }
    }

    protected override void OnInitialized()
    {
        this.TreeData = BusinessObject.GetSelfDataSource().ToList();

        this.CopyModes.Add(new DropdownData() { Id = "Parent", Mode = "Parent" });
        this.CopyModes.Add(new DropdownData() { Id = "Child", Mode = "Child" });
        this.CopyModes.Add(new DropdownData() { Id = "Both", Mode = "Both" });
        this.CopyModes.Add(new DropdownData() { Id = "None", Mode = "None" });
    }

    private async void OnTypeChange(Syncfusion.Blazor.DropDowns.ChangeEventArgs<string, DropdownData> Args)
    {
        if (Args.Value == "Parent")
        {
            CopyType = CopyHierarchyType.Parent;
        }
        else if (Args.Value == "Child")
        {
            CopyType = CopyHierarchyType.Child;
        }
        else if (Args.Value == "Both")
        {
            CopyType = CopyHierarchyType.Both;
        }
        else if(Args.Value == "None")
        {
            CopyType = CopyHierarchyType.None;
        }
    }

}

{% endhighlight %}

{% highlight c# %}

namespace TreeGridComponent.Data {
        public class BusinessObject
        {
            public int TaskId { get; set;}
            public string TaskName { get; set;}
            public DateTime? StartDate { get; set;}
            public int? Duration { get; set;}
            public int? Progress { get; set;}
            public string Priority { get; set;}
            public int? ParentId { get; set;}

        public static List<BusinessObject> GetSelfDataSource()
        {
            List<BusinessObject> BusinessObjectCollection = new List<BusinessObject>();
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 1,TaskName = "Parent Task 1",StartDate = new DateTime(2017, 10, 23),Duration = 10,Progress = 70,Priority = "Critical",ParentId = null });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 2,TaskName = "Child task 1",StartDate = new DateTime(2017, 10, 23),Duration = 12,Progress = 80,Priority = "Low",ParentId = 1 });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 3,TaskName = "Child Task 2",StartDate = new DateTime(2017, 10, 24),Duration = 5,Progress = 65,Priority = "Critical",ParentId = 2 });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 4,TaskName = "Child task 3",StartDate = new DateTime(2017, 10, 25),Duration = 6,Priority = "High",Progress = 77,ParentId = 3 });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 5, TaskName = "Child Task 5",StartDate = new DateTime(2017, 10, 26), Duration = 9, Progress = 25, ParentId = 4, Priority = "Normal" });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 6, TaskName = "Child Task 6",StartDate = new DateTime(2017, 10, 27), Duration = 9, Progress = 7, ParentId = 5, Priority = "Normal" });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 7, TaskName = "Parent Task 3",StartDate = new DateTime(2017, 10, 28), Duration = 4, Progress = 45, ParentId = null, Priority = "High" });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 8, TaskName = "Child Task 7",StartDate = new DateTime(2017, 10, 29), Duration = 3, Progress = 38, ParentId = 7, Priority = "Critical" });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 9, TaskName = "Child Task 8",StartDate = new DateTime(2017, 10, 30), Duration = 7, Progress = 70, ParentId = 7, Priority = "Low" });
            return BusinessObjectCollection;
        }
    }

}

{% endhighlight %}

{% endtabs %}

