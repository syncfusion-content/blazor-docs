---
layout: post
title: How to Custom Control In Treegrid Toolbar in Blazor Tree Grid Component | Syncfusion
description: Checkout and learn about Custom Control In Treegrid Toolbar in Blazor Tree Grid component of Syncfusion, and more details.
platform: Blazor
control: Tree Grid
documentation: ug
---

# Custom control in Tree Grid toolbar

You can render custom controls inside the Tree Grid's toolbar area. This can be achieved by initializing the custom controls within the Template property of the Toolbar component. This toolbar component is defined inside the Tree Grid component.

This is demonstrated in the below sample code where Autocomplete component is rendered inside the Tree Grid's toolbar and is used for performing search operation on the Tree Grid,

```csharp

@using TreeGridComponent.Data;
@using  Syncfusion.Blazor.Grids;
@using  Syncfusion.Blazor.TreeGrid;
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
            this.TreeGrid.Search(args.Value);
        }
    }

```

The following GIF represents the search operation performed on the Tree Grid using the Autocomplete component rendered in the toolbar,

![Custom control in toolbar](../images/custom-control-toolbar.gif)