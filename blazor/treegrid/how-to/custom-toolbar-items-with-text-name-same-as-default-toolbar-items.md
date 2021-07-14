---
layout: post
title: How to Custom Toolbar Items With Text Name Same As Default Toolbar Items in Blazor Tree Grid Component | Syncfusion
description: Checkout and learn about Custom Toolbar Items With Text Name Same As Default Toolbar Items in Blazor Tree Grid component of Syncfusion, and more details.
platform: Blazor
control: Tree Grid
documentation: ug
---

# Custom toolbar items with text name same as default toolbar items

You can create the Custom toolbar items with text name same as default toolbar items (Add,Edit,Delete,etc.). But while creating them, they will be considered as default toolbar items which will cause some issues while clicking on it. To overcome this behavior, we suggest you to define the **Id** property for custom toolbar items.

This is demonstrated in the below sample code where we have custom toolbar items with text same as **Add** and **Delete** buttons. These toolbar buttons will be enabled only when TreeGridEditSettings is defined in TreeGrid. So custom toolbar will be disabled state considering it as default toolbar item. We have overcome that behaviour by defining the Id property.

```csharp

@using TreeGridComponent.Data;
@using  Syncfusion.Blazor.Grids;
@using  Syncfusion.Blazor.TreeGrid;

@{
    List<Syncfusion.Blazor.Navigations.ItemModel> Toolbaritems = new List<Syncfusion.Blazor.Navigations.ItemModel>();
    Toolbaritems.Add(new Syncfusion.Blazor.Navigations.ItemModel() { Text = "Add", Id = "add", TooltipText = "Add Record", PrefixIcon = "add" });
    Toolbaritems.Add(new Syncfusion.Blazor.Navigations.ItemModel() { Text = "Delete", Id = "delete", TooltipText = "Delete Record", PrefixIcon = "delete" });
}
<SfTreeGrid DataSource="@TreeGridData" IdMapping="TaskId" ParentIdMapping="ParentId" AllowPaging="true"
            TreeColumnIndex="1" Toolbar="Toolbaritems">
    <TreeGridEvents OnToolbarClick="ToolbarClickHandler" TValue="TreeData"></TreeGridEvents>
    <TreeGridColumns>
        <TreeGridColumn Field="TaskId" HeaderText="Task ID" IsPrimaryKey="true" Width="70" TextAlign="TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="TaskName" HeaderText="Task Name" Width="85"></TreeGridColumn>
        <TreeGridColumn Field="Resources" HeaderText="Resource" Width="70" TextAlign="TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="Duration" HeaderText="Duation" Width="70" TextAlign="TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="Progress" HeaderText="Progress" Width="70" TextAlign="TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="Priority" HeaderText="Priority" Width="70"></TreeGridColumn>
    </TreeGridColumns>
</SfTreeGrid>

@code{
    SfTreeGrid<TreeData> TreeGrid;

    public List<TreeData> TreeGridData { get; set; }
    protected override void OnInitialized()
    {
        this.TreeGridData = TreeData.GetSelfDataSource().ToList();
    }
    public void ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
        if (args.Item.Text == "Add")
        {
            //perform your actions here
        }
        if (args.Item.Text == "Delete")
        {
            //perform your actions here
        }
    }
}

```

Output be like the below.

![`Final output`](../images/custom-toolbar-text.PNG)