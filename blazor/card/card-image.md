---
layout: post
title: Image and Divider in Blazor Card | Syncfusion®
description: Add an image and a divider to the Blazor Card using the CardImage and CardImage with Separator, to compose richer card layouts.
platform: Blazor
control: Card
documentation: ug
---

<!-- markdownlint-disable MD036 -->

# Image and Divider in Blazor Card Component

## Images

The [Blazor Card](https://www.syncfusion.com/blazor-components/blazor-card) component supports including images within its elements. You can add an image as a direct element anywhere inside the card root by using the `CardImage` component. Using the class defined, you can write CSS styles to load images into that element.

N> By default, card images occupy the full width of their parent element.

```cshtml
@using Syncfusion.Blazor.Cards

<SfCard>
    <CardImage/>
</SfCard>
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/rXrRtHsLrOnTFpDk?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" %}

### Title

The `CardImage` component supports a `Title` property to display a title over the image. By default, the title is placed over the image on the left-bottom position with an overlay.

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
{% previewsample "https://blazorplayground.syncfusion.com/embed/LDLnDHCBBYxcOZwm?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" %}

## Divider

A divider is used to separate elements inside the card. You can add a divider inside card content by setting the `EnableSeparator` property to `true`.

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
{% previewsample "https://blazorplayground.syncfusion.com/embed/VDBRZdMhVamtbNWR?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" %}

## See also

* [Style and Appearance in Blazor Card](style.md)
* [Header and Content in Blazor Card](header-content.md)
* [Action Buttons in Blazor Card](action-buttons.md)
* [Horizontal Card in Blazor Card](horizontal.md)