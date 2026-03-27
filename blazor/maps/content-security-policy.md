---
layout: post
title: Maps - Strict CSP Feature Limitations - Syncfusion
description: Details on features in Syncfusion Blazor Maps Component that require Content Security Policy (CSP) relaxation
platform: Blazor
control: Maps
documentation: ug
---

# Maps - Content Security Policy Limitations

## What's Supported Under Strict CSP?

The Syncfusion® Blazor **Maps** component supports most features under strict Content Security Policy without needing `'unsafe-inline'`. You can safely use:

- GeoJSON shape data rendering
- Multiple map layers
- Data binding and color mapping
- Legends and data labels
- Tooltips
- Basic zoom and pan navigation
- Static customizations

## What Requires *'unsafe-inline'* ?

The following features require the `style-src 'unsafe-inline'` directive:

### 1. OpenStreetMap (OSM) with Toolbar

When you use the OSM base layer with the built-in toolbar (zoom, pan, reset buttons), the toolbar applies dynamic inline styles for button states, icon rendering, responsive layout, and overlay management.

### 2. Click Interactions

Single and double-click events that trigger custom actions or visual feedback may apply dynamic inline styles to visual elements.

### 3. Highlight Features

These interactive highlight effects apply runtime inline styles:
- Bubble Highlight (dynamic size and color)
- Marker Highlight (glow, borders, scaling)
- Polygon Highlight (fill and border changes)
- Navigation Highlight (stroke changes)
- Shape Highlight (region/country selection effects)

> **Note:** Core features—including static shape rendering, data-bound color mapping, legends, tooltips, multiple layers, basic zooming/panning (without toolbar), annotations, and export (image/PDF)—operate fully under strict CSP without requiring `'unsafe-inline'`.

## Recommended CSP Configurations

### Strict CSP (Static Maps Only)

Use this configuration if you don't need OSM with toolbar, click interactions, or highlight features:

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

This configuration maintains full security for the Maps component's geographic data visualization.

### Relaxed CSP (With Interactive Features)

Include `'unsafe-inline'` if you need OSM with toolbar, click interactions, or highlight customizations:

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

> Use this only when interactive features like OSM, toolbar, click behavior, or highlight effects are essential to your application.

> **Note:** Core features—including static shape rendering, data-bound color mapping, legends, tooltips, multiple layers, basic zoom/pan, and export—work fully under strict CSP.
