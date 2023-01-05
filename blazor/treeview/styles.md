---
layout: post
title: Styles and Appearance in Blazor TreeView Component | Syncfusion
description: Checkout and learn here all about styles and appearance in Syncfusion Blazor TreeView component and more.
platform: Blazor
control: TreeView
documentation: ug
---

# Styles and Appearance in Blazor TreeView Component

The following content provides the exact CSS structure that can be used to modify the control's appearance based on the user preference.

## Customizing the TreeView nodes

Use the following CSS to customize the TreeView nodes.

```css
.e-treeview .e-list-item { 
        line-height: 45px; 
} 
.e-treeview .e-fullrow { 
        height: 45px; 
}
```

## Customizing the text of TreeView nodes

Use the following CSS to customize the text of TreeView nodes.

```css
.e-treeview .e-list-text { 
        font-weight: bold;
        color:yellow !important;
} 
```

## Customizing the TreeView expand and collapse icons

Use the following CSS to customize the TreeView expand and collapse icons.

```css
.e-treeview .e-icon-expandable { 
        color: red; 
} 
.e-treeview .e-icon-collapsible { 
        color: black; 
}
```

## Customizing the TreeView checkboxes

Use the following CSS to customize the TreeView checkboxes.

```css
.e-checkbox-wrapper .e-frame {
    border:aqua solid 2px !important;
    border-radius: 50% !important;
}
.e-checkbox-wrapper:hover .e-frame{
    border:black solid 2px !important;
    border-radius:50% !important;
}
```

## Customizing the TreeView nodes based on levels

Use the following CSS to customize the TreeView nodes based on levels.

```css
.e-treeview .e-level-2 > .e-text-content { 
        border: 1px solid black; 
        color:red !important;
} 
```

## Set Height for TreeView.

In the Blazor TreeView component, by default, there is no height property, and it takes the parent container height. So, create the scrollable TreeView by setting the height of the TreeView container in the Blazor TreeView component. Use the following CSS to set the TreeView height.

```css
.tree{ 
    border:1px solid black;
    height:670px;
    overflow: scroll;
}
```

```cshtml
@using Syncfusion.Blazor.Navigations
<div class="tree">
<SfTreeView TValue="MusicAlbum" ShowCheckBox="true" AutoCheck="true" @ref="tree" >
    <TreeViewFieldsSettings TValue="MusicAlbum" Id="Id" DataSource="@Albums" Text="Name" ParentID="ParentId" HasChildren="HasChild" Expanded="Expanded" IsChecked="IsChecked"></TreeViewFieldsSettings>
</SfTreeView>
</div>
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

<style>
    /*Customizing TreeView*/ 
    .tree{ 
        border:1px solid black;
        height:670px;
        overflow: scroll;
    } 

    /*Customizing the TreeView nodes*/ 
    .e-treeview .e-list-item { 
         line-height: 45px; 
    } 
    .e-treeview .e-fullrow { 
           height: 45px; 
    }

    /*Customizing the text of TreeView nodes*/
    .e-treeview .e-list-text { 
         font-weight: bold;
         color:yellow !important;
    } 

    /*Customizing the expand and collapse icons*/ 
    .e-treeview .e-icon-expandable { 
         color: red; 
    } 
    .e-treeview .e-icon-collapsible { 
         color: black; 
    } 
    	
    /*Customizing the TreeView nodes based on levels*/
   .e-treeview .e-level-2 > .e-text-content { 
          border: 1px solid black; 
          color:red !important;
   } 
   	
    /*Customizing the TreeView checkboxes*/
   .e-checkbox-wrapper .e-frame {
        border:aqua solid 2px !important;
        border-radius: 50% !important;
   }
   .e-checkbox-wrapper:hover .e-frame{
        border:black solid 2px !important;
        border-radius:50% !important;
   }
</style>
```