---
layout: post
title: Dimension in the Predefined Dialogs in Blazor | Syncfusion
description: Check out and learn here all about dimensions in predefined dialogs in blazor and much more details.
platform: Blazor
control: Predefined Dialogs
documentation: ug
---

# Dimension in Predefined Dialogs in Blazor

Customize predefined dialog dimensions using the [DialogOptions.Height](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Popups.DialogOptions.html#Syncfusion_Blazor_Popups_DialogOptions_Height) and [DialogOptions.Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Popups.DialogOptions.html#Syncfusion_Blazor_Popups_DialogOptions_Width) properties.

By default, the `Width` and `Height` properties are set to `auto`. The dialog size adapts to its content when these values are not specified. Dimensions can be provided in pixels (for example, `300px`) or percentages (for example, `50%`) to override the default sizing.

Use the following code snippet for **alert.razor**, **confirm.razor**, and **prompt.razor** to customize dialog dimensions.

{% tabs %}

{% highlight razor tabtitle="alert.razor" %}
{% include_relative code-snippet/alert-dimension.razor %}
{% endhighlight %}

{% highlight razor tabtitle="confirm.razor" %}
{% include_relative code-snippet/confirm-dimension.razor %}
{% endhighlight %}

{% highlight razor tabtitle="prompt.razor" %}
{% include_relative code-snippet/prompt-dimension.razor %}
{% endhighlight %}

{% endtabs %}

**Results from the code snippet**

**Alert**

![Alert dialog with custom width and height](./images/blazor-alert-dimension.png)

**Confirm**

![Confirm dialog with custom width and height](./images/blazor-confirm-dimension.png)

**Prompt**

![Prompt dialog with custom width and height](./images/blazor-prompt-dimension.png)

## Max-width and max-height

To constrain the dialog’s maximum size, specify `max-width` and `max-height` CSS properties for the component’s container using the [CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Popups.DialogOptions.html#Syncfusion_Blazor_Popups_DialogOptions_CssClass) property. The component may apply an inline `max-height`; to override it, use a higher-specificity selector (or `!important` if necessary).

Use the following code to customize the max-width and max-height for the alert dialog:

{% tabs %}
{% highlight razor %}

{% include_relative code-snippet/max-width-height.razor %}

{% endhighlight %}
{% endtabs %}

![Dialog constrained with max width and max height](./images/blazor-max-width-height.png)

## Min-width and min-height

To ensure a minimum dialog size (for example, to keep action buttons visible), specify `min-width` and `min-height` CSS properties for the component’s container using the [CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Popups.DialogOptions.html#Syncfusion_Blazor_Popups_DialogOptions_CssClass) property.

Use the following code to customize the min-width and min-height for the alert dialog:

{% tabs %}
{% highlight razor %}

{% include_relative code-snippet/min-width-height.razor %}

{% endhighlight %}
{% endtabs %}

![Dialog constrained with min width and min height](./images/blazor-min-width-height.png)