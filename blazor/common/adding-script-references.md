---
layout: post
title: Adding script references in Blazor - Syncfusion
description: Learn here about that how to add the script references manually in the Syncfusion Blazor Components.
platform: Blazor
component: Common
documentation: ug
---

# Reference scripts in Blazor Application

This section provides information about the script isolation process and how to reference scripts from CDN, Static Web Assets and Custom resource generator (CRG) for Syncfusion Blazor Components.

## JavaScript isolation

Syncfusion Blazor components supports JavaScript isolation where the needed scripts are loaded by the component itself when its rendered. So, you don't have to reference scripts externally in application.

> Syncfusion recommends to reference scripts using CDN over static web assets for better loading performance of the blazor application.

## Disable JavaScript isolation

The Syncfusion Blazor components supports to refer scripts externally at the application-end by disabling default JavaScript isolation approach for better initial loading performance which explained in the previous section. You can disable JS isolation by setting [IgnoreScriptIsolation](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.GlobalOptions.html#Syncfusion_Blazor_GlobalOptions_IgnoreScriptIsolation) as `true` while adding Syncfusion blazor service using `AddSyncfusionBlazor()`.

### Blazor Server App

* If you're using `.NET 6` Blazor Server App, set [IgnoreScriptIsolation](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.GlobalOptions.html#Syncfusion_Blazor_GlobalOptions_IgnoreScriptIsolation) property as `true` using `AddSyncfusionBlazor` service method in `~/Program.cs` file.

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

* If you're using `.NET 5 or .NET Core SDK 3.1 project` Blazor Server App, set [IgnoreScriptIsolation](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.GlobalOptions.html#Syncfusion_Blazor_GlobalOptions_IgnoreScriptIsolation) property as `true` using `AddSyncfusionBlazor` service method in `~/Startup.cs` file.

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

### Blazor WASM App

* If you're using Blazor WebAssembly App, set [IgnoreScriptIsolation](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.GlobalOptions.html#Syncfusion_Blazor_GlobalOptions_IgnoreScriptIsolation) property as `true` using `AddSyncfusionBlazor` service method in `~/Program.cs` file.

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

> If you set [IgnoreScriptIsolation](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.GlobalOptions.html#Syncfusion_Blazor_GlobalOptions_IgnoreScriptIsolation) property as `true`, You need to reference scripts externally via CDN Reference or Static Web Assets.

## CDN Reference

You can refer the Syncfusion Blazor scripts through the CDN resources by configuring the [IgnoreScriptIsolation](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.GlobalOptions.html#Syncfusion_Blazor_GlobalOptions_IgnoreScriptIsolation) as `true`. The external script reference can be added as follows,

* For Blazor Server App, reference scripts in `~/Pages/_Layout.cshtml` file for `.NET 6` project and in `~/Pages/_Host.cshtml` file for `.NET 5 and .NET Core 3.1` project.
* For Blazor WASM App, reference scripts in `~/wwwroot/index.html` file.

Syncfusion Blazor components are available in CDN for each version. Make sure that the version in the URLs matches the version of the Syncfusion Blazor Package you are using.

| Component  | CDN Script Reference |
| --- | --- |
| All components except PDF Viewer & Document Editor | https://cdn.syncfusion.com/blazor/{{ site.blazorversion }}/syncfusion-blazor.min.js |
| PDF Viewer | https://cdn.syncfusion.com/blazor/{{ site.blazorversion }}/syncfusion-blazor-pdfviewer.min.js |
| Document Editor | https://cdn.syncfusion.com/blazor/{{ site.blazorversion }}/syncfusion-blazor-documenteditor.min.js |

```html
<head>
    ....
    ....
    <script src="https://cdn.syncfusion.com/blazor/{{ site.blazorversion }}/syncfusion-blazor.min.js" type="text/javascript"></script>
</head>
```

If you are using `PDFViewer` or `DocumentEditor`, ensure to add additional script references as follows,

```html
<head>
    ....
    ....
    <script src="https://cdn.syncfusion.com/blazor/{{ site.blazorversion }}/syncfusion-blazor-pdfviewer.min.js" type="text/javascript"></script>
    <script src="https://cdn.syncfusion.com/blazor/{{ site.blazorversion }}/syncfusion-blazor-documenteditor.min.js" type="text/javascript"></script>
</head>
```

In addition to above, Syncfusion Blazor components provides latest scripts in CDN without versioning. You can use this in development environment if you want to always use the latest version of scripts. It is not recommended to use this in production environment.

| Component | CDN Script Reference |
| --- | --- |
|  All components except PDF Viewer & Document Editor | https://cdn.syncfusion.com/blazor/syncfusion-blazor.min.js |
| PDF Viewer | https://cdn.syncfusion.com/blazor/syncfusion-blazor-pdfviewer.min.js |
| Document Editor | https://cdn.syncfusion.com/blazor/syncfusion-blazor-documenteditor.min.js |

## Static Web Assets

You can refer the Syncfusion Blazor scripts through the NuGet package's Static Web Assets by configuring the `IgnoreScriptIsolation` as `true` in our Syncfusion Blazor Service.

The [Syncfusion.Blazor](https://www.nuget.org/packages/Syncfusion.Blazor/) NuGet package's Static Web Assets contains a combined scripts for all components except PDF Viewer and Document Editor component.

* If you are using Syncfusion Blazor overall NuGet package ([Syncfusion.Blazor](https://www.nuget.org/packages/Syncfusion.Blazor/)), refer to the below code snippet for Static Web Assets Script reference.

    ```html
    <head>
        ...
        ...
        <script  src="_content/Syncfusion.Blazor/scripts/syncfusion-blazor.min.js"  type="text/javascript"></script>
    </head>
    ```

The Syncfusion Blazor individual NuGet packages contains [Syncfusion.Blazor.Core](https://www.nuget.org/packages/Syncfusion.Blazor/) as dependent package. The [Syncfusion.Blazor.Core](https://www.nuget.org/packages/Syncfusion.Blazor/) NuGet package's Static Web Assets contains a combined scripts for all components.

* If you are using Syncfusion Blazor individual NuGet package, the combined Scripts available in [Syncfusion.Blazor.Core](https://www.nuget.org/packages/Syncfusion.Blazor.Core/) package and refer to the below code snippet for Static Web Assets Script reference.

    ```html
    <head>
        ...
        ...
        <script  src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js"  type="text/javascript"></script>
    </head>
    ```

* PDF Viewer and Document Editor component scripts are not available in `syncfusion-blazor.min.js` file. If You use the PDF viewer or document editor component refer the below script reference in your application end.

    ```html
    <head>
        ...
        ...
       <script  src="_content/Syncfusion.Blazor.PdfViewer/scripts/syncfusion-blazor-pdfviewer.min.js"  type="text/javascript"></script>
       <script  src="_content/Syncfusion.Blazor.WordProcessor/scripts/syncfusion-blazor-documenteditor.min.js"  type="text/javascript"></script>
    </head>
    ```

    > PDF Viewer and Document Editor component scripts are only available after 19.3.* version. If you are using PDF Viewer or Document Editor component with 19.2.* version, it automatically refer the dynamic script in our application end.

## Custom Resource Generator

The Syncfusion Blazor provides an option to generate a component's interop scripts using the [Custom Resource Generator](https://blazor.syncfusion.com/crg) (CRG) web tool for Blazor components. Refer [here for how to generate the component wise scripts manually using CRG](./custom-resource-generator).
