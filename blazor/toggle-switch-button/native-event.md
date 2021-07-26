---
layout: post
title: Native Event in Blazor Toggle Switch Button  Component | Syncfusion 
description: Learn about Native Event in Blazor Toggle Switch Button  component of Syncfusion, and more details.
platform: Blazor
control: Toggle Switch Button 
documentation: ug
---

# Overview

## ValueChange Event

The ValueChange event will triggers when Switch state has been changed by user interaction.

```csharp

@using Syncfusion.Blazor.Buttons

<SfSwitch @bind-Checked="isChecked" OffLabel="OFF" OnLabel="ON" ValueChange="Change" TChecked="bool?" ></SfSwitch>

@code{
    private bool? isChecked = null;
    private void Change(ChangeEventArgs<bool?> args)
    {
        // Your code here.
    }
}

```

> Toggle Switch Button has support for nullable boolean

## Native Events

You can define the native event using on `event` attribute in component. The value of attribute is treated as an event handler. The event specific data will be available in event arguments.

The different event argument types for each event are,

* Focus Events - UIFocusEventArgs
* Mouse Events - UIMouseEventArgs
* Keyboard Events - UIKeyboardEventArgs
* Touch Events – UITouchEventArgs

## List of Native events supported

We have provided the following native event support to the Toggle Switch Button component:

| List of Native events |  |  | | | |
| --- | --- | --- | --- | --- | --- |
|onfocus|onfocusout|onfocusin|onkeydown|onkeyup|Onkeypress|

## How to bind focus event to Toggle Switch Button

The `onfocus` attribute is used to bind the focus event for Toggle Switch Button. Here, we have explained about the sample code snippets of Toggle Switch Button.

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