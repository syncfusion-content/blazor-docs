---
layout: post
title: Upgrading Syncfusion Blazor components to a latest version
description: Learn here about the how upgrade Syncfusion Blazor components to a latest version from NuGet manager and migrate.
platform: Blazor
component: Common
documentation: ug
---

# Upgrading Syncfusion&reg; Blazor components to latest version

The Syncfusion&reg; Blazor migration add-in for Visual Studio allows you to migrate an existing Syncfusion&reg; Blazor application from one version of Essential Studio version to another version. This reduces the amount of manual work required when migrating the Syncfusion&reg; version.

The steps below will assist you to upgrade the Syncfusion&reg; version in the Syncfusion&reg; Blazor application via Visual Studio 2019:

N> Before use the Syncfusion&reg; Blazor Project Migration, check whether the Syncfusion&reg; Blazor Template Studio Extension installed or not in Visual Studio Extension Manager by clicking on the Extensions -> Manage Extensions -> Installed. If this extension not installed, install the extension by follow the steps from the [download and installation](https://blazor.syncfusion.com/documentation/visual-studio-integration/download-and-installation) help topic.

1. Open the Syncfusion&reg; Blazor application that uses the Syncfusion&reg; component.

2. Open the Migration Wizard,  by right-click the application from the **Solution Explorer** and select the **Syncfusion&reg; Blazor** and choose the **Migrate Syncfusion&reg; Blazor project from another version...**

    ![MigrationAddin](images/MigrationAddin.png)

3. The Syncfusion&reg; Project Migration window will appear. You can choose the required version of Syncfusion&reg; Blazor to migrate.

    N> The versions are loaded from the Syncfusion&reg; Blazor NuGet packages published in [`NuGet.org`](https://www.nuget.org/packages?q=Tags%3A%22blazor%22syncfusion) and it requires internet connectivity.

    ![MigrationWizard](images/Migration.png)

4. Click **Migrate** button, then the Syncfusion&reg; Blazor NuGet packages will be updated to the respective chosen version in the application.

5. If you installed the trial setup or NuGet packages from nuget.org you must register the Syncfusion&reg; license key to your application since Syncfusion&reg; introduced the licensing system from 2018 Volume 2 (v16.2.0.41) Essential Studio release. Navigate to the [help topic](https://help.syncfusion.com/common/essential-studio/licensing/overview#how-to-generate-syncfusion-license-key) to generate and register the Syncfusion&reg; license key to your application. Refer to this [blog](https://www.syncfusion.com/blogs/post/whats-new-in-2018-volume-2.aspx?_ga=2.11237684.1233358434.1587355730-230058891.1567654773) post for understanding the licensing changes introduced in Essential Studio.