---
layout: post
title: Getting Started with Razor Class Library in Visual Studio 2022 | Syncfusion
description: Check out the documentation for Creating Razor Class Library (RCL) using Syncfusion Blazor components in Visual Studio 2022.
platform: Blazor
component: Common
documentation: ug
---

# Creating Razor Class Library (RCL) using Syncfusion Blazor components

This section provides information about creating Razor Class Library with the Syncfusion Blazor components using [Visual Studio 2022 Preview](https://visualstudio.microsoft.com/vs/preview/).

## Prerequisites

* [Visual Studio 2022 Preview](https://visualstudio.microsoft.com/vs/preview/)
* [.NET 6.0 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)

> **.NET 6.0** requires Visual Studio 2022 Preview 4.1 or later.

## Create a Razor Class Library using Syncfusion Blazor components in Visual Studio 2022

1. Choose **Create a new project** from the Visual Studio dashboard.

    ![new project in aspnetcore blazor](images/new-project-2022.png)

2. Select **Razor Class Library** from the template, and then click the **Next** button.

    ![razor class template](images/razor-project-configuration-2022.png)

3. Now, the project configuration window will popup. Click **Create** button to create a new project with the default project configuration.

    ![razor class project configuration](images/razor-class-template-2022.png)

4. Select the target Framework **.NET 6.0** at the top of the Application based on your required target that you want and then click the **Create** button to create a new Razor Class Library application.

    ![select framework](images/blazor-select-template-rcl-2022.png)

### Importing Syncfusion Blazor component in Razor Class Library

You can use any one of the below standards to install the Syncfusion Blazor library in your Razor Class Library Server application.

#### Using Syncfusion Blazor individual NuGet Packages [New standard]

> Starting with Volume 4, 2020 (v18.4.0.30) release, Syncfusion provides [individual NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages/) for our Syncfusion Blazor components. We highly recommend this new standard for your Blazor production applications. Refer to [this section](https://blazor.syncfusion.com/documentation/nuget-packages/#benefits-of-using-individual-nuget-packages) to know the benefits of the individual NuGet packages.

1. Now, install **Syncfusion.Blazor.Calendars** NuGet package to the newly created RLC by using the `NuGet Package Manager`. For more details about the available NuGet packages, refer to the [Individual NuGet Packages](https://blazor.syncfusion.com/documentation/nuget-packages/) documentation.

2. Right-click the project, and then select Manage NuGet Packages.

    ![nuget explorer](images/nuget-explorer-2022.png)

3. Search **Syncfusion.Blazor.Calendars** keyword in the Browse tab and install **Syncfusion.Blazor.Calendars** NuGet package in RLC.

    ![select nuget](images/individual-nuget-rlc-2022.png)

4. The Syncfusion Blazor Calendars package will be included in the newly created project once the installation process is completed.

5. Now, import and add the Syncfusion Blazor components in the `~/RclComponent.razor` file. For example, the Calendar component is imported and added in the **~/RclComponent.razor** page.

    ```cshtml
    @using Syncfusion.Blazor.Calendars

    <div class="my-component">
    This Blazor component is defined in the <strong>RazorClassLibrary</strong> package.
    </div><br />

    <SfCalendar TValue="DateTime"></SfCalendar>
    ```

#### Using Syncfusion.Blazor NuGet Package [Old standard]

W> If you prefer the above new standard (individual NuGet packages), then skip this section. Using both old and new standards in the same application will throw ambiguous compilation errors.

1. Now, install **Syncfusion.Blazor** NuGet package to the newly created RLC by using the `NuGet Package Manager`. Right-click the project and select Manage NuGet Packages.

    ![nuget explorer](images/nuget-explorer-2022.png)

2. Search **Syncfusion.Blazor** keyword in the Browse tab and install **Syncfusion.Blazor** NuGet package in RLC.

    ![select nuget](images/select-all-nuget-2022.png)

3. The Syncfusion Blazor package will be installed in the project once the installation process is completed.

4. Now, import and add the Syncfusion Blazor components in the `~/RclComponent.razor` file. For example, the Calendar component is imported and added in the **~/RclComponent.razor** page.

    ```cshtml
    @using Syncfusion.Blazor.Calendars

    <div class="my-component">
    This Blazor component is defined in the <strong>RazorClassLibrary</strong> package.
    </div><br />

    <SfCalendar TValue="DateTime"></SfCalendar>
    ```

## Create a Blazor Server project in Visual Studio 2022 with Razor Class Library (RCL)

1. Choose **Create a new project** from the Visual Studio dashboard.

    ![new project in aspnetcore blazor](images/new-project-2022.png)

2. Select **Blazor Server App** from the template, and then click the **Next** button.

    ![blazor template](images/blazor-template-2022.png)

3. Now, the project configuration window will popup. Click **Create** button to create a new project with the default project configuration.

    ![asp.net core project configuration](images/project-configuration-2022.png)

4. Select the target Framework **.NET 6.0** at the top of the Application based on your required target that you want and then click the **Create** button to create a new Blazor Server application.

    ![select framework](images/blazor-select-template-2022.png)

### Configure the Razor Class Library and Blazor Server Application

1. Now, Right-click the solution, and then select Add/Existing Project.

    ![razor class library in blazor app](images/blazor-configure-2022.png)

2. Add the **Razor Class Library** project by selecting the `RazorClassLibrary.csproj` file.

    ![add RCL in blazor app](images/blazor-razor-configure-2022.png)

    > Razor Class Library project is added to the existing Blazor Server Application.

3. Right-click the Blazor App project, and then select Add/Project reference. Now click the checkbox and configure the **Razor Class Library** and **Blazor Server Application**.

    ![reference manager in blazor app](images/reference-manager-2022.png)

    ![select RCL to configure blazor app](images/configure-razor-2022.png)

### Importing Razor Class Library in the Blazor Server Application

1. Open **~/_Imports.razor** file in Blazor Server App and import the `RazorClassLibrary`.

    ```cshtml
    @using RazorClassLibrary
    ```

2. Open the **~/Program.cs** file and register the Syncfusion Blazor Service from RCL.

    ```c#
    using Syncfusion.Blazor;
    builder.Services.AddSyncfusionBlazor();
    ```

3. Add the Syncfusion bootstrap5 theme in the `<head>` element of the **~/Pages/_Layout.cshtml** page in Blazor Server App.

    ```html
    <head>
        ....
        ....
        // Using individual NuGet packages
        <link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />
        
        // (or)
        
        // Using overall NuGet package
        <link href="_content/Syncfusion.Blazor/styles/bootstrap5.css" rel="stylesheet" />
    </head>
    ```

    W> `Syncfusion.Blazor` package should not to be installed along with [individual NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages/). If you are using individual NuGet packages, you have to add the above `Syncfusion.Blazor.Themes` static web assets (styles) reference in the application. Or else, you have to add the above `Syncfusion.Blazor` styles reference for overall NuGet package.

    > Also, we can referred the themes through the CDN version by using below link instead of package theme reference.
    [https://cdn.syncfusion.com/blazor/{{ site.blazorversion }}/styles/bootstrap5.css](https://cdn.syncfusion.com/blazor/{{ site.blazorversion }}/styles/bootstrap5.css).

4. Now, add the created custom component that is imported with Syncfusion Blazor component from Razor Class Library in any web page (razor) in the `~/Pages` folder. For example, the custom component with imported Syncfusion Blazor Calendar component from Razor Class Library is added to the **~/Pages/Index.razor** page as like below.

    ```cshtml
    <RclComponent></RclComponent>
    ```

5. Run the application, The Syncfusion Blazor Calendar component will be rendered in the default web browser.

    ![RCL output](images/rcl-output-2022.png)

## Create a Blazor WebAssembly project in Visual Studio 2022 with Razor Class Library (RCL)

1. Choose **Create a new project** from the Visual Studio dashboard.

    ![new project in aspnetcore blazor](images/new-project-2022.png)

2. Select **Blazor WebAssembly App** from the template, and then click the **Next** button.

    ![blazor template](images/blazor-template-wasm-2022.png)

3. Now, the project configuration window will popup. Click **Create** button to create a new project with the default project configuration.

    ![asp.net core project configuration](images/project-configuration-wasm-2022.png)

4. Select the target Framework **.NET 6.0** at the top of the Application based on your required target that you want and then click the **Create** button to create a new Blazor Server application.

    ![select framework](images/blazor-select-template-wasm-2022.png)

### Configure the Razor Class Library and Blazor WebAssembly Application

1. Now, Right-click the solution, and then select Add/Existing Project.

    ![razor class library in blazor app](images/blazor-configure-2022-rcl.png)

2. Add the **Razor Class Library** project by selecting `RazorClassLibrary.csproj` file.

    ![add RCL in blazor app](images/blazor-razor-configure-2022-rcl.png)

    > Razor Class Library project is added to the existing Blazor WebAssembly Application.

3. Right-click the Blazor App project, and then select Add/Project reference. Now click the checkbox and configure the **Razor Class Library** and **Blazor WebAssembly Application**.

    ![reference manager in blazor app](images/reference-manager-wasm-2022.png)

    ![select RCL to configure blazor app](images/configure-razor-wasm-2022.png)

### Importing Razor Class Library in the Blazor WebAssembly Application

1. Open **~/_Imports.razor** file in Blazor WebAssembly App and import the `RazorClassLibrary`.

    ```cshtml
    @using RazorClassLibrary
    ```

2. Open the **~/Program.cs** file and register the Syncfusion Blazor Service from RCL.

    ```c#
    using Syncfusion.Blazor;
    builder.Services.AddSyncfusionBlazor();
    ```

3. Add the Syncfusion bootstrap5 theme in the `<head>` element of the **~/wwwroot/index.html** page in Blazor WebAssembly App.

    ```html
    <head>
        ....
        ....
        // Using individual NuGet packages
        <link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />
        
        // (or)
        
        // Using overall NuGet package
        <link href="_content/Syncfusion.Blazor/styles/bootstrap5.css" rel="stylesheet" />
    </head>
    ```

    W> `Syncfusion.Blazor` package should not to be installed along with [individual NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages/). If you are using individual NuGet packages, you have to add the above `Syncfusion.Blazor.Themes` static web assets (styles) reference in the application. Or else, you have to add the above `Syncfusion.Blazor` styles reference for overall NuGet package.

    > Also, we can referred the themes through the CDN version by using below link instead of package theme reference.
    [https://cdn.syncfusion.com/blazor/{{ site.blazorversion }}/styles/bootstrap4.css](https://cdn.syncfusion.com/blazor/{{ site.blazorversion }}/styles/bootstrap4.css).

4. Now, add the created custom component that is imported with Syncfusion Blazor component from Razor Class Library in any web page (razor) in the `~/Pages` folder. For example, the custom component with imported Syncfusion Blazor Calendar component from Razor Class Library is added to the **~/Pages/Index.razor** page as like below.

    ```cshtml
    <RclComponent></RclComponent>
    ```

5. Run the application, The Syncfusion Blazor Calendar component will be rendered in the default web browser.

    ![RCL output](images/rcl-output-2022.png)
