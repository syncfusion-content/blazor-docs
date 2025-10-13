---
layout: post
title: Repeat Button in Blazor Button Component | Syncfusion
description: Checkout and learn here all about Repeat Button in Syncfusion Blazor Button component and much more.
platform: Blazor
control: Button
documentation: ug
---

# Repeat Button in Blazor Button Component

A repeat button triggers its action at a regular interval while the button remains pressed (mouse or touch) and stops when released.

The following example demonstrates how to achieve a repeat button using mouse and touch events with a timer that raises a click action at a fixed interval until the press ends.

```csharp

@using Syncfusion.Blazor.Buttons
@using System.Timers

<div id="button">
    <SfButton Content="Button" oncontextmenu="return false;" @onmousedown='mousedown' @ontouchstart='mousedown' @onmouseup='mouseup' @ontouchend='mouseup'></SfButton>
</div>
<div id="preview">@EventName Event triggered - @Count times</div>

@code{
    public string EventName = "";
    public int Count = 0;
    private static Timer aTimer;
    public void Click(Object source, System.Timers.ElapsedEventArgs e)
    {
        EventName = "Click";
        Count++;
        InvokeAsync(StateHasChanged);
    }
    public void mousedown()
    {
        aTimer = new System.Timers.Timer();
        aTimer.Interval = 200;
        aTimer.Elapsed += Click;
        aTimer.AutoReset = true;
        aTimer.Start();
    }
    public void mouseup()
    {
        aTimer.Stop();
        aTimer.Dispose();
    }
}

<style>
    #preview {
        float: right;
        padding: 0 350px 0 0;
    }
</style>

```

{% previewsample "https://blazorplayground.syncfusion.com/embed/rtrUCVhhiGkNFPZK?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor repeat button that triggers repeatedly while pressed](./../images/blazor-button-with-repeat-button.png)