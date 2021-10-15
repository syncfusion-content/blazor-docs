---
layout: post
title: Getting Started with Blazor Breadcrumb component | Syncfusion
description: Checkout and learn about getting started with Blazor Breadcrumb component of Syncfusion, and more details.
platform: Blazor
control: Breadcrumb
documentation: ug
---

<!-- markdownlint-disable MD024 -->

# Getting Started with Blazor Breadcrumb component

This section briefly explains about how to include [Breadcrumb](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfBreadcrumb.html) component in your Blazor server-side  application. You can refer [Getting Started with Syncfusion Blazor for Server-side in Visual Studio](https://blazor.syncfusion.com/documentation/getting-started/blazor-server-side-visual-studio-2019/) page for the introduction and configuring the common specifications.

## Importing Syncfusion Blazor component in the application

1. Install the [Syncfusion.Blazor](https://www.nuget.org/packages/Syncfusion.Blazor) NuGet package to the application by using the `NuGet Package Manager`.

2. You can add the client-side resources through [CDN](https://blazor.syncfusion.com/documentation/appearance/themes#cdn-reference) or from [NuGet](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets) package in the **HEAD** element of the **~/Pages/_Host.cshtml** page.

```html
<head>
    <environment include="Development">
    ....
    ....
        <link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />
    </environment>
</head>
```

For Internet Explorer 11 kindly refer the polyfills. Refer the [documentation](https://blazor.syncfusion.com/documentation/common/how-to/render-blazor-server-app-in-ie/) for more information.

## Adding component package to the application

Open `/_Imports.razor file` and import the **Syncfusion.Blazor.Navigations** package.

```cshtml

@using Syncfusion.Blazor.Navigations

```

## Add SyncfusionBlazor service in Startup.cs

Open the **Startup.cs** file and add services required by Syncfusion components using **services.AddSyncfusionBlazor()** method. Add this method in the **ConfigureServices** function as follows.

```c#
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

## Add Breadcrumb Component

To initialize the Breadcrumb component add the below code to your **Index.razor** view page which is present under **~/Pages** folder.

```cshtml
<SfBreadcrumb></SfBreadcrumb>

```

![Blazor Breadcrumb Component](./images/blazor-Breadcrumb-component.png)

## Add Items to the Breadcrumb component

Use [BreadcrumbItem](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.BreadcrumbItem.html) tag directive to render the Breadcrumb component. The below example demonstrates the basic rendering of Breadcrumb with items support.

```cshtml
@using Syncfusion.Blazor.Navigations

<SfBreadcrumb>
    <BreadcrumbItems>
        <BreadcrumbItem IconCss="e-icons e-home" Url="https://blazor.syncfusion.com/demos/"></BreadcrumbItem>
        <BreadcrumbItem Text="Components" Url="https://blazor.syncfusion.com/demos/datagrid/overview"></BreadcrumbItem>
        <BreadcrumbItem Text="Navigations" Url="https://blazor.syncfusion.com/demos/menu-bar/default-functionalities"></BreadcrumbItem>
        <BreadcrumbItem Text="Breadcrumb" Url="./breadcrumb/default-functionalities"></BreadcrumbItem>
    </BreadcrumbItems>
</SfBreadcrumb>
```

![Blazor Breadcrumb Component](./images/blazor-Breadcrumb-items.png)

## Enable or disable Navigation

Breadcrumb component enables or disables built-in URL navigation based on the [EnableNavigation](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfBreadcrumb.html#Syncfusion_Blazor_Navigations_SfBreadcrumb_EnableNavigation) property. By default, the navigation will be enabled when setting the [Url](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfBreadcrumb.html#Syncfusion_Blazor_Navigations_SfBreadcrumb_Url) property. To prevent breadcrumb item navigation, set the [EnableNavigation](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfBreadcrumb.html#Syncfusion_Blazor_Navigations_SfBreadcrumb_EnableNavigation) property as false in Breadcrumb.

## See Also

* [Getting Started with Syncfusion Blazor for Client-Side in .NET Core CLI](https://blazor.syncfusion.com/documentation/getting-started/blazor-webassembly-dotnet-cli/)
* [Getting Started with Syncfusion Blazor for Server-Side in Visual Studio 2019 Preview](https://blazor.syncfusion.com/documentation/getting-started/blazor-server-side-visual-studio-2019/)
* [Getting Started with Syncfusion Blazor for Server-Side in .NET Core CLI](https://blazor.syncfusion.com/documentation/getting-started/blazor-server-side-dotnet-cli/)