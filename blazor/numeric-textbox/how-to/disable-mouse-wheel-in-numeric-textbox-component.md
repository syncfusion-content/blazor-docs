---
layout: post
title: Disable Mouse Wheel in Blazor NumericTextBox | Syncfusion
description: Learn how to enable or disable mouse wheel scrolling in the Syncfusion Blazor Numeric TextBox component using the AllowMouseWheel property.
platform: Blazor
control: Numeric TextBox
documentation: ug
---

# Prevent Mouse Wheel from Changing Value in Blazor NumericTextBox Component

The Blazor Numeric TextBox component supports controlling mouse wheel scrolling via the `AllowMouseWheel` property. This lets you prevent value changes when the input has focus and the user scrolls the mouse wheel.

## Enable/disable mouse wheel interaction

- Default: `AllowMouseWheel` is `true`, so the value increments/decrements based on the `Step` while scrolling the mouse wheel when the input is focused.
- Disable: Set `AllowMouseWheel` to `false` to ignore mouse wheel scrolling. Other input methods (typing and spin buttons) continue to work.

```cshtml
@using Syncfusion.Blazor.Inputs

<h4>Mouse wheel disabled</h4>
<SfNumericTextBox TValue="double?" Value=10 Step=1 AllowMouseWheel="false" Placeholder="Enter a value"></SfNumericTextBox>
```
