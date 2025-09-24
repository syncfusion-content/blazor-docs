---
layout: post
title: Custom Toolbar with Drop-Down List in Blazor TreeGrid | Syncfusion.
description: Learn how to create a custom toolbar with a drop-down list in the Syncfusion Blazor TreeGrid component and more.
platform: Blazor
control: TreeGrid
documentation: ug
---

# Create Custom Toolbar with Drop-Down List in Blazor TreeGrid Component

Custom toolbar items can be added to the TreeGrid using the [Toolbar](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_Toolbar) property. Actions for these toolbar template items can be defined using the `ToolbarClick` event.

**Step 1**:
I
nitialize the template for the custom component. The following code adds a `DropDownList` component to the ToolBar.

```cshtml
<SfToolbar>
    <ToolbarItems>
        <ToolbarItem Type="ItemType.Input">
            <Template>
                <SfDropDownList TValue="string" TItem="Select" DataSource=@LocalData Width="200">
                    <DropDownListFieldSettings Text="text" Value="text"> </DropDownListFieldSettings>
                    <DropDownListEvents TValue="string" ValueChange="OnChange" TItem="Select"> </DropDownListEvents>
                </SfDropDownList>
            </Template>
        </ToolbarItem>
    </ToolbarItems>
</SfToolbar>
```

**Step 2**:

To render the `DropDownList` component, use the [DropDownListEvents](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.DropDownListEvents-2.html). The TreeGrid row index can be selected based on the selected value in the Drop-Down List.

{% tabs %}

{% highlight razor %}

@using TreeGridComponent.Data;
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.DropDowns

<SfTreeGrid @ref="TreeGrid" DataSource="@TreeGridData" AllowPaging="true"
            IdMapping="TaskId" ParentIdMapping="ParentId" TreeColumnIndex="1" Height="200">
    <SfToolbar>
        <ToolbarItems>
            <ToolbarItem Type="ItemType.Input">
                <Template>
                    <SfDropDownList TValue="string" TItem="Select" DataSource=@LocalData Width="200">
                        <DropDownListFieldSettings Text="text" Value="text"> </DropDownListFieldSettings>
                        <DropDownListEvents TValue="string" ValueChange="OnChange" TItem="Select"> </DropDownListEvents>
                    </SfDropDownList>
                </Template>
            </ToolbarItem>
        </ToolbarItems>
    </SfToolbar>
    <TreeGridColumns>
        <TreeGridColumn Field="TaskId" HeaderText="Task ID" IsPrimaryKey="true" Width="80" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="TaskName" HeaderText="Task Name" Width="160"></TreeGridColumn>
        <TreeGridColumn Field="Duration" HeaderText="Duration" Width="100" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="Progress" HeaderText="Progress" Width="100" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="Priority" HeaderText="Priority" Width="80"></TreeGridColumn>
    </TreeGridColumns>
</SfTreeGrid>

@code{
    SfTreeGrid<TreeData> TreeGrid;

    public List<TreeData> TreeGridData { get; set; }

    public class Select
    {
        public string text { get; set; }
    }
    List<Select> LocalData = new List<Select>
    {
            new Select() { text = "0"},
            new Select() { text = "1"},
            new Select() { text = "2"},
            new Select() { text = "3"},
            new Select() { text = "4"},
            new Select() { text = "5"},
            new Select() { text = "6"},
            new Select() { text = "7"},
            new Select() { text = "8"},
            new Select() { text = "9"},
    };
    protected override void OnInitialized()
    {
        this.TreeGridData = TreeData.GetSelfDataSource().ToList();
    }
    public void OnChange(Syncfusion.Blazor.DropDowns.ChangeEventArgs<string, Select> args)
    {
        this.TreeGrid.SelectRowAsync(int.Parse(args.Value));
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

![Creating Custom Toolbar with DropDownList in Blazor TreeGrid](../images/blazor-treegrid-custom-toolbar-with-dropdownlist.PNG)
