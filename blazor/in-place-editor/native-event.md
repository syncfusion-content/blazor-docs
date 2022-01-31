---
layout: post
title: Native Event in Blazor In Place Editor Component | Syncfusion 
description: Checkout and learn here all about Native Event in Syncfusion Blazor In Place Editor component and much more.
platform: Blazor
control: In Place Editor 
documentation: ug
---

# Overview

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

<SfInPlaceEditor Mode="@Mode" OnMousedown="OnMouseDown" Type="InputType.Text" Value="@TextValue" SubmitOnEnter="true" Model="@TModel" />

@code {
    public string TextValue = "Andrew";
    public RenderMode Mode = RenderMode.Inline;

    public TextBoxModel TModel = new TextBoxModel()
    {
        Placeholder = "Enter employee name"
    };

    private void OnMouseDown(MouseEventArgs args)
    {
        this.Mode = this.Mode == RenderMode.Inline ? RenderMode.Popup : RenderMode.Inline;
        this.StateHasChanged();
    }
}

```
