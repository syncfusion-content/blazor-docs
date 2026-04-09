---
layout: post
title: TreeView - Strict CSP Feature Limitations - Syncfusion
description: Details on Syncfusion Blazor features in TreeView that require Content Security Policy (CSP) relaxation.
platform: Blazor
control: TreeView
documentation: ug
---

# TreeView - Content Security Policy Limitations

## What's supported under strict CSP?

The Syncfusion® Blazor **TreeView** component supports most features under strict Content Security Policy without needing `'unsafe-inline'`. You can safely use:

- Hierarchical and self-referential data binding
- Node selection and multi-selection
- Expand/collapse functionality
- Checkboxes and badges
- Drag-and-drop
- Node editing
- Context menu integration
- Custom templates and custom rendering
- Icons and images
- Lazy loading
- RTL support
- Accessibility (ARIA/WCAG)
- Keyboard navigation and export

## What requires *'unsafe-inline'*?

**UI Virtualization** requires the `style-src 'unsafe-inline'` directive.

### Why does virtualization need `'unsafe-inline'`?

UI virtualization improves performance with large datasets by rendering only visible nodes. It uses dynamic inline styles for:
- Container sizing and positioning
- Node offset calculations
- Scroll container management
- Smooth scrolling behavior
- DOM element recycling calculations

These calculations happen in real-time as users scroll and are blocked under strict CSP.

### How to disable virtualization ?

If you don't need virtualization, simply omit `EnableVirtualization="true"` or leave the Height unset. The rest of the TreeView works fully under strict CSP for large and small datasets.

## Recommended CSP configurations

### Strict CSP (no virtualization)

Use this configuration if you don't use virtualization (or handle smaller datasets):

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

This configuration maintains full security for the TreeView's hierarchical data display and interactions.

### Relaxed CSP (with virtualization)

Include `'unsafe-inline'` if you need virtualization for optimal performance with large datasets:

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

> Use this only when handling very large datasets where virtualization is essential for performance and memory efficiency.
