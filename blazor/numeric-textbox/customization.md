---
layout: post
title: Customization in Blazor Numeric TextBox Component | Syncfusion
description: Checkout and learn here all about customization in Syncfusion Blazor Numeric TextBox component and more.
platform: Blazor
control: Numeric TextBox
documentation: ug
---

# Customization in Blazor Numeric TextBox Component

## Read only Input
You can disable the text box from editing by setting the `readonly` attribute to the input element.

```cshtml
@using Syncfusion.Blazor.Inputs
<SfNumericTextBox ID="numeric" @bind-Value="@textvalue" Readonly="true">
</SfNumericTextBox>
```

## Disable interaction in input

You can disable cursor focus on the text box by setting `pointer-events` as `none` for input element as below,

```
<style>
.custom .e-control.e-numerictextbox.e-input{
    pointer-events:none;
}
</style>
```
