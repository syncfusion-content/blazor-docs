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

The Blazor Card component allows you to include images within its structure using the [`CardImage`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Cards.CardImage.html) component. You can add the `<CardImage>` component directly inside the `<SfCard>` element.

N> By default, card images occupies full width of its parent element.

The CardImage supports direct specification of the image source using its `Image` property. Additionally, it can include an `Alt` property for improved accessibility, providing alternative text for the image.

```cshtml
@using Syncfusion.Blazor.Cards

<SfCard>
    <CardImage/>
</SfCard>
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BXVgihBBLRBjgnKM?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Title

To apply custom CSS styles to an image within a `CardImage` component, you can define a CSS class and apply it using the `CssClass` property. This allows for advanced styling such as background images, specific sizing, or positioning.

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
![Blazor Card Component with Title](images/Title-card.png)

## Divider

Dividers are used to visually separate elements within the Card. To add a divider below a `CardContent` component, set its [`EnableSeparator`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Cards.CardContent.html#Syncfusion_Blazor_Cards_CardContent_EnableSeparator) property to `true`.

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
![Blazor Card Component with Divider](images/Divider-card.png)