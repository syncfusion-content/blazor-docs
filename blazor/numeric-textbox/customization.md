---
layout: post
title: Read only Input in Blazor Numeric TextBox Component | Syncfusion
description: Checkout and learn here all about data binding in Syncfusion Blazor Numeric TextBox component and more.
platform: Blazor
control: Numeric TextBox
documentation: ug
---
# Read only Input in Blazor Numeric TextBox Component

You can disable the text box from editing by setting the `readonly` attribute to the input element.

```cshtml
@using Syncfusion.Blazor.Inputs
<SfNumericTextBox ID="numeric" @bind-Value="@textvalue" Readonly="true">
</SfNumericTextBox>
```

## Disable interaction in input

You can also remove the cursor focus on the text box by eliminating the `css` from code snippet.

```
<style>
.custom .e-control.e-numerictextbox.e-input{
    pointer-events:none;
}
</style>
```