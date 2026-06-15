---
layout: post
title: Native Events in Blazor Button Component | Syncfusion®
description: Checkout and learn here all features about native events support in Blazor Button component, it's elements and more.
platform: Blazor
control: Button
documentation: ug
---

# Native Events in Blazor Button Component

You can define the native event using `event` attribute in component. The value of attribute is treated as an event handler. The event specific data will be available in event arguments.

The different event argument types for each event are,

* Focus Events - UIFocusEventArgs
* Mouse Events - UIMouseEventArgs
* Keyboard Events - UIKeyboardEventArgs
* Touch Events – UITouchEventArgs

## List of native events supported

The following native event support has been provided to the Button component:

| List of Native events |  |  |  |  |
| --- | --- | --- | --- | --- |
| onclick | ondblclick | onmousedown | onmouseup | onmouseover |
| onmouseout | onmousemove | onmouseenter | onmouseleave | oncontextmenu |
| onkeydown | onkeypress | onkeyup | onfocus | onblur |
| onfocusin | onfocusout | ontouchstart | ontouchend | |

## How to bind click event to Button

The `onclick` event fires when the user clicks the button with a mouse or activates it via keyboard. It is the most commonly used event for triggering actions such as form submission, navigation, or toggling UI state.

```csharp
@using Syncfusion.Blazor.Buttons

<SfButton @ref="ToggleBtn" @onclick="OnToggleClick" CssClass="e-flat" IsToggle="true" IsPrimary="true" Content="@Content"></SfButton>

@code {
    SfButton ToggleBtn;
    public string Content = "Play";

    private void OnToggleClick(Microsoft.AspNetCore.Components.Web.MouseEventArgs args)
    {
        Content = (ToggleBtn.Content == "Play") ? "Pause" : "Play";
    }
}
```

## How to bind double-click event to Button

The `ondblclick` event fires when the user rapidly clicks the button twice in quick succession. It is useful for triggering actions that should only occur on deliberate double-click gestures, such as expanding a panel or confirming a selection.

```csharp
@using Syncfusion.Blazor.Buttons

<SfButton @ondblclick="OnDoubleClick" Content="Double Click Me" IsPrimary="true"></SfButton>
<p>@Message</p>

@code {
    public string Message = "";

    private void OnDoubleClick(Microsoft.AspNetCore.Components.Web.MouseEventArgs args)
    {
        Message = $"Double-clicked at position X: {args.ClientX}, Y: {args.ClientY}";
    }
}
```

## How to bind mousedown event to Button

The `onmousedown` event fires the moment a mouse button is pressed down on the Button element, before the mouse button is released. It is useful for implementing press-and-hold interactions or initiating drag operations.

```csharp
@using Syncfusion.Blazor.Buttons

<SfButton @onmousedown="OnMouseDown" Content="Press Me" IsPrimary="true"></SfButton>
<p>@Message</p>

@code {
    public string Message = "";

    private void OnMouseDown(Microsoft.AspNetCore.Components.Web.MouseEventArgs args)
    {
        Message = $"Mouse button {args.Button} pressed down.";
    }
}
```

## How to bind mouseup event to Button

The `onmouseup` event fires when a mouse button is released after being pressed over the Button element. It complements `onmousedown` and can be used to complete press-and-hold interactions or detect the end of a drag gesture.

```csharp
@using Syncfusion.Blazor.Buttons

<SfButton @onmouseup="OnMouseUp" Content="Release Me" IsPrimary="true"></SfButton>
<p>@Message</p>

@code {
    public string Message = "";

    private void OnMouseUp(Microsoft.AspNetCore.Components.Web.MouseEventArgs args)
    {
        Message = $"Mouse button {args.Button} released.";
    }
}
```

## How to bind mouseover event to Button

The `onmouseover` event fires when the mouse pointer enters the Button element or any of its child elements. It is commonly used to show tooltips, highlight elements, or trigger hover-based UI effects.

```csharp
@using Syncfusion.Blazor.Buttons

<SfButton @onmouseover="OnMouseOver" Content="Hover Over Me" IsPrimary="true"></SfButton>
<p>@Message</p>

@code {
    public string Message = "";

    private void OnMouseOver(Microsoft.AspNetCore.Components.Web.MouseEventArgs args)
    {
        Message = "Mouse is over the button.";
    }
}
```

## How to bind mouseout event to Button

The `onmouseout` event fires when the mouse pointer leaves the Button element or one of its child elements. It is typically paired with `onmouseover` to reset styles or hide hover-based UI elements when the pointer moves away.

```csharp
@using Syncfusion.Blazor.Buttons

<SfButton @onmouseout="OnMouseOut" Content="Move Away" IsPrimary="true"></SfButton>
<p>@Message</p>

@code {
    public string Message = "";

    private void OnMouseOut(Microsoft.AspNetCore.Components.Web.MouseEventArgs args)
    {
        Message = "Mouse has left the button.";
    }
}
```

## How to bind mousemove event to Button

The `onmousemove` event fires continuously as the mouse pointer moves over the Button element. It is useful for tracking cursor position within the button area or creating custom interactive hover effects.

```csharp
@using Syncfusion.Blazor.Buttons

<SfButton @onmousemove="OnMouseMove" Content="Move Mouse Here" IsPrimary="true"></SfButton>
<p>@Message</p>

@code {
    public string Message = "";

    private void OnMouseMove(Microsoft.AspNetCore.Components.Web.MouseEventArgs args)
    {
        Message = $"Mouse position — X: {args.OffsetX:F0}, Y: {args.OffsetY:F0}";
    }
}
```

## How to bind mouseenter event to Button

The `onmouseenter` event fires when the mouse pointer enters the Button element. Unlike `onmouseover`, it does not bubble, meaning it only fires for the button itself and not for any child elements inside it.

```csharp
@using Syncfusion.Blazor.Buttons

<SfButton @onmouseenter="OnMouseEnter" Content="Enter Button" IsPrimary="true"></SfButton>
<p>@Message</p>

@code {
    public string Message = "";

    private void OnMouseEnter(Microsoft.AspNetCore.Components.Web.MouseEventArgs args)
    {
        Message = "Mouse entered the button area.";
    }
}
```

## How to bind mouseleave event to Button

The `onmouseleave` event fires when the mouse pointer leaves the Button element. Unlike `onmouseout`, it does not bubble, so it only triggers when the pointer actually exits the button boundary, not when moving between child elements.

```csharp
@using Syncfusion.Blazor.Buttons

<SfButton @onmouseleave="OnMouseLeave" Content="Leave Button" IsPrimary="true"></SfButton>
<p>@Message</p>

@code {
    public string Message = "";

    private void OnMouseLeave(Microsoft.AspNetCore.Components.Web.MouseEventArgs args)
    {
        Message = "Mouse left the button area.";
    }
}
```

## How to bind contextmenu event to Button

The `oncontextmenu` event fires when the user right-clicks the Button element, triggering the browser's context menu. It is used to intercept the right-click action and display a custom context menu or perform a specific operation.

```csharp
@using Syncfusion.Blazor.Buttons

<SfButton @oncontextmenu="OnContextMenu" @oncontextmenu:preventDefault="true" Content="Right Click Me" IsPrimary="true"></SfButton>
<p>@Message</p>

@code {
    public string Message = "";

    private void OnContextMenu(Microsoft.AspNetCore.Components.Web.MouseEventArgs args)
    {
        Message = $"Context menu triggered at X: {args.ClientX}, Y: {args.ClientY}";
    }
}
```

## How to bind keydown event to Button

The `onkeydown` event fires when any key is pressed down while the Button has focus. It is useful for implementing keyboard shortcuts, preventing default key behavior, or handling navigation within a component.

```csharp
@using Syncfusion.Blazor.Buttons

<SfButton @onkeydown="OnKeyDown" Content="Focus & Press Key" IsPrimary="true"></SfButton>
<p>@Message</p>

@code {
    public string Message = "";

    private void OnKeyDown(Microsoft.AspNetCore.Components.Web.KeyboardEventArgs args)
    {
        Message = $"Key down: {args.Key} (Code: {args.Code})";
    }
}
```

## How to bind keypress event to Button

The `onkeypress` event fires when a key that produces a character value is pressed while the Button has focus. Note that this event is deprecated in modern web standards and may not fire for non-printable keys such as `Shift`, `Ctrl`, or arrow keys. Use `onkeydown` for broader key handling.

```csharp
@using Syncfusion.Blazor.Buttons

<SfButton @onkeypress="OnKeyPress" Content="Focus & Press Key" IsPrimary="true"></SfButton>
<p>@Message</p>

@code {
    public string Message = "";

    private void OnKeyPress(Microsoft.AspNetCore.Components.Web.KeyboardEventArgs args)
    {
        Message = $"Key pressed: {args.Key}";
    }
}
```

## How to bind keyup event to Button

The `onkeyup` event fires when a key is released after being pressed while the Button has focus. It is commonly used to detect the completion of a key interaction, such as confirming a value after typing or triggering an action when a specific key is released.

```csharp
@using Syncfusion.Blazor.Buttons

<SfButton @onkeyup="OnKeyUp" Content="Focus & Release Key" IsPrimary="true"></SfButton>
<p>@Message</p>

@code {
    public string Message = "";

    private void OnKeyUp(Microsoft.AspNetCore.Components.Web.KeyboardEventArgs args)
    {
        Message = $"Key released: {args.Key}";
    }
}
```

## How to bind focus event to Button

The `onfocus` event fires when the Button receives focus, either through a mouse click or keyboard navigation (e.g., `Tab` key). It is used to highlight the button, display hints, or trigger focus-related UI changes.

```csharp
@using Syncfusion.Blazor.Buttons

<SfButton @onfocus="OnFocus" Content="Click or Tab to Focus" IsPrimary="true"></SfButton>
<p>@Message</p>

@code {
    public string Message = "";

    private void OnFocus(Microsoft.AspNetCore.Components.Web.FocusEventArgs args)
    {
        Message = "Button is focused.";
    }
}
```

## How to bind blur event to Button

The `onblur` event fires when the Button loses focus, typically when the user clicks elsewhere or tabs away. It is useful for validating state, hiding focus indicators, or resetting UI changes applied during focus.

```csharp
@using Syncfusion.Blazor.Buttons

<SfButton @onblur="OnBlur" Content="Click Then Click Away" IsPrimary="true"></SfButton>
<p>@Message</p>

@code {
    public string Message = "";

    private void OnBlur(Microsoft.AspNetCore.Components.Web.FocusEventArgs args)
    {
        Message = "Button lost focus.";
    }
}
```

## How to bind focusin event to Button

The `onfocusin` event fires when the Button or any of its child elements receives focus. Unlike `onfocus`, this event bubbles up the DOM tree, making it useful for detecting focus within a container component or handling delegated focus scenarios.

```csharp
@using Syncfusion.Blazor.Buttons

<SfButton @onfocusin="OnFocusIn" Content="Focus In" IsPrimary="true"></SfButton>
<p>@Message</p>

@code {
    public string Message = "";

    private void OnFocusIn(Microsoft.AspNetCore.Components.Web.FocusEventArgs args)
    {
        Message = "Focus moved into the button (focusin).";
    }
}
```

## How to bind focusout event to Button

The `onfocusout` event fires when the Button or any of its child elements loses focus. Unlike `onblur`, this event bubbles, making it useful for tracking when focus leaves a group of related elements or a container.

```csharp
@using Syncfusion.Blazor.Buttons

<SfButton @onfocusout="OnFocusOut" Content="Focus Out" IsPrimary="true"></SfButton>
<p>@Message</p>

@code {
    public string Message = "";

    private void OnFocusOut(Microsoft.AspNetCore.Components.Web.FocusEventArgs args)
    {
        Message = "Focus moved out of the button (focusout).";
    }
}
```

## Complete sample with all events

The following example demonstrates all supported native events bound to a single Button component. Each interaction is captured and displayed as an event log, allowing you to observe the event name and relevant details.

```csharp
@using Syncfusion.Blazor.Buttons

<div class="event-demo">
    <SfButton @ref="EventBtn"
              Content="Interact With Me"
              IsPrimary="true"
              CssClass="e-flat"
              @onclick="OnClick"
              @ondblclick="OnDblClick"
              @onmousedown="OnMouseDown"
              @onmouseup="OnMouseUp"
              @onmouseover="OnMouseOver"
              @onmouseout="OnMouseOut"
              @onmousemove="OnMouseMove"
              @onmouseenter="OnMouseEnter"
              @onmouseleave="OnMouseLeave"
              @oncontextmenu="OnContextMenu"
              @onkeydown="OnKeyDown"
              @onkeypress="OnKeyPress"
              @onkeyup="OnKeyUp"
              @onfocus="OnFocus"
              @onblur="OnBlur"
              @onfocusin="OnFocusIn"
              @onfocusout="OnFocusOut">
    </SfButton>
</div>

<div class="event-log" style="margin-top: 20px; border: 1px solid #ccc; padding: 10px; max-height: 250px; overflow-y: auto;">
    <strong>Event Log:</strong>
    <SfButton Content="Clear Log" CssClass="e-small e-outline" style="float:right" @onclick="ClearLog"></SfButton>
    @if (EventLog.Count == 0)
    {
        <p style="color: gray;">No events fired yet. Interact with the button above.</p>
    }
    else
    {
        @foreach (var entry in EventLog)
        {
            <p style="margin: 2px 0; font-family: monospace; font-size: 13px;">@entry</p>
        }
    }
</div>

@code {
    SfButton EventBtn;
    private List<string> EventLog = new();

    private void Log(string eventName, string detail)
    {
        EventLog.Insert(0, $"{eventName} — {detail}");
        if (EventLog.Count > 50)
            EventLog = EventLog.Take(50).ToList();
    }

    private void OnClick(Microsoft.AspNetCore.Components.Web.MouseEventArgs e) => Log("onclick", $"Button={e.Button}");
    private void OnDblClick(Microsoft.AspNetCore.Components.Web.MouseEventArgs e) => Log("ondblclick", $"X={e.ClientX}, Y={e.ClientY}");
    private void OnMouseDown(Microsoft.AspNetCore.Components.Web.MouseEventArgs e) => Log("onmousedown", $"Button={e.Button}");
    private void OnMouseUp(Microsoft.AspNetCore.Components.Web.MouseEventArgs e) => Log("onmouseup", $"Button={e.Button}");
    private void OnMouseOver(Microsoft.AspNetCore.Components.Web.MouseEventArgs e) => Log("onmouseover", $"X={e.ClientX}");
    private void OnMouseOut(Microsoft.AspNetCore.Components.Web.MouseEventArgs e) => Log("onmouseout", $"X={e.ClientX}");
    private void OnMouseMove(Microsoft.AspNetCore.Components.Web.MouseEventArgs e) => Log("onmousemove", $"OffsetX={e.OffsetX:F0}, OffsetY={e.OffsetY:F0}");
    private void OnMouseEnter(Microsoft.AspNetCore.Components.Web.MouseEventArgs e) => Log("onmouseenter", "entered");
    private void OnMouseLeave(Microsoft.AspNetCore.Components.Web.MouseEventArgs e) => Log("onmouseleave", "left");
    private void OnContextMenu(Microsoft.AspNetCore.Components.Web.MouseEventArgs e) => Log("oncontextmenu", $"X={e.ClientX}, Y={e.ClientY}");
    private void OnKeyDown(Microsoft.AspNetCore.Components.Web.KeyboardEventArgs e) => Log("onkeydown", $"Key={e.Key}");
    private void OnKeyPress(Microsoft.AspNetCore.Components.Web.KeyboardEventArgs e) => Log("onkeypress", $"Key={e.Key}");
    private void OnKeyUp(Microsoft.AspNetCore.Components.Web.KeyboardEventArgs e) => Log("onkeyup", $"Key={e.Key}");
    private void OnFocus(Microsoft.AspNetCore.Components.Web.FocusEventArgs e) => Log("onfocus", "button focused");
    private void OnBlur(Microsoft.AspNetCore.Components.Web.FocusEventArgs e) => Log("onblur", "button blurred");
    private void OnFocusIn(Microsoft.AspNetCore.Components.Web.FocusEventArgs e) => Log("onfocusin", "focus in");
    private void OnFocusOut(Microsoft.AspNetCore.Components.Web.FocusEventArgs e) => Log("onfocusout", "focus out");

    private void ClearLog(Microsoft.AspNetCore.Components.Web.MouseEventArgs args)
    {
        EventLog.Clear();
    }
}
```