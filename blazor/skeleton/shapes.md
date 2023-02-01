---
layout: post
title: Shapes in Blazor Skeleton Component | Syncfusion
description: Checkout and learn here all about shapes and how to use them in Syncfusion Blazor Skeleton component and much more.
platform: Blazor
control: Skeleton
documentation: ug
---

# Shapes in Blazor Skeleton Component

The Skeleton component supports various built-in shape variants to design the layout of the page. You can use the [Shape](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Notifications.SfSkeleton.html#Syncfusion_Blazor_Notifications_SfSkeleton_Shape) property to display the skeleton in various shapes, such as circle, square, rectangle, and text and create a preview of any layout.

The Skeleton component supports the following content shapes:

{% tabs %}
{% highlight razor %}

<div style="width: 200px">
    <SfSkeleton Shape=SkeletonType.Circle Width="48px" CssClass="custom-css"></SfSkeleton>
    <SfSkeleton Shape="SkeletonType.Square" Width="48px"></SfSkeleton>
    <br/><br/>
    <SfSkeleton Shape="SkeletonType.Text" Height="15px"></SfSkeleton>
    <br/><br/>
    <SfSkeleton Shape="SkeletonType.Rectangle" Height="50px" Width="100%" ></SfSkeleton>
</div>
<style>
    .custom-css {
        margin-right: 30px;
    }
</style>

{% endhighlight %}
{% endtabs %}

![Blazor Skeleton component with different shapes](./images/blazor-skeleton-shape-sample.png)

Below example demonstrates the use case example of a Skeleton component.

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

![Blazor Skeleton component with different shapes](./images/Blazor-skeleton-shape.png)