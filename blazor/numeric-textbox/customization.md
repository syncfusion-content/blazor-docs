---
layout: post
title: Customization in Blazor Numeric TextBox Component | Syncfusion
description: Checkout and learn here all about data binding in Syncfusion Blazor Numeric TextBox component and more.
platform: Blazor
control: Numeric TextBox
documentation: ug
---

# Customization in Blazor Numeric TextBox Component

## Read-only input

Make the Numeric TextBox non-editable by setting the Readonly property. In read-only mode, users can still focus the field and select its content, but they cannot modify the value. This state maps to aria-readonly for assistive technologies. To completely disable user interaction (including focus), use the Enabled property instead, which maps to aria-disabled.

```cshtml
@using Syncfusion.Blazor.Inputs
<SfNumericTextBox ID="numeric" @bind-Value="@textvalue" Readonly="true">
</SfNumericTextBox>
```

![Blazor Numeric TextBox](./images/blazor-numericte-xtbox-customization.png)

## Disable interaction in input

Disable cursor focus and selection on the text box by setting `pointer-events` as `none` for input element as below,


```cshtml
@using Syncfusion.Blazor.Inputs
<SfNumericTextBox ID="numeric" @bind-Value="@textvalue" Readonly="true">
</SfNumericTextBox>
<style>
.e-control.e-numerictextbox.e-input{
    pointer-events:none;
}
</style>
```
