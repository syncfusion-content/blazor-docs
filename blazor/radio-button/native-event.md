---
layout: post
title: Native Events in Blazor RadioButton Component | Syncfusion
description: Checkout and learn here all about native events in Syncfusion Blazor RadioButton component and more.
platform: Blazor
control: Radio Button
documentation: ug
---

# Native Events in Blazor RadioButton Component

You can define the native event using on `event` attribute in component. The value of attribute is treated as an event handler. The event specific data will be available in event arguments.

The different event argument types for each event are,

* Focus Events - UIFocusEventArgs
* Mouse Events - UIMouseEventArgs
* Keyboard Events - UIKeyboardEventArgs
* Touch Events - UITouchEventArgs

## List of Native events supported

The following native event support have been provided to the Radio Button component:

| List of Native events |  |  | | |
| --- | --- | --- | --- | --- |
| onchange | oninput | onblur | onfocus | onfocusout |
|onfocusin|onclick|onkeydown|onkeyup|onkeypress |

## How to bind onchange event to Radio Button

The `onchange` attribute is used to bind the onchange event for Radio Button. Here, we have explained about the sample code snippets of Radio Button.

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
