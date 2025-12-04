---
layout: post
title: Draggable in the Predefined Dialogs in Blazor | Syncfusion
description: Learn how to enable draggable behavior for predefined dialogs in Blazor, including alert, confirm, and prompt dialog examples.
platform: Blazor
control: Predefined Dialogs
documentation: ug
---

# Draggable in Predefined Dialogs

Predefined dialogs support dragging by the dialog header, allowing users to reposition the dialog within its target container. Enable this behavior using the [DialogOptions.AllowDragging](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Popups.DialogOptions.html#Syncfusion_Blazor_Popups_DialogOptions_AllowDragging) property. The default value is `false`. Dragging requires a visible header; if the header is hidden or replaced, dragging behavior may be affected.

The following examples demonstrate enabling dragging for Alert, Confirm, and Prompt dialogs.

{% tabs %}

{% highlight razor tabtitle="alert.razor" %}
{% include_relative code-snippet/alert-drag.razor %}
{% endhighlight %}

{% highlight razor tabtitle="confirm.razor" %}
{% include_relative code-snippet/confirm-drag.razor %}
{% endhighlight %}

{% highlight razor tabtitle="prompt.razor" %}
{% include_relative code-snippet/prompt-drag.razor %}
{% endhighlight %}

{% endtabs %}
