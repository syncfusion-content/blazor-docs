---
layout: post
title: Event handlers in Blazor DataForm Component | Syncfusion
description: Checkout and learn here about how to bound event handlers and recieve necessary arguments in Blazor DataForm component.
platform: Blazor
control: DataForm
documentation: ug
---

# Event handlers in DataForm component

This segment briefly explains about the event handlers in DataForm component.

## On submit event

The [OnSubmit](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.SfDataForm.html#Syncfusion_Blazor_DataForm_SfDataForm_OnSubmit) event is activated whenever the form is submitted, regardless of whether the submission is valid or invalid.


{% tabs %}
{% highlight razor tabtitle="Model" %}

{% include_relative code-snippet/events/onsubmit-model.razor %}

{% endhighlight %}
{% highlight razor tabtitle="EditContext" %}

{% include_relative code-snippet/events/onsubmit-editcontext.razor %}

{% endhighlight %}
{% endtabs %}

## On valid submit event

he [OnValidSubmit](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.SfDataForm.html#Syncfusion_Blazor_DataForm_SfDataForm_OnValidSubmit) event is triggered when the form is submitted and all the form validation rules are satisfied.

`OnValidSubmit` is typically used to handle the form submission logic, such as saving the form data to a database, when the form data is valid.

{% tabs %}
{% highlight razor tabtitle="Model" %}

{% include_relative code-snippet/events/onvalidsubmit-model.razor %}

{% endhighlight %}
{% highlight razor tabtitle="EditContext" %}

{% include_relative code-snippet/events/onvalidsubmit-editcontext.razor %}

{% endhighlight %}
{% endtabs %}

## On invalid submit event

The [OnInvalidSubmit](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.SfDataForm.html#Syncfusion_Blazor_DataForm_SfDataForm_OnInvalidSubmit) event is triggered when the form is submitted but the form validation rules are not satisfied. It's typically used to handle scenarios when the form data is invalid.

{% tabs %}
{% highlight razor tabtitle="Model" %}

{% include_relative code-snippet/events/oninvalidsubmit-model.razor %}

{% endhighlight %}
{% highlight razor tabtitle="EditContext" %}

{% include_relative code-snippet/events/oninvalidsubmit-editcontext.razor %}

{% endhighlight %}
{% endtabs %}

## On update event

The [OnUpdate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.SfDataForm.html#Syncfusion_Blazor_DataForm_SfDataForm_OnUpdate) event will be invoked upon editing a field in the DataForm component. The changed field name and newly updated model are available through the [FormUpdateEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.FormUpdateEventArgs.html) event context. 

{% tabs %}
{% highlight razor tabtitle="Model" %}

{% include_relative code-snippet/events/onupdate-model.razor %}

{% endhighlight %}
{% highlight razor tabtitle="EditContext" %}

{% include_relative code-snippet/events/onupdate-editcontext.razor %}

{% endhighlight %}
{% endtabs %}