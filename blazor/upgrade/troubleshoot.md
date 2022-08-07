---
layout: post
title: How to troubleshoot after upgrading between different versions.
description: Checkout and learn here all about troubleshooting after upgrading between versions in Blazor.
platform: Blazor
component: Common
documentation: ug
---

# TroubleShoot

## Syncfusion Components doesnt render after upgrading to 20.1.* versions from 19.* version

### Case 1: When set **IgnoreScriptIsolation** as true in 19.* versions.

If you are using individual NuGet packages and referred themes from `static web assets`, from 20.* versions you need to install `Syncfusion.Blazor.Themes` NuGet package in your application to render controls properly.

### Case 2: When set **IgnoreScriptIsolation** as false in 19.* versions or didnt use **IgnoreScriptisolation**.

* If you are using individual NuGet packages and referred themes from `static web assets`, from 20.* versions you need to install `Syncfusion.Blazor.Themes` NuGet package in your application to render controls properly.
* As we have set the defalut value of **IgnoreScriptIsolation** as true, add the following script file reference in the **~/Pages/_Host.cshtml** for Blazor Server app or add it in the **~/wwwroot/index.html** for Blazor WebAssembly app.

    If you are using `Syncfusion.Blazor` NuGet package in your application, then use the below reference link.

    ```html
    <script src="_content/Syncfusion.Blazor/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
    ```

    If you are using [individual NuGet packages](http://blazor.syncfusion.com/documentation/nuget-packages/) in your application, then use the below reference link.
    
    ```html
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
    ```

## Throws script error after upgrading to 20.* version when referred scripts through CDN

* From 20.* versions while referring scripts through CDN you need to refer using version based CDN links which contains the latest scripts.
* Add the following script file reference in the **~/Pages/_Host.cshtml** for Blazor Server app or add it in the **~/wwwroot/index.html** for Blazor WebAssembly app.

    ```html
    <script src="https://cdn.syncfusion.com/blazor/20.2.36/syncfusion-blazor.min.js" type="text/javascript"></script>
    ```
