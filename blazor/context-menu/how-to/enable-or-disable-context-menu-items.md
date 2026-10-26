---
layout: post
title: How to enable or disable items in Blazor Context Menu | Syncfusion®
description: Enable or disable individual Blazor Context Menu items at design time or runtime by setting the Disabled property of the MenuItem.
platform: Blazor
control: Context Menu
documentation: ug
---

# How to enable or disable items in Blazor Context Menu

You can enable and disable the menu items using the [Disabled](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.MenuItem.html#Syncfusion_Blazor_Navigations_MenuItem_Disabled) property in [MenuItem](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.MenuItem.html). To disable menuItems, set the [Disabled](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.MenuItem.html#Syncfusion_Blazor_Navigations_MenuItem_Disabled) property in each item to `true` and vice-versa.

In the following example, the **Display Settings** parent item is disabled during initial loading and the **Medium Icons** sub menu item is enabled/disabled dynamically while opening the sub menu.

```cshtml

@using Syncfusion.Blazor.Navigations

<div id="target">Right click/Touch hold to open the ContextMenu </div>
<SfContextMenu Target="#target" TValue="MenuItem">
    <MenuItems>
        <MenuItem Text="View">
            <MenuItems>
                <MenuItem Text="Large Icons"></MenuItem>
                <MenuItem Text="Medium Icons" Disabled="@disableState"></MenuItem>
                <MenuItem Text="Small Icons"></MenuItem>
            </MenuItems>
        </MenuItem>
        <MenuItem Text="Sort By"></MenuItem>
        <MenuItem Text="Refresh"></MenuItem>
        <MenuItem Separator="true"></MenuItem>
        <MenuItem Text="New"></MenuItem>
        <MenuItem Separator="true"></MenuItem>
        <MenuItem Text="Display Settings" Disabled="true"></MenuItem>
        <MenuItem Text="Personalize"></MenuItem>
    </MenuItems>
    <MenuEvents TValue="MenuItem" OnOpen="@BeforeOpenHandler"></MenuEvents>
</SfContextMenu>

@code {
    private bool disableState;

    private void BeforeOpenHandler(BeforeOpenCloseMenuEventArgs<MenuItem> e)
    {
        // While opening the first level context menu the parent item will not be available, so it would be null.
        if (e.ParentItem != null && e.ParentItem.Text == "View")
            disableState = !disableState; // Execute only for the View item sub menu.
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/VZrxtRWupOwRWZMh?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Enabling or Disabling Items in Blazor Context Menu](./../images/blazor-contextmenu-enable-disable-item.webp)" %}

N> To disable sub menu items, use the `OnOpen` event.
