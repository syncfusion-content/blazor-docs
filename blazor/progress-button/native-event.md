---
layout: post
title: Native Events in Blazor ProgressButton Component | Syncfusion
description: Checkout and learn here all about native events in Syncfusion Blazor ProgressButton component and more.
platform: Blazor
control: Progress Button
documentation: ug
---

# Native Events in Blazor ProgressButton Component

Define native DOM events on the component by using Blazor’s @on{event} attributes. The attribute value is an event handler method, and event-specific data is provided through strongly typed event argument objects.

The different event argument types for each event are:

* Focus Events - UIFocusEventArgs
* Mouse Events - UIMouseEventArgs
* Keyboard Events - UIKeyboardEventArgs
* Touch Events – UITouchEventArgs

## List of Native events supported

The following native event support has been provided to the Progress Button component:

| List of Native events |  |  | |
| --- | --- | --- | --- |
| onclick | onblur | onfocus | onfocusout |
|onmousemove|onmouseover|onmouseout|onmousedown|onmouseup|
|ondblclick|onkeydown|onkeyup|onkeypress|
|ontouchend|onfocusin|onmouseup|ontouchstart|

## How to bind click event to ProgressButton

The `onclick` attribute is used to bind the click event for Progress Button. Here, the sample code snippets of Progress Button has been explained.

```cshtml
@using Syncfusion.Blazor.SplitButtons

<SfProgressButton IsPrimary="true" @onclick="onClick" Content="Spin Left"></SfProgressButton>

@code {

    private void onClick(Microsoft.AspNetCore.Components.Web.MouseEventArgs args)
    {
        //onclick Event triggered
    }
}

```

## Trace Events in Blazor ProgressButton 

The ProgressButton component triggers lifecycle events that can be used as extension points to perform custom logic and update the UI.

The events available in ProgressButton are [OnFailure](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SplitButtons.ProgressButtonEvents.html#Syncfusion_Blazor_SplitButtons_ProgressButtonEvents_OnFailure), [OnBegin](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SplitButtons.ProgressButtonEvents.html#Syncfusion_Blazor_SplitButtons_ProgressButtonEvents_OnBegin), [Progressing](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SplitButtons.ProgressButtonEvents.html#Syncfusion_Blazor_SplitButtons_ProgressButtonEvents_Progressing), and [OnEnd](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SplitButtons.ProgressButtonEvents.html#Syncfusion_Blazor_SplitButtons_ProgressButtonEvents_OnEnd). OnBegin fires when progress starts, Progressing fires while the progress updates, OnEnd fires when progress completes, and OnFailure fires if the operation fails.

The following example wires the OnBegin, Progressing, and OnEnd events and displays the most recently triggered event in the UI. OnFailure is available but not shown in this sample.

```cshtml

@using Syncfusion.Blazor.SplitButtons

<div id="preview">@eventName Event Triggered</div>
<SfProgressButton Content="Progress">
    <ProgressButtonEvents OnBegin="Begin" OnEnd="End" Progressing="Progressing"></ProgressButtonEvents>
</SfProgressButton>

@code {
    private string eventName = "No";
    public void Begin(Syncfusion.Blazor.SplitButtons.ProgressEventArgs args)
    {
        eventName = "Begin";
    }
    public void End(Syncfusion.Blazor.SplitButtons.ProgressEventArgs args)
    {
        eventName = "End";
    }
    public void Progressing(Syncfusion.Blazor.SplitButtons.ProgressEventArgs args)
    {
        eventName = "Progressing";
    }
}

<style>
    #preview {
        float: right;
        padding: 0 350px 0 0;
    }
</style>

```

![Tracing Events in Blazor ProgressButton](./images/blazor-progressbutton-trace-event.webp)