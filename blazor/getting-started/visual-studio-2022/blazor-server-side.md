---
layout: post
title: Getting started with Syncfusion Blazor - Blazor Server Side App in Visual Studio 2022
description: Check out the documentation for Getting started with the Syncfusion Blazor using Visual Studio 2022 IDE.
platform: Blazor
component: Common
documentation: ug
---

<!-- markdownlint-disable MD024 -->

# Getting started with Syncfusion Blazor Components in Blazor Server Side App in Visual Studio 2022

This article provides a step-by-step introduction to configure Syncfusion Blazor setup, and also to build and run a simple Blazor Server Side application using [Visual Studio 2022 Preview](https://visualstudio.microsoft.com/vs/preview/).

> Starting with version 17.4.0.39 (2019 Volume 4), you need to include a valid license key (either paid or trial key) within your applications. Please refer to this [help topic](https://help.syncfusion.com/common/essential-studio/licensing/license-key#blazor) for more information.

## Prerequisites

* [Visual Studio 2022 Preview](https://visualstudio.microsoft.com/vs/preview/)
* [.NET 6.0 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)

> **.NET 6.0** requires Visual Studio 2022 Preview 4.1 or later.

## Create a new Blazor Server side project in Visual Studio 2022

1. Choose **Create a new project** from the Visual Studio dashboard.

    ![new project in aspnetcore blazor](images/new-project-2022.png)

2. Select **Blazor Server App** from the template, and then click the **Next** button.

    ![blazor template](images/blazor-template-2022.png)

3. Now, the project configuration window will popup. Click the **Create** button to create a new project with the default project configuration.

    ![asp.net core project configuration](images/project-configuration-2022.png)

4. Select the target Framework **.NET 6.0** at the top of the Application based on your required target that you want and then click the **Create** button to create a new Blazor Server application.

    ![select framework](images/blazor-select-template-2022.png)

## Installing Syncfusion Blazor packages in the application

You can use any one of the below standards to install the Syncfusion Blazor library in your application.

### Using Syncfusion Blazor individual NuGet Packages [New standard]

> Starting with Volume 4, 2020 (v18.4.0.30) release, Syncfusion provides [individual NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages/) for our Syncfusion Blazor components. We highly recommend this new standard for your Blazor production applications. Refer to [this section](https://blazor.syncfusion.com/documentation/nuget-packages/#benefits-of-using-individual-nuget-packages) to know the benefits of the individual NuGet packages.

1. Now, install **Syncfusion.Blazor.Calendars** NuGet package to the new application using the `NuGet Package Manager`. Refer to the [Individual NuGet Packages](https://blazor.syncfusion.com/documentation/nuget-packages/) section for the available NuGet packages.

    ![nuget explorer](images/nuget-explorer-2022.png)

2. Search **Syncfusion.Blazor.Calendars** keyword in the Browse tab and install **Syncfusion.Blazor.Calendars** NuGet package in the application.

    ![select nuget](images/individual-nuget-2022.png)

3. Once the installation process is completed, the Syncfusion Blazor Calendars package will be installed in the project.

4. Add the Syncfusion bootstrap5 theme in the `<head>` element of the **~/Pages/_Layout.cshtml** page in Blazor Server App.

    ```html
    <head>
        ....
        ....
        <link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />
    </head>
    ```

    W> `Syncfusion.Blazor` package should not be installed along with [individual NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages/). Hence, you have to add the above `Syncfusion.Blazor.Themes` static web assets (styles) in the application.

### Using Syncfusion.Blazor NuGet Package [Old standard]

W> If you prefer the above new standard (individual NuGet packages), then skip this section. Using both old and new standards in the same application will throw ambiguous compilation errors.

1. Install **Syncfusion.Blazor** NuGet package to the newly created application by using the `NuGet Package Manager`. Right-click the project and then select Manage NuGet Packages.

    ![nuget explorer](images/nuget-explorer-2022.png)

2. Search **Syncfusion.Blazor** keyword in the Browse tab and install **Syncfusion.Blazor** NuGet package in the application.

    ![select nuget](images/select-nuget-2022.png)

3. Once the installation process is completed, the Syncfusion Blazor package will be installed in the project.

4. Add the Syncfusion bootstrap5 theme in the `<head>` element of the **~/Pages/_Host.html** page in Blazor Server App.

    ```html
    <head>
        ....
        ....
        <link href="_content/Syncfusion.Blazor/styles/bootstrap5.css" rel="stylesheet" />
    </head>
    ```

    > The same theme file can be referred through the CDN version by using [https://cdn.syncfusion.com/blazor/{{ site.blazorversion }}/styles/bootstrap5.css](https://cdn.syncfusion.com/blazor/19.3.43/styles/bootstrap5.css).

## Adding Syncfusion Blazor component and running the application

1. Open **~/_Imports.razor** file and import the `Syncfusion.Blazor` namespace.

    ```cshtml
    @using Syncfusion.Blazor
    @using Syncfusion.Blazor.Calendars
    ```

2. Open the **~/Program.cs** file and register the Syncfusion Blazor Service.

    ```c#
    using Syncfusion.Blazor;
    builder.Services.AddSyncfusionBlazor();
    ```

    > We can disable the dynamic script loading and refer to the scripts from the application end by using the `IgnoreScriptIsolation` parameter in `AddSyncfusionBlazor()` at the `Program.cs`. For more details, please refer here for [how to refer custom/CDN resources](../../common/custom-resource-generator/#how-to-use-custom-resources-in-the-blazor-application).

3. Now, add the Syncfusion Blazor components in any .razor file in the `~/Pages` folder. For example, the Calendar component is added to the **~/Pages/Index.razor** page.

    ```cshtml
    <SfCalendar TValue="DateTime"></SfCalendar>
    ```

4. Run the application. Then, the Syncfusion Blazor Calendar component will be rendered in the default web browser.

    ![output](images/browser-output-2022.png)
