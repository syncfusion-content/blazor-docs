---
layout: post
title: Events in Floating Action Button Component | Syncfusion®
description: Checkout and learn here all about Native Events in Floating Action Button component and much more details.
platform: Blazor
control: Floating Action Button
documentation: ug
---

# Events in Blazor Floating Action Button Component

The Floating Action Button component exposes the following events: `OnClick` and `Created`. Use these events to handle user interactions and component lifecycle.

## OnClick

Raised when the Floating Action Button is activated by a user action, including mouse click, keyboard activation (Enter/Space), or touch. The example below demonstrates handling the click event.

```cshtml

@using Syncfusion.Blazor.Buttons

<SfFab IconCss="e-icons e-edit" Content="Edit" OnClick="EventClick"></SfFab>

<label>Event log</label>
<div style="border:1px solid;min-height:20px;"> @((MarkupString)log)</div>

@code{
    private string log = "";
    public void EventClick()
    {
        // Here, you can call your desired action.
        log = log + "Fab Clicked.<br/>";
    }
}

```

## Created

Raised after the Floating Action Button has been created and its initial rendering is complete. Use this event to run setup logic or access the component once it is available in the UI.

```cshtml

@using Syncfusion.Blazor.Buttons

<SfFab IconCss="e-icons e-edit" Content="Edit" Created="Created"></SfFab>

@code{
    public void Created()
    {
        // Your required action here
    }
}

```

## See also

* [Getting started with Blazor Floating Action Button](./getting-started)
* [Styles in Blazor Floating Action Button](./styles)
* [Icons in Blazor Floating Action Button](./icons)