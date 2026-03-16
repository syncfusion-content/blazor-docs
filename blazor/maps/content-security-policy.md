---
layout: post
title: Maps - Strict CSP Feature Limitations - Syncfusion
description: Details on features in Syncfusion Blazor Maps Component that require Content Security Policy (CSP) relaxation
platform: Blazor
control: Maps
documentation: ug
---

# Maps Strict CSP Feature Limitations

The Syncfusion® Blazor **Maps** component supports **strict CSP** for its core functionality, allowing most default operations—such as rendering GeoJSON shape data, multiple layers, data binding, color mapping, legends, data labels, tooltips, basic navigation (zoom/pan via mouse/touch), and static customizations—without requiring `'unsafe-inline'` in the `style-src` directive.

However, certain interactive and dynamic visualization features rely on runtime-applied inline styles (for dynamic positioning, sizing, highlighting effects, border changes, fill transitions, or overlay adjustments managed via JavaScript), which are blocked under a fully strict CSP configuration.

This document outlines the specific features that require the `style-src 'unsafe-inline'` directive and provides guidance on CSP configurations with and without those features.

## Current Limitations Under Strict CSP

The following features in the Maps component currently **require** `style-src 'unsafe-inline'` to function correctly:

- **OpenStreetMap (OSM) with Toolbar**  
  Enabling the OSM base map layer combined with the built-in toolbar (for zoom in/out, reset, panning tools, etc.) involves dynamic toolbar rendering, button states, and map viewport adjustments that apply inline styles for responsive layout, icon positioning, and overlay management.

- **Single and Double Click Interactions**  
  Handling single-click and double-click events on the map surface (for custom actions, zooming, or feature selection) depends on runtime event handling and potential dynamic style updates to visual feedback elements.

- **Custom Highlight Features**  
  The following highlight/selection effects use dynamic inline styles to apply visual changes (e.g., border/color modifications, opacity shifts, scaling, or overlay rendering) at runtime:  
  - **Bubble Highlight** — Dynamic emphasis on bubble elements (size/color changes on interaction).  
  - **Marker Highlight** — Runtime styling for selected or hovered markers (e.g., glow, border, scale).  
  - **Polygon Highlight** — Shape/polygon selection effects (fill/border updates).  
  - **Navigation Highlight** — Highlighting navigation lines or paths (stroke changes, animations).  
  - **Shape Highlight** — Base shape (region/country) selection or hover highlighting (color overrides, borders).

> **Note:** Core features—including static shape rendering, data-bound color mapping, legends, tooltips, multiple layers, basic zooming/panning (without toolbar), annotations, and export (image/PDF)—operate fully under strict CSP without requiring `'unsafe-inline'`.

## Recommended CSP Configurations

### Strict CSP Configuration (Core Maps Functionality Only)

Use this configuration when the listed interactive/highlight features, OSM+toolbar, or click-based interactions are not required (or can be disabled/limited):

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
>This policy ensures full strict CSP compliance for the Maps component's primary geographic data visualization capabilities.

### Relaxed CSP Configuration (Full Feature Enabled)
Include 'unsafe-inline' in style-src to enable the restricted features (OSM with toolbar, click interactions, and all highlight customizations):

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
>Use this configuration only when interactive highlights, OSM integration with toolbar, or click-based behaviors are essential to your application. This maintains strong overall protection while permitting the dynamic styling needed.

### Future Improvements
 - The security limitation related to the Notes field (Rich Text Editor formatting) will be addressed in future weekly security patch releases.

 - Syncfusion® is actively working toward full strict CSP compatibility across all features of the Gantt Chart component, with the goal of eliminating the need for **'unsafe-inline'** entirely.

 - Track the latest **Syncfusion® Blazor release notes and weekly patches for CSP-related updates and announcements.