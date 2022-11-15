---
layout: post
title: Animation in Blazor TreeView Component | Syncfusion
description: Checkout and learn here all about Animation in Syncfusion Blazor TreeView component and much more.
platform: Blazor
control: TreeView
documentation: ug
---

# Animation in Blazor TreeView Component

The [Animation](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfTreeView-1.html#Syncfusion_Blazor_Navigations_SfTreeView_1_Animation) property is used to speed up or slow down the expand and collapse actions in the Blazor TreeView component.

The `TreeViewNodeAnimationSettings` API, which includes the `TreeViewAnimationExpand` and `TreeViewAnimationCollapse` APIs helps in setting Animation in TreeView. Both collapse and expand APIs include the below properties.

* **Duration** - specifies the duration to animate.
* **Easing** - specifies the animation timing function.
* **Effect** - specifies the type of animation.

In the following example, the `Animation` settings are defined.

```cshtml
@using Syncfusion.Blazor.Navigations
<SfTreeView TValue="MailItem" @ref="treeview">
    <TreeViewFieldsSettings TValue="MailItem" Id="Id" DataSource="@MyFolder" Text="FolderName" ParentID="ParentId" HasChildren="HasSubFolders" Expanded="Expanded"></TreeViewFieldsSettings>
    <b><TreeViewNodeAnimationSettings>
        <TreeViewAnimationExpand Duration="1000" Effect="Syncfusion.Blazor.AnimationEffect.SlideDown" Easing="Linear"></TreeViewAnimationExpand>
        <TreeViewAnimationCollapse Duration="1000" Effect="Syncfusion.Blazor.AnimationEffect.SlideUp" Easing="Linear"></TreeViewAnimationCollapse>
    </TreeViewNodeAnimationSettings></b>
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
}

```