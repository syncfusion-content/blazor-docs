---
layout: post
title: Enable or Disable ContextMenu Items in Blazor | Syncfusion
description: Learn here all about Enable/Disable Context Menu items in Syncfusion Blazor ContextMenu component and more.
platform: Blazor
control: Context Menu
documentation: ug
---

# Enable or Disable ContextMenu Items in Blazor Component

Menu items can be individually enabled or disabled using the [Disabled](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.MenuItem.html#Syncfusion_Blazor_Navigations_MenuItem_Disabled) property of a [MenuItem](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.MenuItem.html). To disable menuItems, set the [Disabled](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.MenuItem.html#Syncfusion_Blazor_Navigations_MenuItem_Disabled) property in each item to `true` and vice-versa.

In the following example, the **Display Settings** item is initially disabled. The **Medium Icons** sub-item within the **View** menu is dynamically enabled or disabled each time its sub-menu is opened.

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
};

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

{% previewsample "https://blazorplayground.syncfusion.com/embed/rtBUiVVGAalMSCbE?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Enabling or Disabling Items in Blazor ContextMenu](./../images/blazor-contextmenu-enable-disable-item.png)

N> To dynamically enable or disable sub-menu items, use the `OnOpen` event. This event fires just before a sub-menu is displayed, providing an opportunity to modify its items or properties.