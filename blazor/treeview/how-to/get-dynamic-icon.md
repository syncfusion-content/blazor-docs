---
layout: post
title: Get iconCss dynamically in Blazor TreeView Component | Syncfusion
description: Learn here all about how to get iconCss dynamically in TreeView in Syncfusion Blazor TreeView component and more.
platform: Blazor
control: TreeView
documentation: ug
---

# Get iconCss dynamically in Blazor TreeView Component

In the TreeView component, get the original bound data using the [`GetTreeData`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfTreeView-1.html#Syncfusion_Blazor_Navigations_SfTreeView_1_GetTreeData_System_String_) method. For this method, if the id of the tree node is passed, it returns the corresponding node information, or otherwise the overall tree nodes information will be returned. This method can be used to get the bound IconCss class in the [`NodeChecking`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.TreeViewEvents-1.html#Syncfusion_Blazor_Navigations_TreeViewEvents_1_NodeChecking) event.

```csharp

@using Syncfusion.Blazor.Navigations

<SfTreeView TValue="TreeItem" SortOrder="@Syncfusion.Blazor.Navigations.SortOrder.Ascending" ShowCheckBox="true" AutoCheck="false" @ref="tree">
    <TreeViewEvents TValue="TreeItem" NodeChecking="BeforeCheck"></TreeViewEvents>
    <TreeViewFieldsSettings DataSource="@TreeDataSource" Id="NodeId" Text="NodeText" Expanded="Expanded" Child="Child" IconCss="Icon"></TreeViewFieldsSettings>
</SfTreeView>
@if (SelectedIcon != null)
{
    @SelectedIcon;
}


@code{
    SfTreeView<TreeItem> tree;
    List<TreeItem> TreeDataSource = new List<TreeItem>();
    string SelectedIcon = null;
    string SelectedID = null;

    async void BeforeCheck(NodeCheckEventArgs args)
    {
        if (args.Action == "check")
        {
            SelectedID = args.NodeData.Id;
            List<TreeItem> IconData = this.tree.GetTreeData(SelectedID);
            SelectedIcon = $"Icon class is: {IconData[0].Icon}";
            StateHasChanged();
        }
    }
    protected override void OnInitialized()
    {
        base.OnInitialized();
        TreeDataSource.Add(new TreeItem
        {
            NodeId = "01",
            NodeText = "Music",
            Icon = "folder",
            Child = new List<TreeItem>()
            {
                new TreeItem { NodeId = "01-01", NodeText = "Gouttes.mp3", Icon = "audio" }
            },
        });
        TreeDataSource.Add(new TreeItem
        {
            NodeId = "02",
            NodeText = "Videos",
            Icon = "folder",
            Child = new List<TreeItem>()
            {
                new TreeItem { NodeId = "02-01", NodeText = "Naturals.mp4", Icon = "video" },
                new TreeItem { NodeId = "02-02", NodeText = "Wild.mpeg", Icon = "video" },
            },
        });
    }
    class TreeItem
    {
        public string? NodeId { get; set; }
        public string? NodeText { get; set; }
        public string? Icon { get; set; }
        public bool Expanded { get; set; }
        public bool Selected { get; set; }
        public List<TreeItem> Child;
    }
}
<style>       

    .e-treeview .e-list-icon {
        background-repeat: no-repeat;
        background-image: url(https://ej2.syncfusion.com/demos/src/treeview/images/icons/file_icons.png);
        height: 20px;
    }

    .e-treeview .e-list-icon.folder {
        background-position: -10px -552px
    }

    .e-treeview .e-list-icon.audio {
        background-position: -10px -244px
    }

    .e-treeview .e-list-icon.video {
        background-position: -10px -272px
    }
</style>
```

![Blazor TreeView with Dynamic Icon](../images/blazor-treeview-dynamic-icon.png)