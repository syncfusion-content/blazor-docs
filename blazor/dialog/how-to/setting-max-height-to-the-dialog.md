---
layout: post
title: How to set maximum height in Blazor Dialog | Syncfusion®
description: Set the MaxHeight of the Blazor Dialog so long content scrolls within the dialog instead of expanding beyond the viewport.
platform: Blazor
control: Dialog
documentation: ug
---

# How to set maximum height in Blazor Dialog

By default, the MaxHeight for the Dialog is calculated based on the target. If the target is not specified externally, the Dialog consider the body as target and will calculate the MaxHeight based on it. We have an option to set the MaxHeight of the Dialog in the [OnOpen](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Popups.DialogEvents.html#Syncfusion_Blazor_Popups_DialogEvents_OnOpen) event.

{% tabs %}
{% highlight cshtml tabtitle="Index.razor" %}

{% include_relative code-snippet/setting-max-height.razor %}

{% endhighlight %}
{% endtabs %}
