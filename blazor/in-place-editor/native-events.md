---
layout: post
title: Native Events in Blazor In-place Editor Component | Syncfusion
description: Checkout and learn here all about Native Events in Syncfusion Blazor In-place Editor component and much more.
platform: Blazor
control: In-place Editor  
documentation: ug
---

# Overview on Native Events

You can define the native event using on `<event>` attribute in component. The value of attribute is treated as an event handler. The event specific data will be available in event arguments.

The different event argument types for each event are:

* Mouse Events - UIMouseEventArgs
* Keyboard Events - UIKeyboardEventArgs

## List of Native events supported

The following native events support is provided to the In-place Editor component:

| List of Native events |  |  | |
| --- | --- | --- | --- |
| onmousedown | onmouseup | onmouseover | onmousemove |
| onmouseout | onkeydown | onkeypress | onkeyup |

## How to bind onmousedown event to In-place Editor

The `onmousedown` attribute is used to bind the mouse down event for In-place Editor. The sample code snippets of `onmousedown` in In-place Editor to change the mode as Inline are explained as follows.

```cshtml

@using Syncfusion.Blazor.InPlaceEditor

<SfInPlaceEditor Mode="@Mode" @onmousedown="OnMouseDown" Type="InputType.Text" Value="@TextValue" SubmitOnEnter="true" />

@code {
    public string TextValue = "Andrew";
    public Syncfusion.Blazor.InPlaceEditor.RenderMode Mode = Syncfusion.Blazor.InPlaceEditor.RenderMode.Inline;

    private void OnMouseDown(MouseEventArgs args)
    {
        this.Mode = this.Mode == Syncfusion.Blazor.InPlaceEditor.RenderMode.Inline ? Syncfusion.Blazor.InPlaceEditor.RenderMode.Popup : Syncfusion.Blazor.InPlaceEditor.RenderMode.Inline;
        this.StateHasChanged();
    }

}

```