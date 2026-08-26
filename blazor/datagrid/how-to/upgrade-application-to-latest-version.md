---
layout: post
title: Blazor Grid Upgrade NuGet Package | Syncfusion
description: Learn how to upgrade a Blazor Data Grid application to the latest version, update resources, refresh NuGet packages, and resolve cache-related issues.
platform: Blazor
control: DataGrid
documentation: ug
---

# Upgrade NuGet Package to Latest Version in Blazor Data Grid

## Step 1: Install the compatible .NET SDK

Syncfusion Blazor supports the `.NET 10` SDK. [Download and install the .NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0) before updating the application.

## Step 2: Review compatibility requirements

Review the [v34.1.29 release notes](https://blazor.syncfusion.com/documentation/release-notes/34.1.29) for compatibility requirements and breaking changes. Refer to the Blazor components [release notes](https://blazor.syncfusion.com/documentation/release-notes?type=all) for additional details.

## Step 3: Clear the NuGet package cache

Delete or clear the `Syncfusion.Blazor` package from the installed location `{System drive}/Users/{user-name}/.nuget/packages/syncfusion.blazor`. On Windows, the installed location can also be accessed using `%userprofile%/.nuget/packages/syncfusion.blazor`.

## Step 4: Update the NuGet package

Update to the latest Blazor [NuGet](https://www.nuget.org/packages/Syncfusion.Blazor/) package using the NuGet Package Manager in the application.

![Updating Blazor NuGet Package](../images/blazor-datagrid-update-nuget-package.webp)

## Step 5: Add client resource references

Add the theme stylesheet and Syncfusion Blazor script to the application's host file.

* For a classic Blazor Server project, add the references to **~/Pages/_Host.cshtml**.

* For a Blazor Web App project, add the references to **~/Components/App.razor**.

* For a standalone Blazor WebAssembly app, add the stylesheet to the `<head>` and the script to the `<body>` of **~/wwwroot/index.html**.

```html
<head>
    <link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />
</head>

<body>
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
</body>
```
