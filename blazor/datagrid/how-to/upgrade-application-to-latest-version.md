---
layout: post
title: Upgrade Blazor DataGrid App to Latest Syncfusion Version
description: Upgrade your Blazor DataGrid app to the latest Syncfusion version, update resource links, and fix NuGet cache issues.
platform: Blazor
control: DataGrid
documentation: ug
---

# Upgrade application To latest version in Blazor DataGrid

**Step 1:** Update to the latest Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor [NuGet](https://www.nuget.org/packages/Syncfusion.Blazor/) package using the NuGet Package Manager in the application.

![Updating Blazor NuGet Package](../images/blazor-datagrid-update-nuget-package.PNG)

## Compatible .NET version

The latest Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components are compatible with the latest .NET (for example, .NET 9). It is recommended to upgrade the .NET SDK on the machine before updating to the latest Syncfusion version.

## Client resource file references

Ensure Syncfusion CSS resources are properly referenced in the application.

* For a Blazor Server app, add the following style file reference in **~/Pages/_Host.cshtml**.

* For a Blazor WebAssembly app, add the following style file reference in **~/wwwroot/index.html**.

```html
    <link href="_content/Syncfusion.Blazor/styles/bootstrap4.css" rel="stylesheet" />
```

N> For production scenarios and minimal footprint, Syncfusion<sup style="font-size:70%">&reg;</sup> provides the Custom Resource Generator (CRG) web tool to generate scripts and styles for selected controls. Refer to this [link](https://crg.syncfusion.com/) for more details on CRG.

## Breaking changes

Some changes may occur across releases that affect existing applications. Review the breaking changes and notes for the target version before upgrading. Refer to the Blazor components [release notes](https://blazor.syncfusion.com/documentation/release-notes) for details.

## Cache problem

Before restoring NuGet packages, clear any cached versions of the Syncfusion.Blazor package to avoid conflicts.

The following steps explain how to clean the cache:

1. Delete/clear the `Syncfusion.Blazor` package from the installed location `{System drive}/Users/{user-name}/.nuget/packages/syncfusion.blazor`. On Windows, the installed location can also be accessed using `%userprofile%/.nuget/packages/syncfusion.blazor`.

2. Update to the latest version of the `Syncfusion.Blazor` NuGet package.