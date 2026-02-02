---
layout: post
title: Upgrade Syncfusion Blazor components to the latest version
description: Learn how to upgrade Syncfusion Blazor components, verify .NET compatibility, ensure correct CSS references and configuration for Blazor Web, Server, WASM App.
platform: Blazor
control: Common
documentation: ug
---

# Upgrade Syncfusion® Blazor components to the latest version

Use the following checklist to upgrade Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components safely and consistently.

## Compatible .NET version

Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components in the latest version `'{:nuget-version:}'` are compatible with the latest version of [.NET 8.0](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) or [.NET 9.0](https://dotnet.microsoft.com/en-us/download/dotnet/9.0) or [.NET 10](https://dotnet.microsoft.com/en-us/download/dotnet/10.0). Also, refer to [version compatibility](./version-compatibility) documentation for more information about version compatibility of Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components and .NET SDK.

## Client resource file references

Ensure CSS resources are correctly referenced in the application.

* Add the following style reference in the appropriate file based on the hosting model: in **~/Components/App.razor** for Blazor Web App, in **~/Pages/_Host.cshtml** for Blazor Server App, or in **~/wwwroot/index.html** for Blazor WebAssembly App.

    If using the `Syncfusion.Blazor` NuGet package, include the following reference:

    ```html
    <link href="_content/Syncfusion.Blazor/styles/bootstrap4.css" rel="stylesheet" />
    ```

    If using [individual NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages), include the following reference:

    ```html
    <link href="_content/Syncfusion.Blazor.Themes/bootstrap4.css" rel="stylesheet" />
    ```

N> Use a single theme file that matches the chosen look and feel (for example, Bootstrap 5, Material, Tailwind, or Fluent). Replace the file name in the reference with the corresponding theme (for example, `bootstrap5.css`, `material.css`, `tailwind.css`, or `fluent.css`) when applicable. For production builds or minimal bundles, generate custom styles for selected components using the Theme Studio web application at the following link: https://ej2.syncfusion.com/themestudio/.

## Breaking changes

Review breaking changes for each release to understand required code or behavior updates. See the [release notes (breaking changes)](https://blazor.syncfusion.com/documentation/release-notes/index/?type=breaking-changes).

## Cache problem

Before restoring NuGet packages, clear older versions of Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor NuGet packages to avoid conflicts.

The following steps explain how to clean the cache:

1. Delete the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor NuGet packages from the installed location `{System-driver}/Users/{user-name}/.nuget/packages/`. In Windows, the installed location of Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor NuGet packages can be found using `%userprofile%/.nuget/packages/`.
2. Update to the latest Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor NuGet packages.

Tip: The NuGet cache can also be cleared using the .NET CLI: run `dotnet nuget locals all --clear` in a terminal.

## Linker.xml configuration

For Blazor WebAssembly applications, ensure that a Linker.xml (trimming configuration) file is configured when required. Missing this configuration can prevent Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components from rendering.

Refer to this [KB article](https://support.syncfusion.com/kb/article/12054/syncfusion-components-doesnt-render-in-blazor-webassembly-application) for details on Linker.xml usage.

N> Linker.xml configuration applies only to Blazor WebAssembly applications.

## See Also

* [Version compatibility](../version-compatibility)
