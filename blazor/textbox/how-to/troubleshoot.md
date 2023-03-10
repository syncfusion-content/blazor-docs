---
layout: post
title: How to troubleshoot server & client exceptions in Blazor | Syncfusion
description: Checkout and learn here all about troubleshooting server and client exceptions in Blazor and much more.
platform: Blazor
component: TextBox
documentation: ug
---

# How to troubleshoot server and client exceptions in Blazor

<!-- markdownlint-disable MD036 -->

## Runtime exceptions

* **InvalidOperationException: Cannot provide a value for property 'Localizer' on type 'Syncfusion.Blazor.Inputs.SfTextBox'. There is no registered service of type 'Syncfusion.Blazor.ISyncfusionStringLocalizer'**

    You may see the below runtime exception while running the application for the first time.

    E> **InvalidOperationException:** Cannot provide a value for property 'SyncfusionService' on type 'Syncfusion.Blazor.Namespace.Component'. There is no registered service of type 'Syncfusion.Blazor.SyncfusionBlazorService'.

    **Cause:**

    This exception thrown because you missed registering the `SyncfusionBlazorService` in `Startup.cs`.

    **Solution:**

    You can register the `SyncfusionBlazorService` in `Startup.cs` file to resolve the exception.

    ```c#
    using Syncfusion.Blazor;
    public class Startup
    {
        ....
        ....
        public void ConfigureServices(IServiceCollection services)
        {
            ....
            ....
            services.AddSyncfusionBlazor();
        }
        ....
        ....
    }
    ```