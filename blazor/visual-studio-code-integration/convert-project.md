---
layout: post
title: Convert a project using the Blazor extension | Syncfusion®
description: Learn here about how to convert an existing Blazor application into a Syncfusion Blazor application using the Blazor extension for Visual Studio Code.
platform: Blazor
control: Common
documentation: ug
---

# Convert a Blazor Project to Syncfusion Blazor

The [Syncfusion® Blazor extension](https://marketplace.visualstudio.com/items?itemName=SyncfusionInc.Blazor-VSCode-Extensions) for Visual Studio Code upgrades a Blazor project by adding the required NuGet packages and configuring the selected theme automatically.

## Supported project types

- Blazor Web App (Server or WebAssembly rendering)
- Blazor Server App
- Blazor WebAssembly App (standalone or ASP.NET Core hosted)
- Blazor WebAssembly App (Progressive Web Application)

## Conversion steps

1. Open the Blazor project in Visual Studio Code.

2. In Explorer, right-click the project `.csproj` file and choose **Convert to Syncfusion Blazor App...**.

    ![Context menu showing Convert to Blazor Application option](images/conversion.webp)

3. In the Command Palette, pick **Select Blazor Version** and choose the desired Blazor release (pulled from [nuget.org](https://www.nuget.org)).

    ![Command Palette showing Blazor version selection](images/versionselection.webp)

4. Choose the theme from the theme list. Refer to the [Blazor Themes](https://blazor.syncfusion.com/documentation/appearance/themes) documentation for the full list.

    ![Command Palette showing theme selection options](images/ChooseThemes.webp)

   N> The conversion process will run automatically. This may take a few moments as NuGet packages are downloaded and the project is configured.

After conversion, the project contains the required Blazor NuGet packages and the selected theme stylesheet.

N> If you installed the trial setup or NuGet packages from [nuget.org](https://www.nuget.org), you must register the license key. Refer to the [licensing overview](https://blazor.syncfusion.com/documentation/getting-started/license-key/overview) for details on generating and registering your license key.

## What changes are made during conversion

- NuGet packages: Adds [Syncfusion.Blazor](https://www.nuget.org/packages/Syncfusion.Blazor) (and other required packages depending on project type).

    ![Project file showing NuGet package references](images/nugetpackage.webp)

- Theme: Adds the chosen theme reference to the appropriate file based on application type:

    | Application Type | Theme file location |
    | --- | --- |
    | Blazor Web App (Server or WebAssembly) | `Components/App.razor` |
    | Blazor WebAssembly (standalone) | `wwwroot/index.html` |
    | Blazor WebAssembly (ASP.NET Core hosted) | Client project: `wwwroot/index.html` |
    | Blazor WebAssembly (PWA) | `wwwroot/index.html` |

    ![Example showing where the theme link is added in the project](images/cdnlink.webp)

## See also

- [Overview of Blazor Extension for Visual Studio Code](overview.md)
- [Download and Installation for Visual Studio Code](download-and-installation.md)
- [Create Project Template for Visual Studio Code](create-project.md)
- [Code Snippets for Visual Studio Code](code-snippet.md)
- [Upgrade Project for Visual Studio Code](upgrade-project.md)
- [Scaffolding for Visual Studio Code](scaffolding.md)

