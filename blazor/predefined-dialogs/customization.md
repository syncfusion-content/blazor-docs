---
layout: post
title: Customization of the Predefined Dialogs in Blazor| Syncfusion
description: Check out and learn here all about customization of the predefined dialogs in Blazor and much more details.
platform: Blazor
control: Predefined Dialogs
documentation: ug
---

# Customization of Predefined Dialogs in Blazor

## Customize action buttons

Customize predefined dialog buttons using the following properties:
* [DialogOptions.PrimaryButtonOptions](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Popups.DialogOptions.html#Syncfusion_Blazor_Popups_DialogOptions_PrimaryButtonOptions) - Customizes the primary (OK) button text and appearance.
* [DialogOptions.CancelButtonOptions](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Popups.DialogOptions.html#Syncfusion_Blazor_Popups_DialogOptions_CancelButtonOptions) - Customizes the secondary (Cancel) button text and appearance.

Use the following code snippet for **alert.razor**, **confirm.razor**, and **prompt.razor** to customize predefined dialog action buttons.

For the alert dialog, the default button content is customized to `Okay` using the [DialogButtonOptions.Content](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Popups.DialogButtonOptions.html#Syncfusion_Blazor_Popups_DialogButtonOptions_Content) property.

For the confirm dialog, the default button content is customized to `Yes` and `No` using the `DialogButtonOptions.Content` property, and the button icons are customized using the [DialogButtonOptions.IconCss](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Popups.DialogButtonOptions.html#Syncfusion_Blazor_Popups_DialogButtonOptions_IconCss) property (provide CSS class names for icons).

For the prompt dialog, the default button content is customized to `Connect` and `Close` using the [DialogButtonOptions.Content](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Popups.DialogButtonOptions.html#Syncfusion_Blazor_Popups_DialogButtonOptions_Content) property.

{% tabs %}

{% highlight razor tabtitle="alert.razor" %}
{% include_relative code-snippet/alert-action-button.razor %}
{% endhighlight %}

{% highlight razor tabtitle="confirm.razor" %}
{% include_relative code-snippet/confirm-action-button.razor %}
{% endhighlight %}

{% highlight razor tabtitle="prompt.razor" %}
{% include_relative code-snippet/prompt-action-button.razor %}
{% endhighlight %}

{% endtabs %}

**Results from the code snippet**

**Alert**

![Alert dialog with customized action button](./images/blazor-alert-action-button.png)

**Confirm**

![Confirm dialog with customized buttons](./images/blazor-confirm-action-button.png)

**Prompt**

![Prompt dialog with customized Connect and Close buttons](./images/blazor-prompt-action-button.png)

## Show or hide dialog close button 

Show or hide the close button in predefined dialogs using the [DialogOptions.ShowCloseIcon](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Popups.DialogOptions.html#Syncfusion_Blazor_Popups_DialogOptions_ShowCloseIcon) property. The default value is `false`.

Use the following code snippet for **alert.razor**, **confirm.razor**, and **prompt.razor** to show or hide the dialog close button.

{% tabs %}

{% highlight razor tabtitle="alert.razor" %}
{% include_relative code-snippet/alert-close-button.razor %}
{% endhighlight %}

{% highlight razor tabtitle="confirm.razor" %}
{% include_relative code-snippet/confirm-close-button.razor %}
{% endhighlight %}

{% highlight razor tabtitle="prompt.razor" %}
{% include_relative code-snippet/prompt-close-button.razor %}
{% endhighlight %}

{% endtabs %}

**Results from the code snippet**

**Alert**

![Alert dialog showing the close icon](./images/blazor-alert-close-button.png)

**Confirm**

![Confirm dialog showing the close icon](./images/blazor-confirm-close-button.png)

**Prompt**

![Prompt dialog showing the close icon](./images/blazor-prompt-close-button.png)

### Customize dialog content

Load custom content in predefined dialogs using the [DialogOptions.ChildContent](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Popups.DialogOptions.html#Syncfusion_Blazor_Popups_DialogOptions_ChildContent) property.

Use the following code to customize the dialog content and render a custom TextBox component inside the prompt dialog to obtain a username from the user using the `@bind-Value` property.

{% tabs %}
{% highlight razor %}

{% include_relative code-snippet/customize-dialog.razor %}

{% endhighlight %}
{% endtabs %}

![Prompt dialog with custom content for username input](./images/blazor-customize-dialog.png)