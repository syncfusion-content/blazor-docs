---
layout: post
title: Convert a project using the Blazor extension | Syncfusion
description: Learn here about how to convert an existing Blazor application into a Syncfusion Blazor application using the Blazor extension for Visual Studio Code.
platform: Blazor
control: Common
documentation: ug
---

# Convert a Blazor Project to Syncfusion® Blazor

The Syncfusion® Blazor extension for Visual Studio Code upgrades a Blazor project by adding the required Syncfusion® NuGet packages and configuring the selected theme automatically.

## Supported project types

- Blazor Web App (Server or WebAssembly rendering)
- Blazor Server App
- Blazor WebAssembly App (standalone or ASP.NET Core hosted)
- Blazor WebAssembly App (Progressive Web Application)

## Conversion steps

1. Open the Blazor project in Visual Studio Code.

2. In Explorer, right-click the project `.csproj` file and choose **Convert to Syncfusion Blazor App...**.

    ![Context menu showing Convert to Syncfusion Blazor Application option](images/conversion.webp)

3. In the Command Palette, pick **Select Blazor Version** and choose the desired Syncfusion® Blazor release (pulled from `nuget.org`).

    ![Command Palette showing Blazor version selection](images/versionselection.webp)

4. Choose the theme from the theme list (Material, Bootstrap, Tailwind, Fluent, HighContrast, etc.).

    ![Command Palette showing theme selection options](images/ChooseThemes.webp)

   N> The conversion process will run automatically. This may take a few moments as NuGet packages are downloaded and the project is configured.

After conversion, the project contains the required Syncfusion® Blazor NuGet packages and the selected theme stylesheet.

If the trial setup or NuGet packages from `nuget.org`, register the Syncfusion® license key in the application. Syncfusion® introduced the licensing system in the 2018 Volume 2 (v16.2.0.41) Essential Studio® release. Navigate to the [help topic](https://help.syncfusion.com/common/essential-studio/licensing/overview#how-to-generate-syncfusion-license-key) to generate and register the Syncfusion® license key to the application. Refer to this [UG](https://blazor.syncfusion.com/documentation/getting-started/license-key/overview) topic for understanding the licensing details in Essential Studio® for Blazor.

## What changes are made during conversion

- NuGet packages: Adds `Syncfusion.Blazor` (and other required packages depending on project type).

    ![Project file showing Syncfusion NuGet package references](images/nugetpackage.webp)

- Theme: Adds the chosen theme reference to the appropriate file based on application type:

    | Application Type | Theme file location |
    | --- | --- |
    | Blazor Web App (Server or WebAssembly) | Components/App.razor |
    | Blazor WebAssembly (standalone) | wwwroot/index.html |
    | Blazor WebAssembly (ASP.NET Core hosted) | Client project: wwwroot/index.html |
    | Blazor WebAssembly (PWA) | wwwroot/index.html |

    ![Example showing where the theme link is added in the project](images/cdnlink.webp)

