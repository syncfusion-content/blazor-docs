---
layout: post
title: Adding script references in Blazor - Syncfusion
description: Checkout and learn here about how to add the script references manually in the Syncfusion Blazor Components.
platform: Blazor
component: Common
documentation: ug
---

# Reference Scripts in Blazor Application

This section provides information about the script isolation process and how to reference scripts from CDN, Static Web Assets and Custom resource generator (CRG) for Syncfusion Blazor Components.

> The javascript interop files needs to be added to support the features that can't be implemented in native Blazor. 

## JavaScript isolation

Syncfusion Blazor components support JavaScript isolation where the needed scripts are loaded by the component itself when it is rendered. So, you don't have to reference scripts externally in application. 

> Syncfusion recommends to reference scripts using [Static Web Assets](https://blazor.syncfusion.com/documentation/common/adding-script-references#static-web-assets), [CDN](https://blazor.syncfusion.com/documentation/common/adding-script-references#cdn-reference) and [CRG](https://blazor.syncfusion.com/documentation/common/custom-resource-generator) by disabling JavaScript isolation for better loading performance of the Blazor application. 

## Disable JavaScript isolation

The Syncfusion Blazor components support to refer scripts externally at the application-end by disabling default JavaScript isolation approach for better initial loading performance which is explained in the previous section. You can disable JS isolation by setting [IgnoreScriptIsolation](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.GlobalOptions.html#Syncfusion_Blazor_GlobalOptions_IgnoreScriptIsolation) as `true` while adding Syncfusion Blazor service using `AddSyncfusionBlazor()`. 

### Blazor Server App

* For **.NET 6** app, open the **~/Program.cs** file and register the Syncfusion Blazor Service by setting `IgnoreScriptIsolation`.

* For **.NET 5 and .NET 3.X** app, open the **~/Startup.cs** file and register the Syncfusion Blazor Service by setting `IgnoreScriptIsolation`.

{% tabs %}
{% highlight c# tabtitle=".NET 6 (~/Program.cs)" hl_lines="10" %}

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSyncfusionBlazor(options => { options.IgnoreScriptIsolation = true; });

var app = builder.Build();
....

{% endhighlight %}

{% highlight c# tabtitle=".NET 5 and .NET 3.X (~/Startup.cs)" hl_lines="12" %}

using Syncfusion.Blazor;

namespace BlazorApplication
{
    public class Startup
    {
        ...
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSyncfusionBlazor(options => { options.IgnoreScriptIsolation = true; });
        }
        ...
    }
}

{% endhighlight %}
{% endtabs %}

### Blazor WASM App

For Blazor WebAssembly App, set [IgnoreScriptIsolation](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.GlobalOptions.html#Syncfusion_Blazor_GlobalOptions_IgnoreScriptIsolation) property as `true` using `AddSyncfusionBlazor` service method in `~/Program.cs` file.

{% tabs %}
{% highlight c# tabtitle=".NET 6 (~/Program.cs)" hl_lines="9" %}

using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Syncfusion.Blazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddSyncfusionBlazor(options => { options.IgnoreScriptIsolation = true; });
await builder.Build().RunAsync();
....

{% endhighlight %}

{% highlight c# tabtitle=".NET 5 and .NET 3.X (~/Program.cs)" hl_lines="10" %}

using Syncfusion.Blazor;

namespace WebApplication1
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            ....
            builder.Services.AddSyncfusionBlazor(options => { options.IgnoreScriptIsolation = true; });
            await builder.Build().RunAsync();
        }
    }
}
{% endhighlight %}
{% endtabs %}

> If you set [IgnoreScriptIsolation](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.GlobalOptions.html#Syncfusion_Blazor_GlobalOptions_IgnoreScriptIsolation) property as `true`, you need to reference scripts externally via [Static Web Assets](https://blazor.syncfusion.com/documentation/common/adding-script-references#static-web-assets), [CDN](https://blazor.syncfusion.com/documentation/common/adding-script-references#cdn-reference), or [CRG](https://blazor.syncfusion.com/documentation/common/custom-resource-generator). 

## CDN Reference

You can refer the Syncfusion Blazor scripts through the CDN resources by configuring the [IgnoreScriptIsolation](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.GlobalOptions.html#Syncfusion_Blazor_GlobalOptions_IgnoreScriptIsolation) as `true`. The external script reference can be added as follows,

* For **Blazor WASM App**, reference scripts in `~/wwwroot/index.html` file. 
* For **Blazor Server App**, reference scripts in `~/Pages/_Layout.cshtml` file for `.NET 6` project and in `~/Pages/_Host.cshtml` file for `.NET 5 and .NET Core 3.X` project.

Syncfusion Blazor components are available in CDN for each version. Make sure that the version in the URLs matches the version of the Syncfusion Blazor Package you are using.

| Component  | CDN Script Reference |
| --- | --- |
| All components except PDF Viewer & Document Editor | https://cdn.syncfusion.com/blazor/{{ site.blazorversion }}/syncfusion-blazor.min.js |
| PDF Viewer | https://cdn.syncfusion.com/blazor/{{ site.blazorversion }}/syncfusion-blazor-pdfviewer.min.js |
| Document Editor | https://cdn.syncfusion.com/blazor/{{ site.blazorversion }}/syncfusion-blazor-documenteditor.min.js |

```html
<head>
    ....
    <script src="https://cdn.syncfusion.com/blazor/{{ site.blazorversion }}/syncfusion-blazor.min.js" type="text/javascript"></script>
</head>
```

If you are using `PDFViewer` or `DocumentEditor`, ensure to add additional script references as follows,

```html
<head>
    ....
    <script src="https://cdn.syncfusion.com/blazor/{{ site.blazorversion }}/syncfusion-blazor-pdfviewer.min.js" type="text/javascript"></script>
    <script src="https://cdn.syncfusion.com/blazor/{{ site.blazorversion }}/syncfusion-blazor-documenteditor.min.js" type="text/javascript"></script>
</head>
```

In addition to the above, Syncfusion Blazor components provide the latest scripts in CDN without versioning. You can use this in development environment if you want to always use the latest version of scripts. It is not recommended to use this in production environment. 

| Component | CDN Script Reference |
| --- | --- |
|  All components except PDF Viewer & Document Editor | https://cdn.syncfusion.com/blazor/syncfusion-blazor.min.js |
| PDF Viewer | https://cdn.syncfusion.com/blazor/syncfusion-blazor-pdfviewer.min.js |
| Document Editor | https://cdn.syncfusion.com/blazor/syncfusion-blazor-documenteditor.min.js |

## Static web assets

You can refer the Syncfusion Blazor scripts through the NuGet package's static web assets using [IgnoreScriptIsolation](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.GlobalOptions.html#Syncfusion_Blazor_GlobalOptions_IgnoreScriptIsolation) as `true` in our Syncfusion Blazor Service.

### Enable static web assets usage

To use static web assets, ensure [UseStaticFiles](https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.builder.staticfileextensions.usestaticfiles) method is called as follows,

* For **.NET 6** app, open the **~/Program.cs** file and call `UseStaticFiles` method.
* For **.NET 5 and .NET 3.X** app, open the **~/Startup.cs** file and call `UseStaticFiles` method.

> For **Blazor WASM App**, call `UseStaticFiles` method in **Server project** of the above mentioned file. 

### Refer script from static web assets

* If you are using Syncfusion [Blazor individual NuGet package](https://blazor.syncfusion.com/documentation/nuget-packages), the combined scripts available in [Syncfusion.Blazor.Core](https://www.nuget.org/packages/Syncfusion.Blazor.Core/) package. To refer script from static web assets, use the code below.

    ```html
    <head>
        ...
        <script  src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js"  type="text/javascript"></script>
    </head>
    ```

* If you're using the PDF viewer or Document Editor component, use the code below to refer to script from static web assets.

    ```html
    <head>
        ...
       <script  src="_content/Syncfusion.Blazor.PdfViewer/scripts/syncfusion-blazor-pdfviewer.min.js"  type="text/javascript"></script>
       <script  src="_content/Syncfusion.Blazor.WordProcessor/scripts/syncfusion-blazor-documenteditor.min.js"  type="text/javascript"></script>
    </head>
    ```

* If you are using [Syncfusion.Blazor](https://www.nuget.org/packages/Syncfusion.Blazor/) NuGet package, use the code below to refer to script from static web assets.

    It is not recommended to use [Syncfusion.Blazor](https://www.nuget.org/packages/Syncfusion.Blazor/) NuGet for production environment. Use individual NuGet packages for production.  

    ```html
    <head>
        ...
        <script  src="_content/Syncfusion.Blazor/scripts/syncfusion-blazor.min.js"  type="text/javascript"></script>
    </head>
    ```

    > The PDF Viewer and Document Editor component scripts are available in static web assets from 19.3.* version. If you are using PDF Viewer or Document Editor component with 19.2.* version, it automatically switches to the JavaScript isolation in the application end.

## Custom Resource Generator

The Syncfusion Blazor provides an option to generate a component's interop scripts using the [Custom Resource Generator](https://blazor.syncfusion.com/crg) (CRG) tool for the Blazor components. Refer [here to generate the component-wise scripts externally using CRG](./custom-resource-generator).
