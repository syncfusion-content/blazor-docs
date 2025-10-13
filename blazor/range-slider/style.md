---
layout: post
title: CSS Structure in Blazor Range Slider Component | Syncfusion
description: Checkout and learn here all about CSS Structure in Syncfusion Blazor Range Slider component and more.
platform: Blazor
control: Range Slider
documentation: ug
---

# CSS Structure in Blazor Range Slider Component

The following content outlines the CSS structure that can be used to modify the control’s appearance according to application requirements.

## Customizing the slider track

Use the following CSS to customize the slider track.

```css
.e-control-wrapper.e-slider-container.e-horizontal .e-slider-track {
    background: #007bff;
    height: 3px;
}
```

## Customizing the slider handle

Use the following CSS to customize the slider handle properties.

```css
.e-control-wrapper.e-slider-container .e-slider .e-handle {
    background-color: #f9920b;
    border-radius: 50%;
    border: 0;
}
```

## Customizing the slider limits

Use the following CSS to customize the slider limits.

```css
.e-control-wrapper.e-slider-container.e-horizontal .e-limits {
    background-color: rgba(69, 100, 233, 0.46);
}
```

## Customizing the slider ticks

Use the following CSS to customize the slider ticks.

```css
.e-scale .e-tick.e-custom::before {
    content: '\e967';
    position: absolute;
}
```

## Customizing the slider buttons

Use the following CSS to customize the slider buttons.

```css
.e-control-wrapper.e-slider-container .e-slider-button {
    background: #007bff;
    height: 25px;
    width: 25px;
}
```