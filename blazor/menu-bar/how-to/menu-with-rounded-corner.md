---
layout: post
title: Menu Bar with Rounded Corner in Blazor Menu Bar Component | Syncfusion
description: Checkout and learn here all about menu bar with rounded corner in Syncfusion Blazor Menu Bar component and more.
platform: Blazor
control: Menu Bar 
documentation: ug
---

# Menu Bar with Rounded Corner in Blazor Menu Bar Component

Rounded corners can be applied to the Blazor Menu Bar component using the [`CssClass`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor~Syncfusion.Blazor.Navigations.SfMenu~CssClass.html) property. Assign a custom CSS class to the Menu Bar component and then define `border-radius` and other related styles within this class. The `styles` section provides a detailed example.

```cshtml
@using Syncfusion.Blazor.Navigations

<SfMenu TValue="MenuItem" CssClass="e-rounded-menu">
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
<style>

    /* Styles to achieve rounder corner in menu */
    .e-menu-container.e-rounded-menu:not(.e-menu-popup),
    .e-menu-container.e-rounded-menu .e-menu {
        border-radius: 20px;
    }

    /* Increased the menu component left and right padding for better rounded corner UI */
    .e-menu-container.e-rounded-menu ul.e-menu {
        padding: 0 14px;
    }
</style>

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/LNhICXDgLCYdXjCg?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}
![Blazor MenuBar with Rounded Corner](./../images/blazor-menubar-with-rounded-corner.png)