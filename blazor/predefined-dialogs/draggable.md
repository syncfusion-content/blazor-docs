---
layout: post
title: Draggable in the Predefined Dialogs in Blazor | Syncfusion
description: Check out and learn here all about draggable in the predefined dialogs and much more details.
platform: Blazor
control: Predefined Dialogs
documentation: ug
---

# Draggable in Predefined Dialogs

The predefined dialogs supports dragging within its target container by grabbing the dialog header, which allows the user to reposition the dialog dynamically by using the [DialogOptions.AllowDragging](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Popups.DialogOptions.html#Syncfusion_Blazor_Popups_DialogOptions_AllowDragging) property.

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