---
layout: post
title: Events in Blazor SplitButton Component | Syncfusion
description: Checkout and learn here all about events in Syncfusion Blazor SplitButton component and much more details.
platform: Blazor
control: Split Button
documentation: ug
---

# Events in Blazor SplitButton Component

Handle Split Button events by defining handlers in the [SplitButtonEvents](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SplitButtons.SplitButtonEvents.html) tag. The assigned method names act as event handlers, and event-specific data is provided through strongly typed event argument classes.

## List of events supported

The Split Button component supports the following events and corresponding event argument types:

* Created - Initializes after the component is created.
* Clicked - Raised when the primary button is clicked. Argument type: Syncfusion.Blazor.SplitButtons.ClickEventArgs
* OnOpen - Raised before the popup opens. Argument type: BeforeOpenCloseMenuEventArgs
* Opened - Raised after the popup opens. Argument type: OpenCloseMenuEventArgs
* ItemSelected - Raised when a menu item is selected. Argument type: MenuEventArgs
* OnClose – Raised before the popup closes. Argument type: BeforeOpenCloseMenuEventArgs
* OnItemRender – Raised while rendering each menu item. Argument type: MenuEventArgs
* Closed – Raised after the popup closes. Argument type: OpenCloseMenuEventArgs

## How to bind event to Split Button

Bind the above events to the Split Button component using the SplitButtonEvents tag, as shown below.

```cshtml
@using Syncfusion.Blazor.SplitButtons

    <SfSplitButton Content="Profile">
        <SplitButtonEvents Created="Created" Clicked="Clicked" OnOpen="OnOpen" Opened="Opened" ItemSelected="ItemSelected" OnClose="OnClose" OnItemRender="ItemRender" Closed="Closed">
        </SplitButtonEvents>
        <DropDownMenuItems>
            <DropDownMenuItem Text="Cut"></DropDownMenuItem>
            <DropDownMenuItem Text="Copy"></DropDownMenuItem>
            <DropDownMenuItem Text="Paste"></DropDownMenuItem>
        </DropDownMenuItems>
    </SfSplitButton>


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

    private void Clicked(Syncfusion.Blazor.SplitButtons.ClickEventArgs args)
    {

    }
}


```