---
layout: post
title: Getting started with Syncfusion Smart TextArea Component in Blazor Web App
description: Checkout and learn about getting started with Blazor Smart TextArea component in Blazor Web App.
platform: Blazor
control: Smart TextArea
documentation: ug
---

# Getting Started with Smart TextArea in Blazor Web App

This section briefly explains about how to include [Blazor Smart TextArea](https://www.syncfusion.com/blazor-components/blazor-smartpaste-button) component in your Blazor Web App using [Visual Studio](https://visualstudio.microsoft.com/vs/).

## Prerequisites

* [System requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements)
* [OpenAI](https://platform.openai.com/api-keys) or [Azure OpenAI Account](https://learn.microsoft.com/en-us/azure/ai-services/openai/how-to/create-resource)

N> As of now, Syncfusion Blazor Smart Components are currently compatible with both OpenAI and Azure OpenAI configurations.

## Create a new Blazor Web App

You can create a **Blazor Web App** using Visual Studio 2022 via [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-8.0) or the [Syncfusion Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-integration/template-studio).

N> As of now, Syncfusion Blazor Smart components are fully compatible with Server Interactivity mode Apps.

## Install Syncfusion Blazor SmartComponents and Themes NuGet in the App

To add **Blazor Smart TextArea** component in the app, open the NuGet package manager in Visual Studio (*Tools → NuGet Package Manager → Manage NuGet Packages for Solution*), search and install [Syncfusion.Blazor.SmartComponents](https://www.nuget.org/packages?q=Syncfusion.Blazor.SmartComponents) and [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/).

Alternatively, you can utilize the following package manager command to achieve the same.

{% tabs %}
{% highlight C# tabtitle="Package Manager" %}

Install-Package Syncfusion.Blazor.SmartComponents -Version {{ site.releaseversion }}
Install-Package Syncfusion.Blazor.Themes -Version {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

N> Syncfusion Blazor components are available in [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). Refer to [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for available NuGet packages list with component details.

## Register Syncfusion Blazor Service

Open **~/_Imports.razor** file and import the `Syncfusion.Blazor` and `Syncfusion.Blazor.SmartComponents` namespace .

```cshtml

@using Syncfusion.Blazor
@using Syncfusion.Blazor.SmartComponents

```

Now, register the Syncfusion Blazor Service in the **~/Program.cs** file of your Blazor Web App.

```cshtml

....
using Syncfusion.Blazor;
....
builder.Services.AddSyncfusionBlazor();
....

```

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

If you are using **OpenAI** and [create an API key](https://platform.openai.com/docs/quickstart/create-and-export-an-api-key), leave the `endpoint` as `""`. The value for `deploymentName` is the [models](https://platform.openai.com/docs/models/) you wish to use (e.g., `gpt-3.5-turbo`, `gpt-4`, etc.).

## Add stylesheet and script resources

The theme stylesheet and script can be accessed from NuGet through [Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets). Include the stylesheet reference in the `<head>` section and the script reference at the end of the `<body>` in the **~/Components/App.razor** file as shown below:

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

## Add Syncfusion Blazor Smart TextArea component

Add the Syncfusion Blazor Smart TextArea component with form components in the **~Pages/.razor** file.

```cshtml
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
```

Here,

**UserRole**: This attribute is `required` to defines the context of the autocompletion based on the role of the person typing.
**UserPhrases**: This attribute is optional to provides predefined expressions that align with User/application's tone and frequently used content.

* Press <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS) to launch the application. This will render the Syncfusion Blazor Smart TextArea component in your default web browser.

* Type 'To investigate' to experience instant sentence autocompletion.

![Syncfusion Smart TextArea - Output](images/smart-textarea-userphrases.gif)

N> [View Sample in GitHub](https://github.com/search?q=org%3Asyncfusion%20smart-ai-samples&type=repositories).

## See Also

* [Getting Started with Syncfusion Blazor Smart TextArea Blazor Server App](https://blazor.syncfusion.com/documentation/)
