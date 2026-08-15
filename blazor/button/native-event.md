---
layout: post
title: Native Events in Blazor Button | Syncfusion®
description: Attach native DOM events to the Blazor Button using the @on{event} directive and pass event argument data to the handler.
platform: Blazor
control: Button
documentation: ug
---

# Native Events in Blazor Button

You can bind native Blazor events to the Button component using the `@on{event}` directive. The event-specific data is available through the event arguments.

The following event argument types are used for each event category:

* Focus Events - `FocusEventArgs`
* Mouse Events - `MouseEventArgs`
* Keyboard Events - `KeyboardEventArgs`
* Touch Events - `TouchEventArgs`

> All event argument types are from the `Microsoft.AspNetCore.Components.Web` namespace.

## List of native events supported

The following native events are supported by the Blazor Button component. Use the Blazor `@on{event}` directive syntax (for example, `@onclick`, `@onfocus`) to bind them.

| List of Native events |  |  |  |  |
| --- | --- | --- | --- | --- |
| onclick | ondblclick | onmousedown | onmouseup | onmouseover |
| onmouseout | onmousemove | onmouseenter | onmouseleave | oncontextmenu |
| onkeydown | onkeypress | onkeyup | onfocus | onblur |
| onfocusin | onfocusout | ontouchstart | ontouchend | |

## How to bind click event to Button

The `onclick` event fires when the user clicks the button with a mouse or activates it via the keyboard (`Space` or `Enter`). It is the most commonly used event for triggering actions such as form submission, navigation, or toggling UI state.

```csharp
@using Syncfusion.Blazor.Buttons
@using Microsoft.AspNetCore.Components.Web

<SfButton @ref="ToggleBtn" @onclick="OnToggleClick" CssClass="e-flat" IsToggle="true" IsPrimary="true" Content="@Content"></SfButton>

@code {
    SfButton ToggleBtn;
    public string Content = "Play";

    private void OnToggleClick(MouseEventArgs args)
    {
        Content = (ToggleBtn.Content == "Play") ? "Pause" : "Play";
    }
}
```

## How to bind double-click event to Button

The `ondblclick` event fires when the user rapidly clicks the button twice in quick succession. It is useful for triggering actions that should only occur on deliberate double-click gestures, such as expanding a panel or confirming a selection.

```csharp
@using Syncfusion.Blazor.Buttons
@using Microsoft.AspNetCore.Components.Web

<SfButton @ondblclick="OnDoubleClick" Content="Double Click Me" IsPrimary="true"></SfButton>
<p>@Message</p>

@code {
    public string Message = "";

    private void OnDoubleClick(MouseEventArgs args)
    {
        Message = $"Double-clicked at position X: {args.ClientX}, Y: {args.ClientY}";
    }
}
```

## How to bind mousedown event to Button

The `onmousedown` event fires the moment a mouse button is pressed down on the Button element, before the mouse button is released. It is useful for implementing press-and-hold interactions or initiating drag operations.

```csharp
@using Syncfusion.Blazor.Buttons
@using Microsoft.AspNetCore.Components.Web

<SfButton @onmousedown="OnMouseDown" Content="Press Me" IsPrimary="true"></SfButton>
<p>@Message</p>

@code {
    public string Message = "";

    private void OnMouseDown(MouseEventArgs args)
    {
        Message = $"Mouse button {args.Button} pressed down.";
    }
}
```

## How to bind mouseup event to Button

The `onmouseup` event fires when a mouse button is released after being pressed over the Button element. It complements `onmousedown` and can be used to complete press-and-hold interactions or detect the end of a drag gesture.

```csharp
@using Syncfusion.Blazor.Buttons
@using Microsoft.AspNetCore.Components.Web

<SfButton @onmouseup="OnMouseUp" Content="Release Me" IsPrimary="true"></SfButton>
<p>@Message</p>

@code {
    public string Message = "";

    private void OnMouseUp(MouseEventArgs args)
    {
        Message = $"Mouse button {args.Button} released.";
    }
}
```

## How to bind mouseover event to Button

The `onmouseover` event fires when the mouse pointer enters the Button element or any of its child elements. It is commonly used to show tooltips, highlight elements, or trigger hover-based UI effects.

```csharp
@using Syncfusion.Blazor.Buttons
@using Microsoft.AspNetCore.Components.Web

<SfButton @onmouseover="OnMouseOver" Content="Hover Over Me" IsPrimary="true"></SfButton>
<p>@Message</p>

@code {
    public string Message = "";

    private void OnMouseOver(MouseEventArgs args)
    {
        Message = "Mouse is over the button.";
    }
}
```

## How to bind mouseout event to Button

The `onmouseout` event fires when the mouse pointer leaves the Button element or one of its child elements. It is typically paired with `onmouseover` to reset styles or hide hover-based UI elements when the pointer moves away.

```csharp
@using Syncfusion.Blazor.Buttons
@using Microsoft.AspNetCore.Components.Web

<SfButton @onmouseout="OnMouseOut" Content="Move Away" IsPrimary="true"></SfButton>
<p>@Message</p>

@code {
    public string Message = "";

    private void OnMouseOut(MouseEventArgs args)
    {
        Message = "Mouse has left the button.";
    }
}
```

## How to bind mousemove event to Button

The `onmousemove` event fires continuously as the mouse pointer moves over the Button element. It is useful for tracking cursor position within the button area or creating custom interactive hover effects.

```csharp
@using Syncfusion.Blazor.Buttons
@using Microsoft.AspNetCore.Components.Web

<SfButton @onmousemove="OnMouseMove" Content="Move Mouse Here" IsPrimary="true"></SfButton>
<p>@Message</p>

@code {
    public string Message = "";

    private void OnMouseMove(MouseEventArgs args)
    {
        Message = $"Mouse position — X: {args.OffsetX:F0}, Y: {args.OffsetY:F0}";
    }
}
```

## How to bind mouseenter event to Button

The `onmouseenter` event fires when the mouse pointer enters the Button element. Unlike `onmouseover`, it does not bubble, meaning it only fires for the button itself and not for any child elements inside it.

```csharp
@using Syncfusion.Blazor.Buttons
@using Microsoft.AspNetCore.Components.Web

<SfButton @onmouseenter="OnMouseEnter" Content="Enter Button" IsPrimary="true"></SfButton>
<p>@Message</p>

@code {
    public string Message = "";

    private void OnMouseEnter(MouseEventArgs args)
    {
        Message = "Mouse entered the button area.";
    }
}
```

## How to bind mouseleave event to Button

The `onmouseleave` event fires when the mouse pointer leaves the Button element. Unlike `onmouseout`, it does not bubble, so it only triggers when the pointer actually exits the button boundary, not when moving between child elements.

```csharp
@using Syncfusion.Blazor.Buttons
@using Microsoft.AspNetCore.Components.Web

<SfButton @onmouseleave="OnMouseLeave" Content="Leave Button" IsPrimary="true"></SfButton>
<p>@Message</p>

@code {
    public string Message = "";

    private void OnMouseLeave(MouseEventArgs args)
    {
        Message = "Mouse left the button area.";
    }
}
```

## How to bind contextmenu event to Button

The `oncontextmenu` event fires when the user right-clicks the Button element, triggering the browser's context menu. It is used to intercept the right-click action and display a custom context menu or perform a specific operation.

```csharp
@using Syncfusion.Blazor.Buttons
@using Microsoft.AspNetCore.Components.Web

<SfButton @oncontextmenu="OnContextMenu" Content="Right Click Me" IsPrimary="true"></SfButton>
<p>@Message</p>

@code {
    public string Message = "";

    private void OnContextMenu(MouseEventArgs args)
    {
        Message = $"Context menu triggered at X: {args.ClientX}, Y: {args.ClientY}";
    }
}
```

## How to bind keydown event to Button

The `onkeydown` event fires when any key is pressed down while the Button has focus. It is useful for implementing keyboard shortcuts, preventing default key behavior, or handling navigation within a component.

```csharp
@using Syncfusion.Blazor.Buttons
@using Microsoft.AspNetCore.Components.Web

<SfButton @onkeydown="OnKeyDown" Content="Focus & Press Key" IsPrimary="true"></SfButton>
<p>@Message</p>

@code {
    public string Message = "";

    private void OnKeyDown(KeyboardEventArgs args)
    {
        Message = $"Key down: {args.Key} (Code: {args.Code})";
    }
}
```

## How to bind keypress event to Button

The `onkeypress` event fires when a key that produces a character value is pressed while the Button has focus. Note that this event is deprecated in modern web standards and may not fire for non-printable keys such as `Shift`, `Ctrl`, or arrow keys. Use `onkeydown` for broader key handling.

```csharp
@using Syncfusion.Blazor.Buttons
@using Microsoft.AspNetCore.Components.Web

<SfButton @onkeypress="OnKeyPress" Content="Focus & Press Key" IsPrimary="true"></SfButton>
<p>@Message</p>

@code {
    public string Message = "";

    private void OnKeyPress(KeyboardEventArgs args)
    {
        Message = $"Key pressed: {args.Key}";
    }
}
```

## How to bind keyup event to Button

The `onkeyup` event fires when a key is released after being pressed while the Button has focus. It is commonly used to detect the completion of a key interaction, such as confirming a value after typing or triggering an action when a specific key is released.

```csharp
@using Syncfusion.Blazor.Buttons
@using Microsoft.AspNetCore.Components.Web

<SfButton @onkeyup="OnKeyUp" Content="Focus & Release Key" IsPrimary="true"></SfButton>
<p>@Message</p>

@code {
    public string Message = "";

    private void OnKeyUp(KeyboardEventArgs args)
    {
        Message = $"Key released: {args.Key}";
    }
}
```

## How to bind focus event to Button

The `onfocus` event fires when the Button receives focus, either through a mouse click or keyboard navigation (for example, the `Tab` key). It is used to highlight the button, display hints, or trigger focus-related UI changes.

```csharp
@using Syncfusion.Blazor.Buttons
@using Microsoft.AspNetCore.Components.Web

<SfButton @onfocus="OnFocus" Content="Click or Tab to Focus" IsPrimary="true"></SfButton>
<p>@Message</p>

@code {
    public string Message = "";

    private void OnFocus(FocusEventArgs args)
    {
        Message = "Button is focused.";
    }
}
```

## How to bind blur event to Button

The `onblur` event fires when the Button loses focus, typically when the user clicks elsewhere or tabs away. It is useful for validating state, hiding focus indicators, or resetting UI changes applied during focus.

```csharp
@using Syncfusion.Blazor.Buttons
@using Microsoft.AspNetCore.Components.Web

<SfButton @onblur="OnBlur" Content="Click Then Click Away" IsPrimary="true"></SfButton>
<p>@Message</p>

@code {
    public string Message = "";

    private void OnBlur(FocusEventArgs args)
    {
        Message = "Button lost focus.";
    }
}
```

## How to bind focusin event to Button

The `onfocusin` event fires when the Button or any of its child elements receives focus. Unlike `onfocus`, this event bubbles up the DOM tree, making it useful for detecting focus within a container component or handling delegated focus scenarios.

```csharp
@using Syncfusion.Blazor.Buttons
@using Microsoft.AspNetCore.Components.Web

<SfButton @onfocusin="OnFocusIn" Content="Focus In" IsPrimary="true"></SfButton>
<p>@Message</p>

@code {
    public string Message = "";

    private void OnFocusIn(FocusEventArgs args)
    {
        Message = "Focus moved into the button (focusin).";
    }
}
```

## How to bind focusout event to Button

The `onfocusout` event fires when the Button or any of its child elements loses focus. Unlike `onblur`, this event bubbles, making it useful for tracking when focus leaves a group of related elements or a container.

```csharp
@using Syncfusion.Blazor.Buttons
@using Microsoft.AspNetCore.Components.Web

<SfButton @onfocusout="OnFocusOut" Content="Focus Out" IsPrimary="true"></SfButton>
<p>@Message</p>

@code {
    public string Message = "";

    private void OnFocusOut(FocusEventArgs args)
    {
        Message = "Focus moved out of the button (focusout).";
    }
}
```

## How to bind touch events to Button

The `ontouchstart` and `ontouchend` events fire when the user touches and releases the Button on a touch-enabled device. Use the `TouchEventArgs` type to access touch-specific data such as the list of changed touches.

```csharp
@using Syncfusion.Blazor.Buttons
@using Microsoft.AspNetCore.Components.Web

<SfButton @ontouchstart="OnTouchStart" @ontouchend="OnTouchEnd" Content="Touch Me" IsPrimary="true"></SfButton>
<p>@Message</p>

@code {
    public string Message = "";

    private void OnTouchStart(TouchEventArgs args)
    {
        Message = $"Touch started with {args.Touches.Length} touch point(s).";
    }

    private void OnTouchEnd(TouchEventArgs args)
    {
        Message = $"Touch ended with {args.ChangedTouches.Length} changed touch point(s).";
    }
}
```

## See also

* [Types and Styles in Blazor Button](types-and-styles.md)
* [Accessibility in Blazor Button](accessibility.md)
* [Blazor Button API reference](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfButton.html)