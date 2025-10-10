---
layout: post
title: Troubleshoot server and client exceptions in Blazor | Syncfusion
description: Learn here about how to diagnose and resolve common server and client exceptions in Blazor, including runtime, compile-time, and browser console errors.
platform: Blazor
control: Common
documentation: ug
---

# How to troubleshoot server and client exceptions in Blazor

<!-- markdownlint-disable MD036 -->

## Runtime exceptions

* **InvalidOperationException: Cannot provide a value for property 'SyncfusionService' on type 'Syncfusion.Blazor.Namespace.Component'**

    You may see the below runtime exception while running the application for the first time.

    E> **InvalidOperationException:** Cannot provide a value for property 'SyncfusionService' on type 'Syncfusion.Blazor.Namespace.Component'. There is no registered service of type 'Syncfusion.Blazor.SyncfusionBlazorService'.

    **Cause:**

    This exception thrown because you missed registering the `SyncfusionBlazorService` in `Program.cs`.

    **Solution:**

    Register the `SyncfusionBlazorService` in the `Program.cs` file to resolve the exception.

    ```c#
    using Syncfusion.Blazor;
    ....
    builder.Services.AddSyncfusionBlazor();
    ```

* **System.NullReferenceException: Object reference not set to an instance of an object**

    You may see the below exception while running the application in your production/server machine.

    E> **System.NullReferenceException:** Object reference not set to an instance of an object. <br /> at `Syncfusion.Blazor.SyncfusionBlazorService.GetContext()`
    <br /> at `Syncfusion.Blazor.BaseComponent.OnInitializedAsync()`
    <br /> at `Syncfusion.Blazor.Charts.SfChart.OnInitializedAsync()`
    <br /> at `Microsoft.AspNetCore.Components.ComponentBase.RunInitAndSetParametersAsync()`

    **Cause:**

    The production/hosting server machine may have an outdated configuration like .NET Core SDK and .NET Core runtime hosting bundle.

    **Solution:**

    Update your dotnet SDK/hosting bundle with the latest version in your production/hosting server machine.

    Install the latest .NET SDK/hosting bundle from [here](https://dotnet.microsoft.com/en-us/download/dotnet) on the hosting machine to resolve this.

* **The type name 'Shared' does not exist in the type 'SyncfusionBlazor'**

   You may see the below exception while running the Syncfusion<sup style="font-size:70%">&reg;</sup> blazor
   application.

    E> The type name 'Shared' does not exist in the type 'SyncfusionBlazor' SyncfusionBlazor `\SyncfusionBlazor\SyncfusionBlazor\obj\Debug\netcoreapp3.1\Razor\Shared\MainLayout.razor.g.cs`

   **Cause:**

    This issue occurred, if you are creating the application name as **SyncfusionBlazor**. The name **SyncfusionBlazor** is already registered in the Syncfusion<sup style="font-size:70%">&reg;</sup> service handling. So your application name and the internally used class name gets conflict.

   **Solution:**

   Try to use a different application name, when you create the blazor application with Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components.

* **System.IO.FileLoadException: Could not load file or assembly 'System.Text.Json**

    You may get the below exception while running the Syncfusion<sup style="font-size:70%">&reg;</sup> blazor application.

    E> **System.IO.FileLoadException:** Could not load file or assembly 'System.Text.Json, Version=4.0.1.1, Culture=neutral PublicKeyToken=cc7b13ffcd2ddd51'. The located assembly's manifest definition does not match the assembly reference.

    **Cause:**

    You may have .NET Core SDK older than version 3.1.2, but Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components need the latest version of .NET Core SDK as stated in the [pre-requisite](https://blazor.syncfusion.com/documentation/getting-started/blazor-server-side-visual-studio#prerequisites) documentation.

    **Solution:**

    Check installed .NET Core SDK version and update to the latest version. You can also find/download the details of the latest .NET Core SDK version [here](https://dotnet.microsoft.com/en-us/download/dotnet).

## Compile-time errors

* **error CS0121: The call is ambiguous between the following methods or properties: 'Syncfusion.Blazor.SyncfusionBlazor.AddSyncfusionBlazor(Microsoft.Extensions.DependencyInjection.IServiceCollection, bool)' and 'Syncfusion.Blazor.SyncfusionBlazor.AddSyncfusionBlazor(Microsoft.Extensions.DependencyInjection.IServiceCollection, bool)'**

    You may see the below compile-time exception while running the application.

    E> The call is ambiguous between the following methods or properties 'Syncfusion.Blazor.SyncfusionBlazor.AddSyncfusionBlazor(Microsoft.Extensions.DependencyInjection.IServiceCollection, bool)'

    **Cause:**

    1. You may used `SfPdfViewer` or `SfDocumentEditor` components along with other Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components in your application.
    2. You may installed both [Syncfusion.Blazor](https://www.nuget.org/packages/Syncfusion.Blazor/) and [individual NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) in the same application.

    **Solution**

    1. Starts with Volume 4, 2020 (v18.4.0.30) release, The `SfPdfViewer` and `SfDocumentEditor` components changed its dependency structure.
    2. We suggest you to use the [individual NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) to resolve this issue.

* **The type or namespace name 'EJ2' does not exist in the namespace 'Syncfusion' (are you missing an assembly reference?)**

    You may see the below compile-time exception while running the application.

    E> The type or namespace name 'EJ2' does not exist in the namespace 'Syncfusion' (are you missing an assembly reference?)

    **Cause:**

    You may use deprecated namespace in the application with Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor NuGet package version greater than or equal to 18.1.0.36.

    **Solution**

    The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor library changed its namespace, NuGet package name, and component names starting with v18.1.0.36. Refer to this [documentation](../how-to/upgrade-syncfusion-components-to-18dot1-version#namespace-changes) to migrate the application with the correct namespace. Example: `Syncfusion.EJ2.Blazor` is now `Syncfusion.Blazor`.

* **Found markup element with unexpected name 'Ejs'. If this is intended to be a component, add a @using directive for its namespace**

    You may see the below compile-time exception while running the application.

    E> Found markup element with unexpected name 'Ejs'. If this is intended to be a component, add a @using directive for its namespace

    **Cause:**

    You may use the deprecated component name in the application with the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor NuGet package version greater than or equal to 18.1.0.36.

    **Solution**

    The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor library changed its namespace, NuGet package name, and component names starting with v18.1.0.36. Refer to this [documentation](./upgrade-syncfusion-components-to-18.1.0.36-version#component-name-changes) to migrate the application with the correct component names. Example: `EjsGrid` is now `SfGrid`.

## Browser console errors

* **net::ERR_ABORTED 404 Error While Using Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Static CSS**

    You may see the below exception in the web browser dev tool console.

    E> GET ./_content/Syncfusion.Blazor/styles/bootstrap4.css net::ERR_ABORTED 404

    **Cause:**

    If you upgraded Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor packages from previous versions to 18.4.0.* version or later, this issue occurred.

    **Solution**

    The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor library provides [individual NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) from the 18.4.0.30 version. If you are using `individual NuGet Package` in your application, you have to modify the below static web assets (styles) reference from `Syncfusion.Blazor` to `Syncfusion.Blazor.Themes` in the application to resolve this issue.

    ```html
        <head>
             ....
             ....
             <link href="_content/Syncfusion.Blazor.Themes/bootstrap4.css" rel="stylesheet" />
        </head>
    ```

    N> Do not use both Syncfusion.Blazor and individual NuGet packages in the same application. It will throw ambiguous errors while compiling the project.

* **An unhandled exception has occurred. See browser dev tools for details**

    You may see the below exception at the bottom of the page.

    E> An unhandled exception has occurred. See browser dev tools for details

    **Cause:**

    There may be script errors thrown in the JS Interop or client script source.

    **Solution:**

    Open the browser dev tool by pressing the `F12` key and navigate to the `Console` tab.

    Check the console error with the following topics to resolve the issue or report us the console error through our [support ticket](https://support.syncfusion.com/).

* **Unhandled exception rendering component: Could not find 'loadScripts' in 'window.sfBlazor'.**

    You may see the below exception in the web browser dev tool console.

    E> Could not find 'loadScripts' in 'window.sfBlazor'.

    **Cause:**

    This script error may throws because of browser cache or outdated script reference in the application.

    **Solution:**

    We recommend you to clear the browser cache to resolve the above script error in v18.2.0.44 or later.

* **net::ERR_ABORTED 404 Error While Using Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Static files in modified base path or hosted as sub path app.**

   You may face the below exception when deploying the blazor application as Sub application.

    E> GET `./<SUB-PATH>/<SUB-PATH>_content/Syncfusion.Blazor/<Scripts and CSSs references>` net::ERR_ABORTED 404

    For this, we need to configure the Base path configuration in the root application's `Program.cs` and `_Host.cshtml`.

    **Cause:**

    For sub-path hosting we need to configure the base path related configuration. If we missed to configure it leads to this errors.

    **Solution:**

    We need to configure the base path in our application when we are hosting the app as Sub-URL like below.

    | In _Host.cshtml File | In Program.cs File |
    | ------------- | ------------- |
    | `<base href="/myblazorapp/" />`  | `app.UsePathBase("/myblazorapp");`|

    N> The trailing slash is required for the '_Host.cshtml' base path configuration.

    For further details, refer to [Host and deploy ASP.NET Core Blazor](https://learn.microsoft.com/en-us/aspnet/core/blazor/host-and-deploy#app-base-path).


## See also

* [How to solve AOT publish failure when using Syncfusion.Blazor](https://www.syncfusion.com/forums/169884/aot-publish-fails-for-syncfusion-blazor-dll)

* [Syncfusion<sup style="font-size:70%">&reg;</sup> components doesn't render in Blazor WebAssembly application](https://support.syncfusion.com/kb/article/12054/syncfusion-components-doesnt-render-in-blazor-webassembly-application?isInternalRefresh=False#problem)

