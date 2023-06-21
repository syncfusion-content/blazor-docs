---
layout: post
title: Upgrade Syncfusion Components to Latest Version in Blazor - Syncfusion
description: Check out the documentation for Upgrade Syncfusion Components to Latest Version in Blazor Application.
platform: Blazor
component: Common
documentation: ug
---

# How to upgrade Syncfusion Blazor Components to the latest version

To upgrade Syncfusion Blazor Components to the latest version, you need to ensure the following:

## Compatible .NET version

Syncfusion Blazor components in the latest version `'{:nuget-version:}'` are compatible with the latest version of .NET Core 5.0 and .NET Core 3.1. Also, refer to [version compatibility](./version-compatibility) documentation for more information about version compatibility of Syncfusion Blazor components and .NET Core SDK.

## Client resource file references

Ensure your CSS files have been properly configured in your application.

* Add the following style file reference in the **~/Pages/_Host.cshtml** for Blazor Server app or add it in the **~/wwwroot/index.html** for Blazor WebAssembly app.

    If you are using `Syncfusion.Blazor` NuGet package in your application, then use the below reference link.

    ```html
    <link href="_content/Syncfusion.Blazor/styles/bootstrap4.css" rel="stylesheet" />
    ```

    If you are using [individual NuGet packages](http://blazor.syncfusion.com/documentation/nuget-packages/) in your application, then use the below reference link.
    
    ```html
    <link href="_content/Syncfusion.Blazor.Themes/bootstrap4.css" rel="stylesheet" />
    ```

N> For production purpose and minimal requirement, Syncfusion provides an option to generate custom styles of selective components by using the ThemeStudio web application. Refer to this [link](http://ej2.syncfusion.com/themestudio/) for more details on ThemeStudio.

## Breaking changes

Some changes have been modified in our Blazor samples for each release. So, we suggest you to ensure the breaking changes. Refer to this [release notes](https://blazor.syncfusion.com/documentation/release-notes/index/?type=breaking-changes) for our Blazor components.

## Cache problem

Before restoring the NuGet packages, clean the older versions of Syncfusion Blazor NuGet packages.

The following steps explain how to clean the cache:

1. Delete the Syncfusion Blazor NuGet packages from the installed location `{System-driver}/Users/{user-name}/.nuget/packages/`. In Windows, the installed location of Syncfusion Blazor NuGet packages can be found using `%userprofile%/.nuget/packages/`.

2. Update the latest version of Syncfusion Blazor NuGet packages.

## Linker.xml configuration

In Blazor WebAssembly application, ensure if you have configured **Linker.xml** file in your Syncfusion Blazor application. Missing this configuration may prevent the rendering of Syncfusion Blazor components in the application.

Refer to this [KB article](https://www.syncfusion.com/kb/13439/syncfusion-components-doesnt-render-in-blazor-webassembly-application) for more information on Linker.xml file usage.

N> Linker.xml configuration is applicable only for the Blazor WebAssembly application.

## See Also

* [Version Compatibility](./version-compatibility)
