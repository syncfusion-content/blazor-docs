---
layout: post
title: Setting Maximum Height to the Blazor Dialog component | Syncfusion
description: Checkout and learn here all about setting MaxHeight to the Dialog in Syncfusion Blazor Dialog component and more.
platform: Blazor
control: Dialog
documentation: ug
---

# Setting maximum height to the Dialog

By default, the MaxHeight for the Dialog is calculated based on the target. If the target is not specified externally, the Dialog consider the body as target and will calculate the MaxHeight based on it. We have an option to set the MaxHeight of the Dialog in the [OnOpen](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Popups.DialogEvents.html#Syncfusion_Blazor_Popups_DialogEvents_OnOpen) event.

{% tabs %}
{% highlight cshtml tabtitle="Index.razor" %}

{% include_relative code-snippet/setting-max-height.razor %}

{% endhighlight %}
{% endtabs %}