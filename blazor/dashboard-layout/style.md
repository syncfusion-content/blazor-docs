---
layout: post
title: Style and Appearance in Blazor Dashboard Layout | Syncfusion®
description: Customize the Blazor Dashboard Layout appearance by overriding its default CSS structure for cells, panels, headers, and content.
platform: Blazor
control: Dashboard Layout
documentation: ug
---

# Style and Appearance in Blazor Dashboard Layout

The following content provides the exact CSS structure that can be used to modify the control's appearance based on the user preference.

## Customizing the Blazor Dashboard Layout Panel Header

Use the following CSS to customize the header section of the Blazor Dashboard Layout panels.

```css
.e-dashboardlayout.e-control .e-panel .e-panel-container .e-panel-header {
    color: #754131;
    background-color: #c9e2f7;
    text-align: center;
}
```

## Customizing the Blazor Dashboard Layout Panel Content

Apply the following CSS to customize the main content area of the Blazor Dashboard Layout panels.

```css
.e-dashboardlayout.e-control .e-panel .e-panel-container .e-panel-content {
    background-color: #c9e2f7;
    padding: 50px;
}
```

## Customizing the Blazor Dashboard Layout Panel Resize Icon

The resize icon that appears in the corner of resizable panels can also be customized. This selector applies only when `AllowResizing` is set to `true`. Use the following CSS to modify its appearance.

```css
.e-dashboardlayout.e-control .e-panel .e-panel-container .e-resize.e-double{
    color: #0378d5;
    font-size: 30px;
    height: 20px;
    width: 20px;
}
```

## Customizing the Blazor Dashboard Layout Background

Modify the overall background of the Blazor Dashboard Layout component using the CSS below. This targets the main container of the dashboard.

```css
.e-dashboardlayout.e-control.e-responsive {
    background: #b3d3ed;
}
```