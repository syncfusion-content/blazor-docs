---
layout: post
title: Trace Events in Blazor ProgressButton Component | Syncfusion
description: Learn here all about trace events of Progress Button in Syncfusion Blazor ProgressButton component and more.
platform: Blazor
control: Progress Button
documentation: ug
---

# Trace Events in Blazor ProgressButton Component

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

![Tracing Events in Blazor ProgressButton](./../images/blazor-progressbutton-trace-event.png)