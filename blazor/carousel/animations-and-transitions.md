---
layout: post
title: Animations and Transitions with Blazor Carousel Component | Syncfusion
description: Checkout and learn about Animations and Transitions with Blazor Carousel component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: Carousel
documentation: ug
---

# Animations and Transitions

## Animations

### Fade animation

In Carousel, two built-in animations are provided for slide transitions. You can disable animation using the `AnimationEffect` property. By default, Slide animation is applied for the transition between slides.

The following demo depicts the example for fade animation,

{% tabs %}
{% highlight cshtml tabtitle="CSHTML" %}
{% include code-snippet/carousel/animations/carousel-item/tagHelper %}
{% endhighlight %}
{% highlight c# tabtitle="Data.cs" %}
{% include code-snippet/carousel/animations/fade/fade.cs %}
{% endhighlight %}
{% endtabs %}

## Intervals between slides

Using the items property, you can set different intervals for each item to transition between slides. The default interval is `5000 ms` (5 seconds). The following example depicts the code for setting the different intervals between each item.

{% tabs %}
{% highlight cshtml tabtitle="CSHTML" %}
{% include code-snippet/carousel/animations/intervals/tagHelper %}
{% endhighlight %}
{% highlight c# tabtitle="Data.cs" %}
{% include code-snippet/carousel/animations/intervals/intervals.cs %}
{% endhighlight %}
{% endtabs %}

**Note**: Interval property can accept value in terms of milliseconds.

## Auto play slides

In the carousel, all slides transitions are performed continuously after the specified or default intervals. You can enable or disable the auto slide transition using the `AutoPlay` property. The following example depicts the code to enable or disable the auto slide transitions.

{% tabs %}
{% highlight cshtml tabtitle="CSHTML" %}
{% include code-snippet/carousel/animations/auto-play/tagHelper %}
{% endhighlight %}
{% highlight c# tabtitle="Data.cs" %}
{% include code-snippet/carousel/animations/auto-play/auto-play.cs %}
{% endhighlight %}
{% endtabs %}

## Looping slides

In the carousel, slides transitions are repeated continuously when you reach the last slide by default. You can enable or disable the infinite slide transition using the `Loop` property. The following example depicts the code to enable or disable the infinite slide transitions.

{% tabs %}
{% highlight cshtml tabtitle="CSHTML" %}
{% include code-snippet/carousel/animations/loop/tagHelper %}
{% endhighlight %}
{% highlight c# tabtitle="Data.cs" %}
{% include code-snippet/carousel/animations/loop/loop.cs %}
{% endhighlight %}
{% endtabs %}

## Slide changing events

Using the `SlideItemChanged` events of the Carousel component, you can perform sample end customization while the carousel items are switched.

The following demo depicts the example for carousel events,

{% tabs %}
{% highlight cshtml tabtitle="CSHTML" %}
{% include code-snippet/carousel/animations/slide-events/tagHelper %}
{% endhighlight %}
{% highlight c# tabtitle="Data.cs" %}
{% include code-snippet/carousel/animations/slide-events/slide-events.cs %}
{% endhighlight %}
{% endtabs %}

## Disable touch swiping

In the carousel, we can able to perform swipe the carousel slides using touch actions by default. We had the option to enable or disable the swipe action using the `EnableTouchSwipe` property. The following example depicts the code to disable the swipe action for the slide.

{% tabs %}
{% highlight cshtml tabtitle="CSHTML" %}
{% include code-snippet/carousel/animations/touch-swipe/tagHelper %}
{% endhighlight %}
{% highlight c# tabtitle="Data.cs" %}
{% include code-snippet/carousel/animations/touch-swipe/touch-swipe.cs %}
{% endhighlight %}
{% endtabs %}
