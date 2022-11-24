---
layout: post
title: Navigation in Blazor TreeView Component | Syncfusion
description: Checkout and learn here all about navigation in Syncfusion Blazor TreeView component and much more.
platform: Blazor
control: TreeView
documentation: ug
---

# Navigation URL binding in Blazor TreeView Component

The TreeView component's **NavigateUrl** property is used to navigate from one page to other pages with TreeView node selection.

In the following example, the `NavigateUrl` property is enabled.

```cshtml
@using Syncfusion.Blazor.Navigations
<SfTreeView TValue="MailItem" @ref="treeview" >
    <TreeViewFieldsSettings TValue="MailItem" Id="Id" NavigateUrl="NavigateUrl" DataSource="@MyFolder" Text="FolderName" ParentID="ParentId" HasChildren="HasSubFolders" Expanded="Expanded"></TreeViewFieldsSettings>
</SfTreeView>

@code{
    SfTreeView<MailItem> treeview;
    public class MailItem
    {
        public string Id { get; set; }
        public string ParentId { get; set; }
        public string FolderName { get; set; }
        public bool Expanded { get; set; }
        public bool HasSubFolders { get; set; }
        public string NavigateUrl { get; set; }
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
            NavigateUrl="/counter"
        });
        MyFolder.Add(new MailItem
        {
            Id = "2",
            ParentId = "1",
            FolderName = "Categories",
            Expanded = true,
            HasSubFolders = true,
            NavigateUrl="/home"
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

## Full row navigation in Blazor TreeView Component

The TreeView [FullRowNavigable](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfTreeView-1.html#Syncfusion_Blazor_Navigations_SfTreeView_1_FullRowNavigable) property is used to make the entire TreeView node navigable instead of text element in the Blazor TreeView component.

In the following example, the `FullRowNavigable` property is enabled.

```cshtml
@using Syncfusion.Blazor.Navigations
<SfTreeView TValue="MailItem" @ref="treeview" FullRowNavigable="true">
    <TreeViewFieldsSettings TValue="MailItem" Id="Id" NavigateUrl="NavigateUrl" DataSource="@MyFolder" Text="FolderName" ParentID="ParentId" HasChildren="HasSubFolders" Expanded="Expanded"></TreeViewFieldsSettings>
</SfTreeView>

@code{
    SfTreeView<MailItem> treeview;
    public class MailItem
    {
        public string Id { get; set; }
        public string ParentId { get; set; }
        public string FolderName { get; set; }
        public bool Expanded { get; set; }
        public bool HasSubFolders { get; set; }
        public string NavigateUrl { get; set; }
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
            NavigateUrl="/counter"
        });
        MyFolder.Add(new MailItem
        {
            Id = "2",
            ParentId = "1",
            FolderName = "Categories",
            Expanded = true,
            HasSubFolders = true,
            NavigateUrl="/home"
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

## Handle processing on node click in Blazor TreeView Component

In the Blazor TreeView component, when clicking on the TreeView node, you can get the TreeView nodes' id, text, and parent id using our NodeClicked event.

```cshtml
@using Syncfusion.Blazor.Navigations
<div class="tree">
<SfTreeView TValue="MailItem" @ref="tree">
    <TreeViewEvents TValue="MailItem" NodeClicked="nodeClicked"></TreeViewEvents>
    <TreeViewFieldsSettings TValue="MailItem" Id="Id" HtmlAttributes="HtmlAttributes" DataSource="@MyFolder" Text="FolderName" ParentID="ParentId" HasChildren="HasSubFolders" Expanded="Expanded"></TreeViewFieldsSettings>
</SfTreeView>
</div>
<div class="containers">
    <p>Which node was click and list out the details</p>
<table >
        <tr>
            <th style="width: 50%">Id</th>
            <td style="width: 50%" align="center"><div>@Id</div></td>
        </tr>
        <tr>
            <th style="width: 50%;">Text</th>
            <td style="width: 30%" align="center">
                <div>@Text</div>
            </td>
        </tr>
        <tr><th style="width: 50%;" >Parent Id</th>
            <td style="width: 30%" align="center">
                    @if (ParentID == null)
                    {
                        <div>null</div>
                    }
                    else
                    {
                        <div>@ParentID</div>
                    }
            </td>
        </tr>
    </table>
</div>
@code {
    SfTreeView<MailItem> tree;
    public class MailItem
    {
        public string Id { get; set; }
        public string ParentId { get; set; }
        public string FolderName { get; set; }
        public bool Expanded { get; set; }
        public bool HasSubFolders { get; set; }
        public Dictionary<string, object> HtmlAttributes { get; set; }
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
                Expanded = true
            });
        MyFolder.Add(new MailItem
            {
                Id = "2",
                ParentId = "1",
                FolderName = "Categories",
                Expanded = true,
                HasSubFolders = true
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
    public string Id;
    public string Text;
    public string ParentID;
    public void nodeClicked(NodeClickEventArgs args)
    {
        Id = (args.NodeData.Id);
        Text = (args.NodeData.Text);
        ParentID = (args.NodeData.ParentID);
    }
}
<style>
    .containers {
        margin-top: -200px;
        margin-left: 500px;
    }
    .tree{
        width:50%;
    }
</style>

```

## Tree node as hyperlink in Blazor TreeView Component

The TreeView component's **NavigateUrl** property is used to navigate from one page to other pages with TreeView node selection. Using the CSS styles, you can customize the TreeView node as a hyperlink.

The following code example demonstrates how to customize the tree nodes as a hyperlink.


```cshtml

@using Syncfusion.Blazor.Navigations
<SfTreeView TValue="MailItem" @ref="treeview" >
    <TreeViewFieldsSettings TValue="MailItem" Id="Id" NavigateUrl="NavigateUrl" DataSource="@MyFolder" Text="FolderName" ParentID="ParentId" HasChildren="HasSubFolders" Expanded="Expanded"></TreeViewFieldsSettings>
</SfTreeView>

@code{
    SfTreeView<MailItem> treeview;
    public class MailItem
    {
        public string Id { get; set; }
        public string ParentId { get; set; }
        public string FolderName { get; set; }
        public bool Expanded { get; set; }
        public bool HasSubFolders { get; set; }
        public string NavigateUrl { get; set; }
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
            NavigateUrl="/counter"
        });
        MyFolder.Add(new MailItem
        {
            Id = "2",
            ParentId = "1",
            FolderName = "Categories",
            Expanded = true,
            HasSubFolders = true,
            NavigateUrl="/home"
        });
        MyFolder.Add(new MailItem
        {
            Id = "3",
            ParentId = "2",
            FolderName = "Primary",
            NavigateUrl = "/"
        });
        MyFolder.Add(new MailItem
        {
            Id = "4",
            ParentId = "2",
            FolderName = "Social",
            NavigateUrl = "/social"
        });
        MyFolder.Add(new MailItem
        {
            Id = "5",
            ParentId = "2",
            FolderName = "Promotions",
            NavigateUrl = "/promotions"
        });
    }
}
<style>
    .e-treeview .e-list-text {
        cursor: pointer;
        color: blue;
        text-decoration: underline;
    }
</style>

```