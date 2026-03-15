---
layout: post
title: Gantt Chart - Strict CSP Feature Limitations - Syncfusion
description: Details on features in Syncfusion Blazor Gantt Chart that require CSP relaxation
platform: Blazor
control: Gantt Chart
documentation: ug
---

# Gantt Chart Strict CSP Feature Limitations

The Syncfusion® Blazor **Gantt Chart** component supports **strict CSP** for its core functionality, enabling most default operations—such as task scheduling, timeline rendering, dependency management, resource allocation, and basic editing—without requiring `'unsafe-inline'` in the `style-src` directive.

However, certain rich content and advanced formatting features rely on dynamic inline styles generated at runtime, which are blocked in a fully strict CSP environment.

This document details the specific features that require the `style-src 'unsafe-inline'` directive and provides recommended CSP configurations for different usage scenarios.

## Current Limitations Under Strict CSP

The following feature in the Gantt Chart currently **requires** `style-src 'unsafe-inline'` to function correctly:

- **Notes Task Field (with Rich Text Editor support)**  
  The `Notes` field in tasks supports rich text formatting via an integrated Rich Text Editor. Rendering formatted content (bold, italic, colors, lists, hyperlinks, etc.) applies dynamic inline style attributes to achieve the requested visual appearance, including font styles, text colors, background colors, and alignment.

> **Note:** Remaining All core Gantt Chart features Work fully under strict CSP without requiring `'unsafe-inline'`.

## Recommended CSP Configurations

### Strict CSP Configuration (Except RichTextEditor related Features)

Use this configuration when the rich **Notes** field is not required or can be disabled/limited to plain text:

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
>This policy ensures full strict CSP compliance for the Gantt Chart's primary project management and visualization capabilities.

### Relaxed CSP Configuration (Full Feature Enabled)

Include 'unsafe-inline' in style-src to enable rich formatting in the Notes field:

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

### Future Improvements
 - The security limitation related to the Notes field (Rich Text Editor formatting) will be addressed in future weekly security patch releases.

 - Syncfusion® is actively working toward full strict CSP compatibility across all features of the Gantt Chart component, with the goal of eliminating the need for **'unsafe-inline'** entirely.
Track the latest **Syncfusion® Blazor release notes and weekly patches for CSP-related updates and announcements.