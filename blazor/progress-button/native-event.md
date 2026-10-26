---
layout: post
title: Native Events in Blazor Progress Button | Syncfusion
description: Bind native DOM events such as focus, mouse, keyboard, and touch to Blazor Progress Button for advanced interactivity and custom integration.
platform: Blazor
control: Progress Button
documentation: ug
---

# Native Events in Blazor Progress Button

Define native DOM events on the component by using Blazor’s @on{event} attributes. The attribute value is an event handler method, and event-specific data is provided through strongly typed event argument objects.

The different event argument types for each event are:

* Focus Events - UIFocusEventArgs
* Mouse Events - UIMouseEventArgs
* Keyboard Events - UIKeyboardEventArgs
* Touch Events - UITouchEventArgs

## List of native events supported

The following native events are supported by the Blazor  Progress Button component:

| List of Native events | | | |
| --- | --- | --- | --- | --- |
| onclick | onmousedown | onmouseup | onmouseover |
| onmouseout | onmousemove | onkeydown | onkeypress |
| onkeyup | onfocus | onblur | onfocusin |
| onfocusout | ontouchstart | ontouchend | |

## How to bind click event to Blazor  Progress Button

The `onclick` event fires when the Blazor  Progress Button is clicked with a mouse or activated via keyboard. It is the primary event used to trigger the button's action, initiate an async operation, or start the progress animation.

```cshtml
@using Syncfusion.Blazor.SplitButtons

<SfProgressButton IsPrimary="true" @onclick="OnClick" Content="Spin Left"></SfProgressButton>
<p>@Message</p>

@code {
    public string Message = "";

    private void OnClick(Microsoft.AspNetCore.Components.Web.MouseEventArgs args)
    {
        Message = $"Button clicked at X: {args.ClientX}, Y: {args.ClientY}";
    }
}
```

## How to bind mousedown event to Blazor  Progress Button

The `onmousedown` event fires the moment a mouse button is pressed down on the Blazor  Progress Button, before it is released. It is used for press-and-hold interactions or to track when the user begins pressing the button.

```cshtml
@using Syncfusion.Blazor.SplitButtons

<SfProgressButton IsPrimary="true" @onmousedown="OnMouseDown" Content="Press Me"></SfProgressButton>
<p>@Message</p>

@code {
    public string Message = "";

    private void OnMouseDown(Microsoft.AspNetCore.Components.Web.MouseEventArgs args)
    {
        Message = $"Mouse button {args.Button} pressed down.";
    }
}
```

## How to bind mouseup event to Blazor  Progress Button

The `onmouseup` event fires when a mouse button is released after being pressed on the Blazor  Progress Button. It complements `onmousedown` and is used to detect the end of a press interaction.

```cshtml
@using Syncfusion.Blazor.SplitButtons

<SfProgressButton IsPrimary="true" @onmouseup="OnMouseUp" Content="Release Me"></SfProgressButton>
<p>@Message</p>

@code {
    public string Message = "";

    private void OnMouseUp(Microsoft.AspNetCore.Components.Web.MouseEventArgs args)
    {
        Message = $"Mouse button {args.Button} released.";
    }
}
```

## How to bind mouseover event to Blazor  Progress Button

The `onmouseover` event fires when the mouse pointer enters the Blazor  Progress Button or any of its child elements. It is typically used to show tooltips or apply hover-based visual changes.

```cshtml
@using Syncfusion.Blazor.SplitButtons

<SfProgressButton IsPrimary="true" @onmouseover="OnMouseOver" Content="Hover Over Me"></SfProgressButton>
<p>@Message</p>

@code {
    public string Message = "";

    private void OnMouseOver(Microsoft.AspNetCore.Components.Web.MouseEventArgs args)
    {
        Message = "Mouse is over the button.";
    }
}
```

## How to bind mouseout event to Blazor  Progress Button

The `onmouseout` event fires when the mouse pointer leaves the Blazor  Progress Button or one of its child elements. It is commonly paired with `onmouseover` to reset hover-based styles or hide tooltips.

```cshtml
@using Syncfusion.Blazor.SplitButtons

<SfProgressButton IsPrimary="true" @onmouseout="OnMouseOut" Content="Move Away"></SfProgressButton>
<p>@Message</p>

@code {
    public string Message = "";

    private void OnMouseOut(Microsoft.AspNetCore.Components.Web.MouseEventArgs args)
    {
        Message = "Mouse has left the button.";
    }
}
```

## How to bind mousemove event to Blazor  Progress Button

The `onmousemove` event fires continuously as the mouse pointer moves over the Blazor  Progress Button. It is useful for tracking the cursor position within the button area or implementing custom interactive hover effects.

```cshtml
@using Syncfusion.Blazor.SplitButtons

<SfProgressButton IsPrimary="true" @onmousemove="OnMouseMove" Content="Move Mouse Here"></SfProgressButton>
<p>@Message</p>

@code {
    public string Message = "";

    private void OnMouseMove(Microsoft.AspNetCore.Components.Web.MouseEventArgs args)
    {
        Message = $"Mouse position — X: {args.OffsetX:F0}, Y: {args.OffsetY:F0}";
    }
}
```

## How to bind keydown event to Blazor  Progress Button

The `onkeydown` event fires when any key is pressed while the Blazor  Progress Button has focus. It is used to implement keyboard shortcuts, intercept specific key presses, or prevent default key behavior.

```cshtml
@using Syncfusion.Blazor.SplitButtons

<SfProgressButton IsPrimary="true" @onkeydown="OnKeyDown" Content="Focus & Press Key"></SfProgressButton>
<p>@Message</p>

@code {
    public string Message = "";

    private void OnKeyDown(Microsoft.AspNetCore.Components.Web.KeyboardEventArgs args)
    {
        Message = $"Key down: {args.Key} (Code: {args.Code})";
    }
}
```

## How to bind keypress event to Blazor  Progress Button 

The `onkeypress` event fires when a key that produces a character value is pressed while the Blazor  Progress Button has focus. Note that this event is deprecated in modern web standards and does not fire for non-printable keys such as `Shift`, `Ctrl`, or arrow keys. Use `onkeydown` for broader key handling.

```cshtml
@using Syncfusion.Blazor.SplitButtons

<SfProgressButton IsPrimary="true" @onkeypress="OnKeyPress" Content="Focus & Press Key"></SfProgressButton>
<p>@Message</p>

@code {
    public string Message = "";

    private void OnKeyPress(Microsoft.AspNetCore.Components.Web.KeyboardEventArgs args)
    {
        Message = $"Key pressed: {args.Key}";
    }
}
```

## How to bind keyup event to Blazor  Progress Button 

The `onkeyup` event fires when a key is released after being pressed while the Blazor  Progress Button has focus. It is used to detect the completion of a key interaction or to trigger an action when a specific key is released.

```cshtml
@using Syncfusion.Blazor.SplitButtons

<SfProgressButton IsPrimary="true" @onkeyup="OnKeyUp" Content="Focus & Release Key"></SfProgressButton>
<p>@Message</p>

@code {
    public string Message = "";

    private void OnKeyUp(Microsoft.AspNetCore.Components.Web.KeyboardEventArgs args)
    {
        Message = $"Key released: {args.Key}";
    }
}
```

## How to bind focus event to Blazor  Progress Button

The `onfocus` event fires when the Blazor  Progress Button receives focus, either through a mouse click or keyboard navigation (e.g., `Tab` key). It is used to display contextual hints or apply focus-related visual changes.

```cshtml
@using Syncfusion.Blazor.SplitButtons

<SfProgressButton IsPrimary="true" @onfocus="OnFocus" Content="Click or Tab to Focus"></SfProgressButton>
<p>@Message</p>

@code {
    public string Message = "";

    private void OnFocus(Microsoft.AspNetCore.Components.Web.FocusEventArgs args)
    {
        Message = "Button is focused.";
    }
}
```

## How to bind blur event to Blazor  Progress Button

The `onblur` event fires when the Blazor  Progress Button loses focus, typically when the user clicks elsewhere or tabs to another element. It is used to validate state, hide focus indicators, or reset UI changes applied during focus.

```cshtml
@using Syncfusion.Blazor.SplitButtons

<SfProgressButton IsPrimary="true" @onblur="OnBlur" Content="Click Then Click Away"></SfProgressButton>
<p>@Message</p>

@code {
    public string Message = "";

    private void OnBlur(Microsoft.AspNetCore.Components.Web.FocusEventArgs args)
    {
        Message = "Button lost focus.";
    }
}
```

## How to bind focusin event to Blazor  Progress Button

The `onfocusin` event fires when the Blazor  Progress Button or any of its child elements receives focus. Unlike `onfocus`, this event bubbles up the DOM, making it suitable for detecting focus within a container or handling delegated focus scenarios.

```cshtml
@using Syncfusion.Blazor.SplitButtons

<SfProgressButton IsPrimary="true" @onfocusin="OnFocusIn" Content="Focus In"></SfProgressButton>
<p>@Message</p>

@code {
    public string Message = "";

    private void OnFocusIn(Microsoft.AspNetCore.Components.Web.FocusEventArgs args)
    {
        Message = "Focus moved into the button (focusin).";
    }
}
```

## How to bind focusout event to Blazor  Progress Button

The `onfocusout` event fires when the Blazor  Progress Button or any of its child elements loses focus. Unlike `onblur`, this event bubbles, making it useful for tracking when focus leaves a group of related elements.

```cshtml
@using Syncfusion.Blazor.SplitButtons

<SfProgressButton IsPrimary="true" @onfocusout="OnFocusOut" Content="Focus Out"></SfProgressButton>
<p>@Message</p>

@code {
    public string Message = "";

    private void OnFocusOut(Microsoft.AspNetCore.Components.Web.FocusEventArgs args)
    {
        Message = "Focus moved out of the button (focusout).";
    }
}
```

## Trace Events in Blazor Progress Button  

The Blazor  Progress Button  component triggers lifecycle events that can be used as extension points to perform custom logic and update the UI.

The events available in Blazor  Progress Button  are [OnFailure](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SplitButtons.ProgressButtonEvents.html#Syncfusion_Blazor_SplitButtons_ProgressButtonEvents_OnFailure), [OnBegin](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SplitButtons.ProgressButtonEvents.html#Syncfusion_Blazor_SplitButtons_ProgressButtonEvents_OnBegin), [Progressing](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SplitButtons.ProgressButtonEvents.html#Syncfusion_Blazor_SplitButtons_ProgressButtonEvents_Progressing), and [OnEnd](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SplitButtons.ProgressButtonEvents.html#Syncfusion_Blazor_SplitButtons_ProgressButtonEvents_OnEnd). OnBegin fires when progress starts, Progressing fires while the progress updates, OnEnd fires when progress completes, and OnFailure fires if the operation fails.

The following example wires the OnBegin, Progressing, and OnEnd events and starts the progress programmatically so the events fire. OnFailure is available but not shown in this sample.

```cshtml

@using Syncfusion.Blazor.SplitButtons

<div id="preview">@eventName Event Triggered</div>
<SfProgressButton Content="Progress" EnableProgress="true" @ref="ProgressBtnObj">
    <ProgressButtonEvents OnBegin="Begin" OnEnd="End" Progressing="Progressing"></ProgressButtonEvents>
</SfProgressButton>
<SfButton @onclick="StartProgress">Start Progress</SfButton>

@code {
    private string eventName = "No";
    SfProgressButton ProgressBtnObj;
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
    private async Task StartProgress()
    {
        await ProgressBtnObj.StartAsync(2000);
    }
}

<style>
    #preview {
        float: right;
        padding: 0 350px 0 0;
    }
</style>

```

![Tracing Events in Blazor Progress Button](./images/blazor-progressbutton-trace-event.webp)