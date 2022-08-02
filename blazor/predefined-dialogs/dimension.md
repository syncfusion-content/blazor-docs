---
layout: post
title: Dimension in Blazor Predefined Dialogs Component | Syncfusion
description: Checkout and learn here all about dimensions in Syncfusion Blazor Predefined Dialogs component and much more details.
platform: Blazor
control: Predefined Dialogs
documentation: ug
---

# Dimension in Blazor Predefined Dialogs Component

You can customize the Predefined Dialogs dimensions using [DialogOptions.Height](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Popups.DialogOptions.html#Syncfusion_Blazor_Popups_DialogOptions_Height) and [DialogOptions.Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Popups.DialogOptions.html#Syncfusion_Blazor_Popups_DialogOptions_Width) properties.

Customize the Predefined Dialogs dimensions using the [DialogOptions.Height](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Popups.DialogOptions.html#Syncfusion_Blazor_Popups_DialogOptions_Height) and [DialogOptions.Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Popups.DialogOptions.html#Syncfusion_Blazor_Popups_DialogOptions_Width) properties.

By default, the predefined dialogs `Width` and Height property value is set as `auto`.

Use the following code to customize the dialog dimensions:

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

![Alert dimension Dialog](./images/blazor-alert-dimension.png)

![confirm dimension Dialog](./images/blazor-confirm-dimension.png)

![prompt dimension Dialog](./images/blazor-prompt-dimension.png)