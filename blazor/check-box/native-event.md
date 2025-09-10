---
layout: post
title: Native Events in Blazor CheckBox Component | Syncfusion
description: Checkout and learn here all about Native Events in Syncfusion Blazor CheckBox component and much more.
platform: Blazor
control: Checkbox
documentation: ug
---

# Native Events in Blazor CheckBox Component

You can define the native event using on `event` attribute in component. The value of attribute is treated as an event handler. The event specific data will be available in event arguments.

The different event argument types for each event are,

* Focus Events - UIFocusEventArgs
* Mouse Events - UIMouseEventArgs
* Keyboard Events - UIKeyboardEventArgs
* Touch Events – UITouchEventArgs

## List of Native events supported

The following native event support has been provided to the Checkbox component:

| List of Native events |  |  | | |
| --- | --- | --- | --- | --- |
| onchange | oninput | onblur | onfocusout | onfocusin |
|onfocus|onclick|onkeydown|onkeyup|onkeypress|

## How to bind onchange event to Checkbox

The `onchange` attribute is used to bind the onchange event for Checkbox. Here, we have explained about the sample code snippets of Checkbox.

```cshtml
@using Syncfusion.Blazor.Buttons

<SfCheckBox @bind-Checked="isChecked" Label="Change" @onchange="onChange"></SfCheckBox>

@code {
    private bool isChecked = true;
    private void onChange(Microsoft.AspNetCore.Components.ChangeEventArgs args)
    {
       //onChange Event triggered
    }
}
```

## How to bind ValueChange event to Checkbox

To bind the change event in the checkbox [ValueChange](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfCheckBox-1.html#Syncfusion_Blazor_Buttons_SfCheckBox_1_ValueChange) event is used and the event is triggered when the value in the checkbox changes.

N> When using multiple Syncfusion components within the same project, it is recommended to explicitly define the namespace to avoid ambiguity and ensure proper functionality.
In certain integrated development environments (IDEs), such as Playground, it is necessary to explicitly specify the namespace for event arguments. This helps prevent ambiguous reference errors, especially when both Syncfusion and native components are used without defined namespaces.


```cshtml
@using Syncfusion.Blazor.Buttons

<SfCheckBox @bind-Checked="isChecked" Label="Change" ValueChange="ValueChange" TChecked="bool"></SfCheckBox>

@code {
    private bool isChecked = true;
    private void ValueChange(Syncfusion.Blazor.Buttons.ChangeEventArgs<bool> args)
    {
        //ValueChange Event triggered
        var state = args.Checked;
    }
}
```