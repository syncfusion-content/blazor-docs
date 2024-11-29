---
layout: post
title: Upgrade Project to Latest Version in Blazor | Syncfusion
description: Learn here all about upgrading project to use latest version using Syncfusion Blazor Extension for Visual Studio Code.
platform: Blazor
component: Common
documentation: ug
---

# Upgrading Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor application to latest version

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Migration is an add-in for Visual Studio Code allows you to migrate an existing Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Web Application from one Essential Studio<sup style="font-size:70%">&reg;</sup> version to another.

   N> The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Web Application Project Migration utility is available from `v17.4.0.39`.

The steps below assist you to migrating existing Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Web Application.

1. Open an existing Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Web Application or create a new Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Web Application in Visual Studio Code.

2. Select **Migrate Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Application to another version...** from the context menu when you right-click on the **Project file** from Explorer (Workspace). Refer to the screenshot below.

    ![Migration add-in](images/Migration.PNG)

    N>  If you have a Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor reference in your application, the Migration option will be enabled.

3. **Select Blazor Version** (which published in `nuget.org`) from the palette appears.

    ![Select Blazor Version](images/VersionSelection.PNG)

4. The Syncfusion<sup style="font-size:70%">&reg;</sup> NuGet packages references and themes are updated to the selected version in the application.

    ![NuGetPackage](images/NuGetPackage.png)

    ![CDNLink](images/CDNLink.png)

5. If you installed the trial setup or NuGet packages from nuget.org you must register the Syncfusion<sup style="font-size:70%">&reg;</sup> license key to your application since Syncfusion<sup style="font-size:70%">&reg;</sup> introduced the licensing system from 2018 Volume 2 (v16.2.0.41) Essential Studio<sup style="font-size:70%">&reg;</sup> release. Navigate to the [help topic](https://help.syncfusion.com/common/essential-studio/licensing/overview#how-to-generate-syncfusion-license-key) to generate and register the Syncfusion<sup style="font-size:70%">&reg;</sup> license key to your application. Refer to this [UG](https://blazor.syncfusion.com/documentation/getting-started/license-key/overview) topic for understanding the licensing details in Essential Studio<sup style="font-size:70%">&reg;</sup> for Blazor.