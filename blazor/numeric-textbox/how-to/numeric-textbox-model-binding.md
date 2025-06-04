---
layout: post
title: Data annotations in Blazor Numeric Textbox component | Syncfusion
description: Checkout and learn here all about model binding in Syncfusion Blazor Numeric TextBox component and more.
platform: Blazor
control: Numeric TextBox
documentation: ug
---

# Model Binding in Blazor Numeric TextBox Component

This section demonstrates the strongly typed extension support in NumericTextBox. The view which binds with any model is called as strongly typed view. You can bind any class as model to view. You can access model properties on that view. You can use data associated with model to render components.

In this sample, first click the submit button to post the selected value in the MaskedTextBox. When posting the null value, validation error message will be shown below the NumericTextBox.

```cshtml
@using System.ComponentModel.DataAnnotations
@using Syncfusion.Blazor.Inputs

<EditForm Model="@User">
    <DataAnnotationsValidator />
    <div asp-validation-summary="All" class="text-danger"></div>
    <div class="form-group">
        <SfNumericTextBox Placeholder='Enter value' @bind-Value="@User.ID"></SfNumericTextBox>
        <ValidationMessage For="@(() => User.ID)" />
    </div>
    <button type="submit" class="btn btn-primary">Submit</button>
</EditForm>

@code {

    public Customer User = new Customer();

    public class Customer
    {
        [Required(ErrorMessage = "Value is required")]

        public int? ID { get; set; }

    }
}
```


![Validation in Blazor NumericTextBox](../images/blazor-numerictextbox-validation.png)