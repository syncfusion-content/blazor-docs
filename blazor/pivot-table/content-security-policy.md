---
layout: post
title: Content Security Policy Limitations in Blazor Pivot Table | Syncfusion
description: Learn which Blazor Pivot Table features work under strict Content Security Policy and which need style-src 'unsafe-inline' for chart and formatting.
platform: Blazor
control: Pivot Table
documentation: ug
---

# Content Security Policy Limitations in Blazor Pivot Table

N> **Prerequisites:** A Content Security Policy is enforced by the browser for the served HTML document. For Blazor Server, place the CSP meta tag in `Pages/_Host.cshtml` (or as a response header in `Startup.cs` / `Program.cs`); for Blazor WebAssembly, place it in `wwwroot/index.html`. Some directives — such as `frame-ancestors`, `report-uri`, and `sandbox` — must be delivered as response headers and cannot be set via a meta tag. This page is compatible with Syncfusion Blazor PivotTable version 28.1.33 and later on .NET 6.0+.

## What's supported under strict CSP?

The Syncfusion® Blazor **Pivot Table** component supports most of its features under strict Content Security Policy without needing `'unsafe-inline'`. You can safely use the following feature groups:

- **Grid features:** grid view with data binding, data aggregation and grouping, sorting, filtering, expand/collapse, drill down, drill through, paging, and virtualization.
- **Layout features:** keyboard navigation, accessibility support, and the basic Pivot Table layout.
- **Field list and grouping bar:** opening the field list and the grouping bar popups, dragging fields between axes, and member selection.

> The Pivot Table's default cell rendering uses external stylesheets, so most view features continue to work under a strict CSP that excludes `'unsafe-inline'`. The only Pivot Table features that require `'unsafe-inline'` are listed in the next section.

### How to verify your CSP is active

After applying the meta tag or response header, open the browser DevTools, switch to the **Network** tab, reload the page, and inspect the response headers for the document. The `Content-Security-Policy` header (or its report-only counterpart `Content-Security-Policy-Report-Only`) should be present. To debug a Pivot Table feature that you suspect is being blocked, set the policy to **Report-Only** mode in your browser or in `Startup.cs` and watch the **Console** for `Content Security Policy` violation entries. Each violation includes the blocked directive and the inline-style attribute that triggered it, which maps directly to the feature groups below.

## What requires `'unsafe-inline'`?

The following features require the `style-src 'unsafe-inline'` directive. They apply runtime inline styles to the Pivot Table's DOM, which a strict CSP without `'unsafe-inline'` will strip, breaking the feature. Each sub-section also lists the Syncfusion popup components that share the same inline-style behavior, so you know what to expect when enabling a related feature:

### 1. Pivot chart integration

When you enable the integrated Pivot Chart view (via the `ShowToolbar` Chart toggle or `<PivotViewDisplayOption View="View.Chart" />`), the chart applies dynamic inline styles for chart rendering, positioning, legends, tooltips, and responsive layout adjustments. The chart's tooltip, legend, and data-label popups are also rendered with inline styles, so they will be hidden or unstyled under a strict CSP.

### 2. Conditional formatting

Cell-level conditional formatting uses inline styles to dynamically apply background colors, font styles and weights, text colors, and visual indicators based on the configured formatting rules. The conditional formatting dialog itself uses a Syncfusion popup that also relies on inline styles, so opening the dialog under strict CSP will display it unstyled.

### 3. Advanced number formatting & styling

Custom number formatting combined with alignment, text wrapping, or theme overrides may apply inline styles to individual cells at runtime. The number-formatting dialog, calculated-field dialog, and member editor also share this behavior, so they will display without theming under strict CSP.

### How to disable these features

If you do not need these advanced features, the rest of the Pivot Table works fully under strict CSP. Disable them at the component level by clearing the `View` to `Table`, removing conditional-formatting rules, and avoiding per-cell theme overrides.

## Recommended CSP configurations

Choose a configuration based on which features your app needs. Use the **strict** configuration when your Pivot Table is grid-only; use the **relaxed** configuration when you also need the integrated Pivot Chart, conditional formatting, or advanced number formatting.

N> **Stricter alternative to `'unsafe-inline'`:** instead of allowing all inline styles, use a per-request `nonce-*` or `hash-*` strategy. Generate a unique nonce per request, apply it to `<style>` and `style` attributes that the Pivot Table injects, and add `style-src 'self' 'nonce-<value>'` to the CSP. Syncfusion does not yet expose a built-in nonce API for the Pivot Table's runtime styles, so this approach requires a custom script to rewrite the generated `style` attributes before the browser evaluates them. Most teams therefore accept `'unsafe-inline'` for the Pivot Table's host page and rely on a strict CSP elsewhere.

N> **Hosting caveats:** for Blazor Server, the `connect-src` directive must allow the server origin and `wss://` for the SignalR connection. For Blazor WebAssembly, add `worker-src 'self' blob:;` to allow the runtime to spawn blob workers.

### Strict CSP (grid view only)

Use this configuration if you do not use the Pivot Chart view, conditional formatting, or advanced number formatting:

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

This configuration maintains full security for the Pivot Table's grid view functionality.

### Relaxed CSP (with advanced features)

Include `'unsafe-inline'` if you need Pivot Chart view, conditional formatting, or advanced number styling:

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

> Use the relaxed configuration only when integrated charting, cell-level conditional formatting, or advanced styling are essential to the app.

## See also

* [Content security policy in Blazor components](https://blazor.syncfusion.com/documentation/common/content-security-policy)