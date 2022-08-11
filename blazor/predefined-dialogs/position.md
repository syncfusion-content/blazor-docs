---
layout: post
title: Positioning in the Predefined Dialog in Blazor | Syncfusion
description: Check out and learn here all about positioning in predefined dialogs in blazor and much more details.
platform: Blazor
control: Predefined Dialogs
documentation: ug
---

# Positioning in Predefined Dialogs in Blazor

Customize the dialog position by using the [DialogOptions.Position](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Popups.DialogOptions.html#Syncfusion_Blazor_Popups_DialogOptions_Position) property. The position can be represented with specific `X` and `Y` values.

* The `PositionDataModel.X` can be configured with a left, center, right, or offset value. By default, the value is set as `center`.
* The `PositionDataModel.Y` can be configured with a top, center, bottom, or offset value. By default, the value is set as `center`.

Use the following code snippet for **alert.razor**, **confirm.razor** and **prompt.razor** to customize the position. Here, customized the dialog position as X= "top" and Y= "center".

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

**Results from the code snippet**

**Alert**

![Alert position Dialog](./images/blazor-alert-position.png)

**Confirm**

![Confirm position Dialog](./images/blazor-confirm-position.png)

**Prompt**

![Prompt position Dialog](./images/blazor-prompt-position.png)