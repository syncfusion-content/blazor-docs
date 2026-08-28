---
layout: post
title: Form Binding in Blazor Data Form | Syncfusion®
description: Bind the Blazor Data Form to a Model, EditContext, or custom validation attribute set to drive editors and submit behavior.
platform: Blazor
control: DataForm
documentation: ug
---

# Form Binding in Blazor Data Form

This section provides an overview of associating a [Model](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.components.forms.editform.model?view=aspnetcore-7.0#microsoft-aspnetcore-components-forms-editform-model) or [EditContext](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.components.forms.editform.editcontext?view=aspnetcore-7.0#microsoft-aspnetcore-components-forms-editform-editcontext) with a Blazor Data Form.

## Model binding 

The following example illustrates how the `Model` is bound to the Blazor Data Form component using the user-defined `EventRegistration` model class. Choose Model binding for straightforward scenarios where the form manages its own validation context internally.

{% tabs %}
{% highlight razor tabtitle="Model"  %}

{% include_relative code-snippet/form-binding/model-binding.razor %}

{% endhighlight %}
{% endtabs %}

![Blazor Data Form Model Binding](images/blazor_dataform_formbinding.webp)

## Edit context binding 

The following example illustrates how the `EditContext` is bound to the Blazor Data Form component using the user-defined `EventRegistration` model class. Choose EditContext binding when advanced control over validation state, messages, or custom validation logic is required, or when sharing an EditContext across components.

{% tabs %}
{% highlight razor tabtitle="EditContext"  %}

{% include_relative code-snippet/form-binding/edit-context-binding.razor %}

{% endhighlight %}
{% endtabs %}

## FormName

The `FormName` property of the Blazor Data Form component assigns a specified value to the underlying `EditForm.FormName`. This allows unique identification of the form for processing or validation, especially in applications with multiple forms.

The following example illustrates how to add the `FormName` for the Blazor Data Form component.

{% tabs %}
{% highlight Razor %}

{% include_relative code-snippet/form-binding/form-name.razor %}

{% endhighlight %} 
{% endtabs %}