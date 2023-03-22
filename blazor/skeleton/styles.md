---
layout: post
title: Styles in Blazor Skeleton Component | Syncfusion
description: Checkout and learn here all about styles and how to use them in Syncfusion Blazor Skeleton component and much more.
platform: Blazor
control: Skeleton
documentation: ug
---

# Styles in Blazor Skeleton Component

You can customize skeleton component in the below ways.

## CssClass

You can customize the style of a Skeleton component by using [CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Notifications.SfSkeleton.html#Syncfusion_Blazor_Notifications_SfSkeleton_CssClass). The appearance of Blazor Skeleton can be customized by changing the wave color, background color, width, and height.

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

You can use the [Visible](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Notifications.SfSkeleton.html#Syncfusion_Blazor_Notifications_SfSkeleton_Visible) property which defines the visible state of Skeleton.

{% tabs %}
{% highlight razor %}

<SfSkeleton Shape=SkeletonType.Circle Width="60px" Visible=false></SfSkeleton>

{% endhighlight %}
{% endtabs %}
