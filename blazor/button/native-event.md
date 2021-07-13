---
layout: post
title: Native Event in Blazor Button Component | Syncfusion 
description: Learn about Native Event in Blazor Button component of Syncfusion, and more details.
platform: Blazor
control: Button
documentation: ug
---

# Overview

You can define the native event using on `event` attribute in component. The value of attribute is treated as an event handler. The event specific data will be available in event arguments.

The different event argument types for each event are,

* Focus Events - UIFocusEventArgs
* Mouse Events - UIMouseEventArgs
* Keyboard Events - UIKeyboardEventArgs
* Touch Events – UITouchEventArgs

## List of Native events supported

We have provided the following native event support to the Button component:

| List of Native events |  |  | |
| --- | --- | --- | --- |
| onclick | onblur | onfocus | onfocusout |
|onmousemove|onmouseover|onmouseout|onmousedown|onmouseup|
|ondblclick|onkeydown|onkeyup|onkeypress|
|ontouchend|onfocusin|onmouseup|ontouchstart|

## How to bind click event to Button

The `onclick` attribute is used to bind the click event for button. Here, we have explained about the sample code snippets of toggle button.

```csharp

    @using Syncfusion.Blazor.Buttons

    <SfButton @ref="ToggleBtn" @onclick="onToggleClick" CssClass="e-flat" IsToggle="true" IsPrimary="true" Content="@Content"></SfButton>

@code {
    SfButton ToggleBtn;
    public string Content = "Play";
    private void onToggleClick(Microsoft.AspNetCore.Components.Web.MouseEventArgs args)
    {
        if (ToggleBtn.Content == "Play")
        {
            this.Content = "Pause";
        }
        else
        {
            this.Content = "Play";
        }
    }
}
```
