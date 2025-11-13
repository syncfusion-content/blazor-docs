---
layout: post
title: Animation in the Predefined Dialogs in Blazor | Syncfusion
description: Check out and learn here all about animation in the predefined dialogs in Blazor and much more details.
platform: Blazor
control: Predefined Dialogs
documentation: ug
---

# Animation in Predefined Dialogs in Blazor

The predefined dialogs (Alert, Confirm, and Prompt) support animation on open and close. Customize the animation `Delay` (ms), `Duration` (ms), and `Effect` using the [DialogOptions.AnimationSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Popups.DialogOptions.html#Syncfusion_Blazor_Popups_DialogOptions_AnimationSettings) property of type [DialogAnimationSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Popups.DialogAnimationSettings.html). The `Effect` accepts values from the [DialogEffect](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Popups.DialogEffect.html) enumeration. If not specified, the dialog uses its default animation settings.

In the following sample, the zoom effect (`DialogEffect.Zoom`) is used. The dialog opens with a zoom-in animation and closes with a zoom-out animation.

{% tabs %}

{% highlight razor tabtitle="alert.razor" %}
{% include_relative code-snippet/alert-animation.razor %}
{% endhighlight %}

{% highlight razor tabtitle="confirm.razor" %}
{% include_relative code-snippet/confirm-animation.razor %}
{% endhighlight %}

{% highlight razor tabtitle="prompt.razor" %}
{% include_relative code-snippet/prompt-animation.razor %}
{% endhighlight %}

{% endtabs %}