---
layout: post
title: Open Numeric Keyboard in Numeric TextBox Component | Syncfusion
description: Learn how to configure the Numeric TextBox component to display the numeric keyboard in web applications.
platform: Blazor
control: Numeric TextBox
documentation: ug
---

# Open Numeric Keyboard in Numeric TextBox Component

On mobile and touch devices, providing a numeric keyboard improves data entry for number inputs. This topic explains how to hint supported browsers to show a numeric keypad while keeping the Numeric TextBox behavior intact.

## Enabling the Numeric Keyboard

A practical way to suggest a numeric keypad on many mobile browsers is to set the input type to "tel", which often triggers a number-centric keypad. Behavior varies by device and browser.

Here is an example code snippet using the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Numeric TextBox component:

```csharp
@using Syncfusion.Blazor.Inputs

<div style="margin:150px auto;width:300px">
    <SfNumericTextBox TValue="int?" type="tel"></SfNumericTextBox>
</div>
```

By setting the `type` attribute to `"tel"`, the Numeric TextBox will trigger the numeric keyboard on supported devices, making it easier for users to enter numeric data.

![Open Numeric Keyboard in Numeric TextBox Component](../images/Open-Numeric-Keyboard-in-Numeric-TextBox-Component.gif)

## Fallback for Unsupported Browsers

It is important to note that not all browsers support the `type="tel"` attribute. In cases where a browser does not support this attribute, the `Numeric TextBox` will fall back to being a standard text input. This ensures that the functionality remains intact across all browsers, even if the enhanced keyboard experience is not available.

## Live Sample

To see a live example of the Numeric TextBox configured for the numeric keyboard, visit the following link:

[Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Playground - Numeric Textbox](https://blazorplayground.syncfusion.com/embed/rDLpjJrOLrHzOprq?appbar=true&editor=true&result=true&errorlist=true&theme=bootstrap5)

**Additional References:**
- [MDN Web Docs: input type="tel"](https://developer.mozilla.org/en-US/docs/Web/HTML/Element/input/tel)
