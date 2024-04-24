---
layout: post
title: Render the Blazor Server App in IE11 Browser in Blazor - Syncfusion
description: Learn here all about how to Render the Blazor Server App in IE11 Browser in Blazor component and more.
platform: Blazor
component: Common
documentation: ug
---

# How to Render the Blazor Server Application in IE11 Web Browser

This section explains how to render the Blazor Server application in IE11 web browser.

## Blazor Client/WebAssembly App

The Microsoft Internet Explorer doesn't support with `WebAssembly`. So, Blazor Client/WebAssembly application does not support with Internet Explorer web browser.

## Blazor Server App

The Microsoft Internet Explorer supports `Blazor Server` app with additional polyfills in .NET Core 3.1 apps. However, it is not support with .NET 5.0 or later versions. Refer to [Blazor updated browser support](https://learn.microsoft.com/en-us/aspnet/core/blazor/supported-platforms?view=aspnetcore-7.0) for more information.

Find the following steps to add the polyfills in the Blazor server application.

1. Create a Blazor server application using [Blazor Server Getting Started](https://blazor.syncfusion.com/documentation/getting-started/blazor-server-side-visual-studio) documentation.

2. Add the polyfill script reference in the `<head>` element of the `~/Pages/_Host.cshtml` page.

    ```html
    <head>

        .....
        .....

        <script src="https://github.com/Daddoon/Blazor.Polyfill/releases/download/3.0.8/blazor.polyfill.min.js"></script>
    </head>

    ```

    N> This [polyfill](https://github.com/Daddoon/Blazor.Polyfill/releases/tag/3.0.8) is required to configure in Blazor server application for IE 11 support for .NET Core 3.1 app.

3. Run the application in the IE 11 web browser and the Syncfusion Blazor Component is now rendered on IE 11.

    ![Syncfusion component rendering on IE11](images/rendering-component-on-ie11.png)

## See Also

* [Blazor Updated Browser Support](https://learn.microsoft.com/en-us/dotnet/core/compatibility/aspnet-core/5.0/blazor-browser-support-updated)
* [Blazor Browser Support on .NET 7.0](https://learn.microsoft.com/en-us/aspnet/core/blazor/supported-platforms?view=aspnetcore-7.0)
