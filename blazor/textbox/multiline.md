---
layout: post
title: Multiline in Blazor TextBox Component | Syncfusion
description: Checkout and learn here all about Multiline in Syncfusion Blazor TextBox component and much more details.
platform: Blazor
control: TextBox
documentation: ug
---

# Multiline in Blazor TextBox Component

This feature enables the TextBox to accept multiple lines of text for scenarios such as addresses, descriptions, and comments. When Multiline is enabled, the component renders an HTML textarea element under the hood and supports vertical resizing by default.

## Create multiline textbox

The default TextBox can be converted into a multiline TextBox by setting the [Multiline](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfTextBox.html#Syncfusion_Blazor_Inputs_SfTextBox_Multiline) property to true or by passing an HTML5 textarea element to the TextBox.

N> The multiline TextBox allows resizing in the vertical direction only by default.

```cshtml
@using Syncfusion.Blazor.Inputs

<div class="multiline">
    <SfTextBox Multiline=true Placeholder="Enter your address" Value="Mr. Dodsworth Dodsworth, System Analyst, Studio 103"></SfTextBox>
</div>
<style>
     .multiline{
        margin-top: 60px;
        width: 20%;
    }
</style>
```

![Blazor Multiline TextBox](./images/blazor-multiline-textbox.png)

## Implementing floating label

Floating label behavior can be applied to a multiline TextBox by setting [FloatLabelType](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfTextBox.html#Syncfusion_Blazor_Inputs_SfTextBox_FloatLabelType) to Auto. In this mode, the Placeholder text acts as the floating label for the multiline TextBox. The placeholder can be specified using the [Placeholder](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfTextBox.html#Syncfusion_Blazor_Inputs_SfTextBox_Placeholder) property or the Placeholder attribute. Use descriptive placeholder text or an associated label to improve accessibility.

```cshtml
@using Syncfusion.Blazor.Inputs

<label>Float label type as Auto</label>
<div class="multiline">
    <SfTextBox Multiline=true FloatLabelType="@FloatLabelType.Auto" Placeholder="Enter your address"></SfTextBox>
</div>

<label>Float label type as Always</label>
<div class="multiline">
    <SfTextBox Multiline=true FloatLabelType="@FloatLabelType.Always" Placeholder="Enter your address"></SfTextBox>
</div>

<label>Float label type as Never</label>
<div class="multiline">
    <SfTextBox Multiline=true FloatLabelType="@FloatLabelType.Never" Placeholder="Enter your address"></SfTextBox>
</div>

<style>
    .multiline{
        margin-top: 60px;
        width: 20%;
    }
</style>
```

![Blazor Multiline TextBox with Floating Label](./images/blazor-textbox-multiline-float-label.png)

## Disable resizing

By default, the multiline TextBox is resizable vertically. Resizing can be disabled by applying the following CSS styles (using the CSS resize property set to none).

```CSS
textarea.e-input,
.e-float-input textarea,
.e-float-input.e-control-wrapper textarea,
.e-input-group textarea,
.e-input-group.e-control-wrapper textarea {
    resize: none;
}

```

```cshtml
@using Syncfusion.Blazor.Inputs

<SfTextBox Multiline=true FloatLabelType="@FloatLabelType.Auto" Placeholder="Enter your address"></SfTextBox>
```

![Disable Resizing in Blazor TextBox](./images/blazor-textbox-disable-resizing.png)