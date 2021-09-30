---
layout: post
title: Getting Started with Blazor Toolbar Component | Syncfusion
description: Checkout and learn here all about getting started with Blazor Toolbar component of Syncfusion, and more details.
platform: Blazor
control: Toolbar
documentation: ug
---

# Getting Started with Blazor Toolbar Component

This section briefly explains about how to include a `Toolbar` in the Blazor server-side application. Refer [Getting Started with Syncfusion Blazor for Server-Side in Visual Studio 2019](../getting-started/blazor-server-side-visual-studio-2019/) page for the introduction and configuring the common specifications.

To get started quickly with Blazor Toolbar, check on this video:

{% youtube
"youtube:https://www.youtube.com/watch?v=3brT3ztZErE"%}

## Importing Syncfusion Blazor component in the application

Use any one of the below standards to install the Syncfusion Blazor library in the application.

### Using Syncfusion Blazor individual NuGet Packages [New standard]

> Starting with Volume 4, 2020 (v18.4.0.30) release, Syncfusion provides [individual NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages/) for the Syncfusion Blazor components. This new standard is highly recommended for the Blazor production applications. Refer to [this section](https://blazor.syncfusion.com/documentation/nuget-packages/#benefits-of-using-individual-nuget-packages) to know the benefits of the individual NuGet packages.

1. Install **Syncfusion.Blazor.Navigations** NuGet package to the application using the `NuGet Package Manager`.

2. Add the client-side style resources through [CDN](https://blazor.syncfusion.com/documentation/appearance/themes#cdn-reference) or from [NuGet](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets) package in the `<head>` element of the **~/Pages/_Host.cshtml** page.

    ```html
    <head>
        ....
        ....
        <link href="_content/Syncfusion.Blazor.Themes/bootstrap4.css" rel="stylesheet" />
    </head>
    ```

    W> `Syncfusion.Blazor` package should not be installed along with the [individual NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages/). Hence, the above `Syncfusion.Blazor.Themes` static web assets (styles) have to be added in the application.

### Using Syncfusion.Blazor NuGet Package [Old standard]

W> If the above new standard (individual NuGet packages) is preferred, then skip this section. Using both old and new standards in the same application will throw ambiguous compilation errors.

1. Install **Syncfusion.Blazor** NuGet package to the newly created application by using the `NuGet Package Manager`.

2. The client-side style resources can be added through [CDN](https://blazor.syncfusion.com/documentation/appearance/themes#cdn-reference) or from [NuGet](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets) package in the `<head>` element of the **~/Pages/_Host.cshtml** page.

    ```html
    <head>
        ....
        ....
        <link href="_content/Syncfusion.Blazor/styles/bootstrap4.css" rel="stylesheet" />
         @*<link href="https://cdn.syncfusion.com/blazor/{{ site.blazorversion }}/styles/bootstrap4.css" rel="stylesheet" />*@
    </head>
    ```

    > For Internet Explorer 11 kindly refer the polyfills. Refer the [documentation](../common/how-to/render-blazor-server-app-in-ie/) for more information.

    ```html
    <head>
        ...
            <link href="https://cdn.syncfusion.com/blazor/{{ site.blazorversion }}/styles/bootstrap4.css" rel="stylesheet" />
            <script src="https://github.com/Daddoon/Blazor.Polyfill/releases/download/3.0.1/blazor.polyfill.min.js"></script>
        ...
    </head>
    ```

## Adding component package to the application

Open `~/_Imports.razor` file and import the `Syncfusion.Blazor.Navigations` package.

```cshtml
@using Syncfusion.Blazor.Navigations
```

## Add SyncfusionBlazor service in Startup file

Open the **Startup.cs** file and add services required by Syncfusion components using  **services.AddSyncfusionBlazor()** method. Add this method in the **ConfigureServices** function as follows.

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

## Adding Toolbar component to the application

Now, add the Syncfusion Blazor Toolbar component in any web page (razor) in the `Pages` folder. For example, the Toolbar component is added in the `~/Pages/Index.razor` page.

```cshtml
@using Syncfusion.Blazor.Navigations

<SfToolbar>
    <ToolbarItems>
        <ToolbarItem Text="Cut"></ToolbarItem>
        <ToolbarItem Text="Copy"></ToolbarItem>
        <ToolbarItem Text="Paste"></ToolbarItem>
        //To separate the Toolbar items
        <ToolbarItem></ToolbarItem>
        <ToolbarItem Text="Bold"></ToolbarItem>
        <ToolbarItem Text="Underline"></ToolbarItem>
        <ToolbarItem Text="Italic"></ToolbarItem>
        <ToolbarItem Text="Color-Picker"></ToolbarItem>
    </ToolbarItems>
</SfToolbar>
```

## Run the application

After successful compilation of the application, simply press `F5` to run the application.

![Default Toolbar](./images/browser-output.png)

## See Also

1. [Getting Started with Syncfusion Blazor for client-side in .NET Core CLI](../getting-started/blazor-webassembly-dotnet-cli/)
2. [Getting Started with Syncfusion Blazor for client-side in Visual Studio 2019](../getting-started/blazor-webassembly-visual-studio-2019/)
3. [Getting Started with Syncfusion Blazor for server-side in .NET Core CLI](../getting-started/blazor-server-side-dotnet-cli/)