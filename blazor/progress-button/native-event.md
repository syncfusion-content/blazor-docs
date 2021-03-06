---
layout: post
title: Native Events in Blazor ProgressButton Component | Syncfusion
description: Checkout and learn here all about native events in Syncfusion Blazor ProgressButton component and more.
platform: Blazor
control: Progress Button
documentation: ug
---

# Native Events in Blazor ProgressButton Component

You can define the native event using an `event` attribute in the component. The value of attribute is treated as an event handler. The event specific data will be available in the event arguments.

The different event argument types for each event are,

* Focus Events - UIFocusEventArgs
* Mouse Events - UIMouseEventArgs
* Keyboard Events - UIKeyboardEventArgs
* Touch Events – UITouchEventArgs

## List of Native events supported

The following native event support has been provided to the Progress Button component:

| List of Native events |  |  | |
| --- | --- | --- | --- |
| onclick | onblur | onfocus | onfocusout |
|onmousemove|onmouseover|onmouseout|onmousedown|onmouseup|
|ondblclick|onkeydown|onkeyup|onkeypress|
|ontouchend|onfocusin|onmouseup|ontouchstart|

## How to bind click event to Progress Button

The `onclick` attribute is used to bind the click event for Progress Button. Here, the sample code snippets of Progress Button has been explained.

```cshtml
@using Syncfusion.Blazor.SplitButtons

<SfProgressButton IsPrimary="true" @onclick="onClick" Content="Spin Left"></SfProgressButton>

@code {

    private void onClick(Microsoft.AspNetCore.Components.Web.MouseEventArgs args)
    {
        //onclick Event triggered
    }
}

```