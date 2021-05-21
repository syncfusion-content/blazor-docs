---
layout: post
title: Getting started with Syncfusion Blazor - Blazor WebAssembly App in .NET Core CLI
description: Check out the documentation for Getting started with Syncfusion Blazor
platform: Blazor
component: Common
documentation: ug
---

<!-- markdownlint-disable MD024 -->

# Getting started with Syncfusion Blazor Components in Blazor WebAssembly App using .NET Core CLI

This article provides a step-by-step introduction to configure Syncfusion Blazor setup, and also to build and run a simple Blazor WebAssembly application using [.NET Core CLI](https://dotnet.microsoft.com/download/dotnet-core/3.1).

> **Note:** Starting with version 17.4.0.39 (2019 Volume 4), you need to include a valid license key (either paid or trial key) within your applications. Please refer to this [help topic](https://help.syncfusion.com/common/essential-studio/licensing/license-key#blazor) for more information.

## Prerequisites

* [.NET Core SDK 3.1.8](https://dotnet.microsoft.com/download/dotnet-core/3.1) / [.NET 5.0 SDK](https://dotnet.microsoft.com/download/dotnet/5.0)

## Create a Blazor WebAssembly project using .NET Core CLI

1. Run the following command line to create a new Blazor WebAssembly application.

{% tabs %}

{% highlight BASH %}

        dotnet new blazorwasm -o WebApplication1
        cd WebApplication1

{% endhighlight %}

{% endtabs %}
    > If you have installed multiple SDK versions and need any specific framework version (net5.0/netcoreapp3.1) project, then add `-f` flag along with `dotnet new blazorwasm` comment. Refer [here](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-new#blazorwasm) for the available options.

## Installing Syncfusion Blazor packages in the application

You can use any one of the below standards to install the Syncfusion Blazor library in your application.

### Using Syncfusion Blazor components individual NuGet Packages [New standard]

> Starting with Volume 4, 2020 (v18.4.0.30) release, Syncfusion provides [individual NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages/) for our Syncfusion Blazor components. We highly recommend this new standard for your Blazor production applications. Refer to [this section](https://blazor.syncfusion.com/documentation/nuget-packages/#benefits-of-using-individual-nuget-packages) to know the benefits of the individual NuGet packages.

1. Now, add **Syncfusion.Blazor.Calendars** NuGet package to the new application using the following command line. For more details about available NuGet packages, refer to the [individual NuGet Packages](https://blazor.syncfusion.com/documentation/nuget-packages/) documentation.

{% tabs %}

{% highlight BASH %}

        dotnet add package Syncfusion.Blazor.Calendars -v '{:nuget-version:}'
        dotnet restore

{% endhighlight %}

{% endtabs %}

2. The Syncfusion Blazor Calendars package will be included in the newly created project once the installation process is completed.

3. Add the Syncfusion bootstrap4 theme in the `<head>` element of the **~/wwwroot/index.html** page.

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

1. Now, add **Syncfusion.Blazor** NuGet package to the new application using the following command line.

{% tabs %}

{% highlight BASH %}

        dotnet add package Syncfusion.Blazor -v '{:nuget-version:}'
        dotnet restore

{% endhighlight %}

{% endtabs %}

2. The Syncfusion Blazor package will be included in the newly created project once the installation process is completed.

3. Add the Syncfusion bootstrap4 theme in the `<head>` element of the **~/wwwroot/index.html** page.

{% tabs %}

{% highlight HTML %}

    <head>
        ....
        ....
         <link href="_content/Syncfusion.Blazor/styles/bootstrap4.css" rel="stylesheet" />
    </head>

{% endhighlight %}

{% endtabs %}

    > **Note:** The same theme file can be referred through the CDN version by using [https://cdn.syncfusion.com/blazor/{:version:}/styles/bootstrap4.css](https://cdn.syncfusion.com/blazor/18.4.30/styles/bootstrap4.css).

## Adding Syncfusion Blazor component and running the application

1. Open **~/_Imports.razor** file and import the `Syncfusion.Blazor` namespace.

{% tabs %}

{% highlight C# %}

    @using Syncfusion.Blazor
    @using Syncfusion.Blazor.Calendars

{% endhighlight %}

{% endtabs %}

2. Open the **~/Program.cs** file and register the Syncfusion Blazor Service.

{% tabs %}

{% highlight C# %}

    using Syncfusion.Blazor;

    namespace WebApplication1
    {
        public class Program
        {
            public static async Task Main(string[] args)
            {
                ....
                ....
                builder.Services.AddSyncfusionBlazor();
                await builder.Build().RunAsync();
            }
        }
    }

{% endhighlight %}

{% endtabs %}

3. Now, add the Syncfusion Blazor component in any .razor file in the `~/Pages` folder. For example, the calendar component is added in the **~/Pages/Index.razor** page.

{% tabs %}

{% highlight C# %}

    <SfCalendar TValue="DateTime"></SfCalendar>

{% endhighlight %}

{% endtabs %}

4. Run `dotnet run` command to run the application. The Syncfusion Blazor Calendar component will be rendered in the web browser.

    ![output](images/browser-output.png)
