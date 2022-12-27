---
layout: post
title: Form validtion in Blazor DropDown List Component | Syncfusion
description: Checkout and learn here all about Form Validation in Syncfusion Blazor DropDown List component and much more.
platform: Blazor
control: DropDown List
documentation: ug
---

# Form Validation in Dropdown List

## Dropdown List inside edit form

The `EditForm` validates all data annotation rules using the `DataAnnotationsValidator`. If the Dropdown List input is valid, the form will be ready to be submit. If the Dropdown List input is invalid, an error message will be displayed until a valid value is chosen.

In this following example, the `EditForm` component is used to wrap the DropDownList and the submit button. The `DataAnnotationsValidator` component is used to enable data annotation-based validation, and the `ValidationMessage` component is used to display the validation error message. The `Required` attribute is applied to the Name field to make it a required field.

{% highlight cshtml %}

{% include_relative code-snippet/form-validation/dropdown-inside-editform.razor %}

{% endhighlight %}

![Blazor DropdownList inside editform](./images/form-validation/blazor_dropodown_with-editform.png)