---
layout: post
title: Clipboard in Blazor TreeGrid Component | Syncfusion
description: Checkout and learn here all about clipboard in Syncfusion Blazor TreeGrid component and much more details.
platform: Blazor
control: Tree Grid
documentation: ug
---

# Clipboard in Blazor TreeGrid Component

The clipboard provides an option to copy selected rows or cells data into the clipboard.

The following list of keyboard shortcuts is supported in the Tree Grid to copy selected rows or cells data into the clipboard.

Interaction keys |Description
-----|-----
<kbd>Ctrl + C</kbd> |Copy selected rows or cells data into clipboard.
<kbd>Ctrl + Shift + H</kbd> |Copy selected rows or cells data with header into clipboard.

{% tabs %}

{% highlight razor %}

@using TreeGridComponent.Data;
@using Syncfusion.Blazor.TreeGrid;

<SfTreeGrids DataSource="@TreeData" IdMapping="TaskID" ParentIdMapping="ParentID" TreeColumnIndex="1">
    <TreeGridColumns>
        <TreeGridColumn Field="TaskID" HeaderText="Task ID" Width="60" TextAlign="TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="TaskName" HeaderText="Task Name" Width="80"></TreeGridColumn>
        <TreeGridColumn Field="StartDate" HeaderText="Start Date" Format="d" Type=ColumnType.Date Width="90" TextAlign="TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="Duration" HeaderText="Duration" Width="80" TextAlign="TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="Progress" HeaderText="Progress" Width="80"></TreeGridColumn>
    </TreeGridColumns>
</SfTreeGrids>

@code {
    
    public List<BusinessObject> TreeData { get; set; }
    protected override void OnInitialized()
    {
        this.TreeGridData = BusinessObject.GetSelfDataSource().ToList();
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

## Copy to clipboard by external buttons

To copy the data of the selected rows or cells into the clipboard with help of external buttons, invoke the `copy` method.

{% tabs %}

{% highlight razor %}

@using TreeGridComponent.Data;
@using Syncfusion.Blazor.TreeGrid;
@using Syncfusion.Blazor.Buttons;

<SfButton OnClick="Copy">Copy</SfButton>

<SfButton OnClick="CopyHeader">Copy With Header</SfButton>

<SfTreeGrid @ref="TreeGrid" DataSource="@TreeGridData" IdMapping="TaskId" ParentIdMapping="ParentId" TreeColumnIndex="1" AllowTextWrap="true">
    <TreeGridColumns>
        <TreeGridColumn Field="TaskId" HeaderText="Task ID" Width="80" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="TaskName" HeaderText="Task Name" Width="100"></TreeGridColumn>
        <TreeGridColumn Field="StartDate" HeaderText="Start Date" Format="yMd" Type="Syncfusion.Blazor.Grids.ColumnType.Date" Width="100" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="Duration" HeaderText="Duration" Width="100" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="Progress" HeaderText="Progress" Width="100" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="Priority" HeaderText="Priority" Width="100"></TreeGridColumn>
    </TreeGridColumns>
</SfTreeGrid>

@code {
    
    SfTreeGrid<BusinessObject> TreeGrid;
    public List<BusinessObject> TreeData { get; set; }
    protected override void OnInitialized()
    {
        this.TreeGridData = BusinessObject.GetSelfDataSource().ToList();
    }

    public async void Copy()
    {
        await this.TreeGrid.Copy();
    }

    public async void CopyHeader()
    {
        await this.TreeGrid.Copy(true);
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

## Copy Hierarchy Modes

Tree Grid provides support for a set of copy modes with `CopyHierarchyMode` property. The below are the type of filter mode available in the Tree Grid.

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

    private async void OnTypeChange(Syncfusion.Blazor.DropDowns.ChangeEventArgs<string> Args)
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
