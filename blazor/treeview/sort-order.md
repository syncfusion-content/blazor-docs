---
layout: post
title: Sorting in Blazor TreeView Component | Syncfusion
description: Checkout and learn here all about SortOrder in Syncfusion Blazor TreeView component and much more.
platform: Blazor
control: TreeView
documentation: ug
---

# Sorting in Blazor TreeView Component

The `SortOrder` property is used to sort the TreeView nodes in ascending or descending order in the Blazor TreeView component.

The default value of `SortOrder` property is none.

In the following example, the `SortOrder` property is dynamically updated on DropdownList selection.

```cshtml
@using Syncfusion.Blazor.Navigations
<button @onclick="click">Get TreeView NodeOrders</button>
<SfTreeView @ref="treeview" TValue="MailItem" AllowDragAndDrop="true" SortOrder="@SortOrder">
    <TreeViewFieldsSettings TValue="MailItem" Id="Id" DataSource="@MyFolder" Text="FolderName" ParentID="ParentId" HasChildren="HasSubFolders" Expanded="Expanded"></TreeViewFieldsSettings>
</SfTreeView>

@code{
    SfTreeView<MailItem> treeview;
    public SortOrder SortOrder = SortOrder.Descending;
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
        });
        MyFolder.Add(new MailItem
        {
            Id = "2",
            ParentId = "1",
            HasSubFolders = true,
            FolderName = "Categories"
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
        MyFolder.Add(new MailItem
        {
            Id = "6",
            FolderName = "Others",
            HasSubFolders = true,
            Expanded = true
        });
        MyFolder.Add(new MailItem
        {
            Id = "7",
            ParentId = "6",
            FolderName = "Sent Items"
        });
        MyFolder.Add(new MailItem
        {
            Id = "8",
            ParentId = "6",
            FolderName = "Delete Items"
        });
        MyFolder.Add(new MailItem
        {
            Id = "9",
            ParentId = "6",
            FolderName = "Drafts"
        });
        MyFolder.Add(new MailItem
        {
            Id = "10",
            ParentId = "6",
            FolderName = "Archive"
        });

    }
    public void click()
    {
        var data = treeview.GetTreeData();
    }
}

```