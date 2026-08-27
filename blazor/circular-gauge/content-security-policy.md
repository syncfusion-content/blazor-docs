---
layout: post
title: Blazor Circular Gauge Content Security Policy | Syncfusion®
description: Learn how the Blazor Circular Gauge features work under strict Content Security Policy and which animation settings require unsafe-inline relaxation.
platform: Blazor
control: Circular Gauge
documentation: ug
---

# Blazor Circular Gauge Content Security Policy

Content Security Policy (CSP) is a browser security standard that helps prevent cross-site scripting (XSS) and other code-injection attacks by restricting the sources from which a page can load scripts, styles, and other resources. The Syncfusion® Blazor **Circular Gauge** renders as SVG, so most of its features work under a strict CSP without `'unsafe-inline'`. The exception is animated rendering, which uses dynamic inline styles during transitions.

## Animations and 'unsafe-inline'

**Animation features** require the `style-src 'unsafe-inline'` directive.

### Why animations need 'unsafe-inline'

Animations work by applying dynamic inline CSS styles to make elements transition smoothly. This includes:

- The main gauge animation (controlled by [`AnimationDuration`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.SfCircularGauge.html#Syncfusion_Blazor_CircularGauge_SfCircularGauge_AnimationDuration))
- Individual pointer animations using the [`CircularGaugePointerAnimation`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.CircularGaugePointerAnimation.html) child of [`CircularGaugePointer`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.CircularGaugePointer.html)
- Sequential rendering: axis → ticks → labels → ranges → pointers → annotations

Animations are implemented with runtime inline styles, so the browser blocks element transitions when `style-src` does not allow `'unsafe-inline'`. The pointers still position correctly and the gauge still renders, but no animated transition occurs.

### How to disable animations

If you don't need animations, set [`AnimationDuration`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.SfCircularGauge.html#Syncfusion_Blazor_CircularGauge_SfCircularGauge_AnimationDuration) to **0** (the default) to render the gauge instantly without transitions. The following example shows the minimum markup that complies with a strict CSP:

```cshtml

@using Syncfusion.Blazor.CircularGauge;

<SfCircularGauge AnimationDuration="0">
    <CircularGaugeAxes>
        <CircularGaugeAxis>
            <CircularGaugePointers>
                <CircularGaugePointer Value="60" />
            </CircularGaugePointers>
        </CircularGaugeAxis>
    </CircularGaugeAxes>
</SfCircularGauge>
```

## Features supported under strict CSP

With `AnimationDuration` left at its default value of **0**, the Blazor **Circular Gauge** supports most features under strict CSP without needing `'unsafe-inline'`. You can use:

- [Axes](axes.md) and axis customization
- [Ticks and axis labels](axes.md)
- [Ranges](ranges.md) and [pointers](pointers.md)
- [Legends](legend.md)
- [Annotations](annotations.md)
- [Multiple axes](axes.md)

## Recommended CSP configurations

The following two configurations are the only adjustments typically required to host a Circular Gauge. Keep all other directives as restrictive as your application allows.

### Strict CSP (no animations)

Use this configuration when `AnimationDuration` is **0** (default) or left unset:

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

### Relaxed CSP (with animations)

Add `'unsafe-inline'` to `style-src` to enable smooth animations:

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

> Use this configuration only when animations are required. Adding `'unsafe-inline'` to `style-src` permits inline styles throughout the document and weakens CSP protection against style-based injection..

## See also

* [Content security policy in Blazor components](https://blazor.syncfusion.com/documentation/common/content-security-policy)
* [Blazor Circular Gauge animation](animation.md)