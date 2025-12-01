---
layout: post
title: Form Validation in Blazor ComboBox Component | Syncfusion
description: Checkout and learn about Form validation with Blazor ComboBox component in Blazor Sever App and Blazor WebAssembly App.
platform: Blazor
control: ComboBox
documentation: ug
---

# Form Validation in ComboBox

This article demonstrates how to use the Syncfusion ComboBox within a Blazor EditForm to validate user input with data annotations. The example shows a form where the user selects an item from the ComboBox, and validation ensures required fields are completed before submission.

## ComboBox inside edit form

The ComboBox component can be used inside an EditForm to create a form that includes a list for selecting an option. The `EditForm` component validates all data annotation rules using the `DataAnnotationsValidator` component.

When the ComboBox input is valid, the form is ready to be submitted. If the input is invalid, an error message will be displayed until a valid value is chosen.

- The EditForm component wraps the entire form, sets the Model to a view model (for example, Countries), and invokes a submit handler when the form is submitted.
- The DataAnnotationsValidator component enables validation based on data annotation attributes (such as [Required]) applied to model properties.
- The ValidationSummary component displays a summary of all validation errors in the form.
- The ValidationMessage component displays a validation error message for the specific model property bound to the ComboBox (for example, the Name property).
- The submit button submits the form and invokes the submit handler when clicked.

{% highlight cshtml %}

{% include_relative code-snippet/form-validation/combobox-inside-editform.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hXrKWVrGUcRBhJQE?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor ComboBox inside editform](./images/form-validation/blazor_combobox_inside-editform.png)" %}
