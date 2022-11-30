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

Below example demonstrates a list with pulse effect skeleton.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Notifications

<ul id="skeleton-list" class="e-card">
    <li>
        <div class='cardProfile'>
            <SfSkeleton Shape=SkeletonType.Circle Width="40px" Effect=ShimmerEffect.Pulse></SfSkeleton>
        </div>
        <div>
            <SfSkeleton Width="60%" Height='15px' Effect=ShimmerEffect.Pulse></SfSkeleton><br/>
            <SfSkeleton Width="40%" Height='15px' Effect=ShimmerEffect.Pulse></SfSkeleton>
        </div>
    </li>
    <li>
        <div class='cardProfile'>
            <SfSkeleton Shape=SkeletonType.Circle Width="40px" Effect=ShimmerEffect.Pulse></SfSkeleton>
        </div>
        <div>
            <SfSkeleton Width="60%" Height='15px' Effect=ShimmerEffect.Pulse></SfSkeleton><br/>
            <SfSkeleton Width="40%" Height='15px' Effect=ShimmerEffect.Pulse></SfSkeleton>
        </div>
    </li>
</ul>

<style>
    #skeleton-list {
      padding-left: 12px;
      padding-top: 7px;
      line-height: inherit;
    }

    #skeleton-list li {
      list-style: none;
      display: flow-root;
      margin-bottom: 9px;
    }

    .cardProfile {
      float: left;
      margin-right: 15px;
    }
</style>

{% endhighlight %}
{% endtabs %}

![Blazor Skeleton Pulse Effect](./images/Blazor-skeleton-Effect.png)