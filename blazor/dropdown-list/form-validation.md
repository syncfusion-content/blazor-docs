---
layout: post
title: Form validtion in Blazor DropDown List Component | Syncfusion
description: Checkout and learn here all about Form Validation in Syncfusion Blazor DropDown List component and much more.
platform: Blazor
control: DropDown List
documentation: ug
---

# Form Validation in Dropdown List

This demonstrates the creation of a form that includes a dropdown list, allowing the user to select an option from a list of items. The form also includes validation, which verifies that all required fields are filled out before the form can be submitted.

## Dropdown List inside edit form

The DropDownList component can be used inside an EditForm to create a form that includes a list for selecting an option. The `EditForm` component validates all data annotation rules using the `DataAnnotationsValidator` component.

When the DropDownList input is valid, the form is ready to be submitted. If the input is invalid, an error message will be displayed until a valid value is chosen.

* The EditForm component wraps the entire form, has the Model attribute set to the model variable of type Countries, and triggers the handleSubmit() method when the form is submitted.
* The DataAnnotationsValidator component enables validation based on the Data Annotations attributes applied on the model properties.
* The ValidationSummary component displays a summary of all validation errors on the form.
* The ValidationMessage component displays a validation error message for the Name property of the model variable.
* The submit button submits the form and triggers the handleSubmit() method when clicked.

{% highlight cshtml %}

{% include_relative code-snippet/form-validation/dropdown-inside-editform.razor %}

{% endhighlight %}

![Blazor DropdownList inside editform](./images/form-validation/blazor_dropodown_with-editform.png)