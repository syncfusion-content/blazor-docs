---
layout: post
title: Events in Blazor Dropdown Menu Component | Syncfusion
description: Checkout and learn here all about Events in Syncfusion Blazor Dropdown Menu component and much more.
platform: Blazor
control: Dropdown Menu
documentation: ug
---

# Events in Blazor Dropdown Menu Component

You can define the dropdown menu event using on [DropDownButtonEvents](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SplitButtons.DropDownButtonEvents.html#Syncfusion_Blazor_SplitButtons_DropDownButtonEvents) in component. The value of event is treated as an event handler. The event specific data will be available in event arguments.

## List of events supported

We have provided the following event support to the DropDownButton component. The different event argument types for each event are,

* [OnOpen](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SplitButtons.DropDownButtonEvents.html#Syncfusion_Blazor_SplitButtons_DropDownButtonEvents_OnOpen) - BeforeOpenCloseMenuEventArgs
* [Opened](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SplitButtons.DropDownButtonEvents.html#Syncfusion_Blazor_SplitButtons_DropDownButtonEvents_Opened) - OpenCloseMenuEventArgs
* [ItemSelected](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SplitButtons.DropDownButtonEvents.html#Syncfusion_Blazor_SplitButtons_DropDownButtonEvents_ItemSelected) - MenuEventArgs
* [OnClose](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SplitButtons.DropDownButtonEvents.html#Syncfusion_Blazor_SplitButtons_DropDownButtonEvents_OnClose) – BeforeOpenCloseMenuEventArgs
* [OnItemRender](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SplitButtons.DropDownButtonEvents.html#Syncfusion_Blazor_SplitButtons_DropDownButtonEvents_OnItemRender) – MenuEventArgs
* [Closed](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SplitButtons.DropDownButtonEvents.html#Syncfusion_Blazor_SplitButtons_DropDownButtonEvents_Closed) – OpenCloseMenuEventArgs

## How to bind event to Dropdown Menu

Above defined events are bind the Dropdown Menu component. Here, we have explained about the sample code snippets of Dropdown Menu.

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