---
layout: post
title: Reduce slowness while running the WASM sample | Syncfusion
description: Learn here all about how to reduce slowness while running the WASM sample in Debug Mode in Blazor SfPdfViewer component and more.
platform: Blazor
control: SfPdfViewer
documentation: ug
---

# Reduce slowness while running the WASM sample in Debug Mode

You may experience performance issues when running the WASM sample in Debug mode. To improve performance and reduce slowness, we recommend disabling the new .NET 9+ Mono Debugger, as it can impact the execution speed in this mode.

![Mono Debugger](../../pdfviewer-2/images/mono_debugger.png)

Disabling the Mono Debugger should help resolve the performance issues and provide a smoother experience while debugging your WebAssembly project.