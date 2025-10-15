---
layout: post
title: Best practices to optimize Syncfusion Blazor App performance
description: Learn practical ways to optimize Syncfusion Blazor Apps, including smaller packages, minimal scripts, optimized themes, lazy loading, and PreventRender.
platform: Blazor
control: Common
documentation: ug
---

# Best practices for optimizing Syncfusion® Blazor App performance

Improve rendering performance by applying the following best practices.

## Use individual NuGet packages

Use individual Syncfusion<sup style="font-size:70%">&reg;</sup> NuGet packages for specific components. This lets the app include only what it needs and reduces download size. Learn more in [Benefits of using individual NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages#benefits-of-using-individual-nuget-packages).

## Reduce script reference size

The overall `syncfusion-blazor.min.js` may include scripts the app doesn't use. Prefer referencing only the required scripts using one of the following options:

- [Individual reference](https://blazor.syncfusion.com/documentation/common/adding-script-references#individual-control-script-reference)
- [Blazor Custom Resource Generator (CRG)](https://blazor.syncfusion.com/documentation/common/custom-resource-generator)

## Use optimized CSS themes

To reduce CSS payload and improve rendering speed, use optimized CSS themes that include only the styles required by the components in use. Learn more in [Optimized CSS themes](https://blazor.syncfusion.com/documentation/appearance/themes#optimized-css-themes).

## Lazy loading in Blazor WebAssembly App

If using a Blazor WebAssembly App, implement lazy loading to reduce initial load time. See [WebAssembly lazy load assemblies](https://learn.microsoft.com/en-us/aspnet/core/blazor/webassembly-lazy-load-assemblies) and the Syncfusion blog on [lazy loading Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor assemblies](https://www.syncfusion.com/blogs/post/lazy-loading-syncfusion-blazor-assemblies-in-a-blazor-webassembly-application.aspx).

## Use PreventRender in Blazor WebAssembly App

In a Blazor WebAssembly App, use the `PreventRender` option to avoid unnecessary re-rendering of Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components and improve performance. For details, see:

- DataGrid: [WebAssembly performance](https://blazor.syncfusion.com/documentation/datagrid/webassembly-performance)
- Pivot Table: [WebAssembly performance](https://blazor.syncfusion.com/documentation/pivot-table/webassembly-performance)
