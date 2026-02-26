---
layout: post
title: Supported Blazor Models
description: Learn how Syncfusion Blazor Components run across Blazor Server, Blazor WebAssembly, and the Blazor Web App (.NET 8, .NET 9, and .NET 10) render modes, with notes on Hybrid hosting.
platform: Blazor
control: Common
documentation: ug
---

# Supported Blazor Models

Syncfusion Blazor Components work across the main Blazor hosting and rendering models. Choose the model that best matches your deployment, performance, and team constraints.

## Blazor Web App (.NET 8, .NET 9, and .NET 10)

Blazor Web App introduces server-side rendering (SSR) with interactive render modes:

- Server: UI updates run on the server over a real-time connection.
- WebAssembly: UI logic executes on the client in the browser’s WebAssembly runtime.
- Auto: Starts with server interactivity and progressively enhances to WebAssembly when ready.

*Benefits*

- Fast first paint with SSR and progressive interactivity.
- SEO friendly markup generation on the server.
- Flexible per-page or per-component interactivity choice.

## Blazor Server

- UI events are processed on the server via a persistent SignalR connection.
- Very small download footprint and quick startup.
- Centralized resource usage; ideal for controlled environments.

*Considerations*

- Requires reliable connectivity; latency affects perceived responsiveness.
- Server resources scale with concurrent users.

## Blazor WebAssembly

- Runs entirely in the browser using the .NET WebAssembly runtime.
- Works offline once assets are cached.
- Can enable AOT (ahead-of-time) compilation for faster runtime performance.

*Considerations*

- Larger initial download compared to Server.
- Some operations (e.g., file processing) may require server APIs.

## Blazor Hybrid (overview)

Blazor Hybrid apps host Blazor UI in a native WebView inside .NET MAUI, WPF, or WinForms applications. Syncfusion Blazor UI works in this setup for building desktop and mobile experiences with shared Razor components.

## Choosing the right model

- Need fastest first paint and SEO with flexible interactivity: Blazor Web App with SSR + Auto interactivity.
- Need minimal download and centralized control: Blazor Server.
- Need offline capability and fully client-side execution: Blazor WebAssembly.
- Targeting desktop/mobile with shared web UI: Blazor Hybrid.
