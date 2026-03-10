---
layout: post
title: Upgrade a Syncfusion Blazor project to the latest version | Syncfusion
description: Learn how to upgrade a Blazor application to latest version using Blazor Project Migration wizard in VS 2022, including NuGet package updates and backup option.
platform: Blazor
control: Common
documentation: ug
---

# Upgrade a Project to the latest Syncfusion® Version

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor migration add-in for Visual Studio updates an existing Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor application to a newer Essential Studio<sup style="font-size:70%">&reg;</sup> release by automatically updating NuGet package references and theme links.

## Steps to migrate the project

1. Open the existing Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor application in **Visual Studio 2022** or **Visual Studio 2026**.

    Supported application types:
    - Blazor Web App (Server or WebAssembly rendering)
    - Blazor Server App
    - Blazor WebAssembly App (standalone or ASP.NET Core hosted)
    - Blazor WebAssembly App (Progressive Web Application)

2. Open the Migration Wizard using one of the following options:

    **Option 1:**

    Choose **Extensions -> Syncfusion® -> Essential Studio® for Blazor -> Migrate Project…** from the Visual Studio menu.

    ![Open the Migrate Project wizard from the Extensions menu in Visual Studio](images/MigrationMenu.webp)

    **Option 2:**

    In **Solution Explorer**, right-click the project, select **Syncfusion® Blazor**, then choose **Migrate Syncfusion® Blazor project from another version...**

      ![Open the Migrate Project wizard from the Solution Explorer context menu](images/MigrationAddin.webp)

    N> The Migration option becomes available only after the project references the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor NuGet packages.

3. In the Syncfusion® Project Migration window, select the desired Syncfusion® Blazor version to migrate to.

    ![Syncfusion Blazor Project Migration wizard with version selection](images/Migration.webp)

    N> Versions are loaded from the Syncfusion® Blazor NuGet packages available on [NuGet.org](https://www.nuget.org/) and require an active internet connection.

4. (Optional) Select **Enable a backup before migrating** to create a backup of the original project and choose a backup location.

5. After migration completes, a confirmation message is displayed.

    ![Migration succeeded message after completing the project migration](images/MigrationSuccess.webp)

    If a backup was created, the original project will be saved to the specified backup path.

    ![Backup location for the original project created during conversion](images/Backuplocation.webp)

6. The migration updates the Syncfusion® Blazor NuGet package references in the application's `.csproj` to the selected version.

7. If using trial setup or NuGet packages from `nuGet.org`, register the Syncfusion® license key in the application. Syncfusion® introduced license registration in the 2018 Volume 2 (v16.2.0.41) Essential Studio® release. See the [licensing overview and key generation guide](https://help.syncfusion.com/common/essential-studio/licensing/overview#how-to-generate-syncfusion-license-key) to generate and register Syncfusion® license key. For details about the licensing changes introduced in Essential Studio®, see the [2018 Volume 2 announcement](https://www.syncfusion.com/blogs/post/whats-new-in-2018-volume-2).