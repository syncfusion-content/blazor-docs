---
layout: post
title: Customization in Blazor Numeric TextBox Component | Syncfusion®
description: Checkout and learn here all the features about data binding in Blazor Numeric TextBox component and more details.
platform: Blazor
control: Numeric TextBox
documentation: ug
---

# Customization in Blazor Numeric TextBox Component

## Read-only input

Make the Numeric TextBox non-editable by setting the [Readonly](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfNumericTextBox-1.html#Syncfusion_Blazor_Inputs_SfNumericTextBox_1_Readonly) property. In read-only mode, users can still focus the field and select its content, but they cannot modify the value. This state maps to `aria-readonly` for assistive technologies. To completely disable user interaction (including focus), use the `Enabled` property instead, which maps to `aria-disabled`.

```cshtml
@using Syncfusion.Blazor.Inputs
<SfNumericTextBox ID="numeric" @bind-Value="@textvalue" Readonly="true">
</SfNumericTextBox>

@code {
    private int? textvalue = 5;
}
```

![Blazor Numeric TextBox](./images/blazor-numericte-xtbox-customization.png)

## Disable interaction in input

Completely disable cursor focus and selection on the text box by setting the `Enabled` property to `false`.

```cshtml
@using Syncfusion.Blazor.Inputs
<SfNumericTextBox ID="numeric" @bind-Value="@textvalue" Enabled="false">
</SfNumericTextBox>

@code {
    private int? textvalue = 5;
}
```

Alternatively, keep the field focusable but disable only pointer interactions by setting `pointer-events: none` for the input element as shown below.

```cshtml
@using Syncfusion.Blazor.Inputs
<SfNumericTextBox ID="numeric" @bind-Value="@textvalue">
</SfNumericTextBox>
<style>
.e-control.e-numerictextbox.e-input{
    pointer-events:none;
}
</style>

@code {
    private int? textvalue = 5;
}
```
