---
layout: post
title: Convert a project using the Blazor extension | Syncfusion
description: Learn here about how to convert an existing Blazor application into a Syncfusion Blazor application using the Blazor extension for Visual Studio Code.
platform: Blazor
control: Common
documentation: ug
---

# Convert a Blazor Project to Syncfusion® Blazor

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor conversion extension for Visual Studio Code converts an existing Blazor application into a Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Web application by automatically adding required NuGet packages and configuring themes.

## Steps to Convert the Application

Use the following steps to convert an existing Blazor application to a Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor application:

1. In Visual Studio Code, open an existing Blazor application or create a new Blazor application.

   Supported application types:
   - Blazor Web App (Server or WebAssembly rendering)
   - Blazor Server App
   - Blazor WebAssembly App (standalone or ASP.NET Core hosted)
   - Blazor WebAssembly App (Progressive Web Application)

2. In the Explorer panel, right-click the project file (`.csproj`) and select **Convert to Syncfusion Blazor App...** from the context menu.

    ![Context menu showing Convert to Syncfusion Blazor Application option](images/conversion.webp)

3. In the Command Palette, select **Select Blazor Version** and choose the desired Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor version from the dropdown list (displays versions available on `nuget.org`).

    ![Command Palette showing Blazor version selection](images/versionselection.webp)

4. After version selection, the Command Palette will display available themes. Select the preferred theme (e.g., Material, Bootstrap, Tailwind, Fluent and HighContrast).

    ![Command Palette showing theme selection options](images/ChooseThemes.webp)

   N> The conversion process will run automatically. This may take a few moments as NuGet packages are downloaded and the project is configured.

5. After conversion completes, the application is configured with the required Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor NuGet packages and the selected theme stylesheet.

6. If the trial setup or NuGet packages from `nuget.org`, register the Syncfusion® license key in the application. Syncfusion® introduced the licensing system in the 2018 Volume 2 (v16.2.0.41) Essential Studio® release. Navigate to the [help topic](https://help.syncfusion.com/common/essential-studio/licensing/overview#how-to-generate-syncfusion-license-key) to generate and register the Syncfusion® license key to the application. Refer to this [UG](https://blazor.syncfusion.com/documentation/getting-started/license-key/overview) topic for understanding the licensing details in Essential Studio® for Blazor.

## NuGet Packages

During conversion, the required NuGet packages are automatically added to the application based on the application type.

| NuGet Packages | Application Types |
|---------|---------|
| `Syncfusion.Blazor` | Blazor Web App (Server or WebAssembly),  <br/> Blazor WebAssembly App (all variants) |

The packages are added to the application's `.csproj` file as shown below:

![Project file showing Syncfusion NuGet package references](images/nugetpackage.webp)

## Theme Configuration

During conversion, the selected Syncfusion<sup style="font-size:70%">&reg;</sup> theme stylesheet is automatically added in the following locations based on the application type.

| Application Type | Theme File Location |
|---|---|
| Blazor Web App (Server or WebAssembly) | `Components/App.razor` |
| Blazor WebAssembly (standalone) | `wwwroot/index.html` |
| Blazor WebAssembly (ASP.NET Core hosted) | **Client project:** `wwwroot/index.html` |
| Blazor WebAssembly (Progressive Web Application) | `wwwroot/index.html` |

![Example showing where the theme link is added in the project](images/cdnlink.webp)
