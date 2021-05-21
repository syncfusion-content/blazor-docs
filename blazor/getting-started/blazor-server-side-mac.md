---
layout: post
title: Getting started with Syncfusion Blazor - Blazor Server Side App in Visual Studio for Mac
description: Check out the documentation for Getting started with Syncfusion Blazor
platform: Blazor
component: Common
documentation: ug
---

<!-- markdownlint-disable MD024 -->

# Getting started with Syncfusion Blazor Components in Blazor Server Side App using Visual Studio for Mac

This article provides a step-by-step introduction to configure Syncfusion Blazor setup, and also to build and run a simple Blazor Server Side application using [Visual Studio for Mac](https://visualstudio.microsoft.com/vs/mac/).

> **Note:** Starting with version 17.4.0.39 (2019 Volume 4), you need to include a valid license key (either paid or trial key) within your applications. Please refer to this [help topic](https://help.syncfusion.com/common/essential-studio/licensing/license-key#blazor) for more information.

## Prerequisites

* [Visual Studio for Mac](https://visualstudio.microsoft.com/vs/mac/)
* [.NET Core SDK 3.1.8](https://dotnet.microsoft.com/download/dotnet-core/3.1) / [.NET 5.0 SDK](https://dotnet.microsoft.com/download/dotnet/5.0)

>**.NET Core SDK 3.1.8** requires Visual Studio for Mac 8.7.6 or later.
>
> **.NET 5.0** requires Visual Studio 2019 for Mac 8.8 or later.

## Create a Blazor Server side project in Visual Studio for Mac

1. Choose **New** from the Visual Studio for Mac dashboard.

    ![new project in blazor](images/mac-new-project.png)

2. Select **Blazor Server App** from the template, and then click the **Next** button.

    ![blazor template](images/mac-server-template.png)

3. Continue with the **No Authentication** selection in Authentication, and then click the **Next** button.

    ![blazor authentication](images/mac-server-authentication.png)

4. Now, the Blazor Server App project configuration window will popup. Click the **Create** button to create a new project after filling in the Project name.

    ![blazor project configuration](images/mac-server-project-config.png)

## Installing Syncfusion Blazor packages in the application

You can use any one of the below standards to install the Syncfusion Blazor library in your application.

### Using Syncfusion Blazor individual NuGet Packages [New standard]

> Starting with Volume 4, 2020 (v18.4.0.30) release, Syncfusion provides [individual NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages/) for our Syncfusion Blazor components. We highly recommend this new standard for your Blazor production applications. Refer to [this section](https://blazor.syncfusion.com/documentation/nuget-packages/#benefits-of-using-individual-nuget-packages) to know the benefits of the individual NuGet packages.

1. Now, install **Syncfusion.Blazor.Calendars** NuGet package to the new application using the `NuGet Package Manager`. Refer to the [Individual NuGet Packages](https://blazor.syncfusion.com/documentation/nuget-packages/) section for the available NuGet packages.

    ![nuget explorer](images/mac-server-nuget-explorer.png)

2. Search **Syncfusion.Blazor.Calendars** keyword in the Browse tab and install **Syncfusion.Blazor.Calendars** NuGet package in the application.

3. Once the installation process is completed, the Syncfusion Blazor Calendars package will be installed in the project.

4. Add the Syncfusion bootstrap4 theme in the `<head>` element of the **~/Pages/_Host.cshtml** page.

{% tabs %}

{% highlight HTML %}

    <head>
        ....
        ....
        <link href="_content/Syncfusion.Blazor.Themes/bootstrap4.css" rel="stylesheet" />
    </head>

{% endhighlight %}

{% endtabs %}

    > Warning: `Syncfusion.Blazor` package should not be installed along with [individual NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages/). Hence, you have to add the above `Syncfusion.Blazor.Themes` static web assets (styles) in the application.

### Using Syncfusion.Blazor NuGet Package [Old standard]

> Warning: If you prefer the above new standard (individual NuGet packages), then skip this section. Using both old and new standards in the same application will throw ambiguous compilation errors.

1. Now, install **Syncfusion.Blazor** NuGet package to the newly created application by using the `NuGet Package Manager`. Right-click the project, and then select Manage NuGet Packages.

    ![nuget explorer](images/mac-server-nuget-explorer.png)

2. Search **Syncfusion.Blazor** keyword in the Browse tab and install **Syncfusion.Blazor** NuGet package in the application.

    ![select nuget](images/mac-server-sync-pack.png)

3. The Syncfusion Blazor package will be installed in the project once the installation process is completed.

4. Add the Syncfusion bootstrap4 theme in the `<head>` element of the **~/Pages/_Host.html** page.

{% tabs %}

{% highlight HTML %}

    <head>
        ....
        ....
        <link href="_content/Syncfusion.Blazor.Themes/bootstrap4.css" rel="stylesheet" />
    </head>

{% endhighlight %}

{% endtabs %}

    > **Note:** The same theme file can be referred through the CDN version by using [https://cdn.syncfusion.com/blazor/{:version:}/styles/bootstrap4.css](https://cdn.syncfusion.com/blazor/18.3.47/styles/bootstrap4.css).

## Adding Syncfusion Blazor component and running the application

1. Open **~/_Imports.razor** file and import the `Syncfusion.Blazor`.

{% tabs %}

{% highlight C# %}

    @using Syncfusion.Blazor
    @using Syncfusion.Blazor.Calendars

{% endhighlight %}

{% endtabs %}

2. Open the **~/Startup.cs** file and register the Syncfusion Blazor Service.

{% tabs %}

{% highlight C# %}

    using Syncfusion.Blazor;

    namespace WebApplication1
    {
        public class Startup
        {
            public void ConfigureServices(IServiceCollection services)
            {
                ....
                ....
                services.AddSyncfusionBlazor();
            }
        }
    }

{% endhighlight %}

{% endtabs %}
3. Now, add the Syncfusion Blazor components in any .razor file in the `~/Pages` folder. For example, the Calendar component is added in the **~/Pages/Index.razor** page.

{% tabs %}

{% highlight C# %}

    <SfCalendar TValue="DateTime"></SfCalendar>

{% endhighlight %}

{% endtabs %}

4. Run the application, the Syncfusion Blazor Calendar component will be rendered in the default web browser.

    ![output](images/mac-output.png)
