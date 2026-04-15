---
layout: post
title: Pivot Table - Strict CSP Feature Limitations - Syncfusion
description: Details on Syncfusion Blazor features in Pivot Table that require Content Security Policy (CSP) relaxation.
platform: Blazor
control: Pivot Table
documentation: ug
---

# Pivot Table - Content Security Policy Limitations

## What's supported under strict CSP ?

The Syncfusion® Blazor **Pivot Table** component supports most features under strict Content Security Policy without needing `'unsafe-inline'`. You can safely use:

- Grid view with data binding
- Data aggregation and grouping
- Sorting and filtering
- Basic cell editing
- Expand/collapse functionality
- Field list integration
- Keyboard navigation and accessibility

## What requires *'unsafe-inline'* ?

The following features require the `style-src 'unsafe-inline'` directive:

### 1. Pivot chart integration

When you enable the integrated Pivot Chart view (via `ShowToolbar` Chart toggle or `DisplayOption="Chart"`), the chart applies dynamic inline styles for:
- Chart rendering and positioning
- Legends and tooltips
- Responsive layout adjustments

### 2. Conditional formatting

Cell-level conditional formatting uses inline styles to dynamically apply:
- Background colors
- Font styles and weights
- Text colors
- Visual indicators based on formatting rules

### 3. Advanced number formatting & styling

Custom number formatting combined with alignment, text wrapping, or theme overrides may apply runtime inline styles.

### How to disable these features ?

If you don't need these advanced features, the rest of the Pivot Table works fully under strict CSP.

## Recommended CSP configurations

### Strict CSP (grid view only)

Use this configuration if you don't use Pivot Chart view, conditional formatting, or advanced number formatting:

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

This configuration maintains full security for the Pivot Table's grid view functionality.

### Relaxed CSP (with advanced features)

Include `'unsafe-inline'` if you need Pivot Chart view, conditional formatting, or advanced number styling:

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

> Use this only when integrated charting, cell-level conditional formatting, or advanced styling is essential.
