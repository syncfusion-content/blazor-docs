---
layout: post
title: ExpandAll/CollapseAll in Blazor TreeView Component | Syncfusion
description: Checkout and learn here all about ExpandAll/ CollapseAll/ CheckAll/ UnCheckAll methods in Syncfusion Blazor TreeView component and much more.
platform: Blazor
control: TreeView
documentation: ug
---

# ExpandAll/CollapseAll actions in Blazor TreeView Component

The `ExpandAllAsync` method is used to expand all the collapsed TreeView nodes in the Blazor TreeView component. Also, we can expand the specific nodes by passing the array of collapsed nodes.

The `CollapseAllAsync` method is used to collapse all the expanded TreeView nodes in the Blazor TreeView component.Also, collapse the specific nodes by passing the array of expanded nodes.

In the following example, the `ExpandAllAsync`, `CollapseAllAsync` methods are used inside the button click.

```cshtml
@using Syncfusion.Blazor.Navigations
<button @onclick="@Expand">TreeView Expand</button>
<button @onclick="@Collaspe">TreeView Collaspe</button>
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
    public void Expand()
    {
        // To expand all the TreeView nodes 
        this.treeview.ExpandAllAsync();
        // To expand the particular node in the TreeView
        // this.treeview.ExpandAllAsync(new string[]{"1"});
    }
    public void Collaspe()
    {
        // To collapse all the nodes in the TreeView 
        this.treeview.CollapseAllAsync();
        // To collapse the particular node in the TreeView
        // this.treeview.CollapseAllAsync(new string[]{"1"});
    }
}

```

## ExpandOn in Blazor TreeView Component

The `ExpandOn` property is used to specify the action upon which the node expands or collapses in the TreeView. The available actions are,

* **Click** : The expand/collapse operation happens when you single-click the node on both desktop and mobile devices.
* **DoubleClick** : The expand/collapse operation happens when you double-click the node on both desktop and mobile devices. 
* **None** : The expand/collapse operation will not happen.

The default value of the `ExpandOn` property is DoubleClick.

In the following example, the `ExpandOn` property is enabled.

```cshtml
@using Syncfusion.Blazor.Navigations
<SfTreeView TValue="MailItem" @ref="treeview" ExpandOn="@Expand">
    <TreeViewFieldsSettings TValue="MailItem" Id="Id" DataSource="@MyFolder" Text="FolderName" ParentID="ParentId" HasChildren="HasSubFolders" Expanded="Expanded"></TreeViewFieldsSettings>
</SfTreeView>

@code{
    SfTreeView<MailItem> treeview;
    public ExpandAction Expand = ExpandAction.Click;
    public class MailItem
    {
        public string Id { get; set; }
        public string ParentId { get; set; }
        public string FolderName { get; set; }
        public bool Expanded { get; set; }
        public bool HasSubFolders { get; set; }
    }
    List<MailItem> MyFolder = new List<MailItem>();
    protected override void OnInitialized()
    {
        base.OnInitialized();
        MyFolder.Add(new MailItem
        {
            Id = "1",
            FolderName = "Inbox",
            HasSubFolders = true,
            Expanded = true,
        });
        MyFolder.Add(new MailItem
        {
            Id = "2",
            ParentId = "1",
            FolderName = "Categories",
            Expanded = true,
            HasSubFolders = true,
        });
        MyFolder.Add(new MailItem
        {
            Id = "3",
            ParentId = "2",
            FolderName = "Primary"
        });
        MyFolder.Add(new MailItem
        {
            Id = "4",
            ParentId = "2",
            FolderName = "Social"
        });
        MyFolder.Add(new MailItem
        {
            Id = "5",
            ParentId = "2",
            FolderName = "Promotions"
        });
    }
}

```

## ExpandedNodes in Blazor TreeView Component

The ExpandedNodes property is used to represent the nodes that are expanded in the Blazor TreeView component. We can expand the specific nodes by passing the array of nodes ID.

In the following example, the `ExpandedNodes` property is used inside the button click.

```cshtml
@using Syncfusion.Blazor.Navigations
<button @onclick="@TreeViewExpandedNodes">TreeView ExpandedNodes</button>
<SfTreeView TValue="MusicAlbum" ShowCheckBox="true" AutoCheck="true" @bind-ExpandedNodes="ExpandedNodes">
    <TreeViewFieldsSettings TValue="MusicAlbum" Id="Id" DataSource="@Albums" Text="Name" ParentID="ParentId" HasChildren="HasChild" Expanded="Expanded" IsChecked="IsChecked"></TreeViewFieldsSettings>
</SfTreeView>

@code{
    SfTreeView<MusicAlbum> treeview;
    public string[] ExpandedNodes = new string[] { "" };
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
    public void TreeViewExpandedNodes()
    {
        ExpandedNodes = new string[] { "1","04" };
    }
}

```