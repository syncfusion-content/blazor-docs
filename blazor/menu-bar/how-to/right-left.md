---
layout: post
title: Right to Left in Blazor Menu Bar Component | Syncfusion®
description: Checkout and learn here all the features about right to left in Blazor Menu Bar component and much more details.
platform: Blazor
control: Menu Bar 
documentation: ug
---

# Right to Left in Blazor Menu Bar Component

The Menu Bar component supports right-to-left (RTL) layout direction for languages such as Arabic and Hebrew. This is enabled by setting the [EnableRtl](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor~Syncfusion.Blazor.Navigations.SfMenu~EnableRtl.html) property to `true`. When enabled, the menu bar reverses its layout: items align to the right, sub menus open toward the left, and any built-in icons are mirrored.

The following example illustrates how to enable right-to-left support in the Menu Bar component.

```cshtml
@using Syncfusion.Blazor.Navigations

<SfMenu TValue="MenuItem" EnableRtl="true">
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

![Right to Left in Blazor MenuBar](./../images/blazor-menubar-right-to-left.webp)