---
layout: post
title: Circular Gauge - Strict CSP Feature Limitations - Syncfusion
description: Details on features in Syncfusion Blazor Circular Gauge that require CSP relaxation
platform: Blazor
control: Circular Gauge
documentation: ug
---

# Circular Gauge Strict CSP Feature Limitations

The Syncfusion® Blazor **Circular Gauge** component supports **strict CSP** for its core functionality, allowing most default operations such as rendering axes, ticks, labels, ranges, pointers, annotations, legends, tooltips, and multiple axes—without requiring `'unsafe-inline'` in the `style-src` directive.

However, animation-related features rely on dynamic runtime style manipulations (likely involving inline styles or CSS transitions applied via JavaScript) to achieve smooth sequential rendering effects, which are blocked under a fully strict CSP configuration.

This document outlines the specific animation features that require the `style-src 'unsafe-inline'` directive and provides guidance on CSP configurations with and without animation support.

## Current Limitations Under Strict CSP

The following features in the Circular Gauge currently **require** `style-src 'unsafe-inline'` to function correctly:

 **[Animation Features](./content-security-policy.md)**  
  All animation capabilities, controlled primarily via the `AnimationDuration` property (on the `SfCircularGauge` component) and optionally via `CircularGaugePointerAnimation` for individual pointers, depend on dynamic inline styles or style injections for smooth transitions.  
  When animation is enabled (`AnimationDuration > 0`), the component animates elements sequentially: axis line → ticks and labels → ranges → pointers → annotations. Pointers can have individual animation durations.  
  Disabling animation (default: `AnimationDuration = 0`) renders the gauge instantly without transitions.

> **Note:** Core features supports fully under strict CSP without requiring `'unsafe-inline'`.

## Recommended CSP Configurations

### Strict CSP Configuration (Core Gauge Functionality Only)

Use this configuration when animation is not required (or can be disabled by setting `AnimationDuration="0"`):

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

>This policy ensures full strict CSP compliance for the Circular Gauge's primary visualization and data representation capabilities.

### Relaxed CSP Configuration (Full Feature Enabled)

Include 'unsafe-inline' in style-src to enable animation features:

```
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

> Use this configuration only when smooth loading animations or pointer-specific animations are essential to your application. This maintains strong overall protection while permitting the dynamic styling needed for animations.


### Future Improvements
 - The security limitation related to the Notes field (Rich Text Editor formatting) will be addressed in future weekly security patch releases.

 - Syncfusion® is actively working toward full strict CSP compatibility across all features of the Gantt Chart component, with the goal of eliminating the need for **'unsafe-inline'** entirely.

 - Track the latest **Syncfusion® Blazor release notes and weekly patches for CSP-related updates and announcements.