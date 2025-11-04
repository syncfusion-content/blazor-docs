---
layout: post
title: Events in Blazor Dropdown Menu Component | Syncfusion
description: Checkout and learn here all about Events in Syncfusion Blazor Dropdown Menu component and much more.
platform: Blazor
control: Dropdown Menu
documentation: ug
---

# Events in Blazor Dropdown Menu Component

Attach event handlers to the Dropdown Menu using the [DropDownButtonEvents](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SplitButtons.DropDownButtonEvents.html#Syncfusion_Blazor_SplitButtons_DropDownButtonEvents) component. Each event accepts a handler whose parameter (if any) provides event-specific data through event arguments.

## List of events supported

The DropDownButton component supports the following events and argument types:


* [OnOpen](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SplitButtons.DropDownButtonEvents.html#Syncfusion_Blazor_SplitButtons_DropDownButtonEvents_OnOpen) - BeforeOpenCloseMenuEventArgs; raised before the dropdown menu opens.
* [Opened](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SplitButtons.DropDownButtonEvents.html#Syncfusion_Blazor_SplitButtons_DropDownButtonEvents_Opened) - OpenCloseMenuEventArgs; raised after the dropdown menu opens.
* [ItemSelected](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SplitButtons.DropDownButtonEvents.html#Syncfusion_Blazor_SplitButtons_DropDownButtonEvents_ItemSelected) - MenuEventArgs; raised when a menu item is selected.
* [OnClose](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SplitButtons.DropDownButtonEvents.html#Syncfusion_Blazor_SplitButtons_DropDownButtonEvents_OnClose) – BeforeOpenCloseMenuEventArgs; raised before the dropdown menu closes.
* [OnItemRender](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SplitButtons.DropDownButtonEvents.html#Syncfusion_Blazor_SplitButtons_DropDownButtonEvents_OnItemRender) – MenuEventArgs; raised while rendering each menu item.
* [Closed](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SplitButtons.DropDownButtonEvents.html#Syncfusion_Blazor_SplitButtons_DropDownButtonEvents_Closed) – OpenCloseMenuEventArgs; raised after the dropdown menu closes.

## How to bind event to Dropdown Menu

Bind the above events to the Dropdown Menu by specifying handlers in the DropDownButtonEvents tag. Ensure each handler matches the expected delegate signature for the corresponding event. The following example demonstrates wiring all supported events:

```cshtml
@using Syncfusion.Blazor.SplitButtons

<SfDropDownButton Content="Profile">
    <DropDownButtonEvents Created="Created" OnOpen="OnOpen" Opened="Opened" ItemSelected="ItemSelected" OnClose="OnClose" OnItemRender="ItemRender" Closed="Closed">
    </DropDownButtonEvents>
    <DropDownMenuItems>
        <DropDownMenuItem Text="Dashboard" Id="Dashboard"></DropDownMenuItem>
        <DropDownMenuItem Text="Notifications" Id="Notifications"></DropDownMenuItem>
        <DropDownMenuItem Text="User Settings" Id="UserSettings"></DropDownMenuItem>
        <DropDownMenuItem Text="Log Out" Id="LogOut"></DropDownMenuItem>
    </DropDownMenuItems>
</SfDropDownButton>

@code {

    private void Created()
    {

    }

    private void OnOpen(BeforeOpenCloseMenuEventArgs args)
    {

    }

    private void Opened(OpenCloseMenuEventArgs args)
    {

    }

    private void ItemSelected(MenuEventArgs args)
    {

    }

    private void OnClose(BeforeOpenCloseMenuEventArgs args)
    {

    }

    private void ItemRender(MenuEventArgs args)
    {

    }

    private void Closed(OpenCloseMenuEventArgs args)
    {

    }
}

```