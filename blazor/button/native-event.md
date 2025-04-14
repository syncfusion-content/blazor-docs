---
layout: post
title: Native Events in Blazor Button Component | Syncfusion
description: Checkout and learn here all about native events support in Syncfusion Blazor Button component, it's elements and more.
platform: Blazor
control: Button
documentation: ug
---

# Native Events in Blazor Button Component

You can define the native event using `event` attribute in component. The value of attribute is treated as an event handler. The event specific data will be available in event arguments.

The different event argument types for each event are,

* Focus Events - UIFocusEventArgs
* Mouse Events - UIMouseEventArgs
* Keyboard Events - UIKeyboardEventArgs
* Touch Events – UITouchEventArgs

## List of native events supported

The following native event support has been provided to the Button component:

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

{% previewsample "https://blazorplayground.syncfusion.com/embed/hNrqMVBhCcqcrEoi?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor Native Event Button.](images/blazor-native-event-button.png)