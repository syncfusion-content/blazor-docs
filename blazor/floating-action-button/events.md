---
layout: post
title: Events in FloatingActionButton Component | Syncfusion
description: Checkout and learn here all about Native Events in Syncfusion FloatingActionButton component and much more.
platform: Blazor
control: FloatingActionButton
documentation: ug
---

# Events in Floating Action Button Component

This section explains the available events in Floating Action Button Component.

## Created

Event triggers after the creation of Floating Action Button.

```cshtml

@using Syncfusion.Blazor.Buttons

<div id="target" style="height:250px; position:relative; width:300px; border:1px solid;">
    <SfFab IconCss="e-icons e-edit" Content="Edit" Created="Created"></SfFab>
</div>

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

<div id="target" style="height:250px; position:relative; width:300px; border:1px solid;">
    <SfFab IconCss="e-icons e-edit" Content="Edit" OnClick="EventClick"></SfFab>
</div>

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



