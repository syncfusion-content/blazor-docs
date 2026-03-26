---
layout: post
title: Content Security Policy (CSP) - Syncfusion
description: Learn how to use Syncfusion Blazor components with a strict Content Security Policy (CSP) in Blazor Web App, Blazor WebAssembly (WASM), and Blazor Server.
platform: Blazor
control: Common
documentation: ug
---

# Syncfusion® Blazor Components with Strict Content Security Policy

## What is Content Security Policy (CSP)?

**Content Security Policy (CSP)** is a browser security feature that protects your application against malicious attacks like cross-site scripting (XSS) and data injection. It works by controlling where your application can load scripts, styles, images, fonts, and other resources from.

## Where to Add CSP Directives

Add CSP directives to the `<head>` tag of your application's main HTML file:

- **For .NET 8, 9, or 10 Blazor Web Apps** (Server, WebAssembly, or Auto modes): Add to `~/Components/App.razor`
- **For Blazor WebAssembly Standalone Apps**: Add to `wwwroot/index.html`

## Syncfusion Support for Strict CSP

Syncfusion now provides **strict CSP compatibility** for **over 80 components**. This means most of your application's core functionality can work securely without needing unsafe directives like `'unsafe-eval'` or `'unsafe-inline'`. 

This makes it easier for you to enforce strong security policies while still having access to all component features.

## Recommended CSP Configurations 

The following CSP configurations are **recommended** for Syncfusion® Blazor components that support strict CSP (Refer Supported list below).

### Blazor Server App

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

### Blazor WebAssembly and Hybrid (Auto) Apps

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

## When You Need `'unsafe-inline'`

Most Syncfusion components support strict CSP. However, some components or features still need the **`style-src 'unsafe-inline'`** directive. Read the sections below to determine if your application needs it.

## Three Scenarios That Require CSP Relaxation

### Scenario 1: Components That Always Require `'unsafe-inline'`

The following components need inline styles to work and always require `'unsafe-inline'`: 

| Category | Components |
| **Data Visualization** | Charts, 3D Charts, Stock Chart, Bullet Chart, Range Selector, Sankey, Sparkline Chart, Smith Chart |
| **File Viewers & Editors** | Block Editor, Rich Text Editor |
| **Interactive Chat** | Chat UI |
| **File Management** | File Manager |
| **Layout** | Card |
| **Diagrams and Maps** | Diagram |
| **Kanban** | Kanban |

### Scenario 2: Components With Limited Features Requiring `'unsafe-inline'`

These components work under strict CSP for most features, but specific advanced features need `'unsafe-inline'`:

| Category | Components |
|----------|------------|
| Data Management | [Pivot Table](../pivot-table/content-security-policy) |
| Scheduling | [Gantt Chart](../gantt-chart/content-security-policy) |
| Charts & Maps | [Circular Gauge](../circular-gauge/content-security-policy), [Maps](../maps/content-security-policy), [Heatmap Chart](../heatmap-chart/content-security-policy) |
| Navigation | [TreeView](../treeview/content-security-policy) |

### Scenario 3: Passing Inline Styles via ComponentInputAttributes

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

## CSP Configuration With `'unsafe-inline'`

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


