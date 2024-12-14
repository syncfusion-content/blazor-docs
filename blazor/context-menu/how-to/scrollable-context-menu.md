---
layout: post
title: Render Scrollable Context Menu in Blazor ContextMenu Component | Syncfusion
description: Checkout and learn here all about Render Scrollable Context Menu in Syncfusion Blazor ContextMenu component and more.
platform: Blazor
control: Context Menu
documentation: ug
---

# Render Scrollable Context Menu in Blazor ContextMenu Component

To enable scrolling for the Context Menu, use the [EnableScrolling](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfContextMenu-1.html#Syncfusion_Blazor_Navigations_SfContextMenu_1_EnableScrolling) property to manage the overflow behavior of menu items by enabling or disabling scroll functionality. This is especially useful when dealing with a large number of menu items that exceed the viewport height, ensuring the context menu remains accessible without affecting the page layout.

To achieve this functionality, set the `EnableScrolling` property to `true`. Additionally, use the [`BeforeOpenCloseMenuEventArg`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.MenuEvents-1.html#Syncfusion_Blazor_Navigations_MenuEvents_1_BeforeOpenCloseMenuEventArg.html) event to adjust the height of the menu's parent element, ensuring the scrollable area is applied correctly.

```cshtml
@using Syncfusion.Blazor.Navigations

<SfContextMenu Target="#target" TValue="MenuItem" CssClass="custom" EnableScrolling="true" BeforeOpen="OnBeforeOpen">
    <MenuEvents TValue="MenuItem" OnOpen="@OnBeforeOpen"></MenuEvents>
    <MenuItems>
        <MenuItem Text="View">
            <MenuItems>
                <MenuItem Text="Mobile" />
                <MenuItem Text="Desktop Smaller" />
                <MenuItem Text="Desktop Normal" />
                <MenuItem Text="Desktop Bigger Smaller" />
                <MenuItem Text="Desktop Bigger Normal" />
            </MenuItems>
        </MenuItem>
        <MenuItem Text="Refresh" />
        <MenuItem Text="Paste" />
        <MenuItem Separator="true" />
        <MenuItem Text="New" />
        <MenuItem Text="Personalize" />
    </MenuItems>
</SfContextMenu>

<div id="target">Right click/Touch hold to open the ContextMenu </div>

@code {
    private void OnBeforeOpen(BeforeOpenCloseMenuEventArgs<MenuItem> args)
    {
        args.ScrollHeight = 150;
    }
}

<style>
    #target {
        border: 1px dashed;
        height: 250px;
        padding: 10px;
        position: relative;
        text-align: center;
        color: gray;
        line-height: 17;
        font-size: 14px;
    }
</style>

```

![Blazor ContextMenu with Scroller Support](./../images/blazor-contextmenu-scroller.png)