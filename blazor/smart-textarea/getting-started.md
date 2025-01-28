---
layout: post
title: Getting Started with Blazor Smart TextArea | Syncfusion
description: Checkout and learn here all about Getting started with Syncfusion Blazor Smart TextArea component in Blazor Server App and more.
platform: Blazor
control: Smart TextArea
documentation: ug
---

# Getting Started with Smart TextArea Component

This section briefly explains about how to include [Blazor Smart TextArea](https://www.syncfusion.com/blazor-components/blazor-smart-textarea) component in your Blazor Server App using Visual Studio.

## Prerequisites

* [System requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements)
* OpenAI or Azure OpenAI Account

N> Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Smart Components are compatible with both `OpenAI` and `Azure OpenAI`, and fully support Server Interactivity mode apps.

{% tabcontents %}

{% tabcontent Visual Studio %}

## Create a new Blazor App in Visual Studio

You can create a **Blazor Server App** using Visual Studio via [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-7.0) or the [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-integration/template-studio).

## Install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor SmartComponents and Themes NuGet in the App

To add **Blazor Smart TextArea** component in the app, open the NuGet package manager in Visual Studio (*Tools → NuGet Package Manager → Manage NuGet Packages for Solution*), search and install [Syncfusion.Blazor.SmartComponents](https://www.nuget.org/packages?q=Syncfusion.Blazor.SmartComponents) and [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/). Alternatively, you can utilize the following package manager command to achieve the same.

{% tabs %}
{% highlight C# tabtitle="Package Manager" %}

Install-Package Syncfusion.Blazor.SmartComponents -Version {{ site.releaseversion }}
Install-Package Syncfusion.Blazor.Themes -Version {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

N> Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components are available in [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). Refer to [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for available NuGet packages list with component details.

{% endtabcontent %}

{% tabcontent Visual Studio Code %}

## Create a new Blazor App in Visual Studio Code

You can create a **Blazor Server App** or **Blazor WebAssembly App** using Visual Studio Code via [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-7.0&pivots=vsc) or the [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-code-integration/create-project).

Alternatively, you can create a Server or WebAssembly application using the following command in the terminal(<kbd>Ctrl</kbd>+<kbd>`</kbd>).

{% tabs %}

{% highlight c# tabtitle="Blazor Server App" %}

dotnet new blazorserver -o BlazorApp
cd BlazorApp

{% endhighlight %}

{% highlight c# tabtitle="Blazor WASM App" %}

dotnet new blazorwasm -o BlazorApp
cd BlazorApp

{% endhighlight %}

{% endtabs %}

## Install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor SmartComponents and Themes NuGet in the App

* Press <kbd>Ctrl</kbd>+<kbd>`</kbd> to open the integrated terminal in Visual Studio Code.
* Ensure you’re in the project root directory where your `.csproj` file is located.
* Run the following command to install a [Syncfusion.Blazor.SmartComponents](https://www.nuget.org/packages?q=Syncfusion.Blazor.SmartComponents) and [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/) NuGet package and ensure all dependencies are installed.

{% tabs %}

{% highlight c# tabtitle="Package Manager" %}

dotnet add package Syncfusion.Blazor.SmartComponents -v {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Themes -v {{ site.releaseversion }}
dotnet restore

{% endhighlight %}

{% endtabs %}

N> Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components are available in [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). Refer to [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for available NuGet packages list with component details.

{% endtabcontent %}

{% endtabcontents %}

## Register Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Service

Open **~/_Imports.razor** file and import the `Syncfusion.Blazor` and `Syncfusion.Blazor.SmartComponents` namespace.

{% tabs %}
{% highlight razor tabtitle="~/_Imports.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.SmartComponents

{% endhighlight %}
{% endtabs %}

Now, register the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Service in the **~/Program.cs** file of your Blazor Server App.

{% tabs %}
{% highlight C# tabtitle="Blazor Server App" hl_lines="3 10" %}

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSyncfusionBlazor();

var app = builder.Build();
....

{% endhighlight %}
{% endtabs %}

## Configure AI Service

To configure the AI service, add the following settings to the **~/Program.cs** file in your Blazor Server app.

{% tabs %}
{% highlight C# tabtitle="Blazor Server App" hl_lines="7 8 9 11 12 13" %}

using Syncfusion.Blazor.SmartComponents;
var builder = WebApplication.CreateBuilder(args);

....

builder.Services.AddSyncfusionBlazor();

string apiKey = "api-key";
string deploymentName = "deployment-name";
string endpoint = "end point url";

builder.Services.AddSyncfusionSmartComponents()
.ConfigureCredentials(new AIServiceCredentials(apiKey, deploymentName, endpoint))
.InjectOpenAIInference();

var app = builder.Build();
....

{% endhighlight %}
{% endtabs %}

Here,

* **apiKey**: "OpenAI or Azure OpenAI API Key";
* **deploymentName**: "Azure OpenAI deployment name";
* **endpoint**: "Azure OpenAI deployment end point URL";

For **Azure OpenAI**, first [deploy an Azure OpenAI Service resource and model](https://learn.microsoft.com/en-us/azure/ai-services/openai/how-to/create-resource), then values for `apiKey`, `deploymentName` and `endpoint` will all be provided to you.

>N From version 28.2.33, the Azure.AI.OpenAI package has been removed from the SmartComponents dependency. To use Azure OpenAI, please install the [Azure.AI.OpenAI](https://www.nuget.org/packages/Azure.AI.OpenAI) package separately in your Blazor application.

If you are using **OpenAI**, create an API key and place it at `apiKey`, leave the `endpoint` as `""`. The value for `deploymentName` is the model you wish to use (e.g., `gpt-3.5-turbo`, `gpt-4`, etc.).

## Add stylesheet and script resources

The theme stylesheet and script can be accessed from NuGet through [Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets). Reference the stylesheet and script in the `<head>` of the main page as follows:

* For **.NET 6** Blazor Server app, include it in **~/Pages/_Layout.cshtml** file.

* For **.NET 9 and .NET 8** Blazor Server app, include it in the **~/Components/App.razor** file.

```html
<head>
    ....
    <link href="_content/Syncfusion.Blazor.Themes/tailwind.css" rel="stylesheet" />
</head>

<body>
    ....
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
</body>
```

N> Check out the [Blazor Themes](https://blazor.syncfusion.com/documentation/appearance/themes) topic to discover various methods ([Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets), [CDN](https://blazor.syncfusion.com/documentation/appearance/themes#cdn-reference), and [CRG](https://blazor.syncfusion.com/documentation/common/custom-resource-generator)) for referencing themes in your Blazor application. Also, check out the [Adding Script Reference](https://blazor.syncfusion.com/documentation/common/adding-script-references) topic to learn different approaches for adding script references in your Blazor application.

## Add Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Smart TextArea component

Add the Syncfusion<sup style="font-size:70%">&reg;</sup> **Blazor Smart TextArea** component in the **~/Pages/Index.razor** file.

{% tabs %}
{% highlight razor tabtitle="~/Index.razor" %}

@using Syncfusion.Blazor.SmartComponents

<SfSmartTextArea UserRole="@userRole" UserPhrases="@userPhrases" Placeholder="Enter your queries here" @bind-Value="prompt" Width="75%" RowCount="5">
</SfSmartTextArea>

@code {
    private string? prompt;
    public string userRole = "Maintainer of an open-source project replying to GitHub issues";
    public string[] userPhrases = [
        "Thank you for contacting us.",
        "To investigate, We will need a reproducible example as a public Git repository.",
        "Could you please post a screenshot of NEED_INFO?",
        "This sounds like a usage question. This issue tracker is intended for bugs and feature proposals. Unfortunately, we don't have the capacity to answer general usage questions and would recommend StackOverflow for a faster response.",
        "We do not accept ZIP files as reproducible examples.",
        "Bug report: File not found error occurred in NEED_INFO"
    ];
}

{% endhighlight %}
{% endtabs %}

* Press <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS) to launch the application. This will render the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Smart TextArea component in your default web browser.

* Type 'To investigate' to experience instant sentence autocompletion.

![Syncfusion Smart TextArea - Output](images/smart-textarea-userphrases.gif)

N> [View Sample in GitHub](https://github.com/syncfusion/smart-ai-samples).

## See also

* [Getting Started with Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Smart TextArea in Blazor Web App](https://blazor.syncfusion.com/documentation/)
