---
layout: post
title: Bind Events in Blazor ContextMenu Component | Syncfusion
description: Checkout and learn here all about Bind Context Menu Events in Syncfusion Blazor ContextMenu component and more.
platform: Blazor
control: Context Menu
documentation: ug
---

# Bind Events in Blazor ContextMenu Component

The [`ItemSelected`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.MenuEvents-1.html#Syncfusion_Blazor_Navigations_MenuEvents_1_ItemSelected) event is used to handle menu item selections in the ContextMenu component. This event triggers whenever an item within the context menu is selected by the user.

```cshtml

@using Syncfusion.Blazor.Navigations

<div id="target">Right click/Touch hold to open the ContextMenu </div>
<SfContextMenu Target="#target" TValue="MenuItem">
    <MenuItems>
        <MenuItem Text="Cut"></MenuItem>
        <MenuItem Text="Copy"></MenuItem>
        <MenuItem Text="Paste"></MenuItem>
    </MenuItems>
    <MenuEvents TValue="MenuItem" ItemSelected="@selectedHandler"></MenuEvents>
</SfContextMenu>

@code {
    public MenuItem SelectedItem;
    // Triggers when the item is selected
    private void selectedHandler(MenuEventArgs<MenuItem> args) {
        SelectedItem = args.Item;
    }
}

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


{% previewsample "https://blazorplayground.syncfusion.com/embed/rZhUCBBcgOQARqgw?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Binding Blazor ContextMenu Events](./../images/blazor-contextmenu-component.png)