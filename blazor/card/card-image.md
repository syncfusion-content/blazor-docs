---
layout: post
title: Image and Divider in Blazor Card Component | Syncfusion
description: Checkout and learn here all about Image and Divider in Syncfusion Blazor Card component and much more.
platform: Blazor
control: Card
documentation: ug
---

<!-- markdownlint-disable MD036 -->

# Image and Divider in Blazor Card Component

## Images

The Card supports to include images within the elements, you can add image as direct element anywhere inside card root by adding the `CardImage` component . Using the class defined, you can write CSS styles to load images to that element.

N> By default, card images occupies full width of its parent element.

```cshtml
@using Syncfusion.Blazor.Cards

<SfCard>
    <CardImage/>
</SfCard>
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BXVgihBBLRBjgnKM?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Title

Card image is supported to include a `Title` property for the image. By default, Title is placed over the image on left-bottom position with overlay.

```cshtml
@using Syncfusion.Blazor.Cards

<SfCard>
    <CardHeader Title="JavaScript"></CardHeader>
    <CardContent>
        JavaScript Succinctly was written to give readers an accurate, concise examination
        of JavaScript objects and their supporting nuances, such as complex values, primitive
        values scope, inheritance, the head object, and more.
    </CardContent>
</SfCard>
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/rDVUihLBhHVhadTB?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Divider

Divider used to separate the elements inside the card. You can add divider inside the card elements to separate it. Set `EnableSeparator` property to `true` in card content for adding a divider.

```cshtml
@using Syncfusion.Blazor.Cards

<SfCard>
    <CardHeader Title="Explore Cities"></CardHeader>
    <CardContent EnableSeparator="true">
        Sydney is a city on the east coast of Australia. Sydney is the capital city of New South
        Wales. About four million people live in Sydney which makes it the biggest cityin Oceania.
    </CardContent>
    <CardContent EnableSeparator="true">
        New York City has been described as the cultural, financial, and media capital of the
        world, and exerts a significant impact upon commerce and etc.
    </CardContent>
    <CardContent EnableSeparator="true">
        Malaysia is one of the Southeast Asian countries, on a peninsula of the Asian continent,
        to a certain extent; it can be recognized  as part of the Asian continent.
    </CardContent>
</SfCard>

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/hZhqsVBBLnBeVrnG?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}