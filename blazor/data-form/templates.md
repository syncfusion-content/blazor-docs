---
layout: post
title: Templates in Blazor DataForm Component | Syncfusion
description: Checkout and learn here about how to customize the specific editor component or entire form components in Blazor DataForm component.
platform: Blazor
control: DataForm
documentation: ug
---

# Templates in DataForm component

In DataForm component we can customize the specific editor field or the entire form components using template feature. 

## Customization of specific field editor

We can customize the particular field editor with required UI customization using the [Template](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.Template.html) `RenderFragment` inside `FormItem` tag.

{% tabs %}
{% highlight razor tabtitle="Template"  %}

{% include_relative code-snippet/templates/specific-field-editor.razor %}

{% endhighlight %}
{% endtabs %}

![Blazor DataForm Form Item](images/blazor_dataform_template.png)

We can also utilize the above `Template` combination with [FormAutoGenerateItems](./form-items.md) which will generate the items except the specified `Formitem`.


## Customization of entire form

`DataForm` have the ability to customize the entire structure of the form, incorporating necessary components within it, and we can also personalize the messages displayed for validation errors.

{% tabs %}
{% highlight razor tabtitle="Razor"  %}

{% include_relative code-snippet/templates/customization-entire-form.razor %}

{% endhighlight %}
{% highlight C# tabtitle="C#"  %}

{% include_relative code-snippet/templates/customization-entire-form.cs %}

{% endhighlight %}
{% highlight cshtml tabtitle="Css"  %}

{% include_relative code-snippet/templates/customization-entire-form.css %}

{% endhighlight %}
{% endtabs %}

![Blazor DataForm Form Item](images/blazor_dataform_template.png)

We can also integrate the `FormTemplate` renderer along with `FormItem` as showcased in the below example.

{% tabs %}
{% highlight razor tabtitle="Form Template"  %}

{% include_relative code-snippet/templates/form-template.razor %}

{% endhighlight %}
{% endtabs %}

## Tooltip validation message with template

When using the `Template` renderer, we can also customize the validation message with the help of `Tooltip` component by setting `ID` field to the custom editor component similar to the form item's `ID` property.

{% tabs %}
{% highlight razor tabtitle="Razor"  %}

{% include_relative code-snippet/templates/tooltip-validation.razor %}

{% endhighlight %}

{% highlight C# tabtitle="C#"  %}

{% include_relative code-snippet/templates/tooltip-validation.cs %}

{% endhighlight %}
{% endtabs %}

![Blazor DataForm Form Item](images/blazor_dataform_tooltip_with_templates.png)

## Validation summary 

The [ValidationSummary](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.components.forms.validationsummary?view=aspnetcore-8.0) tag can be utilized to present a summary of validation messages, and it should be positioned within the `FormValidator` tag to function correctly.The below example demonstrates the usage of it.

{% tabs %}
{% highlight razor tabtitle="Razor"  %}

{% include_relative code-snippet/templates/validation-summary.razor %}

{% endhighlight %}

{% highlight C# tabtitle="C#"  %}

{% include_relative code-snippet/templates/validation-summary.cs %}

{% endhighlight %}
{% endtabs %}

![Blazor DataForm Form Item](images/blazor_dataform_validation_summary.png)
