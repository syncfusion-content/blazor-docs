---
layout: post
title: Load webp Format Image With Blazor Carousel Component | Syncfusion
description: Checkout and learn about how to load webp format image with Blazor Carousel component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: Carousel
documentation: ug
---

# Load webp Format Image With Blazor Carousel Component

The Blazor Carousel component supports loading images in the WebP format, which is an advantageous modern image format. WebP offers superior compression for images, resulting in significantly smaller file sizes compared to traditional formats like JPEG and PNG, often without sacrificing visual quality. This can lead to improved website performance, faster load times, and reduced data usage for users.

To implement this, convert the images to WebP format and then reference them within your Carousel items.

## How to Load WebP Images

The following example illustrates how to load WebP images within the `SfCarousel` component. This approach is consistent for both Blazor Server and Blazor WebAssembly applications.

```cshtml
@using Syncfusion.Blazor.Navigations

<div class="control-container">
    <SfCarousel SwipeMode="CarouselSwipeMode.Mouse & CarouselSwipeMode.Touch">
        <CarouselItem>
            <figure class="img-container">
                <img src="https://www.gstatic.com/webp/gallery/1.webp" alt="Majestic Valley View" style="height:100%;width:100%;" />
                <figcaption class="img-caption">Majestic Valley View</figcaption>
            </figure>
        </CarouselItem>
        <CarouselItem>
            <figure class="img-container">
                <img src="https://www.gstatic.com/webp/gallery/2.webp" alt="Thrilling Rapids Adventure" style="height:100%;width:100%;" />
                <figcaption class="img-caption">Thrilling Rapids Adventure</figcaption>
            </figure>
        </CarouselItem>
        <CarouselItem>
            <figure class="img-container">
                <img src="https://www.gstatic.com/webp/gallery/3.webp" alt="Snowy Stroll" style="height:100%;width:100%;" />
                <figcaption class="img-caption">Snowy Stroll</figcaption>
            </figure>
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