---
layout: post
title: Create Project in Blazor - Syncfusion
description: Learn here about how to create and render the project in Essential Syncfusion Blazor Components.
platform: Blazor
component: Common
documentation: ug
---

# Create project in Blazor 

Syncfusion provides **project templates** for **Visual Studio Code** to create Syncfusion Blazor applications. Syncfusion Blazor creates applications with the required Syncfusion NuGet packages, namespaces, and component render code for the Calendar, Button, and DataGrid components, and the style for making development easier with Syncfusion components.

> The Syncfusion Visual Studio Code project template provides support for Blazor project templates from `v17.4.0.39`.

The following steps helps to create **Syncfusion Blazor Applications** through the **Visual Studio Code:**

1. In Visual Studio Code, open the command palette by pressing **Ctrl+Shift+P** to create a Syncfusion Blazor project. When the Visual Studio Code palette opens, search for the word **Syncfusion** to get the templates provided.

    ![CreateProjectPalette](../images/CreateBlazorProjectPalette.png)

2. Select **Syncfusion Blazor Template Studio: Launch** and then press **Enter**. The Template Studio wizard for configuring the Syncfusion Blazor app will appear. Provide the required Project Name and Path to create the new Syncfusion Blazor application.

    ![TemplateStudioWizard](../images/ProjectLocationName.png)

3. Click either **Next** or the **Project Type** tab. The Syncfusion Blazor Project Types will appear. Choose one of the Syncfusion Blazor project types:
   * Syncfusion Blazor Server App
   * Syncfusion Blazor WebAssembly App

    In the Syncfusion Blazor WebAssembly App project type, choose ASP.NET Core hosted, Progressive Web Application, or both.

    ![ProjectType](../images/ProjectTypeDetails.png)

4. Click either **Next** or the **Configuration** tab, and the Configuration section will be loaded. Choose the required .NET Core version, themes, https configuration, and Blazor Web Assembly project types (ASP.NET Core hosted and Progressive Web Application).

    ![Configuration](../images/Configuration.png)

    > ASP.NET Core hosted and Progressive Web Application options are only visible for the Blazor Web Assembly App project type.

5. The configuration details below could be changed in the Project Details section to change the project name, location, project types, or change the configurations.

    ![ProjectDetails](../images/ProjectDetails.png)

6. Click **Create**. The Syncfusion Blazor application has been created. The created Syncfusion Blazor app is configured with the Syncfusion NuGet packages, styles, and the component render code for the Syncfusion component added to the Index, Counter, and FetchData pages.

7. To show the Syncfusion components, run the application. Click on **F5** or navigate to **Debug>Start Debugging**.

    ![Debug](../images/Debug.png)

8. If the trial setup or NuGet packages are installed from nuget.org, register the Syncfusion license key to the project since Syncfusion introduced the licensing system from 2018 Volume 2 (v16.2.0.41) Essential Studio release. Navigate to the [help topic](https://help.syncfusion.com/common/essential-studio/licensing/license-key#how-to-generate-syncfusion-license-key) to generate and register the Syncfusion license key to the project. Refer to this [blog](https://blog.syncfusion.com/post/Whats-New-in-2018-Volume-2-Licensing-Changes-in-the-1620x-Version-of-Essential-Studio.aspx?_ga=2.11237684.1233358434.1587355730-230058891.1567654773) post for understanding the licensing changes introduced in Essential Studio.

## Syncfusion integration

The latest Syncfusion Blazor NuGet packages, styles, namespaces, and component render code for Syncfusion components are added in the created application.

### NuGet Packages

The `Syncfusion.Blazor` NuGet package will be added as NuGet references for all application types.

![NuGetPackage](../images/NuGetPackage.png)

### Style

The selected theme is added from Syncfusion NuGet and its reference at these applications' locations in Blazor.

| Application type  | File location  |
|---|---|
| Syncfusion Blazor Server App | {Project location}\Pages\\_Host.cshtml |
| Syncfusion Blazor WebAssembly App (ASPNET Core hosted) <br/> Syncfusion Blazor WebAssembly App (Progressive Web Application) | {Client Project location}\wwwroot\index.html  |
| Syncfusion Blazor WebAssembly App  | {Project location}\wwwroot\index.html|

![CDNLink](../images/CDNLink.png)

### Namespaces

The Syncfusion Blazor namespaces are added in the **`_imports.razor`** file.

![NameSpace](../images/NameSpace.png)

### Component render code

The Calendar, Button, and DataGrid component render code is in the Razor files in the pages folder. The render code is updated in these Razor files.

| File name  | Code snippet added |
|---|---|
| `~/Pages/Index.razor`  | ![IndexFileChange](../images/IndexFileChange.png) |
| `~/Pages/Counter.razor` | ![CounterPageChange](../images/CounterPageChange.png) |
| `~/Pages/FetchData.razor`  | ![FetchDataPageChange](../images/FetchDataPageChange.png) |