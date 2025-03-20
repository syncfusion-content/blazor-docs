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

You can customize the predefined dialogs buttons by using below properties.
* [DialogOptions.PrimaryButtonOptions](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Popups.DialogOptions.html#Syncfusion_Blazor_Popups_DialogOptions_PrimaryButtonOptions) - Use this property to customize **OK** button text and appearence.
* [DialogOptions.CancelButtonOptions](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Popups.DialogOptions.html#Syncfusion_Blazor_Popups_DialogOptions_CancelButtonOptions) - Use this property to customize **Cancel** button text and appearence.

Use the following code snippet for **alert.razor**, **confirm.razor** and **prompt.razor** to customize the predefined dialog action buttons.

For alert dialog , customized the default dialog button content as `Okay` by using the [DialogButtonOptions.Content](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Popups.DialogButtonOptions.html#Syncfusion_Blazor_Popups_DialogButtonOptions_Content) property.

For confirm dialog, customized the default dialog buttons content as `Yes` and `No` by using the `DialogButtonOptions.Content` property and also customized the dialog button icons by using [DialogButtonOptions.IconCss](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Popups.DialogButtonOptions.html#Syncfusion_Blazor_Popups_DialogButtonOptions_IconCss) property.

For prompt dialog , customized the default dialog buttons content as `Connect` and `Close` by using [DialogButtonOptions.Content](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Popups.DialogButtonOptions.html#Syncfusion_Blazor_Popups_DialogButtonOptions_Content) property.

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

![Alert action buttons Dialog](./images/blazor-alert-action-button.png)

**Confirm**

![Confirm action buttons Dialog](./images/blazor-confirm-action-button.png)

**Prompt**

![Prompt action buttons Dialog](./images/blazor-prompt-action-button.png)

## Show or hide dialog close button 

You can show or hide close button in dialog using the [DialogOptions.ShowCloseIcon](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Popups.DialogOptions.html#Syncfusion_Blazor_Popups_DialogOptions_ShowCloseIcon) property.The default value is `false`.

Use the following code snippet for **alert.razor**, **confirm.razor** and **prompt.razor** to customize the show or hide dialog close button.

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

![Alert close icon Dialog](./images/blazor-alert-close-button.png)

**Confirm**

![Confirm close icon Dialog](./images/blazor-confirm-close-button.png)

**Prompt**

![Prompt close icon Dialog](./images/blazor-prompt-close-button.png)

### Customize dialog content

You can load custom content in predefined dialogs using the [DialogOptions.ChildContent](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Popups.DialogOptions.html#Syncfusion_Blazor_Popups_DialogOptions_ChildContent) property. 

Use the following code to customize the dialog content and render the custom TextBox component inside the prompt dialog to obtain the username from the user using the `@bind-Value` property.

{% tabs %}
{% highlight razor %}

{% include_relative code-snippet/customize-dialog.razor %}

{% endhighlight %}
{% endtabs %}

![Customize Prompt Dialog](./images/blazor-customize-dialog.png)
