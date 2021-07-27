---
layout: post
title: Upgrade Application To Latest Version in Blazor DataGrid Component | Syncfusion
description: Learn here all about Upgrade Application To Latest Version in Syncfusion Blazor DataGrid component and more.
platform: Blazor
control: DataGrid
documentation: ug
---

# Upgrade Application To Latest Version in Blazor DataGrid Component

**Step 1:** Update the latest Syncfusion blazor [`nuget`](https://www.nuget.org/packages/Syncfusion.Blazor/) from Nuget package manager in your application.

![update syncfusion blazor nuget](../images/upgrade-version.PNG)

## Compatible .NET version

Syncfusion Blazor components in the latest version `'{:nuget-version:}'` are compatible with the latest version of .NET Core 3.1. So, we suggest you to upgrade the .NET Core 3.1 SDK in your machine before upgrading to the latest version.

## Client resource file references

Ensure our CSS files have been properly configured in your application.

* If you use the Blazor server app, add the following style file references in **~/Pages/_Host.cshtml**.

* If you use the Blazor WebAssembly app, add the following style file references in **~/wwwroot/index.html**.

```html
    <link href="_content/Syncfusion.Blazor/styles/bootstrap4.css" rel="stylesheet" />
```

> For production purpose and minimal requirement, Syncfusion provides an option to generate scripts and styles of selective control by using the Custom Resource Generator (CRG) web tool. Refer to this [link](https://crg.syncfusion.com/) for more details on CRG.

## Breaking changes

Some changes have been modified in our Blazor samples for each release. So, we suggest you to ensure the breaking changes. Refer to this [release notes](https://blazor.syncfusion.com/documentation/release-notes/index/) for our Blazor components.

## Cache problem

Before restoring the NuGet packages, clean the old version Syncfusion.Blazor NuGet package.

The following steps explain how to clean the cache:

1. Delete/clear the package Syncfusion.Blazor from the installed location `{System-driver}\Users\{user-name}\.nuget\packages\syncfusion.blazor`. In Windows, the installed location of Syncfusion.Blazor package can be found using `%userprofile%\.nuget\packages\syncfusion.blazor`.

2. Update the latest version of Syncfusion.Blazor NuGet package.