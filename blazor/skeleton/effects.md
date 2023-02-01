---
layout: post
title: Effects in Blazor Skeleton Component | Syncfusion
description: Checkout and learn here all about shimmer effects and how to use them in Syncfusion Blazor Skeleton component and much more.
platform: Blazor
control: Skeleton
documentation: ug
---

# Shimmer Effect in Blazor Skeleton Component

You can use the [Effect](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Notifications.SfSkeleton.html#Syncfusion_Blazor_Notifications_SfSkeleton_Effect) property to change animation effect in the skeleton component. Skeleton supports `Wave`, `Pulse` and `Fade` effects and by default, the `Effect` is set to `Wave` effect.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Notifications

<SfSkeleton Shape=SkeletonType.Circle Width="60px" Effect=ShimmerEffect.Pulse></SfSkeleton>

{% endhighlight %}
{% endtabs %}

![Blazor Skeleton Pulse Effect](./images/Blazor-skeleton-pulse-effect.png)