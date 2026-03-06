---
layout: post
title: Custom toolbar with drop-down list in Blazor TreeGrid | Syncfusion
description: Learn here all about how to create custom toolbar with drop-down list in Syncfusion Blazor TreeGrid component and more.
platform: Blazor
control: Tree Grid
documentation: ug
---

# Create custom toolbar with drop-down list in Blazor TreeGrid Component

Custom toolbar items can be added to the Tree Grid by defining the [Template](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.ToolbarItem.html#Syncfusion_Blazor_Navigations_ToolbarItem_Template) within a [<SfToolbar>](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfToolbar.html). This allows embedding components directly into the toolbar.

**Step 1**:

Initialize the template for the custom component. Using the following code add the [DropDownList](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html) component to the ToolBar.

```cshtml
 <SfToolbar>
     <ToolbarItems>
         <ToolbarItem Type="ItemType.Input">
             <Template>
                 <SfDropDownList TValue="string" TItem="SelectOption" DataSource=@LocalData Width="200">
                     <DropDownListFieldSettings Text="Text" Value="Text"> </DropDownListFieldSettings>
                     <DropDownListEvents TValue="string" ValueChange="OnChange" TItem="SelectOption"> </DropDownListEvents>
                 </SfDropDownList>
             </Template>
         </ToolbarItem>  
     </ToolbarItems>
 </SfToolbar>
```

**Step 2**:

The Tree Grid row index can be selected based on the selected data in the DropDownList and pass values using the [DropDownListEvents](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.DropDownListEvents-2.html).

{% tabs %}

{% highlight razor %}

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.TreeGrid
@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.DropDowns

<SfTreeGrid @ref="TreeGrid" DataSource="@TreeGridData" AllowPaging="true"
            IdMapping="TaskId" ParentIdMapping="ParentId" TreeColumnIndex="1" Height="200">
    <SfToolbar>
        <ToolbarItems>
            <ToolbarItem Type="ItemType.Input">
                <Template>
                    <SfDropDownList TValue="string" TItem="SelectOption" DataSource=@LocalData Width="200">
                        <DropDownListFieldSettings Text="Text" Value="Text"> </DropDownListFieldSettings>
                        <DropDownListEvents TValue="string" ValueChange="OnChange" TItem="SelectOption"> </DropDownListEvents>
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

    public class SelectOption
    {
        public string Text { get; set; }
    }
    List<SelectOption> LocalData = new List<SelectOption>
    {
            new SelectOption() { Text = "0"},
            new SelectOption() { Text = "1"},
            new SelectOption() { Text = "2"},
            new SelectOption() { Text = "3"},
            new SelectOption() { Text = "4"},
            new SelectOption() { Text = "5"},
            new SelectOption() { Text = "6"},
            new SelectOption() { Text = "7"},
            new SelectOption() { Text = "8"},
            new SelectOption() { Text = "9"},
    };
    protected override void OnInitialized()
    {
        this.TreeGridData = TreeData.GetSelfDataSource().ToList();
    }
    public void OnChange(Syncfusion.Blazor.DropDowns.ChangeEventArgs<string, SelectOption> args)
    {   
        // Selects the Tree Grid row based on the Row Index selected in the DropDownList
        this.TreeGrid.SelectRowAsync(int.Parse(args.Value));
    }
}

{% endhighlight %}

{% highlight c# %}

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

{% endhighlight %}

{% endtabs %}

![Creating Custom Toolbar with DropDownList in Blazor TreeGrid](../images/blazor-treegrid-custom-toolbar-with-dropdownlist.PNG)
