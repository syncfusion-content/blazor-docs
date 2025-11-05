---
layout: post
title: Events in Blazor SplitButton Component | Syncfusion
description: Checkout and learn here all about events in Syncfusion Blazor SplitButton component and much more details.
platform: Blazor
control: Split Button
documentation: ug
---

# Events in Blazor SplitButton Component

The split button event can be defined using on [SplitButtonEvents](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SplitButtons.SplitButtonEvents.html) in component. The value of event is treated as an event handler. The event specific data will be available in event arguments.

## List of events supported

The following event support is provided to the SplitButton component. The different event argument types for each event are,

* OnOpen - BeforeOpenCloseMenuEventArgs
* Opened - OpenCloseMenuEventArgs
* ItemSelected - MenuEventArgs
* OnClose – BeforeOpenCloseMenuEventArgs
* OnItemRender – MenuEventArgs
* Closed – OpenCloseMenuEventArgs

## How to bind event to Split Button

Above defined events bind the Split Button component. Here, we have explained about the sample code snippets of SplitButton.

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