---
layout: post
title: Native Events in Blazor CheckBox Component | Syncfusion
description: Learn here all about Native Events in Syncfusion Blazor CheckBox component and more.
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

We have provided the following native event support to the Checkbox component:

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