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

`EditForm` validates all data annotation rules using `DataAnnotationsValidator`. Choose the value from the dropdown popup and if the value is valid, then the given input will be ready to submit. Otherwise, an error message will be shown until you choose the valid value.

{% highlight cshtml %}

{% include_relative code-snippet/form-validation/dropdown-inside-editform.razor %}

{% endhighlight %}

![Blazor DropdownList inside editform](./images/form-validation/blazor_dropodown_with-editform.png)