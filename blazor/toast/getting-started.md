---
layout: post
title: Getting Started with Blazor Toast Component | Syncfusion
description: Checkout and learn about getting started with Blazor Toast component of Syncfusion, and more details.
platform: Blazor
control: Toast
documentation: ug
---

# Getting Started with Blazor Toast Component

This section briefly explains how to include a Toast component in the Blazor Server-side application. Refer to Getting Started with [Syncfusion Blazor for Server-Side in Visual Studio 2019 page](../getting-started/blazor-server-side-visual-studio-2019/) for the introduction and configuring the common specifications.

To get start quickly with Blazor Toast component, check on this video:
{% youtube
"youtube:https://www.youtube.com/watch?v=tMa7JvcfNcY"%}

## Importing Syncfusion Blazor component in the application

* Install **Syncfusion.Blazor.Notifications** NuGet package to the application by using the **NuGet Package Manager**.

* The client-side resources can be added through [CDN](https://blazor.syncfusion.com/documentation/appearance/themes#cdn-reference) or from [NuGet](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets) package in the **HEAD** element of the **~/Pages/_Host.cshtml** page.

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

Open **~/_Imports.razor** file and import the **Syncfusion.Blazor.Notifications** package.

```cshtml

@using Syncfusion.Blazor.Notifications

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

## Add Toast component

To initialize the Toast component, add the below code to **Index.razor** view page which is present under **~/Pages** folder.

The following code explains how to initialize a simple Toast in Razor page.

```cshtml

@using Syncfusion.Blazor.Notifications

<div class="col-lg-12 control-section toast-default-section">
    <SfToast ID="toast_default" @ref="ToastObj" Title="Adaptive Tiles Meeting" Content="@ToastContent" Timeout="5000" Icon="e-meeting">
        <ToastPosition X="@ToastPosition"></ToastPosition>
    </SfToast>
    <div class="col-lg-12 col-sm-12 col-md-12 center">
        <div id="toastBtnDefault" style="margin: auto;text-align: center">
            <button class="e-btn" @onclick="@ShowOnClick">Show Toasts</button>
            <button class="e-btn" @onclick="@HideOnClick">Hide All</button>
        </div>
    </div>
</div>
<style>
    #toast_default .e-meeting::before {
        content: "\e705";
        font-size: 17px;
    }

    .bootstrap4 #toast_default .e-meeting::before {
        content: "\e763";
        font-size: 20px;
    }
</style>
@code {
    SfToast ToastObj;
    private string ToastPosition = "Right";
    private string ToastContent = "Conference Room 01 / Building 135 10:00 AM-10:30 AM";
    private async Task ShowOnClick()
    {
        await this.ToastObj.ShowAsync();
    }
    private async Task HideOnClick()
    {
        await this.ToastObj.HideAsync("All");
    }
}
```

## Run the application

After successful compilation of the application, run the application.

![Blazor Toast](./images/blazor-toast.png)

## See Also

* [Getting Started with Syncfusion Blazor for client-side in .NET Core CLI](../getting-started/blazor-webassembly-dotnet-cli/)

* [Getting Started with Syncfusion Blazor for server-side in Visual Studio 2019](../getting-started/blazor-server-side-visual-studio-2019/)

* [Getting Started with Syncfusion Blazor for server-side in .NET Core CLI](../getting-started/blazor-server-side-dotnet-cli/)