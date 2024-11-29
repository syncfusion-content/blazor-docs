---
layout: post
title: Validation in Blazor TextBox Component | Syncfusion
description: Checkout and learn here all about Validation in Syncfusion Blazor TextBox component and much more details.
platform: Blazor
control: TextBox
documentation: ug
---

# Validation in Blazor TextBox Component

The TextBox supports three types of validation styles namely `error`, `warning`, and `success`. These states are enabled by adding corresponding classes `.e-error`, `.e-warning`, or `.e-success` to the input parent element.

```cshtml
@using Syncfusion.Blazor.Inputs

<label>Success</label>
<SfTextBox Placeholder="Enter your address" CssClass="e-success" ></SfTextBox>

<label>Error</label>
<SfTextBox Placeholder="Enter your address" CssClass="e-error"></SfTextBox>

<label>Warning</label>
<SfTextBox Placeholder="Enter your address" CssClass="e-warning"></SfTextBox>
```

![Validation in Blazor TextBox](./images/blazor-textbox-validation.png)

## Limit no of character count

You can limit the number of characters by setting `maxlength` attribute using `HtmlAttributes` property.

```cshtml
@using Syncfusion.Blazor.Inputs
<SfTextBox Placeholder='First Name' HtmlAttributes="@htmlattribute"></SfTextBox>
@code {
   Dictionary<string, object> htmlattribute = new Dictionary<string, object>() 
    { 
           { "maxlength", "10" }, 
    };
}
```

TextBox supports to set the attributes directly also.
```cshtml
@using Syncfusion.Blazor.Inputs
<SfTextBox Placeholder='First Name' maxlength="10"></SfTextBox>
```

## See also

* [Create Edit Forms with FluentValidation and Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Components](https://www.syncfusion.com/blogs/post/create-edit-forms-with-fluentvalidation-and-syncfusion-blazor-components.aspx)