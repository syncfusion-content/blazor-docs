---
layout: post
title: Native Events in Blazor CheckBox Component | Syncfusion
description: Learn how to handle native events in the Syncfusion Blazor CheckBox component using Blazor @on… event attributes, event argument types, and the component ValueChange event.
platform: Blazor
control: CheckBox
documentation: ug
---

# Native Events in Blazor CheckBox Component

Attach native DOM events in Blazor by using the @on{event} attributes on the component. The attribute value is the event handler method, and event-specific data is provided via the corresponding EventArgs. For an overview of Blazor event handling and event arguments, see the Microsoft documentation on Blazor event handling (https://learn.microsoft.com/aspnet/core/blazor/components/event-handling).

The common event argument types include:

* Focus events - FocusEventArgs
* Mouse events - MouseEventArgs
* Keyboard events - KeyboardEventArgs
* Touch events – TouchEventArgs

## List of Native events supported

The following native events are supported by the CheckBox component:

| List of Native events |  |  | | |
| --- | --- | --- | --- | --- |
| onchange | oninput | onblur | onfocusout | onfocusin |
| onfocus | onclick | onkeydown | onkeyup | onkeypress |

## How to bind onchange event to Checkbox

Use the `@onchange` attribute to bind the native change event for the CheckBox. The handler receives a ChangeEventArgs instance from Blazor.

```cshtml
@using Syncfusion.Blazor.Buttons

<SfCheckBox @bind-Checked="isChecked" Label="Change" @onchange="onChange"></SfCheckBox>

@code {
    private bool isChecked = true;
    private void onChange(Microsoft.AspNetCore.Components.ChangeEventArgs args)
    {
       // onChange event triggered
    }
}
```

## How to bind ValueChange event to Checkbox

To handle component-level state changes, use the CheckBox [ValueChange](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfCheckBox-1.html#Syncfusion_Blazor_Buttons_SfCheckBox_1_ValueChange) event. This event is raised when the CheckBox value changes and provides strongly typed event data.

```cshtml
@using Syncfusion.Blazor.Buttons

<SfCheckBox @bind-Checked="isChecked" Label="Change" ValueChange="ValueChange" TChecked="bool"></SfCheckBox>

@code {
    private bool isChecked = true;
    private void ValueChange(ChangeEventArgs<bool> args)
    {
        // ValueChange event triggered
        var state = args.Checked;
    }
}
```