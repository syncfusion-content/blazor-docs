---
layout: post
title: Create projects using project templates in VS Code | Syncfusion
description: Learn how to create a Syncfusion Blazor application using the Syncfusion Blazor extension for Visual Studio Code.
platform: Blazor
control: Common
documentation: ug
---

# Create a Syncfusion® Blazor application

Syncfusion<sup style="font-size:70%">&reg;</sup> provides the Blazor Template Studio for Visual Studio Code, which scaffolds a Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor application preconfigured with Syncfusion<sup style="font-size:70%">&reg;</sup> NuGet packages, namespaces, themes, and component render code. The Template Studio offers a guided wizard to create an application with Syncfusion<sup style="font-size:70%">&reg;</sup> components.

N> Blazor project templates from version `v17.4.0.39` and later are supported by the Syncfusion Visual Studio Code project template.

Use the following steps to create Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor applications in Visual Studio Code:

1. To create a Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor application in Visual Studio Code, open the Command Palette with **Ctrl+Shift+P**. Search for the word **Syncfusion<sup style="font-size:70%">&reg;</sup>** in the Visual Studio Code palette to get the templates provided by Syncfusion<sup style="font-size:70%">&reg;</sup>.

    ![Command Palette showing Syncfusion commands](images/CreateBlazorProjectPalette.png)

2. Select **Syncfusion Blazor Template Studio: Launch**, and press **Enter**. The Template Studio wizard opens to configure the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor app. Enter the project name and project path.

    ![Template Studio wizard with Project name and Project path fields](images/ProjectLocationName1.png)

    N> For supported .NET SDK versions, see the .NET SDK support for Syncfusion Blazor components in the system requirements [documentation](https://blazor.syncfusion.com/documentation/system-requirements#net-sdk).

3. Select **Next** or the **Project type** tab. The available Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor project types are displayed. Choose one based on the .NET SDK version in use.

    | .NET SDK version | Supported Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Application Type |
    | ---------------- | -------------------------------------------- |
    | [.NET 9.0](https://dotnet.microsoft.com/en-us/download/dotnet/9.0), [.NET 8.0](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) | Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Web App |
    | [.NET 9.0](https://dotnet.microsoft.com/en-us/download/dotnet/9.0), [.NET 8.0](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) | Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor WebAssembly App |
    
    In the **Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Web App** application type, the following options are available:

    <table>
    <tbody>
    <tr>
    <td>
    <a href="https://learn.microsoft.com/en-us/aspnet/core/blazor/components/render-modes?view=aspnetcore-8.0#render-modes">Interactivity type</a>
    </td>
    <td>
    Server, WebAssembly, Auto (Server and WebAssembly)
    </td>
    </tr>
    <tr>
    <td>
    <a href="https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-8.0&pivots=windows">Interactivity location</a>
    </td>
    <td>
    Global, Per page/component
    </td>
    </tr>
    </tbody>
    </table>

    ![Project type selection showing Blazor Web App options](images/WebAppType1.png)

     In the **Syncfusion Blazor WebAssembly App** project type, choose Progressive Web Application (PWA).

     ![Project type selection showing Blazor WebAssembly and PWA option](images/ProjectTypeDetails1.png)

4. Select **Next** or the **Controls** tab, and then choose the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components to include in the application.

     ![Controls tab listing Syncfusion Blazor components](images/ControlsSection.png)

     Choose the required control(s) by selecting the corresponding control tiles.

     To unselect added control(s), use one of the following options:

     **Option 1:** Click the corresponding selected control box.

     **Option 2:** In **Project Details**, click the ‘x’ next to the corresponding control in the selected controls list.

     N> Choose at least one control to enable the Features and Configuration tabs.

5. Select **Next** or the **Features** tab to view the available features for the selected controls, and choose the required options.

    ![FeaturesSection](images/FeaturesSection.png)

6. Select **Next** or the **Configuration** tab to open the Configuration section. Configure the target .NET version (.NET 9.0 or .NET 8.0), theme, HTTPS configuration, localization, authentication type, and options specific to Blazor Web App or Blazor WebAssembly App types.

     Depending on the selected Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor application type, the following authentication options are supported:

     | Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Application Type | Supported Authentication Types |
     | ------------- | ------------- |
     | Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Web App | None, Individual Accounts |
     | Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor WebAssembly App | None, Individual Accounts, Microsoft Identity Platform |

     For the **Blazor Web App** application type, Interactivity type and Interactivity location can be customized.

     ![Configuration panel showing interactivity options for Blazor Web App](images/WebApp.png)

     For the **Blazor WebAssembly App** appllication type, the Progressive Web Application option can be enabled or disabled.

     ![Configuration panel showing PWA option for Blazor WebAssembly](images/WebAssembly.png)

     **Project details section**

     Use the Project Details section to change the application type, remove selected control(s), or update configuration options.

    ![Project Details panel showing selected controls and configuration summary](images/ProjectDetailsRightSide.png)

7. Click **Create**. The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor application is created with the required Syncfusion<sup style="font-size:70%">&reg;</sup> NuGet packages, styles, and the render code for the selected Syncfusion<sup style="font-size:70%">&reg;</sup> components.

    
8. Run the application to view the Syncfusion<sup style="font-size:70%">&reg;</sup> components. Press **F5** or select **Run > Start Debugging**.

     ![Running the generated Syncfusion Blazor project in Visual Studio Code](images/RunProject.png)

9. The Syncfusion® Blazor application configures with most recent Syncfusion® Blazor NuGet packages version, selected style, namespaces, selected authentication, and component render code for Syncfusion® components.

10. If you installed the trial setup or NuGet packages from nuget.org you must register the Syncfusion® license key to your application since Syncfusion® introduced the licensing system from 2018 Volume 2 (v16.2.0.41) Essential Studio® release. Navigate to the [help topic](https://help.syncfusion.com/common/essential-studio/licensing/license-key#how-to-generate-syncfusion-license-key) to generate and register the Syncfusion® license key to your application. Refer to this [UG](https://blazor.syncfusion.com/documentation/getting-started/license-key/overview) topic for understanding the licensing details in Essential Studio® for Blazor.

## Syncfusion<sup style="font-size:70%">&reg;</sup> integration

The Syncfusion® Blazor application configures with latest Syncfusion® Blazor NuGet packages, styles, namespaces, and component render code for Syncfusion® components are added in the created application.

### NuGet packages

The `Syncfusion.Blazor` package is added as a dependency for all project types.

![NuGetPackage](images/NuGetPackage.png)

### Style

The selected theme is added from the Syncfusion<sup style="font-size:70%">&reg;</sup> NuGet package and referenced at the following locations.

| Application type  | File location  |
|---|---|
| Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Web App | ~/Components/App.razor |
| Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor WebAssembly App (ASP.NET Core hosted) <br/> Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor WebAssembly App (Progressive Web Application) | {Client Project location}/wwwroot/index.html  |
| Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor WebAssembly App  | {Project location}/wwwroot/index.html|

![Theme reference location examples](images/CDNLink.png)

### Namespaces

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor namespaces are added in the **`_imports.razor`** file.

![Imports file showing Syncfusion namespaces](images/NameSpace.png)

### Component render code

The Syncfusion Blazor Calendar, Button, and DataGrid component render code is added to the Razor files in the Pages folder.

| File name  | Code snippet added |
|---|---|
| `~/Pages/Home.razor or Index.razor`  | ![Index page updated with Syncfusion components](images/IndexFileChange.png) |
| `~/Pages/Counter.razor` | ![Counter page updated with Syncfusion components](images/CounterPageChange.png) |
| `~/Pages/FetchData.razor`  | ![FetchData page updated with Syncfusion DataGrid](images/FetchDataPageChange.png) |
