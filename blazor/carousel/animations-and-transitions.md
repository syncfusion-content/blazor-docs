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

```cshtml
@using Syncfusion.Blazor.Navigations

<div class="control-container">
    <SfCarousel AnimationEffect="CarouselAnimationEffect.Fade">
        <CarouselItem>
            <div class="fs-5">Slide 1</div>
        </CarouselItem>
        <CarouselItem>
            <div class="fs-5">Slide 2</div>
        </CarouselItem>
        <CarouselItem>
            <div class="fs-5">Slide 3</div>
        </CarouselItem>
        <CarouselItem>
            <div class="fs-5">Slide 4</div>
        </CarouselItem>
        <CarouselItem>
            <div class="fs-5">Slide 5</div>
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

    .e-carousel .e-carousel-items.e-carousel-fade-animation .e-carousel-item {
        align-items: center;
        border: 1px solid #f5f5f5;
        display: flex;
        justify-content: center;
    }
</style>
```

## Intervals between slides

Using the items property, you can set different intervals for each item to transition between slides. The default interval is `5000 ms` (5 seconds). The following example depicts the code for setting the different intervals between each item.

```cshtml
@using Syncfusion.Blazor.Navigations

<div class="control-container">
    <SfCarousel>
        <CarouselItem Interval="2000">
            <div class="fs-5">Slide 1</div>
        </CarouselItem>
        <CarouselItem Interval="4000">
            <div class="fs-5">Slide 2</div>
        </CarouselItem>
        <CarouselItem>
            <div class="fs-5">Slide 3</div>
        </CarouselItem>
        <CarouselItem Interval="6000">
            <div class="fs-5">Slide 4</div>
        </CarouselItem>
        <CarouselItem Interval="8000">
            <div class="fs-5">Slide 5</div>
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

    .e-carousel .e-carousel-items.e-carousel-slide-animation .e-carousel-item.e-prev,
    .e-carousel .e-carousel-items.e-carousel-slide-animation .e-carousel-item.e-next,
    .e-carousel .e-carousel-items.e-carousel-slide-animation .e-carousel-item.e-active {
        align-items: center;
        border: 1px solid #f5f5f5;
        display: flex;
        justify-content: center;
    }
</style>
```

**Note**: Interval property can accept value in terms of milliseconds.

## Auto play slides

In the carousel, all slides transitions are performed continuously after the specified or default intervals. You can enable or disable the auto slide transition using the `AutoPlay` property. The following example depicts the code to enable or disable the auto slide transitions.

```cshtml
@using Syncfusion.Blazor.Navigations

<div class="control-container">
    <SfCarousel AutoPlay="false">
        <CarouselItem>
            <div class="fs-5">Slide 1</div>
        </CarouselItem>
        <CarouselItem>
            <div class="fs-5">Slide 2</div>
        </CarouselItem>
        <CarouselItem>
            <div class="fs-5">Slide 3</div>
        </CarouselItem>
        <CarouselItem>
            <div class="fs-5">Slide 4</div>
        </CarouselItem>
        <CarouselItem>
            <div class="fs-5">Slide 5</div>
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

    .e-carousel .e-carousel-items.e-carousel-slide-animation .e-carousel-item.e-prev,
    .e-carousel .e-carousel-items.e-carousel-slide-animation .e-carousel-item.e-next,
    .e-carousel .e-carousel-items.e-carousel-slide-animation .e-carousel-item.e-active {
        align-items: center;
        border: 1px solid #f5f5f5;
        display: flex;
        justify-content: center;
    }
</style>
```

## Looping slides

In the carousel, slides transitions are repeated continuously when you reach the last slide by default. You can enable or disable the infinite slide transition using the `Loop` property. The following example depicts the code to enable or disable the infinite slide transitions.

```cshtml
@using Syncfusion.Blazor.Navigations

<div class="control-container">
    <SfCarousel Loop="false">
        <CarouselItem>
            <div class="fs-5">Slide 1</div>
        </CarouselItem>
        <CarouselItem>
            <div class="fs-5">Slide 2</div>
        </CarouselItem>
        <CarouselItem>
            <div class="fs-5">Slide 3</div>
        </CarouselItem>
        <CarouselItem>
            <div class="fs-5">Slide 4</div>
        </CarouselItem>
        <CarouselItem>
            <div class="fs-5">Slide 5</div>
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

    .e-carousel .e-carousel-items.e-carousel-slide-animation .e-carousel-item.e-prev,
    .e-carousel .e-carousel-items.e-carousel-slide-animation .e-carousel-item.e-next,
    .e-carousel .e-carousel-items.e-carousel-slide-animation .e-carousel-item.e-active {
        align-items: center;
        border: 1px solid #f5f5f5;
        display: flex;
        justify-content: center;
    }
</style>
```

## Slide changing events

Using the `SlideItemChanged` events of the Carousel component, you can perform sample end customization while the carousel items are switched.

The following demo depicts the example for carousel events,

```cshtml
@using Syncfusion.Blazor.Navigations

<div class="control-container">
    <SfCarousel SelectedIndexChanged="OnSelectedIndexChanged">
        <CarouselItem>
            <div class="fs-5">Slide 1</div>
        </CarouselItem>
        <CarouselItem>
            <div class="fs-5">Slide 2</div>
        </CarouselItem>
        <CarouselItem>
            <div class="fs-5">Slide 3</div>
        </CarouselItem>
        <CarouselItem>
            <div class="fs-5">Slide 4</div>
        </CarouselItem>
        <CarouselItem>
            <div class="fs-5">Slide 5</div>
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

    .e-carousel .e-carousel-items.e-carousel-slide-animation .e-carousel-item.e-prev,
    .e-carousel .e-carousel-items.e-carousel-slide-animation .e-carousel-item.e-next,
    .e-carousel .e-carousel-items.e-carousel-slide-animation .e-carousel-item.e-active {
        align-items: center;
        border: 1px solid #f5f5f5;
        display: flex;
        justify-content: center;
    }
</style>
```

## Disable touch swiping

In the carousel, we can able to perform swipe the carousel slides using touch actions by default. We had the option to enable or disable the swipe action using the `EnableTouchSwipe` property. The following example depicts the code to disable the swipe action for the slide.

```cshtml
@using Syncfusion.Blazor.Navigations

<div class="control-container">
    <SfCarousel EnableTouchSwipe="false">
        <CarouselItem>
            <div class="fs-5">Slide 1</div>
        </CarouselItem>
        <CarouselItem>
            <div class="fs-5">Slide 2</div>
        </CarouselItem>
        <CarouselItem>
            <div class="fs-5">Slide 3</div>
        </CarouselItem>
        <CarouselItem>
            <div class="fs-5">Slide 4</div>
        </CarouselItem>
        <CarouselItem>
            <div class="fs-5">Slide 5</div>
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

    .e-carousel .e-carousel-items.e-carousel-slide-animation .e-carousel-item.e-prev,
    .e-carousel .e-carousel-items.e-carousel-slide-animation .e-carousel-item.e-next,
    .e-carousel .e-carousel-items.e-carousel-slide-animation .e-carousel-item.e-active {
        align-items: center;
        border: 1px solid #f5f5f5;
        display: flex;
        justify-content: center;
    }
</style>
```
