---
layout: post
title: Methods in Blazor DataForm Component | Syncfusion
description: Checkout and learn here about in-built functions along with their correct application within the Blazor DataForm component.
platform: Blazor
control: DataForm
documentation: ug
---

# Built-in methods in DataForm component

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