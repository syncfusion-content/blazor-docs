---
layout: post
title: Events in Floating Action Button Component | Syncfusion
description: Checkout and learn here all about Native Events in Syncfusion Floating Action Button component and much more.
platform: Blazor
control: Floating Action Button
documentation: ug
---

# Events in Floating Action Button Component

This section explains the available events in Floating Action Button Component.

## Created

Event triggers after the creation of Floating Action Button.

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

Event triggers when the Floating Action Button is clicked. Below example shows the Click event of the Floating Action Button.

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



