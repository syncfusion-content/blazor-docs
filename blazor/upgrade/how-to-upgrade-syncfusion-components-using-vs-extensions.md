---
layout: post
title: Upgrade Syncfusion Blazor components to the latest version
description: Learn how to upgrade Syncfusion Blazor components to the latest version with the Syncfusion Blazor migration add-in for Visual Studio, including version selection and licensing notes.
platform: Blazor
control: Common
documentation: ug
---

# Upgrade Syncfusion® Blazor components to the latest version

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor migration add-in for Visual Studio updates an existing Syncfusion Blazor application from one Essential Studio<sup style="font-size:70%">&reg;</sup> version to another. This reduces the amount of manual work required when migrating the Syncfusion<sup style="font-size:70%">&reg;</sup> version.

Use the following steps to upgrade the Syncfusion<sup style="font-size:70%">&reg;</sup> version in a Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor application using Visual Studio 2022:

N> Before use the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Project Migration, check whether the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Template Studio Extension installed or not in Visual Studio Extension Manager by clicking on the Extensions -> Manage Extensions -> Installed. If this extension not installed, install the extension by follow the steps from the [download and installation](https://blazor.syncfusion.com/documentation/visual-studio-integration/download-and-installation) help topic.

1. Open the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor application that uses Syncfusion<sup style="font-size:70%">&reg;</sup> components.

2. In Solution Explorer, right-click the project, choose **Syncfusion Blazor**, and then select **Migrate Syncfusion Blazor project from another version...** to open the Migration Wizard.

    ![Open the Syncfusion Blazor Migration Wizard from Solution Explorer](images/MigrationAddin.png)

3. In the Syncfusion<sup style="font-size:70%">&reg;</sup> Project Migration window, select the required Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor version to migrate to.

    N> Versions are loaded from Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor NuGet packages on [NuGet.org](https://www.nuget.org/packages?q=Tags%3A%22blazor%22syncfusion) and require internet connectivity.

    ![Select the target Syncfusion Blazor version in the Migration Wizard](images/Migration.png)

4. Select **Migrate**. The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor NuGet packages are updated to the chosen version in the project.

5. If you installed the trial setup or NuGet packages from nuget.org you must register the Syncfusion<sup style="font-size:70%">&reg;</sup> license key to your application since Syncfusion<sup style="font-size:70%">&reg;</sup> introduced the licensing system from 2018 Volume 2 (v16.2.0.41) Essential Studio<sup style="font-size:70%">&reg;</sup> release. Navigate to the [help topic](https://help.syncfusion.com/common/essential-studio/licensing/overview#how-to-generate-syncfusion-license-key) to generate and register the Syncfusion<sup style="font-size:70%">&reg;</sup> license key to your application. Refer to this [blog](https://www.syncfusion.com/blogs/post/whats-new-in-2018-volume-2.aspx?_ga=2.11237684.1233358434.1587355730-230058891.1567654773) post for understanding the licensing changes introduced in Essential Studio<sup style="font-size:70%">&reg;</sup>.