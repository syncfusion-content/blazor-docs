---
layout: post
title: Shapes in Blazor Skeleton Component | Syncfusion
description: Check out and learn about the built-in shapes in the Syncfusion Blazor Skeleton component and how to use the Shape property (Circle, Square, Rectangle, Text) to design loading placeholders.
platform: Blazor
control: Skeleton
documentation: ug
---

# Shapes in Blazor Skeleton Component

The Skeleton component supports multiple built-in shapes for designing loading placeholders. Use the [Shape](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Notifications.SfSkeleton.html#Syncfusion_Blazor_Notifications_SfSkeleton_Shape) property to preview and compose any layout. Width and height can be configured per shape to match the intended content.

The Skeleton component supports the following content shapes:

## Circle skeleton shape

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Notifications

<SfSkeleton Shape=SkeletonType.Circle Width="48px"></SfSkeleton>

{% endhighlight %}
{% endtabs %}

![Blazor Skeleton circle shape](./images/Blazor-skeleton-circle-shape.png)

## Square skeleton shape

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Notifications

<SfSkeleton Shape=SkeletonType.Square Width="48px"></SfSkeleton>

{% endhighlight %}
{% endtabs %}

![Blazor Skeleton square shape](./images/Blazor-skeleton-square.png)

## Rectangle skeleton shape

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Notifications

<SfSkeleton Shape=SkeletonType.Rectangle Height="50px"></SfSkeleton>

{% endhighlight %}
{% endtabs %}

![Blazor Skeleton rectangle shape](./images/Blazor-skeleton-rectangle-shape.png)

## Text skeleton shape

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Notifications

<SfSkeleton Shape=SkeletonType.Text Height="15px"></SfSkeleton>

{% endhighlight %}
{% endtabs %}

![Blazor Skeleton text shape](./images/Blazor-skeleton-text-shape.png)

The following example demonstrates a card-style layout composed using the above Skeleton shapes.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Notifications

<div id="skeletonCard">
    <div class='cardProfile'>
        <SfSkeleton Shape=SkeletonType.Circle Width= "60px"></SfSkeleton>
    </div>
    <div class="cardinfo">
        <SfSkeleton Width="30%" Height='15px'></SfSkeleton><br/>
        <SfSkeleton Width="15%" Height='15px'></SfSkeleton>
    </div>
    <div class="cardContent">
        <SfSkeleton Shape=SkeletonType.Rectangle Width="100%" Height='150px'></SfSkeleton>
    </div>
    <div class="cardoptions">
        <SfSkeleton Shape=SkeletonType.Rectangle Width="20%" Height='32px'></SfSkeleton>
        <SfSkeleton Shape=SkeletonType.Rectangle Width="20%" Height='32px'></SfSkeleton>
    </div>
</div>

<style>
    #skeletonCard {
        padding: 10px;
        line-height: inherit;
        height: 330px;
    }

    #skeletonCard .cardProfile {
        float: left;
        margin-right: 15px;
    }

    #skeletonCard .cardinfo {
        margin-top: 10px;
        overflow: hidden;
    }

    #skeletonCard .cardContent {
        margin: 20px 0px 20px;
    }

    #skeletonCard .cardoptions {
        display: flex;
        justify-content: space-between;
    }
</style>

{% endhighlight %}
{% endtabs %}

![Blazor Skeleton card layout using multiple shapes](./images/Blazor-skeleton-shape.png)