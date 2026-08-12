---
layout: post
title: Native Events in Blazor In-place Editor Component | Syncfusion®
description: Checkout and learn here all about Native Events in Blazor In-place Editor component and much more details.
platform: Blazor
control: In-place Editor  
documentation: ug
---

# Overview of Native Events

You can define a native event by using the `on<event>` attribute on a component. The value of the attribute is treated as an event handler. The event-specific data is available in the event arguments.

The supported event argument types for each event are:

* **Mouse Events** - `UIMouseEventArgs`
* **Keyboard Events** - `UIKeyboardEventArgs`

## List of native events supported

The following native events are supported by the In-place Editor component:

| List of native events |  |  | |
| --- | --- | --- | --- |
| onmousedown | onmouseup | onmouseover | onmousemove |
| onmouseout | onkeydown | onkeypress | onkeyup |

## How to bind the onmousedown event to the In-place Editor

The `onmousedown` attribute is used to bind the mouse-down event for the In-place Editor. The following sample shows how to use `onmousedown` in the In-place Editor to toggle the rendering mode between `Inline` and `Popup`.

```cshtml

@using Syncfusion.Blazor.InPlaceEditor

<SfInPlaceEditor Mode="@Mode" @onmousedown="OnMouseDown" Type="InputType.Text" Value="@TextValue" SubmitOnEnter="true" />

@code {
    public string TextValue { get; set; } = "Andrew";
    public Syncfusion.Blazor.InPlaceEditor.RenderMode Mode { get; set; } = Syncfusion.Blazor.InPlaceEditor.RenderMode.Inline;

    private void OnMouseDown(MouseEventArgs args)
    {
        this.Mode = this.Mode == Syncfusion.Blazor.InPlaceEditor.RenderMode.Inline ? Syncfusion.Blazor.InPlaceEditor.RenderMode.Popup : Syncfusion.Blazor.InPlaceEditor.RenderMode.Inline;
    }

}
```
