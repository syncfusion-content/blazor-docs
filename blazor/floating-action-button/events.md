---
layout: post
title: Events in Floating Action Button Component | Syncfusion
description: Checkout and learn here all about Native Events in Syncfusion Floating Action Button component and much more.
platform: Blazor
control: Floating Action Button
documentation: ug
---

# Events in Floating Action Button Component

This section explains the events available in the Floating Action Button component. The following events are covered: Created and OnClick.

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