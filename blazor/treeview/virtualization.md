---
layout: post
title: Virtualization in Blazor TreeView Component | Syncfusion
description: Checkout and learn here all about Virtualization in Syncfusion Blazor TreeView component and much more details.
platform: Blazor
control: TreeView
documentation: ug
---

# Virtualization in Blazor TreeView Component

The Blazor TreeView component supports UI virtualization to enhance performance when handling a large amount of data. This feature optimizes rendering by initially gathering all data but only rendering a subset of it (a specific number of items, N) during the initial load. The remaining items are then loaded dynamically as the user scrolls within the TreeView container.

To enable virtualization, set the [`EnableVirtualization`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfTreeView-1.html#Syncfusion_Blazor_Navigations_SfTreeView_1_EnableVirtualization) property to `true` and define a fixed [`Height`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfTreeView-1.html#Syncfusion_Blazor_Navigations_SfTreeView_1_Height) for the TreeView container.
The following sample shows the example of Virtualization.

```cshtml
@using Syncfusion.Blazor.Navigations

<SfTreeView TValue="TreeData" EnableVirtualization="true" Height="400">
    <TreeViewFieldsSettings DataSource="@TreeDataSource" Id="Id" ParentID="Pid" Text="Name" HasChildren="HasChild" Expanded="Expanded"></TreeViewFieldsSettings>
</SfTreeView>

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
        for (int i = 1; i <= 5; i++)
        {
            List<TreeData> TreeViewData = Enumerable.Range(0, 5000)
            .Select(j =>
            {
                count++;
                return new TreeData { Id = i.ToString() + "-" + j.ToString(), Name = DefaultData[j % DefaultData.Count].Name + " - " + count.ToString(), Pid = i.ToString() };
            }).ToList();
            TreeDataSource.AddRange(TreeViewData);
        }
    }
    class TreeData
    {
        public string? Id { get; set; }
        public string? Pid { get; set; }
        public bool HasChild { get; set; }
        public bool Expanded { get; set; }
        public string? Name { get; set; }
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/LXVSCNsUVVQcEAYN?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor TreeView with Virtualization](./images/virtualization.gif)

N> Virtualization is not compatible with expand and collapse animation. Select all action will select only visible items in UI.