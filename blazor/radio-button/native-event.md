---
layout: post
title: Native Events in Blazor RadioButton Component | Syncfusion
description: Checkout and learn here all about native events in Syncfusion Blazor RadioButton component and more.
platform: Blazor
control: Radio Button
documentation: ug
---

# Native Events in Blazor RadioButton Component

Attach native DOM events to the RadioButton component using the @on{event} attribute (for example, @onchange, @onclick). The attribute value is an event handler method, and the event-specific data is provided via the event argument parameter.

The different event argument types for each event are,

* Focus Events - UIFocusEventArgs
* Mouse Events - UIMouseEventArgs
* Keyboard Events - UIKeyboardEventArgs
* Touch Events - UITouchEventArgs

## List of Native events supported

The following native event support has been provided to the RadioButton component:

| List of native events |  |  |  |  |
| --- | --- | --- | --- | --- |
| onchange | oninput | onblur | onfocus | onfocusout |
| onfocusin | onclick | onkeydown | onkeyup | onkeypress |

## How to bind onchange event to Radio Button

Use the `onchange` attribute to bind the change event for a radio button. The following example shows how to access the event arguments in the handler.

```cshtml
@using Syncfusion.Blazor.Buttons

<SfRadioButton Label="Credit/Debit Card" Name="payment" Value="credit/debit" TChecked="string" @onchange="onChange" @bind-Checked="stringChecked"></SfRadioButton>
<br />
<SfRadioButton Label="Net Banking" Name="payment" Value="netbanking" TChecked="string" @onchange="onChange" @bind-Checked="stringChecked"></SfRadioButton>

@code {
    private string stringChecked = "netbanking";
    private void onChange(Microsoft.AspNetCore.Components.ChangeEventArgs args)
    {
       //onChange Event triggered
    }
}

```

![Blazor RadioButton with Native Event](./images/blazor-radiobutton-native-event.png)