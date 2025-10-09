---
layout: post
title: Styles in Blazor Skeleton Component | Syncfusion
description: Check out and learn about styles in the Syncfusion Blazor Skeleton component, including customizing wave color, background, size, and visibility using CssClass and Visible.
platform: Blazor
control: Skeleton
documentation: ug
---

# Styles in Blazor Skeleton Component

The Skeleton component can be customized as described below.

## CssClass

Customize the style of a Skeleton component using the [CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Notifications.SfSkeleton.html#Syncfusion_Blazor_Notifications_SfSkeleton_CssClass) property. The appearance can be tailored by changing the wave color, background color, width, and height.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Notifications

<SfSkeleton Shape=SkeletonType.Circle Width="60px" CssClass="e-customize"></SfSkeleton>

<style>
    .e-customize.e-skeleton.e-shimmer-wave::after{
        background-image: linear-gradient(90deg, transparent calc(50% - 100px), 
        rgb(30 128 234 / 50%) 50%, 
        transparent calc(50% + 100px));
    }
    .e-customize.e-skeleton.e-skeleton-circle{
        background-color: #a8c1f2;
    }
</style>

{% endhighlight %}
{% endtabs %}

![Blazor Skeleton CssClass](./images/Blazor-skeleton-css-customize.png)

## Visible

Use the [Visible](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Notifications.SfSkeleton.html#Syncfusion_Blazor_Notifications_SfSkeleton_Visible) property to control whether the Skeleton is displayed.

{% tabs %}
{% highlight razor %}

<SfSkeleton Shape=SkeletonType.Circle Width="60px" Visible=false></SfSkeleton>

{% endhighlight %}
{% endtabs %}