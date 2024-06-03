---
layout: post
title: Optimizing Syncfusion Blazor App Performance | Best Practices
description: Check out and learn here all about optimal strategies for enhancing Syncfusion Blazor App performance.
platform: Blazor
component: Common
documentation: ug
---

# Best Practices for Improving Syncfusion Blazor App Performance

Enhancing the rendering performance of Syncfusion Blazor apps involves implementing the following best practices.

## Use Individual NuGet Packages

Opt for individual Syncfusion NuGet packages for specific components. This approach allows you to selectively include only the necessary components, minimizing overhead. For detailed information, refer to [Benefits of Using Individual NuGet Packages](https://blazor.syncfusion.com/documentation/nuget-packages#benefits-of-using-individual-nuget-packages).

## Reduce Script Reference Size

The overall `syncfusion-blazor.min.js` script reference may be redundant. Instead, consider employing the following solutions to include only the required scripts for rendering Syncfusion components.
* [Individual reference](https://blazor.syncfusion.com/documentation/common/adding-script-references#individual-control-script-reference)
* [Blazor custom resource generator](https://blazor.syncfusion.com/documentation/common/custom-resource-generator)

## Lazy Loading in Blazor WebAssembly App

If you're using a Blazor WebAssembly app, consider implementing lazy loading to reduce the initial loading time. For guidance, refer to Microsoft's documentation on [WebAssembly lazy load assemblies](https://learn.microsoft.com/en-us/aspnet/core/blazor/webassembly-lazy-load-assemblies?view=aspnetcore-7.0) and Syncfusion's blog on [lazy loading Syncfusion Blazor assemblies](https://www.syncfusion.com/blogs/post/lazy-loading-syncfusion-blazor-assemblies-in-a-blazor-webassembly-application.aspx).

## Utilize PreventRender Option in Blazor WebAssembly App

In a Blazor WebAssembly app, leverage the **PreventRender** option to avoid unnecessary rerendering of Syncfusion Blazor components. This ensures optimal performance. For reference, we have provided links for the DataGrid and PivotTable:

* DataGrid: [Link to WebAssembly performance documentation](https://blazor.syncfusion.com/documentation/datagrid/webassembly-performance)
* PivotTable: [Link to WebAssembly performance documentation](https://blazor.syncfusion.com/documentation/pivot-table/webassembly-performance)
