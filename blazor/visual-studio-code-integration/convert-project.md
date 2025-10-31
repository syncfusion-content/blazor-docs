---
layout: post
title: Convert a project using the Blazor extension | Syncfusion
description: Learn here about how to convert an existing Blazor application into a Syncfusion Blazor application using the Blazor extension for Visual Studio Code.
platform: Blazor
control: Common
documentation: ug
---

# Converting Blazor Extension for Visual Studio Code

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor conversion add-in for Visual Studio Code converts an existing Blazor application into a Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor web application by adding the required NuGet packages and themes.

N> The Syncfusion® Blazor Web Application Project Conversion utility is available from `v17.4.0.39`.

Use the following steps to run the Syncfusion<sup style="font-size:70%">&reg;</sup> project conversion in an existing Blazor Web application:

1. In Visual Studio Code, open an existing Blazor Web application or create a new Blazor Web application.

2. In Explorer (Workspace), right-click the project file and select **Convert to Syncfusion Blazor Application...** from the context menu. Refer the screenshot below.

    ![Context menu showing Convert to Syncfusion Blazor Application command](images/Conversion.PNG)

3. From the Command Palette, choose **Select Blazor Version** (version published on `nuget.org`).

    ![Palette showing selection of Blazor version](images/VersionSelection.PNG)

4. From the palette, choose the desired Syncfusion theme.

    ![Palette showing selection of Syncfusion themes](images/ChooseThemes.PNG)

5. The application is configured with the required Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor NuGet packages and themes.

6. If you installed the trial setup or NuGet packages from nuget.org you must register the Syncfusion® license key to your application since Syncfusion® introduced the licensing system from 2018 Volume 2 (v16.2.0.41) Essential Studio® release. Navigate to the [help topic](https://help.syncfusion.com/common/essential-studio/licensing/overview#how-to-generate-syncfusion-license-key) to generate and register the Syncfusion® license key to your application. Refer to this [UG](https://blazor.syncfusion.com/documentation/getting-started/license-key/overview) topic for understanding the licensing details in Essential Studio® for Blazor.

## NuGet Packages

Based on the application type, the following NuGet packages are added as dependencies.

| Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor NuGet packages  | Application type  |
|---|---|
| `Syncfusion.Blazor`  | Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Web App <br/> Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Server App <br/> Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor WebAssembly App <br/> Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor WebAssembly App (ASPNET Core hosted) <br/> Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor WebAssembly App (Progressive Web Application)|
| `Syncfusion.Blazor.PdfViewerServer.Windows`  | Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Server App  |
| `Syncfusion.Blazor.WordProcessor`  | Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Server App <br/> Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor WebAssembly App <br/> Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor WebAssembly App (ASPNET Core hosted) <br/> Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor WebAssembly App (Progressive Web Application)|

The packages are added to the application as shown below.

![Project file showing Syncfusion NuGet package references](images/NuGetPackage.png)

## Theme links

During conversion, the selected Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor theme is added in the following locations based on the application type.

| Application type  | File location  |
|---|---|
| Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Web App | ~/Components/App.razor |
| Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Server App | {Project location}/Pages/_Host.cshtml |
| Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor WebAssembly App (ASPNET Core hosted) <br/> Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor WebAssembly App (Progressive Web Application)| {Client Project location}/wwwroot/index.html  |
| Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor WebAssembly App  | {Project location}/wwwroot/index.html|

![Example showing where the theme link is added in the project](images/CDNLink.png)
