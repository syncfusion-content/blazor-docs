---
layout: post
title: CheckBox in Blazor TreeView Component | Syncfusion
description: Checkout and learn here all about CheckBox in Syncfusion Blazor TreeView component and much more details.
platform: Blazor
control: TreeView
documentation: ug
---

# CheckBox in Blazor TreeView Component

The Blazor TreeView component allows to check more than one node in TreeView without affecting the UI's appearance by enabling the `ShowCheckBox` property. When this property is enabled, checkbox appears before each TreeView node text.

* If one of the child nodes is not in a checked state, then the parent node will be in an intermediate state.

* If all the child nodes are in checked state, then the parent node's state will also be checked.

* If a parent node is checked, then all the child nodes' state will also be checked.

By default, the checkbox state of parent and child nodes are dependent on each other. For independent checked state, achieve it using the `AutoCheck` property.

```cshtml
@using Syncfusion.Blazor.Navigations
<SfTreeView TValue="MusicAlbum" ShowCheckBox="true" AutoCheck="true">
    <TreeViewFieldsSettings TValue="MusicAlbum" Id="Id" DataSource="@Albums" Text="Name" ParentID="ParentId" HasChildren="HasChild" Expanded="Expanded" IsChecked="IsChecked"></TreeViewFieldsSettings>
</SfTreeView>

@code{
    public class MusicAlbum
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Name { get; set; }
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
}
```

![Blazor TreeView with CheckBox](./images/blazor-treeview-checkbox.png)

## CheckAll/ UnCheckAll actions in Blazor TreeView Component

The `CheckAllAsync` method is used to check all the unchecked TreeView nodes in the Blazor TreeView component. Also, we can check the specific nodes by passing the array of unchecked nodes.

The `UnCheckAllAsync` method is used to uncheck all the checked TreeView nodes in the Blazor TreeView component. Also, we can uncheck the specific nodes by passing the array of checked nodes.

In the following example, the `CheckAllAsync`, `UnCheckAllAsync` methods are used inside the button click.

```cshtml
@using Syncfusion.Blazor.Navigations
<button @onclick="@CheckAll">TreeView CheckAll</button>
<button @onclick="@UnCheckAll">TreeView UnCheckAll</button>
<SfTreeView TValue="MusicAlbum" @ref="treeview" ShowCheckBox="true" AutoCheck="true">
    <TreeViewFieldsSettings TValue="MusicAlbum" Id="Id" DataSource="@Albums" Text="Name" ParentID="ParentId" HasChildren="HasChild" Expanded="Expanded" IsChecked="IsChecked"></TreeViewFieldsSettings>
</SfTreeView>
@code{
    SfTreeView<MusicAlbum> treeview;
    public class MusicAlbum
    {
        public string Id { get; set; }
        public string ParentId { get; set; }
        public string Name { get; set; }
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
            Id = "1",
            Name = "Discover Music",
            HasChild = true,
        });
        Albums.Add(new MusicAlbum
        {
            Id = "2",
            ParentId = "1",
            Name = "Hot Singles"
        });
        Albums.Add(new MusicAlbum
        {
            Id = "3",
            ParentId = "1",
            Name = "Rising Artists"
        });
        Albums.Add(new MusicAlbum
        {
            Id = "4",
            ParentId = "1",
            Name = "Live Music"
        });
        Albums.Add(new MusicAlbum
        {
            Id = "04",
            HasChild = true,
            Name = "MP3 Albums"            
        });
        Albums.Add(new MusicAlbum
        {
            Id = "5",
            ParentId = "04",
            Name = "Rock",
            IsChecked = true
        });
        Albums.Add(new MusicAlbum
        {
            Id = "6",
            Name = "Gospel",
            ParentId = "04",
        });
        Albums.Add(new MusicAlbum
        {
            Id = "7",
            ParentId = "04",
            Name = "Latin Music"
        });
        Albums.Add(new MusicAlbum
        {
            Id = "8",
            ParentId = "04",
            Name = "Jazz"
        });
    }
    public void CheckAll()
    {
        // To check all the nodes in the TreeView 
        this.treeview.CheckAllAsync();
        // To check the particular node in the TreeView
        // this.treeview.CheckAllAsync(new string[]{"1"});
    }
    public void UnCheckAll()
    {
        // To uncheck all the nodes in the TreeView  
        this.treeview.UncheckAllAsync();
        // To uncheck the particular node in the TreeView
        // this.treeview.UncheckAllAsync(new string[]{"1"});
    }
}
```

## CheckedNodes in Blazor TreeView Component

The `CheckedNodes` property is used to represent the nodes that are checked in the Blazor TreeView component. We can check the specific nodes by passing the array of nodes ID.

In the following example, the `CheckedNodes` are passed through the button click.

```cshtml
@using Syncfusion.Blazor.Navigations
<button @onclick="@TreeViewCheckedNodes">TreeView CheckedNodes</button>
<SfTreeView TValue="MusicAlbum" ShowCheckBox="true" AutoCheck="true" @bind-CheckedNodes="CheckedNodes">
    <TreeViewFieldsSettings TValue="MusicAlbum" Id="Id" DataSource="@Albums" Text="Name" ParentID="ParentId" HasChildren="HasChild" Expanded="Expanded" IsChecked="IsChecked"></TreeViewFieldsSettings>
</SfTreeView>
@code{
    SfTreeView<MusicAlbum> treeview;
    public string[] CheckedNodes = new string[] { "" };
    public class MusicAlbum
    {
        public string Id { get; set; }
        public string ParentId { get; set; }
        public string Name { get; set; }
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
            Id = "1",
            Name = "Discover Music",
            HasChild = true
        });
        Albums.Add(new MusicAlbum
        {
            Id = "2",
            ParentId = "1",
            Name = "Hot Singles"
        });
        Albums.Add(new MusicAlbum
        {
            Id = "3",
            ParentId = "1",
            Name = "Rising Artists"
        });
        Albums.Add(new MusicAlbum
        {
            Id = "4",
            ParentId = "1",
            Name = "Live Music"
        });
        Albums.Add(new MusicAlbum
        {
            Id = "04",
            HasChild = true,
            Name = "MP3 Albums"           
        });
        Albums.Add(new MusicAlbum
        {
            Id = "5",
            ParentId = "04",
            Name = "Rock",
            IsChecked = true
        });
        Albums.Add(new MusicAlbum
        {
            Id = "6",
            Name = "Gospel",
            ParentId = "04",
        });
        Albums.Add(new MusicAlbum
        {
            Id = "7",
            ParentId = "04",
            Name = "Latin Music"
        });
        Albums.Add(new MusicAlbum
        {
            Id = "8",
            ParentId = "04",
            Name = "Jazz"
        });
    }
    public void TreeViewCheckedNodes()
    {
        CheckedNodes = new string[] { "6","7","8" };
    }
}
```

## Hide checkbox for child nodes in Blazor TreeView Component

In the Blazor TreeView component, enable the check box using the ShowCheckBox property, and a check box could be rendered before each node of the tree items. However, some applications need to render the check box in the parent nodes alone. In such cases, remove the check box of the child node by customizing the CSS styles.

In the following example, the `ShowCheckBox` property is enabled and removed the check box of the child nodes by customizing the CSS style.

```cshtml
@using Syncfusion.Blazor.Navigations
<SfTreeView TValue="Country" ShowCheckBox="true" CssClass="CustomTree">
    <TreeViewFieldsSettings TValue="Country" Id="Id" DataSource="@Countries" Text="Name" ParentID="ParentId" HasChildren="HasChild" Expanded="Expanded" Selected="IsSelected"></TreeViewFieldsSettings>
</SfTreeView>
@code{
    public class Country
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Name { get; set; }
        public bool HasChild { get; set; }
        public bool Expanded { get; set; }
        public bool IsSelected { get; set; }
    }
    List<Country> Countries = new List<Country>();

    protected override void OnInitialized()
    {
        base.OnInitialized();
        Countries.Add(new Country
        {
            Id = 1,
            Name = "Australia",
            HasChild = true,
            Expanded = true
        });
        Countries.Add(new Country
        {
            Id = 2,
            ParentId = 1,
            Name = "New South Wales",
            IsSelected = true
        });
        Countries.Add(new Country
        {
            Id = 3,
            ParentId = 1,
            Name = "Victoria",
            IsSelected = true
        });
        Countries.Add(new Country
        {
            Id = 4,
            ParentId = 1,
            Name = "South Australia"
        });
        Countries.Add(new Country
        {
            Id = 5,
            ParentId = 1,
            Name = "Western Australia"
        });
        Countries.Add(new Country
        {
            Id = 6,
            Name = "Brazil",
            HasChild = true
        });
        Countries.Add(new Country
        {
            Id = 7,
            ParentId = 6,
            Name = "Paraná"
        });
        Countries.Add(new Country
        {
            Id = 8,
            ParentId = 6,
            Name = "Ceará"
        });
        Countries.Add(new Country
        {
            Id = 9,
            Name = "China",
            HasChild = true
        });
        Countries.Add(new Country
        {
            Id = 10,
            ParentId = 9,
            Name = "Guangzhou"
        });
        Countries.Add(new Country
        {
            Id = 11,
            ParentId = 9,
            Name = "Shantou"
        });
    }
}
<style>
    .CustomTree .e-list-item.e-level-2 .e-checkbox-wrapper.e-css {
        display: none
    }
</style>
```

## Single selection with checkbox in Blazor TreeView Component

The single selection on TreeView nodes along with the checkbox can be achieved by unchecking the previously checked nodes using the uncheckAll methods during the nodeChecking event in the Blazor TreeView component.

```cshtml
@using Syncfusion.Blazor.Navigations
<SfTreeView TValue="MusicAlbum" ShowCheckBox="true" AutoCheck="true" @ref="tree">
    <TreeViewEvents TValue="MusicAlbum" NodeChecking="NodeChecking"></TreeViewEvents>
    <TreeViewFieldsSettings TValue="MusicAlbum" Id="Id" DataSource="@Albums" Text="Name" ParentID="ParentId" HasChildren="HasChild" Expanded="Expanded" IsChecked="IsChecked"></TreeViewFieldsSettings>
</SfTreeView>
@code{
    SfTreeView<MusicAlbum> tree;
    public class MusicAlbum
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Name { get; set; }
        public bool Expanded { get; set; }
        public bool? IsChecked { get; set; }
        public bool HasChild { get; set; }
    }
    public void NodeChecking(NodeCheckEventArgs args)
    {
        if(args.Action=="check" && args.IsInteracted)
        {
            tree.UncheckAllAsync();
        }

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
            Expanded = true
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
            Expanded = true
        
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
}
```