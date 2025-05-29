---
layout: post
title: Styles and Appearance in Blazor TreeView Component | Syncfusion
description: Checkout and learn here all about styles and appearance in Syncfusion Blazor TreeView component and more.
platform: Blazor
control: TreeView
documentation: ug
---

# Styles and Appearance in Blazor TreeView Component

The following content provides the exact CSS structure that can be used to modify the component's appearance based on the user preference.

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
<SfTreeView TValue="MusicAlbum" ShowCheckBox="true" AutoCheck="true">
    <TreeViewFieldsSettings TValue="MusicAlbum" Id="Id" DataSource="@Albums" Text="Name" ParentID="ParentId" HasChildren="HasChild" Expanded="Expanded" IsChecked="IsChecked"></TreeViewFieldsSettings>
</SfTreeView>
</div>
@code{
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

## Customizing the TreeView using HtmlAttributes

The [HtmlAttributes](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.TreeViewFieldOptions-1.html#Syncfusion_Blazor_Navigations_TreeViewFieldOptions_1_HtmlAttributes) property of the Blazor TreeView component allows you to define a mapping field for applying custom HTML attributes to individual TreeView nodes.

```cshtml
@using Syncfusion.Blazor.Navigations

<div class="control-section">
    <div class="control_wrapper">
        @*Initialize the TreeView component*@
        <SfTreeView TValue="TreeItem" CssClass="custom_tree">
            <TreeViewFieldsSettings DataSource="@TreeDataSource" Id="NodeId" Text="NodeText" Expanded="Expanded" Child="@("Child")" HtmlAttributes="HtmlAttribute"></TreeViewFieldsSettings>
        </SfTreeView>
    </div>
</div>
@code {
    // Specifies the DataSource value for TreeView component.
    List<TreeItem> TreeDataSource = new List<TreeItem>();
    protected override void OnInitialized()
    {
        base.OnInitialized();
        TreeDataSource.Add(new TreeItem
            {
                NodeId = "01",
                NodeText = "Local Disk (C:)",
                Expanded = true,
                HtmlAttribute = new Dictionary<string, object>() { { "class", "e-node-one" } },
                Child = new List<TreeItem>()
            {
                new TreeItem { NodeId = "01-01", NodeText = "Program Files",
                    Child = new List<TreeItem>()
                    {
                        new TreeItem { NodeId = "01-01-01", NodeText = "Windows NT" },
                        new TreeItem { NodeId = "01-01-02", NodeText = "Windows Mail" },
                        new TreeItem { NodeId = "01-01-03", NodeText = "Windows Photo Viewer" }
                    },
                },
                new TreeItem { NodeId = "01-02", NodeText = "Users", Expanded = true,
                    Child = new List<TreeItem>()
                    {
                        new TreeItem { NodeId = "01-02-01", NodeText = "Smith" },
                        new TreeItem { NodeId = "01-02-02", NodeText = "Public" },
                        new TreeItem { NodeId = "01-02-03", NodeText = "Admin" },
                    },
                },
                new TreeItem { NodeId = "01-03", NodeText = "Windows",
                    Child = new List<TreeItem>()
                    {
                        new TreeItem { NodeId = "01-03-01", NodeText = "Boot" },
                        new TreeItem { NodeId = "01-03-02", NodeText = "Media" },
                        new TreeItem { NodeId = "01-03-03", NodeText = "System32" },
                    }
                },
            },
            });
        TreeDataSource.Add(new TreeItem
            {
                NodeId = "02",
                NodeText = "Local Disk (D:)",
                Child = new List<TreeItem>()
            {
                new TreeItem { NodeId = "02-01", NodeText = "Personals",
                    Child = new List<TreeItem>()
                    {
                        new TreeItem { NodeId = "02-01-01", NodeText = "My photo.png" },
                        new TreeItem { NodeId = "02-01-02", NodeText = "Rental document.docx" },
                        new TreeItem { NodeId = "02-01-03", NodeText = "Payslip.pdf" },
                    },
                },
                new TreeItem { NodeId = "02-02", NodeText = "Projects",
                    Child = new List<TreeItem>()
                    {
                        new TreeItem { NodeId = "02-02-01", NodeText = "Blazor Application " },
                        new TreeItem { NodeId = "02-02-02", NodeText = "TypeScript Application" },
                        new TreeItem { NodeId = "02-02-03", NodeText = "React Application" },
                    }
                },
                new TreeItem { NodeId = "02-03", NodeText = "Office",
                    Child = new List<TreeItem>()
                    {
                        new TreeItem { NodeId = "02-03-01", NodeText = "Work details.docx " },
                        new TreeItem { NodeId = "02-03-02", NodeText = "Weekly report.docx" },
                        new TreeItem { NodeId = "02-03-03", NodeText = "Wishlist.csv" },
                    }
                },
            },
            });
        TreeDataSource.Add(new TreeItem
            {
                NodeId = "03",
                NodeText = "Local Disk (E:)",
                Child = new List<TreeItem>()
            {
                new TreeItem { NodeId = "03-01", NodeText = "Pictures",
                    Child = new List<TreeItem>()
                    {
                        new TreeItem { NodeId = "03-01-01", NodeText = "Wind.jpg " },
                        new TreeItem { NodeId = "03-01-02", NodeText = "Stone.jpg" },
                        new TreeItem { NodeId = "03-01-03", NodeText = "Home.jpg" },
                    }
                },
                new TreeItem { NodeId = "03-02", NodeText = "Documents", Icon = "docx",
                    Child = new List<TreeItem>()
                    {
                        new TreeItem { NodeId = "03-02-01", NodeText = "Environment Pollution.docx " },
                        new TreeItem { NodeId = "03-02-02", NodeText = "Global Warming.ppt" },
                        new TreeItem { NodeId = "03-02-03", NodeText = "Social Network.pdf" },
                    },
                },
                new TreeItem { NodeId = "03-03", NodeText = "Study Materials",
                    Child = new List<TreeItem>()
                    {
                        new TreeItem { NodeId = "03-03-01", NodeText = "UI-Guide.pdf" },
                        new TreeItem { NodeId = "03-03-02", NodeText = "Tutorials.zip" },
                        new TreeItem { NodeId = "03-03-03", NodeText = "TypeScript.7z" },
                    }
                },
            },
            });
    }
    class TreeItem
    {
        public string? NodeId { get; set; }
        public string? NodeText { get; set; }
        public string? Icon { get; set; }
        public bool Expanded { get; set; }
        public bool Selected { get; set; }
        public List<TreeItem> Child { get; set; }
        public Dictionary<string, object> HtmlAttribute { get; set; }
    }
}
<style>
    /* Sample specific styles */
    .control_wrapper {
        max-width: 500px;
        margin: auto;
        border: 1px solid #dddddd;
        border-radius: 3px;
        max-height: 470px;
        overflow: auto;
    }
</style>

```

