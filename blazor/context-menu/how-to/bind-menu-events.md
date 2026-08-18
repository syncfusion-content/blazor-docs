---
layout: post
title: How to bind Context Menu events in Blazor | Syncfusion®
description: Bind Blazor Context Menu events such as ItemSelected, OnOpen, OnClose, and BeforeOpen to react to user interactions with the menu.
platform: Blazor
control: Context Menu
documentation: ug
---

# How to bind Context Menu events in Blazor

To bind a menu event in the ContextMenu, the [ItemSelected](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.MenuEvents-1.html#Syncfusion_Blazor_Navigations_MenuEvents_1_ItemSelected) event is used and is triggered when an item in the ContextMenu is selected.

The following table lists the events exposed by `MenuEvents`.

| Event | Description |
| --- | --- |
| [ItemSelected](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.MenuEvents-1.html#Syncfusion_Blazor_Navigations_MenuEvents_1_ItemSelected) | Triggered when a ContextMenu item is selected. |
| [OnOpen](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.MenuEvents-1.html#Syncfusion_Blazor_Navigations_MenuEvents_1_OnOpen) | Triggered before the ContextMenu opens (root and sub menus). |
| [Opened](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.MenuEvents-1.html#Syncfusion_Blazor_Navigations_MenuEvents_1_Opened) | Triggered after the ContextMenu is fully opened. |
| [OnClose](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.MenuEvents-1.html#Syncfusion_Blazor_Navigations_MenuEvents_1_OnClose) | Triggered before the ContextMenu closes. |
| [Closed](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.MenuEvents-1.html#Syncfusion_Blazor_Navigations_MenuEvents_1_Closed) | Triggered after the ContextMenu is fully closed. |

The handler receives a [MenuEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.MenuEventArgs-1.html) object that exposes properties such as `Item`, `Event`, `Name`, and `ParentItem`.

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


{% previewsample "https://blazorplayground.syncfusion.com/embed/VXVdjmiZJbXAPfth?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Binding Blazor ContextMenu Events](./../images/blazor-contextmenu-component.webp)" %}