---
layout: post
title: Upgrade a project to the latest version | Syncfusion
description: Learn here about how to upgrade a project to the latest version using the Syncfusion Blazor extension for Visual Studio Code. Explore to more details.
platform: Blazor
control: Common
documentation: ug
---

# Upgrading Syncfusion® Blazor application to latest version

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor migration add-in for Visual Studio Code enables upgrading an existing Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor web application from one Essential Studio<sup style="font-size:70%">&reg;</sup> version to another.

N> The Syncfusion Blazor Web Application project migration utility is available from version `v17.4.0.39`.

Use the following steps to migrate an existing Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Web Application.

1. In Visual Studio Code, open an existing Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Web Application or create a new one.

2. In Explorer (Workspace), right-click the project file and select **Migrate Syncfusion® Blazor Application to another version...** from the context menu. Refer to the screenshot below.

    ![Context menu showing Migrate Syncfusion Blazor Application command](images/Migration.PNG)

    N> The Migration option is available only when the application already references Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor packages.

3. From the Command Palette, choose **Select Blazor Version** and pick the required Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor package version published on `nuget.org`.

    ![Palette showing selection of Syncfusion Blazor version](images/VersionSelection.PNG)

4. The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor NuGet package references and theme links are updated to the selected version in the application.

    ![Project file updated with new Syncfusion NuGet package versions](images/NuGetPackage.png)

    ![Theme link updated to the selected version](images/CDNLink.png)

5. If you installed the trial setup or NuGet packages from nuget.org you must register the Syncfusion® license key to your application since Syncfusion® introduced the licensing system from 2018 Volume 2 (v16.2.0.41) Essential Studio® release. Navigate to the [help topic](https://help.syncfusion.com/common/essential-studio/licensing/overview#how-to-generate-syncfusion-license-key) to generate and register the Syncfusion® license key to your application. Refer to this [UG](https://blazor.syncfusion.com/documentation/getting-started/license-key/overview) topic for understanding the licensing details in Essential Studio® for Blazor.