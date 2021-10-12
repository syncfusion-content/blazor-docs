---
layout: post
title: Sizing in Blazor TextBox Component | Syncfusion
description: Checkout and learn here all about Sizing in Syncfusion Blazor TextBox component and much more details.
platform: Blazor
control: TextBox
documentation: ug
---

# Sizing in Blazor TextBox Component

The TextBox can be rendered in two different sizes:

Property   | Description
------------ | -------------
  Normal     | By default, the TextBox is rendered with normal size.
  Small      | Add `e-small` class to the input element, or else add to the input container.

```cshtml
@using Syncfusion.Blazor.Inputs

<label>Normal</label>
<SfTextBox Placeholder="Enter text"></SfTextBox>

<label>Float input</label>
<SfTextBox Placeholder="Focus the input" FloatLabelType="@FloatLabelType.Auto"></SfTextBox>

<label>Small</label>
<SfTextBox Placeholder="Enter text" CssClass="e-small"></SfTextBox>

<label>Float input</label>
<SfTextBox Placeholder="Focus the input" CssClass="e-small" FloatLabelType="@FloatLabelType.Auto"></SfTextBox>
```

![Changin Blazor TextBox Size](./images/blazor-textbox-change-size.png)