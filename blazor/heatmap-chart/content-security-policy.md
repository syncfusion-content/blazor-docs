---
layout: post
title: Heatmap - Strict CSP Feature Limitations - Syncfusion
description: Details on features in Syncfusion Blazor Heatmap Chart that require Content Security Policy (CSP) relaxation
platform: Blazor
control: Heatmap
documentation: ug
---

# Heatmap - Content Security Policy Limitations

## What's Supported Under Strict CSP?

The Syncfusion® Blazor **Heatmap** component supports most features under strict Content Security Policy without needing `'unsafe-inline'`. You can safely use:

- Data binding (one-dimensional and two-dimensional)
- Color mapping (palette, gradient, fixed colors)
- Axis customization (labels, ticks, inversed, opposed)
- Cell rendering and spacing
- Legends and tooltips
- Title and subtitle
- RTL support and accessibility
- Keyboard navigation
- Image/PDF export

## What Requires *'unsafe-inline'* ?

**Cell Selection** (single or multiple) requires the `style-src 'unsafe-inline'` directive.

### Why Does Selection Need `'unsafe-inline'`?

When users click on cells to select them, the component applies dynamic inline styles to visually highlight the selected cells. This includes:

- Selection borders and outlines
- Background color changes
- Opacity and brightness adjustments
- Focus rings and highlight effects

These visual indicators are applied in real-time during user interaction and blocked under strict CSP.

### How to Disable Selection ?

If you don't need cell selection, set `SelectionMode="None"` or simply don't configure selection-related events. The rest of the Heatmap will work fully under strict CSP.

## Recommended CSP Configurations

### Strict CSP (No Cell Selection)

Use this configuration if you don't use cell selection (or don't want selection interactions):

```html
<meta http-equiv="Content-Security-Policy"
      content="base-uri 'self';
               default-src 'self';
               connect-src 'self' https: ws: wss:;
               img-src 'self' data: https:;
               object-src 'none';
               script-src 'self';
               style-src 'self';
               font-src 'self' data:;
               upgrade-insecure-requests;">
```

This configuration maintains full security for the Heatmap's data visualization capabilities.

### Relaxed CSP (With Cell Selection)

Include `'unsafe-inline'` if you want users to select cells for drill-down or data exploration:

```html
<meta http-equiv="Content-Security-Policy"
      content="base-uri 'self';
               default-src 'self';
               connect-src 'self' https: ws: wss:;
               img-src 'self' data: https:;
               object-src 'none';
               script-src 'self';
               style-src 'self' 'unsafe-inline';
               font-src 'self' data:;
               upgrade-insecure-requests;">
```

> Use this only when single or multiple cell selection is essential for user workflows.
