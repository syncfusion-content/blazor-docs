---
layout: post
title: Heatmap - Strict CSP Feature Limitations - Syncfusion
description: Details on features in Syncfusion Blazor Heatmap that require CSP relaxation
platform: Blazor
control: Heatmap
documentation: ug
---

# Heatmap Strict CSP Feature Limitations

The Syncfusion® Blazor **Heatmap** component supports **strict CSP** for its core functionality, enabling most default operations—such as data binding (one-dimensional and two-dimensional), color mapping (palette, gradient, fixed), axis customization (labels, ticks, inversed, opposed), cell rendering, legends, tooltips, title/subtitle, border and cell spacing, RTL support, accessibility, keyboard navigation, and export (image/PDF)—without requiring `'unsafe-inline'` in the `style-src` directive.

However, interactive selection features rely on dynamic runtime style manipulations (typically for applying selection borders, background changes, opacity adjustments, focus indicators, or overlay effects via inline styles managed by JavaScript), which are blocked under a fully strict CSP configuration.

This document details the specific selection features that require the `style-src 'unsafe-inline'` directive and provides recommended CSP configurations for different usage scenarios.

## Current Limitations Under Strict CSP

The following features in the Heatmap currently **require** `style-src 'unsafe-inline'` to function correctly:

- **[Single and Multiple Selection](./selection.md)**  
  Enabling cell selection whether single cell (`AllowSelection="true" EnableMultiSelect="false"`) or multiple cells depends on runtime-applied inline styles to visually indicate selected cells. This includes dynamic changes such as:  
  - Selection border or outline  
  - Background color / fill overrides  
  - Opacity or brightness adjustments  
  - Focus ring or highlight effects  
  These visual cues are applied directly to cell elements during user interaction (click, Ctrl+click, Shift+click, or programmatic selection).

> **Note:** All core Heatmap features operate fully under strict CSP without requiring `'unsafe-inline'`.

## Recommended CSP Configurations

### Strict CSP Configuration (Core Heatmap Functionality Only)

Use this configuration when selection interactivity is not required (or can be disabled by setting `SelectionMode="None"` or omitting selection-related events):

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
>This policy ensures full strict CSP compliance for the Heatmap component's primary data visualization and representation capabilities.

### Relaxed CSP Configuration (Full Feature Enabled)

Include 'unsafe-inline' in style-src to enable single and multiple cell selection:
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
>Use this configuration only when single or multiple cell selection is essential for user interaction, drill-down, or data exploration workflows. This maintains strong overall protection while permitting the dynamic styling needed for selection feedback.

### Future Improvements
 - The security limitation related to the Notes field (Rich Text Editor formatting) will be addressed in future weekly security patch releases.

 - Syncfusion® is actively working toward full strict CSP compatibility across all features of the Gantt Chart component, with the goal of eliminating the need for **'unsafe-inline'** entirely.

 - Track the latest **Syncfusion® Blazor release notes and weekly patches for CSP-related updates and announcements.