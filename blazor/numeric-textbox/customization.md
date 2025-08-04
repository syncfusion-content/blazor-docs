---
layout: post
title: Customization in Blazor Numeric TextBox Component | Syncfusion
description: Check out and learn about data binding in the Syncfusion Blazor Numeric TextBox component and more.
platform: Blazor
control: Numeric TextBox
documentation: ug
---

# Customization in Blazor Numeric TextBox Component

## Read only Input

You can disable the text box from editing by setting the `readonly` attribute to numeric textbox where textbox is marked as read-only. Still end-users can select text in textbox and only editing is disabled.  

```cshtml
@using Syncfusion.Blazor.Inputs
<SfNumericTextBox ID="numeric" @bind-Value="@textvalue" Readonly="true">
</SfNumericTextBox>
```

![Blazor NumericTextBox](./images/blazor-numericte-xtbox-customization.png)

## Disable interaction in input

You can disable cursor focus and selection on the text box by setting `pointer-events` as `none` for input element as below,


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
