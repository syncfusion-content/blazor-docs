---
layout: post
title: Getting Started with Blazor Spinner Component | Syncfusion
description: Checkout and learn about getting started with Blazor Spinner component of Syncfusion, and more details.
platform: Blazor
control: Spinner
documentation: ug
---

# Getting Started with Blazor Spinner Component

This section briefly explains how to include a Spinner component in your Blazor Server-side application. You can refer to our Getting Started with [Syncfusion Blazor for Server-Side Spinner in Visual Studio 2019 page](../getting-started/blazor-server-side-visual-studio-2019/) for the introduction and configuring the common specifications.

## Importing Syncfusion Blazor component in the application

* Install **Syncfusion.Blazor.Spinner** NuGet package to the application by using the **NuGet Package Manager**.

* You can add the client-side resources using [NuGet](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets) package in the **HEAD** element of the **~/Pages/_Host.cshtml** page.

    ```cshtml

    <head>
        <environment include="Development">
        ....
        ....
            <link href="_content/Syncfusion.Blazor/styles/fabric.css" rel="stylesheet" />
            <!---CDN--->
            @*<link href="https://cdn.syncfusion.com/blazor/18.4.42/styles/fabric.css" rel="stylesheet" />*@
    </environment>
    </head>

    ```

    > For Internet Explorer 11 kindly refer the polyfills. Refer the [documentation](../common/how-to/render-blazor-server-app-in-ie/) for more information.

    ```cshtml

    <head>
    <environment include="Development">
        <link href="_content/Syncfusion.Blazor/styles/fabric.css" rel="stylesheet" />
        <script src="https://github.com/Daddoon/Blazor.Polyfill/releases/download/3.0.1/blazor.polyfill.min.js"></script>
    </environment>
    </head>

```

## Adding component package to the application

Open **~/_Imports.razor** file and import the **Syncfusion.Blazor.Spinner** package.

```cshtml

@using Syncfusion.Blazor.Spinner

```

## Add SyncfusionBlazor service in Startup.cs

Open the **Startup.cs** file and add services required by Syncfusion components using **services.AddSyncfusionBlazor()** method. Add this method in the **ConfigureServices** function as follows.

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

## Add Spinner component

To initialize the Spinner component, add the below code to your **Index.razor** view page which is present under **~/Pages** folder.

The Blazor Spinner component is used to display the loading indication with a specified target area while loading.

### Initialization

Import the `Syncufusion.Blazor.Spinner` NuGet package and initialize the Spinner component by adding the spinner as a child of the target element where the spinner needs to be shown.

The following code explains how to initialize a simple Spinner in the Blazor Razor page.

```cshtml

@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Spinner

<div>
    <SfButton @onclick="@ClickHandler">Show/Hide Spinner</SfButton>
    <div id="container">
        <SfSpinner @bind-Visible="@VisibleProperty">
        </SfSpinner>
    </div>
</div>

@code{
    private bool VisibleProperty { get; set; } = false;

    private async Task ClickHandler()
    {
        this.VisibleProperty = true;
        await Task.Delay(2000);
        this.VisibleProperty = false;
    }
}

```

## Run the application

After successful compilation of your application, simply press `F5` to run the application.

The output will be as follows.

![Spinner Default](./images/default.png)