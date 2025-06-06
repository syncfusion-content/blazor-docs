---
layout: post
title: Create Projects using Project Templates via Extensions | Syncfusion
description: Learn here about how to create syncfusion blazor application using Syncfusion Blazor Extension for Visual Studio Code.
platform: Blazor
component: Common
documentation: ug
---

# Creating a Syncfusion® Blazor application

Syncfusion® provides Visual Studio Code project templates for creating Syncfusion® Blazor applications. These templates generate an application that includes the necessary Syncfusion® NuGet packages, namespaces, and component render code for the Calendar, Button, and DataGrid components, along with the styles to make Syncfusion® component development easier.

N> Blazor project templates from `v17.4.0.39` are supported by the Syncfusion® Visual Studio Code project template.

The instructions below assist you in creating **Syncfusion Blazor Applications** using **Visual Studio Code**:

1. To create a Syncfusion® Blazor application in Visual Studio Code, open the command palette by pressing **Ctrl+Shift+P**. Search for the word **Syncfusion** in the Visual Studio Code palette to get the templates provided by Syncfusion®.

    ![CreateProjectPalette](images/CreateBlazorProjectPalette.png)

2. Select **Syncfusion Blazor Template Studio: Launch**, then press **Enter** key. The Template Studio wizard for configuring the Syncfusion® Blazor app will be launched. Provide the Project Name and Project Path.

    ![TemplateStudioWizard](images/ProjectLocationName.png)

N> Refer to the .NET SDK support for Syncfusion® Blazor Components [here](https://blazor.syncfusion.com/documentation/system-requirements#net-sdk).

3. Select either **Next** or the **Project Type** tab. Syncfusion® Blazor project types will be displayed. Choose one of the following Syncfusion® Blazor project types based on the version of the .NET SDK you are using.

    | .NET SDK version | Supported Syncfusion Blazor Application Type |
    | ---------------- | -------------------------------------------- |
    | [.NET 9.0](https://dotnet.microsoft.com/en-us/download/dotnet/9.0), [.NET 8.0](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) | Syncfusion Blazor Web App |
    | [.NET 9.0](https://dotnet.microsoft.com/en-us/download/dotnet/9.0), [.NET 8.0](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) | Syncfusion Blazor WebAssembly App |
    
    In the **Syncfusion Blazor Web App** application type, you can configure the following options:

    <table>
    <tbody>
    <tr>
    <td>
    <a href="https://learn.microsoft.com/en-us/aspnet/core/blazor/components/render-modes?view=aspnetcore-8.0#render-modes" rel="nofollow">Interactivity type</a>
    </td>
    <td>
    Server, WebAssembly, Auto (Server and WebAssembly)
    </td>
    </tr>
    <tr>
    <td>
    <a href="https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-8.0&pivots=windows" rel="nofollow">Interactivity location</a>
    </td>
    <td>
    Global, Per page/component
    </td>
    </tr>
    </tbody>
    </table>

    ![WebAppTemplate](images/WebAppType.png)

     In the **Syncfusion Blazor WebAssembly App** application type, you can choose Progressive Web Application.

     ![ProjectType](images/ProjectTypeDetails.png)

4. The Configuration section will be displayed when you click either **Next** or the **Configuration** tab. Here, you have the option for selecting the required .NET Core version, themes, https configuration, and Blazor Web Assembly project types (Progressive Web Application).

    ![Configuration](images/Configuration.png)

    N> Progressive Web Application options are only visible if Blazor Web Assembly App project type is selected.

5. Click the **Create** button. The Syncfusion® Blazor application has been created. The created Syncfusion® Blazor app has the Syncfusion® NuGet packages, styles, and the component render code for the Syncfusion® component added to the Index, Counter, and FetchData pages.

6. You can run the application to see the Syncfusion® components. Click **F5** or go to **Run>Start Debugging**.

    ![Debug](images/Debug.png)

7. If you installed the trial setup or NuGet packages from nuget.org you must register the Syncfusion® license key to your application since Syncfusion® introduced the licensing system from 2018 Volume 2 (v16.2.0.41) Essential Studio® release. Navigate to the [help topic](https://help.syncfusion.com/common/essential-studio/licensing/license-key#how-to-generate-syncfusion-license-key) to generate and register the Syncfusion® license key to your application. Refer to this [UG](https://blazor.syncfusion.com/documentation/getting-started/license-key/overview) topic for understanding the licensing details in Essential Studio® for Blazor.

## Syncfusion® integration

The Syncfusion® Blazor application configures with latest Syncfusion® Blazor NuGet packages, styles, namespaces, and component render code for Syncfusion® components are added in the created application.

### NuGet Packages

The `Syncfusion.Blazor` NuGet package will be added as NuGet references for all application types.

![NuGetPackage](images/NuGetPackage.png)

### Style

The selected theme is added from Syncfusion® NuGet and its reference at these applications locations in Blazor.

| Application type  | File location  |
|---|---|
| Syncfusion Blazor Web App | ~/Components/App.razor |
| Syncfusion Blazor WebAssembly App (ASPNET Core hosted) <br/> Syncfusion Blazor WebAssembly App (Progressive Web Application) | {Client Project location}/wwwroot/index.html  |
| Syncfusion Blazor WebAssembly App  | {Project location}/wwwroot/index.html|

![CDNLink](images/CDNLink.png)

### Namespaces

The Syncfusion® Blazor namespaces are added in the **`_imports.razor`** file.

![NameSpace](images/NameSpace.png)

### Component render code

The Syncfusion® Blazor Calendar, Button, and DataGrid component render code is in the Razor files in the pages folder. The render code is updated in these Razor files.

| File name  | Code snippet added |
|---|---|
| `~/Pages/Home.razor or Index.razor`  | ![IndexFileChange](images/IndexFileChange.png) |
| `~/Pages/Counter.razor` | ![CounterPageChange](images/CounterPageChange.png) |
| `~/Pages/FetchData.razor`  | ![FetchDataPageChange](images/FetchDataPageChange.png) |