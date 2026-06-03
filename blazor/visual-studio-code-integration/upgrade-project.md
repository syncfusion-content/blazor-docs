---
layout: post
title: Upgrade a project to the latest version in VS Code | Syncfusion®
description: Learn here about how to upgrade a project to the latest version using the Syncfusion Blazor extension for Visual Studio Code. 
platform: Blazor
control: Common
documentation: ug
---

# Upgrade the Syncfusion Blazor Application to the Latest Version

The [Syncfusion Blazor](https://www.syncfusion.com/blazor-components) extension for Visual Studio Code enables upgrading an existing Syncfusion Blazor application to a newer Essential Studio release by updating NuGet package references and theme links automatically.

## Supported project types

- Blazor Web App (Server, WebAssembly, or Auto rendering)
- Blazor Server App
- Blazor WebAssembly App (standalone or ASP.NET Core hosted)
- Blazor WebAssembly App (Progressive Web Application)

## Steps to migrate the project

1. Open the Syncfusion Blazor project in Visual Studio Code.

2. In Explorer, right-click the project `.csproj` file and choose **Migrate Syncfusion Blazor Application to another version**.

    ![Context menu showing Migrate Syncfusion Blazor Application option](images/migration.webp)

    N> The migration command is available only if the project already references Syncfusion Blazor NuGet packages.

3. In the Command Palette, choose **Select Blazor Version** and pick the desired Syncfusion Blazor release version (versions are retrieved from [nuget.org](https://www.nuget.org)).

    ![Command Palette showing Syncfusion version selection](images/versionselection.webp)

4. The tool updates the Syncfusion Blazor NuGet package references to the selected version.

    ![Project file updated with Syncfusion NuGet package references](images/nugetpackage.webp)

N> If you installed the trial setup or NuGet packages from [nuget.org](https://www.nuget.org), you must register the Syncfusion license key. Refer to the [licensing overview](https://blazor.syncfusion.com/documentation/getting-started/license-key/overview) for details on generating and registering your license key.  

## See also

- [Overview of Blazor Extension for Visual Studio Code](overview.md)
- [Download and Installation](download-and-installation.md)
- [Create Project Template](create-project.md)
- [Code Snippets](code-snippet.md)
- [Convert Project](convert-project.md)
- [Scaffolding](scaffolding.md)