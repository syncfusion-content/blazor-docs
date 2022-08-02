---
layout: post
title: Customization of Blazor Predefined Dialogs Component | Syncfusion
description: Checkout and learn here all about customization of Blazor Predefined Dialogs in Syncfusion  component and much more details.
platform: Blazor
control: Predefined Dialogs
documentation: ug
---

# Customization of Blazor Predefined Dialogs Component

## Customization of Action Buttons

Customize the Predefined Dialogs buttons by using the [DialogOptions.PrimaryButtonOptions](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Popups.DialogOptions.html#Syncfusion_Blazor_Popups_DialogOptions_PrimaryButtonOptions) property. Use the following code to customize the predefined dialog buttons.

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

## Customization of close button dialog

Customize the close icon using the [DialogOptions.ShowCloseIcon](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Popups.DialogOptions.html#Syncfusion_Blazor_Popups_DialogOptions_ShowCloseIcon) property. If the `ShowCloseIcon` property is set to true, then the close icon will appear. Use the following code to enable the `ShowCloseIcon`.

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

## Customization of dialog content

Customize the Predefined Dialogs using the [DialogOptions.ChildContent](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Popups.DialogOptions.html#Syncfusion_Blazor_Popups_DialogOptions_ChildContent) property. Use the following code to customize the dialog content to render the TextBox component inside the `Propmt` dialog to get the username from the user.

{% tabs %}
{% highlight razor %}

{% include_relative code-snippet/customize-dialog.razor %}

{% endhighlight %}
{% endtabs %}

![Customize Prompt Dialog](./images/blazor-customize-dialog.png)