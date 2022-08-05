---
layout: post
title: Customization of the Blazor Predefined Dialogs Component | Syncfusion
description: Check out and learn here all about customization of the Blazor Predefined Dialogs in the Syncfusion component and much more details.
platform: Blazor
control: Predefined Dialogs
documentation: ug
---

# Customization of Blazor Predefined Dialogs Component

## Customize action buttons

You can customize the predefined dialogs buttons by using below properties.
* [DialogOptions.PrimaryButtonOptions](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Popups.DialogOptions.html#Syncfusion_Blazor_Popups_DialogOptions_PrimaryButtonOptions) - Use this property to customize **OK** button text and appearence.
*  [https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Popups.DialogOptions.html#Syncfusion_Blazor_Popups_DialogOptions_CancelButtonOptions](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Popups.DialogOptions.html#Syncfusion_Blazor_Popups_DialogOptions_CancelButtonOptions) - Use this property to customize **Cancel** button text and appearence.

Use the following code to customize the predefined dialog action buttons.

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

![Alert action buttons Dialog](./images/blazor-alert-action-button.png)

![Confirm action buttons Dialog](./images/blazor-confirm-action-button.png)

![Prompt action buttons Dialog](./images/blazor-prompt-action-button.png)

## Show or hide close button dialog

You can show or hide close button in dialog using the [DialogOptions.ShowCloseIcon](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Popups.DialogOptions.html#Syncfusion_Blazor_Popups_DialogOptions_ShowCloseIcon) property.The default value is `true`.

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

![Alert close icon Dialog](./images/blazor-alert-close-button.png)

![Confirm close icon Dialog](./images/blazor-confirm-close-button.png)

![Prompt close icon Dialog](./images/blazor-prompt-close-button.png)

## Customize dialog content

You can load custom content in predefined dialogs using the [DialogOptions.ChildContent](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Popups.DialogOptions.html#Syncfusion_Blazor_Popups_DialogOptions_ChildContent) property. 

Use the following code to customize the dialog content to render the TextBox component inside the `Propmt` dialog to get the username from the user.

{% tabs %}
{% highlight razor %}

{% include_relative code-snippet/customize-dialog.razor %}

{% endhighlight %}
{% endtabs %}

![Customize Prompt Dialog](./images/blazor-customize-dialog.png)
