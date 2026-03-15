---
layout: post
title: Pivot Table - Strict CSP Feature Limitations - Syncfusion
description: Details on features in Pivot Table that require CSP relaxation
platform: Blazor
control: Pivot Table
documentation: ug
---

# Pivot Table Strict CSP Feature Limitations

The Syncfusion® Blazor **Pivot Table**  component supports **strict CSP** for its core functionality, allowing most default operations without `'unsafe-inline'` in `style-src`. However, certain advanced visualization and formatting features still rely on dynamic inline styles, which are blocked under a fully strict CSP configuration.

This document outlines the specific features that require the `style-src 'unsafe-inline'` directive and provides guidance on CSP configurations with and without those features.

## Current Limitations Under Strict CSP

The following features in the Pivot Table currently **require** `style-src 'unsafe-inline'` to function correctly:

- **Pivot Chart Integration**  
  Rendering the integrated Pivot Chart (via the `ShowToolbar` Chart view toggle or `DisplayOption` set to Chart) depends on dynamic inline styles for chart rendering, positioning, legends, tooltips, and responsive layout adjustments.

- **Conditional Formatting**  
  Applying cell-level conditional formatting (via the `ConditionalFormatSettings` collection) uses inline style attributes to dynamically set background colors, font styles, text colors, and other visual indicators based on applied rules.

- **Number Formatting & Cell Styling** 
  Certain custom number formatting options, especially when combined with alignment, text wrapping, or theme-based overrides that trigger runtime style calculations, may apply inline styles.

> **Note:** Core features operate fully under strict CSP without requiring `'unsafe-inline'`.

## Recommended CSP Configurations

### Strict CSP Configuration (Core Grid Functionality Only)

Use this configuration when you can disable or avoid the limited features listed above:

```html
<meta http-equiv="Content-Security-Policy"
      content="base-uri 'self';
               default-src 'self';
               connect-src 'self' https: ws: wss:;
               img-src 'self' data: https:;
               object-src 'none';
               script-src 'self' ;
               style-src 'self';
               font-src 'self' data:;
               upgrade-insecure-requests;">

```
> This policy allows full strict CSP compliance for the Pivot Table's grid view and most non-visual features.
### Relaxed CSP Configuration (Full Feature Enabled)
Include 'unsafe-inline' in style-src to enable all features:

```
HTML<meta http-equiv="Content-Security-Policy"
      content="base-uri 'self';
               default-src 'self';
               connect-src 'self' https: ws: wss:;
               img-src 'self' data: https:;
               object-src 'none';
               script-src 'self' ;
               style-src 'self' 'unsafe-inline';
               font-src 'self' data:;
               upgrade-insecure-requests;">

```

> Use this only when the restricted features (Pivot Chart, conditional formatting, etc.) are essential to your application. This relaxes the CSP slightly but still provides strong protection compared to broader unsafe directives.


### Future Improvements

These security limitations for the listed features (Pivot Chart integration, conditional formatting, and related styling behaviors) will be addressed in **future weekly security patch releases**. 

Syncfusion® is actively working toward full strict CSP compatibility across all features of the Pivot Table component, eliminating the need for 'unsafe-inline' entirely.
Track the latest Syncfusion® Blazor release notes and weekly patches for CSP-related updates and announcements.