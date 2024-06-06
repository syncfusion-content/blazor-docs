---
layout: post
title: Virtualization in Blazor TreeView Component | Syncfusion
description: Checkout and learn here all about Virtualization in Syncfusion Blazor TreeView component and much more details.
platform: Blazor
control: TreeView
documentation: ug
---

# Virtualization in Blazor TreeView Component

The TreeView has been provided virtualization support to improve the UI performance for a large amount of data when [EnableVirtualization](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfTreeView-1.html#Syncfusion_Blazor_Navigations_SfTreeView_1_EnableVirtualization) is true. This feature doesn’t render out the entire data source on initial rendering. It loads the N number of items in the initial rendering and the remaining set number of items will load on each scrolling action in the TreeView container. To setup the virtualization, define the [EnableVirtualization](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfTreeView-1.html#Syncfusion_Blazor_Navigations_SfTreeView_1_EnableVirtualization) as true and content height by [Height](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfTreeView-1.html#Syncfusion_Blazor_Navigations_SfTreeView_1_Height) property.

The following sample shows the example of Virtualization.

```cshtml

@using Syncfusion.Blazor.Navigations
<div class="control-section"> 
    <div class="control_wrapper">
        @*Initialize the TreeView component*@
        <SfTreeView TValue="TreeData" EnableVirtualization="true" Height="400">
            <TreeViewFieldsSettings DataSource="@TreeDataSource" Id="Id" ParentID="Pid" Text="Name" HasChildren="HasChild" Expanded="Expanded"></TreeViewFieldsSettings>
        </SfTreeView>
    </div>
</div>
@code {
    // Specifies the DataSource value for TreeView component.
    List<TreeData> TreeDataSource = new List<TreeData>()
    {
        new TreeData() { Id = "1", Name = "Software Developers", HasChild = true, Expanded = true },
        new TreeData() { Id = "2", Name = "UX/UI Designers", HasChild = true, Expanded = false },
        new TreeData() { Id = "3", Name = "Quality Testers", HasChild = true, Expanded = false },
        new TreeData() { Id = "4", Name = "Technical Support", HasChild = true, Expanded = false },
        new TreeData() { Id = "5", Name = "Network Engineers", HasChild = true, Expanded = false }
    };
    List<TreeData> DefaultData = new List<TreeData>()
    {
        new TreeData() { Name = "Nancy" },
        new TreeData() { Name = "Andrew" },
        new TreeData() { Name = "Janet" },
        new TreeData() { Name = "Margaret" },
        new TreeData() { Name = "Steven" },
        new TreeData() { Name = "Laura" },
        new TreeData() { Name = "Robert" },
        new TreeData() { Name = "Michael" },
        new TreeData() { Name = "Albert" },
        new TreeData() { Name = "Nolan" },
        new TreeData() { Name = "Jennifer" },
        new TreeData() { Name = "Carter" },
        new TreeData() { Name = "Allison" },
        new TreeData() { Name = "John" },
        new TreeData() { Name = "Susan" },
        new TreeData() { Name = "Lydia" },
        new TreeData() { Name = "Kelsey" },
        new TreeData() { Name = "Jessica" },
        new TreeData() { Name = "Shelley" },
        new TreeData() { Name = "Jack" }
    };
    int count = 10005;
    protected override void OnInitialized()
    {
        base.OnInitialized();
        List<TreeData> tempData1 = TreeDataSource?.ToList();
        for (int i = 1; i <= TreeDataSource.Count; i++)
        {
            List<TreeData> tempData = Enumerable.Range(0, 5000)
            .Select(j =>
            {
                count++;
                return new TreeData { Id = i.ToString() + "-" + j.ToString(), Name = DefaultData[j % DefaultData.Count].Name + " - " + count.ToString(), Pid = i.ToString() };
            }).ToList();
            tempData1.AddRange(tempData);
        }
        TreeDataSource = tempData1.ToList();
    }
    class TreeData
    {
        public string Id { get; set; }
        public string Pid { get; set; }
        public bool HasChild { get; set; }
        public bool Expanded { get; set; }
        public string Name { get; set; }
    }
    class MenuItems
    {
        public string ID { get; set; }
        public string Text { get; set; }
    }
}
<style>
    /* Sample specific styles */
    .control_wrapper {
        max-width: 500px;
        margin: auto;
        border: 1px solid #dddddd;
        border-radius: 3px;
        max-height: 420px;
    }
</style>
```

![Blazor TreeView with virtualization](./images/virtualization.gif)

## Limitations for Virtualization

* Virtualization is not compatible with expand and collapse animation.
* Select all action will select only visible items in UI.