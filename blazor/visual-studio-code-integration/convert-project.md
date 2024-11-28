---
layout: post
title: Convert Project - Blazor Extension for Visual Studio Code | Syncfusion
description: Learn here all about how to convert blazor application into syncfusion blazor application using Blazor Extension for Visual Studio Code.
platform: Blazor
component: Common
documentation: ug
---

# Converting Blazor Extension for Visual Studio Code

The Syncfusion&reg; Blazor conversion is an add-in for Visual Studio Code that converts an existing Blazor application into a Syncfusion&reg; Blazor Web Application by adding the required NuGet packages and themes.

N> The Syncfusion&reg; Blazor Web Application Project Conversion utility is available from `v17.4.0.39`.

The steps below assist you to using the Syncfusion&reg; Project conversion in your existing Blazor Web Application:

1. Open an existing Blazor Web Application or create a new Microsoft Blazor Web Application in Visual Studio Code.

2. Select **Convert to Syncfusion&reg; Blazor Application...** from the context menu when you right-click on the **Project file** from Explorer (Workspace). Refer the screenshot below.

    ![Conversion Add-in](images/Conversion.PNG)

3. **Select Blazor Version** (which published in `nuget.org`) from the palette appears.

    ![Select Blazor Version](images/VersionSelection.PNG)

4. Choose the **Theme** from the palette appears.

    ![Select Themes](images/ChooseThemes.PNG)

5. The application configured with Syncfusion&reg; Blazor required NuGet packages and themes.

6. If you installed the trial setup or NuGet packages from nuget.org you must register the Syncfusion&reg; license key to your application since Syncfusion&reg; introduced the licensing system from 2018 Volume 2 (v16.2.0.41) Essential Studio release. Navigate to the [help topic](https://help.syncfusion.com/common/essential-studio/licensing/overview#how-to-generate-syncfusion-license-key) to generate and register the Syncfusion&reg; license key to your application. Refer to this [UG](https://blazor.syncfusion.com/documentation/getting-started/license-key/overview) topic for understanding the licensing details in Essential Studio for Blazor.

## NuGet Packages

Based on the application type, the following NuGet packages are added as NuGet references.

| Syncfusion&reg; Blazor NuGet packages  | Application type  |
|---|---|
| `Syncfusion.Blazor`  | Syncfusion&reg; Blazor Web App <br/> Syncfusion&reg; Blazor Server App <br/> Syncfusion&reg; Blazor WebAssembly App <br/> Syncfusion&reg; Blazor WebAssembly App (ASPNET Core hosted) <br/> Syncfusion&reg; Blazor WebAssembly App (Progressive Web Application)|
| `Syncfusion.Blazor.PdfViewerServer.Windows`  | Syncfusion&reg; Blazor Server App  |
| `Syncfusion.Blazor.WordProcessor`  | Syncfusion&reg; Blazor Server App <br/> Syncfusion&reg; Blazor WebAssembly App <br/> Syncfusion&reg; Blazor WebAssembly App (ASPNET Core hosted) <br/> Syncfusion&reg; Blazor WebAssembly App (Progressive Web Application)|

The NuGet packages added to the application file as follows.

![NuGetPackage](images/NuGetPackage.png)

## Theme links

While converting the application, the selected Syncfusion&reg; Blazor theme is added in the following location of a Blazor type application.

| Application type  | File location  |
|---|---|
| Syncfusion&reg; Blazor Web App | ~/Components/App.razor |
| Syncfusion&reg; Blazor Server App | {Project location}/Pages//_Host.cshtml |
| Syncfusion&reg; Blazor WebAssembly App (ASPNET Core hosted) <br/> Syncfusion&reg; Blazor WebAssembly App (Progressive Web Application)| {Client Project location}/wwwroot/index.html  |
| Syncfusion&reg; Blazor WebAssembly App  | {Project location}/wwwroot/index.html|

![CDNLink](images/CDNLink.png)