---
layout: post
title: Circular Gauge - Strict CSP Feature Limitations - Syncfusion
description: Details on Syncfusion Blazor features in Circular Gauge that require Content Security Policy (CSP) relaxation.
platform: Blazor
control: Circular Gauge
documentation: ug
---

# Circular Gauge - Content Security Policy Limitations

## What's Supported Under Strict CSP?

The Syncfusion® Blazor **Circular Gauge** component supports most features under strict Content Security Policy without needing `'unsafe-inline'`. You can safely use:

- Axes and axis customization
- Ticks and axis labels
- Ranges and pointers
- Legends and tooltips
- Annotations
- Multiple axes

## What Requires **'unsafe-inline'**?

**Animation Features** require the `style-src 'unsafe-inline'` directive.

### Why Do Animations Need `'unsafe-inline'`?

Animations work by applying dynamic inline CSS styles to make elements transition smoothly. This includes:

- The main gauge animation (controlled by `AnimationDuration`)
- Individual pointer animations (via `CircularGaugePointerAnimation`)
- Sequential rendering: axis → ticks → labels → ranges → pointers → annotations

### How to Disable Animations

If you don't need animations, set `AnimationDuration="0"` (this is the default) to render the gauge instantly without transitions.

## Recommended CSP Configurations

### Strict CSP (No Animations)

Use this configuration if you don't use animations (set `AnimationDuration="0"` or leave it unset):

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

This configuration maintains full security for the gauge's core visualization features.

### Relaxed CSP (With Animations)

Include `'unsafe-inline'` if you want smooth animations:

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

> Use this only if animations are important for your user experience.
