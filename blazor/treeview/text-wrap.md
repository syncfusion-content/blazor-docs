---
layout: post
title: Wrpping Text in Blazor TreeView Component | Syncfusion
description: Checkout and learn here all about AllowTextWrap in Syncfusion Blazor TreeView component and much more.
platform: Blazor
control: TreeView
documentation: ug
---

# Wrpping Text in Blazor TreeView Component

The `AllowTextWrap` property is used to enable or disable wrapping the text in the TreeView node. When this property is set to true, the TreeView node's text content will wrap to the next line when its text content exceeds the width of the TreeView node.

The default value of the `AllowTextWrap` property is false.

In the following example, the `AllowTextWrap` property is enabled.

```cshtml
<SfTreeView TValue="MailItem" @ref="treeview" AllowTextWrap="true">
    <TreeViewFieldsSettings TValue="MailItem" Id="Id" DataSource="@MyFolder" Text="FolderName" ParentID="ParentId" HasChildren="HasSubFolders" Expanded="Expanded"></TreeViewFieldsSettings>
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
    }
    List<MailItem> MyFolder = new List<MailItem>();
    protected override void OnInitialized()
    {
        base.OnInitialized();
        MyFolder.Add(new MailItem
        {
            Id = "1",
            FolderName = "The AllowTextWrap property is used to enable or disable wrapping the text in the TreeView node. When the this property is set to true, the TreeView node's text content will wrap to the next line when its text content exceeds the width of the TreeView node.",
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