---
layout: post
title: Methods in Blazor Data Form | Syncfusion®
description: Use the Blazor Data Form built-in methods to validate, submit, and reset the form, and to access or update field values programmatically.
platform: Blazor
control: DataForm
documentation: ug
---

# Methods in Blazor Data Form

The following methods can be invoked on the DataForm instance to manage validation and rendering behavior.

## Validate method

The [IsValid](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.SfDataForm.html#Syncfusion_Blazor_DataForm_SfDataForm_IsValid) method evaluates the form data against the configured validation rules and returns the validation result. When validation fails, associated error messages are displayed next to the corresponding fields.

{% tabs %}
{% highlight razor tabtitle="IsValid" %}

{% include_relative code-snippet/methods/isValid-method.razor %}

{% endhighlight %}
{% endtabs %}

## Refresh method

[Refresh](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.SfDataForm.html#Syncfusion_Blazor_DataForm_SfDataForm_Refresh) method updates the form to reflect any changes in the data model or configuration.It also resets the validation state, clearing any existing validation error messages. 

{% tabs %}
{% highlight razor tabtitle="Refresh" %}

{% include_relative code-snippet/methods/refresh-method.razor %}

{% endhighlight %}
{% endtabs %}