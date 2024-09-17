---
layout: post
title: Getting Started with Blazor Smart Paste Button Component | Syncfusion
description: Checkout and learn about getting started with Blazor Smart Paste Button component in Blazor Server App.
platform: Blazor
control: Smart Paste Button
documentation: ug
---

# Getting Started with Blazor Smart Paste Button Component

This section briefly explains about how to include [Blazor Smart Paste Button](https://www.syncfusion.com/blazor-components/blazor-smartpaste-button) component in your Blazor Server App using Visual Studio.

## Prerequisites

* [System requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements)
* [OpenAI](https://platform.openai.com/api-keys) or [Azure OpenAI Account](https://learn.microsoft.com/en-us/azure/ai-services/openai/how-to/create-resource)

N> Blazor Smart Components are currently compatible with both OpenAI and Azure OpenAI configurations.

## Create a new Blazor App in Visual Studio

You can create a **Blazor Server App** using Visual Studio via [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-7.0) or the [Syncfusion Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-integration/template-studio).

N> As of now, Syncfusion Blazor Smart components are fully compatible with Server App.

## Install Syncfusion Blazor SmartComponents and Themes NuGets in the App

To add **Blazor Smart Paste Button** component in the app, open the NuGet package manager in Visual Studio (*Tools → NuGet Package Manager → Manage NuGet Packages for Solution*), search and install [Syncfusion.Blazor.SmartComponents](https://www.nuget.org/packages/Syncfusion.Blazor.SmartComponents/) and [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/). Alternatively, you can utilize the following package manager command to achieve the same.

{% tabs %}
{% highlight C# tabtitle="Package Manager" %}

Install-Package Syncfusion.Blazor.SmartComponents -Version {{ site.releaseversion }}
Install-Package Syncfusion.Blazor.Themes -Version {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

N> Syncfusion Blazor components are available in [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). Refer to [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for available NuGet packages list with component details.

## Register Syncfusion Blazor Service

Open **~/_Imports.razor** file and import the `Syncfusion.Blazor` and `Syncfusion.Blazor.SmartComponents` namespace.

{% tabs %}
{% highlight razor tabtitle="~/_Imports.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.SmartComponents

{% endhighlight %}
{% endtabs %}

Now, register the Syncfusion Blazor Service in the **~/Program.cs** file of your Blazor Server App.

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

If you are using **OpenAI** and [create an API key](https://platform.openai.com/api-keys), leave the `endpoint` as `""`. The value for `deploymentName` is the [model](https://platform.openai.com/docs/models/) you wish to use (e.g., `gpt-3.5-turbo`, `gpt-4`, etc.).

## Add stylesheet and script resources

The theme stylesheet and script can be accessed from NuGet through [Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets). Reference the stylesheet and script in the `<head>` of the main page as follows:

* For **.NET 6** Blazor Server app, include it in **~/Pages/_Layout.cshtml** file.

* For **.NET 7** Blazor Server app, include it in the **~/Pages/_Host.cshtml** file.

```html
<head>
    ....
    <link href="_content/Syncfusion.Blazor.Themes/tailwind.css" rel="stylesheet" />
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
</head>
```

N> Check out the [Blazor Themes](https://blazor.syncfusion.com/documentation/appearance/themes) topic to discover various methods ([Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets), [CDN](https://blazor.syncfusion.com/documentation/appearance/themes#cdn-reference), and [CRG](https://blazor.syncfusion.com/documentation/common/custom-resource-generator)) for referencing themes in your Blazor application. Also, check out the [Adding Script Reference](https://blazor.syncfusion.com/documentation/common/adding-script-references) topic to learn different approaches for adding script references in your Blazor application.

## Add Syncfusion Blazor Smart Paste Button component

Add the Syncfusion Blazor Smart Paste Button component with form components in the **~/Pages/Index.razor** file.

```cshtml
<EditForm Model="@formModel">
    <p>Name: <InputText @bind-Value="@formModel.Name" /></p>
    <p>Address line 1: <InputText @bind-Value="@formModel.AddressLine1" /></p>
    <p>City: <InputText @bind-Value="@formModel.City" /></p>
    <p>Zip/postal code: <InputText @bind-Value="@formModel.Zip" /></p>

    <button type="submit">Submit</button>
    <SfSmartPasteButton>Smart Paste</SfSmartPasteButton>
</EditForm>

@code {
    private FormModel formModel = new FormModel();

    public class FormModel
    {
        public string? Name { get; set; }
        public string? AddressLine1 { get; set; }
        public string? City { get; set; }
        public string? Zip { get; set; }
    }
}
```

* Press <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS) to launch the application. This will render the Syncfusion Blazor Smart Paste Button component in your default web browser.

* Copy the sample content and click on Smart Paste to see how the form is instantly filled.

N> [View Sample in GitHub](https://github.com/syncfusion/smart-ai-samples/tree/master/blazor).

## See Also

* [Getting Started with Syncfusion Blazor Smart Paste Button Blazor Web App](https://blazor.syncfusion.com/documentation/smart-paste/getting-started-webapp)
