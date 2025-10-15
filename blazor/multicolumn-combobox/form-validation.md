---
layout: post
title: Form Validation in Syncfusion Blazor MultiColumn ComboBox
description: Checkout and learn about Form validation with Blazor MultiColumn ComboBox component in Blazor Sever App and Blazor WebAssembly App.
platform: Blazor
control: MultiColumn ComboBox
documentation: ug
---

# Form validation in MultiColumn ComboBox

This article demonstrates how to use the Blazor MultiColumn ComboBox in a validated form with Blazor’s `EditForm`. It covers binding to a model, applying data annotations, and showing validation messages so the form submits only when required fields are valid.

## MultiColumn ComboBox inside edit form

The MultiColumn ComboBox component can be used inside an EditForm to create a form that includes a list for selecting an option. The `EditForm` component validates all data annotation rules using the `DataAnnotationsValidator` component.

When the MultiColumn ComboBox input is valid, the form is ready to be submitted; if invalid, a validation message is shown until a valid value is selected.

* The `EditForm` wraps the form, sets the `Model` to the view model instance, and triggers the configured submit handlers (`OnValidSubmit`/`OnInvalidSubmit`) on submit.
* The `DataAnnotationsValidator` enables validation based on data annotation attributes applied to the model properties (for example, `[Required]`).
* The [`ValidationSummary`](https://learn.microsoft.com/aspnet/core/blazor/forms-and-validation#validation-summary-and-validation-message-components) displays a summary of validation errors.
* The [`ValidationMessage`](https://learn.microsoft.com/aspnet/core/blazor/forms-and-validation#validation-summary-and-validation-message-components) displays a validation error for the specific bound property (via its `For` parameter).
* The submit button submits the form and invokes the appropriate submit handler.

{% highlight cshtml %}

{% include_relative code-snippet/form-validation/combobox-inside-editform.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hXrKWVrGUcRBhJQE?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}