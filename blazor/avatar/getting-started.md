---
layout: post
title: Getting Started with Blazor Avatar Component | Syncfusion
description: Checkout and learn about getting started with Blazor Avatar component of Syncfusion, and more details.
platform: Blazor
control: Avatar
documentation: ug
---

<!-- markdownlint-disable MD024 -->

# Getting Started with Blazor Avatar Component

This section briefly explains about how to include a `Avatar` in your Blazor application. You can refer [Getting Started with Syncfusion Blazor for Server-Side in Visual Studio 2019](../../getting-started/blazor-server-side-visual-studio-2019/) page for the introduction and configuring the common specifications.

## Importing Syncfusion Blazor component in the application

* Install [Syncfusion.Blazor](https://www.nuget.org/packages/Syncfusion.Blazor) NuGet package to the application by using the `NuGet Package Manager`.

* You can add the client-side style resources through [CDN](https://blazor.syncfusion.com/documentation/appearance/themes#cdn-reference) or from [NuGet](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets) package to the `<head>` element of the `~/wwwroot/index.html` page in Blazor WebAssembly app or `~/Pages/_Host.cshtml` page in Blazor app.

    ```html
    <head>
        <link href="_content/Syncfusion.Blazor/styles/bootstrap4.css" rel="stylesheet" />
    </head>
    ```

    ```html
    <head>
        <link href="https://cdn.syncfusion.com/blazor/{{ site.blazorversion }}/styles/bootstrap4.css" rel="stylesheet" />
    </head>
    ```

    * For `Internet Explorer` 11 kindly refer the polyfills. Refer the [documentation](https://blazor.syncfusion.com/documentation/common/how-to/render-blazor-server-app-in-ie/) for more information.

    ```html
    <head>
        <link href="_content/Syncfusion.Blazor/styles/bootstrap4.css" rel="stylesheet" />
        <script src="https://github.com/Daddoon/Blazor.Polyfill/releases/download/3.0.1/blazor.polyfill.min.js"></script>
    </head>
    ```

## Adding Avatar component to the application

Now, add the Syncfusion Avatar component in any web page `razor` in the `Pages` folder. For example, the Avatar component is added in the `~/Pages/Index.razor` page.

```html
<!-- xSmall Avatar-->
<div class="e-avatar e-avatar-xsmall image"></div>

<!-- Small Avatar-->
<div class="e-avatar e-avatar-small image"></div>

<!-- Avatar-->
<div class="e-avatar image"></div>

<!-- Large Avatar-->
<div class="e-avatar e-avatar-large image"></div>

<!-- xLarge Avatar-->
<div class="e-avatar e-avatar-xlarge image"></div>
```

## Run the application

After successful compilation of your application, simply press `F5` to run the application.

Output be like the below.

![Blazor Avatar Component](./images/blazor-avatar-component.PNG)