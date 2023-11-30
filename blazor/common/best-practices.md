---
layout: post
title: Best Practices for Improving Syncfusion Blazor App Performance | Syncfusion
description: Checkout and learn here all about optimal strategies for enhancing Syncfusion Blazor App performance.
platform: Blazor
component: Common
documentation: ug
---

# Best Practices for Improving Syncfusion Blazor App Performance

Enhancing the rendering performance of Syncfusion Blazor apps involves implementing the following best practices.

## Use Individual NuGet Packages

Opt for individual Syncfusion NuGet packages tailored to specific components. This approach allows you to selectively include only the necessary components, minimizing overhead. For detailed information, refer to [Benefits of Using Individual NuGet Packages](https://blazor.syncfusion.com/documentation/nuget-packages#benefits-of-using-individual-nuget-packages).

## Reduce Script Reference Size

The syncfusion-blazor-base.min.js' script reference may be redundant. Instead, consider employing the following solutions to include only the required scripts for rendering Syncfusion components.
* Referencing Scripts for Individual Components: Explore the guidance on incorporating script references for individual components at [Individual Control Script Reference](https://blazor.syncfusion.com/documentation/common/adding-script-references#individual-control-script-reference).
* Blazor CRG (Custom Resource Generator): Explore the Blazor CRG at [Blazor Custom Resource Generator](https://blazor.syncfusion.com/documentation/common/custom-resource-generator).

## Lazy Loading in Blazor WebAssembly App

If you're using a Blazor WebAssembly App, consider implementing lazy loading to reduce the initial loading time. For guidance, refer to Microsoft's documentation on [WebAssembly Lazy Load Assemblies](https://learn.microsoft.com/en-us/aspnet/core/blazor/webassembly-lazy-load-assemblies?view=aspnetcore-7.0) and Syncfusion's blog on [Lazy Loading Syncfusion Blazor Assemblies](https://www.syncfusion.com/blogs/post/lazy-loading-syncfusion-blazor-assemblies-in-a-blazor-webassembly-application.aspx).

## Utilize PreventRender Option (For Blazor WebAssembly App)

In a Blazor WebAssembly App, leverage the PreventRender option to avoid unnecessary re-rendering of Syncfusion components. This ensures optimal performance.
