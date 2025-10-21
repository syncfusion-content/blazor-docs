---
layout: post
title: Native Events in Blazor Button Group Component | Syncfusion
description: Checkout and learn here all about Native Events in Syncfusion Blazor Button Group component and much more.
platform: Blazor
control: ButtonGroup
documentation: ug
---

# Native Events in Blazor Button Group Component

Define native events on components/elements using Blazor’s `@on...` event attributes. The attribute value is treated as an event handler, and event-specific data is provided via event argument types from `Microsoft.AspNetCore.Components.Web`.

Common event argument types include:

* Focus events – `UIFocusEventArgs`
* Mouse events – `UIMouseEventArgs`
* Keyboard events – `UIKeyboardEventArgs`
* Touch events – `UITouchEventArgs`

## List of native events supported for default Button Group

The following native events are supported by the Button Group component:

| List of native events |  |  |  |
| --- | --- | --- | --- |
| onclick | onblur | onfocus | onfocusout |
| onmousemove | onmouseover | onmouseout | onmousedown |
| onmouseup | ondblclick | onkeydown | onkeyup |
| onkeypress | ontouchend | onfocusin | ontouchstart |

## How to bind click event to Button Group

Use the `onclick` attribute to bind the click event for a Button Group. The following example shows simple click handlers for each button.

```csharp

@using Syncfusion.Blazor.SplitButtons

<SfButtonGroup>
    <ButtonGroupButton @onclick="onLeftClick">Left</ButtonGroupButton>
    <ButtonGroupButton @onclick="onCenterClick">Center</ButtonGroupButton>
    <ButtonGroupButton @onclick="onRightClick">Right</ButtonGroupButton>
</SfButtonGroup>

@code{
    private void onLeftClick()
    {
        // handle the left click event
    }
    private void onCenterClick()
    {
        // handle the center click event
    }
    private void onRightClick()
    {
        // handle the right click event
    }
}
```

## List of native events supported for Single / Multiple selection mode Button Group

The following native events are supported by the Button Group component in single or multiple selection modes:

| List of native events |  |  |  |  |
| --- | --- | --- | --- | --- |
| onchange | oninput | onblur | onfocusout | onfocusin |
| onfocus | onclick | onkeydown | onkeyup | onkeypress |

## How to bind onchange event to Button Group

Use the `onchange` attribute to bind the change event for a Button Group configured with selection mode. The following example demonstrates handling item changes with `ChangeEventArgs`, where `args.Value` contains the selected value.

```csharp

@using Syncfusion.Blazor.SplitButtons

<SfButtonGroup Mode="Syncfusion.Blazor.SplitButtons.SelectionMode.Single">
    <ButtonGroupButton @onchange="onLeftClick" Value="Left">Left</ButtonGroupButton>
    <ButtonGroupButton @onchange="onCenterClick" Value="Center">Center</ButtonGroupButton>
    <ButtonGroupButton @onchange="onRightClick" Value="Right">Right</ButtonGroupButton>
</SfButtonGroup>

@code{
    private void onLeftClick(ChangeEventArgs args)
    {
        var SelectedValue = args.Value;
    }
    private void onCenterClick(ChangeEventArgs args)
    {
        var SelectedValue = args.Value;
    }
    private void onRightClick(ChangeEventArgs args)
    {
        var SelectedValue = args.Value;
    }
}
```