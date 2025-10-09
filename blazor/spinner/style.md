---
layout: post
title: Style and appearance in Blazor Spinner Component | Syncfusion
description: Check out and learn about styling and appearance customization in the Syncfusion Blazor Spinner component, including theme-specific selectors and CSS overrides.
platform: Blazor
control: Spinner
documentation: ug
---

# Style and appearance in Blazor Spinner Component

This topic outlines the CSS structure that can be used to modify the Spinner’s appearance to match application requirements.

N> To avoid global changes, scope custom styles to a specific instance by assigning a custom class via the component’s CssClass property (for example, .e-spinner-pane.my-spinner …). Theme-specific CSS classes vary; use the selector that matches the active theme or the Spinner Type.

## Customizing the spinner

Use the following CSS to customize the spinner stroke color. Choose the selector that corresponds to the active theme.

### Material theme

```css

.e-spinner-pane .e-spinner-inner .e-spin-material {
  stroke: green;
}

```

### Fabric theme

```css

.e-spinner-pane .e-spinner-inner .e-spin-fabric {
  stroke: green;
}

```

### Bootstrap theme

```css

.e-spinner-pane .e-spinner-inner .e-spin-bootstrap {
    fill: green;
    stroke: green;
}

```

### Bootstrap4 theme

```css

.e-spinner-pane .e-spinner-inner .e-spin-bootstrap4 {
    stroke: green;
}

```

### High Contrast theme

```css

.e-spinner-pane .e-spinner-inner .e-spin-high-contrast .e-path-arc {
    stroke: green;
}

```