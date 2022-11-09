---
layout: post
title: Navigation in Blazor TreeView Component | Syncfusion
description: Checkout and learn here all about FullRowNavigable in Syncfusion Blazor TreeView component and much more.
platform: Blazor
control: TreeView
documentation: ug
---

# Navigation in Blazor TreeView Component

In the TreeView component, we have provided a **NavigateUrl** property. By using this property, you can navigate to other pages with TreeView node selection.

The TreeView `FullRowNavigable` property is used to make the entire TreeView node navigable instead of text element in the Blazor TreeView component.

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