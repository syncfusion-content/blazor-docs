---
layout: post
title: Upgrade a project to the latest version | Syncfusion
description: Learn here about how to upgrade a project to the latest version using the Syncfusion Blazor extension for Visual Studio Code. Explore to more details.
platform: Blazor
control: Common
documentation: ug
---

# Upgrade the latest Syncfusion® Version

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor extension for Visual Studio Code enables upgrading an existing Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor application to a newer Essential Studio<sup style="font-size:70%">&reg;</sup> release by updating NuGet package references and theme links automatically.

## Supported project types

- Blazor Web App (Server or WebAssembly rendering)
- Blazor Server App
- Blazor WebAssembly App (standalone or ASP.NET Core hosted)
- Blazor WebAssembly App (Progressive Web Application)

## Steps to migrate the project

1. Open the Syncfusion® Blazor project in Visual Studio Code.

2. In Explorer, right-click the project `.csproj` file and choose **Migrate Syncfusion® Blazor Application to another version**.

    ![Context menu showing Migrate Syncfusion Blazor Application option](images/migration.webp)

    N> The migration command is available only if the project already references Syncfusion® Blazor NuGet packages.

3. In the Command Palette, choose **Select Blazor Version** and pick the desired Syncfusion® Blazor release version (versions are retrieved from `nuget.org`).

    ![Command Palette showing Syncfusion version selection](images/versionselection.webp)

4. The tool updates the Syncfusion® Blazor NuGet package references to the selected version.

    ![Project file updated with Syncfusion NuGet package references](images/nugetpackage.webp)

5. If the trial setup or NuGet packages from `nuget.org`, register the Syncfusion® license key in the application. Syncfusion® introduced the licensing system in the 2018 Volume 2 (v16.2.0.41) Essential Studio® release. Navigate to the [help topic](https://help.syncfusion.com/common/essential-studio/licensing/overview#how-to-generate-syncfusion-license-key) to generate and register the Syncfusion® license key to the application. Refer to this [UG](https://blazor.syncfusion.com/documentation/getting-started/license-key/overview) topic for understanding the licensing details in Essential Studio® for Blazor.