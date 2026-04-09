---
layout: post
title: Content security policy (CSP) - Syncfusion
description: Learn how to use Syncfusion Blazor components with a strict Content Security Policy (CSP) in Blazor Web App, Blazor WebAssembly (WASM), and Blazor Server.
platform: Blazor
control: Common
documentation: ug
---

# Syncfusion® blazor components with strict content security policy

## What is content security policy (CSP)?

**Content Security Policy (CSP)** is a browser security feature that protects your application against malicious attacks like cross-site scripting (XSS) and data injection. It works by controlling where your application can load scripts, styles, images, fonts, and other resources from.

## Where to add CSP directives ?

Add CSP directives to the `<head>` tag of your application's main HTML file:

- **For .NET 8, 9, or 10 Blazor Web Apps** (Server, WebAssembly, or Auto modes): Add to `~/Components/App.razor`
- **For Blazor WebAssembly Standalone Apps**: Add to `wwwroot/index.html`

## Syncfusion support for strict CSP

Syncfusion now provides **strict CSP compatibility** for **over 80 components**. This means most of your application's core functionality can work securely without needing unsafe directives like `'unsafe-eval'` or `'unsafe-inline'`. 

This makes it easier for you to enforce strong security policies while still having access to all component features.

## Recommended CSP configurations 

The following CSP configurations are **recommended** for Syncfusion® Blazor components that support strict CSP (Refer Supported list below).

### Blazor server app

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

### Blazor interactive webassembly app and wasm standalone app

```html
<meta http-equiv="Content-Security-Policy"
      content="base-uri 'self';
               default-src 'self';
               connect-src 'self' https: ws: wss:;
               img-src 'self' data: https:;
               object-src 'none';
               script-src 'self' 'wasm-unsafe-eval';
               style-src 'self';
               font-src 'self' data:;
               upgrade-insecure-requests;">
```

**Why `'wasm-unsafe-eval'` for WebAssembly?** 

WebAssembly requires the [`'wasm-unsafe-eval'`](https://developer.mozilla.org/en-US/docs/Web/HTTP/Reference/Headers/Content-Security-Policy/script-src#unsafe_webassembly_execution) directive to compile and run. Without it, your Blazor runtime won't start. This is different from `'unsafe-eval'` and is necessary for client-side WebAssembly applications.

## When you need *'unsafe-inline'* ?

Most Syncfusion components support strict CSP. However, some components or features still need the **`style-src 'unsafe-inline'`** directive. Read the sections below to determine if your application needs it.


### Scenario 1: components that always require `'unsafe-inline'`

The following components need inline styles to work and always require `'unsafe-inline'`: 

| Category | Components | Reason for unsafe-inline Requirement |
|----------|------------|------------|
| **Data Visualization** | • Charts<br> • 3D Charts<br> • Stock Chart<br> • Bullet Chart<br> • Range Selector<br> • Sankey<br> • Sparkline Chart<br> • Smith Chart |<ul><li>These components are independent of external Syncfusion theme files and rely on runtime-generated inline styles for precise SVG, Canvas, and DOM rendering.</li><li>Dynamic calculation of axes, scales, gradients, data labels, and tooltips at runtime.</li><li>Inline styles ensure pixel‑perfect alignment and high‑performance redraws during zoom, pan, and real-time updates.</li></ul>|
| **File Viewers & Editors** | • Block Editor<br> • Rich Text Editor |<ul><li>File editing components apply dynamic inline styles to render rich content accurately based on user input and stored markup.</li><li>Formatting features (bold, italic, underline, font size, font color, background color, lists, links, alignment) require inline styles to reflect user intent precisely.</li></ul>|
| **Interactive Chat** | • Chat UI |<ul><li>Chat UI component is implemented using Blazor’s Virtualize component, which optimizes performance by rendering only the visible subset of messages within the viewport while representing the full dataset logically.</li><li>Blazor’s virtualization mechanism relies on runtime-generated inline styles as an essential part of its layout and scrolling model.</li></ul>|
| **File Management** | • File Manager |<ul><li>Uses inline styles for responsive grid/list views, selection highlights, drag indicators, and context menus.</li><li>Inline styles allow immediate visual feedback during selection, resizing panes, and drag operations.</li></ul>|
| **Layout** | • Card |<ul><li>Card components dynamically adjust layout, elevation, spacing, and responsive breakpoints via inline styles.</li><li>Enables adaptive layouts across different screen sizes and container widths.</li><li>Supports dynamic styling scenarios such as hover effects and conditional emphasis.</li></ul>|
| **Diagrams and Maps** | • Diagram |<ul><li>Diagram components depend extensively on inline styles for interactive behaviors.</li><li>Inline styles are used for node positioning, connectors, ports, annotations, and selection states.</li><li>Dragging, resizing, rotating, and snapping operations require continuous style updates at runtime.</li></ul>|
| **Kanban** | • Kanban |<ul><li>Kanban boards use inline styles to provide fluid drag‑and‑drop interactions between columns and cards.</li></ul>|

### Scenario 2: components with limited features requiring `'unsafe-inline'`

These components work under strict CSP for most features, but specific advanced features need `'unsafe-inline'`:

| Category | Components | 
|----------|------------|
| Data Management | Pivot Table - [Click here for feature details](../pivot-table/content-security-policy) |
| Scheduling | Gantt Chart - [Click here for feature details](../gantt-chart/content-security-policy) |
| Charts | Circular Gauge - [Click here for feature details](../circular-gauge/content-security-policy)<br> Heatmap Chart - [Click here for feature details](../heatmap-chart/content-security-policy) |
| Navigation | TreeView - [Click here for feature details](../treeview/content-security-policy) |
| Maps | Maps -[Click here for feature details](../maps/content-security-policy) |

### Scenario 3: passing inline styles via ComponentInputAttributes

If you add `style` attributes directly through `InputAttributes` or `HtmlAttributes`, strict CSP will block them:

```cshtml
@* This won't work under strict CSP *@
<SfTextBox InputAttributes='@(new Dictionary<string, object> { { "style", "width:200px;" } })' />
```

**Better approach:** Use component properties instead:

```cshtml
@* Use built-in properties like Width instead *@
<SfTextBox Width="200px" />

@* Or apply CSS classes to style the component *@
<style>
    .my-textbox { width: 200px; }
</style>
<SfTextBox CssClass="my-textbox" />
```

This keeps your CSP strict while still achieving your styling goals.

## CSP configuration with *'unsafe-inline'*

If your application needs any of the above scenarios, use this configuration:

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

This allows inline styles while keeping the rest of your security policy strict.


