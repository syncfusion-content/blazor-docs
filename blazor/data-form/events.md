---
layout: post
title: Event handlers in Blazor DataForm Component | Syncfusion
description: Checkout and learn here about how to bound event handlers and recieve necessary arguments in Blazor DataForm component.
platform: Blazor
control: DataForm
documentation: ug
---

# Event handlers in DataForm component

This section describes the available DataForm events and when to use them. The form-level submit events mirror the Blazor EditForm pipeline, and a field-level update event helps react to per-field edits.

## On submit event

The [OnSubmit](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.SfDataForm.html#Syncfusion_Blazor_DataForm_SfDataForm_OnSubmit) event is raised whenever the form is submitted, regardless of validation success or failure. Use this event to run logic that must occur on every submit (for example, logging or generic pre-processing). The callback receives the current EditContext in its event args. Handlers can be synchronous or async.

{% tabs %}
{% highlight razor tabtitle="Model" %}

{% include_relative code-snippet/events/onsubmit-model.razor %}

{% endhighlight %}
{% highlight razor tabtitle="EditContext" %}

{% include_relative code-snippet/events/onsubmit-editcontext.razor %}

{% endhighlight %}
{% endtabs %}

## On valid submit event

The [OnValidSubmit](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.SfDataForm.html#Syncfusion_Blazor_DataForm_SfDataForm_OnValidSubmit) event is triggered when the form is submitted and all validation rules are satisfied. Use this event to persist data, call APIs, or navigate on success. The callback provides the current EditContext so the validated model can be accessed. Async handlers are supported.

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

The [OnInvalidSubmit](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.SfDataForm.html#Syncfusion_Blazor_DataForm_SfDataForm_OnInvalidSubmit) event is triggered when the form is submitted and one or more validation rules fail. Use this event to show a message, focus the first invalid field, or log validation issues. The handler receives the current EditContext, which contains validation messages.

{% tabs %}
{% highlight razor tabtitle="Model" %}

{% include_relative code-snippet/events/oninvalidsubmit-model.razor %}

{% endhighlight %}
{% highlight razor tabtitle="EditContext" %}

{% include_relative code-snippet/events/oninvalidsubmit-editcontext.razor %}

{% endhighlight %}
{% endtabs %}

## On update event

The [OnUpdate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.SfDataForm.html#Syncfusion_Blazor_DataForm_SfDataForm_OnUpdate) event is invoked when a field value changes in the DataForm. The event provides the changed field name and the updated model through [FormUpdateEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.FormUpdateEventArgs.html), enabling scenarios such as dependent field updates or incremental validation.

{% tabs %}
{% highlight razor tabtitle="Model" %}

{% include_relative code-snippet/events/onupdate-model.razor %}

{% endhighlight %}
{% highlight razor tabtitle="EditContext" %}

{% include_relative code-snippet/events/onupdate-editcontext.razor %}

{% endhighlight %}
{% endtabs %}