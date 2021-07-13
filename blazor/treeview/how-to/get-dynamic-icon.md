---
layout: post
title: How to Get Dynamic Icon in Blazor TreeView Component | Syncfusion
description: Checkout and learn about Get Dynamic Icon in Blazor TreeView component of Syncfusion, and more details.
platform: Blazor
control: TreeView
documentation: ug
---

# Get IconCss dynamically in TreeView

In TreeView component, you can get the original bound data using the `GetTreeData` method. For this method, if you pass the id of the tree node, it returns the corresponding node information, or otherwise the overall tree nodes information will be returned. You can use this method to get the bound IconCss class in the `NodeChecking` event. Please refer to the following sample.

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
        public string NodeId { get; set; }
        public string NodeText { get; set; }
        public string Icon { get; set; }
        public bool Expanded { get; set; }
        public bool Selected { get; set; }
        public List<TreeItem> Child;
    }
}
<style>

    .e-treeview .e-list-img {
        width: 25px;
        height: 25px;
    }
    /* Loading sprite image for TreeView */
    .e-treeview .e-list-icon {
        background-repeat: no-repeat;
        background-image: url("css/treeview/images/file_Icons.png");
        height: 20px;
    }
        /* Specify the Icon positions based upon class name */
        .e-treeview .e-list-icon.folder {
            background-position: -197px -552px
        }

        .e-treeview .e-list-icon.docx {
            background-position: -197px -20px
        }

        .e-treeview .e-list-icon.ppt {
            background-position: -197px -48px
        }

        .e-treeview .e-list-icon.pdf {
            background-position: -197px -104px
        }

        .e-treeview .e-list-icon.images {
            background-position: -197px -132px
        }

        .e-treeview .e-list-icon.zip {
            background-position: -197px -188px
        }

        .e-treeview .e-list-icon.audio {
            background-position: -197px -244px
        }

        .e-treeview .e-list-icon.video {
            background-position: -197px -272px
        }

        .e-treeview .e-list-icon.exe {
            background-position: -197px -412px
        }
</style>
```

Output be like the below.

![TreeView Sample](../images/IconCss.png)