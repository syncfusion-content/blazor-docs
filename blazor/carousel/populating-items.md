---
layout: post
title: Populating items with Blazor Carousel Component | Syncfusion®
description: Checkout and learn about populating items with Blazor Carousel component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: Carousel
documentation: ug
---

# Populating items in Blazor Carousel component

## Populating items using CarouselItem

You can populate the Carousel by declaring `CarouselItem` child components inside `SfCarousel`. You can customize the transition interval for each item separately using the `Interval` property on `CarouselItem`. The following example demonstrates populating items using `CarouselItem`.

```cshtml
@using Syncfusion.Blazor.Navigations

<div class="control-container">
    <SfCarousel>
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
{% previewsample "https://blazorplayground.syncfusion.com/embed/VXVxjxWVUhhiStlD?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" %}

## Selection

By default, the Carousel displays the first slide. You can select a different slide in one of the following ways:

* Select an item using the property.
* Select an item using the method.

### Select an item using the property

Use the [SelectedIndex](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfCarousel.html#Syncfusion_Blazor_Navigations_SfCarousel_SelectedIndex) property (default: `0`) to set the slide displayed at initial rendering, or to switch to a specific slide at any time. The two-way bindable form (`@bind-SelectedIndex`) keeps the property synchronized with the active index.

```cshtml
@using Syncfusion.Blazor.Navigations

<div class="control-container">
    <SfCarousel @bind-SelectedIndex="@CurrentIndex">
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
    int CurrentIndex = 2;
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
{% previewsample "https://blazorplayground.syncfusion.com/embed/hDBRXxMLgBrfFPXo?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Carousel selected slide](images/selected_index.webp)" %}

### Select an item using the method

Use the [`PreviousAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfCarousel.html#Syncfusion_Blazor_Navigations_SfCarousel_PreviousAsync) or [`NextAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfCarousel.html#Syncfusion_Blazor_Navigations_SfCarousel_NextAsync) public methods of the Carousel component to navigate to the previous or next slide programmatically.

```cshtml
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Navigations

<div class="container">
    <div class="row control-container">
        <SfCarousel @ref="@CarouselRef" @bind-SelectedIndex="@CurrentIndex" ButtonsVisibility="CarouselButtonVisibility.Hidden">
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
    <div class="row justify-content-center">
        <SfButton CssClass="w-auto" @onclick="@(()=>OnNavigationClick(CarouselSlideDirection.Previous))">Previous</SfButton>
        <SfButton CssClass="w-auto" @onclick="@(()=>OnNavigationClick(CarouselSlideDirection.Next))">Next</SfButton>
    </div>
</div>

@code {
    SfCarousel CarouselRef;
    int CurrentIndex = 2;

    async Task OnNavigationClick(CarouselSlideDirection slideDirection)
    {
        if (slideDirection == CarouselSlideDirection.Previous)
        {
            await CarouselRef.PreviousAsync();
        }
        else
        {
            await CarouselRef.NextAsync();
        }
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
{% previewsample "https://blazorplayground.syncfusion.com/embed/LtBHNHMVghLlzRml?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" %}

## Partial visible slides

The Carousel can display one complete slide along with a partial view of the adjacent (previous and next) slides at the same time. You can enable or disable this behavior using the [`PartialVisible`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfCarousel.html#Syncfusion_Blazor_Navigations_SfCarousel_PartialVisible) property (default: `false`).

```cshtml
@using Syncfusion.Blazor.Navigations

<div class="control-container">
    <SfCarousel PartialVisible="true">
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
        margin: 0 auto 2em;
        max-width: 800px;
        height: 300px;
    }

    .img-container {
        margin: 0 10px;
        width: 100%;
        height: 100%;
    }

    .img-caption {
        bottom: 4em;
        color: #fff;
        font-size: 12pt;
        height: 2em;
        position: relative;
        padding: 0.3em 1em;
        text-align: center;
        width: 100%;
    }

</style>
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/LNBdXRshqBqhCAOS?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Carousel partial visible slide](images/partial-visible.webp)" %}

N> Slide animation applies only when `PartialVisible` is enabled.

The last slide is displayed as a partial slide during initial rendering when the [`Loop`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfCarousel.html#Syncfusion_Blazor_Navigations_SfCarousel_Loop) and `PartialVisible` properties are both enabled.

The previous slide is not displayed at initial rendering when `Loop` is disabled.

The following example demonstrates the `PartialVisible` behavior when `Loop` is disabled.

```cshtml
@using Syncfusion.Blazor.Navigations

<div class="control-container">
    <SfCarousel PartialVisible="true" Loop="false">
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
        margin: 0 auto 2em;
        max-width: 800px;
        height: 300px;
    }

    .img-container {
        margin: 0 10px;
        width: 100%;
        height: 100%;
    }

    .img-caption {
        bottom: 4em;
        color: #fff;
        font-size: 12pt;
        height: 2em;
        position: relative;
        padding: 0.3em 1em;
        text-align: center;
        width: 100%;
    }

</style>
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/rjVxXniVUBqodeNT?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Carousel partial visible slide](images/without-loop.webp)" %}

## See also

* [Customizing partial slides area size](./styles-and-appearance#customizing-partial-slides-size)