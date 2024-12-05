---
layout: post
title: Convert Project in Blazor | Syncfusion
description: Learn here about how to convert the blazor application to Syncfusion Blazor application using Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Extension for Visual Studio.
platform: Blazor
component: Common
documentation: ug
---

# Converting Blazor application to Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor application

Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor conversion is a Visual Studio add-in that converts an existing Blazor application to the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor application by adding the required assemblies and theme files.

The steps below help you to convert the **Blazor application** to the **Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor application** via the **Visual Studio 2022**:

N> Before use the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Project Conversion, check whether the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Template Studio Extension installed or not in Visual Studio Extension Manager by clicking on the Extensions -> Manage Extensions -> Installed. If this extension not installed, install the extension by follow the steps from the [download and installation](download-and-installation) help topic.

1. Open your existing Blazor application or create a new Blazor application in Visual Studio 2022.

2. To open the Syncfusion<sup style="font-size:70%">&reg;</sup> Project Conversion Wizard, follow either one of the options below:

    **Option 1:**

    Choose **Extensions -> Syncfusion<sup style="font-size:70%">&reg;</sup> -> Essential Studio for Blazor -> Convert Project...** in the Visual Studio menu.

    ![ConversionMenu](images/ConversionMenu.png)

    **Option 2:**

    Right-click the application from the **Solution Explorer** and select the **Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor** and choose the **Convert to Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor application...**

    ![ConversionAddin](images/ConversionAddin.png)

3. The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Project Conversion window will appear. You can choose the required version of Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor and Themes to convert the application.

    ![ConversionWizard](images/Conversion.png)

    N> The versions are loaded from the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor NuGet packages published in [`NuGet.org`](https://www.nuget.org/packages?q=Tags%3A%22blazor%22syncfusion) and it requires internet connectivity.

4. Check the **“Enable a backup before converting”** checkbox if you want to take the project backup and choose the location.

5. Once the conversion process has been completed, you will get a successful message window.

    ![ConversionSuccessMessage](images/ConversionSuccess.png)

    If you enabled project backup before converting, the old application was saved in the specified backup path location, as shown below once the conversion process completed.

    ![ConversionBackupLocation](images/Backuplocation.png)

6. Selected Blazor application is converted to Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor application by installed Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor NuGet packages with selected version, and added selected style in corresponding layout file.

7. If you installed the trial setup or NuGet packages from nuget.org you must register the Syncfusion<sup style="font-size:70%">&reg;</sup> license key to your application since Syncfusion<sup style="font-size:70%">&reg;</sup> introduced the licensing system from 2018 Volume 2 (v16.2.0.41) Essential Studio<sup style="font-size:70%">&reg;</sup> release. Navigate to the [help topic](https://help.syncfusion.com/common/essential-studio/licensing/overview#how-to-generate-syncfusion-license-key) to generate and register the Syncfusion<sup style="font-size:70%">&reg;</sup> license key to your application. Refer to this [blog](https://www.syncfusion.com/blogs/post/whats-new-in-2018-volume-2) post for understanding the licensing changes introduced in Essential Studio<sup style="font-size:70%">&reg;</sup>.