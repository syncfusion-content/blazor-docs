---
layout: post
title: Create a custom component using Blazor TextBox | Syncfusion
description: Learn here all about using Blazor TextBox component to create a custom component with tooltip validation.
platform: Blazor
control: TextBox
documentation: ug
---

# Create a Custom Component with Tooltip Validation Using Blazor TextBox

Custom component allows to reuse the defined components in a razor page anywhere in the application by using the file name of the razor page as HTML tag. For more information refer [here](https://www.syncfusion.com/faq/blazor/components/how-do-i-create-a-custom-component)

## Defining Blazor TextBox component

The TextBox component is defined in the razor page along with the required properties and event binding. The following code snippets are added in a razor file with name as CustomTextBox.

{% tabs %}
{% highlight razor tabtitle="CustomTextBox.razor" %}
{% include_relative code-snippet/CustomTextBox.razor %}
{% endhighlight %}
{% endtabs %}

T> In the above code, the properties and events are added to the razor page, and the definition for the respective properties can be done on the same page using the `@code` block or on a partial class page. 

N> It is necessary to bind `Value`, `ValueExpression`, and native `ValueChanged` event for accessing the value changes and triggering validation. To retrieve the validation message from the custom component, it is required to add the `ValidationMessage` tag in the textbox component.

## Adding the custom TextBox component in the EditForm

The EditForm with the bound model is declared on the main razor page. Inside the EditForm, the `DataAnnotationsValidator` and `CustomTextBox` with wrapped `SfTooltip` component are added. The DataAnnotationsValidator is added to enable form validation based on validation attributes declared in the model. The CustomTextBox component is then bound with the "Text" property from the model and the "Text" property contains DataAnnotations attributes used for validation. To learn more about `SfTooltip` component refer [here](https://blazor.syncfusion.com/documentation/tooltip/getting-started) 

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
{% include_relative code-snippet/Index.razor %}
{% endhighlight %}
{% endtabs %}

The SfTooltip component is wrapped around the CustomTextBox and the [`Target`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Popups.SfTooltip.html#Syncfusion_Blazor_Popups_SfTooltip_Target) property is set to the ID attribute of the CustomTextBox to display tooltip for that particular component. The `ValidationMessage` tag is placed inside the [`TooltipTemplates`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Popups.TooltipTemplates.html) to display the validation error messages inside the tooltip. 

![Custom Component with Tooltip Validation Using Blazor TextBox](../images/blazor-textBox-custom-component-with-validation.png)

T> To avoid empty tooltips, tooltips can be restricted based on the presence of text content in the `OnOpen` event callback.