---
layout: post
title: Sorting in Blazor TreeView Component | Syncfusion
description: Checkout and learn here all about Sorting in Syncfusion Blazor TreeView component and much more details.
platform: Blazor
control: TreeView
documentation: ug
---

# Sort order in Blazor TreeView Component

The [`SortOrder`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfTreeView-1.html#Syncfusion_Blazor_Navigations_SfTreeView_1_SortOrder) property is used to sort the TreeView nodes in ascending or descending order in the Blazor TreeView component. The default value of `SortOrder` property is none.

* **Ascending** - specifies the TreeView nodes are sorted in the ascending order.
* **Descending** - specifies the TreeView nodes are sorted in the descending order.
* **None** - specifies the TreeView nodes are not sorted.

In the following example, the `SortOrder` property is dynamically updated on the button click.

```cshtml
@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.Buttons

<SfButton OnClick="Ascending">TreeView Ascending Order</SfButton>
<SfButton OnClick="Descending">TreeView Descending Order</SfButton>
<SfTreeView TValue="MailItem" AllowDragAndDrop="true" SortOrder="sortOrder">
    <TreeViewFieldsSettings TValue="MailItem" DataSource="@MyFolder" Id="Id" Text="FolderName" ParentID="ParentId" HasChildren="HasSubFolders" Expanded="Expanded"></TreeViewFieldsSettings>
</SfTreeView>
@code {
    public SortOrder sortOrder;
    public class MailItem
    {
        public string? Id { get; set; }
        public string? ParentId { get; set; }
        public string? FolderName { get; set; }
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
    public void Ascending()
    {
        sortOrder = SortOrder.Ascending;
    }
    public void Descending()
    {
        sortOrder = SortOrder.Descending;
    }
}

```

