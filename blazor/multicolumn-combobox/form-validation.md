---
layout: post
title: Form Validation in Syncfusion Blazor MultiColumn ComboBox
description: Checkout and learn about Form validation with Blazor MultiColumn ComboBox component in Blazor Sever App and Blazor WebAssembly App.
platform: Blazor
control: MultiColumn ComboBox
documentation: ug
---

# Form Validation in MultiColumn ComboBox

This demonstrates the creation of a form that includes a MultiColumn ComboBox, allowing the user to select an option from a list of items. The form also includes validation, which verifies that all required fields are filled out before the form can be submitted.

## MultiColumn ComboBox inside edit form

The MultiColumn ComboBox component can be used inside an EditForm to create a form that includes a list for selecting an option. The `EditForm` component validates all data annotation rules using the `DataAnnotationsValidator` component.

When the MultiColumn ComboBox input is valid, the form is ready to be submitted. If the input is invalid, an error message will be displayed until a valid value is chosen.

* The EditForm component wraps the entire form, has the Model attribute set to the model variable of type, and triggers the OnValidSubmit() method when the form is submitted.
* The DataAnnotationsValidator component enables validation based on the Data Annotations attributes applied on the model properties.
* The ValidationSummary component displays a summary of all validation errors on the form.
* The ValidationMessage component displays a validation error message for the Name property of the model variable.
* The submit button submits the form and triggers the OnValidSubmit() method when clicked.

{% highlight cshtml %}

{% include_relative code-snippet/form-validation/combobox-inside-editform.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hXrKWVrGUcRBhJQE?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}
