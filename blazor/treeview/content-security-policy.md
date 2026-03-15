---
layout: post
title: TreeView - Strict CSP Feature Limitations - Syncfusion
description: Details on features in TreeView that require CSP relaxation
platform: Blazor
control: TreeView
documentation: ug
---

# TreeView Strict CSP Feature Limitations

The Syncfusion® Blazor **TreeView** component supports **strict CSP** for its core functionality, enabling most default operations—such as hierarchical data binding, node selection, expansion/collapse, drag-and-drop, checkboxes, multi-selection, node editing, context menu integration, templates, icons/images, accessibility, keyboard navigation, and lazy loading—without requiring `'unsafe-inline'` in the `style-src` directive.

However, the **[virtualization](virtualization.md)** feature relies on dynamic runtime style manipulations (typically for precise positioning, sizing of virtualized containers, scroll calculations, and DOM recycling), which apply inline styles via JavaScript and are blocked under a fully strict CSP configuration.

This document details the specific feature that requires the `style-src 'unsafe-inline'` directive and provides recommended CSP configurations for different usage scenarios.

## Current Limitations Under Strict CSP

The following feature in the TreeView currently **requires** `style-src 'unsafe-inline'` to function correctly:

- **Virtualization**  
  UI virtualization (enabled via `EnableVirtualization="true"` with a fixed `Height`) optimizes performance for large hierarchical datasets by rendering only visible nodes and dynamically loading others on scroll. This involves runtime calculations for node positions, viewport management, and efficient DOM updates, which depend on applying dynamic inline styles for container sizing, offset positioning, and smooth scrolling behavior.

> **Note:** All core TreeView features—including data binding (hierarchical and self-referential), node templates, custom rendering, drag-and-drop, editing, filtering, sorting (via integration), badges, context menu, RTL support, accessibility (ARIA/WCAG), keyboard navigation, lazy loading, and export capabilities—operate fully under strict CSP without requiring `'unsafe-inline'`.

## Recommended CSP Configurations

### Strict CSP Configuration (Core TreeView Functionality Only)

Use this configuration when virtualization is not required (or can be disabled by omitting `EnableVirtualization="true"` or not setting a fixed height):

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

>This policy ensures full strict CSP compliance for the TreeView's primary hierarchical data display and interaction capabilities.

### Relaxed CSP Configuration (Full Feature Enabled)

Include **'unsafe-inline'** in **style-src** to enable the virtualization feature:

```<meta http-equiv="Content-Security-Policy"
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
>Use this configuration only when handling very large datasets requiring virtualization for optimal performance and memory efficiency. This maintains strong overall protection while allowing the dynamic styling needed for virtualization.

### Future Improvements
 - The security limitation related to the Notes field (Rich Text Editor formatting) will be addressed in future weekly security patch releases.

 - Syncfusion® is actively working toward full strict CSP compatibility across all features of the Gantt Chart component, with the goal of eliminating the need for **'unsafe-inline'** entirely.

 - Track the latest **Syncfusion® Blazor release notes and weekly patches for CSP-related updates and announcements.