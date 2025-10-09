---
layout: post
title: CSS Structure in Blazor Dashboard Layout Component | Syncfusion
description: Checkout and learn here all about CSS Structure in Syncfusion Blazor Dashboard Layout component and more.
platform: Blazor
control: Dashboard Layout
documentation: ug
---

# CSS Structure in Blazor Dashboard Layout Component

The following content provides the exact CSS structure that can be used to modify the control's appearance based on the user preference.

## Customizing the Dashboard Layout Panel Header

Use the following CSS to customize the header section of the Dashboard Layout panels.

```css
.e-dashboardlayout.e-control .e-panel .e-panel-container .e-panel-header {
    color: #754131;
    background-color: #c9e2f7;
    text-align: center;
}
```

## Customizing the Dashboard Layout Panel Content

Apply the following CSS to customize the main content area of the Dashboard Layout panels.

```css
.e-dashboardlayout.e-control .e-panel .e-panel-container .e-panel-content {
    background-color: #c9e2f7;
    padding: 50px;
}
```

## Customizing the Dashboard Layout Panel Resize Icon

The resize icon that appears in the corner of resizable panels can also be customized. Use the following CSS to modify its appearance.

```css
.e-dashboardlayout.e-control .e-panel .e-panel-container .e-resize.e-double{
    color: #0378d5;
    font-size: 30px;
    height: 20px;
    width: 20px;
}
```

## Customizing the Dashboard Layout Background

Modify the overall background of the Dashboard Layout component using the CSS below. This targets the main container of the dashboard.

```css
.e-dashboardlayout.e-control.e-responsive {
    background: #b3d3ed;
}
```