---
layout: post
title: Install Syncfusion Blazor NuGet packages | Syncfusion
description: Learn here about how to install Syncfusion Blazor NuGet packages using the Package Manager UI, .NET CLI, and Package Manager Console. Explore to more details.
platform: Blazor
control: Common
documentation: ug
---

# Install Syncfusion® Blazor NuGet packages

## Overview

**NuGet** is a Package management system for Visual Studio. It makes it easy to add, update and remove external libraries in our application. Syncfusion<sup style="font-size:70%">&reg;</sup> publishing all Blazor NuGet packages in [nuget.org](https://www.nuget.org/packages?q=Tag%3A%22Blazor%22+Syncfusion). The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor NuGet packages can be used without installing the Syncfusion<sup style="font-size:70%">&reg;</sup> installation. You can simply exploit the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor NuGet packages in your Blazor application to develop with the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components.

N> The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor NuGet package, which contains all Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components in a single package, is available beginning with v17.4.0.39 (Essential Studio<sup style="font-size:70%">&reg;</sup> 2019 Volume 4).
<br/> The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor UI components are available separately as [Individual NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) beginning with v18.4.0.30 (Essential Studio<sup style="font-size:70%">&reg;</sup> 2020 Volume 4). The NuGet packages are segregated based on the component usage and its namespace.

## Installation using Package Manager UI

The NuGet **Package Manager UI** allows you to search, install, uninstall, and update Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor NuGet packages in your applications and solutions.

Follow the steps below to locate and install the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor NuGet packages into a Blazor application:

1. Right-click on the Blazor application or solution in Solution Explorer and select **Manage NuGet Packages...** from the context menu.

    ![Open Manage NuGet Packages from Solution Explorer](images/managenuget.webp)

    Alternatively, open the NuGet package manager in Visual Studio, select **Tools → NuGet Package Manager → Manage NuGet Packages for Solution...**.

2. In the **Manage NuGet Packages** window, go to **Browse** tab and type **Syncfusion.Blazor** in the search field. This displays all Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor NuGet package options. Select the appropriate package based on the component requirements.

    N> By default, the [nuget.org](https://api.nuget.org/v3/index.json) package source is configured in Visual Studio. If `nuget.org` is not available, refer to the [Microsoft documents](https://learn.microsoft.com/en-us/nuget/consume-packages/install-use-packages-visual-studio#package-sources) to configure the `nuget.org` feed URL.

    ![Search for Syncfusion Blazor packages in the Browse tab](images/nugetsearch.webp)

3. When a Blazor package is selected, the right side panel displays detailed information about that package.

4. By default, the latest version is selected. To install a specific release, select the required version from the available options, click **Install** and accept the license terms. The package will be added to the Blazor application.

    ![Install a Syncfusion Blazor package from the Package Manager UI](images/installnuget.webp)

5. Now, all required Syncfusion<sup style="font-size:70%">&reg;</sup> assemblies have been installed. the application is ready to build high-performance, responsive solutions with [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components](https://www.syncfusion.com/blazor-components). See the [Blazor documentation](https://blazor.syncfusion.com/documentation/introduction) for further development assistance.

## Installation using Dotnet (.NET) CLI

The [.NET CLI](https://learn.microsoft.com/en-us/nuget/consume-packages/install-use-packages-dotnet-cli) provides functionality to add, restore, pack, publish, and manage packages without modifying project files. Use [dotnet add package](https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-package-add?tabs=netcore2x) to add a package reference, and [dotnet restore](https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-restore?tabs=netcore2x) to install it.

Follow the below steps to install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor NuGet packages using the .NET CLI command.

1. Open a command prompt and navigate the directory to where the Blazor application file is located.
2. Run the following command to install the NuGet package.

    ```bash
    dotnet add package <PackageName>
    ```

    **For example:**

    ```bash
    dotnet add package Syncfusion.Blazor.Grid
    ```

    N> By default, the command upgrades to the latest version when no version flag is provided. Add the `-v` parameter to specify a version: `dotnet add package Syncfusion.Blazor.Grid -v {{ site.releaseversion }}`

3. After the installation command completes, check the `.csproj` file to verify that the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor package reference has been added to the Blazor application.

    ![Blazor Package Entry ](images/packageentry.webp)

4. Then, run [dotnet restore](https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-restore?tabs=netcore2x) command to restore all required packages to the application file.

5. Now, all required Syncfusion<sup style="font-size:70%">&reg;</sup> assemblies have been installed. the application is ready to build high-performance, responsive solutions with [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components](https://www.syncfusion.com/blazor-components). See the [Blazor documentation](https://blazor.syncfusion.com/documentation/introduction) for further development assistance.

## Installation using Package Manager Console

The **Package Manager Console** saves NuGet package installation time since there is no need to search for the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor NuGet package that needs to be installed. Instead of browsing for the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor NuGet package, developers can simply type an installation command. Follow the instructions below to use the Package Manager Console to install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components as NuGet packages in Blazor application.

1. Open the Blazor application in Visual Studio, then go to **Tools → NuGet Package Manager → Package Manager Console**.

    ![Package Manager Console in Visual Studio](images/console.webp)

2. The **Package Manager Console** appears at the bottom of Visual Studio. Enter the following NuGet commands to install the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor NuGet packages.

    ***Install specified Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor NuGet package.***

    The following command will install the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor NuGet package in the default Blazor application.

    ```powershell
    Install-Package <PackageName>
    ```

    **For example:**

    ```powershell
    Install-Package Syncfusion.Blazor.Grid
    ```

    > **Note:** Browse Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor NuGet packages on [NuGet.org](https://www.nuget.org/packages?q=Tags%3A%22Blazor%22+syncfusion).

    ***Install specified Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor NuGet package in specified Blazor application***

    The following command installs the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor NuGet package into the specified Blazor application.

    ```powershell
    Install-Package <PackageName> -ProjectName <ProjectName>
    ```

    **For example:**

    ```powershell
    Install-Package Syncfusion.Blazor.Grid -ProjectName SyncfusionBlazorApp
    ```

3. By default, the package will be installed with latest version. To install a specific Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor release, specify `-Version` parameter with the Package Manager Console command.

    ```powershell
    Install-Package Syncfusion.Blazor.Grid -Version {{ site.releaseversion }}
    ```

    ![Package Manager Console output showing installed package](images/consoleinstallationoutput.webp)

4. The Package Manager Console installs the Syncfusion® Blazor NuGet package and its dependencies. After installation finishes, check the console output for a confirmation message indicating the Syncfusion® Blazor package was added to the application.

5. Now, all required Syncfusion<sup style="font-size:70%">&reg;</sup> assemblies have been installed. the application is ready to build high-performance, responsive solutions with [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components](https://www.syncfusion.com/blazor-components). See the [Blazor documentation](https://blazor.syncfusion.com/documentation/introduction) for further development assistance.