---
layout: post
title: Effects in Blazor Skeleton Component | Syncfusion
description: Checkout and learn here all about shimmer effects and how to use them in Syncfusion Blazor Skeleton component and much more.
platform: Blazor
control: Skeleton
documentation: ug
---

# Shimmer Effect in Blazor Skeleton Component

Use the [Effect](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Notifications.SfSkeleton.html#Syncfusion_Blazor_Notifications_SfSkeleton_Effect) property to change the animation effect of the Skeleton component. The Skeleton supports `Wave`, `Pulse`, and `Fade` effects. By default, the `Effect` is set to `Wave`.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Notifications

<SfSkeleton Shape=SkeletonType.Circle Width="60px" Effect=ShimmerEffect.Pulse></SfSkeleton>

{% endhighlight %}
{% endtabs %}

![Blazor Skeleton with Pulse effect](./images/Blazor-skeleton-pulse-effect.png)

The following example demonstrates a list with the Pulse effect applied to Skeleton placeholders.

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

![Blazor Skeleton list using Pulse effect](./images/Blazor-skeleton-Effect.png)