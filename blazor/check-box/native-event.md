---
layout: post
title: Native Events in Blazor CheckBox Component | Syncfusion®
description: Checkout and learn here all the features about Native Events in Blazor CheckBox component and much more.
platform: Blazor
control: Checkbox
documentation: ug
---

# Native Events in Blazor CheckBox Component

You can bind native Blazor events to the CheckBox component using the `@on{event}` directive. The event-specific data is available through the event arguments.

The following event argument types are used for each event category:

* Focus Events - `FocusEventArgs`
* Mouse Events - `MouseEventArgs`
* Keyboard Events - `KeyboardEventArgs`
* Touch Events - `TouchEventArgs`

> All event argument types are from the `Microsoft.AspNetCore.Components.Web` namespace.

## List of native events supported

The following native events are supported by the CheckBox component:

| List of native events |  |  |  |  |
| --- | --- | --- | --- | --- |
| onchange | oninput | onblur | onfocusout | onfocusin |
| onfocus | onclick | onkeydown | onkeyup | onkeypress |

| Event | Description |
| --- | --- |
| `onchange` | Fires when the CheckBox value is committed by the user. |
| `oninput` | Fires every time the value changes. |
| `onblur` | Fires when the CheckBox loses focus. |
| `onfocus` | Fires when the CheckBox gains focus. |
| `onfocusin` | Fires when focus enters the CheckBox (bubbling). |
| `onfocusout` | Fires when focus leaves the CheckBox (bubbling). |
| `onclick` | Fires when the CheckBox is clicked. |
| `onkeydown` | Fires when a key is pressed down. |
| `onkeyup` | Fires when a key is released. |
| `onkeypress` | Fires when a key that produces a character is pressed. |

## How to bind onchange event to CheckBox

The `@onchange` attribute is used to bind the native onchange event to a CheckBox. The following sample shows how to bind it.

```cshtml
@using Syncfusion.Blazor.Buttons
@using Microsoft.AspNetCore.Components

<SfCheckBox @bind-Checked="isChecked" Label="Change" @onchange="onChange"></SfCheckBox>

@code {
    private bool isChecked = true;
    private void onChange(ChangeEventArgs args)
    {
       // onChange event triggered
       var value = args.Value;
    }
}
```

## How to bind ValueChange event to CheckBox

The component-specific change event is bound using the [ValueChange](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfCheckBox-1.html#Syncfusion_Blazor_Buttons_SfCheckBox_1_ValueChange) event of the CheckBox. This event is triggered when the CheckBox value changes. The `ChangeEventArgs<bool>` type is from `Syncfusion.Blazor.Buttons` (it is not the framework's `Microsoft.AspNetCore.Components.ChangeEventArgs`), so that namespace must be imported.

`@onchange` is used for the framework's native change behavior with `ChangeEventArgs` (object `Value`). `ValueChange` is used when a strongly typed `ChangeEventArgs<bool>` payload from Syncfusion is required.

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