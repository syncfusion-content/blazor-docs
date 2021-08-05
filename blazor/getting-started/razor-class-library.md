---
layout: post
title: Getting started with Syncfusion Blazor - Razor Class Library in Visual Studio 2019
description: Check out the documentation for Getting started with Syncfusion Blazor
platform: Blazor
component: Common
documentation: ug
---

# Creating Razor Class Library (RCL) using Syncfusion Blazor components

This section provides information about creating Razor Class Library with the Syncfusion Blazor components using [Visual Studio 2019](https://visualstudio.microsoft.com/vs/).

## Prerequisites

* [Visual Studio 2019](https://visualstudio.microsoft.com/vs/)
* [.NET Core SDK 3.1.8](https://dotnet.microsoft.com/download/dotnet-core/3.1) / [.NET 5.0 SDK](https://dotnet.microsoft.com/download/dotnet/5.0)

> **.NET Core SDK 3.1.8** requires Visual Studio 2019 16.7 or later. <br /> **.NET 5.0** requires Visual Studio 2019 16.8 or later.

## Create a Razor Class Library using Syncfusion Blazor components in Visual Studio 2019

1. Choose **Create a new project** from the Visual Studio dashboard.

    ![new project in aspnetcore blazor](images/new-project.png)

2. Select **Razor Class Library** from the template, and then click the **Next** button.

    ![razor class template](images/razor-project-configuration.png)

3. Now, the project configuration window will popup. Click **Create** button to create a new project with the default project configuration.

    ![razor class project configuration](images/razor-class-template.png)

4. Choose **Razor Class Library** from the dashboard and click **Create** button to create a new Razor Class Library Server application. Select the target framework **.NET Core 3.1**  or **.NET5.0** at the top based on your required target.

    ![select framework](images/razor-class-server-template.png)

    > If exist netstandard version is 2.0 in `RazorClassLibrary.csproj`, then change it to **netstandard2.1**

    ```xml
    <PropertyGroup>
        <TargetFramework>netstandard2.1</TargetFramework>
        ....
    </PropertyGroup>
    ```

### Importing Syncfusion Blazor component in Razor Class Library

You can use any one of the below standards to install the Syncfusion Blazor library in your Razor Class Library Server application.

#### Using Syncfusion Blazor individual NuGet Packages [New standard]

> Starting with Volume 4, 2020 (v18.4.0.30) release, Syncfusion provides [individual NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages/) for our Syncfusion Blazor components. We highly recommend this new standard for your Blazor production applications. Refer to [this section](https://blazor.syncfusion.com/documentation/nuget-packages/#benefits-of-using-individual-nuget-packages) to know the benefits of the individual NuGet packages.

1. Now, install **Syncfusion.Blazor.Calendars** NuGet package to the newly created RLC by using the `NuGet Package Manager`. For more details about the available NuGet packages, refer to the [Individual NuGet Packages](https://blazor.syncfusion.com/documentation/nuget-packages/) documentation.

2. Right-click the project, and then select Manage NuGet Packages.

    ![nuget explorer](images/rcl-nuget-explorer.png)

3. Search **Syncfusion.Blazor.Calendars** keyword in the Browse tab and install **Syncfusion.Blazor.Calendars** NuGet package in RLC.

    ![select nuget](images/individual-nuget.png)

4. The Syncfusion Blazor Calendars package will be included in the newly created project once the installation process is completed.

5. Now, import and add the Syncfusion Blazor components in the `~/Component.razor` file. For example, the Calendar component is imported and added in the **~/Component.razor** page.

    ```cshtml

    <div class="my-component">
    This Blazor component is defined in the <strong>RazorClassLibrary</strong> package.
    </div><br />

    <SfCalendar TValue="DateTime"></SfCalendar>
    ```

#### Using Syncfusion.Blazor NuGet Package [Old standard]

W> If you prefer the above new standard (individual NuGet packages), then skip this section. Using both old and new standards in the same application will throw ambiguous compilation errors.

1. Now, install **Syncfusion.Blazor** NuGet package to the newly created RLC by using the `NuGet Package Manager`. Right-click the project and select Manage NuGet Packages.

    ![nuget explorer](images/rcl-nuget-explorer.png)

2. Search **Syncfusion.Blazor** keyword in the Browse tab and install **Syncfusion.Blazor** NuGet package in RLC.

    ![select nuget](images/select-nuget.png)

3. The Syncfusion Blazor package will be installed in the project once the installation process is completed.

4. Open **~/_Imports.razor** file in RLC and import the `Syncfusion.Blazor`.

    ```cshtml
    @using Syncfusion.Blazor
    ```

5. Now, import and add the Syncfusion Blazor components in the `~/Component.razor` file. For example, the Calendar component is imported and added in the **~/Component.razor** page.

    ```cshtml
    @using Syncfusion.Blazor.Calendars

    <div class="my-component">
    This Blazor component is defined in the <strong>RazorClassLibrary</strong> package.
    </div><br />

    <SfCalendar TValue="DateTime"></SfCalendar>
    ```

## Create a Blazor Server project in Visual Studio 2019 with Razor Class Library (RCL)

1. Choose **Create a new project** from the Visual Studio dashboard.

    ![new project in aspnetcore blazor](images/new-project.png)

2. Select **Blazor App** from the template, and then click the **Next** button.

    ![blazor template](images/blazor-template.png)

3. Now, the project configuration window will popup. Click **Create** button to create a new project with the default project configuration.

    ![asp.net core project configuration](images/blazorapp-template.png)

4. Select the target Framework **ASP.NET Core 3.1** or **.NET 5.0** at the top of the Application based on your required target information.

    ![select framework](images/blazor-select-template.png)

5. Choose **Blazor Server App** from the dashboard, and then click **Create** button to create a new Blazor Server application.

    ![select framework](images/blazor-server-template.png)

    > ASP.NET Core 3.1 is available in Visual Studio 2019 version.

### Configure the Razor Class Library and Blazor Server Application

1. Now, Right-click the solution, and then select Add/Existing Project.

    ![razor class library in blazor app](images/blazor-configure.png)

2. Add the **Razor Class Library** project by selecting the `RazorClassLibrary.csproj` file.

    ![add RCL in blazor app](images/blazor-razor-configure.png)

    > Razor Class Library project is added to the existing Blazor Server Application.

3. Right-click the Blazor App project, and then select Add/Project reference. Now click the checkbox and configure the **Razor Class Library** and **Blazor Server Application**.

    ![reference manager in blazor app](images/reference-manager.png)

    ![select RCL to configure blazor app](images/configure-razor.png)

### Importing Razor Class Library in the Blazor Server Application

1. Open **~/_Imports.razor** file in Blazor App and import the `RazorClassLibrary`.

    ```cshtml
    @using RazorClassLibrary
    ```

2. Open the **~/Startup.cs** file and register the Syncfusion Blazor Service from RCL.

    ```c#
    ....
    using Syncfusion.Blazor;
    namespace BlazorApp
    {
        public class Startup
        {
        ....
        ....
        public void ConfigureServices(IServiceCollection services)
        {
            ....
            ....
            services.AddSyncfusionBlazor();
        }
        ....
        }
    }
    ```

3. Add the Syncfusion bootstrap4 theme in the `<head>` element of the **~/Pages/_Host.html** page in Blazor App.

    ```html
    <head>
        ....
        ....
        // Using individual NuGet packages
        <link href="_content/Syncfusion.Blazor.Themes/bootstrap4.css" rel="stylesheet" />
        
        // (or)
        
        // Using overall NuGet package
        <link href="_content/Syncfusion.Blazor/styles/bootstrap4.css" rel="stylesheet" />
    </head>
    ```

    W> `Syncfusion.Blazor` package should not to be installed along with [individual NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages/). If you are using individual NuGet packages, you have to add the above `Syncfusion.Blazor.Themes` static web assets (styles) reference in the application. Or else, you have to add the above `Syncfusion.Blazor` styles reference for overall NuGet package.

    > Also, we can referred the themes through the CDN version by using below link instead of package theme reference. 
    [https://cdn.syncfusion.com/blazor/{:version:}/styles/bootstrap4.css](https://cdn.syncfusion.com/blazor/{:version:}/styles/bootstrap4.css).

4. Now, add the created custom component that is imported with Syncfusion Blazor component from Razor Class Library in any web page (razor) in the `~/Pages` folder. For example, the custom component with imported Syncfusion Blazor Calendar component from Razor Class Library is added to the **~/Pages/Index.razor** page as like below.

    ```cshtml
    <Component></Component>
    ```

5. Run the application, The Syncfusion Blazor Calendar component will be rendered in the default web browser.

    ![RCL output](images/rcl-output.png)

## Create a Blazor WebAssembly project in Visual Studio 2019 with Razor Class Library (RCL)

1. Choose **Create a new project** from the Visual Studio dashboard.

    ![new project in aspnetcore blazor](images/new-project.png)

2. Select **Blazor App** from the template, and then click the **Next** button.

    ![blazor template](images/blazor-template.png)

3. Now, the project configuration window will popup. Click **Create** button to create a new project with the default project configuration.

    ![asp.net core project configuration](images/blazorapp-template.png)

4. Select the target Framework **ASP.NET Core 3.1** or **.NET 5.0** at the top of the Application based on your required target information.

    ![select framework](images/blazor-select-template.png)

5. Choose **Blazor WebAssembly App** from the dashboard, and then click **Create** button to create a new Blazor WebAssembly application.

    ![select framework](images/webassembly-template.png)

    > ASP.NET Core 3.1 is available in Visual Studio 2019 version.

### Configure the Razor Class Library and Blazor WebAssembly Application

1. Now, Right-click the solution, and then select Add/Existing Project.

    ![razor class library in blazor app](images/blazor-configure.png)

2. Add the **Razor Class Library** project by selecting `RazorClassLibrary.csproj` file.

    ![add RCL in blazor app](images/blazor-razor-configure.png)

    > Razor Class Library project is added to the existing Blazor WebAssembly Application.

3. Right-click the Blazor App project, and then select Add/Project reference. Now click the checkbox and configure the **Razor Class Library** and **Blazor WebAssembly Application**.

    ![reference manager in blazor app](images/reference-manager.png)

    ![select RCL to configure blazor app](images/configure-razor.png)

### Importing Razor Class Library in the Blazor WebAssembly Application

1. Open **~/_Imports.razor** file in Blazor WebAssembly App and import the `RazorClassLibrary`.

    ```cshtml
    @using RazorClassLibrary
    ```

2. Open the **~/Program.cs** file and register the Syncfusion Blazor Service from RCL.

    ```c#
    using Syncfusion.Blazor;

    namespace BlazorApp
    {
        public class Program
        {
            public static async Task Main(string[] args)
            {
                ....
                ....
                builder.Services.AddSyncfusionBlazor();
                await builder.Build.RunAsync();
            }
        }
    }
    ```

3. Add the Syncfusion bootstrap4 theme in the `<head>` element of the **~/wwwroot/index.html** page.

    ```html
    <head>
        ....
        ....
        // Using individual NuGet packages
        <link href="_content/Syncfusion.Blazor.Themes/bootstrap4.css" rel="stylesheet" />
        
        // (or)
        
        // Using overall NuGet package
        <link href="_content/Syncfusion.Blazor/styles/bootstrap4.css" rel="stylesheet" />
    </head>
    ```

    W> `Syncfusion.Blazor` package should not to be installed along with [individual NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages/). If you are using individual NuGet packages, you have to add the above `Syncfusion.Blazor.Themes` static web assets (styles) reference in the application. Or else, you have to add the above `Syncfusion.Blazor` styles reference for overall NuGet package.

    > Also, we can referred the themes through the CDN version by using below link instead of package theme reference. 
    [https://cdn.syncfusion.com/blazor/{:version:}/styles/bootstrap4.css](https://cdn.syncfusion.com/blazor/{:version:}/styles/bootstrap4.css).

4. Now, add the created custom component that is imported with Syncfusion Blazor component from Razor Class Library in any web page (razor) in the `~/Pages` folder. For example, the custom component with imported Syncfusion Blazor Calendar component from Razor Class Library is added to the **~/Pages/Index.razor** page as like below.

    ```cshtml
    <Component></Component>
    ```

5. Run the application, The Syncfusion Blazor Calendar component will be rendered in the default web browser.

    ![RCL output](images/rcl-output.png)
