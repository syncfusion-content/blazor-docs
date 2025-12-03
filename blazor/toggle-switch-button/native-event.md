---
layout: post
title: Events in Blazor Toggle Switch Button Component | Syncfusion
description: Checkout and learn here all about events in Syncfusion Blazor Toggle Switch Button component and more.
platform: Blazor
control: Toggle Switch Button 
documentation: ug
---

# Events in Blazor Toggle Switch Button Component

This explains how to handle the ValueChange event and bind standard Blazor native DOM events to the Toggle Switch Button component for common interaction scenarios such as focus, keyboard, mouse, and touch.

## ValueChange Event

The ValueChange event is triggered when the switch state changes through user interaction. The ValueChange event argument type is [ChangeEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.ChangeEventArgs-1.html). [ChangeEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.ChangeEventArgs-1.html) includes the [Checked](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.ChangeEventArgs-1.html#Syncfusion_Blazor_Buttons_ChangeEventArgs_1_Checked) and [Event](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.ChangeEventArgs-1.html#Syncfusion_Blazor_Buttons_ChangeEventArgs_1_Event) properties for obtaining the current state and the associated event details.

```csharp

@using Syncfusion.Blazor.Buttons

<SfSwitch @bind-Checked="isChecked" OffLabel="OFF" OnLabel="ON" ValueChange="Change" TChecked="bool?" ></SfSwitch>

@code{
    private bool? isChecked = null;
    private void Change(Syncfusion.Blazor.Buttons.ChangeEventArgs<bool?> args)
    {
        // Your code here.
    }
}

```

N> Toggle Switch Button supports a nullable boolean value (true, false, or null).

## How to bind native events

In addition to the ValueChange component event, the Toggle Switch Button supports standard Blazor native DOM events for detailed control over user interactions. Attach native event handlers using Blazor's `@on*` directives (for example, `@onfocus`, `@onkeydown`), and access event-specific data through the corresponding event argument type.

The following native events are supported:

| Event Category | Events |
|---|---|
| **Focus** | onfocus, onfocusin, onfocusout |
| **Keyboard** | onkeydown, onkeyup, onkeypress |
| **Mouse** | onclick, ondblclick, onmousedown, onmouseup, onmousemove, onmouseenter, onmouseleave |
| **Touch** | ontouchstart, ontouchend, ontouchmove |

### Focus Events

Focus events fire when the Toggle Switch Button receives or loses focus. The `FocusEventArgs` parameter provides access to focus state information for implementing accessibility features and focus-dependent logic.

| Event | Behavior |
|---|---|
| **onfocus** | Fires when the component gains focus |
| **onfocusin** | Fires when the component gains focus, including during event bubbling |
| **onfocusout** | Fires when the component loses focus |

The following example demonstrates handling focus events on the Toggle Switch Button:

```cshtml
@using Syncfusion.Blazor.Buttons

<SfSwitch @bind-Checked="isChecked"
          OffLabel="OFF"
          OnLabel="ON"
          TChecked="bool?"
          @onfocus="OnFocus"
          @onfocusin="OnFocusIn"
          @onfocusout="OnFocusOut">
</SfSwitch>

@code {
    private bool? isChecked = null;

    private void OnFocus(FocusEventArgs args)    
    { 
        /* onfocus triggered */ 
    }
    private void OnFocusIn(FocusEventArgs args)  
    {
         /* onfocusin triggered */ 
    }
    private void OnFocusOut(FocusEventArgs args) 
    {
         /* onfocusout triggered */ 
    }
}
```

### Keyboard Events

Keyboard events are triggered when keyboard interactions occur on the Toggle Switch Button component. The `KeyboardEventArgs` event argument provides information about which key was pressed and keyboard modifiers, allowing you to handle keyboard navigation and shortcuts.

| Event | Behavior |
|---|---|
| **onkeydown** | Fires when a key is pressed |
| **onkeyup** | Fires when a pressed key is released |
| **onkeypress** | Fires when a key is pressed (generally use onkeydown for better compatibility) |

The following example demonstrates handling keyboard events:

```cshtml
@using Syncfusion.Blazor.Buttons

<SfSwitch @bind-Checked="isChecked"
          OffLabel="OFF"
          OnLabel="ON"
          TChecked="bool?"
          @onkeydown="OnKeyDown"
          @onkeyup="OnKeyUp"
          @onkeypress="OnKeyPress">
</SfSwitch>

@code {
    private bool? isChecked = null;

    private void OnKeyDown(KeyboardEventArgs args) 
    {
         /* onkeydown triggered */ 
    }
    private void OnKeyUp(KeyboardEventArgs args)   
    { 
        /* onkeyup triggered */ 
    }
    private void OnKeyPress(KeyboardEventArgs args)
    { 
        /* onkeypress triggered */ 
    }
}
```

### Mouse Events

Mouse events fire when the user interacts with the Toggle Switch Button using the mouse. The `MouseEventArgs` parameter provides positional data, button information, and other mouse-related properties.

**Event Types:**| Event | Behavior |
|---|---|
| **OnClick** | Fires when the component is clicked |
| **OnDoubleClick** | Fires when the component is double-clicked |
| **OnMouseDown** | Fires when a mouse button is pressed down |
| **OnMouseUp** | Fires when a mouse button is released |
| **OnMouseMove** | Fires as the mouse pointer moves over the component |
| **OnMouseEnter** | Fires when the mouse pointer enters the component area |
| **OnMouseLeave** | Fires when the mouse pointer leaves the component area |

The following example demonstrates handling mouse events:

```cshtml
@using Syncfusion.Blazor.Buttons

<SfSwitch @bind-Checked="isChecked"
          OffLabel="OFF"
          OnLabel="ON"
          TChecked="bool?"
          @onclick="OnClick"
          @ondblclick="OnDoubleClick"
          @onmousedown="OnMouseDown"
          @onmouseup="OnMouseUp"
          @onmousemove="OnMouseMove"
          @onmouseenter="OnMouseEnter"
          @onmouseleave="OnMouseLeave">
</SfSwitch>

@code {
    private bool? isChecked = null;

    private void OnClick(MouseEventArgs args)       
    { 
        /* onclick triggered */ 
    }
    private void OnDoubleClick(MouseEventArgs args) 
    {
         /* ondblclick triggered */ 
    }
    private void OnMouseDown(MouseEventArgs args)   
    {
         /* onmousedown triggered */ 
    }
    private void OnMouseUp(MouseEventArgs args)
    {
         /* onmouseup triggered */ 
    }
    private void OnMouseMove(MouseEventArgs args)   
    {
         /* onmousemove triggered */ 
    }
    private void OnMouseEnter(MouseEventArgs args)
    {
         /* onmouseenter triggered */ 
    }
    private void OnMouseLeave(MouseEventArgs args)
    {
         /* onmouseleave triggered */ 
    }
}
```

### Touch Events

Touch events fire when the user interacts with the Toggle Switch Button using touch input on touch-enabled devices (tablets, smart phones, etc.). The `TouchEventArgs` parameter provides information about touch points and their positions.

| Event | Behavior |
|---|---|
| **ontouchstart** | Fires when one or more touch points contact the component |
| **ontouchend** | Fires when one or more touch points are removed from the component |
| **ontouchmove** | Fires when one or more touch points move while in contact with the component |

The following example demonstrates handling touch events:

```cshtml
@using Syncfusion.Blazor.Buttons

<SfSwitch @bind-Checked="isChecked"
          OffLabel="OFF"
          OnLabel="ON"
          TChecked="bool?"
          @ontouchstart="OnTouchStart"
          @ontouchend="OnTouchEnd"
          @ontouchmove="OnTouchMove">
</SfSwitch>

@code {
    private bool? isChecked = null;

    private void OnTouchStart(TouchEventArgs args) 
    {
         /* ontouchstart triggered */ 
    }
    private void OnTouchEnd(TouchEventArgs args)
    {
         /* ontouchend triggered */ 
    }
    private void OnTouchMove(TouchEventArgs args)
    {
         /* ontouchmove triggered */ 
    }
}
```



