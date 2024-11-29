---
layout: post
title: Draggable in the Predefined Dialogs in Blazor | Syncfusion
description: Learn here all about Draggable in Syncfusion Blazor Predefined dialogs component of Syncfusion Essential JS 2 and more.
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