---
layout: post
title: Getting Started with Blazor Media Query in Blazor Web App | Syncfusion®
description: Check out the documentation for getting started with Blazor Media Query Components in Blazor Web App.
platform: Blazor
control: Media Query
documentation: ug
---

# Getting Started with Blazor Media Query in Blazor Web App

This section briefly explains about how to include [Blazor Media Query](https://www.syncfusion.com/blazor-components/blazor-media-query) component in your Blazor Web App using [Visual Studio](https://visualstudio.microsoft.com/vs/), [Visual Studio Code](https://code.visualstudio.com/), and the [.NET CLI](https://learn.microsoft.com/en-us/dotnet/core/tools/).

### Create a new Blazor Web App

{% tabcontents %}

{% tabcontent Visual Studio %}

Create a **Blazor Web App** using Visual Studio via [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-10.0&pivots=vs) or the [Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-integration/template-studio). For detailed instructions, refer to the [Blazor Web App Getting Started](https://blazor.syncfusion.com/documentation/getting-started/blazor-web-app) documentation.

{% endtabcontent %}

{% tabcontent Visual Studio Code %}

Run the following command to create a new Blazor Web App.

{% tabs %}
{% highlight razor tabtitle="Terminal" %}

dotnet new blazor -o BlazorWebApp --interactivity Auto

{% endhighlight %}
{% endtabs %}

Alternatively, create a **Blazor Web App** using Visual Studio Code via [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-10.0&pivots=vsc), the [Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-code-integration/create-project), or the [C# Dev Kit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit) extension.

{% endtabcontent %}

{% tabcontent .NET CLI %}

Run the following command to create a new Blazor Web App.

{% tabs %}
{% highlight razor tabtitle="Command Prompt" %}

dotnet new blazor -o BlazorWebApp --interactivity Auto

{% endhighlight %}
{% endtabs %}

{% endtabcontent %}

{% endtabcontents %}

N> Configure the appropriate [Interactive render mode](https://learn.microsoft.com/en-us/aspnet/core/blazor/components/render-modes?view=aspnetcore-10.0#render-modes) and [Interactivity location](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-10.0&pivots=vs) while creating a Blazor Web App. For detailed information, refer to the [interactive render mode documentation](https://blazor.syncfusion.com/documentation/common/interactive-render-mode).

### Install the required Blazor packages

Install [Syncfusion.Blazor.Core](https://www.nuget.org/packages/Syncfusion.Blazor.Core) and [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/) NuGet packages. All Syncfusion Blazor packages are available on [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). See the [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for details. If using the `WebAssembly` or `Auto` render modes in the Blazor Web App, install these packages in the `.Client` project.

{% tabcontents %}

{% tabcontent Visual Studio %}

1. Go to *Tools → NuGet Package Manager → Manage NuGet Packages for Solution*.
2. Search the required NuGet packages (`Syncfusion.Blazor.Core` and `Syncfusion.Blazor.Themes`) and install them.

Alternatively, you can install the same packages using the Package Manager Console with the following commands.

{% tabs %}
{% highlight razor tabtitle="Package Manager Console" %}

Install-Package Syncfusion.Blazor.Core -Version {{ site.releaseversion }}
Install-Package Syncfusion.Blazor.Themes -Version {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

{% endtabcontent %}

{% tabcontent Visual Studio Code %}

Open the terminal and run the following commands.

{% tabs %}
{% highlight razor tabtitle="Terminal" %}

dotnet add package Syncfusion.Blazor.Core -v {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Themes -v {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

{% endtabcontent %}

{% tabcontent .NET CLI %}

Open the command prompt and run the following commands.

{% tabs %}
{% highlight razor tabtitle="Command Prompt" %}

dotnet add package Syncfusion.Blazor.Core -v {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Themes -v {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

{% endtabcontent %}

{% endtabcontents %}

N> All Syncfusion Blazor packages are available on [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). See the [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for details.

### Add import namespaces

After the packages are installed, open the **~/_Imports.razor** file in the client project and import the `Syncfusion.Blazor` namespace.

{% tabs %}
{% highlight C# tabtitle="~/_Imports.razor" %}

@using Syncfusion.Blazor

{% endhighlight %}
{% endtabs %}

### Register the Blazor service

Open the **Program.cs** file in Blazor Web App and register the Blazor service. If the **Interactive Render Mode** is set to `WebAssembly` or `Auto`, register the Blazor service in **Program.cs** files of both the server and client projects in your Blazor Web App.

{% tabs %}
{% highlight c# tabtitle="Program.cs" %}

....
using Syncfusion.Blazor;
....
builder.Services.AddSyncfusionBlazor();
....

{% endhighlight %}
{% endtabs %}

### Add stylesheet and script resources

The theme stylesheet and script can be accessed from NuGet through [Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets). Include the [stylesheet](https://blazor.syncfusion.com/documentation/appearance/themes) and [script references](https://blazor.syncfusion.com/documentation/common/adding-script-references) in the **App.razor** file.
 
{% tabs %}
{% highlight html tabtitle="App.razor" %}
 
...
<link href="_content/Syncfusion.Blazor.Themes/fluent2.css" rel="stylesheet" />
...
<script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
 
{% endhighlight %}
{% endtabs %}

N> Check out the [Blazor Themes](https://blazor.syncfusion.com/documentation/appearance/themes) topic to discover various methods ([Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets), [CDN](https://blazor.syncfusion.com/documentation/appearance/themes#cdn-reference), and [CRG](https://blazor.syncfusion.com/documentation/common/custom-resource-generator)) for referencing themes in your Blazor application. Also, check out the [Adding Script Reference](https://blazor.syncfusion.com/documentation/common/adding-script-references) topic to learn different approaches for adding script references in your Blazor application.

### Add Blazor Media Query component

Open a Razor file located in the **~/Pages/*.razor** (for example, **Home.razor**) and add the [Blazor Media Query](https://www.syncfusion.com/blazor-components/blazor-media-query) component inside the razor file.

N> If the interactivity location is set to `Per page/component` in the Web App, define a render mode at the top of the razor file. (For example, `InteractiveServer`, `InteractiveWebAssembly` or `InteractiveAuto`). If the **Interactivity** is set to `Global` with `Auto` or `WebAssembly`, the render mode is automatically configured in the `App.razor` file by default.

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

@rendermode InteractiveAuto

@using Syncfusion.Blazor

<SfMediaQuery @bind-ActiveBreakPoint="activeBreakpoint"></SfMediaQuery>
<br />
@if (activeBreakpoint == "Small")
{
    deviceSize = "small-device";
}
else if (activeBreakpoint == "Medium")
{
    deviceSize = "medium-device";
}
else
{
    deviceSize = "";
}

<div class="mediaquery-demo @deviceSize">
    <div class="header e-skeleton e-skeleton-text">
        <div class="search-box e-skeleton e-skeleton-text"></div>
    </div>
    <div class="banner e-skeleton e-skeleton-text e-shimmer-pulse"></div>
    <div class="main-container">
        <ul>
            <li>
                <div class="content e-skeleton e-skeleton-text e-shimmer-pulse"></div>
                <div class="title e-skeleton e-skeleton-text e-shimmer-pulse"></div>
                <p class="e-skeleton e-skeleton-text e-shimmer-pulse"></p>
            </li>
            <li>
                <div class="content e-skeleton e-skeleton-text e-shimmer-pulse"></div>
                <div class="title e-skeleton e-skeleton-text e-shimmer-pulse"></div>
                <p class="e-skeleton e-skeleton-text e-shimmer-pulse"></p>
            </li>
        </ul>
    </div>
    <div class="footer e-skeleton e-skeleton-text"></div>
</div>

@code {
    private string deviceSize { get; set; }
    private string activeBreakpoint { get; set; }
}
<style>
    .mediaquery-demo {
        height: 715px;
        margin: 0 10%;
        border: 2px solid #f3f2f1;
        border-top-width: 0px;
        border-radius: 4px;
        overflow: hidden;
    }

    .mediaquery-demo .e-skeleton {
        display: block;
    }

    .mediaquery-demo .header {
        height: 6vh;
        text-align: center;
        overflow: visible;
    }

        .mediaquery-demo .header .search-box {
            width: 25%;
            height: 55%;
            margin-top: 1.5vh;
            display: inline-block;
            border-radius: 7px;
            float: right;
            margin-right: 3%;
            background-color: white;
        }

    .mediaquery-demo .banner {
        height: 35%;
        margin: 1% 8%;
    }

    .mediaquery-demo .main-container {
        margin: 0 8%;
        height: 35%;
    }

    .mediaquery-demo .main-container ul {
        list-style: none;
        display: flex;
        height: 100%;
        padding: 0;
        justify-content: space-between;
        padding-top: 20px;
    }

        .mediaquery-demo .main-container ul li {
            width: 49%;
        }

    .mediaquery-demo .main-container li .content {
        height: 60%;
    }

    .mediaquery-demo .main-container li .title,
    .mediaquery-demo .main-container li p {
        width: 50%;
        height: 7%;
        margin-top: 3%;
    }

    .mediaquery-demo .main-container li p {
        width: 80%;
    }

    .mediaquery-demo .footer {
        height: 20%;
        margin: 0% 8%;
    }

    .mediaquery-demo.medium-device .header .search-box {
        width: 50%;
        float: none;
        margin-right: 0px;
    }

    .mediaquery-demo.medium-device .banner,
    .mediaquery-demo.medium-device .main-container,
    .mediaquery-demo.medium-device .footer {
        margin: 0px;
    }

    .mediaquery-demo.medium-device .banner {
        margin-top: 1%;
    }

    .mediaquery-demo.medium-device .main-container {
        height: 42%;
    }

    .mediaquery-demo.medium-device .main-container ul {
        flex-direction: column;
    }

    .mediaquery-demo.medium-device .main-container ul li {
        height: 50%;
        display: flex;
        margin-bottom: 2%;
        margin-left: 5%;
        width: 100%;
    }

    .mediaquery-demo.medium-device .main-container li .content {
        height: auto;
        width: 30%;
    }

    .mediaquery-demo.medium-device .main-container li .title,
    .mediaquery-demo.medium-device .main-container li p {
        height: 24%;
    }

    .mediaquery-demo.medium-device .main-container li .title {
        margin-left: 5%;
        width: 25%;
        margin-top: 0;
    }

    .mediaquery-demo.medium-device .main-container li p {
        margin-top: 8%;
        margin-left: -25%;
        width: 55%;
    }

    .mediaquery-demo.small-device .header .search-box {
        text-align: center;
        float: none;
        width: 60%;
        height: 65%;
        margin-top: 8vh;
        background-color: inherit;
    }

    .mediaquery-demo.small-device .banner,
    .mediaquery-demo.small-device .main-container,
    .mediaquery-demo.small-device .footer {
        margin: 0px;
        height: 20%;
    }

    .mediaquery-demo.small-device .banner {
        margin: 8vh 0 0;
    }

    .mediaquery-demo.small-device .main-container {
        height: 48%;
    }

    .mediaquery-demo.small-device .main-container ul {
        display: block;
    }

    .mediaquery-demo.small-device .main-container ul li {
        height: 50%;
        display: block;
        width: 90%;
        margin: 0 auto;
    }

    .mediaquery-demo.small-device .main-container li .content {
        height: 40%;
        width: auto;
    }

    .mediaquery-demo.small-device .main-container li .title {
        width: 40%;
        height: 10%;
    }

    .mediaquery-demo.small-device .main-container li p {
        width: auto;
        height: 10%;
    }
</style>

{% endhighlight %}
{% endtabs %}

**Run the application**

{% tabcontents %}

{% tabcontent Visual Studio %}

Press <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS) to launch the application. The Blazor Media Query component will render in your default web browser.

{% endtabcontent %}

{% tabcontent Visual Studio Code %}

Open the terminal and navigate to the main project folder (for example, `BlazorWebApp`) and run the following command.

{% tabs %}
{% highlight razor tabtitle="Terminal" %}

cd BlazorWebApp
dotnet run

{% endhighlight %}
{% endtabs %}

{% endtabcontent %}

{% tabcontent .NET CLI %}

Open the command prompt and navigate to the main project folder (for example, `BlazorWebApp`) and run the following command.

{% tabs %}
{% highlight razor tabtitle="Command Prompt" %}

cd BlazorWebApp
dotnet run

{% endhighlight %}
{% endtabs %}

{% endtabcontent %}

{% endtabcontents %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rZBzXMKtikurjnwB?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor Media Query Component](images/blazor-media-query.png)" %}

N> [View Sample in GitHub](https://github.com/SyncfusionExamples/Blazor-Getting-Started-Examples/tree/main/MediaQuery).

### See also

* [Getting Started with Blazor for Client-Side in .NET Core CLI](https://blazor.syncfusion.com/documentation/getting-started/blazor-webassembly-dotnet-cli)
* [Getting Started with Blazor for Server-side in Visual Studio](https://blazor.syncfusion.com/documentation/getting-started/blazor-server-side-visual-studio)
* [Getting Started with Blazor for Server-Side in .NET Core CLI](https://blazor.syncfusion.com/documentation/getting-started/blazor-server-side-dotnet-cli)