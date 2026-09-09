---
layout: post
title: How to create a repeat button in Blazor Button | Syncfusion®
description: Implement a Blazor Repeat Button that fires click events at regular intervals while pressed, and customize it with mouse, touch, and timer-based events.
platform: Blazor
control: Button
documentation: ug
---

# How to create a repeat button in Blazor Button

A Blazor Repeat Button is a type of Button in which the click event is triggered at regular time intervals from the pressed state until the released state.

The following example demonstrates how to implement a Blazor Repeat Button using both mouse and touch events.

```csharp

@using Syncfusion.Blazor.Buttons
@using System.Timers

<div id="button">
    <SfButton Content="Button" oncontextmenu="return false;" @onmousedown='OnMouseDown ' @ontouchstart='OnMouseDown ' @onmouseup='OnMouseUp' @ontouchend='OnMouseUp'></SfButton>
</div>
<div id="preview">@EventName Event triggered - @Count times</div>

@code {
    public string EventName = "";
    public int Count = 0;
    private static Timer aTimer;
    public void Click(Object source, System.Timers.ElapsedEventArgs e)
    {
        EventName = "Click";
        Count++;
        InvokeAsync(StateHasChanged);
    }
    public void OnMouseDown ()
    {
        aTimer = new System.Timers.Timer();
        aTimer.Interval = 200;
        aTimer.Elapsed += Click;
        aTimer.AutoReset = true;
        aTimer.Start();
    }
    public void OnMouseUp()
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/htBHXHMBVAFlkGSe?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Repeat Button in Blazor Button Component](./../images/blazor-button-with-repeat-button.webp)" %}

## How it works

1. On `OnMouseDown `, a `System.Timers.Timer` is started with a 200 ms interval.
2. Each tick of the timer invokes `Click`, which increments the counter and updates the UI.
3. On `OnMouseUp`, the timer is stopped and disposed.
4. The component also implements `IDisposable` to ensure the timer is released when the component is removed from the page.

## See also

* [Native Events in Blazor Button](../native-event.md)
* [Types and Styles in Blazor Button](../types-and-styles.md)
* [Blazor Button API reference](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfButton.html)