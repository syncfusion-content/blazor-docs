---
layout: post
title: Getting Started with Blazor Toggle Switch Button | Syncfusion
description: Checkout and learn about getting started with Blazor Toggle Switch Button component of Syncfusion, and more details.
platform: Blazor
control: Toggle Switch Button 
documentation: ug
---

<!-- markdownlint-disable MD024 -->

# Getting Started with Blazor Toggle Switch Button Component

This section briefly explains about how to include Toggle Switch Button Component in your Blazor server-side  application. You can refer [Getting Started with Syncfusion Blazor for Server-side in Visual Studio 2019 page](https://blazor.syncfusion.com/documentation/getting-started/blazor-server-side-visual-studio-2019/) page for the introduction and configuring the common specifications.

To get start quickly with Toggle Switch Button Component using Blazor, you can check on this video:

{% youtube
"youtube:https://www.youtube.com/watch?v=u_5050Ws9JM"%}

## Importing Syncfusion Blazor component in the application

1. Install the **Syncfusion.Blazor** NuGet package to the application by using the `NuGet Package Manager`.

2. You can add the client-side style resources through CDN or from NuGet package in the `<head>` element of the `~/Pages/_Host.cshtml` page.

> Please ensure to check the **Include prerelease** option.

```csharp
<head>
        <link href="_content/Syncfusion.Blazor/styles/bootstrap4.css" rel="stylesheet" />
        @*<link href="https://cdn.syncfusion.com/blazor/{:version:}/styles/bootstrap4.css" rel="stylesheet" />*@
</head>
```

For Internet Explorer 11 kindly refer the polyfills. Refer the [documentation](https://blazor.syncfusion.com/documentation/common/how-to/render-blazor-server-app-in-ie/) for more information.

```csharp
<head>
        <link href="_content/Syncfusion.Blazor/styles/bootstrap4.css" rel="stylesheet" />
        <script src="https://github.com/Daddoon/Blazor.Polyfill/releases/download/3.0.1/blazor.polyfill.min.js"></script>
</head>
```

## Adding component package to the application

Open `/_Imports.razor file` and import the **Syncfusion.Blazor.Buttons** package.

```csharp

@using Syncfusion.Blazor.Buttons

```

## Add SyncfusionBlazor service in Startup.cs

Open the **Startup.cs** file and add services required by Syncfusion components.
Add **services.AddSyncfusionBlazor()** method in the ConfigureServices function as follows.

```csharp
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

> To enable custom client side resource loading from CRG or CDN. You need to disable resource loading by **AddSyncfusionBlazor(true)** and load the scripts in the HEAD element of the **~/Pages/_Host.cshtml** page.

```csharp
<head>
    <environment include="Development">
        <script src="https://cdn.syncfusion.com/blazor/{:version:}/syncfusion-blazor.min.js">
        </script>
    </environment>
</head>
```

## Adding Toggle Switch Button component to the application

Now, add the Syncfusion Blazor Toggle Switch Button component in `razor` page in the `Pages` folder. For example the Toggle Switch Button component is added in the `~/Pages/Index.razor` page.

```csharp
<label for="checked" style="padding: 10px 10px 10px 0">USB Tethering</label>
<SfSwitch @bind-Checked="isChecked"></SfSwitch>

@code {
    private bool isChecked = true;
}
```

## Run the application

After successful compilation of your application, simply press F5 to run the application. The Blazor Toggle Switch Button component will render in the web browser as shown below

![Switch Sample](./images/switch.png)

## Set text on Switch

This section explains how to set `OnLabel` and `OffLabel` texts on Switch. In the following example, `onLabel` is set as `ON` and `offLabel` is set as `OFF`.

```csharp
<SfSwitch @bind-Checked="isChecked" OnLabel="On" OffLabel="Off"></SfSwitch>

@code {
    private bool isChecked = true;
}
```

> Switch does not have text support for material themes, and does not support long custom text.

Output be like

![Switch Sample](./images/switch-label.png)

## See Also

* [Getting Started with Syncfusion Blazor for Client-Side in .NET Core CLI](https://blazor.syncfusion.com/documentation/getting-started/blazor-webassembly-dotnet-cli/)
* [Getting Started with Syncfusion Blazor for Server-Side in Visual Studio 2019 Preview](https://blazor.syncfusion.com/documentation/getting-started/blazor-server-side-visual-studio-2019/)
* [Getting Started with Syncfusion Blazor for Server-Side in .NET Core CLI](https://blazor.syncfusion.com/documentation/getting-started/blazor-server-side-dotnet-cli/)