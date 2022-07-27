---
layout: post
title: Draggable in Blazor Predefined Dialogs Component | Syncfusion
description: Checkout and learn here all about draggable in Syncfusion Blazor Predefined Dialogs component and much more details.
platform: Blazor
control: Predefined Dialogs
documentation: ug
---

# Draggable in Blazor Predefined Dialogs Component

The Predefined Dialogs supports dragging within its target container by grabbing the Dialog header, which allows the user to reposition the Dialog dynamically by using the [DialogOptions.AllowDragging](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Popups.DialogOptions.html#Syncfusion_Blazor_Popups_DialogOptions_AllowDragging) property.

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