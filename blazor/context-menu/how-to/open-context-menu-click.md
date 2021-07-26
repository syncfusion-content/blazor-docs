---
layout: post
title: How to Open Context Menu Click in Blazor Context Menu Component | Syncfusion
description: Checkout and learn about Open Context Menu Click in Blazor Context Menu component of Syncfusion, and more details.
platform: Blazor
control: Context Menu
documentation: ug
---

# Open a Sub Menu on Context Menu item click

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
