---
layout: post
title: Style and Appearance in Blazor Card Component | Syncfusion
description: Checkout and learn here all about Style and Appearance in Syncfusion Blazor Card component and more.
platform: Blazor
control: Card
documentation: ug
---

# Style and Appearance in Blazor Card Component

The Blazor Card component can be visually customized by overriding its default CSS styles. This document provides a list of common CSS classes and demonstrations on how to apply custom styles to various parts of the Card, such as its background, header, content, images, and action buttons.

For comprehensive theme generation across Syncfusion controls, you can also utilize our [Theme Studio](https://blazor.syncfusion.com/themestudio/?theme=material).

## Customizing the Card

The following table lists key CSS classes and their corresponding sections within the Card component, which you can target for styling:

```css
.e-card {
    background-color: aqua;
    padding-left: 20px;
    margin-bottom: 20px;
}
```

## Customizing the Header Element

Use the following CSS to customize the Header element properties.

```css
.e-card .e-card-header {
    font-family: cursive;
    font-style: italic;
}
```

## Customizing the Card Content

Use the following CSS to customize the card content properties.

```css
.e-card .e-card-content {
    font-size: 20px;
    color: gray;
    line-height: initial;
    font-weight: normal;
}
```

## Divider Used to Separate the Elements Inside the Card

Use the following CSS to customize the Divider used to separate the elements inside the card properties.

```css
.e-card .e-card-separator {
   padding-bottom: 30px;
}
```

## Including Image Within Card Element

Use the following CSS to Include image within card element.

```css
.e-card .e-card-image {
    background-image: url(images.png);
    background-color: yellow;
    height: 160px;
}
```

## Including a Title or Caption for the Image

Use the following CSS to Include a title or caption for the image.

```css
.e-card .e-card-image .e-card-title {
    font-family: cursive;
    font-style: italic;
}
```

## To Include Heading Image Within the Header

Use the following CSS to Include heading image within the header.

```css
.e-card .e-card-header .e-card-header-image  {
    height: 48px;
    width: 48px;
}
```

## Customizing the Header Main Title

Use the following CSS to Customize the Header main title.

```css
.e-card .e-card-header .e-card-header-caption .e-card-header-title {
    font-size: large;
    color: aquamarine;
}
```

## Customizing the Header Subtitle

Use the following CSS to Customize the Header subtitle.

```css
.e-card .e-card-header .e-card-header-caption .e-card-sub-title {
    font-size: 20px;
    font-variant: all-petite-caps;
}
```

## Including Action Buttons or Anchor Tags

Use the following CSS to Include action buttons or anchor tags.

```css
.e-card .e-card-actions .e-card-btn {
    padding-left: 20px;
    background-color: wheat;
}
```

## To Align Card Elements Horizontally

Use the following CSS to align card elements horizontally.

```css
.e-card .e-card-horizontal {
    margin: auto;
    width: inherit;
}
```

## To Align Elements Vertically Within the Horizontal Layout

Use the following CSS to align elements vertically within the horizontal layout.

```css
.e-card .e-card-horizontal .e-card-stacked {
    justify-content: flex-start;
    margin: initial;
}
```