---
layout: post
title: Getting Started with Syncfusion Blazor MAUI App in Visual Studio 
description: Check out the documentation for getting started with Blazor MAUI App and Syncfusion Blazor Components in Visual Studio and much more.
platform: Blazor
component: Common
documentation: ug
---

# Getting Started with MAUI Blazor Application

This section explains how to create and run the first .NET Multi platform App UI Blazor (.NET MAUI Blazor) app.

## Prerequisites

*  .NET SDK 6.0 (Latest [SDK 6.0.101 or above])

*  The latest preview of Visual Studio 2022 17.1 or above, with [required workload](https://docs.microsoft.com/en-us/dotnet/maui/get-started/installation).

## Get started with Visual Studio 2022 Preview (Latest 17.1 or above) with 'Windows-Machine' mode for Syncfusion Blazor Controls

1. Launch Visual Studio 2022 17.1 (Preview), Choose `Create a new project` from Visual Studio 2022 dashboard.

   ![Create a new project in VS2022](images\maui\create-new-project.png)

2. In the Create a new project window, select MAUI in the project type drop-down, select the `MAUI Blazor App(Preview)` template and click on the `Next` button.

   ![Create MAUI Blazor App](images\maui\create-maui-blazor-server-project.png)

3. In the Configure your new project window, name your project, choose a location for the project and click the `Create` button.

   ![Create new MAUI Blazor App](images\maui\create-new-maui-blazor-app.png)

4. The project structure looks like below

   ![Project Structure](images\maui\maui-project-structure.png)

5. Wait for the project to be created, and its dependencies to be restored.

   ![Restore dependencies](images\maui\maui-restore-dependencies.png)

## Install Syncfusion Blazor Packages in the App

Syncfusion Blazor components are available in [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). In order to use Syncfusion Blazor components in the application, add reference to the corresponding NuGet. Refer to [NuGet packages topic](https://blazor.syncfusion.com/documentation/nuget-packages) for available NuGet packages list with component details. 

To add Blazor Calendar component in the app, open the NuGet package manager in Visual Studio (*Tools → NuGet Package Manager → Manage NuGet Packages for Solution*), search for [Syncfusion.Blazor.Calendars](https://www.nuget.org/packages/Syncfusion.Blazor.Calendars/) and then install it.

1. Open `~/Imports.razor` file and add Syncfusion.Blazor namespace.

```cshtml
    @using Syncfusion.Blazor
```

2. Now, open `MauiProgram.cs` file and register syncfusion blazor services as below.

```cs
    using Syncfusion.Blazor;

    public static class MauiProgram
    {
        public static Maui CreateMauiApp()
        {
            ...
            builder.Services.AddSyncfusionBlazor();
        }
    }
```

3. Now, add the theme stylesheet from NuGet can be referred inside the <head> of `wwwroot/index.html` file in the application.

```html
   <head>
       ....
       <link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />
   </head>
```

4. Now add Syncfusion Blazor component in any razor file. Here, the calendar component is added in `~/Pages/index.razor` page under the `~/Pages` folder.

```cs
    @using Syncfusion.Blazor.Calendars

    <SfCalendar TValue="DateTime"></SfCalendar>
```

5. Before run the sample, make sure the mode is `Windows Machine`.

   ![Windows machine mode](images\maui\windows-machine-mode.png)

**Note:** If you want to run the application in android or iOS, then change the mode in the mode dropdown. Android or iOS modes required emulator installation during initial project setup. Refer the [MSDN guidelines](https://docs.microsoft.com/en-us/dotnet/maui/get-started/first-app) for the setup. 

6. Run the sample, it will display MAUI Blazor app with Syncfusion Blazor Calendar component.

    ![Syncfusion Blazor Calendar component rendering on MAUI Blazor App](images\maui\syncfusion-calendar-output.png)

If you face the below error while running the application, install [this](https://marketplace.visualstudio.com/items?itemName=ProjectReunion.MicrosoftSingleProjectMSIXPackagingToolsDev17).

   ![Maui runtime error](images\maui\runtime-error-maui.png)

Once installed, you may face the below issue.

   ![Maui Deployment error](images\maui\maui-deployment-error.png)

To resolve the above issue, please go to settings, search for developer mode and enable it. [Settings --> Update and Security --> For developers --> enable developer mode].

   ![Enable developer mode in system settings](images\maui\enable-developer-mode.png)
