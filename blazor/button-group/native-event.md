---
layout: post
title: Native Events in Blazor Button Group Component | Syncfusion®
description: Checkout and learn here all features about Native Events in Blazor Button Group component and much more.
platform: Blazor
control: Button Group
documentation: ug
---

# Native Events in Blazor Button Group Component

Native DOM events (such as click, change, focus, mouse, keyboard, and touch events) can be handled on the Button Group component through Blazor's `@on{event}` directive (for example, `@onclick`, `@onchange`). The value of the directive is treated as an event handler. The event-specific data is passed to the handler through the event arguments.

The following event argument types are available for the corresponding native events:

* Focus Events - `FocusEventArgs`
* Mouse Events - `MouseEventArgs`
* Keyboard Events - `KeyboardEventArgs`
* Touch Events - `TouchEventArgs`
* Change Events - `ChangeEventArgs`

> All event argument types except `ChangeEventArgs` are from the `Microsoft.AspNetCore.Components.Web` namespace.

## List of native events supported for default Button Group

The following native events are supported by the default Button Group component:

| List of Native events |  |  |  |
| --- | --- | --- | --- |
| onclick | onblur | onfocus | onfocusout |
| onmousemove | onmouseover | onmouseout | onmousedown |
| onmouseup | ondblclick | onkeydown | onkeyup |
| onkeypress | ontouchend | onfocusin | ontouchstart |

## How to bind click event to Button Group

The `@onclick` directive is used to bind the click event for the Button Group. The following code snippet demonstrates binding a click event to each button in the group.

```cshtml

@using Syncfusion.Blazor.SplitButtons

<SfButtonGroup>
    <ButtonGroupButton @onclick="OnLeftClick">Left</ButtonGroupButton>
    <ButtonGroupButton @onclick="OnCenterClick">Center</ButtonGroupButton>
    <ButtonGroupButton @onclick="OnRightClick">Right</ButtonGroupButton>
</SfButtonGroup>

@code{
    private void OnLeftClick()
    {
        // handle the left click event
    }
    private void OnCenterClick()
    {
        // handle the center click event
    }
    private void OnRightClick()
    {
        // handle the right click event
    }
}
```

## How to bind a mouse event with arguments to Button Group

The following code snippet demonstrates how to handle a mouse event and read the `MouseEventArgs` payload.

```cshtml

@using Syncfusion.Blazor.SplitButtons
@using Microsoft.AspNetCore.Components.Web

<SfButtonGroup>
    <ButtonGroupButton @onmouseover="OnHover">
        Hover me
    </ButtonGroupButton>
</SfButtonGroup>

<p>@message</p>

@code {
    private string message = "Move mouse over the button";

    private void OnHover(MouseEventArgs args)
    {
        var x = args.ClientX;
        var y = args.ClientY;

        message = $"Mouse Position: X = {x}, Y = {y}";
    }
}
```

## List of native events supported for Single / Multiple selection mode Button Group

The following native events are supported when the Button Group is in single or multiple selection mode (`Mode="SelectionMode.Single"` or `Mode="SelectionMode.Multiple"`):

| List of Native events |  |  |  |  |
| --- | --- | --- | --- | --- |
| onchange | oninput | onblur | onfocusout | onfocusin |
| onfocus | onclick | onkeydown | onkeyup | onkeypress |

## How to bind onchange event to Button Group

The `@onchange` directive is used to bind the change event for the Button Group in selection mode. The following code snippet demonstrates binding an `onchange` event to each button in a single-selection Button Group.

```cshtml

@using Syncfusion.Blazor.SplitButtons

<SfButtonGroup Mode="Syncfusion.Blazor.SplitButtons.SelectionMode.Single">
    <ButtonGroupButton @onchange="OnLeftChange">Left</ButtonGroupButton>
    <ButtonGroupButton @onchange="OnCenterChange">Center</ButtonGroupButton>
    <ButtonGroupButton @onchange="OnRightChange">Right</ButtonGroupButton>
</SfButtonGroup>

<p>@message</p>

@code {
    private string message = "No button selected";

    private void OnLeftChange ( ChangeEventArgs args )
    {
        message = $"Selected Button: Left";

    }

    private void OnCenterChange ( ChangeEventArgs args )
    {
        message = $"Selected Button: Center";
    }

    private void OnRightChange ( ChangeEventArgs args )
    {
        message = $"Selected Button: Right";
    }
}
```

## See also

* [Getting Started with Blazor Button Group](getting-started.md)
* [Types and Styles in Blazor Button Group](types-and-styles.md)
* [Selection and Nesting in Blazor Button Group](selection-and-nesting.md)
* [Accessibility in Blazor Button Group](accessibility.md)
