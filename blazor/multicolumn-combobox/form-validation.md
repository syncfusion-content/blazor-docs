---
layout: post
title: Form Validation in Blazor MultiColumn ComboBox Component | Syncfusion®
description: Checkout and learn about Form validation with Blazor MultiColumn ComboBox component in Blazor Sever App and Blazor WebAssembly App.
platform: Blazor
control: MultiColumn ComboBox
documentation: ug
---

# Form Validation in MultiColumn ComboBox

This article demonstrates how to use the Blazor MultiColumn ComboBox in a validated form with Blazor's `EditForm`. It covers binding to a model, applying data annotations, and showing validation messages so the form submits only when required fields are valid.

> The `EditForm` and `DataAnnotationsValidator` components require an interactive render mode (for example, `InteractiveServer`, `InteractiveWebAssembly`, or `InteractiveAuto`). Confirm that the form's hosting page has the appropriate render mode applied.

## MultiColumn ComboBox Inside an EditForm

The MultiColumn ComboBox component can be used inside an `EditForm` to create a form that includes a list for selecting an option. The `EditForm` component validates all data annotation rules using the `DataAnnotationsValidator` component.

When the MultiColumn ComboBox input is valid, the form is ready to be submitted; if invalid, a validation message is shown until a valid value is selected.

* The `EditForm` component wraps the entire form, has the `Model` attribute set to the model variable, and triggers the `OnValidSubmit` event when the form is submitted.
* The `DataAnnotationsValidator` component enables validation based on the `[Required]`, `[Range]`, and other data annotation attributes applied to the model properties.
* The `ValidationSummary` component displays a summary of all validation errors on the form.
* The `ValidationMessage` component displays a validation error message for the `Name` property of the model variable.
* The submit button submits the form and triggers the `OnValidSubmit` event when clicked.

### Sample model

```csharp
public class Order
{
    [Required(ErrorMessage = "Please select a product.")]
    public string Name { get; set; }
}
```

{% highlight cshtml %}

{% include_relative code-snippet/form-validation/combobox-inside-editform.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hXrKWVrGUcRBhJQE?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}