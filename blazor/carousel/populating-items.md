---
layout: post
title: Populating items with Blazor Carousel Component | Syncfusion
description: Checkout and learn about populating items with Blazor Carousel component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: Carousel
documentation: ug
---

# Populating Items with Blazor Carousel Component

## Populating items using carousel item

When rendering the Carousel component using items binding, you can assign templates for each item separately or assign a common template to each item. You can also customize the slide transition interval for each item separately. The following example code depicts the functionality as item property binding.

```cshtml
@using Syncfusion.Blazor.Navigations

<div class="control-container">
    <SfCarousel>
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

## Selection

The Carousel items will be populated from the first index of the Carousel items and can be customized using the following ways,

* Select an item using the property.
* Select an item using the method.

### Select an item using the property

Using the `SelectedIndex` property of the Carousel component, you can set the slide to be populated at the time of initial rendering else you can switch to the particular slide item.

```cshtml
@using Syncfusion.Blazor.Navigations

<div class="control-container">
    <SfCarousel @bind-SelectedIndex="@CurrentIndex">
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
    int CurrentIndex = 2;
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

### Select an item using the method

Using the `PreviousAsync` or `NextAsync` public method of the Carousel component, you can switch the current populating slide to a previous or next slide.

```cshtml
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Navigations

<div class="container">
    <div class="row control-container">
        <SfCarousel @ref="@CarouselRef" @bind-SelectedIndex="@CurrentIndex" ButtonsVisibility="CarouselButtonVisibility.Hidden">
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
