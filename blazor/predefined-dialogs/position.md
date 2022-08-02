---
layout: post
title: Positioning in Blazor Predefined Dialog Component | Syncfusion
description: Checkout and learn here all about positioning in Syncfusion Predefined Blazor Dialog component and much more details.
platform: Blazor
control: Predefined Dialogs
documentation: ug
---

# Positioning in Blazor Predefined Dialogs Component

Customize the dialog position by using the [DialogOptions.Position](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Popups.DialogOptions.html#Syncfusion_Blazor_Popups_DialogOptions_Position) property. The position can be represented with specific `X` and `Y` values.

* The `PositionDataModel.X` can be configured with a left, center, right, or offset value. By default, the value is set as `center`.
* The `PositionDataModel.Y` can be configured with a top, center, bottom, or offset value. By default, the value is set as `center`.

Use the following code to customize the dialog position:

{% tabs %}

{% highlight razor tabtitle="alert.razor" %}
{% include_relative code-snippet/alert-position.razor %}
{% endhighlight %}

{% highlight razor tabtitle="confirm.razor" %}
{% include_relative code-snippet/confirm-position.razor %}
{% endhighlight %}

{% highlight razor tabtitle="prompt.razor" %}
{% include_relative code-snippet/prompt-position.razor %}
{% endhighlight %}

{% endtabs %}

![Alert position Dialog](./images/blazor-alert-position.png)

![Confirm position Dialog](./images/blazor-confirm-position.png)