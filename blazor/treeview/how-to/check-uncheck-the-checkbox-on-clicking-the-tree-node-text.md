---
layout: post
title: Check/uncheck on clicking the tree node text in TreeView | Syncfusion
description: Learn here all about how to check and uncheck the checkbox on clicking the tree node text in Syncfusion Blazor TreeView component and more.
platform: Blazor
control: TreeView
documentation: ug
---

# Check/uncheck on clicking the tree node text in Blazor TreeView

Checkboxes in the TreeView can be checked and unchecked by clicking the tree node's text, utilizing the [`NodeClicked`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.TreeViewEvents-1.html#Syncfusion_Blazor_Navigations_TreeViewEvents_1_NodeClicked) event.

```cshtml
@using Syncfusion.Blazor.Navigations
<SfTreeView TValue="MusicAlbum" @ref="tree" ShowCheckBox="true" AutoCheck="true" @bind-CheckedNodes="@CheckedNodes">
    <TreeViewEvents TValue="MusicAlbum" OnKeyPress="TreeNodeClick" NodeClicked="NodeClick" NodeChecking="BeforeCheck" NodeExpanding="ExpandCollapse" NodeCollapsing="ExpandCollapse"></TreeViewEvents>
    <TreeViewFieldsSettings TValue="MusicAlbum" Id="Id" DataSource="@Albums" Text="Name" ParentID="ParentId" HasChildren="HasChild" Expanded="Expanded" IsChecked="IsChecked"></TreeViewFieldsSettings>
</SfTreeView>

@code{

    SfTreeView<MusicAlbum> tree;
    public string[] CheckedNodes;
    public bool ExpandIconClick { get; set; } = false;
    public bool CheckBoxClick { get; set; } = false;
    List<MusicAlbum> NodeDetails;
    public List<string> TempCheckedNodes = new List<string>();
    public class MusicAlbum
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string? Name { get; set; }
        public bool Expanded { get; set; }
        public bool? IsChecked { get; set; }
        public bool HasChild { get; set; }

    }
    List<MusicAlbum> Albums = new List<MusicAlbum>();

    protected override void OnInitialized()
    {
        base.OnInitialized();
        Albums.Add(new MusicAlbum
            {
                Id = 1,
                Name = "Discover Music",
                HasChild = true,
            });
        Albums.Add(new MusicAlbum
            {
                Id = 2,
                ParentId = 1,
                Name = "Hot Singles"
            });
        Albums.Add(new MusicAlbum
            {
                Id = 3,
                ParentId = 1,
                Name = "Rising Artists"
            });
        Albums.Add(new MusicAlbum
            {
                Id = 4,
                ParentId = 1,
                Name = "Live Music"
            });
        Albums.Add(new MusicAlbum
            {
                Id = 14,
                HasChild = true,
                Name = "MP3 Albums",
                Expanded = true,
                IsChecked = true
            });
        Albums.Add(new MusicAlbum
            {
                Id = 15,
                ParentId = 14,
                Name = "Rock"
            });
        Albums.Add(new MusicAlbum
            {
                Id = 16,
                Name = "Gospel",
                ParentId = 14,
            });
        Albums.Add(new MusicAlbum
            {
                Id = 17,
                ParentId = 14,
                Name = "Latin Music"
            });
        Albums.Add(new MusicAlbum
            {
                Id = 18,
                ParentId = 14,
                Name = "Jazz"
            });
    }

    public async void TreeNodeClick(NodeKeyPressEventArgs args)
    {
        string Key = args.Key;
        if (Key == "Enter" && !ExpandIconClick)
        {
            TempCheckedNodes = CheckedNodes?.ToList() ?? new();
            List<MusicAlbum> NodeDetails = this.tree.GetTreeData(args.NodeData.Id);
            if (NodeDetails[0].IsChecked == true)
            {
                if (tree.AutoCheck)
                {
                    await tree.UncheckAllAsync(new string[] { args.NodeData.Id });
                }
                else
                {
                    TempCheckedNodes.Remove(args.NodeData.Id);
                }
            }
            else
            {
                if (tree.AutoCheck)
                {
                    await tree.CheckAllAsync(new string[] { args.NodeData.Id });
                }
                else
                {
                    TempCheckedNodes.Add(args.NodeData.Id);
                }
            }
            if (!tree.AutoCheck)
            {
                CheckedNodes = TempCheckedNodes?.ToArray();
            }
        }
        ExpandIconClick = false;
        tree.PreventRender(false);
    }

    public async void NodeClick(NodeClickEventArgs args)
    {
        if (!ExpandIconClick && !CheckBoxClick)
        {
            TempCheckedNodes = CheckedNodes?.ToList() ?? new();
            List<MusicAlbum> NodeDetails = this.tree.GetTreeData(args.NodeData.Id);
            if (NodeDetails[0].IsChecked == true)
            {
                if (tree.AutoCheck)
                {
                    await tree.UncheckAllAsync(new string[] { args.NodeData.Id });
                }
                else
                {
                    TempCheckedNodes.Remove(args.NodeData.Id);
                }
            }
            else
            {
                if (tree.AutoCheck)
                {
                    await tree.CheckAllAsync(new string[] { args.NodeData.Id });
                }
                else
                {
                    TempCheckedNodes.Add(args.NodeData.Id);
                }
            }
            if (!tree.AutoCheck)
            {
                CheckedNodes = TempCheckedNodes?.ToArray();
            }
        }
        ExpandIconClick = false;
        CheckBoxClick = false;
        tree.PreventRender(false);
    }

    public void ExpandCollapse(NodeExpandEventArgs args)
    {
        ExpandIconClick = true;
    }

    public void BeforeCheck(NodeCheckEventArgs args)
    {
        if (args.IsInteracted)
        {
            CheckBoxClick = true;
        }
    }
}
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/VtLesXsrAwEkrazW?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Checking or Unchecking CheckBox in Blazor TreeView](../images/blazor-treeview-checkbox.png)