---
layout: post
title: Port a Blazor Web App to a .NET MAUI Blazor Hybrid App | Syncfusion
description: Learn here about how to migrate a Blazor Web App to a .NET MAUI Blazor Hybrid app using a Razor Class Library (RCL) to reuse pages, assets, and services.
platform: Blazor
control: Common
documentation: ug
---

# How to port Syncfusion® Blazor Web App to .NET MAUI Blazor Hybrid App

This guide explains how to migrate a Blazor Web App to a .NET MAUI Blazor Hybrid App by using a Razor Class Library (RCL) to share pages, layouts, assets, and services. This approach avoids rewriting Blazor Web App pages for the .NET MAUI Blazor Hybrid app.

## Prerequisites

Install the [.NET SDK 8.0](https://dotnet.microsoft.com/en-us/download) or later and Visual Studio 2022 with the .NET MAUI and ASP.NET and web development workloads.

## Create a Blazor Web App

Create a new [Blazor Web App](https://blazor.syncfusion.com/documentation/getting-started/blazor-web-app) that uses the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Calendar component in [Visual Studio](https://visualstudio.microsoft.com/vs/).

### 1. Create a .NET MAUI Blazor Hybrid App in Visual Studio

Open Visual Studio and create a new project using the [.NET MAUI Blazor Hybrid App](https://blazor.syncfusion.com/documentation/getting-started/maui-blazor-app) template. Specify a project name and create the project.

### 2. Create a Razor Class Library (RCL)

In the solution, add a new project using the [Razor Class Library](https://blazor.syncfusion.com/documentation/getting-started/razor-class-library) template in Visual Studio. Ensure it targets .NET 8.0 to match both the Blazor Web App and the .NET MAUI Blazor Hybrid App.

### 3. Migrate static assets, references, NuGet packages, and Razor pages

- Move all static assets (such as CSS, JavaScript, and images) from the Blazor Web App’s `wwwroot` folder to the Razor Class Library’s `wwwroot` directory. Then, update asset references in the .NET MAUI Blazor Hybrid App to use the RCL assets via the `_content/RazorClassLibrary/` path.
- Move Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor NuGet package references from the Blazor Web App `.csproj` to the RCL `.csproj`.
- Move `Components/Pages` and `Components/Layouts` to the Razor Class Library. Add the necessary namespaces in the RCL’s `_Imports.razor` file.

![Folders to move into the RCL](images/server-folders.png)

### 4. Add project references and register services

Add the Razor Class Library as a project reference in both the Blazor Web App and the .NET MAUI Blazor Hybrid App. Resolve any missing references or errors. After verifying the reference, remove folders such as `Components/Pages` and `Components/Layouts` from the .NET MAUI Blazor App to avoid duplication and keep the project structure clean.

Register the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor service in the `MauiProgram.cs` file of the .NET MAUI Blazor App.

    {% tabs %}
    {% highlight C# tabtitle="~/MauiProgram.cs" hl_lines="1 3" %}

        using Syncfusion.Blazor;
        ....
        builder.Services.AddSyncfusionBlazor();
        ....

    {% endhighlight %}
    {% endtabs %}

Finally, update the `_Imports.razor` file to include the necessary namespaces from the Razor Class Library. Then, modify the `Routes.razor` file in the Blazor MAUI Hybrid app to set the DefaultLayout and AppAssembly to use the `MainLayout` component from the Razor Class Library

### 5. Run the project

In the Visual Studio toolbar, select the target (for example, **Windows Machine**) to build and run the app.

![Build and run the .NET MAUI Blazor Hybrid App](images/windows-machine-mode.png)