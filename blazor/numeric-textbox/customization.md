---
layout: post
title: Customization in Blazor Numeric TextBox Component | Syncfusion
description: Checkout and learn here all about data binding in Syncfusion Blazor Numeric TextBox component and more.
platform: Blazor
control: Numeric TextBox
documentation: ug
---
# Read only Input

You can disable the text box from editing by setting the `readonly` attribute to the input element.

```cshtml
@using Syncfusion.Blazor.Inputs
<SfNumericTextBox ID="numeric" TValue="int?" CssClass="custom" @bind-Value="@textvalue">
    <NumericTextBoxEvents TValue="int?" Created="OnCreate"></NumericTextBoxEvents>
</SfNumericTextBox>

@code{
    [Inject]
    protected IJSRuntime JsRuntime { get; set; }

    public int? textvalue { get; set; } = 5;
    public void OnCreate()
    {
      JsRuntime.InvokeVoidAsync("OnCreated", "numeric");
    }
}
<style>
.custom .e-control.e-numerictextbox.e-input{
    pointer-events:none;
}
</style>
```
```
window.OnCreated = function (id) { 
    document.getElementById(id).setAttribute("readonly", true); 
 } 
 ```
Numeric textbox supports to set the attributes directly also.

```cshtml
@using Syncfusion.Blazor.Inputs
<SfNumericTextBox ID="numeric" @bind-Value="@textvalue" Readonly="true">
</SfNumericTextBox>
```

## Disable interaction in input

You can also remove the cursor focus on the text box by eliminating the `css` from code snippet.