---
layout: post
title: Native Event in Blazor Radio Button Component | Syncfusion 
description: Learn about Native Event in Blazor Radio Button component of Syncfusion, and more details.
platform: Blazor
control: Radio Button
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

We have provided the following native event support to the Radio Button component:

| List of Native events |  |  | | |
| --- | --- | --- | --- | --- |
| onchange | oninput | onblur | onfocus | onfocusout |
|onfocusin|onclick|onkeydown|onkeyup|Onkeypress |

## How to bind click event to Radio Button

The `onclick` attribute is used to bind the click event for Radio Button. Here, we have explained about the sample code snippets of Radio Button.

```cshtml
@using Syncfusion.Blazor.Buttons

<SfRadioButton Label="Credit/Debit Card" Name="payment" Value="credit/debit" @onclick="onClick" @bind-Checked="stringChecked"></SfRadioButton><br />
<SfRadioButton Label="Net Banking" Name="payment" Value="netbanking" @onclick="onClick" @bind-Checked="stringChecked"></SfRadioButton>

@code {
    private string stringChecked = "netbanking";
    private void onClick(Microsoft.AspNetCore.Components.Web.MouseEventArgs args){
        //onclick Event triggered
    }
}

```
