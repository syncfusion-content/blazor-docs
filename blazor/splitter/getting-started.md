---
layout: post
title: Getting Started with Blazor Splitter Component | Syncfusion
description: Checkout and learn about getting started with Blazor Splitter component of Syncfusion, and more details.
platform: Blazor
control: Splitter
documentation: ug
---

<!-- markdownlint-disable MD024 -->

# Getting Started with Blazor Splitter Component

This section briefly explains how to include a Splitter component in your Blazor Server-side application. You can refer to our Getting Started with [Syncfusion Blazor for Server-Side in Visual Studio 2019 page](../getting-started/blazor-server-side-visual-studio-2019/) for the introduction and configuring the common specifications.

## Importing Syncfusion Blazor component in the application

* Install **Syncfusion.Blazor.Layouts** NuGet package to the application by using the **NuGet Package Manager**.

* You can add the client-side resources through CDN or from NuGet package in the **HEAD** element of the **~/Pages/_Host.cshtml** page.

```html

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

> For Internet Explorer 11 kindly refer the polyfills. Refer the [documentation](../../common/how-to/render-blazor-server-app-in-ie/) for more information.

```html

<head>
   <environment include="Development">
      <link href="_content/Syncfusion.Blazor/styles/fabric.css" rel="stylesheet" />
      <script src="https://github.com/Daddoon/Blazor.Polyfill/releases/download/3.0.1/blazor.polyfill.min.js"></script>
  </environment>
</head>

```

## Adding component package to the application

Open **~/_Imports.razor** file and import the **Syncfusion.Blazor.Layouts** package.

```csharp

@using Syncfusion.Blazor.Layouts

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

## Add Splitter component

To initialize the Splitter component, add the below code to your **Index.razor** view page which is present under **~/Pages** folder.

The following code explains how to initialize a simple horizontal Splitter in the Razor page.

```csharp

@using Syncfusion.Blazor.Layouts

<div>Horizontal Splitter</div>

<SfSplitter Height="240px" Width="100%">
    <SplitterPanes>
        <SplitterPane>
            <ContentTemplate>
                <div> Left Pane </div>
            </ContentTemplate>
        </SplitterPane>
        <SplitterPane>
            <ContentTemplate>
                <div> Middle Pane </div>
            </ContentTemplate>
        </SplitterPane>
        <SplitterPane>
            <ContentTemplate>
                <div> Right Pane </div>
            </ContentTemplate>
        </SplitterPane>
    </SplitterPanes>
</SfSplitter>

```

## Run the application

After successful compilation of your application, run the application.

The output will be as follows.

![splitter Sample](./images/getting-started-horizontal.png)

## See Also

* [Getting Started with Syncfusion Blazor for client-side in .NET Core CLI](../getting-started/blazor-webassembly-dotnet-cli/)

* [Getting Started with Syncfusion Blazor for server-side in Visual Studio 2019](../getting-started/blazor-server-side-visual-studio-2019/)

* [Getting Started with Syncfusion Blazor for server-side in .NET Core CLI](../getting-started/blazor-server-side-dotnet-cli/)