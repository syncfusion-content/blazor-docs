---
layout: post
title: Style and appearance in Blazor Calendar Component | Syncfusion
description: Checkout and learn here all about Style and appearance in Syncfusion Blazor Calendar component and more.
platform: Blazor
control: Calendar
documentation: ug
---

# Style and appearance in Blazor Calendar Component

The following content shows the Calendar’s CSS structure that can be overridden to change the component’s appearance based on user preferences. These examples are theme-agnostic overrides; depending on the selected theme, additional selector specificity may be required.

## Customizing the background color for the Calendar

Use the following CSS to customize the Calendar container’s background color and border. This affects the overall widget surface.

```css
/* To specify background color and border */
.e-calendar {
        background-color: peachpuff;
        border: 3px solid red;
}
```

## Customizing the Calendar date elements on hovering

Use the following CSS to customize day cells on hover and focus states in the Calendar’s month view. This helps emphasize interactive feedback.

```css
/* To specify background color, color, and border */
.e-calendar .e-content td:hover span.e-day, .e-calendar .e-content td:focus span.e-day, .e-bigger.e-small .e-calendar .e-content td:hover span.e-day, .e-bigger.e-small .e-calendar .e-content td:focus span.e-day {
        background-color: red;
        border: 2px solid;
        color: #212529;
}
```

## Customizing the border of date cell grid

Use the following CSS to add borders around individual day cells in the month grid for clearer separation.

```css
/* To specify border */
.e-calendar .e-content span.e-day, .e-bigger.e-small .e-calendar .e-content span.e-day {
        border: 1px solid;
}
```

## Customizing the Calendar title

Use the following CSS to style the Calendar title (month/year text) in the header.

```css
/* To specify color and font size  */
.e-calendar .e-header .e-title, .e-bigger.e-small .e-calendar .e-header .e-title {
        color: black;
        font-size: 20px;
}
```

## Customizing the previous and next icon

Use the following CSS to customize the appearance of the previous and next navigation icons in the header.

```css
/* To specify color and border  */
.e-calendar .e-header span, .e-bigger.e-small .e-calendar .e-header span {
        border: 1px solid;
        color: chocolate;
}
```

## Customizing the footer button

Use the following CSS to customize the Today footer button’s background, text color, and border color (when the button is visible).

```css
/* To specify background color, color, and border-color  */
.e-calendar .e-btn.e-today.e-flat.e-primary, .e-calendar .e-css.e-btn.e-today.e-flat.e-primary {
        background-color: red;
        border-color: black;
        color: black;
}
```

## Customizing the selected date cell grid

Use the following CSS to style the currently selected day cell in the Calendar for stronger visual emphasis.

```css
/* To specify background color and color  */
.e-calendar .e-content td.e-selected.e-focused-date span.e-day {
        background-color: maroon;
        color: #fff;
}
```

## Customizing the content header in Calendar

Use the following CSS to customize the weekday header row above the month grid.

```css
/* To specify background */
.e-calendar .e-content thead, .e-bigger.e-small .e-calendar .e-content thead {
    background: aquamarine;
}
```