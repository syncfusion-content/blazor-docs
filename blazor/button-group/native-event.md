---
layout: post
title: Native Events in Blazor Button Group Component | Syncfusion
description: Checkout and learn here all about Native Events in Syncfusion Blazor Button Group component and much more.
platform: Blazor
control: Button Group
documentation: ug
---

# Native Events in Blazor Button Group Component

You can define the native event using `event` attribute in component. The value of attribute is treated as an event handler. The event specific data will be available in event arguments.

The different event argument types for each event are,

* Focus Events - UIFocusEventArgs
* Mouse Events - UIMouseEventArgs
* Keyboard Events - UIKeyboardEventArgs
* Touch Events – UITouchEventArgs

## List of native events supported for default Button Group

The following native event support has been provided to the Button Group component:

| List of Native events |  |  | |
| --- | --- | --- | --- |
| onclick | onblur | onfocus | onfocusout |
|onmousemove|onmouseover|onmouseout|onmousedown|onmouseup|
|ondblclick|onkeydown|onkeyup|onkeypress|
|ontouchend|onfocusin|onmouseup|ontouchstart|

## How to bind click event to Button Group

The `onclick` attribute is used to bind the click event for button group. Here, we have explained about the sample code snippets.

```csharp

@using Syncfusion.Blazor.SplitButtons

<SfButtonGroup>
    <ButtonGroupButton @onclick="onLeftClick">Left</ButtonGroupButton>
    <ButtonGroupButton @onclick="onCenterClick">Center</ButtonGroupButton>
    <ButtonGroupButton @onclick="onRightClick">Right</ButtonGroupButton>
</SfButtonGroup>

@code{
    private void onLeftClick()
    {
        // handle the left click event
    }
    private void onCenterClick()
    {
        // handle the center click event
    }
    private void onRightClick()
    {
        // handle the right click event
    }
}
```

## List of native events supported for Single / Multiple selection mode Button Group

The following native event support has been provided to the Button Group component:

| List of Native events |  |  | | |
| --- | --- | --- | --- | --- |
| onchange | oninput | onblur | onfocusout | onfocusin |
|onfocus|onclick|onkeydown|onkeyup|onkeypress|

## How to bind onchange event to Button Group

The `onchange` attribute is used to bind the change event for button group. Here, we have explained about the sample code snippets.

```csharp

@using Syncfusion.Blazor.SplitButtons

<SfButtonGroup Mode="Syncfusion.Blazor.SplitButtons.SelectionMode.Single">
    <ButtonGroupButton @onchange="onLeftClick" Value="Left">Left</ButtonGroupButton>
    <ButtonGroupButton @onchange="onCenterClick" Value="Center">Center</ButtonGroupButton>
    <ButtonGroupButton @onchange="onRightClick" Value="Right">Right</ButtonGroupButton>
</SfButtonGroup>

@code{
    private void onLeftClick(ChangeEventArgs args)
    {
        var SelectedValue = args.Value;
    }
    private void onCenterClick(ChangeEventArgs args)
    {
        var SelectedValue = args.Value;
    }
    private void onRightClick(ChangeEventArgs args)
    {
        var SelectedValue = args.Value;
    }
}
```
