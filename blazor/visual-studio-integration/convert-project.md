---
layout: post
title: Convert a Blazor project to Syncfusion Blazor | Syncfusion
description: Learn how to convert an existing Blazor application to a Blazor application using the Blazor Extension for VS 2022, including NuGet package installation.
platform: Blazor
control: Common
documentation: ug
---

# Convert a Blazor Application to Syncfusion® Blazor

This guide explains how to convert an existing Blazor application into a Syncfusion® Blazor application using the Syncfusion® Project Conversion wizard for Visual Studio. The conversion installs required Syncfusion® NuGet packages and applies your selected theme stylesheet.

N> Ensure the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Template Studio extension is installed in Visual Studio (Extensions → Manage Extensions → Installed). If not installed, follow the steps in the [download and installation](https://blazor.syncfusion.com/documentation/visual-studio-integration/download-and-installation) topic.

Supported project types

- Blazor Web App (Server or WebAssembly rendering)
- Blazor Server App
- Blazor WebAssembly App (standalone or ASP.NET Core hosted)
- Blazor WebAssembly App (Progressive Web Application)

Steps

1. Open your Blazor project in Visual Studio.

2. Launch the Syncfusion® Project Conversion wizard by either:

    - Choosing **Extensions → Syncfusion® → Essential Studio® for Blazor → Convert Project...**

      ![Open Convert Project from the Extensions menu in Visual Studio](images/conversionmenu.webp)

    - Or right-clicking the project in Solution Explorer, selecting **Syncfusion® Blazor**, then **Convert to Syncfusion® Blazor application...**

      ![Open Convert Project from the Solution Explorer context menu](images/conversionaddin.webp)

3. In the Project Conversion window, select the target Syncfusion® Blazor version and the theme to apply.

     ![Syncfusion Blazor Project Conversion wizard with version and theme selection](images/conversion.webp)

     N> Versions are read from the Syncfusion® Blazor NuGet packages on [NuGet.org](https://www.nuget.org/) and require an internet connection.

4. (Optional) Enable **Enable a backup before converting** to save a copy of your original project to a chosen backup location.

5. After conversion finishes, you will see a confirmation message.

    ![Conversion succeeded message after completing the conversion](images/conversionsuccess.webp)

    If a backup was created, the original project is saved to the selected backup path.

    ![Backup location for the original project created during conversion](images/backuplocation.webp)

6. The conversion updates your project with the required Syncfusion® Blazor NuGet packages and adds the selected theme stylesheet.

7. If you installed packages from `nuget.org` or the trial setup, register your Syncfusion® license key. Licensing was introduced in the 2018 Volume 2 (v16.2.0.41) release. See the [licensing overview and key generation guide](https://help.syncfusion.com/common/essential-studio/licensing/overview#how-to-generate-syncfusion-license-key) for details. For background, see the [2018 Volume 2 announcement](https://www.syncfusion.com/blogs/post/whats-new-in-2018-volume-2).