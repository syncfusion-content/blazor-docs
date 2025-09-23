---
layout: post
title: Custom control in Blazor TreeGrid Toolbar
description: Learn how to integrate custom controls like Autocomplete into the Tree Grid toolbar in Syncfusion Blazor TreeGrid component.
platform: Blazor
control: TreeGrid
documentation: ug
---

# Custom control in TreeGrid toolbar in Blazor TreeGrid Component

You can integrate custom controls within the toolbar area of the Tree Grid component. This is accomplished by initializing the desired control inside the `Template` property of the `Toolbar` component, which is nested within the TreeGrid.

The following example demonstrates how to render an `SfAutoComplete` control inside the TreeGrid's toolbar to enable search functionality.

{% tabs %}

{% highlight razor %}

@using TreeGridComponent.Data;
@using Syncfusion.Blazor.Grids;
@using Syncfusion.Blazor.TreeGrid;
@using Syncfusion.Blazor.DropDowns;
@using Syncfusion.Blazor.Navigations;


<SfTreeGrid @ref="TreeGrid" DataSource="@TreeGridData" IdMapping="TaskId" ParentIdMapping="ParentId"
       TreeColumnIndex="1" AllowPaging="true">
        <TreeGridPageSettings PageSize="8"></TreeGridPageSettings>
        <SfToolbar>
            <ToolbarItems>
                <ToolbarItem Type="ItemType.Input">
                    <Template>
                        <SfAutoComplete Placeholder="Search Task Name" TItem="TaskDetails" TValue="string" DataSource="@TaskNames">
                            <AutoCompleteEvents ValueChange="OnSearch" TValue="string" TItem="TaskDetails"></AutoCompleteEvents>
                            <AutoCompleteFieldSettings Value="Name"></AutoCompleteFieldSettings>
                        </SfAutoComplete>
                    </Template>
                </ToolbarItem>
            </ToolbarItems>
        </SfToolbar>
        <TreeGridColumns>
            <TreeGridColumn Field="TaskId" HeaderText="Task ID" IsPrimaryKey="true" Width="70" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
            <TreeGridColumn Field="TaskName" HeaderText="Task Name" Width="85">
            </TreeGridColumn>
            <TreeGridColumn Field="Priority" HeaderText="Priority" Width="70">
            </TreeGridColumn>
            <TreeGridColumn Field="Duration" HeaderText="Duration" Width="70" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right">
            </TreeGridColumn>
            <TreeGridColumn Field="Progress" HeaderText="Progress" Width="70" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
        </TreeGridColumns>
    </SfTreeGrid>

    @code{
        SfTreeGrid<TreeData> TreeGrid;

        public List<TreeData> TreeGridData { get; set; }

        public class TaskDetails
        {
            public string Name { get; set; }

            public int Id { get; set; }
        }

        List<TaskDetails> TaskNames = new List<TaskDetails>
        {
            new TaskDetails() { Name = "Parent Task 1", Id = 1 },
            new TaskDetails() { Name = "Parent Task 2", Id = 2 },
            new TaskDetails() { Name = "Child task 1", Id = 3 },
            new TaskDetails() { Name = "Child Task 2", Id = 4 },
            new TaskDetails() { Name = "Child task 3", Id = 5 },
            new TaskDetails() { Name = "Child task 4", Id = 6 }
        };
        protected override void OnInitialized()
        {
            this.TreeGridData = TreeData.GetSelfDataSource().ToList();
        }
        public void OnSearch(Syncfusion.Blazor.DropDowns.ChangeEventArgs<string, TaskDetails> args)
        {
            this.TreeGrid.SearchAsync(args.Value);
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
}

{% endhighlight %}

{% endtabs %}

![Custom Control in Blazor TreeGrid Toolbar](../images/blazor-treegrid-custom-control-in-toolbar.gif)