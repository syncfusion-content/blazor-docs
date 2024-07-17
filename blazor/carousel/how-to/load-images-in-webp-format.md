---
layout: post
title: Load webp format image with Blazor Carousel Component | Syncfusion
description: Checkout and learn about how to load webp format image with Blazor Carousel component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: Carousel
documentation: ug
---

# Load webp format image with Blazor Carousel Component

You can load the carousel image in the webp format, which aims to create smaller, better-looking images. Choosing webp as your image format can significantly improve your website's performance without sacrificing visual quality. webp images are significantly smaller in file size compared to formats like JPEG and PNG. This results in faster load times and less data usage. To achieve this, you can convert your image format to webp and pass them to Carousel items. The following sample illustrates how to load a carousel image in the webp format component.

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