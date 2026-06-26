---
layout: post
title: Maps - Strict CSP Feature Limitations | Syncfusion®
description: Details on features in Blazor Maps Component that require Content Security Policy (CSP) relaxation and much more details.
platform: Blazor
control: Maps
documentation: ug
---

# Maps - Content Security Policy Limitations

## What's supported under strict CSP ?

The Syncfusion® Blazor **Chat UI** component supports most features under strict Content Security Policy without needing `'unsafe-inline'`. You can safely use:

- Virtualization

## What requires *'unsafe-inline'* ?

The following features require the `style-src 'unsafe-inline'` directive:

### Relaxed CSP (with Virtualization features)

Include `'unsafe-inline'` if you need OSM with toolbar, click interactions, or highlight customizations:

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

> Use this only when interactive features like OSM, toolbar, click behavior, or highlight effects are essential to your application.

> **Note:** Core features—including static shape rendering, data-bound color mapping, legends, tooltips, multiple layers, basic zoom/pan, and export—work fully under strict CSP.

## See also

* [Content security policy in Blazor components](https://blazor.syncfusion.com/documentation/common/content-security-policy)