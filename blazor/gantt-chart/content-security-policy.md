---
layout: post
title: Gantt Chart - Strict CSP Feature Limitations - Syncfusion
description: Details on Syncfusion Blazor features in Gantt Chart that require Content Security Policy (CSP) relaxation.
platform: Blazor
control: Gantt Chart
documentation: ug
---

# Gantt Chart - Content Security Policy Limitations

## What's Supported Under Strict CSP?

The Syncfusion® Blazor **Gantt Chart** component supports most features under strict Content Security Policy without needing `'unsafe-inline'`. You can safely use:

- Task scheduling and timeline rendering
- Dependency management
- Resource allocation and assignment
- Basic editing capabilities
- Data binding and filtering
- Multiple views and interactions

## What Requires *'unsafe-inline'*?

**Rich Text Formatting in Notes Field** requires the `style-src 'unsafe-inline'` directive.

### Why Does Rich Text Formatting Need `'unsafe-inline'`?

The Notes field supports rich text formatting (bold, italic, colors, lists, links, etc.). When you render formatted content, the Rich Text Editor applies dynamic inline styles to display the requested visual appearance, including:

- Font styles and weights
- Text colors and backgrounds
- Text alignment and spacing
- List formatting and indentation

These styles are applied at runtime and blocked under strict CSP.

### How to Use Plain Text Only ?

If you don't need rich text formatting in Notes, just use plain text. The rest of the Gantt Chart will work fully under strict CSP.

## Recommended CSP Configurations

### Strict CSP (Without  RichTextEditor related Features)

Use this configuration if you don't use rich text formatting in Notes (or don't use the Notes field):

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

This configuration maintains full security for the Gantt Chart's project management and visualization features.

### Relaxed CSP (With Rich Text Notes)

Include `'unsafe-inline'` if you want to use rich text formatting in the Notes field:

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

> Use this only if you need formatted text (bold, colors, lists, etc.) in task Notes.

