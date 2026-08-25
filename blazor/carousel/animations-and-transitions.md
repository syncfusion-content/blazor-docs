---
layout: post
title: Animations and Transitions in Blazor Carousel | Syncfusion®
description: Apply slide, fade, and custom animations and transitions between Blazor Carousel slides with configurable duration and easing.
platform: Blazor
control: Carousel
documentation: ug
---

# Animations and Transitions in Blazor Carousel

## Animations

### Fade animation

In Carousel, two built-in animations are provided for slide transitions. You can disable animation using the [AnimationEffect](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfCarousel.html#Syncfusion_Blazor_Navigations_SfCarousel_AnimationEffect) property. By default, `Slide` animation is applied for the transition between slides.

The following example demonstrates the `Fade` animation:

```cshtml
@using Syncfusion.Blazor.Navigations

<div class="control-container">
    <SfCarousel AnimationEffect="CarouselAnimationEffect.Fade">
        <CarouselItem>
            <figure class="img-container"><img src="https://ej2.syncfusion.com/products/images/carousel/cardinal.png" alt="cardinal" style="height:100%;width:100%;" /><figcaption class="img-caption">Cardinal</figcaption></figure>
        </CarouselItem>
        <CarouselItem>
            <figure class="img-container"><img src="https://ej2.syncfusion.com/products/images/carousel/hunei.png" alt="kingfisher" style="height:100%;width:100%;" /><figcaption class="img-caption">Kingfisher</figcaption></figure>
        </CarouselItem>
        <CarouselItem>
            <figure class="img-container"><img src="https://ej2.syncfusion.com/products/images/carousel/costa-rica.png" alt="keel-billed-toucan" style="height:100%;width:100%;" /><figcaption class="img-caption">Keel-billed-toucan</figcaption></figure>
        </CarouselItem>
        <CarouselItem>
            <figure class="img-container"><img src="https://ej2.syncfusion.com/products/images/carousel/kaohsiung.png" alt="yellow-warbler" style="height:100%;width:100%;" /><figcaption class="img-caption">Yellow-warbler</figcaption></figure>
        </CarouselItem>
        <CarouselItem>
           <figure class="img-container"><img src="https://ej2.syncfusion.com/products/images/carousel/bee-eater.png" alt="bee-eater" style="height:100%;width:100%;" /><figcaption class="img-caption">Bee-eater</figcaption></figure>
        </CarouselItem>
    </SfCarousel>
</div>

<style>
    .control-container {
        height: 300px;
        margin: 0 auto;
        width: 500px;
    }

    .img-container {
        height: 100%;
        margin: 0;
    }

    .img-caption {
        color: #fff;
        font-size: 1rem;
        position: absolute;
        bottom: 3rem;
        width: 100%;
        text-align: center;
    }

</style>
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/hNLxZdsrAVfjOACG?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Carousel fade animation](images/fade_animation.webp)" %}

### Custom animation

You can apply customized animation effects for slide transitions by setting [`AnimationEffect`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfCarousel.html#Syncfusion_Blazor_Navigations_SfCarousel_AnimationEffect) to `CarouselAnimationEffect.Custom` and providing the animation CSS through the [`CssClass`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfCarousel.html#Syncfusion_Blazor_Navigations_SfCarousel_CssClass) property.

The following example demonstrates a `parallax` custom animation:

```cshtml
@using Syncfusion.Blazor.Navigations

<div class="control-container">
    <SfCarousel AnimationEffect="CarouselAnimationEffect.Custom" CssClass="parallax">
        <CarouselItem>
            <figure class="img-container"><img src="https://ej2.syncfusion.com/products/images/carousel/cardinal.png" alt="cardinal" style="height:100%;width:100%;" /><figcaption class="img-caption">Cardinal</figcaption></figure>
        </CarouselItem>
        <CarouselItem>
            <figure class="img-container"><img src="https://ej2.syncfusion.com/products/images/carousel/hunei.png" alt="kingfisher" style="height:100%;width:100%;" /><figcaption class="img-caption">Kingfisher</figcaption></figure>
        </CarouselItem>
        <CarouselItem>
            <figure class="img-container"><img src="https://ej2.syncfusion.com/products/images/carousel/costa-rica.png" alt="keel-billed-toucan" style="height:100%;width:100%;" /><figcaption class="img-caption">Keel-billed-toucan</figcaption></figure>
        </CarouselItem>
        <CarouselItem>
            <figure class="img-container"><img src="https://ej2.syncfusion.com/products/images/carousel/kaohsiung.png" alt="yellow-warbler" style="height:100%;width:100%;" /><figcaption class="img-caption">Yellow-warbler</figcaption></figure>
        </CarouselItem>
        <CarouselItem>
           <figure class="img-container"><img src="https://ej2.syncfusion.com/products/images/carousel/bee-eater.png" alt="bee-eater" style="height:100%;width:100%;" /><figcaption class="img-caption">Bee-eater</figcaption></figure>
        </CarouselItem>
    </SfCarousel>
</div>

<style>
    .control-container {
        height: 300px;
        margin: 0 auto;
        width: 500px;
    }

    .img-container {
        height: 100%;
        margin: 0;
    }

    .img-caption {
        color: #fff;
        font-size: 1rem;
        position: absolute;
        bottom: 3rem;
        width: 100%;
        text-align: center;
    }

    /* Parallax animation */
    .parallax .e-carousel-item {
        transition: transform 1s ease-in-out;
    }

    .parallax .e-carousel-item.e-next {
        animation: ParallaxIn 1s ease-in-out;
    }

    .parallax .e-carousel-item.e-prev {
        animation: ParallaxOut 1s ease-in-out;
    }

    @@keyframes ParallaxIn {
        from {
         opacity: 0;
        transform: scale(0) translateY(100%);
        }   

        to {
            opacity: 1;
            transform: scale(1) translateY(0);
        }
    }

    @@keyframes ParallaxOut {
        from {
            opacity: 1;
            transform: scale(1) translateY(0);
        }

        to {
            opacity: 0;
            transform: scale(0) translateY(-100%);
        }
    }

</style>
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/LNrxDHsVAhpTPgJU?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Carousel custom animation](images/custom_animation.webp)" %}

## Intervals between slides

You can set a different interval for each slide using the `Interval` property of `CarouselItem`. The default interval is `5000 ms` (5 seconds). The following example demonstrates how to set different intervals for each item.

```cshtml
@using Syncfusion.Blazor.Navigations

<div class="control-container">
    <SfCarousel>
        <CarouselItem Interval="2000">
            <div class="slide-content">Slide 1</div>
        </CarouselItem>
        <CarouselItem Interval="4000">
            <div class="slide-content">Slide 2</div>
        </CarouselItem>
        <CarouselItem>
            <div class="slide-content">Slide 3</div>
        </CarouselItem>
        <CarouselItem Interval="6000">
            <div class="slide-content">Slide 4</div>
        </CarouselItem>
        <CarouselItem Interval="8000">
            <div class="slide-content">Slide 5</div>
        </CarouselItem>
    </SfCarousel>
</div>

<style>
    .control-container {
        background-color: #adb5bd;
        height: 300px;
        margin: 0 auto;
        width: 500px;
    }

    .e-carousel .slide-content {
        align-items: center;
        display: flex;
        font-size: 1.25rem;
        height: 100%;
        justify-content: center;
    }
</style>
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/VjBxNxCVUVfbpnIM?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" %} 

N> The `Interval` property accepts values in milliseconds.

## Auto play slides

In the Carousel, slides transition continuously after the specified or default interval. You can enable or disable auto slide transitions using the [AutoPlay](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfCarousel.html#Syncfusion_Blazor_Navigations_SfCarousel_AutoPlay) property (enabled by default). The following example demonstrates how to disable auto slide transitions.

```cshtml
@using Syncfusion.Blazor.Navigations

<div class="control-container">
    <SfCarousel AutoPlay="false">
        <CarouselItem>
            <div class="slide-content">Slide 1</div>
        </CarouselItem>
        <CarouselItem>
            <div class="slide-content">Slide 2</div>
        </CarouselItem>
        <CarouselItem>
            <div class="slide-content">Slide 3</div>
        </CarouselItem>
        <CarouselItem>
            <div class="slide-content">Slide 4</div>
        </CarouselItem>
        <CarouselItem>
            <div class="slide-content">Slide 5</div>
        </CarouselItem>
    </SfCarousel>
</div>

<style>
    .control-container {
        background-color: #adb5bd;
        height: 300px;
        margin: 0 auto;
        width: 500px;
    }

    .e-carousel .slide-content {
        align-items: center;
        display: flex;
        font-size: 1.25rem;
        height: 100%;
        justify-content: center;
    }
</style>
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/hNVRDRWrKVIryvrP?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" %}

## Pause on hover

By default, slide transitions are paused when hovering the mouse pointer over the Carousel element. You can enable or disable this functionality using the [`PauseOnHover`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfCarousel.html#Syncfusion_Blazor_Navigations_SfCarousel_PauseOnHover) property (enabled by default).

The following example demonstrates how to keep the slides playing when hovering the mouse pointer over the Carousel element.

```cshtml
@using Syncfusion.Blazor.Navigations

<div class="control-container">
    <SfCarousel  PauseOnHover="false">
        <CarouselItem>
            <div class="slide-content">Slide 1</div>
        </CarouselItem>
        <CarouselItem>
            <div class="slide-content">Slide 2</div>
        </CarouselItem>
        <CarouselItem>
            <div class="slide-content">Slide 3</div>
        </CarouselItem>
        <CarouselItem>
            <div class="slide-content">Slide 4</div>
        </CarouselItem>
        <CarouselItem>
            <div class="slide-content">Slide 5</div>
        </CarouselItem>
    </SfCarousel>
</div>

<style>
    .control-container {
        background-color: #adb5bd;
        height: 300px;
        margin: 0 auto;
        width: 500px;
    }

    .e-carousel .slide-content {
        align-items: center;
        display: flex;
        font-size: 1.25rem;
        height: 100%;
        justify-content: center;
    }
</style>
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/rDBdjRWVKLIHItiK?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" %}

## Looping slides

In the Carousel, slides loop continuously by default when you reach the last slide. You can enable or disable looping using the [Loop](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfCarousel.html#Syncfusion_Blazor_Navigations_SfCarousel_Loop) property (enabled by default). The following example demonstrates how to disable looping.

```cshtml
@using Syncfusion.Blazor.Navigations

<div class="control-container">
    <SfCarousel Loop="false">
        <CarouselItem>
            <div class="slide-content">Slide 1</div>
        </CarouselItem>
        <CarouselItem>
            <div class="slide-content">Slide 2</div>
        </CarouselItem>
        <CarouselItem>
            <div class="slide-content">Slide 3</div>
        </CarouselItem>
        <CarouselItem>
            <div class="slide-content">Slide 4</div>
        </CarouselItem>
        <CarouselItem>
            <div class="slide-content">Slide 5</div>
        </CarouselItem>
    </SfCarousel>
</div>

<style>
    .control-container {
        background-color: #adb5bd;
        height: 300px;
        margin: 0 auto;
        width: 500px;
    }

    .e-carousel .slide-content {
        align-items: center;
        display: flex;
        font-size: 1.25rem;
        height: 100%;
        justify-content: center;
    }
</style>
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/rDrHjdChUhHCGnew?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Carousel Looping Slides](images/looping_slides.webp)" %}

## Slide changing events

Using the [`SelectedIndexChanged`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfCarousel.html#Syncfusion_Blazor_Navigations_SfCarousel_SelectedIndexChanged) event of the Carousel component, you can perform custom actions whenever the active slide changes.

The following example demonstrates the Carousel events:

```cshtml
@using Syncfusion.Blazor.Navigations

<div class="control-container">
    <SfCarousel SelectedIndexChanged="OnSelectedIndexChanged">
        <CarouselItem>
            <div class="slide-content">Slide 1</div>
        </CarouselItem>
        <CarouselItem>
            <div class="slide-content">Slide 2</div>
        </CarouselItem>
        <CarouselItem>
            <div class="slide-content">Slide 3</div>
        </CarouselItem>
        <CarouselItem>
            <div class="slide-content">Slide 4</div>
        </CarouselItem>
        <CarouselItem>
            <div class="slide-content">Slide 5</div>
        </CarouselItem>
    </SfCarousel>
</div>

@code {
    void OnSelectedIndexChanged(int index)
    {
        Console.WriteLine(index);
    }
}

<style>
    .control-container {
        background-color: #adb5bd;
        height: 300px;
        margin: 0 auto;
        width: 500px;
    }

    .e-carousel .slide-content {
        align-items: center;
        display: flex;
        font-size: 1.25rem;
        height: 100%;
        justify-content: center;
    }
</style>
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/hZhHDRWBULRIpgrG?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" %}

## Disable touch swiping

By default, the Carousel allows users to swipe between slides using touch actions. You can enable or disable the swipe action using the [EnableTouchSwipe](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfCarousel.html#Syncfusion_Blazor_Navigations_SfCarousel_EnableTouchSwipe) property (enabled by default). The following example demonstrates how to disable touch swiping.

```cshtml
@using Syncfusion.Blazor.Navigations

<div class="control-container">
    <SfCarousel EnableTouchSwipe="false">
        <CarouselItem>
            <div class="slide-content">Slide 1</div>
        </CarouselItem>
        <CarouselItem>
            <div class="slide-content">Slide 2</div>
        </CarouselItem>
        <CarouselItem>
            <div class="slide-content">Slide 3</div>
        </CarouselItem>
        <CarouselItem>
            <div class="slide-content">Slide 4</div>
        </CarouselItem>
        <CarouselItem>
            <div class="slide-content">Slide 5</div>
        </CarouselItem>
    </SfCarousel>
</div>

<style>
    .control-container {
        background-color: #adb5bd;
        height: 300px;
        margin: 0 auto;
        width: 500px;
    }

    .e-carousel .slide-content {
        align-items: center;
        display: flex;
        font-size: 1.25rem;
        height: 100%;
        justify-content: center;
    }
</style>
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BNBRZnWVArxYNuuP?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" %}

## Swipe modes

The [`SwipeMode`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfCarousel.html#Syncfusion_Blazor_Navigations_SfCarousel_SwipeMode) property specifies whether the Carousel transitions slides when swiping via touch, mouse, or both. Swipe modes are combined using bitwise operators.

The following swipe modes are available:

* `CarouselSwipeMode.Touch` - Allows users to swipe slides using touch actions.
* `CarouselSwipeMode.Mouse` - Allows users to swipe slides using mouse actions.
* `CarouselSwipeMode.Touch | CarouselSwipeMode.Mouse` - Allows users to swipe slides using both touch and mouse actions.
* `~(CarouselSwipeMode.Touch | CarouselSwipeMode.Mouse)` - Disables both touch and mouse actions.


```cshtml
@using Syncfusion.Blazor.Navigations

<div class="control-container">
    <SfCarousel SwipeMode="CarouselSwipeMode.Mouse & CarouselSwipeMode.Touch">
        <CarouselItem>
            <figure class="img-container"><img src="https://ej2.syncfusion.com/products/images/carousel/cardinal.png" alt="cardinal" style="height:100%;width:100%;" /><figcaption class="img-caption">Cardinal</figcaption></figure>
        </CarouselItem>
        <CarouselItem>
            <figure class="img-container"><img src="https://ej2.syncfusion.com/products/images/carousel/hunei.png" alt="kingfisher" style="height:100%;width:100%;" /><figcaption class="img-caption">Kingfisher</figcaption></figure>
        </CarouselItem>
        <CarouselItem>
            <figure class="img-container"><img src="https://ej2.syncfusion.com/products/images/carousel/costa-rica.png" alt="keel-billed-toucan" style="height:100%;width:100%;" /><figcaption class="img-caption">Keel-billed-toucan</figcaption></figure>
        </CarouselItem>
        <CarouselItem>
            <figure class="img-container"><img src="https://ej2.syncfusion.com/products/images/carousel/kaohsiung.png" alt="yellow-warbler" style="height:100%;width:100%;" /><figcaption class="img-caption">Yellow-warbler</figcaption></figure>
        </CarouselItem>
        <CarouselItem>
           <figure class="img-container"><img src="https://ej2.syncfusion.com/products/images/carousel/bee-eater.png" alt="bee-eater" style="height:100%;width:100%;" /><figcaption class="img-caption">Bee-eater</figcaption></figure>
        </CarouselItem>
    </SfCarousel>
</div>

<style>
    .control-container {
        height: 300px;
        margin: 0 auto;
        width: 500px;
    }

    .img-container {
        height: 100%;
        margin: 0;
    }

    .img-caption {
        color: #fff;
        font-size: 1rem;
        position: absolute;
        bottom: 3rem;
        width: 100%;
        text-align: center;
    }

</style>
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/rthxDnChUBQKMXup?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Carousel Swipe Mode](images/swipe.webp)" %}