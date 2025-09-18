---
layout: post
title: Upgrade Application To Latest Version in Blazor DataGrid | Syncfusion
description: Learn here all about Upgrade Application To Latest Version in Syncfusion Blazor DataGrid component and more.
platform: Blazor
control: DataGrid
documentation: ug
---

# Upgrade application To latest version in Blazor DataGrid

**Step 1:** Update the latest Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor [NuGet](https://www.nuget.org/packages/Syncfusion.Blazor/) from NuGet package manager in your application.

![Updating Blazor NuGet Package](../images/blazor-datagrid-update-nuget-package.PNG)

## Compatible .NET version

Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components in the latest version `'{:nuget-version:}'` are compatible with the latest version of .NET Core 9.0. So, we suggest you to upgrade the .NET Core 9.0 SDK in your machine before upgrading to the latest version.

## Client resource file references

Ensure our CSS files have been properly configured in your application.

* If you use the Blazor server app, add the following style file references in **~/Pages/_Host.cshtml**.

* If you use the Blazor WebAssembly app, add the following style file references in **~/wwwroot/index.html**.

```html
    <link href="_content/Syncfusion.Blazor/styles/bootstrap4.css" rel="stylesheet" />
```

N> For production purpose and minimal requirement, Syncfusion<sup style="font-size:70%">&reg;</sup> provides an option to generate scripts and styles of selective control by using the Custom Resource Generator (CRG) web tool. Refer to this [link](https://crg.syncfusion.com/) for more details on CRG.

## Breaking changes

Some changes have been modified in our Blazor samples for each release. So, we suggest you to ensure the breaking changes. Refer to this [release notes](https://blazor.syncfusion.com/documentation/release-notes/19.4.47?type=all) for our Blazor components.

## Cache problem

Before restoring the NuGet packages, clean the old version Syncfusion.Blazor NuGet package.

The following steps explain how to clean the cache:

1. Delete/clear the package Syncfusion.Blazor from the installed location `{System-driver}/Users/{user-name}/.nuget/packages/syncfusion.blazor`. In Windows, the installed location of Syncfusion.Blazor package can be found using `%userprofile%/.nuget/packages/syncfusion.blazor`.

2. Update the latest version of Syncfusion.Blazor NuGet package.