---
layout: post
title: How to troubleshoot exceptions in TextBox Blazor | Syncfusion
description: Checkout and learn here all about troubleshooting server and client exceptions in Blazor TextBox component.
platform: Blazor
component: Common
documentation: ug
---

# How to troubleshoot exceptions in Blazor TextBox

<!-- markdownlint-disable MD036 -->

## Runtime exceptions

* **InvalidOperationException: Cannot provide a value for property 'SyncfusionService' on type 'Syncfusion.Blazor.Inputs.SfTextBox'**

    You may see the below runtime exception while running the application for the first time.

    E> **InvalidOperationException:** Cannot provide a value for property 'SyncfusionService' on type 'Syncfusion.Blazor.Inputs.SfTextBox'. There is no registered service of type 'Syncfusion.Blazor.SyncfusionBlazorService'.

    **Cause:**

    This exception thrown because you missed registering the `SyncfusionBlazorService` in `Program.cs`.

    **Solution:**

    You can register the `SyncfusionBlazorService` in `Program.cs` file to resolve the exception.

    ```c#
    using Syncfusion.Blazor;
    ....
    builder.Services.AddSyncfusionBlazor();
    ```

## See also

* [Common Troubleshoot](https://blazor.syncfusion.com/documentation/common/how-to/troubleshoot)
