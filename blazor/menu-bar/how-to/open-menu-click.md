---
layout: post
title: Open Sub Menu on Menu Item Click in Blazor Menu Bar | Syncfusion
description: Learn here all about how to open sub menu on Menu item click in Syncfusion Blazor Menu Bar component and more.
platform: Blazor
control: Menu Bar 
documentation: ug
---

# Open Sub Menu on Menu Item Click in Blazor Menu Bar Component

This section explains about how to open a sub menu on Menu item click. This can be achieved by using `ShowItemOnClick` property of the Menu.

In the following sample, Sub Menu will open while clicking `File` menu.

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

![Opening Menu Item in Blazor MenuBar](./../images/blazor-menubar-with-menu-item.png)