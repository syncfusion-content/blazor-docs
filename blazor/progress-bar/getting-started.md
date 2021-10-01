---
layout: post
title: Getting Stared with Blazor ProgressBar in Server Side | Syncfusion
description: Learn here all about Getting Started with Syncfusion Blazor ProgressBar in Blazor Server Side App using Visual Studio and more.
platform: Blazor
control: Progress Bar 
documentation: ug
---

# Blazor ProgressBar Component in Server Side App using Visual Studio

This section briefly explains how to include a Progress Bar component in the Blazor server-side application. Refer to [Getting Started with Syncfusion Blazor for server-side in Visual Studio 2019](https://blazor.syncfusion.com/documentation/getting-started/blazor-server-side-visual-studio-2019/) page for introduction and configuring common specifications.

## Importing Syncfusion Blazor Progress Bar component in the application

1. Install **Syncfusion.Blazor** NuGet package to the application by using the **NuGet Package Manager**.

2. Add the client-side resources using through [CDN](https://blazor.syncfusion.com/documentation/appearance/themes#cdn-reference) or from [NuGet](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets) package in the **HEAD** element of the **~/Pages/_Host.cshtml** page.

    ```cshtml
    <head>
        <link href="_content/Syncfusion.Blazor.Themes/bootstrap4.css" rel="stylesheet" />
        <!---CDN--->
        @*<link href="https://cdn.syncfusion.com/blazor/{{ site.blazorversion }}/styles/bootstrap4.css" rel="stylesheet" />*@
    </head>
    ```

    > For Internet Explorer 11, kindly refer to the polyfills. Refer to the [documentation](https://blazor.syncfusion.com/documentation/common/how-to/render-blazor-server-app-in-ie/) for more information.

    ```cshtml
    <head>
        <link href="https://cdn.syncfusion.com/blazor/{{ site.blazorversion }}/styles/bootstrap4.css" rel="stylesheet" />
        <script src="https://github.com/Daddoon/Blazor.Polyfill/releases/download/3.0.1/blazor.polyfill.min.js"></script>
    </head>
    ```

## Adding component package to the application

Open the **~/_Imports.razor** file and include the **Syncfusion.Blazor.ProgressBar** namespace.

```cshtml
@using Syncfusion.Blazor.ProgressBar
```

## Adding SyncfusionBlazor service in the Startup.cs

Open the **Startup.cs** file and add services required by Syncfusion components using the **services.AddSyncfusionBlazor()** method. Add this method in the **ConfigureServices** function as follows.

```csharp
using Syncfusion.Blazor;

namespace BlazorApplication
{
    public class Startup
    {
        ....
        ....
        public void ConfigureServices(IServiceCollection services)
        {
            ....
            ....
            services.AddSyncfusionBlazor();
        }
    }
}
```

> To enable the custom client-side source loading from CRG or CDN, please refer to the section about [custom resources in Blazor application](https://blazor.syncfusion.com/documentation/common/custom-resource-generator/#how-to-use-custom-resources-in-the-blazor-application).

## Adding Progress Bar component

To initialize the Progress Bar component, add the following code to the **Index.razor** view page under the **~/Pages** folder. In a new application, if the **Index.razor** page has any default content template, then those content can be completely removed and following code can be added.

```cshtml
@page "/"

<SfProgressBar Value="50" Minimum="0" Maximum="100" TrackThickness="12" ProgressThickness="12">
</SfProgressBar>
```

On successful compilation of the application, the Syncfusion Blazor Progress Bar component will render in the web browser as following.

![Blazor Linear ProgressBar](images/blazor-linear-progressbar.png)

## Progress Type

Change the type of the Progress Bar by using the [Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ProgressBar.ProgressType.html) property. By default, the [Linear](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ProgressBar.ProgressType.html#Syncfusion_Blazor_ProgressBar_ProgressType_Linear) type of Progress Bar will be rendered. In the following example, view the [Circular](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ProgressBar.ProgressType.html#Syncfusion_Blazor_ProgressBar_ProgressType_Circular) type.

```cshtml
<SfProgressBar Type="ProgressType.Circular" Value="70" Minimum="0" Maximum="100" TrackThickness="8" ProgressThickness="8">
</SfProgressBar>
```

![Blazor Circular ProgressBar](images/blazor-circular-progressbar.png)
