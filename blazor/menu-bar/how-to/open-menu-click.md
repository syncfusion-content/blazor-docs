---
layout: post
title: Open Sub Menu on Menu Item Click in Blazor Menu Bar | Syncfusion
description: Learn here all about how to open sub menu on Menu item click in Syncfusion Blazor Menu Bar component and more.
platform: Blazor
control: Menu Bar 
documentation: ug
---

# Open Sub Menu on Menu Item Click in Blazor Menu Bar Component

This section explains how to open a sub-menu when a menu item is clicked. This functionality is achieved using the `ShowItemOnClick` property of the Menu component.

In the following sample, the sub-menu will open when the "File" menu is clicked.

```cshtml
@using Syncfusion.Blazor.Navigations

<SfMenu TValue="MenuItem" ShowItemOnClick="true">
    <MenuItems>
        <MenuItem Text="File">
            <MenuItems>
                <MenuItem Text="Open"></MenuItem>
                <MenuItem Text="Save"></MenuItem>
                <MenuItem Text="Exit"></MenuItem>
            </MenuItems>
        </MenuItem>
        <MenuItem Text="Edit">
            <MenuItems>
                <MenuItem Text="Cut"></MenuItem>
                <MenuItem Text="Copy"></MenuItem>
                <MenuItem Text="Paste"></MenuItem>
            </MenuItems>
        </MenuItem>
        <MenuItem Text="View">
            <MenuItems>
                <MenuItem Text="Toolbar"></MenuItem>
                <MenuItem Text="Sidebar"></MenuItem>
                <MenuItem Text="Full Screen"></MenuItem>
            </MenuItems>
        </MenuItem>
        <MenuItem Text="Tools">
            <MenuItems>
                <MenuItem Text="Spelling & Grammer"></MenuItem>
                <MenuItem Text="Customize"></MenuItem>
                <MenuItem Text="Options"></MenuItem>
            </MenuItems>
        </MenuItem>
    </MenuItems>
</SfMenu>
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/hXhoMXZUhrXpuMoM?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}
![Opening Menu Item in Blazor MenuBar](./../images/blazor-menubar-with-menu-item.png)