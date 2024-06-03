---
layout: post
title: Port Blazor Server Side App to MAUI Blazor Hybrid App | Syncfusion
description: Checkout and learn here all about porting Syncfusion Blazor Server App to .NET MAUI Blazor Hybrid App.
platform: Blazor
component: Common
documentation: ug
---

# How to port Syncfusion Blazor Server App to MAUI Blazor Hybrid App

This section explains how to port Syncfusion Blazor Server App to .NET MAUI Blazor Hybrid App using Razor Class Library (RCL). This way, you can avoid rewriting all your Blazor Server App pages for the .NET MAUI Blazor Hybrid App.

## Prerequisites

[.NET 6.0](https://dotnet.microsoft.com/en-us/download/dotnet/6.0) or later.

## Create a new project for Blazor Server App

1. Create a new [Blazor Server App](https://blazor.syncfusion.com/documentation/getting-started/blazor-server-side-visual-studio) with Syncfusion `Blazor Calendar` component using [Visual Studio](https://visualstudio.microsoft.com/vs/).

2. Now, create a [Razor Class Library](https://blazor.syncfusion.com/documentation/getting-started/razor-class-library) in Visual Studio and configure it with already created Blazor Server App.

3. Next, move the Syncfusion `Blazor NuGet packages`, `Razor components`, `App.razor`, `Import.razor`, `CSS`, `Shared`, and `Data` folders to the Razor class library from the Blazor server project.

    ![Folders to move](images/server-folders.png)

4. Create a new [.NET MAUI Blazor Hybrid App](https://learn.microsoft.com/en-us/aspnet/core/blazor/hybrid/tutorials/maui?view=aspnetcore-8.0) for porting the `Blazor Server Side App`.

5. Afterward, refer the `Razor class library` in both the `Blazor server app` and `MAUI Blazor App` and then resolve reference missing errors.

6. Delete the common folders like Razor components, Main.razor, Import.razor, CSS, Shared, and Data folder from the MAUI Blazor app.

7. Modify the **~/index.html** file as shown below to render the already existing razor components in the MAUI Blazor project

    ```html
    <head>
        ...
        <link rel="stylesheet" href="_content/RazorClassLibrary/css/bootstrap/bootstrap.min.css" />
        <link href="_content/RazorClassLibrary/css/site.css" rel="stylesheet" />
        <link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />
        <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
        <link href="MauiBlazorApp.styles.css" rel="stylesheet" />
    </head>
    ```

8. Now, register the Syncfusion Blazor service in the `MauiProgram.cs` file of your MAUI Blazor App.

    {% tabs %}
    {% highlight C# tabtitle="~/MauiProgram.cs" hl_lines="1 3" %}

        using Syncfusion.Blazor;
        ....
        builder.Services.AddSyncfusionBlazor();
        ....

    {% endhighlight %}
    {% endtabs %}

9. Finally, in `MainPage.xaml`, The `RazorClassLibrary` is added and points to the root of the Blazor app. The root Blazor component for the app is in `App.razor`, which Razor compiles into a type named `App` in the application's root namespace.

    {% tabs %}
    {% highlight xaml tabtitle="MainPage.xaml" %}

    <?xml version="1.0" encoding="utf-8" ?>

    <ContentPage xmlns=  http://schemas.microsoft.com/dotnet/2021/maui
                xmlns:x=  http://schemas.microsoft.com/winfx/2009/xaml
                xmlns:rcl="clr-namespace:RazorClassLibrary;assembly=RazorClassLibrary"
                x:Class="MauiBlazorApp.MainPage"
                BackgroundColor="{DynamicResource PageBackgroundColor}">

        <BlazorWebView HostPage="wwwroot/index.html">
            <BlazorWebView.RootComponents>
                <RootComponent Selector="#app" ComponentType="{x:Type rcl:App}" />
            </BlazorWebView.RootComponents>
        </BlazorWebView>
    </ContentPage>

    {% endhighlight %}
    {% endtabs %}

10. In the Visual Studio toolbar, select the **Windows Machine** button to build and run the app.

    ![Build and run MAUI Blazor Hybrid App](images/windows-machine-mode.png)

