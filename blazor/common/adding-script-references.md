---
layout: post
title: Adding script references in Blazor - Syncfusion
description: Learn here about that how to add the script references manually in the Syncfusion Blazor Components.
platform: Blazor
component: Common
documentation: ug
---

# Reference scripts in Blazor Application

This section provides information about the Script Isolation process and how to add CDN, Static Web Assets & Customer resource generator script references for Syncfusion Blazor Components.

## JavaScript Isolation

Syncfusion Blazor enables JavaScript (JS) isolation in standard JavaScript modules and loaded scripts internally using JavaScript Isolation. It allows to load JavaScript code for a specific component alone. One of the goals of JavaScript (JS) isolation is to make components reusable that are not impacted by the global scope.

## IgnoreScript Isolation

The Syncfusion Blazor provides an `IgnoreScriptIsolation` option to refer the required component scripts externally from the application-end to increase initial load performance and better performance. If `IgnoreScriptIsolation` option is set to `true` in `AddSyncfusionBlazor()` service, the Syncfusion Blazor components will disable the dynamic script loading, instead of this it uses the external scripts reference from the application.

> The `IgnoreScriptIsolation` support is applicable only from 19.2.* version.

### Refer component scripts externally on Blazor Application

Set `IgnoreScriptIsolation` option as true in `AddSyncfusionBlazor` service to add script externally.

* If you're using `.NET 6` Blazor Server App, set `IgnoreScriptIsolation` option as true in `AddSyncfusionBlazor` service in `~/Program.cs` file.

    ```c#
    // For .NET 6 project, add the IgnoreScriptIsolation in Syncfusion Blazor Service in Program.cs file.
    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Web;
    using Syncfusion.Blazor;

    var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddRazorPages();
    builder.Services.AddServerSideBlazor();
    ....
    builder.Services.AddSyncfusionBlazor(options => { options.IgnoreScriptIsolation = true; });
    var app = builder.Build();
    ....
    ....
    ```

* If you're using `.NET 5 or .NET Core SDK 3.1 project` Blazor Server App, set `IgnoreScriptIsolation` option as true in `AddSyncfusionBlazor` service in `~/Startup.cs` file.

     ```c#
    using Syncfusion.Blazor;

    namespace WebApplication1
    {
        public class Startup
        {
            public void ConfigureServices(IServiceCollection services)
            {
                ....
                ....
                services.AddSyncfusionBlazor();
            }
        }
    }
    ```

* If you're using Blazor WebAssembly App, set `IgnoreScriptIsolation` option as true in `AddSyncfusionBlazor` service in `~/Program.cs` file.

    ```c#
    // For .NET 6 project.
    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Web;
    using Syncfusion.Blazor;

    var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddRazorPages();
    builder.Services.AddServerSideBlazor();
    ....
    builder.Services.AddSyncfusionBlazor(options => { options.IgnoreScriptIsolation = true; });
    var app = builder.Build();
    ....
    ....

    // For .NET 5 or .NET Core SDK 3.1 project.
    using Syncfusion.Blazor;
    ....
    ....
    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args)    ;
        ....
        ....

        // Set IgnoreScriptIsolation as true to load custom  scripts
        builder.Services.AddSyncfusionBlazor(options => { options.IgnoreScriptIsolation = true; });
        await builder.Build().RunAsync();
    }
    ```

> If we configure the `IgnoreScriptIsolation` as `true` in our Syncfusion Blazor Service, we need to manually add the external script reference in `~/Pages/_Layout.cshtml` for `.NET 6` project and in `~/Pages/_Host.cshtml` for `.NET 5 or .NET Core SDK 3.1 project` in Blazor Server app or `~/wwwroot/index.html` in Blazor WebAssembly app.

## CDN Reference

We can refer the Syncfusion Blazor scripts through the CDN resources by configuring the `IgnoreScriptIsolation` as `true` in our Syncfusion Blazor Service.

### Types

CDN Reference can be available in both version specific and unversioned links.

* Version based CDN
* Global CDN

#### Version based CDN

Version based CDN will contains the version specific contents (Scripts) for Syncfusion Blazor Components.

    ```html
    <head>
        ....
        ....
        <script src="https://cdn.syncfusion.com/blazor/{{ site.blazorversion }}/syncfusion-blazor.min.js" type="text/javascript"></script>
    </head>
    ```

> PdfViewer and DocumentEditor Component has a version specific separate CDN Script resources.

* To add verison specific CDN script reference for PdfViewer Component.

    ```html
    <head>
        ....
        ....
        <script src="https://cdn.syncfusion.com/blazor/{{ site.blazorversion }}/syncfusion-blazor-pdfviewer.min.js" type="text/javascript"></script>
    </head>
    ```

* To add verison specific CDN script reference for DocumentEditor Component.

    ```html
    <head>
        ....
        ....
        <script src="https://cdn.syncfusion.com/blazor/{{ site.blazorversion }}/syncfusion-blazor-documenteditor.min.js" type="text/javascript"></script>
    </head>
    ```

#### Global CDN

Global CDN will contains the latest release contents (Scripts) for Syncfusion Blazor Components.

    ```html
    <head>
        ....
        ....
        <script src="https://cdn.syncfusion.com/blazor/syncfusion-blazor.min.js" type="text/javascript"></script>
    </head>
    ```

> PdfViewer and DocumentEditor Component has a separate CDN Script resources.

* To add global CDN script reference for PdfViewer Component.

    ```html
    <head>
        ....
        ....
        <script src="https://cdn.syncfusion.com/blazor/syncfusion-blazor-pdfviewer.min.js" type="text/javascript"></script>
    </head>
    ```

* To add global CDN script reference for DocumentEditor Component.

    ```html
    <head>
        ....
        ....
        <script src="https://cdn.syncfusion.com/blazor/syncfusion-blazor-documenteditor.min.js" type="text/javascript"></script>
    </head>
    ```

## Static Web Assets

We can refer the Syncfusion Blazor scripts through the NuGet package's Static Web Assets by configuring the `IgnoreScriptIsolation` as `true` in our Syncfusion Blazor Service.

The [Syncfusion.Blazor](https://www.nuget.org/packages/Syncfusion.Blazor/) NuGet package's Static Web Assets contains a combined scripts for all components except PDF Viewer and Document Editor component.

* If you are using Syncfusion Blazor overall NuGet package ([Syncfusion.Blazor](https://www.nuget.org/packages/Syncfusion.Blazor/)), refer to the below code snippet for Static Web Assets Script reference.

    ```html
    <head>
        ...
        ...
        <script  src="_content/Syncfusion.Blazor/scripts/syncfusion-blazor.min.js"  type="text/javascript"></script>
    </head>
    ```

The Syncfusion Blazor individual Nuget packages contains [Syncfusion.Blazor.Core](https://www.nuget.org/packages/Syncfusion.Blazor/) as dependent package. The [Syncfusion.Blazor.Core](https://www.nuget.org/packages/Syncfusion.Blazor/) NuGet package's Static Web Assets contains a combined scripts for all components.

* If you are using Syncfusion Blazor individual NuGet package, the combined Scripts available in [Syncfusion.Blazor.Core](https://www.nuget.org/packages/Syncfusion.Blazor.Core/) package and refer to the below code snippet for Static Web Assets Script reference.

    ```html
    <head>
        ...
        ...
        <script  src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js"  type="text/javascript"></script>
    </head>
    ```

    > PDF Viewer and Document Editor component scripts are not available in `syncfusion-blazor.min.js` file. If we use the PDF viewer or document editor component refer the below script reference in your application end.

    ```html
    <head>
        ...
        ...
       <script  src="_content/Syncfusion.Blazor.PdfViewer/scripts/syncfusion-blazor-pdfviewer.min.js"  type="text/javascript"></script>
       <script  src="_content/Syncfusion.Blazor.WordProcessor/scripts/syncfusion-blazor-documenteditor.min.js"  type="text/javascript"></script>
    </head>
    ```

    > PDF Viewer and Document Editor component scripts are only available after 19.3.* version. If you are using PDF Viewer or Document Editor component with 19.2.* version, it automatically refer the dynamic script in our application end.

## Customer Resource Generator

The Syncfusion Blazor provides an option to generate a component's interop scripts using the [Custom Resource Generator](https://blazor.syncfusion.com/crg) (CRG) web tool for Blazor components. Refer [here for how to generate the component wise scripts manually using CRG](./custom-resource-generator)
