---
layout: post
title: Open Sub Menu on Item Click in Blazor ContextMenu | Syncfusion
description: Learn here all about Open Sub Menu on Context Menu Item Click in Syncfusion Blazor ContextMenu component and more.
platform: Blazor
control: Context Menu
documentation: ug
---

# Open Sub Menu on Item Click in Blazor ContextMenu Component

This section explains about how to open a sub menu on Context Menu item click. This can be achieved by using `ShowItemOnClick` property of the Context Menu.

In the following sample, Sub Menu will open while clicking `Save` item.

```cshtml
@using Syncfusion.Blazor.Navigations

<div id="target">Right click/Touch hold to open the ContextMenu </div>
<SfContextMenu Target="#target" TValue="MenuItem" ShowItemOnClick="true">
    <MenuItems>
        <MenuItem Text="Back"></MenuItem>
        <MenuItem Text="Forward"></MenuItem>
        <MenuItem Text="Reload"></MenuItem>
        <MenuItem Separator="true"></MenuItem>
        <MenuItem Text="Save">
            <MenuItems>
                <MenuItem Text="Save"></MenuItem>
                <MenuItem Text="Save As..."></MenuItem>
            </MenuItems>
        </MenuItem>
        <MenuItem Text="Print"></MenuItem>
        <MenuItem Text="Cast"></MenuItem>
    </MenuItems>
</SfContextMenu>

<style>
    #target {
        border: 1px dashed;
        height: 150px;
        padding: 10px;
        position: relative;
        text-align: justify;
        color: gray;
        user-select: none;
    }
</style>

```

{% previewsample "https://blazorplayground.syncfusion.com/embed/hDBUiLLwAuYIrlKL?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor ContextMenu](./../images/contextmenu-submenu.png)" %}