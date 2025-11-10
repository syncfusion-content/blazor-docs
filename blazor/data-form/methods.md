---
layout: post
title: Methods in Blazor DataForm Component | Syncfusion
description: Checkout and learn here about in-built functions along with their correct application within the Blazor DataForm component.
platform: Blazor
control: DataForm
documentation: ug
---

# Inbuilt methods in DataForm component

The classification of methods that can be invoked by using the DataForm instance are outlined below 

## Validate method

 The [IsValid](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.SfDataForm.html#Syncfusion_Blazor_DataForm_SfDataForm_IsValid) method evaluates the form data against defined validation rules to determine its validity.


{% tabs %}
{% highlight razor tabtitle="IsValid" %}

{% include_relative code-snippet/methods/isValid-method.razor %}

{% endhighlight %}
{% endtabs %}

## Refresh method

 The [Refresh](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.SfDataForm.html#Syncfusion_Blazor_DataForm_SfDataForm_Refresh) method updates the form to reflect any changes in the data model or configuration.It also resets the validation state, clearing any existing validation error messages. 

{% tabs %}
{% highlight razor tabtitle="Refresh" %}

{% include_relative code-snippet/methods/refresh-method.razor %}

{% endhighlight %}
{% endtabs %}