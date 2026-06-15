---
layout: post
title: Upgrade a project to the latest version in VS Code | Syncfusion®
description: Learn here about how to upgrade a project to the latest version using the Syncfusion® Blazor extension for Visual Studio Code. 
platform: Blazor
control: Common
documentation: ug
---

# Upgrade the Blazor Application to the Latest Version

The [Syncfusion® Blazor extension](https://marketplace.visualstudio.com/items?itemName=SyncfusionInc.Blazor-VSCode-Extensions) extension for Visual Studio Code enables upgrading an existing Blazor application to a newer Essential ® release by updating NuGet package references and theme links automatically.

## Supported project types

- Blazor Web App (Server, WebAssembly, or Auto rendering)
- Blazor Server App
- Blazor WebAssembly App (standalone or ASP.NET Core hosted)
- Blazor WebAssembly App (Progressive Web Application)

## Steps to migrate the project

1. Open the Blazor project in Visual Studio Code.

2. In Explorer, right-click the project `.csproj` file and choose **Migrate Syncfusion Blazor Application to another version**.

    ![Context menu showing Migrate Syncfusion Blazor Application option](images/migration.webp)

    N> The migration command is available only if the project already references Blazor NuGet packages.

3. In the Command Palette, choose **Select Blazor Version** and pick the desired Blazor release version (versions are retrieved from [nuget.org](https://www.nuget.org)).

    ![Command Palette showing version selection](images/versionselection.webp)

4. The tool updates the Blazor NuGet package references to the selected version.

    ![Project file updated with NuGet package references](images/nugetpackage.webp)

N> If you installed the trial setup or NuGet packages from [nuget.org](https://www.nuget.org), you must register the license key. Refer to the [licensing overview](https://blazor.syncfusion.com/documentation/getting-started/license-key/overview) for details on generating and registering your license key.  

## See also

- [Overview of Blazor Extension for Visual Studio Code](overview.md)
- [Download and Installation for Visual Studio Code](download-and-installation.md)
- [Create Project Template for Visual Studio Code](create-project.md)
- [Code Snippets for Visual Studio Code](code-snippet.md)
- [Convert Project for Visual Studio Code](convert-project.md)
- [Scaffolding for Visual Studio Code](scaffolding.md)
