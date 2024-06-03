---
layout: post
title: Form Binding in Blazor DataForm Component | Syncfusion
description: Checkout and learn here about Model ,EditContext and Custom Validation attributes binding with Blazor DataForm component.
platform: Blazor
control: DataForm
documentation: ug
---

# Form binding in DataForm component

This segment provides a concise overview of the concepts involved in associating a [Model](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.components.forms.editform.model?view=aspnetcore-7.0#microsoft-aspnetcore-components-forms-editform-model) or [EditContext](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.components.forms.editform.editcontext?view=aspnetcore-7.0#microsoft-aspnetcore-components-forms-editform-editcontext) with a Data Form.

## Model binding 

The following example illustrates how the `Model` is bound to the DataForm component using the user-defined `EventRegistration` model class.

{% tabs %}
{% highlight razor tabtitle="Model"  %}

{% include_relative code-snippet/form-binding/model-binding.razor %}

{% endhighlight %}
{% endtabs %}

![Blazor DataForm Model Binding](images/blazor_dataform_formbinding.png)

## Edit context binding 

The following example illustrates how the `EditContext` is bound to the DataForm component using the user-defined `EventRegistration` model class.

{% tabs %}
{% highlight razor tabtitle="EditContext"  %}

{% include_relative code-snippet/form-binding/edit-context-binding.razor %}

{% endhighlight %}
{% endtabs %}

