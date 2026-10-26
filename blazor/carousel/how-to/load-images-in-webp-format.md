---
layout: post
title: How to load images in webp format in Blazor Carousel | Syncfusion®
description: Load webp-format images in the Blazor Carousel to reduce file size and improve page-load performance compared to JPEG and PNG.
platform: Blazor
control: Carousel
documentation: ug
---

# How to load images in webp format in Blazor Carousel

The Blazor Carousel can display images in [WebP](https://developers.google.com/speed/webp) format by setting the `src` attribute of each slide's `<img>` element to a WebP file. The Blazor Carousel component requires no special configuration for WebP; the browser handles the rendering natively.

WebP produces smaller file sizes than formats like JPEG and PNG, resulting in faster load times and reduced data usage. To use WebP in the Blazor Carousel, convert your images to WebP using a tool such as [`cwebp`](https://developers.google.com/speed/webp/download), [Squoosh](https://squoosh.app/), or any image-editing application, and reference the resulting `.webp` files in your `CarouselItem` content.

> WebP is supported by all modern browsers. If you need to support legacy browsers, provide a fallback using the `<picture>` element with a JPEG or PNG `<source>` and the WebP source.

The following example demonstrates how to load Blazor Carousel images in WebP format. You can also add `loading="lazy"` to each `<img>` element to defer off screen images and further improve performance.

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

## See also

* [Getting started with Blazor Carousel](https://blazor.syncfusion.com/documentation/carousel/getting-started)
* [Populating items in Blazor Carousel](https://blazor.syncfusion.com/documentation/carousel/populating-items)
* [Animations and transitions in Blazor Carousel](https://blazor.syncfusion.com/documentation/carousel/animations-and-transitions)
* [WebP image format](https://developers.google.com/speed/webp)