---
layout: post
title: Form Validation in Blazor MultiSelect Component | Syncfusion
description: Checkout and learn here all about Form Validation in Syncfusion Blazor MultiSelect component and more.
platform: Blazor
control: MultiSelect
documentation: ug
---

# Form Validation in MultiSelect

## Edit form validation

The MultiSelect component can be used inside an EditForm to build a form that supports selecting multiple values. The `EditForm` component validates data annotation rules via the `DataAnnotationsValidator` component.

When the MultiSelect input is valid, the form can be submitted. If the input is invalid, a validation message is displayed until a valid value is provided.

- The `EditForm` wraps the form, sets the `Model` parameter to a model instance, and wires up the form submit handler.
- The `DataAnnotationsValidator` enables validation based on data annotation attributes applied to model properties.
- The `ValidationSummary` displays a summary of all validation errors in the form.
- The `ValidationMessage` displays a validation error message for the property bound to the MultiSelect.
- The submit button submits the form and invokes the configured submit handler.

{% highlight cshtml %}

{% include_relative code-snippet/validators/editform-validation.razor %}

{% endhighlight %}

![Blazor MultiSelect inside EditForm](./images/form-validation/blazor_multiselect_inside-editform.png)

## Selection Limit

The number of selectable items in the MultiSelect component can be limited by setting the [MaximumSelectionLength](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfMultiSelect-2.html#Syncfusion_Blazor_DropDowns_SfMultiSelect_2_MaximumSelectionLength) property.

In the following example, the selection limit is set to three items, and the MultiSelect component displays the selected items in CheckBox mode.

{% highlight cshtml %}

{% include_relative code-snippet/validators/selection-limit.razor %}

{% endhighlight %}

![Blazor MultiSelect Dropdown with limit selection in CheckBox mode](./images/blazor-multiselect-dropdown-limit-selection.png)