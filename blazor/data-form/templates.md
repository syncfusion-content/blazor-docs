---
layout: post
title: Templates in Blazor DataForm Component | Syncfusion
description: Checkout and learn here about how to customize the specific editor component or entire form components in Blazor DataForm component.
platform: Blazor
control: DataForm
documentation: ug
---

# Templates in DataForm component

The DataForm component supports templating to customize either a specific field editor or the entire form layout and validation experience.

## Customization of specific field editor

Customize an individual field editor using the [Template](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.Template.html) `RenderFragment` inside a `FormItem`. This enables full control over the rendering, styling, and behavior of a single editor while retaining DataForm features such as validation and labels.

{% tabs %}
{% highlight razor tabtitle="Template"  %}

{% include_relative code-snippet/templates/specific-field-editor.razor %}

{% endhighlight %}
{% endtabs %}

![Blazor DataForm field customized using FormItem.Template](images/blazor_dataform_template.png)

The above `Template` approach can also be used alongside [FormAutoGenerateItems](./form-items.md) to auto-generate all items except those explicitly customized with a `FormItem` template.

## Customization of entire form

The `DataForm` supports customizing the entire form structure using a full-form template. This allows arranging editors, labels, buttons, and validation messages as required and customizing the appearance and text of validation errors.

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

![Blazor DataForm with a fully customized form template](images/blazor_dataform_template.png)

The `FormTemplate` renderer can also be integrated together with `FormItem` elements, as shown in the following example.

{% tabs %}
{% highlight razor tabtitle="Form Template"  %}

{% include_relative code-snippet/templates/form-template.razor %}

{% endhighlight %}
{% endtabs %}

## Tooltip validation message with template

When using the `Template` renderer, validation messages can be displayed using a tooltip component. Assign an `ID` to the custom editor that matches the form item's `ID` so that validation messages can be targeted correctly.

{% tabs %}
{% highlight razor tabtitle="Razor"  %}

{% include_relative code-snippet/templates/tooltip-validation.razor %}

{% endhighlight %}

{% highlight C# tabtitle="C#"  %}

{% include_relative code-snippet/templates/tooltip-validation.cs %}

{% endhighlight %}
{% endtabs %}

![Blazor DataForm showing validation messages in tooltips for templated editors](images/blazor_dataform_tooltip_with_templates.png)

## Validation summary 

Use the [ValidationSummary](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.components.forms.validationsummary?view=aspnetcore-8.0) tag to display a consolidated list of validation messages. It must be placed within the `FormValidator` tag to function correctly. The example below demonstrates its usage.

{% tabs %}
{% highlight razor tabtitle="Razor"  %}

{% include_relative code-snippet/templates/validation-summary.razor %}

{% endhighlight %}

{% highlight C# tabtitle="C#"  %}

{% include_relative code-snippet/templates/validation-summary.cs %}

{% endhighlight %}
{% endtabs %}

![Blazor DataForm displaying a ValidationSummary with aggregated error messages](images/blazor_dataform_validation_summary.png)