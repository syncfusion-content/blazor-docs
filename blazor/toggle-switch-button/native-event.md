---
layout: post
title: Events in Blazor Toggle Switch Button Component | Syncfusion
description: Checkout and learn here all about events in Syncfusion Blazor Toggle Switch Button component and more.
platform: Blazor
control: Toggle Switch Button
documentation: ug
---

# Events in Blazor Toggle Switch Button Component

## ValueChange Event

The ValueChange event triggers when the switch state changes due to user interaction. The event argument type is [ChangeEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.ChangeEventArgs-1.html). [ChangeEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.ChangeEventArgs-1.html) provides the [Checked](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.ChangeEventArgs-1.html#Syncfusion_Blazor_Buttons_ChangeEventArgs_1_Checked) and [Event](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.ChangeEventArgs-1.html#Syncfusion_Blazor_Buttons_ChangeEventArgs_1_Event) properties.

```csharp

@using Syncfusion.Blazor.Buttons

<SfSwitch @bind-Checked="isChecked" OffLabel="OFF" OnLabel="ON" ValueChange="Change" TChecked="bool?" ></SfSwitch>

@code{
    private bool? isChecked = null;
    private void Change(Syncfusion.Blazor.Buttons.ChangeEventArgs<bool?> args)
    {
        // Your code here.
    }
}

```

N> Toggle Switch Button has support for nullable boolean

## Native Events

The native event can be defined using `event` attributes (for example, @onfocus, @onkeydown). The value of the attribute is an event handler method, and event-specific data is exposed through the corresponding event argument type.

The event argument types are:
* Focus Events - UIFocusEventArgs
* Mouse Events - UIMouseEventArgs
* Keyboard Events - UIKeyboardEventArgs
* Touch Events – UITouchEventArgs

## List of Native events supported

The following native event support has been provided to the Toggle Switch Button component:

* onfocus
* onfocusout
* onfocusin
* onkeydown
* onkeyup
* onkeypress

## How to bind focus event to Toggle Switch Button

The `onfocus` attribute is used to bind the focus event for Toggle Switch Button. The following example shows how to bind the focus event to the Toggle Switch Button.

```cshtml
@using Syncfusion.Blazor.Buttons

<label>onfocus</label>
<SfSwitch @onfocus="onFocus" @bind-Checked="isChecked"></SfSwitch>

@code {
    private bool isChecked = true;
}

@code {

    private void onFocus(Microsoft.AspNetCore.Components.Web.FocusEventArgs args)
    {
       //onfocus Event triggered
    }
}

```