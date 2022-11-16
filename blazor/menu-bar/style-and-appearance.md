---
layout: post
title: Styles and Appearances in Blazor Menu Bar Component | Syncfusion
description: Checkout and learn here all about styles and appearances in Syncfusion Blazor Menu Bar component and more.
platform: Blazor
control: Menu Bar 
documentation: ug
---

# Styles and Appearances in Blazor Menu Bar Component

To modify the Menu appearance, you need to override the default CSS of Menu component. Find the list of CSS classes and its corresponding section in Menu component. Also, you have an option to create your own custom theme for the controls using our [Theme Studio](https://blazor.syncfusion.com/themestudio/?theme=material).

| CSS Class | Purpose of Class |
| ----- | ----- |
| .e-menu-container | To customize the menu wrapper |
| .e-menu-container.e-menu-popup | To customize the menu popup | 
| .e-menu-container .e-ul .e-menu-item | To customize the menu items | 
| .e-menu-container .e-ul .e-menu-item.e-focused | To customize the menu items on focus |
| .e-menu-container ul .e-menu-item .e-caret::before | To customize the menu items caret icon |
| .e-menu-container .e-ul .e-menu-item.e-selected | To customize selected menu item |

## Customizing the appearance of menu

Use the following CSS to customize the background color of menu container, focus items and selected items.

```cshtml

@using Syncfusion.Blazor.Navigations

<SfMenu TValue="MenuItem">
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
                <MenuItem Text="Toolbars"></MenuItem>
                <MenuItem Text="Zoomr"></MenuItem>
                <MenuItem Text="Full Screen"></MenuItem>
            </MenuItems>
        </MenuItem>
        <MenuItem Text="Tools">
            <MenuItems>
                <MenuItem Text="Spelling & Grammar"></MenuItem>
                <MenuItem Text="Customize"></MenuItem>
                <MenuItem Text="Options"></MenuItem>
            </MenuItems>
        </MenuItem>
        <MenuItem Text="Go"></MenuItem>
        <MenuItem Text="Help"></MenuItem>
    </MenuItems>
</SfMenu>

<style>
    .e-menu-container {
        background-color: #bad9ff;
    }

    .e-menu-container .e-menu .e-menu-item.e-selected {
        background-color: #8ec6fe;
    }

    .e-menu-container .e-ul .e-menu-item.e-focused{
        background-color: #b3d9ff;
    }
</style>

```

![Blazor Menubar with Style and Appearance](./images/blazor-menubar-style-and-appearance.png)