---
layout: post
title: Chat UI - Strict CSP Feature Limitations | Syncfusion®
description: Details on features in Blazor Chat UI Component that require Content Security Policy (CSP) relaxation and much more details.
platform: Blazor
control: Chat UI
documentation: ug
---

# Chat UI - Content Security Policy Limitations

## What's supported under strict CSP ?

The Syncfusion® Blazor **Chat UI** component supports most features under strict Content Security Policy without needing `'unsafe-inline'`. You can safely use:

- Sending and receiving messages
- Rendering text, rich text, and custom message templates
- User and author details (avatar, name, timestamp)
- Typing indicator
- Suggested/quick reply actions
- Theming and static customizations

## What requires *'unsafe-inline'* ?

The following feature requires the `style-src 'unsafe-inline'` directive:

### 1. Load on demand

The **Load on demand** feature internally uses the `Virtualize` component to render chat messages efficiently for large conversation lists. The `Virtualize` component dynamically applies inline styles to manage item placeholders, spacing, and scroll positioning while loading data on demand, which requires `'unsafe-inline'` to function correctly.

> **Note:** Core features including message rendering, templates, typing indicator, suggestions, and theming operate fully under strict CSP without requiring `'unsafe-inline'`. Only the **Load on demand** feature is impacted under strict CSP.

## Recommended CSP configurations

### Strict CSP (without Load on demand)

Use this configuration if you don't need the **Load on demand** feature:

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

This configuration maintains full security for the Chat UI component's messaging experience.

### Relaxed CSP (with Load on demand)

Include `'unsafe-inline'` if you need the **Load on demand** feature:

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

> Use this only when **Load on demand** (virtualized message loading) is essential to your application.

## See also

* [Content security policy in Blazor components](https://blazor.syncfusion.com/documentation/common/content-security-policy)